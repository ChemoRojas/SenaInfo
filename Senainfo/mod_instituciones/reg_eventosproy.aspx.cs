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
using System.Data.SqlClient;

using System.Collections.Generic;


public partial class mod_institucion_reg_eventosproy : System.Web.UI.Page
{
    public int vCodPaso
    {
        get { return (int)Session["vCodPaso"]; }
        set { Session["vCodPaso"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        
      alerts.Attributes.Add("style", "display:none");
      lbl005.Attributes.Add("style", "display:none");
      alerts2.Attributes.Add("style", "display:none");
      lbl0052.Attributes.Add("style", "display:none");

      if (!IsPostBack)
      {
          
          //A3.HRef = "bsc_institucion.aspx?param001=Registro de Eventos-Proyecto&dir=reg_eventosproy.aspx&codproy=" + ddown002.SelectedValue;

          txt003.Attributes.Add("onchange", "funcionsuma();");
          //txt003.Attributes.Add("OnKeyPress", "return AcceptNum(event)");       ESTO NO FUNCIONA EN EL EXPLORER 8
          txt003.Attributes.Add("OnKeyPress", "f_SoloNumeros()");
          txt004.Attributes.Add("onchange", "funcionsuma();");
          //txt004.Attributes.Add("OnKeyPress", "return AcceptNum(event)");
          txt004.Attributes.Add("OnKeyPress", "f_SoloNumeros()");
          txt005.Attributes.Add("onchange", "funcionsuma();");
          //txt005.Attributes.Add("OnKeyPress", "return AcceptNum(event)");
          txt005.Attributes.Add("OnKeyPress", "f_SoloNumeros()");
          txt006.Attributes.Add("onchange", "funcionsuma();");
          //txt006.Attributes.Add("OnKeyPress", "return AcceptNum(event)");
          txt006.Attributes.Add("OnKeyPress", "f_SoloNumeros()");
          //txt003.Text = "0";
          //txt004.Text = "0";
          //txt005.Text = "0";
          //txt006.Text = "0";




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
              if (Session["NNA"] != null && Request.QueryString["sw"] == null)
              {
                  oNNA NNA = (oNNA)Session["NNA"];

                  //txt003.Text = NNA.NNAApePaterno;
                  //txt005.Text = NNA.NNANombres;
                  //txt004.Text = NNA.NNAApeMaterno;
                  ddown001.SelectedValue = NNA.NNACodInstitucion;
                  getproyecto();
                  ddown002.SelectedValue = NNA.NNACodProyecto;

              }
              else
              {
                  oNNA NNA = new oNNA("", "", 0, 0, "", "", "", "", "", "");
                  Session["NNA"] = NNA;
              }
              //                gettipoevento(" Where T1.IndVigencia = 'V'");
              ninocoll ncoll = new ninocoll();
              int CodModeloIntervencion = 0;
              if (Convert.ToInt32(Convert.ToInt32(Request.QueryString["codinst"])) == 0)
              {
                  gettipoevento(" Where T1.IndVigencia = 'V'", null);
              }
              else
              {
                  CodModeloIntervencion = (int)ncoll.callto_get_codmodelointervencion(Convert.ToInt32(Request.QueryString["codinst"]));
                  gettipoevento(" Where T1.IndVigencia = 'V' and T2.CodModeloIntervencion =" + CodModeloIntervencion.ToString(), null);
              }
              getregion();
              getcomuna();

              if (Request.QueryString["sw"] != null)
              {
                  Get_Resultado_Busqueda(vCodPaso);
              }
              else
              {
                  vCodPaso = -1;
              }
              if (Request.QueryString["sw"] == "3")
              {

                  ddown001.SelectedValue = Request.QueryString["codinst"];
                  getproyecto();
              }
              if (Request.QueryString["sw"] == "4")
              {
                  buscador_institucion bsc = new buscador_institucion();
                  int codinst = bsc.GetCodInstxCodProy(Convert.ToInt32(Request.QueryString["codinst"]));
                  ddown001.SelectedValue = Convert.ToString(codinst);
                  getproyecto();
                  ddown002.SelectedValue = Request.QueryString["codinst"];
                  //CodModeloIntervencion = (int)ncoll.callto_get_codmodelointervencion(Convert.ToInt32(ddown002.SelectedValue));
                  gettipoevento(" Where T1.IndVigencia = 'V' and T2.CodModeloIntervencion =" + CodModeloIntervencion.ToString(), null);
                  oNNA NNA = (oNNA)Session["NNA"];
                  NNA.NNACodInstitucion = ddown001.SelectedValue;
                  NNA.NNACodProyecto = ddown002.SelectedValue;
                  Session["NNA"] = NNA;
              }

              validatescurity(); //LO ULTIMO DEL LOAD
          }

      }
      else
      {
          //grdAsistencia.DataSource = null;
          //grdAsistencia.DataBind();
          //if (grdAsistencia.Rows.Count == 0)  
          //if (WebDateChooser1.Text != "")
          //    ListadoAsistencia(Convert.ToInt32(ddown002.SelectedValue));

          //ListadoAsistencia(Convert.ToInt32(Request.QueryString["codinst"]));
      } 
    }
    private void validatescurity()
    {
        //04640223-98C3-4874-9847-A5E5AA5263F0 1.8_INGRESAR
        if (!window.existetoken("04640223-98C3-4874-9847-A5E5AA5263F0"))
        {
            imb001.Visible = false;
            
        }
        //075CEDBA-76F3-44E1-9C3E-A0F93CC86C57 1.1_MODIFICAR
        if (!window.existetoken("075CEDBA-76F3-44E1-9C3E-A0F93CC86C57"))
        {
            WebImageButton4.Visible = false;
        }

    }

    private void getinstituciones()
    {

        institucioncoll ncoll = new institucioncoll();
        DataView dv1 = new DataView(ncoll.GetData(Convert.ToInt32(Session["IdUsuario"])));
        ddown001.DataSource = dv1;
        ddown001.DataTextField = "Nombre";
        ddown001.DataValueField = "CodInstitucion";
        dv1.Sort = "Nombre";
        DataBind();


    } 
    private void getproyecto()
    {

        proyectocoll pcoll = new proyectocoll();

        DataTable dtproy = pcoll.GetData(Convert.ToInt32(Session["IdUsuario"]),"V",Convert.ToInt32(ddown001.SelectedValue));
        ddown002.DataSource = dtproy;
        ddown002.DataTextField = "Nombre";
        ddown002.DataValueField = "CodProyecto";
        ddown002.DataBind();
        if (ddown002.SelectedValue != "0")
        {
            ninocoll ncoll = new ninocoll();
            int CodModeloIntervencion = (int)ncoll.callto_get_codmodelointervencion(Convert.ToInt32(ddown002.SelectedValue)); 
            gettipoevento(" Where T1.IndVigencia = 'V' and T2.CodModeloIntervencion =" + CodModeloIntervencion.ToString(), null);
            oculto.Visible = true;
            NombreTaller.SelectedValue = "";
            rbl_registrarTaller.SelectedValue = "2";
        }
        //ddown002.SelectedValue = "0";
    }
    private void gettipoevento(string filtro, List<DbParameter> listDbParameter)
    {
        parcoll par = new parcoll();
        DataView dv6 = new DataView(par.GetparTipoEvento(filtro, listDbParameter));
        ddown003.DataSource = dv6;
        ddown003.DataTextField = "Descripcion";
        ddown003.DataValueField = "TipoEventos";
        dv6.Sort = "TipoEventos";
        ddown003.DataBind();
    }
    private void getregion()
    {


        parcoll par = new parcoll();
        DataView dv6 = new DataView(par.GetparRegion());
        ddown004.DataSource = dv6;
        ddown004.DataTextField = "Descripcion";
        ddown004.DataValueField = "CodRegion";
        dv6.Sort = "CodRegion";
        ddown004.DataBind();


    }
    private void getcomuna()
    {
         if (Convert.ToInt32(ddown004.SelectedValue) > 0)
        {

            parcoll par = new parcoll();
            DataView dv6 = new DataView(par.GetparComunas(ddown004.SelectedValue));
            ddown005.Items.Clear();
            ddown005.DataSource = dv6;
            ddown005.DataTextField = "Descripcion";
            ddown005.DataValueField = "CodComuna";
            dv6.Sort = "Descripcion";
            ddown005.DataBind();


        }
        else
        {
            ddown005.Items.Clear();
        }

    }


    
   
    protected void ddown001_SelectedIndexChanged(object sender, EventArgs e)
    {
        getproyecto();
    }
 
    private void funcion_guardar()
    {
        int ICodEventosProyectos = 0;
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        insert_instproy inup = new insert_instproy();
        if (ddown001.SelectedValue == "0" || ddown002.SelectedValue == "0" || ddown003.SelectedValue == "0" ||
           WebDateChooser1.Text == "" || ddown004.SelectedValue == "-2" || ddown005.SelectedValue == "0" ||
            txt003.Text.Trim() == "" || txt004.Text.Trim() == "" || txt005.Text.Trim() == "" || txt006.Text.Trim() == "") 
        {
            if (ddown001.SelectedValue == "0")
            { ddown001.BackColor = colorCampoObligatorio; }
            else { ddown001.BackColor = System.Drawing.Color.White; }
            if (ddown002.SelectedValue == "0")
            { ddown002.BackColor = colorCampoObligatorio; }
            else { ddown002.BackColor = System.Drawing.Color.White; }
            if (ddown003.SelectedValue == "0")
            { ddown003.BackColor = colorCampoObligatorio; }
            else { ddown003.BackColor = System.Drawing.Color.White; }
            if (ddown004.SelectedValue == "-2")
            { ddown004.BackColor = colorCampoObligatorio; }
            else { ddown004.BackColor = System.Drawing.Color.White; }
            if (ddown005.SelectedValue == "0")
            { ddown005.BackColor = colorCampoObligatorio; }
            else { ddown005.BackColor = System.Drawing.Color.White; }
            //if (ddown005.SelectedValue == "")
            //{ ddown005.BackColor = colorCampoObligatorio; }
            //else { ddown005.BackColor = System.Drawing.Color.White; }
            if (WebDateChooser1.Text == "")
            { WebDateChooser1.BackColor = colorCampoObligatorio; }
            else { WebDateChooser1.BackColor = System.Drawing.Color.White; }
            if (txt003.Text.Trim() == "")
            { txt003.BackColor = colorCampoObligatorio; }
            else { txt003.BackColor = System.Drawing.Color.White; }
            if (txt004.Text.Trim() == "")
            { txt004.BackColor = colorCampoObligatorio; }
            else { txt004.BackColor = System.Drawing.Color.White; }
            if (txt005.Text.Trim() == "")
            { txt005.BackColor = colorCampoObligatorio; }
            else { txt005.BackColor = System.Drawing.Color.White; }
            if (txt006.Text.Trim() == "")
            { txt006.BackColor = colorCampoObligatorio; }
            else { txt006.BackColor = System.Drawing.Color.White; }
        }
        else
        {
            if (cierre_mes() == 0)
            {

                string descripcion = "";
                if (txt001.Text != "")
                {
                    descripcion = txt001.Text.ToUpper();
                }

                int cantasistentes = 0;
                if (txt002.Text.ToString().Trim() != "" && txt003.Text.Trim() == "0" &&
                    txt004.Text.Trim() == "0" && txt005.Text.Trim() == "0" && txt006.Text.Trim() == "0")
                {
                    cantasistentes = Convert.ToInt32(txt002.Text);
                }
                else
                {
                    cantasistentes = Convert.ToInt32(txt003.Text) + Convert.ToInt32(txt004.Text) + Convert.ToInt32(txt005.Text) + Convert.ToInt32(txt006.Text);
                    txt002.Text = cantasistentes.ToString();
                }

                //int ICodEventosProyectos = 0;

                 ICodEventosProyectos = inup.Insert_Update_EventosProyecto(vCodPaso, Convert.ToInt32(ddown002.SelectedValue),
                 Convert.ToInt32(ddown003.SelectedValue), Convert.ToDateTime(WebDateChooser1.Text), Convert.ToInt32(Session["IdUsuario"])/*usr*/, Convert.ToInt32(ddown005.SelectedValue),
                 descripcion, cantasistentes, "V", Convert.ToInt32(txt003.Text), Convert.ToInt32(txt004.Text), Convert.ToInt32(txt005.Text),
                 Convert.ToInt32(txt006.Text));

                alerts2.Attributes.Add("style", "");
                lbl0052.Text = "Evento del Proyecto guardado con exito.";
                lbl0052.Attributes.Add("style", "");  

                WebImageButton4.Visible = false;
                imb001.Visible = true;

                txt001.Text = ""; txt002.Text = ""; txt003.Text = ""; txt004.Text = ""; txt005.Text = ""; txt006.Text = "";
                ddown003.SelectedIndex = 0; ddown004.SelectedIndex = 0; ddown005.SelectedIndex = 0;

                validatescurity();

                ddown001.BackColor = System.Drawing.Color.White;
                ddown002.BackColor = System.Drawing.Color.White;
                ddown003.BackColor = System.Drawing.Color.White;
                ddown004.BackColor = System.Drawing.Color.White;
                ddown005.BackColor = System.Drawing.Color.White;
                WebDateChooser1.BackColor = System.Drawing.Color.White;
                txt003.BackColor = System.Drawing.Color.White;
                txt004.BackColor = System.Drawing.Color.White;
                txt005.BackColor = System.Drawing.Color.White;
                txt006.BackColor = System.Drawing.Color.White;
                //lbl001.Visible = false;
                ninocoll ncoll = new ninocoll();
                int CodModeloIntervencion = (int)ncoll.callto_get_codmodelointervencion(Convert.ToInt32(ddown002.SelectedValue));

                if (CodModeloIntervencion == 107 || CodModeloIntervencion == 104 || CodModeloIntervencion == 17 || CodModeloIntervencion == 100 || CodModeloIntervencion == 101 || CodModeloIntervencion == 77 || CodModeloIntervencion == 99 || CodModeloIntervencion == 132)       // PPC - PROGRAMA PREVENCION COMUNITARIA y CRC  CENTRO DE INTERNACION EN REGIMEN CERRADO y CTD - CENTRO DE TRÁNSITO Y DISTRIBUCIÓN CON RESIDENCIA
                {
                    //if (vCodPaso==Convert.ToInt32(ddown002.Text)) ICodEventosProyectos = 0; else ICodEventosProyectos = vCodPaso;
                    if (ICodEventosProyectos == 0 && vCodPaso != Convert.ToInt32(ddown002.Text) && vCodPaso != -1) ICodEventosProyectos = vCodPaso;
                    inup.Insert_Update_EventosProyectoAsistencia_PPC(grdAsistencia, ICodEventosProyectos);
                    grdAsistencia.Visible = false;
                    grdAsistencia.DataSource = null;
                    btnMarcarTodo.Visible = false;
                    btnDesmarcarTodo.Visible = false;
                    btn_Excel.Visible = false;
                    lblCantidadVigentes.Visible = false;
                    grdAsistencia.DataSource = "";
////////////////////////

                    int AnoMes = Convert.ToInt32(WebDateChooser1.Text.Substring(6, 4) + WebDateChooser1.Text.Substring(3, 2));

                    DbDataReader datareader = null;
                    /* Database db = new Database(objconn); */
                    Conexiones con = new Conexiones();
                    DbParameter[] parametros = {
		            con.parametros("@CodProyecto", SqlDbType.Int, 4, Convert.ToInt32(ddown002.SelectedValue)) , 
		            con.parametros("@MesAno", SqlDbType.Int, 4, AnoMes) , 
		            con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, Convert.ToInt32(Session["IdUsuario"]))  
                    };

                    con.ejecutarProcedimiento("cierre_regenerar", parametros, out datareader);
                    con.Desconectar();
                    alerts2.Attributes.Add("style", "");
                    lbl0052.Text = "Registro de Eventos del Proyecto guardado con exito.";
                    lbl0052.Attributes.Add("style", "");  
///////////////////////
                }
                WebDateChooser1.Text = null;
            }
            else
            {
              alerts.Attributes.Add("style", "");
              lbl005.Text = "No puede registrar evento en mes cerrado.";
              lbl005.Attributes.Add("style", ""); 
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "No se puede", "window.alert('No puede registrar evento en mes cerrado')", true);
                //lbl001.Visible = true;
            }
         
        }
        if (NombreTaller.Text != "")
        {
            //insertar
            int icodproyecto = ICodEventosProyectos;
            string taller = NombreTaller.SelectedItem.Text;

            SqlCommand cmd = new SqlCommand();
            Conexiones con = new Conexiones();
            SqlConnection conex = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
            con.Autenticar();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertUpdate_EventosProyectoTaller";
            cmd.Parameters.Add("ICodEventosProyecto", SqlDbType.Int).Value = icodproyecto;
            cmd.Parameters.Add("Taller", SqlDbType.VarChar).Value = taller;
            
            cmd.Connection = conex;

            try
            {
                conex.Open();
                SqlDataReader Retornodata = cmd.ExecuteReader();
                cmd.Connection.Close();
                Retornodata.Close();
                
            }
            catch (Exception ex)
             {
                
            }
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
                    ((TextBox)this.Controls[j].Controls[i]).Text = "";
                }
                catch { }

