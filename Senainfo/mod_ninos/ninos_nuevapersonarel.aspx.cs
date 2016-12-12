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
using Argentis.Regmen;
using CustomWebControls;
using System.Data.Sql;
using System.Collections.Generic;
using System.Data.SqlClient;




public partial class mod_ninos_nuevapersonarel : System.Web.UI.Page
{

    public bool swLrpa
    {
        get
        {
            if (ViewState["swLrpa"] == null)
            { ViewState["swLrpa"] = -1; }
            return Convert.ToBoolean(ViewState["swLrpa"]);
        }
        set { ViewState["swLrpa"] = value; }
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
    public int VCodPersonaRelacionada
    {
        get
        {
            if (ViewState["VCodPersonaRelacionada"] == null)
            { ViewState["VCodPersonaRelacionada"] = -1; }
            return Convert.ToInt32(ViewState["VCodPersonaRelacionada"]);
        }
        set { ViewState["VCodPersonaRelacionada"] = value; }
    }
    private string dir = string.Empty;

    public string Rut { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        alert.Attributes.Add("style", "display:none");
        lbl0055.Attributes.Add("style", "display:none");
        alert2.Attributes.Add("style", "display:none");
        lbl00552.Attributes.Add("style", "display:none");
        //if (hBtnBorrar.Value != null && hBtnBorrar.Value != "")
        //{
        //    btnB001.Visible = Convert.ToBoolean(hBtnBorrar.Value);
        //}

        Rut = txtb001.Text.Trim();
        
        dir = Request.QueryString["dir"];

        if (!IsPostBack)
        {

            bool sw1 = true;
            if (Request.QueryString["CodPersonaRelacionada"] != null)
            {
                VCodPersonaRelacionada = Convert.ToInt32(Request.QueryString["CodPersonaRelacionada"]);
                getdata();
                sw1 = false;
            }
            # region VALIDACION USUARIO


            if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
                Response.Write("<script>parent.location.href='../autenticacion.aspx';</script>");
            else
            {

                //B122B56F-15E0-4488-B5FE-FEADD035CF36 2.4
                if (!window.existetoken("B122B56F-15E0-4488-B5FE-FEADD035CF36") || !window.existetoken("79270734-C383-487D-8EAB-BC63F1521932") || !window.existetoken("3FE17A39-80A0-4F7A-9A46-EC2BB934697D") || !window.existetoken("B122B56F-15E0-4488-B5FE-FEADD035CF36") || !window.existetoken("45442D35-CC14-45C6-89F8-C7F6892D919A"))
                    Response.Write("<script>parent.location.href='../autenticacion.aspx';</script>"); ;



                validatescurity(); //LO ULTIMO DEL LOAD
                CalendarExtende1052.StartDate = SSnino.fchingdesde;
                //cal002.MinDate = SSnino.fchingdesde;
                CalendarExtende1052.EndDate = DateTime.Now;
                //cal002.MaxDate = DateTime.Now;

                swLrpa = FiltroLRPA();

                
                if (VCodPersonaRelacionada > 0)
                {
                    modificaraccion();
                    btn001.Text = "Modificar Persona Relacionada";

                    lblTitulo.Text = btn001.Text;
                    //btn002.Visible = false;
                    btnB001.Visible = false;
                    pnlBuscar.Visible = false;
                    pnlAgregar.Visible = true;
                }
                else
                {
                    limpiar();
                    btn001.Text = "Agregar Persona Relacionada";
                    lblTitulo.Text = btn001.Text;
                    //btn002.Visible = true;
                    //btnB001.Visible = true;
                    pnlBuscar.Visible = true;
                    pnlAgregar.Visible = false;
                }

                if (swLrpa)
                {
                    txt001.Enabled = false; //rut
                    txt001.Text = "";
                    txt002.Enabled = false; //nomb
                    txt002.Text = "N.N.";
                    txt003.Enabled = false; // ap pat
                    txt003.Text = "N.N.";
                    txt004.Enabled = false; // ap mat
                    txt004.Text = "N.N.";
                    btnB001.Visible = false; //llama a panel buscar
                    if (ddown005.SelectedValue != "0") // tipo relacion
                        txt003.Text = "N.N. " + ddown005.SelectedItem.Text;
                    btn001.CausesValidation = false;
                }
                else
                {
                    txt001.Enabled = true;
                    txt002.Enabled = true;
                    txt003.Enabled = true;
                    txt004.Enabled = true;
                    btn004.Enabled = true;
                    btnB001.Visible = true;
                }

                if (sw1) getdata();   
            }

            if (Request.QueryString["mode"] != null)
            {
                rdo001.Checked = true;
                rdo002.Enabled = false;
                txt001.Text = SSmadre.rut_madre;
                txt002.Text = SSmadre.Nombres;
                txt003.Text = SSmadre.ApePat;
                txt004.Text = SSmadre.ApeMat;
            }



            #endregion

        }

        ScriptManager.RegisterStartupScript(this, this.GetType(), "r", "window.parent.agregarValidaRutPersonaRelacionada();", true);
    }


    #region VISIBILIDAD DE FUNCIONALIDADES SEGUN PERMISOS

    private void validatescurity()
    {
        #region PESRSONAS RELACIONADAS

        //B122B56F-15E0-4488-B5FE-FEADD035CF36 2.4_VER
        if (!window.existetoken("B122B56F-15E0-4488-B5FE-FEADD035CF36"))
        {
            btn001.Visible = false;
            //btn002_2f.Visible = false;
        }

        //21A824F4-19EC-4D44-9C44-C4136DD5AC66 2.4_MODIFICAR
        if (!window.existetoken("21A824F4-19EC-4D44-9C44-C4136DD5AC66"))
        {
            grd001buscar.Columns[5].Visible = false;
        }
        #endregion



    }

    #endregion




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

        ninocoll ncoll = new ninocoll();
        DataTable dt = new DataTable();
        DropDownList tddown009 = (DropDownList)this.Form.FindControl("ddown009");
        DropDownList tddown010 = (DropDownList)this.Form.FindControl("ddown010");
        TextBox ttxttelefono = (TextBox)this.Form.FindControl("txttelefono");
        SenameTextBox ttxt_direccion = (SenameTextBox)this.Form.FindControl("txt_direccion");



        dt = ncoll.callto_getpersonasrelacionadas(VCodPersonaRelacionada, SSnino.ICodIE);
        try
        {
            txt001.Text = dt.Rows[0][0].ToString();
            txt001.Text.Trim();
        }
        catch { }
        try
        {
            txt002.Text = dt.Rows[0][1].ToString();
        }
        catch { }
        try
        {
            txt003.Text = dt.Rows[0][2].ToString();
        }
        catch { }
        try
        {
            txt004.Text = dt.Rows[0][3].ToString();
        }
        catch { }
        try
        {

            if (dt.Rows[0][4].ToString() == "M")
            {
                rdo002.Checked = true;
                rdo001.Checked = false;
            }
            else
            {
                rdo001.Checked = true;
                rdo002.Checked = false;
            }


        }
        catch { }
        try
        {
            cal001.Text = FormatFecha(dt.Rows[0][5].ToString());
        }
        catch { }

        try
        {
            ddown_tipo_nacionalidad.SelectedValue = dt.Rows[0][19].ToString();
            if (ddown_tipo_nacionalidad.SelectedValue != "0")
                getNacionalidad();
                
        }
        catch
        {
            ddown_tipo_nacionalidad.SelectedValue = "0";
        }

        try
        {
            ddown001.SelectedValue = dt.Rows[0][6].ToString();
        }
        catch {
            ddown001.SelectedIndex = 0;
        }
        try
        {
            ddown002.SelectedValue = dt.Rows[0][7].ToString();
        }
        catch {

            ddown002.SelectedIndex = 0;
        }
        try
        {
            ddown003.SelectedValue = dt.Rows[0][8].ToString();
        }
        catch {
            ddown004.SelectedIndex = 0;
        }
        try
        {
            ddown004.SelectedValue = dt.Rows[0][9].ToString();
        }
        catch {
            ddown004.SelectedIndex = 0;
        }
        try
        {
            if (dt.Rows[0][8].ToString() == "20" || dt.Rows[0][8].ToString() == "21")
            {

                parcoll par = new parcoll();
                proyectocoll pcP = new proyectocoll();
                DataTable dtProyecto = pcP.GetProyectos(SSnino.CodProyecto.ToString());
                int CodModeloIntervencion = Convert.ToInt32(dtProyecto.Rows[0]["CodModeloIntervencion"].ToString());

                ////////////////ddwn situacion////////////
                DataView dv6;
                DataView dv7;
                DataView dv8;

                dv6 = new DataView(par.GetparSituacionPerRel(1));
                dv7 = new DataView(par.GetparSituacionPerRel(2));
                dv8 = new DataView(par.GetparSituacionPerRel(3));

                ddown006.Items.Clear();
                ddown006.DataSource = dv6;
                ddown006.DataTextField = "Descripcion";
                ddown006.DataValueField = "CodSituacion";
                dv6.Sort = "Descripcion";
                ddown006.DataBind();

                //DataView dv7 = new DataView(par.GetparSituacionPerRel(2));
                ddown007.Items.Clear();
                ddown007.DataSource = dv7;
                ddown007.DataTextField = "Descripcion";
                ddown007.DataValueField = "CodSituacion";
                dv7.Sort = "Descripcion";
                ddown007.DataBind();

                //DataView dv8 = new DataView(par.GetparSituacionPerRel(3));
                ddown008.Items.Clear();
                ddown008.DataSource = dv8;
                ddown008.DataTextField = "Descripcion";
                ddown008.DataValueField = "CodSituacion";
                dv8.Sort = "Descripcion";
                ddown008.DataBind();

            }
            ddown006.SelectedValue = dt.Rows[0][10].ToString();
        }
        catch { }
        try
        {
            ddown007.SelectedValue = dt.Rows[0][11].ToString();
        }
        catch { }
        try
        {
            ddown008.SelectedValue = dt.Rows[0][12].ToString();
        }
        catch { }
        try
        {
            ddown005.SelectedValue = dt.Rows[0][13].ToString();
        }
        catch { }
        try
        {
            cal002.Text = FormatFecha(dt.Rows[0][14].ToString());
        }
        catch { }
        try
        {
            ttxt_direccion.Text = dt.Rows[0][16].ToString();
        }
        catch { }


        //try
        //{
        //    tddown010.SelectedValue = dt.Rows[0][15].ToString();
        //}
        //catch { }
        try
        {
            ttxttelefono.Text = dt.Rows[0][17].ToString();
        }
        catch { }
        try
        {
            ddown009.SelectedValue = dt.Rows[0][18].ToString();
        }
        catch { }

        try
        {
            parcoll par = new parcoll();
            DataView dv10 = new DataView(par.GetparComunas(dt.Rows[0][18].ToString()));
            ddown010.DataSource = dv10;
            ddown010.DataTextField = "Descripcion";
            ddown010.DataValueField = "CodComuna";
            dv10.Sort = "CodComuna";
            ddown010.DataBind();
        }
        catch { }

        try
        {
            ddown010.SelectedValue = dt.Rows[0][15].ToString();
        }
        catch { }


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

        for (int i = 1; i <= ddown001.Items.Count - 1; i++)
        {
            if (ddown001.Items[i] != null) // el 8 no existe
            {
                ddown001.Items[i].Enabled = false;
                //ddown001.Items.FindByValue(Convert.ToString(i)).Enabled = false;
            }
        }
        ddown001.SelectedValue = "0";

        DataView dv2 = new DataView(par.GetparProfesionOficio());
        ddown002.DataSource = dv2;
        ddown002.DataTextField = "Descripcion";
        ddown002.DataValueField = "CodProfesion";
        dv2.Sort = "ProfesionOficio, Descripcion";
        ddown002.DataBind();

        DataView dv3 = new DataView(par.GetparActividad(CodModeloIntervencion));
        ddown003.DataSource = dv3;
        ddown003.DataTextField = "Descripcion";
        ddown003.DataValueField = "CodActividad";
        dv3.Sort = "Descripcion";
        ddown003.DataBind();

        DataView dv4 = new DataView(par.GetparEscolaridadAdulto());
        ddown004.DataSource = dv4;
        ddown004.DataTextField = "Descripcion";
        ddown004.DataValueField = "CodEscolaridadAdulto";
        dv4.Sort = "Descripcion";
        ddown004.DataBind();

        DataView dvx = new DataView((GetParTipoNacionalidad()));
        ddown_tipo_nacionalidad.DataSource = dvx;
        ddown_tipo_nacionalidad.DataTextField = "Descripcion";
        ddown_tipo_nacionalidad.DataValueField = "CodTipoNacionalidad";
        dvx.Sort = "CodTipoNacionalidad";
        ddown_tipo_nacionalidad.DataBind();

        DataView dv6;
        DataView dv7;
        DataView dv8;


        ////////////////ddwn situacion////////////
        if (CodModeloIntervencion == 91 || CodModeloIntervencion == 92)   // ModIntervencion FAS o FAE
        {
            if (ddown003.SelectedValue.ToString() == "20" || ddown003.SelectedValue.ToString() == "21")
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

            ddown006.Items.Clear();
            ddown006.DataSource = dv6;
            ddown006.DataTextField = "Descripcion";
            ddown006.DataValueField = "CodSituacion";
            dv6.Sort = "Descripcion";
            ddown006.DataBind();

            //DataView dv7 = new DataView(par.GetparSituacionPerRel(2));
            ddown007.Items.Clear();
            ddown007.DataSource = dv7;
            ddown007.DataTextField = "Descripcion";
            ddown007.DataValueField = "CodSituacion";
            dv7.Sort = "Descripcion";
            ddown007.DataBind();

            //DataView dv8 = new DataView(par.GetparSituacionPerRel(3));
            ddown008.Items.Clear();
            ddown008.DataSource = dv8;
            ddown008.DataTextField = "Descripcion";
            ddown008.DataValueField = "CodSituacion";
            dv8.Sort = "Descripcion";
            ddown008.DataBind();
        }
        else
        {
            dv6 = new DataView(par.GetparSituacionPerRel(0));
            ddown006.Items.Clear();
            ddown006.DataSource = dv6;
            ddown006.DataTextField = "Descripcion";
            ddown006.DataValueField = "CodSituacion";
            dv6.Sort = "Descripcion";
            ddown006.DataBind();

            dv7 = new DataView(par.GetparSituacionPerRel(0));
            ddown007.Items.Clear();
            ddown007.DataSource = dv7;
            ddown007.DataTextField = "Descripcion";
            ddown007.DataValueField = "CodSituacion";
            dv7.Sort = "Descripcion";
            ddown007.DataBind();

            dv8 = new DataView(par.GetparSituacionPerRel(0));
            ddown008.Items.Clear();
            ddown008.DataSource = dv8;
            ddown008.DataTextField = "Descripcion";
            ddown008.DataValueField = "CodSituacion";
            dv8.Sort = "Descripcion";
            ddown008.DataBind();
        }
        DropDownList tddown009 = (DropDownList)this.Form.FindControl("ddown009");
        DataView dv9 = new DataView(par.GetparRegion());
        tddown009.DataSource = dv9;
        tddown009.DataTextField = "Descripcion";
        tddown009.DataValueField = "CodRegion";
        dv9.Sort = "CodRegion";
        tddown009.DataBind();


        /////////////////Fin ddwn situacion////////////////

        DataView dv5 = new DataView(par.GetparTipoRelacion());
        ddown005.DataSource = dv5;
        ddown005.DataTextField = "Descripcion";
        ddown005.DataValueField = "TipoRelacion";
        dv5.Sort = "Descripcion";
        ddown005.DataBind();

    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void btn001_Click(object sender, EventArgs e)
    {
        btn001.Visible = false;
        if (btn001.Text.Trim().ToUpper() == "AGREGAR PERSONA RELACIONADA")
        {
            string sexo = "M";
            int nacionalidad = 0;
            string telefono = "0";
            string direccion = "0";
            DateTime fecha = Convert.ToDateTime("01-01-1900");

            if (rdo001.Checked) sexo = "F";

            if (Convert.ToInt32(ddown001.SelectedValue) > 0) nacionalidad = Convert.ToInt32(ddown001.SelectedValue);

            TextBox ttxttelefono = (TextBox)this.Form.FindControl("txttelefono");
            SenameTextBox ttxt_direccion = (SenameTextBox)this.Form.FindControl("txt_direccion");

            telefono = (ttxttelefono.Text.Trim() == "")?"0":(ttxttelefono.Text);

            direccion = (ttxt_direccion.Text.Trim() == "") ? "0" : ttxt_direccion.Text;

            if (cal001.Text == null || cal001.Text == "Seleccione Fecha" || cal001.Text.Trim() == "")
                fecha = Convert.ToDateTime("01-01-1900");
            else
                fecha = Convert.ToDateTime(cal001.Text);

            ninocoll ncoll = new ninocoll();

            if (!validate()) 
            {
                lbl001.Text = Resources.lblmessages.FaltanDatos;
                btn001.Visible = true;
                return;
            }

            DropDownList tddown010 = (DropDownList)this.Form.FindControl("ddown010");

            int codcomuna = -1;
            if (tddown010.SelectedValue.ToString().Trim().Length > 0) codcomuna = Convert.ToInt32(tddown010.SelectedValue);
            if (VCodPersonaRelacionada == -1) // si es -1 entonces es nueva, o sea no se encontró por medio de la busqueda
            {
                DataTable identidad = ncoll.callto_insert_personasrelacionadas_2f(txt001.Text, txt002.Text, txt003.Text, txt004.Text, sexo, fecha/*Convert.ToDateTime(cal001.Text)*/, Convert.ToDateTime(cal002.Text), Convert.ToInt32(Session["IdUsuario"]), 1, codcomuna, direccion, Convert.ToString(telefono));
                VCodPersonaRelacionada = Convert.ToInt32(identidad.Rows[0][0]);
            }

            ncoll.callto_insert_ninospersonasrelacionadas(VCodPersonaRelacionada, SSnino.ICodIE, SSnino.CodNino, Convert.ToDateTime(cal002.Text), Convert.ToInt32(ddown005.SelectedValue), Convert.ToInt32(ddown004.SelectedValue)
                , Convert.ToInt32(ddown002.SelectedValue), Convert.ToInt32(ddown001.SelectedValue), Convert.ToInt32(ddown003.SelectedValue), Convert.ToInt32(ddown006.SelectedValue)
                , Convert.ToInt32(ddown007.SelectedValue), Convert.ToInt32(ddown008.SelectedValue), DateTime.Now, Convert.ToInt32(Session["IdUsuario"]), Convert.ToInt32(ddown_tipo_nacionalidad.SelectedValue));

            //LimpiaPersonarel();

            if (Request.QueryString["mode"] != null)
            {
                Response.Redirect("ninos_ingresonuevo.aspx?CODPERSONARELACIONADA=" + VCodPersonaRelacionada.ToString());
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "RefrescaPadre();", true);
            }
        }
        else //modificar
        {
            string sexo = "M";
            int nacionalidad = 0;
            string direccion = "0";
            string telefono = "0";
            string rut = "0";

            TextBox ttxttelefono = (TextBox)this.Form.FindControl("txttelefono");
            SenameTextBox ttxt_direccion = (SenameTextBox)this.Form.FindControl("txt_direccion");
            DropDownList tddown010 = (DropDownList)this.Form.FindControl("ddown010");

            if (rdo001.Checked)
            { sexo = "F"; }


            if (Convert.ToInt32(ddown001.SelectedValue) > 0)                nacionalidad = Convert.ToInt32(ddown001.SelectedValue);
            
            ninocoll ncoll = new ninocoll();

            if (!validateModif())
            {
                lbl001.Visible = true;
                lbl001.Text = Resources.lblmessages.FaltanDatos;
                btn001.Visible = true;
            }else{
                rut = (txt001.Text.Trim() == "") ? "0" : txt001.Text.Trim();

                if (cal001.Text == null || cal001.Text == "Seleccione Fecha" || cal001.Text == "") cal001.Text = Convert.ToString("01-01-1900");

                direccion = (ttxt_direccion.Text.Trim() == "")?"0":ttxt_direccion.Text.Trim();

                telefono = (ttxttelefono.Text.Trim() == "")?"0":ttxttelefono.Text.Trim();

                ncoll.callto_update_personasrelacionadas_2f(VCodPersonaRelacionada, rut, txt002.Text, txt003.Text, txt004.Text, sexo, Convert.ToDateTime(cal001.Text), Convert.ToDateTime(cal002.Text), Convert.ToInt32(Session["IdUsuario"]), 0, Convert.ToInt32(tddown010.SelectedValue), direccion, Convert.ToString(telefono));
                ncoll.callto_update_ninospersonasrelacionadas(VCodPersonaRelacionada, SSnino.ICodIE, SSnino.CodNino, Convert.ToDateTime(cal002.Text), Convert.ToInt32(ddown005.SelectedValue), Convert.ToInt32(ddown004.SelectedValue)
                    , Convert.ToInt32(ddown002.SelectedValue), Convert.ToInt32(ddown001.SelectedValue), Convert.ToInt32(ddown003.SelectedValue), Convert.ToInt32(ddown006.SelectedValue)
                    , Convert.ToInt32(ddown007.SelectedValue), Convert.ToInt32(ddown008.SelectedValue), DateTime.Now, Convert.ToInt32(Session["IdUsuario"]), Convert.ToInt32(ddown_tipo_nacionalidad.SelectedValue));


                if (Request.QueryString["mode"] != null)
                {
                    Response.Redirect("ninos_ingresonuevo.aspx?CODPERSONARELACIONADA=" + VCodPersonaRelacionada.ToString());
                }
                else
                {
                    // cerrar y refrescar listado de datos de gestion
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "", "RefrescaPadre();", true);
                }
            }

        }


    }

    private void LimpiaPersonarel()
    {

        ddown001.SelectedValue = "0";
        ddown002.SelectedValue = "0";
        ddown003.SelectedValue = "0";
        ddown004.SelectedValue = "0";
        ddown005.SelectedValue = "0";
        ddown006.SelectedValue = "0";
        ddown007.SelectedValue = "0";
        ddown008.SelectedValue = "0";
        cal001.Text = "";
        cal002.Text = "";
        txt001.Text = "";
        txt001.Enabled = true;
        txt002.Enabled = true;
        txt003.Enabled = true;
        txt004.Enabled = true;
        txtb001.Text = "";
        txtb002.Text = "";
        txtb003.Text = "";
        txtb004.Text = "";
        pnlBuscar.Visible = true;
        btn001.Visible = true;
        // this.Form.FindControl("btn002_2f").Visible = false;

    }

    private bool validate()
    {
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        TextBox ttxttelefono = (TextBox)this.Form.FindControl("txttelefono");
        SenameTextBox ttxt_direccion = (SenameTextBox)this.Form.FindControl("txt_direccion");
        DropDownList tddown009 = (DropDownList)this.Form.FindControl("ddown009");
        DropDownList tddown010 = (DropDownList)this.Form.FindControl("ddown010");

        bool v = true;


        if (ddown_tipo_nacionalidad.SelectedValue != "2" ) // verifica si se selecciona tipo de nacionalidad extrangero (ocultar nacionalidad chilena)
        {
            if (!swLrpa)
            {
                if (txt001.Text.Trim() == "")
                {
                    txt001.BackColor = colorCampoObligatorio;
                    v = false;
                }
                else
                {
                    txt001.BackColor = System.Drawing.Color.Empty;
                }
            }
        }
        else
        {
            txt001.BackColor = System.Drawing.Color.Empty;
        }


        if (!swLrpa)
        {
            if (txt002.Text.Trim().Length < 3)
            {
                txt002.BackColor = colorCampoObligatorio;
                v = false;
            }
            else
            {
                txt002.BackColor = System.Drawing.Color.Empty;
            }

            if (txt003.Text.Trim().Length < 3)
            {
                txt003.BackColor = colorCampoObligatorio;
                v = false;
            }
            else
            {
                txt003.BackColor = System.Drawing.Color.Empty;
            }
        }

        if ((!rdo001.Checked && !rdo002.Checked))
        {
            rdo001.BackColor = colorCampoObligatorio;
            rdo002.BackColor = colorCampoObligatorio;
            v = false;
        }
        else
        {
            rdo001.BackColor = System.Drawing.Color.Empty;
            rdo002.BackColor = System.Drawing.Color.Empty;
        }
        if (Convert.ToInt32(ddown001.SelectedValue) == 0)
        {
            ddown001.BackColor = colorCampoObligatorio;
            v = false;
        }
        else
        {
            ddown001.BackColor = System.Drawing.Color.Empty;
        }

        //if (cal001.Value == null)
        //{
        //    cal001.BackColor = colorCampoObligatorio;
        //    v = false;
        //}
        if (cal002.Text == null || cal002.Text.Trim() == "Seleccione Fecha" || cal002.Text.Trim() == "")
        {
            cal002.BackColor = colorCampoObligatorio;
            v = false;
        }
        else
        {
            cal002.BackColor = System.Drawing.Color.Empty;
        }

        if (ddown001.SelectedValue == "0")
        {
            ddown001.BackColor = colorCampoObligatorio;
            v = false;
        }
        else
        {
            ddown001.BackColor = System.Drawing.Color.Empty;
        }
        if (ddown002.SelectedValue == "0")
        {
            ddown002.BackColor = colorCampoObligatorio;
            v = false;
        }
        else
        {

            ddown002.BackColor = System.Drawing.Color.Empty;
        }
        if (ddown003.SelectedValue == "0")
        {
            ddown003.BackColor = colorCampoObligatorio;
            v = false;
        }
        else
        {
            ddown003.BackColor = System.Drawing.Color.Empty;
        }
        if (ddown004.SelectedValue == "0")
        {
            ddown004.BackColor = colorCampoObligatorio;
            v = false;
        }
        else
        {
            ddown004.BackColor = System.Drawing.Color.Empty;
        }
        if (ddown005.SelectedValue == "0")
        {
            ddown005.BackColor = colorCampoObligatorio;
            v = false;
        }
        else
        {
            ddown005.BackColor = System.Drawing.Color.Empty;
        }
        if (ddown006.SelectedValue == "0")
        {
            ddown006.BackColor = colorCampoObligatorio;
            v = false;
        }
        else
        {
            ddown006.BackColor = System.Drawing.Color.Empty;
        }




        if (tddown010.SelectedValue == "0")
        {
            tddown010.BackColor = colorCampoObligatorio;
            v = false;
        }
        else
        {
            tddown010.BackColor = System.Drawing.Color.Empty;
        }
        //if (ttxt_direccion.Text.Trim() == "")
        //{
        //    ttxt_direccion.BackColor = colorCampoObligatorio;
        //    v = false;
        //}

        return v;

    }

    private bool validateModif()
    {
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        TextBox ttxttelefono = (TextBox)this.Form.FindControl("txttelefono");
        SenameTextBox ttxt_direccion = (SenameTextBox)this.Form.FindControl("txt_direccion");
        DropDownList tddown009 = (DropDownList)this.Form.FindControl("ddown009");
        DropDownList tddown010 = (DropDownList)this.Form.FindControl("ddown010");

        bool v = true;


        //if (ddown_tipo_nacionalidad.SelectedValue != "2") // verifica si se selecciona tipo de nacionalidad extrangero (ocultar nacionalidad chilena)
        //{
        //    if (txt001.Text.Trim() == "")
        //    {
        //        txt001.BackColor = colorCampoObligatorio;
        //        v = false;
        //    }
        //    else
        //    {
        //        txt001.BackColor = System.Drawing.Color.Empty;
        //    }
        //}
        //else
        //{
        //    txt001.BackColor = System.Drawing.Color.Empty;
        //}

        if ((!rdo001.Checked && !rdo002.Checked))
        {
            rdo001.BackColor = colorCampoObligatorio;
            rdo002.BackColor = colorCampoObligatorio;
            v = false;
        }
        else
        {
            rdo001.BackColor = System.Drawing.Color.Empty;
            rdo002.BackColor = System.Drawing.Color.Empty;
        }
        if (Convert.ToInt32(ddown001.SelectedValue) == 0)
        {
            ddown001.BackColor = colorCampoObligatorio;
            v = false;
        }
        else
        {
            ddown001.BackColor = System.Drawing.Color.Empty;
        }
        if (txt002.Text.Trim().Length < 3)
        {
            txt002.BackColor = colorCampoObligatorio;
            v = false;
        }
        else
        {
            txt002.BackColor = System.Drawing.Color.Empty;
        }
        if (txt003.Text.Trim().Length < 3)
        {
            txt003.BackColor = colorCampoObligatorio;
            v = false;
        }
        else
        {
            txt003.BackColor = System.Drawing.Color.Empty;

        }




        //if (cal001.Value == null)
        //{
        //    cal001.BackColor = colorCampoObligatorio;
        //    v = false;
        //}
        if (cal002.Text == null || cal002.Text.Trim() == "Seleccione Fecha" || cal002.Text.Trim() == "")
        {
            cal002.BackColor = colorCampoObligatorio;
            v = false;
        }
        else
        {
            cal002.BackColor = System.Drawing.Color.Empty;
        }

        if (ddown001.SelectedValue == "0")
        {
            ddown001.BackColor = colorCampoObligatorio;
            v = false;
        }
        else
        {
            ddown001.BackColor = System.Drawing.Color.Empty;
        }
        if (ddown002.SelectedValue == "0")
        {
            ddown002.BackColor = colorCampoObligatorio;
            v = false;
        }
        else
        {

            ddown002.BackColor = System.Drawing.Color.Empty;
        }
        if (ddown003.SelectedValue == "0")
        {
            ddown003.BackColor = colorCampoObligatorio;
            v = false;
        }
        else
        {
            ddown003.BackColor = System.Drawing.Color.Empty;
        }
        if (ddown004.SelectedValue == "0")
        {
            ddown004.BackColor = colorCampoObligatorio;
            v = false;
        }
        else
        {
            ddown004.BackColor = System.Drawing.Color.Empty;
        }
        if (ddown005.SelectedValue == "0")
        {
            ddown005.BackColor = colorCampoObligatorio;
            v = false;
        }
        else
        {
            ddown005.BackColor = System.Drawing.Color.Empty;
        }
        if (ddown006.SelectedValue == "0")
        {
            ddown006.BackColor = colorCampoObligatorio;
            v = false;
        }
        else
        {
            ddown006.BackColor = System.Drawing.Color.Empty;
        }




        if (tddown010.SelectedValue == "0")
        {
            tddown010.BackColor = colorCampoObligatorio;
            v = false;
        }
        else
        {
            tddown010.BackColor = System.Drawing.Color.Empty;
        }
        //if (ttxt_direccion.Text.Trim() == "")
        //{
        //    ttxt_direccion.BackColor = colorCampoObligatorio;
        //    v = false;
        //}



        return v;
    }

    protected void txt001_ValueChange(object sender, EventArgs e)
    {
        try
        {
            if (txt001.Text.Trim().Length > 3)
            {
                string rutsinnada = txt001.Text.Replace(".", "").Replace(",", "").Replace("-", "").Trim();
                string digitoingresado = rutsinnada.Substring(rutsinnada.Length - 1, 1);

                string digitocalculado = digitoVerificador(Convert.ToInt32(rutsinnada.ToUpper().Replace("K", "").Substring(0, rutsinnada.Length - 1)));
                if (digitocalculado.ToUpper() == digitoingresado.ToUpper())
                {
                    this.Form.FindControl("pnl005").Visible = false;
                    string punorut = rutsinnada.ToUpper().Replace("K", "").Substring(0, rutsinnada.Length - 1).Trim();
                    string rcompleto = punorut + "-" + digitocalculado.ToUpper();
                    txt001.Text = rcompleto;
                    txt001.Text.Trim();
                }
                else
                {
                    txt001.Text = "";
                    ((Label)Form.FindControl("lbl005")).Text = "RUT INGRESADO NO ES VALIDO";
                    ((Label)Form.FindControl("lbl005")).Visible = true;
                    this.Form.FindControl("pnl005").Visible = true;
                }
            }
            else
            {
                txt001.Text = "";
                ((Label)Form.FindControl("lbl005")).Text = "RUT INGRESADO NO ES VALIDO";
                ((Label)Form.FindControl("lbl005")).Visible = true;
                this.Form.FindControl("pnl005").Visible = true;
            }
        }
        catch
        {
            txt001.Text = "";
            ((Label)Form.FindControl("lbl005")).Visible = true;
            ((Label)Form.FindControl("lbl005")).Text = "RUT INGRESADO NO ES VALIDO";
            this.Form.FindControl("pnl005").Visible = true;
        }

        ninocoll ncoll = new ninocoll();
        DataTable ExisteRut = ncoll.callto_getrut_personasrelacionadas(txt001.Text.Trim());


        if (ExisteRut.Rows[0][0].ToString() == "1" && txt001.Text.Trim() != "0" && txt001.Text.Trim() != "")
        {
            lbl003.Text = "Este rut ya existe Ingrese otro";
            lbl003.Visible = true;
            txt001.Text = "";
        }
        else
        {
            lbl003.Text = "";
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
    protected void ddown001_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    //protected void btn003_Click(object sender, EventArgs e)
    //{
    //    //window.close(this.Page);
    //    ClientScript.RegisterStartupScript(this.GetType(), "", "CerrarFancybox();", true); 
    //}

    protected void limpiar()
    {

        ddown001.SelectedValue = "0";
        ddown002.SelectedValue = "0";
        ddown003.SelectedValue = "0";
        ddown004.SelectedValue = "0";
        ddown005.SelectedValue = "0";
        ddown006.SelectedValue = "0";
        ddown007.SelectedValue = "0";
        ddown008.SelectedValue = "0";
        ddown009.SelectedValue = "-2";
        // ddown009.Items.Clear();
        ddown010.Items.Clear();
        cal001.Text = "";
        cal002.Text = "";
        txt001.Text = "";
        txt001.Enabled = true;
        txt002.Enabled = true;
        txt003.Enabled = true;
        txt004.Enabled = true;
        txt001.Text = "";
        txt002.Text = "";
        txt003.Text = "";
        txt004.Text = "";

        txtb001.Text = "";
        txtb002.Text = "";
        txtb003.Text = "";
        txtb004.Text = "";
        
        btnB001.Visible = true;
        btn001.Visible = true;
        //this.Form.FindControl("btn002_2f").Visible = false;

        bool swLrpa = FiltroLRPA();
        if (swLrpa)
        {
            txt001.Enabled = false;
            txt001.Text = "";
            txt002.Enabled = false;
            txt002.Text = "N.N.";
            txt003.Enabled = false;
            txt003.Text = "N.N.";
            txt004.Enabled = false;
            txt004.Text = "N.N.";
            btnB001.Visible = false;
            if (ddown005.SelectedValue != "0")
            {
                txt003.Text = "N.N. " + ddown005.SelectedItem.Text;
            }
            pnlAgregar.Visible = true;
            pnlBuscar.Visible = false;

            btn001.CausesValidation = false;
        }
        else {
            pnlAgregar.Visible = false;
            pnlBuscar.Visible = true;
        }


        //lblb001.Text = "";
    }
    //protected void btn002_Click(object sender, EventArgs e)
    //{

    //    limpiar();

    //}

    #region BuscadorPersonaRelacionada
    protected void btn004_Click(object sender, EventArgs e)
    {

        lbl001.Visible = false;
        if (txtb001.Text.Trim() != "")
        {
            valida_rut_busca();
        }
        if (!Pnl2.Visible)
        {
            ninocoll ncoll = new ninocoll();
            string rut;
            string Nombre = "";
            string Apepat = "";
            string apemat = "";
            bool sw = true;
            int longitud = txtb001.Text.Trim().Length;
            if (longitud < 2)
            {
                rut = Convert.ToString("0");
            }
            else
            {
                rut = txtb001.Text.Trim();
            }
            if (txtb002.Text.Trim() == "")
            {
                Nombre = "";
            }
            else
            {
                Nombre = txtb002.Text.Trim();
            }
            if (txtb003.Text.Trim() == "")
            {
                Apepat = "";
            }
            else
            {
                Apepat = txtb003.Text.Trim();
            }
            if (txtb004.Text.Trim() == "")
            {
                apemat = "";
            }
            else
            {
                apemat = txtb004.Text.Trim();
            }
            if (longitud < 2 && Nombre == "" && apemat == "" && Apepat == "")
            {
                alert.Attributes.Add("style", "");
                lbl0055.Text = "Debe ingresar el Rut o el Nombre y un Apellido.";
                lbl0055.Attributes.Add("style", "");  
                //lblb001.Text = "Debe ingresar el Rut o el Nombre y un Apellido";
                //lblb001.Visible = true;
                sw = false;
            }
            if (longitud < 2 && Nombre.Length > 1 && apemat == "" && Apepat == "")
            {
                alert.Attributes.Add("style", "");
                lbl0055.Text = "Debe ingresar el Rut o el Nombre y un Apellido.";
                lbl0055.Attributes.Add("style", "");  
                //lblb001.Text = "Debe ingresar por lo menos un apellido ";
                //lblb001.Visible = true;
                sw = false;
            }




            if (sw)
            {

                DataTable dt = ncoll.callto_search_persona_realcionada(rut, Nombre, apemat, Apepat, longitud);
                DataView dv = new DataView(dt);

                if (dt.Rows.Count == 0)
                {
                    alert.Attributes.Add("style", "");
                    lbl0055.Text = "No se encontraron Coincidencias.";
                    lbl0055.Attributes.Add("style", "");
                    //lblb001.Text = "No se encontraron Coincidencias";
                   // lblb001.Visible = true;
                    //btnAgregarNueva.Visible = true;
                }
                else
                {
                    //lblb001.Text = "";
                    //btnAgregarNueva.Visible = false;
                }

                dv.Sort = "Nombres";
                grd001buscar.DataSource = dv;
                grd001buscar.DataBind();
                grd001buscar.Visible = true;





            }
            else
            {
                //lblb001.Text = "";
            }


            //btn002.Focus();

        }

    }
    protected void btnB001_Click(object sender, EventArgs e)
    {
        pnlBuscar.Visible = true;
        //btnAgregarNueva.Visible = false;
        pnlAgregar.Visible = false;
    }

    protected void grd001buscar_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ninocoll ncoll = new ninocoll();

        string CodPersonaRelacionada = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
        VCodPersonaRelacionada = -1;
        VCodPersonaRelacionada = Convert.ToInt32(CodPersonaRelacionada);
        //DataTable dt = ncoll.callto_get_personasrelacionadas(Convert.ToInt32(CodPersonaRelacionada));
        DataTable dt = ncoll.callto_get_personasrelacionadasII(Convert.ToInt32(CodPersonaRelacionada), SSnino.CodProyecto);
        limpiar();
        pnlBuscar.Visible = false;
        pnlAgregar.Visible = true;
        if (dt.Rows.Count > 0)
        {
            //getdata();
            txt001.Text = dt.Rows[0][1].ToString();
            txt001.Text = txt001.Text.Replace(" ", "");
            txt001.Enabled = false;
            txt002.Text = dt.Rows[0][2].ToString();
            txt002.Enabled = false;
            txt003.Text = dt.Rows[0][3].ToString();
            txt003.Enabled = false;
            txt004.Text = dt.Rows[0][4].ToString();
            txt004.Enabled = false;
            if (dt.Rows[0][5].ToString() == "M")
            {
                rdo002.Checked = true;
            }
            else
            {
                rdo001.Checked = true;
            }
            rdo001.Enabled = false;
            rdo002.Enabled = false;

            if (dt.Rows[0]["ICodIE"].ToString() != "")      // Si existe algún ingreso en el proyecto
            {
                if (dt.Rows[0]["CodNacionalidad"].ToString() != "") ddown001.SelectedValue = dt.Rows[0]["CodNacionalidad"].ToString();
                if (dt.Rows[0]["CodProfesion"].ToString() != "")
                {
                    if (dt.Rows[0]["CodProfesion"].ToString() == "31" || dt.Rows[0]["CodProfesion"].ToString() == "32" || dt.Rows[0]["CodProfesion"].ToString() == "35" || dt.Rows[0]["CodProfesion"].ToString() == "36")
                    {
                        ddown002.SelectedValue = "0";
                    }else{
                        ddown002.SelectedValue = dt.Rows[0]["CodProfesion"].ToString();
                    }
                }
                if (dt.Rows[0]["CodActividad"].ToString() != "")
                {
                    try
                    {
                        ddown003.SelectedValue = dt.Rows[0]["CodActividad"].ToString();
                    }
                    catch { }
                    ddown003_SelectedIndexChanged(new object(), new EventArgs());
                }

                try
                {
                    if (dt.Rows[0]["CodEscolaridadAdulto"].ToString() != "") ddown004.SelectedValue = dt.Rows[0]["CodEscolaridadAdulto"].ToString();
                }
                catch
                {

                }

                try
                {
                    if (dt.Rows[0]["CodSituacion1"].ToString() != "") ddown006.SelectedValue = dt.Rows[0]["CodSituacion1"].ToString();
                }
                catch { }

                try
                {
                    if (dt.Rows[0]["CodSituacion2"].ToString() != "") ddown007.SelectedValue = dt.Rows[0]["CodSituacion2"].ToString();
                }
                catch { }

                try
                {
                    if (dt.Rows[0]["CodSituacion3"].ToString() != "") ddown008.SelectedValue = dt.Rows[0]["CodSituacion3"].ToString();
                }
                catch { }

                if (dt.Rows[0]["TipoRelacion"].ToString() != "") ddown005.SelectedValue = dt.Rows[0]["TipoRelacion"].ToString();
                if (dt.Rows[0]["Direccion"].ToString() != "") txt_direccion.Text = dt.Rows[0]["Direccion"].ToString();
            }
            if (dt.Rows[0]["CodRegion"].ToString() != "")
            {
                ddown009.SelectedValue = dt.Rows[0]["CodRegion"].ToString();
                ddown009_SelectedIndexChanged(new object(), new EventArgs());
            }
            if (dt.Rows[0]["CodComuna"].ToString() != "") ddown010.SelectedValue = dt.Rows[0]["CodComuna"].ToString();
            if (dt.Rows[0]["Telefono"].ToString() != "") txttelefono.Text = dt.Rows[0]["Telefono"].ToString();

            //try
            //{
            //    parcoll par = new parcoll();
            //    DataView dv10 = new DataView(par.GetparComunas(dt.Rows[0][14].ToString()));
            //    ddown010.DataSource = dv10;
            //    ddown010.DataTextField = "Descripcion";
            //    ddown010.DataValueField = "CodComuna";
            //    dv10.Sort = "CodComuna";
            //    ddown010.DataBind();
            //    ddown010.Focus();
            //    ddown010.SelectedValue = dt.Rows[0]["CodComuna"].ToString();
            //}
            //catch { }


           
            cal001.Text = FormatFecha(dt.Rows[0][6].ToString());
            cal001.Enabled = false;
            btn001.Visible = true; //Agregar

            DataView dtC = new DataView();

            //this.Form.FindControl("btn002_2f").Visible = true;
            grd001buscar.DataSource = dtC;
            grd001buscar.DataBind();
            grd001buscar.Visible = false;
            btnB001.Visible = true;
        }


    }

    //protected void btn002_2f_Click(object sender, EventArgs e)
    //{
    //    ninocoll ncoll = new ninocoll();
    //    if (validate())
    //    {
    //        try
    //        {
    //            ncoll.callto_insert_ninospersonasrelacionadas(VCodPersonaRelacionada, SSnino.ICodIE, SSnino.CodNino, Convert.ToDateTime(cal002.Text), Convert.ToInt32(ddown005.SelectedValue), Convert.ToInt32(ddown004.SelectedValue)
    //            , Convert.ToInt32(ddown002.SelectedValue), Convert.ToInt32(ddown001.SelectedValue), Convert.ToInt32(ddown003.SelectedValue), Convert.ToInt32(ddown006.SelectedValue)
    //            , Convert.ToInt32(ddown007.SelectedValue), Convert.ToInt32(ddown008.SelectedValue), DateTime.Now, Convert.ToInt32(Session["IdUsuario"]));
    //        }
    //        catch { }

    //        ClientScript.RegisterStartupScript(this.GetType(), "", "RefrescaPadre();", true);
    //        //ClientScript.RegisterStartupScript(this.GetType(), "", "CerrarFancybox();", true);
    //    }
    //}



    #endregion



    protected void ddown009_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList tddown009 = (DropDownList)this.Form.FindControl("ddown009");
        DropDownList tddown010 = (DropDownList)this.Form.FindControl("ddown010");

        parcoll par = new parcoll();
        DataView dv10 = new DataView(par.GetparComunas(tddown009.SelectedValue));
        tddown010.Items.Clear();
        tddown010.DataSource = dv10;
        tddown010.DataTextField = "Descripcion";
        tddown010.DataValueField = "CodComuna";
        dv10.Sort = "CodComuna";
        tddown010.DataBind();
        tddown010.Focus();
    }
    protected void txtb001_ValueChange(object sender, EventArgs e)
    {

    }
    private void valida_rut_busca()
    {
        try
        {
            if (txtb001.Text.Length > 3)
            {
                string rutsinnada = txtb001.Text.Replace(".", "").Replace(",", "").Replace("-", "").Trim();
                string digitoingresado = rutsinnada.Substring(rutsinnada.Length - 1, 1);

                string digitocalculado = digitoVerificador(Convert.ToInt32(rutsinnada.ToUpper().Replace("K", "").Substring(0, rutsinnada.Length - 1)));
                if (digitocalculado.ToUpper() == digitoingresado.ToUpper())
                {
                    this.Form.FindControl("Pnl2").Visible = false;
                    string punorut = rutsinnada.ToUpper().Replace("K", "").Substring(0, rutsinnada.Length - 1).Trim();
                    string rcompleto = punorut + "-" + digitocalculado.ToUpper();
                    txtb001.Text = rcompleto;
                }
                else
                {
                    txtb001.Text = "";
                    ((Label)Form.FindControl("lbl004")).Text = "RUT INGRESADO NO ES VALIDO";
                    this.Form.FindControl("Pnl2").Visible = true;
                }
            }
            else
            {
                txtb001.Text = "";
                ((Label)Form.FindControl("lbl004")).Text = "RUT INGRESADO NO ES VALIDO";
                this.Form.FindControl("Pnl2").Visible = true;
            }
        }
        catch
        {
            ((Label)Form.FindControl("lbl005")).Text = "RUT INGRESADO NO ES VALIDO";
            this.Form.FindControl("Pnl2").Visible = true;
        }
        //btn002.Focus();
        //ninocoll ncoll = new ninocoll();
        //DataTable ExisteRut = ncoll.callto_getrut_personasrelacionadas(txt001.Text.Trim());
        //if (ExisteRut.Rows[0][0].ToString() == "1")
        //{
        //    lblb001.Text = "Este rut ya existe Ingrese otro";
        //    txtb001.Text = "";
        //}
    }
    protected void cal001_ValueChanged(object sender, EventArgs e)
    {

    }
    #region filtro LRPA

    private bool FiltroLRPA()
    {
        #region FiltroLRPA

        bool swLrpa;

        LRPAcoll LRPA = new LRPAcoll();

        DataTable dt = new DataTable();
        dt = LRPA.callto_get_proyectoslrpa(SSnino.CodProyecto);
        if (dt.Rows.Count > 0)
        {
            if (Convert.ToInt32(dt.Rows[0][0]) > 0 && dt.Rows[0][1].ToString() == "20084")
            {
                swLrpa = true;
            }
            else
            {
                swLrpa = false;
            }
        }
        else
        {
            swLrpa = false;
        }
        return (swLrpa);


        #endregion

    }


    #endregion
    protected void ddown005_SelectedIndexChanged(object sender, EventArgs e)
    {
        bool swLrpa = FiltroLRPA();
        if (swLrpa)
        {
            if (ddown005.SelectedValue != "0")
            {
                txt003.Text = "N.N. " + ddown005.SelectedItem.Text;
            }
        }
    }
    protected void ddown003_SelectedIndexChanged(object sender, EventArgs e)
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
            if (ddown003.SelectedValue.ToString() == "20" || ddown003.SelectedValue.ToString() == "21")
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

            ddown006.Items.Clear();
            ddown006.DataSource = dv6;
            ddown006.DataTextField = "Descripcion";
            ddown006.DataValueField = "CodSituacion";
            dv6.Sort = "Descripcion";
            ddown006.DataBind();

            //DataView dv7 = new DataView(par.GetparSituacionPerRel(2));
            ddown007.Items.Clear();
            ddown007.DataSource = dv7;
            ddown007.DataTextField = "Descripcion";
            ddown007.DataValueField = "CodSituacion";
            dv7.Sort = "Descripcion";
            ddown007.DataBind();

            //DataView dv8 = new DataView(par.GetparSituacionPerRel(3));
            ddown008.Items.Clear();
            ddown008.DataSource = dv8;
            ddown008.DataTextField = "Descripcion";
            ddown008.DataValueField = "CodSituacion";
            dv8.Sort = "Descripcion";
            ddown008.DataBind();
        }
    }
    protected void grd001buscar_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btn002_Click1(object sender, EventArgs e)
    {
        // btnB001.Visible = true;
    }
    protected void btnAgregarNueva_Click(object sender, EventArgs e)
    {
        // DPL 14-11-2015 14:28
        //if (txtb001.Text == "")
        //{
        //    alert.Attributes.Add("style", "");
        //    lbl0055.Text = "El RUN es obligatorio.";
        //    lbl0055.Attributes.Add("style", "");
        //    //lblb001.Text = ".";
        //    //lblb001.Visible = true;
        //    return;
        //}


        pnlBuscar.Visible = false;
        pnlAgregar.Visible = true;
        
        txt001.Text = txtb001.Text.Trim().Replace(".", "");
        txt001.Text.Trim();
        txt001.Enabled = (txtb001.Text == "");
        txt002.Text = string.Empty;
        txt002.Enabled = true;
        txt003.Text = string.Empty;
        txt003.Enabled = true;
        txt004.Text = string.Empty;
        txt004.Enabled = true;
        rdo002.Checked = false;
        rdo001.Checked = false;
        rdo001.Enabled = true;
        rdo002.Enabled = true;

        cal001.Enabled = true;
        VCodPersonaRelacionada = -1;

        //pinta blanco
        rdo001.BackColor = System.Drawing.Color.Empty;
        rdo002.BackColor = System.Drawing.Color.Empty;
        ddown001.BackColor = System.Drawing.Color.Empty;
        txt002.BackColor = System.Drawing.Color.Empty;
        txt003.BackColor = System.Drawing.Color.Empty;
        cal002.BackColor = System.Drawing.Color.Empty;
        ddown001.BackColor = System.Drawing.Color.Empty;
        ddown002.BackColor = System.Drawing.Color.Empty;
        ddown003.BackColor = System.Drawing.Color.Empty;
        ddown004.BackColor = System.Drawing.Color.Empty;
        ddown005.BackColor = System.Drawing.Color.Empty;
        ddown006.BackColor = System.Drawing.Color.Empty;
        ddown010.BackColor = System.Drawing.Color.Empty;

        if (swLrpa)
        {
            txt001.Enabled = false; //rut
            txt001.Text = "";
            txt002.Enabled = false; //nomb
            txt002.Text = "N.N.";
            txt003.Enabled = false; // ap pat
            txt003.Text = "N.N.";
            txt004.Enabled = false; // ap mat
            txt004.Text = "N.N.";
            btnB001.Visible = false; //llama a panel buscar
            if (ddown005.SelectedValue != "0") // tipo relacion
                txt003.Text = "N.N. " + ddown005.SelectedItem.Text;
            btn001.CausesValidation = false;
        }


    }
    protected void ddownTipoNac_SelectedIndexChanged(object sender, EventArgs e)
    {
        getNacionalidad();
    }

    protected void getNacionalidad()
    {
        ddown001.Items.FindByValue("1").Enabled = true;
        if (ddown_tipo_nacionalidad.SelectedValue == "1" || ddown_tipo_nacionalidad.SelectedValue == "3") // verifica si se selecciona tipo de nacionalidad chileno o nacionalizado 
        {
            if (ddown001.Items.FindByValue("2").Enabled == true) //verifica si las nacionalidades que no son chilenas estan visibles
            {
                for (int i = 2; i <= ddown001.Items.Count - 1; i++)
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
                for (int i = 2; i <= ddown001.Items.Count - 1; i++)
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
                for (int i = 1; i <= ddown001.Items.Count - 1; i++)
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


