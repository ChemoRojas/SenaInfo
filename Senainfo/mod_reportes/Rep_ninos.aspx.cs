using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;

public partial class Reportes_Rep_ninos : System.Web.UI.Page
{
    private DataTable dt_busqueda
    {
        get { return (DataTable)Session["dt_busqueda"]; }
        set { Session["dt_busqueda"] = value; }
    }
    public string proyecto_;
    protected void Page_Load(object sender, EventArgs e)
    {
      
        if (!IsPostBack)
        {
            if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
            {
                Response.Redirect("~/logout.aspx");
            }

            else
            {
                if (!window.existetoken("C4BFE91D-C904-47B0-B2C9-FD558E25BF29"))
                {

                    Response.Redirect("~/logout.aspx");

                }
                getparregion();
                if (Session["CodRegion"] != null)
                    ddregion.SelectedValue = Session["CodRegion"].ToString();


                getinstitucionesxRgn();
                if (Session["CodInstitucion"] != null)
                    ddinstitucion.SelectedValue = Session["CodInstitucion"].ToString();

                getproyectoxinst();
                if (Session["CodProyecto"] != null)
                    ddproyecto.SelectedValue = Session["CodProyecto"].ToString();

                ImageButton1.Visible = false;

                if (Request.QueryString["sw"] == "3")
                {
                    limpiarDatosSession();
                    ddinstitucion.SelectedValue = Request.QueryString["codinst"];
                    ddown002_SelectedIndexChanged(sender, e);
                }
                if (Request.QueryString["sw"] == "4")
                {
                    limpiarDatosSession();
                    buscador_institucion bsc = new buscador_institucion();
                    int codinst = bsc.GetCodInstxCodProy(Convert.ToInt32(Request.QueryString["codinst"]));
                    ddinstitucion.SelectedValue = Convert.ToString(codinst);
                    
                    if (Session["region_sel"] != null && Convert.ToInt32(Session["region_sel"]) != -1)
                        ddregion.SelectedValue = Session["region_sel"].ToString();
                    else
                    ddregion.SelectedValue = "-1";

                    getproyectoxinst();
                    ddproyecto.SelectedValue = Request.QueryString["codinst"];
                }
            }
           
        }
      
        RequiredFieldValidator1.Validate();
        proyecto_ = ddproyecto.SelectedValue;
        Session["CodRegion"] = ddregion.SelectedValue;
        Session["CodInstitucion"] = ddinstitucion.SelectedValue;
        Session["CodProyecto"] = ddproyecto.SelectedValue;
    }

    private void limpiarDatosSession()
    {
        Session["CodRegion"] = null;
        Session["CodInstitucion"] = null;
        Session["CodProyecto"] = null;
    }


