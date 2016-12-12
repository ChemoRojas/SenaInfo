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

public partial class accionesinformediagnostico : System.Web.UI.Page
{
    private string dir = string.Empty;
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

    public int VICodAccion
    {
        get
        {
            if (ViewState["VICodAccion"] == null)
            { ViewState["VICodAccion"] = -1; }  
            return Convert.ToInt32(ViewState["VICodAccion"]);
        }
        set { ViewState["VICodAccion"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        dir = Request.QueryString["dir"];
        if (!IsPostBack)
        {

            if (Request.QueryString["icodaccion"] != null)
            {
                VICodAccion = Convert.ToInt32(Request.QueryString["icodaccion"]);
                getdata();
               modificaraccion();
            }
            else 
            {
                getdata();            
            }
            if (Request.QueryString["sw"] != null)
            {

                //modificaraccion();

            }
            CalendarExtende339.StartDate = SSnino.fchingdesde;
            //cal001.MinDate = SSnino.fchingdesde;
            CalendarExtende339.EndDate = DateTime.Now;
            //cal001.MaxDate = DateTime.Now;
        
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
    private void modificaraccion()
    {
        
        diagnosticoscoll dcoll = new diagnosticoscoll();
        DataTable dt = dcoll.GetAccionesInformeDiagnosticoModifica(Request.QueryString["icodaccion"]);

        cal001.Text = FormatFecha(dt.Rows[0][2].ToString());

      
        ddown001.Items.FindByValue(ddown001.SelectedValue).Selected = false;
        ddown001.Items.FindByValue(dt.Rows[0][3].ToString()).Selected = true;

        ddown002.Items.FindByValue(ddown002.SelectedValue).Selected = false;
        ddown002.Items.FindByValue(dt.Rows[0][1].ToString()).Selected = true;

        txt001.Text = dt.Rows[0][4].ToString();
        btn001.Text = "Modificar";


    }


    private void getdata()
    {
        parcoll par = new parcoll();
        trabajadorescoll tcoll = new trabajadorescoll();

        DataView dv1 = new DataView(par.GetparTipoEventoIntervencion());
        ddown001.DataSource = dv1;
        ddown001.DataTextField = "Descripcion";
        ddown001.DataValueField = "TipoEventoIntervencion";
        dv1.Sort = "Descripcion";
        ddown001.DataBind();

       
        DataView dv2 = new DataView(tcoll.GetTrabajadoresProyecto(SSnino.CodProyecto.ToString()));
        ddown002.DataSource = dv2;
        ddown002.DataTextField = "NombreCompleto";
        ddown002.DataValueField = "ICodTrabajador";
        dv2.Sort = "NombreCompleto";
        ddown002.DataBind();
            
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void btn001_Click(object sender, EventArgs e)
    {
        if (validate() == true)
        {
            string Observaciones;
            if (txt001.Text.Trim().ToUpper() == "")
            {
                Observaciones = "SIN OBSERVACIONES";
            }
            else 
            {
                Observaciones = txt001.Text.Trim().ToUpper();
            }


            diagnosticoscoll dcoll = new diagnosticoscoll();
            if (btn001.Text.Trim().ToUpper() == "AGREGAR ACCIONES")
            {

                SSnino.Estado = 0;

                int rep = dcoll.callto_insert_accionesinformediagnostico_2f(SSnino.ICodinformediagnostico, Convert.ToInt32(ddown001.SelectedValue),
                Convert.ToDateTime(cal001.Text), Convert.ToDateTime(cal001.Text), Convert.ToInt32(ddown002.SelectedValue),
                SSnino.CodInst, Convert.ToInt32(ddown002.SelectedValue), Observaciones, DateTime.Now, Convert.ToInt32(ddown001.SelectedValue));

                SSnino.Estado = rep;
            }
            else
            {

                dcoll.callto_update_accionesinformediagnostico_2f(VICodAccion, SSnino.ICodinformediagnostico
                , Convert.ToInt32(ddown001.SelectedValue), Convert.ToDateTime(cal001.Text), Convert.ToDateTime(cal001.Text)
                , Convert.ToInt32(ddown002.SelectedValue), SSnino.CodInst, Convert.ToInt32(ddown002.SelectedValue), txt001.Text.ToUpper()
                , DateTime.Now, Convert.ToInt32(ddown001.SelectedValue));

                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "window.parent.cerrarModalInfoDiag();", true);

                //dcoll.Update_AccionesInformeDiagnostico(ASP.global_asax.globaconn
                //    , SSnino.ICodinformediagnostico
                //    , VICodAccion
                //    , Convert.ToDateTime(cal001.Text)
                //    , Convert.ToInt32(ddown001.SelectedValue)
                //    , Convert.ToDateTime(cal001.Text)

                //    , SSnino.CodInst
                //    , Convert.ToInt32(ddown002.SelectedValue)
                //    , txt001.Text.ToUpper()
                //    , DateTime.Now);




            }
            //dcoll.Insert_AccionesInformeDiagnostico(ASP.global_asax.globaconn
            //, SSnino.ICodinformediagnostico
            //,/* SSnino.InicioInformeDiagnostico,*/Convert.ToInt32(ddown001.SelectedValue)
            //,Convert.ToDateTime(cal001.Value)
            //,Convert.ToDateTime(cal001.Value)
            //,Convert.ToInt32(ddown002.SelectedValue)
            //,SSnino.CodInst
            //,Convert.ToInt32(ddown002.SelectedValue)
            //,txt001.Text
            //,DateTime.Now
            //,Convert.ToInt32(ddown001.SelectedValue));

            //ClientScript.RegisterClientScriptBlock(typeof(string), "SENAINFO2", "<script  languaje=javascript> window.opener.__doPostBack('btnbind',''); </script>");
            //window.close(this);
            //window.alert(this, "Ingresado Correctamente");
            //actualiza ventana padre
            ClientScript.RegisterStartupScript(this.GetType(), "", "RefrescaPadre();", true);
            //ClientScript.RegisterClientScriptBlock(typeof(string), "SENAINFO2", "<script  languaje=javascript> RefrescaPadre(); </script>");
            

        }
    }
    private bool validate()
    {
        bool n = true;

        if (cal001.Text.Trim().ToUpper() == "SELECCIONE FECHA")
        {
            cal001.BackColor = System.Drawing.Color.Pink;
            n = false;
        }
        else 
        {
            cal001.BackColor = System.Drawing.Color.White;
            
        }
        if (ddown001.SelectedValue == "0")
        {
            ddown001.BackColor = System.Drawing.Color.Pink;
            n = false;
        }
        else 
        {
            ddown001.BackColor = System.Drawing.Color.White;
            
        }
        if (ddown002.SelectedValue == "0")
        {
            ddown002.BackColor = System.Drawing.Color.Pink;
            n = false;
        }
        else
        {
            ddown002.BackColor = System.Drawing.Color.White;
            
        }
       

        return n;
    
    }


    protected void btnsalir_Click(object sender, EventArgs e)
    {
        //window.close(this.Page);
        //cierra esta ventana
        ClientScript.RegisterStartupScript(this.GetType(), "", "CerrarFancybox();", true);
    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        clean();
    }
    private void clean()
    { 
        cal001.Text = "Seleccione Fecha";
        ddown001.SelectedValue = "0";
        ddown002.SelectedValue = "0";
        txt001.Text = "";
    
    }
}
