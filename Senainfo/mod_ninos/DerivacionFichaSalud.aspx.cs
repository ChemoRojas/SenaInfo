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
using System.Data.SqlClient;
using System.Text.RegularExpressions;

public partial class mod_ninos_DerivacionFichaSalud : System.Web.UI.Page
{
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

        if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "RedirectScript", "parent.location.reload();", true);
            //Response.Write("<script language='javascript'>parent.location.reload();</script>"); // carga la pagina padre para que verifique el padre si perdio la sesión y no el hijo 

            //Response.Redirect("~/logout.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                GetData();

                if (Request.QueryString["sw"] != "" && Request.QueryString["mdf"] != "")
                {
                    if (Session["CodDiagnostico"].ToString() != "")
                    {
                        ObtenerDerivacion();
                    }
                }
            }
        }
    }

    public string RemoverAcentos(string inputString)
    {
        Regex a = new Regex("[á|à|ä|â|Á]", RegexOptions.Compiled);
        Regex e = new Regex("[é|è|ë|ê|É]", RegexOptions.Compiled);
        Regex i = new Regex("[í|ì|ï|î|Í]", RegexOptions.Compiled);
        Regex o = new Regex("[ó|ò|ö|ô|Ó]", RegexOptions.Compiled);
        Regex u = new Regex("[ú|ù|ü|û|Ú]", RegexOptions.Compiled);
        Regex n = new Regex("[ñ|Ñ]", RegexOptions.Compiled);
        inputString = a.Replace(inputString, "A");
        inputString = e.Replace(inputString, "E");
        inputString = i.Replace(inputString, "I");
        inputString = o.Replace(inputString, "O");
        inputString = u.Replace(inputString, "U");
        inputString = n.Replace(inputString, "N");
        return inputString;
    }

    private void ObtenerDerivacion()
    {
        string Tipo = Request.QueryString["sw"].ToString();
        string Modificar = "no";

        if (window.existetoken("4E0E80E3-5BC7-4A0F-8535-778E2613F35B"))
        {
            Modificar = "no";
        }

        if (window.existetoken("804C2A82-7B95-4C04-9A9B-AC8A2B0E5587"))
        {
            Modificar = Request.QueryString["mdf"].ToString();
        }        

        if (Tipo == "Vision")
        {
            Session["TipoDerivacion"] = 1;
        }
        if (Tipo == "Audicion")
        {   
            Session["TipoDerivacion"] = 2;
        }
        if (Tipo ==  "SaludBucal")
        {
            Session["TipoDerivacion"] = 3;
        }
        if (Tipo == "Columna")
        {            
            Session["TipoDerivacion"] = 4;
        }

        int CodTipoDerivacion = Convert.ToInt32(Session["TipoDerivacion"]);

        SqlTransaction sqlt;
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        sconn.Open();
        sqlt = sconn.BeginTransaction();
        try
        {           
            int CodDiagnostico = Convert.ToInt32(Session["CodDiagnostico"].ToString());
            int CodFichaSaludInicial = GetCodDiagnosticoSaludFichaInicial(sqlt, CodDiagnostico);
            Session["CodFichaSaludInicial"] = CodFichaSaludInicial;

            if (CodFichaSaludInicial > 0)
            {
                String PrimerApellido = RemoverAcentos((HttpUtility.HtmlDecode(SSninoDiag.Apellido_Paterno.ToString())).Trim());
                String SegundoApellido = RemoverAcentos((HttpUtility.HtmlDecode(SSninoDiag.Apellido_Materno.ToString())).Trim());
                String Nombre = RemoverAcentos((HttpUtility.HtmlDecode(SSninoDiag.Nombres.ToString())).Trim());
                String FecNac = SSninoDiag.FechaNacimiento.ToShortDateString().Replace("-", "");
                String Rut = (SSninoDiag.rut.ToString()).Trim();

                try
                {
                    if ((PrimerApellido != null || PrimerApellido != "") && (SegundoApellido != null || SegundoApellido != "") && (Nombre != null || Nombre != "") && (Rut != null || Rut != "") && (FecNac != null || FecNac != ""))
                    {
                        txtNIdentificacion.Text = Nombre.Substring(0, 1) + PrimerApellido.Substring(0, 1) + SegundoApellido.Substring(0, 1) + FecNac + Rut.Substring((Rut.Length - 5), 5);
                    }
                    else
                    {
                        txtNIdentificacion.Text = "Faltan Datos para generar el N° de identificación ";
                    }

                }
                catch
                {
                    txtNIdentificacion.Text = "Datos erroneos para generar el N° de identificación";
                }

                if (SSninoDiag.NombreInst != null)
                {
                    if (SSninoDiag.NombreInst.ToString() != "")
                    {
                        txtInstitucionQueDeriva.Text = SSninoDiag.NombreInst.ToString();
                    }
                }

                if (SSninoDiag.NombreProy != null)
                {
                    if (SSninoDiag.NombreProy.ToString() != "")
                    {
                        txtProyectoQueDeriva.Text = SSninoDiag.NombreProy.ToString();
                    }
                }
                   

                DataTable dtDerivacionFichaSalud = GetDerivacionFichaSalud(sqlt, CodFichaSaludInicial, CodTipoDerivacion);              

                if (dtDerivacionFichaSalud.Rows.Count == 1) // existe la ficha de derivación
                {                    

                    txtInstitucionALaQueDeriva.Text = dtDerivacionFichaSalud.Rows[0]["InstitucionALaQueDeriva"].ToString();

                    try
                    {
                        ddlRegionInstitucionALaQueDeriva.Items.FindByValue(ddlRegionInstitucionALaQueDeriva.SelectedValue).Selected = false;
                        ddlRegionInstitucionALaQueDeriva.Items.FindByValue(dtDerivacionFichaSalud.Rows[0]["CodRegionInstitucionALaQueDeriva"].ToString()).Selected = true;
                    }
                    catch { }

                    try
                    {
                        ddlPersonaQuienDeriva.Items.FindByValue(ddlPersonaQuienDeriva.SelectedValue).Selected = false;
                        ddlPersonaQuienDeriva.Items.FindByValue(dtDerivacionFichaSalud.Rows[0]["IdPersonaQuienDeriva"].ToString()).Selected = true;
                    }
                    catch { }

                    divIngresoDatos.Visible = true;
                    divAlertaSinDerivacion.Visible = false;

                    if (Modificar == "si")
                    {
                        lnkGuardarDerivacion.Visible = true;
                    }
                    if (Modificar == "no")
                    {
                        lnkGuardarDerivacion.Visible = false;
                    }

                }

                if (dtDerivacionFichaSalud.Rows.Count == 0) // no existe la ficha de deriváción
                {

                    if (Modificar == "si")
                    {
                        divIngresoDatos.Visible = true;
                        divAlertaSinDerivacion.Visible = false;
                    }
                    if (Modificar == "no")
                    {
                        divIngresoDatos.Visible = false;
                        divAlertaSinDerivacion.Visible = true;
                        lblAlertaSinDerivacion.Text = "No existe derivación asociada a la ficha de salud inicial";
                    }
                }

                if (dtDerivacionFichaSalud.Rows.Count > 1) // hay mas de una ficha de derivación
                {
                    divAlertaSinDerivacion.Visible = true;
                    lblAlertaSinDerivacion.Text = "ERROR, hay mas de una ficha de derivación de " + Tipo + ". Por favor contactarse con mesa de ayuda.";
                    Response.Write("<script language='javascript'>alert('ERROR, hay mas de una ficha de derivación de " + Tipo + ". Por favor contactarse con mesa de ayuda. ');</script>");
                    divIngresoDatos.Visible = false;
                }
            }

            else
            {
                divIngresoDatos.Visible = false;
            }

            sqlt.Commit();
            sconn.Close();            
        }
        catch (Exception ex)
        {
            Response.Write("<script language='javascript'>alert('Hay problemas con la ficha de salud, intentar nuevamene.');</script>");
            Console.WriteLine(ex.Message);
            try
            {
                sqlt.Rollback();
            }
            catch (Exception exRollback)
            {
                Response.Write("<script language='javascript'>alert('Hay problemas con la ficha de salud, por favor contactarse con mesa de ayuda. ');</script>");
                Console.WriteLine(exRollback.Message);
            }
        }
    }


    public int GetCodDiagnosticoSaludFichaInicial(SqlTransaction sqlt, int CodDiagnostico)
    {
        int returnvalue = 0;
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;
        sqlc.CommandType = System.Data.CommandType.Text;

        sqlc.CommandText = "select T1.CodFichaSaludInicial from DiagnosticoSaludFichaSaludInicial T1 where T1.CodDiagnostico = @CodDiagnostico";
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodDiagnostico", SqlDbType.Int, 4, CodDiagnostico));
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        da.Fill(dt);      

        if (dt.Rows.Count == 1)
        {
            returnvalue = Convert.ToInt32(dt.Rows[0][0]);
        }
        if (dt.Rows.Count > 1)
        {
            returnvalue = -1;
        }
        return returnvalue;
    }

    public DataTable GetDerivacionFichaSalud(SqlTransaction sqlt, int CodFichaSaludInicial, int CodTipoDerivacion)
    {
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;
        sqlc.CommandType = System.Data.CommandType.Text;

        sqlc.CommandText = "select InstitucionALaQueDeriva, CodRegionInstitucionALaQueDeriva, IdPersonaQuienDeriva from FichaDerivacion where CodFichaSaludInicial = @CodFichaSaludInicial ";

        if (CodTipoDerivacion == 1)
        {
            sqlc.CommandText = sqlc.CommandText + " and CodTipoDerivacion = 1";            
        }

        if (CodTipoDerivacion == 2)
        {
            sqlc.CommandText = sqlc.CommandText + " and CodTipoDerivacion = 2";            
        }
        if (CodTipoDerivacion ==  3)
        {
            sqlc.CommandText = sqlc.CommandText + " and CodTipoDerivacion = 3";            
        }
        if (CodTipoDerivacion == 4)
        {
            sqlc.CommandText = sqlc.CommandText + " and CodTipoDerivacion = 4";            
        }

        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodFichaSaludInicial", SqlDbType.Int, 4, CodFichaSaludInicial));        
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        da.Fill(dt);       
        return dt;
    }

    private void GetData()
    {

        DataSet ds = (DataSet)Session["dsParametricas"];

        if (SSnino != null)
        {
            int edad = 0;
            txtPrimerApellido.Text = HttpUtility.HtmlDecode(SSninoDiag.Apellido_Paterno.ToString()); 
            txtSegundoApellido.Text = HttpUtility.HtmlDecode(SSninoDiag.Apellido_Materno.ToString());
            txtNombre.Text = HttpUtility.HtmlDecode(SSninoDiag.Nombres.ToString());
            txtRut.Text = SSninoDiag.rut.ToString();
            txtFechaNacimiento.Text = SSninoDiag.FechaNacimiento.ToShortDateString();
            edad = Convert.ToInt32((DateTime.Now.Year - SSninoDiag.FechaNacimiento.Year).ToString());
            txtEdad.Text = edad.ToString();
            //ddlSexo.SelectedValue = SSninoDiag.sexo.ToString();
            //txtDomicilio.Text =
            //ddlNacionalidad.SelectedValue = SSninoDiag.CodNacionalidad.ToString();
                 
           
            DataView dv = new DataView(ds.Tables["dtparRegion"]);
            ddlRegion.DataSource = dv;
            ddlRegion.DataTextField = "Descripcion";
            ddlRegion.DataValueField = "CodRegion";
            dv.Sort = "CodRegion ASC";
            ddlRegion.DataBind();


            ddlRegionInstitucionALaQueDeriva.DataSource = dv;
            ddlRegionInstitucionALaQueDeriva.DataTextField = "Descripcion";
            ddlRegionInstitucionALaQueDeriva.DataValueField = "CodRegion";
            dv.Sort = "CodRegion ASC";
            ddlRegionInstitucionALaQueDeriva.DataBind();

            //ddlRegionInstitucionQueDeriva.DataSource = dv;
            //ddlRegionInstitucionQueDeriva.DataTextField = "Descripcion";
            //ddlRegionInstitucionQueDeriva.DataValueField = "CodRegion";
            //dv.Sort = "CodRegion ASC";
            //ddlRegionInstitucionQueDeriva.DataBind();

            trabajadorescoll tcoll = new trabajadorescoll();
            DataView dvPersonaQuienDeriva = new DataView(tcoll.GetTrabajadoresProyecto(SSninoDiag.CodProyecto.ToString()));
            ddlPersonaQuienDeriva.Items.Clear();
            ddlPersonaQuienDeriva.DataSource = dvPersonaQuienDeriva;
            ddlPersonaQuienDeriva.DataTextField = "NombreCompleto";
            ddlPersonaQuienDeriva.DataValueField = "ICodTrabajador";
            dvPersonaQuienDeriva.Sort = "NombreCompleto";
            ddlPersonaQuienDeriva.DataBind();

            try
            {
                DataView dt = new DataView(SQL_GetDatosPersonalesNino(SSninoDiag.CodNino.ToString()));
                DataView dtDireccionNino = new DataView(SQL_GetDireccionNino(SSninoDiag.CodNino.ToString()));
                
                try
                {
                    ddlSexo.Items.FindByValue(ddlSexo.SelectedValue).Selected = false;
                    ddlSexo.Items.FindByValue(dt.Table.Rows[0][4].ToString()).Selected = true;
                }
                catch { }
                try
                {
                    txtDomicilio.Text = dtDireccionNino.Table.Rows[0][5].ToString();

                    if (dtDireccionNino.Table.Rows[0][5].ToString() == "")
                    {
                        txtDomicilio.Text = "NO TIENE DOMICILIO REGISTRADO";
                    }
                }
                catch { }
                try
                {
                    ddlComuna.Items.Add(new ListItem(dtDireccionNino.Table.Rows[0][12].ToString(), dtDireccionNino.Table.Rows[0][11].ToString()));
                    ddlComuna.Items.FindByValue(dtDireccionNino.Table.Rows[0][11].ToString()).Selected = true;
                }
                catch { }

                try
                {
                    ddlRegion.Items.FindByValue(ddlRegion.SelectedValue).Selected = false;
                    ddlRegion.Items.FindByValue(dtDireccionNino.Table.Rows[0][13].ToString()).Selected = true;
                }
                catch { }

            }
            catch { }
        }
    }


    public DataTable SQL_GetDatosPersonalesNino(string codnino)
    {

        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "SELECT CodNino, FechaAdoptabilidad, IdentidadConfirmada, Rut, Sexo, Nombres, Apellido_Paterno, Apellido_Materno, FechaNacimiento, CodNacionalidad," +
                            "CodEtnia, OficinaInscripcion, AnoInscripcion, NumeroInscripcionCivil, AlergiasConocidas, InscritoFONADIS, InscritoFONASA, NinoSuceptibleAdopcion," +
                            "EstadoGestacion, FechaActualizacion, IdUsuarioActualizacion, MuestraADN, CodTipoUsuario, CodConfirmaSRCEI, CodEstadoCivil, FechaDefuncion," +
                            "CodTipoNacionalidad FROM Ninos where CodNino = @CodNino";

        sqlc.Parameters.AddWithValue("@CodNino", codnino);
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt;
    }


    public DataTable SQL_GetDireccionNino(string codnino)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "SELECT TOP (1) T1.ICodDireccion, T1.ICodIE, T1.CodProyecto, T1.CodNino, T1.FechaIngresoDireccion, T1.Direccion, T1.Telefono, T1.TelefonoRecado, T1.Mail, T1.Fax, T1.CodigoPostal," +
                            "T1.CodComuna, (select Descripcion from parComunas where CodComuna =  T1.CodComuna) as DescripcionComuna," +
                            "(select CodRegion from parProvincia where CodProvincia = (select CodProvincia from parComunas where CodComuna =  T1.CodComuna)) as CodRegion, AlIngreso, FechaActualizacion, " +
                            " IdUsuarioActualizacion, IndVigencia FROM DireccionNinos T1 WHERE CodNino = @CodNino order by FechaActualizacion DESC ";
        sqlc.Parameters.AddWithValue("@CodNino", codnino);
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt;
    }

    private void InsertFichaDerivacion(
        SqlTransaction sqlt,
        int CodFichaSaludInicial,
        int CodTipoDerivacion,         
        string InstitucionALaQueDeriva,
        int CodRegionInstitucionALaQueDeriva,
        int IdPersonaQuienDeriva,
        DateTime FechaActualizacion)
    {
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "INSERT FichaDerivacion (CodFichaSaludInicial, CodTipoDerivacion, InstitucionALaQueDeriva, " +
                            "CodRegionInstitucionALaQueDeriva, IdPersonaQuienDeriva, FechaActualizacion) " +
                            "VALUES" +
                            "(@CodFichaSaludInicial, @CodTipoDerivacion, @InstitucionALaQueDeriva, @CodRegionInstitucionALaQueDeriva, " +
                            "@IdPersonaQuienDeriva, @FechaActualizacion)";

        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodFichaSaludInicial", SqlDbType.Int, 4, CodFichaSaludInicial));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodTipoDerivacion", SqlDbType.Int, 4, CodTipoDerivacion));        
        sqlc.Parameters.Add(Conexiones.CrearParametro("@InstitucionALaQueDeriva", SqlDbType.VarChar, 50, InstitucionALaQueDeriva));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodRegionInstitucionALaQueDeriva", SqlDbType.Int, 4, CodRegionInstitucionALaQueDeriva));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@IdPersonaQuienDeriva", SqlDbType.Int, 4, IdPersonaQuienDeriva));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion));
        
        sqlc.ExecuteNonQuery();
    }

    private void UpdateFichaDerivacion(
        SqlTransaction sqlt,
        int CodFichaSaludInicial,        
        string InstitucionALaQueDeriva,
        int CodRegionInstitucionALaQueDeriva,
        int IdPersonaQuienDeriva,
        DateTime FechaActualizacion)
    {
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sqlt.Connection;
        sqlc.Transaction = sqlt;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "UPDATE FichaDerivacion SET InstitucionALaQueDeriva = @InstitucionALaQueDeriva, " +
                            "CodRegionInstitucionALaQueDeriva = @CodRegionInstitucionALaQueDeriva, " +
                            "IdPersonaQuienDeriva = @IdPersonaQuienDeriva , FechaActualizacion = @FechaActualizacion " +
                            "WHERE CodFichaSaludInicial = @CodFichaSaludInicial";                           

        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodFichaSaludInicial", SqlDbType.Int, 4, CodFichaSaludInicial));        
        sqlc.Parameters.Add(Conexiones.CrearParametro("@InstitucionALaQueDeriva", SqlDbType.VarChar, 50, InstitucionALaQueDeriva));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@CodRegionInstitucionALaQueDeriva", SqlDbType.Int, 4, CodRegionInstitucionALaQueDeriva));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@IdPersonaQuienDeriva", SqlDbType.Int, 4, IdPersonaQuienDeriva));
        sqlc.Parameters.Add(Conexiones.CrearParametro("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion));
        
        sqlc.ExecuteNonQuery();
    }
    


    private bool ValidaFichaDerivacion()
    {
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis
        bool valida = true;

        if (txtInstitucionQueDeriva.Text == "")
        {
            txtInstitucionQueDeriva.BackColor = colorCampoObligatorio;
            valida = false;
        }
        else
        {
            txtInstitucionQueDeriva.BackColor = System.Drawing.Color.Empty;
        }

        //if (ddlRegionInstitucionQueDeriva.SelectedValue == "0")
        //{
        //    ddlRegionInstitucionQueDeriva.BackColor = colorCampoObligatorio;
        //    valida = false;
        //}
        //else
        //{
        //    ddlRegionInstitucionQueDeriva.BackColor = System.Drawing.Color.Empty;
        //}

        if (txtInstitucionALaQueDeriva.Text == "")
        {
            txtInstitucionALaQueDeriva.BackColor = colorCampoObligatorio;
            valida = false;
        }
        else
        {
            txtInstitucionALaQueDeriva.BackColor = System.Drawing.Color.Empty;
        }


        if (ddlRegionInstitucionALaQueDeriva.SelectedValue == "-2")
        {
            ddlRegionInstitucionALaQueDeriva.BackColor = colorCampoObligatorio;
            valida = false;
        }
        else
        {
            ddlRegionInstitucionALaQueDeriva.BackColor = System.Drawing.Color.Empty;
        }

        if (ddlPersonaQuienDeriva.SelectedValue == "0")
        {
            ddlPersonaQuienDeriva.BackColor = colorCampoObligatorio;
            valida = false;
        }
        else
        {
            ddlPersonaQuienDeriva.BackColor = System.Drawing.Color.Empty;
        }


        

        return valida;
        
    }

    private void GuardarDerivacion()
    {

        int codTipoDerivacion = Convert.ToInt32(Session["TipoDerivacion"]);
        int CodFichaSaludInicial = Convert.ToInt32(Session["CodFichaSaludInicial"]);

        SqlTransaction sqlt;
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        sconn.Open();
        sqlt = sconn.BeginTransaction();
        try
        {
            DataTable dtDerivacionFichaSalud = GetDerivacionFichaSalud(sqlt, CodFichaSaludInicial, codTipoDerivacion);

            if (dtDerivacionFichaSalud.Rows.Count == 0)
            {
                InsertFichaDerivacion(sqlt, CodFichaSaludInicial, codTipoDerivacion,
                                  txtInstitucionALaQueDeriva.Text, Convert.ToInt32(ddlRegionInstitucionALaQueDeriva.SelectedValue), Convert.ToInt32(ddlPersonaQuienDeriva.SelectedValue), Convert.ToDateTime(DateTime.Now));
            }

            if (dtDerivacionFichaSalud.Rows.Count == 1)
            {
                UpdateFichaDerivacion(sqlt, CodFichaSaludInicial,
                                  txtInstitucionALaQueDeriva.Text, Convert.ToInt32(ddlRegionInstitucionALaQueDeriva.SelectedValue), Convert.ToInt32(ddlPersonaQuienDeriva.SelectedValue), Convert.ToDateTime(DateTime.Now));
            }

            sqlt.Commit();
            sconn.Close();

            string Tipo = Request.QueryString["sw"].ToString();
            Response.Write("<script language='JavaScript'>;");
            Response.Write("parent.document.getElementById('btnCerrarModal" + Tipo + "').click();");
            Response.Write("parent.document.getElementById('spanDerivacion" + Tipo + "').setAttribute('class', 'glyphicon glyphicon-eye-open');");
            Response.Write("parent.document.getElementById('lblDerivacion" + Tipo + "').innerHTML = 'Ver o Modificar Derivación';");
            Response.Write("</script>");

            if (Tipo == "Vision")
            {
                Session["lblDerivacionVision"] = "VerModificar";
            }

            if (Tipo == "Audicion")
            {
                Session["lblDerivacionAudicion"] = "VerModificar";
            }

            if (Tipo == "SaludBucal")
            {
                Session["lblDerivacionSaludBucal"] = "VerModificar";
            }

            if (Tipo == "Columna")
            {
                Session["lblDerivacionColumna"] = "VerModificar";
            }


            Response.Write("<script language='javascript'>alert('Guardado de Ficha de Derivación realizada de forma exitosa');</script>");

        }
        catch (Exception ex)
        {
            Response.Write("<script language='javascript'>alert('Guardado no realizado, intentar nuevamene.');</script>");
            Console.WriteLine(ex.Message);
            try
            {
                sqlt.Rollback();
            }
            catch (Exception exRollback)
            {
                Response.Write("<script language='javascript'>alert('Guardado de derivación Realizada Con errores, por favor contactarse con mesa de ayuda . ');</script>");
                Console.WriteLine(exRollback.Message);
            }
        }
    }

    protected void lnkGuardarDerivacion_Click(object sender, EventArgs e)
    {
        if (ValidaFichaDerivacion()) 
        {
            GuardarDerivacion();
        }
        
    }
    
}