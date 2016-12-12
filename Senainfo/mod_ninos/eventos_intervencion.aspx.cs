/*
 * 
 * GMP
 * 08/05/2015
 * Revisión windows.open, agregué reloj de espera, validación de fecha, no hay descargas excel
 * 
 */
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

//////using neocsharp.NeoDatabase;

public partial class mod_ninos_eventos_intervencion : System.Web.UI.Page
{
    #region Variables_Sesion
    public string tipoPlan
    {
        get { return (string)Session["tipoPlan"]; }
        set { Session["tipoPlan"] = value; }
    }
    public string codplanintervencion
    {
        get { return (string)Session["codplanintervencion"]; }
        set { Session["codplanintervencion"] = value; }
    }
    public int codInstitucion
    {
        get { return (int)Session["codInstitucion"]; }
        set { Session["codInstitucion"] = value; }
    }
    public int codProyecto
    {
        get { return (int)Session["codProyecto"]; }
        set { Session["codProyecto"] = value; }
    }
    public int codgrupo
    {
        get { return (int)Session["codgrupo"]; }
        set { Session["codgrupo"] = value; }
    }
    public int codplaninterv
    {
        get { return (int)Session["codplaninterv"]; }
        set { Session["codplaninterv"] = value; }
    }
    public DateTime fechainicioplan
    {
        get { return (DateTime)Session["fechainicioplan"]; }
        set { Session["fechainicioplan"] = value; }
    
    }
    private DataSet dv2
    {
        get { return (DataSet)Session["dv2"]; }
        set { Session["dv2"] = value; }
    
    }
    public int icodie
    {
        get { return (int)Session["icodie"]; }
        set { Session["icodie"] = value; }
    }
    public string icodie_2
    {
        get { return (string)Session["icodie_2"]; }
        set { Session["icodie_2"] = value; }
    }
    public DataTable Tabla_Eventos
    {
        get { return (DataTable)Session["PI_Eventos_Estructura_Tabla"]; }
        set { Session["PI_Eventos_Estructura_Tabla"] = value; }
    }
    public DateTime fechaelaboracionplan
    {
        get { return (DateTime)Session["fechaelaboracionplan"]; }
        set { Session["fechaelaboracionplan"] = value; }

    }
    #endregion

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
                if (!window.existetoken("6F360136-E048-44FA-828E-E62CE3BDE05F"))
                {
                    Response.Redirect("~/logout.aspx");
                }
                else
                {
                    ddown003.Attributes.Add("CodTipo", "CodigoTipoNivel");
                    funcion_limpiar();
                    try
                    {
                        CalendarExtende473.StartDate = fechaelaboracionplan;
                        CalendarExtende473.EndDate = DateTime.Now;

                    }
                    catch { }

                    Arma_Estructura_Tabla();
                    Get_Resultado_Busqueda();
                }
                validatescurity();
            }
        }
    }
    private void validatescurity()
    {
        //DCE10CD5-8F3E-42F6-818C-9827C89A2FCD 2.6_INGRESAR
        if (!window.existetoken("DCE10CD5-8F3E-42F6-818C-9827C89A2FCD"))
        {
            WebImageButton1.Visible = false;
            WebImageButton2.Visible = false;

        }
        //AB6C0CB8-2C58-4C7D-B15D-00A0AFC14287 2.6_ELIMINAR
        if (!window.existetoken("AB6C0CB8-2C58-4C7D-B15D-00A0AFC14287"))
        {
            grd003.Columns[4].Visible = false;

        }

        ////B122B56F-15E0-4488-B5FE-FEADD035CF36
        //if (!window.existetoken(""))
        //{
        //    grd001.Columns[9].Visible = false;
        //}
       
    }
    private void Arma_Estructura_Tabla()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("FechaEvento", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("TipoEventoIntervencion", typeof(string)));
        dt.Columns.Add(new DataColumn("DescTipoIntervencion", typeof(string)));
        dt.Columns.Add(new DataColumn("CodTrabajador", typeof(string)));
        dt.Columns.Add(new DataColumn("IdGrupoEventos", typeof(string)));
        Tabla_Eventos = dt;
    }
    private void Carga_Tabla()
    {
        if (grd003.Rows.Count > 0)
        {
            DataRow dr;

            for (int i = 0; i < grd003.Rows.Count; i++)
            {
                dr = Tabla_Eventos.NewRow();
                dr[0] = grd003.Rows[i].Cells[0].Text;
                dr[1] = Server.HtmlDecode(grd003.Rows[i].Cells[1].Text);
                dr[2] = Server.HtmlDecode(grd003.Rows[i].Cells[2].Text);
                dr[3] = Server.HtmlDecode(grd003.Rows[i].Cells[3].Text);
                dr[4] = grd003.Rows[i].Cells[4].Text;
                Tabla_Eventos.Rows.Add(dr);
            }
        }
    }

    private void Get_Resultado_Busqueda()
    {
        cargagrilla();
        Carga_Tabla();
    }
    private void cargagrilla()
    {
        pintervencion pin = new pintervencion();
        int grupo = 0;
        int plan = 0;
        try
        {
            grupo = codgrupo;
        }
        catch { }
        try
        {
            plan = codplaninterv;
        }
        catch { };

        DataView dv = new DataView(pin.get_tipoevento_Cons(grupo,plan,codProyecto));
        if (dv.Table.Rows.Count > 0)
        {
            dv.Sort = "FechaEvento DESC";
            grd003.DataSource = dv;
            //grd003.DataSource = Tabla_Eventos;
            grd003.DataBind();
            grd003.Visible = true;
        }
        else
        {
            grd003.Visible = false;
        }
    }

    private void getTrabajadores()
    {
       
        trabajadorescoll tcoll = new trabajadorescoll();
        DataView dv1 = new DataView(tcoll.GetTrabajadoresProyecto(codProyecto.ToString() ));
        ddown005.DataSource = dv1;
        ddown005.DataTextField = "NombreCompleto";
        ddown005.DataValueField = "ICodTrabajador";
        dv1.Sort = "NombreCompleto";
        ddown005.DataBind();


    }
    private void get_areaintervencion(int CodGrupo,int PlanIntervencion)
    {
        pintervencion pin = new pintervencion();
            DataView dv1 = new DataView(pin.get_areaintervencionII(CodGrupo, PlanIntervencion, codProyecto));
        dv1.Sort = "Descripcion";
        ddown003.DataSource = dv1;
        ddown003.DataTextField = "Descripcion";
        ddown003.DataValueField = "ICodIntervenciones";
        
        ddown003.DataBind();
    }
    private void get_tipoEvento(int CodGrupo, int PlanIntervencion,int CodTipoIntervencion,int CodModeloIntervencion)
    {
        pintervencion pin = new pintervencion();
        DataView dv1 = new DataView(pin.get_tipoeventoII(CodGrupo, PlanIntervencion,CodTipoIntervencion,CodModeloIntervencion, codProyecto));
        dv1.Sort = "descripcion";
        ddown004.DataSource = dv1;
        ddown004.DataTextField = "descripcion";
        ddown004.DataValueField = "TipoEventoIntervencion";
        ddown004.DataBind();
    }

  
    private bool Agrega_evento()
    {
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis
        if (ddown003.SelectedValue == "0" || ddown005.SelectedValue == "0" || ddown004.SelectedValue == "0"   || WebDateChooser1.Text.Trim() == "")
        {
            if (ddown003.SelectedValue == "0") { ddown003.BackColor = colorCampoObligatorio; }
            else { ddown003.BackColor = System.Drawing.Color.White; }
            if (ddown004.SelectedValue == "0") { ddown004.BackColor = colorCampoObligatorio; }
            else { ddown004.BackColor = System.Drawing.Color.White; }
            if (ddown005.SelectedValue == "0") { ddown005.BackColor = colorCampoObligatorio; }
            else { ddown005.BackColor = System.Drawing.Color.White; }
            if (WebDateChooser1.Text == "Seleccione Fecha" || WebDateChooser1.Text.Trim() == "") { WebDateChooser1.BackColor = colorCampoObligatorio; }
            else { WebDateChooser1.BackColor = System.Drawing.Color.White; }
            return false;
        }
        else
        {
            int var = 0;
            pintervencion pin = new pintervencion();
            DataRow dr;

            #region Forma Antigua
            //DataTable dt = new DataTable();
            //dt.Columns.Add(new DataColumn("FechaEvento", typeof(DateTime))); //1
            //dt.Columns.Add(new DataColumn("TipoEventoIntervencion", typeof(String))); //2
            //dt.Columns.Add(new DataColumn("DescTipoIntervencion", typeof(String))); //3
            //dt.Columns.Add(new DataColumn("CodTrabajador", typeof(String))); //4
            //dt.Columns.Add(new DataColumn("IdGrupoEventos", typeof(String))); //5

            //for (int i = 0; i < grd003.Rows.Count; i++)
            //{
            //    dr = dt.NewRow();
            //    dr[0] = grd003.Rows[i].Cells[0].Text;
            //    dr[1] = Server.HtmlDecode(grd003.Rows[i].Cells[1].Text);
            //    dr[2] = Server.HtmlDecode(grd003.Rows[i].Cells[2].Text);
            //    dr[3] = Server.HtmlDecode(grd003.Rows[i].Cells[3].Text);
            //    dr[4] = grd003.Rows[i].Cells[4].Text;
            //    dt.Rows.Add(dr);
            //    if (grd003.Rows[i].Cells[0].Text == Convert.ToDateTime(WebDateChooser1.Value).ToShortDateString() &&
            //       grd003.Rows[i].Cells[1].Text == ddown004.SelectedItem.Text && grd003.Rows[i].Cells[2].Text == ddown003.SelectedItem.Text &&
            //       grd003.Rows[i].Cells[3].Text == ddown005.SelectedItem.Text)
            //    {
            //        var = 1;
            //    }

            //}
            #endregion

            if (Tabla_Eventos.Rows.Count > 0) // verifica que no sea el mismo
            {
                for (int i = 0; i < Tabla_Eventos.Rows.Count; i++)
                {
                    if (Convert.ToDateTime(Tabla_Eventos.Rows[i][0]).ToShortDateString() == Convert.ToDateTime(WebDateChooser1.Text).ToShortDateString() &&
                       Tabla_Eventos.Rows[i][1].ToString() == ddown004.SelectedItem.Text &&
                       Tabla_Eventos.Rows[i][2].ToString() == ddown003.SelectedItem.Text &&
                       Tabla_Eventos.Rows[i][3].ToString() == ddown005.SelectedItem.Text)
                    {
                        var = 1;
                    }
                }
            }

            if (var == 0)
            {
                string iden = "";
                iden = Guid.NewGuid().ToString();
                //kvega
                char[] splitter_1 = { '_' };
                string[] cod_interv = ddown003.SelectedValue.Split(splitter_1);
                //kvega
               
                if (tipoPlan == "I")
                {
                    //int CodEventos = pin.Insert_Update_EventosIntervencion(-1,
                    //Convert.ToInt32(dv2.Table.Rows[0][0]), codProyecto, icodie,
                    //Convert.ToDateTime(WebDateChooser1.Text), Convert.ToInt32(ddown004.SelectedValue), txt002.Text.ToUpper(),
                    //Convert.ToInt32(ddown005.SelectedValue), codInstitucion, 0, DateTime.Now, Convert.ToInt32(Session["IdUsuario"]) /*usr*/,/*IdGrupoEventos*/iden);

                    int CodEventos = pin.Insert_Update_EventosIntervencion(-1,
                    Convert.ToInt32(cod_interv[0].ToString().Trim()), codProyecto, icodie,
                    Convert.ToDateTime(WebDateChooser1.Text), Convert.ToInt32(ddown004.SelectedValue), txt002.Text.ToUpper(),
                    Convert.ToInt32(ddown005.SelectedValue), codInstitucion, 0, DateTime.Now, Convert.ToInt32(Session["IdUsuario"]) /*usr*/,/*IdGrupoEventos*/iden);
                }
                else
                {
                    char[] splitter = { ',' };
                    string[] ie = icodie_2.Split(splitter);
                    for (int i = 0; i < ie.Length; i++)
                    {
                        if (ie[i].Trim() != "")
                        {
                            int CodEventos = pin.Insert_Update_EventosIntervencion(-1,
                             Convert.ToInt32(dv2.Tables[0].Rows[i][0]), codProyecto, Convert.ToInt32(ie[i]),
                             Convert.ToDateTime(WebDateChooser1.Text), Convert.ToInt32(ddown004.SelectedValue), txt002.Text.ToUpper(),
                             Convert.ToInt32(ddown005.SelectedValue), codInstitucion, 0, DateTime.Now, Convert.ToInt32(Session["IdUsuario"]) /*usr*/,/*IdGrupoEventos*/iden);
                        }
                    }
                }

                ddown003.BackColor = System.Drawing.Color.White;
                ddown004.BackColor = System.Drawing.Color.White;
                ddown005.BackColor = System.Drawing.Color.White;
                WebDateChooser1.BackColor = System.Drawing.Color.White;

                //dr = dt.NewRow();
                dr = Tabla_Eventos.NewRow();

                dr[0] = Convert.ToDateTime(WebDateChooser1.Text);
                dr[1] = ddown004.SelectedItem.Text;
                dr[2] = ddown003.SelectedItem.Text;
                dr[3] = ddown005.SelectedItem.Text;
                dr[4] = iden;
                //dt.Rows.Add(dr);
                Tabla_Eventos.Rows.Add(dr);

                idenEvento.Value = iden;
                
                //grd003.DataSource = dt;
                grd003.DataSource = Tabla_Eventos;
                grd003.DataBind();
                grd003.Visible = true;
                //funcion_limpiar();
            }
            ddown003.BackColor = System.Drawing.Color.White;
            ddown004.BackColor = System.Drawing.Color.White;
            ddown005.BackColor = System.Drawing.Color.White;
            WebDateChooser1.BackColor = System.Drawing.Color.White;
            return true;
        }

    }
    protected void ddown003_SelectedIndexChanged(object sender, EventArgs e)
    {
        pintervencion pin = new pintervencion();
        int grupo = 0;
        int plan = 0;
        try
        {
            grupo = codgrupo;
        }
        catch { }
        try
        {
            plan = codplaninterv;
        }
        catch { };


        char[] splitter = { '_' };
        string[] cod_interv = ddown003.SelectedValue.Split(splitter);
        

        int CodModeloInterv =  pin.get_CodModeloInterv(codProyecto);
        if (tipoPlan == "G")
        {
            get_tipoEvento(grupo,0,Convert.ToInt32(cod_interv[1].ToString().Trim()),CodModeloInterv);
            dv2 = new DataSet();
            dv2.Tables.Add(pin.get_ICodIntervenciones(grupo, 0, Convert.ToInt32(cod_interv[1].ToString().Trim())));
        }
        else
        {
            get_tipoEvento(grupo, plan, Convert.ToInt32(cod_interv[1].ToString().Trim()), CodModeloInterv);
            dv2 = new DataSet();
            dv2.Tables.Add(pin.get_ICodIntervenciones(grupo, plan, Convert.ToInt32(cod_interv[1].ToString().Trim())));
        }
    }
    protected void grd003_RowCommand(object sender, GridViewCommandEventArgs e)
    {
     
        if (e.CommandName == "Eliminar")
        {
            #region Forma Antigua
            //pintervencion pin = new pintervencion();
            //string Codigo = ""; 
            //if (tipoPlan == "I")
            //{
            //    Codigo = grd003.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Text;
            //    pin.delete_eventosintervencionxcodigo(Convert.ToInt32(Codigo));
            //}
            //else if (tipoPlan == "G")
            //{
            //    Codigo = grd003.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Text;
            //    pin.Delete_EventosIntervencion(Codigo);
            //}
            #endregion
            pintervencion pin = new pintervencion();
            string Codigo = "";
            grd003.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Visible = true;
            Codigo = grd003.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Text;
            pin.Delete_EventosIntervencion(Codigo);
            if (Tabla_Eventos.Rows.Count > 0)
            { Tabla_Eventos.Rows.RemoveAt(Convert.ToInt32(e.CommandArgument)); }
            grd003.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Visible = false;
            cargagrilla();
        }
    }

    //limpiar ventana
    protected void WebImageButton3_Click(object sender, EventArgs e)
    {
        funcion_limpiar();
    }

    private void funcion_limpiar()
    {
        if (Panel2.Visible)
        {
            ddown003.SelectedIndex = 0;
            ddown004.SelectedIndex = 0;
            ddown005.SelectedIndex = 0;
            txt002.Text = "";
            WebDateChooser1.Text = null;
        }
    }

    // cerrar ventana
    protected void WebImageButton4_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "", "CerrarFancybox();", true);
    }

    protected void grd003_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
       grd003.PageIndex = e.NewPageIndex;
       cargagrilla();
    }

    protected void WebDateChooser1_ValueChanged(object sender, EventArgs e)
    {
        if (ConfigurationSettings.AppSettings["Cierre_mes"].ToString() == "1")
        {
            DateTime fecha = Convert.ToDateTime(WebDateChooser1.Text);
            string ano = Convert.ToDateTime(fecha).Year.ToString();// fecha.Year.ToString();
            string mes = Convert.ToDateTime(fecha).Month.ToString();  //DateTime.Now.Month.ToString();

            if (mes.Length <= 1)
            {
                mes = 0 + mes;
            }
            
            diagnosticoscoll dcoll = new diagnosticoscoll();

            int Periodo = Convert.ToInt32(ano + mes);
            int Estado_cierre = dcoll.callto_consulta_cierremes(codProyecto, Periodo);

            if (Estado_cierre != 1)
            {
                WebImageButton1.Visible = true;
                lbl004b.Visible = false;
            }
            else
            {
                lbl004b.Text = "EL MES ESTA CERRADO, INSERTE UNA FECHA DIFERENTE";
                lbl004b.Visible = true;
                WebImageButton1.Visible = false;
                WebDateChooser1.Text = null;
            }
        }
    }
    protected void WebImageButton1_Click(object sender, EventArgs e)
    {
        if (Agrega_evento())
            Cuentaintervenciones();
            Get_Resultado_Busqueda();
            int k;
            for (k=0; k < grd003.Rows.Count; k++)
            {
                if (grd003.Rows[k].Cells[5].Text != "" && grd003.Rows[k].Cells[5].Text == idenEvento.Value)
                {
                    grd003.Rows[k].BackColor = System.Drawing.Color.LightBlue;
                    rowSelected.Value = Convert.ToString(k+1);
                }
            }
            Panel2.Visible = false;
            WebImageButton2.Visible = true;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "1", "window.parent.mostrarNotificacionVerde();", true);
     }
    protected void WebImageButton2_Click1(object sender, EventArgs e) // agregar
    {
        int grupo = 0;
        int plan = 0;
        try
        {
            grupo = codgrupo;
        }
        catch { }
        try
        {
            plan = codplaninterv;
        }
        catch { };
        getTrabajadores();
        get_areaintervencion(grupo, plan);
        WebImageButton2.Visible = false;
        pnl002.Visible = true;
        Panel2.Visible = true;
    }
    private void Cuentaintervenciones()
    {
        Intervencionescoll intcoll = new Intervencionescoll();

        if ((WebDateChooser1.Text.ToUpper() == "SELECCIONE FECHA") || (WebDateChooser1.Text.Trim() == ""))
        {
            lbl004b.Text = "Debe Ingresar una Fecha";
            lbl004b.Visible = true;
        }
        else
        {
            DateTime fecha = Convert.ToDateTime(WebDateChooser1.Text);
            string ano = Convert.ToDateTime(fecha).Year.ToString();// fecha.Year.ToString();
            string mes = Convert.ToDateTime(fecha).Month.ToString();  //DateTime.Now.Month.ToString();

            if (mes.Length <= 1)
            {
                mes = 0 + mes;
            }
            int Periodo = Convert.ToInt32(ano + mes);
            if (tipoPlan == "I")
            {
                intcoll.callto_cierre_cuentaintervenciones_porperiodo(icodie, Periodo);
            }
            else
            {
                char[] splitter = { ',' };
                string[] ie = icodie_2.Split(splitter);
                for (int i = 0; i < ie.Length; i++)
                {
                    if (ie[i].Trim() != "")
                    {
                        intcoll.callto_cierre_cuentaintervenciones_porperiodo(Convert.ToInt32(ie[i].Trim()), Periodo);
                    }
                }
            }
            lbl004b.Visible = false;
        }
        funcion_limpiar();
    
    }
    //protected void WebImageButton2_Click(object sender, Infragistics.WebUI.WebDataInput.EventArgs e)
    //{
    //    Panel2.Visible = true;
    //    if (tipoPlan == "G")
    //    {
    //        get_areaintervencion(codgrupo, 0);
    //    }
    //    else if (tipoPlan == "I")
    //    {
    //        get_areaintervencion(0, codplaninterv);
    //    }
    //    getTrabajadores();


    //}
    protected void WebDateChooser1_TextChanged(object sender, EventArgs e)
    {
        if (ConfigurationSettings.AppSettings["Cierre_mes"].ToString() == "1")
        {
            DateTime fecha = Convert.ToDateTime(WebDateChooser1.Text);
            string ano = Convert.ToDateTime(fecha).Year.ToString();// fecha.Year.ToString();
            string mes = Convert.ToDateTime(fecha).Month.ToString();  //DateTime.Now.Month.ToString();

            if (mes.Length <= 1)
            {
                mes = 0 + mes;
            }

            diagnosticoscoll dcoll = new diagnosticoscoll();

            int Periodo = Convert.ToInt32(ano + mes);
            int Estado_cierre = dcoll.callto_consulta_cierremes(codProyecto, Periodo);

            if (Estado_cierre != 1)
            {
                WebImageButton1.Visible = true;
                lbl004b.Visible = false;
            }
            else
            {
                lbl004b.Text = "EL MES ESTA CERRADO";
                lbl004b.Visible = true;
                WebImageButton1.Visible = false;
                WebDateChooser1.Text = null;
            }
        }
    }
}