                try
                {
                    ((TextBox)this.Controls[j].Controls[i]).Text = "";
                }
                catch { }


            }

        }
        getproyecto();
        getcomuna();
        WebImageButton4.Visible = false;
        imb001.Visible = true;
        grdAsistencia.Visible = false;
        grdAsistencia.DataSource = null;
        btnMarcarTodo.Visible = false;
        btnDesmarcarTodo.Visible = false;
        btn_Excel.Visible = false;
        lblCantidadVigentes.Visible = false;
        grdAsistencia.DataSource = "";
        WebDateChooser1.Text = null;
        txt001.Text = "";
        txt003.Text = "";
        txt004.Text = "";
        txt005.Text = "";
        txt006.Text = "";
        txt002.Text = "";
        ddown004.SelectedIndex = 0;
        alerts.Attributes.Add("style", "display:none");
        lbl005.Attributes.Add("style", "display:none");
        alerts2.Attributes.Add("style", "display:none");
        lbl0052.Attributes.Add("style", "display:none");
    }
    public void Get_Resultado_Busqueda(int codEventoProyecto)
    {
        string sParametrosConsulta = "Select T1.ICodEventosProyectos, T1.CodProyecto, T1.TipoEventos, T1.FechaEvento,"+
                                     "T1.IdUsuarioActualizacion, T1.CodComuna, T1.Descripcion, T1.CantidadAsistentes,T2.CodInstitucion, " + 
                                     "T1.IndVigencia, T1.FechaActualizacion,T1.CantAsistNinosAdolecentesFemenino, "+
	                                 "T1.CantAsistNinosAdolecentesMasculino,T1.CantAsistAdultoFemenino,T1.CantAsistAdultoMasculino From EventosProyecto T1 Inner Join Proyectos T2 "+
                                     "ON T1.CodProyecto = T2.CodProyecto Where T1.IndVigencia = 'V' and T1.ICodEventosProyectos="+codEventoProyecto;

        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */
        Conexiones con = new Conexiones();
        con.ejecutar(sParametrosConsulta, out datareader);

        while (datareader.Read())
        {
            try
            {
                WebImageButton4.Visible = true;
                imb001.Visible = false;
                ddown001.SelectedValue = Convert.ToString((int)datareader["CodInstitucion"]);
                getproyecto();
                ddown002.SelectedValue = Convert.ToString((int)datareader["CodProyecto"]);
                gettipoevento("", null);
                ddown003.SelectedValue = Convert.ToString((int)datareader["TipoEventos"]);
                WebDateChooser1.Text = Convert.ToString(((DateTime)datareader["FechaEvento"]).ToShortDateString());

                parcoll par = new parcoll();
                int codRegion = par.Getregionxcomuna((int)datareader["CodComuna"]);
                ddown004.SelectedValue = Convert.ToString(codRegion);
                getcomuna();
                ddown005.SelectedValue = Convert.ToString((int)datareader["CodComuna"]);

                txt001.Text = Convert.ToString((String)datareader["Descripcion"]);
                txt002.Text = Convert.ToString((int)datareader["CantidadAsistentes"]);
                txt003.Text = Convert.ToString((int)datareader["CantAsistNinosAdolecentesFemenino"]);
	            txt004.Text = Convert.ToString((int)datareader["CantAsistNinosAdolecentesMasculino"]);
	            txt005.Text = Convert.ToString((int)datareader["CantAsistAdultoFemenino"]);
                txt006.Text = Convert.ToString((int)datareader["CantAsistAdultoMasculino"]);
            }
            catch { }
        }
        con.Desconectar();

        try
        {
            if (cierre_mes() > 0)
            {
                imb001.Visible = false;
                WebImageButton4.Visible = false;
            }
        }
        catch { }

        ListadoAsistencia(Convert.ToInt32(ddown002.SelectedValue));
    }
    private void ListadoAsistencia(int CodProyecto)
    {
        ninocoll ncoll = new ninocoll();
        // = ;
        int CodModeloIntervencion = 0;

        if (CodProyecto != 0)
            CodModeloIntervencion = (int)ncoll.callto_get_codmodelointervencion(CodProyecto);
        else
            return;

        if (WebDateChooser1.Text == null) //|| (CodModeloIntervencion != 107 && CodModeloIntervencion != 104))       // PPC - PROGRAMA PREVENCION COMUNITARIA
            return;

        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();

        if (CodModeloIntervencion == 107 || CodModeloIntervencion == 104 || CodModeloIntervencion == 17 || CodModeloIntervencion == 100 || CodModeloIntervencion == 101 || CodModeloIntervencion == 77 || CodModeloIntervencion == 99 || CodModeloIntervencion == 132)
        {
            sqlc.Connection = sconn;
            sqlc.CommandType = System.Data.CommandType.StoredProcedure;
            sqlc.CommandText = "GetNinosEventoProyecto_PPC";
            sqlc.Parameters.Add("@ICodEventosProyectos", SqlDbType.Int, 4).Value = vCodPaso;
            sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = CodProyecto;
            sqlc.Parameters.Add("@FechaVigencia", SqlDbType.DateTime, 16).Value = WebDateChooser1.Text;
            sqlc.Parameters.Add("@MesCerrado", SqlDbType.Int, 4).Value = cierre_mes();

            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
            DataTable dt = new DataTable();
            sconn.Open();
            da.Fill(dt);
            sconn.Close();

            if (dt.Rows.Count > 0)
            {
                CheckBox chkPresente = new CheckBox();
                grdAsistencia.DataSource = dt;
                grdAsistencia.DataBind();

                for (int i = 0; i < grdAsistencia.Rows.Count; i++)
                {
                    chkPresente = (CheckBox)grdAsistencia.Rows[i].Cells[5].FindControl("chkPresente");
                    if (Convert.ToInt32(dt.Rows[i][8]) == 1)
                        chkPresente.Checked = true;
                }
                btnMarcarTodo.Visible = true;
                btnDesmarcarTodo.Visible = true;
                btn_Excel.Visible = true;
                lblCantidadVigentes.Visible = true;
                lblCantidadVigentes.Text = dt.Rows.Count.ToString() + " Niños vigentes al " + WebDateChooser1.Text;
                grdAsistencia.Visible = true;
            }
            else
            {
                return;
            }
        }
    }

    private int cierre_mes()
    {
        diagnosticoscoll dgcol = new diagnosticoscoll();
        string mes = "";
        int anomes, cta;
        if (Convert.ToDateTime(WebDateChooser1.Text).Month.ToString().Length == 1)
        {
            try
            {
                mes = "0" + Convert.ToDateTime(WebDateChooser1.Text).Month.ToString();
            }
            catch
            {

            }
        }
        else
        {
            try
            {
                mes = Convert.ToDateTime(WebDateChooser1.Text).Month.ToString();
            }
            catch
            {

            }
        }
        anomes = Convert.ToInt32(Convert.ToDateTime(WebDateChooser1.Text).Year.ToString() + mes);
        cta = dgcol.callto_consulta_cierremes(Convert.ToInt32(ddown002.SelectedValue), anomes);

        return cta;
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Plan de Intervencion";
        string cadena = string.Empty;

        cadena = @" window.open(this.Page, 'bsc_institucion.aspx?param001=" + etiqueta + "&dir=reg_eventosproy.aspx', 'Buscador', false, true, '770', '420', false, false, true)";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);
    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Busca Proyectos";
        string cadena = string.Empty;

        cadena = @"window.open(this.Page, 'bsc_institucion.aspx?param001=" + etiqueta + "&dir=reg_eventosproy.aspx', 'Buscador', false, true, '770', '420', false, false, true)";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);
    }

    protected void ddown004_SelectedIndexChanged(object sender, EventArgs e)
    {
        getcomuna();
    }



    protected void ddown002_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddown002.SelectedValue != "0")
        {
            ninocoll ncoll = new ninocoll();
            int CodModeloIntervencion = (int)ncoll.callto_get_codmodelointervencion(Convert.ToInt32(ddown002.SelectedValue));
            grdAsistencia.Visible = (CodModeloIntervencion == 107 || CodModeloIntervencion == 104 || CodModeloIntervencion == 17 || CodModeloIntervencion == 100 || CodModeloIntervencion == 101 || CodModeloIntervencion == 77 || CodModeloIntervencion == 99 || CodModeloIntervencion == 132);  // PPC, CRC, CTD, CIP, CSC, PLA, PLE, FPA
            btnMarcarTodo.Visible = (CodModeloIntervencion == 107 || CodModeloIntervencion == 104 || CodModeloIntervencion == 17 || CodModeloIntervencion == 100 || CodModeloIntervencion == 101 || CodModeloIntervencion == 77 || CodModeloIntervencion == 99 || CodModeloIntervencion == 132);  // PPC, CRC, CTD, CIP, CSC, PLA, PLE, FPA
            btnDesmarcarTodo.Visible = (CodModeloIntervencion == 107 || CodModeloIntervencion == 104 || CodModeloIntervencion == 17 || CodModeloIntervencion == 100 || CodModeloIntervencion == 101 || CodModeloIntervencion == 77 || CodModeloIntervencion == 99 || CodModeloIntervencion == 132);  //PPC, CRC, CTD, CIP, CSC, PLA, PLE, FPA
            btn_Excel.Visible = (CodModeloIntervencion == 107 || CodModeloIntervencion == 104 || CodModeloIntervencion == 17 || CodModeloIntervencion == 100 || CodModeloIntervencion == 101 || CodModeloIntervencion == 77 || CodModeloIntervencion == 99 || CodModeloIntervencion == 132);  // PPC, CRC, CTD, CIP, CSC, PLA, PLE, FPA
            lblCantidadVigentes.Visible = (CodModeloIntervencion == 107 || CodModeloIntervencion == 104 || CodModeloIntervencion == 17 || CodModeloIntervencion == 100 || CodModeloIntervencion == 101 || CodModeloIntervencion == 77 || CodModeloIntervencion == 99 || CodModeloIntervencion == 132);  // PPC, CRC, CTD, CIP, CSC, PLA, PLE, FPA
            gettipoevento(" Where T1.IndVigencia = 'V' and T2.CodModeloIntervencion =" + CodModeloIntervencion.ToString(), null);

            if (WebDateChooser1.Text != "")
                WebDateChooser1_TextChanged(sender, e);

            //A3.HRef = "bsc_institucion.aspx?param001=Registro de Eventos-Proyecto&dir=reg_eventosproy.aspx&codproy=" + ddown002.SelectedValue;
        }
        oNNA NNA = (oNNA)Session["NNA"];
        NNA.NNACodInstitucion = ddown001.SelectedValue;
        NNA.NNACodProyecto = ddown002.SelectedValue;
        Session["NNA"] = NNA;
        if (grdAsistencia.Rows.Count == 0)
        {
            lblCantidadVigentes.Visible = false;
            btnMarcarTodo.Visible = false;
            btnDesmarcarTodo.Visible = false;
            btn_Excel.Visible = false;  
        }
        oculto.Visible = true;
        rbl_registrarTaller.SelectedValue = "2";
        tdNombreTaller.Visible = false;
        NombreTaller.Items.Clear();
    }
    protected void btn_Excel_Click(object sender, EventArgs e)
    {
        //ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(btn_Excel);
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=Eventos_Proyecto " + WebDateChooser1.Text.ToString().Substring(0, 10) + ".xls");
        Response.Charset = "";
        this.EnableViewState = false;

        System.IO.StringWriter tw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

        DataTable dt = new DataTable();
        dt.Columns.Add("Institucion");
        dt.Columns.Add("Proyecto");
        dt.Columns.Add("TipoEvento");
        dt.Columns.Add("FechaEvento");
        dt.Columns.Add("Region");
        dt.Columns.Add("Comuna");
        dt.Columns.Add("ICodIE");
        dt.Columns.Add("ApellidoPaterno");
        dt.Columns.Add("ApellidoMaterno");
        dt.Columns.Add("Nombres");
        dt.Columns.Add("Presente");

        DataRow dr;

        for (int i = 0; i < grdAsistencia.Rows.Count; i++)
        {
            dr = dt.NewRow();
            dr[0] = ddown001.SelectedItem.Text;
            dr[1] = ddown002.SelectedItem.Text;
            dr[2] = ddown003.SelectedItem.Text;
            dr[3] = WebDateChooser1.Text.ToString().Substring(0, 10);
            dr[4] = ddown004.SelectedItem.Text;
            dr[5] = ddown005.SelectedItem.Text;

            for (int j = 1; j < grdAsistencia.Columns.Count -2 ; j++)
            {
                if (j < 5)
                    dr[j + 5] = grdAsistencia.Rows[i].Cells[j].Text;
                else
                {
                    CheckBox chkPresente = (CheckBox)grdAsistencia.Rows[i].Cells[j].FindControl("chkPresente");
                    if (chkPresente.Checked)
                        dr[j + 5] = "SI";
                    else
                        dr[j + 5] = "NO";
                }
            }
            dt.Rows.Add(dr);
        }
        DataView dv = new DataView(dt);
        DataGrid d1 = new DataGrid();
        d1.DataSource = dv;
        d1.DataBind();
        d1.RenderControl(hw);
        Response.Write(tw.ToString());
        Response.End();
        //HttpResponse response = HttpContext.Current.Response;

        //string filename = 

        //response.Clear();
        //response.Charset = "";

        //response.ContentType = "application/vnd.ms-excel";
        //response.AddHeader("Content-Disposition", "attachment;filename=\"" + filename + "\"");


        //Response.Buffer = true;
        //this.EnableViewState = false;


        //// create a string writer
        //using (System.IO.StringWriter sw = new System.IO.StringWriter())
        //{
        //    using (HtmlTextWriter htw = new HtmlTextWriter(sw))
        //    {
        
        //        d1.RenderControl(htw);
        //        response.Write(sw.ToString());
        //        response.End();
        //    }
        //}
    }


    public override void VerifyRenderingInServerForm(Control control)
    {}

    protected void WebImageButton1_Click(object sender, EventArgs e)
    {
        string cadena = string.Empty;
        cadena = @"window.open(this.Page, 'bsc_institucion.aspx?param001=Registro de Eventos-Proyecto&codproy=" + ddown002.SelectedValue + "', 'Buscador', false, false, '770', '420', false, false, true)";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);
    }
    protected void btnMarcarTodo_Click(object sender, EventArgs e)
    {
        CheckBox chkPresente = new CheckBox();
        for (int i = 0; i < grdAsistencia.Rows.Count; i++)
        {
            chkPresente = (CheckBox)grdAsistencia.Rows[i].Cells[5].FindControl("chkPresente");
            chkPresente.Checked = true;

        }
    }
    protected void btnDesmarcarTodo_Click(object sender, EventArgs e)
    {
        CheckBox chkPresente = new CheckBox();
        for (int i = 0; i < grdAsistencia.Rows.Count; i++)
        {
            chkPresente = (CheckBox)grdAsistencia.Rows[i].Cells[5].FindControl("chkPresente");
            chkPresente.Checked = false;

        }
    }
    protected void WebImageButton4_Click(object sender, EventArgs e)
    {
        funcion_guardar();
    }
    protected void imb001_Click(object sender, EventArgs e)
    {
        funcion_guardar();
    }
    protected void WebImageButton2_Click(object sender, EventArgs e)
    {
        funcion_limpiar();
    }
    protected void WebImageButton3_Click(object sender, EventArgs e)
    {
        Response.Redirect("index_instituciones.aspx");
    }
    protected void WebDateChooser1_TextChanged(object sender, EventArgs e)
    {
        Session["FechaSeleccionada"] = WebDateChooser1.Text;
        ListadoAsistencia(Convert.ToInt32(ddown002.SelectedValue));
    }
    protected void WebImageButton1_Click1(object sender, EventArgs e)
    {
        oculto.Visible = true;
    }

    protected void rbl_registrarTaller_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbl_registrarTaller.SelectedValue == "1")
        {
            GetProyecto();
            thNombreTaller.Visible = true;
            tdNombreTaller.Visible = true;
        }
        else 
        {
            thNombreTaller.Visible = false;
            tdNombreTaller.Visible = false;
        }
    }
    protected void GetProyecto()
     {
        string proyecto = ddown002.SelectedValue;
        string consulta = "select COUNT(CodProyecto) from Taller where Codproyecto =" + proyecto;
        parcoll pa = new parcoll();
        DataTable codproyecto = pa.ejecuta_SQL(consulta);
        
       // if (codproyecto.ExtendedProperties.Count > 0)
        int contador = Convert.ToInt32(codproyecto.Rows[0][0].ToString());
        if (contador > 0)
        {
            parcoll par = new parcoll();
            string consultaTallere = "select a.CodTipoTaller , c.Descripcion, a.CodTaller from partipotaller_taller a left join partipotalleres b on  a.CodTipoTaller = b.CodTipoTaller left join parTalleres c on a.CodTaller = c.CodTaller";
            DataTable dttalleres = par.ejecuta_SQL(consultaTallere);
           // DataView dv = new DataView(par.GetNombreTalleres(codtaller));
            //NombreTaller.DataSource = dttalleres; 
            //NombreTaller.DataTextField = "Descripcion";
            //NombreTaller.DataValueField = "CodTaller";
            //NombreTaller.DataBind();

            string consulta_taller = " select codtaller,NombreTaller from taller where CodProyecto =" + proyecto + " and Estado = 'Cierre' ";
            DataTable dt = par.ejecuta_SQL(consulta_taller);
            NombreTaller.DataSource = dt;
            NombreTaller.DataTextField = "NombreTaller";
            NombreTaller.DataValueField = "CodTaller";
            NombreTaller.DataBind();

         
        }
    }
}
