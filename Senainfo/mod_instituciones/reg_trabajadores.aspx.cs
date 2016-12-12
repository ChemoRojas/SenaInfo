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
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;
using SenainfoSdk.Helpers;
using System.IO;
using SenainfoSdk.Net;
using System.Drawing;

public partial class mod_institucion_reg_trabajadores : System.Web.UI.Page
{
    #region Propiedades
    /// <summary>
    /// Propiedad que almacena en session el codtrabajador o un valor por defecto para registro nuevo o de busqueda.
    /// </summary>
    public int vCodPaso
    {
        get { return (int)Session["vCodPaso"]; }
        set { Session["vCodPaso"] = value; }
    }

    /// <summary>
    /// Propiedad que almacena en session el idUsuario del trabajador.
    /// </summary>
    public int IdUsuarioSenainfo
    {
        get { return (int)ViewState["IdUsuarioSenainfo"]; }
        set { ViewState["IdUsuarioSenainfo"] = value; }
    }

    /// <summary>
    /// Propiedad que almacena en session el nombre de usuario. Permite verificar si ha cambiado el valor del campo usuario.
    /// </summary>
    public string InitialUser
    {
        get { return Session["strInitialUser"].ToString(); }
        set { Session["strInitialUser"] = value; }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        string urlBoton = "bsc_institucion.aspx?param001=" + lbl001.Text + "&dir=reg_trabajadores.aspx&codinst=" + ddown001.SelectedValue;

        if (!IsPostBack)
        {
            IdUsuarioSenainfo = 0;
            if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
            {
                Response.Redirect("~/logout.aspx");
            }
            else
            {
                if (!window.existetoken("A757360B-5759-4070-89D0-C9696E5C2DF8"))
                {
                    Response.Redirect("~/logout.aspx"); ;
                }

                getinstituciones();
                getprofesion();
                getregion();

                tblInfoUser.Visible = false;

                if (Request.QueryString["sw"] == "1")
                {
                    Get_Resultado_Busqueda(vCodPaso);
                    txt_usuario.Attributes.Clear();
                    ddown004.AutoPostBack = true;
                }
                else if (Request.QueryString["sw"] == "3")
                {
                    ddown001.SelectedValue = Request.QueryString["codinst"];
                    if (ddown001.SelectedValue == "6050")
                    {
                        ddown004.AutoPostBack = true;
                        ddown005.Visible = true;
                        tr_direccionregional.Visible = true;
                        lbl_direccionregional.Visible = true;
                    }
                    else
                    {
                        tr_direccionregional.Visible = false;
                        lbl_direccionregional.Visible = false;
                        ddown005.Visible = false;
                        ddown004.AutoPostBack = false;
                    }
                    llenacombo();
                }
                else
                {
                    validatescurity();
                    vCodPaso = -1;
                }
            }
        }
    }

    /// <summary>
    /// Funcion carga listas.
    /// </summary>
    private void llenacombo()
    {
        ddown_rol.Items.Add(new ListItem("Seleccionar", "0"));
        if (window.existetoken("146209E4-C62A-48FB-BD77-2913E3D64DD5"))
        {
            //100_SEGURIDAD_ADMINISTRADOR
            ddown_rol.Items.Add(new ListItem("ADMINISTRADOR DE SISTEMA", "252"));
            ddown_rol.Items.Add(new ListItem("DIRECTOR(A) NACIONAL", "253"));
            ddown_rol.Items.Add(new ListItem("ADMINISTRADOR NACIONAL FINANCIERO (AUDITORIA)", "254"));
            ddown_rol.Items.Add(new ListItem("DPTO ADMINISTRACION Y FINANZAS NACIONAL", "256"));
            ddown_rol.Items.Add(new ListItem("UNIDAD PROCESOS Y PAGOS", "259"));
            ddown_rol.Items.Add(new ListItem("ADMINISTRADOR DPTO TECNICO NACIONAL", "255"));
            ddown_rol.Items.Add(new ListItem("ADMINISTRADOR DPTO TECNICO NACIONAL CON NIÑOS", "257"));
            ddown_rol.Items.Add(new ListItem("ADMINISTRADOR TECNICO DEPLAE", "260"));
            ddown_rol.Items.Add(new ListItem("ADMINISTRADOR TECNICO DEPLAE CON NIÑOS", "261"));
            ddown_rol.Items.Add(new ListItem("ADMINISTRADOR NACIONAL JURIDICO", "258"));
            ddown_rol.Items.Add(new ListItem("ADMINISTRADOR DE COMISARIA", "272"));
            ddown_rol.Items.Add(new ListItem("COORDINADOR REGIONAL ADOPCIÓN", "274"));
            ddown_rol.Items.Add(new ListItem("COORDINADOR NACIONAL(JUDICIAL)", "278"));
            ddown_rol.Items.Add(new ListItem("COORDINADOR REGIONAL(JUDICIAL)", "277"));
            ddown_rol.Items.Add(new ListItem("SENAME LRPA", "280"));
            ddown_rol.Items.Add(new ListItem("JEFE TECNICO SENAINFO", "281"));
            ddown_rol.Items.Add(new ListItem("COORDINADOR DEPTO. JUSTICIA JUVENIL", "283"));
            ddown_rol.Items.Add(new ListItem("UPLAE PERMISOS ESPECIAL", "249"));
            ddown_rol.Items.Add(new ListItem("COORDINADOR EQUIPO GESTION (PROGRAMA VIDA NUEVA)", "288"));
            ddown_rol.Items.Add(new ListItem("JUEZ DE FAMILIA", "284"));
            ddown_rol.Items.Add(new ListItem("ADMINISTRADOR FINANCIERO INSTITUCION", "290"));
        }
        if (window.existetoken("146209E4-C62A-48FB-BD77-2913E3D64DD5") || window.existetoken("C4C499B5-1DDF-4FDB-9AB1-6B4F110A0A65"))
        {
            //100_SEGURIDAD_ADMINISTRADOR
            //102_SEGURIDAD_UPLAE
            ddown_rol.Items.Add(new ListItem("ADMINISTRADOR REGIONAL (UPRODE Y ADOPCION)", "262"));
            ddown_rol.Items.Add(new ListItem("ADMINISTRADOR REGIONAL UPLAE", "263"));
            ddown_rol.Items.Add(new ListItem("ADMINISTRADOR REGIONAL JURIDICO", "264"));
            ddown_rol.Items.Add(new ListItem("ADMINISTRADOR REGIONAL FINANCIERO", "266"));
            ddown_rol.Items.Add(new ListItem("DIRECTOR(A) REGIONAL", "248"));
            ddown_rol.Items.Add(new ListItem("COORDINADOR UNIDAD JUSTICIA JUVENIL", "282"));

        }//1FECB5C2-839A-4579-BFC1-16D9246230F0
        if (window.existetoken("146209E4-C62A-48FB-BD77-2913E3D64DD5") || window.existetoken("C9648861-72EF-4C48-9E6D-FD3074F340C5") || window.existetoken("C4C499B5-1DDF-4FDB-9AB1-6B4F110A0A65"))
        {
            //100_SEGURIDAD_ADMINISTRADOR
            //101_SEGURIDAD_INSTITUCIONYPROYECTO
            //102_SEGURIDAD_UPLAE
            ddown_rol.Items.Add(new ListItem("ADMINISTRADOR INSTITUCION", "251"));
            ddown_rol.Items.Add(new ListItem("ADMINISTRADOR FINANCIERO INSTITUCION", "290"));
        }
        if (window.existetoken("146209E4-C62A-48FB-BD77-2913E3D64DD5") || window.existetoken("C9648861-72EF-4C48-9E6D-FD3074F340C5") || window.existetoken("C4C499B5-1DDF-4FDB-9AB1-6B4F110A0A65") || window.existetoken("1FECB5C2-839A-4579-BFC1-16D9246230F0"))
        {
            //100_SEGURIDAD_ADMINISTRADOR
            //101_SEGURIDAD_INSTITUCIONYPROYECTO
            //102_SEGURIDAD_UPLAE
            //103_SEGURIDAD_ADMINISTRADOR_PROYECTO
            ddown_rol.Items.Add(new ListItem("ADMINISTRADOR DEL PROYECTO", "265"));
            ddown_rol.Items.Add(new ListItem("TECNICO DEL PROYECTO", "267"));
            ddown_rol.Items.Add(new ListItem("ADMINISTRADOR FINANCIERO PROYECTO", "268"));
            ddown_rol.Items.Add(new ListItem("ADMINISTRATIVO PROYECTO", "269"));
            ddown_rol.Items.Add(new ListItem("TECNICO PROYECTO SENAINFO (COORDINADO)", "286"));
            ddown_rol.Items.Add(new ListItem("ADMINISTRADOR DEL PROYECTO SENAINFO (COORDINADO)", "287"));
        }
        //0360BAD8-E0BB-47BE-8863-DDD5B0DBBD9F
        if (window.existetoken("C9648861-72EF-4C48-9E6D-FD3074F340C5"))
        {
            //100_SEGURIDAD_ADMINISTRADOR
            //101_SEGURIDAD_INSTITUCIONYPROYECTO
            ddown_rol.Items.Add(new ListItem("DIRECTOR(A) REGIONAL", "248"));
            ddown_rol.Items.Add(new ListItem("COORDINADOR REGIONAL ADOPCIÓN", "274"));
            ddown_rol.Items.Add(new ListItem("COORDINADOR REGIONAL", "277"));
            ddown_rol.Items.Add(new ListItem("JEFE TECNICO SENAINFO", "281"));
            ddown_rol.Items.Add(new ListItem("COORDINADOR UNIDAD JUSTICIA JUVENIL", "282"));
            ddown_rol.Items.Add(new ListItem("ADMINISTRADOR INSTITUCION", "251"));
            ddown_rol.Items.Add(new ListItem("ADMINISTRADOR REGIONAL (UPRODE,Y ADOPCION)", "262"));
            ddown_rol.Items.Add(new ListItem("ADMINISTRADOR REGIONAL UPLAE", "263"));
            ddown_rol.Items.Add(new ListItem("ADMINISTRADOR REGIONAL JURIDICO", "264"));
            ddown_rol.Items.Add(new ListItem("ADMINISTRADOR REGIONAL FINANCIERO", "266"));
            ddown_rol.Items.Add(new ListItem("ADMINISTRADOR DEL PROYECTO", "265"));
            ddown_rol.Items.Add(new ListItem("TECNICO DEL PROYECTO", "267"));
            ddown_rol.Items.Add(new ListItem("ADMINISTRADOR FINANCIERO PROYECTO", "268"));
            ddown_rol.Items.Add(new ListItem("ADMINISTRATIVO PROYECTO", "269"));
            ddown_rol.Items.Add(new ListItem("TECNICO PROYECTO SENAINFO (COORDINADO)", "286"));
            ddown_rol.Items.Add(new ListItem("ADMINISTRADOR DEL PROYECTO SENAINFO (COORDINADO)", "287"));
        }
        
    }

