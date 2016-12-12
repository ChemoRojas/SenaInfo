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

public partial class QuienTraslada : System.Web.UI.Page
{
    public int vCodPaso
    {
        get { return (int)Session["vCodPaso"]; }
        set { Session["vCodPaso"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //A1.HRef = "bsc_institucion.aspx?param001=Busca Proyectos&dir=reg_eventosproy.aspx, 'Buscador', false, true, '770', '420', false, false, true";

        if (!IsPostBack)
        {
            if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
            {
                Response.Redirect("~/logout.aspx");
            }
            else
            {
                if (!window.existetoken("E0430222-2C3A-4CDB-818A-F893A322D9B0"))
                {
                    Response.Redirect("~/logout.aspx");
                }


                getinstituciones();
                getproyecto();
                ninocoll ncoll = new ninocoll();
                if (Request.QueryString["sw"] == "3")
                {

                    ddlInstitucion.SelectedValue = Request.QueryString["codinst"];
                    getproyecto();
                }
                if (Request.QueryString["sw"] == "4")
                {
                    buscador_institucion bsc = new buscador_institucion();
                    int codinst = bsc.GetCodInstxCodProy(Convert.ToInt32(Request.QueryString["codinst"]));
                    ddlInstitucion.SelectedValue = Convert.ToString(codinst);
                    getproyecto();
                    ddlProyecto.SelectedValue = Request.QueryString["codinst"];
                }

                validatescurity(); //LO ULTIMO DEL LOAD
            }
        }
        else
            if (grdQuienTraslada.Rows.Count == 0)
            {
            }
        
    }
    private void validatescurity()
    {
        if (!window.existetoken("04640223-98C3-4874-9847-A5E5AA5263F0"))
        {
            imb001.Visible = false;
            
        }
        if (!window.existetoken("075CEDBA-76F3-44E1-9C3E-A0F93CC86C57"))
        {
        }

    }

    private void getinstituciones()
    {

        institucioncoll ncoll = new institucioncoll();
        DataView dv1 = new DataView(ncoll.GetData(Convert.ToInt32(Session["IdUsuario"])));
        ddlInstitucion.DataSource = dv1;
        ddlInstitucion.DataTextField = "Nombre";
        ddlInstitucion.DataValueField = "CodInstitucion";
        dv1.Sort = "Nombre";
        DataBind();


    }
    private void getproyecto()
    {

        proyectocoll pcoll = new proyectocoll();

        DataTable dtproy = pcoll.GetData(Convert.ToInt32(Session["IdUsuario"]),"V",Convert.ToInt32(ddlInstitucion.SelectedValue));
        ddlProyecto.DataSource = dtproy;
        ddlProyecto.DataTextField = "Nombre";
        ddlProyecto.DataValueField = "CodProyecto";
        ddlProyecto.DataBind();
    }
    private void getregion()
    {


        parcoll par = new parcoll();
        DataView dv6 = new DataView(par.GetparRegion());
        dv6.Sort = "CodRegion";


    }
    private void getcomuna()
    {

    }


    
   
    protected void ddown001_SelectedIndexChanged(object sender, EventArgs e)
    {
        getproyecto();
    }
    //protected void imb001_Click(object sender, EventArgs e)
    //{
    //    GrabarDatos();
        
    //}
    private void funcion_guardar()
    {
        Conexiones con = new Conexiones();

                // JOVM - 20/01/2015
                // Se comenta la grabación original
                //int ICodEventosProyectos = inup.Insert_Update_EventosProyecto(ASP.global_asax.globaconn, vCodPaso, Convert.ToInt32(ddown002.SelectedValue),
                // Convert.ToInt32(ddown003.SelectedValue), Convert.ToDateTime(WebDateChooser1.Value), Convert.ToInt32(Session["IdUsuario"])/*usr*/, Convert.ToInt32(ddown005.SelectedValue),
                // descripcion, cantasistentes, "V", Convert.ToInt32(txt003.Text), Convert.ToInt32(txt004.Text), Convert.ToInt32(txt005.Text),
                // Convert.ToInt32(txt006.Text));
                


                imb001.Visible = true;

                validatescurity();

                ddlInstitucion.BackColor = System.Drawing.Color.White;
                ddlProyecto.BackColor = System.Drawing.Color.White;
                lbl001.Visible = false;
                ninocoll ncoll = new ninocoll();
                int CodModeloIntervencion = (int)ncoll.callto_get_codmodelointervencion(Convert.ToInt32(ddlProyecto.SelectedValue));

                if (CodModeloIntervencion == 107 || CodModeloIntervencion == 104 || CodModeloIntervencion == 17 || CodModeloIntervencion == 100)       // PPC - PROGRAMA PREVENCION COMUNITARIA y CRC  CENTRO DE INTERNACION EN REGIMEN CERRADO y CTD - CENTRO DE TRÁNSITO Y DISTRIBUCIÓN CON RESIDENCIA
                {

                    // JOVM - 20/01/2015
                    // Se comenta la grabación original
                    //if (ICodEventosProyectos == 0 && vCodPaso != Convert.ToInt32(ddown002.Text) && vCodPaso != -1) ICodEventosProyectos = vCodPaso;
                    //inup.Insert_Update_EventosProyectoAsistencia_PPC(ASP.global_asax.globaconn, grdQuienTraslada, ICodEventosProyectos);
                    grdQuienTraslada.Visible = false;
                    grdQuienTraslada.DataSource = null;
                    grdQuienTraslada.DataSource = "";

                    DbDataReader datareader = null;
                    //Database db = new Database();

                    DbParameter[] neoprms = {
        con.parametros("@CodProyecto", SqlDbType.Int, 4, Convert.ToInt32(ddlProyecto.SelectedValue)),
         con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4,  Convert.ToInt32(Session["IdUsuario"]))};

                    //DbParameter[] neoprms = {
                    //db.neoinprms("@CodProyecto", DbTypes.Int, 4, Convert.ToInt32(ddlProyecto.SelectedValue)) , 
                    ////db.neoinprms("@MesAno", DbTypes.Int, 4, AnoMes) , 
                    //db.neoinprms("@IdUsuarioActualizacion", DbTypes.Int, 4, Convert.ToInt32(Session["IdUsuario"]))  
                    //};


                    con.ejecutarProcedimiento("cierre_regenerar", neoprms, out datareader);
                    //db.execproecedure("cierre_regenerar", neoprms, out datareader);
                    //db.Close();
         
        }

    }
    //protected void WebImageButton1_Click(object sender, EventArgs e)
    //{
    //    window.open(this.Page, "bsc_institucion.aspx?param001=Registro de Eventos-Proyecto&codproy="+ddlProyecto.SelectedValue, "Buscador", false, false, 770, 420, false, false, true);
    //}
    protected void WebImageButton2_Click(object sender, EventArgs e)
    {
        funcion_limpiar();
    }
    private void funcion_limpiar()
    {
        for (int j = 0; j < this.Controls.Count; j++)
        {
            for (int i = 0; i < this.Controls[j].Controls.Count; i++)
            {
                try
                {
                    ((TextBox)this.Controls[j].Controls[i]).Text = "";
                }
                catch { }
                try
                {
                    ((DropDownList)this.Controls[j].Controls[i]).SelectedIndex = 0;
                }
                catch { }
                try
                {
                    //((TextBox)this.Controls[j].Controls[i]).Value = "";
                }
                catch { }

                try
                {
                    //((WebDateTimeEdit)this.Controls[j].Controls[i]).Value = "";
                }
                catch { }


            }

        }
        getproyecto();
        getcomuna();
        imb001.Visible = true;
        grdQuienTraslada.Visible = false;
        grdQuienTraslada.DataSource = null;
        grdQuienTraslada.DataSource = "";
    }
    private void ListadoAsistencia(int CodProyecto)
    {
        Conexiones con = new Conexiones();
        ninocoll ncoll = new ninocoll();
        int CodModeloIntervencion = 0;

        if (CodProyecto != 0)
            CodModeloIntervencion = (int)ncoll.callto_get_codmodelointervencion(CodProyecto);
        else
            return;


        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + con.Servidor + " ;Database= " + con.Base + " ; User ID= " + con.Usuario + " ;Password= " + con.Passw + " ;Trusted_Connection=False");
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();

        if (CodModeloIntervencion == 107 || CodModeloIntervencion == 104 || CodModeloIntervencion == 17 || CodModeloIntervencion == 100)
        {
            sqlc.Connection = sconn;
            sqlc.CommandType = System.Data.CommandType.StoredProcedure;
            sqlc.CommandText = "GetNinosEventoProyecto_PPC";
            sqlc.Parameters.Add("@ICodEventosProyectos", SqlDbType.Int, 4).Value = vCodPaso;
            sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = CodProyecto;

            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
            DataTable dt = new DataTable();
            sconn.Open();
            da.Fill(dt);
            sconn.Close();

            if (dt.Rows.Count > 0)
            {
                CheckBox chkPresente = new CheckBox();
                grdQuienTraslada.DataSource = dt;
                grdQuienTraslada.DataBind();

                for (int i = 0; i < grdQuienTraslada.Rows.Count; i++)
                {
                    chkPresente = (CheckBox)grdQuienTraslada.Rows[i].Cells[5].FindControl("chkPresente");
                    if (Convert.ToInt32(dt.Rows[i][8]) == 0)
                        chkPresente.Checked = false;
                }
            }
            else
            {
                return;
            }
        }
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Plan de Intervencion";
        window.open(this.Page, "bsc_institucion.aspx?param001=" + etiqueta + "&dir=reg_eventosproy.aspx", "Buscador", false, true, 770, 420, false, false, true);
    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Busca Proyectos";
        window.open(this.Page, "bsc_institucion.aspx?param001=" + etiqueta + "&dir=reg_eventosproy.aspx", "Buscador", false, true, 770, 420, false, false, true);
    }
    //protected void WebImageButton3_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("Default.aspx");
    //}
    protected void ddown002_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlProyecto.SelectedValue != "0")
        {
            CargaGrilla();
        }

    }
    protected void CargaGrilla()
    {
        Conexiones con = new Conexiones();
        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + con.Servidor + " ;Database= " + con.Base + " ; User ID= " + con.Usuario + " ;Password= " + con.Passw + " ;Trusted_Connection=False");
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();

        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "QuienTraslada_Consulta";
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = ddlProyecto.SelectedValue;

        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();

        if (dt.Rows.Count > 0)
        {
            grdQuienTraslada.DataSource = dt;
            grdQuienTraslada.DataBind();

            imb001.Visible = true;
            WebImageButton4.Visible = false;
        }
    
    }
    protected void GrabarDatos()
    {
        Conexiones con = new Conexiones();
        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + con.Servidor + " ;Database= " + con.Base + " ; User ID= " + con.Usuario + " ;Password= " + con.Passw + " ;Trusted_Connection=False");
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "QuienTraslada_Graba";

        int CodigoTraslado=0, ICodIE=0;
        DropDownList ListaTiposTraslados= new DropDownList();

        for (int i = 0; i < grdQuienTraslada.Rows.Count; i++)
        {
            ListaTiposTraslados = (DropDownList)(grdQuienTraslada.Rows[i].Cells[7].FindControl("ListaTiposTraslados"));
            CodigoTraslado= Convert.ToInt32(ListaTiposTraslados.SelectedValue);
            ICodIE =Convert.ToInt32(grdQuienTraslada.Rows[i].Cells[0].Text);
            sqlc.Parameters.Add("@IcodIE", SqlDbType.Int, 4).Value = ICodIE;
            sqlc.Parameters.Add("@CodTraslado", SqlDbType.Int, 4).Value = CodigoTraslado;
            sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = Convert.ToInt32(Session["IdUsuario"]);
            sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 4).Value = DateTime.Now;
            sqlc.Connection.Open();
            sqlc.ExecuteNonQuery();
            sqlc.Connection.Close();
            sqlc.Parameters.Clear();
        }
        Response.Redirect("default.aspx");
        
    }
    protected void MarcaCasilla(int Columna)
    {
        for (int i = 0; i < grdQuienTraslada.Rows.Count; i++)
        {

        }
    }
    //protected void WebImageButton4_Click(object sender, EventArgs e)
    //{
    //    CargaGrilla();
    //}
    protected void WebImageButton1_Click(object sender, EventArgs e)
    {
        window.open(this.Page, "bsc_institucion.aspx?param001=Registro de Eventos-Proyecto&codproy=" + ddlProyecto.SelectedValue, "Buscador", false, false, 770, 420, false, false, true);
    }
    protected void imb001_Click(object sender, EventArgs e)
    {
        GrabarDatos();
    }
    protected void WebImageButton4_Click(object sender, EventArgs e)
    {
        CargaGrilla();
    }
    protected void WebImageButton3_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}
