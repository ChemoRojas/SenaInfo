using System;
using System.Data;
using System.Collections;
using System.Data.Common;
////////using neocsharp.NeoDatabase;

using System.Collections.Generic;

namespace Argentis.Regmen
{
    /// <summary>
    /// Summary description for regcoll.
    /// </summary>
    /// 

    public class regmenlist : ArrayList { }
    public class regcoll
    {
        public regcoll()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public string GenerateSQLNinoisRed(string ap1, string ap2, string rut, string codnino, string sexo, string inst, string nombres, out List<DbParameter> listDbParameter)
        {
            listDbParameter = new List<DbParameter>();

            bool IsFirst = true;
            string tsql = "SELECT DISTINCT TOP 2000 T1.CodNino, T1.Rut, T1.Sexo, T1.Nombres, T1.Apellido_Paterno, T1.Apellido_Materno, T1.FechaNacimiento,";
            tsql += "T2.CodProyecto, T4.Nombre as NombreProy, T5.Nombre as NombreInst, T2.FechaIngreso, T3.FechaIngreso FROM Ninos T1 ";
            tsql += "INNER JOIN Ingresos T2 ON T2.Codnino = T1.Codnino ";
            tsql += "INNER JOIN Proyectos T4 ON T4.CodProyecto = T2.CodProyecto ";
            tsql += "INNER JOIN Instituciones T5 ON T5.CodInstitucion = T4.CodInstitucion ";
            tsql += "INNER JOIN Egresos T3 ON T3.CodProyecto = T2.CodProyecto AND T3.CodNino = T1.CodNino ";
            tsql += "WHERE ";

            if (ap1.Length > 1)
            {
                IsFirst = false;
                tsql += "T1.Apellido_Paterno =@pApellido_Paterno ";

                listDbParameter.Add(Conexiones.CrearParametro("@pApellido_Paterno", SqlDbType.VarChar, 50, ap1));
            }
            if (ap2.Length > 1)
            {
                if (!IsFirst)
                {
                    tsql += " AND ";
                }
                else
                {
                    IsFirst = false;
                }
                tsql += " T1.Apellido_Materno =@pApellido_Materno ";

                listDbParameter.Add(Conexiones.CrearParametro("@pApellido_Materno", SqlDbType.VarChar, 50, ap2));
            }
            if (rut.Length > 1)
            {
                if (!IsFirst)
                {
                    tsql += " AND ";
                }
                else
                {
                    IsFirst = false;
                }

                tsql += " T1.Rut =@pRut ";

                listDbParameter.Add(Conexiones.CrearParametro("@pRut", SqlDbType.VarChar, 11, rut));
            }
            if (codnino.Length > 1)
            {
                if (!IsFirst)
                {
                    tsql += " AND ";
                }
                else
                {
                    IsFirst = false;
                }
                tsql += " T1.CodNino =@pCodNino ";

                listDbParameter.Add(Conexiones.CrearParametro("@pCodNino", SqlDbType.Int, 4, Convert.ToInt32(codnino)));
            }
            if (sexo.Length > 0)
            {
                if (!IsFirst)
                {
                    tsql += " AND ";
                }
                else
                {
                    IsFirst = false;
                }
                tsql += " T1.sexo =@psexo ";

                listDbParameter.Add(Conexiones.CrearParametro("@psexo", SqlDbType.Char, 1, sexo));
            }
            if (inst.Length > 1)
            {
                if (!IsFirst)
                {
                    tsql += " AND ";
                }
                else
                {
                    IsFirst = false;
                }
                tsql += " T5.Nombre like @pNombre ";

                listDbParameter.Add(Conexiones.CrearParametro("@pNombre", SqlDbType.VarChar, 100, "%" + inst + "%"));
            }
            if (nombres.Length > 1)
            {
                if (!IsFirst)
                {
                    tsql += " AND ";
                }
                else
                {
                    IsFirst = false;
                }
                tsql += " T1.Nombres like @pNombres ";

                listDbParameter.Add(Conexiones.CrearParametro("@pNombres", SqlDbType.VarChar, 100, "%" + nombres + "%"));
            }


            return tsql;


        }


        public regmenlist GetData(string ap1, string ap2, string rut, string codnino, string sexo, string inst, string nombres)
        {
            DbDataReader datareader = null;
            /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
            DbParameter[] parametros = { };
            List<DbParameter> listDbParameter = null;

            string sql = GenerateSQLNinoisRed(ap1, ap2, rut, codnino, sexo, inst, nombres, out listDbParameter);

            con.ejecutar(sql, listDbParameter, out datareader);

            regmenlist rcoll = new regmenlist();
            regobject rgo = null;

            while (datareader.Read())
            {
                try
                {
                    rgo = new regobject();
                    rgo.CodNino = (System.Int32)datareader["CodNino"];
                    rgo.rut = (System.String)datareader["Rut"];
                    rgo.sexo = (System.String)datareader["Sexo"];
                    rgo.Nombres = (System.String)datareader["Nombres"];
                    rgo.Apellido_Paterno = (System.String)datareader["Apellido_Paterno"];
                    rgo.Apellido_Materno = (System.String)datareader["Apellido_Materno"];
                    rgo.FechaNacimiento = (System.DateTime)datareader["FechaNacimiento"];
                    rgo.CodProyecto = (System.Int32)datareader["CodProyecto"];
                    rgo.NombreProy = (System.String)datareader["NombreProy"];
                    rgo.NombreInst = (System.String)datareader["NombreInst"];
                    rgo.fchegdesde = (System.DateTime)datareader["FechaIngreso"];
                    rgo.fcheghasta = (System.DateTime)datareader["FechaIngreso"];
                    rcoll.Add(rgo);
                }
                catch
                { }
            }
            con.Desconectar();

            return rcoll;
        }




    }
}
