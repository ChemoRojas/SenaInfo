using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data.Common;
////////using neocsharp.NeoDatabase;

using System.Collections.Generic;

/// <summary>
/// Descripción breve de RendicionCuentasColl
/// </summary>
public class RendicionCuentasColl
{
	public RendicionCuentasColl()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
    public DataTable GetResumenRendicionMensualFirma(string CodProyecto, int AnoMes)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_ResumenRendicionMensualFirma";
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = Convert.ToInt32(CodProyecto);
        sqlc.Parameters.Add("@AnoMes", SqlDbType.Int, 4).Value = AnoMes;

        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable GetResumenRendicionMensualFirmaInstitucion(string CodInstitucion, int AnoMes)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_ResumenRendicionMensualFirmaInstitucion";
        sqlc.Parameters.Add("@CodInstitucion", SqlDbType.Int, 4).Value = Convert.ToInt32(CodInstitucion);
        sqlc.Parameters.Add("@AnoMes", SqlDbType.Int, 4).Value = AnoMes;

        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    private string SQL_InstruccionResumen(string CodProyecto, int iAnoMes, int IE, out List<DbParameter> listDbParameter)
    {
        listDbParameter = new List<DbParameter>();

        string tSql = string.Empty;

        if (IE == 1)        // Ingresos
        {
            tSql = tSql + "SELECT pTi.CodTipoIngreso, pTi.Descripcion AS TipoIngreso, ";
            tSql = tSql + "pDi.CodDetalleIngreso, pDi.Descripcion AS DetalleIngreso, ";
            tSql = tSql + "SUM(rId.Monto) AS Total ";
            tSql = tSql + "FROM RendicionesIngreso rI ";
            tSql = tSql + "INNER JOIN RendicionesIngresoDetalle rId ";
            tSql = tSql + "ON rI.IdRendicionIngreso = rId.IdRendicionIngreso ";
            tSql = tSql + "LEFT JOIN parDetalleIngreso pDi ";
            tSql = tSql + "ON rId.CodDetalleIngreso = pDi.CodDetalleIngreso ";
            tSql = tSql + "LEFT JOIN parTipoIngreso pTi ";
            tSql = tSql + "ON pDi.CodTipoIngreso = pTi.CodTipoIngreso ";
            tSql = tSql + "WHERE rI.CodProyecto =@pCodProyecto ";
            tSql = tSql + "AND rId.Nulo = 0 ";
            tSql = tSql + "AND rI.AnoMes =@pAnoMes ";
            tSql = tSql + "GROUP BY pTi.CodTipoIngreso, pTi.Descripcion, pDi.CodDetalleIngreso, pDi.Descripcion";
        }
        else               // Egresos
        {
            tSql = tSql + "SELECT pO.CodObjetivo, pO.Descripcion AS Objetivo, ";
            tSql = tSql + "SUM(rEd.Monto) AS Total ";
            tSql = tSql + "FROM RendicionesEgreso rE ";
            tSql = tSql + "INNER JOIN RendicionesEgresoDetalle rEd ";
            tSql = tSql + "ON rE.IdRendicionEgreso = rEd.IdRendicionEgreso ";
            tSql = tSql + "LEFT JOIN parUso pU ";
            tSql = tSql + "ON rEd.CodUso = pU.CodUso ";
            tSql = tSql + "LEFT JOIN parObjetivo pO ";
            tSql = tSql + "ON pU.CodObjetivo = pO.CodObjetivo ";
            tSql = tSql + "WHERE rE.CodProyecto =@pCodProyecto ";
            tSql = tSql + "AND rEd.Nulo = 0 ";
            tSql = tSql + "AND rE.AnoMes =@pAnoMes ";
            tSql = tSql + "GROUP BY pO.CodObjetivo, pO.Descripcion";
        }

        listDbParameter.Add(Conexiones.CrearParametro("@pCodProyecto", SqlDbType.Int, 4, Convert.ToInt32(CodProyecto)));
        listDbParameter.Add(Conexiones.CrearParametro("@pAnoMes", SqlDbType.Int, 4, iAnoMes));
		
        return tSql;
    }

