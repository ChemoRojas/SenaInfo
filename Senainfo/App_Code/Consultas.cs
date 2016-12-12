using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

/// <summary>
/// Descripción breve de Consultas
/// </summary>
class Consultas
{
    protected SqlConnection cn;
    protected SqlDataAdapter da;
    protected SqlCommand cmd;
    protected DataTable dt;


    public Consultas()
    {
        //cn = new SqlConnection(cadenaConexion);
        cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
    }

    public Boolean EjecutaSP(string comando)
    {
        try
        {
            cn.Open();
            cmd = new SqlCommand(comando, cn);
            cmd.CommandTimeout = 3000000;

            if (cmd.ExecuteNonQuery() != 0)
            {
                return true;
            }
            else { return false; }
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            cn.Close();
        }
    }

    public DataTable ExecuteSPDataTable(string sp_name, ArrayList SqlParameters)
    {
        DataTable dt = new DataTable();

        using (SqlConnection mySqlConnection = cn)
        {
            // Define the command
            using (SqlCommand mySqlCommand = new SqlCommand())
            {
                mySqlCommand.Connection = mySqlConnection;
                mySqlCommand.CommandType = CommandType.StoredProcedure;
                mySqlCommand.CommandText = sp_name;
                mySqlCommand.CommandTimeout = 3000000;

                // Handle the parameters
                if (SqlParameters != null)
                {
                    foreach (SqlParameter param in SqlParameters)
                    {
                        mySqlCommand.Parameters.Add(param);
                    }
                }

                // Define the data adapter and fill the dataset
                using (SqlDataAdapter da = new SqlDataAdapter(mySqlCommand))
                {
                    da.Fill(dt);
                }
            }
        }
        return dt;
    }

    public void ExecuteSP(string sp_name, ArrayList SqlParameters)
    {

        using (SqlConnection mySqlConnection = cn)
        {
            // Define the command
            using (SqlCommand mySqlCommand = new SqlCommand())
            {
                mySqlCommand.Connection = mySqlConnection;
                mySqlCommand.CommandType = CommandType.StoredProcedure;
                mySqlCommand.CommandText = sp_name;
                mySqlCommand.CommandTimeout = 3000000;

                // Handle the parameters
                if (SqlParameters != null)
                {
                    foreach (SqlParameter param in SqlParameters)
                        mySqlCommand.Parameters.Add(param);
                }
                if (cn.State != ConnectionState.Open)
                {
                    cn.Open();
                }
                mySqlCommand.ExecuteNonQuery();
            }
        }
    }

    public Object ExecuteSPScalar(string sp_name, ArrayList SqlParameters)
    {
        Object res = new Object();
        using (SqlConnection mySqlConnection = cn)
        {
            // Define the command
            using (SqlCommand mySqlCommand = new SqlCommand())
            {
                mySqlCommand.Connection = mySqlConnection;
                mySqlCommand.CommandType = CommandType.StoredProcedure;
                mySqlCommand.CommandText = sp_name;
                mySqlCommand.CommandTimeout = 3000000;

                // Handle the parameters
                if (SqlParameters != null)
                {
                    foreach (SqlParameter param in SqlParameters)
                        mySqlCommand.Parameters.Add(param);
                }
                if (cn.State != ConnectionState.Open)
                {
                    cn.Open();
                }
                res = mySqlCommand.ExecuteScalar();
            }
        }
        return res;
    }

    public DataTable RetornoEjecutaSP(string procedimiento)
    {
        dt = new DataTable();
        string qry = procedimiento;
        //escribeLog("RetornoEjecutaSP", procedimiento);
        try
        {
            if (cn.State != ConnectionState.Open)
            {
                cn.Open();
            }
            da = new SqlDataAdapter(qry, cn);
            da.Fill(dt);
            cn.Close();
        }
        catch (Exception)
        {
            throw;
        }
        return dt;
    }
}


