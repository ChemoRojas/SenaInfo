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

public partial class Reportes_Rep_proyectos : System.Web.UI.Page
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
                // si los datos de session poseen datos, estos se asignan a los controles que correspondan

                getparregion();
                if (Session["CodRegion"] != null)
                   ddregion.SelectedValue = Session["CodRegion"].ToString();

                getinstitucionesxRgn();
                if (Session["CodInstitucion"] != null)
                    ddinstitucion.SelectedValue = Session["CodInstitucion"].ToString();
                
                getproyectoxinst();
                if (Session["CodProyecto"] != null)
                    ddproyecto.SelectedValue = Session["CodProyecto"].ToString();
                
                btn_excel.Visible = false;


                if (Request.QueryString["sw"] == "3") //lupa institucion
                {
                    //Se limpia la Session para que no modifique los valores que vengan desde querystring
                    limpiarDatosSession();
                    ddinstitucion.SelectedValue = Request.QueryString["codinst"];
                    ddlproyecto_SelectIndex_changed(sender, e);
                    ddregion.SelectedValue = Session["vs_region"].ToString();
                    
                }


                if (Request.QueryString["sw"] == "4") //lupa proyecto
                {
                    //Se limpia la Session para que no modifique los valores que vengan desde querystring
                    limpiarDatosSession();
                    buscador_institucion bsc = new buscador_institucion();
                    int codinst = bsc.GetCodInstxCodProy(Convert.ToInt32(Request.QueryString["codinst"]));
                    ddinstitucion.SelectedValue = Convert.ToString(codinst);
                    getproyectoxinst();
                    ddproyecto.SelectedValue = Request.QueryString["codinst"];
                    ddlproyecto_SelectIndex_changed(sender, e);

                }
            }
        }

        //Se cargan en Session los datos utilizados
        Session["vs_region"] = ddregion.SelectedValue;
        Session["CodRegion"] = ddregion.SelectedValue;
        Session["CodInstitucion"] = ddinstitucion.SelectedValue;
        Session["CodProyecto"] = ddproyecto.SelectedValue;
    }
    protected void rv_fecha_Init(object sender, EventArgs e)
    {
        ((RangeValidator)sender).MaximumValue = DateTime.Today.ToString("dd-MM-yyyy");
        ((RangeValidator)sender).MinimumValue = "01-01-1900";

    }

    private void limpiarDatosSession()
    {
        Session["CodRegion"] = null;
        Session["CodInstitucion"] = null;
        Session["CodProyecto"] = null;
    }
    private void getparregion()
    {
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
        DataView dv2 = new DataView(inst.GetData(Convert.ToInt32(Session["IdUsuario"])));
        ddinstitucion.DataSource = dv2;
        ddinstitucion.DataTextField = "Nombre";
        ddinstitucion.DataValueField = "CodInstitucion";
        dv2.Sort = "Nombre";
        ddinstitucion.DataBind();

        if (dv2.Count == 2)
            ddinstitucion.SelectedIndex = 1;
        //else
        //    if (Session["CodProyecto"] != null)
        //        ddinstitucion.SelectedValue = Session["CodInstitucion"].ToString();

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
        //proyectocoll proy = new proyectocoll();
        //DataView dv3 = new DataView(proy.GetData(Convert.ToInt32(Session["IdUsuario"]), "V", Convert.ToInt32(ddinstitucion.SelectedValue)));
        //ddproyecto.DataSource = dv3;
        //ddproyecto.DataTextField = "Nombre";
        //ddproyecto.DataValueField = "CodProyecto";
        //dv3.Sort = "CodProyecto";
        //ddproyecto.DataBind();

        //if (dv3.Count == 2)
        //    ddproyecto.SelectedIndex = 1;
        //else
        //    if (Session["CodProyecto"] != null)
        //        ddproyecto.SelectedValue = Session["CodProyecto"].ToString();

        proyectocoll proy = new proyectocoll();
        //DataView dv3 = new DataView(proy.GetProyectos_Region_Institucion(Convert.ToInt32(ddregion.SelectedValue), Convert.ToInt32(Session["IdUsuario"]), "V", Convert.ToInt32(ddinstitucion.SelectedValue)));
        DataView dv1 = new DataView(proy.GetProyectos_Region_Institucion(Convert.ToInt32(ddregion.SelectedValue), Convert.ToInt32(Session["IdUsuario"]), "V", Convert.ToInt32(ddinstitucion.SelectedValue)));
        // DataView dv3 = new DataView(proy.GetProyectoxInst(Convert.ToInt32(ddinstitucion.SelectedValue)));
        ddproyecto.DataSource = dv1;
        dv1.RowFilter = "Codregion = " + ddregion.SelectedValue;
        ddproyecto.DataTextField = "Nombre";
        ddproyecto.DataValueField = "CodProyecto";
        dv1.Sort = "CodProyecto";
        ddproyecto.DataBind();
        

        if (dv1.Count == 2 && Session["CodProyecto"] == null)
            ddproyecto.SelectedIndex = 1;

        if (dv1.Count == 0)
            ddproyecto.Items.Add(new ListItem("Seleccionar", "0"));
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
    protected void btn_volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("../mod_reportes/index_reportes.aspx");
    }
    protected void btn_buscar_Click(object sender, EventArgs e)
    {
       
        int reporte = 1;
        if (Convert.ToBoolean(rdb001.Checked) == true)
        {
            reporte = 1;
        }
        if (Convert.ToBoolean(rdb002.Checked) == true)
        {
            reporte = 2;
        }
  
        int val = validatesecurity();
        int mes = 0;
        if (cal_inicio.Text != "" && cal_termino.Text != "") //Seleccione Fecha
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
             if (cal_inicio.Text == "")
             {
                 lbl_error.Visible = true;
                 lbl_error.Text = "Debe Ingresar la fecha de Inicio Periodo";
                 cal_inicio.Focus();
                 return;
             }
             else if (cal_termino.Text == "")
             {
                 lbl_error.Visible = true;
                 lbl_error.Text = "Debe Ingresar la fecha de Fin Periodo";
                 cal_termino.Focus();
                 return;
             }
             else if (Convert.ToDateTime(cal_inicio.Text) > Convert.ToDateTime(cal_termino.Text))
             {
                 lbl_error.Visible = true;
                 lbl_error.Text = "Debe Ingresar fecha de Inicio Mayor o Igual a Fin Periodo";
                 cal_inicio.Focus();
                 return;
             }
          
             else
             {
                 cargaDTG(Convert.ToInt32(ddregion.SelectedValue), Convert.ToInt32(ddinstitucion.SelectedValue), Convert.ToInt32(ddproyecto.SelectedValue), Convert.ToDateTime(cal_inicio.Text), Convert.ToDateTime(cal_termino.Text), reporte, Convert.ToInt32(ddtipoProyecto.SelectedValue));
             }
         }
    }
    private void cargaDTG(int region,int codinstitucion,int codproyecto, DateTime fechainicio, DateTime fechatermino,int reporte,int tipo)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        DbParameter[] parametros = {con.parametros("@region",SqlDbType.Int,4,region),
                                 con.parametros("@codinstitucion",SqlDbType.Int,4, codinstitucion),
                                 con.parametros("@codproyecto",SqlDbType.Int ,4, codproyecto),
                                 con.parametros("@fechainicio",SqlDbType.DateTime,16, fechainicio),
                                 con.parametros("@fechatermino",SqlDbType.DateTime,16, fechatermino),
                                 con.parametros("@reporte",SqlDbType.Int,4,reporte),
                                 con.parametros("@tipo",SqlDbType.Int,4,tipo)
										};
        con.ejecutarProcedimiento("reporte_proyectos", parametros, out datareader);

        DataTable dt = new DataTable();
        dt.Columns.Add("CodInstitucion");	
        dt.Columns.Add("NombreInstitucion");		
        dt.Columns.Add("CodRegion");
        dt.Columns.Add("CodProyecto");
        dt.Columns.Add("Nombre", typeof(String));
        dt.Columns.Add("NombreSistemaAsistencial");
        dt.Columns.Add("Tematica");
        dt.Columns.Add("nModelo");
        dt.Columns.Add("nTipoProyecto");
        dt.Columns.Add("NumeroPlazas");
        dt.Columns.Add("NombreDepartamentosSename");
        dt.Columns.Add("EdadMinima");
        dt.Columns.Add("EdadMaxima");
        dt.Columns.Add("nsexo");
        dt.Columns.Add("Direccion");
        dt.Columns.Add("Comuna");
        dt.Columns.Add("Telefono");
        dt.Columns.Add("Mail");
        dt.Columns.Add("Director");
        dt.Columns.Add("FechaInicio");
        dt.Columns.Add("FechaTermino");
        dt.Columns.Add("IndVigencia");
        dt.Columns.Add("nino_i");
        dt.Columns.Add("nino_e");
        dt.Columns.Add("nino_v");
        dt.Columns.Add("nino_a");
        dt.Columns.Add("desde", typeof(DateTime));
        dt.Columns.Add("hasta", typeof(DateTime));
        dt.Columns.Add("reporte");
        
        DataRow dr;
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0]  = (System.Int32)datareader["CodInstitucion"];
                dr[1]  = (System.String)datareader["NombreInstitucion"];
                dr[2]  = (System.Int32)datareader["CodRegion"];
                dr[3]  = (System.Int32)datareader["CodProyecto"];
                dr[4]  = (System.String)datareader["Nombre"];
                dr[5]  = (System.String)datareader["NombreSistemaAsistencial"];
                dr[6]  = (System.String)datareader["Tematica"];
                dr[7]  = (System.String)datareader["nModelo"];
                dr[8]  = (System.String)datareader["nTipoProyecto"];
                dr[9]  = (System.Int32)datareader["NumeroPlazas"];
                dr[10] = (System.String)datareader["NombreDepartamentosSename"];
                dr[11] = (System.Int32)datareader["EdadMinima"];
                dr[12] = (System.Int32)datareader["EdadMaxima"];
                dr[13] = (System.String)datareader["nsexo"];
                dr[14] = (System.String)datareader["Direccion"];
                dr[15] = (System.String)datareader["Comuna"];
                dr[16] = (System.String)datareader["Telefono"];
                dr[17] = (System.String)datareader["Mail"];
                dr[18] = (System.String)datareader["Director"];
                dr[19] = (System.String)datareader["FechaInicio"];
                dr[20] = (System.String)datareader["FechaTermino"];
                dr[21] = (System.String)datareader["IndVigencia"];
                dr[22] = (System.Int32)datareader["nino_i"];
                dr[23] = (System.Int32)datareader["nino_e"];
                dr[24] = (System.Int32)datareader["nino_v"];
                dr[25] = (System.Int32)datareader["nino_a"];
                dr[26] = (System.DateTime)datareader["desde"];
                dr[27] = (System.DateTime)datareader["hasta"];
                dr[28] = (System.String)datareader["reporte"];
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
            btn_excel.Visible= false;
            lbl_error.Text = "No se han encontrado registros coincidentes.";
            lbl_error.Visible= true;
            alerts.Visible = true;
            grd001.Visible = false;
        }
    }

    protected void ddinstitucion_SelectIndexChanged(object sender, EventArgs e)
    {
        if (ddregion.SelectedValue == "-1" ||ddregion.SelectedValue == "15")
        {
            getinstituciones();
        }
        else
        {
            getinstitucionesxRgn();
        }
    }
    protected void ddlproyecto_SelectIndex_changed(object sender, EventArgs e)
    {
        getproyectoxinst();

    }
    protected void btn_limpiar_Click(object sender, EventArgs e)
    {
        grd001.Visible = false;
        lbl_error.Visible = false;
        ddregion.SelectedIndex = -1;
        ddinstitucion.SelectedIndex = -1;
        ddproyecto.SelectedIndex = -1;
        cal_inicio.Text = string.Empty;
        cal_termino.Text = string.Empty;
        alerts.Visible = false;
    }

    //protected void btnBuscaInstitucion_Click(object sender, ImageClickEventArgs e)
    //{
    //    string etiqueta = "Plan de Intervencion";
    //    window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_reportes/Rep_proyectos.aspx", "Buscador", false, true, 500, 650, false, false, true);
    //}
    protected void btn_excel_Click1(object sender, EventArgs e)
    {
        try
        {
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment;filename=Reporte_Proyectos.xls");
            Response.ContentType = "application/vnd.xls";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

            DataTable dt = new DataTable();
            dt.Columns.Add("CodInstitucion");
            dt.Columns.Add("NombreInstitucion");
            dt.Columns.Add("CodRegion");
            dt.Columns.Add("CodProyecto");
            dt.Columns.Add("Nombre", typeof(String));
            dt.Columns.Add("NombreSistemaAsistencial");
            dt.Columns.Add("Tematica");
            dt.Columns.Add("nModelo");
            dt.Columns.Add("nTipoProyecto");
            dt.Columns.Add("NumeroPlazas");
            dt.Columns.Add("NombreDepartamentosSename");
            dt.Columns.Add("EdadMinima");
            dt.Columns.Add("EdadMaxima");
            dt.Columns.Add("nsexo");
            dt.Columns.Add("Direccion");
            dt.Columns.Add("Comuna");
            dt.Columns.Add("Telefono");
            dt.Columns.Add("Mail");
            dt.Columns.Add("Director");
            dt.Columns.Add("FechaInicio");
            dt.Columns.Add("FechaTermino");
            dt.Columns.Add("IndVigencia");
            dt.Columns.Add("nino_i");
            dt.Columns.Add("nino_e");
            dt.Columns.Add("nino_v");
            dt.Columns.Add("nino_a");
            dt.Columns.Add("desde", typeof(DateTime));
            dt.Columns.Add("hasta", typeof(DateTime));
            dt.Columns.Add("reporte");
            DataRow dr;

            for (int i = 0; i < grd001.Rows.Count; i++)
            {
                dr = dt.NewRow();
                dr[0] = grd001.Rows[i].Cells[0].Text;
                dr[1] = grd001.Rows[i].Cells[1].Text;
                dr[2] = grd001.Rows[i].Cells[2].Text;
                dr[3] = grd001.Rows[i].Cells[3].Text;
                dr[4] = grd001.Rows[i].Cells[4].Text;
                dr[5] = grd001.Rows[i].Cells[5].Text;
                dr[6] = grd001.Rows[i].Cells[6].Text;
                dr[7] = grd001.Rows[i].Cells[7].Text;
                dr[8] = grd001.Rows[i].Cells[8].Text;
                dr[9] = grd001.Rows[i].Cells[9].Text;
                dr[10] = grd001.Rows[i].Cells[10].Text;
                dr[11] = grd001.Rows[i].Cells[11].Text;
                dr[12] = grd001.Rows[i].Cells[12].Text;
                dr[13] = grd001.Rows[i].Cells[13].Text;
                dr[14] = grd001.Rows[i].Cells[14].Text;
                dr[15] = grd001.Rows[i].Cells[15].Text;
                dr[16] = grd001.Rows[i].Cells[16].Text;
                dr[17] = grd001.Rows[i].Cells[17].Text;
                dr[18] = grd001.Rows[i].Cells[18].Text;
                dr[19] = grd001.Rows[i].Cells[19].Text;
                dr[20] = grd001.Rows[i].Cells[20].Text;
                dr[21] = grd001.Rows[i].Cells[21].Text;
                dr[22] = grd001.Rows[i].Cells[22].Text;
                dr[23] = grd001.Rows[i].Cells[23].Text;
                dr[24] = grd001.Rows[i].Cells[24].Text;
                dr[25] = grd001.Rows[i].Cells[25].Text;
                dr[26] = grd001.Rows[i].Cells[26].Text;
                dr[27] = grd001.Rows[i].Cells[27].Text;
                dr[28] = grd001.Rows[i].Cells[28].Text;
                dt.Rows.Add(dr);
            }
            DataView dv = new DataView(dt);
            DataGrid d1 = new DataGrid();

            d1.DataSource = dv;
            d1.DataBind();



            d1.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            //Response.Close();
            Response.End();

         
        }
        catch (Exception ex)
        { lbl_error.Visible = true; lbl_error.Text = ex.Message + " " + ex.InnerException; }
    }
}
