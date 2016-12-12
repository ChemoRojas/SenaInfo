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
using System.Collections.Generic;
using System.Data.SqlClient;

public partial class mod_ninos_ingreso_adulto : System.Web.UI.Page
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
    public int Cod_Interv
    {
        get { return (int)Session["Cod_Interv"]; }
        set { Session["Cod_Interv"] = value; }
    }

    public int per_rel_1
    {
        get { return (int)Session["per_rel_1"]; }
        set { Session["per_rel_1"] = value; }
    }
    public int per_rel_2
    {
        get { return (int)Session["per_rel_2"]; }
        set { Session["per_rel_2"] = value; }
    }

    public int n_nino_ing
    {
        get { return (int)Session["n_nino_ing"]; }
        set { Session["n_nino_ing"] = value; }
    }
    public int Cod_IE_Gen
    {
        get { return (int)Session["Cod_IE_Gen"]; }
        set { Session["Cod_IE_Gen"] = value; }
    }
    public int cod_prog
    {
        get { return (int)Session["cod_prog"]; }
        set { Session["cod_prog"] = value; }
    }
    public int tipo
    {
        get { return (int)Session["tipo"]; }
        set { Session["tipo"] = value; }
    }
    public int tipo_inter
    {
        get { return (int)Session["tipo_inter"]; }
        set { Session["tipo_inter"] = value; }
    }

    


    public string sexo
    {
        get { return (string)Session["sexo"]; }
        set { Session["sexo"] = value; }
    }
    public bool chk_box
    {
        get { return (bool)Session["chk_box"]; }
        set { Session["chk_box"] = value; }
    }

      public int retorno_val
    {
        get 
        {
            if (ViewState["retorno_val"] == null)
            { ViewState["retorno_val"] = -1; }
            return Convert.ToInt32(ViewState["retorno_val"]);
        }
        set { ViewState["retorno_val"] = value; }
    }

      public int codModeloIntervencion
      {
          get { return (int)ViewState["codModeloIntervencion"]; }
          set { ViewState["codModeloIntervencion"] = value; }
      }
    protected void Page_Load(object sender, EventArgs e)
    {
        //Ajax.Utility.RegisterTypeForAjax(typeof(mod_ninos_ingreso_adulto));
        if (!IsPostBack)
        {
            int codproy = Convert.ToInt32(SSnino.CodProyecto);
            LRPAcoll codmod = new LRPAcoll();
            DataTable dt2 = codmod.GetCodModIntervencion(codproy);
            codModeloIntervencion = Convert.ToInt32(dt2.Rows[0][0]);

            if (codModeloIntervencion == 132)
            {
                rd_PAF.Checked = false;
                rd_PES.Checked = true;
                rd_PAF.Visible = false;

                cod_prog = 2;

                cambio_estado_inicial(sender, e);
                pnl_02.Visible = false;

                lblTitulo.Text = "Ingreso a SubProgramas Solicitantes";
                lblSubTituloDatosUsuario.Text = "Datos Usuario SubProgramas Solicitantes";
                //lblSubtitulo2.Text = "Ingreso a SubProgramas Solicitantes";
            }
            
        
        }
        datos_gral();
        CalendarExtende618.EndDate = DateTime.Now;
        //cal_3.MaxDate = DateTime.Now;
            if (rd_PAF.Checked)
        {
            ddown_tuser2.AutoPostBack = true;
            txt_materno2.AutoPostBack = true;
            lbl_info1.Visible = true;
            div_alert.Visible = true;
            lbl_info1.Text = "Para Ingresar Usuario (2), debe seleccionar Tipo Usuario";
        }
        else
        {
            lbl_info1.Visible = false;
            div_alert.Visible = false;
            lbl_info1.Text = "";
            ddown_tuser2.AutoPostBack = true;
        }

        if (rd_PAF.Checked == true || rd_PES.Checked == true)
        {
            btnnext004.Attributes.Remove("disabled");
        }

            

    }

    #region LIMPIA PANELES

    private void limpia_panel1()
    {
        ddown_tuser01.SelectedValue = "0";
        txt_materno1.Text = "";
        txt_paterno1.Text = "";
        ddown_nac1.SelectedValue = "-1";
        txt_nombre1.Text = "";        
        cal_1.Text = Convert.ToString("");
        txt_rut1.Text = "";

    }

    private void limpia_panel3()
    {
       
        ddown_region.SelectedValue = "-2";
        //ddown_comuna.SelectedItem = "0";
        txt_nom_gen.Text = "";
        txt_pat_gen.Text = "";
        txt_mat_gen.Text = "";
        cal_3.Text = Convert.ToString("");
        dd_prueba.SelectedValue = "-2";
        ddown_comuna.SelectedValue = "-2";

    }

    private void limpia_panel2()
    {
        ddown_tuser2.SelectedValue = "0";
        txt_materno2.Text = "";
        txt_paterno2.Text = "";
        ddown_nac2.SelectedValue = "-1";
        txt_nombre2.Text = "";
        cal_2.Text = Convert.ToString("");
        txt_rut2.Text = "";

    }

    #endregion LIMPIA PANELES

   

    private void datos_gral()
    {
        if (rd_PAF.Checked == true)
        { cod_prog = 1; }
        if (rd_PES.Checked == true)
        { cod_prog = 2; }
        if ((rd_PAF.Checked != false) || (rd_PES.Checked != false))
        {
            ninocoll cons = new ninocoll();
            DataTable dt = cons.consulta_Adopcion_Tipo_Usuario(cod_prog);
        }
    
    }
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
   
    }
    protected void cambio_estado_inicial(object sender, EventArgs e)
    {
        ninocoll cons = new ninocoll();
        DataTable dt = cons.consulta_Adopcion_Tipo_Usuario(cod_prog);
        parcoll par = new parcoll();
         
        if (rd_PAF.Checked)
        {
            btnnext004.Attributes.Remove("disabled");
            limpia_panel1();
            limpia_panel2();
            limpia_panel3();
            pnl_01.Enabled = true;
            pnl_03.Enabled = true;
            pnl_02.Enabled = true;
            ddown_tuser01.Items.Clear();
            ddown_tuser01.DataSource = dt;
            ddown_tuser01.DataValueField = "codtipousuario";
            ddown_tuser01.DataTextField = "descripcion";
            ddown_tuser01.DataBind();
            lbl_usuario2.Visible = true;
            lbl_usuario2.Text = "* NO OBLIGATORIA PARA FLIA ORIGEN *";


            ddown_tuser2.Items.Clear();
            ddown_tuser2.DataSource = dt;
            ddown_tuser2.DataValueField = "codtipousuario";
            ddown_tuser2.DataTextField = "descripcion";
            ddown_tuser2.DataBind();


        }
        if (rd_PES.Checked)
        {
            btnnext004.Attributes.Remove("disabled");
            limpia_panel1();
            limpia_panel2();
            limpia_panel3();
            pnl_01.Enabled = true;
            pnl_02.Enabled = false;
            pnl_03.Enabled = true;
            lbl_usuario2.Visible = false;
            lbl_usuario2.Text = "";
           
            ddown_tuser01.Items.Clear();
            ddown_tuser01.DataSource = dt;
            ddown_tuser01.DataValueField = "codtipousuario";
            ddown_tuser01.DataTextField = "descripcion";
            ddown_tuser01.DataBind();

            ddown_tuser2.Items.Clear();
            ddown_tuser2.DataSource = dt;
            ddown_tuser2.DataValueField = "codtipousuario";
            ddown_tuser2.DataTextField = "descripcion";
            ddown_tuser2.DataBind();

        }

        DataView dv2 = new DataView((GetParTipoNacionalidad()));
        ddown_tipo_nacionalidad1.DataSource = dv2;
        ddown_tipo_nacionalidad1.DataTextField = "Descripcion";
        ddown_tipo_nacionalidad1.DataValueField = "CodTipoNacionalidad";
        dv2.Sort = "CodTipoNacionalidad";
        ddown_tipo_nacionalidad1.DataBind();

        ddown_tipo_nacionalidad2.DataSource = dv2;
        ddown_tipo_nacionalidad2.DataTextField = "Descripcion";
        ddown_tipo_nacionalidad2.DataValueField = "CodTipoNacionalidad";
        dv2.Sort = "CodTipoNacionalidad";
        ddown_tipo_nacionalidad2.DataBind();


        ninocoll cons2 = new ninocoll();
        DataTable dt2 = cons2.consulta_Nacionalidad_Adulto();
        ddown_nac1.Items.Clear();
        ddown_nac1.DataSource = dt2;
        ddown_nac1.DataValueField = "codnacionalidad";
        ddown_nac1.DataTextField = "descripcion";
        ddown_nac1.DataBind();

        ddown_nac2.Items.Clear();
        ddown_nac2.DataSource = dt2;
        ddown_nac2.DataValueField = "codnacionalidad";
        ddown_nac2.DataTextField = "descripcion";
        ddown_nac2.DataBind();


        for (int i = 1; i <= ddown_nac1.Items.Count; i++)
        {
            if (ddown_nac1.Items.FindByValue(Convert.ToString(i)) != null) // el 8 no existe
            {
                ddown_nac1.Items.FindByValue(Convert.ToString(i)).Enabled = false;

            }
        }

        for (int i = 1; i <= ddown_nac2.Items.Count; i++)
        {
            if (ddown_nac2.Items.FindByValue(Convert.ToString(i)) != null) // el 8 no existe
            {
                ddown_nac2.Items.FindByValue(Convert.ToString(i)).Enabled = false;

            }
        }
        


        ninocoll cons3 = new ninocoll();
        DataTable dt3 = cons3.consulta_region_adulto();

        ddown_region.Items.Clear();
        ddown_region.DataSource = dt3;
        ddown_region.DataValueField = "codregion";
        ddown_region.DataTextField = "descripcion";
        ddown_region.DataBind();

        int codproyecto = Convert.ToInt32(Request.QueryString["codproy"]);
       
        ninocoll cons4 = new ninocoll();
        DataTable dt4 = cons4.consulta_DATOSPROYECTO_Adulto(codproyecto, codModeloIntervencion);
        DataView dv = new DataView(dt4);
        dv.Sort = "icot";
        dd_prueba.Items.Clear();
        dd_prueba.DataSource = dv;
        dd_prueba.DataValueField = "icot";
        dd_prueba.DataTextField = "Nombre";                   
        dd_prueba.DataBind();
        //dd_prueba.Items.Add(new ListItem("Seleccionar", "-2")); 
        

    }
    protected void txt_rut1_TextChanged(object sender, EventArgs e)
    {

    }
    #region CONSULTA RUT EN LA RED
    private void Function_Genera_String_Consulta(string sParametrosConsulta)
    {
        ninocoll nic = new ninocoll();
        DataTable dt = nic.callto_get_ninoxrut(sParametrosConsulta);
    }
    #endregion

    #region DIGITO VERIFICADOR
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
    #endregion

    #region VALIDA RUT 1