    protected void rv_fecha_Init(object sender, EventArgs e)
    {
        ((RangeValidator)sender).MaximumValue = DateTime.Today.ToString("dd-MM-yyyy");
        ((RangeValidator)sender).MinimumValue = "01-01-1900";
    }
    private int validatesecurity()
    {
        trabajadorescoll tcol = new trabajadorescoll();
        string rol = tcol.get_rol(Convert.ToInt32(Session["IdUsuario"]));
        int val = 0;

        if (rol == "267" || rol == "265")
        {
            if (ddinstitucion.SelectedValue == "0")
            {
                ddinstitucion.BackColor = System.Drawing.Color.Pink;
                val = 1;
                limpiar();
            }
            else { ddinstitucion.BackColor = System.Drawing.Color.White; }

            if (ddproyecto.SelectedValue == "0")
            {
                ddproyecto.BackColor = System.Drawing.Color.Pink;
                val = 1;
                limpiar();
            }
            else { ddproyecto.BackColor = System.Drawing.Color.White; }
        }
        if (rol == "251")
        {
            if (ddinstitucion.SelectedValue == "0")
            {
                ddinstitucion.BackColor = System.Drawing.Color.Pink;
                val = 1;
                limpiar();
            }
            else { ddinstitucion.BackColor = System.Drawing.Color.White; }
        }

        return val;
    }
    private void limpiar()
    {
        grd001.Visible = false;
        ImageButton1.Visible = false;
        lbl_error.Visible = false;

    }
    private void getparregion()
    {
        parcoll par = new parcoll();
        DataView dv1 = new DataView(par.GetDataRegion(Convert.ToInt32(Session["IdUsuario"])));
        // DataView dv1 = new DataView(par.GetparRegion());
        ddregion.DataSource = dv1;
        ddregion.DataTextField = "Descripcion";
        ddregion.DataValueField = "CodRegion";
        dv1.Sort = "CodRegion";
        ddregion.DataBind();

        if (dv1.Count == 2)
            ddregion.SelectedIndex = 1;
    }
    private void getinstituciones()
    {
        institucioncoll inst = new institucioncoll();
        DataView dv2 = new DataView(inst.GetData(Convert.ToInt32(Session["IdUsuario"])));
        ddinstitucion.DataSource = dv2;
        ddinstitucion.DataTextField = "Nombre";
        ddinstitucion.DataValueField = "CodInstitucion";
        dv2.Sort = "Nombre";
        ddinstitucion.DataBind();

        if (dv2.Count == 2)
            ddinstitucion.SelectedIndex = 1;
    }
    private void getinstitucionesxRgn()
    {
        institucioncoll inst = new institucioncoll();
        DataView dv2 = new DataView(inst.GetDataxRgn(Convert.ToInt32(Session["IdUsuario"]), Convert.ToInt32(ddregion.SelectedValue)));
        //DataView dv2 = new DataView(inst.GetInstitucionReportexRgn(Convert.ToInt32(ddregion.SelectedValue)));        
        ddinstitucion.DataSource = dv2;
        ddinstitucion.DataTextField = "Nombre";
        ddinstitucion.DataValueField = "CodInstitucion";
        dv2.Sort = "Nombre";
        ddinstitucion.DataBind();

        if (dv2.Count == 2)
            ddinstitucion.SelectedIndex = 1;
    }
    private void getproyectoxinst()
    {
        proyectocoll proy = new proyectocoll();
        //DataView dv3 = new DataView(proy.GetProyectos_Region_Institucion(Convert.ToInt32(ddregion.SelectedValue), Convert.ToInt32(Session["IdUsuario"]), "V", Convert.ToInt32(ddinstitucion.SelectedValue)));
        DataView dv3 = new DataView(proy.GetProyectos_Region_Institucion(Convert.ToInt32(ddregion.SelectedValue), Convert.ToInt32(Session["IdUsuario"]), "V", Convert.ToInt32(ddinstitucion.SelectedValue)));
        // DataView dv3 = new DataView(proy.GetProyectoxInst(Convert.ToInt32(ddinstitucion.SelectedValue)));
        ddproyecto.DataSource = dv3;
        //dv3.RowFilter = "Codregion = " + ddregion.SelectedValue; 
        ddproyecto.DataTextField = "Nombre";
        ddproyecto.DataValueField = "CodProyecto";
        dv3.Sort = "CodProyecto";
        ddproyecto.DataBind();

        if (dv3.Count == 2)
            ddproyecto.SelectedIndex = 1;

        if (dv3.Count == 0)
            ddproyecto.Items.Add(new ListItem("Seleccionar", "0"));
    }

