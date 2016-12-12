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

/// <summary>
/// Descripción breve de RendicionEgresoColl
/// </summary>
/// 

public class RendicionEgresoColl
{
    public RendicionEgresoColl()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    private string SQL_Instruccion(string Institucion, string CodProyecto, string Proyecto, int iAnoMes, int Busca, int RolId, int CodDireccionRegional, int CodRegion, int UserId, out List<DbParameter> listDbParameter)
    {
        listDbParameter = new List<DbParameter>();

        string sWhere = string.Empty;
        string tSql = string.Empty;

        if (Institucion.Trim() != "")
        {
            sWhere = sWhere + " AND i.Nombre LIKE @pNombre";

            listDbParameter.Add(Conexiones.CrearParametro("@pNombre", SqlDbType.VarChar, 100, "%" + Institucion.Trim() + "%"));
        }

        if (CodProyecto.Trim() != "")
        {
            sWhere = sWhere + " AND p.CodProyecto =@pCodProyecto ";

            listDbParameter.Add(Conexiones.CrearParametro("@pCodProyecto", SqlDbType.Int, 4, Convert.ToInt32(CodProyecto)));
        }
        else
        {
            if (Proyecto.Trim() != "")
            {
                sWhere = sWhere + " AND p.Nombre LIKE @pNombreProyecto ";

                listDbParameter.Add(Conexiones.CrearParametro("@pNombreProyecto", SqlDbType.VarChar, 100, "%" + Proyecto.Trim() + "%"));
            }
        }

        if (iAnoMes != 0)
        {
            sWhere = sWhere + " AND a.AnoMes =@pAnoMes ";

            listDbParameter.Add(Conexiones.CrearParametro("@pAnoMes", SqlDbType.Int, 4, iAnoMes));
        }

        if (sWhere.Trim() != "")
            sWhere = "WHERE " + sWhere.Substring(5);
        else
            sWhere = string.Empty;

        string strFrom = string.Empty;
        string strWhere = string.Empty;

        if (!(RolId == 252 || RolId == 253 || RolId == 258 || RolId == 260 || RolId == 261 || RolId == 255 || RolId == 257 || RolId == 254 || RolId == 256 || RolId == 262 || RolId == 259 || RolId == 289))
        {
            if (CodDireccionRegional > 0)
            {
                if (sWhere.Trim() == "")
                    strWhere = " WHERE p.CodRegion =@pCodRegion ";
                else
                    strWhere = " AND p.CodRegion =@pCodRegion ";

                listDbParameter.Add(Conexiones.CrearParametro("@pCodRegion", SqlDbType.Int, 4, CodRegion));
            }
            else
            {
                strFrom += " INNER JOIN TrabajadorProyecto tp ON tp.CodProyecto = p.CodProyecto ";
                strFrom += " INNER JOIN Usuarios u ON u.ICodTrabajador = tp.ICodTrabajador ";

                if (sWhere.Trim() == "")
                    strWhere = " WHERE u.idUsuario =@pIdUsuario ";
                else
                    strWhere = " AND u.idUsuario =@pIdUsuario ";

                listDbParameter.Add(Conexiones.CrearParametro("@pIdUsuario", SqlDbType.Int, 4, UserId));
            }
        }
        sWhere += strWhere;

        tSql += "SELECT	a.IdRendicionEgreso, a.CodProyecto, a.AnoMes, a.FechaRegistro, ";
        tSql += "p.CodInstitucion, i.Nombre AS Institucion, p.Nombre as Proyecto, ";
        if (Busca == 1) // Busca
        {
            tSql += "0 as NroComprobante, cast('01-01-2006' as  datetime) as FechaComprobante, 0 as Monto, ";
            tSql += "0 as Correlativo, '' as Glosa, 0 as Nulo, 0 as IdUsuarioActualizacion, cast('01-01-2006' as  datetime) as FechaActualizacion, ";
            tSql += "0 as CodUso, '' AS Uso, 0 as CodObjetivo, '' AS Objetivo, '' as Destino, '' as NumeroCheque, ";
            tSql += "0 as CodMedioDePago, '' as MedioDePago, ";
            tSql += "Cerrado = CASE ";
            tSql += "WHEN rc.cerrado IS NULL THEN 0 ";
            tSql += "ELSE rc.Cerrado END ";

            tSql += "FROM	RendicionesEgreso a ";
            tSql += "INNER JOIN Proyectos p ";
            tSql += "ON a.CodProyecto = p.CodProyecto ";
            tSql += "LEFT JOIN Instituciones i ";
            tSql += "ON p.CodInstitucion = i.CodInstitucion ";
            tSql += "LEFT JOIN RendicionCuentas rc ";
            tSql += "ON a.CodProyecto = rc.CodProyecto AND a.AnoMes = rc.AnoMes ";

            tSql += strFrom;
            tSql += sWhere;
            tSql += " ORDER BY a.CodProyecto, a.AnoMes";
        }
        else    // Mantener
        {
            tSql += "b.NroComprobante, b.FechaComprobante, b.Monto, ";
            tSql += "b.Correlativo, b.Glosa, b.Nulo, b.IdUsuarioActualizacion, b.FechaActualizacion, ";
            tSql += "c.CodUso, c.Descripcion AS Uso, d.CodObjetivo, d.Descripcion AS Objetivo, b.Destino, b.NumeroCheque, ";
            tSql += "b.CodMedioDePago, mp.Descripcion AS MedioDePago, 0 AS Cerrado ";

            tSql += "FROM	RendicionesEgreso a ";
            tSql += "INNER JOIN RendicionesEgresoDetalle b ";
            tSql += "ON a.IdRendicionEgreso = b.IdRendicionEgreso ";
            tSql += "LEFT  JOIN parUso c ";
            tSql += "ON b.CodUso = c.CodUso ";
            tSql += "LEFT  JOIN parObjetivo d ";
            tSql += "ON c.CodObjetivo = d.CodObjetivo ";
            tSql += "LEFT  JOIN parMedioDePago mp ";
            tSql += "ON b.CodMedioDePago = mp.CodMedioDePago ";
            tSql += "INNER JOIN Proyectos p ";
            tSql += "ON a.CodProyecto = p.CodProyecto ";
            tSql += "LEFT JOIN Instituciones i ";
            tSql += "ON p.CodInstitucion = i.CodInstitucion ";

            tSql += strFrom;
            tSql += sWhere;
            tSql += " ORDER BY b.NroComprobante";
        }

        return tSql;
    }

