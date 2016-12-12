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
using System.Drawing;

using System.Collections.Generic;
using System.Data.SqlClient;

public partial class mod_ninos_ingresonuevo : System.Web.UI.Page
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

    public int UserId
    {
        get { return (int)Session["IdUsuario"]; }
        set { Session["IdUsuario"] = value; }
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
            CalendarExtende952.EndDate = DateTime.Now;
            CalendarExtende964.EndDate = DateTime.Now;
            CalendarExtende975.EndDate = DateTime.Now;
            CalendarExtende988.EndDate = DateTime.Now;


            //si el cod proyecto llega en cero
            if (SSnino.CodProyecto == 0)
            {
                window.alert(this, "Debe Seleccionar un Proyecto Válido");
                //ClientScript.RegisterStartupScript(this.GetType(), "", "CerrarFancybox()", true);  
            }
            else
            {

                getdata();

                if (Request.QueryString["rut"] != "")
                {
                    
                    txt001.Text = Request.QueryString["rut"];
                    txt001_ValueChange(sender, e);
                }

                if (Request.QueryString["CODPERSONARELACIONADA"] != null)
                {
                    ninocoll ncoll = new ninocoll();
                    DataTable dt = ncoll.GetPersonasRelacionadas(Convert.ToInt32(Request.QueryString["CODPERSONARELACIONADA"]));
                    txt005.Text = dt.Rows[1][1].ToString();
                    txt006.Text = dt.Rows[1][2].ToString();
                    txt007.Text = dt.Rows[1][3].ToString();
                    txt008.Text = dt.Rows[1][4].ToString();
                    txt004.Text = dt.Rows[1][4].ToString();
                    chk002.Checked = true;

                    setgestacion();
                }
                if (Request.QueryString["eg"] != null)
                {
                    if (Request.QueryString["eg"] == "si")
                    {
                        chk001.Checked = false;
                        chk001.Enabled = false;
                        chk002.Checked = true;
                        chk002.Enabled = false;
                        txt001.Enabled = false;
                        setgestacion();
                        if (chk002.Checked == false)
                        {
                            pnl004.Visible = false;
                        }
                    }
                }
                else
                {
                    //proyectocoll pcoll = new proyectocoll();
                    //DataTable dtproyecto = pcoll.GetProyectos(SSnino.CodProyecto.ToString());

                    //if (dtproyecto.Rows.Count > 0)
                    //{
                    //    if (dtproyecto.Rows[0]["TipoProyecto"].ToString() == "7" || dtproyecto.Rows[0]["CodModeloIntervencion"].ToString() == "92" || dtproyecto.Rows[0]["CodModeloIntervencion"].ToString() == "142")
                    //    {
                    //        chk001.Visible = false;
                    //    }
                    //}

                    if (window.existetoken("1FA4CCAF-8156-45A3-B07E-60381CB48FC3"))
                    {
                        chk001.Visible = true;
                    }                    

                }
            }
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

        proyectocoll pcP = new proyectocoll();
        DataTable dtProyecto = pcP.GetProyectos(SSnino.CodProyecto.ToString());
        int CodModeloIntervencion = Convert.ToInt32(dtProyecto.Rows[0]["CodModeloIntervencion"].ToString());

        DataView dv1 = new DataView(par.GetparNacionalidades());
        ddown001.DataSource = dv1;
        ddown001.DataTextField = "Descripcion";
        ddown001.DataValueField = "CodNacionalidad";
        dv1.Sort = "CodNacionalidad";
        ddown001.DataBind();

        
        for (int i = 1; i <= ddown001.Items.Count -1 ; i++)
        {
            if (ddown001.Items[i] != null) // el 8 no existe
            {
                ddown001.Items[i].Enabled = false;
                //ddown001.Items.FindByValue(Convert.ToString(i)).Enabled = false;
            }
        }
        ddown001.SelectedValue = "0";


        DataView dv2 = new DataView((GetParTipoNacionalidad()));
        ddown_tipo_nacionalidad.DataSource = dv2;
        ddown_tipo_nacionalidad.DataTextField = "Descripcion";
        ddown_tipo_nacionalidad.DataValueField = "CodTipoNacionalidad";
        dv2.Sort = "CodTipoNacionalidad";
        ddown_tipo_nacionalidad.DataBind();

        //DataView dv2 = new DataView(par.GetparNivelDiscapacidad());
        //ddown002.DataSource = dv2;
        //ddown002.DataTextField = "Descripcion";
        //ddown002.DataValueField = "CodNivelDiscapacidad";
        //dv2.Sort = "Descripcion";
        //ddown002.DataBind();

        //DataView dv3 = new DataView(tcoll.GetTrabajadoresProyecto(SSnino.CodProyecto.ToString()));
        //ddown003.DataSource = dv3;
        //ddown003.DataTextField = "NombreCompleto";
        //ddown003.DataValueField = "ICodTrabajador";
        //dv3.Sort = "NombreCompleto";
        //ddown003.DataBind();

        DataView dv3 = new DataView(par.GetparActividad(CodModeloIntervencion));
        ddown003M.Items.Clear();
        //ListItem li = new ListItem(" Seleccionar", "0");
        ddown003M.Items.Add(new ListItem(" Seleccionar", "0"));
        ddown003M.DataSource = dv3;
        ddown003M.DataTextField = "Descripcion";
        ddown003M.DataValueField = "CodActividad";
        dv3.Sort = "Descripcion";
        ddown003M.DataBind();

        DataView dv6;
        DataView dv7;
        DataView dv8;

        ////////////////ddwn situacion////////////
        if (CodModeloIntervencion == 91 || CodModeloIntervencion == 92)   // ModIntervencion FAS o FAE
        {
            if (ddown003M.SelectedValue.ToString() == "20" || ddown003M.SelectedValue.ToString() == "21")
            {
                dv6 = new DataView(par.GetparSituacionPerRel(1));
                dv7 = new DataView(par.GetparSituacionPerRel(2));
                dv8 = new DataView(par.GetparSituacionPerRel(3));
            }
            else
            {
                dv6 = new DataView(par.GetparSituacionPerRel(0));
                dv7 = new DataView(par.GetparSituacionPerRel(0));
                dv8 = new DataView(par.GetparSituacionPerRel(0));
            }

            ddown006M.Items.Clear();
            ddown006M.DataSource = dv6;
            ddown006M.DataTextField = "Descripcion";
            ddown006M.DataValueField = "CodSituacion";
            dv6.Sort = "Descripcion";
            ddown006M.DataBind();

            //DataView dv7 = new DataView(par.GetparSituacionPerRel(2));
            ddown007M.Items.Clear();
            ddown007M.DataSource = dv7;
            ddown007M.DataTextField = "Descripcion";
            ddown007M.DataValueField = "CodSituacion";
            dv7.Sort = "Descripcion";
            ddown007M.DataBind();

            //DataView dv8 = new DataView(par.GetparSituacionPerRel(3));
            ddown008M.Items.Clear();
            ddown008M.DataSource = dv8;
            ddown008M.DataTextField = "Descripcion";
            ddown008M.DataValueField = "CodSituacion";
            dv8.Sort = "Descripcion";
            ddown008M.DataBind();
        }
        else
        {
            dv6 = new DataView(par.GetparSituacionPerRel(0));
            ddown006M.Items.Clear();
            ddown006M.DataSource = dv6;
            ddown006M.DataTextField = "Descripcion";
            ddown006M.DataValueField = "CodSituacion";
            dv6.Sort = "Descripcion";
            ddown006M.DataBind();

            dv7 = new DataView(par.GetparSituacionPerRel(0));
            ddown007M.Items.Clear();
            ddown007M.DataSource = dv7;
            ddown007M.DataTextField = "Descripcion";
            ddown007M.DataValueField = "CodSituacion";
            dv7.Sort = "Descripcion";
            ddown007M.DataBind();

            dv8 = new DataView(par.GetparSituacionPerRel(0));
            ddown008M.Items.Clear();
            ddown008M.DataSource = dv8;
            ddown008M.DataTextField = "Descripcion";
            ddown008M.DataValueField = "CodSituacion";
            dv8.Sort = "Descripcion";
            ddown008M.DataBind();
        }
        //cal001.MaxDate = DateTime.Now;
        CalendarExtende952.EndDate = DateTime.Now;



    }

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


    protected void ddown009M_SelectedIndexChanged(object sender, EventArgs e)
    {
        parcoll par = new parcoll();
        DataView dv10 = new DataView(par.GetparComunas(ddown009M.SelectedValue));
        ddown010M.Items.Clear();
        ddown010M.DataSource = dv10;
        ddown010M.DataTextField = "Descripcion";
        ddown010M.DataValueField = "CodComuna";
        dv10.Sort = "CodComuna";
        ddown010M.DataBind();

    }



    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void btn001_Click(object sender, EventArgs e)
    {
        //string url = "reg_inmueblesproy.aspx?sw=5&codInmueble=1";
        //ClientScript.RegisterStartupScript(this.GetType(), "", "AbrirURLFancybox('" + url + "');", true);
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "JSscript", "alert('this is a test');", true);
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "showSaveMessage", "<script language='javascript'>alert('USER Deleted Sucessfully');</script>");


        //Valida nuevamente si el rut se encuentra en los registros de SENAINFO.
        if (txt001.Text != "" && chk001.Checked == false && chk002.Checked == false)
        {
            cv_rut.Validate();
            if (cv_rut.IsValid)
            {
                ninocoll ncoll = new ninocoll();
                bool ExisteRut = ncoll.ConsultaRutnino(txt001.Text.Trim().Replace(".", ""));
                if (ExisteRut == true)
                {
                    lblexrut.Text = "Este rut existe en la red";
                    lblexrut.Visible = true;
                    Function_Genera_String_Consulta(txt001.Text.Trim().Replace(".",""));
                }
                else
                {
                    lblexrut.Text = "";
                    lblexrut.Visible = false;
                    Ingreso();
                }
            }
        }
        else
        {
            Ingreso();
        }
        
        
    }

    private void Ingreso()
    {

        string sexo = "M";
        string eg = "N";            // en gestacion
        int nacionalidad = 0;
        if (rdo001.Checked)
        { sexo = "F"; }
        if (chk002.Checked)
        {
            eg = "S";
            sexo = "F";
        }

     


        ninocoll ncoll = new ninocoll();
        //if (validate())
        //{

        if (eg == "S") // En Gestación
        {
            int comuna = 0;

            if (validateNinoGestacion())
            {
                divAlerta.Visible = false;

                if (txt002.Text.Trim() == "") txt002.Text = "N.N. Nombre";
                if (txt004.Text.Trim() == "") txt004.Text = "N.N. Apellido";

                if (txttelefono.Text.Trim() == "") txttelefono.Text = "0";
                if (txt001M.Text.Trim() == "") txt001M.Text = "SIN OBSERVACION";
                if (txt005.Text.Trim() == "") txt005.Text = "0";
                if (txt007.Text.Trim() == "") txt007.Text = "0";
                if ((cal004.Text.ToUpper() == "") || (cal004.Text.Trim() == "")) cal004.Text = DateTime.Now.ToShortDateString();

                if (ddown010M.SelectedValue == "0" || ddown010M.SelectedValue == "")
                { comuna = 0; }
                else
                { comuna = Convert.ToInt32(ddown010M.SelectedValue); }


                SqlTransaction sqlt;

                SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
                sconn.Open();
                sqlt = sconn.BeginTransaction();
                try
                {
                // Insert nino en gestacion  //OK

                int iden = ncoll.Insert_NinosTransaccional(sqlt,
                        Convert.ToDateTime("01-01-1900"),
                        false,
                        "0",
                        "F",
                        txt002.Text.ToUpper(),
                        "N.N. EN GESTACION",
                        txt004.Text.ToUpper(),
                        Convert.ToDateTime("01-01-1900"),
                        0, 0, "0", 0, "0", "0", false, false, false, "S", DateTime.Now, UserId, 0);

                SSnino.CodNino = iden;                

                int CodIE = ncoll.SetIngresos_Egresos(sqlt,
                    SSnino.CodProyecto,
                    iden,
                    Convert.ToDateTime(cal004.Text),
                    28, false, 2, 9, 0,
                    CodInmueble(), 0, 0, 0, "0", "0", 0, 0, -1, -1, false, "0", "0", "NO",
                    DateTime.Now, UserId, Convert.ToDateTime("01-01-1900"), "0", 0, "0", 0, 0, 0, 0, 0);
                
                
                SSnino.ICodIE = CodIE;
                ncoll.Insert_CausalesIngresoTransaccional(sqlt, CodIE, 79, 1, "0", DateTime.Now, UserId, 0);
                ncoll.Cierre_ingresoTransaccional(sqlt, CodIE, SSnino.CodProyecto, Convert.ToDateTime(cal004.Text), SSnino.CodNino, sexo, UserId);
              
                if (Convert.ToString(VCod_PersonaRelacionada) != "-1")
                {
                    ncoll.callto_insert_ninospersonasrelacionadasTransaccional(sqlt, VCod_PersonaRelacionada, SSnino.ICodIE, SSnino.CodNino
                        , Convert.ToDateTime(cal001M.Text), Convert.ToInt32(ddown005M.SelectedValue)
                        , Convert.ToInt32(ddown004M.SelectedValue)
                        , Convert.ToInt32(ddown002M.SelectedValue), Convert.ToInt32(ddown001M.SelectedValue)
                        , Convert.ToInt32(ddown003M.SelectedValue), Convert.ToInt32(ddown006M.SelectedValue)
                        , Convert.ToInt32(ddown007M.SelectedValue), Convert.ToInt32(ddown008M.SelectedValue)
                        , DateTime.Now, UserId);

                }
                else
                {
                    int iden2;
                    DataTable identidad = ncoll.callto_insert_personasrelacionadas_2fTransaccional(sqlt,
                        txt005.Text.Trim().Replace(".",""),
                        txt006.Text.Trim(),
                        txt007.Text.Trim(),
                        txt008.Text.Trim(),
                        "F",
                        Convert.ToDateTime(cal005.Text),
                        DateTime.Now,
                        UserId, 1,
                        comuna,
                        txt001M.Text.Trim(),
                        txttelefono.Text.Trim());

                    iden2 = Convert.ToInt32(identidad.Rows[0][0]);

                    ncoll.callto_insert_ninospersonasrelacionadasTransaccional(sqlt,
                        iden2,
                        SSnino.ICodIE,
                        SSnino.CodNino,
                        Convert.ToDateTime(cal001M.Text),
                        Convert.ToInt32(ddown005M.SelectedValue),
                        Convert.ToInt32(ddown004M.SelectedValue),
                        Convert.ToInt32(ddown002M.SelectedValue),
                        Convert.ToInt32(ddown001M.SelectedValue),
                        Convert.ToInt32(ddown003M.SelectedValue),
                        Convert.ToInt32(ddown006M.SelectedValue),
                        Convert.ToInt32(ddown007M.SelectedValue),
                        Convert.ToInt32(ddown008M.SelectedValue),
                        DateTime.Now, UserId);
                }
                

                sqlt.Commit();
                sconn.Close();

                window.alert(this, "Ingreso de niño en gestación realizado satisfactoriamente.");
                ClientScript.RegisterStartupScript(this.GetType(), "", "CerrarModalPopUp();", true);
                
                }
                catch (Exception ex)
                {                    
                    //Console.WriteLine(ex.Message);
                    try
                    {
                        // Attempt to roll back the transaction.
                        sqlt.Rollback();
                        window.alert(this, "Ingreso no realizado, por favor intentar nuevamente.");
                    }
                    catch (Exception exRollback)
                    {
                        // Throws an InvalidOperationException if the connection 
                        // is closed or the transaction has already been rolled 
                        // back on the server.
                        //Console.WriteLine(exRollback.Message);
                        window.alert(this, "Ingreso realizado con errores, por favor contactarse con mesa de ayuda.");
                    }
                }

               
            }
            else
            {
                divAlerta.Visible = true;
                window.alert(this, "Faltan datos para realizar el ingreso.");
            }


        }
        else
        {
            if (validate())
            {
                divAlerta.Visible = false;

                if (txt004.Text.Trim() == "") txt004.Text = "N.N. MATERNO";

                DateTime FechNac = Convert.ToDateTime(cal001.Text);
                bool sw = false;
                if (FechNac.Year == DateTime.Now.Year)
                {
                    lblFechNac.Text = "La fecha de nacimiento corresponde a un niño menor de 1 año ¿Desea Continuar?";
                    lblFechNac.Visible = true;
                    lnk_si.Visible = true;
                    lnk_no.Visible = true;
                    lblFechNac.Focus();
                }
                else
                {
                    sw = true;
                }

                if (sw == true)
                {
                    SqlTransaction sqlt;
                    SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
                    sconn.Open();
                    sqlt = sconn.BeginTransaction();
                    try
                    {

                        int iden = ncoll.Insert_NinosTransaccional(sqlt,
                            DateTime.Now,
                            false,
                            txt001.Text.Trim().Replace(".", ""),
                            sexo,
                            txt002.Text.ToUpper(),
                            txt003.Text.ToUpper(),
                            txt004.Text.ToUpper(),
                            Convert.ToDateTime(cal001.Text),
                            Convert.ToInt32(ddown001.SelectedValue),
                            0, "0", 0, "0", "0", false, false, false, "N",
                            DateTime.Now, UserId,
                            Convert.ToInt32(ddown_tipo_nacionalidad.SelectedValue));

                        SSnino.CodNino = iden;

                        SSnino.FechaNacimiento = Convert.ToDateTime(cal001.Text);

                        // si voy a cerrar la ventana no necesito esto
                        //lblFechNac.Visible = false;
                        //lnk_no.Visible = false;
                        //lnk_si.Visible = false;

                        //ClientScript.RegisterClientScriptBlock(typeof(string), "SENAINFO2", "<script  languaje=javascript> window.opener.document.location.href = 'ninos_index.aspx?CODNUEVO= " + iden + "' </script>");
                        // window.close(this);

                        sqlt.Commit();
                        sconn.Close();

                        window.alert(this, "Ingreso de niño realizado satisfactoriamente.");
                        string url = "ninos_index.aspx?CODNUEVO= " + iden;
                        ClientScript.RegisterStartupScript(this.GetType(), "", "AbrirURLModalPopUp('" + url + "')", true);

                        //ClientScript.RegisterStartupScript(this.GetType(), "", "AbrirURLFancybox('" + url + "');return false;", true);
                        //ClientScript.RegisterStartupScript(this.GetType(), "", "CerrarFancybox();", true);

                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine(ex.Message);
                        try
                        {
                            // Attempt to roll back the transaction.
                            sqlt.Rollback();
                            window.alert(this, "Ingreso no realizado, por favor intentar nuevamente.");
                        }
                        catch (Exception exRollback)
                        {
                            // Throws an InvalidOperationException if the connection 
                            // is closed or the transaction has already been rolled 
                            // back on the server.
                            //Console.WriteLine(exRollback.Message);
                            window.alert(this, "Ingreso realizado con errores, por favor contactarse con mesa de ayuda.");
                        }
                    }
                }
            }
            else
            {
                divAlerta.Visible = true;
            }
        }
    }

    private void Ingreso2()
    {
        string url = "ninos_index.aspx?CODNUEVO=0";
        //ClientScript.RegisterStartupScript(this.GetType(), "", "AbrirURLFancybox('" + url + "')", true);
        //ClientScript.RegisterClientScriptBlock(typeof(string), "SENAINFO2", "<script  languaje=javascript>AbrirURLFancybox('" + url + "'); </script>");

        //window.alert(this, "Niño ingresado correctamente");
        //UpdateProgress1.Visible = true;
        //ClientScript.RegisterStartupScript(this.GetType(), "", "CerrarModalPopUp();", true);

        //return;

        string sexo = "M";
        string eg = "N";
        int nacionalidad = 0;
        if (rdo001.Checked)
        { sexo = "F"; }
        if (chk002.Checked)
        {
            eg = "S";
            sexo = "F";
        }
        if (Convert.ToInt32(ddown001.SelectedValue) > 0)
        {
            nacionalidad = Convert.ToInt32(ddown001.SelectedValue);
        }



        ninocoll ncoll = new ninocoll();
        //if (validate())
        //{

        if (eg == "S")
        {
            int comuna = 0;

            if (validateNinoGestacion())
            {
                divAlerta.Visible = false;

                if (txt002.Text.Trim() == "")
                {
                    txt002.Text = "N.N. Nombre";
                }
                if (txt004.Text.Trim() == "")
                {
                    txt004.Text = "N.N. Apellido";
                }

                if (txttelefono.Text.Trim() == "")
                {
                    txttelefono.Text = "0";
                }
                if (txt001M.Text.Trim() == "")
                {
                    txt001M.Text = "SIN OBSERVACION";
                }
                if (txt005.Text.Trim() == "")
                {
                    txt005.Text = "0";
                }
                if (txt007.Text.Trim() == "")
                {
                    txt007.Text = "0";
                }
                if (cal004.Text.ToUpper() == "")
                {
                    cal004.Text = "01-01-1900";
                }
                if (ddown010M.SelectedValue == "0" || ddown010M.SelectedValue == "")
                {
                    comuna = 0;
                }
                else
                {
                    comuna = Convert.ToInt32(ddown010M.SelectedValue);
                }

                SqlTransaction sqlt;
                SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
                sconn.Open();
                sqlt = sconn.BeginTransaction();

                try
                {

                    // Insert nino en gestacion  //OK

                    int iden = ncoll.Insert_NinosTransaccional(sqlt, Convert.ToDateTime("01-01-1900"), false, "0",
                        "F", txt002.Text.ToUpper(), "N.N. EN GESTACION", txt004.Text.ToUpper()
                        , Convert.ToDateTime("01-01-1900"), 0,
                        0, "0", 0, "0", "0", false, false, false, "S", DateTime.Now, UserId, 0);

                    SSnino.CodNino = iden;


                    int CodIE = ncoll.SetIngresos_Egresos(sqlt, SSnino.CodProyecto, iden, Convert.ToDateTime(cal004.Text)
                    , 28, false, 2, 9, 0, CodInmueble(), 0, 0, 0, "0", "0", 0, 0, -1, -1, false, "0", "0", "NO", DateTime.Now, UserId, Convert.ToDateTime("01-01-1900"), "0", 0, "0", 0, 0, 0, 0, 0);

                    SSnino.ICodIE = CodIE;

                    ncoll.Insert_CausalesIngresoTransaccional(sqlt, CodIE, 79, 1, "0", DateTime.Now, UserId, 0);

                    ncoll.Cierre_ingresoTransaccional(sqlt, CodIE, SSnino.CodProyecto, Convert.ToDateTime(cal004.Text), SSnino.CodNino, sexo, UserId);

                    //DateTime FechaNacimiento = Convert.ToDateTime("01-01-1900").Date;
                    //if (textbox.text != "Seleccione Fecha")
                    //{
                    //    FechaNacimiento = Convert.ToDateTime(textbox.text);
                    //}

                    if (Convert.ToString(VCod_PersonaRelacionada) != "-1")
                    {



                        ncoll.callto_insert_ninospersonasrelacionadasTransaccional(sqlt, VCod_PersonaRelacionada, SSnino.ICodIE, SSnino.CodNino
                            , Convert.ToDateTime(cal001M.Text), Convert.ToInt32(ddown005M.SelectedValue)
                            , Convert.ToInt32(ddown004M.SelectedValue)
                       , Convert.ToInt32(ddown002M.SelectedValue), Convert.ToInt32(ddown001M.SelectedValue)
                       , Convert.ToInt32(ddown003M.SelectedValue), Convert.ToInt32(ddown006M.SelectedValue)
                       , Convert.ToInt32(ddown007M.SelectedValue), Convert.ToInt32(ddown008M.SelectedValue)
                       , DateTime.Now, UserId);

                    }
                    else
                    {
                        int iden2;
                        DataTable identidad = ncoll.callto_insert_personasrelacionadas_2fTransaccional(sqlt, txt005.Text.Trim().Replace(".", ""), txt006.Text.Trim(), txt007.Text.Trim(), txt008.Text.Trim()
                            , "F", Convert.ToDateTime(cal005.Text), DateTime.Now, UserId, 1, comuna
                            , txt001M.Text.Trim(), txttelefono.Text.Trim());
                        iden2 = Convert.ToInt32(identidad.Rows[0][0]);


                        ncoll.callto_insert_ninospersonasrelacionadasTransaccional(sqlt, iden2, SSnino.ICodIE, SSnino.CodNino
                            , Convert.ToDateTime(cal001M.Text), Convert.ToInt32(ddown005M.SelectedValue)
                            , Convert.ToInt32(ddown004M.SelectedValue)
                       , Convert.ToInt32(ddown002M.SelectedValue), Convert.ToInt32(ddown001M.SelectedValue)
                       , Convert.ToInt32(ddown003M.SelectedValue), Convert.ToInt32(ddown006M.SelectedValue)
                       , Convert.ToInt32(ddown007M.SelectedValue), Convert.ToInt32(ddown008M.SelectedValue)
                       , DateTime.Now, UserId);


                    }

                    sqlt.Commit();
                    sconn.Close();

                    //window.close(this.Page);
                    //ClientScript.RegisterClientScriptBlock(typeof(string), "SENAINFO2", "<script  languaje=javascript>alert('Ingreso de niño en gestación realizado satisfactoriamente.'); window.close(); </script>");
                    window.alert(this, "Ingreso de niño en gestación realizado satisfactoriamente.");
                    ClientScript.RegisterStartupScript(this.GetType(), "", "CerrarModalPopUp();", true);


                }

                catch (Exception ex)
                {
                    //Console.WriteLine(ex.Message);
                    try
                    {
                        // Attempt to roll back the transaction.
                        sqlt.Rollback();
                        window.alert(this, "Ingreso no realizado, por favor intentar nuevamente.");
                    }
                    catch (Exception exRollback)
                    {
                        // Throws an InvalidOperationException if the connection 
                        // is closed or the transaction has already been rolled 
                        // back on the server.
                        //Console.WriteLine(exRollback.Message);
                        window.alert(this, "Ingreso realizado con errores, por favor contactarse con mesa de ayuda.");
                    }
                }
            }
            else
            {
                divAlerta.Visible = true;
            }

        }
        else
        {
            if (validate())
            {
                divAlerta.Visible = false;

                if (txt004.Text.Trim() == "")
                {
                    txt004.Text = "N.N. MATERNO";
                }
                DateTime FechNac = Convert.ToDateTime(cal001.Text);
                //bool sw = false;
                //if (FechNac.Year == DateTime.Now.Year)
                //{
                //    lblFechNac.Text = "La fecha de nacimiento corresponde a un niño menor de 1 año ¿Desea Continuar?";
                //    lblFechNac.Visible = true;
                //    lnk_si.Visible = true;
                //    lnk_no.Visible = true;
                //    lblFechNac.Focus();
                //}
                //else
                //{
                //    sw = true;
                //}
                //if (sw == true)
                //{

                SqlTransaction sqlt;
                SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
                sconn.Open();
                sqlt = sconn.BeginTransaction();

                try
                {

                    int iden = ncoll.Insert_NinosTransaccional(sqlt, DateTime.Now, false, txt001.Text.Trim().Replace(".", ""),
                      sexo, txt002.Text.ToUpper(), txt003.Text.ToUpper(), txt004.Text.ToUpper(), Convert.ToDateTime(cal001.Text),
                      Convert.ToInt32(ddown001.SelectedValue), 0, "0", 0, "0", "0", false, false, false, "N",
                      DateTime.Now, UserId, Convert.ToInt32(ddown_tipo_nacionalidad.SelectedValue));

                    SSnino.CodNino = iden;

                    SSnino.FechaNacimiento = Convert.ToDateTime(cal001.Text);

                    lblFechNac.Visible = false;
                    lnk_no.Visible = false;
                    lnk_si.Visible = false;

                    sqlt.Commit();
                    sconn.Close();

                    window.alert(this, "Ingreso de niño realizado satisfactoriamente.");
                    ClientScript.RegisterStartupScript(this.GetType(), "", "CerrarModalPopUp();", true);

                }

                catch (Exception ex)
                {
                    //Console.WriteLine(ex.Message);
                    try
                    {
                        // Attempt to roll back the transaction.
                        sqlt.Rollback();
                        window.alert(this, "Ingreso no realizado, por favor intentar nuevamente.");
                    }
                    catch (Exception exRollback)
                    {
                        // Throws an InvalidOperationException if the connection 
                        // is closed or the transaction has already been rolled 
                        // back on the server.
                        //Console.WriteLine(exRollback.Message);
                        window.alert(this, "Ingreso realizado con errores, por favor contactarse con mesa de ayuda.");
                    }
                }

                //}
            }
            else
            {
                divAlerta.Visible = true;
            }
        }


    }

    private int CodInmueble()
    {
        ninocoll ncoll = new ninocoll();
        int codinmueble = ncoll.CodInmueble(SSnino.CodProyecto);

        return codinmueble;

    }

    private bool validateNinoGestacion()
    {

        bool v = true;
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        //if ((!rdo001.Checked && !rdo002.Checked))
        //{
        //    rdo001.BackColor = colorCampoObligatorio;
        //    rdo002.BackColor = colorCampoObligatorio;
        //    v = false;
        //}
        try
        {
            DateTime tmp = Convert.ToDateTime(cal005.Text);
            cal005.BackColor = System.Drawing.Color.White;
        }
        catch
        {
            cal005.BackColor = colorCampoObligatorio;
            v = false;
        }

        //if (Convert.ToInt32(ddown001M.SelectedValue) == 0)
        //{
        //    ddown001M.BackColor = colorCampoObligatorio;
        //    v = false;
        //}
        //else ddown001M.BackColor = System.Drawing.Color.White;

        if (txt006.Text.Trim().Length < 2)
        {
            txt006.BackColor = colorCampoObligatorio;
            v = false;
        }
        else txt006.BackColor = System.Drawing.Color.White;

        if (txt008.Text.Trim().Length < 2)
        {
            txt008.BackColor = colorCampoObligatorio;
            v = false;
        }
        else txt008.BackColor = System.Drawing.Color.White;
        //if (cal001.Text == null)
        //{
        //    cal001.BackColor = colorCampoObligatorio;
        //    v = false;
        //}
        if (cal004.Text == null || cal004.Text == "")
        {
            cal004.BackColor = colorCampoObligatorio;
            v = false;
        }
        else cal004.BackColor = System.Drawing.Color.White;


        //if (cal005.Text == null)
        //{
        //    cal005.BackColor = colorCampoObligatorio;
        //    v = false;
        //}
        //else cal005.BackColor = System.Drawing.Color.White;

        try
        {
            DateTime tmp = Convert.ToDateTime(cal001M.Text);
            cal001M.BackColor = System.Drawing.Color.White;
        }
        catch
        {
            cal001M.BackColor = colorCampoObligatorio;
            v = false;
        }

        if (ddown001M.SelectedValue == "0")
        {
            ddown001M.BackColor = colorCampoObligatorio;
            v = false;
        }
        else ddown001M.BackColor = System.Drawing.Color.White;

        if (ddown002M.SelectedValue == "0")
        {
            ddown002M.BackColor = colorCampoObligatorio;
            v = false;
        }
        else ddown002M.BackColor = System.Drawing.Color.White;

        if (ddown003M.SelectedValue == "0")
        {
            ddown003M.BackColor = colorCampoObligatorio;
            v = false;
        }
        else ddown003M.BackColor = System.Drawing.Color.White;

        if (ddown004M.SelectedValue == "0")
        {
            ddown004M.BackColor = colorCampoObligatorio;
            v = false;
        }
        else ddown004M.BackColor = System.Drawing.Color.White;

        if (ddown005M.SelectedValue == "0")
        {
            ddown005M.BackColor = colorCampoObligatorio;
            v = false;
        }
        else ddown005M.BackColor = System.Drawing.Color.White;

        if (ddown006M.SelectedValue == "0")
        {
            ddown006M.BackColor = colorCampoObligatorio;
            v = false;
        }
        else ddown006M.BackColor = System.Drawing.Color.White;

        if (ddown010M.SelectedValue == "0")
        {
            ddown010M.BackColor = colorCampoObligatorio;
            v = false;
        }
        else ddown010M.BackColor = System.Drawing.Color.White;
        //if (ttxt_direccion.Text.Trim() == "")
        //{
        //    ttxt_direccion.BackColor = colorCampoObligatorio;
        //    v = false;
        //}



        return v;

    }

    private bool validate()
    {
        bool v = true;

        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis
        if (txt001.Text.Trim().Length < 4 && !chk001.Checked && !chk002.Checked)
        {
            txt001.BackColor = colorCampoObligatorio;
            v = false;
        }
        else
        {
            txt001.BackColor = System.Drawing.Color.White;
        }

        RangeValidator903.Validate();

        //if (txt001.Text.Trim() != "" && cal001.Text.Trim() == "" || RangeValidator903.IsValid == false)
        if (cal001.Text.Trim() == "" || RangeValidator903.IsValid == false)
        {
            cal001.BackColor = colorCampoObligatorio;
            v = false;

        }
        else
        {
            cal001.BackColor = System.Drawing.Color.White;
        }


        if (!rdo001.Checked && !rdo002.Checked)
        {
            rdo001.BackColor = colorCampoObligatorio;
            rdo002.BackColor = colorCampoObligatorio;
            v = false;
        }
        else
        {
            rdo001.BackColor = System.Drawing.Color.White;
            rdo002.BackColor = System.Drawing.Color.White;
        }
        if (Convert.ToInt32(ddown001.SelectedValue) == 0 && !chk002.Checked)
        {
            ddown001.BackColor = colorCampoObligatorio;
            v = false;
        }
        else
        {
            ddown001.BackColor = System.Drawing.Color.Empty;
        }

        if (Convert.ToInt32(ddown_tipo_nacionalidad.SelectedValue) == 0 && !chk002.Checked)
        {
            ddown_tipo_nacionalidad.BackColor = colorCampoObligatorio;
            v = false;
        }
        else
        {
            ddown_tipo_nacionalidad.BackColor = System.Drawing.Color.Empty;
        }

        if (!chk002.Checked && txt002.Text.Trim().Length < 2)
        {
            txt002.BackColor = colorCampoObligatorio;
            v = false;
        }
        else
        {
            txt002.BackColor = System.Drawing.Color.White;
        }

        if (!chk002.Checked && txt003.Text.Trim().Length < 2)
        {
            txt003.BackColor = colorCampoObligatorio;
            v = false;
        }
        else
        {
            txt003.BackColor = System.Drawing.Color.White;
        }


        // Valida nino en gestacion 

        if (chk002.Checked == true)
        {
            if (txt006.Text.Trim().Length < 2)
            {
                txt006.BackColor = colorCampoObligatorio;
                v = false;
            }
            else
            {
                txt006.BackColor = System.Drawing.Color.White;
            }
            if (txt007.Text.Trim().Length < 2)
            {
                txt007.BackColor = colorCampoObligatorio;
                v = false;
            }
            else
            {
                txt007.BackColor = System.Drawing.Color.White;
            }

        }

        return v;

    }

    protected void chk002_CheckedChanged(object sender, EventArgs e)
    {

        setgestacion();
        if (chk002.Checked == true)
        {
            ddown_tipo_nacionalidad.Enabled = false;
            



        }
        else
        {
            pnl004.Visible = false;
            ddown_tipo_nacionalidad.Enabled = true;
        }


    }

    private void setgestacion()
    {
        cal004.Enabled = true;
        txt001.Enabled = !chk002.Checked;
        chk001.Enabled = !chk002.Checked;
        if (chk002.Checked)
        {
            txt001.Text = "";
            txt003.Text = "N.N En Gestación";
            txt002.Text = "N.N";
            rdo001.Checked = true;
        }
        else
        {
            txt003.Text = "";
        }
        cal001.Enabled = !chk002.Checked;
        rdo001.Enabled = !chk002.Checked;
        rdo002.Enabled = !chk002.Checked;
        rdo001.Checked = true;
        rdo002.Checked = false;
        txt003.Enabled = !chk002.Checked;
        //txt004.Enabled = !chk002.Checked;
        ddown001.Enabled = !chk002.Checked;
        ddown_tipo_nacionalidad.Enabled = !chk002.Checked;
        txt005.Enabled = chk002.Checked;
        txt006.Enabled = chk002.Checked;
        txt007.Enabled = chk002.Checked;
        txt008.Enabled = chk002.Checked;
        btn002.Visible = chk002.Checked;
        cal004.Enabled = chk002.Checked;
        //btn003.Visible = chk002.Checked;

        //  chk003.Enabled = !chk002.Checked;

        pnl004.Visible = true;



        #region NINOS_PERSONAS_REL

        parcoll par = new parcoll();

        proyectocoll pcP = new proyectocoll();
        DataTable dtProyecto = pcP.GetProyectos(SSnino.CodProyecto.ToString());
        int CodModeloIntervencion = Convert.ToInt32(dtProyecto.Rows[0]["CodModeloIntervencion"].ToString());

        DataView dv1M = new DataView(par.GetparNacionalidades());
        dv1M.Sort = "CodNacionalidad";
        ddown001M.DataSource = dv1M;
        ddown001M.DataValueField = "CodNacionalidad";
        ddown001M.DataTextField = "Descripcion";
        ddown001M.DataBind();

        DataView dv2 = new DataView(par.GetparProfesionOficio());
        ddown002M.DataSource = dv2;
        ddown002M.DataTextField = "Descripcion";
        ddown002M.DataValueField = "CodProfesion";
        dv2.Sort = "Descripcion";
        ddown002M.DataBind();

        DataView dv3 = new DataView(par.GetparActividad(CodModeloIntervencion));
        ddown003M.Items.Clear();
        ddown003M.Items.Add(new ListItem(" Seleccionar", "0"));
        ddown003M.DataSource = dv3;
        ddown003M.DataTextField = "Descripcion";
        ddown003M.DataValueField = "CodActividad";
        dv3.Sort = "Descripcion";
        ddown003M.DataBind();

        DataView dv4 = new DataView(par.GetparEscolaridadAdulto());
        ddown004M.DataSource = dv4;
        ddown004M.DataTextField = "Descripcion";
        ddown004M.DataValueField = "CodEscolaridadAdulto";
        dv4.Sort = "Descripcion";
        ddown004M.DataBind();


        ////////////////ddwn situacion////////////

        DataView dv6;
        DataView dv7;
        DataView dv8;

        if (CodModeloIntervencion == 91 || CodModeloIntervencion == 92)   // ModIntervencion FAS o FAE
        {
            if (ddown003M.SelectedValue.ToString() == "20" || ddown003M.SelectedValue.ToString() == "21")
            {
                dv6 = new DataView(par.GetparSituacionPerRel(1));
                dv7 = new DataView(par.GetparSituacionPerRel(2));
                dv8 = new DataView(par.GetparSituacionPerRel(3));
            }
            else
            {
                dv6 = new DataView(par.GetparSituacionPerRel(0));
                dv7 = new DataView(par.GetparSituacionPerRel(0));
                dv8 = new DataView(par.GetparSituacionPerRel(0));
            }
            ddown006M.DataSource = dv6;
            ddown006M.DataTextField = "Descripcion";
            ddown006M.DataValueField = "CodSituacion";
            dv6.Sort = "Descripcion";
            ddown006M.DataBind();

            ddown007M.DataSource = dv7;
            ddown007M.DataTextField = "Descripcion";
            ddown007M.DataValueField = "CodSituacion";
            dv7.Sort = "Descripcion";
            ddown007M.DataBind();

            ddown008M.DataSource = dv8;
            ddown008M.DataTextField = "Descripcion";
            ddown008M.DataValueField = "CodSituacion";
            dv8.Sort = "Descripcion";
            ddown008M.DataBind();
        }
        else
        {
            dv6 = new DataView(par.GetparSituacionPerRel());
            ddown006M.DataSource = dv6;
            ddown006M.DataTextField = "Descripcion";
            ddown006M.DataValueField = "CodSituacion";
            dv6.Sort = "Descripcion";
            ddown006M.DataBind();

            dv7 = new DataView(par.GetparSituacionPerRel());
            ddown007M.DataSource = dv7;
            ddown007M.DataTextField = "Descripcion";
            ddown007M.DataValueField = "CodSituacion";
            dv7.Sort = "Descripcion";
            ddown007M.DataBind();

            dv8 = new DataView(par.GetparSituacionPerRel());
            ddown008M.DataSource = dv8;
            ddown008M.DataTextField = "Descripcion";
            ddown008M.DataValueField = "CodSituacion";
            dv8.Sort = "Descripcion";
            ddown008M.DataBind();
        }
        DropDownList tddown009M = (DropDownList)this.Form.FindControl("ddown009M");
        DataView dv9 = new DataView(par.GetparRegion());
        tddown009M.DataSource = dv9;
        tddown009M.DataTextField = "Descripcion";
        tddown009M.DataValueField = "CodRegion";
        dv9.Sort = "CodRegion";
        tddown009M.DataBind();



        /////////////////Fin ddwn situacion////////////////

        DataView dv5 = new DataView(par.GetparTipoRelacion());
        ddown005M.DataSource = dv5;
        ddown005M.DataTextField = "Descripcion";
        ddown005M.DataValueField = "TipoRelacion";
        dv5.Sort = "Descripcion";
        ddown005M.DataBind();



        #endregion



    }


    protected void chk001_CheckedChanged(object sender, EventArgs e)
    {
        txt001.Enabled = !chk001.Checked;
    }
    protected void btn002_Click(object sender, EventArgs e)
    {
        ninocoll ncoll = new ninocoll();
        string run = "";
        bool v = false;
        lblb001.Visible = false;

        if (txt005.Text.Trim().Length > 4 && CustomValidator2.IsValid == true)
        {
            run = txt005.Text.Trim().Replace(".","");
            v = true;
        }
        if (txt006.Text.Trim().Length > 2 && (txt007.Text.Trim().Length > 2 || txt008.Text.Trim().Length > 2))
        {
            v = true;

        }

        if (v)
        {
            DataTable dt = ncoll.callto_search_persona_realcionada(run.Trim().Replace(".",""), txt006.Text, txt008.Text, txt007.Text, run.Length);
            DataView dv = new DataView(dt);
            grd001.DataSource = dv;
            grd001.DataBind();
            grd001.Visible = true;
        }
        else
        {
            lblb001.Visible = true;
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
    protected void grd001_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ninocoll ncoll = new ninocoll();
        DataTable dt = ncoll.GetPersonasRelacionadas(Convert.ToInt32(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text));
        txt005.Text = dt.Rows[1][1].ToString();
        txt006.Text = dt.Rows[1][2].ToString();
        txt007.Text = dt.Rows[1][3].ToString();
        txt008.Text = dt.Rows[1][4].ToString();
        txt004.Text = dt.Rows[1][4].ToString();

        try
        {
            cal005.Text = FormatFecha(dt.Rows[1][6].ToString()); //FechaNacimiento
        }
        catch { }

        Madre mad = new Madre();


        mad.rut_madre = dt.Rows[1][1].ToString();
        mad.Nombres = dt.Rows[1][2].ToString();
        mad.ApePat = dt.Rows[1][3].ToString();
        mad.ApeMat = dt.Rows[1][4].ToString();

        string codPersoanRel = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;

        VCod_PersonaRelacionada = Convert.ToInt32(codPersoanRel);

        DataTable dt2 = new DataTable();
        grd001.DataSource = dt2;
        grd001.DataBind();
        grd001.Visible = false;
        pnl004.Visible = true;

    }

    ////////////////////////////////////////////////////////////////
    //                                                            //
    //  Boton agregar a la madre no se ocupa NO BORRAR            //
    //                                                            //  
    ////////////////////////////////////////////////////////////////
    protected void btn003_Click(object sender, EventArgs e)
    {

        grd001.Visible = false;
        btn002.Visible = true;
        btn003.Visible = true;
        Madre mad = new Madre();


        SSmadre.rut_madre = txt005.Text.Trim();
        SSmadre.Nombres = txt006.Text;
        SSmadre.ApePat = txt007.Text;
        SSmadre.ApeMat = txt008.Text;

        txt005.Text = "";
        txt006.Text = "";
        txt007.Text = "";
        txt008.Text = "";

        Response.Redirect("ninos_nuevapersonarel.aspx?MODE=1");
    }

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
                    lblexrut.Text = "";
                    lblexrut.Visible = false;
                    Function_Genera_String_Consulta(txt001.Text);
                }
            }
        }
        catch { }
    }
    private void Function_Genera_String_Consulta(string sParametrosConsulta)
    {
        ninocoll nic = new ninocoll();
        DataTable dt = nic.callto_get_ninoxrut(sParametrosConsulta);
        if (dt.Rows.Count > 0)
        {
            pnl006.Visible = true;
            grd003.DataSource = dt;
            grd003.DataBind();
            grd003.Visible = true;
            //pnl005.Visible = false;
            //pnl006.Visible = true;
            btn001.Visible = false;

        }
        else
        {
            pnl006.Visible = false;
            DataTable dtCL = new DataTable();
            dtCL.Rows.Clear();
            grd003.DataSource = dtCL;
            grd003.DataBind();
            grd003.Visible = false;
            btn001.Visible = true;
        }
    }
    //protected void txt005_ValueChange(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (txt005.Text.Length > 3)
    //        {
    //            string rutsinnada = txt005.Text.Replace(".", "").Replace(",", "").Replace("-", "").Trim();
    //            string digitoingresado = rutsinnada.Substring(rutsinnada.Length - 1, 1);

    //            string digitocalculado = digitoVerificador(Convert.ToInt32(rutsinnada.ToUpper().Replace("K", "").Substring(0, rutsinnada.Length - 1)));
    //            if (digitocalculado.ToUpper() == digitoingresado.ToUpper())
    //            {
    //                this.Form.FindControl("pnl001").Visible = false;
    //                string punorut = rutsinnada.ToUpper().Replace("K", "").Substring(0, rutsinnada.Length - 1).Trim();
    //                string rcompleto = punorut + "-" + digitocalculado.ToUpper();
    //                txt005.Text = rcompleto;
    //            }
    //            else
    //            {
    //                txt005.Text = "";
    //                ((Label)Form.FindControl("lbl001")).Text = "RUT INGRESADO NO ES VALIDO";
    //                this.Form.FindControl("pnl001").Visible = true;
    //            }
    //        }
    //        else
    //        {
    //            txt005.Text = "";
    //            ((Label)Form.FindControl("lbl001")).Text = "RUT INGRESADO NO ES VALIDO";
    //            this.Form.FindControl("pnl001").Visible = true;
    //        }
    //    }
    //    catch
    //    {
    //        ((Label)Form.FindControl("lbl001")).Text = "RUT INGRESADO NO ES VALIDO";
    //        this.Form.FindControl("pnl001").Visible = true;
    //    }
    //}


    protected void cal004_ValueChanged(object sender, EventArgs e)
    {

        if (ConfigurationSettings.AppSettings["cierre_mes"].ToString() == "1")
        {
            DateTime fecha = DateTime.Now;
            if (cal004.Text.ToUpper() != "")
            {
                RangeValidator1.Validate();
                if (RangeValidator1.IsValid == true)
                {
                    fecha = Convert.ToDateTime(cal004.Text);
                }

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
                lbl002.Text = "El mes esta cerrado";
                cal004.Text = "";
                lbl002.Visible = true;
            }
            else
            {
                lbl002.Visible = false;
            }


        }



    }
    protected void btn004_Click(object sender, EventArgs e)
    {
        int iden = Convert.ToInt32(grd003.Rows[0].Cells[0].Text);
        ninocoll nin = new ninocoll();
        int EstadoIE = nin.Get_EstadoIExNino(iden, SSnino.CodProyecto);

        if (EstadoIE == 0)
        {
            //ClientScript.RegisterClientScriptBlock(typeof(string), "SENAINFO2", "<script  languaje=javascript> alert('EL niño ya ha sido ingresado.'); </script>");
            Response.Write("<script language='javascript'>alert(''EL niño ya ha sido ingresado.');</script>");
        }
        else
        {
            //ClientScript.RegisterClientScriptBlock(typeof(string), "SENAIResponse.Redirect("ninos_index.aspx?CODNUEVO="+ iden);
            string script = "AbrirURLModalPopUp('ninos_index.aspx?CODNUEVO=" + iden + "')";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "", script, true);

        }

    }

    protected void lnk_si_Click(object sender, EventArgs e)
    {
        Ingreso2();
    }
    protected void lnk_no_Click(object sender, EventArgs e)
    {
        lbl_avisoFecha.Text = "Ingrese una nueva Fecha";
        lbl_avisoFecha.Visible = true;
        lblFechNac.Visible = false;
        lnk_no.Visible = false;
        lnk_si.Visible = false;
        OpNo();
        //window.close(this.Page);

    }
    private void OpNo()
    {
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis
        lbl_avisoFecha.Text = "Ingrese una nueva Fecha de nacimiento";
        cal001.BackColor = colorCampoObligatorio;
        //Ingreso3();

    }

    //private void Ingreso3()
    //{

    //    string sexo = "M";
    //    string eg = "N";

    //    cal001.BackColor = colorCampoObligatorio;
    //    int nacionalidad = 0;
    //    if (rdo001.Checked)
    //    { sexo = "F"; }
    //    if (chk002.Checked)
    //    {
    //        eg = "S";
    //        sexo = "F";
    //    }
    //    if (Convert.ToInt32(ddown001.SelectedValue) > 0)
    //    {
    //        nacionalidad = Convert.ToInt32(ddown001.SelectedValue);
    //    }

    //    ninocoll ncoll = new ninocoll();
    //    //if (validate())
    //    //{

    //    if (eg == "S")
    //    {
    //        int comuna = 0;

    //        if (validateNinoGestacion())
    //        {
    //            if (txt002.Text.Trim() == "")
    //            {
    //                txt002.Text = "N.N. Nombre";
    //            }
    //            if (txt004.Text.Trim() == "")
    //            {
    //                txt004.Text = "N.N. Apellido";
    //            }




    //            if (txttelefono.Text.Trim() == "")
    //            {
    //                txttelefono.Text = "0";
    //            }
    //            if (txt001M.Text.Trim() == "")
    //            {
    //                txt001M.Text = "SIN OBSERVACION";
    //            }
    //            if (txt005.Text.Trim() == "")
    //            {
    //                txt005.Text = "0";
    //            }
    //            if (txt007.Text.Trim() == "")
    //            {
    //                txt007.Text = "0";
    //            }
    //            if (cal004.Text.ToUpper() == "SELECCIONE FECHA")
    //            {
    //                cal004.Text = "01-01-1900";
    //            }
    //            if (ddown010M.SelectedValue == "0" || ddown010M.SelectedValue == "")
    //            {
    //                comuna = 0;
    //            }
    //            else
    //            {
    //                comuna = Convert.ToInt32(ddown010M.SelectedValue);
    //            }


    //            // Insert nino en gestacion  //OK

    //            int iden = ncoll.Insert_Ninos(Convert.ToDateTime("01-01-1900"), false, "0",
    //                "F", txt002.Text.ToUpper(), "N.N. EN GESTACION", txt004.Text.ToUpper()
    //                , Convert.ToDateTime("01-01-1900"), 0,
    //                0, "0", 0, "0", "0", false, false, false, "N", DateTime.Now, Convert.ToInt32(Session["userid"]));

    //            SSnino.CodNino = iden;

    //            int CodIE = ncoll.SetIngresos_Egresos(SSnino.CodProyecto, iden, Convert.ToDateTime(cal004.Text)
    //            , 28, false, 2, 9, 0, CodInmueble(), 0, 0, 0, "0", "0", 0, 0, -1, -1, false, "0", "0", "NO", DateTime.Now, Convert.ToInt32(Session["userid"]), Convert.ToDateTime("01-01-1900"), "0", 0, "0", 0, 0, 0, 0, 0);

    //            SSnino.ICodIE = CodIE;

    //            ncoll.Insert_CausalesIngreso(
    //                 CodIE,
    //                 79, 1, "0", DateTime.Now, Convert.ToInt32(Session["userid"]), 0);


    //            ncoll.Cierre_ingreso(CodIE, SSnino.CodProyecto, Convert.ToDateTime(cal004.Text)
    //            , SSnino.CodNino, sexo, Convert.ToInt32(Session["userid"]));



    //            //DateTime FechaNacimiento = Convert.ToDateTime("01-01-1900").Date;
    //            //if (textbox.text != "Seleccione Fecha")
    //            //{
    //            //    FechaNacimiento = Convert.ToDateTime(textbox.text);
    //            //}

    //            if (Convert.ToString(VCod_PersonaRelacionada) != "-1")
    //            {



    //                ncoll.callto_insert_ninospersonasrelacionadas(VCod_PersonaRelacionada, SSnino.ICodIE, SSnino.CodNino
    //                    , Convert.ToDateTime(cal001M.Text), Convert.ToInt32(ddown005M.SelectedValue)
    //                    , Convert.ToInt32(ddown004M.SelectedValue)
    //               , Convert.ToInt32(ddown002M.SelectedValue), Convert.ToInt32(ddown001M.SelectedValue)
    //               , Convert.ToInt32(ddown003M.SelectedValue), Convert.ToInt32(ddown006M.SelectedValue)
    //               , Convert.ToInt32(ddown007M.SelectedValue), Convert.ToInt32(ddown008M.SelectedValue)
    //               , DateTime.Now, Convert.ToInt32(Session["userid"]));
    //                window.close(this.Page);
    //            }
    //            else
    //            {
    //                int iden2;
    //                DataTable identidad = ncoll.callto_insert_personasrelacionadas_2f(txt005.Text.Trim(), txt006.Text.Trim(), txt007.Text.Trim(), txt008.Text.Trim()
    //                    , "F", Convert.ToDateTime(cal005.Text), DateTime.Now, Convert.ToInt32(Session["userid"]), 1, comuna
    //                    , txt001M.Text.Trim(), txttelefono.Text.Trim());
    //                iden2 = Convert.ToInt32(identidad.Rows[0][0]);


    //                ncoll.callto_insert_ninospersonasrelacionadas(iden2, SSnino.ICodIE, SSnino.CodNino
    //                    , Convert.ToDateTime(cal001M.Text), Convert.ToInt32(ddown005M.SelectedValue)
    //                    , Convert.ToInt32(ddown004M.SelectedValue)
    //               , Convert.ToInt32(ddown002M.SelectedValue), Convert.ToInt32(ddown001M.SelectedValue)
    //               , Convert.ToInt32(ddown003M.SelectedValue), Convert.ToInt32(ddown006M.SelectedValue)
    //               , Convert.ToInt32(ddown007M.SelectedValue), Convert.ToInt32(ddown008M.SelectedValue)
    //               , DateTime.Now, Convert.ToInt32(Session["userid"]));
    //                window.close(this.Page);

    //            }

    //            ClientScript.RegisterClientScriptBlock(typeof(string), "SENAINFO2", "<script  languaje=javascript>alert('Ingreso de niño en gestación realizado satisfactoriamente.'); window.close(); </script>");
    //        }

    //    }
    //    else
    //    {
    //        if (validate())
    //        {
    //            if (txt004.Text.Trim() == "")
    //            {
    //                txt004.Text = "N.N. MATERNO";
    //            }
    //            DateTime FechNac = Convert.ToDateTime(cal001.Text);
    //            //bool sw = false;
    //            //if (FechNac.Year == DateTime.Now.Year)
    //            //{
    //            //    lblFechNac.Text = "La fecha de nacimiento corresponde a un niño menor de 1 año ¿Desea Continuar?";
    //            //    lblFechNac.Visible = true;
    //            //    lnk_si.Visible = true;
    //            //    lnk_no.Visible = true;
    //            //    lblFechNac.Focus();


    //            //}
    //            //else
    //            //{
    //            //    sw = true;
    //            //}


    //            //if (sw == true)
    //            //{
    //            int iden = ncoll.Insert_Ninos(DateTime.Now, false, txt001.Text,
    //              sexo, txt002.Text.ToUpper(), txt003.Text.ToUpper(), txt004.Text.ToUpper(), Convert.ToDateTime(cal001.Text),
    //              Convert.ToInt32(ddown001.SelectedValue), 0, "0", 0, "0", "0", false, false, false, "N",
    //              DateTime.Now, Convert.ToInt32(Session["userid"]));

    //            SSnino.CodNino = iden;

    //            SSnino.FechaNacimiento = Convert.ToDateTime(cal001.Text);

    //            lblFechNac.Visible = false;
    //            lnk_no.Visible = false;
    //            lnk_si.Visible = false;

    //            ClientScript.RegisterClientScriptBlock(typeof(string), "SENAINFO2", "<script  languaje=javascript> window.opener.document.location.href = 'ninos_index.aspx?CODNUEVO= " + iden + "' </script>");
    //            window.close(this);
    //            //}
    //        }
    //    }


    //}

    protected void ddown001_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void grd001_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddown001M_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddown003M_SelectedIndexChanged(object sender, EventArgs e)
    {
        parcoll par = new parcoll();
        proyectocoll pcP = new proyectocoll();
        DataTable dtProyecto = pcP.GetProyectos(SSnino.CodProyecto.ToString());
        int CodModeloIntervencion = Convert.ToInt32(dtProyecto.Rows[0]["CodModeloIntervencion"].ToString());

        ////////////////ddwn situacion////////////
        DataView dv6;
        DataView dv7;
        DataView dv8;

        if (CodModeloIntervencion == 91 || CodModeloIntervencion == 92)   // ModIntervencion FAS o FAE
        {
            if (ddown003M.SelectedValue.ToString() == "20" || ddown003M.SelectedValue.ToString() == "21")
            {
                dv6 = new DataView(par.GetparSituacionPerRel(1));
                dv7 = new DataView(par.GetparSituacionPerRel(2));
                dv8 = new DataView(par.GetparSituacionPerRel(3));
            }
            else
            {
                dv6 = new DataView(par.GetparSituacionPerRel(0));
                dv7 = new DataView(par.GetparSituacionPerRel(0));
                dv8 = new DataView(par.GetparSituacionPerRel(0));
            }

            ddown006M.Items.Clear();
            ddown006M.DataSource = dv6;
            ddown006M.DataTextField = "Descripcion";
            ddown006M.DataValueField = "CodSituacion";
            dv6.Sort = "Descripcion";
            ddown006M.DataBind();

            //DataView dv7 = new DataView(par.GetparSituacionPerRel(2));
            ddown007M.Items.Clear();
            ddown007M.DataSource = dv7;
            ddown007M.DataTextField = "Descripcion";
            ddown007M.DataValueField = "CodSituacion";
            dv7.Sort = "Descripcion";
            ddown007M.DataBind();

            //DataView dv8 = new DataView(par.GetparSituacionPerRel(3));
            ddown008M.Items.Clear();
            ddown008M.DataSource = dv8;
            ddown008M.DataTextField = "Descripcion";
            ddown008M.DataValueField = "CodSituacion";
            dv8.Sort = "Descripcion";
            ddown008M.DataBind();
        }
    }

    protected void rv_año_Init(object sender, EventArgs e)
    {
        ((RangeValidator)sender).MaximumValue = DateTime.Today.ToString("yyyy");
        ((RangeValidator)sender).MinimumValue = "1900";

    }
    protected void rv_fecha_Init(object sender, EventArgs e)
    {
        ((RangeValidator)sender).MaximumValue = DateTime.Today.ToString("dd-MM-yyyy");
        ((RangeValidator)sender).MinimumValue = "01-01-1900";

    }

    protected void ddown_tipo_nacionalidad_SelectedIndexChanged(object sender, EventArgs e)
    {

        ddown001.Items.FindByValue("1").Enabled = true;
        if (ddown_tipo_nacionalidad.SelectedValue == "1" || ddown_tipo_nacionalidad.SelectedValue == "3") // verifica si se selecciona tipo de nacionalidad chileno o nacionalizado 
        {
            if (ddown001.Items.FindByValue("2").Enabled == true) //verifica si las nacionalidades que no son chilenas estan visibles
            {
                for (int i = 2; i <= ddown001.Items.Count -1; i++)
                {
                    if (ddown001.Items[i] != null) // el 8 no existe
                    {
                        ddown001.Items[i].Enabled = false;
                        //ddown001.Items.FindByValue(Convert.ToString(i)).Enabled = false;
                    }
                }
            }
            ddown001.SelectedValue = "1";
        }
        else // todas las demas
        {
            if (ddown001.Items.FindByValue("2").Enabled == false) //verifica si las nacionalidades que no son chilenas estan ocultas
            {
                for (int i = 2; i <= ddown001.Items.Count -1; i++)
                {
                    if (ddown001.Items[i] != null) // el 8 no existe
                    {
                        ddown001.Items[i].Enabled = true;
                        //ddown001.Items.FindByValue(Convert.ToString(i)).Enabled = true;
                    }
                }
            }
            if (ddown_tipo_nacionalidad.SelectedValue == "2") // verifica si se selecciona tipo de nacionalidad extrangero (ocultar nacionalidad chilena)
            {
                ddown001.Items.FindByValue("1").Enabled = false; // oculta nacionalidad chilena


            }

            if (ddown_tipo_nacionalidad.SelectedValue == "0")
            {
                for (int i = 1; i <= ddown001.Items.Count -1; i++)
                {
                    if (ddown001.Items[i] != null) // el 8 no existe
                    {
                        ddown001.Items[i].Enabled = false;
                        //ddown001.Items.FindByValue(Convert.ToString(i)).Enabled = false;

                    }
                }
                ddown001.SelectedValue = "0";
            }
        }
    }
}