//    [Ajax.AjaxMethod]
    //public void rut_01()
    //    {

    //        bool sw = false;
    //        try
    //        {
    //            if (txt_rut1.Text.Length > 3)
    //            {
    //                string rutsinnada = txt_rut1.Text.Replace(".", "").Replace(",", "").Replace("-", "").Trim();
    //                string digitoingresado = rutsinnada.Substring(rutsinnada.Length - 1, 1);

    //                string digitocalculado = digitoVerificador(Convert.ToInt32(rutsinnada.ToUpper().Replace("K", "").Substring(0, rutsinnada.Length - 1)));
    //                if (digitocalculado.ToUpper() == digitoingresado.ToUpper())
    //                {

    //                    string punorut = rutsinnada.ToUpper().Replace("K", "").Substring(0, rutsinnada.Length - 1).Trim();
    //                    if (punorut.Length == 7)
    //                    {
    //                        punorut = "0" + punorut;
    //                    }
    //                    string rcompleto = punorut + "-" + digitocalculado.ToUpper();
    //                    txt_rut1.Text = rcompleto;
    //                    sw = true;
    //                    lbl_rut1.Visible = false;

    //                }
    //                else
    //                {
    //                    txt_rut1.Text = "";
    //                    lbl_rut1.Visible = true;
    //                    lbl_rut1.Text = "El Rut Ingresado no es valido";
    //                }

    //            }
    //            else
    //            {
    //                txt_rut1.Text = "";
    //                lbl_rut1.Visible = true;
    //                lbl_rut1.Text = "El Rut Ingresado no es valido";
    //            }
    //        }
    //        catch
    //        {
    //            lbl_rut1.Text = "El Rut Ingresado no es valido";
    //        }
    //        try
    //        {
    //            if (txt_rut1.Text.Length > 3 && sw == true)
    //            {
    //                ninocoll ncoll = new ninocoll();
    //                bool ExisteRut = ncoll.ConsultaRutnino(txt_rut1.Text);
    //                if (ExisteRut == true)
    //                {
    //                    lbl_rut1.Text = "Este rut existe en la red";
    //                    lbl_rut1.Visible = true;
    //                    Function_Genera_String_Consulta(txt_rut1.Text);
    //                }
    //                else
    //                {
    //                    lbl_rut1.Text = "Este rut existe en la red";
    //                    lbl_rut1.Visible = false;

    //                }

    //            }
    //        }
    //        catch { }

    //        SetFocus(txt_nombre1);
    //        txt_nombre1.Focus();
    //    }

    //protected void txt001_ValueChange(object sender, EventArgs e)
    //{
    //    rut_01();
    //}
    #endregion

    #region  VALIDA RUT 2
    //protected void txt_rut_02(object sender, EventArgs e)
    //{
    //    bool sw = false;
    //    try
    //    {
    //        if (txt_rut2.Text.Length > 3)
    //        {
    //            string rutsinnada = txt_rut2.Text.Replace(".", "").Replace(",", "").Replace("-", "").Trim();
    //            string digitoingresado = rutsinnada.Substring(rutsinnada.Length - 1, 1);

    //            string digitocalculado = digitoVerificador(Convert.ToInt32(rutsinnada.ToUpper().Replace("K", "").Substring(0, rutsinnada.Length - 1)));
    //            if (digitocalculado.ToUpper() == digitoingresado.ToUpper())
    //            {

    //                string punorut = rutsinnada.ToUpper().Replace("K", "").Substring(0, rutsinnada.Length - 1).Trim();
    //                if (punorut.Length == 7)
    //                {
    //                    punorut = "0" + punorut;
    //                }
    //                string rcompleto = punorut + "-" + digitocalculado.ToUpper();
    //                txt_rut2.Text = rcompleto;
    //                sw = true;
    //                lbl_rut2.Visible = false;

    //            }
    //            else
    //            {
    //                txt_rut2.Text = "";
    //                lbl_rut2.Visible = true;
    //                lbl_rut2.Text = "El Rut Ingresado no es valido";
    //            }

    //        }
    //        else
    //        {
    //            txt_rut2.Text = "";
    //            lbl_rut2.Visible = true;
    //            lbl_rut2.Text = "El Rut Ingresado no es valido";
    //        }
    //    }
    //    catch
    //    {
    //        lbl_rut2.Text = "El Rut Ingresado no es valido";
    //    }
    //    try
    //    {
    //        if (txt_rut2.Text.Length > 3 && sw == true)
    //        {
    //            ninocoll ncoll = new ninocoll();
    //            bool ExisteRut = ncoll.ConsultaRutnino(txt_rut2.Text);
    //            if (ExisteRut == true)
    //            {
    //                lbl_rut2.Text = "Este rut existe en la red";
    //                lbl_rut2.Visible = true;
    //                Function_Genera_String_Consulta(txt_rut2.Text);
    //            }
    //            else
    //            {
    //                lbl_rut2.Text = "Este rut existe en la red";
    //                lbl_rut2.Visible = false;

    //            }

    //        }
    //    }
    //    catch { }
    //    SetFocus(txt_nombre2);
    //    txt_nombre2.Focus();
    //}
    #endregion


    private DataTable GetParTipoNacionalidad()
    {
        DataTable dt = new DataTable();
        try
        {
            SqlDataReader reader;

            string consulta = "select CodTipoNacionalidad, Descripcion from parTipoNacionalidad where IndVigencia = 'V'";
            SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
            SqlCommand cmd = new SqlCommand();


            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();
            dt.Load(reader);

            // Data is accessible through the DataReader object here.
            sqlConnection1.Close();
        }
        catch (Exception ex)
        {
        }
        return dt;

    }

    protected void txt_materno2_TextChanged(object sender, EventArgs e)
    {

    }
    protected void post_back_validacion(object sender, EventArgs e)
    {
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9");
        
        chk_box = false;

            #region VALIDACION POSTBACK PARA (PAF)

        if (rd_PAF.Checked == true)
        {
            if (txt_nombre1.Text != "" & txt_paterno1.Text != "" & txt_paterno1.Text != "")
            {

                lbl_info1.Visible = false;
                div_alert.Visible = false;
                txt_pat_gen.Text = txt_paterno1.Text;
                txt_mat_gen.Text = txt_materno1.Text;
                txt_nom_gen.Text = "F.O." + " " + txt_nombre1.Text;
                txt_nom_gen.Enabled = false;
                txt_pat_gen.Enabled = false;
                txt_mat_gen.Enabled = false;
                txt_nombre1.BackColor = System.Drawing.Color.Empty; txt_nombre1.AutoPostBack = false;
                txt_paterno1.BackColor = System.Drawing.Color.Empty; txt_paterno1.AutoPostBack = false;
                txt_materno1.BackColor = System.Drawing.Color.Empty;

                txt_nombre2.BackColor = System.Drawing.Color.Empty; txt_nombre2.AutoPostBack = false;
                txt_paterno2.BackColor = System.Drawing.Color.Empty; txt_paterno2.AutoPostBack = false;
                txt_materno2.BackColor = System.Drawing.Color.Empty; txt_materno2.AutoPostBack = false;

            }
            else
            {

                if (txt_nombre1.Text == "")
                { 
                    txt_nombre1.BackColor = colorCampoObligatorio; 
                    chk_box = true; 
                    txt_nombre1.AutoPostBack = true; 
                }
                else
                { 
                    txt_nombre1.BackColor = System.Drawing.Color.Empty; 
                    txt_nombre1.AutoPostBack = false; 
                }

                if (txt_paterno1.Text == "")
                {
                    if (txt_materno1.Text == "")
                    { 
                        txt_materno1.BackColor = colorCampoObligatorio; 
                        chk_box = true; 
                        txt_nombre1.AutoPostBack = true; 
                    }
                    else
                    { 
                        txt_materno1.BackColor = System.Drawing.Color.Empty; 
                    }

                    lbl_info1.Visible = true;
                    div_alert.Visible = true;
                    lbl_info1.Text = "Debe Ingresar datos de identidad para generar solicitante";
                }

            }
        }
        #endregion

            #region VALIDACION PARA SOLICITANTE (PAREJA)

                if ((rd_PES.Checked == true) & (ddown_tuser01.SelectedValue != "4"))///UNICO
                {
                if (txt_nombre1.Text != "" & txt_paterno1.Text != "" & txt_paterno1.Text != "" &
                    txt_nombre2.Text != "" & txt_paterno2.Text != "" & txt_materno2.Text != "")
                {

                    lbl_info1.Visible = false;
                    div_alert.Visible = false;
                    if (ddown_tuser01.SelectedValue == "6")
                    {
                        txt_pat_gen.Text = txt_paterno2.Text;
                        txt_mat_gen.Text = txt_paterno1.Text;
                    }
                    if (ddown_tuser01.SelectedValue == "5")
                    {
                        txt_pat_gen.Text = txt_paterno1.Text;
                        txt_mat_gen.Text = txt_paterno2.Text;
                    }
                   
                    txt_nom_gen.Text = "Solicitante";
                    txt_nom_gen.Enabled = false;
                    txt_pat_gen.Enabled = false;
                    txt_mat_gen.Enabled = false;
                    txt_nombre1.BackColor = System.Drawing.Color.Empty; txt_nombre1.AutoPostBack = false;
                    txt_paterno1.BackColor = System.Drawing.Color.Empty; txt_paterno1.AutoPostBack = false;
                    txt_materno1.BackColor = System.Drawing.Color.Empty;

                    txt_nombre2.BackColor = System.Drawing.Color.Empty; txt_nombre2.AutoPostBack = false;
                    txt_paterno2.BackColor = System.Drawing.Color.Empty; txt_paterno2.AutoPostBack = false;
                    txt_materno2.BackColor = System.Drawing.Color.Empty;

                }
                else
                {

                    if (txt_nombre1.Text == "")
                    { txt_nombre1.BackColor = colorCampoObligatorio; chk_box = true; txt_nombre1.AutoPostBack = true; }
                    else
                    { txt_nombre1.BackColor = System.Drawing.Color.Empty; txt_nombre1.AutoPostBack = false; txt_paterno1.Focus(); }

                    if (txt_paterno1.Text == "")
                    { txt_paterno1.BackColor = colorCampoObligatorio; chk_box = true; txt_paterno1.AutoPostBack = true; }
                    else
                    { txt_paterno1.BackColor = System.Drawing.Color.Empty; txt_paterno1.AutoPostBack = false; txt_materno1.Focus(); }

                    if (txt_materno1.Text == "")
                    { txt_materno1.BackColor = colorCampoObligatorio; chk_box = true; }
                    else
                    { txt_materno1.BackColor = System.Drawing.Color.Empty; ddown_nac1.Focus(); }

                    if (txt_nombre2.Text == "")
                    { txt_nombre2.BackColor = colorCampoObligatorio; chk_box = true; }// txt_nombre2.AutoPostBack = true; }
                    else
                    { txt_nombre2.BackColor = System.Drawing.Color.Empty; }// txt_nombre2.AutoPostBack = false; txt_paterno2.Focus(); }

                    if (txt_paterno2.Text == "")
                    { txt_paterno2.BackColor = colorCampoObligatorio; chk_box = true; } // txt_paterno2.AutoPostBack = true; }
                    else
                    { txt_paterno2.BackColor = System.Drawing.Color.Empty; }//txt_paterno2.AutoPostBack = false; txt_materno2.Focus(); }

                    if (txt_materno2.Text == "")
                    { txt_materno2.BackColor = colorCampoObligatorio; chk_box = true; }
                    else
                    { txt_materno2.BackColor = System.Drawing.Color.Empty; ddown_nac2.Focus(); }

                    lbl_info1.Visible = true;
                    div_alert.Visible = true;
                    lbl_info1.Text = "Debe Ingresar datos de identidad para generar solicitante";
                }
            }
            #endregion

            #region VALIDACION PARA FAMILIA SOLICITANTE (UNICO)

            if ((rd_PES.Checked == true) & (ddown_tuser01.SelectedValue == "4"))//////debe grabar al usuario solo////
            {
                if (txt_nombre1.Text != "" & txt_materno1.Text != "" & txt_paterno1.Text != "")
                {

                    lbl_info1.Visible = false;
                    div_alert.Visible = false;
                    txt_pat_gen.Text = txt_paterno1.Text;
                    txt_mat_gen.Text = txt_materno1.Text;
                    txt_nom_gen.Text = "Solicitante Único" + " " + txt_nombre1.Text;
                    txt_nom_gen.Enabled = false;
                    txt_pat_gen.Enabled = false;
                    txt_mat_gen.Enabled = false;
                    txt_nombre1.BackColor = System.Drawing.Color.Empty; txt_nombre1.AutoPostBack = false;
                    txt_paterno1.BackColor = System.Drawing.Color.Empty; txt_paterno1.AutoPostBack = false;
                    txt_materno1.BackColor = System.Drawing.Color.Empty;

                    txt_nombre2.BackColor = System.Drawing.Color.Empty; txt_nombre2.AutoPostBack = false;
                    txt_paterno2.BackColor = System.Drawing.Color.Empty; txt_paterno2.AutoPostBack = false;
                    txt_materno2.BackColor = System.Drawing.Color.Empty;

                }
                else
                {
                  
                    if (txt_nombre1.Text == "")
                    { txt_nombre1.BackColor = colorCampoObligatorio; chk_box = true; txt_nombre1.AutoPostBack = true; }
                    else
                    { txt_nombre1.BackColor = System.Drawing.Color.Empty; txt_nombre1.AutoPostBack = false; }

                    if (txt_paterno1.Text == "")
                    { txt_paterno1.BackColor = colorCampoObligatorio; chk_box = true; txt_paterno1.AutoPostBack = true; }
                    else
                    { txt_paterno1.BackColor = System.Drawing.Color.Empty; txt_paterno1.AutoPostBack = false; }

                    if (txt_materno1.Text == "")
                    { txt_materno1.BackColor = colorCampoObligatorio; chk_box = true; txt_materno1.AutoPostBack = true; }
                    else
                    { txt_materno1.BackColor = System.Drawing.Color.Empty; }

                    lbl_info1.Visible = true;
                    div_alert.Visible = true;
                    lbl_info1.Text = "Debe Ingresar datos de identidad para generar solicitante";

                    txt_nombre2.BackColor = System.Drawing.Color.Empty; txt_nombre2.AutoPostBack = false;
                    txt_paterno2.BackColor = System.Drawing.Color.Empty; txt_paterno2.AutoPostBack = false;
                    txt_materno2.BackColor = System.Drawing.Color.Empty;

                }


            }
            #endregion

            #region VALIDACION PARA SECCION (3)
            if (dd_prueba.SelectedValue == "-2")
            {
                dd_prueba.BackColor = colorCampoObligatorio;
                chk_box = true;
            }
            else
            {
                dd_prueba.BackColor = System.Drawing.Color.Empty;
            }

            if (ddown_comuna.SelectedValue == "-2")
            {
                ddown_comuna.BackColor = colorCampoObligatorio;
                chk_box = true;
            }
            else
            {
                ddown_comuna.BackColor = System.Drawing.Color.Empty;
            }

            if (ddown_region.SelectedValue == "-2")
            {
                ddown_region.BackColor = colorCampoObligatorio;
                chk_box = true;
            }
            else
            {
                ddown_region.BackColor = System.Drawing.Color.Empty;
            }
            if (cal_3.Text.ToUpper() == "")
            {
                cal_3.BackColor = colorCampoObligatorio;
                chk_box = true;
            }
            else
            {
               cal_3.BackColor = System.Drawing.Color.Empty;
            }
            if ((rd_PES.Checked == true) & (ddown_tuser01.SelectedValue != "4"))
            {
                if (cal_2.Text.ToUpper() == "")
                {
                    cal_2.BackColor = colorCampoObligatorio;
                    chk_box = true;
                }
                else
                {
                    cal_2.BackColor = System.Drawing.Color.Empty;
                }
            }
            if (cal_1.Text.ToUpper() == "")
            {
                cal_1.BackColor = colorCampoObligatorio;
                chk_box = true;
            }
            else
            {
                cal_1.BackColor = System.Drawing.Color.Empty;
            }
            if (rd_PAF.Checked)
            {
                if (ddown_nac1.SelectedValue == "-1")
                {
                    ddown_nac1.BackColor = colorCampoObligatorio;
                    chk_box = true;
                }
                else
                {
                    ddown_nac1.BackColor = System.Drawing.Color.Empty;
                }
                

                if ((rd_masc1.Checked == false) & (rd_fem1.Checked == false))
                {
                    lbl_aviso.Visible = true;
                    lbl_aviso.Text = "Debe especificar Sexo";                    
                    chk_box = true;
                }
                else
                {
                    lbl_aviso.Visible = false;                    
                }


                if (ddown_tuser2.SelectedValue != "0")
                {

                    if (txt_nombre2.Text == "")
                    { txt_nombre2.BackColor = colorCampoObligatorio; chk_box = true; }// txt_nombre2.AutoPostBack = true; }
                    else
                    { txt_nombre2.BackColor = System.Drawing.Color.Empty; }// txt_nombre2.AutoPostBack = false; txt_paterno2.Focus(); }

                    if (txt_paterno2.Text == "")
                    { txt_paterno2.BackColor = colorCampoObligatorio; chk_box = true; } // txt_paterno2.AutoPostBack = true; }
                    else
                    { txt_paterno2.BackColor = System.Drawing.Color.Empty; }//txt_paterno2.AutoPostBack = false; txt_materno2.Focus(); }

                    if (txt_materno2.Text == "")
                    { txt_materno2.BackColor = colorCampoObligatorio; chk_box = true; }
                    else
                    { txt_materno2.BackColor = System.Drawing.Color.Empty; ddown_nac2.Focus(); }


                    if (ddown_nac2.SelectedValue == "-1")
                    {
                        ddown_nac2.BackColor = colorCampoObligatorio;
                        chk_box = true;
                    }
                    else
                    {
                        ddown_nac2.BackColor = System.Drawing.Color.Empty;
                    }

                    if ((rd_masc2.Checked == false) & (rd_fem2.Checked == false))
                    {
                        lbl_aviso1.Visible = true;
                        lbl_aviso1.Text = "Debe especificar Sexo";
                        chk_box = true;
                    }
                    else
                    {
                        lbl_aviso1.Visible = false;
                    }
                    if (cal_2.Text.ToUpper() == "")
                    {
                        cal_2.BackColor = colorCampoObligatorio;
                        chk_box = true;
                    }
                    else
                    {
                        cal_2.BackColor = System.Drawing.Color.Empty;
                    }
                }
                else
                {

                    txt_nombre2.BackColor = System.Drawing.Color.Empty; // txt_nombre2.AutoPostBack = false; txt_paterno2.Focus(); }

                    txt_paterno2.BackColor = System.Drawing.Color.Empty; //txt_paterno2.AutoPostBack = false; txt_materno2.Focus(); }

                    txt_materno2.BackColor = System.Drawing.Color.Empty; ddown_nac2.Focus();
                }

            }
           
            if (rd_PES.Checked)
            {
                if (ddown_tuser01.SelectedValue != "4")
                {
                    if (ddown_nac1.SelectedValue == "-1")
                    {
                        ddown_nac1.BackColor = colorCampoObligatorio;
                        chk_box = true;
                    }
                    else
                    {
                        ddown_nac1.BackColor = System.Drawing.Color.Empty;
                    }

                    if (ddown_nac2.SelectedValue == "-1")
                    {
                        ddown_nac2.BackColor = colorCampoObligatorio;
                        chk_box = true;
                    }
                    else
                    {
                        ddown_nac2.BackColor = System.Drawing.Color.Empty;
                    }

                    if ((rd_masc1.Checked == false) & (rd_fem1.Checked == false))
                    {
                        lbl_aviso.Visible = true;
                        lbl_aviso.Text = "Debe especificar Sexo";
                        chk_box = true;
                    }
                    else
                    {
                        lbl_aviso.Visible = false;
                    }
                    if ((rd_masc2.Checked == false) & (rd_fem2.Checked == false))
                    {
                        lbl_aviso1.Visible = true;
                        lbl_aviso1.Text = "Debe especificar Sexo";
                        chk_box = true;
                    }
                    else
                    {
                        lbl_aviso1.Visible = false;
                    }



                }

                

                if (ddown_tuser01.SelectedValue == "4")//// SOLICITANTE UNICO
                {
                    if (ddown_nac1.SelectedValue == "-1")
                    {
                        ddown_nac1.BackColor = colorCampoObligatorio;
                        chk_box = true;
                    }
                    else
                    {
                        ddown_nac1.BackColor = System.Drawing.Color.Empty;
                    }
                    if ((rd_fem1.Checked == false) & (rd_masc1.Checked == false))
                    {
                        lbl_aviso.Visible = true;
                        lbl_aviso.Text = "Debe especificar Sexo";
                        chk_box = true;
                    }
                    else
                    {
                        lbl_aviso.Visible = false;
                    }
                }
            }

            #endregion
        
        if (chk_box == true)
        {
            retorno_val = 1;
        }
        else
        {
            retorno_val = 0;
        }
        
    }
    protected void ddown_region_SelectedIndexChanged(object sender, EventArgs e)
    {
        ninocoll cons = new ninocoll();
        DataTable dt = cons.consulta_comuna_Adulto(Convert.ToInt32(ddown_region.SelectedValue));
        ddown_comuna.Items.Clear();
        ddown_comuna.DataSource = dt;
        ddown_comuna.DataValueField = "codcomuna";
        ddown_comuna.DataTextField = "descripcion";
        ddown_comuna.DataBind();
        
    }
    protected void ddown_tuser01_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        rd_fem1.Checked = false;
        rd_masc1.Enabled = true;
        rd_masc1.Checked = false;
        rd_fem1.Enabled = true;

        rd_fem2.Checked = false;
        rd_masc2.Enabled = true;
        rd_masc2.Checked = false;
        rd_fem2.Enabled = true;

        #region GENERA CHECK Y LOGICA PADRE O MADRE PARA SOLICITANTE
        if (rd_PES.Checked)
        {
            if (ddown_tuser01.SelectedValue == "6") //// PAREJA MADRE
            {

                rd_fem1.Checked = true;
                rd_masc1.Enabled = false;
                ddown_tuser2.SelectedValue = "5";
                ddown_tuser2.Enabled = false;

                rd_fem2.Enabled = false;
                rd_fem2.Checked = false;
                rd_masc2.Checked = true;
                rd_masc2.Enabled = true;
                pnl_02.Visible = true;
                pnl_02.Enabled = true;
                lbl_usuario2.Visible = true;
                lbl_usuario2.Text = "* OBLIGATORIA PARA SOLICITANTES - PAREJA *";

                if (txt_nom_gen.Text != "")
                {
                    post_back_validacion(sender, e);
                   lbl_info1.Visible = false;
                   div_alert.Visible = false;
                    txt_pat_gen.Text = txt_paterno2.Text;
                    txt_mat_gen.Text = txt_paterno1.Text;
                    txt_nom_gen.Text = "Solicitante";
                    txt_nom_gen.Enabled = false;
                    txt_pat_gen.Enabled = false;
                    txt_mat_gen.Enabled = false;
                
                }
            }

            if (ddown_tuser01.SelectedValue == "5")//// PAREJA PADRE
            {
                rd_masc1.Checked = true;
                rd_fem1.Enabled = false;
                rd_fem1.Checked = false;
                rd_masc1.Enabled = true;
                ddown_tuser2.SelectedValue = "6";
                ddown_tuser2.Enabled = false;

                rd_fem2.Enabled = true;
                rd_fem2.Checked = true;
                rd_masc2.Checked = false;
                rd_masc2.Enabled = false;
                pnl_02.Visible = true;
                pnl_02.Enabled = true;

                lbl_usuario2.Visible = true;
                lbl_usuario2.Text = "* OBLIGATORIA PARA SOLICITANTES - PAREJA *";

                if (txt_nom_gen.Text != "")
                {
                    post_back_validacion(sender, e);
                    lbl_info1.Visible = false;
                    div_alert.Visible = false;
                    txt_pat_gen.Text = txt_paterno1.Text;
                    txt_mat_gen.Text = txt_paterno2.Text;
                    txt_nom_gen.Text = "Solicitante";
                    txt_nom_gen.Enabled = false;
                    txt_pat_gen.Enabled = false;
                    txt_mat_gen.Enabled = false;

                }
            }
            if (ddown_tuser01.SelectedValue == "4")//// SOLICITANTE UNICO
            {
                rd_fem1.Checked = false;
                rd_masc1.Checked = false ;

                rd_fem1.Enabled = true;
                rd_masc1.Enabled = true;
                limpia_panel2();
                pnl_02.Visible = false;
                pnl_02.Enabled = false;
                lbl_usuario2.Visible = false;
                lbl_usuario2.Text = "";

                if (txt_nom_gen.Text != "")
                {
                    post_back_validacion(sender, e);
                    lbl_info1.Visible = false;
                    div_alert.Visible = false;
                    txt_pat_gen.Text = txt_paterno1.Text;
                    txt_mat_gen.Text = txt_materno1.Text;
                    txt_nom_gen.Text = "Solicitante Único" + " " + txt_nombre1.Text;
                    txt_nom_gen.Enabled = false;
                    txt_pat_gen.Enabled = false;
                    txt_mat_gen.Enabled = false;
                }

            }
        }
        #endregion


    }

    #region INSERT PARA USUARIO 2 (PES)

    private void insert_usuario_2(SqlTransaction sqlt)
    {
        if (rd_fem2.Checked)
        {
            sexo = "F";
        }
        if (rd_masc2.Checked)
        {
            sexo = "M";
        }
        

        try
        {
             ninocoll ins2 = new ninocoll();
             DataView dvExisteRut = new DataView(ins2.callto_getrut_personasrelacionadas(txt_rut2.Text.Trim()));

             if (dvExisteRut.Table.Rows[0]["Retorno"].ToString() == "1")
             {
                 per_rel_2 = Convert.ToInt32(dvExisteRut.Table.Rows[0]["CodPersonaRelacionada"].ToString());
             }
             else
             {
                 DateTime fechaact = DateTime.Now;

                 per_rel_2 = ins2.Insert_PersonaRelacionada_PAGTransaccional(sqlt,
                 Convert.ToString(txt_rut2.Text),
                 Convert.ToString(txt_nombre2.Text),
                 Convert.ToString(txt_materno2.Text),
                 Convert.ToString(txt_paterno2.Text),
                 Convert.ToString(sexo),
                 Convert.ToDateTime(cal_2.Text),
                 Convert.ToInt32(ddown_comuna.SelectedValue),
                 Convert.ToDateTime(fechaact),
                 Convert.ToInt32(dd_prueba.SelectedValue),
                 Convert.ToInt32(ddown_tuser2.SelectedValue));
             }
            
        }
        catch
        {
            Response.Write("<script language='javascript'>alert('Se produjo un error al intentar guardar los datos para el usuario 2. Verifique nuevamente');</script>");
        }


    }
    #endregion


    #region INSERT PARA USUARIO 1 Y UNICO (PES)

    private void insert_solicitante_unico2()
    {

        ninocoll ninocoll = new ninocoll();
        int codproyecto = Convert.ToInt32(Request.QueryString["codproy"]);
        tipo = 0;

        if (rd_fem1.Checked)
        {
            sexo = "F";
        }
        if (rd_masc1.Checked)
        {
            sexo = "M";
        }

        if (cod_prog == 1)
        {
            tipo = 9;
        }
        if (cod_prog == 2)
        {
            tipo = 10;
        }

        if (cod_prog == 1)
        {
            tipo_inter = 38;
        }
        if (cod_prog == 2)
        {
            tipo_inter = 39;
        }

        ///////////////TRAE DATOS INMUEBLE///////////////////////////////
        DataTable dt3 = ninocoll.trae_datos_inmueble(codproyecto, tipo);
        int codinst_inmu = Convert.ToInt32(dt3.Rows[0][0]);
        int codinmu = Convert.ToInt32(dt3.Rows[0][1]);
        
        ///////////////TRAE DATOS ENTREVISTADOR//////////////////////////
        int codinst_entre = ninocoll.trae_inst_entrevistador(Convert.ToInt32(dd_prueba.SelectedValue));        
        DateTime fechaact = DateTime.Now;

        if (txt_rut1.Text != "")
        {
            string rn = txt_rut1.Text.Replace(" ", "");
            rn = rn.Replace(".", "");
            txt_rut1.Text = rn.ToUpper();
        }
        if (txt_rut2.Text != "")
        {
            string rn2 = txt_rut2.Text.Replace(" ", "");
            rn2 = rn2.Replace(".", "");
            txt_rut2.Text = rn2.ToUpper();
        }


        SqlTransaction sqlt;               
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        sconn.Open();
        sqlt = sconn.BeginTransaction();
        try
        {
            // insert 3er panel
            n_nino_ing = ninocoll.Insert_SOLICITANTE_UNICOTRANSACCIONAL(sqlt,
            Convert.ToInt32(-1),
            Convert.ToString("0"),///rut_nulo para unico
            Convert.ToString(txt_nom_gen.Text),
            Convert.ToString(txt_mat_gen.Text),
            Convert.ToString(txt_pat_gen.Text),
            Convert.ToString("0"),///0 para unico 
            Convert.ToInt32("0"),
            Convert.ToDateTime(fechaact),
            Convert.ToInt32(dd_prueba.SelectedValue));
            
            //insert 1er panel

            DataView dvExisteRut =  new DataView(ninocoll.callto_getrut_personasrelacionadas(txt_rut1.Text.Trim()));

            if (dvExisteRut.Table.Rows[0]["Retorno"].ToString() == "1")
            {
                per_rel_1 = Convert.ToInt32(dvExisteRut.Table.Rows[0]["CodPersonaRelacionada"].ToString());
            }
            else
            {
                per_rel_1 = ninocoll.Insert_PersonaRelacionada_PAGTransaccional(sqlt,

                Convert.ToString(txt_rut1.Text),
                Convert.ToString(txt_nombre1.Text),
                Convert.ToString(txt_materno1.Text),
                Convert.ToString(txt_paterno1.Text),
                Convert.ToString(sexo),
                Convert.ToDateTime(cal_1.Text),
                Convert.ToInt32(ddown_comuna.SelectedValue),
                Convert.ToDateTime(fechaact),
                Convert.ToInt32(dd_prueba.SelectedValue),
                Convert.ToInt32(ddown_tuser01.SelectedValue));
            }

            if (rd_PAF.Checked)
            {
                if ((txt_rut2.Text != "") & (txt_nombre2.Text != "") & (txt_paterno2.Text != "") & (txt_materno2.Text != ""))
                {
                    insert_usuario_2(sqlt);
                }
            }

            if (rd_PES.Checked)
            {
                if (ddown_tuser01.SelectedValue != "4")
                {
                    insert_usuario_2(sqlt);
                }
            }            

            Cod_IE_Gen = ninocoll.Insert_Ingreso_Egreso_PAGTransaccional(sqlt,
            Convert.ToInt32(codproyecto),
            Convert.ToInt32(n_nino_ing),
            Convert.ToDateTime(cal_3.Text),
            Convert.ToInt32(codinst_inmu),
            Convert.ToInt32(codinmu),
            Convert.ToInt32(codinst_entre),
            Convert.ToInt32(dd_prueba.SelectedValue),
            Convert.ToInt32(0),
            Convert.ToInt32(0),
            Convert.ToDateTime(fechaact),
            Convert.ToInt32(dd_prueba.SelectedValue), 
            codModeloIntervencion);

            ninocoll.Insert_Causal_Ingreso_PAGTransaccional(sqlt,
            Convert.ToInt32(Cod_IE_Gen),
            Convert.ToDateTime(fechaact),
            Convert.ToInt32(dd_prueba.SelectedValue),
            codModeloIntervencion);

            ninocoll.Insert_ninos_personas_relacionadas_PAGTransaccional(sqlt,
            Convert.ToInt32(per_rel_1),
            Convert.ToInt32(Cod_IE_Gen),
            Convert.ToInt32(n_nino_ing),
            Convert.ToInt32(ddown_nac1.SelectedValue),
            Convert.ToDateTime(fechaact),
            Convert.ToInt32(dd_prueba.SelectedValue),
            Convert.ToDateTime(cal_3.Text),
            Convert.ToInt32(ddown_tipo_nacionalidad1.SelectedValue));

            if (rd_PAF.Checked)
            {
                if ((txt_rut2.Text != "") & (txt_nombre2.Text != "") & (txt_paterno2.Text != "") & (txt_materno2.Text != "")){

                    ninocoll.Insert_ninos_personas_relacionadas_PAGTransaccional(sqlt,
                    Convert.ToInt32(per_rel_2),
                    Convert.ToInt32(Cod_IE_Gen),
                    Convert.ToInt32(n_nino_ing),
                    Convert.ToInt32(ddown_nac2.SelectedValue),
                    Convert.ToDateTime(fechaact),
                    Convert.ToInt32(dd_prueba.SelectedValue),
                    Convert.ToDateTime(cal_3.Text),
                    Convert.ToInt32(ddown_tipo_nacionalidad2.SelectedValue));
                }
            }

            if (rd_PES.Checked)
            {
                if (ddown_tuser01.SelectedValue != "4")
                {
                    ninocoll.Insert_ninos_personas_relacionadas_PAGTransaccional(sqlt,
                    Convert.ToInt32(per_rel_2),
                    Convert.ToInt32(Cod_IE_Gen),
                    Convert.ToInt32(n_nino_ing),
                    Convert.ToInt32(ddown_nac2.SelectedValue),
                    Convert.ToDateTime(fechaact),
                    Convert.ToInt32(dd_prueba.SelectedValue),
                    Convert.ToDateTime(cal_3.Text),
                    Convert.ToInt32(ddown_tipo_nacionalidad2.SelectedValue));
                }
            }
            
            Cod_Interv = ninocoll.Insert_Plan_intervencion_PAGTransaccional(sqlt,
            Convert.ToInt32(Cod_IE_Gen),
            Convert.ToInt32(codproyecto),
            Convert.ToInt32(n_nino_ing),
            Convert.ToDateTime(cal_3.Text),
            Convert.ToInt32(codinst_inmu),
            Convert.ToInt32(dd_prueba.SelectedValue),
            Convert.ToInt32(Session["IdUsuario"]),
            Convert.ToDateTime(fechaact),
            Convert.ToInt32(dd_prueba.SelectedValue),
            codModeloIntervencion);

            ninocoll.Insert_Intervenciones_PAGTransaccional(sqlt,
            Convert.ToInt32(Cod_Interv),
            Convert.ToInt32(tipo_inter),
            Convert.ToDateTime(DateTime.Now));

            ninocoll.Insert_Estados_Intervenciones_PAGTransaccional(sqlt,
            Convert.ToInt32(Cod_Interv),
            Convert.ToDateTime(DateTime.Now));

            if (codModeloIntervencion != 132)// CTLL se descarta ya que no hace ningun insert
            {
                ninocoll.Insert_Cierre_ingreso_PAGTransaccional(sqlt,
                Convert.ToInt32(Cod_IE_Gen),
                Convert.ToInt32(codproyecto),
                Convert.ToDateTime(cal_3.Text),
                Convert.ToInt32(n_nino_ing),
                Convert.ToString("0"),
                Convert.ToInt32(dd_prueba.SelectedValue));
            }

            limpia_panel1();
            limpia_panel2();
            limpia_panel3();

            sqlt.Commit();
            sconn.Close();

            Response.Write("<script language='javascript'>alert('Ingreso Exitoso');</script>");
            Response.Write("<script language='JavaScript'>;");
            Response.Write("parent.document.getElementById('btnCerrarModal7').click();");
            Response.Write("</script>");

        }
        catch (Exception ex)
        {
            // Handle the exception if the transaction fails to commit.
            Response.Write("<script language='javascript'>alert('Ingreso no realizado, intentar nuevamene.');</script>");
            Console.WriteLine(ex.Message);

            try
            {
                // Attempt to roll back the transaction.
                sqlt.Rollback();
            }
            catch (Exception exRollback)
            {
                // Throws an InvalidOperationException if the connection 
                // is closed or the transaction has already been rolled 
                // back on the server.
                Response.Write("<script language='javascript'>alert('Ingreso Realizado Con errores, por favor contactarse con mesa de ayuda. ');</script>");
                Console.WriteLine(exRollback.Message);
            }
        }
        }

    #endregion


    #region PRUEBA INSERT

    //    private void insert_solicitante_unico()
