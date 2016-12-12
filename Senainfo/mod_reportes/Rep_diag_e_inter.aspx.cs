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
using System.Drawing;

public partial class Reportes_rep_Diag_e_inter : System.Web.UI.Page
{
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
                if (!window.existetoken("3014920C-B438-4FE7-8261-7D33BBA4AC2A"))
                {
                    Response.Redirect("~/logout.aspx");
                }
                getparregion();
                getinstituciones();
                getproyectoxinst();
                btn_excel.Visible = false;

                if (Request.QueryString["sw"] == "3")
                {
                    ddinstitucion.SelectedValue = Request.QueryString["codinst"];
                    ddproyecto_SelectedIndexChanged(sender, e);
                }
                if (Request.QueryString["sw"] == "4")
                {
                    buscador_institucion bsc = new buscador_institucion();
                    int codinst = bsc.GetCodInstxCodProy(Convert.ToInt32(Request.QueryString["codinst"]));
                    ddinstitucion.SelectedValue = Convert.ToString(codinst);
                    ddregion.SelectedValue = "-1";
                    getproyectoxinst();
                    ddproyecto.SelectedValue = Request.QueryString["codinst"];
                }
            }
        }
    }
    protected void ddinstitucion_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddregion.SelectedValue == "-1" || ddregion.SelectedValue == "15")
        {
            getinstituciones();
        }
        else
        {
            getinstitucionesxRgn();
        }
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
        btn_excel.Visible = false;
        lbl_error.Visible = false;

    }
    protected void ddproyecto_SelectedIndexChanged(object sender, EventArgs e)
    {
        getproyectoxinst();
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
        if (ddregion.SelectedValue == "15")
        {
            ddregion.SelectedValue = "-1";
        }
    }
    private void getinstituciones()
    {
        institucioncoll inst = new institucioncoll();
        DataView dv2 = new DataView(inst.GetData(Convert.ToInt32(Session["IdUsuario"])));
        //DataView dv2 = new DataView(inst.GetInstitucionReporte());
        ddinstitucion.DataSource = dv2;
        ddinstitucion.DataTextField = "Nombre";
        ddinstitucion.DataValueField = "CodInstitucion";
        dv2.Sort = "Nombre";
        ddinstitucion.DataBind();
    }
    private void getinstitucionesxRgn()
    {
        institucioncoll inst = new institucioncoll();
        DataView dv2 = new DataView(inst.GetDataxRgn(Convert.ToInt32(Session["IdUsuario"]), Convert.ToInt32(ddregion.SelectedValue)));
        // DataView dv2 = new DataView(inst.GetInstitucionReportexRgn(Convert.ToInt32(ddregion.SelectedValue)));
        ddinstitucion.DataSource = dv2;
        ddinstitucion.DataTextField = "Nombre";
        ddinstitucion.DataValueField = "CodInstitucion";
        dv2.Sort = "Nombre";
        ddinstitucion.DataBind();
    }
    private void getproyectoxinst()
    {
        proyectocoll proy = new proyectocoll();
        // DataView dv3 = new DataView(proy.GetProyectos_Region_Institucion( Convert.ToInt32(ddregion.SelectedValue),Convert.ToInt32(Session["IdUsuario"]), "V", Convert.ToInt32(ddinstitucion.SelectedValue)));
        DataView dv3 = new DataView(proy.GetData(Convert.ToInt32(Session["IdUsuario"]), "V", Convert.ToInt32(ddinstitucion.SelectedValue)));
        //DataView dv3 = new DataView(proy.GetProyectoxInst(Convert.ToInt32(ddinstitucion.SelectedValue)));
        ddproyecto.DataSource = dv3;
        ddproyecto.DataTextField = "Nombre";
        ddproyecto.DataValueField = "CodProyecto";
        dv3.Sort = "CodProyecto";
        ddproyecto.DataBind();
    }
    protected void btn_volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("../mod_reportes/index_reportes.aspx");
    }
    protected void btnBuscaInstitucion_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Plan de Intervencion";
        string cadena = string.Empty;

        cadena = @"window.open(this.Page, '../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_reportes/Rep_diag_e_inter.aspx', 'Buscador', false, true, '500', '650', false, false, true)";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);
    }
    protected void btnBuscaProyecto_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Busca Proyectos";
        string cadena = string.Empty;

        cadena = @"window.open(this.Page, '../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_reportes/Rep_diag_e_inter.aspx', 'Buscador', false, true, '500', '650', false, false, true)";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);
    }



    protected void btn_buscar_Click(object sender, EventArgs e)
    {
         int val = validatesecurity();
         int mes = 0;
         if (cal_inicio.Text != "Seleccione Fecha" && cal_termino.Text != "Seleccione Fecha")
         {
             if (Convert.ToDateTime(cal_termino.Text).Year != Convert.ToDateTime(cal_inicio.Text).Year)
             {
                 if (Convert.ToDateTime(cal_termino.Text).Month != 1 || Convert.ToDateTime(cal_inicio.Text).Month != 12)
                 {
                     mes = 2;
                 }
             }
             else
             {
                 mes = Convert.ToInt32(Convert.ToDateTime(cal_termino.Text).Month - Convert.ToDateTime(cal_inicio.Text).Month);
             }
         }

         if (val == 0)
         {
             if (Convert.ToDateTime(cal_inicio.Text) > Convert.ToDateTime(cal_termino.Text))
             {
                 lbl_error.Visible = true;
                 lbl_error.Text = "Debe Ingresar fecha de Inicio Mayor o Igual a Fin Periodo";
                 cal_inicio.Focus();
                 return;
             }
             else if (cal_inicio.Text == "Seleccione Fecha")
             {
                 lbl_error.Visible = true;
                 lbl_error.Text = "Debe Ingresar fecha de Inicio del Periodo";
                 cal_inicio.Focus();
                 return;
             }
             else if (cal_termino.Text == "Seleccione Fecha")
             {
                 lbl_error.Visible = true;
                 lbl_error.Text = "Debe Ingresar fecha de Término del Periodo";
                 cal_inicio.Focus();
                 return;
             }
             else if (ddproyecto.SelectedValue == "0" && mes > 1)
             {
                 
                     lbl_error.Visible = true;
                     lbl_error.Text = "El Período no puede ser mayor a Un Mes";
                     cal_inicio.Focus();
                     return;
                 
             }
             else
             {
                 cargaDTG(Convert.ToInt32(ddregion.SelectedValue), Convert.ToInt32(ddinstitucion.SelectedValue), Convert.ToInt32(ddproyecto.SelectedValue), Convert.ToDateTime(cal_inicio.Text), Convert.ToDateTime(cal_termino.Text));
             }
         }
    }
    private void cargaDTG(int region, int codinstitucion, int codproyecto, DateTime fechainicio, DateTime fechatermino)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = {con.parametros("@region",SqlDbType.Int,4,region),
                                 con.parametros("@codinstitucion",SqlDbType.Int,4, codinstitucion),
                                 con.parametros("@codproyecto",SqlDbType.Int,4, codproyecto),
                                 con.parametros("@fechainicio",SqlDbType.DateTime,16, fechainicio),
                                 con.parametros("@fechatermino",SqlDbType.DateTime,16, fechatermino),
                                 con.parametros("@userid",SqlDbType.Int,4,Convert.ToInt32(Session["IdUsuario"]))};

        con.ejecutarProcedimiento("reporte_nino_diagnostico", parametros, out datareader);

        DataTable dt = new DataTable();

        dt.Columns.Add("CodProyecto");      //0
        dt.Columns.Add("nombproy");         //1
        dt.Columns.Add("codnino");          //2
        dt.Columns.Add("apellido_paterno"); //3
        dt.Columns.Add("apellido_materno"); //4
        dt.Columns.Add("nombres");          //5
        dt.Columns.Add("fechanacimiento");  //6
        dt.Columns.Add("fechaingreso");     //7
        dt.Columns.Add("fechaegreso");      //8
        dt.Columns.Add("permanencia");      //9
        dt.Columns.Add("intervenciones");   //10
        dt.Columns.Add("diligencias_sol");  //11
        dt.Columns.Add("diligencias_rea");  //12
        dt.Columns.Add("maltrato");         //13
        dt.Columns.Add("escolar");          //14
        dt.Columns.Add("droga");            //15
        dt.Columns.Add("sicologica");       //16
        dt.Columns.Add("social");           //17
        dt.Columns.Add("capacitacion");     //18
        dt.Columns.Add("laboral");          //19
        dt.Columns.Add("pfti");             //20
        dt.Columns.Add("vigencia");         //21
        DataRow dr;

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (System.Int32)datareader["CodProyecto"];
                dr[1] = (System.String)datareader["nombproy"];
                dr[2] = (System.Int32)datareader["codnino"];
                dr[3] = (System.String)datareader["apellido_paterno"];
                dr[4] = (System.String)datareader["apellido_materno"];
                dr[5] = (System.String)datareader["nombres"];
                dr[6] = (System.String)datareader["fechanacimiento"];
                dr[7] = (System.String)datareader["fechaingreso"];
                dr[8] = (System.String)datareader["fechaegreso"];
                dr[9] = (System.Int32)datareader["permanencia"];
                dr[10] = (System.Int32)datareader["intervenciones"];
                dr[11] = (System.Int32)datareader["diligencias_sol"];
                dr[12] = (System.Int32)datareader["diligencias_rea"];
                dr[13] = (System.String)datareader["maltrato"];
                dr[14] = (System.String)datareader["escolar"];
                dr[15] = (System.String)datareader["droga"];
                dr[16] = (System.String)datareader["sicologica"];
                dr[17] = (System.String)datareader["social"];
                dr[18] = (System.String)datareader["capacitacion"];
                dr[19] = (System.String)datareader["laboral"];
                dr[20] = (System.String)datareader["pfti"];
                dr[21] = (System.String)datareader["vigencia"];
                dt.Rows.Add(dr);
            }
            catch
            {
            }
        }
        con.Desconectar();
        con.CerrarConexion();
        DataView dv = new DataView(dt);
        if (dv.Count > 0)
        {
            grd001.DataSource = dv;
            grd001.DataBind();
            btn_excel.Visible = true;
            lbl_error.Visible = false;
            grd001.Visible = true;
        }
        else
        {
            btn_excel.Visible = false;
            lbl_error.Text = "No se han encontrado registros coincidentes";
            lbl_error.Visible = true;
            grd001.Visible = false;
        }

    }
    protected void btn_excel_Click(object sender, ImageClickEventArgs e)
    {
        int region, codinstitucion, codproyecto;
        DateTime fechainicio, fechatermino;

        region = Convert.ToInt32(ddregion.SelectedValue);
        codinstitucion = Convert.ToInt32(ddinstitucion.SelectedValue);
        codproyecto = Convert.ToInt32(ddproyecto.SelectedValue);
        fechainicio = Convert.ToDateTime(cal_inicio.Text);
        fechatermino = Convert.ToDateTime(cal_termino.Text);

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=Reporte_Nino_Diagnosticos.xls");
        Response.Charset = "";
        this.EnableViewState = false;

        System.IO.StringWriter tw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
        //--------------------------------------------------------------------------------------
        DbDataReader datareader = null;
        ;
        //objconn = ASP.global_asax.globaconn;
        /* Database db = new Database(objconn); */
        Conexiones con = new Conexiones();
        DbParameter[] parametros = {con.parametros("@region",SqlDbType.Int,4,region),
                                  con.parametros("@codinstitucion",SqlDbType.Int,4, codinstitucion),
                                 con.parametros("@codproyecto",SqlDbType.Int,4, codproyecto),
                                 con.parametros("@fechainicio",SqlDbType.DateTime,16, fechainicio),
                                 con.parametros("@fechatermino",SqlDbType.DateTime,16, fechatermino)};
        con.ejecutarProcedimiento("reporte_nino_diagnostico", parametros, out datareader);

        //-------------------------------------------------------------------------------------
        DataTable dt = new DataTable();
        dt.Columns.Add("codinstitucion"); //0
        dt.Columns.Add("nombinst"); //1
        dt.Columns.Add("CodProyecto"); //2
        dt.Columns.Add("nombproy");     //3
        dt.Columns.Add("CodRegion");    //4
        dt.Columns.Add("comuna");       //5
        dt.Columns.Add("codnino");      //6
        dt.Columns.Add("apellido_paterno"); //7
        dt.Columns.Add("apellido_materno"); //8
        dt.Columns.Add("nombres");          //9
        dt.Columns.Add("fechanacimiento");  //10
        dt.Columns.Add("rut");              //11
        dt.Columns.Add("fechaingreso");     //12
        dt.Columns.Add("fechaegreso");      //13
        dt.Columns.Add("permanencia");      //14
        dt.Columns.Add("intervenciones");   //15
        dt.Columns.Add("diligencias_sol");  //16
        dt.Columns.Add("diligencias_rea");  //17
        dt.Columns.Add("maltrato");         //18
        dt.Columns.Add("escolar");          //19
        dt.Columns.Add("droga");            //20
        dt.Columns.Add("sicologica");       //21
        dt.Columns.Add("social");           //22
        dt.Columns.Add("capacitacion");     //23
        dt.Columns.Add("laboral");          //24
        dt.Columns.Add("pfti");             //25
        dt.Columns.Add("vigencia");         //26
        dt.Columns.Add("ICodIE");           //27
        dt.Columns.Add("desde");            //28
        dt.Columns.Add("hasta");            //29
        dt.Columns.Add("reporte");          //30
        DataRow dr;

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (System.Int32)datareader["codinstitucion"];
                dr[1] = (System.String)datareader["nombinst"];
                dr[2] = (System.Int32)datareader["CodProyecto"];
                dr[3] = (System.String)datareader["nombproy"];
                dr[4] = (System.Int32)datareader["CodRegion"];
                dr[5] = (System.String)datareader["comuna"];
                dr[6] = (System.Int32)datareader["codnino"];
                dr[7] = (System.String)datareader["apellido_paterno"];
                dr[8] = (System.String)datareader["apellido_materno"];
                dr[9] = (System.String)datareader["nombres"];
                dr[10] = (System.String)datareader["fechanacimiento"];
                dr[11] = (System.String)datareader["rut"];
                dr[12] = (System.String)datareader["fechaingreso"];
                dr[13] = (System.String)datareader["fechaegreso"];
                dr[14] = (System.Int32)datareader["permanencia"];
                dr[15] = (System.Int32)datareader["intervenciones"];
                dr[16] = (System.Int32)datareader["diligencias_sol"];
                dr[17] = (System.Int32)datareader["diligencias_rea"];
                dr[18] = (System.String)datareader["maltrato"];
                dr[19] = (System.String)datareader["escolar"];
                dr[20] = (System.String)datareader["droga"];
                dr[21] = (System.String)datareader["sicologica"];
                dr[22] = (System.String)datareader["social"];
                dr[23] = (System.String)datareader["capacitacion"];
                dr[24] = (System.String)datareader["laboral"];
                dr[25] = (System.String)datareader["pfti"];
                dr[26] = (System.String)datareader["vigencia"];
                dr[27] = (System.Int32)datareader["ICodIE"];
                dr[28] = (System.String)datareader["desde"];
                dr[29] = (System.String)datareader["hasta"];
                dr[30] = (System.String)datareader["reporte"];
                dt.Rows.Add(dr);
            }
            catch
            {
            }
        }
        con.Desconectar();

        DataView dv = new DataView(dt);
        DataGrid d1 = new DataGrid();
        d1.DataSource = dv;
        d1.DataBind();
        d1.RenderControl(hw);
        Response.Write(tw.ToString());
        Response.End();
    }
    protected void btn_limpiar_Click(object sender, EventArgs e)
    {
        grd001.Visible = false;
        btn_excel.Visible = false;
        lbl_error.Visible = false;
        ddregion.SelectedIndex = -1;
        ddinstitucion.SelectedIndex = -1;
        ddproyecto.SelectedIndex = -1;
        cal_inicio.Text = "0";
        cal_termino.Text = "0";
    }
}
