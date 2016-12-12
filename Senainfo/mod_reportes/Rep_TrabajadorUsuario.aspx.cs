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
using System.Drawing;

public partial class Reportes_Rep_TrabajadorUsuario : System.Web.UI.Page
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

                getinstituciones();
                if (Session["CodInstitucion"] != null)
                    ddInstitucion.SelectedValue = Session["CodInstitucion"].ToString();

                getproyectoxinst();
                if (Session["CodProyecto"] != null)
                    ddProyecto.SelectedValue = Session["CodProyecto"].ToString();

                ImageButton1.Visible = false;

                if (Request.QueryString["sw"] == "3")
                {
                    ddInstitucion.SelectedValue = Request.QueryString["codinst"];
                    ddown002_SelectedIndexChanged(sender, e);
                }
                if (Request.QueryString["sw"] == "4")
                {
                    buscador_institucion bsc = new buscador_institucion();
                    int codinst = bsc.GetCodInstxCodProy(Convert.ToInt32(Request.QueryString["codinst"]));
                    ddInstitucion.SelectedValue = Convert.ToString(codinst);
                    getproyectoxinst();
                    ddProyecto.SelectedValue = Request.QueryString["codinst"];
                }
            }
        }

        Session["CodInstitucion"] = ddInstitucion.SelectedValue;
        Session["CodProyecto"] = ddProyecto.SelectedValue;
    }

    private void limpiaSession()
    {
        Session["CodRegion"] = null;
        Session["CodInstitucion"] = null;
        Session["CodProyecto"] = null;
    }
    private int validatesecurity()
    {
        trabajadorescoll tcol = new trabajadorescoll();
        string rol = tcol.get_rol(Convert.ToInt32(Session["IdUsuario"]));
        int val = 0;

        if (rol == "267" || rol == "265")
        {
            if (ddInstitucion.SelectedValue == "0")
            {
                ddInstitucion.BackColor = System.Drawing.Color.Pink;
                val = 1;
                limpiar();
            }
            else { ddInstitucion.BackColor = System.Drawing.Color.White; }

            if (ddProyecto.SelectedValue == "0")
            {
                ddProyecto.BackColor = System.Drawing.Color.Pink;
                val = 1;
                limpiar();
            }
            else { ddProyecto.BackColor = System.Drawing.Color.White; }
        }
        if (rol == "251")
        {
            if (ddInstitucion.SelectedValue == "0")
            {
                ddInstitucion.BackColor = System.Drawing.Color.Pink;
                val = 1;
                limpiar();
            }
            else { ddInstitucion.BackColor = System.Drawing.Color.White; }
        }

        return val;
    }
    private void limpiar()
    {
        grd001.Visible = false;
        ImageButton1.Visible = false;
        lbl_error.Visible = false;

    }
    private void getinstituciones()
    {
        institucioncoll inst = new institucioncoll();
        DataView dv2 = new DataView(inst.GetData(Convert.ToInt32(Session["IdUsuario"])));
        ddInstitucion.DataSource = dv2;
        ddInstitucion.DataTextField = "Nombre";
        ddInstitucion.DataValueField = "CodInstitucion";
        dv2.Sort = "Nombre";
        ddInstitucion.DataBind();

        if (dv2.Count == 2)
            ddInstitucion.SelectedIndex = 1;

    }
    private void getproyectoxinst()
    {
        proyectocoll proy = new proyectocoll();
        DataView dv3 = new DataView(proy.GetData(Convert.ToInt32(Session["IdUsuario"]), "V", Convert.ToInt32(ddInstitucion.SelectedValue)));
        ddProyecto.DataSource = dv3;
        ddProyecto.DataTextField = "Nombre";
        ddProyecto.DataValueField = "CodProyecto";
        dv3.Sort = "CodProyecto";
        ddProyecto.DataBind();

        if (dv3.Count == 2)
            ddProyecto.SelectedIndex = 1;   
    }

    protected void btn_volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("../mod_reportes/index_reportes.aspx");
    }
    protected void btn_buscar_Click(object sender, EventArgs e)
    {
        int val = validatesecurity();
        if (val == 0)
            cargaDTG(Convert.ToInt32(ddInstitucion.SelectedValue), Convert.ToInt32(ddProyecto.SelectedValue), 0);
    }
    private void cargaDTG(int CodInstitucion, int CodProyecto, int iExcel)
    {
        //SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        //System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        //sqlc.Connection = sconn;
        //sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        //sqlc.CommandText = "Reporte_Usuarios";
        //sqlc.Parameters.Add("@CodInstitucion", SqlDbType.Int, 4).Value = CodInstitucion;
        //sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = CodProyecto;
        //System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        //DataTable dt = new DataTable();
        //sconn.Open();
        //da.Fill(dt);
        //sconn.Close();

        DataTable dt = new DataTable();

        Conexiones con = new Conexiones();
        con.Autenticar();
        dt = con.TraerDataTable("Reporte_Usuarios", CodInstitucion, CodProyecto);
        con.CerrarConexion();

        if (iExcel == 1)
            ExportaExcel(dt);
        
        DataView dv = new DataView(dt);
        if (dv.Count > 0)
        {
            grd001.DataSource = dv;
            grd001.DataBind();
            ImageButton1.Visible = true;
            lbl_error.Visible = false;
            grd001.Visible = true;
        }
        else
        {
            ImageButton1.Visible = false;
            lbl_error.Text = "No se han encontrado registros coincidentes";
            lbl_error.Visible = true;
            grd001.Visible = false;
        }

    }
    protected void ddown002_SelectedIndexChanged(object sender, EventArgs e)
    {
        getproyectoxinst();
    }
    protected void ddown001_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddregion.SelectedValue == "-1" || ddregion.SelectedValue == "15")
        //{
        //    getinstituciones();
        //}
        //else
        //{
        //    getinstitucionesxRgn();
        //}
    }


    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        cargaDTG(Convert.ToInt32(ddInstitucion.SelectedValue), Convert.ToInt32(ddProyecto.SelectedValue), 1);
    }

    protected void ExportaExcel(DataTable dt)
    {
        Response.Clear();
        Response.Buffer = true;

        // Set the content type to Excel
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=Reporte_TrabajadorUsuarios.xls");
        // Remove the charset from the Content-Type header.
        Response.Charset = "";
        // Turn off the view state.
        this.EnableViewState = false;

        System.IO.StringWriter tw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

        // Get the HTML for the control.
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
    protected void btn_limpiar_Click(object sender, EventArgs e)
    {
        grd001.Visible = false;
        ImageButton1.Visible = false;
        lbl_error.Visible = false;
        ddInstitucion.SelectedIndex = -1;
        ddProyecto.SelectedIndex = -1;
    }
    protected void btnBuscaInstitucion_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Plan de Intervencion";
        window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_reportes/Rep_TrabajadorUsuario.aspx", "Buscador", false, true, 500, 650, false, false, true);
    }
    protected void btnBuscaProyecto_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Busca Proyectos";
        window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_reportes/Rep_TrabajadorUsuario.aspx", "Buscador", false, true, 500, 650, false, false, true);
    }
    protected void ddInstitucion_SelectedIndexChanged(object sender, EventArgs e)
    {
        getproyectoxinst();
    }

    protected void ImageButton1_Click1(object sender, EventArgs e)
    {
        cargaDTG(Convert.ToInt32(ddInstitucion.SelectedValue), Convert.ToInt32(ddProyecto.SelectedValue), 1);
    }
}