    //protected void btn_volver_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("../mod_reportes/index_reportes.aspx");
    //}
    private DataTable consulta_rol()
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        String sql = "Select * from usuarios where IdUsuario =" + Convert.ToInt32(Session["IdUsuario"]);
        con.ejecutar(sql, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodDireccionRegional", typeof(int)));
        dt.Columns.Add(new DataColumn("Contrasena", typeof(String)));
        dt.Columns.Add(new DataColumn("CodRegion", typeof(int)));

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodDireccionRegional"];
                dr[1] = (String)datareader["Contrasena"];
                dr[2] = (int)datareader["CodRegion"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;

    }
    protected void btn_buscar_Click(object sender, EventArgs e)
     {
        alerts.Visible = false;
        lbl_error.Visible = false;
        try
        {
            lbl_error.Text = "";
            int val = validatesecurity();
            int mes = 0;
            if (cal_inicio.Text != "" && cal_Termino.Text != "")
            {
                if (Convert.ToDateTime(cal_Termino.Text).Year != Convert.ToDateTime(cal_inicio.Text).Year)
                {
                    if (Convert.ToDateTime(cal_Termino.Text).Month != 1 || Convert.ToDateTime(cal_inicio.Text).Month != 12)
                    {
                        mes = 2;
                    }
                }
                else
                {
                    mes = Convert.ToInt32(Convert.ToDateTime(cal_Termino.Text).Month - Convert.ToDateTime(cal_inicio.Text).Month);
                }
            }

            if (ddregion.SelectedValue == "-2")
            {
                lbl_error.Visible = true;
                alerts.Visible = true;
                lbl_error.Text = "- Debe seleccionar la Región <br>";
                ddregion.Focus();
                val = 1;
            }

            DataTable dt = consulta_rol();
            if (Convert.ToString(dt.Rows[0][1]) == "252" || Convert.ToString(dt.Rows[0][1]) == "249" || Convert.ToString(dt.Rows[0][1]) == "263")
            { }
            else
            {

                if (ddinstitucion.SelectedValue == "0")
                {
                    lbl_error.Visible = true;
                    alerts.Visible = true;
                    lbl_error.Text += "- Debe seleccionar la Institutción <br>";
                    ddinstitucion.Focus();
                    val = 1;
                }
                ddproyecto.SelectedValue = proyecto_;
                if (proyecto_ == "0")
                {
                    lbl_error.Visible = true;
                    alerts.Visible = true;
                    lbl_error.Text += "- Debe seleccionar el proyecto <br>";
                    ddproyecto.Focus();
                    val = 1;
                }
            }

            if (val == 0)
            {
                if (cal_inicio.Text == "")
                {
                    lbl_error.Visible = true;
                    alerts.Visible = true;
                    lbl_error.Text = "Debe Ingresar la fecha de Inicio Periodo";
                    cal_inicio.Focus();
                    return;
                }
                else if (cal_Termino.Text == "")
                {
                    lbl_error.Visible = true;
                    alerts.Visible = true;
                    lbl_error.Text = "Debe Ingresar la fecha de Fin Periodo";
                    cal_Termino.Focus();
                    return;
                }
                else if (Convert.ToDateTime(cal_inicio.Text) > Convert.ToDateTime(cal_Termino.Text))
                {
                    lbl_error.Visible = true;
                    alerts.Visible = true;
                    lbl_error.Text = "Debe Ingresar fecha de Inicio Mayor o Igual a Fin Periodo";
                    cal_inicio.Focus();
                    return;
                }
                else if (ddproyecto.SelectedValue == "0" && mes > 1)
                {
                    lbl_error.Visible = true;
                    alerts.Visible = true;
                    lbl_error.Text = "El Período no puede ser mayor a Un Mes";
                    cal_inicio.Focus();
                    return;
                }
                else
                {
                    TimeSpan var;
                    var = Convert.ToDateTime(cal_Termino.Text).Subtract(Convert.ToDateTime(cal_inicio.Text));
                    if (var.Days >= 31)
                    {
                        lbl_error.Visible = true;
                        alerts.Visible = true;
                        lbl_error.Text = "La cantidad de días entre la fecha de inicio y término no debe exceder de 31 días";
                        //cal_inicio.Focus();
                    }
                    else
                    {
                        alerts.Visible = false;
                        lbl_error.Visible = false;
                        cargaDTG(Convert.ToInt32(ddregion.SelectedValue), Convert.ToInt32(ddinstitucion.SelectedValue), Convert.ToInt32(ddproyecto.SelectedValue), Convert.ToDateTime(cal_inicio.Text), Convert.ToDateTime(cal_Termino.Text), Convert.ToInt32(ddtipo.SelectedValue));

                    }
                }
                
            }
            if (val == 1)
            {
                alerts.Visible = false;
                lbl_error.Visible = false;
                cargaDTG(Convert.ToInt32(ddregion.SelectedValue), Convert.ToInt32(ddinstitucion.SelectedValue), Convert.ToInt32(ddproyecto.SelectedValue), Convert.ToDateTime(cal_inicio.Text), Convert.ToDateTime(cal_Termino.Text), Convert.ToInt32(ddtipo.SelectedValue));
            }
        }
        catch (Exception ex)
        {
            lbl_error.Text = ex.Message; alerts.Visible = false;
            lbl_error.Visible = false;
        }
 
        
    }

    private void cargaDTG(int region ,int codinstitucion ,int codproyecto ,DateTime fechainicio ,DateTime fechatermino ,int tipo  )
    {
      
	    SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
	    System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
	    sqlc.Connection = sconn;
	    sqlc.CommandType = System.Data.CommandType.StoredProcedure;
	    sqlc.CommandText = "reporte_nino";
		    sqlc.Parameters.Add("@Region",SqlDbType.Int, 4 ).Value = region;
		    sqlc.Parameters.Add("@CodInstitucion",SqlDbType.Int, 4 ).Value = codinstitucion;
		    sqlc.Parameters.Add("@CodProyecto",SqlDbType.Int, 4 ).Value = codproyecto;
		    sqlc.Parameters.Add("@FechaInicio",SqlDbType.DateTime, 16 ).Value = fechainicio;
		    sqlc.Parameters.Add("@FechaTermino",SqlDbType.DateTime, 16 ).Value = fechatermino;
		    sqlc.Parameters.Add("@Tipo",SqlDbType.Int, 4 ).Value = tipo;
            sqlc.Parameters.Add("@UserId", SqlDbType.Int, 4).Value = Convert.ToInt32(Session["IdUsuario"]);
	    System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
	    DataTable dt = new DataTable();
	    sconn.Open(); 
	    da.Fill(dt); 
	    sconn.Close();
        dt_busqueda = dt;
        DataView dv = new DataView(dt);
        if (dv.Count > 0)
        {
            alerts.Visible = false;
            lbl_error.Visible = false;
            lbl_error.Visible = false;
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=Reporte_Ninos_"+ ddtipo.SelectedItem.ToString()+".xls");
            Response.Charset = "";
            this.EnableViewState = false;

            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

            GridView grd002 = new GridView();
            grd002.DataSource = dv;
            grd002.DataBind();
            grd002.RenderControl(hw);
            Response.ContentEncoding = System.Text.Encoding.Default;
            Response.Write(tw.ToString());
            Response.End();
        }
        else
        {
            ImageButton1.Visible = false;
            lbl_error.Text = "No se han encontrado registros coincidentes";
            lbl_error.Visible = true;
            alerts.Visible = true;
            grd001.Visible = false;
        }

    }
    protected void ddown002_SelectedIndexChanged(object sender, EventArgs e)
    {
        getproyectoxinst();
    }
    protected void ddown001_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddregion.SelectedValue == "-1" )
        {
            getinstituciones();
            Session["region_sel"] = ddregion.SelectedValue;
        }
        else
        {
            getinstitucionesxRgn();
            Session["region_sel"] = ddregion.SelectedValue;
        }
    }


    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        alerts.Visible = false;
        lbl_error.Visible = false;
        Response.Clear();
        Response.Buffer = true;

        // Set the content type to Excel
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=Reporte_Nino.xls");
        // Remove the charset from the Content-Type header.
        Response.Charset = "";
        // Turn off the view state.
        this.EnableViewState = false;

        System.IO.StringWriter tw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

        DataTable dt = dt_busqueda;
        dt.Columns[0].ColumnName = "COD. INSTITUCION";	//0
        dt.Columns[1].ColumnName = "NOM. INSTITUCION";			//1
        dt.Columns[2].ColumnName = "COD. PROYECTO";		//2
        dt.Columns[3].ColumnName = "NOM. PROYECTO";		    //3
        dt.Columns[4].ColumnName = "COD. NIÑO";	    //4
        dt.Columns[5].ColumnName = "APELLIDO PATERNO";	        //5
        dt.Columns[6].ColumnName = "APELLIDO MATERNO";	        //6
        dt.Columns[7].ColumnName = "NOMBRES";	//7
        dt.Columns[8].ColumnName = "FECHA NACIMIENTO";	//8
        dt.Columns[9].ColumnName = "RUT";	        //9
        dt.Columns[10].ColumnName = "FECHA INGRESO";	//10
        dt.Columns[11].ColumnName = "FECHA EGRESO";	            //11
        dt.Columns[12].ColumnName = "VIGENCIA";	//12
        dt.Columns[13].ColumnName = "DESDE";	//13
        dt.Columns[14].ColumnName = "HASTA";	            //14
        dt.Columns[15].ColumnName = "REPORTE";		    //15
        dt.Columns[16].ColumnName = "SEXO";		    //16
        dt.Columns[17].ColumnName = "NACIONALIDAD";	//0
        dt.Columns[18].ColumnName = "TIPO ATENCION";			//1
        dt.Columns[19].ColumnName = "CALIDAD JURIDICA";		//2
        dt.Columns[20].ColumnName = "DIRECCION NINO";		    //3
        dt.Columns[21].ColumnName = "REGION NINO";	    //4
        dt.Columns[22].ColumnName = "COMUNA";	        //5
        dt.Columns[23].ColumnName = "TIPO SOLICITANTE INGRESO";	        //6
        dt.Columns[24].ColumnName = "SOLICITANTE INGRESO";	//7
        dt.Columns[25].ColumnName = "TRIBUNAL";	//8
        dt.Columns[26].ColumnName = "RUC";	        //9
        dt.Columns[27].ColumnName = "RIT";	//10
        dt.Columns[28].ColumnName = "CAUSAL INGRESO 1";	            //11
        dt.Columns[29].ColumnName = "CAUSAL INGRESO 2";	//12
        dt.Columns[30].ColumnName = "CAUSAL INGRESO 3";	//13
       // dt.Columns[31].ColumnName = "COD. CAUSAL EGRESO";	            //14
        dt.Columns[31].ColumnName = "TIPO CAUSAL EGRESO";		    //15
        dt.Columns[32].ColumnName = "CAUSAL EGRESO";		    //16
        dt.Columns[33].ColumnName = "CON QUIEN EGRESA";	//0
        dt.Columns[34].ColumnName = "CON QUIEN VIVE";			//1
        

        DataView dv = new DataView(dt);
        DataGrid d1 = new DataGrid();
        d1.DataSource = dv;
        d1.DataBind();
        d1.RenderControl(hw);
        Response.ContentEncoding = System.Text.Encoding.Default;
        Response.Write(tw.ToString());
        Response.End();
    }

    protected void btn_limpiar_Click(object sender, EventArgs e)
    {
        alerts.Visible = false;
        grd001.Visible = false;
        ImageButton1.Visible = false;
        lbl_error.Visible = false;
        cal_inicio.Text = string.Empty;
        cal_Termino.Text = string.Empty;
        
        ddregion.SelectedIndex = -1;
        ddinstitucion.SelectedIndex = -1;
        ddproyecto.SelectedIndex = -1;
        //cal_inicio.Value = 0;
        //cal_Termino.Value = 0;


    }

    //protected void btnBuscaInstitucion_Click(object sender, ImageClickEventArgs e)
    //{
    //    string etiqueta = "Plan de Intervencion";
    //    window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_reportes/Rep_ninos.aspx", "Buscador", false, true, 500, 650, false, false, true);
    //}
    //protected void btnBuscaProyecto_Click(object sender, ImageClickEventArgs e)
    //{
    //    string etiqueta = "Busca Proyectos";
    //    window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_reportes/Rep_ninos.aspx", "Buscador", false, true, 500, 650, false, false, true);
    //}

    protected void ImageButton1_Click1(object sender, EventArgs e)
    {

    }
    protected void ddproyecto_SelectedIndexChanged(object sender, EventArgs e)
    {
        getproyectoxinst();
        ddproyecto.SelectedValue = proyecto_;
    }
}
