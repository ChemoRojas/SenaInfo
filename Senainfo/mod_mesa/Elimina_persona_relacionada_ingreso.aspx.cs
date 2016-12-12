using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mod_mesa_C_Elimina_persona_relacionada_ingreso : System.Web.UI.Page
{
    private string msgsp;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
        {
            Response.Redirect("~/logout.aspx");
        }
        else
        {
            if (!window.existetoken("3AFCA78A-D54A-465A-AC3D-929474479D71"))
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

        if (txt_comentarios.Text == "")
        {
            valido = false;

            mensaje = "Debe Ingresar un comentario. ";

            txt_comentarios.CssClass = SenainfoSdk.UI.Util.AddCssClass(txt_comentarios.CssClass,
                    "campo-obligatorio");
        }
        else
        {
            txt_comentarios.CssClass = SenainfoSdk.UI.Util.RemoveCssClass(txt_comentarios.CssClass,
                    "campo-obligatorio");
        }
        if (this.C_buscaPersonaRelacionada.CodProyecto == 0)
        {
            valido = false;
            mensaje += "Debe seleccionar un proyecto.";
            this.C_buscaPersonaRelacionada.MarcarRequeridos(true);
        }
        else
            this.C_buscaPersonaRelacionada.MarcarRequeridos(false);
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
    protected void ExecProcedimiento(int confirmar)
    {
        int resultado;
        Conexiones con = new Conexiones();
        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + con.Servidor + " ;Database= " + con.Base + " ; User ID= " + con.Usuario + " ;Password= " + con.Passw + " ;Trusted_Connection=False");
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sconn.InfoMessage += (object sender, SqlInfoMessageEventArgs e) =>
        {
            msgsp += e.Message;  
        };
        try
        {
            sqlc.Connection = sconn;
            sqlc.CommandType = System.Data.CommandType.StoredProcedure;
            sqlc.CommandText = "Mesa_Elimina_PersonaRelacionada_Ingreso";

            var returnParameter = sqlc.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            sqlc.Parameters.Add("@CodPersonaRelacionada", SqlDbType.Int).Value = this.C_buscaPersonaRelacionada.CodPersonaRelacionada;
            sqlc.Parameters.Add("@icodie", SqlDbType.Int).Value = 1; 
            sqlc.Parameters.Add("@Confirmar", SqlDbType.Int).Value = confirmar;


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
                        this.C_modalPopUp.ShowMensaje("Confirmar Eliminar persona relacionada",
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
                        this.C_modalPopUp.ShowMensaje("Confirmar Eliminar persona relacionada",
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
    protected void registrolog()
    {
        SenainfoSdk.Log_mesa_ayuda logreg = new SenainfoSdk.Log_mesa_ayuda();

        logreg.Codproyecto = Convert.ToString(this.C_buscaPersonaRelacionada.CodProyecto);
        logreg.anomes = DateTime.Now.ToShortDateString();
        logreg.datoanexo = Convert.ToString(this.C_buscaPersonaRelacionada.CodPersonaRelacionada);
        logreg.mensaje = txt_comentarios.Text;
        logreg.msj_retorno_sp = this.msgsp;
        logreg.nombre_sp_ejecutado = "Mesa_Elimina_PersonaRelacionada_Ingreso";
        logreg.insertLog();
    }
    protected void C_modalPopUp_ResultadoPopup(object sender, SenainfoSdk.UI.ModelPopupResultEventArgs e)
    {
        if (e.ModalPopupResult == SenainfoSdk.UI.ModalPopupResult.Yes)
            this.ExecProcedimiento(1);
    }
    protected void btnlimpiar_Click(object sender, EventArgs e)
    {
        this.C_buscaPersonaRelacionada.MarcarRequeridos(false);
        txt_comentarios.CssClass = SenainfoSdk.UI.Util.RemoveCssClass(txt_comentarios.CssClass,"campo-obligatorio");
        C_msgAlerta.Hide();
        SenainfoSdk.UI.Util.CleanControl(this.Controls);
    }
    protected void C_buscaPersonaRelacionada_CodPersonaRelacionadaSeleccionadoCambio(object sender, EventArgs e)
    {

    }
}