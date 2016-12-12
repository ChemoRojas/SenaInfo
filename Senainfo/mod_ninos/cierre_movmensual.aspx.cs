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
using System.Data.SqlClient;

public partial class mod_institucion_reg_cierremovmensual : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //imb001.Visible = true;
        //Session["vsdir"] = null;
        //string currentform = Form.Name.ToString();
        Session["vsdir"] = "../mod_ninos/cierre_movmensual.aspx";
        mostrar_collapse(true);
        if (!IsPostBack)
        {
            
            //imb005.Attributes.Add("onclick", "javascript:var Buscando=document.getElementById('Buscando');if (Buscando.value=='0') {Buscando.value='1';document.getElementById('imb005').style.visibility='hidden';document.getElementById('lblBuscando').style.visibility='visible'; t=setInterval('tiempo()',1000);return true;} else return false;");
            getinstituciones();
            getproyectos();
            getanos();

            try
            {
                if (Request.QueryString["sw"] == "4")
                {
                    buscador_institucion bsc = new buscador_institucion();
                    int codinst = bsc.GetCodInstxCodProy(Convert.ToInt32(Request.QueryString["codinst"]));
                    ddown001.SelectedValue = Convert.ToString(codinst);
                    getproyectos();
                    ddown002.SelectedValue = Request.QueryString["codinst"];
                    ddown_AnoCierre.Items.FindByValue(Request.QueryString["A"]).Selected = true;
                    ddown_MesCierre.Items.FindByValue(Request.QueryString["M"]).Selected = true;
                    fn_buscar();
                }

                if (Session["NNA"] != null && Request.QueryString["sw"] == null)
                {
                    oNNA NNA = (oNNA)Session["NNA"];
                    ddown001.SelectedValue = NNA.NNACodInstitucion;
                    getproyectos();
                    ddown002.SelectedValue = NNA.NNACodProyecto;
                }
                

            }
            
                
            catch { }
        }
        validatescurity();
    }

    private void validatescurity()
    {
        //F1315126-A9BB-443D-8040-44F721B97EB2 2.8_Regenerar
        if (!window.existetoken("F1315126-A9BB-443D-8040-44F721B97EB2"))
        {
            imb005.Visible = false; //9
        }
    }



    //protected void Imb002_Click(object sender, EventArgs e)
    //{
    //    if (ddown_MesCierre.SelectedIndex > 0)
    //    {
    //        Response.Redirect("cierre_informeatencion.aspx?sw=4&codinst=" + ddown002.SelectedValue + "&M=" + ddown_MesCierre.SelectedValue + "&A=" + ddown_AnoCierre.SelectedValue);
    //    }

    //}
    //protected void Imb003_Click(object sender, EventArgs e)
    //{
    //if (ddown_MesCierre.SelectedIndex > 0)
    //{
    //    Response.Redirect("cierre_registroatencion.aspx?sw=4&codinst=" + ddown002.SelectedValue + "&M=" + ddown_MesCierre.SelectedValue + "&A=" + ddown_AnoCierre.SelectedValue);
    //}

    //}
    protected void WebImageButton1_Click(object sender, EventArgs e)
    {
        if (ddown_MesCierre.SelectedIndex > 0)
        {
            Response.Redirect("cierre_resumenatencion.aspx?sw=4&codinst=" + ddown002.SelectedValue + "&M=" + ddown_MesCierre.SelectedValue + "&A=" + ddown_AnoCierre.SelectedValue);
        }

    }
    private void fn_buscar()
    {

        if ((DateTime.Now.Month < ddown_MesCierre.SelectedIndex && DateTime.Now.Year == Convert.ToInt16(ddown_AnoCierre.SelectedItem.ToString())) || DateTime.Now.Year < Convert.ToInt16(ddown_AnoCierre.SelectedItem.ToString()))
        {
            alertfuturo.Visible = true;
            ddown_MesCierre.SelectedIndex = DateTime.Now.Month;

        }
        else { 
            alertfuturo.Visible = false; 
        }

        if (ddown002.SelectedIndex > 0 && ddown_MesCierre.SelectedIndex > 0)
        {
            //------------------------------------ << REGENERA ANTES DE CAMBIAR EL MES --- DPL 2012-07-04 >>-------------------------------------------------------------------------------------------------------------------------------
            //DataTable dt = callto_cierre_regenerar(Convert.ToInt32(ddown002.SelectedValue), Convert.ToInt32(ddown_AnoCierre.SelectedValue + ddown_MesCierre.SelectedValue), Convert.ToInt32(Session["IdUsuario"]), ASP.global_asax.globaconn);
            object sender = new object(); ImageClickEventArgs e = new ImageClickEventArgs(0, 0);

            ImageButton1_Click(sender, e);
            //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            DataTable dt0 = callto_cierre_cabeceraproyecto(Convert.ToInt32(ddown002.SelectedValue), Convert.ToInt32(ddown_AnoCierre.SelectedValue + ddown_MesCierre.SelectedValue));
            DataTable dt1 = callto_cierre_nomina(Convert.ToInt32(ddown002.SelectedValue), Convert.ToInt32(ddown_AnoCierre.SelectedValue + ddown_MesCierre.SelectedValue), "I");
            DataTable dt2 = callto_cierre_nomina(Convert.ToInt32(ddown002.SelectedValue), Convert.ToInt32(ddown_AnoCierre.SelectedValue + ddown_MesCierre.SelectedValue), "E");
            grd001.DataSource = dt1;
            grd002.DataSource = dt2;

            /*RUTINA RPA */
            cargoNominaIngreso(dt1);
            cargoNominaEgreso(dt2);
            /*FIN RUTINA RPA*/
            lbl002.Text = dt1.Rows.Count.ToString();
            lbl003.Text = dt2.Rows.Count.ToString();
            lbl003panel.Visible = true;//gfontbrevis
            lbl002panel.Visible = true;//gfontbrevis

            if (Convert.ToInt32(dt0.Rows[0][12]) == 1)
            {
                alert_lb_1y8.Visible = true;
                lbl001.Visible = true;
                alertfuturo.Visible = false;

            }
            else
            {
                alert_lb_1y8.Visible = false;
                lbl001.Visible = false;
            }

            //Gfontbrevis
            lbl_resumen_filtro.Text = "Resumen: ";
            //lbl_resumen_filtro.Text += "- Institución: " + ddown001.SelectedItem.Text.Trim() + "<br>";
            lbl_resumen_filtro.Text +=  ddown002.SelectedItem.Text.Trim()  + " / ";
            lbl_resumen_filtro.Text +=  ddown_MesCierre.SelectedItem.Text + " de " + ddown_AnoCierre.SelectedItem.Text + "";

            lbl_resumen_filtro.Visible = true;
            lbl_resumen_filtro.Style.Add("display", "none");

            grd001.DataBind();
            grd002.DataBind();
        }

    }
    public void cargoNominaIngreso(DataTable dtnomina)
    {
        try
        {
            if (dtnomina.Rows.Count > 0)
            {
                DataTable dtsearch = new DataTable();
                dtsearch.Columns.Add("apellido_paterno");
                dtsearch.Columns.Add("apellido_materno");
                dtsearch.Columns.Add("nombres");
                dtsearch.Columns.Add("rut");
                dtsearch.Columns.Add("ICodIE");
                dtsearch.Columns.Add("fecha");
                for (int i = 0; i < dtnomina.Rows.Count; i++)
                {
                    DataRow dr = dtsearch.NewRow();
                    dr["apellido_paterno"] = dtnomina.Rows[i]["apellido_paterno"];
                    dr["apellido_materno"] = dtnomina.Rows[i]["apellido_materno"];
                    dr["nombres"] = dtnomina.Rows[i]["nombres"];
                    dr["rut"] = dtnomina.Rows[i]["rut"];
                    dr["ICodIE"] = dtnomina.Rows[i]["ICodIE"];
                    dr["fecha"] = dtnomina.Rows[i]["fecha"];
                    dtsearch.Rows.Add(dr);


                }
                grd001.DataSource = dtnomina;
                grd001.DataBind();
            }
        }
        catch
        { }
    }
    public void cargoNominaEgreso(DataTable dtnomina)
    {
        try
        {
            if (dtnomina.Rows.Count > 0)
            {
                DataTable dtsearch2 = new DataTable();
                dtsearch2.Columns.Add("apellido_paterno");
                dtsearch2.Columns.Add("apellido_materno");
                dtsearch2.Columns.Add("nombres");
                dtsearch2.Columns.Add("rut");
                dtsearch2.Columns.Add("ICodIE");
                dtsearch2.Columns.Add("fecha");
                for (int i = 0; i < dtnomina.Rows.Count; i++)
                {
                    DataRow dr2 = dtsearch2.NewRow();
                    dr2["apellido_paterno"] = dtnomina.Rows[i]["apellido_paterno"];
                    dr2["apellido_materno"] = dtnomina.Rows[i]["apellido_materno"];
                    dr2["nombres"] = dtnomina.Rows[i]["nombres"];
                    dr2["rut"] = dtnomina.Rows[i]["rut"];
                    dr2["ICodIE"] = dtnomina.Rows[i]["ICodIE"];
                    dr2["fecha"] = dtnomina.Rows[i]["fecha"];
                    dtsearch2.Rows.Add(dr2);


                }
                grd002.DataSource = dtnomina;
                grd002.DataBind();
            }
        }
        catch
        { }
    }
  
    private DataTable callto_cierre_nomina(int codproyecto, int mesano, string indica)
    {
        Conexiones con = new Conexiones();
        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + con.Servidor + " ;Database= " + con.Base + " ; User ID= " + con.Usuario + " ;Password= " + con.Passw + " ;Trusted_Connection=False");
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "cierre_nomina";
        sqlc.Parameters.Add("@codproyecto", SqlDbType.Int, 4).Value = codproyecto;
        sqlc.Parameters.Add("@mesano", SqlDbType.Int, 4).Value = mesano;
        sqlc.Parameters.Add("@indica", SqlDbType.Char, 1).Value = indica;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    private DataTable callto_cierre_cabeceraproyecto(int codproyecto, int mesano)
    {
        Conexiones con = new Conexiones();
        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + con.Servidor + " ;Database= " + con.Base + " ; User ID= " + con.Usuario + " ;Password= " + con.Passw + " ;Trusted_Connection=False");
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "cierre_cabeceraproyecto";
        sqlc.Parameters.Add("@codproyecto", SqlDbType.Int, 4).Value = codproyecto;
        sqlc.Parameters.Add("@mesano", SqlDbType.Int, 4).Value = mesano;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    private void getinstituciones()
    {
        DataSet ds = (DataSet)Session["dsParametricas"];
        // << --- DPL 26-08-2015 --- >
        //institucioncoll icoll = new institucioncoll();
        //DataTable dtinst = icoll.GetData(Convert.ToInt32(Session["IdUsuario"]));
        //DataView dv = new DataView(dtinst);
        // << --- DPL 26-08-2015 --- >
        DataTable dtinst = ds.Tables["dtInstituciones"];
        DataView dv = new DataView(ds.Tables["dtInstituciones"]);
        dv.Sort = "Nombre ASC";
        ddown001.DataSource = dv;
        ddown001.DataTextField = "Nombre";
        ddown001.DataValueField = "Codinstitucion";
        ddown001.DataBind();
        // <---------- DPL ---------->  09-08-2010
        if (dtinst.Rows.Count > 0 && ddown001.SelectedIndex == 0)
            ddown001.SelectedIndex = 1;
        // <---------- DPL ---------->  09-08-2010

    }
    private void getproyectos()
    {
        if (ddown001.Items.Count > 0 && Convert.ToInt32(ddown001.SelectedValue) > 0)
        {
            proyectocoll pcoll = new proyectocoll();

            DataTable dtproy = pcoll.GetData(Convert.ToInt32(Session["IdUsuario"]), "V", Convert.ToInt32(ddown001.SelectedValue));
            DataView dv = new DataView(dtproy);
            dv.Sort = "Nombre";
            ddown002.DataSource = dv;
            ddown002.DataTextField = "Nombre";
            ddown002.DataValueField = "CodProyecto";
            ddown002.DataBind();

            if (dv.Count == 2 && ddown002.SelectedIndex == 0)
            {
                ddown002.SelectedIndex = 1;
            }
        }


    }


    private void getanos()
    {
        for (int i = 0; i < 7; i++)
        {
            ddown_AnoCierre.Items.Add(Convert.ToString(DateTime.Now.Year - i));

        }

    }
    protected void ddown001_SelectedIndexChanged(object sender, EventArgs e)
    {
        getproyectos();
    }
    protected void ddown002_SelectedIndexChanged(object sender, EventArgs e)
    {
        fn_buscar();
    }
    protected void ddown_MesCierre_SelectedIndexChanged(object sender, EventArgs e)
    {
        fn_buscar();
    }

    protected void imb001_Click(object sender, ImageClickEventArgs e)
    {
        string cadena = string.Empty;
        string etiqueta = "Busca Proyectos";

        cadena = @"window.open(this.Page, '../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_ninos/cierre_informeatencion.aspx', 'Buscador', false, true, '770', '420', false, false, true)";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Buscador", cadena, true);
    }

    private DataTable callto_cierre_regenerar(int codproyecto, int mesano, int idusuarioactualizacion)
    {
        Conexiones con = new Conexiones();
        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + con.Servidor + " ;Database= " + con.Base + " ; User ID= " + con.Usuario + " ;Password= " + con.Passw + " ;Trusted_Connection=False");
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "cierre_regenerar";
        sqlc.Parameters.Add("@codproyecto", SqlDbType.Int, 4).Value = codproyecto;
        sqlc.Parameters.Add("@mesano", SqlDbType.Int, 4).Value = mesano;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = idusuarioactualizacion;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();

        //Img_cargando.Visible = false;

        return dt;


    }


    protected void imb005_Click(object sender, EventArgs e)
    {

        if (ddown002.SelectedValue != "" && Convert.ToString(ddown_MesCierre.SelectedValue) != "Seleccione mes")
        {

            DataTable dt0 = callto_cierre_regenerar(Convert.ToInt32(ddown002.SelectedValue), Convert.ToInt32(ddown_AnoCierre.SelectedValue + ddown_MesCierre.SelectedValue), Convert.ToInt32(Session["IdUsuario"]));
            //Img_cargando.Visible = true;
            lbl008.Text = "";
        }
        else
        {
            alert_lb_1y8.Visible = true;
            lbl008.Text = "Debe Ingresar un Periodo";
            lbl008.Visible = true;
        }
    }
    //protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    //{
    //    if (ddown002.SelectedValue != "" && Convert.ToString(ddown_MesCierre.SelectedValue) != "Seleccione mes")
    //    {

    //        DataTable dt0 = callto_cierre_regenerar(Convert.ToInt32(ddown002.SelectedValue), Convert.ToInt32(ddown_AnoCierre.SelectedValue + ddown_MesCierre.SelectedValue), Convert.ToInt32(Session["IdUsuario"]), ASP.global_asax.globaconn);
    //        //Img_cargando.Visible = true;
    //        lbl008.Text = "";
    //    }
    //    else
    //    {
    //        lbl008.Text = "Debe Ingresar un Periodo";
    //        lbl008.Visible = true;
    //    }
    //}
    protected void Imb002_Click(object sender, EventArgs e)
    {
        if (ddown_MesCierre.SelectedIndex > 0)
        {
            Response.Redirect("cierre_informeatencion.aspx?sw=4&codinst=" + ddown002.SelectedValue + "&M=" + ddown_MesCierre.SelectedValue + "&A=" + ddown_AnoCierre.SelectedValue);
        }
    }
    protected void Imb003_Click(object sender, EventArgs e)
    {
        if (ddown_MesCierre.SelectedIndex > 0)
        {
            Response.Redirect("cierre_registroatencion.aspx?sw=4&codinst=" + ddown002.SelectedValue + "&M=" + ddown_MesCierre.SelectedValue + "&A=" + ddown_AnoCierre.SelectedValue);
        }
    }
 
    protected void ImageButton1_Click(object sender, EventArgs e)
    {
        if (ddown002.SelectedValue != "" && Convert.ToString(ddown_MesCierre.SelectedValue) != "Seleccione mes")
        {

            DataTable dt0 = callto_cierre_regenerar(Convert.ToInt32(ddown002.SelectedValue), Convert.ToInt32(ddown_AnoCierre.SelectedValue + ddown_MesCierre.SelectedValue), Convert.ToInt32(Session["IdUsuario"]));
            //Img_cargando.Visible = true;
            lbl008.Text = "";
        }
        else
        {
            alert_lb_1y8.Visible = true;
            lbl008.Text = "Debe Ingresar un Periodo";
            lbl008.Visible = true;
        }
    }

    private void mostrar_collapse(bool valor)
    {
      if (valor)
      {
        collapse_Form.Attributes.Remove("Class");
        collapse_Form.Attributes.Add("Class", "panel-collapse collapse in");
      }
      if (!valor)
      {
        collapse_Form.Attributes.Remove("Class");
        collapse_Form.Attributes.Add("Class", "panel-collapse collapse out");
      }

    }
}