    /// <summary>
    /// Valida accesos a funciones del formulario segun roles.
    /// </summary>
    private void validatescurity()
    {
        ddown_rol.Items.Clear();
        //F4E295EA-02A9-4180-8BEC-F532FF357A14 1.2_INGRESAR
        if (!window.existetoken("F4E295EA-02A9-4180-8BEC-F532FF357A14"))
        {
            imb002.Visible = false;
            WebImageButton1.Visible = false;
            //block();

        }
        //8145AB2F-2E60-4A73-BCAC-E18F4271B561 1.2_MODIFICAR
        if (!window.existetoken("8145AB2F-2E60-4A73-BCAC-E18F4271B561"))
        {
            WebImageButton3.Visible = false;
            WebImageButton1.Visible = false;
            btnPswChange.Visible = false;
            btnCancelarSolicitud.Visible = false;
            btnReenvio.Visible = false;
            //block();

        }
        //85A1C656-60FC-41F8-A95C-886B0160C46E 1.2_ELIMINAR
        if (!window.existetoken("85A1C656-60FC-41F8-A95C-886B0160C46E"))
        {
            ddown003.Enabled = false;
            //block();

        }
        llenacombo();



    }

    /// <summary>
    /// Carga lista de instituciones 
    /// </summary>
    private void getinstituciones()
    {
        // << -- DPL 21-08-2015 -------------------- >>
        //institucioncoll ncoll = new institucioncoll();
        //DataView dv1 = new DataView(ncoll.GetData(Convert.ToInt32(Session["IdUsuario"])));
        // << -- DPL 21-08-2015 -------------------- >>
        DataSet ds = (DataSet)Session["dsParametricas"];
        DataView dv1 = new DataView(ds.Tables["dtInstituciones"]);
        ddown001.DataSource = dv1;
        ddown001.DataTextField = "Nombre";
        ddown001.DataValueField = "CodInstitucion";
        dv1.Sort = "Nombre ASC";
        DataBind();
    }

    /// <summary>
    /// Carga lista de profesiones.
    /// </summary>
    private void getprofesion()
    {
        parcoll pcoll = new parcoll();
        DataTable dtproy = pcoll.GetparProfesionOficio();
        try
        {

            dtproy.AsEnumerable().ToList<DataRow>().ForEach
            (r =>
                {
                    if (String.Compare(r["descripcion"].ToString(), "SALVAVIDAS") == 0 || String.Compare(r["descripcion"].ToString(), "OFICIOS EN LOCALES PARA ADULTOS (ACOMPAÑANTE/STRIPPER)") == 0 || String.Compare(r["descripcion"].ToString(), "TRABAJADOR/A SEXUAL") == 0)
                    {
                        r["descripcion"] = "";
                    }
                }
        );

            ddown002.DataSource = dtproy;
            ddown002.DataTextField = "Descripcion";
            ddown002.DataValueField = "CodProfesion";
            ddown002.DataBind();
        }
        catch (Exception ex)
        { }

    }

    /// <summary>
    /// Carga lista de regiones.
    /// </summary>
    private void getregion()
    {

        parcoll pcoll = new parcoll();

        DataTable dtproy = pcoll.GetparRegion();
        ddown004.DataSource = dtproy;
        ddown004.DataTextField = "Descripcion";
        ddown004.DataValueField = "CodRegion";
        ddown004.DataBind();
    }

    /// <summary>
    /// Carga lista de direcciones region
    /// </summary>
    private void getdireccionregional()
    {

        parcoll pcoll = new parcoll();
        DataTable dtproy = pcoll.GetParDireccionRegional(Convert.ToInt32(ddown004.SelectedValue));
        ddown005.DataSource = dtproy;
        ddown005.DataTextField = "Descripcion";
        ddown005.DataValueField = "CodDireccionRegional";
        ddown005.DataBind();
    }

    /// <summary>
    /// Evento del control de lista de instituciones.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddown001_SelectedIndexChanged(object sender, EventArgs e)
    {
        //alerts.Visible = false;
        //lb_mensajes.Text = string.Empty;
        alertW.Visible = false;
        lblMsgWarning.Visible = false;
        alertS.Visible = false;
        lblMsgSuccess.Visible = false;

        if (ddown001.SelectedValue == "6050")
        {
            ddown004.AutoPostBack = true;
            ddown005.Visible = true;
            tr_direccionregional.Visible = true;
            lbl_direccionregional.Visible = true;
        }
        else
        {
            tr_direccionregional.Visible = false;
            lbl_direccionregional.Visible = false;
            ddown005.Visible = false;
            ddown004.AutoPostBack = false;

        }
        if (!C_FormatRut.TextIsEmpty)
            valida_rut();
    }

