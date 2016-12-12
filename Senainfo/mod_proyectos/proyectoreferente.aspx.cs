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

using Argentis.Regmen;


using System.Drawing;

public partial class Proyectos_proyectoreferente : System.Web.UI.Page
{

    public nino SSnino
    {
        get
        {
            if (Session["neo_SSnino"] == null)
            { Session["neo_SSnino"] = new nino(); }
            return (nino)Session["neo_SSnino"];
        }
        set { Session["neo_SSnino"] = value; }


    }
    public proyecto SSproyecto
    {
        get
        {
            if (Session["neo_SSproyecto"] == null)
            { Session["neo_SSproyecto"] = new proyecto(); }
            return (proyecto)Session["neo_SSproyecto"];
        }
        set { Session["neo_SSproyecto"] = value; }
    }
    public int vCodPaso
    {
        get { return (int)Session["vCodPaso"]; }
        set { Session["vCodPaso"] = value; }
    }
    public int vCodPaso2
    {
        get { return (int)Session["vCodPaso2"]; }
        set { Session["vCodPaso2"] = (value != null) ? value : 0; }
    }

    public DataTable DTinmueble
    {
        get { return (DataTable)Session["DTinmueble"]; }
        set { Session["DTinmueble"] = value; }
    }
    public DateTime inFechaCreacion
    {
        get { return (DateTime)Session["inFechaCreacion"]; }
        set { Session["inFechaCreacion"] = value; }
    }
    //public DataTable DTProyecto
    //{
    //    get { return (DataTable)Session["DTProyecto"]; }
    //    set { Session["DTProyecto"] = value; }

    //}


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
                if (!window.existetoken("3EE11321-5110-44A0-819E-443CEBC462E1"))
                {
                    Response.Redirect("~/logout.aspx");
                }

                if (getinstituciones() > 0)
                {
                    getproyectosxcod();
                }
                //jvb toma la region escogida
                if (Session["reg_selec"] != null)
                    ddown005.SelectedValue = Session["reg_selec"].ToString();

                gettipoproyecto();
                getregion();
                getcomuna();
                gettipoatencion();
                getcausalterminoproyecto();
                getinstitucionestab();
                getbancos();
                cal003.Enabled = false;


                pnlAlert.Style.Add("display", "none");
                //divAlert.Style.Add("display", "none");
                pnlCorrecto.Style.Add("display", "none");
                pnlActualizado.Style.Add("display", "none");

