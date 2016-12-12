using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mod_ninos_DatosdeGestion_condicionesLeyRPA_Flexibilizacion : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { gettipoflexibilidad();
        ObtenerFlexibilizacion();
        }
    }
    private void gettipoflexibilidad()
    {
        parcoll par = new parcoll();
        DataView dv = new DataView(par.GetParFlexibilizacion());
        ddl_tipoParflexibilidad.DataSource = dv;
        ddl_tipoParflexibilidad.DataTextField = "Descripcion";
        ddl_tipoParflexibilidad.DataValueField = "CodFlexibilizacion";
        dv.Sort = "";
        ddl_tipoParflexibilidad.DataBind();

    }

    protected void lnk_guardar_Click(object sender, EventArgs e)
    {
        int CodFlexibilizado = int.Parse(ddl_tipoParflexibilidad.SelectedValue);
        int icodie = Convert.ToInt32(Session["SS_ICodIE"].ToString());
        DateTime fechainicio = DateTime.Parse(txt_fechaInicio.Text);
        DateTime fechatermino = DateTime.Parse(txt_fechatermino.Text);
        SqlCommand cmd = new SqlCommand();
        Conexiones con = new Conexiones();
        SqlConnection conex = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        con.Autenticar();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "Insertar_Flexibilizacion";
        cmd.Parameters.Add("CodFlexibilizado", SqlDbType.Int).Value = CodFlexibilizado;
        cmd.Parameters.Add("Icodie", SqlDbType.Int).Value = icodie;
        cmd.Parameters.Add("Fechainicio", SqlDbType.DateTime).Value = fechainicio;
        cmd.Parameters.Add("FechaTermino", SqlDbType.DateTime).Value = fechatermino;
        cmd.Connection = conex;

        try
        {
            conex.Open();
            SqlDataReader Retornodata = cmd.ExecuteReader();
            cmd.Connection.Close();
            Retornodata.Close();
        }
        catch (Exception ex)
        {
        }     
    }
    protected void ObtenerFlexibilizacion()
    {
        Conexiones con = new Conexiones();
        DataTable dt_get = (DataTable)con.TraerDataTable("Consulta_Flexibilizacion", 1);
        foreach (DataRow dt in dt_get.Rows)
        {
            string tipoFlexibilidad = dt["CodFlexibilizado"].ToString();
            string fechaInicio = dt["Fechainicio"].ToString();
            string fechaTermino = dt["FechaTermino"].ToString();
            ddl_tipoParflexibilidad.SelectedValue = tipoFlexibilidad;
            txt_fechaInicio.Text = fechaInicio;
            txt_fechatermino.Text = fechaTermino;
        }
    }
}