    private string SQL_InstruccionInstitucion(string Institucion, int iAnoMes, int Busca, int RolId, int CodDireccionRegional, int CodRegion, int UserId, out List<DbParameter> listDbParameter)
    {
        listDbParameter = new List<DbParameter>();
        string sWhere = string.Empty;
        string tSql = string.Empty;

        if (Institucion.Trim() != "")
        {
            sWhere = sWhere + " AND i.CodInstitucion =@pCodInstitucion";

            listDbParameter.Add(Conexiones.CrearParametro("@pCodInstitucion", SqlDbType.Int, 4, Convert.ToInt32(Institucion.Trim())));
        }

        if (iAnoMes != 0)
        {
            sWhere = sWhere + " AND a.AnoMes =@pAnoMes ";

            listDbParameter.Add(Conexiones.CrearParametro("@pAnoMes", SqlDbType.Int, 4, iAnoMes));
        }

        if (sWhere.Trim() != "")
            sWhere = "WHERE " + sWhere.Substring(5);
        else
            sWhere = string.Empty;

        string strFrom = string.Empty;
        string strWhere = string.Empty;

        //if (!(RolId == 252 || RolId == 253 || RolId == 258 || RolId == 260 || RolId == 261 || RolId == 255 || RolId == 257 || RolId == 254 || RolId == 256 || RolId == 262 || RolId == 259))
        //{
        //    if (CodDireccionRegional > 0)
        //    {
        //        if (sWhere.Trim() == "")
        //            strWhere = " WHERE p.CodRegion = " + CodRegion + " ";
        //        else
        //            strWhere = " AND p.CodRegion = " + CodRegion + " ";
        //    }
        //    else
        //    {
        //        strFrom += " INNER JOIN TrabajadorProyecto tp ON tp.CodProyecto = p.CodProyecto ";
        //        strFrom += " INNER JOIN Usuarios u ON u.ICodTrabajador = tp.ICodTrabajador ";

        //        if (sWhere.Trim() == "")
        //            strWhere = " WHERE u.idUsuario = " + UserId + " ";
        //        else
        //            strWhere = " AND u.idUsuario = " + UserId + " ";
        //    }
        //}
        sWhere += strWhere;

        tSql += "SELECT	a.IdRendicionEgreso, a.AnoMes, a.FechaRegistro, ";
        tSql += "i.Nombre, ";
        if (Busca == 1) // Busca
        {
            tSql += "0 as NroComprobante, cast('01-01-2006' as  datetime) as FechaComprobante, 0 as Monto, ";
            tSql += "0 as Correlativo, '' as Glosa, 0 as Nulo, 0 as IdUsuarioActualizacion, cast('01-01-2006' as  datetime) as FechaActualizacion, ";
            tSql += "0 as CodUso, '' AS Uso, 0 as CodObjetivo, '' AS Objetivo, '' as Destino, '' as NumeroCheque, ";
            tSql += "0 as CodMedioDePago, '' as MedioDePago, ";
            tSql += "Cerrado = CASE ";
            tSql += "WHEN rc.cerrado IS NULL THEN 0 ";
            tSql += "ELSE rc.Cerrado END ";

            tSql += "FROM	RendicionesEgresoInstituciones a ";
            tSql += "INNER JOIN Instituciones i ";
            tSql += "ON a.CodInstitucion = i.CodInstitucion ";
            tSql += "LEFT JOIN RendicionCuentasInstituciones rc ";
            tSql += "ON a.CodInstitucion = rc.CodInstitucion AND a.AnoMes = rc.AnoMes ";

            tSql += strFrom;
            tSql += sWhere;
            tSql += " ORDER BY a.CodInstitucion, a.AnoMes";
        }
        else    // Mantener
        {
            tSql += "b.NroComprobante, b.FechaComprobante, b.Monto, ";
            tSql += "b.Correlativo, b.Glosa, b.Nulo, b.IdUsuarioActualizacion, b.FechaActualizacion, ";
            tSql += "c.CodUso, c.Descripcion AS Uso, d.CodObjetivo, d.Descripcion AS Objetivo, b.Destino, b.NumeroCheque, ";
            tSql += "b.CodMedioDePago, mp.Descripcion AS MedioDePago, 0 AS Cerrado ";

            tSql += "FROM	RendicionesEgresoInstituciones a ";
            tSql += "INNER JOIN RendicionesEgresoInstitucionesDetalle b ";
            tSql += "ON a.IdRendicionEgreso = b.IdRendicionEgreso ";
            tSql += "LEFT  JOIN parUso c ";
            tSql += "ON b.CodUso = c.CodUso ";
            tSql += "LEFT  JOIN parObjetivo d ";
            tSql += "ON c.CodObjetivo = d.CodObjetivo ";
            tSql += "LEFT  JOIN parMedioDePago mp ";
            tSql += "ON b.CodMedioDePago = mp.CodMedioDePago ";
            tSql += "INNER JOIN Instituciones i ";
            tSql += "ON a.CodInstitucion = i.CodInstitucion ";

            tSql += strFrom;
            tSql += sWhere;
            tSql += " ORDER BY b.NroComprobante";
        }
        return tSql;
    }

