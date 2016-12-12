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
using System.Data.Sql;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlTypes;

using System.Collections.Generic;

/// <summary>
/// Descripción breve de Conexiones
/// </summary>
public class Conexiones
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
    int timeout = 180; //segs
    protected IDbConnection MConexion;
    protected bool EnTransaccion;
    protected IDbTransaction MTransaccion;
    //protected abstract IDbConnection CrearConexion(string cadena);
    //protected abstract IDbCommand ComandoSql(string comandoSql);
    static readonly System.Collections.Hashtable ColComandos = new System.Collections.Hashtable();

    #region Propiedades
    private string _servidor;

    public string Servidor
    {
        get { return _servidor; }
        set { _servidor = value; }
    }
    private string _base;

    public string Base
    {
        get { return _base; }
        set { _base = value; }
    }
    private string _usuario;

    public string Usuario
    {
        get { return _usuario; }
        set { _usuario = value; }
    }
    private string _passw;

    public string Passw
    {
        get { return _passw; }
        set { _passw = value; }
    }
    #endregion



    private void CargarParametros(IDbCommand com, Object[] args)
    {
        for (int i = 1; i < com.Parameters.Count; i++)
        {
            var p = (SqlParameter)com.Parameters[i];
            p.Value = i <= args.Length ? args[i - 1] : null;
        }
    }

    private IDbConnection CrearConexion(string cadenaConexion)
    {
        return new SqlConnection(cadenaConexion);
    }



    //Seccion de Transaccion
    //IniciarTransaccion: iniciar la trans
    //TerminarTransaccion: termina la trans haciendo commit

    // Crea u obtiene un objeto para conectarse a la base de datos.  
    protected IDbConnection Conexion
    {
        get
        {
            if (MConexion == null)
                MConexion = conn; //CrearConexion(conn.ConnectionString);
            else
                MConexion = conn;

            return MConexion;
        }
    }

    private IDbCommand Comando(string procedimientoAlmacenado)
    {
        SqlCommand com;
        if (ColComandos.Contains(procedimientoAlmacenado))
        {
            com = (SqlCommand)ColComandos[procedimientoAlmacenado];
            com.CommandTimeout = this.timeout;
        }
        else
        {

            var con2 = new SqlConnection(Conexion.ConnectionString);
            con2.Open();
            com = new SqlCommand(procedimientoAlmacenado, con2) { CommandType = CommandType.StoredProcedure, CommandTimeout =this.timeout };

            SqlCommandBuilder.DeriveParameters(com);
            con2.Close();
            con2.Dispose();
            ColComandos.Add(procedimientoAlmacenado, com);
        }
        com.Connection = (SqlConnection)Conexion;
        com.Transaction = (SqlTransaction)MTransaccion;
        return com;
    }




    private IDbCommand ComandoSql(string _comandoSql)
    {
        var com = new SqlCommand(_comandoSql, (SqlConnection)Conexion, (SqlTransaction)MTransaccion);
        return com;
    }

    public void IniciarTransaccion()
    {
        try
        {
            MTransaccion = Conexion.BeginTransaction();
            EnTransaccion = true;
        }
        finally
        { EnTransaccion = false; }
    }

    //Confirma la transacción activa. 
    public void TerminarTransaccion()
    {
        try
        { MTransaccion.Commit(); }
        finally
        {
            MTransaccion = null;
            EnTransaccion = false;
        }
    }

    //Cancela la transacción activa.
    public void AbortarTransaccion()
    {
        try
        { MTransaccion.Rollback(); }
        finally
        {
            MTransaccion = null;
            EnTransaccion = false;
        }
    }

    //Si no esta abierta la conexion se debe abrir
    public bool Autenticar()
    {
        if (Conexion.State != ConnectionState.Open)
            Conexion.Open();
        return true;
    }

    // cerrar conexion
    public void CerrarConexion()
    {
        if (Conexion.State != ConnectionState.Closed)
            MConexion.Close();
    }



    // Obtiene un Valor Escalar a partir de un Procedimiento Almacenado. 
    public object TraerValorOutputSql(string comadoSql)
    {
        // asignar el string sql al command
        var com = ComandoSql(comadoSql);
        // ejecutar el command
        com.ExecuteNonQuery();
        // declarar variable de retorno
        Object resp = null;

        // recorrer los parametros del Query (uso tipico envio de varias sentencias sql en el mismo command)
        foreach (IDbDataParameter par in com.Parameters)
            // si tiene parametros de tipo IO/Output retornar ese valor
            if (par.Direction == ParameterDirection.InputOutput || par.Direction == ParameterDirection.Output)
                resp = par.Value;
        return resp;
    }

    // Obtiene un Valor de una funcion Escalar a partir de un Procedimiento Almacenado, con Params de Entrada
    public object TraerValorEscalar(string procedimientoAlmacenado, params object[] args)
    {
        var com = Comando(procedimientoAlmacenado);
        CargarParametros(com, args);
        int i = Convert.ToInt32(com.ExecuteScalar());
        //MConexion.Close();
        return i;
    }

    public double TraerValorEscalar_Double(string procedimientoAlmacenado, params object[] args)
    {
        var com = Comando(procedimientoAlmacenado);
        CargarParametros(com, args);
        double i = Convert.ToDouble(com.ExecuteScalar());
        //MConexion.Close();
        return i;

    }

    // Ejecuta un query sql
    public int EjecutarSql(string comandoSql)
    {
        return ComandoSql(comandoSql).ExecuteNonQuery();
    }

    // Ejecuta un Procedimiento Almacenado en la base. 
    public int EjecutarSP(string procedimientoAlmacenado)
    {
        return Comando(procedimientoAlmacenado).ExecuteNonQuery();
    }

    //Ejecuta un Procedimiento Almacenado en la base, utilizando los parámetros. 
    public int EjecutarSP(string procedimientoAlmacenado, params  Object[] args)
    {
        var com = Comando(procedimientoAlmacenado);
        CargarParametros(com, args);
        var resp = com.ExecuteNonQuery();
        for (var i = 0; i < com.Parameters.Count; i++)
        {
            var par = (IDbDataParameter)com.Parameters[i];
            if (par.Direction == ParameterDirection.InputOutput || par.Direction == ParameterDirection.Output)
                args.SetValue(par.Value, i - 1);
        }
        return resp;
    }

    //Obtiene un DataSet a partir de un Procedimiento Almacenado y sus parámetros. 
    public DataTable TraerDataTable(string procedimientoAlmacenado, params Object[] args)
    {
        DataTable DataTable = TraerDataSet(procedimientoAlmacenado, args).Tables[0].Copy();
        //MConexion.Close();
        return DataTable;
    }

    //Obtiene un DataSet a partir de un Procedimiento Almacenado y sus parámetros. 
    public DataSet TraerDataSet(string procedimientoAlmacenado, params Object[] args)
    {
        var mDataSet = new DataSet();
        try
        {
           
            CrearDataAdapter(procedimientoAlmacenado, args).Fill(mDataSet);
            
        }
        catch (Exception ex)
        { }
        return mDataSet;
    }

    // Obtiene un DataReader a partir de un Procedimiento Almacenado y sus parámetros. 
    public IDataReader TraerDataReader(string procedimientoAlmacenado, params object[] args)
    {
        var com = Comando(procedimientoAlmacenado);
        CargarParametros(com, args);
        return com.ExecuteReader();
    }

    //Finalmente, es el turno de definir CrearDataAdapter, el cual aprovecha el método Comando para crear el comando necesario.
    protected IDataAdapter CrearDataAdapter(string procedimientoAlmacenado, params Object[] args)
    {
        var da = new SqlDataAdapter((SqlCommand)Comando(procedimientoAlmacenado));
        if (args.Length != 0)
            CargarParametros(da.SelectCommand, args);
        return da;
    } // end CrearDataAdapter

    // Obtiene un Valor a partir de un Procedimiento Almacenado, y sus parámetros. 
    public object TraerValorOutput(string procedimientoAlmacenado, params Object[] args)
    {
        // asignar el string sql al command
        var com = Comando(procedimientoAlmacenado);
        // cargar los parametros del SP
        CargarParametros(com, args);
        // ejecutar el command
        com.ExecuteNonQuery();
        // declarar variable de retorno
        Object resp = null;

        // recorrer los parametros del SP
        foreach (IDbDataParameter par in com.Parameters)
            // si tiene parametros de tipo IO/Output retornar ese valor
            if (par.Direction == ParameterDirection.InputOutput || par.Direction == ParameterDirection.Output)
                resp = par.Value;
        return resp;
    } 
    /// <summary>
    /// //////////////////////////////////////////////////////
    /// </summary>


    //public DbParameterCollection 


    public Conexiones()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //

        SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder(conn.ConnectionString);

        this.Servidor = csb.DataSource;
        this.Base = csb.InitialCatalog;
        this.Usuario = csb.UserID;
        this.Passw = csb.Password;

    }


    public void ejecutar(string _sql, List<DbParameter> listDbParameter)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = (_sql);
        cmd.CommandType = CommandType.Text;
        cmd.Connection = conn;

        if (listDbParameter != null)
        {
            foreach (DbParameter dbParameter in listDbParameter)
                cmd.Parameters.Add(dbParameter);
        }

        Conectar();
        cmd.ExecuteReader();
    }

    public void ejecutar(string _sql, List<DbParameter> listDbParameter, out DbDataReader dataReader)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = (_sql);
        cmd.CommandType = CommandType.Text;
        cmd.Connection = conn;

        if (listDbParameter != null)
        {
            foreach (DbParameter dbParameter in listDbParameter)
                cmd.Parameters.Add(dbParameter);
        }

        Conectar();
        dataReader = cmd.ExecuteReader();
    }

    public void ejecutar(string _sql)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = (_sql);
        cmd.CommandType = CommandType.Text;
        cmd.Connection = conn;
        Conectar();
        cmd.ExecuteReader();
    }



    public void ejecutar(string _sql, out DbDataReader dataReader)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = (_sql);
        cmd.CommandType = CommandType.Text;
        cmd.Connection = conn;
        cmd.CommandTimeout = 0;
        Conectar();
        dataReader = cmd.ExecuteReader();
    }

    public int ejecutarProcedimiento(string nombre)
    {
        SqlCommand cmd = parametrosProcedimiento(nombre, (DbParameter[])null);
        cmd.ExecuteNonQuery();
        return (int)cmd.Parameters["ReturnValue"].Value;
    }

    public int ejecutarProcedimiento(string nombre, DbParameter[] parametros)
    {
       
        SqlCommand cmd = parametrosProcedimiento(nombre, parametros);
        //si hay param de salida
        string salida = string.Empty;
        if (parametros != null)
        {
            foreach (SqlParameter dbParameter in parametros)
                if (dbParameter.Direction == ParameterDirection.Output)
                    salida = dbParameter.ParameterName;
        }

        if (cmd.Connection == null)
            cmd.Connection = this.conn;
        cmd.ExecuteNonQuery();
        
        if (salida== String.Empty)
            return cmd.ExecuteNonQuery();
        else
        return Convert.ToInt32(cmd.Parameters[salida].Value);
    }

    public void ejecutarProcedimiento(string nombre, out DbDataReader dataReader)
    {
        SqlCommand cmd = parametrosProcedimiento(nombre, (DbParameter[])null);
        dataReader = cmd.ExecuteReader();
    }

    public void ejecutarProcedimiento(string nombre, DbParameter[] parametros, out DbDataReader dataReader)
    {

        object[] argsx;
        argsx = new object[parametros.Length];
        int indice = 0;
        foreach (SqlParameter item in parametros)
        {
            argsx[indice] = item.Value;
            indice += 1;
        }

        this.Autenticar();
        dataReader = (DbDataReader)TraerDataReader(nombre, argsx);
    }

    protected SqlCommand parametrosProcedimiento(string nombre, DbParameter[] parametros)
    {
        Conectar();
        SqlCommand oleDbCommand = new SqlCommand(nombre);
        oleDbCommand.CommandType = CommandType.StoredProcedure;
        if (parametros != null)
        {
            foreach (SqlParameter dbParameter in parametros)
                oleDbCommand.Parameters.Add(dbParameter);
        }
        return oleDbCommand;
    }

    public DbParameter parametros(string nombre, SqlDbType tipo, int tamano, object valor)
    {
        //DbParameter dbp = new DbParameter(nombre, (DbType)tipo, tamano);
        //DbParameter dbp;
        SqlParameter dbp = new SqlParameter();

        dbp.ParameterName = nombre;
        dbp.SqlDbType = tipo;
        dbp.Direction = ParameterDirection.Input;
        if (valor != null)
            dbp.Value = valor;
        return (DbParameter)dbp;
    }

    public static DbParameter CrearParametro(string nombre, SqlDbType tipo, int tamano, object valor)
    {
        //DbParameter dbp = new DbParameter(nombre, (DbType)tipo, tamano);
        //DbParameter dbp;
        SqlParameter dbp = new SqlParameter();

        dbp.ParameterName = nombre;
        dbp.SqlDbType = tipo;
        dbp.Direction = ParameterDirection.Input;
        if (valor != null)
            dbp.Value = valor;
        return (DbParameter)dbp;
    }

    /// <summary>
    /// Crea un parámetro con nombre y valor para se usado en una consulta o procedimiento almacenado.
    /// </summary>
    /// <param name="nombre">Nombre del parámetro</param>
    /// <param name="valor">Valor del parámetro</param>
    /// <returns></returns>
    public DbParameter parametros(string nombre, object valor)
    {
        return (DbParameter)new SqlParameter(nombre, valor);
    }

    public DbParameter parametrosSalida(string nombre, SqlDbType tipo, int tamano)
    {
        SqlParameter dbp = new SqlParameter();

        dbp.ParameterName = nombre;
        dbp.DbType = (DbType)tipo;
        dbp.Direction = ParameterDirection.Output;
        return (DbParameter)dbp;
    }

    private void Conectar()
    {
         //** original **
        conn.Close();
         conn.Open();
         //** original **

        //if (conn.State != ConnectionState.Open)
        //{
        //    conn.Open();
        //}
    }

    public void Desconectar()
    {
        //** original **
        conn.Close();
        //** original **

        //if (conn.State != ConnectionState.Closed)
        //{
        //    conn.Close();
        //}
    }
}

