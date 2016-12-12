using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mod_buscador_IngresoPII : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                bool existe = ConsultarAsignacion();

                if (existe == true)
                {
                    ConsultaProfAsignados();
                }
                else
                {
                    ConsultaProfInstitucion();
                }

               

            }
            catch (Exception ex)
            {
                Response.Write("error: " + ex.Message);
            }
        }
    }

    private bool ConsultarAsignacion()
    {
        int codInst = GetIdInstitucion();

        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "select count(*) from [dbo].[Profe_Rol_Centro] PRC inner join Trabajadores Tra on PRC.ICodTrabajador = Tra.ICodTrabajador where CodInstitucionInmueble = @CodInst and CodNino = @CodNino";
        sqlc.Parameters.Add("CodInst", SqlDbType.Int).Value = codInst;
        sqlc.Parameters.Add("CodNino", SqlDbType.Int).Value = Convert.ToInt32(Request["CodNino"]);

        sconn.Open();
        Int32 count = (Int32)sqlc.ExecuteScalar();
        sconn.Close();

        if (count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void ConsultaProfAsignados()
    {
        ConsultaProfInstitucion();
        int codInst = GetIdInstitucion();

        // Establece el string de conexión
        string cadenaConexion = ConfigurationManager.ConnectionStrings["Conexiones"].ToString();
        // Establece la consulta SQL a ejecutar
        string consulta =

        "select Tra.ICodTrabajador as IdTrabajador, Tra.Paterno + ' ' + Tra.Materno + ' ' + Tra.Nombres as nombre " +
        "from [dbo].[Profe_Rol_Centro] PRC " +
        "inner join Trabajadores Tra on PRC.ICodTrabajador = Tra.ICodTrabajador " +
        "where CodInstitucionInmueble = '" + codInst + "' and CodNino = '" + Convert.ToInt32(Request["CodNino"]) +"' ";


        // Crea un DataAdapter que será el encargado de ejecutar la consulta
        // y Posteriormente ingresar los datos a un DataSet
        SqlDataAdapter daTrabajadores = new SqlDataAdapter(consulta, cadenaConexion);
        // Crea el DataSet
        DataSet dsTrabajadores = new DataSet();
        // Llena el DataSet con la información de la base de datos
        daTrabajadores.Fill(dsTrabajadores, "Tra");

        List<string> list = new List<string>();
        foreach (DataRow dr in dsTrabajadores.Tables[0].Rows)
        {
            list.Add(dr[0].ToString());
        }
        ddlEod.Items.FindByValue(list[0]).Selected = true;
        ddlPic.Items.FindByValue(list[1]).Selected = true;
        ddlEtd.Items.FindByValue(list[2]).Selected = true;
        ddlTo.Items.FindByValue(list[3]).Selected = true;
        ddlCF.Items.FindByValue(list[4]).Selected = true;
        ddlEpe.Items.FindByValue(list[5]).Selected = true;
        string fecha = SeteaFecha();
        txtFecha.Text = fecha;
    }

    private String SeteaFecha()
    {
        int codInst = GetIdInstitucion();

        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText =
                            "select top 1 PRC.FechaIngreso " +
                            "from [dbo].[Profe_Rol_Centro] PRC " +
                            "inner join Trabajadores Tra on PRC.ICodTrabajador = Tra.ICodTrabajador " +
                            "where CodInstitucionInmueble = @codInst and CodNino = @CodNino";

        sqlc.Parameters.Add("codInst", SqlDbType.Int).Value = codInst;
        sqlc.Parameters.Add("CodNino", SqlDbType.Int).Value = Convert.ToInt32(Request["CodNino"]);

        sconn.Open();
        DateTime fecha = (DateTime)sqlc.ExecuteScalar();
        sconn.Close();
        
        return Convert.ToString(fecha);
    }

    private void ConsultaProfInstitucion()
    {
        // Establece el string de conexión
        string cadenaConexion = ConfigurationManager.ConnectionStrings["Conexiones"].ToString();
        // Establece la consulta SQL a ejecutar
        string consulta =

        "select distinct Tra.ICodTrabajador as IdTrabajador, Tra.Paterno + ' ' + Tra.Materno + ' ' + Tra.Nombres as nombre " +
        "from OrdenTribunalIngreso OTI " +
        "inner join Ingresos_Egresos IE on OTI.ICodIE = IE.ICodIE " +
        "inner join Proyectos Pro on IE.CodProyecto = Pro.CodProyecto " +
        "inner join Trabajadores Tra on Pro.CodInstitucion = Tra.CodInstitucion " +
        "where OTI.Ruc = '" + Request["Ruc"] + "' and Tra.IndVigencia = 'V'";


        // Crea un DataAdapter que será el encargado de ejecutar la consulta
        // y Posteriormente ingresar los datos a un DataSet
        SqlDataAdapter daTrabajadores = new SqlDataAdapter(consulta, cadenaConexion);
        // Crea el DataSet
        DataSet dsTrabajadores = new DataSet();
        // Llena el DataSet con la información de la base de datos
        daTrabajadores.Fill(dsTrabajadores, "Tra");
        // Pone el DataTable Tra como fuente de datos para el DropDownList
        ddlEod.DataSource = dsTrabajadores.Tables["Tra"].DefaultView;
        ddlPic.DataSource = dsTrabajadores.Tables["Tra"].DefaultView;
        ddlEtd.DataSource = dsTrabajadores.Tables["Tra"].DefaultView;
        ddlTo.DataSource = dsTrabajadores.Tables["Tra"].DefaultView;
        ddlCF.DataSource = dsTrabajadores.Tables["Tra"].DefaultView;
        ddlEpe.DataSource = dsTrabajadores.Tables["Tra"].DefaultView;
        // Asigna el valor a mostrar en el DropDownList
        ddlEod.DataTextField = "nombre";
        ddlPic.DataTextField = "nombre";
        ddlEtd.DataTextField = "nombre";
        ddlTo.DataTextField = "nombre";
        ddlCF.DataTextField = "nombre";
        ddlEpe.DataTextField = "nombre";
        // Asigna el valor del value en el DropDownList
        ddlEod.DataValueField = "IdTrabajador";
        ddlPic.DataValueField = "IdTrabajador";
        ddlEtd.DataValueField = "IdTrabajador";
        ddlTo.DataValueField = "IdTrabajador";
        ddlCF.DataValueField = "IdTrabajador";
        ddlEpe.DataValueField = "IdTrabajador";
        // Llena el DropDownList con los datos
        ddlEod.DataBind();
        ddlPic.DataBind();
        ddlEtd.DataBind();
        ddlTo.DataBind();
        ddlCF.DataBind();
        ddlEpe.DataBind();
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        DateTime fechaingreso = Convert.ToDateTime(txtFecha.Text);
        //int icodTrabajador = Convert.ToInt32(ddlCF.SelectedValue);
        string NomUsuario = GetNombreUsuario();
        int codnino = Convert.ToInt32(Request["CodNino"]);

        int codInstitucionInmueble = GetIdInstitucion();

        //Dictionary<idRol,ICodTrabajador>
        Dictionary<int, int> dcRolTrab = new Dictionary<int, int>();
        dcRolTrab.Add(1, Convert.ToInt32(ddlEod.SelectedValue)); // 1 = ddlEoD
        dcRolTrab.Add(2, Convert.ToInt32(ddlPic.SelectedValue)); // 2 = ddlPic
        dcRolTrab.Add(3, Convert.ToInt32(ddlEtd.SelectedValue)); // 3 = ddlEtd
        dcRolTrab.Add(4, Convert.ToInt32(ddlTo.SelectedValue));  // 4 = ddlTo
        dcRolTrab.Add(5, Convert.ToInt32(ddlCF.SelectedValue));  // 5 = ddlCF
        dcRolTrab.Add(6, Convert.ToInt32(ddlEpe.SelectedValue)); // 6 = ddlEpe


        try
        {

            foreach (var item in dcRolTrab)
            {
                AsignaProfesional(item.Key, item.Value, fechaingreso, NomUsuario, codnino, codInstitucionInmueble);
            }

            Response.Redirect("DetalleNNA.aspx?CodNino=" + Request["CodNino"] + "&Ruc=" + Request["Ruc"]);

        }

        catch (Exception ex)
        {
            Response.Write("error: " + ex.Message);
        }
        
    }

    private void AsignaProfesional(int idRol, int icodTrabajador, DateTime fechaingreso, string NomUsuario, int codnino, int codInstitucionInmueble)
    {

        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "[dbo].[SP_Insert_Update_Prof_Rol_centro]";
        sqlc.Parameters.AddWithValue("@CodNino", SqlDbType.Int).Value = codnino;
        sqlc.Parameters.AddWithValue("@ICodTrabajador", SqlDbType.Int).Value = icodTrabajador;
        sqlc.Parameters.AddWithValue("@IdRol", SqlDbType.Int).Value = idRol; // manual el rol segun el combo elegido
        sqlc.Parameters.AddWithValue("@CodInstitucionInmueble", SqlDbType.Int).Value = codInstitucionInmueble;
        sqlc.Parameters.AddWithValue("@NomUsuario", SqlDbType.VarChar).Value = NomUsuario;
        sqlc.Parameters.AddWithValue("@FechaIngreso", SqlDbType.DateTime).Value = fechaingreso;

        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);

        sconn.Open();
        sqlc.ExecuteNonQuery();
        sconn.Close();
    }

    private string GetNombreUsuario()
    {

        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "select Usuario from Usuarios where IdUsuario = @IdUsuario";
        sqlc.Parameters.Add("IdUsuario", SqlDbType.Int).Value = Convert.ToInt32(Session["IdUsuario"]);

        sconn.Open();
        string nombreUsuario = (string)sqlc.ExecuteScalar();
        sconn.Close();
        return nombreUsuario;

    }

    private int GetIdInstitucion()
    {

        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "select distinct Tra.CodInstitucion from OrdenTribunalIngreso OTI inner join Ingresos_Egresos IE on OTI.ICodIE = IE.ICodIE inner join Proyectos Pro on IE.CodProyecto = Pro.CodProyecto inner join Trabajadores Tra on Pro.CodInstitucion = Tra.CodInstitucion where OTI.Ruc = @Ruc and Tra.IndVigencia = 'V'";
        sqlc.Parameters.Add("Ruc", SqlDbType.VarChar).Value = Request["Ruc"];

        sconn.Open();   
        Int32 codInst = (Int32)sqlc.ExecuteScalar();
        sconn.Close();
        return codInst;

    }
}