    public int InsertUpdate(Int32 IdRendicionEgreso, Int32 NroComprobante, Int32 Correlativo, Int32 CodUso, DateTime FechaComprobante, Int32 CodMedioDePago, Int32 Monto, string NumeroCheque, string Glosa, string Destino, int Nulo, int IdUsuarioActualizacion, int CodProyecto, int AnoMes, DateTime FechaRegistro)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;
        //Conexiones con = new Conexiones();
        Conexiones con = new Conexiones();
        DbParameter[] parametros =
        {
		con.parametros("@IdRendicionEgreso", SqlDbType.Int, 4, IdRendicionEgreso) ,
		con.parametros("@NroComprobante", SqlDbType.Int, 4, NroComprobante) ,
		con.parametros("@Correlativo", SqlDbType.Int, 4, Correlativo) ,
        con.parametros("@CodUso", SqlDbType.Int, 4, CodUso) ,
		con.parametros("@FechaComprobante", SqlDbType.DateTime, 16, FechaComprobante) ,
        con.parametros("@CodMedioDePago", SqlDbType.Int, 4, CodMedioDePago) ,
		con.parametros("@Monto", SqlDbType.Int, 4, Monto), 
		con.parametros("@NumeroCheque", SqlDbType.VarChar, 20, NumeroCheque), 
		con.parametros("@Destino", SqlDbType.VarChar, 20, Destino), 
		con.parametros("@Glosa", SqlDbType.VarChar, 20, Glosa), 
		con.parametros("@Nulo", SqlDbType.Int, 4, Nulo), 
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion),
        con.parametros("@CodProyecto", SqlDbType.Int, 4, CodProyecto),
        con.parametros("@AnoMes", SqlDbType.Int, 4, AnoMes),
        