    private string SQL_InstruccionResumenInstitucion(string CodInstitucion, int iAnoMes, int IE, out List<DbParameter> listDbParameter)
    {
        listDbParameter = new List<DbParameter>();

        string tSql = string.Empty;

        if (IE == 1)        // Ingresos
        {
            tSql = tSql + "SELECT pTi.CodTipoIngreso, pTi.Descripcion AS TipoIngreso, ";
            tSql = tSql + "pDi.CodDetalleIngreso, pDi.Descripcion AS DetalleIngreso, ";
            tSql = tSql + "SUM(rId.Monto) AS Total ";
            tSql = tSql + "FROM RendicionesIngresoInstituciones rI ";
            tSql = tSql + "INNER JOIN RendicionesIngresoInstitucionesDetalle rId ";
            tSql = tSql + "ON rI.IdRendicionIngreso = rId.IdRendicionIngreso ";
            tSql = tSql + "LEFT JOIN parDetalleIngreso pDi ";
            tSql = tSql + "ON rId.CodDetalleIngreso = pDi.CodDetalleIngreso ";
            tSql = tSql + "LEFT JOIN parTipoIngreso pTi ";
            tSql = tSql + "ON pDi.CodTipoIngreso = pTi.CodTipoIngreso ";
            tSql = tSql + "WHERE rI.CodInstitucion =@pCodInstitucion ";
            tSql = tSql + "AND rId.Nulo = 0 ";
            tSql = tSql + "AND rI.AnoMes =@pAnoMes ";
            tSql = tSql + "GROUP BY pTi.CodTipoIngreso, pTi.Descripcion, pDi.CodDetalleIngreso, pDi.Descripcion";
        }
        else               // Egresos
        {
            tSql = tSql + "SELECT pO.CodObjetivo, pO.Descripcion AS Objetivo, ";
            tSql = tSql + "SUM(rEd.Monto) AS Total ";
            tSql = tSql + "FROM RendicionesEgresoInstituciones rE ";
            tSql = tSql + "INNER JOIN RendicionesEgresoInstitucionesDetalle rEd ";
            tSql = tSql + "ON rE.IdRendicionEgreso = rEd.IdRendicionEgreso ";
            tSql = tSql + "LEFT JOIN parUso pU ";
            tSql = tSql + "ON rEd.CodUso = pU.CodUso ";
            tSql = tSql + "LEFT JOIN parObjetivo pO ";
            tSql = tSql + "ON pU.CodObjetivo = pO.CodObjetivo ";
            tSql = tSql + "WHERE rE.CodInstitucion =@pCodInstitucion ";
            tSql = tSql + "AND rEd.Nulo = 0 ";
            tSql = tSql + "AND rE.AnoMes =@pAnoMes ";
            tSql = tSql + "GROUP BY pO.CodObjetivo, pO.Descripcion";
        }

        listDbParameter.Add(Conexiones.CrearParametro("@pCodInstitucion", SqlDbType.Int, 4, Convert.ToInt32(CodInstitucion)));
        listDbParameter.Add(Conexiones.CrearParametro("@pAnoMes", SqlDbType.Int, 4, iAnoMes));

        return tSql;
    }


    private string SQL_Instruccion(string Institucion, string CodProyecto, string Proyecto, int iAnoMes, int RolId, int CodDireccionRegional, int CodRegion, int UserId, out List<DbParameter> listDbParameter)
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
                sWhere = sWhere + " AND p.Nombre LIKE @pNombreProyecto";

