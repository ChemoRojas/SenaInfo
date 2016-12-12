using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mod_ninos_DatosdeGestion_condicionesLeyRPA_PlanMotivacional : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getcategoria();
            GetParCondicionPM1();
            GetParCondicionPM3();
            ObtenerPlanMotivacional();
        }
    }
    private void getcategoria()
    {
        parcoll par = new parcoll();
        DataView dv = new DataView(par.getparCategoriaPM());
        ddl_categoria.DataSource = dv;
        ddl_categoria.DataTextField = "Descripcion";
        ddl_categoria.DataValueField = "CodCategoria";
        dv.Sort = "";
        ddl_categoria.DataBind();

    }
    private void GetParCondicionPM1()
    {
        parcoll par = new parcoll();
        DataView dv = new DataView(par.GetParCondicionPM1());
        ddl_condicion1.DataSource = dv;
        ddl_condicion1.DataTextField = "Descripcion";
        ddl_condicion1.DataValueField = "CodCondicion";
        dv.Sort = "";
        ddl_condicion1.DataBind();  
    }
    private void GetParCondicionPM3()
    {
        parcoll par = new parcoll();
        DataView dv = new DataView(par.GetParCondicionPM3());
        ddl_condicion3.DataSource = dv;
        ddl_condicion3.DataTextField = "Descripcion";
        ddl_condicion3.DataValueField = "CodCondicion";
        dv.Sort = "";
        ddl_condicion3.DataBind();
    }

    protected void link_buttonGuardar_Click(object sender, EventArgs e)
    {
        int pernocta = 0;
        int diaspernocta = 0;
        int condicion4 = 0;
        int resultado = 0;

        int icodie = Convert.ToInt32(Session["SS_ICodIE"].ToString());
        int codcategoria = int.Parse(ddl_categoria.SelectedValue);
        int CodCondicion1 = int.Parse(ddl_condicion1.SelectedValue);
        if (rbt_pernotaSiempre.Checked)
            pernocta = 1;
        if (rbt_pernoctaAveces.Checked)
            pernocta = 1;
        int diasPernocta = int.Parse(txt_cantidadDiasPernocta.Text);
        int codcondicion3 = int.Parse(ddl_condicion3.SelectedValue);
        if (rdb_continuo.Checked)
            condicion4 = 1;
        if (rdb_discontinuo.Checked)
            condicion4 = 1;
        int cantidaddiasCondicion4 = int.Parse(txt_cantidaddeDias.Text);
        DateTime fechaIncio = DateTime.Parse(txt_fechaInicio.Text);
        DateTime fechaTermino = DateTime.Parse(txt_fechaTermino.Text);
        bool compromisoCumplimiento = chk_comproDeCumplimiento.Checked;
        bool certificado = chk_certificadoConstanciaContinuidad.Checked;
        if (rdb_positivo.Checked)
            resultado = 1;
        if (rdb_negativo.Checked)
            resultado = 1;

        SqlCommand cmd = new SqlCommand();
        Conexiones con = new Conexiones();
        SqlConnection conex = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        con.Autenticar();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "Insert_planMotivacional";
        cmd.Parameters.Add("Icodie", SqlDbType.Int).Value = icodie;
        cmd.Parameters.Add("CodCategoria", SqlDbType.Int).Value = codcategoria;
        cmd.Parameters.Add("CodCondicion1", SqlDbType.Int).Value = CodCondicion1;
        cmd.Parameters.Add("pernocta", SqlDbType.Int).Value = pernocta;
        cmd.Parameters.Add("DiasPernocta", SqlDbType.Int).Value = diasPernocta;
        cmd.Parameters.Add("CodCondicion3", SqlDbType.Int).Value = codcondicion3;
        cmd.Parameters.Add("Condicion4", SqlDbType.Int).Value = condicion4;
        cmd.Parameters.Add("DiasCondicion4", SqlDbType.Int).Value = cantidaddiasCondicion4;
        cmd.Parameters.Add("FechaInicio", SqlDbType.DateTime).Value = fechaIncio;
        cmd.Parameters.Add("FechaTermino", SqlDbType.DateTime).Value = fechaTermino;
        cmd.Parameters.Add("CompromisoCumplimiento", SqlDbType.Bit).Value = compromisoCumplimiento;
        cmd.Parameters.Add("Certificado", SqlDbType.Bit).Value = certificado;
        cmd.Parameters.Add("Resultado", SqlDbType.Int).Value = resultado;

        

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
    protected void ObtenerPlanMotivacional()
    {
        Conexiones con = new Conexiones();
        DataTable dt_get = (DataTable)con.TraerDataTable("Consulta_PlanMotivacional", 1);
        foreach(DataRow dt in dt_get.Rows)
        {
           //tipo falta
            string categoria = dt["CodCategoria"].ToString();
            string condicion = dt["CodCondicion1"].ToString();
            int pernocta = Convert.ToInt32(dt["Pernocta"]);
            string cantDiasPer = dt["DiasPernocta"].ToString();
            string Condicion3 = dt["CodCondicion3"].ToString();
            int Condicion4 = Convert.ToInt32(dt["Condicion4"]);
            string cantDias = dt["DiasCondicion4"].ToString();
            string fechaInicio = dt["FechaInicio"].ToString();
            int CompromisoCumplimiento = Convert.ToInt32(dt["CompromisoCumplimiento"]);
            string FechaTermino = dt["FechaTermino"].ToString();
            int Certificado = Convert.ToInt32(dt["Certificado"]);
            int resultado = Convert.ToInt32(dt["Resultado"]);

            ddl_categoria.SelectedValue = categoria;


        }
    }
}