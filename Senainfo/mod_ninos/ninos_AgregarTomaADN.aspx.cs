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

public partial class mod_ninos_ninos_AgregarTomaADN : System.Web.UI.Page
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
        Chk001.Enabled = false;
        Chk002.Enabled = false;
        
        Txt_nue.Enabled = true;

        int bsq2 = Convert.ToInt32(Request.QueryString["CodNino"]);
        adncolls adnbsq2 = new adncolls();
        DataTable dtbsq2 = adnbsq2.GetADN(bsq2);
        int rdb = Convert.ToInt32(dtbsq2.Rows[0][4]);

        if (rdo002.Checked) cal001.Enabled = true;
        if (rdo003.Checked) cal001.Enabled = true;
     
        if (rdo001.Checked) 
        {
            if (cal001.Text.ToUpper() == "")
            {
                Chk002.Enabled = false;
                cal002.Enabled = false;
                Txt_nue.Enabled = false;
    
                //cal003.MaxDate = DateTime.Now;
                //cal003.MinDate = Convert.ToDateTime(cal001.Value);
            }
            else
            {
                Chk002.Enabled = true;
                CalendarExtende703.StartDate = Convert.ToDateTime(cal001.Text);
                CalendarExtende703.EndDate = DateTime.Now;
            }
        }
        else
        {
            //cal003.Enabled = true;
            //cal003.Text = "Seleccione Fecha";
            //cal003.Enabled = false;
        }

        //cal003.Enabled = false; ////// AGREGADO RECIEN 

        if (!IsPostBack)
        {

            int usuario = (Convert.ToInt32(Session["IdUsuario"]));
            adncolls adnuser = new adncolls();
            DataTable dtuser = adnuser.GetTraeCodTrabajador(usuario);

            int codtra = 0;
            // MODIFICACION //int codtra = (Convert.ToInt32(dtuser.Rows[0][0]));
            codtra = Convert.ToInt32(dtuser.Rows[0][0]);

            cdtr.Text = Convert.ToString(codtra);

            adncolls adnuser2 = new adncolls();
            DataTable dtuser2 = adnuser2.GetTraeDatosTrabajador(codtra);

            Txt_tecnico.Text = (Convert.ToString(dtuser2.Rows[0][0])) + " " + (Convert.ToString(dtuser2.Rows[0][1])) + " " + (Convert.ToString(dtuser2.Rows[0][2]));
            Txt_run.Text = (Convert.ToString(dtuser2.Rows[0][3]));

            adncolls adnuser3 = new adncolls();
            DataTable dtuser3 = adnuser3.GetTraeCodCargo(codtra);

            int codcargo22 = (Convert.ToInt32(Session["IdUsuario"]));
            int codcargo = (Convert.ToInt32(dtuser3.Rows[0][0]));
           

            ////////////////////
            adncolls adnuser4 = new adncolls();
            DataTable dtuser4 = adnuser4.GetTraeCargo(codcargo);

            Txt_cargo.Text = (Convert.ToString(dtuser4.Rows[0][0]));


            adncolls fdesde = new adncolls();
            int codpr = Convert.ToInt32(Request.QueryString["codp"]);
            //DataTable dtfecha = fdesde.GetTraeFdesde(Convert.ToInt32(Request.QueryString["CodNino"]), codpr);
            DataTable dtfecha = fdesde.GetTraeFIngreso(Convert.ToInt32(Request.QueryString["delta"]));
            


            CalendarExtende690.StartDate = (Convert.ToDateTime(dtfecha.Rows[0][0]));
            CalendarExtende690.EndDate = DateTime.Now;

            if ((Convert.ToDateTime(dtfecha.Rows[0][0])) < (Convert.ToDateTime("25-11-2008")))

            {
                //ChkSentenciaExpresa.Enabled = false;
                //ChkSentenciaExpresaSI.Enabled = false;
                ChkSentenciaExpresa.Visible = false;
                ChkSentenciaExpresaSI.Visible = false;
                Label1.Visible = false;
            }


            
            imb_nuevo.Enabled = false;
            Chk001.Checked = false;

            CalendarExtende716.StartDate = (Convert.ToDateTime("01-01-2006"));
            CalendarExtende716.EndDate = DateTime.Now;

            int bsq = Convert.ToInt32(Request.QueryString["CodNino"]);
            adncolls adnbsq = new adncolls();
            DataTable dtbsq = adnbsq.GetADN(bsq);

            txt_rut.Text = Convert.ToString(dtbsq.Rows[0][5]);
            txtnombres.Text = Convert.ToString(dtbsq.Rows[0][1]);
            txtpaterno.Text = Convert.ToString(dtbsq.Rows[0][2]);
            txtmaterno.Text = Convert.ToString(dtbsq.Rows[0][3]);
            txtmaterno.Enabled = false;
            txtnombres.Enabled = false;
            txtpaterno.Enabled = false;
            txt_rut.Enabled = false;

            //////////////////////////
            Txt_cargo.Enabled = false;
            Txt_run.Enabled = false;
            cal002.Enabled = false;
            Txt_tecnico.Enabled = false;
            /////////////////////////

            DataTable dtNotificacion = adnbsq.GetADNNotificacion(Convert.ToInt32(Request.QueryString["delta"]));
            if (dtNotificacion.Rows.Count != 0)
            {
                chkNotificacion.Checked = (dtNotificacion.Rows[0][0].ToString() == "1");
                if (dtNotificacion.Rows[0][1].ToString().Substring(0, 10) == "01-01-1900")
                    txtFechaNotificacion.Text = null;
                else
                    txtFechaNotificacion.Text = dtNotificacion.Rows[0][1].ToString();

                if (dtNotificacion.Rows[0][2].ToString().Substring(0, 10) == "01-01-1900")
                    txtFechaMedicoLegal.Text = null;
                else
                    txtFechaMedicoLegal.Text = dtNotificacion.Rows[0][2].ToString();

                //txtFechaMedicoLegal.Value = dtNotificacion.Rows[0][2];
                txtHora.Text = dtNotificacion.Rows[0][3].ToString();
                txtMinuto.Text = dtNotificacion.Rows[0][4].ToString();

                // pnlNotificacion.Enabled = false;
                chkNotificacion.Enabled = false;
                txtFechaNotificacion.Enabled = false;
                txtFechaMedicoLegal.Enabled = false;
                txtHora.Enabled = false;
                txtMinuto.Enabled = false;
            }
            else
            CalendarExtende642.EndDate = System.DateTime.Now;

            if (Request.QueryString["sExpresa"].ToString() == "SI")
            {
                ChkSentenciaExpresaSI.Checked = true;
                SentenciaExpresa(1);
            }
            else
            {
               //ChkSentenciaExpresa.Checked = true;
                ChkSentenciaExpresa.Checked = false;
                SentenciaExpresa(0);
            }
            if (!ChkSentenciaExpresa.Visible)
            {
                rdo001.Enabled = true;
                rdo002.Enabled = true;
                rdo003.Enabled = true;
                chkNotificacion.Enabled = true;
            }
        }
    }
    
  
    protected void rdo001_CheckedChanged(object sender, EventArgs e)
    {
        rdo002.Checked = false;
        rdo003.Checked = false;
        rdoestado.Text = "0";
        cal003.Enabled = true;
        cal001.Enabled = true;

           int CodNino = Convert.ToInt32(Request.QueryString["CodNino"]);
            adncolls adn = new adncolls();
            DataTable dt = adn.GetADN(CodNino);  //Response.Redirect("ninos_adn.aspx?TomaADN=" + 0);
                                                                            //window.open(Page, "ninos_adn.aspx?TomaADN=" + 0 , 560, 400);
            if (Convert.ToInt32(dt.Rows[0][4]) == 0)

            {


                if (cal001.Text.ToUpper() != "")
                {
                    CalendarExtende703.StartDate = Convert.ToDateTime(cal001.Text);
                    CalendarExtende703.EndDate = DateTime.Now;

                }
                    Chk001.Checked = true;
                    Chk001.Enabled = false;
                    Chk002.Enabled = true;
                    cal003.Enabled = true;
                    Txt_nue.Enabled = true;
                    imb_nuevo.Enabled = true;
                    
                    ddown005g.Enabled = true;
                    ddown001g.Enabled = true;
                    ddown006g.Enabled = true;
                    cal002.Enabled = true;
                    Txt_orden.Enabled = true;

                    
        
            }

            diagnosticoscoll dcoll = new diagnosticoscoll();
            parcoll par = new parcoll();
            ninocoll ncoll = new ninocoll();
            trabajadorescoll tcoll = new trabajadorescoll();

            
            DataView dv43 = new DataView(par.GetparTipoTribunalADN());
            ddown001g.Items.Clear();
            ddown001g.DataSource = dv43;
            ddown001g.DataTextField = "Descripcion";
            ddown001g.DataValueField = "TipoTribunal";
            dv43.Sort = "Descripcion";
            ddown001g.DataBind();
            
          

            DataView dv44 = new DataView(par.GetparRegion());
            ddown005g.Items.Clear();
            ddown005g.DataSource = dv44;
            ddown005g.DataTextField = "Descripcion";
            ddown005g.DataValueField = "Codregion";
            dv44.Sort = "Codregion";
            ddown005g.DataBind();
            
    }


    protected void imb002_Click(object sender, EventArgs e)
    {
       
        imb_nuevo.Enabled = true;
       
    }


    

    private bool valida()//// VALIDACIONES
    {
        bool sw = true;

        if (rdo001.Checked)
        {
            if (cal003.Text.ToUpper() == "")
            {
                cal003.BackColor = System.Drawing.Color.Pink;
                sw = false;
            }
            else
            {
                cal003.BackColor = System.Drawing.Color.White;
            }

            if (cal001.Text.ToUpper() == "")
            {
                cal001.BackColor = System.Drawing.Color.Pink;
                sw = false;
            }
            else
            {
                cal001.BackColor = System.Drawing.Color.White;
            }

            if (Txt_nue.Text == "")
            {
                Txt_nue.BackColor = System.Drawing.Color.Pink;
                sw = false;

            }
            else
            {
                Txt_nue.BackColor = System.Drawing.Color.White;

            }
            ////////////////////////////
            if (ddown005g.SelectedItem.Text != " Seleccionar ")
            {
                if (ddown001g.SelectedValue == "0")
                {
                    ddown001g.BackColor = System.Drawing.Color.Pink;
                    sw = false;
                }
                else
                {
                    ddown001g.BackColor = System.Drawing.Color.White;
                }
                if (ddown006g.SelectedValue == "")
                {
                    ddown006g.BackColor = System.Drawing.Color.Pink;
                    sw = false;
                }
                else
                {
                    ddown006g.BackColor = System.Drawing.Color.White;
                }
                if (Txt_orden.Text == "")
                {
                    Txt_orden.BackColor = System.Drawing.Color.Pink;
                    sw = false;
                }
                else
                {
                    Txt_orden.BackColor = System.Drawing.Color.White;
                }
                if (cal002.Text.ToUpper() == "")
                {
                    cal002.BackColor = System.Drawing.Color.Pink;
                    sw = false;
                }
                else
                {
                    cal002.BackColor = System.Drawing.Color.White;
                }


            }
            else
            {
                ddown006g.BackColor = System.Drawing.Color.White;
                ddown001g.BackColor = System.Drawing.Color.White;
                Txt_orden.BackColor = System.Drawing.Color.White;
                cal002.BackColor = System.Drawing.Color.White;
            }




        }

        if (rdo002.Checked)
        {

            if (cal001.Text.ToUpper() == "")
            {
                cal001.BackColor = System.Drawing.Color.Pink;
                sw = false;
            }
            else
            {
                cal001.BackColor = System.Drawing.Color.White;
            }


            if (ddown005g.SelectedItem.Text != " Seleccionar ")
            
            {
                    if (ddown001g.SelectedValue == "0")
                    {
                        ddown001g.BackColor = System.Drawing.Color.Pink;
                        sw = false;
                    }
                    else
                    {
                        ddown001g.BackColor = System.Drawing.Color.White;
                    }
                    if (ddown006g.SelectedValue == "")
                    {
                        ddown006g.BackColor = System.Drawing.Color.Pink;
                        sw = false;
                    }
                    else
                    {
                        ddown006g.BackColor = System.Drawing.Color.White;
                    }
                    if (Txt_orden.Text == "")
                    {
                        Txt_orden.BackColor = System.Drawing.Color.Pink;
                        sw = false;
                    }
                    else
                    {
                        Txt_orden.BackColor = System.Drawing.Color.White; 
                    }
                    if (cal002.Text.ToUpper() == "")
                    {
                        cal002.BackColor = System.Drawing.Color.Pink;
                        sw = false;
                    }
                    else
                    {
                        cal002.BackColor = System.Drawing.Color.White;
                    }


            }
            else
            {
                ddown006g.BackColor = System.Drawing.Color.White;
                ddown001g.BackColor = System.Drawing.Color.White;
                Txt_orden.BackColor = System.Drawing.Color.White;
                cal002.BackColor = System.Drawing.Color.White;
            }
        
        }
        if (rdo003.Checked)
        {

            if (cal001.Text.ToUpper() == "")
            {
                cal001.BackColor = System.Drawing.Color.Pink;
                sw = false;
            }
            else
            {
                cal001.BackColor = System.Drawing.Color.White;
            }

        }

        if (chkNotificacion.Checked)
        {
            if (txtFechaNotificacion.Text.ToUpper() == "")
            {
                txtFechaNotificacion.BackColor = System.Drawing.Color.Pink;
                sw = false;
            }
            else
                txtFechaNotificacion.BackColor = System.Drawing.Color.White;

            if (txtFechaMedicoLegal.Text.ToUpper() == "")
            {
                txtFechaMedicoLegal.BackColor = System.Drawing.Color.Pink;
                sw = false;
            }
            else
                txtFechaMedicoLegal.BackColor = System.Drawing.Color.White;

        }

        return sw;

    }



   
    protected void rdo002_CheckedChanged1(object sender, EventArgs e)
    {
        cal001.Enabled = false;
        rdo002.Checked = true;
        rdo001.Checked = false;
        rdo003.Checked = false;
        Chk001.Checked = false;
        Chk001.Enabled = false;
        Chk002.Enabled = false;
        cal003.Enabled = false;
        cal002.Enabled = true;
        ddown001g.Enabled = true;
        ddown005g.Enabled = true;
        ddown006g.Enabled = true;
        Txt_nue.Enabled = false;
        Txt_orden.Enabled = true;
        imb_nuevo.Enabled = true;

        diagnosticoscoll dcoll = new diagnosticoscoll();
        parcoll par = new parcoll();
        ninocoll ncoll = new ninocoll();
        trabajadorescoll tcoll = new trabajadorescoll();

        DataView dv43 = new DataView(par.GetparTipoTribunalADN());
        ddown001g.Items.Clear();
        ddown001g.DataSource = dv43;
        ddown001g.DataTextField = "Descripcion";
        ddown001g.DataValueField = "TipoTribunal";
        dv43.Sort = "Descripcion";
        ddown001g.DataBind();



        DataView dv44 = new DataView(par.GetparRegion());
        ddown005g.Items.Clear();
        ddown005g.DataSource = dv44;
        ddown005g.DataTextField = "Descripcion";
        ddown005g.DataValueField = "Codregion";
        dv44.Sort = "Codregion";
        ddown005g.DataBind();
      
    }
    protected void rdo003_CheckedChanged(object sender, EventArgs e)
    {
        cal001.Enabled = false;
        rdo002.Checked = false;
        rdo001.Checked = false;
        rdo003.Checked = true;
        Chk001.Checked = false;
        Chk001.Enabled = false;
        Chk002.Enabled = false;
        cal003.Enabled = false;
        cal002.Enabled = false;
        ddown001g.Enabled = false;
        ddown005g.Enabled = false;
        ddown006g.Enabled = false;
        Txt_nue.Enabled = false;
        Txt_orden.Enabled = false;
        imb_nuevo.Enabled = true;
       
    }
    protected void imb_nuevo_Click(object sender, EventArgs e)
    {
        adncolls adnguarga = new adncolls();
        if (ChkSentenciaExpresa.Checked == true)
            valida();

        int Estado = 0;
        int ADN = 0;
        int dactilar = 0;
        int SentenciaExpresa = 0;

        if (rdo001.Checked) Estado = 1;
        if (rdo002.Checked) Estado = 2;
        if (rdo003.Checked) Estado = 3;
        if (Chk001.Checked) ADN = 1;
        if (Chk002.Checked) dactilar = 1;

        if (ChkSentenciaExpresaSI.Checked)
        {
            //  Estado = 4; //Sentencia expresa no es necesario la ADN
            SentenciaExpresa = 1;
        }

        if (valida() == true)
        {
            int Notificacion;
            if (chkNotificacion.Checked) Notificacion = 1; else Notificacion = 0;

            if (chkNotificacion.Checked)
            {
                if (cal001.Text.ToUpper() == "")
                    cal001.Text = DateTime.Now.ToShortDateString();
                if (cal002.Text.ToUpper() == "")
                    cal002.Text = DateTime.Now.ToShortDateString();
            }
            else
            {
                txtFechaNotificacion.Text = Convert.ToDateTime("01-01-1900").ToShortDateString();
                txtFechaMedicoLegal.Text = Convert.ToDateTime("01-01-1900").ToShortDateString();
            }

            if (rdo001.Checked)
            {


                if (ddown006g.SelectedValue == "0")//////LLENARA EN CASO DE NO TRAER DATOS//////////LOS DROP
                {
                    ddown006g.SelectedValue = "0";
                    cal002.Text = DateTime.Now.ToShortDateString();
                    Txt_orden.Text = "0";
                }
                else
                {
                    adncolls adnguar = new adncolls();
                    string tribunal = (Convert.ToString(ddown006g.SelectedItem));
                    DataTable dtguar = adnguar.GetTraeCodTribunal(tribunal);
                    int codtribu = (Convert.ToInt32(dtguar.Rows[0][1]));
                    rdoestado.Text = Convert.ToString(codtribu);
                }



                int bsq2 = Convert.ToInt32(Request.QueryString["CodNino"]);
                int IECOD = Convert.ToInt32(Request.QueryString["delta"]);

                adncolls cod = new adncolls();
                DataTable dt = cod.GetNinoMUESTRA(IECOD);///busca si el niño ya esta en la tabla MUESTRAADN
                int IECOD2 = (Convert.ToInt32(dt.Rows[0][0]));

                if (IECOD2 == 0)
                {//////////AQUI inserta///////////

                    adnguarga.Update_ADN(IECOD

                    , Estado
                    , Convert.ToDateTime(cal001.Text)
                    , ADN
                    , dactilar
                    , Convert.ToDateTime(cal003.Text)
                    , Convert.ToString(Txt_nue.Text)
                        //, codtribu
                    , Convert.ToInt32(rdoestado.Text)
                    , Convert.ToDateTime(cal002.Text)
                    , Convert.ToString(Txt_orden.Text)
                    , Convert.ToInt32(cdtr.Text)
                    , DateTime.Now
                    , Notificacion
                    , Convert.ToDateTime(txtFechaNotificacion.Text)
                    , Convert.ToDateTime(txtFechaMedicoLegal.Text)
                    , Convert.ToInt16(txtHora.Text)
                    , Convert.ToInt16(txtMinuto.Text)
                    , SentenciaExpresa);

                }/////////////SI NO DEBE updatea//////////
                else
                {
                    if (ChkSentenciaExpresa.Checked) cal001.Text = DateTime.Now.ToShortDateString();

                    adnguarga.Insert_ADN(IECOD

                    , Estado
                    , Convert.ToDateTime(cal001.Text)
                    , ADN
                    , dactilar
                    , Convert.ToDateTime(cal003.Text)
                    , Convert.ToString(Txt_nue.Text)
                     , Convert.ToInt32(rdoestado.Text)
                    , Convert.ToDateTime(cal002.Text)
                    , Convert.ToString(Txt_orden.Text)
                    , Convert.ToInt32(cdtr.Text)
                    , DateTime.Now
                    , Convert.ToDateTime(txtFechaMedicoLegal.Text)
                    , Convert.ToInt32(txtHora.Text)
                    , Convert.ToInt32(txtMinuto.Text)
                    , SentenciaExpresa);
                }


                if (Estado == 1)
                {
                    int codn = Convert.ToInt32(Request.QueryString["CodNino"]);
                    adnguarga.Update_NinosADN(codn
                   , 1
                   );

                    int cod1 = Convert.ToInt32(Request.QueryString["codp"]);
                    int CodInst = Convert.ToInt32(Request.QueryString["codi"]);
                    string vsdir = Convert.ToString(Request.QueryString["vdir"]);


                    //Response.Write("<script language='JavaScript'>var url = '" + vsdir + "?sw=4&codinst=" + cod1 + "&codproy=" + CodInst + "';");
                    //Response.Write("window.opener.location = url;");
                    //Response.Write("self.close();");
                    //Response.Write("</script>");
                    ////ClientScript.RegisterClientScriptBlock(typeof(string), "SENAINFO2", "<script  languaje=javascript> window.opener.__doPostBack('btnbind',''); </script>");
                    //window.close(this.Page);

                }
                else
                {
                    int cod2 = Convert.ToInt32(Request.QueryString["codp"]);
                    int CodInst = Convert.ToInt32(Request.QueryString["codi"]);
                    string vsdir = Convert.ToString(Request.QueryString["vdir"]);

                    //Response.Write("<script language='JavaScript'>var url = '" + vsdir + "?sw=4&codinst=" + cod2 + "&codproy=" + CodInst + "';");
                    //Response.Write("window.opener.location = url;");
                    //Response.Write("self.close();");
                    //Response.Write("</script>");

                    ////ClientScript.RegisterClientScriptBlock(typeof(string), "SENAINFO2", "<script  languaje=javascript> window.opener.__doPostBack('btnbind',''); </script>");
                    //window.close(this.Page);
                }

                if (IECOD2 == 0)
                {

                    window.alert(this, "Muestra de ADN Ingresada Satisfactoriamente.");
                }
                else
                {
                    window.alert(this, "Muestra de ADN Actualizada Satisfactoriamente.");
                    

                }

                int cod3 = Convert.ToInt32(Request.QueryString["codp"]);
                int CodInst2 = Convert.ToInt32(Request.QueryString["codi"]);
                string vsdir2 = Convert.ToString(Request.QueryString["vdir"]);
                string url = vsdir2 + "?sw=4&codinst=" + cod3 + "&codproy=" + CodInst2;
                ClientScript.RegisterStartupScript(this.GetType(), "", "AbrirURLModalPopUp('" + url + "');", true);
                


            }
            else
            {
                int bsq2 = Convert.ToInt32(Request.QueryString["CodNino"]);
                //adncolls adnIE = new adncolls();
                //DataTable dtIE = adnIE.GetTraeICodIE(bsq2);
                int IECOD = Convert.ToInt32(Request.QueryString["delta"]);


                adncolls cod = new adncolls();
                DataTable dt = cod.GetNinoMUESTRA(IECOD);///busca si el niño ya esta en la tabla MUESTRAADN
                int IECOD2 = (Convert.ToInt32(dt.Rows[0][0]));

                /////////AQUI ENTRA CUANDO NO ESTA EN LA TABLA MUESTRA DE ADN E INSERTA/////////
                if (IECOD2 == 0)
                {

                    if (ChkSentenciaExpresa.Checked) cal001.Text = DateTime.Now.ToShortDateString();

                    if (ddown006g.SelectedValue == "0")//////LLENARA EN CASO DE NO TRAER DATOS//////////LOS DROP
                    {
                        ddown006g.SelectedValue = "0";
                        cal002.Text = DateTime.Now.ToShortDateString();
                        Txt_orden.Text = "0";
                        rdoestado.Text = "0";
                    }
                    else
                    {
                        adncolls adnguar = new adncolls();
                        string tribunal = (Convert.ToString(ddown006g.SelectedItem));
                        DataTable dtguar = adnguar.GetTraeCodTribunal(tribunal);
                        int codtribu = (Convert.ToInt32(dtguar.Rows[0][1]));
                        rdoestado.Text = Convert.ToString(codtribu);
                        if (ChkSentenciaExpresa.Checked) cal001.Text = DateTime.Now.ToShortDateString();
                    }

                    adnguarga.Update_ADN(IECOD, Estado, Convert.ToDateTime(cal001.Text), ADN, dactilar
                    , Convert.ToDateTime("01-01-1900"), Convert.ToString(0) //, 0
                    , Convert.ToInt32(rdoestado.Text), Convert.ToDateTime(cal002.Text)
                    , Convert.ToString(Txt_orden.Text)
                        //, 0
                        //, Convert.ToDateTime("01-01-1900")
                        //, Convert.ToString(0)
                    , Convert.ToInt32(cdtr.Text), DateTime.Now, Notificacion
                    , Convert.ToDateTime(txtFechaNotificacion.Text), Convert.ToDateTime(txtFechaMedicoLegal.Text)
                    , Convert.ToInt16(txtHora.Text), Convert.ToInt16(txtMinuto.Text)
                    , SentenciaExpresa);

                    int cod4 = Convert.ToInt32(Request.QueryString["codp"]);
                    int CodInst = Convert.ToInt32(Request.QueryString["codi"]);
                    string vsdir = Convert.ToString(Request.QueryString["vdir"]);

                    //Response.Write("<script language='JavaScript'>var url = '" + vsdir + "?sw=4&codinst=" + cod4 + "&codproy=" + CodInst + "';");
                    //Response.Write("window.opener.location = url;");
                    //Response.Write("self.close();");
                    //Response.Write("</script>");

                    //window.close(this.Page);

                    window.alert(this, "Muestra de ADN Actualizada Satisfactoriamente.");

                    string url = vsdir + "?sw=4&codinst=" + cod4 + "&codproy=" + CodInst;
                    
                    ClientScript.RegisterStartupScript(this.GetType(), "","AbrirURLModalPopUp('"+url+"');"  , true);
                    
                    
                }
                else
                {
                    if (ChkSentenciaExpresa.Checked) cal001.Text = DateTime.Now.ToShortDateString();

                    if (ddown006g.SelectedValue == "0")//////LLENARA EN CASO DE NO TRAER DATOS//////////LOS DROP
                    {
                        ddown006g.SelectedValue = "0";
                        cal002.Text = DateTime.Now.ToShortDateString();
                        Txt_orden.Text = "0";
                        rdoestado.Text = "0";
                    }
                    else
                    {
                        adncolls adnguar = new adncolls();
                        string tribunal = (Convert.ToString(ddown006g.SelectedItem));
                        DataTable dtguar = adnguar.GetTraeCodTribunal(tribunal);
                        int codtribu = (Convert.ToInt32(dtguar.Rows[0][1]));
                        rdoestado.Text = Convert.ToString(codtribu);
                    }
                    adnguarga.Insert_ADN( IECOD
                    , Estado
                    , Convert.ToDateTime(cal001.Text)
                    , ADN
                    , dactilar
                    , Convert.ToDateTime("01-01-1900")
                    , Convert.ToString(0)
                    , Convert.ToInt32(rdoestado.Text)
                    , Convert.ToDateTime(cal002.Text)
                    , Convert.ToString(Txt_orden.Text)
                        //, 0
                        //, Convert.ToDateTime("01-01-1900")
                        //, Convert.ToString(0)
                    , Convert.ToInt32(cdtr.Text)
                    , DateTime.Now, Convert.ToDateTime(txtFechaMedicoLegal.Text)
                    , Convert.ToInt16(txtHora.Text), Convert.ToInt16(txtMinuto.Text)
                    , SentenciaExpresa);

                    int cod5 = Convert.ToInt32(Request.QueryString["codp"]);
                    int CodInst = Convert.ToInt32(Request.QueryString["codi"]);
                    string vsdir = Convert.ToString(Request.QueryString["vdir"]);

                    //Response.Write("<script language='JavaScript'>var url = '" + vsdir + "?sw=4&codinst=" + cod5 + "&codproy=" + CodInst + "';");
                    //Response.Write("window.opener.location = url;");
                    //Response.Write("self.close();");
                    //Response.Write("</script>");
                    ////ClientScript.RegisterClientScriptBlock(typeof(string), "SENAINFO2", "<script  languaje=javascript> window.opener.__doPostBack('btnbind',''); </script>");
                    //window.close(this.Page);

                   
                    window.alert(this, "Muestra de ADN Ingresada Satisfactoriamente.");

                    string url = vsdir + "?sw=4&codinst=" + cod5 + "&codproy=" + CodInst;
                    ClientScript.RegisterStartupScript(this.GetType(), "", "AbrirURLModalPopUp('" + url + "');", true);
                }

                
            }
        }
        else
        {
        }
    }
    protected void ddown005g_SelectedIndexChanged(object sender, EventArgs e)
    {

      
            

    }
    protected void ddown006g_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        if (rdo002.Checked)
        {
            cal003.Enabled = false;
            Chk001.Enabled = false;
            Chk001.Checked = false;
            Chk002.Enabled = false;
            Txt_nue.Enabled = false;
        }
        else
        {
            rdo001.Checked = true;
            rdo003.Checked = false;
            cal003.Enabled = true;
        }
       
    }
    protected void ddown001g_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdo002.Checked)
        {
            cal003.Enabled = false;
            Chk001.Enabled = false;
            Chk001.Checked = false;
            Chk002.Enabled = false;
            Txt_nue.Enabled = false;
        }
        else
        {
            cal003.Enabled = true;
        }

        int TipoTribunal = Convert.ToInt32(ddown001g.SelectedValue);
        int CodRegion = Convert.ToInt32(ddown005g.SelectedValue);

        parcoll par = new parcoll();
        DataView dv39 = new DataView(par.GetparTribunalesHechosJudiciales(TipoTribunal, CodRegion));
        
        ddown006g.Items.Clear();
        ddown006g.DataSource = dv39;
        ddown006g.DataTextField = "Descripcion";
        ddown006g.DataValueField = "CodTribunal";
        dv39.Sort = "CodTribunal";
        ddown006g.DataBind();
        rdo001.Checked = true;
        rdo003.Checked = false;
        
   
       
    }
    protected void chkNotificacion_CheckedChanged(object sender, EventArgs e)
    {
        rdo003_CheckedChanged(sender, e);
        rdo003.Checked = false;
        
        rdo001.Enabled = !chkNotificacion.Checked;
        rdo002.Enabled = !chkNotificacion.Checked;
        rdo003.Enabled = !chkNotificacion.Checked;
        imb_nuevo.Enabled = chkNotificacion.Checked;
        txtFechaMedicoLegal.Enabled = chkNotificacion.Checked;
        txtFechaNotificacion.Enabled = chkNotificacion.Checked;
        txtHora.Enabled = chkNotificacion.Checked;
        txtMinuto.Enabled = chkNotificacion.Checked;
    }
    protected void txtFechaNotificacion_ValueChanged(object sender, EventArgs e)
    {
        CalendarExtende653.StartDate = Convert.ToDateTime(txtFechaNotificacion.Text);
    }
    protected void ChkSentenciaExpresa_CheckedChanged(object sender, EventArgs e)
    {
        SentenciaExpresa(0);
        rdo003_CheckedChanged(sender, e);
    }
    protected void Chk001_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void ChkSentenciaExpresaSI_CheckedChanged(object sender, EventArgs e)
    {
        SentenciaExpresa(1);
    }
    protected void SentenciaExpresa(int SiNo)
    {
        if (SiNo == 1)
        {
            imb_nuevo.Enabled = false;
            rdo001.Enabled = true;
            rdo002.Enabled = true;
            rdo003.Enabled = true;

            ChkSentenciaExpresaSI.Checked = true; // CET
            ChkSentenciaExpresa.Checked = false;
            chkNotificacion.Enabled = true;
        }
        else
        {
            //imb_nuevo.Enabled = ChkSentenciaExpresa.Checked;
            //rdo001.Enabled = !ChkSentenciaExpresa.Checked;
            //rdo002.Enabled = !ChkSentenciaExpresa.Checked;
            //rdo003.Enabled = !ChkSentenciaExpresa.Checked;
            imb_nuevo.Enabled = true;
            rdo001.Enabled = false;
            rdo002.Enabled = false;
            rdo003.Enabled = false;

            rdo001.Checked = false;
            rdo002.Checked = false;
            rdo003.Checked = false;

            cal001.Enabled = false;
            ChkSentenciaExpresa.Checked = true; // CET
            ChkSentenciaExpresaSI.Checked = false;
            chkNotificacion.Enabled = false;
        }
    }

    protected void rv_fecha_Init(object sender, EventArgs e)
    {
        ((RangeValidator)sender).MaximumValue = DateTime.Today.ToString("dd-MM-yyyy");
        ((RangeValidator)sender).MinimumValue = "01-01-1900";

    }

}