                listDbParameter.Add(Conexiones.CrearParametro("@pNombreProyecto", SqlDbType.VarChar, 100, "%" + Proyecto.Trim() + "%"));
            }
        }

        if (iAnoMes > 0)
        {
            sWhere = sWhere + " AND rc.AnoMes =@pAnoMes ";

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
                if (!(RolId == 251 || Institucion == ""))
                {
                    strFrom += " INNER JOIN TrabajadorProyecto tp ON tp.CodProyecto = p.CodProyecto ";
                    strFrom += " INNER JOIN Usuarios u ON u.ICodTrabajador = tp.ICodTrabajador ";

                    if (sWhere.Trim() == "")
                        strWhere = " WHERE u.idUsuario =@pidUsuario ";
                    else
                        strWhere = " AND u.idUsuario =@pidUsuario ";

                    listDbParameter.Add(Conexiones.CrearParametro("@pidUsuario", SqlDbType.Int, 4, UserId));
                }
            }
        }

        sWhere += strWhere;

        tSql += "SELECT i.CodInstitucion, i.Nombre AS Institucion, p.CodProyecto, p.Nombre AS Proyecto, ";
        tSql += "ISNULL(p.CodBanco, '') as CodBanco, p.RutNumeroProyecto, ISNULL(pb.Descripcion, '') AS Banco, p.CuentaCorrienteNumero, p.NumeroPlazas, ";
        tSql += "rc.AnoMes, rc.NumChequeReintegro, rc.MontoReintegro, rc.AnoPptoReintegro, ";
        tSql += "rc.SaldoAnterior, rc.SaldoMes, rc.FechaRendicion, rc.Cerrado, rc.FechaActualizacion, ";
        tSql += "rc.IdusuarioActualizacion,  ";
        tSql += "ISNULL(rc.DeudaAnterior, 0) as DeudaAnterior, ISNULL(rc.DeudaMes, 0) as DeudaMes, ISNULL(rc.ProvisionIndemnizacion, 0) as ProvisionIndemnizacion, ISNULL(rc.SaldoReal, 0) as SaldoReal ";
        tSql += "FROM RendicionCuentas rc ";
        if (iAnoMes < 0)
            tSql += "RIGHT JOIN Proyectos p ";
        else
            tSql += "INNER JOIN Proyectos p ";

        tSql += "ON rc.CodProyecto = p.CodProyecto ";
        tSql += "INNER JOIN Instituciones i ";
        tSql += "ON p.CodInstitucion = i.CodInstitucion ";
        tSql += "LEFT JOIN parBancos pb ";
        tSql += "ON p.CodBanco = pb.CodBanco ";

        tSql += strFrom;
        tSql += sWhere;

        return tSql;
    }
    private string SQL_Instruccion(string CodProyecto, int iAnoMes, int iPagada, out List<DbParameter> listDbParameter)
    {
        listDbParameter = new List<DbParameter>();

        string tSql = string.Empty;

        tSql += "SELECT rd.IdRendicionDeudas, rd.FechaDeuda, po.Descripcion Objetivo, po.CodObjetivo, ";
        tSql += "pu.Descripcion Uso, rd.CodUso, rd.Monto, rd.AnoMes ";
        tSql += "FROM RendicionDeudas rd ";
        tSql += "LEFT  JOIN parUso pu ";
        tSql += "ON rd.CodUso = pu.CodUso ";
        tSql += "LEFT  JOIN parObjetivo po ";
        tSql += "ON pu.CodObjetivo = po.CodObjetivo ";
        tSql += "WHERE rd.CodProyecto =@pCodProyecto ";
        tSql += "AND rd.AnoMes <=@pAnoMes ";

        listDbParameter.Add(Conexiones.CrearParametro("@pCodProyecto", SqlDbType.Int, 4, Convert.ToInt32(CodProyecto)));
        listDbParameter.Add(Conexiones.CrearParametro("@pAnoMes", SqlDbType.Int, 4, iAnoMes));

        if (iPagada == 0) 
            tSql += "AND rd.Pagada = 0 "; 
        else 
            tSql += "";
        tSql += "ORDER BY rd.FechaDeuda";

        return tSql;
    }

    private string SQL_InstruccionDeudaInstitucion(string CodInstitucion, int iAnoMes, int iPagada, out List<DbParameter> listDbParameter)
    {
        listDbParameter = new List<DbParameter>();

        string tSql = string.Empty;

        tSql += "SELECT rd.IdRendicionDeudas, rd.FechaDeuda, po.Descripcion Objetivo, po.CodObjetivo, ";
        tSql += "pu.Descripcion Uso, rd.CodUso, rd.Monto, rd.AnoMes ";
        tSql += "FROM RendicionDeudas_Instituciones rd ";
        tSql += "LEFT  JOIN parUso pu ";
        tSql += "ON rd.CodUso = pu.CodUso ";
        tSql += "LEFT  JOIN parObjetivo po ";
        tSql += "ON pu.CodObjetivo = po.CodObjetivo ";
        tSql += "WHERE rd.CodInstitucion =@pCodInstitucion ";
        tSql += "AND rd.AnoMes <=@pAnoMes ";

        listDbParameter.Add(Conexiones.CrearParametro("@pCodInstitucion", SqlDbType.Int, 4, Convert.ToInt32(CodInstitucion)));
        listDbParameter.Add(Conexiones.CrearParametro("@pAnoMes", SqlDbType.Int, 4, iAnoMes));

        if (iPagada == 0)
            tSql += "AND rd.Pagada = 0 ";
        else
            tSql += "";
        tSql += "ORDER BY rd.FechaDeuda";

        return tSql;
    }

    private string SQL_InstruccionInstitucion(string CodInstitucion, string Institucion, int iAnoMes, int RolId, int CodDireccionRegional, int CodRegion, int UserId, out List<DbParameter> listDbParameter)
    {
        listDbParameter = new List<DbParameter>();
        string sWhere = string.Empty;
        string tSql = string.Empty;

        if (CodInstitucion.Trim() != "")
        {
            sWhere = sWhere + " AND i.CodInstitucion =@pCodInstitucion ";

            listDbParameter.Add(Conexiones.CrearParametro("@pCodInstitucion", SqlDbType.Int, 4, Convert.ToInt32(CodInstitucion.Trim())));
        }

        if (Institucion.Trim() != "")
        {
            sWhere = sWhere + " AND i.Nombre LIKE @pNombre ";

            listDbParameter.Add(Conexiones.CrearParametro("@pNombre", SqlDbType.VarChar, 100, "%" + Institucion.Trim() + "%"));
        }

        if (iAnoMes > 0)
        {
            sWhere = sWhere + " AND rc.AnoMes =@pAnoMes ";

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
            //if (CodDireccionRegional > 0)
            //{
            //    if (sWhere.Trim() == "")
            //        strWhere = " WHERE p.CodRegion = " + CodRegion + " ";
            //    else
            //        strWhere = " AND p.CodRegion = " + CodRegion + " ";
            //}
            //else
            //{
            //    if (sWhere.Trim() == "")
            //        strWhere = " WHERE u.idUsuario = " + UserId + " ";
            //    else
            //        strWhere = " AND u.idUsuario = " + UserId + " ";
            //}
        }

        sWhere += strWhere;

        tSql += "SELECT i.CodInstitucion, i.Nombre AS Institucion,";
        tSql += "ISNULL(i.CodBanco, '') as CodBanco, ISNULL(pb.Descripcion, '') AS Banco,ISNULL(i.CuentaCorrienteNumero, '') AS CuentaCorrienteNumero,";
        tSql += "rc.AnoMes, ISNULL(rc.NumChequeReintegro, 0) AS NumChequeReintegro,ISNULL(rc.MontoReintegro, 0) AS MontoReintegro, rc.AnoPptoReintegro, ";
        tSql += "rc.SaldoAnterior, rc.SaldoMes, rc.FechaRendicion, rc.Cerrado, rc.FechaActualizacion, ";
        tSql += "rc.IdusuarioActualizacion,  ";
        tSql += "ISNULL(rc.DeudaAnterior, 0) as DeudaAnterior, ISNULL(rc.DeudaMes, 0) as DeudaMes, ISNULL(rc.ProvisionIndemnizacion, 0) as ProvisionIndemnizacion, ISNULL(rc.SaldoReal, 0) as SaldoReal ";

        tSql += "FROM RendicionCuentasInstituciones rc ";
        tSql += "INNER JOIN Instituciones i ";
        tSql += "ON i.CodInstitucion = rc.CodInstitucion ";   // + CodInstitucion.Trim();
        tSql += "LEFT JOIN parBancos pb ";
        tSql += "ON i.CodBanco = pb.CodBanco ";

        tSql += strFrom;
        tSql += sWhere;

        return tSql; //metodo sobrecargado, revisar en consulta directa a SQL una vez generada la consulta.
    }
    public DataTable GetData(string Institucion, string CodProyecto, string Proyecto, int iAnoMes, DataTable dt, int UserId)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        DbParameter[] parametros = { };
        List<DbParameter> listDbParameter = null;

        int RolId = GetCod(1, UserId);
        int CodDireccionRegional = GetCod(2, UserId);
        int CodRegion = GetCod(3, UserId);

        string sql = SQL_Instruccion(Institucion, CodProyecto, Proyecto, iAnoMes, RolId, CodDireccionRegional, CodRegion, UserId, out listDbParameter);

        con.ejecutar(sql, listDbParameter, out datareader);

        DataRow dr;

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (System.Int32)datareader["CodInstitucion"];
                dr[1] = (System.String)datareader["Institucion"];
                dr[2] = (System.Int32)datareader["CodProyecto"];
                dr[3] = (System.String)datareader["Proyecto"];
                dr[5] = (System.Int32)datareader["Codbanco"];
                dr[6] = (System.String)datareader["Banco"];
                dr[7] = (System.String)datareader["CuentaCorrienteNumero"];

                if (iAnoMes < 0)
                {
                    dr[4] = (System.Int32)0;
                    dr[9] = (System.Int32)0;
                    dr[10] = (System.Int32)0;
                    dr[11] = (System.Int32)0;
                    dr[12] = (System.Int32)0;
                    dr[13] = (System.Int32)0;
                    dr[14] = (System.DateTime)System.DateTime.Today;
                    dr[15] = (System.Boolean)false;
                    dr[16] = (System.DateTime)System.DateTime.Today;
                    dr[17] = (System.Int32)1;
                }
                else
                {
                    dr[4] = (System.Int32)datareader["AnoMes"];
                    dr[9] = (System.Int32)datareader["NumChequeReintegro"];
                    dr[10] = (System.Int32)datareader["MontoReintegro"];
                    dr[11] = (System.Int32)datareader["AnoPptoReintegro"];
                    dr[12] = (System.Int32)datareader["SaldoAnterior"];
                    dr[13] = (System.Int32)datareader["SaldoMes"];
                    dr[14] = (System.DateTime)datareader["FechaRendicion"];
                    dr[15] = (System.Boolean)datareader["Cerrado"];
                    dr[16] = (System.DateTime)datareader["FechaActualizacion"];
                    dr[17] = (System.Int32)datareader["IdUsuarioActualizacion"];
                }
                dr[8] = (System.Int32)datareader["NumeroPlazas"];
                dr[18] = (System.String)datareader["RutNumeroProyecto"];
                dr[19] = (System.Int32)datareader["DeudaAnterior"];
                dr[20] = (System.Int32)datareader["DeudaMes"];
                dr[21] = (System.Int32)datareader["ProvisionIndemnizacion"];
                dr[22] = (System.Int32)datareader["SaldoReal"];

                dt.Rows.Add(dr);
            }
            catch
            { }
        }

        con.Desconectar();

        return dt;    
    }

    public DataTable GetDataInstituciones(string CodInstitucion, string Institucion, int iAnoMes, DataTable dt, int UserId)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        DbParameter[] parametros = { };
        List<DbParameter> listDbParameter = null;

        int RolId = GetCod(1, UserId);
        int CodDireccionRegional = GetCod(2, UserId);
        int CodRegion = GetCod(3, UserId);

        string sql = SQL_InstruccionInstitucion(CodInstitucion, Institucion, iAnoMes, RolId, CodDireccionRegional, CodRegion, UserId, out listDbParameter);

        con.ejecutar(sql, listDbParameter, out datareader);

        DataRow dr;

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (System.Int32)datareader["CodInstitucion"];
                dr[1] = (System.String)datareader["Institucion"];
                dr[3] = (System.Int32)datareader["Codbanco"];
                dr[4] = (System.String)datareader["Banco"];
                dr[5] = (System.String)datareader["CuentaCorrienteNumero"];

                if (iAnoMes < 0)
                {
                    dr[2] = (System.Int32)0;
                    dr[9] = (System.Int32)0;
                    dr[10] = (System.Int32)0;
                    dr[11] = (System.Int32)0;
                    dr[12] = (System.Int32)0;
                    dr[13] = (System.Int32)0;
                    dr[14] = (System.DateTime)System.DateTime.Today;
                    dr[15] = (System.Boolean)false;
                    dr[16] = (System.DateTime)System.DateTime.Today;
                    dr[17] = (System.Int32)1;
                }
                else
                {
                    dr[2] = (System.Int32)datareader["AnoMes"];
                    dr[7] = (System.Int32)datareader["NumChequeReintegro"];
                    dr[8] = (System.Int32)datareader["MontoReintegro"];
                    dr[9] = (System.Int32)datareader["AnoPptoReintegro"];
                    dr[10] = (System.Int32)datareader["SaldoAnterior"];
                    dr[11] = (System.Int32)datareader["SaldoMes"];
                    dr[12] = (System.DateTime)datareader["FechaRendicion"];
                    dr[13] = (System.Boolean)datareader["Cerrado"];
                    dr[14] = (System.DateTime)datareader["FechaActualizacion"];
                    dr[15] = (System.Int32)datareader["IdUsuarioActualizacion"];
                }
                //dr[6] = (System.Int32)datareader["NumeroPlazas"];
                //dr[16] = (System.String)datareader["RutNumeroProyecto"];
                dr[16] = (System.Int32)datareader["DeudaAnterior"];
                dr[17] = (System.Int32)datareader["DeudaMes"];
                dr[18] = (System.Int32)datareader["ProvisionIndemnizacion"];
                dr[19] = (System.Int32)datareader["SaldoReal"];

                dt.Rows.Add(dr);
            }
            catch
            { }
        }

        con.Desconectar();

        return dt;
    }

    public DataTable GetDataBancoInstitucion(string Institucion, DataTable dt)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        DbParameter[] parametros = { };
        List<DbParameter> listDbParameter = new List<DbParameter>();

        string sql = "select t1.CodInstitucion,  t1.Nombre as Institucion, t1.CodBanco, t2.Descripcion as Banco, t1.CuentaCorrienteNumero from Instituciones t1 left join parBancos t2 ON t1.CodBanco = t2.CodBanco where t1.CodInstitucion =@pCodInstitucion ";

        listDbParameter.Add(Conexiones.CrearParametro("@pCodInstitucion", SqlDbType.Int, 4, Convert.ToInt32(Institucion.Trim())));

        con.ejecutar(sql, listDbParameter, out datareader);

        DataRow dr;

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (System.Int32)datareader["CodInstitucion"];
                dr[1] = (System.String)datareader["Institucion"];
                dr[3] = (System.Int32)datareader["Codbanco"];
                dr[4] = (System.String)datareader["Banco"];
                dr[5] = (System.String)datareader["CuentaCorrienteNumero"];

                    dr[2] = (System.Int32)0;
                    dr[9] = (System.Int32)0;
                    dr[10] = (System.Int32)0;
                    dr[11] = (System.Int32)0;
                    dr[12] = (System.DateTime)System.DateTime.Today;
                    dr[13] = (System.Int32)0;
                    dr[14] = (System.DateTime)System.DateTime.Today;
                    dr[15] = (System.Boolean)false;
                    dr[16] = (System.Int32)0;
                    dr[17] = (System.Int32)1;
                    dr[2] = (System.Int32)0;
                    dr[7] = (System.Int32)0;
                    dr[8] = (System.Int32)0;
                    dr[9] = (System.Int32)0;
                    dr[10] = (System.Int32)0;
                    dr[11] = (System.Int32)0;
                    dr[12] = (System.DateTime)System.DateTime.Today; ;
                    dr[13] = (System.Boolean)false;
                    dr[14] = (System.DateTime)System.DateTime.Today; ;
                    dr[15] = (System.Int32)0;
                //dr[6] = (System.Int32)datareader["NumeroPlazas"];
                //dr[16] = (System.String)datareader["RutNumeroProyecto"];
                dr[16] = (System.Int32)0;
                dr[17] = (System.Int32)0;
                dr[18] = (System.Int32)0;
                dr[19] = (System.Int32)0;

                dt.Rows.Add(dr);
            }
            catch
            { }
        }

        con.Desconectar();

        return dt;
    }

    public DataTable Get_DirectoresProyectosFirma(Int32 CodProyecto, Int32 Tipo)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_DirectoresProyectosFirma";
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = CodProyecto;
        sqlc.Parameters.Add("@Tipo", SqlDbType.Int, 4).Value = Tipo;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable Get_ResponsableInstitucionesFirma(Int32 CodInstitucion, Int32 Tipo)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_ResponsableInstitucionesFirma";
        sqlc.Parameters.Add("@CodInstitucion", SqlDbType.Int, 4).Value = CodInstitucion;
        sqlc.Parameters.Add("@Tipo", SqlDbType.Int, 4).Value = Tipo;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable GetDataBalance(string CodProyecto, int iAnoMesDesde, int iAnoMesHasta, DataTable dt)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        DbParameter[] parametros = { };
        List<DbParameter> listDbParameter = null;

        string sql = SQL_Instruccion(CodProyecto, iAnoMesDesde, iAnoMesHasta, out listDbParameter);

        con.ejecutar(sql, listDbParameter, out datareader);

        DataRow dr;

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (System.String)datareader["Tipo"];
                dr[1] = (System.Int32)datareader["CodProyecto"];
                dr[2] = (System.Int32)datareader["AnoMes"];
                dr[3] = (System.String)datareader["Descripcion1"];
                dr[4] = (System.String)datareader["Descripcion2"];
                dr[5] = (System.Int32)datareader["Monto"];

                dt.Rows.Add(dr);
            }
            catch
            { }
        }

        con.Desconectar();

        return dt;
    }
    public DataTable GetDataDeudaInstitucion(string CodInstitucion, int iAnoMes, int iPagada)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        DbParameter[] parametros = { };
        List<DbParameter> listDbParameter = null;

        string sql = SQL_InstruccionDeudaInstitucion(CodInstitucion, iAnoMes, iPagada, out listDbParameter);

        con.ejecutar(sql, listDbParameter, out datareader);
        DataTable dt = new DataTable();

        dt.Columns.Add(new DataColumn("FechaDeuda", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("Objetivo", typeof(string)));
        dt.Columns.Add(new DataColumn("CodObjetivo", typeof(int)));
        dt.Columns.Add(new DataColumn("Uso", typeof(string)));
        dt.Columns.Add(new DataColumn("CodUso", typeof(int)));
        dt.Columns.Add(new DataColumn("Monto", typeof(int)));
        dt.Columns.Add(new DataColumn("IdRendicionDeudas", typeof(int)));
        dt.Columns.Add(new DataColumn("AnoMes", typeof(int)));

        DataRow dr;

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (System.DateTime)datareader["FechaDeuda"];
                dr[1] = (System.String)datareader["Objetivo"];
                dr[2] = (System.Int32)datareader["CodObjetivo"];
                dr[3] = (System.String)datareader["Uso"];
                dr[4] = (System.Int32)datareader["CodUso"];
                dr[5] = (System.Int32)datareader["Monto"];
                dr[6] = (System.Int32)datareader["IdRendicionDeudas"];
                dr[7] = (System.Int32)datareader["AnoMes"];

                dt.Rows.Add(dr);
            }
            catch
            { }
        }

        con.Desconectar();

        return dt;
    }
    public DataTable GetDataDeuda(string CodProyecto, int iAnoMes, int iPagada)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        DbParameter[] parametros = { };
        List<DbParameter> listDbParameter = null;

        string sql = SQL_Instruccion(CodProyecto, iAnoMes, iPagada, out listDbParameter);

        con.ejecutar(sql, listDbParameter, out datareader);
        DataTable dt = new DataTable();

        dt.Columns.Add(new DataColumn("FechaDeuda", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("Objetivo", typeof(string)));
        dt.Columns.Add(new DataColumn("CodObjetivo", typeof(int)));
        dt.Columns.Add(new DataColumn("Uso", typeof(string)));
        dt.Columns.Add(new DataColumn("CodUso", typeof(int)));
        dt.Columns.Add(new DataColumn("Monto", typeof(int)));
        dt.Columns.Add(new DataColumn("IdRendicionDeudas", typeof(int)));
        dt.Columns.Add(new DataColumn("AnoMes", typeof(int)));

        DataRow dr;

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (System.DateTime)datareader["FechaDeuda"];
                dr[1] = (System.String)datareader["Objetivo"];
                dr[2] = (System.Int32)datareader["CodObjetivo"];
                dr[3] = (System.String)datareader["Uso"];
                dr[4] = (System.Int32)datareader["CodUso"];
                dr[5] = (System.Int32)datareader["Monto"];
                dr[6] = (System.Int32)datareader["IdRendicionDeudas"];
                dr[7] = (System.Int32)datareader["AnoMes"];

                dt.Rows.Add(dr);
            }
            catch
            { }
        }

        con.Desconectar();

        return dt;
    }

    public DataTable GetDataResumen(string CodProyecto, int iAnoMes, int IE)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        DbParameter[] parametros = { };
        List<DbParameter> listDbParameter = null;

        string sql = SQL_InstruccionResumen(CodProyecto, iAnoMes, IE, out listDbParameter);

        con.ejecutar(sql, listDbParameter, out datareader);

        DataTable dt = new DataTable();
        DataRow dr;

        if (IE == 1)        // Ingreso
        {
            dt.Columns.Add(new DataColumn("TipoIngreso"));
            dt.Columns.Add(new DataColumn("DetalleIngreso"));
            dt.Columns.Add(new DataColumn("Total", typeof(Int32)));
        }
        else               // Egreso
        {
            dt.Columns.Add(new DataColumn("Objetivo"));
            dt.Columns.Add(new DataColumn("Total", typeof(Int32)));
        }

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                if (IE == 1)
                {
                    dr[0] = (System.String)datareader["TipoIngreso"];
                    dr[1] = (System.String)datareader["DetalleIngreso"];
                    dr[2] = (System.Int32)datareader["Total"];
                }
                else
                {
                    dr[0] = (System.String)datareader["Objetivo"];
                    dr[1] = (System.Int32)datareader["Total"];
                }

                dt.Rows.Add(dr);
            }
            catch
            { }
        }
        con.Desconectar();

        return dt;
    }

    public DataTable GetDataResumenInstitucion(string CodInstitucion, int iAnoMes, int IE)
    {
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        DbParameter[] parametros = { };
        List<DbParameter> listDbParameter = null;

        string sql = SQL_InstruccionResumenInstitucion(CodInstitucion, iAnoMes, IE, out listDbParameter);

        con.ejecutar(sql, listDbParameter, out datareader);

        DataTable dt = new DataTable();
        DataRow dr;

        if (IE == 1)        // Ingreso
        {
            dt.Columns.Add(new DataColumn("TipoIngreso"));
            dt.Columns.Add(new DataColumn("DetalleIngreso"));
            dt.Columns.Add(new DataColumn("Total", typeof(Int32)));
        }
        else               // Egreso
        {
            dt.Columns.Add(new DataColumn("Objetivo"));
            dt.Columns.Add(new DataColumn("Total", typeof(Int32)));
        }

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                if (IE == 1)
                {
                    dr[0] = (System.String)datareader["TipoIngreso"];
                    dr[1] = (System.String)datareader["DetalleIngreso"];
                    dr[2] = (System.Int32)datareader["Total"];
                }
                else
                {
                    dr[0] = (System.String)datareader["Objetivo"];
                    dr[1] = (System.Int32)datareader["Total"];
                }

                dt.Rows.Add(dr);
            }
            catch
            { }
        }
        con.Desconectar();

        return dt;
    }


    public DataTable GetRendicionAnterior(string CodProyecto, int iAnoMes, DataTable dt, int UserId)
    {
        int iAno = Convert.ToInt32(iAnoMes.ToString().Substring(0, 4));
        int iMes = Convert.ToInt32(iAnoMes.ToString().Substring(4, 2));

        if (iMes == 1)
        {
            iMes = 12;
            iAno = iAno - 1;
        }
        else
            iMes = iMes - 1;

        iAnoMes = (iAno * 100) + iMes;
        dt = GetData("", CodProyecto, "", iAnoMes, dt, UserId);
        return dt;
    }

    public DataTable GetRendicionAnteriorInstitucion(string CodInstitucion, string Institucion, int iAnoMes, DataTable dt, int UserId)
    {
        int iAno = Convert.ToInt32(iAnoMes.ToString().Substring(0, 4));
        int iMes = Convert.ToInt32(iAnoMes.ToString().Substring(4, 2));

        if (iMes == 1)
        {
            iMes = 12;
            iAno = iAno - 1;
        }
        else
            iMes = iMes - 1;

        iAnoMes = (iAno * 100) + iMes;
        dt = GetDataInstituciones(CodInstitucion, Institucion, iAnoMes, dt, UserId);
        return dt;
    }


    public int InsertUpdate( int CodProyecto, int AnoMes, int NumChequeReintegro, int MontoReintegro, int AnoPptoReintegro, int SaldoAnterior, int SaldoMes, DateTime FechaRendicion, int Cerrado, int DeudaAnterior, int DeudaMes, int ProvisionIndemnizacion, int SaldoReal, string Firma, string Cargo, int IdUsuarioActualizacion, int AuditadoCGR)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        DbParameter[] parametros =
        {
		con.parametros("@CodProyecto", SqlDbType.Int, 4, CodProyecto) ,
		con.parametros("@AnoMes", SqlDbType.Int, 4, AnoMes) ,
		con.parametros("@NumChequeReintegro", SqlDbType.Int, 4, NumChequeReintegro) ,
		con.parametros("@MontoReintegro", SqlDbType.Int, 4, MontoReintegro) ,
		con.parametros("@AnoPptoReintegro", SqlDbType.Int, 4, AnoPptoReintegro) ,
		con.parametros("@SaldoAnterior", SqlDbType.Int, 4, SaldoAnterior), 
		con.parametros("@SaldoMes", SqlDbType.Int, 4, SaldoMes), 
        con.parametros("@FechaRendicion", SqlDbType.DateTime, 16, System.DateTime.Today),
		con.parametros("@Cerrado", SqlDbType.Int, 4, Cerrado), 
		con.parametros("@DeudaAnterior", SqlDbType.Int, 4, DeudaAnterior), 
		con.parametros("@DeudaMes", SqlDbType.Int, 4, DeudaMes), 
		con.parametros("@ProvisionIndemnizacion", SqlDbType.Int, 4, ProvisionIndemnizacion), 
		con.parametros("@SaldoReal", SqlDbType.Int, 4, SaldoReal), 
		con.parametros("@Firma", SqlDbType.VarChar, 200, Firma), 
		con.parametros("@Cargo", SqlDbType.VarChar, 200, Cargo), 
        con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion),
        con.parametros("@AuditadoCGR", SqlDbType.Int, 4, AuditadoCGR)
		};

        con.ejecutarProcedimiento("Insert_Update_RendicionCuentas", parametros, out datareader);
        if (datareader.Read())
        {
            returnvalue = Convert.ToInt32(datareader["Retorno"]);
        }
        con.Desconectar();
        return returnvalue;
    }

    public int InsertUpdateInstituciones( int CodInstitucion, int AnoMes, int NumChequeReintegro, int MontoReintegro, int AnoPptoReintegro, int SaldoAnterior, int SaldoMes, DateTime FechaRendicion, int Cerrado, int DeudaAnterior, int DeudaMes, int ProvisionIndemnizacion, int SaldoReal, string Firma, string Cargo, int IdUsuarioActualizacion, int AuditadoCGR)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        DbParameter[] parametros =
        {
		con.parametros("@CodInstitucion", SqlDbType.Int, 4, CodInstitucion) ,
		con.parametros("@AnoMes", SqlDbType.Int, 4, AnoMes) ,
		con.parametros("@NumChequeReintegro", SqlDbType.Int, 4, NumChequeReintegro) ,
		con.parametros("@MontoReintegro", SqlDbType.Int, 4, MontoReintegro) ,
		con.parametros("@AnoPptoReintegro", SqlDbType.Int, 4, AnoPptoReintegro) ,
		con.parametros("@SaldoAnterior", SqlDbType.Int, 4, SaldoAnterior), 
		con.parametros("@SaldoMes", SqlDbType.Int, 4, SaldoMes), 
        con.parametros("@FechaRendicion", SqlDbType.DateTime, 16, System.DateTime.Today),
		con.parametros("@Cerrado", SqlDbType.Int, 4, Cerrado), 
		con.parametros("@DeudaAnterior", SqlDbType.Int, 4, DeudaAnterior), 
		con.parametros("@DeudaMes", SqlDbType.Int, 4, DeudaMes), 
		con.parametros("@ProvisionIndemnizacion", SqlDbType.Int, 4, ProvisionIndemnizacion), 
		con.parametros("@SaldoReal", SqlDbType.Int, 4, SaldoReal), 
        con.parametros("@Firma", SqlDbType.VarChar, 200, Firma), 
        con.parametros("@Cargo", SqlDbType.VarChar, 200, Cargo), 
        con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion),
        con.parametros("@AuditadoCGR", SqlDbType.Int, 4, AuditadoCGR)
		};

        con.ejecutarProcedimiento("Insert_Update_RendicionCuentasInstituciones", parametros, out datareader);
        if (datareader.Read())
        {
            returnvalue = Convert.ToInt32(datareader["Retorno"]);
        }
        con.Desconectar();
        return returnvalue;
    }

    public int InsertUpdate( int IdRendicionDeudas, int CodProyecto, int AnoMes, DateTime FechaDeuda, int CodUso, int Monto, DateTime FechaPago, int Pagada)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        DbParameter[] parametros =
        {
        con.parametros("@IdRendicionDeudas", SqlDbType.Int, 4, IdRendicionDeudas) ,
        con.parametros("@CodProyecto", SqlDbType.Int, 4, CodProyecto) ,
		con.parametros("@AnoMes", SqlDbType.Int, 4, AnoMes) ,
        con.parametros("@FechaDeuda", SqlDbType.DateTime, 16, FechaDeuda),
        con.parametros("@CodUso", SqlDbType.Int, 4, CodUso) ,
		con.parametros("@Monto", SqlDbType.Int, 4, Monto) ,
        con.parametros("@FechaPago", SqlDbType.DateTime, 16, FechaPago),
		con.parametros("@Pagada", SqlDbType.Int, 4, Pagada)
		};

        con.ejecutarProcedimiento("Insert_Update_RendicionDeudas", parametros, out datareader);
        if (datareader.Read())
        {
            returnvalue = Convert.ToInt32(datareader["Retorno"]);
        }
        con.Desconectar();
        return returnvalue;
    }

    public int InsertUpdateDeudasInstituciones( int IdRendicionDeudas, int CodInstitucion, int AnoMes, DateTime FechaDeuda, int CodUso, int Monto, DateTime FechaPago, int Pagada)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;
         Conexiones con = new Conexiones();
        DbParameter[] parametros =
        {
        con.parametros("@IdRendicionDeudas", SqlDbType.Int, 4, IdRendicionDeudas) ,
        con.parametros("@CodInstitucion", SqlDbType.Int, 4, CodInstitucion) ,
		con.parametros("@AnoMes", SqlDbType.Int, 4, AnoMes) ,
        con.parametros("@FechaDeuda", SqlDbType.DateTime, 16, FechaDeuda),
        con.parametros("@CodUso", SqlDbType.Int, 4, CodUso) ,
		con.parametros("@Monto", SqlDbType.Int, 4, Monto) ,
        con.parametros("@FechaPago", SqlDbType.DateTime, 16, FechaPago),
		con.parametros("@Pagada", SqlDbType.Int, 4, Pagada)
		};

        con.ejecutarProcedimiento("Insert_Update_RendicionDeudasInstituciones", parametros, out datareader);
        if (datareader.Read())
        {
            returnvalue = Convert.ToInt32(datareader["Retorno"]);
        }
        con.Desconectar();
        return returnvalue;
    }

    public int GetCod(int TipoCod, int UserId)
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