//    {
//        string rt = "";
//        string fnac = "";

//        if (rd_fem1.Checked)
//        {
//            sexo = "F";
//        }
//        if (rd_masc1.Checked)
//        {
//            sexo = "M";
//        }
//            if (rd_PES.Checked)
//            {
//                if (ddown_tuser01.SelectedValue != "4")
//                {
//                    sexo = "0";
//                    rt = null;
//                    fnac = null; ;
//                }
//                else
//                {
//                    rt = Convert.ToString(txt_rut1.Text);
//                    fnac = Convert.ToString(ddown_nac1.SelectedValue);
//                }
//            }
//            if (rd_PAF.Checked)
//            {
//                rt = Convert.ToString(txt_rut1.Text);
//                fnac = Convert.ToString(ddown_nac1.SelectedValue);
            
//            }
//        DateTime fechaact = DateTime.Now;

//        try
//        {
/////////////////////////////////////////////////////////////////

//            ninocoll ins = new ninocoll();
//            ins.Insert_SOLICITANTE_UNICO(
//            Convert.ToInt32(ddown_tuser01.SelectedValue),
//            Convert.ToString(rt),///rut_nulo para unico
//            Convert.ToString(txt_nom_gen.Text),
//            Convert.ToString(txt_mat_gen.Text),
//            Convert.ToString(txt_pat_gen.Text),
//            Convert.ToString(sexo),///0 para unico 
//            Convert.ToDateTime(cal_3.Value),
//            Convert.ToInt32(fnac),
//            Convert.ToDateTime(fechaact),
//            Convert.ToInt32(dd_prueba.SelectedValue)

