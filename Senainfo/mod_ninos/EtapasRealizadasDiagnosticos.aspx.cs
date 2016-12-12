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
using System.Drawing;

public partial class mod_ninos_EtapasRealizadasDiagnosticos : System.Web.UI.Page
{
    public int VIcodEtapa
    {
        get
        {
            if (ViewState["VIcodEtapa"] == null)
            { ViewState["VIcodEtapa"] = -1; }
            return Convert.ToInt32(ViewState["VIcodEtapa"]);
        }
        set { ViewState["VIcodEtapa"] = value; }
    }

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

            if (Request.QueryString["IcodEtapa"] != null)
            {
                VIcodEtapa = Convert.ToInt32(Request.QueryString["IcodEtapa"]);
                getdata();
                //modificar();
                getEtapas();
                CalendarExtende456.StartDate = SSnino.fchingdesde;
                //cal001.MinDate = SSnino.fchingdesde;
                CalendarExtende456.EndDate = DateTime.Now;
                //cal001.MaxDate = DateTime.Now;
            }
            else 
            {
                getdata();
                CalendarExtende456.StartDate = SSnino.fchingdesde;
                //cal001.MinDate = SSnino.fchingdesde;
                CalendarExtende456.EndDate = DateTime.Now;
                //cal001.MaxDate = DateTime.Now;
            }
          
        }
    


    }
    protected void btn_cerrar_Click(object sender, EventArgs e)
    {
        window.close(this.Page);
    }
    protected void btn_limpiar_Click(object sender, EventArgs e)
    {
        clean();
    }
    private void clean()
    {
        cal001.Text = "Seleccione Fecha";
        ddown001.SelectedValue = "0";    
    
    }
    private void getdata()
    {
       
        parcoll pcoll = new parcoll();
      
        DataTable dt7 = pcoll.GetparEtapasIntervencion();
        DataView dv7 = new DataView(dt7);
        ddown001.DataSource = dv7;
        ddown001.DataValueField = "CodEtapasIntervencion";
        ddown001.DataTextField = "Descripcion";
        ddown001.DataBind();

    }
    private void getEtapas()
    {
        diagnosticoscoll dcoll = new diagnosticoscoll();
        DataTable dt = dcoll.GetEtapasDeIntervencionModifica(VIcodEtapa);

        ddown001.SelectedValue = dt.Rows[0][0].ToString();
        cal001.Text = dt.Rows[0][1].ToString();
    
    
    
    }
    //private void modificar()
    //{
    //    if (validate() == true)
    //    {
    //        diagnosticoscoll dcoll = new diagnosticoscoll();

    //        DataTable dt = dcoll.callto_update_etapasinformediagnostico(VIcodEtapa,SSnino.ICodinformediagnostico 
    //        , Convert.ToInt32(ddown001.SelectedValue), Convert.ToDateTime(cal001.Value));

    //    }
 
    //}

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

        return n;

    }





    protected void btn_modificar_Click(object sender, EventArgs e)
    {
        if (validate() == true)
        {
            diagnosticoscoll dcoll = new diagnosticoscoll();

            DataTable dt = dcoll.callto_update_etapasinformediagnostico(VIcodEtapa, SSnino.ICodinformediagnostico
            , Convert.ToInt32(ddown001.SelectedValue), Convert.ToDateTime(cal001.Text));
            window.close(this.Page);

        }

    }
}
