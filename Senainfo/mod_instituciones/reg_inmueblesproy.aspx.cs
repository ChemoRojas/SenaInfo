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

public partial class mod_institucion_reg_inmueblesproy : System.Web.UI.Page
{
    public int vCodPaso
    {
        get { return (int)Session["vCodPaso"]; }
        set { Session["vCodPaso"] = value; }
    }
    public int vCodPaso2
    {
        get { return (int)Session["vCodPaso2"]; }
        set { Session["vCodPaso2"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
      alerts.Attributes.Add("style", "display:none");
      lbl005.Attributes.Add("style", "display:none");
      alerts2.Attributes.Add("style", "display:none");
      lbl0052.Attributes.Add("style", "display:none");
        //string etiqueta = "Registro de Inmuebles-Proyecto";
        //string urlA3 = "bsc_institucion.aspx?param001=Registro de Inmuebles-Proyecto&dir=reg_inmueblesproy.aspx&codinst=" + ddl_institucion.SelectedValue;
        //A3.HRef = urlA3;

        if (!IsPostBack)
        {
            if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
            {
                Response.Redirect("~/logout.aspx");
            }
            else
            {
                if (!window.existetoken("E6AF7398-72DC-4CAB-A890-026D9C6C3DDF"))
                {
                    Response.Redirect("~/logout.aspx");
                }

                getinstituciones();
                getproyecto();
                getinmuebles();
                if (Request.QueryString["sw"] == "1")
                {
                    Get_Resultado_Busqueda(vCodPaso, vCodPaso2);
                }
                if (Request.QueryString["sw"] == "3")
                {

                    ddl_institucion.SelectedValue = Request.QueryString["codinst"];
                    getproyecto();
                    getinmuebles();
                }
                if (Request.QueryString["sw"] == "4")
                {
                    buscador_institucion bsc = new buscador_institucion();
                    int codinst = bsc.GetCodInstxCodProy(Convert.ToInt32(Request.QueryString["codinst"]));
                    ddl_institucion.SelectedValue = Convert.ToString(codinst);
                    getproyecto();
                    ddl_proyecto.SelectedValue = Request.QueryString["codinst"];
                    getinmuebles();
                   // btn_guardar.Visible = false;
                }
                if (Request.QueryString["sw"] == "5")
                {
                    buscador_institucion bsc = new buscador_institucion();
                    ddl_institucion.SelectedValue = Request.QueryString["codinst"];
                    getproyecto();
                    getinmuebles();
                    ddl_inmueble.SelectedValue = Request.QueryString["codInmueble"];
                    ddl_institucion.Enabled = false;
                    ddl_inmueble.Enabled = false;
                }

                txt_fi.Text = DateTime.Now.ToShortDateString();
                validatescurity(); //LO ULTIMO DEL LOAD
            }

            if (Session["NNA"] != null)
            {
                oNNA NNA = (oNNA)Session["NNA"];

                //txt003.Text = NNA.NNAApePaterno;
                //txt005.Text = NNA.NNANombres;
                //txt004.Text = NNA.NNAApeMaterno;
                ddl_institucion.SelectedValue = NNA.NNACodInstitucion;
                getproyecto();
                ddl_proyecto.SelectedValue = NNA.NNACodProyecto;

                if (NNA.NNACodInstitucion != "" && NNA.NNACodProyecto != "")
                {
                    btn_guardar.Visible = false;
                }
                else
                {
                    btn_actualizar.Visible = false;
                }
            }
            else
            {
                oNNA NNA = new oNNA("", "", 0, 0, "", "", "", "", "", "");
                Session["NNA"] = NNA;
            }
        }
    }
    private void validatescurity()
    {
        //FFDE3824-A2CC-4EDE-928D-829D57ECBB97 1.7_INGRESAR
        if (!window.existetoken("FFDE3824-A2CC-4EDE-928D-829D57ECBB97"))
        {
           
            btn_guardar.Visible = false;
            //block();

        }
        //65C6093C-2D24-49CC-9FFD-B2233BFD9EC4 1.7_MODIFICAR
        if (!window.existetoken("65C6093C-2D24-49CC-9FFD-B2233BFD9EC4"))
        {
            
            btn_actualizar.Visible = false;
            //block();

        }

    }
         private void getinstituciones()
        {
            institucioncoll ncoll = new institucioncoll();
            DataView dv1 = new DataView(ncoll.GetData(Convert.ToInt32(Session["IdUsuario"])));
            ddl_institucion.DataSource = dv1;
            ddl_institucion.DataTextField = "Nombre";
            ddl_institucion.DataValueField = "CodInstitucion";
            dv1.Sort = "Nombre";
            DataBind();

        }
    private void getproyecto()
    {

        proyectocoll pcoll = new proyectocoll();

        DataTable dtproy = pcoll.GetData(Convert.ToInt32(Session["IdUsuario"]),"V",Convert.ToInt32(ddl_institucion.SelectedValue));
        ddl_proyecto.DataSource = dtproy;
        ddl_proyecto.DataTextField = "Nombre";
        ddl_proyecto.DataValueField = "CodProyecto";
        ddl_proyecto.DataBind();
    }
    private void getinmuebles()
    {

        inmueblecoll icoll = new inmueblecoll();

        DataTable dtproy = icoll.GetInmuebleProy(ddl_institucion.SelectedValue);
        DataView dv = new DataView(dtproy);

        DataTable dtproy2 = dv.ToTable(true);
        
        ddl_inmueble.DataSource = dtproy2;
        ddl_inmueble.DataTextField = "Nombre";
        ddl_inmueble.DataValueField = "ICodInmueble";
        ddl_inmueble.DataBind();
    }
    private void getinmueblesSN()
    {

        inmueblecoll icoll = new inmueblecoll();

        DataTable dtproy = icoll.GetInmueble(ddl_proyecto.SelectedValue);
        ddl_inmueble.DataSource = dtproy;
        ddl_inmueble.DataTextField = "Nombre";
        ddl_inmueble.DataValueField = "ICodInmueble";
        ddl_inmueble.DataBind();
    }
    protected void  ddl_institucion_SelectedIndexChanged(object sender, EventArgs e)
    {
        getproyecto();
        getinmuebles();
    }
    

    public void Get_Resultado_Busqueda(int codinmueble, int codproyecto)
    {
        string sParametrosConsulta = "SELECT T3.Nombre as NombreProyecto,T3.Nombre,T2.CodInstitucion,T3.TipoProyecto,T2.Nombre,T2.TipoInmueble,T1.CodProyecto,T1.ICodInmueble,T1.FechaInicioVigencia,T1.IdUsuarioActualizacion," +
                              "T1.FechaFinVigencia,T1.IndVigencia,T1.FechaActualizacion FROM ProyectoInmueble T1 " +
                              "INNER JOIN Inmueble T2 ON T1.ICodInmueble = T2.ICodInmueble " +
                              "INNER JOIN Proyectos T3 ON T1.CodProyecto = T3.CodProyecto " +
                              "WHERE  T1.CodProyecto = "+codproyecto+" and T1.ICodInmueble = "+codinmueble;

        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        con.ejecutar(sParametrosConsulta, out datareader);
        while (datareader.Read())
        {
            try
            {
                btn_guardar.Visible = false;
                btn_actualizar.Visible = true;
                validatescurity();
                ddl_institucion.SelectedValue = Convert.ToString((int)datareader["CodInstitucion"]);
                getproyecto();
                ddl_proyecto.SelectedValue = Convert.ToString((int)datareader["CodProyecto"]);
                getinmueblesSN();
                ddl_inmueble.SelectedValue = Convert.ToString((int)datareader["ICodInmueble"]);
                txt_fi.Text = Convert.ToString((DateTime)datareader["FechaInicioVigencia"]);
                try
                {
                    txt_ft.Text = Convert.ToString((DateTime)datareader["FechaFinVigencia"]);
                }
                catch
                {
                    txt_ft.Text = null;
                }
                ddl_vigencia.SelectedValue = (String)datareader["IndVigencia"];
                
                ddl_institucion.Enabled = false;
                ddl_proyecto.Enabled = false;
                ddl_inmueble.Enabled = false;
                txt_fi.Enabled = false;
                txt_ft.Enabled = true;
                ddl_vigencia.Enabled = true;

            }
            catch { }
        }
        con.Desconectar();

    }
   
    private void funcion_guardar()
    {
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        if (ddl_institucion.SelectedValue == "0" || ddl_proyecto.SelectedValue == "0" || ddl_inmueble.SelectedValue == "0" ||
                txt_fi.Text.Trim() == "")
        {
            if (ddl_institucion.SelectedValue == "0")
            { ddl_institucion.BackColor = colorCampoObligatorio; }
            else { ddl_institucion.BackColor = System.Drawing.Color.White; }
            if (ddl_proyecto.SelectedValue == "0")
            { ddl_proyecto.BackColor = colorCampoObligatorio; }
            else { ddl_proyecto.BackColor = System.Drawing.Color.White; }
            if (ddl_inmueble.SelectedValue == "0")
            { ddl_inmueble.BackColor = colorCampoObligatorio; }
            else { ddl_inmueble.BackColor = System.Drawing.Color.White; }
            if (txt_fi.Text.Trim() == "")
            { txt_fi.BackColor = colorCampoObligatorio; }
            else { txt_fi.BackColor = System.Drawing.Color.White; }

        }
        else
        {
            int CodInstitucion = Convert.ToInt32(ddl_institucion.SelectedValue);
            int CodProyecto = Convert.ToInt32(ddl_proyecto.SelectedValue);
            int IcodInmueble = Convert.ToInt32(ddl_inmueble.SelectedValue);
            DateTime FechaInicio = Convert.ToDateTime(txt_fi.Text);
            DateTime FechaFin = Convert.ToDateTime("01-01-1900").Date;
            if (txt_ft.Text.Trim() != "")
            {
                FechaFin = Convert.ToDateTime(txt_ft.Text);
            }

            insert_instproy inup = new insert_instproy();
            int retorno = inup.Insert_Update_ProyectoInmueble(CodProyecto, IcodInmueble, FechaInicio,
                          Convert.ToInt32(Session["IdUsuario"]), FechaFin, ddl_vigencia.SelectedValue);

            if (retorno == 0)
            {
              alerts2.Attributes.Add("style", "");
              lbl0052.Text = "Grabación Exitosa.";
              lbl0052.Attributes.Add("style", "");  
            }
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "", "window.alert('')", true);

            btn_guardar.Visible = true;
            btn_actualizar.Visible = false;
            funcion_limpiar();
            ddl_institucion.BackColor = System.Drawing.Color.White;
            ddl_proyecto.BackColor = System.Drawing.Color.White;
            ddl_inmueble.BackColor = System.Drawing.Color.White;
            txt_fi.BackColor = System.Drawing.Color.White;

           
        }
    
    }

    private void funcion_limpiar()
    {
        for (int j = 0; j < this.Controls.Count; j++)
        {
            for (int i = 0; i < this.Controls[j].Controls.Count; i++)
            {
                try
                {
                    ((DropDownList)this.Controls[j].Controls[i]).SelectedIndex = 0;
                }
                catch { }

            }

        }
        ddl_proyecto.Items.Clear();
        ListItem item= new ListItem("Seleccionar","0");
        ddl_proyecto.Items.Add(item);
        ddl_institucion.SelectedIndex = 0;
        txt_fi.Text = null;
        txt_ft.Text = null;
        getinmuebles();
        ddl_institucion.Enabled = true;
        ddl_proyecto.Enabled = true;
        ddl_inmueble.Enabled = true;
        ddl_vigencia.Enabled = false;
        txt_fi.Enabled = true;
        txt_ft.Enabled = true;
        btn_guardar.Visible = true;
        btn_actualizar.Visible = false;
        validatescurity();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Plan de Intervencion";
        string cadena = string.Empty;

        cadena = @"window.open(this.Page, 'bsc_institucion.aspx?param001=" + etiqueta + "&dir=reg_inmueblesproy.aspx', 'Buscador', false, true, '770', '420', false, false, true)";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Busca Proyectos";
        string cadena = string.Empty;

        cadena = @"window.open(this.Page, 'bsc_institucion.aspx?param001=" + etiqueta + "&dir=reg_inmueblesproy.aspx', 'Buscador', false, true, '770', '420', false, false, true)";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);
    }

 
    protected void ddl_proyecto_SelectedIndexChanged(object sender, EventArgs e)
    {
        oNNA NNA = (oNNA)Session["NNA"];
        NNA.NNACodInstitucion = ddl_institucion.SelectedValue;
        NNA.NNACodProyecto = ddl_proyecto.SelectedValue;
        Session["NNA"] = NNA;
    }
    protected void btn_buscar_Click(object sender, EventArgs e)
    {
        string etiqueta = "Registro de Inmuebles-Proyecto";
        string cadena = string.Empty;

        cadena = @"window.open(this.Page, 'bsc_institucion.aspx?param001=" + etiqueta + "&codinst=" + ddl_institucion.SelectedValue + "', 'Buscador', false, false, '770', '420', false, false, true)";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);
    }
    protected void btn_actualizar_Click(object sender, EventArgs e)
    {
        funcion_guardar();
    }
    protected void btn_guardar_Click(object sender, EventArgs e)
    {
        funcion_guardar();
    }
    protected void btn_limpiar_Click(object sender, EventArgs e)
    {
        funcion_limpiar();
    }
    //protected void WebImageButton3_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("index_instituciones.aspx");
    //}
}