        con.parametros("@FechaRegistro", SqlDbType.DateTime, 16, FechaRegistro)
		};

        con.ejecutarProcedimiento("Insert_Update_xRendicionesEgresoDetalle", parametros, out datareader);

        if (datareader.Read())
        {
            returnvalue = Convert.ToInt32(datareader["Retorno"]);
        }
        con.Desconectar();
        return returnvalue;
    }

    public int InsertUpdateInstitucion(Int32 IdRendicionEgreso, Int32 NroComprobante, Int32 Correlativo, Int32 CodUso, DateTime FechaComprobante, Int32 CodMedioDePago, Int32 Monto, string NumeroCheque, string Glosa, string Destino, int Nulo, int IdUsuarioActualizacion, int AnoMes, int CodInstitucion, DateTime FechaRegistro)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        DbParameter[] parametros =
        {        
		con.parametros("@IdRendicionEgreso", SqlDbType.Int, 4, IdRendicionEgreso) ,
		con.parametros("@NroComprobante", SqlDbType.Int, 4, NroComprobante) ,
		con.parametros("@Correlativo", SqlDbType.Int, 4, Correlativo) ,
        con.parametros("@CodUso", SqlDbType.Int, 4, CodUso) ,
		con.parametros("@FechaComprobante", SqlDbType.DateTime, 16, FechaComprobante) ,
        con.parametros("@CodMedioDePago", SqlDbType.Int, 4, CodMedioDePago) ,
		con.parametros("@Monto", SqlDbType.Int, 10, Monto), 
		con.parametros("@NumeroCheque", SqlDbType.VarChar, 20, NumeroCheque), 
		con.parametros("@Destino", SqlDbType.VarChar, 20, Destino), 
		con.parametros("@Glosa", SqlDbType.VarChar, 50, Glosa), 
		con.parametros("@Nulo", SqlDbType.Int, 4, Nulo),
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion),
        con.parametros("@AnoMes", SqlDbType.Int, 6, AnoMes),
        con.parametros("@CodInstitucion", SqlDbType.Int, 10, CodInstitucion),
        con.parametros("@FechaRegistro", SqlDbType.DateTime, 16, FechaRegistro)
		};

        con.ejecutarProcedimiento("Insert_Update_xRendicionesInstitucionesEgresoDetalle", parametros, out datareader);
        if (datareader.Read())
            returnvalue = Convert.ToInt32(datareader["Retorno"]);

        con.Desconectar();
        return returnvalue;
    }

    public int Delete(Int32 CodProyecto, Int32 AnoMes, Int32 NroComprobante, Int32 Correlativo)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        DbParameter[] parametros =
        {
		con.parametros("@CodProyecto", SqlDbType.Int, 4, CodProyecto) ,
		con.parametros("@AnoMes", SqlDbType.Int, 4, AnoMes) ,
		con.parametros("@NroComprobante", SqlDbType.Int, 4, NroComprobante),
		con.parametros("@Correlativo", SqlDbType.Int, 4, Correlativo)
        };

        con.ejecutarProcedimiento("PA_EliminaActualizaComprobanteRendicionEgreso", parametros, out datareader);
        if (datareader.Read())
            returnvalue = Convert.ToInt32(datareader["Retorno"]);

        con.Desconectar();
        return returnvalue;
    }

    public int DeleteInstitucion(Int32 CodInstitucion, Int32 AnoMes, Int32 NroComprobante, Int32 Correlativo)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        DbParameter[] parametros =
        {
		con.parametros("@CodInstitucion", SqlDbType.Int, 4, CodInstitucion) ,
		con.parametros("@AnoMes", SqlDbType.Int, 4, AnoMes) ,
		con.parametros("@NroComprobante", SqlDbType.Int, 4, NroComprobante),
		con.parametros("@Correlativo", SqlDbType.Int, 4, Correlativo)
        };

        con.ejecutarProcedimiento("PA_EliminaActualizaComprobanteRendicionEgresoInstitucion", parametros, out datareader);
        if (datareader.Read())
            returnvalue = Convert.ToInt32(datareader["Retorno"]);

        con.Desconectar();
        return returnvalue;
    }


    public DataTable GetData(string Institucion, string CodProyecto, string Proyecto, int iAnoMes, DataTable dt, int Busca, int UserId)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        DbParameter[] parametros = { };
        List<DbParameter> listDbParameter = null;

        int RolId = GetCod(1, UserId);
        int CodDireccionRegional = GetCod(2, UserId);
        int CodRegion = GetCod(3, UserId);

        string sql = SQL_Instruccion(Institucion, CodProyecto, Proyecto, iAnoMes, Busca, RolId, CodDireccionRegional, CodRegion, UserId, out listDbParameter);

        con.ejecutar(sql, listDbParameter, out datareader);

        DataRow dr;

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (System.Int32)datareader["IdRendicionEgreso"];
                dr[1] = (System.Int32)datareader["CodInstitucion"];
                dr[2] = (System.String)datareader["Institucion"];
                dr[3] = (System.Int32)datareader["CodProyecto"];
                dr[4] = (System.String)datareader["Proyecto"];
                dr[5] = (System.Int32)datareader["AnoMes"];
                dr[6] = (System.DateTime)datareader["FechaRegistro"];
                dr[7] = (System.Int32)datareader["NroComprobante"];
                dr[8] = (System.Int32)datareader["Correlativo"];
                dr[9] = (System.DateTime)datareader["FechaComprobante"];
                dr[10] = (System.Int32)datareader["Monto"];
                dr[11] = (System.String)datareader["Glosa"];
                dr[12] = ((System.Int32)datareader["Nulo"] == 1);
                dr[13] = (System.Int32)datareader["CodUso"];
                dr[14] = (System.String)datareader["Uso"];
                dr[15] = (System.Int32)datareader["CodObjetivo"];
                dr[16] = (System.String)datareader["Objetivo"];
                dr[17] = (System.Int32)datareader["CodMedioDePago"];
                dr[18] = (System.String)datareader["MedioDePago"];
                dr[19] = (System.String)datareader["Destino"];
                dr[20] = (System.String)datareader["NumeroCheque"];
                dr[21] = (System.Int32)datareader["IdUsuarioActualizacion"];
                dr[22] = (System.DateTime)datareader["FechaActualizacion"];
                dr[23] = ((System.Int32)datareader["Cerrado"] == 1);

                dt.Rows.Add(dr);
            }
            catch
            { }
        }

        con.Desconectar();
        return dt;
    }
    public DataTable GetDataInstituciones(string Institucion, int iAnoMes, DataTable dt, int Busca, int UserId)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        DbParameter[] parametros = { };
        List<DbParameter> listDbParameter = null;

        int RolId = GetCod(1, UserId);
        int CodDireccionRegional = GetCod(2, UserId);
        int CodRegion = GetCod(3, UserId);

        string sql = SQL_InstruccionInstitucion(Institucion, iAnoMes, Busca, RolId, CodDireccionRegional, CodRegion, UserId, out listDbParameter);

        con.ejecutar(sql, listDbParameter, out datareader);

        DataRow dr;

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (System.Int32)datareader["IdRendicionEgreso"];
                dr[1] = (System.Int32)datareader["AnoMes"];
                dr[2] = (System.DateTime)datareader["FechaRegistro"];
                dr[3] = (System.String)datareader["Nombre"];
                dr[4] = (System.Int32)datareader["NroComprobante"];
                dr[5] = (System.DateTime)datareader["FechaComprobante"];
                dr[6] = (System.Int32)datareader["Monto"];
                dr[7] = (System.Int32)datareader["Correlativo"];
                dr[8] = (System.String)datareader["Glosa"];
                dr[9] = ((System.Int32)datareader["Nulo"] == 1);
                dr[10] = (System.Int32)datareader["IdUsuarioActualizacion"];
                dr[11] = (System.DateTime)datareader["FechaActualizacion"];
                //dr[12] = (System.Int32)datareader["CodDetalleIngreso"];
                //dr[13] = (System.String)datareader["DetalleIngreso"];
                //dr[14] = (System.Int32)datareader["CodTipoIngreso"];
                //dr[15] = (System.String)datareader["TipoIngreso"];
                //dr[16] = (System.String)datareader["CodInstitucion"];
                dr[12] = (System.Int32)datareader["CodUso"];
                dr[13] = (System.String)datareader["Uso"];
                dr[14] = (System.Int32)datareader["CodObjetivo"];
                dr[15] = (System.String)datareader["Objetivo"];
                dr[16] = (System.String)datareader["Destino"];
                dr[17] = (System.String)datareader["NumeroCheque"];
                dr[18] = (System.Int32)datareader["CodMedioDePago"];
                dr[19] = (System.String)datareader["MedioDePago"];
                dr[20] = ((System.Int32)datareader["Cerrado"] == 1);

                dt.Rows.Add(dr);
            }
            catch (Exception ex)
            { }
        }

        con.Desconectar();
        return dt;
    }

    private int GetCod(int TipoCod, int UserId)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        DbParameter[] parametros = { };

        switch (TipoCod)
        {
            case 1:
                con.ejecutar("SELECT convert(int, contrasena) AS Cod from USUARIOS WHERE idUsuario = " + UserId, out datareader);
                break;
            case 2:
                con.ejecutar("SELECT coddireccionregional as Cod From USUARIOS WHERE idUsuario = " + UserId, out datareader);
                break;
            case 3:
                con.ejecutar("SELECT codregion as Cod from USUARIOS WHERE idUsuario = " + UserId, out datareader);
                break;
        }

        datareader.Read();

        int Cod = (System.Int32)datareader["Cod"];
        con.Desconectar();
        return Cod;
    }

}


//public class RendicionEgresoColl
//{
//    public RendicionEgresoColl()
//    {
//        //
//        // TODO: Agregar aquí la lógica del constructor
//        //
//    }
//    private string SQL_Instruccion(string Institucion, string CodProyecto, string Proyecto, int iAnoMes, int Busca, int RolId, int CodDireccionRegional, int CodRegion, int UserId)
//    {
//        string sWhere = string.Empty;
//        string tSql = string.Empty;

//        if (Institucion.Trim() != "")
//            sWhere = sWhere + " AND i.Nombre LIKE '%" + Institucion.Trim() + "%'";

//        if (CodProyecto.Trim() != "")
//            sWhere = sWhere + " AND p.CodProyecto = " + CodProyecto;
//        else
//        {
//            if (Proyecto.Trim() != "")
//                sWhere = sWhere + " AND p.Nombre LIKE '%" + Proyecto.Trim() + "%'";
//        }

//        if (iAnoMes != 0)
//            sWhere = sWhere + " AND a.AnoMes = " + iAnoMes + " ";

//        if (sWhere.Trim() != "")
//            sWhere = "WHERE " + sWhere.Substring(5);
//        else
//            sWhere = string.Empty;

