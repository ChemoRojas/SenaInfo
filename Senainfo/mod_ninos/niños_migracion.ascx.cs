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
using CustomWebControls;
using AjaxControlToolkit;
using System.Data.Common;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

public partial class mod_ninos_niños_migracion : System.Web.UI.UserControl
{
    public int ICOIEAUX = 0;
    public int ICODSITU = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                bt_situacion_migratoria.Enabled = true;
                bt_situacion_migratoria.Visible = true;
                btn_update_situacionMigratoria.Visible = false;
                getParPasoFronterizo();
                carga_situacion_migratoria();
                int param = Convert.ToInt32(Session["SS_ICodIE"].ToString());
                GetInfoMigratoria();
                getIdiomas();//gfontbrevis
                


            }
            catch (Exception ex)
            { }

        }
        if (rbl_situacionMigratoria.SelectedValue != "0")
        {
            dd_situacion_migratoria.Enabled = true;
            bt_situacion_migratoria.Enabled = true;
            bt_situacion_migratoria.Enabled = true;
            pnl_victima.Visible = true;
            panel_migra.Visible = true;
            rb_situacion_si.Visible = false;
            rb_situacion_no.Visible = false;
            rb_situacion_si.Checked = true;
        }
        else
        {
            dd_situacion_migratoria.Enabled = false;
            dd_situacion_migratoria.SelectedIndex = 0;
            bt_situacion_migratoria.Enabled = false;
            bt_situacion_migratoria.Enabled = false;
            panel_migra.Visible = false;
            pnl_victima.Visible = false;
            rb_situacion_si.Visible = false;
            rb_situacion_no.Visible = false;
            rb_situacion_no.Checked = true;
        }

        int ano = DateTime.Now.Year;
        for (int a = ano; a >= (ano - 100); a--)   // Añadimos Items
        {
            ddl_ano.Items.Add(a.ToString());

        }


    }
    protected string PoseeDatosMigracion(object PoseeDatos, int docReque)
    {
        int docMig = -1;
        if (int.TryParse(PoseeDatos.ToString(), out docMig))
        {
            return docMig == docReque ? "checked" : "";
        }
        return "";
    }
    protected string PoseNivelIdioma(object nivelidioma, int nivelrequerido)
    {
        int nivel = -1;
        if (int.TryParse(nivelidioma.ToString(), out nivel))
        {
            return nivel == nivelrequerido ? "checked" : "";
        }
        return "";
    }
    protected string PoseDocumento(object nivelDocu)
    {
        if ((bool)nivelDocu == true)
        {
            return "text";
        }
        return "Hidden";
    }
    protected void control_controles(Object sender, EventArgs e)
    {
        if (rb_situacion_si.Checked)
        {
            dd_situacion_migratoria.Enabled = true;
            bt_situacion_migratoria.Enabled = true;
            bt_situacion_migratoria.Enabled = true;
            panel_migra.Visible = true;
            rb_situacion_si.Checked = true;
            rb_situacion_no.Checked = false;
        }
        if (rb_situacion_no.Checked)
        {
            dd_situacion_migratoria.Enabled = false;
            dd_situacion_migratoria.SelectedIndex = 0;
            bt_situacion_migratoria.Enabled = false;
            bt_situacion_migratoria.Enabled = false;
            panel_migra.Visible = false;
            rb_situacion_no.Checked = true;
            rb_situacion_si.Checked = false;
        }

        //  muestra_pestaña(10);
    }

    protected void control_extranjero(Object sender, EventArgs e)
    {

        //muestra_pestaña(10);
    }

    protected void control_escolaridad(Object sender, EventArgs e)
    {

    }

    protected void bt_situacion_migratoria_Click(object sender, EventArgs e)
    {

        int guardar = 0;
        if (!situacion_migratoria())
        {
            //alerts.Visible = true;
            //lb_situacion_migratoria.Visible = true;
            lb_situacion_migratoria.Text = "Debe llenar toda la información de Situación migratoria";

            guardar++;
        }
        if (!documentacion_migratoria())
        {
            alerts.Visible = true;
            lb_documentacion_migratoria.Visible = true;
            lb_documentacion_migratoria.Text = "Debe llenar toda la información de Documentación migratoria";
            guardar++;
        }
        if (!proceso_migracion())
        {
            alerts.Visible = true;
            lb_proceso_migracion.Visible = true;
            lb_proceso_migracion.Text = "Debe llenar toda la información de Proceso Migratorio";
            guardar++;
        }


        if (guardar == 0)
        {
            guardar_situacion_migratoria();
            GuardoDocumentacion();
            GetIdiomaSeleccionado();
            ListView2.DataBind();
            regionesList.DataBind();
            validatescurity();
            UpdatePanel1.Update();
        }
        UpdatePanel1.Update();
    }
    protected bool situacion_migratoria()
    {
        if (rb_situacion_si.Checked)
        {
            return (dd_situacion_migratoria.SelectedIndex != 0);
        }
        return false;
    }

    protected bool documentacion_migratoria()
    {

        return true;
        #region comentarios

        #endregion
    }

    protected bool proceso_migracion()
    {
        //if (ddl_mes.Text == "" || ddl_ano.Text == "" || txt_paso_fronterizo.Text == "" || txt_ciudad_origen.Text == "")
        if (ddl_mes.Text == "" || ddl_ano.Text == "")
        {
            return false;
        }
        else
        {
            if (rb_ingresos_chile_si.Checked)
            {
                if (txt_ingreso_chile.Text == "")
                {
                    return false;
                }
                else
                {
                    if (rb_otros_paises_si.Checked)
                    {
                        if (txt_otros_paises.Text == "")
                        {
                            return false;
                        }
                        else
                        {
                            if (dd_motivo_ingreso.SelectedIndex == 0)
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                    }
                    return true;
                }
            }
            if (rb_paso_fronterizo_si.Checked == true)
            {
                //if (txt_paso_fronterizo.Text == "")
                if(ddlPasoFronterizo.SelectedValue == "0" && ddlPasoFronterizo.SelectedValue == "")
                {
                    return false;
                }
                else
                { return true; }

            }
            else { return true; }
            if (rb_ingresos_chile_si.Checked == true)
            {
                if (txt_ingreso_chile.Text == "")
                { return true; }
                else { return false; }
            }
            else { return true; }
            if (rb_otros_paises_si.Checked == true)
            {
                if (txt_otros_paises.Text == "")
                { return true; }
                else { return false; }
            }
            else { return false; }

        }

        return false;
    }
    protected void guardar_situacion_migratoria()
    {
        int IngresosAnteriores_Cuantos = 0;
        int TransitadoEnOtrosPaises_Cuantos = 0;

        int ICodSituacionMigratoria = int.Parse(icod_situacion_migratoria.Value);
        //int ICodIE = SSnino.ICodIE;
        int ICodIE = Convert.ToInt32(Session["SS_ICodIE"].ToString());
        int CodSituacionMigratoria = dd_situacion_migratoria.SelectedIndex;
        int SituacionMigratoria_SI_NO = rb_situacion_si.Checked ? 1 : 0;
        int VictimaTraficoPersonas = rb_victima_trafico_si.Checked ? 1 : 0;
        //int FechaIngresoChile = int.Parse(ddl_ano.SelectedValue.ToString() + ddl_mes.SelectedValue.ToString());
        int FechaIngresoChile = int.Parse(txt_fechaIngresoChile.Text.Trim().Replace("-", ""));
        int PasoFronterizoIngresa = rb_paso_fronterizo_si.Checked ? 1 : 0;
        //int PasoFronterizoIngresa_Cual = Convert.ToInt32(txt_paso_fronterizo.Text);
        int PasoFronterizoIngresa_Cual = 0;
        if (PasoFronterizoIngresa == 1)
        {
             PasoFronterizoIngresa_Cual = Convert.ToInt32(ddlPasoFronterizo.SelectedValue);
        }
        else
        {
            PasoFronterizoIngresa_Cual = 0;
        }
        

        //int PasoFronterizoIngresa_Cual = txt_paso_fronterizo.Text;
        int IngresosAnteriores = rb_ingresos_chile_si.Checked ? 1 : 0;
        if (txt_ingreso_chile.Text == "")
        { IngresosAnteriores_Cuantos = 0; }
        else
        { IngresosAnteriores_Cuantos = Convert.ToInt16(txt_ingreso_chile.Text); }

        int TransitadoEnOtrosPaises = rb_otros_paises_si.Checked ? 1 : 0;
        if (txt_otros_paises.Text == "")
        { TransitadoEnOtrosPaises_Cuantos = 0; }
        else { TransitadoEnOtrosPaises_Cuantos = Convert.ToInt16(txt_otros_paises.Text); }

        string CiudadOrigenResidencia = txt_ciudad_origen.Text;
        int CodMotivoIngresoChile = dd_motivo_ingreso.SelectedIndex;
        int IdUsuarioActualizacion = Convert.ToInt32(Session["IdUsuario"]);

        bool avisoRRII = avisorrii_si.Checked ? true : false;
        DateTime fechaAvisoRRII = (avisoRRII ? Convert.ToDateTime(txtFechaAvisoRRII.Text) : new DateTime(1900, 01, 01));
        
        bool gestionRegulacionMigratoria = GestionRegulacionMigratoria_si.Checked ? true : false;
        DateTime fechaGestionRegulacionMigratoria = (gestionRegulacionMigratoria ? Convert.ToDateTime(txtFechaGestionRegulacionMigratoria.Text) : new DateTime(1900, 01, 01));
        
        bool remiteAntecedentesCasoInforme = RemiteAntecedentesCasoInformePericialDiagnostico_si.Checked ? true : false;
        DateTime fechaRemiteAntecedentes = (remiteAntecedentesCasoInforme ? Convert.ToDateTime(txtFechaRemiteAntecedentes) : new DateTime(1900, 01, 01));

        bool retornoAlPaisOrigen = RetornoNNAaPaisOrigen_si.Checked ? true : false;
        DateTime fechaRetornoNNAPaisOrigen = (retornoAlPaisOrigen ? Convert.ToDateTime(txtFechaRetornoPaisOrigen.Text) : new DateTime(1900, 01, 01));

        //int returnvalue = 0;
        //DbDataReader datareader = null;

        SqlCommand cmd = new SqlCommand();
        Conexiones con = new Conexiones();
        SqlConnection conex = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());

        con.Autenticar();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "Insert_Update_SituacionMigratoria";
        cmd.Parameters.Add("@ICodSituacionMigratoria", SqlDbType.Int).Value = ICodSituacionMigratoria;
        cmd.Parameters.Add("@ICodIE", SqlDbType.Int).Value = ICodIE;
        cmd.Parameters.Add("@CodSituacionMigratoria", SqlDbType.Int).Value = CodSituacionMigratoria;
        cmd.Parameters.Add("@SituacionMigratoria_SI_NO", SqlDbType.Int).Value = SituacionMigratoria_SI_NO;
        cmd.Parameters.Add("@VictimaTraficoPersonas", SqlDbType.Int).Value = VictimaTraficoPersonas;
        cmd.Parameters.Add("@FechaIngresoChile", SqlDbType.Int).Value = FechaIngresoChile;
        cmd.Parameters.Add("@PasoFronterizoIngresa", SqlDbType.Int).Value = PasoFronterizoIngresa;
        cmd.Parameters.Add("@CodPasoFronterizo", SqlDbType.VarChar).Value = PasoFronterizoIngresa_Cual;
        //cmd.Parameters.Add("@PasoFronterizoIngresa_Cual", SqlDbType.Int).Value = PasoFronterizoIngresa_Cual;
        cmd.Parameters.Add("@IngresosAnteriores", SqlDbType.Int).Value = IngresosAnteriores;
        cmd.Parameters.Add("@IngresosAnteriores_Cuantos", SqlDbType.Int).Value = IngresosAnteriores_Cuantos;
        cmd.Parameters.Add("@TransitadoEnOtrosPaises", SqlDbType.Int).Value = TransitadoEnOtrosPaises;
        cmd.Parameters.Add("@TransitadoEnOtrosPaises_Cuantos", SqlDbType.Int).Value = TransitadoEnOtrosPaises_Cuantos;
        cmd.Parameters.Add("@CiudadOrigenResidencia", SqlDbType.VarChar).Value = CiudadOrigenResidencia;
        cmd.Parameters.Add("@CodMotivoIngresoChile", SqlDbType.Int).Value = CodMotivoIngresoChile;
        cmd.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int).Value = IdUsuarioActualizacion;

        //Variables Requeridas por SIM (Sistema Integrado de Monitoreo)
        cmd.Parameters.Add("@AvisoRRII", SqlDbType.Bit).Value = avisoRRII;
        cmd.Parameters.Add("@FechaAvisoRRII", SqlDbType.DateTime).Value = fechaAvisoRRII;
        cmd.Parameters.Add("@GestionRegulacionMigratoria", SqlDbType.Bit).Value = gestionRegulacionMigratoria;
        cmd.Parameters.Add("@FechaGestionRegulacionMigratoria", SqlDbType.DateTime).Value = fechaGestionRegulacionMigratoria;
        cmd.Parameters.Add("@RemiteAntecedentesCasoInforme", SqlDbType.Bit).Value = remiteAntecedentesCasoInforme;
        cmd.Parameters.Add("@FechaRemiteAntecedentesCasoInforme", SqlDbType.DateTime).Value = fechaRemiteAntecedentes;
        cmd.Parameters.Add("@RetornoNNAPaisOrigen", SqlDbType.Bit).Value = retornoAlPaisOrigen;
        cmd.Parameters.Add("@FechaRetornoNNAPaisOrigen", SqlDbType.DateTime).Value = fechaRetornoNNAPaisOrigen;
        
        cmd.Connection = conex;
        try
        {
            //int CodSituacionMigratorio = 0;
            conex.Open();
            SqlDataReader Retornodata = cmd.ExecuteReader();
            //cmd.ExecuteNonQuery();
            if (Retornodata.Read())
            {
                ViewState["VS_CodSituacionmigratoria"] = Convert.ToInt32(Retornodata["identidad"]);
                //ViewState["VS_CodSituacionmigratoria"] = CodSituacionMigratoria;
            }
            cmd.Connection.Close();
            Retornodata.Close();
        }
        catch (Exception ex)
        {
            //    lb_guardar_datos.Text = "Error al grabar, intente nuevamente."; 
        }
    }


    protected int guardar_documentacion_migratoria(int CodDocumentacionMigratoria, string txtvalor, int Documento_escolaridad)
    {
        if (Documento_escolaridad != 1)
        { Documento_escolaridad = 0; }
        string Nivel_Escolaridad = string.Empty;
        Random nuevon = new Random();
        int auxDocumentacionMigra = nuevon.Next();
        int CodSituacionMigratoria = Convert.ToInt32(ViewState["VS_CodSituacionmigratoria"]);
        int returnvalue = 0;
        //int codSituacionMigratoria = Convert.ToInt16(icod_situacion_migratoria);
        SqlCommand cmd = new SqlCommand();
        Conexiones con = new Conexiones();
        SqlConnection conex = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        con.Autenticar();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "Insert_Update_DocumentacionMigratoria";
        cmd.Parameters.Add("@ICodDocumentacionMigratoria", SqlDbType.Int).Value = auxDocumentacionMigra;
        cmd.Parameters.Add("@ICodSituacionMigratoria", SqlDbType.Int).Value = CodSituacionMigratoria;
        cmd.Parameters.Add("@CodDocumentacionMigratoria", SqlDbType.Int).Value = CodDocumentacionMigratoria;
        //cmd.Parameters.Add("@DocumentacionMigratoria_SI_NO", SqlDbType.Int).Value = rb_documento_escolaridad_si.Checked ? 1 : 0;
        cmd.Parameters.Add("@DocumentacionMigratoria_SI_NO", SqlDbType.Int).Value = Documento_escolaridad;
        cmd.Parameters.Add("@NroDocumento_NivelEscolaridad", SqlDbType.VarChar).Value = txtvalor;

        cmd.Connection = conex;
        try
        {
            conex.Open();
            SqlDataReader Retornodata = cmd.ExecuteReader();

        }
        catch (Exception ex)
        { }
        return returnvalue;
    }

    protected int guardar_dominio_idiomas()
    {
        //Ciclo idiomas-nivel

        //diccionario_datos();//cambiar nombre RPA
        GetIdiomaSeleccionado();
        return 0;
    }

    public void carga_situacion_migratoria()
    {

        ICOIEAUX = Convert.ToInt32(Session["SS_ICodIE"].ToString());
        if (ICOIEAUX != 0)
        {
            GetInfoMigratoria();
            //BOTON MODIFICAR VISIBLE
            //  bt_situacion_migratoria.Visible = true; 
        }

    }
    public int ConvertNivelIdioma(string NivelIdioma)
    {
        int returnIdioma = 0;
        switch (NivelIdioma)
        {
            case "Nativo":
                returnIdioma = 1;
                break;
            case "Nada":
                returnIdioma = 0;
                break;
            case "Bajo":
                returnIdioma = 2;
                break;
            case "Medio":
                returnIdioma = 3;
                break;
            case "Alto":
                returnIdioma = 4;
                break;
        }
        return returnIdioma;
    }
    protected int GetCodIdioma(string DescripcionIdioma)
    {
        int CodIdioma = 0;
        string str_error = "";

        try
        {
            SqlDataReader reader;

            string consulta = "SELECT CodIdiomas, Descripcion, IndVigencia * FROM parIdiomas where Descripcion =" + "'" + DescripcionIdioma + "'" + "";
            SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
            SqlCommand cmd = new SqlCommand();

            DataTable dt = new DataTable();
            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CodIdioma = (int)reader["CodIdiomas"];
            }
            // Data is accessible through the DataReader object here.
            sqlConnection1.Close();
        }
        catch (Exception ex)
        { }
        return CodIdioma;

    }
    protected void GetIdiomaSeleccionado()
    {
        try
        {
            string[] arrRadioNombre;
            int codigoIdioma;
            int valorInput;
            string Idioma;
            foreach (string input in Request.Form.AllKeys)
            {
                if (input.StartsWith("Radio_"))
                {
                    arrRadioNombre = input.Split('_');
                    codigoIdioma = int.Parse(arrRadioNombre[1]);
                    valorInput = int.Parse(Request.Form[input]);
                    Idioma = Request.Form["idioma_" + codigoIdioma.ToString()];
                    GuardaIdioma(codigoIdioma, valorInput);
                }
            }

        }
        catch (Exception ex)
        { }
        finally { Response.Redirect("Datosdegestion.aspx"); }
    }

    protected void rb_ingresos_chile_si_CheckedChanged(object sender, EventArgs e)
    {

        if (rb_ingresos_chile_si.Checked)
        {
            txt_ingreso_chile.Enabled = true;
        }
        if (rb_otros_paises_no.Checked)
        {
            txt_otros_paises.Enabled = false;
        }

    }
    protected void rb_paso_fronterizo_si_CheckedChanged(object sender, EventArgs e)
    {
        if (rb_paso_fronterizo_si.Checked)
        {
            //txt_paso_fronterizo.Enabled = true;
            ddlPasoFronterizo.Enabled = true;
        }
        if (rb_paso_fronterizo_no.Checked)
        {
            //txt_paso_fronterizo.Enabled = false;
            ddlPasoFronterizo.Enabled = false;
        }
    }
    protected void identificoExtranjero(string RutNinos)
    {
        int CodTipoNacionalidad_ = 0;
        try
        {
            SqlDataReader reader;
            string consulta = "SELECT * FROM Capacitacion.dbo.Ninos where Rut  =" + "'" + RutNinos + "'" + "";
            SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
            SqlCommand cmd = new SqlCommand();

            DataTable dt = new DataTable();
            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CodTipoNacionalidad_ = (int)reader["CodTipoNacionalidad"];
                if (CodTipoNacionalidad_ == 0 || CodTipoNacionalidad_ == 1 || CodTipoNacionalidad_ == 3)
                {
                    //li_nav10.Visible = false;
                    // tab10.Visible = false;
                }
            }
            sqlConnection1.Close();
        }
        catch (Exception ex)
        { }
    }
    protected void GuardaIdioma(int int_CodIdioma, int int_NivelIdioma)
    {
        try
        {
            int returnvalue = 0;
            DbDataReader datareader = null;
            Conexiones con = new Conexiones();
            int CodSituacionMigratoria = Convert.ToInt32(ViewState["VS_CodSituacionmigratoria"]);
            DbParameter[] parametros = {
        con.parametros("@ICodDominioIdiomas", SqlDbType.Int, 4, (0)),
        con.parametros("@ICodSituacionMigratoria", SqlDbType.Int,4,(CodSituacionMigratoria)),
        con.parametros("@CodIdiomas", SqlDbType.Int, 4,(int_CodIdioma)),
        con.parametros("@NivelIdioma", SqlDbType.Int, 4,(int_NivelIdioma)) 
                                        };
            con.ejecutarProcedimiento("Insert_Update_DominioIdiomasMigratoria", parametros, out datareader);
            if (datareader.Read())
            {
                returnvalue = Convert.ToInt32(datareader["identidad"]);
            }
            con.Desconectar();
        }
        catch (Exception ex)
        { }
    }
    public bool GetInfoMigratoria()
    {
        oNNA NNA = (oNNA)Session["NNA"];
        bool valMig = false;
        if (NNA != null)
        {
            Conexiones con = new Conexiones();
            int situacionMigratoriaID = 0;
            int icoie = NNA.NNACodIE;
            try
            {
                DataTable smigratoria = (DataTable)con.TraerDataTable("Get_SituacionMigratoria", ICOIEAUX);
                if (smigratoria.Rows.Count > 0)
                {
                    panel_migra.Visible = true;
                    btn_update_situacionMigratoria.Visible = true;
                    bt_situacion_migratoria.Visible = false;
                    foreach (DataRow dt in smigratoria.Rows)
                    {
                        Session["ICODSITU"] = (int)dt["ICodSituacionMigratoria"];
                        dd_situacion_migratoria.SelectedIndex = (int)dt["CodSituacionMigratoria"];

                        int situacionMigratoria = Convert.ToInt32(dt["SituacionMigratoria_SI_NO"]);
                        int victimatraficopersona = Convert.ToInt32(dt["VictimaTraficoPersonas"]);
                        int pasfronterizoingresa = Convert.ToInt32(dt["PasoFronterizoIngresa"]);
                        int ingresosanteriores = Convert.ToInt32(dt["IngresosAnteriores"]);
                        int transitadotnotrospaises = Convert.ToInt32(dt["TransitadoEnOtrosPaises"]);
                        if (situacionMigratoria == 1)
                        {

                            rbl_situacionMigratoria.SelectedValue = "1";
                            dd_situacion_migratoria.Enabled = true;
                            //rb_situacion_si.Checked = true;
                            //rb_situacion_no.Checked = false;
                        }
                        else
                        {
                            rbl_situacionMigratoria.SelectedValue = "0";
                            dd_situacion_migratoria.Enabled = false;
                            //rb_situacion_no.Checked = true;
                            //rb_situacion_si.Checked = false;
                        }
                        if (victimatraficopersona == 1)
                        {
                            rb_victima_trafico_si.Checked = true;
                            rb_victima_trafico_no.Checked = false;
                        }
                        else
                        {
                            rb_victima_trafico_no.Checked = true;
                            //rb_tarjeta_turismo_si.Checked = false;
                        }
                        ddl_mes.Text = (dt["FechaIngresoChile"].ToString().Substring(4, 2));
                        ddl_ano.Text = dt["FechaIngresoChile"].ToString().Substring(0, 4);


                        if (pasfronterizoingresa == 1)
                        {
                            rb_paso_fronterizo_si.Checked = true;
                            rb_paso_fronterizo_no.Checked = false;
                        }
                        else
                        {
                            rb_paso_fronterizo_no.Checked = true;
                            rb_paso_fronterizo_si.Checked = false;

                        }
                        //txt_paso_fronterizo.Text = dt["CodPasoFronterizo"].ToString();
                        ddlPasoFronterizo.SelectedValue = dt["CodPasoFronterizo"].ToString();
                        if (ingresosanteriores == 1)
                        {
                            rb_ingresos_chile_si.Checked = true;
                            rb_ingresos_chile_no.Checked = false;
                            txt_ingreso_chile.Text = dt["IngresosAnteriores_Cuantos"].ToString();
                        }
                        else
                        {
                            rb_ingresos_chile_no.Checked = true;
                            rb_ingresos_chile_si.Checked = false;
                        }
                        
                        if (transitadotnotrospaises == 1)
                        {
                            rb_otros_paises_si.Checked = true;
                            rb_otros_paises_no.Checked = false;
                            txt_otros_paises.Text = dt["TransitadoEnOtrosPaises_Cuantos"].ToString();
                        }
                        else { rb_otros_paises_no.Checked = true; rb_otros_paises_si.Checked = false; }

                        txt_ciudad_origen.Text = dt["CiudadOrigenResidencia"].ToString();
                        dd_motivo_ingreso.SelectedIndex = Convert.ToInt32(dt["CodMotivoIngresoChile"]);

                        situacionMigratoriaID = Convert.ToInt32(dt["ICodSituacionMigratoria"]);

                        bool avisoRRII = Convert.ToBoolean(dt["AvisoRRIIdeIngresoNNAMigrante"]);
                        bool GestionRegulacionMigratoria = Convert.ToBoolean(dt["GestionRegulacionMigratoria"]);
                        bool RemiteAntecedentesCasoRRII = Convert.ToBoolean(dt["RemiteAntecedentesCasoRRII"]);
                        bool RetornoNNAPaisOrigen = Convert.ToBoolean(dt["RetornoNNAPaisOrigen"]);

                        if (avisoRRII)
                        {
                            avisorrii_si.Checked = true;
                            avisorrii_no.Checked = false;

                            txtFechaAvisoRRII.Text = Convert.ToDateTime(dt["FechaAvisoRRIIIngresoNNAMigrante"].ToString()).ToShortDateString();
                            txtFechaAvisoRRII.Enabled = true;
                        }else
                        {
                            avisorrii_si.Checked = false;
                            avisorrii_no.Checked = true;
                        }

                        if (GestionRegulacionMigratoria)
                        {
                            GestionRegulacionMigratoria_si.Checked = true;
                            GestionRegulacionMigratoria_no.Checked = false;
                            txtFechaGestionRegulacionMigratoria.Text = Convert.ToDateTime(dt["FechaGestionRegulacionMigratoria"].ToString()).ToShortDateString();
                            txtFechaGestionRegulacionMigratoria.Enabled = true;
                        }
                        else
                        {
                            GestionRegulacionMigratoria_si.Checked = false;
                            GestionRegulacionMigratoria_no.Checked = true;
                        }

                        if (RemiteAntecedentesCasoRRII)
                        {
                            RemiteAntecedentesCasoInformePericialDiagnostico_si.Checked = true;
                            RemiteAntecedentesCasoInformePericialDiagnostico_no.Checked = false;
                            txtFechaRemiteAntecedentes.Text = Convert.ToDateTime(dt["FechaRemiteAntecedentesCasoRII"].ToString()).ToShortDateString();
                            txtFechaRemiteAntecedentes.Enabled = true;
                        }
                        else
                        {
                            RemiteAntecedentesCasoInformePericialDiagnostico_si.Checked = false;
                            RemiteAntecedentesCasoInformePericialDiagnostico_no.Checked = true;
                        }

                        if (RetornoNNAPaisOrigen)
                        {
                            RetornoNNAaPaisOrigen_si.Checked = true;
                            RetornoNNAaPaisOrigen_no.Checked = false;
                            txtFechaRetornoPaisOrigen.Text = Convert.ToDateTime(dt["FechaRetornoNNAPaisOrigen"].ToString()).ToShortDateString();
                            txtFechaRetornoPaisOrigen.Enabled = true;
                        }
                        else
                        {
                            RetornoNNAaPaisOrigen_si.Checked = false;
                            RetornoNNAaPaisOrigen_no.Checked = true;
                        }
                    }

                    GetDocumentacionmigratoria(situacionMigratoriaID);
                }
                else
                {
                    pnl_victima.Visible = false;
                    btn_update_situacionMigratoria.Visible = false;
                    bt_situacion_migratoria.Visible = true;
                    panel_migra.Visible = false;
                }

            }
            catch (Exception ex)
            { }
        }
        return valMig;
    }

    

    protected void GetDocumentacionmigratoria(int IdIcod_situacionMigratoria)
    {
        Conexiones con = new Conexiones();
        int icodSituacionmigratoria = 0;
        try
        {
            DataTable dmigratoria = (DataTable)con.TraerDataTable("Get_DocumentacionMigratoria", IdIcod_situacionMigratoria);
            if (dmigratoria.Rows.Count > 0)
            {
                foreach (DataRow dt in dmigratoria.Rows)
                {
                    // Session["ICODDOCU"] = dt[""];
                    string documentosMigratorio = dt["CodDocumentacionMigratoria"].ToString();
                    int documentacionmigratoria_SI_NO = Convert.ToInt32(dt["DocumentacionMigratoria_SI_NO"]);
                    //txt_n_documento_extranjero.Text = documentosMigratorio;
                    //if (txt_n_documento_extranjero.Text == "")
                    //{
                    //    //rb_extranjero_residente_no.Checked = true;
                    //    //rb_extranjero_residente_si.Checked = false;
                    //}
                    //else
                    //{
                    //    //rb_extranjero_residente_si.Checked = true;
                    //    //rb_extranjero_residente_no.Checked = false;
                    //}
                    if (documentacionmigratoria_SI_NO == 1)
                    {
                        //rb_documento_escolaridad_si.Checked = true;
                        //rb_documento_escolaridad_no.Checked = false;
                    }
                    else
                    {
                        //rb_documento_escolaridad_no.Checked = true;
                        //rb_documento_escolaridad_si.Checked = false;
                    }

                    icodSituacionmigratoria = Convert.ToInt32(dt["ICodSituacionMigratoria"]);
                }
                GetDominioIdioma(icodSituacionmigratoria);
            }

        }
        catch (Exception ex)
        { }
    }
    protected void GetDominioIdioma(int ICodSituacionMigratoria)
    {
        Conexiones con = new Conexiones();
        DataTable dIdmigratoria = (DataTable)con.TraerDataTable("Get_DominioIdiomasMigratoria", ICodSituacionMigratoria);
        if (dIdmigratoria.Rows.Count > 0)
        {

            foreach (DataRow dt in dIdmigratoria.Rows)
            {


            }
            for (int x = 0; x < dIdmigratoria.Rows.Count; x++)
            {

            }

            SqlDataReader reader;

            string consulta = "SELECT CodIdiomas, NivelIdioma From DominioIdiomasMigratoria where  ICodSituacionMigratoria =" + "'" + ICodSituacionMigratoria + "'" + "";
            SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
            SqlCommand cmd = new SqlCommand();

            DataTable dtt = new DataTable();
            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int CodIdioma = (int)reader["CodIdiomas"];
                int NivelIdioma = (int)reader["NivelIdioma"];

            }
            sqlConnection1.Close();

            foreach (DataRow dt in dIdmigratoria.Rows)
            {
                string[] arrRadioNombre;
                int codigoIdioma;
                int valorInput;
                string Idioma;
                foreach (string input in Request.Form.AllKeys)
                {

                    if (input.StartsWith("Radio_"))
                    {
                        arrRadioNombre = input.Split('_');
                        codigoIdioma = int.Parse(arrRadioNombre[1]);
                        valorInput = int.Parse(Request.Form[input]);
                        Idioma = Request.Form["idioma_" + codigoIdioma.ToString()];
                    }
                }
            }
        }
    }
    protected void getIdiomas()
    {
        /*
         * Esta funcion obtiene los idiomas disponibles en la base de datos para cargarlos como opciones en el ddownIdiomas.
         * gfontbrevis
         */
        string consulta = "SELECT * FROM [parIdiomas]";
        parcoll pc = new parcoll();
        DataTable dt = pc.ejecuta_SQL(consulta);
        if (dt.Rows.Count > 0)
        {
            DataView dv = new DataView(dt);
            dv.Sort = "Descripcion";
        }

    }

    protected void getParPasoFronterizo()
    {
        Conexiones c = new Conexiones();
        



        DataTable dt = c.TraerDataTable("Get_PasosFronterizos");

        DataRow dr = dt.NewRow();
        dr["CodPasoFronterizo"] = 0;
        dr["PasoFronterizo"] = "Seleccionar";
        dr["CodRegion"] = 0;
        dr["IndVigencia"] = "V";

        dt.Rows.Add(dr);

        DataView dv = new DataView(dt);

        dv.Sort = "CodPasoFronterizo";

        ddlPasoFronterizo.DataSource = dv;
        ddlPasoFronterizo.DataValueField = "CodPasoFronterizo";
        ddlPasoFronterizo.DataTextField = "PasoFronterizo";
        ddlPasoFronterizo.DataBind();

    }
    protected void GuardoDocumentacion()
    {
        try
        {

            string[] arrRadioNombre;
            int codigoDocumentacion;
            int valorInput;
            string val_txt;
            foreach (string input in Request.Form.AllKeys)
            {
                if (input.StartsWith("RadioDoc_"))
                {
                    arrRadioNombre = input.Split('_');
                    codigoDocumentacion = int.Parse(arrRadioNombre[1]);
                    valorInput = int.Parse(Request.Form[input]);
                    val_txt = Request.Form["Doc_datos_" + codigoDocumentacion.ToString()];
                    guardar_documentacion_migratoria(codigoDocumentacion, val_txt, valorInput);


                    // docMIG = { codigoDocumentacion.ToString(), val_txt, valorInput.ToString() };


                }
            }

        }
        catch (Exception ex)
        { }
    }
    protected void btn_update_situacionMigratoria_Click(object sender, EventArgs e)
    {
        int guardar = 0;
        if (!situacion_migratoria())
        {
            alerts.Visible = true;
            lb_situacion_migratoria.Visible = true;
            lb_situacion_migratoria.Text = "Debe llenar toda la información de Situación migratoria";
            guardar++;
        }
        if (!documentacion_migratoria())
        {
            alerts.Visible = true;
            lb_documentacion_migratoria.Visible = true;
            lb_documentacion_migratoria.Text = "Debe llenar toda la información de Documentación migratoria";
            guardar++;
        }
        if (!proceso_migracion())
        {
            alerts.Visible = true;
            lb_proceso_migracion.Visible = true;
            lb_proceso_migracion.Text = "Debe llenar toda la información de Proceso Migratorio";
            guardar++;
        }


        if (guardar == 0)
        {
            Modifica_situacion_migratoria();
            ModificoDocumentacion();
            //GuardoDocumentacion();
            GetModIdiomaSeleccionado();
            ListView2.DataBind();
            regionesList.DataBind();
            validatescurity();
            UpdatePanel1.Update();
        }
        UpdatePanel1.Update();
    }

    private void validatescurity()
    {
        //21A824F4-19EC-4D44-9C44-C4136DD5AC66 2.4_MODIFICAR
        if (!window.existetoken("21A824F4-19EC-4D44-9C44-C4136DD5AC66"))
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "mostrarDocumentacionActiva1", "mostrarDocumentacionActiva();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "mostrarIdiomasActivos1", "mostrarIdiomasActivos();", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "mostrarTodosDocumentos1", "mostrarTodosDocumentacion();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "mostrarTodosIdiomas1", "mostrarTodosIdiomas();", true);
            //ScriptManager.RegisterClientScriptResource(, GetType(), "mostrarOcultarDocDatos1", "$('input[name^='RadioDoc_1_']').click(function () {if ($(this).val() == '0') {$('input[name^='Doc_datos_1']').attr('readonly', 'readonly');} else { $('input[name^='Doc_datos_1']').removeAttr('readonly');}}); };", true);
        }
        //9273FC38-331B-4E54-B78E-1E7CB41CB0B5 2.4_ELIMINAR
        if (!window.existetoken("9273FC38-331B-4E54-B78E-1E7CB41CB0B5"))
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "mostrarDocumentacionActiva", "mostrarTodosDocumentacion();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "mostrarIdiomasActivos", "mostrarTodosIdiomas  ();", true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "mostrarTodosDocumentos2", "mostrarTodosDocumentacion();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "mostrarTodosIdiomas2", "mostrarTodosIdiomas();", true);
            //ScriptManager.RegisterStartupScript(this, GetType(), "mostrarOcultarDocDatos1", "$('input[name^='RadioDoc_1_']').click(function () {if ($(this).val() == '0') {$('input[name^='Doc_datos_1']').attr('readonly', 'readonly');} else { $('input[name^='Doc_datos_1']').removeAttr('readonly');}}); };", true);
            //Parent.FindControl("UpdatePanel11").DataBind();
        }
    }

    protected void ModificoDocumentacion()
    {
        try
        {

            string[] arrRadioNombre;
            int codigoDocumentacion;
            int valorInput;
            string val_txt;
            int Icoddocumentacion;
            foreach (string input in Request.Form.AllKeys)
            {
                if (input.StartsWith("RadioDoc_"))
                {
                    arrRadioNombre = input.Split('_');
                    codigoDocumentacion = int.Parse(arrRadioNombre[1]);
                    if (arrRadioNombre[2] == "")
                    {
                        Random nuevon = new Random();
                        Icoddocumentacion = 0;
                    }
                    else
                    {
                        Icoddocumentacion = int.Parse(arrRadioNombre[2]);
                    }

                    valorInput = int.Parse(Request.Form[input]);
                    val_txt = Request.Form["Doc_datos_" + codigoDocumentacion.ToString()];
                    Modifico_documentacion_migratoria(codigoDocumentacion, val_txt, valorInput, Icoddocumentacion);



                }
            }

        }
        catch (Exception ex)
        { }
    }
    protected void GetModIdiomaSeleccionado()
    {
        try
        {
            string[] arrRadioNombre;
            int codigoIdioma;
            int valorInput;
            string Idioma;
            int ICODIDIOMA;
            foreach (string input in Request.Form.AllKeys)
            {
                if (input.StartsWith("Radio_"))
                {
                    arrRadioNombre = input.Split('_');
                    codigoIdioma = int.Parse(arrRadioNombre[1]);
                    if (arrRadioNombre[2] == "")
                    {
                        ICODIDIOMA = 0;
                    }
                    else
                    { ICODIDIOMA = int.Parse(arrRadioNombre[2]); }
                    valorInput = int.Parse(Request.Form[input]);
                    Idioma = Request.Form["idioma_" + codigoIdioma.ToString()];
                    GuardaIdiomaModificado(codigoIdioma, valorInput, ICODIDIOMA);
                }
            }

        }
        catch (Exception ex)
        { }
    }
    protected void GuardaIdiomaModificado(int int_CodIdioma, int int_NivelIdioma, int IcodIDIOMA)
    {
        try
        {
            int returnvalue = 0;
            DbDataReader datareader = null;
            Conexiones con = new Conexiones();
            int CodSituacionMigratoria = Convert.ToInt32(ViewState["VS_CodSituacionmigratoria"]);
            DbParameter[] parametros = {
        con.parametros("@ICodDominioIdiomas", SqlDbType.Int, 4, (IcodIDIOMA)),
        con.parametros("@ICodSituacionMigratoria", SqlDbType.Int,4,(CodSituacionMigratoria)),
        con.parametros("@CodIdiomas", SqlDbType.Int, 4,(int_CodIdioma)),
        con.parametros("@NivelIdioma", SqlDbType.Int, 4,(int_NivelIdioma)) 
                                       };
            con.ejecutarProcedimiento("Insert_Update_DominioIdiomasMigratoria", parametros, out datareader);
            if (datareader.Read())
            {
                returnvalue = Convert.ToInt32(datareader["identidad"]);
            }
            con.Desconectar();
        }
        catch (Exception ex)
        { }
    }
    protected void Modifica_situacion_migratoria()
    {
        int IngresosAnteriores_Cuantos = 0;
        int TransitadoEnOtrosPaises_Cuantos = 0;
        try
        {
            int ICodSituacionMigratoria = Convert.ToInt32(Session["ICODSITU"].ToString());
            //int ICodIE = SSnino.ICodIE;
            int ICodIE = Convert.ToInt32(Session["SS_ICodIE"].ToString());
            int CodSituacionMigratoria = dd_situacion_migratoria.SelectedIndex;
            int SituacionMigratoria_SI_NO = rb_situacion_si.Checked ? 1 : 0;
            int VictimaTraficoPersonas = rb_victima_trafico_si.Checked ? 1 : 0;
            //int FechaIngresoChile = int.Parse(ddl_ano.SelectedValue.ToString() + ddl_mes.SelectedValue.ToString());
            int FechaIngresoChile = int.Parse(txt_fechaIngresoChile.Text.Trim().Replace("-", ""));
            int PasoFronterizoIngresa = rb_paso_fronterizo_si.Checked ? 1 : 0;
            //int PasoFronterizoIngresa_Cual = Convert.ToInt32(txt_paso_fronterizo.Text); //CodPasoFronterizo

            int PasoFronterizoIngresa_Cual;
            if (PasoFronterizoIngresa == 1)
            {
                PasoFronterizoIngresa_Cual = Convert.ToInt32(ddlPasoFronterizo.SelectedValue);
            }
            else
            {
                PasoFronterizoIngresa_Cual = 0;
            }
            

            //int PasoFronterizoIngresa_Cual = Convert.ToInt32(txt_paso_fronterizo.Text);
            int IngresosAnteriores = rb_ingresos_chile_si.Checked ? 1 : 0;
            if (txt_ingreso_chile.Text == "")
            {
                IngresosAnteriores_Cuantos = 0;
            }
            else
            { IngresosAnteriores_Cuantos = Convert.ToInt16(txt_ingreso_chile.Text); }
            int TransitadoEnOtrosPaises = rb_otros_paises_si.Checked ? 1 : 0;
            if (txt_otros_paises.Text == "")
            { TransitadoEnOtrosPaises = 0; }
            else { TransitadoEnOtrosPaises_Cuantos = Convert.ToInt16(txt_otros_paises.Text); }
            string CiudadOrigenResidencia = txt_ciudad_origen.Text;
            int CodMotivoIngresoChile = dd_motivo_ingreso.SelectedIndex;
            int IdUsuarioActualizacion = Convert.ToInt32(Session["IdUsuario"]);

            bool avisoRRII = avisorrii_si.Checked ? true : false;
            DateTime fechaAvisoRRII = (avisoRRII ? Convert.ToDateTime(txtFechaAvisoRRII.Text) : new DateTime(1900, 01, 01));

            bool gestionRegulacionMigratoria = GestionRegulacionMigratoria_si.Checked ? true : false;
            DateTime fechaGestionRegulacionMigratoria = (gestionRegulacionMigratoria ? Convert.ToDateTime(txtFechaGestionRegulacionMigratoria.Text) : new DateTime(1900, 01, 01));

            bool remiteAntecedentesCasoInforme = RemiteAntecedentesCasoInformePericialDiagnostico_si.Checked ? true : false;
            DateTime fechaRemiteAntecedentes = (remiteAntecedentesCasoInforme ? Convert.ToDateTime(txtFechaRemiteAntecedentes.Text) : new DateTime(1900, 01, 01));

            bool retornoAlPaisOrigen = RetornoNNAaPaisOrigen_si.Checked ? true : false;
            DateTime fechaRetornoNNAPaisOrigen = (retornoAlPaisOrigen ? Convert.ToDateTime(txtFechaRetornoPaisOrigen.Text) : new DateTime(1900, 01, 01));

            //int returnvalue = 0;


            SqlCommand cmd = new SqlCommand();
            Conexiones con = new Conexiones();
            SqlConnection conex = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());

            con.Autenticar();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Insert_Update_SituacionMigratoria";
            cmd.Parameters.Add("@ICodSituacionMigratoria", SqlDbType.Int).Value = ICodSituacionMigratoria;
            cmd.Parameters.Add("@ICodIE", SqlDbType.Int).Value = ICodIE;
            cmd.Parameters.Add("@CodSituacionMigratoria", SqlDbType.Int).Value = CodSituacionMigratoria;
            cmd.Parameters.Add("@SituacionMigratoria_SI_NO", SqlDbType.Int).Value = SituacionMigratoria_SI_NO;
            cmd.Parameters.Add("@VictimaTraficoPersonas", SqlDbType.Int).Value = VictimaTraficoPersonas;
            cmd.Parameters.Add("@FechaIngresoChile", SqlDbType.Int).Value = FechaIngresoChile;
            cmd.Parameters.Add("@PasoFronterizoIngresa", SqlDbType.Int).Value = PasoFronterizoIngresa;
            cmd.Parameters.Add("@CodPasoFronterizo", SqlDbType.Int).Value = PasoFronterizoIngresa_Cual;
            //cmd.Parameters.Add("@PasoFronterizoIngresa_Cual", SqlDbType.VarChar).Value = PasoFronterizoIngresa_Cual;
            //cmd.Parameters.Add("@PasoFronterizoIngresa_Cual", SqlDbType.Int).Value = PasoFronterizoIngresa_Cual;
            cmd.Parameters.Add("@IngresosAnteriores", SqlDbType.Int).Value = IngresosAnteriores;
            cmd.Parameters.Add("@IngresosAnteriores_Cuantos", SqlDbType.Int).Value = IngresosAnteriores_Cuantos;
            cmd.Parameters.Add("@TransitadoEnOtrosPaises", SqlDbType.Int).Value = TransitadoEnOtrosPaises;
            cmd.Parameters.Add("@TransitadoEnOtrosPaises_Cuantos", SqlDbType.Int).Value = TransitadoEnOtrosPaises_Cuantos;
            cmd.Parameters.Add("@CiudadOrigenResidencia", SqlDbType.VarChar).Value = CiudadOrigenResidencia;
            cmd.Parameters.Add("@CodMotivoIngresoChile", SqlDbType.Int).Value = CodMotivoIngresoChile;
            cmd.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int).Value = IdUsuarioActualizacion;

            //Variables Requeridas por SIM (Sistema Integrado de Monitoreo)
            cmd.Parameters.Add("@AvisoRRII", SqlDbType.Bit).Value = avisoRRII;
            cmd.Parameters.Add("@FechaAvisoRRII", SqlDbType.DateTime).Value = fechaAvisoRRII;
            cmd.Parameters.Add("@GestionRegulacionMigratoria", SqlDbType.Bit).Value = gestionRegulacionMigratoria;
            cmd.Parameters.Add("@FechaGestionRegulacionMigratoria", SqlDbType.DateTime).Value = fechaGestionRegulacionMigratoria;
            cmd.Parameters.Add("@RemiteAntecedentesCasoInforme", SqlDbType.Bit).Value = remiteAntecedentesCasoInforme;
            cmd.Parameters.Add("@FechaRemiteAntecedentesCasoInforme", SqlDbType.DateTime).Value = fechaRemiteAntecedentes;
            cmd.Parameters.Add("@RetornoNNAPaisOrigen", SqlDbType.Bit).Value = retornoAlPaisOrigen;
            cmd.Parameters.Add("@FechaRetornoNNAPaisOrigen", SqlDbType.DateTime).Value = fechaRetornoNNAPaisOrigen;

            cmd.Connection = conex;
            try
            {
                conex.Open();
                SqlDataReader Retornodata = cmd.ExecuteReader();
                if (Retornodata.Read())
                {
                    ViewState["VS_CodSituacionmigratoria"] = Convert.ToInt32(Retornodata["identidad"]);
                }
                cmd.Connection.Close();
                Retornodata.Close();
            }
            catch (Exception ex)
            {
                //    lb_guardar_datos.Text = "Error al grabar, intente nuevamente."; 
            }
        }
        catch (Exception ex)
        { }
    }
    protected int Modifico_documentacion_migratoria(int CodDocumentacionMigratoria, string txtvalor, int Documento_escolaridad, int IcodDocu)
    {

        string Nivel_Escolaridad = string.Empty;
        Random nuevon = new Random();
        int auxDocumentacionMigra = nuevon.Next();
        int CodSituacionMigratoria = Convert.ToInt32(ViewState["VS_CodSituacionmigratoria"]);
        int returnvalue = 0;
        SqlCommand cmd = new SqlCommand();
        Conexiones con = new Conexiones();
        SqlConnection conex = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        con.Autenticar();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "Insert_Update_DocumentacionMigratoria";
        cmd.Parameters.Add("@ICodDocumentacionMigratoria", SqlDbType.Int).Value = IcodDocu;
        cmd.Parameters.Add("@ICodSituacionMigratoria", SqlDbType.Int).Value = CodSituacionMigratoria;
        cmd.Parameters.Add("@CodDocumentacionMigratoria", SqlDbType.Int).Value = CodDocumentacionMigratoria;
        //cmd.Parameters.Add("@DocumentacionMigratoria_SI_NO", SqlDbType.Int).Value = rb_documento_escolaridad_si.Checked ? 1 : 0;
        cmd.Parameters.Add("@DocumentacionMigratoria_SI_NO", SqlDbType.Int).Value = Documento_escolaridad;
        cmd.Parameters.Add("@NroDocumento_NivelEscolaridad", SqlDbType.VarChar).Value = txtvalor;

        cmd.Connection = conex;
        try
        {
            conex.Open();
            SqlDataReader Retornodata = cmd.ExecuteReader();

        }
        catch (Exception ex)
        { }
        CodDocumentacionMigratoria = 0;
        txtvalor = string.Empty;
        Documento_escolaridad = 0;
        IcodDocu = 0;
        return returnvalue;
    }

    protected void RetornoNNAaPaisOrigen_si_CheckedChanged(object sender, EventArgs e)
    {
        txtFechaRetornoPaisOrigen.Enabled = true;
    }
    protected void RetornoNNAaPaisOrigen_no_CheckedChanged(object sender, EventArgs e)
    {
        txtFechaRetornoPaisOrigen.Enabled = false;
    }
    protected void RemiteAntecedentesCasoInformePericialDiagnostico_si_CheckedChanged(object sender, EventArgs e)
    {
        txtFechaRemiteAntecedentes.Enabled = true;
    }
    protected void RemiteAntecedentesCasoInformePericialDiagnostico_no_CheckedChanged(object sender, EventArgs e)
    {
        txtFechaRemiteAntecedentes.Enabled = false;
    }
    protected void avisorrii_si_CheckedChanged(object sender, EventArgs e)
    {
        txtFechaAvisoRRII.Enabled = true;
    }
    protected void avisorrii_no_CheckedChanged(object sender, EventArgs e)
    {
        txtFechaAvisoRRII.Enabled = false;
    }
    protected void GestionRegulacionMigratoria_si_CheckedChanged(object sender, EventArgs e)
    {
        txtFechaGestionRegulacionMigratoria.Enabled = true;
    }
    protected void GestionRegulacionMigratoria_no_CheckedChanged(object sender, EventArgs e)
    {
        txtFechaGestionRegulacionMigratoria.Enabled = false;
    }
}