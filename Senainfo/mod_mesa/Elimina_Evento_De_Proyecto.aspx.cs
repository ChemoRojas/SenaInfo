using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mod_mesa_Elimina_Evento_De_Proyecto : System.Web.UI.Page
{
    private string msgsp;
 
    public int CODEVENTPROYECTO 
    {
        get { return (int)Session["CODEVENTPROYECTO"]; }
        set { Session["CODEVENTPROYECTO"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
        {
            Response.Redirect("~/logout.aspx");
        }
        else
        {
            if (!window.existetoken("0E1D9FAC-5157-449C-94AC-704A002EA0E2"))
            {
                Response.Redirect("~/e403.aspx");
            }
        }
    }
    protected void btn_ejecutar_Click(object sender, EventArgs e)
    {
        if (this.EntradaValida())
        {
            this.ExecProcedimiento(0);
        }
    }
    protected bool EntradaValida()
    {
        bool valido = true;
        string mensaje = string.Empty;

        if (txt_comentario.Text == "")
        {
            valido = false;

            mensaje = "Debe Ingresar un comentario. ";

            txt_comentario.CssClass = SenainfoSdk.UI.Util.AddCssClass(txt_comentario.CssClass,
                    "campo-obligatorio");
        }
        else
        {
            txt_comentario.CssClass = SenainfoSdk.UI.Util.RemoveCssClass(txt_comentario.CssClass,
                    "campo-obligatorio");
        }

        if (this.C_codigoeventoproyecto.CodProyecto == 0)
        {
            valido = false;

            mensaje += "Debe seleccionar un proyecto.";

            this.C_codigoeventoproyecto.MarcarRequeridos(true);
        }
        else
            this.C_codigoeventoproyecto.MarcarRequeridos(false);


        if (valido)
        {
            this.C_msgAlerta.Hide();
        }
        else
        {
            this.C_msgAlerta.Show(mensaje,
                SenainfoSdk.UI.TipoMsgAlerta.Warning,
                false);
        }

        return valido;
    }
    public void ExecProcedimiento(int confirmar)
    {
        int resultado;
        SqlDataReader reader;

        string str_error = "";  
        Conexiones con = new Conexiones();
        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + con.Servidor + " ;Database= " + con.Base + " ; User ID= " + con.Usuario + " ;Password= " + con.Passw + " ;Trusted_Connection=False");
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sconn.InfoMessage += (object sender, SqlInfoMessageEventArgs e) =>
        {
            msgsp += e.Message + "<br />";
        };
        try
        {
            sqlc.Connection = sconn;
            sqlc.CommandType = System.Data.CommandType.StoredProcedure;
            sqlc.CommandText = "Mesa_Elimina_EventoProyecto";
            var returnParameter = sqlc.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            sqlc.Parameters.Add("@ICodEventosProyectos", SqlDbType.Int).Value = CODEVENTPROYECTO;
            sqlc.Parameters.Add("@Confirmar", SqlDbType.Int).Value = confirmar;
            sconn.Open();


            this.msgsp = string.Empty;

            sconn.Open();

            sqlc.ExecuteNonQuery();

            resultado = (int)returnParameter.Value;

            sconn.Close();


            this.C_msgAlerta.Hide();
            if (confirmar == 0)
            {
                switch (resultado)
                {
                    case 0: //exito
                        this.C_modalPopUp.ShowMensaje("Confirmar Eliminar evento de proyecto",
                            this.msgsp,
                            SenainfoSdk.UI.TipoMsgAlerta.Ninguna,
                            SenainfoSdk.UI.ModalPopupButtons.YesNoCancel);
                        break;

                    case 1: //error
                        this.C_msgAlerta.Show(this.msgsp,
                            SenainfoSdk.UI.TipoMsgAlerta.Danger,
                            false);
                        break;

                    case 2: //advertencia
                        this.C_modalPopUp.ShowMensaje("Confirmar Eliminar evento de proyecto",
                            this.msgsp,
                            SenainfoSdk.UI.TipoMsgAlerta.Warning,
                            SenainfoSdk.UI.ModalPopupButtons.YesNoCancel);
                        break;

                    default: //código no soportado
                        this.C_msgAlerta.Show("CÓDIGO NO SOPORTADO!!! <br/> Informar a soporte <br />" + this.msgsp,
                            SenainfoSdk.UI.TipoMsgAlerta.Danger,
                            false);
                        break;
                }
            }
            else if (confirmar == 1)
            {
                switch (resultado)
                {
                    case 0: //exito
                        this.C_msgAlerta.Show(this.msgsp,
                            SenainfoSdk.UI.TipoMsgAlerta.Success,
                            false);
                        break;

                    case 1: //error
                        this.C_msgAlerta.Show(this.msgsp,
                            SenainfoSdk.UI.TipoMsgAlerta.Danger,
                            false);
                        break;

                    case 2: //advertencia
                        this.C_msgAlerta.Show(this.msgsp,
                            SenainfoSdk.UI.TipoMsgAlerta.Warning,
                            false);
                        break;

                    default: //código no soportado
                        this.C_msgAlerta.Show("CÓDIGO NO SOPORTADO!!! <br/> Informar a soporte <br />" + this.msgsp,
                            SenainfoSdk.UI.TipoMsgAlerta.Danger,
                            false);
                        break;
                }

                //this.C_seleccionIcodie.Actualizar();
                registrolog();
            }

           
        }
        catch (Exception ex)
        {
            this.C_msgAlerta.Show(ex.Message,
                 SenainfoSdk.UI.TipoMsgAlerta.Danger,
                 false);
        }
        finally
        {
            if (sconn.State != ConnectionState.Closed)
                sconn.Close();
        }
        
    }
   
    public void registrolog()
    {
        SenainfoSdk.Log_mesa_ayuda logreg = new SenainfoSdk.Log_mesa_ayuda();
        logreg.Codproyecto = Convert.ToString(this.C_codigoeventoproyecto.CodProyecto);
        logreg.anomes = DateTime.Now.ToShortDateString();
        logreg.datoanexo = Convert.ToString(this.C_codigoeventoproyecto.CODEVENTPROY);
        logreg.mensaje = txt_comentario.Text;
        logreg.msj_retorno_sp = msgsp;
        logreg.nombre_sp_ejecutado = "Mesa_Elimina_EventoProyecto";
        logreg.insertLog();
    }
    protected void C_modalPopUp_ResultadoPopup(object sender, SenainfoSdk.UI.ModelPopupResultEventArgs e)
    {
        if (e.ModalPopupResult == SenainfoSdk.UI.ModalPopupResult.Yes)
            this.ExecProcedimiento(1);
    }
    protected void btnlimpiar_Click(object sender, EventArgs e)
    {
        C_msgAlerta.Hide();
        this.C_codigoeventoproyecto.MarcarRequeridos(false);
        txt_comentario.CssClass = SenainfoSdk.UI.Util.RemoveCssClass(txt_comentario.CssClass,
         "campo-obligatorio");
        SenainfoSdk.UI.Util.CleanControl(this.Controls);
     
    }
  
}