//        string strFrom = string.Empty;
//        string strWhere = string.Empty;

//        if (!(RolId == 252 || RolId == 253 || RolId == 258 || RolId == 260 || RolId == 261 || RolId == 255 || RolId == 257 || RolId == 254 || RolId == 256 || RolId == 262 || RolId == 259 || RolId == 289))
//        {
//            if (CodDireccionRegional > 0)
//            {
//                if (sWhere.Trim() == "")
//                    strWhere = " WHERE p.CodRegion = " + CodRegion + " ";
//                else
//                    strWhere = " AND p.CodRegion = " + CodRegion + " ";
//            }
//            else
//            {
//                if (!(RolId == 251 || Institucion == ""))
//                {
//                    strFrom += " INNER JOIN TrabajadorProyecto tp ON tp.CodProyecto = p.CodProyecto ";
//                    strFrom += " INNER JOIN Usuarios u ON u.ICodTrabajador = tp.ICodTrabajador ";

//                    if (sWhere.Trim() == "")
//                        strWhere = " WHERE u.idUsuario = " + UserId + " ";
//                    else
//                        strWhere = " AND u.idUsuario = " + UserId + " ";
//                }
//            }
//        }
//        sWhere += strWhere;

//        //tSql += "SELECT	a.IdRendicionEgreso, a.CodProyecto, a.AnoMes, a.FechaRegistro, ";
//        //tSql += "p.CodInstitucion, i.Nombre AS Institucion, p.Nombre as Proyecto, ";
//        if (Busca == 1) // Busca
//        {

//            tSql += "SELECT ISNULL(IdRendicionEgreso, 0) as IdRendicionEgreso, rc.CodProyecto, rc.AnoMes, cast('01-01-2006' as  datetime) as FechaRegistro, ";
//            tSql += "p.CodInstitucion, i.Nombre AS Institucion, p.Nombre as Proyecto, ";

//            tSql += "0 as NroComprobante, cast('01-01-2006' as  datetime) as FechaComprobante, 0 as Monto, ";
//            tSql += "0 as Correlativo, '' as Glosa, 0 as Nulo, 0 as IdUsuarioActualizacion, cast('01-01-2006' as  datetime) as FechaActualizacion, ";
//            tSql += "0 as CodUso, '' AS Uso, 0 as CodObjetivo, '' AS Objetivo, '' as Destino, '' as NumeroCheque, ";
//            tSql += "0 as CodMedioDePago, '' as MedioDePago, ";

//            tSql += "Cerrado = CASE ";
//            tSql += "WHEN rc.cerrado IS NULL THEN 0 ";
//            tSql += "ELSE rc.Cerrado END ";

//            //tSql += "FROM	RendicionesEgreso a ";
//            //tSql += "INNER JOIN Proyectos p ";
//            //tSql += "ON a.CodProyecto = p.CodProyecto ";
//            //tSql += "LEFT JOIN Instituciones i ";
//            //tSql += "ON p.CodInstitucion = i.CodInstitucion ";
//            //tSql += "LEFT JOIN RendicionCuentas rc ";
//            //tSql += "ON a.CodProyecto = rc.CodProyecto AND a.AnoMes = rc.AnoMes ";

//            tSql += "FROM RendicionCuentas rc ";
//            tSql += "INNER JOIN Proyectos p ON rc.CodProyecto = p.CodProyecto ";
//            tSql += "INNER JOIN Instituciones i ON p.CodInstitucion = i.CodInstitucion ";
//            tSql += "LEFT JOIN RendicionesEgreso a ON a.CodProyecto = rc.CodProyecto AND rc.AnoMes = a.AnoMes ";

//            tSql += strFrom;
//            tSql += sWhere;
//            tSql += " ORDER BY a.CodProyecto, a.AnoMes";          
//        }
//        else    // Mantener
//        {
//            tSql += "SELECT a.IdRendicionEgreso, a.CodProyecto, a.AnoMes, a.FechaRegistro, ";
//            tSql += "p.CodInstitucion, i.Nombre AS Institucion, p.Nombre as Proyecto, ";
//            tSql += "b.NroComprobante, b.FechaComprobante, b.Monto, ";
//            tSql += "b.Correlativo, b.Glosa, b.Nulo, b.IdUsuarioActualizacion, b.FechaActualizacion, ";
//            tSql += "c.CodDetalleEgreso, c.Descripcion AS DetalleIngreso, d.CodTipoeEgreso, d.Descripcion AS TipoEgreso, ";
//            tSql += "0 AS Cerrado ";


//            tSql += "FROM	RendicionesEgreso a ";
//            tSql += "INNER JOIN RendicionesEgresoDetalle b ";
//            tSql += "ON a.IdRendicionEgreso = b.IdRendicionEgreso ";
//            tSql += "LEFT  JOIN parDetalleEgreso c ";
//            //tSql += "LEFT  JOIN parUso c ";
//            tSql += "ON b.CodDetalleEgreso = c.CodDetalleIngreso ";
//            tSql += "LEFT  JOIN parTipoEgreso d ";
//            //tSql += "LEFT  JOIN parObjetivo d ";
//            tSql += "ON c.CodTipoeEgreso = d.CodTipoEgreso ";
//            tSql += "INNER JOIN Proyectos p ";
//            tSql += "ON a.CodProyecto = p.CodProyecto ";
//            tSql += "LEFT JOIN Instituciones i ";
//            tSql += "ON p.CodInstitucion = i.CodInstitucion ";


//            tSql += strFrom;
//            tSql += sWhere;
//            tSql += " ORDER BY b.NroComprobante";
//        }

//        return tSql;
//    }

//    private string SQL_InstruccionInstitucion(string Institucion, int iAnoMes, int Busca, int RolId, int CodDireccionRegional, int CodRegion, int UserId)
//    {
//        string sWhere = string.Empty;
//        string tSql = string.Empty;

//        if (Institucion.Trim() != "")
//            sWhere = sWhere + " AND i.CodInstitucion =" + Institucion.Trim();

//         if (iAnoMes != 0)
//            sWhere = sWhere + " AND a.AnoMes = " + iAnoMes + " ";

