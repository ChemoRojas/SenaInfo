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

public partial class Reportes_Rep_ninos : System.Web.UI.Page
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

                ImageButton12.Visible = false;

                if (Request.QueryString["sw"] == "3")
                {
                    ddinstitucion.SelectedValue = Request.QueryString["codinst"];
                    ddown002_SelectedIndexChanged(sender, e);
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
        alerts.Visible = false;
        RequiredFieldValidator1.Validate();

        Session["CodRegion"] = ddregion.SelectedValue;
        Session["CodInstitucion"] = ddinstitucion.SelectedValue;
        Session["CodProyecto"] = ddproyecto.SelectedValue;
    }

    private void limpiaSession()
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
        else
        {
            if (dv1.Count == 2)
                ddregion.SelectedIndex = 1;
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
        ImageButton12.Visible = false;
        lbl_error.Visible = false;
        alerts.Visible = false;

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
        {
            ddinstitucion.SelectedIndex = 1;
        }
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
        DataView dv3;
        proyectocoll proy = new proyectocoll();
        if (Convert.ToInt32(ddregion.SelectedValue) > 0 && Convert.ToInt32(ddregion.SelectedValue) < 14)
        {
            
            dv3 = new DataView(proy.GetProyectos_Region_Institucion(Convert.ToInt32(ddregion.SelectedValue), Convert.ToInt32(Session["IdUsuario"]), "V", Convert.ToInt32(ddinstitucion.SelectedValue)));
            ddproyecto.DataSource = dv3;
            ddproyecto.DataTextField = "Nombre";
            ddproyecto.DataValueField = "CodProyecto";
            dv3.Sort = "CodProyecto";
            ddproyecto.DataBind();
        }
        else
        {
            dv3 = new DataView(proy.GetData(Convert.ToInt32(Session["IdUsuario"]), "V", Convert.ToInt32(ddinstitucion.SelectedValue)));
            ddproyecto.DataSource = dv3;
            ddproyecto.DataTextField = "Nombre";
            ddproyecto.DataValueField = "CodProyecto";
            dv3.Sort = "CodProyecto";
            ddproyecto.DataBind();
        }

        if (dv3.Count == 2)
        {
            ddproyecto.SelectedIndex = 1;
        }
    }

    protected void btn_volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("../mod_reportes/index_reportes.aspx");
    }

    protected void btn_buscar_Click(object sender, EventArgs e)
    {
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
        if (val == 0)
        {
            if (cal_inicio.Text == "")
            {
                alerts.Visible = true;
                lbl_error.Visible = true;
                lbl_error.Text = "Debe Ingresar la fecha de Inicio Periodo";
                cal_inicio.Focus();
                return;
            }
            else if (cal_Termino.Text == "")
            {
                alerts.Visible = true;
                lbl_error.Visible = true;
                lbl_error.Text = "Debe Ingresar la fecha de Fin Periodo";
                cal_Termino.Focus();
                return;
            }
            else if (Convert.ToDateTime(cal_inicio.Text) > Convert.ToDateTime(cal_Termino.Text))
            {
                lbl_error.Visible = true;
                lbl_error.Text = "Debe Ingresar fecha de Inicio Mayor o Igual a Fin Periodo";
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
                cargaDTG(Convert.ToInt32(ddregion.SelectedValue), Convert.ToInt32(ddinstitucion.SelectedValue), Convert.ToInt32(ddproyecto.SelectedValue), Convert.ToDateTime(cal_inicio.Text), Convert.ToDateTime(cal_Termino.Text));
            }
        }
    }
    private void cargaDTG(int region, int codinstitucion, int codproyecto, DateTime fechainicio, DateTime fechatermino)
    {
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */
        Conexiones con = new Conexiones();
        DbParameter[] parametros = {con.parametros("@region",SqlDbType.Int,4,region),
                                             
                                 con.parametros("@codinstitucion",SqlDbType.Int,4, codinstitucion),
                                 con.parametros("@codproyecto",SqlDbType.Int ,4, codproyecto),
                                 con.parametros("@fechainicio",SqlDbType.DateTime,16, fechainicio),
                                 con.parametros("@fechatermino",SqlDbType.DateTime,16, fechatermino),
                                 con.parametros("@userid",SqlDbType.Int,4,Convert.ToInt32(Session["IdUsuario"]))
										};

        con.ejecutarProcedimiento("Reporte_NinosVisitados", parametros, out datareader);

        //cal_inicio.Value = 0;
        //cal_Termino.Value = 0;

        DataTable dt = new DataTable();
        dt.Columns.Add("codinstitucion");	        //0
        dt.Columns.Add("nombinst");			        //1
        dt.Columns.Add("codproyecto");		        //2
        dt.Columns.Add("nombproy", typeof(String));    //3
        dt.Columns.Add("CodRegion");	    //4
        dt.Columns.Add("comuna");	        //5
        dt.Columns.Add("codnino");	        //6
        dt.Columns.Add("apellido_paterno");	//7
        dt.Columns.Add("apellido_materno");	//8
        dt.Columns.Add("nombres");	        //9
        dt.Columns.Add("fechanacimiento", typeof(DateTime));	//10
        dt.Columns.Add("rut");	                                //11
        dt.Columns.Add("fechaRegistro", typeof(DateTime));		//12
        dt.Columns.Add("Madre");
        dt.Columns.Add("Padre");
        dt.Columns.Add("Otro_Femenino");
        dt.Columns.Add("Otro_Masculino");
        dt.Columns.Add("desde", typeof(DateTime));
        dt.Columns.Add("hasta", typeof(DateTime));
        dt.Columns.Add("reporte");

        DataRow dr;
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (System.Int32)datareader["codinstitucion"];
                dr[1] = (System.String)datareader["nombinst"];
                dr[2] = (System.Int32)datareader["codproyecto"];
                dr[3] = (System.String)datareader["nombproy"];
                dr[4] = (System.Int32)datareader["CodRegion"];
                dr[5] = (System.String)datareader["comuna"];
                dr[6] = (System.Int32)datareader["codnino"];
                dr[7] = (System.String)datareader["apellido_paterno"];
                dr[8] = (System.String)datareader["apellido_materno"];
                dr[9] = (System.String)datareader["nombres"];
                dr[10] = (System.DateTime)datareader["fechanacimiento"];
                dr[11] = (System.String)datareader["rut"];
                dr[12] = (System.DateTime)datareader["fechaRegistro"];
                dr[13] = (System.String)datareader["Madre"];
                dr[14] = (System.String)datareader["Padre"];
                dr[15] = (System.String)datareader["Otro_Femenino"];
                dr[16] = (System.String)datareader["Otro_Masculino"];
                dr[17] = (System.DateTime)datareader["desde"];
                dr[18] = (System.DateTime)datareader["hasta"];
                dr[19] = (System.String)datareader["reporte"];
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
            ImageButton12.Visible = true;
            lbl_error.Text = string.Empty;
            alerts.Visible = false;
            grd001.Visible = true;
        }
        else
        {
            ImageButton12.Visible = false;
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
        if (ddregion.SelectedValue == "-1" || ddregion.SelectedValue == "15")
        {
            getinstituciones();
            Session["Repninovisitado_ddregion"] = ddregion.SelectedValue;
        }
        else
        {
            getinstitucionesxRgn();
            Session["Repninovisitado_ddregion"] = ddregion.SelectedValue;
        }
    }




    protected void btn_limpiar_Click(object sender, EventArgs e)
    {
        alerts.Visible = false;
        grd001.Visible = false;
        ImageButton12.Visible = false;
        lbl_error.Visible = false;
        ddregion.SelectedIndex = -1;
        ddinstitucion.SelectedIndex = -1;
        ddproyecto.SelectedIndex = -1;
        cal_inicio.Text = string.Empty;
        cal_Termino.Text = string.Empty;


    }
    protected void btnBuscaInstitucion_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Plan de Intervencion";
        window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_reportes/Rep_ninosvisitados.aspx", "Buscador", false, true, 500, 650, false, false, true);
    }
    protected void btnBuscaProyecto_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Busca Proyectos";
        window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_reportes/Rep_ninosvisitados.aspx", "Buscador", false, true, 500, 650, false, false, true);
    }


    protected void ImageButton12_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Clear();
            Response.Buffer = true;

            // Set the content type to Excel
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=Reporte_NinosVisitados.xls");
            // Remove the charset from the Content-Type header.
            Response.Charset = "";
            // Turn off the view state.
            this.EnableViewState = false;

            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

            DataTable dt = new DataTable();
            dt.Columns.Add("codinstitucion");	//0
            dt.Columns.Add("nombinst");			//1
            dt.Columns.Add("codproyecto");		//2
            dt.Columns.Add("nomproy");		    //3
            dt.Columns.Add("CodRegion");	    //4
            dt.Columns.Add("comuna");	        //5
            dt.Columns.Add("codnino");	        //6
            dt.Columns.Add("apellido_paterno");	//7
            dt.Columns.Add("apellido_materno");	//8
            dt.Columns.Add("nombres");	        //9
            dt.Columns.Add("fechanacimiento");	//10
            dt.Columns.Add("rut");	            //11
            dt.Columns.Add("fechaRegistro");	//12
            dt.Columns.Add("Madre");	//13
            dt.Columns.Add("Padre");	            //14
            dt.Columns.Add("Otro_Femenino");	//13
            dt.Columns.Add("Otro_Masculino");	            //14
            dt.Columns.Add("desde");		    //15
            dt.Columns.Add("hasta");		    //16
            dt.Columns.Add("reporte");		    //17

            DataRow dr;

            // Get the HTML for the control.
            for (int i = 0; i < grd001.Rows.Count; i++)
            {
                dr = dt.NewRow();
                for (int j = 0; j < grd001.Columns.Count; j++)
                {
                    dr[j] = grd001.Rows[i].Cells[j].Text;
                }
                dt.Rows.Add(dr);
            }
            DataView dv = new DataView(dt);
            DataGrid d1 = new DataGrid();
            d1.DataSource = dv;
            d1.DataBind();
            d1.RenderControl(hw);
            //Write the HTML back to the browser.
            Response.Write(tw.ToString());
            // End the response.
            Response.End();
        }
        catch (Exception ex)
        { lbl_error.Text = ex.Message; }
    }


}
