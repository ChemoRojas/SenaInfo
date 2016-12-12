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

public partial class mod_reportes_Rep_NinosDeteccionPrecoz : System.Web.UI.Page
{

      private DataTable dtRol
    {
        get { return (DataTable)Session["dtRol"]; }
        set { Session["dtRol"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        RequiredFieldValidator1.Validate();
        if (!IsPostBack)
        {
            if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
            {
                Response.Redirect("~/autenticacion.aspx");
            }

            else
            {
                getparregion();
                if (Session["CodRegion"] != null)
                    ddregion.SelectedValue = Session["CodRegion"].ToString();

                getinstitucionesxRgn();
                if (Session["CodInstitucion"] != null)
                    ddinstitucion.SelectedValue = Session["CodInstitucion"].ToString();

                getproyectoxinst();
                if (Session["CodProyecto"] != null)
                    ddproyecto.SelectedValue = Session["CodProyecto"].ToString();

                //cargaProyectos();

                if (Request.QueryString["sw"] == "4")
                {
                    buscador_institucion bsc = new buscador_institucion();
                    string codregion = region_bycodproyecto(Convert.ToInt32(Request.QueryString["codinst"]));
                    ddregion.SelectedValue = codregion;
                    chk001.Checked = false;
//                    cargaProyectos2();
                    getproyectoxinst();
                    ddproyecto.SelectedValue = Request.QueryString["codinst"];
                    ddinstitucion.SelectedValue = Request.QueryString["codproy"];
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
            ddinstitucion.SelectedIndex = 1;

    }

    private void getproyectoxinst()
    {
        proyectocoll proy = new proyectocoll();
        //DataView dv3 = new DataView(proy.GetProyectos_Region_Institucion(Convert.ToInt32(ddregion.SelectedValue), Convert.ToInt32(Session["IdUsuario"]), "V", Convert.ToInt32(ddinstitucion.SelectedValue)));
        DataView dv3 = new DataView(proy.GetProyectos_Region_Institucion(Convert.ToInt32(ddregion.SelectedValue), Convert.ToInt32(Session["IdUsuario"]), "V", Convert.ToInt32(ddinstitucion.SelectedValue)));
        // DataView dv3 = new DataView(proy.GetProyectoxInst(Convert.ToInt32(ddinstitucion.SelectedValue)));
        ddproyecto.DataSource = dv3;
        dv3.RowFilter = "Codregion = " + ddregion.SelectedValue;
        ddproyecto.DataTextField = "Nombre";
        ddproyecto.DataValueField = "CodProyecto";
        dv3.Sort = "CodProyecto";
        ddproyecto.DataBind();

        if (dv3.Count == 2)
            ddproyecto.SelectedIndex = 1;

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
    private void getinstituciones()
    {
        institucioncoll ncoll = new institucioncoll();
        DataView dv1 = new DataView(ncoll.GetData(Convert.ToInt32(Session["IdUsuario"])));
        ddinstitucion.DataSource = dv1;
        ddinstitucion.DataTextField = "Nombre";
        ddinstitucion.DataValueField = "CodInstitucion";
        dv1.Sort = "Nombre";
        ddinstitucion.DataBind();

        if (dv1.Count == 2)
            ddinstitucion.SelectedIndex = 1;

    }
    protected void btnBuscaProyecto_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Busca Proyectos";
        window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_reportes/Rep_NinosDeteccionPrecoz.aspx", "Buscador", false, true, 500, 650, false, false, true);
    }
    protected void btn_buscar_Click(object sender, EventArgs e)
    {
        try
        {
            trabajadorescoll tracoll = new trabajadorescoll();
            string rol = tracoll.get_rol(Convert.ToInt32(Session["IdUsuario"]));

            System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

            if (ddregion.SelectedValue == "-2" || cal_inicio.Text == "" ||
                cal_Termino.Text == "" || (ddproyecto.SelectedValue == "" && (Convert.ToInt32(rol) == 267 || Convert.ToInt32(rol) == 265)))
            {


                if (ddregion.SelectedValue == "-2")
                { ddregion.BackColor = colorCampoObligatorio; }
                else { ddregion.BackColor = System.Drawing.Color.White; }

                if (cal_inicio.Text == "")
                { cal_inicio.BackColor = colorCampoObligatorio; }
                else { cal_inicio.BackColor = System.Drawing.Color.White; }

                if (cal_Termino.Text == "")
                { cal_Termino.BackColor = colorCampoObligatorio; }
                else { cal_Termino.BackColor = System.Drawing.Color.White; }



            }
            else
            {
                string codProy = "0";
                if (ddproyecto.SelectedValue == "")
                {
                    codProy = "0";
                }
                else
                {
                    codProy = ddproyecto.SelectedValue;
                }
                ddregion.BackColor = System.Drawing.Color.White;
                ddproyecto.BackColor = System.Drawing.Color.White;
                cal_inicio.BackColor = System.Drawing.Color.White;
                cal_Termino.BackColor = System.Drawing.Color.White;

                bool chk = true;
                TimeSpan mes = Convert.ToDateTime(cal_Termino.Text) - Convert.ToDateTime(cal_inicio.Text);
                int meses = mes.Days / 30;

                if (meses > 12)
                {
                    chk = false;
                    alerts.Visible = true;
                    lbl_error.Visible = true;
                    lbl_error.Text = "El periodo debe ser máximo 12 meses";
                }
                if (Convert.ToDateTime(cal_inicio.Text) > Convert.ToDateTime(cal_Termino.Text))
                {
                    chk = false;
                    alerts.Visible = true;
                    lbl_error.Visible = true;
                    lbl_error.Text = "Debe Ingresar fecha de Inicio Mayor o Igual a Fin Periodo";
                }

                if (chk)
                {
                    alerts.Visible = false;
                    lbl_error.Visible = false;
                    ReporteNinoColl rep = new ReporteNinoColl();
                    DataTable dt = rep.callto_reporte_deteccionprecoz(Convert.ToInt32(ddregion.SelectedValue), Convert.ToInt32(codProy),
                        Convert.ToDateTime(cal_inicio.Text), Convert.ToDateTime(cal_Termino.Text));

                    if (dt.Rows.Count > 0)
                    {
                        Response.Clear();
                        Response.Buffer = true;
                        Response.ContentType = "application/vnd.ms-excel";
                        Response.AddHeader("Content-Disposition", "attachment;filename=Reporte_Deteccion_Precoz.xls");
                        Response.Charset = "";
                        this.EnableViewState = false;

                        System.IO.StringWriter tw = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

                        DataView dv = new DataView(dt);

                        GridView grd002 = new GridView();
                        grd002.DataSource = dv;
                        grd002.DataBind();
                        grd002.RenderControl(hw);
                        Response.ContentEncoding = System.Text.Encoding.Default;
                        Response.Write(tw.ToString());
                        Response.End();
                        lbl_error.Visible = false;
                        alerts.Visible = false;
                    }
                    else
                    {
                        alerts.Visible = true;
                        lbl_error.Text = "No se han encontrado registros coincidentes";
                        lbl_error.Visible = true;

                    }
                }


            }
        }
        catch (Exception ex)
        {
            alerts.Visible = true;
            lbl_error.Visible = true;
            lbl_error.Text = "Falta seleccionar campos...";
        }

    }
    protected void btn_limpiar_Click(object sender, EventArgs e)
    {
        chk001.Checked = false;
        ddregion.SelectedIndex = -1;
        ddinstitucion.SelectedValue = "0";
        ddproyecto.Items.Clear();
        cargaProyectos();
        cal_inicio.Text = string.Empty;
        cal_Termino.Text = string.Empty;
        lbl_error.Visible = false;
        alerts.Visible = false;
    }
    protected void btn_volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("../mod_reportes/index_reportes.aspx");
    }
    
    protected void ddown001_SelectedIndexChanged(object sender, EventArgs e)
    {
        //cargaProyectos();
        ddproyecto.SelectedValue = "0";

    }
    private string region_bycodproyecto(int codproyecto)
    {
        ReporteNinoColl rep = new ReporteNinoColl();
        string sql = "Select  codregion from proyectos where codproyecto = "+codproyecto;
        DataTable dt = rep.ejecuta_SQL(sql);
        return dt.Rows[0][0].ToString();
    }
      
    private DataTable proyectos_byregion_and_UserID(int codregion, int UserID)
    {

        coordinador cr = new coordinador();
       // dtRol = cr.consulta_rol(Convert.ToInt32(Session["IdUsuario"]));


        //string vigencia = "V";
        //if (chk001.Checked)
        //    vigencia = "C";
        //ReporteNinoColl rep = new ReporteNinoColl();
        //string sql = "select t1.codproyecto,('('+cast(t1.codproyecto as varchar)+')'+' '+t1.nombre) as nombre from proyectos t1 INNER JOIN TrabajadorProyecto t2 ON t1.codproyecto = t2.CodProyecto where (t1.codModeloIntervencion in (54,55,56,10, 58,59,63,64,65,66,57,60,61,62,67,68,69,70,71,72,73) OR t1.codsistemaasistencial in (2,12))" +
        //" and t1.codregion = " + codregion + " and t1.indvigencia ='" + vigencia + "' and t2.IcodTrabajador = " + Convert.ToInt32(dtRol.Rows[0][3]) + " order by nombre";
       
        //DataTable dt = rep.ejecuta_SQL(sql);

        proyectocoll proy = new proyectocoll();
        DataTable dt = proy.GetData(Convert.ToInt32(Session["IdUsuario"]),"V", Convert.ToInt32(ddinstitucion.SelectedValue));
        //DataRow dr = dt.NewRow();
        //dr[0] = "0";
        //dr[15] = " Seleccionar";
        //dt.Rows.Add(dr);
        return dt;
    }  
    private DataTable proyectos_byregion(int codregion)
    {
        string vigencia = "V";
        if (chk001.Checked)
            vigencia = "C";
        ReporteNinoColl rep = new ReporteNinoColl();
        string sql = "select codproyecto,('('+cast(codproyecto as varchar)+')'+' '+nombre) as nombre from proyectos where (codModeloIntervencion in (54,55,56,10, 58,59,63,64,65,66,57,60,61,62,67,68,69,70,71,72,73) OR codsistemaasistencial in (2,12))" +
        " and codregion = " + codregion + " and indvigencia ='"+vigencia+"' order by nombre";
        DataTable dt = rep.ejecuta_SQL(sql);
        DataRow dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = " Seleccionar";
        dt.Rows.Add(dr);
        return dt;
    }
    private DataTable proyectos_byregion2(int codregion)
    {
        string vigencia = "V";
        if (chk001.Checked)
            vigencia = "C";
        ReporteNinoColl rep = new ReporteNinoColl();
        string sql = "select codproyecto,('('+cast(codproyecto as varchar)+')'+' '+nombre) as nombre from proyectos where codregion = " + codregion + " and indvigencia ='" + vigencia + "' order by nombre";
        DataTable dt = rep.ejecuta_SQL(sql);
        DataRow dr = dt.NewRow();
        dr[0] = "0";
        dr[1] = " Seleccionar";
        dt.Rows.Add(dr);
        return dt;
    }

    private void cargaProyectos()
    {

        DataTable dt = proyectos_byregion_and_UserID(Convert.ToInt32(ddregion.SelectedValue), Convert.ToInt32(Session["IdUsuario"]));
        //DataTable dt = proyectos_byregion(Convert.ToInt32(ddregion.SelectedValue));
        ddproyecto.DataSource = dt;
        ddproyecto.DataTextField = "nombre";
        ddproyecto.DataValueField = "codproyecto";
        ddproyecto.DataBind();

        if (dt.Rows.Count == 2)
            ddproyecto.SelectedIndex = 0;
    
    }
    private void cargaProyectos2()
    {
        DataTable dt = proyectos_byregion2(Convert.ToInt32(ddregion.SelectedValue));
        ddproyecto.DataSource = dt;
        ddproyecto.DataTextField = "nombre";
        ddproyecto.DataValueField = "codproyecto";
        ddproyecto.DataBind();


    }

    protected void ddinstitucion_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargaProyectos();
    }
}
