/*
 * 
 * GMP
 * 08/05/2015
 * Revisión windows.open, agregué reloj de espera, validación de fecha, no hay descargas excel
 * puse validador del RUC en javascript
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

public partial class mod_ninos_enfermedadescronicas: System.Web.UI.Page
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getdata();
            if (Request.QueryString["ICodEnfermedadCronica"] != null)
            {
                modificardiscapacidad();
            }
            //cal001.MinDate = SSnino.fchingdesde;
            CalendarExtender_cal001.StartDate = SSnino.fchingdesde;
            //cal001.MaxDate = DateTime.Now;
            CalendarExtender_cal001.EndDate = DateTime.Now;
            //cal002.MinDate = SSnino.fchingdesde;
            //cal002.MaxDate = DateTime.Now;
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
        DataTable dt = dicoll.GetNinosEnfermedadesCronicasById(Request.QueryString["ICodEnfermedadCronica"]);

        cal001.Text = FormatFecha(dt.Rows[0][3].ToString());
        //cal002.Value = dt.Rows[0][4];
        ddown001.Items.FindByValue(ddown001.SelectedValue).Selected = false;
        ddown001.Items.FindByValue(dt.Rows[0][2].ToString()).Selected = true;

        ddown002.Items.FindByValue(ddown002.SelectedValue).Selected = false;
        ddown002.Items.FindByValue(dt.Rows[0][7].ToString()).Selected = true;

        txt001.Text = dt.Rows[0][4].ToString();
        btn001.Text = "Modificar";


    }


    private void getdata()
    {
        parcoll par = new parcoll();
        trabajadorescoll tcoll = new trabajadorescoll();

        DataView dv1 = new DataView(par.GetparEnfermedadesCronicas());
        ddown001.DataSource = dv1;
        ddown001.DataTextField = "Descripcion";
        ddown001.DataValueField = "CodEnfermedadCronica";
        dv1.Sort = "Descripcion";
        ddown001.DataBind();

       
        DataView dv2 = new DataView(tcoll.GetTrabajadoresProyecto(SSnino.CodProyecto.ToString()));
        ddown002.DataSource = dv2;
        ddown002.DataTextField = "NombreCompleto";
        ddown002.DataValueField = "ICodTrabajador";
        dv2.Sort = "NombreCompleto";
        ddown002.DataBind();
            
    }

    private bool validate()
    {


        bool n = true;
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        
        if (cal001.Text == "")
        {

            cal001.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            cal001.BackColor = System.Drawing.Color.White;

        }

        if (Convert.ToInt32(ddown001.SelectedValue) == 0)
        {
            ddown001.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown001.BackColor = System.Drawing.Color.White;

        }

        if (Convert.ToInt32(ddown002.SelectedValue) == 0)
        {
            ddown002.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown002.BackColor = System.Drawing.Color.White;

        }

        return n;
    
    }



    protected void btn001_Click(object sender, EventArgs e)
    {
        diagnosticoscoll dcoll = new diagnosticoscoll();

        if (validate() == true)
        {
            if (btn001.Text.ToUpper() == "MODIFICAR")
            {
                DataTable dt = dcoll.GetNinosEnfermedadesCronicasById(Request.QueryString["ICodEnfermedadCronica"]);
                dcoll.callto_update_ninosenfermedadescronicas_2f(Convert.ToInt32(Request.QueryString["ICodEnfermedadCronica"])
                    , SSnino.ICodIE
                    , Convert.ToInt32(ddown001.SelectedValue)
                    , Convert.ToDateTime(cal001.Text)
                    , txt001.Text.ToUpper()
                    , "V"
                    , Convert.ToInt32(ddown002.SelectedValue)
                    , SSnino.CodInst
                    , Convert.ToInt32(ddown002.SelectedValue)
                    , DateTime.Now, Convert.ToInt32(Session["IdUsuario"]));

                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "window.parent.cerrarModalEnfermedadesCronicas();", true);
            }
            else
            {
                dcoll.Insert_NinosEnfermedadesCronicas(/* iden,*/ Convert.ToInt32(ddown001.SelectedValue), SSnino.ICodIE, Convert.ToDateTime(cal001.Text), /*Convert.ToDateTime(cal002.Value),*/ txt001.Text.ToUpper(), "V", Convert.ToInt32(ddown002.SelectedValue), SSnino.CodInst, Convert.ToInt32(ddown002.SelectedValue), DateTime.Now, Convert.ToInt32(Session["IdUsuario"]));
            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "window.parent.cerrarModalEnfermedadesCronicas();", true);
        }
    }
    protected void btn002_Click(object sender, EventArgs e)
    {

        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "CerrarFancybox();", true); 
    }
}