    /// <summary>
    /// Obtiene vigencia de usuario senainfo
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
    public string get_indvigencia(string username)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetIndiceVigencia";
        sqlc.Parameters.Add("@IdUsuario", SqlDbType.VarChar).Value = IdUsuarioSenainfo;

        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);

        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();

        int codigoTrabajador;
        int codtrab = 0;
        string VigenciaUsuario = "";
        DateTime FechaActualizacion = Convert.ToDateTime("01-01-1900");
        if (dt.Rows.Count >= 1)
        {
            codtrab = Convert.ToInt32(dt.Rows[0]["ICodTrabajador"]);
            codigoTrabajador = Convert.ToInt32(dt.Rows[0]["ICodTrabajador"]);
            FechaActualizacion = Convert.ToDateTime(dt.Rows[0]["FechaActualizacion"]);
            VigenciaUsuario = Convert.ToString(dt.Rows[0]["indvigencia"]);
        }

        Conexiones con = new Conexiones();
        DbDataReader datareader = null;

        List<DbParameter> listDbParameter = new List<DbParameter>();
        //listDbParameter.Add(Conexiones.CrearParametro("@username", SqlDbType.VarChar, 30, username.Trim()));
        //con.ejecutar(Resources.Procedures.GetVigencia_Usuario + "@username", listDbParameter, out datareader);

        //int codigoTrabajador;
        //int codtrab = 0;
        //string VigenciaUsuario = "";
        //DateTime FechaActualizacion = Convert.ToDateTime("01-01-1900");
        //while (datareader.Read())
        //{
        //    try
        //    {
        //        codtrab = (int)datareader["ICodTrabajador"];
        //        codigoTrabajador = (int)datareader["ICodTrabajador"];
        //        FechaActualizacion = (DateTime)datareader["FechaActualizacion"];
        //        VigenciaUsuario = (string)datareader["indvigencia"];
        //    }
        //    catch { }
        //}
        //datareader.Close();

        //listDbParameter.Clear();
        listDbParameter.Add(Conexiones.CrearParametro("@codtrab", SqlDbType.Int, 4, codtrab));
        con.ejecutar(Resources.Procedures.GetVigencia_CodTrab2 + "@codtrab", listDbParameter, out datareader);  //Trae IndVigencia, Nombres y Apellido Paterno

        string vigencia = "";
        while (datareader.Read())
        {
            try
            {
                vigencia = (string)datareader["indvigencia"];
            }
            catch { }
        }
        datareader.Close();

        con.Desconectar();

        if (vigencia == "V")//Usuario Vigente en LoginSenaInfo
        {
            if (VigenciaUsuario == "V") //Trabajador Vigente
            {
                if (!(System.DateTime.Now < FechaActualizacion.AddDays(45)))
                {
                    vigencia = "CC";//Vigente y Caducó Contraseña
                }
                else
                {
                    vigencia = "V";
                }
            }
            else if (VigenciaUsuario == "P")//Pendiente(CambioContraseña)
            {
                vigencia = "P";
            }
            else
            {
                vigencia = "C";
            }
        }
        else
        {
            vigencia = "C";
        }

        return vigencia;
    }


    private DataTable ConsultaUsuarioSeguridad(string usuario)
    {
        string sQuery = string.Format(@"
            Select EmailConfirmado, TokenMail, Email from Usuarios where Usuario = '{0}'"
            , usuario);
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionesSS"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = sQuery;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    /// <summary>
    /// Obtiene resultado de información del usuario, solicitudes pendientes, caducidad de contraseña.
    /// </summary>
    /// <param name="userName"></param>
    public void GetResultadoInfoUser(string userName)
    {
        bool emailConfirmado = false;
        string tokenMail = string.Empty;
        string correoConfirmacion = string.Empty;
        string prueba = string.Empty;
        try
        {
            DataTable dtUsuario = ConsultaUsuarioSeguridad(userName.Trim());
            string vigencia = get_indvigencia(userName.Trim());
            prueba = vigencia;

            if (dtUsuario.Rows.Count > 0)
            {
                DataRow rUsuario = dtUsuario.Rows[0];
                emailConfirmado = rUsuario["EmailConfirmado"].Equals(DBNull.Value) ? false : (bool)rUsuario["EmailConfirmado"];
                tokenMail = rUsuario["TokenMail"].Equals(DBNull.Value) ? string.Empty : (String)rUsuario["TokenMail"];
                correoConfirmacion = rUsuario["Email"].Equals(DBNull.Value) ? string.Empty : (string)rUsuario["Email"];
            }

            
            if (ValidarMail())
            {
                btnCancelarSolicitud.Visible = true;
                btnReenvio.Visible = true;
                btnPswChange.Visible = true;
            }

            tblInfoUser.Visible = true;

            if (!emailConfirmado && string.IsNullOrEmpty(tokenMail))//Usuario aun no actualiza cuenta a mail.
            {
                txtInfoUser.Text = "No tiene solicitudes pendientes.";
                btnCancelarSolicitud.Visible = false;
                btnReenvio.Visible = false;
                tblInfoUser.Visible = false;
            }
            else if (!emailConfirmado && !string.IsNullOrEmpty(tokenMail)) //Tiene Token, email sin confirmacion.
            {
                if (vigencia == "V")
                {
                    txtInfoUser.Text = "Tiene una solicitud pendiente para actualizar la cuenta. Se le envió un correo a la dirección " + correoConfirmacion;
                }
                else if (vigencia == "CC")//Pendiente y Caducó Contraseña
                {
                    txtInfoUser.Text = "La contraseña caducó. Tiene una solicitud pendiente para actualizar la cuenta. Se le envió un correo a la dirección " + correoConfirmacion;
                }
                else if (vigencia == "P") //Vigente y Caducó Contraseña
                {
                    txtInfoUser.Text = "Tiene una solicitud pendiente para cambio de contraseña. Se le envió un correo a la dirección " + correoConfirmacion;
                }
            }
            else if (emailConfirmado && string.IsNullOrEmpty(tokenMail))
            {
                if (vigencia == "V")
                {
                    txtInfoUser.Text = "No tiene solicitudes pendientes.";
                    btnCancelarSolicitud.Visible = false;
                    btnReenvio.Visible = false;
                    //tblInfoUser.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {

            alertW.Visible = true;
            lblMsgWarning.Text = string.Format("userNameee: {0}, MailConfirm: {1}, token: {2}, correo: {3}, vigencia: {4}, excepción; {5}, codTrabajador: {6}",
                userName, emailConfirmado, tokenMail, correoConfirmacion, prueba, ex.StackTrace, C_BuscaTrabajador.CodTrabajador.ToString());
            lblMsgWarning.Visible = true;
            return;
        }
    }


    /// <summary>
    /// Función que obtiene un trabajador por cod trabajador. 
    /// </summary>
    /// <param name="codTrabajador">Código de trabajador</param>
    public string Get_Resultado_Busqueda(int codTrabajador)
    {
        string sParametrosConsulta = "Select T1.ICodTrabajador,T1.CodInstitucion,T1.CodTrabajador,T1.CodProfesion,T1.Paterno,T1.Materno, " +
                              "T1.Nombres,T1.RutTrabajador,T1.Telefono,T1.Mail,T1.Fax,T1.CodigoPostal,T1.IndVigencia,T1.FechaActualizacion,T3.Usuario,T3.CodRegion,T3.CodDireccionRegional,T3.Contrasena, " +
                              "T1.IdUsuarioActualizacion,T3.IdUsuario From Trabajadores T1 inner join instituciones T2 ON T1.CodInstitucion = T2.CodInstitucion inner join usuarios T3 ON T3.ICodTrabajador = T1.ICodTrabajador " +
                              "Where T1.ICodTrabajador =" + codTrabajador;

        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */
        Conexiones con = new Conexiones();
        con.ejecutar(sParametrosConsulta, out datareader);
        while (datareader.Read())
        {

            try
            {
                if (!ExisteUsuarioSenainfo(datareader.GetInt32(datareader.GetOrdinal("IdUsuario"))))
                {
                    IdUsuarioSenainfo = 0;
                    return string.Format("Esta cuenta presenta problemas(Error 301). Comuníquese con mesa de ayuda con los siguientes datos: Institucion: {0}, Rut: {1}, Nombre {2}, Mail: {3}.",
                        Convert.ToString((int)datareader["CodInstitucion"]), ((String)datareader["RutTrabajador"]).Trim(), (String)datareader["Nombres"] + " " + (String)datareader["Paterno"],
                        (String)datareader["Mail"]);
                }

                if (UsuarioRepetido((String)datareader["Usuario"]))
                {
                    IdUsuarioSenainfo = 0;
                    return string.Format("Esta cuenta presenta problemas.Error 301. Comuníquese con mesa de ayuda con los siguientes datos: Institucion: {0}, Rut: {1}, Nombre {2}, Mail: {3}.",
                        Convert.ToString((int)datareader["CodInstitucion"]), ((String)datareader["RutTrabajador"]).Trim(), (String)datareader["Nombres"] + " " + (String)datareader["Paterno"],
                        (String)datareader["Mail"]);
                }
                IdUsuarioSenainfo = datareader.GetInt32(datareader.GetOrdinal("IdUsuario"));
                ddown001.Enabled = false;
                imb002.Visible = false;
                WebImageButton3.Visible = true;
                btnPswChange.Visible = true;
                btnReenvio.Visible = true; //TODO: Acá se debe verificar si relamente debe ser visible 
                btnCancelarSolicitud.Visible = true;
                
                validatescurity();

                ddown001.SelectedValue = Convert.ToString((int)datareader["CodInstitucion"]);
                C_FormatRut.Texto = ((String)datareader["RutTrabajador"]).Trim().ToUpper();
                C_FormatRut.SetTexto();
                //run_tecnico.Text = (String)datareader["RutTrabajador"];
                txt002.Text = (String)datareader["Paterno"];
                txt003.Text = (String)datareader["Materno"];
                txt004.Text = (String)datareader["Nombres"];
                txt005.Text = (String)datareader["Telefono"];
                txt006.Text = (String)datareader["Mail"];
                txt007.Text = (String)datareader["Fax"];
                txt008.Text = Convert.ToString((int)datareader["CodigoPostal"]);
                ddown002.SelectedValue = (ddown002.Items.FindByValue(Convert.ToString((int)datareader["CodProfesion"])) != null ? Convert.ToString((int)datareader["CodProfesion"]) : "0");
                ddown003.SelectedValue = (String)datareader["IndVigencia"];
                txt_usuario.Text = (String)datareader["Usuario"];
                InitialUser = txt_usuario.Text.Trim();

                tblInfoUser.Visible = true;
                btnPswChange.Visible = true;

                if (ddown003.SelectedValue == "C" || !ValidarMail())
                {
                    tblInfoUser.Visible = false;
                    btnPswChange.Visible = false;
                }

                try
                {
                    ddown_rol.Items.FindByValue((String)datareader["Contrasena"]).Selected = true; ;
                }
                catch { }
                try
                {
                    ddown004.SelectedValue = Convert.ToString((int)datareader["CodRegion"]);
                }
                catch { }
             
                if (ddown001.SelectedValue == "6050")
                {
                    ddown005.Visible = true;
                    tr_direccionregional.Visible = true;
                    lbl_direccionregional.Visible = true;
                    getdireccionregional();
                    if (Convert.ToString((int)datareader["CodDireccionRegional"]) != "0")
                    {
                        ddown004.AutoPostBack = true;                        
                        ddown005.SelectedValue = Convert.ToString((int)datareader["CodDireccionRegional"]);
                    }
                }
                else
                {
                    ddown005.Visible = false;
                    tr_direccionregional.Visible = false;
                    lbl_direccionregional.Visible = false;
                }


            }
            catch { }
        }

        parcoll par = new parcoll();
        DataTable dt = par.ejecuta_SQL("select usuario,idusuario,contrasena from usuarios where usuario = '" + txt_usuario.Text.Trim() + "'");
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0][2].ToString() == "263" && dt.Rows[0][1].ToString() == Session["IdUsuario"].ToString())
            {
                ddown_rol.Enabled = false;

            }
        }
        datareader.Close();
        con.Desconectar();
        return string.Empty;
    }

    /// <summary>
    /// Verifica si hay usuarios repetidos en Senainfo y Seguridad.
    /// </summary>
    /// <param name="codInstitucion"></param>
    /// <param name="rutTrabajador"></param>
    /// <param name="usuario"></param>
    /// <returns></returns>
    private bool UsuarioRepetido(string usuario)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetUsuariosRepetidosSenainfo";
        sqlc.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = usuario;

        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);

        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();

        if (dt.Rows.Count > 1)
            return true;
        else
        {
            SqlConnection sconn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionesSS"].ToString());
            System.Data.SqlClient.SqlCommand sqlc1 = new System.Data.SqlClient.SqlCommand();
            sqlc1.Connection = sconn1;
            sqlc1.CommandType = System.Data.CommandType.StoredProcedure;
            sqlc1.CommandText = "GetUsuariosRepetidosLogin";
            sqlc1.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = usuario;
            System.Data.SqlClient.SqlDataAdapter da1 = new System.Data.SqlClient.SqlDataAdapter(sqlc1);

            DataTable dt1 = new DataTable();
            sconn1.Open();
            da1.Fill(dt1);
            sconn1.Close();
            if (dt1.Rows.Count > 1)
                return true;
        }
        return false;
    }

    private bool ExisteUsuarioSenainfo(int IdUsuarioSenainfo)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionesSS"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "LSI_ExisteIdUsuarioSenainfo";
        sqlc.Parameters.Add("@IdUsuarioSenainfo", SqlDbType.VarChar).Value = IdUsuarioSenainfo;

        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);

        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        if (Convert.ToInt32(dt.Rows[0][0]) >= 1)
            return true;

        return false;
    }

    /// <summary>
    /// Función valida campos obligatorios.
    /// </summary>
    /// <returns></returns>
    private bool validaCampos()
    {
        Color colorCampoObligatorio = ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis
        bool validacion = true;

        if (txt002.Text == "") { txt002.BackColor = colorCampoObligatorio; validacion = false; } else { txt002.BackColor = System.Drawing.Color.White; }
        if (C_FormatRut.TextIsEmpty) { C_FormatRut.BackColor(colorCampoObligatorio); validacion = false; } else { C_FormatRut.BackColor(System.Drawing.Color.White); }
        if (txt003.Text == "") { txt003.BackColor = colorCampoObligatorio; validacion = false; } else { txt003.BackColor = System.Drawing.Color.White; }
        if (txt004.Text == "") { txt004.BackColor = colorCampoObligatorio; validacion = false; } else { txt004.BackColor = System.Drawing.Color.White; }
        if (ddown002.SelectedValue == "0") { ddown002.BackColor = colorCampoObligatorio; validacion = false; } else { ddown002.BackColor = System.Drawing.Color.White; }
        if (ddown001.SelectedValue == "0") { ddown001.BackColor = colorCampoObligatorio; validacion = false; } else { ddown001.BackColor = System.Drawing.Color.White; }
        if (ddown004.SelectedValue == "-2") { ddown004.BackColor = colorCampoObligatorio; validacion = false; } else { ddown004.BackColor = System.Drawing.Color.White; }
        if (txt_usuario.Text.Trim() == "") { txt_usuario.BackColor = colorCampoObligatorio; validacion = false; } else { txt_usuario.BackColor = System.Drawing.Color.White; }
        if (txt006.Text == "") { txt006.BackColor = colorCampoObligatorio; validacion = false; } else { txt006.BackColor = System.Drawing.Color.White; }

        if (ddown001.SelectedValue == "6050")
        {
            if (ddown005.SelectedValue == "0") { ddown005.BackColor = colorCampoObligatorio; validacion = false; } else { ddown005.BackColor = System.Drawing.Color.White; }
        }

        #region ValidacionAntigua
        //if (ddown001.SelectedValue == "6050")
        //{
        //    //if (txt002.Text == "" || txt004.Text == "" || txt003.Text == "" || ddown001.SelectedValue == "0" 
        //    //    || ddown002.SelectedValue == "0" || ddown004.SelectedValue == "-2" || txt_usuario.Text.Trim() == "" || ddown005.SelectedValue == "0"
        //    //    || C_FormatRut.TextIsEmpty) //|| txt_usuario.BackColor == colorCampoObligatorio  run_tecnico.Text.Trim() == "" ||
        //    //{
        //    if (txt002.Text == "") { txt002.BackColor = colorCampoObligatorio; } else { txt002.BackColor = System.Drawing.Color.White; }
        //    if (C_FormatRut.TextIsEmpty) { C_FormatRut.BackColor(colorCampoObligatorio); } else { C_FormatRut.BackColor(System.Drawing.Color.White); }
        //    if (txt003.Text == "") { txt003.BackColor = colorCampoObligatorio; } else { txt003.BackColor = System.Drawing.Color.White; }
        //    if (txt004.Text == "") { txt004.BackColor = colorCampoObligatorio; } else { txt004.BackColor = System.Drawing.Color.White; }
        //    if (ddown002.SelectedValue == "0") { ddown002.BackColor = colorCampoObligatorio; } else { ddown002.BackColor = System.Drawing.Color.White; }
        //    if (ddown001.SelectedValue == "0") { ddown001.BackColor = colorCampoObligatorio; } else { ddown001.BackColor = System.Drawing.Color.White; }
        //    if (ddown004.SelectedValue == "-2") { ddown004.BackColor = colorCampoObligatorio; } else { ddown004.BackColor = System.Drawing.Color.White; }
        //    if (txt_usuario.Text.Trim() == "") { txt_usuario.BackColor = colorCampoObligatorio; } else { txt_usuario.BackColor = System.Drawing.Color.White; }
        //    if (ddown005.SelectedValue == "0") { ddown005.BackColor = colorCampoObligatorio; } else { ddown005.BackColor = System.Drawing.Color.White; }
        //    if (txt006.Text == "") { txt006.BackColor = colorCampoObligatorio; } else { txt006.BackColor = System.Drawing.Color.White; }
        //    alertW.Visible = true;
        //    lblMsgWarning.Text = "Faltan campos obligatorios por completar.";
        //    lblMsgWarning.Visible = true;

        //    validacion = false;
        //    //}
        //    //else
        //    //{
        //    //    validacion = true;
        //    //}
        //}
        //else
        //{
        //    if (txt002.Text == "" || txt004.Text == "" || txt003.Text == "" || ddown001.SelectedValue == "0"
        //        || ddown002.SelectedValue == "0" || ddown004.SelectedValue == "-2" || txt_usuario.Text.Trim() == ""
        //        || C_FormatRut.TextIsEmpty) //|| txt_usuario.BackColor == colorCampoObligatorio  || run_tecnico.Text.Trim() == "" 
        //    {
        //        if (txt002.Text == "") { txt002.BackColor = colorCampoObligatorio; } else { txt002.BackColor = System.Drawing.Color.White; }
        //        if (C_FormatRut.TextIsEmpty) { C_FormatRut.BackColor(colorCampoObligatorio); } else { C_FormatRut.BackColor(System.Drawing.Color.White); }
        //        if (txt003.Text == "") { txt003.BackColor = colorCampoObligatorio; } else { txt003.BackColor = System.Drawing.Color.White; }
        //        if (txt004.Text == "") { txt004.BackColor = colorCampoObligatorio; } else { txt004.BackColor = System.Drawing.Color.White; }
        //        if (ddown002.SelectedValue == "0") { ddown002.BackColor = colorCampoObligatorio; } else { ddown002.BackColor = System.Drawing.Color.White; }
        //        if (ddown001.SelectedValue == "0") { ddown001.BackColor = colorCampoObligatorio; } else { ddown001.BackColor = System.Drawing.Color.White; }
        //        if (ddown004.SelectedValue == "-2") { ddown004.BackColor = colorCampoObligatorio; } else { ddown004.BackColor = System.Drawing.Color.White; }
        //        if (txt_usuario.Text.Trim() == "") { txt_usuario.BackColor = colorCampoObligatorio; } else { txt_usuario.BackColor = System.Drawing.Color.White; }
        //        if (txt006.Text == "") { txt006.BackColor = colorCampoObligatorio; } else { txt006.BackColor = System.Drawing.Color.White; }
        //        alertW.Visible = true;
        //        lblMsgWarning.Text = "Faltan campos obligatorios por completar.";
        //        lblMsgWarning.Visible = true;

        //        validacion = false;
        //    }
        //    else
        //    {
        //        validacion = true;
        //    }
        //}
        #endregion

        if (!validacion)
        {
            alertW.Visible = true;
            lblMsgWarning.Text = "Faltan campos obligatorios por completar.";
            lblMsgWarning.Visible = true;
        }
        
        return validacion;
    }

    /// <summary>
    /// Valida si campo nombre de usuario es un correo válido en formato.
    /// </summary>
    /// <returns></returns>
    private bool ValidarMail()
    {
        if (ddown003.SelectedValue != "C")
        {
            string toMail = txt_usuario.Text.Trim();
            RegexUtilities regex = new RegexUtilities();

            if (regex.IsValidEmail(toMail))
                return true;
            else
            {
                txt_usuario.BackColor = System.Drawing.ColorTranslator.FromHtml("#F2F5A9");
                alertW.Visible = true;
                var mensaje = "El correo electrónico, de su identificador de usuario, no tiene un formato válido. Favor ingrese un mail válido.";
                lblMsgWarning.Text = mensaje;
                lblMsgWarning.Visible = true;
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Función de envio de correo para autoservicio de solicitudes de cambio de contraseña o cambio de correo de la cuenta.
    /// Actualiza tokenMail de usuario desde Mesa.
    /// </summary>
    /// <param name="tokenMesa"></param>
    /// <param name="isNew"></param>
    /// <returns></returns>
    private bool EnviarMail(string tokenMesa, bool isNew, bool isPaswordChange)
    {
        try
        {
            SeguridadSENAINFO.SeguridadSENAINFOSoapClient wsSeguridad = new SeguridadSENAINFO.SeguridadSENAINFOSoapClient();
            string toMail = txt_usuario.Text.Trim();
            if (isPaswordChange)
            {
                SeguridadSENAINFO.Usuario usuario = wsSeguridad.ObtenerUsuarioByIdSenainfo(IdUsuarioSenainfo);
                toMail = usuario.NombreUsuario;
                txt_usuario.Text = toMail;
            }
            //1.Actualiza Token de Usuario.
            if (isNew)
                InitialUser = txt_usuario.Text.Trim();

            if (!isNew && InitialUser.Trim() == txt_usuario.Text.Trim())
                return true;
            string token = wsSeguridad.ActualizarMailUsuarioDesdeMesa(
            Session["UserName"].ToString(),
            tokenMesa,
            IdUsuarioSenainfo,
            toMail.Trim());

            //2.Envio de Correo con token de usuario.
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("../TemplateMailNvaCta.html")))
            {
                body = reader.ReadToEnd();
            }

            string baseURL = ConfigurationManager.AppSettings["URLBase"];
            String mailstring = "<a href=" + baseURL + ConfigurationManager.AppSettings["UrlValidaCorreo"] + "?tid=" + token + ">Aquí</a>";
            body = body.Replace("{%aqui%}", mailstring);
            bool resultadoEnvio = false;

            if (!string.IsNullOrEmpty(token))
            {
                SendMail wsMail = new SendMail();
                resultadoEnvio = wsMail.Enviar("Senainfo", toMail, string.Empty, string.Empty, ConfigurationManager.AppSettings["SubjectMail"], body);
            }

            if (resultadoEnvio)
            {
                return true;
            }
        }
        catch (Exception) { }
        return false;
    }

    private bool ReenviarMail()
    {
        try
        {
            /*1.Obtiene TokenMail*/
            SeguridadSENAINFO.SeguridadSENAINFOSoapClient wsSeguridad = new SeguridadSENAINFO.SeguridadSENAINFOSoapClient();
            SeguridadSENAINFO.Usuario usuario = wsSeguridad.ObtenerUsuarioByIdSenainfo(IdUsuarioSenainfo);

            /*2.Obtiene */
            //string correoConfirmacion = string.Empty;
            //DataTable dtUsuario = ConsultaUsuarioSeguridad(txt_usuario.Text);
            //if (dtUsuario.Rows.Count>0)
            //{
            //    DataRow rUsuario = dtUsuario.Rows[0];
            //    correoConfirmacion = rUsuario["Email"].Equals(DBNull.Value) ? string.Empty : (String)rUsuario["Email"];
            //    tokenMail = rUsuario["TokenMail"].Equals(DBNull.Value) ? string.Empty : (String)rUsuario["TokenMail"];
            //    correoConfirmacion = rUsuario["Email"].Equals(DBNull.Value) ? string.Empty : (string)rUsuario["Email"];

            //} 

            //2.Envio de Correo con token de usuario.
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("../TemplateMailNvaCta.html")))
            {
                body = reader.ReadToEnd();
            }

            string baseURL = ConfigurationManager.AppSettings["URLBase"];
            String mailstring = "<a href=" + baseURL + ConfigurationManager.AppSettings["UrlValidaCorreo"] + "?tid=" + usuario.TokenMail + ">Aquí</a>";
            body = body.Replace("{%aqui%}", mailstring);

            SendMail wsMail = new SendMail();
            return wsMail.Enviar("Senainfo", usuario.Email, string.Empty, string.Empty, ConfigurationManager.AppSettings["SubjectMail"], body);
        }
        catch (Exception) { }
        return false;
    }


    /// <summary>
    /// Funcion de ingreso o actualizacion de trabajador, Usuario, Usuario LSI.
    /// Valida Campos Obligatorios
    /// Ingreso y Envio de Correo para autoservicio.
    /// Al finalizar limpia el formulario.
    /// </summary>
    /// <param name="isNew"></param>
    private void funcion_guardar(bool isNew)
    {
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        if (validaCampos())
        {
            alertW.Visible = false;
            lblMsgWarning.Visible = false;
            txt002.BackColor = System.Drawing.Color.White;
            C_FormatRut.BackColor(System.Drawing.Color.White);
            txt003.BackColor = System.Drawing.Color.White;
            txt004.BackColor = System.Drawing.Color.White;
            ddown002.BackColor = System.Drawing.Color.White;
            ddown001.BackColor = System.Drawing.Color.White;
            ddown004.BackColor = System.Drawing.Color.White;
            ddown005.BackColor = System.Drawing.Color.White;
            txt_usuario.BackColor = System.Drawing.Color.White;
            int ICodTrabajador = -1;
            try
            {
                ICodTrabajador = vCodPaso;
            }
            catch { }

            if (ICodTrabajador == -1)
            {
                if (ddown_rol.SelectedValue == "0")
                {
                    if (ddown_rol.SelectedValue == "0") { ddown_rol.BackColor = colorCampoObligatorio; } else { ddown_rol.BackColor = System.Drawing.Color.White; }
                    alertW.Visible = true;
                    lblMsgWarning.Text = "Faltan campos obligatorios por completar.";
                    lblMsgWarning.Visible = true;
                }
                else
                {
                    ddown_rol.BackColor = System.Drawing.Color.White;

                    inserta(isNew);

                    if (ddown003.SelectedValue != "C" && !EnviarMail(GetTokenUser(), isNew, false))
                    {
                        alertW.Visible = true;
                        lblMsgWarning.Text = "Ocurrió un error al tratar de enviar el mail de verificación.";
                        lblMsgWarning.Visible = true;
                    }
                    else if (ddown003.SelectedValue != "C")
                    {
                        lblMsgSuccess.Text += "Deberá crear su contraseña mediante el correo enviado a su cuenta. Mail: " + txt_usuario.Text.Trim();
                    }
                    limpiarCampos();
                }
            }
            else
            {
                inserta(isNew);
                if (ddown003.SelectedValue != "C" && !EnviarMail(GetTokenUser(), isNew, false) && InitialUser.Trim() != txt_usuario.Text.Trim())
                {
                    alertW.Visible = true;
                    lblMsgWarning.Text = "Ocurrió un error al tratar de enviar el mail de verificación.";
                    lblMsgWarning.Visible = true;
                }
                else if (ddown003.SelectedValue != "C" && InitialUser.Trim() != txt_usuario.Text.Trim())
                {
                    lblMsgSuccess.Text += "Deberá crear su contraseña mediante el correo enviado a su cuenta. Mail: " + txt_usuario.Text.Trim();
                }
                limpiarCampos();
            }
        }

        #region antigua validacion
        //if (txt002.Text == "" || run_tecnico.Text.Trim() == "" || txt004.Text == "" || txt003.Text == "" || ddown001.SelectedValue == "0" || ddown002.SelectedValue == "0" || ddown004.SelectedValue == "-2" || txt_usuario.Text.Trim() == "") //|| txt_usuario.BackColor == colorCampoObligatorio
        //{
        //    if (txt002.Text == "") { txt002.BackColor = colorCampoObligatorio; } else { txt002.BackColor = System.Drawing.Color.White; }
        //    if (run_tecnico.Text.Trim() == "") { run_tecnico.BackColor = colorCampoObligatorio; } else { run_tecnico.BackColor = System.Drawing.Color.White; }
        //    if (txt003.Text == "") { txt003.BackColor = colorCampoObligatorio; } else { txt003.BackColor = System.Drawing.Color.White; }
        //    if (txt004.Text == "") { txt004.BackColor = colorCampoObligatorio; } else { txt004.BackColor = System.Drawing.Color.White; }
        //    if (ddown002.SelectedValue == "0") { ddown002.BackColor = colorCampoObligatorio; } else { ddown002.BackColor = System.Drawing.Color.White; }
        //    if (ddown001.SelectedValue == "0") { ddown001.BackColor = colorCampoObligatorio; } else { ddown001.BackColor = System.Drawing.Color.White; }
        //    if (ddown004.SelectedValue == "-2") { ddown004.BackColor = colorCampoObligatorio; } else { ddown004.BackColor = System.Drawing.Color.White; }
        //    //if (ddown005.SelectedValue == "0") { ddown005.BackColor = colorCampoObligatorio; } else { ddown005.BackColor = System.Drawing.Color.White; }
        //    if (txt_usuario.Text == "") { txt_usuario.BackColor = colorCampoObligatorio; } else { txt_usuario.BackColor = System.Drawing.Color.White; }
        //    alertW.Visible = true;
        //    lblMsgWarning.Text = "Faltan campos obligatorios por completar.";
        //    lblMsgWarning.Visible = true;
        //}
        //else
        //{
        //    alertW.Visible = false;
        //    lblMsgWarning.Visible = false;
        //    txt002.BackColor = System.Drawing.Color.White; 
        //    run_tecnico.BackColor = System.Drawing.Color.White; 
        //    txt003.BackColor = System.Drawing.Color.White; 
        //    txt004.BackColor = System.Drawing.Color.White; 
        //    ddown002.BackColor = System.Drawing.Color.White;
        //    ddown001.BackColor = System.Drawing.Color.White;
        //    ddown004.BackColor = System.Drawing.Color.White;
        //    //if (ddown005.SelectedValue == "0") { ddown005.BackColor = colorCampoObligatorio; } else { ddown005.BackColor = System.Drawing.Color.White; }
        //    txt_usuario.BackColor = System.Drawing.Color.White; 
        //    int ICodTrabajador = -1;
        //    try
        //    {
        //        ICodTrabajador = vCodPaso;
        //    }
        //    catch { }

        //    if (ICodTrabajador == -1)
        //    {
        //        if (txt_contrass.Text == "" || txt_contrass2.Text == "" || ddown_rol.SelectedValue == "0")
        //        {
        //            if (txt_contrass.Text == "") { txt_contrass.BackColor = colorCampoObligatorio; } else { txt_contrass.BackColor = System.Drawing.Color.White; }
        //            if (txt_contrass2.Text == "") { txt_contrass2.BackColor = colorCampoObligatorio; } else { txt_contrass2.BackColor = System.Drawing.Color.White; }
        //            if (ddown_rol.SelectedValue == "0") { ddown_rol.BackColor = colorCampoObligatorio; } else { ddown_rol.BackColor = System.Drawing.Color.White; }
        //            alertW.Visible = true;
        //            lblMsgWarning.Text = "Faltan campos obligatorios por completar.";
        //            lblMsgWarning.Visible = true;
        //        }
        //        else
        //        {
        //            txt_contrass.BackColor = System.Drawing.Color.White; 
        //            txt_contrass2.BackColor = System.Drawing.Color.White;
        //            ddown_rol.BackColor = System.Drawing.Color.White; 

        //            inserta();
        //            //funcion_limpiar();
        //            limpiarCampos();
        //        }
        //    }
        //    else
        //    {
        //        inserta();
        //        //funcion_limpiar();
        //        limpiarCampos();
        //    }
        //}
        #endregion
    }

    /// <summary>
    /// Obtiene campos del formulario para su validación
    /// Ingresa o Actualiza trabajador.
    /// Ingresa o Actualiza Usuario
    /// Ingreso de Usuario LSI.
    /// </summary>
    private void inserta(bool isNew)
    {
        parcoll par = new parcoll();

        int CodInstitucion = Convert.ToInt32(ddown001.SelectedValue);
        //string RutTrabajador = txt001.Text;
        string RutTrabajador = C_FormatRut.TextRutConGuion.ToUpper(); //run_tecnico.Text.Replace(".", "").ToString();

        string Paterno = txt002.Text.ToUpper();
        string Materno = "";
        if (txt003.Text != "")
        {
            Materno = txt003.Text.ToUpper();
        }
        string Nombres = txt004.Text.ToUpper();
        string Telefono = "0";
        if (txt005.Text != "")
        {
            Telefono = txt005.Text;
        }

        string Mail = "";
        if (txt006.Text != "")
        {
            Mail = txt006.Text.ToUpper();
        }

        string Fax = "";
        if (txt007.Text != "")
        {
            Fax = txt007.Text;
        }


        int CodigoPostal = 0;
        if (txt008.Text.Trim() != "")
        {
            CodigoPostal = Convert.ToInt32(txt008.Text);
        }

        int CodProfesion = Convert.ToInt32(ddown002.SelectedValue);

        int ICodTrabajador = -1;
        try
        {
            ICodTrabajador = vCodPaso;
        }
        catch { }

        // ---------------------------------------------------------------------------------------- DPL 19-12-2014
        //neows.neoportalservices ns = new neows.neoportalservices();
        ///////// INSERT O UPDATE DE TRABAJADOR///////////

        insert_instproy insup = new insert_instproy();
        int retorno = insup.Insert_Update_Trabajadores(ICodTrabajador, CodInstitucion, -1, CodProfesion,
            Paterno, Materno, Nombres, RutTrabajador, Telefono, Mail, Fax, CodigoPostal, ddown003.SelectedValue, Convert.ToInt32(Session["IdUsuario"])/*USR*/);

        //////////////////////////////////////////////////////////////////////
        // ----------------------------- DPL 19-12-2014 ---------------------
        //////SeguridadSENAINFO.Service1 ls = new SeguridadSENAINFO.Service1();

        SeguridadSENAINFO.SeguridadSENAINFOSoapClient ls = new SeguridadSENAINFO.SeguridadSENAINFOSoapClient();

        int CodDirRegional = 0;
        if (ddown005.Visible)
        {
            CodDirRegional = Convert.ToInt32(ddown005.SelectedValue);
        }

        ///// INSERT DE USUARIO 0 UPDATE//////
        if (ICodTrabajador == -1 && retorno != -1)
        {
            DataTable dtUsuario = insert_usuarios(retorno, Convert.ToInt32(ddown004.SelectedValue), txt_usuario.Text.Trim(), ddown_rol.SelectedValue, CodDirRegional, "P");
            string v = string.Empty;

            int userID = int.Parse(dtUsuario.Rows[0]["identidad"].ToString());
            IdUsuarioSenainfo = userID;

            if (userID > 0)
            {
                Mail = txt_usuario.Text.Trim(); //al crear usuario debe replicar el ID de usuario en el Mail 
                v = ls.CrearUsuario(txt_usuario.Text.Trim(), string.Empty, Nombres, Paterno, Mail, userID);
            }

            if (!string.IsNullOrEmpty(v))
            {
                //window.alert(Page, "USUARIO CREADO CORRECTAMENTE");
                alertS.Visible = true;
                lblMsgSuccess.Text = "Usuario creado exitosamente. ";
                lblMsgSuccess.Visible = true;
            }
            else
            {
                alertW.Visible = true;
                lblMsgWarning.Text = "Error al crear usuario. ";
                lblMsgWarning.Visible = true;
            }
        }
        else if (ICodTrabajador != -1)//UPDATE
        {
            update_usuarios(ICodTrabajador, Convert.ToInt32(ddown004.SelectedValue), ddown_rol.SelectedValue, CodDirRegional, ddown003.SelectedValue);
            alertS.Visible = true;
            lblMsgSuccess.Visible = true;

            lblMsgSuccess.Text = "Registro Modificado Satifactoriamente. ";

        }
        ////////////////////////////

        ///////// AGREGAR ROL ////////

        //        ns.UpdateUseronRol(txt_usuario.Text, Convert.ToInt32(ddown_rol.SelectedValue));
        if (retorno != -1)
            ls.ActualizarUsuarioEnRol(txt_usuario.Text.Trim(), Convert.ToInt32(ddown_rol.SelectedValue));

        /////////////////////////////

        if (ddown003.SelectedValue == "C")
        {
            trabajadorescoll tcol = new trabajadorescoll();
            tcol.update_trabajadoresproyecto_vigencia(retorno, ddown003.SelectedValue);
            ls.EliminaTokenMail(IdUsuarioSenainfo.ToString());
        }
    }

    /// <summary>
    /// Limpa los controles del formulario.
    /// </summary>
    private void limpiarCampos()
    {
        try
        {

            //Response.Redirect("~/mod_instituciones/reg_trabajadores.aspx");
            vCodPaso = -1;
            ddown001.Enabled = true;
            ddown001.SelectedIndex = 0;
            ddown001.BackColor = System.Drawing.Color.White;
            ddown004.Enabled = true;
            ddown004.SelectedIndex = 0;
            ddown004.BackColor = System.Drawing.Color.White;
            tr_direccionregional.Visible = false;
            ddown005.Enabled = true;
            ddown005.SelectedIndex = 0;
            ddown005.BackColor = System.Drawing.Color.White;
            C_FormatRut.Clear();
            C_FormatRut.BackColor(System.Drawing.Color.White);
            pnl003.Visible = false;
            grd001.Visible = false;
            lblProyectosTrabajador.Visible = false;
            txt002.Text = string.Empty;
            txt002.BackColor = System.Drawing.Color.White;
            txt003.Text = string.Empty;
            txt003.BackColor = System.Drawing.Color.White;
            txt004.Text = string.Empty;
            txt004.BackColor = System.Drawing.Color.White;
            txt005.Text = string.Empty;
            txt005.BackColor = System.Drawing.Color.White;
            txt006.Text = string.Empty;
            txt006.BackColor = System.Drawing.Color.White;
            txt007.Text = string.Empty;
            txt007.BackColor = System.Drawing.Color.White;
            txt008.Text = string.Empty;
            txt008.BackColor = System.Drawing.Color.White;
            ddown002.SelectedIndex = 0;
            ddown002.BackColor = System.Drawing.Color.White;
            ddown003.SelectedIndex = 0;
            ddown003.BackColor = System.Drawing.Color.White;

            txt_usuario.Text = string.Empty;
            txt_usuario.BackColor = System.Drawing.Color.White;
            lbl_usrexiste.Text = string.Empty;
            lbl_usrexiste.Visible = false;
            ddown_rol.SelectedIndex = 0;
            ddown_rol.BackColor = System.Drawing.Color.White;
            imb002.Visible = true;
            lbl004.Text = string.Empty;
            btnPswChange.Visible = false;
            WebImageButton3.Visible = false;

            txtInfoUser.Text = string.Empty;
            btnCancelarSolicitud.Visible = false;
            btnReenvio.Visible = false;
            
            tblInfoUser.Visible = false;
        }
        catch (Exception ex)
        {
            return;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void funcion_limpiar()
    {
        for (int j = 0; j < this.Controls.Count; j++)
        {
            for (int i = 0; i < this.Controls[j].Controls.Count; i++)
            {
                try
                {
                    ((TextBox)this.Controls[j].Controls[i]).Text = "";
                }
                catch { }
                try
                {
                    ((TextBox)this.Controls[j].Controls[i]).Text = "";
                }
                catch { }
            }
        }
        vCodPaso = -1;
        IdUsuarioSenainfo = 0;
        ddown001.Enabled = true;
        imb002.Visible = true;
        lbl004.Text = "";
        grd001.Visible = false;
        pnl003.Visible = false;
        ddown002.SelectedIndex = 0;

        btnPswChange.Visible = false;
        WebImageButton3.Visible = false;
        btnCancelarSolicitud.Visible = false;
        btnReenvio.Visible = false;
        txt_usuario.Text = string.Empty;
        ddown_rol.SelectedIndex = 0;
        //txt_contrass.Text = string.Empty;
        //txt_contrass2.Text = string.Empty;
        txt002.BackColor = System.Drawing.Color.White;
        C_FormatRut.BackColor(System.Drawing.Color.White);
        txt004.BackColor = System.Drawing.Color.White;
        txt006.BackColor = System.Drawing.Color.White;
        ddown002.BackColor = System.Drawing.Color.White;
        ddown002.SelectedValue = "0";
        ddown001.BackColor = System.Drawing.Color.White;
        ddown001.SelectedValue = "0";
        ddown004.BackColor = System.Drawing.Color.White;
        ddown001.SelectedValue = "-1";
        ddown005.BackColor = System.Drawing.Color.White;
        //txt_contrass.BackColor = System.Drawing.Color.White;
        //txt_contrass2.BackColor = System.Drawing.Color.White;
        txt003.BackColor = System.Drawing.Color.White;
        txt_usuario.BackColor = System.Drawing.Color.White;

        validatescurity();
    }

    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        InitializeComponent();
        base.OnInit(e);
    }

    private void InitializeComponent()
    {
        this.Load += new System.EventHandler(this.Page_Load);
        C_FormatRut.OnTextRutChanged += new EventHandler(Rut_TextChanged);
    }
    #endregion

    protected void Rut_TextChanged(object sender, EventArgs e)
    {
        alertW.Visible = false;

        lblMsgWarning.Visible = false;
        valida_rut();
    }


    private void valida_rut()
    {

        try
        {
            if (C_FormatRut.TextRutSinFormato.Length > 3)
            {

                this.Form.FindControl("pnl003").Visible = false;
                trabajadorescoll tcoll = new trabajadorescoll();
                DataTable dt = tcoll.GetRutTrab(C_FormatRut.TextRutConGuion, Convert.ToInt32(ddown001.SelectedValue));

                if (dt.Rows.Count > 0)
                {
                    this.Form.FindControl("pnl003").Visible = true;
                    alertW.Visible = true;
                    lblMsgWarning.Visible = true;
                    lblMsgWarning.Text = "Error, el RUN ingresado ya existe en la Institución Seleccionada. Corresponde a : " + Convert.ToString(dt.Rows[0][0]) + " " + Convert.ToString(dt.Rows[0][1]) + " " + Convert.ToString(dt.Rows[0][2]);


                    imb002.Visible = false;
                    grd001.Visible = false;
                }
                else
                {
                    this.Form.FindControl("pnl003").Visible = false;
                    imb002.Visible = true;
                    dt = tcoll.GetTrabInstitucionV(C_FormatRut.TextRutConGuion);
                    if (dt.Rows.Count > 0)
                    {
                        grd001.DataSource = dt;
                        grd001.DataBind();
                        grd001.Visible = true;
                        lblProyectosTrabajador.Visible = true;

                    }
                    else
                    {
                        grd001.Visible = false;
                        lblProyectosTrabajador.Visible = false;
                    }
                }

                //if (((Label)Form.FindControl("lbl004")).Text != "")
                //{
                //    this.Form.FindControl("pnl003").Visible = true;
                //}
                //else
                //{
                //    this.Form.FindControl("pnl003").Visible = false;
                //}

            }
            else
            {
                ((Label)Form.FindControl("lbl004")).Text = "El RUN Ingresado no es valido";
                this.Form.FindControl("pnl004").Visible = true;
                grd001.Visible = false;
            }
        }
        catch
        {
            ((Label)Form.FindControl("lbl004")).Text = "El RUN Ingresado no es valido";
            this.Form.FindControl("pnl003").Visible = true;
            grd001.Visible = false;
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

    /// <summary>
    /// Evento del control de buscar trabajadores por cod. trabajador, ocurre al hacer click en boton buscar del control.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void C_BuscaTrabajador_CodTrabSel(object sender, EventArgs e)
    {
        try
        {
            alertW.Visible = false;
            alertS.Visible = false;
            lblMsgWarning.Visible = false;
            lblMsgSuccess.Visible = false;
            if (C_BuscaTrabajador.isSelected)
            {
                string text = Get_Resultado_Busqueda(C_BuscaTrabajador.CodTrabajador);
                if (IdUsuarioSenainfo > 0)
                {
                    //GetResultadoInfoUser(txt_usuario.Text);
                    GetResultadoInfoUser(this.InitialUser);
                    txt_usuario.Attributes.Clear();
                    ddown004.AutoPostBack = true;
                    //lblTrabajador.Text = C_BuscaTrabajador.CodTrabajador.ToString();
                    //C_FormatRut.Texto = C_BuscaTrabajador.CodTrabajador.ToString();
                    //C_FormatRut.SetTexto();
                    C_BuscaTrabajador.CleanForm();
                    C_BuscaTrabajador.isSelected = false;
                }
                else
                {
                    alertW.Visible = true;
                    lblMsgWarning.Text = text;
                    lblMsgWarning.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {

            alertW.Visible = true;
            lblMsgWarning.Text = string.Format("Error en la carga de datos; trabajador: {0};",
                C_BuscaTrabajador.CodTrabajador.ToString());
            lblMsgWarning.Visible = true;
            return;
        }
    }

    /// <summary>
    /// Evento de la lista de regiones para cargar direccion regional.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddown004_SelectedIndexChanged(object sender, EventArgs e)
    {
        getdireccionregional();
    }

    //protected void txt_usuario_TextChanged(object sender, EventArgs e)
    //{
    //    alertW.Visible = false;
    //    lblMsgWarning.Visible = false;
    //    valida_usuario(true);
    //    return;
    //}

    /// <summary>
    /// Valida Usuario, si usuario ya existe en bd, o si esta actualizando nombre de usuario.
    /// </summary>
    /// <param name="isNew"></param>
    /// <returns></returns>
    private bool valida_usuario(bool isNew)
    {
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        int contar = select_contarusuarios(txt_usuario.Text.Trim());

        if ((contar != 0 && isNew) || (!isNew && InitialUser.Trim() != txt_usuario.Text.Trim() && contar != 0))
        {
            txt_usuario.BackColor = colorCampoObligatorio;
            alertW.Visible = true;
            lblMsgWarning.Text = "El nombre usuario ingresado ya existe.";
            lblMsgWarning.Visible = true;
            return false;
        }
        else
        {
            txt_usuario.BackColor = System.Drawing.Color.White;
            alertW.Visible = false;
            lblMsgWarning.Visible = false;
            return true;
        }       
    }

    /// <summary>
    /// Verifica si el mail ingresado existe en el sistema.
    /// </summary>
    /// <param name="isNew"></param>
    /// <returns></returns>
    private bool ExisteMailEnSistema()
    {
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9");

        if (GetExisteMiCuenta(txt_usuario.Text.Trim()))
        {
            txt_usuario.BackColor = colorCampoObligatorio;
            alertW.Visible = true;
            lblMsgWarning.Text = "El nombre usuario ingresado ya existe.";
            lblMsgWarning.Visible = true;
            return true;
        }
        else
        {
            txt_usuario.BackColor = System.Drawing.Color.White;
            alertW.Visible = false;
            lblMsgWarning.Visible = false;
            return false;
        }
    }

    private bool GetExisteMiCuenta(string login)
    {
        Nullable<int> idSenainfo;
        idSenainfo = IdUsuarioSenainfo;

        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetCuentasSimilaresSenainfo";
        sqlc.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = login;
        sqlc.Parameters.Add("@IdUsuarioSenainfo", SqlDbType.Int).Value = (IdUsuarioSenainfo > 0 ? IdUsuarioSenainfo : idSenainfo);

        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);

        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();

        if (Convert.ToInt32(dt.Rows[0][0]) >= 1)
            return true;
        else
        {
            SqlConnection sconn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionesSS"].ToString());
            System.Data.SqlClient.SqlCommand sqlc1 = new System.Data.SqlClient.SqlCommand();
            sqlc1.Connection = sconn1;
            sqlc1.CommandType = System.Data.CommandType.StoredProcedure;
            sqlc1.CommandText = "LSI_GetCuentasSimilaresSeguridad";
            sqlc1.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = login;
            sqlc1.Parameters.Add("@IdUsuarioSenainfo", SqlDbType.Int).Value = (IdUsuarioSenainfo > 0 ? IdUsuarioSenainfo : idSenainfo);

            System.Data.SqlClient.SqlDataAdapter da1 = new System.Data.SqlClient.SqlDataAdapter(sqlc1);

            DataTable dt1 = new DataTable();
            sconn1.Open();
            da1.Fill(dt1);
            sconn1.Close();
            if (Convert.ToInt32(dt1.Rows[0][0]) >= 1)
                return true;
        }
        return false;        
    }

   
    /// <summary>
    /// Devuelve el numero de usuarios que coinciden con el nombre de usuario consultado.
    /// </summary>
    /// <param name="usuario">Nombre de usuario a consultar</param>
    /// <returns>Nro de coincidencias</returns>
    private int select_contarusuarios(string usuario)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Select_ContarUsuarios";
        sqlc.Parameters.Add("@Usuario", SqlDbType.VarChar, 30).Value = usuario;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return Convert.ToInt32(dt.Rows[0][0]);
    }

    /// <summary>
    /// Ingreso de usuarios Nuevos.
    /// </summary>
    /// <param name="icodtrabajador"></param>
    /// <param name="codregion"></param>
    /// <param name="usuario"></param>
    /// <param name="contrasena"></param>
    /// <param name="coddireccionregional"></param>
    /// <param name="indvigencia"></param>
    /// <returns></returns>
    private DataTable insert_usuarios(int icodtrabajador, int codregion, string usuario, string contrasena, int coddireccionregional, string indvigencia)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Insert_Usuarios";
        sqlc.Parameters.Add("@ICodTrabajador", SqlDbType.Int, 4).Value = icodtrabajador;
        sqlc.Parameters.Add("@CodRegion", SqlDbType.Int, 4).Value = codregion;
        sqlc.Parameters.Add("@Usuario", SqlDbType.VarChar, 30).Value = usuario;
        sqlc.Parameters.Add("@Contrasena", SqlDbType.VarChar, 40).Value = contrasena;
        sqlc.Parameters.Add("@CodDireccionRegional", SqlDbType.Int, 4).Value = coddireccionregional;
        sqlc.Parameters.Add("@IndVigencia", SqlDbType.Char, 1).Value = indvigencia;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    //protected void txt_contrass2_TextChanged(object sender, EventArgs e)
    //{
    //    System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

    //    //if (txt_contrass2.Text == txt_contrass.Text)
    //    //{
    //    //    txt_contrass2.BackColor = System.Drawing.Color.White;

    //    //}
    //    //else
    //    //{
    //    //    txt_contrass2.BackColor = colorCampoObligatorio;
    //    //    //window.alert(this.Page, "ERROR, CONTRASEÑA DEBEN SER IGUALES");
    //    //    //alerts.Visible = true;
    //    //    //lb_mensajes.Text = "ERROR, CONTRASEÑA DEBEN SER IGUALES";
    //    //    alertW.Visible = true;
    //    //    lblMsgWarning.Text = "Error, contraseñas deben ser iguales.";
    //    //    lblMsgWarning.Visible = true;

    //    //}

    //    imb002.Focus();
    //}

    /// <summary>
    /// Actualizacion de usuario.
    /// </summary>
    /// <param name="icodtrabajador"></param>
    /// <param name="codregion"></param>
    /// <param name="contrasena"></param>
    /// <param name="coddireccionregional"></param>
    /// <param name="IndVigencia"></param>
    /// <returns></returns>
    private DataTable update_usuarios(int icodtrabajador, int codregion, string contrasena, int coddireccionregional, string IndVigencia)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Update_Usuarios";
        sqlc.Parameters.Add("@ICodTrabajador", SqlDbType.Int, 4).Value = icodtrabajador;
        sqlc.Parameters.Add("@CodRegion", SqlDbType.Int, 4).Value = codregion;
        sqlc.Parameters.Add("@Contrasena", SqlDbType.VarChar, 40).Value = contrasena;
        sqlc.Parameters.Add("@CodDireccionRegional", SqlDbType.Int, 4).Value = coddireccionregional;
        sqlc.Parameters.Add("@IndVigencia", SqlDbType.Char, 1).Value = IndVigencia;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    //private DataTable update_usuarios(int icodtrabajador, int codregion, string contrasena, int coddireccionregional, string IndVigencia)
    //{
    //    SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
    //    System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
    //    sqlc.Connection = sconn;
    //    sqlc.CommandType = System.Data.CommandType.StoredProcedure;
    //    sqlc.CommandText = "Update_Usuarios";
    //    sqlc.Parameters.Add("@ICodTrabajador", SqlDbType.Int, 4).Value = icodtrabajador;
    //    sqlc.Parameters.Add("@CodRegion", SqlDbType.Int, 4).Value = codregion;
    //    sqlc.Parameters.Add("@Contrasena", SqlDbType.VarChar, 40).Value = contrasena;
    //    sqlc.Parameters.Add("@CodDireccionRegional", SqlDbType.Int, 4).Value = coddireccionregional;
    //    sqlc.Parameters.Add("@IndVigencia", SqlDbType.Char, 1).Value = IndVigencia;
    //    System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
    //    DataTable dt = new DataTable();
    //    sconn.Open();
    //    da.Fill(dt);
    //    sconn.Close();
    //    return dt;
    //}

    //protected void lnnk001_Click(object sender, EventArgs e)
    //{
    //    alertW.Visible = false;
    //    lblMsgWarning.Visible = false;
    //    valida_usuario();
    //    txt_usuario.Attributes.Clear();
    //    txt_usuario.AutoPostBack = true;
    //}

    /// <summary>
    /// Botón Actualizar Cuenta
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void WebImageButton3_Click(object sender, EventArgs e)
    {
        alertW.Visible = false;
        alertS.Visible = false;
        lblMsgWarning.Visible = false;
        lblMsgSuccess.Visible = false;
        
        if (ExisteMailEnSistema())
            return;
        
        if (ValidarMail())
        {
            funcion_guardar(false);
            txtInfoUser.Text = string.Empty;
            btnCancelarSolicitud.Visible = false;
            btnReenvio.Visible = false;
            tblInfoUser.Visible = false;
            btnPswChange.Visible = false;
        }
    }
            
        

    /// <summary>
    /// Obtiene token de usuario en session.
    /// </summary>
    /// <returns></returns>
    public DataSet ObtenerTokensUsuarioSSO()
    {
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        using (SqlDataAdapter da = new SqlDataAdapter("TestGetTokenUserLateral", ConfigurationManager.ConnectionStrings["ConexionesSS"].ToString()))
        {
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@loginUser", SqlDbType.VarChar);
            da.SelectCommand.Parameters["@loginUser"].Value = Session["UserName"];
            da.Fill(dt);
            ds.Tables.Add(dt);
            da.SelectCommand.Connection.Close();
            return ds;
        }
    }

    /// <summary>
    /// Botón solicitud cambiar contraseña
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPswChange_Click(object sender, EventArgs e)
    {
        alertW.Visible = false;
        alertS.Visible = false;
        lblMsgWarning.Visible = false;
        lblMsgSuccess.Visible = false;

        if (validaCampos())
        {
            try
            {
                if (SentMailValidity())
                {
                    alertS.Visible = true;
                    lblMsgSuccess.Text = "Se ha enviado un correo a su casilla de correo, mediante el cual podrá cambiar su password.";
                    lblMsgSuccess.Visible = true;
                    this.GetResultadoInfoUser(txt_usuario.Text.Trim());
                }
               
            }
            catch (Exception ex)
            {
                alertW.Visible = true;
                lblMsgWarning.Text = ex.Message + "" + ex.InnerException;
            }
        }
    }

    /// <summary>
    /// Botón reenvía mail
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnReenvio_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddown003.SelectedValue != "C")
            {
                if (ReenviarMail())
                {
                    alertS.Visible = true;
                    lblMsgSuccess.Text = "Se ha enviado un correo a su casilla de correo.";
                    lblMsgSuccess.Visible = true;
                }
                else
                {
                    alertW.Visible = true;
                    lblMsgWarning.Text = "No se puedo enviar el correo.";
                    lblMsgWarning.Visible = true;
                }
            }
            else
            {
                alertW.Visible = true;
                lblMsgWarning.Text = "Usuario está caducado, favor cancelar solicitud.";
                lblMsgWarning.Visible = true;
            }

            //this.Get_Resultado_InfoUser(txt_usuario.Text); //REVISAR SI realmente va
        }
        catch (Exception ex)
        {
            alertW.Visible = true;
            lblMsgWarning.Text = ex.Message + "" + ex.InnerException;
        }
    }

    /// <summary>
    /// Valida correo y Envio de mail 
    /// </summary>
    /// <returns></returns>
    private bool SentMailValidity()
    {
        alertW.Visible = false;
        alertS.Visible = false;
        lblMsgWarning.Visible = false;
        lblMsgSuccess.Visible = false;
        /******** SÓLO PARA EFECTOS DE PRUEBA AL ENTRAR POR LA PUERTA LATERAL (Autenticacion) */
        Session["TokenAux"] = GetTokenUser();

        /***  FIN ***/

        SeguridadSENAINFO.SeguridadSENAINFOSoapClient wsSeguridad = new SeguridadSENAINFO.SeguridadSENAINFOSoapClient();
        SeguridadSENAINFO.Usuario usuario = wsSeguridad.ObtenerUsuarioByIdSenainfo(IdUsuarioSenainfo);
        
        RegexUtilities regex = new RegexUtilities();

        if (usuario.NombreUsuario.Trim() != txt_usuario.Text.Trim() && !regex.IsValidEmail(usuario.NombreUsuario.Trim()))
        {
            alertW.Visible = true;
            lblMsgWarning.Visible = true;
            lblMsgWarning.Text = "Debe actualizar su usuario, ya que el usuario almacenado en nuestro sistema no tiene un mail válido; usuario: " + usuario.NombreUsuario;
            return false;
        }

         if (ValidarMail())
        {
            if (EnviarMail(Session["TokenAux"].ToString(), true, true))
                return true;
        }
        return false;
    }

    /// <summary>
    /// Obtiene session "TokenAux"
    /// </summary>
    /// <returns></returns>
    private string GetTokenUser()
    {
        if (Session["TokenAux"] == null)
        {
            DataSet dstoken = new DataSet();
            dstoken = ObtenerTokensUsuarioSSO();
            if (dstoken.Tables.Count > 0)
                return dstoken.Tables[0].Rows[0].ItemArray[0].ToString();
            return string.Empty;
        }
        return Session["TokenAux"].ToString();
    }

    /// <summary>
    /// Boton Crear Cuenta
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imb002_Click(object sender, EventArgs e)
    {

        alertW.Visible = false;
        alertS.Visible = false;
        lblMsgWarning.Visible = false;
        lblMsgSuccess.Visible = false;


        // int contar = select_contarusuarios(txt_usuario.Text.Trim());
        if (ExisteMailEnSistema())
            return;

        if (ValidarMail())
        {
            txt_usuario.BackColor = System.Drawing.Color.White;
            alertW.Visible = false;
            lblMsgWarning.Visible = false;
            funcion_guardar(true);
        }


        this.GetResultadoInfoUser(txt_usuario.Text.Trim());
    }        
    

    /// <summary>
    /// Boton limpiar resetear formulario 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void WebImageButton1_Click1(object sender, EventArgs e)
    {
        alertW.Visible = false;
        alertS.Visible = false;
        lblMsgWarning.Visible = false;
        lblMsgSuccess.Visible = false;
        //funcion_limpiar();
        limpiarCampos();
    }

    /// <summary>
    /// Boton Cancelar Solicitud enviadas a correo.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancelarSolicitud_Click(object sender, EventArgs e)
    {
        alertW.Visible = false;
        alertS.Visible = false;
        lblMsgWarning.Visible = false;
        lblMsgSuccess.Visible = false;

        string userName = txt_usuario.Text.Trim();
        RegexUtilities regex = new RegexUtilities();
        bool esCorreo = false;
        if (regex.IsValidEmail(userName))
            esCorreo = true;
        string tokenMesa = GetTokenUser();

        //Actualizar tokenMail(null) y EmailConfirmado(null).
        SeguridadSENAINFO.SeguridadSENAINFOSoapClient wsSeguridad = new SeguridadSENAINFO.SeguridadSENAINFOSoapClient();
        bool resultado = wsSeguridad.CancelarSolicitudUsuario(Session["UserName"].ToString(), tokenMesa, userName, esCorreo);
        this.GetResultadoInfoUser(userName);
    }

}
