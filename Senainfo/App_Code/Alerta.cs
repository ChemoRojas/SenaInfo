using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Alerta
/// </summary>
public class Alerta
{

    SqlConnection sqlc = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());

    #region Properties

    private int cod_alerta;

    public int CodAlerta
    {
        get { return cod_alerta; }
        set { cod_alerta = value; }
    }

    private int Id_rel_catsubcat;

    public int IdRelCatsubcat
    {
        get { return Id_rel_catsubcat; }
        set { Id_rel_catsubcat = value; }
    }

    private int cod_tipo;

    public int CodTipo
    {
        get { return cod_tipo; }
        set { cod_tipo = value; }
    }

    private string desc_alerta;

    public string DescAlerta
    {
        get { return desc_alerta; }
        set { desc_alerta = value; }
    }

    private int icodie;

    public int ICodIE
    {
        get { return icodie; }
        set { icodie = value; }
    }

    private int cod_nino;

    public int CodNino
    {
        get { return cod_nino; }
        set { cod_nino = value; }
    }

    private int cod_estado;

    public int CodEstado
    {
        get { return cod_estado; }
        set { cod_estado = value; }
    }

    private DateTime fecha_creacion;

    public DateTime FechaCreacion
    {
        get { return fecha_creacion; }
        set { fecha_creacion = value; }
    }

    private DateTime fecha_modificacion;

    public DateTime FechaModificacion
    {
        get { return fecha_modificacion; }
        set { fecha_modificacion = value; }
    }

    private DateTime fecha_termino;

    public DateTime FechaTermino
    {
        get { return fecha_termino; }
        set { fecha_termino = value; }
    }

    private int id_usuario_creacion;

    public int IdUsrCreacion
    {
        get { return id_usuario_creacion; }
        set { id_usuario_creacion = value; }
    }

    private int id_usuario_termino;

    public int IdUsrTermino
    {
        get { return id_usuario_termino; }
        set { id_usuario_termino = value; }
    }

    private string url;

    public string Url
    {
        get { return url; }
        set { url = value; }
    }

    private string cua;

    public string Cua
    {
        get { return cua; }
        set { cua = value; }
    }

    private int origen;

    public int Origen
    {
        get { return origen; }
        set { origen = value; }
    }

    private int cod_nivel;

    public int CodNivel
    {
        get { return cod_nivel; }
        set { cod_nivel = value; }
    }

    private string cod_rol;

    public string CodRol
    {
        get { return(string) cod_rol; }
        set { cod_rol = value; }
    }

    private int cod_depto;

    public int CodDepto
    {
        get { return cod_depto; }
        set { cod_depto = value; }
    }

    private int cod_region;

    public int CodRegion
    {
        get { return cod_region; }
        set { cod_region = value; }
    }

    private int cod_modelo;

    public int CodModelo
    {
        get { return cod_modelo; }
        set { cod_modelo = value; }
    }

    private int cod_proyecto;

    public int CodProyecto
    {
        get { return cod_proyecto; }
        set { cod_proyecto = value; }
    }

    #endregion

    #region Instance

    public Alerta()
    {
        this.cod_alerta = 0;
        this.Id_rel_catsubcat = 0;
        this.cod_tipo = 0;
        this.desc_alerta = "";
        this.icodie = 0;
        this.cod_nino = 0;
        this.cod_estado = 0;
        this.fecha_creacion = default(DateTime);
        this.fecha_modificacion = default(DateTime);
        this.fecha_termino = default(DateTime);
        this.id_usuario_creacion = 0;
        this.id_usuario_termino = 0;
        this.url = "";
        this.cua = "";
        this.origen = 0;
        this.cod_nivel = 0;
        this.cod_rol = "0";
        this.cod_depto = 0;
        this.cod_region = 0;
        this.cod_modelo = 0;
        this.cod_proyecto = 0;
    }

    public Alerta(Alerta alerta)
    {
        this.cod_alerta = alerta.CodAlerta;
        this.Id_rel_catsubcat = alerta.IdRelCatsubcat;
        this.cod_tipo = alerta.CodTipo;
        this.desc_alerta = alerta.DescAlerta;
        this.icodie = alerta.ICodIE;
        this.cod_nino = alerta.CodNino;
        this.cod_estado = alerta.CodEstado;
        this.fecha_creacion = alerta.FechaCreacion;
        this.fecha_modificacion = alerta.FechaModificacion;
        this.fecha_termino = alerta.FechaTermino;
        this.id_usuario_creacion = alerta.IdUsrCreacion;
        this.id_usuario_termino = alerta.IdUsrTermino;
        this.url = alerta.Url;
        this.cua = alerta.Cua;
        this.origen = alerta.origen;
        this.cod_nivel = alerta.CodNivel;
        this.cod_rol = alerta.CodRol;
        this.cod_depto = alerta.CodDepto;
        this.cod_region = alerta.CodRegion;
        this.cod_modelo = alerta.CodModelo;
        this.cod_proyecto = alerta.CodProyecto;
    }

    #endregion


    #region Methods

    public DataTable getAlertas(int IdUsuario, int CodRol)
    {
        DataTable dt = new DataTable();

        SqlCommand Command  = new SqlCommand("getAlertas", sqlc);

        Command.CommandType = CommandType.StoredProcedure;
        Command.CommandTimeout = 100000000;
        Command.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = IdUsuario;
        Command.Parameters.Add("@Rol", SqlDbType.Int).Value = CodRol;

        SqlDataAdapter sqlda = new SqlDataAdapter(Command);

        Command.Connection.Open();

        sqlda.Fill(dt);

        Command.Connection.Close();

        return dt;
    }


    public bool updateEstadoAlertaxEgresoRealizado(Alerta alerta)
    {   
        bool alertaModificada = false;
        try
        {
            DataTable dt = new DataTable();

            SqlCommand Command = new SqlCommand("Update_Estado_AlertasxEgresoRealizado", sqlc);
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.Add("ICodIE", SqlDbType.Int).Value = alerta.ICodIE;
            Command.Parameters.Add("CodNino", SqlDbType.Int).Value = alerta.CodNino;
            Command.Parameters.Add("IdUsrTermino", SqlDbType.Int).Value = IdUsrTermino;
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

    public int getTipoAlerta(int CodAlerta)
    {
        DataTable dt = new DataTable();

        SqlCommand command = new SqlCommand("getTipoAlerta", sqlc);
        command.CommandType = CommandType.StoredProcedure;
        command.CommandTimeout = 1000000;
        command.Parameters.Add("@CodAlerta", SqlDbType.Int).Value = CodAlerta;

        SqlDataAdapter sqlda = new SqlDataAdapter(command);

        command.Connection.Open();

        sqlda.Fill(dt);

        command.Connection.Close();

        CodTipo = Convert.ToInt32(dt.Rows[0][0]);

        return CodTipo;
    }

    #endregion

}