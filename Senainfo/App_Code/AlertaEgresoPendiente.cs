using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de AlertaEgresoPendiente
/// </summary>
public class AlertaEgresoPendiente : IAlertas
{
    SqlConnection sqlc = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());

	public AlertaEgresoPendiente()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

  public int getTipoAlerta()
  {
      return 1;
  }

  public bool ActualizarAlerta(Alerta alerta)
  {
      bool alertaModificada = false;
      try
      {
          DataTable dt = new DataTable();

          SqlCommand Command = new SqlCommand("Update_Alerta", sqlc);


          //alerta.Cua = "ECS_" + alerta.CodNino;
          alerta.Cua = "ECS_" + alerta.CodNino;

          Command.CommandType = CommandType.StoredProcedure;
          Command.Parameters.Add("ICodIE", SqlDbType.Int).Value = alerta.ICodIE;
          Command.Parameters.Add("CodNino", SqlDbType.Int).Value = alerta.CodNino;
          Command.Parameters.Add("IdUsrTermino", SqlDbType.Int).Value = alerta.IdUsrTermino;
          Command.Parameters.Add("Cua", SqlDbType.VarChar).Value = alerta.Cua;
          Command.Parameters.Add("CodRol", SqlDbType.VarChar).Value = alerta.CodRol;
          Command.Parameters.Add("CodDepto", SqlDbType.Int).Value = alerta.CodDepto;
          Command.Parameters.Add("CodRegion", SqlDbType.Int).Value = alerta.CodRegion;
          Command.Parameters.Add("CodModelo", SqlDbType.Int).Value = alerta.CodModelo;
          Command.Parameters.Add("CodProyecto", SqlDbType.Int).Value = alerta.CodProyecto;

          Command.Connection.Open();

          Command.ExecuteNonQuery();

          Command.Connection.Close();

          alertaModificada = true;


          return alertaModificada;
      }
      catch
      {
          alertaModificada = false;
          return alertaModificada;
      }
  }
}