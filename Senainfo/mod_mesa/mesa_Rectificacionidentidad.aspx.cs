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
////////using neocsharp.NeoDatabase;

using System.Data.SqlClient;

using System.Collections.Generic;
using System.Data.Common;

public partial class mod_mesa_mesa_Rectificacionidentidad : System.Web.UI.Page
{
    private DataSet DvBusqueda
    {
        get { return (DataSet)Session["DvBusqueda"]; }
        set { Session["DvBusqueda"] = value; }
    }
    private int sem
    {
        get { return (int)Session["sem"]; }
        set { Session["sem"] = value; }
    }
    private int des
    {
        get { return (int)Session["des"]; }
        set { Session["des"] = value; }
    }

    public nino SSninoDiag
    {
        get
        {
            if (Session["neo_SSninoDiag"] == null)
            { Session["neo_SSninoDiag"] = new nino(); }
            return (nino)Session["neo_SSninoDiag"];
        }
        set { Session["neo_SSninoDiag"] = value; }
    }
    string SParametrosConsultas = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
            {
                Response.Redirect("~/logout.aspx");
            }
            else
            {                              
                if (!window.existetoken("EEC5380C-60B8-4E41-9B51-7BB60CA12C93") || !window.existetoken("B65DD182-8A4C-48EE-8C8C-9727AF2388C8"))
                {
                    Response.Redirect("~/logout.aspx"); ;
                }
                nacionalidades();
                etnias();
                sem = 0;
                cal_Nacim.Text = DateTime.Now.ToShortDateString();
                validatescurity();
            }
        }
    }
    private void validatescurity()
    {
        //0A1715B2-9D19-44A0-A067-B1F3AEF2B4B7 6.2_INGRESAR
        if (!window.existetoken("0A1715B2-9D19-44A0-A067-B1F3AEF2B4B7"))
        {
            btn_guardar.Visible = false;
        }
        //7AD10DA4-7503-43D0-A6C2-9372034617A0 6.4_INGRESAR
        if (!window.existetoken("7AD10DA4-7503-43D0-A6C2-9372034617A0"))
        {
            btn_actualizar.Visible = false;
            
        }
       

    }
    private void nacionalidades()
    {
        parcoll par = new parcoll();
        DataView dv = new DataView(par.GetparNacionalidades());
        dv.Sort = "CodNacionalidad";
        ddown_nacionalidad.DataSource = dv;
        ddown_nacionalidad.DataValueField = "CodNacionalidad";
        ddown_nacionalidad.DataTextField = "Descripcion";
        ddown_nacionalidad.DataBind();
    
    }
    private void etnias()
    {
        parcoll par = new parcoll();
        DataView dv = new DataView(par.GetparEtnias());
        dv.Sort = "CodEtnia";
        ddown_etnia.DataSource = dv;
        ddown_etnia.DataValueField = "CodEtnia";
        ddown_etnia.DataTextField = "Descripcion";
        ddown_etnia.DataBind();

    }
    protected void btn_volver_Click(object sender, EventArgs e)
    {
      
        Panel1.Visible = false;
        pnl002.Visible = false;
        pnl005.Visible = false;
        pnl001.Visible = false;
        Pnl_Descicion.Visible = true;
        btn_limpiar.Visible = false;
        btn_volver.Visible = false;
        btn_volver2.Visible = true;
        btn_actualizar.Visible = true;
    }
    
    
    private void Function_Genera_String_Consulta(string sParametrosConsulta)
    {
        List<DbParameter> listDbParameter = new List<DbParameter>();

         /* sParametrosConsulta = "Select Distinct top 201 T1.CodNino,T2.Rut,T2.Sexo,T2.Nombres,T2.Apellido_paterno,T2.Apellido_Materno," +
                              "T2.FechaNacimiento From Ingresos_Egresos T1 inner join Ninos T2 On T1.CodNino = T2.CodNino " +
                              "inner join Proyectos T3 On T1.CodProyecto = T3.CodProyecto ";
        */
        sParametrosConsulta = "Select Distinct top 201 T2.CodNino,T2.Rut,T2.Sexo,T2.Nombres,T2.Apellido_paterno,T2.Apellido_Materno," +
                              "T2.FechaNacimiento, T2.CodNacionalidad From Ninos T2 ";

        if (txt007.Text.Trim() != "" || txt002.Text.Trim() != "" ||
                txt004.Text != "" || txt005.Text != "" || txt006.Text != "" || rdolist001.SelectedValue != "")
        {
            sParametrosConsulta = sParametrosConsulta + "Where ";
        }


        if (txt002.Text.Trim() != "")
        {
            sParametrosConsulta = sParametrosConsulta + " T2.CodNino =@pCodNino And";

            listDbParameter.Add(Conexiones.CrearParametro("@pCodNino", SqlDbType.Int, 4, Convert.ToInt32(txt002.Text.Trim())));
        }
        if (txt004.Text != "")
        {
            sParametrosConsulta = sParametrosConsulta + " T2.Apellido_Paterno like @pApellido_Paterno And";

            listDbParameter.Add(Conexiones.CrearParametro("@pApellido_Paterno", SqlDbType.VarChar, 50, "%" + txt004.Text + "%"));
        }
        if (txt005.Text != "")
        {
            sParametrosConsulta = sParametrosConsulta + " T2.Apellido_Materno like @pApellido_Materno And";

            listDbParameter.Add(Conexiones.CrearParametro("@pApellido_Materno", SqlDbType.VarChar, 50, "%" + txt005.Text + "%"));
        }
        if (txt006.Text != "")
        {
            sParametrosConsulta = sParametrosConsulta + " T2.Nombres like @pNombres And";

            listDbParameter.Add(Conexiones.CrearParametro("@pNombres", SqlDbType.VarChar, 100, "%" + txt006.Text + "%"));
        }
        if (txt007.Text.Trim() != "")
        {
            sParametrosConsulta = sParametrosConsulta + " T2.Rut =@pRut And";

            listDbParameter.Add(Conexiones.CrearParametro("@pRut", SqlDbType.VarChar, 11, txt007.Text.Trim()));
        }
        if (rdolist001.SelectedValue != "")
        {
            sParametrosConsulta = sParametrosConsulta + " T2.Sexo =@pSexo And";

            listDbParameter.Add(Conexiones.CrearParametro("@pSexo", SqlDbType.Char, 1, rdolist001.SelectedValue));
        }
       
        if (sParametrosConsulta.Substring(sParametrosConsulta.Length - 3, 3) == "And")
        {
            sParametrosConsulta = sParametrosConsulta.Substring(0, sParametrosConsulta.Length - 3);
        }


        ninocoll nic = new ninocoll();
        DataSet dv = new DataSet();
        dv.Tables.Add(nic.get_ninorelacionado(sParametrosConsulta, listDbParameter));

        if (dv.Tables[0].Rows.Count > 0 && dv.Tables[0].Rows.Count < 200)
        {
            lnk001.Visible = false;
            dv.Tables[0].DefaultView.Sort = "Apellido_paterno, Apellido_Materno, Nombres";
            grd003.DataSource = dv;
            grd003.DataBind();
            DvBusqueda = dv;
            lbl0014.Visible = false;
            grd003.Visible = true;
        }
        else if (dv.Tables[0].Rows.Count == 0)
        {
            grd003.Visible = false;
            try
            {
                if (sem == 1)
                {

                    lbl0014.Text = "El Niño buscado no ha sido encontrado, desea crearlo?";
                    lnk001.Visible = true;
                    lbl0014.Visible = true;
                }
                else
                {
                    lbl0014.Text = "El Niño buscado no ha sido encontrado, desea crearlo?";
                    lnk001.Visible = false;
                    lbl0014.Visible = true;

                
                }
            }
            catch
            {
                
            }

        }
        else if (dv.Tables[0].Rows.Count > 200)
        {
            grd003.Visible = false;
            lbl0014.Visible = true;
            lbl0014.Text = "Búsqueda demasiado ambigua, Ingrese parámetros.";
            lnk001.Visible = false;
        }


    }
    protected void WebImageButton3_Click(object sender, EventArgs e)
    {
        Function_Genera_String_Consulta(SParametrosConsultas);
    }

    protected void grd003_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Ver")
        {
            int cuenta = 0;
            if (sem == 0)
            {
                if (des == 0)
                {
                   funcion_cargarectificacion(Convert.ToInt32(grd003.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text));
                   btn_actualizar.Visible = true;
                   grd003.Visible = false;
                }
                else if (des == 1)
                {
                    cuenta = carga_grd001(Convert.ToInt32(grd003.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text));
                    if (cuenta > 0)
                    {
                        lbl001.Text = grd003.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text + " " + grd003.Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Text + " " + grd003.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Text;
                        lbl_codNinoOrigen.Text = grd003.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
                        grd001.Visible = true;
                        pnl001.Visible = true;
                        grd003.Visible = false;
                        lbl002.Text = "AL QUE RECIBE INGRESOS";
                        sem = 1;

                    }
                }
            }
            else if (sem == 1)
            {
                cuenta = carga_grd002(Convert.ToInt32(grd003.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text));
                if (cuenta > 0)
                {
                    lbl003.Text = grd003.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text + " " + grd003.Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Text + " " + grd003.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Text;
                    lblCodNinoDestino.Text = grd003.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
                    grd002.Visible = true;
                    Panel1.Visible = false;
                    pnl002.Visible = true;
                    grd003.Visible = false;
                    funcion_cargarectificacion(Convert.ToInt32(grd003.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text));
                    btn_guardar.Visible = true;
                }

            }

            validatescurity();
        }
        if (e.CommandName == "Historial")
        {
           SSninoDiag.CodNino = Convert.ToInt32(grd003.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text);
           window.open(this.Page, "../mod_mesa/mesa_HistoricoNino.aspx", "Historicos", true, 1000, 430, false, false, true);
        }
    }
    private int carga_grd001(int codnino)
    {
        DataView dv = new DataView();
        dv = new DataView(rectificacion_ingresos(codnino));
        if (dv.Count > 0)
        {
            dv.Sort = "ICodIE";
            grd001.DataSource = dv;
            grd001.DataBind();
            return dv.Count;
        }
        else
        {
            DataTable dt = new DataTable();
            grd001.DataSource = dt;
            grd001.DataBind();
            return 0;
        }
    }
    private int carga_grd002(int codnino)
    {
        DataView dv = new DataView();
        dv = new DataView(rectificacion_ingresos(codnino));
        if (dv.Count > 0)
        {
            dv.Sort = "ICodIE";
            grd002.DataSource = dv;
            grd002.DataBind();
            return dv.Count;
        }
        else
        {
            DataTable dt = new DataTable();
            grd001.DataSource = dt;
            grd001.DataBind();
            return 0;
        }

    }
    private void funcion_cargarectificacion(int codnino)
    {
        DataTable dt = rectificacion_nino(codnino);
        if (dt.Rows.Count > 0)
        {
            lbl_CodNinoActual.Text = codnino.ToString();
            txt_rut.Text = dt.Rows[0][1].ToString();
            chk001.Checked = Convert.ToBoolean(Convert.ToInt32(dt.Rows[0][2]));
            txt_Nombre.Text = dt.Rows[0][3].ToString();
            txt_apPaterno.Text = dt.Rows[0][4].ToString();
            txt_apMaterno.Text = dt.Rows[0][5].ToString();
            ddown_sexo.SelectedValue = dt.Rows[0][6].ToString();
            try
            {
                cal_Nacim.Text = Convert.ToDateTime(dt.Rows[0][7]).ToShortDateString();
            }
            catch
            { }
            txt_edadActual.Text = dt.Rows[0][9].ToString();
            ddown_nacionalidad.SelectedValue = dt.Rows[0][17].ToString();
            chk_ident.Checked = Convert.ToBoolean(dt.Rows[0][8]);
            ddown_etnia.SelectedValue = dt.Rows[0][10].ToString();
            txt_Oficina.Text = dt.Rows[0][11].ToString();
            txt_Ano.Text = dt.Rows[0][12].ToString();
            txt_NInscrip.Text = dt.Rows[0][13].ToString();
            TextBox1.Text = dt.Rows[0][14].ToString();
            ddown_Registro.SelectedValue = Convert.ToInt32(dt.Rows[0][15]).ToString();
            ddown_Fonasa.SelectedValue = Convert.ToInt32(dt.Rows[0][16]).ToString();
            pnl005.Visible = true;
        }
    }
    private void procesar()
    {
        if(txt_Nombre.Text.Trim() =="" || txt_apPaterno.Text.Trim() == "" || txt_apMaterno.Text.Trim() == ""||
            ddown_Registro.SelectedValue == "-1" || ddown_Fonasa.SelectedValue == "-1" || ddown_sexo.SelectedValue == "-1" || cal_Nacim.Text == "Seleccione Fecha")
        {
            check();
        }
        else
        {
           

            CheckBox tchk001 = new CheckBox();
            string ingresos ="";
            for (int i = 0; i < grd001.Rows.Count; i++)
            {
                tchk001 = (CheckBox)grd001.Rows[i].Cells[0].FindControl("chk001");
                if (tchk001.Checked)
                {
                    ingresos += grd001.Rows[i].Cells[1].Text + ","; 
                    
                }
             
            
            }

            DateTime FechaNac = Convert.ToDateTime("01-01-1900").Date;
            if (cal_Nacim.Text != "Seleccione Fecha")
            {
                FechaNac = Convert.ToDateTime(cal_Nacim.Text);
            }

            int Ano = 0;
            if (txt_Ano.Text.Trim() != "")
            {
                Ano = Convert.ToInt32(txt_Ano.Text.Trim());
            }

                DataTable dt = rectificacion_procesar(Convert.ToInt32(lbl_codNinoOrigen.Text),Convert.ToInt32(lblCodNinoDestino.Text),Convert.ToDateTime("01-01-1900"),
                Convert.ToInt32(chk_ident.Checked),txt_rut.Text,Convert.ToInt32(chk001.Checked),txt_Nombre.Text.ToUpper(),txt_apPaterno.Text.ToUpper(),txt_apMaterno.Text.ToUpper(),ddown_sexo.SelectedValue,
                FechaNac,Convert.ToInt32(ddown_etnia.SelectedValue),txt_Oficina.Text.ToUpper(),Ano,
                txt_NInscrip.Text.ToUpper(),TextBox1.Text.ToUpper(),Convert.ToInt32(ddown_Registro.SelectedValue),Convert.ToInt32(ddown_Fonasa.SelectedValue),
                0, "N", DateTime.Now, Convert.ToInt32(Session["IdUsuario"])/*usr*/, Convert.ToInt32(ddown_nacionalidad.SelectedValue), ingresos.Trim());

                ddown_sexo.BackColor = System.Drawing.Color.White;
                txt_Nombre.BackColor = System.Drawing.Color.White;
                txt_apPaterno.BackColor = System.Drawing.Color.White; 
                txt_apMaterno.BackColor = System.Drawing.Color.White; 
                ddown_Registro.BackColor = System.Drawing.Color.White; 
                ddown_Fonasa.BackColor = System.Drawing.Color.White;
                btn_guardar.Visible = false;    

                carga_grd001(Convert.ToInt32(lbl_codNinoOrigen.Text));
                carga_grd002(Convert.ToInt32(dt.Rows[0][1]));

                funcion_limpiar();
        
        }

    }
    private void check()
    {
        if (txt_Nombre.Text.Trim() == "") { txt_Nombre.BackColor = System.Drawing.Color.Pink; }
        else { txt_Nombre.BackColor = System.Drawing.Color.White; }
        if (txt_apPaterno.Text.Trim() == "") { txt_apPaterno.BackColor = System.Drawing.Color.Pink; }
        else { txt_apPaterno.BackColor = System.Drawing.Color.White; }
        if (txt_apMaterno.Text.Trim() == "") { txt_apMaterno.BackColor = System.Drawing.Color.Pink; }
        else { txt_apMaterno.BackColor = System.Drawing.Color.White; }
        if (ddown_Registro.SelectedValue == "-1") { ddown_Registro.BackColor = System.Drawing.Color.Pink; }
        else { ddown_Registro.BackColor = System.Drawing.Color.White; }
        if (ddown_Fonasa.SelectedValue == "-1") { ddown_Fonasa.BackColor = System.Drawing.Color.Pink; }
        else { ddown_Fonasa.BackColor = System.Drawing.Color.White; }
        if (ddown_sexo.SelectedValue == "-1") { ddown_sexo.BackColor = System.Drawing.Color.Pink; }
        else { ddown_sexo.BackColor = System.Drawing.Color.White; }
        if (cal_Nacim.Text == "Seleccione Fecha") { cal_Nacim.BackColor = System.Drawing.Color.Pink; }
        else { cal_Nacim.BackColor = System.Drawing.Color.White; }
    }
    #region procedimientos_almacenados
    private DataTable rectificacion_ingresos(int codnino)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "rectificacion_ingresos";
        sqlc.Parameters.Add("@codnino", SqlDbType.Int, 4).Value = codnino;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    private DataTable rectificacion_nino(int codnino)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "rectificacion_nino";
        sqlc.Parameters.Add("@codnino", SqlDbType.Int, 4).Value = codnino;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    private DataTable rectificacion_procesar(int codnino_original, int codnino_nuevo, DateTime fechaadoptabilidad, int identidadconfirmada, string run, int sin_run, string nombres, string apellido_paterno, string apellido_materno, string sexo, DateTime fechanacimiento, int codetnia, string oficinainscripcion, int anoinscripcion, string numeroinscripcioncivil, string alergiasconocidas, int inscritofonadis, int inscritofonasa, int ninosuceptibleadopcion, string estadogestacion, DateTime fechaactualizacion, int idusuarioactualizacion, int codnacionalidad, string ingresos)
    {
        object objFechaNac = DBNull.Value;
        if (fechanacimiento != Convert.ToDateTime("01-01-1900").Date)
        {
            objFechaNac = fechanacimiento;
        };

        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "rectificacion_procesar";
        sqlc.Parameters.Add("@Codnino_original", SqlDbType.Int, 4).Value = codnino_original;
        sqlc.Parameters.Add("@Codnino_nuevo", SqlDbType.Int, 4).Value = codnino_nuevo;
        sqlc.Parameters.Add("@FechaAdoptabilidad", SqlDbType.DateTime, 16).Value = fechaadoptabilidad;
        sqlc.Parameters.Add("@IdentidadConfirmada", SqlDbType.Bit, 1).Value = identidadconfirmada;
        sqlc.Parameters.Add("@Run", SqlDbType.VarChar, 20).Value = run;
        sqlc.Parameters.Add("@Sin_run", SqlDbType.Int, 4).Value = sin_run;
        sqlc.Parameters.Add("@Nombres", SqlDbType.VarChar, 100).Value = nombres;
        sqlc.Parameters.Add("@Apellido_Paterno", SqlDbType.VarChar, 100).Value = apellido_paterno;
        sqlc.Parameters.Add("@Apellido_Materno", SqlDbType.VarChar, 100).Value = apellido_materno;
        sqlc.Parameters.Add("@Sexo", SqlDbType.VarChar, 1).Value = sexo;
        sqlc.Parameters.Add("@FechaNacimiento", SqlDbType.DateTime, 16).Value = objFechaNac;
        sqlc.Parameters.Add("@CodEtnia", SqlDbType.Int, 4).Value = codetnia;
        sqlc.Parameters.Add("@OficinaInscripcion", SqlDbType.VarChar, 50).Value = oficinainscripcion;
        sqlc.Parameters.Add("@AnoInscripcion", SqlDbType.Int, 4).Value = anoinscripcion;
        sqlc.Parameters.Add("@NumeroInscripcionCivil", SqlDbType.VarChar, 20).Value = numeroinscripcioncivil;
        sqlc.Parameters.Add("@AlergiasConocidas", SqlDbType.VarChar, 200).Value = alergiasconocidas;
        sqlc.Parameters.Add("@InscritoFONADIS", SqlDbType.Bit, 1).Value = inscritofonadis;
        sqlc.Parameters.Add("@InscritoFONASA", SqlDbType.Bit, 1).Value = inscritofonasa;
        sqlc.Parameters.Add("@NinoSuceptibleAdopcion", SqlDbType.Bit, 1).Value = ninosuceptibleadopcion;
        sqlc.Parameters.Add("@EstadoGestacion", SqlDbType.Char, 1).Value = estadogestacion;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 16).Value = fechaactualizacion;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = idusuarioactualizacion;
        sqlc.Parameters.Add("@CodNacionalidad", SqlDbType.Int, 4).Value = codnacionalidad;
        sqlc.Parameters.Add("@Ingresos", SqlDbType.VarChar, 100).Value = ingresos;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    #endregion
    protected void btn_guardar_Click(object sender, EventArgs e)
    {
        procesar();
    }

    protected void lnk001_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        grd003.DataSource = dt;
        grd003.DataBind();
        lblCodNinoDestino.Text = "0";
        pnl005.Visible = true;
        Panel1.Visible = false;
        lnk001.Visible = false;
        lbl0014.Visible = false;
        btn_guardar.Visible = true;
        validatescurity();
    }
    protected void txt_rut_ValueChange(object sender, EventArgs e)
    {
        try
        {
            if (txt_rut.Text.Length > 3)
            {
                string rutsinnada = txt_rut.Text.Replace(".", "").Replace(",", "").Replace("-", "").Trim();
                string digitoingresado = rutsinnada.Substring(rutsinnada.Length - 1, 1);

                string digitocalculado = digitoVerificador(Convert.ToInt32(rutsinnada.ToUpper().Replace("K", "").Substring(0, rutsinnada.Length - 1)));
                if (digitocalculado.ToUpper() == digitoingresado.ToUpper())
                {
                    this.Form.FindControl("pnl003").Visible = false;
                    string punorut = rutsinnada.ToUpper().Replace("K", "").Substring(0, rutsinnada.Length - 1).Trim();
                    string rcompleto = punorut + "-" + digitocalculado.ToUpper();
                    txt_rut.Text = rcompleto;

                    ninocoll ncoll = new ninocoll();
                    int ind = ncoll.callto_get_consultaRut(txt_rut.Text.Trim());

                    if (ind == 1)
                    {
                        Response.Write("<script languaje='javascript'>alert('El Rut Ingresado ya existe en la red.');</script>");
                        btn_actualizar.Enabled = true;
                        txt_rut.Text = "";
                        rutsinnada = "";
                        digitocalculado = "";
                        digitocalculado = "";
                        punorut = "";
                        rcompleto = "";                        
                    }
                    else 
                    {
                        btn_actualizar.Enabled = true;
                    }
                }
                else
                {
                    ((Label)Form.FindControl("lbl004")).Text = "RUT INGRESADO NO ES VALIDO";
                    this.Form.FindControl("pnl003").Visible = true;
                }
            }
            else
            {
                ((Label)Form.FindControl("lbl004")).Text = "RUT INGRESADO NO ES VALIDO";
                this.Form.FindControl("pnl004").Visible = true;
            }
        }
        catch
        {
            ((Label)Form.FindControl("lbl004")).Text = "RUT INGRESADO NO ES VALIDO";
            this.Form.FindControl("pnl003").Visible = true;
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
    protected void chk001_CheckedChanged(object sender, EventArgs e)
    {
        if (chk001.Checked)
        {
            txt_rut.Text = "";
            txt_rut.ReadOnly = true;
            pnl003.Visible = false;
        }
        else
        {
            txt_rut.ReadOnly = false;
        }
    }
    protected void cal_Nacim_ValueChanged(object sender, EventArgs e)
    {
        if (cal_Nacim.Text != "Seleccione Fecha")
        {
            DateTime itime = Convert.ToDateTime(cal_Nacim.Text);
            TimeSpan compare = DateTime.Now.Date - itime.Date;
            int y = Convert.ToInt32(compare.Days / 365);
            int m = (compare.Days - (y * 365)) / 30;
            txt_edadActual.Text = y.ToString();
        }
    
    }

    protected void btn_limpiar_Click(object sender, EventArgs e)
    {
        funcion_limpiar();
        
    }

    private void funcion_limpiar()
    {
        txt002.Text = "";
        txt004.Text = "";
        txt005.Text = "";
        txt006.Text = "";
        txt007.Text = "";
        txt_Ano.Text = "";
        txt_apMaterno.Text = "";
        txt_apPaterno.Text = "";
        txt_edadActual.Text = "";
        txt_NInscrip.Text = "";
        txt_Nombre.Text = "";
        txt_Oficina.Text = "";
        txt_rut.Text = "";
        ddown_etnia.SelectedIndex = 0;
        ddown_Fonasa.SelectedIndex = 0;
        ddown_nacionalidad.SelectedIndex = 0;
        ddown_Registro.SelectedIndex = 0;
        ddown_sexo.SelectedIndex = 0;
        TextBox1.Text = "";
        chk_ident.Checked = false;
        chk001.Checked = false;
        if (Panel1.Visible == true)
        {
            rdolist001.SelectedValue = "";
        }

        Panel1.Visible = true;
        pnl001.Visible = false;
        pnl002.Visible = false;
        pnl005.Visible = false;

        cal_Nacim.Text = null;
        sem = 0;
        btn_guardar.Visible = false;
        btn_actualizar.Visible = false;
       
    
    }
    protected void WebImageButton2_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Pnl_Descicion.Visible = false;
        des = 1;
        lbl002.Visible = true;
        btn_limpiar.Visible = true;
        btn_volver.Visible = true;
        btn_volver2.Visible = false;
    }
    protected void WebImageButton1_Click(object sender, EventArgs e)
    {
        lbl002.Visible = false;
        Panel1.Visible = true;
        Pnl_Descicion.Visible = false;
        des = 0;
        btn_limpiar.Visible = true;
        btn_volver.Visible = true;
        btn_volver2.Visible = false;
    }
    protected void btn_actualizar_Click(object sender, EventArgs e)
    {
        if (lbl004.Visible == false)
        {
            if (txt_Nombre.Text.Trim() == "" || txt_apPaterno.Text.Trim() == "" || txt_apMaterno.Text.Trim() == "" ||
                ddown_Registro.SelectedValue == "-1" || ddown_Fonasa.SelectedValue == "-1" || ddown_sexo.SelectedValue == "-1")
            {
                check();
            }
            else
            {
                int Ano = 0;
                if (txt_Ano.Text.Trim() != "")
                {
                    Ano = Convert.ToInt32(txt_Ano.Text.Trim());
                }
                DateTime FechaNac = Convert.ToDateTime("01-01-1900").Date;
                if (cal_Nacim.Text != "Seleccione Fecha")
                {
                    FechaNac = Convert.ToDateTime(cal_Nacim.Text);
                }

                ninocoll nic = new ninocoll();
                nic.Update_Ninos(Convert.ToInt32(lbl_CodNinoActual.Text), Convert.ToDateTime("01-01-1900"), chk_ident.Checked,
                    txt_rut.Text, ddown_sexo.SelectedValue, txt_Nombre.Text.ToUpper(), txt_apPaterno.Text.ToUpper(), txt_apMaterno.Text.ToUpper(), FechaNac,
                    Convert.ToInt32(ddown_nacionalidad.SelectedValue), Convert.ToInt32(ddown_etnia.SelectedValue), txt_Oficina.Text.ToUpper(), Ano, txt_NInscrip.Text.ToUpper(),
                    TextBox1.Text.ToUpper(), Convert.ToBoolean(Convert.ToInt32(ddown_Registro.SelectedValue)), Convert.ToBoolean(Convert.ToInt32(ddown_Fonasa.SelectedValue)), Convert.ToBoolean(0), "N", DateTime.Now, Convert.ToInt32(Session["IdUsuario"]) /*usr*/);

                ddown_sexo.BackColor = System.Drawing.Color.White;
                txt_Nombre.BackColor = System.Drawing.Color.White;
                txt_apPaterno.BackColor = System.Drawing.Color.White;
                txt_apMaterno.BackColor = System.Drawing.Color.White;
                ddown_Registro.BackColor = System.Drawing.Color.White;
                ddown_Fonasa.BackColor = System.Drawing.Color.White;

                btn_actualizar.Visible = false;

            }
        }
        else
        {
            ((Label)Form.FindControl("lbl004")).Visible = true;
            ((Label)Form.FindControl("lbl004")).Text = "DEBE CORREGIR RUT PARA ACTUALIZAR";
            this.Form.FindControl("pnl003").Visible = true;
        }
    }
    protected void grd001_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd001.PageIndex = e.NewPageIndex;
        carga_grd001(Convert.ToInt32(lbl_codNinoOrigen.Text));
    }
    protected void grd002_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd002.PageIndex = e.NewPageIndex;
        carga_grd002(Convert.ToInt32(lblCodNinoDestino.Text));
    }
    protected void grd003_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd003.PageIndex = e.NewPageIndex;
        if (DvBusqueda.Tables[0].Rows.Count > 0)
        {
            DvBusqueda.Tables[0].DefaultView.Sort = "Apellido_paterno";
            grd003.DataSource = DvBusqueda;
            grd003.DataBind();
        }
        

    }
    protected void txt_Ano_ValueChange(object sender, EventArgs e)
    {
        if (Convert.ToInt32(txt_Ano.Text.Trim()) > Convert.ToInt32(DateTime.Now.Year))
        {
            txt_Ano.Text = "";
            txt_Ano.BackColor = System.Drawing.Color.Pink;
        }
        else
        {
            txt_Ano.BackColor = System.Drawing.Color.White;
        }
    }
    protected void btn_volver2_Click(object sender, EventArgs e)
    {
        Response.Redirect("index_mesa.aspx");
    }
}