//            );

/////////////////////////////////////////////////////////////////
//            ninocoll ins2 = new ninocoll();
//            ins2.Insert_PersonaRelacionada_PAG(
        
//            Convert.ToString(txt_rut1.Text),
//            Convert.ToString(txt_nom_gen.Text),
//            Convert.ToString(txt_mat_gen.Text),
//            Convert.ToString(txt_pat_gen.Text),
//            Convert.ToString(sexo),
//            Convert.ToDateTime(cal_3.Value),
//            Convert.ToInt32(ddown_comuna.SelectedValue),
//            Convert.ToDateTime(fechaact),
//            Convert.ToInt32(dd_prueba.SelectedValue)

//            );


//            limpia_panel1();
//            limpia_panel2();
//            limpia_panel3();
//        }
//        catch 
//        {
//            Response.Write("<script language='javascript'>alert('Se produjo un error al intentar guardar los datos. Verifique nuevamente');</script>");
//        }

    //    }
    #endregion 


    #region INSERT USUARIO 2 (PAF)

    private void insert_usuario_2_PAF()
    {
        if (rd_fem2.Checked)
        {
            sexo = "F";
        }
        if (rd_masc2.Checked)
        {
            sexo = "M";
        }

        try
        {
            DateTime fechaact = DateTime.Now;

            ninocoll ins2 = new ninocoll();
            ins2.Insert_PersonaRelacionada_PAG(
            Convert.ToString(txt_rut2.Text),
            Convert.ToString(txt_nombre2.Text),
            Convert.ToString(txt_materno2.Text),
            Convert.ToString(txt_paterno2.Text),
            Convert.ToString(sexo),
            Convert.ToDateTime(cal_2.Text),
            Convert.ToInt32(ddown_comuna.SelectedValue),
            Convert.ToDateTime(fechaact),
            Convert.ToInt32(dd_prueba.SelectedValue),
            Convert.ToInt32(ddown_tuser2.SelectedValue)
            );
        }
        catch
        {
            Response.Write("<script language='javascript'>alert('Se produjo un error al intentar guardar los datos para el usuario 2. Verifique nuevamente');</script>");
        }


    }
    #endregion 


    #region INSERT PARA USUARIO 1  (PAF)

    private void insert_PAF_1()
    {
        tipo = 0;
        if (rd_fem1.Checked)
        {
            sexo = "F";
        }
        if (rd_masc1.Checked)
        {
            sexo = "M";
        }


        DateTime fechaact = DateTime.Now;

        try
        {

            ninocoll ins = new ninocoll();
            n_nino_ing = ins.Insert_SOLICITANTE_UNICO(
            Convert.ToInt32(-1),
            Convert.ToString("0"),///rut_nulo para unico
            Convert.ToString(txt_nom_gen.Text),
            Convert.ToString(txt_mat_gen.Text),
            Convert.ToString(txt_pat_gen.Text),
            Convert.ToString("0"),///0 para unico 

            Convert.ToInt32("0"),
            Convert.ToDateTime(fechaact),
            Convert.ToInt32(dd_prueba.SelectedValue));
            
        }
        catch
        {
            Response.Write("<script language='javascript'>alert('Se Produjo un error al intentar Grabar en Tabla Ninos. ');</script>");
        }

        try
        {

            ninocoll ins2 = new ninocoll();
            per_rel_1 = ins2.Insert_PersonaRelacionada_PAG(

             Convert.ToString(txt_rut1.Text),
             Convert.ToString(txt_nombre1.Text),
             Convert.ToString(txt_materno1.Text),
             Convert.ToString(txt_paterno1.Text),
             Convert.ToString(sexo),
             Convert.ToDateTime(cal_1.Text),
             Convert.ToInt32(ddown_comuna.SelectedValue),
             Convert.ToDateTime(fechaact),
             Convert.ToInt32(dd_prueba.SelectedValue),
             Convert.ToInt32(ddown_tuser01.SelectedValue)
             );            

            if (rd_PAF.Checked)
            {
                if ((txt_rut2.Text != "")&(txt_nombre2.Text != "")&(txt_paterno2.Text != "")&(txt_materno2.Text != ""))
                {
                    insert_usuario_2_PAF();
                }
            }
        }
        catch
        {
            Response.Write("<script language='javascript'>alert('Se Produjo un error al intentar Grabar en Personas Relacionadas. ');</script>");

        }


        try
        {

            if (cod_prog == 1)
            {
                tipo = 9;
            }
            if (cod_prog == 2)
            {
                tipo = 10;
            }
            ///////////////TRAE DATOS INMUEBLE///////////////////////////////
            int codproyecto = Convert.ToInt32(Request.QueryString["codproy"]);
            ninocoll ins4 = new ninocoll();
            DataTable dt3 = ins4.trae_datos_inmueble(codproyecto, tipo);
            int codinst_inmu = Convert.ToInt32(dt3.Rows[0][0]);
            int codinmu = Convert.ToInt32(dt3.Rows[0][1]);
            ///////////////FIN DATOS INMUEBLE////////////////////////////////

            ///////////////TRAE DATOS ENTREVISTADOR//////////////////////////
            ninocoll ins5 = new ninocoll();
            int codinst_entre = ins5.trae_inst_entrevistador(Convert.ToInt32(dd_prueba.SelectedValue));
            
            ///////////////FIN DATOS ENTREVISTADOR///////////////////////////


            ninocoll ins3 = new ninocoll();
            Cod_IE_Gen = ins3.Insert_Ingreso_Egreso_PAG(

            Convert.ToInt32(codproyecto),
            Convert.ToInt32(n_nino_ing),
            Convert.ToDateTime(cal_3.Text),

            Convert.ToInt32(codinst_inmu),
            Convert.ToInt32(codinmu),
            Convert.ToInt32(codinst_entre),
             Convert.ToInt32(dd_prueba.SelectedValue),
            Convert.ToInt32(0),
            Convert.ToInt32(0),
            Convert.ToDateTime(fechaact),
            Convert.ToInt32(dd_prueba.SelectedValue),
            codModeloIntervencion

            );

            
        }
        catch
        {

            Response.Write("<script language='javascript'>alert('Se Produjo un error al intentar Grabar en Ingreso Egreso. ');</script>");

        }
        try
        {

            ninocoll ins5 = new ninocoll();
            ins5.Insert_Causal_Ingreso_PAG(
            Convert.ToInt32(Cod_IE_Gen),
            Convert.ToDateTime(fechaact),
            Convert.ToInt32(dd_prueba.SelectedValue),
            codModeloIntervencion);

        }

        catch
        {

            Response.Write("<script language='javascript'>alert('Se Produjo un error al intentar Grabar Causal de Ingreso. ');</script>");
        }

        try
        {

            ninocoll ins7 = new ninocoll();
            ins7.Insert_ninos_personas_relacionadas_PAG(

            Convert.ToInt32(per_rel_1),
            Convert.ToInt32(Cod_IE_Gen),
            Convert.ToInt32(n_nino_ing),
            Convert.ToInt32(ddown_nac1.SelectedValue),
            Convert.ToDateTime(fechaact),
            Convert.ToInt32(dd_prueba.SelectedValue),
            Convert.ToDateTime(cal_3.Text),
             Convert.ToInt32(ddown_tipo_nacionalidad1.SelectedValue)

            );


            if (rd_PES.Checked)
            {
                if (ddown_tuser01.SelectedValue != "4")
                {
                    ninocoll ins8 = new ninocoll();
                    ins8.Insert_ninos_personas_relacionadas_PAG(

                    Convert.ToInt32(per_rel_2),
                    Convert.ToInt32(Cod_IE_Gen),
                    Convert.ToInt32(n_nino_ing),
                    Convert.ToInt32(ddown_nac2.SelectedValue),
                    Convert.ToDateTime(fechaact),
                    Convert.ToInt32(dd_prueba.SelectedValue),
                    Convert.ToDateTime(cal_3.Text),
                     Convert.ToInt32(ddown_tipo_nacionalidad2.SelectedValue)

                    );
                }
            }

        }
        catch
        {
            Response.Write("<script language='javascript'>alert('Se Produjo un error al intentar Grabar NinosPersonaRelacionada. ');</script>");
        }

        try
        {

            int codproyecto = Convert.ToInt32(Request.QueryString["codproy"]);

            if (cod_prog == 1)
            {
                tipo = 9;
            }
            if (cod_prog == 2)
            {
                tipo = 10;
            }

            ninocoll ins10 = new ninocoll();
            DataTable dt10 = ins10.trae_datos_inmueble(codproyecto, tipo);
            int codinst_inmu = Convert.ToInt32(dt10.Rows[0][0]);

            ninocoll ins9 = new ninocoll();
            Cod_Interv = ins9.Insert_Plan_intervencion_PAG(
            Convert.ToInt32(Cod_IE_Gen),
            Convert.ToInt32(codproyecto),
            Convert.ToInt32(n_nino_ing),

            Convert.ToDateTime(cal_3.Text),
            Convert.ToInt32(codinst_inmu),
             Convert.ToInt32(dd_prueba.SelectedValue),
             Convert.ToInt32(Session["IdUsuario"]),
            Convert.ToDateTime(fechaact),
            Convert.ToInt32(dd_prueba.SelectedValue),
            codModeloIntervencion
            );

           

        }

        catch
        {

            Response.Write("<script language='javascript'>alert('Se Produjo un error al intentar Grabar Plan Intervencion PAG. ');</script>");
        }
        try
        {
            if (cod_prog == 1)
            {
                tipo_inter = 38;
            }
            if (cod_prog == 2)
            {
                tipo_inter = 39;
            }

            ninocoll ins11 = new ninocoll();
            ins11.Insert_Intervenciones_PAG(
            Convert.ToInt32(Cod_Interv),
            Convert.ToInt32(tipo_inter),
            Convert.ToDateTime(DateTime.Now)

            );

        }

        catch
        {

            Response.Write("<script language='javascript'>alert('Se Produjo un error al intentar Grabar Intervenciones. ');</script>");
        }

        try
        {


            ninocoll ins12 = new ninocoll();
            ins12.Insert_Estados_Intervenciones_PAG(
            Convert.ToInt32(Cod_Interv),

            Convert.ToDateTime(DateTime.Now)

            );

        }

        catch
        {

            Response.Write("<script language='javascript'>alert('Se Produjo un error al intentar Grabar Estados plan intervencion. ');</script>");
        }



        limpia_panel1();
        limpia_panel2();
        limpia_panel3();



  
    }


    #endregion


    protected void btnnext004_Click(object sender, EventArgs e)
    {
        post_back_validacion(sender, e);

        if (retorno_val == 0)
        {
            if (rd_PES.Checked)
            {
                    insert_solicitante_unico2();                    
            }
            if (rd_PAF.Checked)
            {
                    insert_solicitante_unico2();                    
            }

            lbl_info1.Visible = false;
            div_alert.Visible = false;
        }
        else
        { 
            lbl_info1.Visible = true;
            div_alert.Visible = true;
            //Response.Write("<script language='javascript'>alert('Faltan Datos para el ingreso');</script>");
            lbl_info1.Text = "Faltan Datos Para realizar el ingreso";
        }
    }
  
            protected void cal004_ValueChanged(object sender, EventArgs e)
    {
        
        if(ConfigurationSettings.AppSettings["cierre_mes"].ToString() == "1")
        {
            DateTime fecha = DateTime.Now; 
            if (cal_3.Text.ToUpper() != "")
            {
                fecha = Convert.ToDateTime(cal_3.Text);
            }




            int Estado_cierre = 0;

            string ano = fecha.Year.ToString();
            string mes = fecha.Month.ToString();

            if (mes.Length <= 1)
            {
                mes = 0 + mes;
            }
            else
            {
                mes = mes;
            }

            int Periodo = Convert.ToInt32(ano + mes);

            diagnosticoscoll dcoll = new diagnosticoscoll();

            Estado_cierre = dcoll.callto_consulta_cierremes(SSnino.CodProyecto, Periodo);

            if (Estado_cierre == 1)
            {
                lbl_cal3.Text = "El mes esta cerrado";
                cal_3.Text = "";
                lbl_cal3.Visible = true;
            }
            else
            {
                lbl_cal3.Visible = false;
            }
           

        }
        
        
       
    
    }
            protected void ddown_tipo_nacionalidad_SelectedIndexChanged(object sender, EventArgs e)
            {

                ddown_nac1.Items.FindByValue("1").Enabled = true;
                if (ddown_tipo_nacionalidad1.SelectedValue == "1" || ddown_tipo_nacionalidad1.SelectedValue == "3") // verifica si se selecciona tipo de nacionalidad chileno o nacionalizado 
                {
                    if (ddown_nac1.Items.FindByValue("2").Enabled == true) //verifica si las nacionalidades que no son chilenas estan visibles
                    {
                        for (int i = 2; i <= ddown_nac1.Items.Count; i++)
                        {
                            if (ddown_nac1.Items.FindByValue(Convert.ToString(i)) != null) // el 8 no existe
                            {
                                ddown_nac1.Items.FindByValue(Convert.ToString(i)).Enabled = false;
                            }
                        }
                    }
                    ddown_nac1.SelectedValue = "1";
                }
                else // todas las demas
                {
                    if (ddown_nac1.Items.FindByValue("2").Enabled == false) //verifica si las nacionalidades que no son chilenas estan ocultas
                    {
                        for (int i = 2; i <= ddown_nac1.Items.Count; i++)
                        {
                            if (ddown_nac1.Items.FindByValue(Convert.ToString(i)) != null) // el 8 no existe
                            {
                                ddown_nac1.Items.FindByValue(Convert.ToString(i)).Enabled = true;
                            }
                        }
                    }
                    if (ddown_tipo_nacionalidad1.SelectedValue == "2") // verifica si se selecciona tipo de nacionalidad extrangero (ocultar nacionalidad chilena)
                    {
                        ddown_nac1.Items.FindByValue("1").Enabled = false; // oculta nacionalidad chilena
                    }

                    if (ddown_tipo_nacionalidad1.SelectedValue == "0")
                    {
                        for (int i = 1; i <= ddown_nac1.Items.Count; i++)
                        {
                            if (ddown_nac1.Items.FindByValue(Convert.ToString(i)) != null) // el 8 no existe
                            {
                                ddown_nac1.Items.FindByValue(Convert.ToString(i)).Enabled = false;

                            }
                        }
                        ddown_nac1.SelectedValue = "-1";
                    }
                }
            }
            protected void ddown_tipo_nacionalidad2_SelectedIndexChanged(object sender, EventArgs e)
            {

                ddown_nac2.Items.FindByValue("1").Enabled = true;
                if (ddown_tipo_nacionalidad2.SelectedValue == "1" || ddown_tipo_nacionalidad2.SelectedValue == "3") // verifica si se selecciona tipo de nacionalidad chileno o nacionalizado 
                {
                    if (ddown_nac2.Items.FindByValue("2").Enabled == true) //verifica si las nacionalidades que no son chilenas estan visibles
                    {
                        for (int i = 2; i <= ddown_nac2.Items.Count; i++)
                        {
                            if (ddown_nac2.Items.FindByValue(Convert.ToString(i)) != null) // el 8 no existe
                            {
                                ddown_nac2.Items.FindByValue(Convert.ToString(i)).Enabled = false;
                            }
                        }
                    }
                    ddown_nac2.SelectedValue = "1";
                }
                else // todas las demas
                {
                    if (ddown_nac2.Items.FindByValue("2").Enabled == false) //verifica si las nacionalidades que no son chilenas estan ocultas
                    {
                        for (int i = 2; i <= ddown_nac2.Items.Count; i++)
                        {
                            if (ddown_nac2.Items.FindByValue(Convert.ToString(i)) != null) // el 8 no existe
                            {
                                ddown_nac2.Items.FindByValue(Convert.ToString(i)).Enabled = true;
                            }
                        }
                    }
                    if (ddown_tipo_nacionalidad2.SelectedValue == "2") // verifica si se selecciona tipo de nacionalidad extrangero (ocultar nacionalidad chilena)
                    {
                        ddown_nac2.Items.FindByValue("1").Enabled = false; // oculta nacionalidad chilena
                    }

                    if (ddown_tipo_nacionalidad2.SelectedValue == "0")
                    {
                        for (int i = 1; i <= ddown_nac2.Items.Count; i++)
                        {
                            if (ddown_nac2.Items.FindByValue(Convert.ToString(i)) != null) // el 8 no existe
                            {
                                ddown_nac2.Items.FindByValue(Convert.ToString(i)).Enabled = false;

                            }
                        }
                        ddown_nac2.SelectedValue = "1";
                    }
                }

            }


            private void SetCamposSolicitanteAutomaticos()
            {
                if (rd_PAF.Checked == true)
                {
                    if (txt_nombre1.Text != "")
                    {                       
                        txt_nom_gen.Text = "F.O." + " " + txt_nombre1.Text;
                    }

                    if (txt_paterno1.Text != "")
                    {                        
                        txt_pat_gen.Text = txt_paterno1.Text;                        
                    }

                    if (txt_materno1.Text != "")
                    {                        
                        txt_mat_gen.Text = txt_materno1.Text;                        
                    }
                }
                else if (rd_PES.Checked == true)
                {
                    if (ddown_tuser01.SelectedValue != "4")
                    {                            
                        if (ddown_tuser01.SelectedValue == "6")
                        {
                            if (txt_paterno2.Text != "")
                            {
                                txt_pat_gen.Text = txt_paterno2.Text;
                            }
                            if (txt_paterno1.Text != "")
                            {
                                txt_mat_gen.Text = txt_paterno1.Text;
                            }
                        }
                        if (ddown_tuser01.SelectedValue == "5")
                        {
                            if (txt_paterno1.Text != "")
                            {
                                txt_pat_gen.Text = txt_paterno1.Text;
                            }
                            if (txt_paterno2.Text != "")
                            {
                                txt_mat_gen.Text = txt_paterno2.Text;
                            }
                        }

                        txt_nom_gen.Text = "Solicitante";
                    }
                    else if (ddown_tuser01.SelectedValue == "4") // UNICO
                    {
                        if (txt_paterno1.Text != "")
                        {
                            txt_pat_gen.Text = txt_paterno1.Text;
                        }
                        if (txt_materno1.Text != "")
                        {
                            txt_mat_gen.Text = txt_materno1.Text;
                        }
                        if (txt_nombre1.Text != "")
                        {
                            txt_nom_gen.Text = "Solicitante Único" + " " + txt_nombre1.Text;
                        }
                    }
                }
            }

            protected void rv_fecha_Init(object sender, EventArgs e)
            {
                ((RangeValidator)sender).MaximumValue = DateTime.Today.Day + "-" + DateTime.Today.Month + "-" + DateTime.Today.AddYears(-25).ToString("yyyy");
                ((RangeValidator)sender).MinimumValue = DateTime.Today.Day + "-" + DateTime.Today.Month + "-" + DateTime.Today.AddYears(-60).ToString("yyyy");

            }
            protected void txt_nombre1_TextChanged(object sender, EventArgs e)
            {
                SetCamposSolicitanteAutomaticos();
            }
            protected void txt_paterno1_TextChanged(object sender, EventArgs e)
            {
                SetCamposSolicitanteAutomaticos();
            }
            protected void txt_materno1_TextChanged(object sender, EventArgs e)
            {
                SetCamposSolicitanteAutomaticos();
            }
}