//        if (sWhere.Trim() != "")
//            sWhere = "WHERE " + sWhere.Substring(5);
//        else
//            sWhere = string.Empty;

//        string strFrom = string.Empty;
//        string strWhere = string.Empty;

//        //if (!(RolId == 252 || RolId == 253 || RolId == 258 || RolId == 260 || RolId == 261 || RolId == 255 || RolId == 257 || RolId == 254 || RolId == 256 || RolId == 262 || RolId == 259))
//        //{
//        //    if (CodDireccionRegional > 0)
//        //    {
//        //        if (sWhere.Trim() == "")
//        //            strWhere = " WHERE p.CodRegion = " + CodRegion + " ";
//        //        else
//        //            strWhere = " AND p.CodRegion = " + CodRegion + " ";
//        //    }
//        //    else
//        //    {
//        //        strFrom += " INNER JOIN TrabajadorProyecto tp ON tp.CodProyecto = p.CodProyecto ";
//        //        strFrom += " INNER JOIN Usuarios u ON u.ICodTrabajador = tp.ICodTrabajador ";

//        //        if (sWhere.Trim() == "")
//        //            strWhere = " WHERE u.idUsuario = " + UserId + " ";
//        //        else
//        //            strWhere = " AND u.idUsuario = " + UserId + " ";
//        //    }
//        //}
//        sWhere += strWhere;
//        /*old*/
//        //tSql += "SELECT	a.IdRendicionEgreso, a.AnoMes, a.FechaRegistro, ";
//        //tSql += "i.Nombre, ";
//        /*fin old*/
//        if (Busca == 1) // Busca
//        {
//            /*instituciones*/

//            tSql += "SELECT ISNULL(IdRendicionEgreso, 0) as IdRendicionEgreso, rc.AnoMes, cast('01-01-2006' as  datetime) as FechaRegistro, ";
//            tSql += "i.Nombre, ";


//            tSql += "0 as NroComprobante, cast('01-01-2006' as  datetime) as FechaComprobante, 0 as Monto, ";
//            tSql += "0 as Correlativo, '' as Glosa, 0 as Nulo, 0 as IdUsuarioActualizacion, cast('01-01-2006' as  datetime) as FechaActualizacion, ";
//            tSql += "0 as CodUso, '' AS Uso, 0 as CodObjetivo, '' AS Objetivo, '' as Destino, '' as NumeroCheque, ";
//            tSql += "0 as CodMedioDePago, '' as MedioDePago, ";
//            tSql += "Cerrado = CASE ";
//            tSql += "WHEN rc.cerrado IS NULL THEN 0 ";
//            tSql += "ELSE rc.Cerrado END ";
//            /*old*/
//            //tSql += "FROM	RendicionesEgresoInstituciones a ";
//            //tSql += "INNER JOIN Instituciones i ";
//            //tSql += "ON a.CodInstitucion = i.CodInstitucion ";
//            //tSql += "LEFT JOIN RendicionCuentasInstituciones rc ";
//            //tSql += "ON a.CodInstitucion = rc.CodInstitucion AND a.AnoMes = rc.AnoMes ";
//            /*fin old*/
//            tSql += "FROM RendicionCuentasInstituciones rc	";
//            tSql += "INNER JOIN Instituciones i ";
//            tSql += "ON rc.CodInstitucion = i.CodInstitucion ";
//            tSql += "LEFT JOIN RendicionesEgresoInstituciones a ";
//            tSql += "ON rc.CodInstitucion = a.CodInstitucion AND rc.AnoMes = a.AnoMes ";


//            tSql += strFrom;
//            tSql += sWhere;
//            tSql += " ORDER BY a.CodInstitucion, a.AnoMes";
//        }
//        else    // Mantener
//        {
//            tSql += "b.NroComprobante, b.FechaComprobante, b.Monto, ";
//            tSql += "b.Correlativo, b.Glosa, b.Nulo, b.IdUsuarioActualizacion, b.FechaActualizacion, ";
//            tSql += "c.CodUso, c.Descripcion AS Uso, d.CodObjetivo, d.Descripcion AS Objetivo, b.Destino, b.NumeroCheque, ";
//            tSql += "b.CodMedioDePago, mp.Descripcion AS MedioDePago, 0 AS Cerrado ";

//            tSql += "FROM	RendicionesEgresoInstituciones a ";
//            tSql += "INNER JOIN RendicionesEgresoInstitucionesDetalle b ";
//            tSql += "ON a.IdRendicionEgreso = b.IdRendicionEgreso ";
//            tSql += "LEFT  JOIN parUso c ";
//            tSql += "ON b.CodUso = c.CodUso ";
//            tSql += "LEFT  JOIN parObjetivo d ";
//            tSql += "ON c.CodObjetivo = d.CodObjetivo ";
//            tSql += "LEFT  JOIN parMedioDePago mp ";
//            tSql += "ON b.CodMedioDePago = mp.CodMedioDePago ";
//            tSql += "INNER JOIN Instituciones i ";
//            tSql += "ON a.CodInstitucion = i.CodInstitucion ";

//            tSql += strFrom;
//            tSql += sWhere;
//            tSql += " ORDER BY b.NroComprobante";
//        }
//        return tSql;
//    }

