using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mod_ninos_DatosdeGestion_condicionesLeyRPA_Art134bis : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getcesepermiso();
            ObtenerArticulo134();
        }
    }
 
    private void getcesepermiso()
    {
        parcoll par = new parcoll();
        DataView dv = new DataView(par.getparTerminoSalida());
        ddl_cesePermiso.DataSource = dv;
        ddl_cesePermiso.DataTextField = "Descripcion";
        ddl_cesePermiso.DataValueField = "CodTerminoSalida";
        dv.Sort = "";
        ddl_cesePermiso.DataBind();
        
    }
    protected void btn_update_situacionMigratoria_Click(object sender, EventArgs e)
     {
        int icodie = Convert.ToInt32(Session["SS_ICodIE"].ToString());
        Boolean laboral = rdb_laboral.Checked;
        Boolean capacitacion = rbl_capacitacion.Checked;
        Boolean educacion = rbl_educacion.Checked;
        string cesePermiso = ddl_cesePermiso.SelectedValue;
        DateTime fechaInicio = Convert.ToDateTime(calFechaCambio.Text);
        DateTime fechaTermino = Convert.ToDateTime(txt_fechatermino.Text);
        Boolean CumpleEstandar = rbl_cumpleestandar.Checked;

        SqlCommand cmd = new SqlCommand();
        Conexiones con = new Conexiones();
        SqlConnection conex = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        con.Autenticar();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "Insert_Articulo134bis";
        cmd.Parameters.Add("ICodie", SqlDbType.Int).Value = icodie;
        cmd.Parameters.Add("laboral", SqlDbType.Bit).Value = laboral;
        cmd.Parameters.Add("capacitacion", SqlDbType.Bit).Value = capacitacion;
        cmd.Parameters.Add("educacion", SqlDbType.Bit).Value = educacion;
        cmd.Parameters.Add("cesePermiso", SqlDbType.VarChar).Value = cesePermiso;
        cmd.Parameters.Add("fechaInicio", SqlDbType.DateTime).Value = fechaInicio;  
        cmd.Parameters.Add("fechaTermino", SqlDbType.DateTime).Value = fechaTermino;
        cmd.Parameters.Add("CumpleEstandar", SqlDbType.Bit).Value = CumpleEstandar;

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
    protected void validarCampos() // aun no se aplica limpieza de campos 
    {
        if (!rbl_laboral())
        { 

        }
        if (!rbl_Capacitacion())
        {

        }
        if (!rbl_Educacion())
        {
        }
        if (!rbl_CumplEestandar())
        { }
    }
    protected bool rbl_laboral()
    {
        if (rdb_laboral.Checked)
        {
            return true;
        }
        return false;
    }
    protected bool rbl_Capacitacion()
    {
        if (rbl_capacitacion.Checked)
        {
            return true;
        }
        return false;
    }
    protected bool rbl_Educacion()
    {
        if (rbl_educacion.Checked)
        {
            return true;
        }
        return false;
    }
    protected bool rbl_CumplEestandar()
    {
        if (rbl_cumpleestandar.Checked)
        {
            return true;
        }
        return false;
    }
    protected void ObtenerArticulo134()
    {
        Conexiones con = new Conexiones();
        DataTable dt_get = (DataTable)con.TraerDataTable("Consulta_Articulo134bis",1 );
        foreach (DataRow dt in dt_get.Rows)
        {
            int laboral = Convert.ToInt32(dt["Laboral"]);
            int capacitacion = Convert.ToInt32(dt["Capacitacion"]);
            int educacion = Convert.ToInt32(dt["Educacion"]);
            string cesePermiso = dt["CesePermiso"].ToString();
            int cumpleestandar = Convert.ToInt32(dt["CumpleEstandar"]);
            string fechaInicio = dt["Fechainicio"].ToString();
            string fechaTermino = dt["FechaTermino"].ToString();
            if (laboral == 1)
            {
                rdb_laboral.Checked = true;
            }
            else rdb_laboral.Checked = false;
            if (capacitacion == 1)
                rbl_capacitacion.Checked = true;
            else rbl_capacitacion.Checked = false;
            if (educacion == 1)
                rbl_educacion.Checked = true;
            else rbl_educacion.Checked = false;
            ddl_cesePermiso.SelectedValue = cesePermiso;
            if (cumpleestandar == 1)
                rbl_cumpleestandar.Checked = true;
            else rbl_cumpleestandar.Checked = false;
            calFechaCambio.Text = fechaInicio;
            txt_fechatermino.Text = fechaTermino;
        }
    }
}