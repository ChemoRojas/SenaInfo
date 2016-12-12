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

public partial class mod_reportes_Rep_ListadeEspera : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RequiredFieldValidator1.Validate();
        if (!IsPostBack)
        {
            if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
            {
                Response.Redirect("~/logout.aspx");
            }

            else
            {
                if (!window.existetoken("6A28C220-4907-4695-A95D-9797F17430F7"))
                {

                    Response.Redirect("~/e403.aspx");

                }

                getparregion();
                if (Session["CodRegion"] != null)
                    ddregion.SelectedValue = Session["CodRegion"].ToString();

                getinstituciones();
                if (Session["CodInstitucion"] != null)
                    ddinstitucion.SelectedValue = Session["CodInstitucion"].ToString();

                getproyectoxinst();
                if (Session["CodProyecto"] != null)
                    ddproyecto.SelectedValue = Session["CodProyecto"].ToString();


                btn_excel.Visible = false;

                if (Request.QueryString["sw"] == "3")
                {
                    limpiaSession();
                    ddinstitucion.SelectedValue = Request.QueryString["codinst"];
                    ddown002_SelectedIndexChanged(sender, e);
                }
                if (Request.QueryString["sw"] == "4")
                {
                    limpiaSession();
                    buscador_institucion bsc = new buscador_institucion();
                    int codinst = bsc.GetCodInstxCodProy(Convert.ToInt32(Request.QueryString["codinst"]));
                    ddinstitucion.SelectedValue = Convert.ToString(codinst);
                    //ddregion.SelectedValue = "-1";
                    getproyectoxinst();
                    int codreg = bsc.GetCodRegionxCodProy(Convert.ToInt32(Request.QueryString["codinst"]));
                    ddregion.SelectedValue = Convert.ToString(codreg);
                    ddproyecto.SelectedValue = Request.QueryString["codinst"];
                }
            }

        }
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
        // grd001.Visible = false;
        alerts.Visible = false;
        btn_excel.Visible = false;
        lbl_error.Visible = false;
        ddinstitucion.SelectedValue = "0";

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
        ddproyecto.DataTextField = "Nombre";
        ddproyecto.DataValueField = "CodProyecto";
        dv3.Sort = "CodProyecto";
        ddproyecto.DataBind();

        if (dv3.Count == 2)
            ddproyecto.SelectedIndex = 1;
    }

    protected void btn_volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("../mod_reportes/index_reportes.aspx");
    }
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

    
        DataTable dt = consulta_rol();
        if (Convert.ToString(dt.Rows[0][1]) == "252" || Convert.ToString(dt.Rows[0][1]) == "249" || Convert.ToString(dt.Rows[0][1]) == "263")
        { }
        else
        {

            if (ddinstitucion.SelectedValue == "0")
            {
                alerts.Visible = true;
                lbl_error.Visible = true;
                lbl_error.Text += "- Debe seleccionar la Institutción <br>";
                ddinstitucion.Focus();
                val = 1;
            }
            if (ddproyecto.SelectedValue == "0")
            {
                alerts.Visible = true;
                lbl_error.Visible = true;
                lbl_error.Text += "- Debe seleccionar el proyecto <br>";
                ddproyecto.Focus();
                val = 1;
            }
        }

        if (val == 0)
        {
            if (cal_inicio.Text == "")
            {
                alerts.Visible = true;
                lbl_error.Visible = true;
                lbl_error.Text = "Debe Ingresar la fecha de Inicio Periodo";
                //cal_inicio.Focus();
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
                alerts.Visible = true;
                lbl_error.Visible = true;
                lbl_error.Text = "Debe Ingresar fecha de Inicio Mayor o Igual a Fin Periodo";
                //cal_inicio.Focus();
                return;
            }
            else if (ddproyecto.SelectedValue == "0" && mes > 1)
            {
                alerts.Visible = true;
                lbl_error.Visible = true;
                lbl_error.Text = "El Período no puede ser mayor a Un Mes";
                //cal_inicio.Focus();
                return;
            }
            else
            {
                TimeSpan var;
                var = Convert.ToDateTime(cal_Termino.Text).Subtract(Convert.ToDateTime(cal_inicio.Text));
                if (var.Days >= 31)
                {
                    alerts.Visible = true;
                    lbl_error.Visible = true;
                    lbl_error.Text = "La cantidad de días entre la fecha de inicio y término no debe exceder de 31 días";
                    //cal_inicio.Focus();
                }
                else
                {
                    btn_excel.Visible = true;
                    alerts.Visible = true;
                    lbl_error.Text = "El archivo esta listo para ser descargado, por favor seleccione Exportar...";

                }
            }
        }
    }
    protected void btn_limpiar_Click(object sender, EventArgs e)
    {
        //grd001.Visible = false;
        btn_excel.Visible = false;
        lbl_error.Visible = false;
        ddregion.SelectedIndex = -1;
        ddinstitucion.SelectedIndex = -1;
        ddproyecto.SelectedIndex = -1;
        cal_inicio.Text = null;
        cal_Termino.Text = null;
        alerts.Visible = false;


    }
    protected void btnBuscaInstitucion_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Plan de Intervencion";
        window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_reportes/Rep_ListadeEspera.aspx", "Buscador", false, true, 500, 650, false, false, true);
    }
    protected void btnBuscaProyecto_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Busca Proyectos";
        window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_reportes/Rep_ListadeEspera.aspx", "Buscador", false, true, 500, 650, false, false, true);
    }
    protected void ddown002_SelectedIndexChanged(object sender, EventArgs e)
    {
        getproyectoxinst();
    }
    protected void ddown001_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddregion.SelectedValue == "-1")
        {
            getinstituciones();
        }
        else
        {
            getinstitucionesxRgn();
        }
    }
 
    protected void btn_excel_Click1(object sender, EventArgs e)
    {
        //excelGenerate();
        {
            if (ddregion.SelectedValue == "-1" || cal_inicio.Text == "" || cal_Termino.Text == "")
            {
                if (ddregion.SelectedValue == "-1")
                { ddregion.BackColor = System.Drawing.Color.Pink; }
                else { ddregion.BackColor = System.Drawing.Color.White; }

                if (cal_inicio.Text == "")
                { cal_inicio.BackColor = System.Drawing.Color.Pink; }
                else { cal_inicio.BackColor = System.Drawing.Color.White; }

                if (cal_Termino.Text == "")
                { cal_Termino.BackColor = System.Drawing.Color.Pink; }
                else { cal_Termino.BackColor = System.Drawing.Color.White; }
            }
            else
            {
                ddregion.BackColor = System.Drawing.Color.White;
                cal_inicio.BackColor = System.Drawing.Color.White;
                cal_Termino.BackColor = System.Drawing.Color.White;

                ReporteNinoColl rp = new ReporteNinoColl();

                DataTable dt = rp.callto_reporte_Lista_Espera(Convert.ToInt32(ddtipo.SelectedValue), Convert.ToInt32(ddproyecto.SelectedValue),
                                            Convert.ToDateTime(cal_inicio.Text), Convert.ToDateTime(cal_Termino.Text),
                                            Convert.ToInt32(ddinstitucion.SelectedValue), Convert.ToInt32(ddregion.SelectedValue));


                if (dt.Rows.Count <= 0)
                {
                    btn_excel.Visible = false;
                    alerts.Visible = true;
                    lbl_error.Text = "No se han encontrado registros coincidentes";
                    lbl_error.Visible = true;
                    return;
                }


                Response.Clear();
                Response.Buffer = true;

                // Set the content type to Excel
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", "attachment;filename=Reporte_ListaEspera.xls");
                // Remove the charset from the Content-Type header.
                Response.Charset = "";
                // Turn off the view state.
                this.EnableViewState = false;

                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);


                dt.Columns[0].ColumnName = "CodProyecto";
                dt.Columns[1].ColumnName = "Nombre";
                dt.Columns[2].ColumnName = "CodRegion";
                dt.Columns[3].ColumnName = "Region";
                dt.Columns[4].ColumnName = "ICodIngresoLE";
                dt.Columns[5].ColumnName = "CodNino";
                dt.Columns[6].ColumnName = "Nombres";
                dt.Columns[7].ColumnName = "Apellido_Paterno";
                dt.Columns[8].ColumnName = "Apellido_Materno";
                dt.Columns[9].ColumnName = "Sexo";
                dt.Columns[10].ColumnName = "FechaNacimiento";
                dt.Columns[11].ColumnName = "Rut";
                dt.Columns[12].ColumnName = "ICodIE";
                dt.Columns[13].ColumnName = "FechaIngresoLE";
                dt.Columns[14].ColumnName = "FechaEgresoLE";
                dt.Columns[15].ColumnName = "CodTribunal";
                dt.Columns[16].ColumnName = "Tribunal";
                dt.Columns[17].ColumnName = "RUC";
                dt.Columns[18].ColumnName = "RIT";
                dt.Columns[19].ColumnName = "FechaOrden";
                dt.Columns[20].ColumnName = "CausalIngreso";
                dt.Columns[21].ColumnName = "Usuario";
                dt.Columns[22].ColumnName = "FechaActualizacion";
                dt.Columns[23].ColumnName = "Estado";
                dt.Columns[24].ColumnName = "CodRegionN";
                dt.Columns[25].ColumnName = "RegionNiño_a";
                dt.Columns[26].ColumnName = "ComunaNiño_a";
                dt.Columns[27].ColumnName = "TipoSolicitanteIngreso_Des";
                dt.Columns[28].ColumnName = "SolicitanteIngreso";
                DataView dv = new DataView(dt);
                DataGrid d1 = new DataGrid();
                d1.DataSource = dv;
                d1.DataBind();
                d1.RenderControl(hw);
                Response.ContentEncoding = System.Text.Encoding.Default;
                Response.Write(tw.ToString());
                Response.End();
            }
        }
    }
}
    
        
      
    
   