//    public int InsertUpdate(Int32 IdRendicionEgreso, Int32 NroComprobante, Int32 Correlativo, Int32 CodUso, DateTime FechaComprobante, Int32 CodMedioDePago, Int32 Monto, string NumeroCheque, string Glosa, string Destino, int Nulo, int IdUsuarioActualizacion, int CodProyecto, int AnoMes, DateTime FechaRegistro)
//    {
//        int returnvalue = 0;
//        DbDataReader datareader = null;
//        /* Conexiones con = new Conexiones(); */
//        Conexiones con = new Conexiones();
//        DbParameter[] parametros =
//        {
//        con.parametros("@IdRendicionEgreso", SqlDbType.Int, 4, IdRendicionEgreso) ,
//        con.parametros("@NroComprobante", SqlDbType.Int, 4, NroComprobante) ,
//        con.parametros("@Correlativo", SqlDbType.Int, 4, Correlativo) ,
//        con.parametros("@CodUso", SqlDbType.Int, 4, CodUso) ,
//        con.parametros("@FechaComprobante", SqlDbType.DateTime, 16, FechaComprobante) ,
//        con.parametros("@CodMedioDePago", SqlDbType.Int, 4, CodMedioDePago) ,
//        con.parametros("@Monto", SqlDbType.Int, 4, Monto), 
//        con.parametros("@NumeroCheque", SqlDbType.VarChar, 20, NumeroCheque), 
//        con.parametros("@Destino", SqlDbType.VarChar, 20, Destino), 
//        con.parametros("@Glosa", SqlDbType.VarChar, 20, Glosa), 
//        con.parametros("@Nulo", SqlDbType.Int, 4, Nulo), 
//        con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion),
//        con.parametros("@CodProyecto", SqlDbType.Int, 4, CodProyecto),
//        con.parametros("@AnoMes", SqlDbType.Int, 4, AnoMes),
//        con.parametros("@FechaRegistro", SqlDbType.DateTime, 16, FechaRegistro)
//        };

//        con.ejecutarProcedimiento("Insert_Update_xRendicionesEgresoDetalle", parametros, out datareader);

//        if (datareader.Read())
//        {
//            returnvalue = Convert.ToInt32(datareader["Retorno"]);
//        }
//        con.Desconectar();
//        return returnvalue;
//    }

//    public int InsertUpdateInstitucion(Int32 IdRendicionEgreso, Int32 NroComprobante, Int32 Correlativo, Int32 CodUso, DateTime FechaComprobante, Int32 CodMedioDePago, Int32 Monto, string NumeroCheque, string Glosa, string Destino, int Nulo, int IdUsuarioActualizacion, int AnoMes,int CodInstitucion, DateTime FechaRegistro)
//    {
//        int returnvalue = 0;
//        DbDataReader datareader = null;
//        /* Conexiones con = new Conexiones(); */ Conexiones con = new Conexiones();
//        DbParameter[] parametros =
//        {        
//        con.parametros("@IdRendicionEgreso", SqlDbType.Int, 4, IdRendicionEgreso) ,
//        con.parametros("@NroComprobante", SqlDbType.Int, 4, NroComprobante) ,
//        con.parametros("@Correlativo", SqlDbType.Int, 4, Correlativo) ,
//        con.parametros("@CodUso", SqlDbType.Int, 4, CodUso) ,
//        con.parametros("@FechaComprobante", SqlDbType.DateTime, 16, FechaComprobante) ,
//        con.parametros("@CodMedioDePago", SqlDbType.Int, 4, CodMedioDePago) ,
//        con.parametros("@Monto", SqlDbType.Int, 10, Monto), 
//        con.parametros("@NumeroCheque", SqlDbType.VarChar, 20, NumeroCheque), 
//        con.parametros("@Destino", SqlDbType.VarChar, 20, Destino), 
//        con.parametros("@Glosa", SqlDbType.VarChar, 50, Glosa), 
//        con.parametros("@Nulo", SqlDbType.Int, 4, Nulo),
//        con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion),
//        con.parametros("@AnoMes", SqlDbType.Int, 6, AnoMes),
//        con.parametros("@CodInstitucion", SqlDbType.Int, 10, CodInstitucion),
//        con.parametros("@FechaRegistro", SqlDbType.DateTime, 16, FechaRegistro)
//        };

//        con.ejecutarProcedimiento("Insert_Update_xRendicionesInstitucionesEgresoDetalle", parametros, out datareader);
//        if (datareader.Read())
//            returnvalue = Convert.ToInt32(datareader["Retorno"]);

//        con.Desconectar();
//        return returnvalue;
//    }

//    public int Delete(Int32 CodProyecto, Int32 AnoMes, Int32 NroComprobante, Int32 Correlativo)
//    {
//        int returnvalue = 0;
//        DbDataReader datareader = null;
//        /* Conexiones con = new Conexiones(); */ Conexiones con = new Conexiones();
//        DbParameter[] parametros =
//        {
//        con.parametros("@CodProyecto", SqlDbType.Int, 4, CodProyecto) ,
//        con.parametros("@AnoMes", SqlDbType.Int, 4, AnoMes) ,
//        con.parametros("@NroComprobante", SqlDbType.Int, 4, NroComprobante),
//        con.parametros("@Correlativo", SqlDbType.Int, 4, Correlativo)
//        };

//        con.ejecutarProcedimiento("PA_EliminaActualizaComprobanteRendicionEgreso", parametros, out datareader);
//        if (datareader.Read())
//            returnvalue = Convert.ToInt32(datareader["Retorno"]);

//        con.Desconectar();
//        return returnvalue;
//    }

//    public int DeleteInstitucion(Int32 CodInstitucion, Int32 AnoMes, Int32 NroComprobante, Int32 Correlativo)
//    {
//        int returnvalue = 0;
//        DbDataReader datareader = null;
//        /* Conexiones con = new Conexiones(); */ Conexiones con = new Conexiones();
//        DbParameter[] parametros =
//        {
//        con.parametros("@CodInstitucion", SqlDbType.Int, 4, CodInstitucion) ,
//        con.parametros("@AnoMes", SqlDbType.Int, 4, AnoMes) ,
//        con.parametros("@NroComprobante", SqlDbType.Int, 4, NroComprobante),
//        con.parametros("@Correlativo", SqlDbType.Int, 4, Correlativo)
//        };

//        con.ejecutarProcedimiento("PA_EliminaActualizaComprobanteRendicionEgresoInstitucion", parametros, out datareader);
//        if (datareader.Read())
//            returnvalue = Convert.ToInt32(datareader["Retorno"]);

//        con.Desconectar();
//        return returnvalue;
//    }


//    public DataTable GetData(string Institucion, string CodProyecto, string Proyecto, int iAnoMes, DataTable dt, int Busca, int UserId)
//    {
//        DbDataReader datareader = null;
//        /* Conexiones con = new Conexiones(); */ Conexiones con = new Conexiones();
//        DbParameter[] parametros = { };

