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

public partial class mod_ninos_hechosdesalud: System.Web.UI.Page
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
    private string dir = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        dir = Request.QueryString["dir"];

        if (!IsPostBack)
        {
            getdata();
            if (Request.QueryString["ICodHechosdeSalud"] != null)
            {
                modificardiscapacidad();
            }
            CalendarExtende889.StartDate = SSnino.fchingdesde;
            CalendarExtende889.EndDate = DateTime.Now;
        }
    }
    private string FormatFecha(string fecha)
    {
        string salida = string.Empty;
        try
        {
            salida = Convert.ToDateTime(fecha).ToString("dd-MM-yyyy");
        }
        catch { return string.Empty; }

        if (salida == "01-01-1900") salida = string.Empty;
        return salida;
    }

    private void modificardiscapacidad()
    {
        diagnosticoscoll dicoll = new diagnosticoscoll();
        DataTable dt = dicoll.GetHechosSaludById(Request.QueryString["ICodHechosdeSalud"]);

        cal001.Text = FormatFecha(dt.Rows[0][2].ToString());
        ddown001.Items.FindByValue(ddown001.SelectedValue).Selected = false;
        ddown001.Items.FindByValue(dt.Rows[0][3].ToString()).Selected = true;

        ddown002.Items.FindByValue(ddown002.SelectedValue).Selected = false;
        ddown002.Items.FindByValue(dt.Rows[0][4].ToString()).Selected = true;

        ddown003.Items.FindByValue(ddown003.SelectedValue).Selected = false;
        ddown003.Items.FindByValue(dt.Rows[0][5].ToString()).Selected = true;

        ddown004.Items.FindByValue(ddown004.SelectedValue).Selected = false;
        ddown004.Items.FindByValue(dt.Rows[0][7].ToString()).Selected = true;

        txt001.Text = dt.Rows[0][8].ToString();
        btn001.Text = "Modificar";
    }

    private void getdata()
    {
        parcoll par = new parcoll();
        trabajadorescoll tcoll = new trabajadorescoll();

        DataView dv1 = new DataView(par.GetparHechosSalud());
        ddown001.DataSource = dv1;
        ddown001.DataTextField = "Descripcion";
        ddown001.DataValueField = "CodHechoSalud";
        dv1.Sort = "Descripcion";
        ddown001.DataBind();

        DataView dv2 = new DataView(par.GetparAtencionHechoSalud());
        ddown002.DataSource = dv2;
        ddown002.DataTextField = "Descripcion";
        ddown002.DataValueField = "CodAtencionHechoSalud";
        dv2.Sort = "Descripcion";
        ddown002.DataBind();

        DataView dv3 = new DataView(par.GetparLugarHechoSalud());
        ddown003.DataSource = dv3;
        ddown003.DataTextField = "Descripcion";
        ddown003.DataValueField = "CodLugarHechoSalud";
        dv3.Sort = "Descripcion";
        ddown003.DataBind();

        DataView dv4 = new DataView(tcoll.GetTrabajadoresProyecto(SSnino.CodProyecto.ToString()));
        ddown004.DataSource = dv4;
        ddown004.DataTextField = "NombreCompleto";
        ddown004.DataValueField = "ICodTrabajador";
        dv4.Sort = "NombreCompleto";
        ddown004.DataBind();
            
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void btn001_Click(object sender, EventArgs e)
    {
        diagnosticoscoll dcoll = new diagnosticoscoll();


        if (Validate() == true)
        {

            string obs = "";
            if (txt001.Text.Trim() == "")
            {
                obs = "SIN OBSERVACIONES";
            }
            else
            {
                obs = txt001.Text.ToUpper();
            }



            if (btn001.Text.ToUpper() == "MODIFICAR")
            {
                DataTable dt = dcoll.GetHechosSaludById(Request.QueryString["ICodHechosdeSalud"]);
                // dcoll.Update_HechosSalud(Convert.ToInt32(Request.QueryString["ICodHechosdeSalud"]), Convert.ToInt32(dt.Rows[0][1]), Convert.ToDateTime(cal001.Value), Convert.ToInt32(ddown001.SelectedValue), Convert.ToInt32(ddown002.SelectedValue), Convert.ToInt32(ddown003.SelectedValue), SSnino.CodInst, Convert.ToInt32(ddown004.SelectedValue), txt001.Text, "V", DateTime.Now, 0);        
                dcoll.callto_update_hechossalud_2f(Convert.ToInt32(Request.QueryString["ICodHechosdeSalud"]), SSnino.ICodIE,
                Convert.ToDateTime(cal001.Text), Convert.ToInt32(ddown001.SelectedValue), Convert.ToInt32(ddown002.SelectedValue)
                , Convert.ToInt32(ddown003.SelectedValue), Convert.ToInt32(ddown004.SelectedValue), SSnino.CodInst,
                Convert.ToInt32(ddown004.SelectedValue), obs, "V", DateTime.Now, Convert.ToInt32(Session["IdUsuario"]));

              
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "", "RefrescaPadre();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "window.parent.cerrarModalHechosSalud();", true);
            }
            else
            {
                
                dcoll.Insert_HechosSalud(/*iden,*/ Convert.ToDateTime(cal001.Text), SSnino.ICodIE, Convert.ToInt32(ddown001.SelectedValue), Convert.ToInt32(ddown002.SelectedValue), /*codigolugar*/Convert.ToInt32(ddown004.SelectedValue), Convert.ToInt32(ddown003.SelectedValue), SSnino.CodInst, Convert.ToInt32(ddown004.SelectedValue), obs, "V", DateTime.Now, 0);
                
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "", "RefrescaPadre();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "window.parent.cerrarModalHechosSalud();", true);
            }
           
        }     
    }



    private bool Validate()
    {
        bool n = true;
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        if (cal001.Text.ToUpper() == "")
        {
            cal001.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            cal001.BackColor = System.Drawing.Color.White;
        }
        if (ddown001.SelectedValue == "0")
        {
            ddown001.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown001.BackColor = System.Drawing.Color.White;
        }
        if (ddown002.SelectedValue == "0")
        {
            ddown002.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown002.BackColor = System.Drawing.Color.White;
        }
        if (ddown003.SelectedValue == "0")
        {
            ddown003.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown003.BackColor = System.Drawing.Color.White;
        }
        if (ddown004.SelectedValue == "0")
        {
            ddown004.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown004.BackColor = System.Drawing.Color.White;
        }

        return n;
    
    }
}