                inFechaCreacion = DateTime.Now;
                if (Request.QueryString["sw"] == "4")
                {
                    Get_Resultado_Busqueda(vCodPaso);
                    //btn001.Visible = false;
                }
                else
                {
                    vCodPaso2 = 15;
                }
                if (Request.QueryString["sw"] == "3")
                {
                    proyectocoll pcoll = new proyectocoll();

                    ddown001.SelectedValue = Request.QueryString["codinst"];


                }
                string codinst = ddown001.SelectedValue.ToString();
                //A2.HRef = "../mod_instituciones/bsc_institucion.aspx?param001=Proyectos&codinst=" + codinst + "&dir=proyectoreferente.aspx";
                validatescurity(); //LO ULTIMO DEL LOAD
            }
        }
        
    }
    private void validatescurity()
    {
        //200E217F-71E6-4DBB-95EE-816A86198D58 1.4_INGRESAR
        if (!window.existetoken("BF175148-E5BD-4229-A5A2-4ECDEAA52A46"))
        {
            //btn001.Visible = false;
            //btnnext.Visible = false;
            next.Visible = false;
            //limpiarTab1.Visible = false;
            //limpiarTab2.Visible = false;
            //limpiarTab3.Visible = false;
            LinkButton1.Visible = false; //Boton Next segunda pestaña
            LinkButton2.Visible = false; //Boton Next tercera pestaña
            WebImageButton4.Visible = false;
            //WebImageButton5.Visible = false;
            ddown005.Enabled = false;
            ddown001.Enabled = false;
            if (Request.QueryString["sw"] == "4")
            {
                if (Session["guardado"] == "1")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "bloqueaTabs", "bloquearTabs();", true);
                    Session["guardado"] = "0";
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "desbloqueaTabs", "desbloquearTabs();", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "bloqueainputs", "bloquearInputs();", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "habilitarInputsModif", "habilitarInputsModificar();", true);
                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "bloqueaTabs", "bloquearTabs();", true);
            }
        }
        //A757360B-5759-4070-89D0-C9696E5C2DF8 1.4_MODIFICAR
        if (!window.existetoken("12839A53-18CA-407E-821E-C109FF601C06"))
        {
            //WebImageButton5.Visible = false;
           ///btn001.Visible = true;
            lblCausalTerminoProyecto.Visible = false;
            ddown001d.Visible = false;
            infoTerminoProyecto.Visible = true;
            tblCausalTerminoProyecto.Visible = false;
            
            
        }
        //1403630F-FE9F-45C2-A9F3-68B5D3478726 1.4_MODIFICAR_UNIDINF
        if (window.existetoken("1403630F-FE9F-45C2-A9F3-68B5D3478726"))
        {
            //block();
            txt003.ReadOnly = false;
            txt006.ReadOnly = false;
            txt007.ReadOnly = false;
            txt008.ReadOnly = false;
            txt010.ReadOnly = false;
            txt011.ReadOnly = false;
            //calaniv001.ReadOnly = false;
            //calaniv002.ReadOnly = false;
            ddwlist001.Enabled = true;
            ddwlist002.Enabled = true;
            txt001a.ReadOnly = false;
            txt002a.ReadOnly = false;
            txt003a.ReadOnly = false;
            //WebImageButton5.Visible = false;
            infoTerminoProyecto.Visible = false;
            tblCausalTerminoProyecto.Visible = true;
            lblCausalTerminoProyecto.Visible = true;
            ddown001d.Visible = true;
            


        }
        //6F26BEE9-9CCC-406D-A6B8-BBCB621D45E6 1.4_MODIFICAR_ADMINST 
        if (window.existetoken("6F26BEE9-9CCC-406D-A6B8-BBCB621D45E6"))
        {
            block();
            txt003.ReadOnly = false;
            txt006.ReadOnly = false;
            txt007.ReadOnly = false;
            txt008.ReadOnly = false;
            txt010.ReadOnly = false;
            txt011.ReadOnly = false;
            //calaniv001.ReadOnly = false;
            //calaniv002.ReadOnly = false;
            //WebImageButton5.Visible = false;
            lblCausalTerminoProyecto.Visible = true;
            ddown001d.Visible = true;
            infoTerminoProyecto.Visible = false;
            tblCausalTerminoProyecto.Visible = true;
            

        }
        //4B9168D8-AB52-4C63-9072-383A844755BB 1.4_MODIFICAR_ADMPROY
        if (window.existetoken("4B9168D8-AB52-4C63-9072-383A844755BB"))
        {
            block();
            txt005.ReadOnly = false;
            txt003.ReadOnly = false;
            txt006.ReadOnly = false;
            txt007.ReadOnly = false;
            txt008.ReadOnly = false;
            txt010.ReadOnly = false;
            txt011.ReadOnly = false;
            //calaniv001.ReadOnly = false;
            //calaniv002.ReadOnly = false;
            //WebImageButton5.Visible = false;
            lblCausalTerminoProyecto.Visible = true;
            //ddown001d.Visible = true;
            infoTerminoProyecto.Visible = false;
            tblCausalTerminoProyecto.Visible = true;

            
            

        }
    }
    private void block()
    {
        for (int j = 0; j < this.utab3.Controls.Count; j++)
        {
            for (int i = 0; i < this.utab3.Controls[j].Controls.Count; i++)
            {
                try
                {
                    if (utab3.Controls[j].Controls[i] is TextBox)
                        ((TextBox)this.utab3.Controls[j].Controls[i]).ReadOnly = true;
                }
                catch { }
                try
                {
                    if (utab3.Controls[j].Controls[i] is DropDownList)
                        ((DropDownList)this.utab3.Controls[j].Controls[i]).Enabled = false;
                }
                catch { }
                try
                {
                    if (utab3.Controls[j].Controls[i] is TextBox)
                        ((TextBox)this.utab3.Controls[j].Controls[i]).ReadOnly = true;
                }
                catch { }
                try
                {
                    if (utab3.Controls[j].Controls[i] is TextBox)
                        ((TextBox)this.utab3.Controls[j].Controls[i]).ReadOnly = true;
                }
                catch { }
            }
        }
    }

    public void Get_Resultado_Busqueda(int codproyecto)
    {
        proyectocoll pcoll = new proyectocoll();
        DataTable dt;
        if (vCodPaso2 == 15)
        {
            dt = pcoll.GetProyectos(Convert.ToString(codproyecto));
            if (dt.Rows.Count > 0)
            {
                //WebImageButton5.Visible = true;
                lblCausalTerminoProyecto.Visible = true;
                ddown001d.Visible = true;
                infoTerminoProyecto.Visible = false;
                tblCausalTerminoProyecto.Visible = true;
            
                btn001.Visible = true;
                inFechaCreacion = Convert.ToDateTime(dt.Rows[0][37]);

                //btn001.Text = "Actualizar Datos del Proyecto";
                lblBtn.Text = "Actualizar Datos del Proyecto";
                txt005a.Text = "Ley 20.032";
                txt005b.Text = Convert.ToString(dt.Rows[0][43]);
                ddown001.SelectedValue = Convert.ToString(dt.Rows[0][1]);

                rdolist001.SelectedValue = Convert.ToString(dt.Rows[0][41]);


                txt014.Text = Convert.ToInt32(dt.Rows[0][0]).ToString();
                txt013.Text = Convert.ToString(dt.Rows[0][15]);
                txt003.Text = Convert.ToString(dt.Rows[0][16]);
                ddown004.SelectedValue = Convert.ToString(dt.Rows[0][5]);
                cal001.Text = Convert.ToString(dt.Rows[0][37]);
                cal001.Text = cal001.Text.Substring(0, 10);
                
                if (Convert.ToString(dt.Rows[0][28]) == "01/01/1900 0:00:00")
                {
                    cal003.Text = null;
                }
                else
                {
                    cal003.Text = Convert.ToString(dt.Rows[0][28]);
                    cal003.Text = cal003.Text.Substring(0, 10);
                }
                txt004.Text = Convert.ToString(dt.Rows[0][17]);
                txt005.Text = Convert.ToString(dt.Rows[0][18]);
                ddown005.SelectedValue = Convert.ToString(dt.Rows[0][2]);
                getcomuna();
                ddown006.SelectedValue = Convert.ToString(dt.Rows[0][3]);

                txt0015.Text = Convert.ToString(dt.Rows[0][4]);
                txt006.Text = Convert.ToString(dt.Rows[0][19]);
                txt007.Text = Convert.ToString(dt.Rows[0][20]);
                txt008.Text = Convert.ToString(dt.Rows[0][21]);
                txt010.Text = Convert.ToString(dt.Rows[0][22]);
                txt011.Text = Convert.ToString(dt.Rows[0][23]);
                if (Convert.ToString(dt.Rows[0][24]) != "0")
                {
                    //calaniv001.Text = Convert.ToString(dt.Rows[0][24]).Substring(0, 2);
                    //calaniv002.Text = Convert.ToString(dt.Rows[0][24]).Substring(2, 2);
                }
                ddown008.SelectedValue = Convert.ToString(dt.Rows[0][26]);
                txt012.Text = Convert.ToString(dt.Rows[0][27]);
                txt001a.Text = Convert.ToString(dt.Rows[0][25]);
                txt002a.Text = Convert.ToString(dt.Rows[0][29]);
                txt003a.Text = Convert.ToString(dt.Rows[0][30]);

                vCodPaso2 = Convert.ToInt32(dt.Rows[0][10]);

                ddown003a.SelectedValue = Convert.ToString(dt.Rows[0][7]);
                getmodelointervencionxproyecto();
                ddown006a.SelectedValue = Convert.ToString(dt.Rows[0][9]);
                if (ddown006a.SelectedValue != "")
                {
                    gettematica();
                    getdeptosename();
                    gettipopago();
                    getvidafamiliar();
                    if (ddown005a.Items.FindByValue(Convert.ToString(dt.Rows[0][8])) != null)
                    {
                        ddown005a.SelectedValue = Convert.ToString(dt.Rows[0][8]);
                    }
                    if (Convert.ToInt32(dt.Rows[0][10]) == 15)
                    {
                        WebImageButton4.Visible = true;
                    }
                    //  ttxt005a.Text = pcoll.GetCodSistemaAsistencialDesc(Convert.ToInt32(dt.Rows[0][10]));


                    if (ddown004a.Items.FindByValue(Convert.ToString(dt.Rows[0][11])) != null)
                    {
                        ddown004a.SelectedValue = Convert.ToString(dt.Rows[0][11]);
                    }
                    if (ddown007a.Items.FindByValue(Convert.ToString(dt.Rows[0][6])) != null)
                    {
                        ddown007a.SelectedValue = Convert.ToString(dt.Rows[0][6]);
                    }
                }

                txt001b.Text = Convert.ToString(dt.Rows[0][31]);
                txt002b.Text = Convert.ToString(dt.Rows[0][32]);
                txt003b.Text = Convert.ToString(dt.Rows[0][33]);
                txt004b.Text = Convert.ToString(dt.Rows[0][34]);
                if (Convert.ToString(dt.Rows[0][42]) == "0")
                {
                    rdo001b.Visible = true;
                    rdo002b.Checked = true;
                    rdo001b.Checked = false;

                }
                else
                {
                    rdo001b.Visible = true;
                    rdo001b.Checked = true;
                    rdo002b.Checked = false;
                }
                ddown001d.SelectedValue = Convert.ToString(dt.Rows[0][12]);


                ddwlist001.SelectedValue = Convert.ToString(dt.Rows[0][13]);
                getproyectoOrigen(codproyecto);
                ddwlist002.SelectedValue = Convert.ToString(dt.Rows[0][14]);

                ddown005.Enabled = false;
                ddown001.Enabled = false;
                txt014.ReadOnly = true;
                txt013.ReadOnly = true;
                ddown004.Enabled = false;
                cal001.Enabled = false;
                cal003.Enabled = false;

                ddown004a.Enabled = false;
                ddown006a.Enabled = false;
                ddown005a.Enabled = false;
                txt005a.ReadOnly = true;
                //ddown007a.Enabled = false;
                ddown007a.Enabled = true;
                ImageButton3.Visible = false;
            }
        }
        else
        {
            //WebImageButton5.Visible = true;

            lblCausalTerminoProyecto.Visible = true;
            ddown001d.Visible = true;
            infoTerminoProyecto.Visible = false;
            tblCausalTerminoProyecto.Visible = true;
            
            btn001.Visible = true;
            dt = pcoll.GetProyectos2(codproyecto);
            if (dt.Rows.Count > 0)
            {
                inFechaCreacion = Convert.ToDateTime(dt.Rows[0][50]);
                ddown005.SelectedValue = Convert.ToString(dt.Rows[0][5]);
                ddown001.SelectedValue = Convert.ToString(dt.Rows[0][2]);
                txt014.Text = Convert.ToString(dt.Rows[0][0]);
                txt013.Text = Convert.ToString(dt.Rows[0][1]);
                txt003.Text = Convert.ToString(dt.Rows[0][3]);
                ListItem oItem = new ListItem(Convert.ToString(dt.Rows[0][12]), Convert.ToString(dt.Rows[0][11]));
                ddown004.Items.Clear();
                ddown004.Items.Add(oItem);
                ddown004.SelectedValue = Convert.ToString(dt.Rows[0][11]);

                //tddown004.SelectedValue = Convert.ToString(dt.Rows[0][11]);
                cal001.Text = Convert.ToDateTime(dt.Rows[0][50]).ToShortDateString();

                rdolist001.SelectedValue = Convert.ToString(dt.Rows[0][54]);

                try
                {
                    if (Convert.ToDateTime(dt.Rows[0][41]) != Convert.ToDateTime("01-01-1900"))
                    {
                        cal003.Text = Convert.ToDateTime(dt.Rows[0][41]).ToShortDateString();
                    }
                }
                catch
                {
                    cal003.Text = null;
                }
                txt004.Text = Convert.ToString(dt.Rows[0][29]);
                txt005.Text = Convert.ToString(dt.Rows[0][30]);
                getcomuna();
                ddown006.SelectedValue = Convert.ToString(dt.Rows[0][7]);

                txt0015.Text = Convert.ToString(dt.Rows[0][9]);
                txt006.Text = Convert.ToString(dt.Rows[0][31]); 
                txt007.Text = Convert.ToString(dt.Rows[0][32]);
                txt008.Text = Convert.ToString(dt.Rows[0][33]);
                txt010.Text = Convert.ToString(dt.Rows[0][34]);
                txt011.Text = Convert.ToString(dt.Rows[0][35]);


                if (Convert.ToString(dt.Rows[0][36]) != "0")
                {
                    //calaniv001.Text = Convert.ToString(dt.Rows[0][36]).Substring(0, 2);
                    //calaniv002.Text = Convert.ToString(dt.Rows[0][36]).Substring(2, 2);
                }

                ddown008.SelectedValue = Convert.ToString(dt.Rows[0][38]);
                txt012.Text = Convert.ToString(dt.Rows[0][40]);
                ddwlist001.SelectedValue = Convert.ToString(dt.Rows[0][27]);
                if (ddwlist001.SelectedValue != "0")
                {
                    if (Convert.ToString(dt.Rows[0][28]) != "0")
                    {
                        getproyectoOrigen(codproyecto);
                        ddwlist002.SelectedValue = Convert.ToString(dt.Rows[0][28]);
                    }
                }
                txt001a.Text = Convert.ToString(dt.Rows[0][37]);
                txt002a.Text = Convert.ToString(dt.Rows[0][42]);
                txt003a.Text = Convert.ToString(dt.Rows[0][43]);

                oItem = new ListItem(Convert.ToString(dt.Rows[0][16]), Convert.ToString(dt.Rows[0][15]));
                ddown003a.Items.Clear();
                ddown003a.Items.Add(oItem);
                ddown003a.SelectedValue = Convert.ToString(dt.Rows[0][15]);

                oItem = new ListItem(Convert.ToString(dt.Rows[0][20]), Convert.ToString(dt.Rows[0][19]));
                ddown006a.Items.Clear();
                ddown006a.Items.Add(oItem);
                ddown006a.SelectedValue = Convert.ToString(dt.Rows[0][19]);

                //oItem = new ListItem(Convert.ToString(dt.Rows[0][20]), Convert.ToString(dt.Rows[0][17]));
                //tddown006a.Items.Clear();
                //tddown006a.Items.Add(oItem);
                //tddown006a.SelectedValue = Convert.ToString(dt.Rows[0][17]);

                oItem = new ListItem(Convert.ToString(dt.Rows[0][18]), Convert.ToString(dt.Rows[0][17]));
                ddown005a.Items.Clear();
                ddown005a.Items.Add(oItem);
                ddown005a.SelectedValue = Convert.ToString(dt.Rows[0][17]);

                txt005a.Text = Convert.ToString(dt.Rows[0][22]);

                oItem = new ListItem(Convert.ToString(dt.Rows[0][25]), Convert.ToString(dt.Rows[0][24]));
                ddown004a.Items.Clear();
                ddown004a.Items.Add(oItem);
                ddown004a.SelectedValue = Convert.ToString(dt.Rows[0][24]);

                oItem = new ListItem(Convert.ToString(dt.Rows[0][14]), Convert.ToString(dt.Rows[0][13]));
                ddown007a.Items.Clear();
                ddown007a.Items.Add(oItem);
                ddown007a.SelectedValue = Convert.ToString(dt.Rows[0][13]);

                txt001b.Text = Convert.ToString(dt.Rows[0][44]);
                txt002b.Text = Convert.ToString(dt.Rows[0][45]);
                txt003b.Text = Convert.ToString(dt.Rows[0][46]);
                txt004b.Text = Convert.ToString(dt.Rows[0][47]);
                txt005b.Text = Convert.ToString(dt.Rows[0][55]);

                if (Convert.ToString(dt.Rows[0][56]) == "0")
                {
                    rdo001b.Checked = false;
                    rdo002b.Checked = true;

                }
                else
                {
                    rdo001b.Checked = true;
                    rdo002b.Checked = false;

                }
                ddown001d.SelectedValue = Convert.ToString(dt.Rows[0][26]);

                for (int j = 0; j < this.utab3.Controls.Count; j++)
                {
                    for (int i = 0; i < this.utab3.Controls[j].Controls.Count; i++)
                    {
                        try
                        {
                            if (utab3.Controls[j].Controls[i] is TextBox)
                                ((TextBox)this.utab3.Controls[j].Controls[i]).ReadOnly = true;
                        }
                        catch { }
                        try
                        {
                            if (utab3.Controls[j].Controls[i] is DropDownList)
                                ((DropDownList)this.utab3.Controls[j].Controls[i]).Enabled = false;
                        }
                        catch { }
                        try
                        {
                            if (utab3.Controls[j].Controls[i] is TextBox)
                                ((TextBox)this.utab3.Controls[j].Controls[i]).ReadOnly = true;
                        }
                        catch { }
                    }

                }

                ddown008.Enabled = true;
                txt012.ReadOnly = false;
                ddown006.Enabled = true;
                ImageButton3.Visible = false;
            }
        }
        //for (int i = 1; i < utab3.Tabs.Count; i++)
        //{
        //    utab3.Tabs[i].Enabled = false;
        //}
        Escondertabs();
        validatescurity();
    }


    private void getvidafamiliar()
    {
        parcoll pcoll = new parcoll();
        DataTable dt = pcoll.GetparTipoSubvencionxModeloIntervencion(Convert.ToInt32(ddown006a.SelectedValue));
        if (dt.Rows.Count > 1)
        {
            string value = Convert.ToString(dt.Rows[1][3]);

            if (value == "S")
            {
                rdo001b.Visible = true;
                rdo001b.Checked = false;
                rdo002b.Checked = false;
            }
            else
            {
                rdo001b.Checked = false;
                rdo002b.Checked = true;
                rdo001b.Visible = true;
                rdo002b.Visible = true;
            }
        }
    }
    private int getinstituciones()
    {
        institucioncoll ncoll = new institucioncoll();
        DataView dv1 = new DataView(ncoll.GetData(Convert.ToInt32(Session["IdUsuario"])));
        ddwlist001.DataSource = dv1;
        ddwlist001.DataTextField = "Nombre";
        ddwlist001.DataValueField = "CodInstitucion";
        dv1.Sort = "Nombre";
        ddwlist001.DataBind();
        return dv1.Count;

    }

    private void getproyecto()
    {
        proyectocoll pcoll = new proyectocoll();

        DataTable dtproy = pcoll.GetData(Convert.ToInt32(Session["IdUsuario"]), "V", Convert.ToInt32(ddwlist001.SelectedValue));
        ddwlist002.DataSource = dtproy;
        ddwlist002.DataTextField = "Nombre";
        ddwlist002.DataValueField = "CodProyecto";
        ddwlist002.DataBind();
    }


    protected void btn001_Click(object sender, EventArgs e)
    {
        

      //pnlAlert.Visible = false;
      pnlCorrecto.Visible = false;
      validaDatos();
    }
    private void validaDatos()
    {
      // Validaciones para el primer tab (Datos del Proyecto) //
      int errTab1 = 0;
      int errTab2 = 0;
      int errTab3 = 0;
      System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

      #region validacionesTab1
      if (ddown005.SelectedValue == "0" || ddown005.SelectedValue == "-2")
      {
        ddown005.BackColor = colorCampoObligatorio;
        errTab1++;
      } else {
        ddown005.BackColor = Color.White;
      }

      if (ddown001.SelectedValue == "0")
      {
        ddown001.BackColor = colorCampoObligatorio;
        errTab1++;
      }
      else
      {
        ddown005.BackColor = Color.White;
      }

      if (txt014.Text.Trim() == "")
      {
        txt014.BackColor = colorCampoObligatorio;
        errTab1++;
      }
      else
      {
        txt014.BackColor = Color.White;
      }

      if (txt013.Text.Trim() == "")
      {
        txt013.BackColor = colorCampoObligatorio;
        errTab1++;
      }
      else
      {
        txt013.BackColor = Color.White;
      }

      if (txt003.Text.Trim() == "")
      {
        txt003.BackColor = colorCampoObligatorio;
        errTab1++;
      }
      else
      {
        txt003.BackColor = Color.White;
      }

      if (ddown004.SelectedValue == "0")
      {
        ddown004.BackColor = colorCampoObligatorio;
        errTab1++;
      }
      else
      {
        ddown004.BackColor = Color.White;
      }

      if (cal001.Text.Trim() == "")
      {
        cal001.BackColor = colorCampoObligatorio;
        errTab1++;
      }
      else
      {
        cal001.BackColor = Color.White;
      }

      if (txt005.Text.Trim() == "")
      {
        txt005.BackColor = colorCampoObligatorio;
        errTab1++;
      }
      else
      {
        txt005.BackColor = Color.White;
      }

      if (txt004.Text.Trim() == "")
      {
          txt004.BackColor = colorCampoObligatorio;
          errTab1++;
      }
      else
      {
          txt004.BackColor = Color.White;
      }

      if (cal003.Text == "")
      {
          cal003.BackColor = colorCampoObligatorio;
          errTab1++;
      }
      else
      {
          cal003.BackColor = Color.White;
      }

      if (errTab1 > 0)
      {
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "a", "$('#opt1').css('color', 'red')", true);
          //opt1.Attributes.Add("class", "pestana-roja");
          ScriptManager.RegisterStartupScript(Page, Page.GetType(), "irAlTope", "$('#html,body').animate({scrollTop:0}, '750');", true);
          ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mostrarAlert", "$('#pnlAlert').delay(1500).show();$('opt1').css('background-color', 'yellow');", true);
          ScriptManager.RegisterStartupScript(Page, Page.GetType(), "cambiarBackgroundTab", "$('#tab1 #opt1').css({'background-color': '#f5e79e','color':'#B2B2B2'});", true);
    

      }
      else
      {
          opt1.Attributes.Remove("class");
      }

      #endregion

      // Validaciones para el segundo tab (Datos Técnicos) //
      #region validacionesTab2

      if (txt001a.Text.Trim() == "")
      {
        txt001a.BackColor = colorCampoObligatorio;
        errTab2++;
      }
      else
      {
        txt001a.BackColor = Color.White;
      }

      if (txt002a.Text.Trim() == "")
      {
        txt002a.BackColor = colorCampoObligatorio;
        errTab2++;
      }
      else
      {
        txt002a.BackColor = Color.White;
      }

      if (txt003a.Text.Trim() == "")
      {
        txt003a.BackColor = colorCampoObligatorio;
        errTab2++;
      }
      else
      {
        txt003a.BackColor = Color.White;
      }

      if (ddown003a.SelectedValue == "0")
      {
        ddown003a.BackColor = colorCampoObligatorio;
        errTab2++;
      }
      else
      {
        ddown003a.BackColor = Color.White;
      }

      if (ddown006a.SelectedValue == "0")
      {
        ddown006a.BackColor = colorCampoObligatorio;
        errTab2++;
      }
      else
      {
        ddown006a.BackColor = Color.White;
      }

        if (ddown005a.SelectedValue == "0")
        {
            ddown005a.BackColor = colorCampoObligatorio;
            errTab2++;
        }
        else
        {
            ddown005a.BackColor = Color.White;
        }

      if (ddown004a.SelectedValue == "0")
      {
        ddown004a.BackColor = colorCampoObligatorio;
        errTab2++;
      }
      else
      {
        ddown004.BackColor = Color.White;
      }

      if (ddown006a.SelectedValue != "30" && ddown006a.SelectedValue != "38")
      {
          if (ddown007a.SelectedValue == "0")
          {
              ddown007a.BackColor = colorCampoObligatorio;
              errTab2++;
          }
          else
          {
              ddown007a.BackColor = Color.White;
          }
      }


      if (errTab2 > 0)
      {
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "b", "$('#opt2').css('color', 'red')", true);
        //opt2.Attributes.Add("class", "pestana-roja");
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "irAlTope", "$('#html,body').animate({scrollTop:0}, '750');", true);
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mostrarAlert", "$('#pnlAlert').delay(1500).show();$('opt2').css('background-color', 'yellow');", true);
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "cambiarBackgroundTab2", "$('#tab2 #opt2').css({'background-color': '#f5e79e','color':'#B2B2B2'});", true);

      }
      else
      {
          opt2.Attributes.Remove("class");
      }


      #endregion

      // Validaciones para el tercer tab (Montos y Factores) //
      #region validacionesTab3

      if (txt005b.Text.Trim() == "")
      {
        txt005b.BackColor = colorCampoObligatorio;
        errTab3++;
      }
      else
      {
        txt005b.BackColor = Color.White;
      }

      if (errTab3 > 0)
      {

          //ScriptManager.RegisterStartupScript(this, this.GetType(), "c", "$('#opt3').css('color', 'red')", true);
          //opt3.Attributes.Add("class", "pestana-roja");
          ScriptManager.RegisterStartupScript(Page, Page.GetType(), "irAlTope", "$('#html,body').animate({scrollTop:0}, '750');", true);
          ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mostrarAlert", "$('#pnlAlert').delay(1500).show();$('opt3').css('background-color', 'yellow');", true);
          ScriptManager.RegisterStartupScript(Page, Page.GetType(), "cambiarBackgroundTab3", "$('#tab3 #opt3').css({'background-color': '#f5e79e','color':'#B2B2B2'});", true);


      }
      else {
          opt3.Attributes.Remove("class");
      }

      #endregion

      if (errTab1 == 0 && errTab2 == 0 && errTab3 == 0)
      {
        funcion_guardar();
      }
      else
      {
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "d", "window.alert('Faltan Datos');", true);
        //pnlAlert.Visible = true;
          //pnlAlert.Style.Remove("display");
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "d", "$('#pnlAlert').fadeOut(10000, 'linear');", true);
      }

    }

    private void funcion_guardar()
    {
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        if (ddown005.SelectedValue == "-2" || ddown001.SelectedValue == "0" || txt014.Text.Trim() == "" ||
            txt013.Text.Trim() == "" || ddown004.SelectedValue == "0" || cal001.Text == "Seleccione Fecha" ||
            txt005.Text.Trim() == "" || ddown006.SelectedValue == "0" ||
            txt001a.Text.Trim() == "" || txt002a.Text.Trim() == "" || txt003a.Text.Trim() == "" ||
            ddown003a.SelectedValue == "0" || ddown006a.SelectedValue == "0" || ddown005a.SelectedValue == "0" ||
            txt005a.Text.Trim() == "" || ddown004a.SelectedValue == "0" || txt005b.Text.Trim() == "" || ddown006.SelectedValue == "" || ddown006a.SelectedValue == "0")
        {
            if (ddown005.SelectedValue == "-2"){ ddown005.BackColor = colorCampoObligatorio; }
            else { ddown005.BackColor = System.Drawing.Color.White; }

            if (ddown001.SelectedValue == "0") { ddown001.BackColor = colorCampoObligatorio; }
            else { ddown001.BackColor = System.Drawing.Color.White; }

            if (txt014.Text.Trim() == "") { txt014.BackColor = colorCampoObligatorio; }
            else { txt014.BackColor = System.Drawing.Color.White; }

            if (txt013.Text.Trim() == "") { txt013.BackColor = colorCampoObligatorio; }
            else { txt013.BackColor = System.Drawing.Color.White; }

            if (ddown004.SelectedValue == "0") { ddown004.BackColor = colorCampoObligatorio; }
            else { ddown004.BackColor = System.Drawing.Color.White; }

            if (cal001.Text == "Seleccione Fecha") { cal001.BackColor = colorCampoObligatorio; }
            else { cal001.BackColor = System.Drawing.Color.White; }

            if (txt005.Text.Trim() == "") { txt005.BackColor = colorCampoObligatorio; }
            else { txt005.BackColor = System.Drawing.Color.White; }

            if (ddown006.SelectedValue == "0" || ddown006.SelectedValue == "") { ddown006.BackColor = colorCampoObligatorio; }
            else { ddown006.BackColor = System.Drawing.Color.White; }

            if (txt001a.Text.Trim() == "") { txt001a.BackColor = colorCampoObligatorio; }
            else { txt001a.BackColor = System.Drawing.Color.White; }

            if (txt002a.Text.Trim() == "") { txt002a.BackColor = colorCampoObligatorio; }
            else { txt002a.BackColor = System.Drawing.Color.White; }

            if (txt003a.Text.Trim() == "") { txt003a.BackColor = colorCampoObligatorio; }
            else { txt003a.BackColor = System.Drawing.Color.White; }

            if (ddown003a.SelectedValue == "0") { ddown003a.BackColor = colorCampoObligatorio; }
            else { ddown003a.BackColor = System.Drawing.Color.White; }

            if (txt005a.Text.Trim() == "") { txt005a.BackColor = colorCampoObligatorio; }
            else { txt005a.BackColor = System.Drawing.Color.White; }

            if (ddown004a.SelectedValue == "0") { ddown004a.BackColor = colorCampoObligatorio; }
            else { ddown004a.BackColor = System.Drawing.Color.White; }

            if (ddown007a.SelectedValue == "0") { ddown007a.BackColor = colorCampoObligatorio; }
            else { ddown007a.BackColor = System.Drawing.Color.White; }

            if (txt005b.Text.Trim() == "") { txt005b.BackColor = colorCampoObligatorio; }
            else { txt005b.BackColor = System.Drawing.Color.White; }

            if (ddown005a.SelectedValue == "0") { ddown005a.BackColor = colorCampoObligatorio; }
            else { ddown005a.BackColor = System.Drawing.Color.White; }

            if (ddown006a.SelectedValue == "0") { ddown006a.BackColor = colorCampoObligatorio; }
            else { ddown006a.BackColor = System.Drawing.Color.White; }


        }
        else
        {
            int vf = 0;
            string fechaaniv;
            fechaaniv = "";
            if (rdo001b.Checked)
            {
                vf = 1;
            }
            else
            {
                vf = 0;
            }
            //if (calaniv001.Text.Trim() != "" && calaniv002.Text.Trim() != "")
            //{
            //    if (calaniv001.Text.Trim().Length == 1)
            //    {
            //        fechaaniv = "0" + calaniv001.Text.Trim();
            //    }
            //    else
            //    {
            //        fechaaniv = calaniv001.Text.Trim();
            //    }
            //    if (calaniv002.Text.Trim().Length == 1)
            //    {
            //        fechaaniv += "0" + calaniv002.Text.Trim();
            //    }
            //    else
            //    {
            //        fechaaniv += calaniv002.Text.Trim();
            //    }
            if (calAniversario.Text.Trim() != ""){
              calAniversario.Text = calAniversario.Text.Replace("-", "");
              fechaaniv = calAniversario.Text.Substring(0, 4);
              //fechaaniv += calAniversario.Text.Substring(2, 4);
            }
            else
            {
              calAniversario.Text = "0";
            }

            DateTime FechaTermino = Convert.ToDateTime("01-01-1900").Date;
            if (cal003.Text != "Seleccione Fecha")
            {
                FechaTermino = Convert.ToDateTime(cal003.Text);
            }
            proyectocoll proycoll = new proyectocoll();

            int codcausalterminoproyecto = proycoll.GetLRPA_ModeloIntervencion(Convert.ToInt32(ddown006a.SelectedValue));
            if (codcausalterminoproyecto == 1 || codcausalterminoproyecto == 2)
            {
                codcausalterminoproyecto = 20084;
            }
            else
            {
                codcausalterminoproyecto = 0;
            }
            inFechaCreacion = Convert.ToDateTime(cal001.Text);

            proycoll.Insert_Proyectos(Convert.ToInt32(txt014.Text), Convert.ToInt32(ddown001.SelectedValue),
            Convert.ToInt32(ddown005.SelectedValue), Convert.ToInt32(ddown006.SelectedValue), txt0015.Text.ToUpper(),
            Convert.ToInt32(ddown004.SelectedValue), Convert.ToInt32(ddown007a.SelectedValue), Convert.ToInt32(ddown003a.SelectedValue),
            Convert.ToInt32(ddown005a.SelectedValue), Convert.ToInt32(ddown006a.SelectedValue), vCodPaso2, Convert.ToInt32(ddown004a.SelectedValue),
            codcausalterminoproyecto, Convert.ToInt32(ddwlist001.SelectedValue), Convert.ToInt32(ddwlist002.SelectedValue),
            txt013.Text.ToUpper(), txt003.Text.ToUpper(), txt004.Text.ToUpper().Trim().Replace(".",""), txt005.Text.ToUpper(), txt006.Text.ToUpper(), txt007.Text.ToUpper(), txt008.Text.ToUpper(), vf, txt010.Text.ToUpper(), txt011.Text.ToUpper(),
            fechaaniv, WMto0(txt001a), Convert.ToInt32(ddown008.SelectedValue), txt012.Text.Trim(),
            FechaTermino, WMto0(txt002a), WMto0(txt003a), WMto0(txt001b), WMto0(txt002b),
            WMto0(txt003b), WMto0(txt004b), Convert.ToInt32(Session["IdUsuario"]) /*usr*/, "V", inFechaCreacion, Convert.ToBoolean(0), DateTime.Now, Convert.ToInt32(Session["IdUsuario"])/*usr*/, Convert.ToInt32(rdolist001.SelectedValue),
            Convert.ToInt32(txt005b.Text));

            
            //WebImageButton5.Visible = false;
            //btn001.Visible = false;
            lblCausalTerminoProyecto.Visible = false;
            ddown001d.Visible = false;
            infoTerminoProyecto.Visible = true;
            tblCausalTerminoProyecto.Visible = false;
            
            btn001.Visible = true;
            if (lblBtn.Text == "Actualizar Datos del Proyecto")
            {
              pnlActualizado.Visible = true;
              lblBtn.Text = "Guardar Datos del Proyecto";
              ScriptManager.RegisterStartupScript(Page, Page.GetType(), "a", "$('#myButton').click();", true);
              ScriptManager.RegisterStartupScript(Page, Page.GetType(), "b", "$('#pnlActualizado').fadeIn();", true);
              //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "c", "$('#pnlActualizado').delay(4000).fadeOut();", true);
              ScriptManager.RegisterStartupScript(Page, Page.GetType(), "d", "$('#opt1').click();", true);
            }
            else
            {
              pnlCorrecto.Visible = true;
              ScriptManager.RegisterStartupScript(Page, Page.GetType(), "e", "$('#myButton').click();", true);
              ScriptManager.RegisterStartupScript(Page, Page.GetType(), "f", "$('#pnlCorrecto').fadeIn();", true);
              //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "g", "$('#pnlCorrecto').delay(4000).FadeOut();", true);
              ScriptManager.RegisterStartupScript(Page, Page.GetType(), "h", "$('#opt1').click();", true);
            }
            Session["guardado"] = "1";
            //pnl002.Visible = false;
            calAniversario.Text = "";
            limpiarTabs();
            validatescurity();
        }

    }

    private int WMto0(TextBox wm)
    {
        if (wm.Text.ToString().Trim() == "")
        {
            return 0;
        }
        else
        {
            return Convert.ToInt32(wm.Text);
        }

    }

    private string WDCtoString(TextBox wdc)
    {
        if (wdc.Text.ToString().Trim() == "Seleccione Fecha")
        {
            return Convert.ToString(DateTime.Now);
        }
        else
        {
            return Convert.ToString(wdc.Text);

        }



    }



    private string vigencia()
    {
        string dtime;
        if (Convert.ToDateTime(cal003.Text).Date <= DateTime.Now.Date)
        {
            dtime = Convert.ToString('V');
        }
        else
        {
            dtime = Convert.ToString('C');
        }

        return dtime;
    }





    protected void WebImageButton2_Click(object sender, EventArgs e)
    {
        getinstitucionestab();
        getregion();
        getbancos();
    }
    private void getinstitucionestab()
    {


        institucioncoll insticoll = new institucioncoll();
        DataView dv = new DataView(insticoll.GetData(Convert.ToInt32(Session["IdUsuario"])));
        ddown001.DataSource = dv;
        ddown001.DataTextField = "Nombre";
        ddown001.DataValueField = "CodInstitucion";
        dv.Sort = "Nombre";
        ddown001.DataBind();
    }



    private void gettipoproyecto()
    {
        parcoll par = new parcoll();
        DataView dv1 = new DataView(par.GetparTipoProyecto());

        ddown004.DataSource = dv1;
        ddown004.DataTextField = "Descripcion";
        ddown004.DataValueField = "TipoProyecto";
        dv1.Sort = "Descripcion";
        ddown004.DataBind();

    }


    private void getregion()
    {


        parcoll par = new parcoll();
        DataView dv6 = new DataView(par.GetparRegion());
        ddown005.DataSource = dv6;
        ddown005.DataTextField = "Descripcion";
        ddown005.DataValueField = "CodRegion";
        dv6.Sort = "CodRegion";
        ddown005.DataBind();


    }

    protected void ddown005_SelectedIndexChanged(object sender, EventArgs e)
    {
        //jvb
        //a session la region seleccionada
        if (ddown005.SelectedValue != null)
        { Session["reg_selec"] = ddown005.SelectedValue; }


        getcomuna();

    }
    private void generacodproyecto()
    {
        proyectocoll pcoll = new proyectocoll();
        int Pparte;
        if (ddown005.SelectedValue != "-2")
        {
            pnl001.Visible = false;
            if (ddown005.SelectedValue.Length == 1)
            {
                Pparte = Convert.ToInt32("1" + "0" + ddown005.SelectedValue);
            }
            else
            {
                Pparte = Convert.ToInt32("1" + ddown005.SelectedValue);
            }
            int CodProyecto = pcoll.funcioncodproyecto(Pparte);
            CodProyecto = CodProyecto + 1;
            txt014.Text = Convert.ToString(CodProyecto);
        }
        else
        {
            lbl003.Text = "Primero debe ingresar la región";
            imb001.Visible = false;
            pnl001.Visible = true;
        }
    }
    private void getcomuna()
    {
        parcoll par = new parcoll();
        DataView dv6 = new DataView(par.GetparComunas(ddown005.SelectedValue));
        ddown006.Items.Clear();
        ddown006.DataSource = dv6;
        ddown006.DataTextField = "Descripcion";
        ddown006.DataValueField = "CodComuna";
        dv6.Sort = "Descripcion";
        ddown006.DataBind();


    }


    private void getbancos()
    {

        parcoll par = new parcoll();
        DataView dv8 = new DataView(par.GetparBancos());

        ddown008.Items.Clear();
        ddown008.DataSource = dv8;
        ddown008.DataTextField = "Descripcion";
        ddown008.DataValueField = "CodBanco";
        dv8.Sort = "Descripcion";
        ddown008.DataBind();

    }

    private void gettematica()
    {

        parcoll par = new parcoll();
        DataView dv5a = new DataView(par.GetparModeloIntervecion_Tematica(Convert.ToInt32(ddown006a.SelectedValue)));

        ddown005a.Items.Clear();
        ddown005a.DataSource = dv5a;
        ddown005a.DataTextField = "Descripcion";
        ddown005a.DataValueField = "CodTematicaProyecto";
        dv5a.Sort = "Descripcion";
        ddown005a.DataBind();

    }

    private void getdeptosename()
    {

        parcoll par = new parcoll();
        DataView dv4a = new DataView(par.parDepartamentosSENAMExModeloIntervencion(Convert.ToInt32(ddown006a.SelectedValue)));

        if (dv4a.Table.Rows.Count == 1)
        {
            dv4a = new DataView(par.GetparDepartamentosSENAME());
            ddown004a.Items.Clear();
            ddown004a.DataSource = dv4a;
            ddown004a.DataTextField = "Nombre";
            ddown004a.DataValueField = "CodDepartamentosSENAME";
            dv4a.Sort = "Nombre";
            ddown004a.DataBind();
        }
        else if (dv4a.Table.Rows.Count > 1)
        {
            ddown004a.Items.Clear();
            ddown004a.DataSource = dv4a;
            ddown004a.DataTextField = "Nombre";
            ddown004a.DataValueField = "CodDepartamentosSENAME";
            dv4a.Sort = "Nombre";
            ddown004a.DataBind();
        }
    }



    private void gettipoatencion()
    {

        parcoll par = new parcoll();
        DataView dv3a = new DataView(par.GetparTipoAtencionxProyectoUno());

        ddown003a.Items.Clear();
        ddown003a.DataSource = dv3a;
        ddown003a.DataTextField = "Descripcion";
        ddown003a.DataValueField = "CodTipoAtencion";
        dv3a.Sort = "Descripcion";
        ddown003a.DataBind();

    }

    private void getmodelointervencionxproyecto()
    {

        parcoll par = new parcoll();
        DataView dv6a = new DataView(par.GetparModeloIntervencionxProyecto(Convert.ToInt32(ddown004.SelectedValue)));

        ddown006a.Items.Clear();
        ddown006a.DataSource = dv6a;
        ddown006a.DataTextField = "Descripcion";
        ddown006a.DataValueField = "CodModeloIntervencion";
        dv6a.Sort = "Descripcion";
        ddown006a.DataBind();

    }

    private void getModeloIntervencionxProyectosFiltrados()
    {
        parcoll par = new parcoll();

        DataView dv = new DataView(par.GetparModeloIntervencionxProyecto(Convert.ToInt32(ddown004.SelectedValue)));

        ddown006a.Items.Clear();
        dv.Sort = "Descripcion";
        dv.RowFilter = "IndVigencia = 'V'";
        ddown006a.DataSource = dv;
        ddown006a.DataTextField = "Descripcion";
        ddown006a.DataValueField = "CodModeloIntervencion";
        ddown006a.DataBind();
        ddown006a_SelectedIndexChanged(new object(), new EventArgs());
    }




    private void getcausalterminoproyecto()
    {


        parcoll par = new parcoll();
        DataView dv1d = new DataView(par.GetparCausalTerminoProyecto());

        ddown001d.DataSource = dv1d;
        ddown001d.DataTextField = "Descripcion";
        ddown001d.DataValueField = "CodCausalTerminoProyecto";
        dv1d.Sort = "Descripcion";
        ddown001d.DataBind();

    }

    private void gettipopago()
    {


        parcoll par = new parcoll();
        DataView dv1 = new DataView(par.GetparTipoSubvencionxModeloIntervencion(Convert.ToInt32(ddown006a.SelectedValue)));

        ddown007a.Items.Clear();
        ddown007a.DataSource = dv1;
        ddown007a.DataTextField = "Descripcion";
        ddown007a.DataValueField = "TipoSubvencion";
        dv1.Sort = "Descripcion";
        ddown007a.DataBind();
        if (ddown007a.Items.Count > 1)
        {
            ddown007a.Visible = true;
        }
        else
        {
            ddown007a.Visible = false;
        }
    }


  
    private void FactoresLey20032()
    {
        int rdoval = 0;
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis
        txt005b.BackColor = System.Drawing.Color.White;
        if (rdo001b.Checked == true)
        {
            rdoval = 1;
        }
        else if (rdo002b.Checked == false)
        {
            rdoval = 0;
        }

        if (ddown006.SelectedValue != "0" && txt005b.Text.Trim() != "" && txt005b.Text.Trim() != "0" && ddown006a.SelectedValue != "0")
        {
          lbl031.Text = "";
          lbl031.Visible = false;
          alertaFactores.Visible = false;
            proyectocoll pcoll = new proyectocoll();
            DataTable dt = pcoll.Get_FactoresLey_20032(Convert.ToInt32(ddown006a.SelectedValue),
                Convert.ToInt32(txt005b.Text), Convert.ToInt32(ddown006.SelectedValue), rdoval);

            if (dt.Rows.Count > 0)
            {
                lbl027.Text = Convert.ToString(dt.Rows[0][0]);
                lbl028.Text = Convert.ToString(dt.Rows[0][1]);
                lbl029.Text = Convert.ToString(dt.Rows[0][2]);
                lbl030.Text = Convert.ToString(dt.Rows[0][3]);
                lbl021.Text = Convert.ToString(dt.Rows[0][4]);
                lbl022.Text = Convert.ToString(dt.Rows[0][5]);
                lbl023.Text = Convert.ToString(dt.Rows[0][6]);
                lbl024.Text = Convert.ToString(dt.Rows[0][7]);
                lbl019.Text = Convert.ToString(dt.Rows[0][10]);
                lbl020.Text = Convert.ToString(dt.Rows[0][9]);
                lbl025.Text = Convert.ToString(dt.Rows[0][3]);

                lbl031.Visible = false;
                alertaFactores.Visible = false;
                //pnl002.Visible = true;
            }

        }
        else
        {

            lbl031.Text = "Faltan datos, ingrese: ";
            
            if (ddown006.SelectedValue == "0") {
                ddown006.BackColor = colorCampoObligatorio;
                lbl031.Text += "Comuna / ";
            }
            else ddown006.BackColor = System.Drawing.Color.White;

            if (txt005b.Text.Trim() == "" || txt005b.Text.Trim() == "0") {
                txt005b.BackColor = colorCampoObligatorio;
                lbl031.Text += "Número Plaza / ";

            }
            else txt005b.BackColor = System.Drawing.Color.White;
            if (ddown006a.SelectedValue == "0") {
                ddown006a.BackColor = colorCampoObligatorio;
                lbl031.Text += "Modelo Intervención";

            }
            else ddown006a.BackColor = System.Drawing.Color.White;

            lbl031.Visible = true;
            alertaFactores.Visible = true;
            


        }
    }
    

    protected void ddown004_SelectedIndexChanged(object sender, EventArgs e)
    {
        //getmodelointervencionxproyecto();
        getModeloIntervencionxProyectosFiltrados();
    }
    protected void ddown006a_SelectedIndexChanged(object sender, EventArgs e)
    {
        gettematica();
        getdeptosename();
        gettipopago();
        getvidafamiliar();
    }
    protected void ddwlist001_SelectedIndexChanged(object sender, EventArgs e)
    {
        getproyectosxcod();
    }
    private void getproyectoOrigen(int codproyecto)
    {
        proyectocoll pcoll = new proyectocoll();
        DataTable dt = pcoll.GetProyectoOrigen(codproyecto);
        if (dt.Rows.Count > 1)
        {
            ListItem oItem = new ListItem(Convert.ToString(dt.Rows[1][1]), Convert.ToString(dt.Rows[1][0]));
            ddwlist002.Items.Clear();
            ddwlist002.Items.Add(oItem);
        }
    }
    private void getproyectosxcod()
    {
        proyectocoll pcoll = new proyectocoll();

        DataTable dtproy = pcoll.GetData(Convert.ToInt32(Session["IdUsuario"]), "V", Convert.ToInt32(ddwlist001.SelectedValue));

        ddwlist002.Items.Clear();
        ddwlist002.DataSource = dtproy;
        ddwlist002.DataTextField = "Nombre";
        ddwlist002.DataValueField = "CodProyecto";
        ddwlist002.DataBind();


        proyecto proyec = new proyecto();
        try
        {

            if (Convert.ToString(SSproyecto.codproyecto_coincidente) != "0")
            {
                ddwlist002.SelectedValue = Convert.ToString(SSproyecto.codproyecto_coincidente);
            }

        }
        catch
        { }


    }


    protected void txt014_ValueChange(object sender, EventArgs e)
    {
        if (txt014.Text.Trim() != "")
        {
            funcion_generacodigo();
        }
    }
    private void funcion_generacodigo()
    {
        string mensaje = "";

        if (txt014.Text.ToString() != "")
        {
            proyectocoll pcoll = new proyectocoll();
            DataTable dt = pcoll.GetProyectos(Convert.ToString(txt014.Text));
            if (dt.Rows.Count > 0)
            {
                if (Convert.ToString(dt.Rows[0][0]) == Convert.ToString(txt014.Text))
                {
                    mensaje = "Error, el código ingresado ya existe.";
                }
            }
            if (txt014.Text.Substring(0, 1) != "1")
            {
                mensaje += "Error el codigo debe comenzar con 1<bR>";
            }
            string region;
            if (txt014.Text.Substring(1, 1) == "0")
            {
                region = txt014.Text.Substring(2, 1);
            }
            else
            {
                region = txt014.Text.Substring(1, 2);
            }

            if (ddown005.Items.FindByValue(region) == null)
            {
                mensaje += "Error, el segundo y tercer dígito deben corresponder a una Región<br>";
            }

            lbl003.Text = mensaje;
            pnl001.Visible = true;
        }
        else
        {
            pnl001.Visible = true;
            lbl003.Text = "Error, campo vacío";
        }
    }
    protected void WebImageButton4_Click(object sender, EventArgs e)
    {
        cargadatos();
    }

    private void cargadatos()
    {
        if (ddown005.SelectedValue == "-2")
        {
            lbl003.Text = "Primero seleccione una Region";
            pnl001.Visible = true;
            imb001.Visible = false;
        }
        else
        {
            generacodproyecto();
            pnl001.Visible = false;
            imb001.Visible = true;
        }

    }

    protected void WebImageButton1_Click1(object sender, EventArgs e)
    {
        window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=Proyectos&codinst=" + ddown001.SelectedValue, "Buscador", false, false, 770, 420, false, false, true);

    }
    protected void ddown005a_SelectedIndexChanged(object sender, EventArgs e)
    {

    }



    protected void WebImageButton2_Click1(object sender, EventArgs e)
    {

        funcion_limpiar();

    }

    private void funcion_limpiar()
    {
        for (int j = 0; j < this.utab3.Controls.Count; j++)
        {
            for (int i = 0; i < this.utab3.Controls[j].Controls.Count; i++)
            {
                try
                {
                    if (utab3.Controls[j].Controls[i] is TextBox)
                        ((TextBox)this.utab3.Controls[j].Controls[i]).Text = "";
                }
                catch { }
                try
                {
                    if (utab3.Controls[j].Controls[i] is DropDownList)
                        ((DropDownList)this.utab3.Controls[j].Controls[i]).SelectedIndex = 0;
                }
                catch { }
                try
                {
                    if (utab3.Controls[j].Controls[i] is TextBox)
                        ((TextBox)this.utab3.Controls[j].Controls[i]).Text = "";
                }
                catch { }
                try
                {
                    if (utab3.Controls[j].Controls[i] is TextBox)
                        ((TextBox)this.utab3.Controls[j].Controls[i]).Text = "";
                }
                catch { }
                try
                {
                    if (utab3.Controls[j].Controls[i] is TextBox)
                        ((TextBox)this.utab3.Controls[j].Controls[i]).Text = null;
                }
                catch { }


            }

        }
        for (int j = 0; j < this.utab3.Controls.Count; j++)
        {
            for (int i = 0; i < this.utab3.Controls[j].Controls.Count; i++)
            {
                try
                {
                    if (utab3.Controls[j].Controls[i] is TextBox)
                        ((TextBox)this.utab3.Controls[j].Controls[i]).ReadOnly = false;
                }
                catch { }
                try
                {
                    if (utab3.Controls[j].Controls[i] is DropDownList)
                        ((DropDownList)this.utab3.Controls[j].Controls[i]).Enabled = true;
                }
                catch { }
                try
                {
                    if (utab3.Controls[j].Controls[i] is TextBox)
                        ((TextBox)this.utab3.Controls[j].Controls[i]).ReadOnly = false;
                }
                catch { }

                try
                {
                    if (utab3.Controls[j].Controls[i] is TextBox)
                        ((TextBox)this.utab3.Controls[j].Controls[i]).Enabled = true;
                }
                catch { }


            }

        }
        for (int j = 0; j < this.utab3.Controls.Count; j++)
        {
            for (int i = 0; i < this.utab3.Controls[j].Controls.Count; i++)
            {
                try
                {
                    if (utab3.Controls[j].Controls[i] is TextBox)
                        ((TextBox)this.utab3.Controls[j].Controls[i]).BackColor = System.Drawing.Color.White;
                }
                catch { }
                try
                {
                    if (utab3.Controls[j].Controls[i] is DropDownList)
                        ((DropDownList)this.utab3.Controls[j].Controls[i]).BackColor = System.Drawing.Color.White;
                }
                catch { }
                try
                {
                    if (utab3.Controls[j].Controls[i] is TextBox)
                        ((TextBox)this.utab3.Controls[j].Controls[i]).BackColor = System.Drawing.Color.White;
                }
                catch { }

                try
                {
                    if (utab3.Controls[j].Controls[i] is TextBox)
                        ((TextBox)this.utab3.Controls[j].Controls[i]).BackColor = System.Drawing.Color.White;
                }
                catch { }

            }

        }
        ddown003a.Items.Clear();
        gettipoatencion();
        ddown004a.Items.Clear();
        ddown005a.Items.Clear();
        ddown006a.Items.Clear();
        ddown007a.Items.Clear();
        ddwlist002.Items.Clear();
        ImageButton3.Visible = true;
        getproyectosxcod();
        Escondertabs();


        btn001.Visible = true;
        //WebImageButton5.Visible = false;
        lblCausalTerminoProyecto.Visible = false;
        ddown001d.Visible = false;
        infoTerminoProyecto.Visible = true;
        tblCausalTerminoProyecto.Visible = false;
            

        rdolist001.Items[0].Enabled = false;
        rdolist001.Items[1].Enabled = false;
        rdolist001.Items[1].Selected = false;
        rdolist001.Items[0].Selected = true;

        txt005a.Text = "Ley 20.032";
        validatescurity();

    }
    protected void WebImageButton3_Click(object sender, EventArgs e)
    {
        Response.Redirect("../mod_instituciones/index_instituciones.aspx");
    }
    protected void WebImageButton4_Click1(object sender, EventArgs e)
    {
        FactoresLey20032();
    }
    protected void WebImageButton4_Click2(object sender, EventArgs e)
    {
        FactoresLey20032();
    }


    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        string etiqueta = "Plan de Intervencion";
        string cadena = string.Empty;

        cadena = @"window.open(this.Page, '../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_proyectos/proyectoreferente.aspx', 'Buscador', false, true, '770', '420', false, false, true)";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        cargadatos();
    }
    protected void txt004_ValueChange(object sender, EventArgs e)
    {
        try
        {
            if (txt004.Text.Length > 3)
            {
                string rutsinnada = txt004.Text.Replace(".", "").Replace(",", "").Replace("-", "").Trim();
                string digitoingresado = rutsinnada.Substring(rutsinnada.Length - 1, 1);

                string digitocalculado = digitoVerificador(Convert.ToInt32(rutsinnada.ToUpper().Replace("K", "").Substring(0, rutsinnada.Length - 1)));
                if (digitocalculado.ToUpper() == digitoingresado.ToUpper())
                {
                    pnl003.Visible = false;
                    string punorut = rutsinnada.ToUpper().Replace("K", "").Substring(0, rutsinnada.Length - 1).Trim();
                    string rcompleto = punorut + "-" + digitocalculado.ToUpper();
                    txt004.Text = rcompleto;
                }
                else
                {
                    lbl004.Text = "RUT INGRESADO NO ES VALIDO";
                    pnl003.Visible = false;
                }
            }
            else
            {
                lbl004.Text = "RUT INGRESADO NO ES VALIDO";
                pnl003.Visible = false;
            }
        }
        catch
        {
            lbl004.Text = "RUT INGRESADO NO ES VALIDO";
            pnl003.Visible = false;
        }
    }

    private string digitoVerificador(int rut)
    {
        int Digito;
        int Contador;
        int Multiplo;
        int Acumulador;
        string RutDigito;

        Contador = 2;
        Acumulador = 0;

        while (rut != 0)
        {
            Multiplo = (rut % 10) * Contador;
            Acumulador = Acumulador + Multiplo;
            rut = rut / 10;
            Contador = Contador + 1;
            if (Contador == 8)
            {
                Contador = 2;
            }

        }

        Digito = 11 - (Acumulador % 11);
        RutDigito = Digito.ToString().Trim();
        if (Digito == 10)
        {
            RutDigito = "K";
        }
        if (Digito == 11)
        {
            RutDigito = "0";
        }
        return (RutDigito);
    }
    protected void txt011_ValueChange(object sender, EventArgs e)
    {
        try
        {
            if (txt011.Text.Length > 3)
            {
                string rutsinnada = txt011.Text.Replace(".", "").Replace(",", "").Replace("-", "").Trim();
                string digitoingresado = rutsinnada.Substring(rutsinnada.Length - 1, 1);

                string digitocalculado = digitoVerificador(Convert.ToInt32(rutsinnada.ToUpper().Replace("K", "").Substring(0, rutsinnada.Length - 1)));
                if (digitocalculado.ToUpper() == digitoingresado.ToUpper())
                {
                    //pnl002.Visible = false;
                    string punorut = rutsinnada.ToUpper().Replace("K", "").Substring(0, rutsinnada.Length - 1).Trim();
                    string rcompleto = punorut + "-" + digitocalculado.ToUpper();
                    txt011.Text = rcompleto;
                }
                else
                {
                    //lbl002.Text = "RUT INGRESADO NO ES VALIDO";
                    //pnl002.Visible = true;
                }
            }
            else
            {
                //lbl002.Text = "RUT INGRESADO NO ES VALIDO";
                //pnl002.Visible = true;
            }
        }
        catch
        {
            //lbl002.Text = "RUT INGRESADO NO ES VALIDO";
            //pnl002.Visible = true;
        }
    }
    //protected void btnnext_Click1(object sender, EventArgs e)
    //{
    //    utab3.ActiveTabIndex = 2;
    //    utab3.Tabs[2].Visible = true;
    //    utab3.Tabs[2].Enabled = true;
    //}
    //protected void btnnext_Click2(object sender, EventArgs e)
    //{

    //    if ((utab3.Tabs.Count - 1) > utab3.ActiveTabIndex)
    //    {
    //        int activo = utab3.ActiveTabIndex + 1;
    //        utab3.ActiveTabIndex = activo;
    //        utab3.Tabs[activo].Visible = true;
    //        utab3.Tabs[activo].Enabled = true;
    //    }
    //}



    protected void cal001_ValueChanged(object sender, EventArgs e)
    {
        CalendarExtende1272.StartDate = Convert.ToDateTime(cal001.Text).AddDays(1);
        cal001.BackColor = System.Drawing.Color.White;
        cal003.Enabled = true;
    }
    protected void cal003_ValueChanged(object sender, EventArgs e)
    {
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        if (cal001.Text == "Seleccione Fecha")
        {
            cal001.BackColor = colorCampoObligatorio;
            cal003.Text = null;
        }
        else
        {
            cal001.BackColor = System.Drawing.Color.White;
        }


    }
    protected void ddwlist002_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddwlist001.SelectedValue != "0" || ddwlist002.SelectedValue != "0" || ddwlist002.SelectedValue != "")
        {
            ddwlist002.BackColor = System.Drawing.Color.White;
            //btnnext.Visible = true;
        }
    }
    protected void WebImageButton5_Click1(object sender, EventArgs e)
    {
        funcion_guardar();
    }

    private void muestra_pestaña(int num_tab)
    {
      //switch (num_tab)
      //{
      //  case 1:
      //    tab1.Attributes.Add("class", "tab-pane fade in active");
      //    tab2.Attributes.Add("class", "tab-pane fade");
      //    tab3.Attributes.Add("class", "tab-pane fade");
      //    tab4.Attributes.Add("class", "tab-pane fade");
      //    li_nav1.Attributes.Add("class", "active");
      //    li_nav2.Attributes.Remove("class");
      //    li_nav3.Attributes.Remove("class");
      //    li_nav4.Attributes.Remove("class");
      //    li_nav2.Visible = false;
      //    li_nav3.Visible = false;
      //    li_nav4.Visible = false;
      //    break;
      //  case 2:
      //    tab1.Attributes.Add("class", "tab-pane fade");
      //    tab2.Attributes.Add("class", "tab-pane fade in active");
      //    tab3.Attributes.Add("class", "tab-pane fade");
      //    tab4.Attributes.Add("class", "tab-pane fade");
      //    li_nav1.Attributes.Remove("class");
      //    li_nav2.Attributes.Add("class", "active");
      //    li_nav3.Attributes.Remove("class");
      //    li_nav4.Attributes.Remove("class");
      //    li_nav2.Visible = true;
      //    break;
      //  case 3:
      //    tab1.Attributes.Add("class", "tab-pane fade");
      //    tab2.Attributes.Add("class", "tab-pane fade");
      //    tab3.Attributes.Add("class", "tab-pane fade in active");
      //    tab4.Attributes.Add("class", "tab-pane fade");
      //    li_nav1.Attributes.Remove("class");
      //    li_nav2.Attributes.Remove("class");
      //    li_nav3.Attributes.Add("class", "active");
      //    li_nav4.Attributes.Remove("class");
      //    li_nav3.Visible = true;
      //    break;
      //  case 4:
      //    tab1.Attributes.Add("class", "tab-pane fade");
      //    tab2.Attributes.Add("class", "tab-pane fade");
      //    tab3.Attributes.Add("class", "tab-pane fade");
      //    tab4.Attributes.Add("class", "tab-pane fade in active");
      //    li_nav1.Attributes.Remove("class");
      //    li_nav2.Attributes.Remove("class");
      //    li_nav3.Attributes.Remove("class");
      //    li_nav4.Attributes.Add("class", "active");
      //    li_nav4.Visible = true;
      //    break;
      //}
    }

    protected void btn_nexttab1_click(object sender, EventArgs e)
    {
      muestra_pestaña(2);
    }
    protected void btn_nexttab2_click(object sender, EventArgs e)
    {
      muestra_pestaña(3);
    }
    protected void btn_nexttab3_click(object sender, EventArgs e)
    {
      muestra_pestaña(4);
    }

    private void Escondertabs()
    {
      //li_nav2.Visible = false;
      //li_nav3.Visible = false;
      //li_nav4.Visible = false;
    }

    protected void ImageButton3_Click1(object sender, EventArgs e)
    {
      cargadatos();
    }
    protected void limpiarTab1_Click(object sender, EventArgs e)
    {
      ddown005.SelectedIndex = 0;
      ddown001.SelectedIndex = 0;
      txt014.Text = "";
      txt013.Text = "";
      txt003.Text = "";
      ddown004.SelectedIndex = 0;
      cal001.Text = "";
      cal003.Text = "";
      txt004.Text = "";
      txt005.Text = "";
      ddown006.SelectedIndex = 0;
      txt0015.Text = "";
      txt006.Text = "";
      txt007.Text = "";
      txt008.Text = "";
      txt010.Text = "";
      txt011.Text = "";
      //calaniv001.Text = "";
      //calaniv002.Text = "";
      ddown008.SelectedIndex = 0;
      txt012.Text = "";
      ddwlist001.SelectedIndex = 0;
      ddwlist002.SelectedValue = "0";
      calAniversario.Text = "";
      ImageButton3.Visible = true;


    }

    protected void limpiarTabs()
    {
      //TAB1
      ddown005.SelectedIndex = 0;
      ddown001.SelectedIndex = 0;
      txt014.Text = "";
      txt013.Text = "";
      txt003.Text = "";
      ddown004.SelectedIndex = 0;
      cal001.Text = "";
      cal003.Text = "";
      txt004.Text = "";
      txt005.Text = "";
      ddown006.SelectedIndex = 0;
      txt0015.Text = "";
      txt006.Text = "";
      txt007.Text = "";
      txt008.Text = "";
      txt010.Text = "";
      txt011.Text = "";
      //calaniv001.Text = "";
      //calaniv002.Text = "";
      ddown008.SelectedIndex = 0;
      txt012.Text = "";
      ddwlist001.SelectedIndex = 0;
      ddwlist002.SelectedIndex = 0;

      //TAB2
      txt001a.Text = "";
      txt002a.Text = "";
      txt003a.Text = "";
      ddown003a.SelectedIndex = 0;
      ddown006a.SelectedIndex = 0;
      ddown005a.SelectedIndex = 0;
      //txt005a.Text = "";
      ddown004a.SelectedIndex = 0;
      ddown007a.SelectedIndex = 0;

      //TAB3
      txt001b.Text = "";
      txt002b.Text = "";
      txt003b.Text = "";
      txt004b.Text = "";
      txt005b.Text = "";
      lbl027.Text = "---";
      lbl028.Text = "---";
      lbl029.Text = "---";
      lbl030.Text = "---";
      lbl019.Text = "---";
      lbl021.Text = "---";
      lbl022.Text = "---";
      lbl023.Text = "---";
      lbl024.Text = "---";
      lbl025.Text = "---";
      lbl020.Text = "---";
      alertaFactores.Visible = false;
      lbl031.Visible = false;

      //TAB4


    }
    protected void limpiarTab2_Click(object sender, EventArgs e)
    {
      txt001a.Text = "";
      txt002a.Text = "";
      txt003a.Text = "";
      ddown003a.SelectedIndex = 0;  
      ddown006a.SelectedIndex = 0;
      ddown005a.SelectedIndex = 0;
      //txt005a.Text = "";
      ddown004a.SelectedIndex = 0;
      ddown007a.SelectedIndex = 0;
    }
    protected void limpiarTab3_Click(object sender, EventArgs e)
    {
      txt001b.Text = "";
      txt002b.Text = "";
      txt003b.Text = "";
      txt004b.Text = "";
      txt005b.Text = "";
      lbl027.Text = "---";
      lbl028.Text = "---";
      lbl029.Text = "---";
      lbl030.Text = "---";
      lbl019.Text = "---";
      lbl021.Text = "---";
      lbl022.Text = "---";
      lbl023.Text = "---";
      lbl024.Text = "---";
      lbl025.Text = "---";
      lbl020.Text = "---";
      alertaFactores.Visible = false;
      lbl031.Visible = false;

    }
    protected void limpiaTab4_Click(object sender, EventArgs e)
    {

    }
    protected void txt004_TextChanged(object sender, EventArgs e)
    {
      try
      {
        if (txt004.Text.Length > 3)
        {
          string rutsinnada = txt004.Text.Replace(".", "").Replace(",", "").Replace("-", "").Trim();
          string digitoingresado = rutsinnada.Substring(rutsinnada.Length - 1, 1);

          string digitocalculado = digitoVerificador(Convert.ToInt32(rutsinnada.ToUpper().Replace("K", "").Substring(0, rutsinnada.Length - 1)));
          if (digitocalculado.ToUpper() == digitoingresado.ToUpper())
          {
            pnl003.Visible = false;
            string punorut = rutsinnada.ToUpper().Replace("K", "").Substring(0, rutsinnada.Length - 1).Trim();
            string rcompleto = punorut + "-" + digitocalculado.ToUpper();
            txt004.Text = rcompleto;
          }
          else
          {
            lbl004.Text = "RUT INGRESADO NO ES VALIDO";
            pnl003.Visible = false;
          }
        }
        else
        {
          lbl004.Text = "RUT INGRESADO NO ES VALIDO";
          pnl003.Visible = false;
        }
      }
      catch
      {
        lbl004.Text = "RUT INGRESADO NO ES VALIDO";
        pnl003.Visible = false;
      }
    }
    protected void cal001_TextChanged(object sender, EventArgs e)
     {
      CalendarExtende1272.StartDate = Convert.ToDateTime(cal001.Text).AddDays(1);
      cal001.BackColor = System.Drawing.Color.White;
      cal003.Enabled = true;
    }

    protected void next_Click(object sender, EventArgs e)
    {
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        int err = 0;

        if (ddown005.SelectedItem.Value == "-2")
        {
            ddown005.BackColor = colorCampoObligatorio;
            err++;
        }
        else
        {
            ddown005.BackColor = Color.White;
        }

        if (ddown001.SelectedItem.Value == "0")
        {
            ddown001.BackColor = colorCampoObligatorio;
            err++;
        }
        else
        {
            ddown001.BackColor = Color.White;
        }
        try
        {
            if (ddown006.SelectedItem.Value == "0")
            {
                ddown006.BackColor = colorCampoObligatorio;
                err++;
            }
            else
            {
                ddown006.BackColor = Color.White;
            }
        }
        catch
        {

        }
        if (txt014.Text == "")
        {
            txt014.BackColor = colorCampoObligatorio;
            err++;
        }
        else
        {
            txt014.BackColor = Color.White;
        }

        if (txt013.Text == "")
        {
            txt013.BackColor = colorCampoObligatorio;
            err++;
        }
        else
        {
            txt013.BackColor = Color.White;
        }

        if (txt003.Text == "")
        {
            txt003.BackColor = colorCampoObligatorio;
            err++;
        }
        else
        {
            txt003.BackColor = Color.White;
        }

        if (ddown004.SelectedValue == "0")
        {
            ddown004.BackColor = colorCampoObligatorio;
            err++;
        }
        else
        {
            ddown004.BackColor = Color.White;
        }

        if (cal001.Text == "")
        {
            cal001.BackColor = colorCampoObligatorio;
            err++;
        }
        else
        {
            cal001.BackColor = Color.White;
        }

        if (txt005.Text == "")
        {
            txt005.BackColor = colorCampoObligatorio;
            err++;
        }
        else
        {
            txt005.BackColor = Color.White;
        }


        if (txt004.Text == "")
        {
            txt004.BackColor = colorCampoObligatorio;
            err++;
        }
        else
        {
            txt004.BackColor = Color.White;
        }

        if (cal003.Text == "")
        {
            cal003.BackColor = colorCampoObligatorio;
            err++;
        }
        else
        {
            cal003.BackColor = Color.White;
        }

        if (err > 0)
        {
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "clickLaunchModal", "$('#myButton').click();", true);
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "fadeOutAlert", "$('#pnlCorrecto').fadeOut(10000,'')", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "irAlTope", "$('#html,body').animate({scrollTop:0}, '750');", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mostrarAlert", "$('#pnlAlert').delay(1500).show();", true);
        }else{

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "clickLaunchModal", "$('#opt2').click();", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mostrarAlert", "$('#pnlAlert').hide();", true);
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

        int err = 0;
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        
        if (txt001a.Text == "")
        {
            txt001a.BackColor = colorCampoObligatorio;
            err++;
        }else{
            txt001a.BackColor = Color.White;
        }

        if (txt002a.Text == "")
        {
            txt002a.BackColor = colorCampoObligatorio;
            err++;
        }else{
            txt002a.BackColor = Color.White;
        }

        if (txt003a.Text == "")
        {
            txt003a.BackColor = colorCampoObligatorio;
            err++;
        }else{
            txt003a.BackColor = Color.White;
        }

        if (ddown003a.SelectedValue == "0")
        {
            ddown003a.BackColor = colorCampoObligatorio;
            err++;
        }else{
            ddown003a.BackColor = Color.White;
        }

        if (ddown006a.SelectedValue == "0")
        {
            ddown006a.BackColor = colorCampoObligatorio;
            err++;
        }else{
            ddown006a.BackColor = Color.White;
        }

        if (ddown005a.SelectedValue == "0")
        {
            ddown005a.BackColor = colorCampoObligatorio;
            err++;
        }else{
            ddown005a.BackColor = Color.White;
        }

        if (ddown004a.SelectedValue == "0")
        {
            ddown004a.BackColor = colorCampoObligatorio;
            err++;
        }
        else
        {
            ddown004.BackColor = Color.White;

        }

        if (ddown007a.Visible == true)
        {
            if (ddown007a.SelectedValue == "0")
            {
                ddown007a.BackColor = colorCampoObligatorio;
                err++;
            }
            else
            {
                ddown007a.BackColor = Color.White;
            }
        }

        if (err > 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "irAlTope", "$('#html,body').animate({scrollTop:0}, '750')", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mostrarAlert", "$('#divAlert').delay(1500).show();", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "clickLaunchModal", "$('#opt3').click();", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mostrarAlert", "$('#divAlert').hide();", true);
        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        int err = 0;
        if (txt005b.Text == "")
        {
            txt005b.BackColor = colorCampoObligatorio;
            err++;
        }
        else
        {
            txt005.BackColor = Color.White;
        }

        if (err > 0)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "irAlTope", "$('#html,body').animate({scrollTop:0}, '750')", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mostrarAlert", "$('#divAlert').delay(1500).show();", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "clickLaunchModal", "$('#opt4').click();", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mostrarAlert", "$('#divAlert').hide();", true);
        }

    }
}