//        int RolId = GetCod(1, UserId);
//        int CodDireccionRegional = GetCod(2, UserId);
//        int CodRegion = GetCod(3, UserId);

//        con.ejecutar(SQL_Instruccion(Institucion, CodProyecto, Proyecto, iAnoMes, Busca, RolId, CodDireccionRegional, CodRegion, UserId), out datareader);

//        DataRow dr;

//        while (datareader.Read())
//        {
//            try
//            {
//                dr = dt.NewRow();
//                dr[0] = (System.Int32)datareader["IdRendicionEgreso"];
//                dr[1] = (System.Int32)datareader["CodInstitucion"];
//                dr[2] = (System.String)datareader["Institucion"];
//                dr[3] = (System.Int32)datareader["CodProyecto"];
//                dr[4] = (System.String)datareader["Proyecto"];
//                dr[5] = (System.Int32)datareader["AnoMes"];
//                dr[6] = (System.DateTime)datareader["FechaRegistro"];
//                dr[7] = (System.Int32)datareader["NroComprobante"];
//                dr[8] = (System.Int32)datareader["Correlativo"];
//                dr[9] = (System.DateTime)datareader["FechaComprobante"];
//                dr[10] = (System.Int32)datareader["Monto"];
//                dr[11] = (System.String)datareader["Glosa"];
//                dr[12] = ((System.Int32)datareader["Nulo"] == 1);
//                dr[13] = (System.Int32)datareader["CodUso"];
//                dr[14] = (System.String)datareader["Uso"];
//                dr[15] = (System.Int32)datareader["CodObjetivo"];
//                dr[16] = (System.String)datareader["Objetivo"];
//                dr[17] = (System.Int32)datareader["CodMedioDePago"];
//                dr[18] = (System.String)datareader["MedioDePago"];
//                dr[19] = (System.String)datareader["Destino"];
//                dr[20] = (System.String)datareader["NumeroCheque"];
//                dr[21] = (System.Int32)datareader["IdUsuarioActualizacion"];
//                dr[22] = (System.DateTime)datareader["FechaActualizacion"];
//                dr[23] = ((System.Int32)datareader["Cerrado"] == 1);

//                dt.Rows.Add(dr);
//            }
//            catch
//            { }
//        }

//        con.Desconectar();
//        return dt;
//    }
//    public DataTable GetDataInstituciones(string Institucion, int iAnoMes, DataTable dt, int Busca, int UserId)
//    {
//        DbDataReader datareader = null;
//        /* Conexiones con = new Conexiones(); */
//        Conexiones con = new Conexiones();
//        DbParameter[] parametros = { };

//        int RolId = GetCod(1, UserId);
//        int CodDireccionRegional = GetCod(2, UserId);
//        int CodRegion = GetCod(3, UserId);

//        con.ejecutar(SQL_InstruccionInstitucion(Institucion, iAnoMes, Busca, RolId, CodDireccionRegional, CodRegion, UserId), out datareader);

//        DataRow dr;

//        while (datareader.Read())
//        {
//            try
//            {
//                dr = dt.NewRow();
//                dr[0] = (System.Int32)datareader["IdRendicionEgreso"];
//                dr[1] = (System.Int32)datareader["AnoMes"];
//                dr[2] = (System.DateTime)datareader["FechaRegistro"];
//                dr[3] = (System.String)datareader["Nombre"];                
//                dr[4] = (System.Int32)datareader["NroComprobante"];                
//                dr[5] = (System.DateTime)datareader["FechaComprobante"];
//                dr[6] = (System.Int32)datareader["Monto"];
//                dr[7] = (System.Int32)datareader["Correlativo"];
//                dr[8] = (System.String)datareader["Glosa"];
//                dr[9] = ((System.Int32)datareader["Nulo"] == 1);
//                dr[10] = (System.Int32)datareader["IdUsuarioActualizacion"];
//                dr[11] = (System.DateTime)datareader["FechaActualizacion"];
//                //dr[12] = (System.Int32)datareader["CodDetalleIngreso"];
//                //dr[13] = (System.String)datareader["DetalleIngreso"];
//                //dr[14] = (System.Int32)datareader["CodTipoIngreso"];
//                //dr[15] = (System.String)datareader["TipoIngreso"];
//                //dr[16] = (System.String)datareader["CodInstitucion"];
//                dr[12] = (System.Int32)datareader["CodUso"];
//                dr[13] = (System.String)datareader["Uso"];
//                dr[14] = (System.Int32)datareader["CodObjetivo"];
//                dr[15] = (System.String)datareader["Objetivo"];
//                dr[16] = (System.String)datareader["Destino"];
//                dr[17] = (System.String)datareader["NumeroCheque"];
//                dr[18] = (System.Int32)datareader["CodMedioDePago"];
//                dr[19] = (System.String)datareader["MedioDePago"];
//                dr[20] = ((System.Int32)datareader["Cerrado"] == 1);

//                dt.Rows.Add(dr);
//            }
//            catch(Exception ex)
//            { }
//        }

//        con.Desconectar();
//        return dt;
//    }

//    private int GetCod(int TipoCod, int UserId)
//    {
//        DbDataReader datareader = null;
//        /* Conexiones con = new Conexiones(); */
//        Conexiones con = new Conexiones();
//        DbParameter[] parametros = { };

//        switch (TipoCod)
//        {
//            case 1:
//                con.ejecutar("SELECT convert(int, contrasena) AS Cod from USUARIOS WHERE idUsuario = " + UserId, out datareader);
//                break;
//            case 2:
//                con.ejecutar("SELECT coddireccionregional as Cod From USUARIOS WHERE idUsuario = " + UserId, out datareader);
//                break;
//            case 3:
//                con.ejecutar("SELECT codregion as Cod from USUARIOS WHERE idUsuario = " + UserId, out datareader);
//                break;
//        }

//        datareader.Read();

//        int Cod = (System.Int32)datareader["Cod"];
//        con.Desconectar();
//        return Cod;
//    }

//}
