/*
 * 
 * GMP
 * 08/05/2015
 * Revisión windows.open, validación de fecha, no hay descargas excel
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

public partial class mod_ninos_discapacidad : System.Web.UI.Page
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

            if (Request.QueryString["ICodDiscapacidad"] != null)/*"ICodDiagnosticoDiscapacidad"*/
            {
                modificardiscapacidad();
            }
            else
            {
                chk001.Checked = false;
                cal004.Enabled = false;
                cal004.Text = "";
            }

            CalendarExtende782.StartDate = SSnino.fchingdesde;
            CalendarExtende782.EndDate = DateTime.Now;

            //cal004.MinDate = SSnino.fchingdesde;  // busca como menor valor de fecha el ingreso del niño a sename
            //cal004.MaxDate = DateTime.Now;        // busca fecha del dia
            CalendarExtende793.EndDate = DateTime.Now;
        }
       
    }

    private string FormatFecha(string fecha) {
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
        DataTable dt = dicoll.GetDiagnosticosDiscapacidadById(Request.QueryString["ICodDiscapacidad"]); /*"ICodDiagnosticoDiscapacidad"*/

        cal001.Text = FormatFecha(dt.Rows[0][2].ToString()); 
        //            Convert.ToDateTime(dt.Rows[0][2]).ToShortDateString().ToString();
        ddown001.Items.FindByValue(ddown001.SelectedValue).Selected = false;
        ddown001.Items.FindByValue(dt.Rows[0][1].ToString()).Selected = true;

        ddown002.Items.FindByValue(ddown002.SelectedValue).Selected = false;
        ddown002.Items.FindByValue(dt.Rows[0][4].ToString()).Selected = true;

        ddown003.Items.FindByValue(ddown003.SelectedValue).Selected = false;
        ddown003.Items.FindByValue(dt.Rows[0][6].ToString()).Selected = true;

        cal004.Enabled = true;
        cal004.Text = FormatFecha(dt.Rows[0][10].ToString());


    




        string inscripcion;
        inscripcion = Convert.ToString(dt.Rows[0][11]);
       
      
        if ( inscripcion == "0")
        {
            chk001.Checked = false;

            cal004.Enabled = false;
            cal004.Text = "";

        }
        else
        {
            chk001.Checked = true;
            cal004.Enabled = false;
        }


        txt001.Text = dt.Rows[0][3].ToString();
        btn001.Text = "Modificar";
      
    }

    private void getdata()
    {
        parcoll par = new parcoll();
        trabajadorescoll tcoll = new trabajadorescoll();

        DataView dv1 = new DataView(par.GetparTipoDiscapacidad ());
        ddown001.DataSource = dv1;
        ddown001.DataTextField = "Descripcion";
        ddown001.DataValueField = "TipoDiscapacidad";
        dv1.Sort = "Descripcion";
        ddown001.DataBind();

        DataView dv2 = new DataView(par.GetparNivelDiscapacidad());
        ddown002.DataSource = dv2;
        ddown002.DataTextField = "Descripcion";
        ddown002.DataValueField = "CodNivelDiscapacidad";
        dv2.Sort = "Descripcion";
        ddown002.DataBind();

        DataView dv3 = new DataView(tcoll.GetTrabajadoresProyecto(SSnino.CodProyecto.ToString()));
        ddown003.DataSource = dv3;
        ddown003.DataTextField = "NombreCompleto";
        ddown003.DataValueField = "ICodTrabajador";
        dv3.Sort = "NombreCompleto";
        ddown003.DataBind();

        ///////////////////////MICHAEL/////////////////////////////

        diagnosticoscoll dicoll = new diagnosticoscoll();
        DataTable dt = dicoll.GetInscritoFonadis(SSnino.CodNino);
        int valor1;
        
        
            valor1 = Convert.ToInt32(dt.Rows[0][15]);
            if (valor1 == 1)
            {
                chk001.Checked = true;
                cal004.Text = FormatFecha(DateTime.Now.ToShortDateString());
                cal004.Enabled = true;
            }
        



        //////////////////////FIN/////////////////////////////////



            
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void btn001_Click(object sender, EventArgs e)
    {
        diagnosticoscoll dcoll = new diagnosticoscoll();

        int fonadis = chk001.Checked?1:0;
        string FechaFonadis;
        if (cal004.Text == null || cal004.Text == "")
            FechaFonadis = "01/01/1900";
        else
            FechaFonadis = cal004.Text;
        
        if (btn001.Text.ToUpper() == "MODIFICAR")
        {
            if (valida())
            {
                DataTable dt = dcoll.GetDiagnosticosDiscapacidadById(Request.QueryString["ICodDiscapacidad"]);

                dcoll.callto_update_diagnosticosdiscapacidad_2f(Convert.ToInt32(Request.QueryString["ICodDiscapacidad"])
                , SSnino.ICodIE
                , Convert.ToInt32(ddown001.SelectedValue)
                , Convert.ToDateTime(cal001.Text)
                , Convert.ToString(txt001.Text)
                , Convert.ToInt32(ddown002.SelectedValue)
                , Convert.ToInt32(ddown003.SelectedValue)
                , SSnino.CodInst
                , Convert.ToInt32(ddown003.SelectedValue)
                , "V"
                , DateTime.Now
                , Convert.ToInt32(Session["IdUsuario"])
                , Convert.ToDateTime(FechaFonadis)
                , fonadis
                );
                
                //window.alert(this, "Ingresado Correctamente");
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "", "window.parent.MFref_AgrDis();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "window.parent.cerrarModalDiscapacidad();", true);
            }
        }
        else 
        {
            if (valida())
            {
                
                //int iden = dcoll.Insert_DiagnosticoGeneral(7, SSnino.CodNino, SSnino.ICodIE, DateTime.Now);
                dcoll.Insert_DiagnosticosDiscapacidad(/*iden,*/ SSnino.ICodIE,
                    /*Convert.ToInt32(ddown001.SelectedValue),*/Convert.ToInt32(ddown001.SelectedValue),
                    Convert.ToDateTime(cal001.Text), txt001.Text.ToUpper(), Convert.ToInt32(ddown002.SelectedValue),
                    Convert.ToInt32(ddown003.SelectedValue), SSnino.CodInst, Convert.ToInt32(ddown003.SelectedValue),
                    "V", DateTime.Now, Convert.ToInt32(Session["IdUsuario"]), Convert.ToDateTime(FechaFonadis), fonadis);

                dcoll.Insert_Fonad(fonadis, SSnino.CodNino);
                //window.alert(this, "Ingresado Correctamente");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "window.parent.cerrarModalDiscapacidad();", true);
                    
            }
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "", "window.parent.cerrarModalDiscapacidad();", true);
            //else 
            //{
                //    dcoll.Insert_DiagnosticosDiscapacidad(/*iden,*/ SSnino.ICodIE,
                //    /*Convert.ToInt32(ddown001.SelectedValue),*/Convert.ToInt32(ddown001.SelectedValue),
                //    Convert.ToDateTime(cal001.Value), txt001.Text.ToUpper(), Convert.ToInt32(ddown002.SelectedValue),
                //    Convert.ToInt32(ddown003.SelectedValue), SSnino.CodInst, Convert.ToInt32(ddown003.SelectedValue),
                //    "V", DateTime.Now, Convert.ToInt32(Session["IdUsuario"]), Convert.ToDateTime(cal004.Value), fonadis);
                //Lbl002.Visible = true;
                //getdata();
            //}
           
        }

        //ClientScript.RegisterStartupScript(this.GetType(), "", "RefrescaPadre();", true);
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "", "window.parent.cerrarModalDiscapacidad();", true);
        //Convert.ToInt32(ddown001.SelectedValue), FueRealizada(), FechaRealizada(), SSnino.CodInst, Convert.ToInt32(ddown003.SelectedValue), PropuestaTecnica(), ResultadoDiscernimiento());
        //ClientScript.RegisterClientScriptBlock(typeof(string), "SENAINFO2", "<script  languaje=javascript> window.opener.__doPostBack('btnbind',''); </script>");
        //window.close(this.Page);
    }


    private bool valida()
    {
        bool sw = true;
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        if (cal001.Text.ToUpper() == "")
        { 
            cal001.BackColor = colorCampoObligatorio;
            sw = false;
        }
        else 
        {
            cal001.BackColor = System.Drawing.Color.White;
        }

        if (ddown001.SelectedValue == "0")
        {
            ddown001.BackColor = colorCampoObligatorio;
            sw = false;
        
        }
        else 
        {
            ddown001.BackColor = System.Drawing.Color.White;
        
        }
        if (ddown002.SelectedValue == "0")
        {
            ddown002.BackColor = colorCampoObligatorio;
            sw = false;

        }
        else
        {
            ddown002.BackColor = System.Drawing.Color.White;

        }

        if (ddown003.SelectedValue == "0")
        {
            ddown003.BackColor = colorCampoObligatorio;
            sw = false;

        }
        else
        {
            ddown003.BackColor = System.Drawing.Color.White;

        }


        if (chk001.Checked)
        {

            if (cal004.Text.ToUpper() == "")
            {
                cal004.BackColor = colorCampoObligatorio;
                sw = false;
            }
            else
            {
                cal004.BackColor = System.Drawing.Color.White;
            
            }
        }

        ninocoll ncoll = new ninocoll();
        int CodModeloIntervencion = (int)ncoll.callto_get_codmodelointervencion(SSnino.CodProyecto);

        if (CodModeloIntervencion == 83 && cierre_mes() == 1)    // PAD - PROGRAMA DE PROTECCIÓN AMBULATORIA PARA NIÑOS(AS) Y ADOLESC. CON DISCAPACIDAD GRAVE O PROFUNDA 
        {
            Lbl002.Text = "No puede agregar una discapacidad en meses cerrados";
            Lbl002.Visible = true;
            cal001.BackColor = colorCampoObligatorio;
            sw = false;
        }

        return sw;

    }

    private int cierre_mes()
    {
        diagnosticoscoll dgcol = new diagnosticoscoll();
        int AnoMes = Convert.ToDateTime(cal001.Text).Year * 100 + Convert.ToDateTime(cal001.Text).Month;
        int MesCerrado = dgcol.callto_consulta_cierremes(SSnino.CodProyecto, AnoMes);
        return MesCerrado;
    }

    protected void btn002_Click(object sender, EventArgs e)
    {
        //window.close(this.Page);
       
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
    
    }
    protected void chk001_CheckedChanged(object sender, EventArgs e)
    {
        if (chk001.Checked)
        {
            cal004.Enabled = true;
            
        }
        else
        {
            cal004.Enabled = false;
            cal004.Text = "";
        }
    }
}
