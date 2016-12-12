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


public partial class mod_coordinador_ingresonuevo : System.Web.UI.Page
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

    public Madre SSmadre
    {
        get
        {
            if (Session["neo_SSmadre"] == null)
            { Session["neo_SSmadre"] = new Madre(); }
            return (Madre)Session["neo_SSmadre"];
        }
        set { Session["neo_SSmadre"] = value; }

    }
    public int VCod_PersonaRelacionada
    {
        get
        {
            if (ViewState["Cod_PersonaRelacionada"] == null)
            { ViewState["Cod_PersonaRelacionada"] = -1; }
            return Convert.ToInt32(ViewState["Cod_PersonaRelacionada"]);
        }
        set { ViewState["Cod_PersonaRelacionada"] = value; }
    }

    //public String Rut
    //{
    //    get { return (String)Session["Rut"]; }
    //    set { Session["Rut"] = value; }
    //}
    //public String Nombres
    //{
    //    get { return (String)Session["Nombres"]; }
    //    set { Session["Nombres"] = value; }
    //}
    //public String ApePat
    //{
    //    get { return (String)Session["ApePat"]; }
    //    set { Session["ApePat"] = value; }
    //}
    //public String ApeMat
    //{
    //    get { return (String)Session["ApeMat"]; }
    //    set { Session["ApeMat"] = value; }
    //}

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getdata();

            
            
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
    private void getdata()
    {
        parcoll par = new parcoll();
        trabajadorescoll tcoll = new trabajadorescoll();

        DataView dv1 = new DataView(par.GetparNacionalidades());
        ddown001.DataSource = dv1;
        ddown001.DataTextField = "Descripcion";
        ddown001.DataValueField = "CodNacionalidad";
        dv1.Sort = "CodNacionalidad";
        ddown001.DataBind();

       

        //cal001.MaxDate = DateTime.Now;
    }
   
       


    
    //protected void btn001_Click(object sender, EventArgs e)
    //{
     
        
        
    //    string sexo = "M";
       
    //    int nacionalidad = 0;
    //    if(rdo001.Checked)
    //    { sexo= "F";}
      
    //    if (Convert.ToInt32(ddown001.SelectedValue) > 0)
    //    {
    //        nacionalidad = Convert.ToInt32(ddown001.SelectedValue); 
    //    }
                
    //    ninocoll ncoll = new ninocoll();
     
            
    //            if (validate())
    //            {
    //                if (txt003.Text.Trim() == "")
    //                {
    //                    txt003.Text = "N.N. PATERNO";
    //                }

    //                int iden = ncoll.Insert_Ninos(DateTime.Now, false, txt001.Text,
    //                  sexo, txt002.Text.ToUpper(), txt003.Text.ToUpper(), txt004.Text.ToUpper(), Convert.ToDateTime(cal001.Value),
    //                  Convert.ToInt32(ddown001.SelectedValue), 0, "0", 0, "0", "0", false, false, false, "N",
    //                  DateTime.Now, Convert.ToInt32(Session["IdUsuario"]));

    //                SSnino.CodNino = iden;

    //                SSnino.FechaNacimiento = Convert.ToDateTime(cal001.Value);


    //                ClientScript.RegisterClientScriptBlock(typeof(string), "SENAINFO2", "<script  languaje=javascript> window.opener.document.location.href = 'ingreso_coordinadores.aspx?CODNUEVO= " + iden + "' </script>");
    //                window.close(this);
    //            }
    //}

    private int CodInmueble()
    {
        ninocoll ncoll = new ninocoll();
        int codinmueble = ncoll.CodInmueble(SSnino.CodProyecto);

        return codinmueble;    

    }

   private bool validate()
    {
        bool v = true;


        if (txt001.Text.Trim().Length < 4 && !chk001.Checked )
        {
            txt001.BackColor = System.Drawing.Color.Pink;
            v = false;            
        }
        if (!rdo001.Checked && !rdo002.Checked)
        {
            rdo001.BackColor = System.Drawing.Color.Pink;
            rdo002.BackColor = System.Drawing.Color.Pink;
            v = false;
        }
        else
        {
            rdo001.BackColor = System.Drawing.Color.White;
            rdo002.BackColor = System.Drawing.Color.White;
        }
        if (Convert.ToInt32(ddown001.SelectedValue) == 0 )
        {
            ddown001.BackColor = System.Drawing.Color.Pink;
            v = false;
        }

        if ( txt002.Text.Trim().Length < 2)
        {
            txt002.BackColor = System.Drawing.Color.Pink;
            v = false;    
        }

        if (txt004.Text.Trim().Length < 2)
        {
            txt004.BackColor = System.Drawing.Color.Pink;
            v = false;
        }
        
       

        return v;
        
    }

   
    protected void chk001_CheckedChanged(object sender, EventArgs e)
    {
        txt001.Enabled = !chk001.Checked;
    }
   

    //protected void txt001_ValueChange(object sender, EventArgs e)
    //{

    //    bool sw = false;
    //    try
    //    {
    //        if (txt001.Text.Length > 3)
    //        {
    //            string rutsinnada = txt001.Text.Replace(".", "").Replace(",", "").Replace("-", "").Trim();
    //            string digitoingresado = rutsinnada.Substring(rutsinnada.Length - 1, 1);

    //            string digitocalculado = digitoVerificador(Convert.ToInt32(rutsinnada.ToUpper().Replace("K", "").Substring(0, rutsinnada.Length - 1)));
    //            if (digitocalculado.ToUpper() == digitoingresado.ToUpper())
    //            {
    //                this.Form.FindControl("pnl003").Visible = false;
    //                string punorut = rutsinnada.ToUpper().Replace("K", "").Substring(0, rutsinnada.Length - 1).Trim();
    //                string rcompleto = punorut + "-" + digitocalculado.ToUpper();
    //                txt001.Text = rcompleto;
    //                sw = true;

    //            }
    //            else
    //            {
    //                txt001.Text = "";
    //                ((Label)Form.FindControl("lbl004")).Text = "RUT INGRESADO NO ES VALIDO";
    //                this.Form.FindControl("pnl003").Visible = true;
    //            }

    //        }
    //        else
    //        {
    //            txt001.Text = "";
    //            ((Label)Form.FindControl("lbl004")).Text = "RUT INGRESADO NO ES VALIDO";
    //            this.Form.FindControl("pnl004").Visible = true;
    //        }
    //    }
    //    catch
    //    {
    //        ((Label)Form.FindControl("lbl004")).Text = "RUT INGRESADO NO ES VALIDO";
    //        this.Form.FindControl("pnl003").Visible = true;
    //    }
    //    try { 
    //             if (txt001.Text.Length > 3 && sw == true)
    //        {
    //                 ninocoll ncoll = new ninocoll();
    //                 bool ExisteRut = ncoll.ConsultaRutnino(txt001.Text);
    //                 if (ExisteRut == true)
    //                 {
    //                     lblexrut.Text = "Este rut existe en la red";
    //                     lblexrut.Visible = true;
    //                     Function_Genera_String_Consulta(txt001.Text);
    //                 }
    //                 else 
    //                 {
    //                     lblexrut.Text = "Este rut existe en la red";
    //                     lblexrut.Visible = false;
                     
    //                 }

    //        }
    //        }
    //    catch { }
    //}
    private void Function_Genera_String_Consulta(string sParametrosConsulta)
    {
        ninocoll nic = new ninocoll();
        DataTable dt = nic.callto_get_ninoxrut(sParametrosConsulta);
        if (dt.Rows.Count > 0 )
        {
            grd003.DataSource = dt;
            grd003.DataBind();
            grd003.Visible = true;
            pnl005.Visible = false;
            pnl006.Visible = true;
        }
       


    }
   
    //protected void btn004_Click(object sender, EventArgs e)
    //{
    //    int iden = Convert.ToInt32(grd003.Rows[0].Cells[0].Text);
    //    ninocoll nin = new ninocoll();
    //    int EstadoIE = nin.Get_EstadoIExNino(iden, SSnino.CodProyecto);

    //    if (EstadoIE == 0)
    //    {
    //        ClientScript.RegisterClientScriptBlock(typeof(string), "SENAINFO2", "<script  languaje=javascript> alert('EL niño ya ha sido ingresado.'); </script>");
    //    }
    //    else
    //    {
    //        ClientScript.RegisterClientScriptBlock(typeof(string), "SENAINFO2", "<script  languaje=javascript> window.opener.document.location.href = 'ninos_index.aspx?CODNUEVO= " + iden + "' </script>");
    //    }
    //    window.close(this);
    //}
    //protected void btn005_Click(object sender, EventArgs e)
    //{
    //    window.close(this.Page);
    //}
    protected void txt001_ValueChange(object sender, EventArgs e)
    {
        bool sw = false;
        try
        {
            if (txt001.Text.Length > 3)
            {
                string rutsinnada = txt001.Text.Replace(".", "").Replace(",", "").Replace("-", "").Trim();
                string digitoingresado = rutsinnada.Substring(rutsinnada.Length - 1, 1);

                string digitocalculado = digitoVerificador(Convert.ToInt32(rutsinnada.ToUpper().Replace("K", "").Substring(0, rutsinnada.Length - 1)));
                if (digitocalculado.ToUpper() == digitoingresado.ToUpper())
                {
                    this.Form.FindControl("pnl003").Visible = false;
                    string punorut = rutsinnada.ToUpper().Replace("K", "").Substring(0, rutsinnada.Length - 1).Trim();
                    string rcompleto = punorut + "-" + digitocalculado.ToUpper();
                    txt001.Text = rcompleto;
                    sw = true;

                }
                else
                {
                    txt001.Text = "";
                    ((Label)Form.FindControl("lbl004")).Text = "RUT INGRESADO NO ES VALIDO";
                    this.Form.FindControl("pnl003").Visible = true;
                }

            }
            else
            {
                txt001.Text = "";
                ((Label)Form.FindControl("lbl004")).Text = "RUT INGRESADO NO ES VALIDO";
                this.Form.FindControl("pnl004").Visible = true;
            }
        }
        catch
        {
            ((Label)Form.FindControl("lbl004")).Text = "RUT INGRESADO NO ES VALIDO";
            this.Form.FindControl("pnl003").Visible = true;
        }
        try
        {
            if (txt001.Text.Length > 3 && sw == true)
            {
                ninocoll ncoll = new ninocoll();
                bool ExisteRut = ncoll.ConsultaRutnino(txt001.Text);
                if (ExisteRut == true)
                {
                    lblexrut.Text = "Este rut existe en la red";
                    lblexrut.Visible = true;
                    Function_Genera_String_Consulta(txt001.Text);
                }
                else
                {
                    lblexrut.Text = "Este rut existe en la red";
                    lblexrut.Visible = false;

                }

            }
        }
        catch { }
    }
    protected void btn001_Click(object sender, EventArgs e)
    {
        string sexo = "M";

        int nacionalidad = 0;
        if (rdo001.Checked)
        { sexo = "F"; }

        if (Convert.ToInt32(ddown001.SelectedValue) > 0)
        {
            nacionalidad = Convert.ToInt32(ddown001.SelectedValue);
        }

        ninocoll ncoll = new ninocoll();


        if (validate())
        {
            if (txt003.Text.Trim() == "")
            {
                txt003.Text = "N.N. PATERNO";
            }

            int iden = ncoll.Insert_Ninos(DateTime.Now, false, txt001.Text,
              sexo, txt002.Text.ToUpper(), txt003.Text.ToUpper(), txt004.Text.ToUpper(), Convert.ToDateTime(cal001.Text),
              Convert.ToInt32(ddown001.SelectedValue), 0, "0", 0, "0", "0", false, false, false, "N",
              DateTime.Now, Convert.ToInt32(Session["IdUsuario"]),0);

            SSnino.CodNino = iden;

            SSnino.FechaNacimiento = Convert.ToDateTime(cal001.Text);


            ClientScript.RegisterClientScriptBlock(typeof(string), "SENAINFO2", "<script  languaje=javascript> window.opener.document.location.href = 'ingreso_coordinadores.aspx?CODNUEVO= " + iden + "' </script>");
            window.close(this);
        }
    }
    protected void btn004_Click(object sender, EventArgs e)
    {
        int iden = Convert.ToInt32(grd003.Rows[0].Cells[0].Text);
        ninocoll nin = new ninocoll();
        int EstadoIE = nin.Get_EstadoIExNino(iden, SSnino.CodProyecto);

        if (EstadoIE == 0)
        {
            ClientScript.RegisterClientScriptBlock(typeof(string), "SENAINFO2", "<script  languaje=javascript> alert('EL niño ya ha sido ingresado.'); </script>");
        }
        else
        {
            ClientScript.RegisterClientScriptBlock(typeof(string), "SENAINFO2", "<script  languaje=javascript> window.opener.document.location.href = 'ninos_index.aspx?CODNUEVO= " + iden + "' </script>");
        }
        window.close(this);
    }
    protected void btn005_Click(object sender, EventArgs e)
    {
        window.close(this.Page);
    }
}
