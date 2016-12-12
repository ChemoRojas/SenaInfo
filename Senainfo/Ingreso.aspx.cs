using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ingreso : System.Web.UI.Page
{
    private int codigoTrabajador;
    private string nombreUsuario;

    private string usuario = "";
    private string contrasena = "";

    public DataTable dtEncuestas
    {
        get { return (DataTable)Session["dtEncuestas"]; }
        set { Session["dtEncuestas"] = value; }
    }

    public void GetEncuestas()
    {
        EncuestasColl ecoll = new EncuestasColl();

        string[] Arr_Devueltos = new string[4];
        Arr_Devueltos = ecoll.ExisteEncuesta(Arr_Devueltos);

        int HayEncuesta = Convert.ToInt16(Arr_Devueltos[0]);
        int CodEncuesta = Convert.ToInt16(Arr_Devueltos[1]);
        string Formulario = Arr_Devueltos[2];

        int CorrespondeRol = ecoll.EncuestasRoles(CodEncuesta, Convert.ToInt32(Session["IdUsuario"]));

        if (HayEncuesta != 0 && CorrespondeRol != 0)
        {
            int Respondido = ecoll.GetData(CodEncuesta, Convert.ToString(Session["IdUsuario"]));

            if (Respondido == 0)
                Response.Redirect(Formulario);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //usuario = Request.Form["usuario"];
            //contrasena = Request.Form["password"];
            //lb_usuario.Text = usuario;
            //lb_contrasena.Text = contrasena;
            NameValueCollection nvc = Request.Form;
            //string usuario, contrasena;
            if (!string.IsNullOrEmpty(nvc["usuario"]) || !string.IsNullOrEmpty(nvc["password"]))
            {
                usuario = nvc["usuario"];
                contrasena = nvc["password"];
                ingreso();
            }
            else
            {
                lbl_aviso.Text = "Debe Completar Ambos Campos.";
                lbl_aviso.Visible = true;
            }

            //if (!string.IsNullOrEmpty(nvc["password"]))
            //{
            //    contrasena = nvc["password"];
            //}

            //Process login
            
        }
    }

    private string get_indvigencia(string username)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        List<DbParameter> listDbParameter = new List<DbParameter>();

        string sql = Resources.Procedures.GetVigencia_Usuario + "@pusername";

        listDbParameter.Add(Conexiones.CrearParametro("@pusername", SqlDbType.VarChar, 30, username));

        con.ejecutar(sql, listDbParameter, out datareader);

        int codtrab = 0;
        string VigenciaUsuario = "";
        DateTime FechaActualizacion = Convert.ToDateTime("01-01-1900");
        while (datareader.Read())
        {
            try
            {
                codtrab = (int)datareader["ICodTrabajador"];
                codigoTrabajador = (int)datareader["ICodTrabajador"];
                FechaActualizacion = (DateTime)datareader["FechaActualizacion"];
                VigenciaUsuario = (string)datareader["indvigencia"];
            }
            catch { }
        }

        //con.ejecutar(Resources.Procedures.GetVigencia_CodTrab + codtrab, out datareader); //Solo trae IndVigencia
        con.ejecutar(Resources.Procedures.GetVigencia_CodTrab2 + codtrab, out datareader);  //Trae IndVigencia, Nombres y Apellido Paterno
        string vigencia = "";
        while (datareader.Read())
        {
            try
            {
                vigencia = (string)datareader["indvigencia"];
                string myString = (string)(datareader["Nombres"] + " " + datareader["Paterno"]).ToLower();
                TextInfo myTI = new CultureInfo("es-CL", false).TextInfo;
                nombreUsuario = myTI.ToTitleCase(myString);
            }
            catch { }
        }
        con.Desconectar();

        if (vigencia == "V")
        {
            if (VigenciaUsuario == "V")
            {
                //if (!(System.DateTime.Now < FechaActualizacion.AddMonths(6)))
                if (!(System.DateTime.Now < FechaActualizacion.AddDays(45)))
                {
                    window.open(this.Page, "cambia_password.aspx?lbl=La contrasena ha caducado y debe cambiarse", "Contraseña", false, false, 400, 250, false, false, false);
                    vigencia = "C";
                }
                else
                {
                    vigencia = "V";
                }
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

    protected void lnk001_Click(object sender, EventArgs e)
    {
        window.open(this.Page, "cambia_password.aspx", "Contraseña", false, false, 400, 550, false, false, false);
    }

    public int getIdUsuario(String user)
    {
        DbDataReader datareader = null;

        Conexiones con = new Conexiones();
        List<DbParameter> listDbParameter = new List<DbParameter>();

        string sql = Resources.Procedures.GetVigencia_Usuario + "@puser";

        listDbParameter.Add(Conexiones.CrearParametro("@puser", SqlDbType.VarChar, 30, user));

        con.ejecutar(sql, listDbParameter, out datareader);
        int idusuario = 0;
        while (datareader.Read())
        {
            try
            {
                idusuario = (int)datareader["idusuario"];
            }
            catch { }
        }
        return idusuario;
    }

    protected void ingreso()
    {
        string vigencia = get_indvigencia(usuario.Trim());

        if (vigencia == "V")
        {
            if (contrasena == "")
            {
                //alerta.Visible = true;
                lbl_aviso.Text = "Debe ingresar su contraseña";
                lbl_aviso.Visible = true;
                return;
            }

            //SeguridadSENAINFO.Service1 ls = new SeguridadSENAINFO.Service1();
            SeguridadSENAINFO.SeguridadSENAINFOSoapClient ls = new SeguridadSENAINFO.SeguridadSENAINFOSoapClient();
            DataSet arr = ls.ObtenerTokensUsuario(usuario, contrasena);
            Session["tokens"] = arr;

            if (window.existetoken("3E85C221-1603-4D99-AA31-9EFD971F7387"))
            {
                Session["IdUsuario"] = getIdUsuario(usuario);
                //Session["Usuario"] = txt_usuario.Text;
                Session["Usuario"] = nombreUsuario;
                GetEncuestas();

                //JVB - Graba fechaultimoingreso
                Conexiones con = new Conexiones();
                con.Autenticar();
                int salida = (int)con.TraerValorEscalar("SP_Usuarios_FechaUltimoIngreso", Session["IdUsuario"]);

                /*
                 * Autor: JLBL
                 * Fecha: 22-05-2015
                 * Descripcion: Genera un registro por cada ingreso al sistema.
                 */

                string NombreSistema = ConfigurationManager.AppSettings["NombreSistema"].ToString();
                string clientIp = Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? Request.ServerVariables["REMOTE_ADDR"];
                System.Web.HttpBrowserCapabilities navegador = Request.Browser;
                int registroIngreso = (int)con.TraerValorEscalar("PA_LogUsuarios", Session["IdUsuario"], NombreSistema, navegador.Browser.ToString(), navegador.Version.ToString(), clientIp.ToString());
                con.CerrarConexion();

                #region Carga de parametricas
                Session["dsParametricas"] = new DataSet();

                institucioncoll instColl = new institucioncoll();
                parcoll par = new parcoll();
                ninocoll ncoll = new ninocoll();

                DataTable dtInstituciones = instColl.GetData(Convert.ToInt32(Session["IdUsuario"])); dtInstituciones.TableName = "dtInstituciones";
                DataTable dtTipoAsistenciaEscolar = par.GetparTipoAsistenciaEscolar(); dtTipoAsistenciaEscolar.TableName = "dtTipoAsistenciaEscolar";
                DataTable dtTipoMaltrato = par.GetparTipoMaltrato(); dtTipoMaltrato.TableName = "dtTipoMaltrato";
                DataTable dtRelacionPresuntoMaltratador = ncoll.Get_TipoRelacionMaltrato(); dtRelacionPresuntoMaltratador.TableName = "dtRelacionPresuntoMaltratador";
                DataTable dtDroga = par.GetparDrogas(); dtDroga.TableName = "dtDroga";
                DataTable dtTipoConsumoDroga = par.GetparTipoConsumoDroga(); dtTipoConsumoDroga.TableName = "dtTipoConsumoDroga";
                DataTable dtTipoDiagnosticosPsicologico = par.GetparTipoDiagnosticosPsicologico(); dtTipoDiagnosticosPsicologico.TableName = "dtTipoDiagnosticosPsicologico";
                DataTable dtInsercionLaboral = par.GetparInsercionLaboral(); dtInsercionLaboral.TableName = "dtInsercionLaboral";
                DataTable dtTipoTribunal = par.GetparTipoTribunal(); dtTipoTribunal.TableName = "dtparTipoTribunal";
                DataTable dtparRegion = par.GetparRegion(); dtparRegion.TableName = "dtparRegion";
                DataTable dtTipoCausalIngreso = par.GetTipoCausal(); dtTipoCausalIngreso.TableName = "dtTipoCausalIngreso";
                DataTable dtparNacionalidades = par.GetparNacionalidades(); dtparNacionalidades.TableName = "dtparNacionalidades";
                DataTable dtparTipoCausalIngreso = par.GetparTipoCausalIngreso(0); dtparTipoCausalIngreso.TableName = "parTipoCausalIngreso";

                DataSet dsParametricas = new DataSet();

                dsParametricas.Tables.Add(dtInstituciones);
                dsParametricas.Tables.Add(dtTipoAsistenciaEscolar);
                dsParametricas.Tables.Add(dtTipoMaltrato);
                dsParametricas.Tables.Add(dtRelacionPresuntoMaltratador);
                dsParametricas.Tables.Add(dtDroga);
                dsParametricas.Tables.Add(dtTipoConsumoDroga);
                dsParametricas.Tables.Add(dtTipoDiagnosticosPsicologico);
                dsParametricas.Tables.Add(dtInsercionLaboral);
                dsParametricas.Tables.Add(dtTipoTribunal);
                dsParametricas.Tables.Add(dtparRegion);
                dsParametricas.Tables.Add(dtTipoCausalIngreso);
                dsParametricas.Tables.Add(dtparNacionalidades);
                dsParametricas.Tables.Add(dtparTipoCausalIngreso);

                Session["dsParametricas"] = dsParametricas;
                #endregion

                Response.Redirect("~/index.aspx");
            }
            else
            {
                //alerta.Visible = true;
                lbl_aviso.Text = "El usuario o contraseña son incorrectas.";
                lbl_aviso.Visible = true;
            }

        }
        else if (vigencia == "C")
        {
            //alerta.Visible = true;
            lbl_aviso.Text = "Su cuenta de usuario presenta problemas. Comuniquese con la Mesa de Ayuda";
            lbl_aviso.Visible = true;
        }
    }

    #region ingresar
    //protected void imb_ingresar_Click1(object sender, EventArgs e)
    //{
    //    string vigencia = get_indvigencia(txt_usuario.Text.Trim());

    //    if (vigencia == "V")
    //    {
    //        if (txt_password.Text == "")
    //        {
    //            alerta.Visible = true;
    //            lbl_aviso.Text = "Debe ingresar su contraseña";
    //            lbl_aviso.Visible = true;
    //            return;
    //        }

    //        SeguridadSENAINFO.Service1 ls = new SeguridadSENAINFO.Service1();
    //        DataSet arr = ls.ObtenerTokensUsuario(txt_usuario.Text, txt_password.Text);
    //        Session["tokens"] = arr;

    //        if (window.existetoken("3E85C221-1603-4D99-AA31-9EFD971F7387"))
    //        {
    //            Session["IdUsuario"] = getIdUsuario(txt_usuario.Text);
    //            //Session["Usuario"] = txt_usuario.Text;
    //            Session["Usuario"] = nombreUsuario;
    //            GetEncuestas();

    //            //JVB - Graba fechaultimoingreso
    //            Conexiones con = new Conexiones();
    //            con.Autenticar();
    //            int salida = (int)con.TraerValorEscalar("SP_Usuarios_FechaUltimoIngreso", Session["IdUsuario"]);

    //            /*
    //             * Autor: JLBL
    //             * Fecha: 22-05-2015
    //             * Descripcion: Genera un registro por cada ingreso al sistema.
    //             */

    //            string NombreSistema = ConfigurationManager.AppSettings["NombreSistema"].ToString();
    //            string clientIp = Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? Request.ServerVariables["REMOTE_ADDR"];
    //            System.Web.HttpBrowserCapabilities navegador = Request.Browser;
    //            int registroIngreso = (int)con.TraerValorEscalar("PA_LogUsuarios", Session["IdUsuario"], NombreSistema, navegador.Browser.ToString(), navegador.Version.ToString(), clientIp.ToString());
    //            con.CerrarConexion();

    //            Response.Redirect("index.aspx");
    //        }
    //        else
    //        {
    //            alerta.Visible = true;
    //            lbl_aviso.Text = "El usuario o contraseña son incorrectas.";
    //            lbl_aviso.Visible = true;
    //        }

    //    }
    //    else if (vigencia == "C")
    //    {
    //        alerta.Visible = true;
    //        lbl_aviso.Text = "Su cuenta de usuario presenta problemas. Comuniquese con la Mesa de Ayuda";
    //        lbl_aviso.Visible = true;
    //    }
    //}
    #endregion

    protected void IniciaVariableSession()
    {
        /*
        * JOVM - 30/01/2015
        * Se declaran  inicializan variables de SESSION
        */
        Session["NNANombres"] = "";
        Session["NNAApellidoPaterno"] = "";
        Session["NNAApellidoMaterno"] = "";
        Session["NNACodProyecto"] = "";
        Session["NNACodInstitucion"] = "";
        Session["NNASexo"] = "";
        Session["NNARutNino"] = "";
        Session["NNACodNino"] = "";
        Session["NNAFechaNacimiento"] = "";
    }
}