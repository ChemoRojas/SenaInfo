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
using System.Globalization;

using System.Collections.Generic;

public partial class autenticacion : System.Web.UI.Page
{
    private int codigoTrabajador;
    private string nombreUsuario;
    private string dns_from = ConfigurationManager.AppSettings["dns_from"];
    
    protected void Page_Load(object sender, EventArgs e)
    {
        alerta.Visible = false;
        if (!IsPostBack)
        {
            window.logout();

            //Response.Redirect(dns_from + "senainfo.cl");
        }
    }

    protected void lnk001_Click(object sender, EventArgs e)
    {
        window.open(this.Page, "cambia_password.aspx", "Contraseña", false, false, 400, 550, false, false, false);
    }

    protected void imb_ingresar_Click1(object sender, EventArgs e)
    {
        string vigencia = get_indvigencia(txt_usuario.Text.Trim());

        if (vigencia == "V")
        {
            if (txt_password.Text == "")
            {
                alerta.Visible = true;
                lbl_aviso.Text = "Debe ingresar su contraseña";
                lbl_aviso.Visible = true;
                return;
            } 

            //SeguridadSENAINFO.Service1 ls = new SeguridadSENAINFO.Service1();

            // comentado para utilizar autenticación directa con la BD de LoginSENAINFO
            //SeguridadSENAINFO.SeguridadSENAINFOSoapClient ls = new SeguridadSENAINFO.SeguridadSENAINFOSoapClient();
            //DataSet arr = ls.ObtenerTokensUsuario(txt_usuario.Text, txt_password.Text);

            DataSet arr = ObtenerTokensUsuario(txt_usuario.Text, txt_password.Text);

            Session["tokens"] = arr;

            if(window.existetoken("3E85C221-1603-4D99-AA31-9EFD971F7387"))
            {
                Session["IdUsuario"] = getIdUsuario(txt_usuario.Text);
                Session["UserName"] = txt_usuario.Text;
                Session["Usuario"] = nombreUsuario;
                

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

                //FormsAuthentication.RedirectFromLoginPage(nombreUsuario, false);
                FormsAuthentication.SetAuthCookie(nombreUsuario, false);

                GetEncuestas();

                /* No se puede usar ReturnUrl porque hay páginas con IFrame
                string returnUrl = Request.QueryString["ReturnUrl"];
                if (string.IsNullOrEmpty(returnUrl))
                    Response.Redirect("~/index.aspx");*/

                GeneraMenu gn = new GeneraMenu();
                Session["mm"] = gn.getMenu(txt_usuario.Text, txt_password.Text);

                //Response.Redirect("~/TestMenu.aspx");

                Response.Redirect("~/index.aspx");
            }
            else
            {
                alerta.Visible = true;
                lbl_aviso.Text = "El usuario o contraseña son incorrectas.";
                lbl_aviso.Visible = true;
            }

        }
        else if (vigencia == "C")
        {
            alerta.Visible = true;
            lbl_aviso.Text = "Su cuenta de usuario presenta problemas. Comuniquese con la Mesa de Ayuda";
            lbl_aviso.Visible = true;
        }
    }

    private DataSet ObtenerTokensUsuario(string usuario, string password)
    {
        DataSet ret = new DataSet();

        try
        {
            string pass = window.EncriptarContrasena(usuario, password);

            ConexionesSS con = new ConexionesSS();
            con.Autenticar();

            System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["ConexionesSS"].ToString());
            System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
            sqlc.Connection = sconn;
            sqlc.CommandType = System.Data.CommandType.StoredProcedure;
            sqlc.CommandText = "[loginsenainfoCapacitacion].[dbo].[LSI_ValidarUsuario]";
            sqlc.Parameters.Add("@usuario", SqlDbType.VarChar, 100).Value = usuario;
            sqlc.Parameters.Add("@contrasena", SqlDbType.VarChar, 100).Value = pass;

            var retorno = sqlc.Parameters.Add("@ReturnVal", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            sconn.Open();
            sqlc.ExecuteNonQuery();
            sconn.Close();

            int salida = (int)retorno.Value;

            if (salida == 1)
                ret = con.TraerDataSet("LSI_ObtenerTokensUsuario", usuario);         
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return ret;
    }

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

        Session["iCodTrabajador"] = codigoTrabajador;

        //con.ejecutar(Resources.Procedures.GetVigencia_CodTrab + codtrab, out datareader); //Solo trae IndVigencia
        con.ejecutar(Resources.Procedures.GetVigencia_CodTrab2 + codtrab, out datareader);  //Trae IndVigencia, Nombres y Apellido Paterno
        string vigencia = "";
        string contrasena = "";
        while (datareader.Read())
        {
            try
            {
                vigencia = (string)datareader["indvigencia"];
                string myString = (string)(datareader["Nombres"] + " " + datareader["Paterno"]).ToLower();
                contrasena = (string)datareader["contrasena"];
                TextInfo myTI = new CultureInfo("es-CL", false).TextInfo;
                nombreUsuario = myTI.ToTitleCase(myString);

                Session["contrasena"] = contrasena;
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
                    vigencia = "V";
                }
                else
                {
                    window.open(this.Page, "cambia_password.aspx?lbl=La contrasena ha caducado y debe cambiarse", "Contraseña", false, false, 400, 250, false, false, false);
                    vigencia = "C";
                   
                }
            }
            else if (VigenciaUsuario == "P")//Pendiente(CambioContraseña)
            {
                if (!(System.DateTime.Now < FechaActualizacion.AddDays(45)))
                {
                    vigencia = "C";//Pendiente Caducó Contraseña
                }
                else
                {
                    vigencia = "V";//entrada lateral aun si tiene solicitudes pendientes.
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
