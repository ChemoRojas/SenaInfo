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
//////using neocsharp.NeoDatabase;

public partial class Reportes_rep_instituciones : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RequiredFieldValidator1.Validate();
        if (!IsPostBack)
        {
            alerts.Visible = false;
            if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
            {
                Response.Redirect("~/logout.aspx");
            }
            else
            {
                getparregion();
                if (Session["CodRegion"] != null)
                    ddregion.SelectedValue = Session["CodRegion"].ToString();

                getinstitucionesxRgn();
                if (Session["CodInstitucion"] != null)
                    ddinstitucion.SelectedValue = Session["CodInstitucion"].ToString();

                getTipoInstituciones();

                alerts.Visible = false;
            }
        }

        //Se cargan en Session los datos utilizados
        Session["CodRegion"] = ddregion.SelectedValue;
        Session["CodInstitucion"] = ddinstitucion.SelectedValue;
    }

    private void limpiarDatosSession()
    {
        Session["CodRegion"] = null;
        Session["CodInstitucion"] = null;
    }

    protected void rv_fecha_Init(object sender, EventArgs e)
    {
        ((RangeValidator)sender).MaximumValue = DateTime.Today.ToString("dd-MM-yyyy");
        ((RangeValidator)sender).MinimumValue = "01-01-1900";

    }

    private void getparregion()
    {
        //parcoll par = new parcoll();
        //DataView dv1 = new DataView(par.GetparRegion());
        parcoll par = new parcoll();
        DataView dv1 = new DataView(par.GetDataRegion(Convert.ToInt32(Session["IdUsuario"])));
        ddregion.DataSource = dv1;
        ddregion.DataTextField = "Descripcion";
        ddregion.DataValueField = "CodRegion";
        dv1.Sort = "CodRegion";
        ddregion.DataBind();
        if (ddregion.SelectedValue == "15")
        {
            ddregion.SelectedValue = "-1";
        }
        else
        {
            if (dv1.Count == 2)
                ddregion.SelectedIndex = 1;
        }


    }
    private void getinstituciones()
    {
        institucioncoll inst = new institucioncoll();
        DataView dv2 = new DataView(inst.GetInstitucionReporte());
        ddinstitucion.DataSource = dv2;
        ddinstitucion.DataTextField = "Nombre";
        ddinstitucion.DataValueField = "CodInstitucion";
        dv2.Sort = "Nombre";
        ddinstitucion.DataBind();

        if (dv2.Count == 2)
            ddinstitucion.SelectedIndex = 1;
        else
            if (Session["CodInstitucion"] != null)
                ddinstitucion.SelectedValue = Session["CodInstitucion"].ToString();
    }
    private void getinstitucionesxRgn()
    {
        institucioncoll inst = new institucioncoll();
        DataView dv2 = new DataView(inst.GetDataxRgn(Convert.ToInt32(Session["IdUsuario"]), Convert.ToInt32(ddregion.SelectedValue)));
        ddinstitucion.DataSource = dv2;
        ddinstitucion.DataTextField = "Nombre";
        ddinstitucion.DataValueField = "CodInstitucion";
        dv2.Sort = "Nombre";
        ddinstitucion.DataBind();

        if (dv2.Count == 2)
        {
            ddinstitucion.SelectedIndex = 1;
        }
    }
    private void getTipoInstituciones()
    {
        institucioncoll TipoInst = new institucioncoll();
        DataView dv3 = new DataView(TipoInst.GetparTipoInstitucion_reporte());
        ddtipoInstitucion.DataSource = dv3;
        ddtipoInstitucion.DataTextField = "Descripcion";
        ddtipoInstitucion.DataValueField = "TipoInstitucion";
        dv3.Sort = "TipoInstitucion";
        ddtipoInstitucion.DataBind();

        if (dv3.Count == 2)
            ddtipoInstitucion.SelectedIndex = 1;
    }

    protected void btn_volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("../mod_reportes/index_reportes.aspx");
    }

    protected void ddown002_SelectIndexChanged(object sender, EventArgs e)
    {
        getinstitucionesxRgn();
    }
    protected void btn_buscar_Click(object sender, EventArgs e)
    {


        if ((cal_termino.Text == "") || (cal_termino.Text == ""))
        {
            cal_inicio.Text = Convert.ToDateTime("01-01-1900").ToShortDateString();
            cal_termino.Text = Convert.ToDateTime("01-01-1900").ToShortDateString();
        }

        if (Convert.ToDateTime(cal_inicio.Text) > Convert.ToDateTime(cal_termino.Text))
        {
            lbl_error.Visible = true;
            lbl_error.Text = "Debe Ingresar fecha de Inicio Mayor o Igual a Fin Periodo";
            cal_inicio.Focus(); 
            return;
        }
        string vig = "A"; 
        if (Convert.ToBoolean(rdb001.Checked)== true)
        {
            vig= "A";
        }
        if (Convert.ToBoolean(rdb002.Checked) == true)
        {
            vig = "T";
        }
        if (Convert.ToBoolean(rdb003.Checked) == true)
        {
            vig = "N";
        }
        cargaDTG(Convert.ToInt32(ddregion.SelectedValue), Convert.ToInt32(ddinstitucion.SelectedValue), Convert.ToDateTime(cal_inicio.Text), Convert.ToDateTime(cal_termino.Text),Convert.ToInt32(ddtipoInstitucion.SelectedValue), vig);
        if (cal_inicio.Text == "01-01-1900" || cal_termino.Text == "01-01-1900")
        {
            cal_inicio.Text = string.Empty;
            cal_termino.Text = string.Empty;
        }
    }
    private void cargaDTG(int region, int codinstitucion, DateTime fechainicio, DateTime fechatermino, int tipo, string vigentes)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = {con.parametros("@region",SqlDbType.Int,4,region),
                                 con.parametros("@codinstitucion",SqlDbType.Int,4, codinstitucion),
                                 con.parametros("@fechainicio",SqlDbType.DateTime,16, fechainicio),
                                 con.parametros("@fechatermino",SqlDbType.DateTime,16, fechatermino),
                                 con.parametros("@tipo",SqlDbType.Int,4,tipo),
                                 con.parametros("@vigentes",SqlDbType.VarChar,1, vigentes)	};

        con.ejecutarProcedimiento("reporte_institucion", parametros, out datareader);

        DataTable dt = new DataTable();
        dt.Columns.Add("CodInstitucion");
        dt.Columns.Add("Nombre");	        
        dt.Columns.Add("RutInstitucion", typeof(String));   
        dt.Columns.Add("TipoInstitucion");		            
                       

        DataRow dr;
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (System.Int32)datareader["CodInstitucion"];
                dr[1] = (System.String)datareader["Nombre"];
                dr[2] = (System.String)datareader["RutInstitucion"];
                dr[3] = (System.String)datareader["TipoInstitucion"];
                dt.Rows.Add(dr);
            }
            catch
            {
            }
        }
        con.Desconectar();


        DataView dv = new DataView(dt);
        if (dv.Count > 0)
        {
            grd001.DataSource = dv;
            grd001.DataBind();
            btn_excel.Visible = true;
            lbl_error.Text = string.Empty;
            alerts.Visible = false;
            grd001.Visible = true;
        }
        else
        {
            btn_excel.Visible = false;
            lbl_error.Visible = true;
            grd001.Visible = false;
            alerts.Visible = true;
            lbl_error_estile.Text = "No se han encontrado registros coincidentes";
            lbl_error_estile.Visible = true;

        }

    }

    protected void btn_limpiar_Click(object sender, EventArgs e)
    {
        try
        {
            grd001.Visible = false;
            btn_excel.Visible = false;
            lbl_error.Visible = false;
            ddregion.SelectedIndex = -1;
            ddinstitucion.SelectedIndex = -1;
            ddtipoInstitucion.SelectedIndex = -1;
            alerts.Visible = false;
            cal_inicio.Text = string.Empty;
            cal_termino.Text = string.Empty;
        }
        catch { }
    }
    protected void btn_excel_Click1(object sender, EventArgs e)
    {

        if ((cal_inicio.Text == "") || (cal_termino.Text == ""))
        {
            cal_inicio.Text = Convert.ToDateTime("01-01-1900").ToShortDateString();
            cal_termino.Text = Convert.ToDateTime("01-01-1900").ToShortDateString();
        }
        int region, codinstitucion, tipo;
        DateTime fechainicio, fechatermino;
        string vig = "A";
        region = Convert.ToInt32(ddregion.SelectedValue);
        codinstitucion = Convert.ToInt32(ddinstitucion.SelectedValue);
        fechainicio = Convert.ToDateTime(cal_inicio.Text);
        fechatermino = Convert.ToDateTime(cal_termino.Text);
        if (Convert.ToBoolean(rdb001.Checked) == true)
        {
            vig = "A";
        }
        if (Convert.ToBoolean(rdb002.Checked) == true)
        {
            vig = "T";
        }
        if (Convert.ToBoolean(rdb003.Checked) == true)
        {
            vig = "N";
        }

        //tipo = Convert.ToInt32(ddtipoInstitucion.SelectedValue);RPA
        tipo = Convert.ToInt32(ddtipoInstitucion.SelectedValue);
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=Reporte_Instituciones.xls");
        Response.Charset = "";
        this.EnableViewState = false;

        System.IO.StringWriter tw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
        //--------------------------------------------------------------------------------------
        //DbDataReader datareader = null;
        //;
        ////objconn = ASP.global_asax.globaconn;
        ///* Database db = new Database(objconn); */
        //Conexiones con = new Conexiones();
        //DbParameter[] parametros = {con.parametros("@region",SqlDbType.Int,4,region),
        //                     con.parametros("@codinstitucion",SqlDbType.Int,4, codinstitucion),
        //                     con.parametros("@fechainicio",SqlDbType.DateTime,16, fechainicio),
        //                     con.parametros("@fechatermino",SqlDbType.DateTime,16, fechatermino),
        //                     con.parametros("@tipo",SqlDbType.Int,4,tipo),
        //                     con.parametros("@vigentes",SqlDbType.VarChar,1,vig)
        //                                                            };
        //con.ejecutarProcedimiento("reporte_institucion", parametros, out datareader);


        SqlConnection sqlc = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());

        DataTable dt = new DataTable();

        SqlCommand cmd = new SqlCommand("reporte_institucion", sqlc);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = 1000;
        cmd.Parameters.Add("@region", SqlDbType.Int).Value = region;
        cmd.Parameters.Add("@codinstitucion", SqlDbType.Int).Value = codinstitucion;
        cmd.Parameters.Add("@fechainicio", SqlDbType.DateTime).Value = fechainicio;
        cmd.Parameters.Add("@fechatermino", SqlDbType.DateTime).Value = fechatermino;
        cmd.Parameters.Add("@tipo", SqlDbType.Int).Value = tipo;
        cmd.Parameters.Add("@estado", SqlDbType.VarChar).Value = vig;

        SqlDataAdapter sqlda = new SqlDataAdapter(cmd);

        cmd.Connection.Open();

        sqlda.Fill(dt);

        cmd.Connection.Close();


        //-------------------------------------------------------------------------------------
        //DataTable dt = new DataTable();
        //dt.Columns.Add("codinstitucion");
        //dt.Columns.Add("TipoInstitucion");	 //1	       
        //dt.Columns.Add("SistemaAdministrativo"); //2	
        //dt.Columns.Add("Comuna");		        //3
        //dt.Columns.Add("RutInstitucion");	    //4
        //dt.Columns.Add("Nombre");			    //5 
        //dt.Columns.Add("NombreCorto");			//6
        //dt.Columns.Add("Direccion");			//7   
        //dt.Columns.Add("Telefono");			    //8   
        //dt.Columns.Add("EMail");			    //9    
        //dt.Columns.Add("Fax");                  //10
        //dt.Columns.Add("CodigoPostal");         //11
        //dt.Columns.Add("RepresentanteLegal");   //12
        //dt.Columns.Add("RutRepresentante");     //13    
        //dt.Columns.Add("PersonaContacto");      //14
        //dt.Columns.Add("FechaAniversario");     //15
        //dt.Columns.Add("NombrePrimeraAutoridad");   //16
        //dt.Columns.Add("CargoPrimeraAutoridad");    //17
        //dt.Columns.Add("NumeroPersonalidadJuridica");//18
        //dt.Columns.Add("ModoInstitucion");      //19
        //dt.Columns.Add("DocumentoReconoce");    //20
        //dt.Columns.Add("FechaIngresoAlRegistro");   //21
        //dt.Columns.Add("NumeroDocumento");  //22
        //dt.Columns.Add("FechaDocumento");	//23	          
        //dt.Columns.Add("IndVigencia");      //24
        //dt.Columns.Add("Personeria");       //25
        //dt.Columns.Add("RutInterventor");   //26
        //dt.Columns.Add("NombreInterventor");    //27
        //dt.Columns.Add("vigentes");             //28
        //dt.Columns.Add("caducos");              //29
        ////dt.Columns.Add("monto");	            //30      
        //dt.Columns.Add("desde");                //31
        //dt.Columns.Add("hasta");                //32
        ////dt.Columns.Add("reporte");	            //33
        //DataRow dr;
        //while (datareader.Read())
        //{
        //    try
        //    {
        //        dr = dt.NewRow();
        //        dr[0] = (System.Int32)datareader["codinstitucion"];
        //        dr[1] = (System.String)datareader["TipoInstitucion"];
        //        dr[2] = (System.String)datareader["SistemaAdministrativo"];
        //        dr[3] = (System.String)datareader["Comuna"];
        //        dr[4] = (System.String)datareader["RutInstitucion"];
        //        dr[5] = (System.String)datareader["Nombre"];
        //        dr[6] = (System.String)datareader["NombreCorto"];
        //        dr[7] = (System.String)datareader["Direccion"];
        //        dr[8] = (System.String)datareader["Telefono"];
        //        dr[9] = (System.String)datareader["EMail"];
        //        dr[10] = (System.String)datareader["Fax"];
        //        dr[11] = (System.Int32)datareader["CodigoPostal"];
        //        dr[12] = (System.String)datareader["RepresentanteLegal"];
        //        dr[13] = (System.String)datareader["RutRepresentante"];
        //        dr[14] = (System.String)datareader["PersonaContacto"];
        //        dr[15] = (System.String)datareader["FechaAniversario"];
        //        dr[16] = (System.String)datareader["NombrePrimeraAutoridad"];
        //        dr[17] = (System.String)datareader["CargoPrimeraAutoridad"];
        //        dr[18] = (System.String)datareader["NumeroPersonalidadJuridica"];
        //        dr[19] = (System.String)datareader["ModoInstitucion"];
        //        dr[20] = (System.String)datareader["DocumentoReconoce"];
        //        dr[21] = (System.String)datareader["FechaIngresoAlRegistro"];
        //        dr[22] = (System.String)datareader["NumeroDocumento"];
        //        dr[23] = (System.String)datareader["FechaDocumento"];
        //        dr[24] = (System.String)datareader["IndVigencia"];
        //        dr[25] = (System.String)datareader["Personeria"];
        //        dr[26] = (System.String)datareader["RutInterventor"];
        //        dr[27] = (System.String)datareader["NombreInterventor"];
        //        dr[28] = (System.Int32)datareader["vigentes"];
        //        dr[29] = (System.Int32)datareader["caducos"];
        //        //dr[30] = (System.Int32)datareader["monto"];
        //        dr[31] = (System.String)datareader["desde"];
        //        dr[32] = (System.String)datareader["hasta"];
        //        //dr[33] = (System.String)datareader["reporte"];
        //        dt.Rows.Add(dr);
        //    }
        //    catch
        //    {
        //    }
        //}
        //con.Desconectar();

        DataView dv = new DataView(dt);
        DataGrid d1 = new DataGrid();

        d1.DataSource = dt;
        d1.DataBind();
        d1.RenderControl(hw);
        Response.Write(tw.ToString());
        Response.End();
        //Response.Close();


    }
}
