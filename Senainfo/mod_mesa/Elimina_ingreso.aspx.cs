using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class mod_mesa_Elimina_ingreso : System.Web.UI.Page
{
    private string msgsp = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
        {
            Response.Redirect("~/logout.aspx");
        }
        else
        {
            if (!window.existetoken("4A063DD1-4F59-43BF-AE95-9C60F4724169"))
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

            mensaje += "Debe Ingresar un Comentario. ";

            txt_comentario.CssClass = SenainfoSdk.UI.Util.AddCssClass(txt_comentario.CssClass,
                    "campo-obligatorio");
        }
        else
        {
            txt_comentario.CssClass = SenainfoSdk.UI.Util.RemoveCssClass(txt_comentario.CssClass,
                    "campo-obligatorio");
        }

        if (this.C_seleccionIcodie1.CodProyecto == 0)
        {
            valido = false;

            mensaje += "Debe Seleccionar un Proyecto.";

            this.C_seleccionIcodie1.MarcarRequeridos(true);
        }
        else
            this.C_seleccionIcodie1.MarcarRequeridos(false);


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
            msgsp += e.Message.Replace(System.Environment.NewLine, "<br />") + "<br />";

        };
        try
        {
            sqlc.Connection = sconn;
            sqlc.CommandType = System.Data.CommandType.StoredProcedure;
            sqlc.CommandText = "Mesa_Elimina_Ingreso";
            var returnParameter = sqlc.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            sqlc.Parameters.Add("@icodie", SqlDbType.Int).Value = this.C_seleccionIcodie1.ICodIE;
            sqlc.Parameters.Add("@Confirmar", SqlDbType.Int).Value = confirmar;
            this.msgsp = string.Empty;

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
                        this.C_modalPopUp.ShowMensaje("Confirmar Eliminar Ingreso",
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
                        this.C_modalPopUp.ShowMensaje("Confirmar Eliminar Ingreso",
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
                registrolog();
                
                this.C_seleccionIcodie1.Actualizar();
                this.txt_comentario.Text = string.Empty;
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
        logreg.Codproyecto = Convert.ToString(this.C_seleccionIcodie1.CodProyecto);
        logreg.anomes = DateTime.Now.ToShortDateString();
        logreg.datoanexo = "";
        logreg.mensaje = txt_comentario.Text;
        logreg.msj_retorno_sp = msgsp;
        logreg.nombre_sp_ejecutado = "Mesa_Elimina_Ingreso";
        logreg.insertLog();
    }

    protected void C_seleccionIcodie1_ICODIECambio(object sender, EventArgs e)
    {
        btn_ejecutar.Enabled = C_seleccionIcodie1.ICodIE != SenainfoSdk.UI.AllInOne.ICodIEEmpty;
       
    }

    protected void C_modalPopUp_ResultadoPopup(object sender, SenainfoSdk.UI.ModelPopupResultEventArgs e)
    {
        if (e.ModalPopupResult == SenainfoSdk.UI.ModalPopupResult.Yes)
            this.ExecProcedimiento(1);
    }

    protected void Limpiar()
    {
        this.C_msgAlerta.Hide();
        SenainfoSdk.UI.Util.CleanControl(this.Controls);
        this.txt_comentario.CssClass = SenainfoSdk.UI.Util.RemoveCssClass(txt_comentario.CssClass,
         "campo-obligatorio");
        this.C_seleccionIcodie1.MarcarRequeridos(false);
    }

    protected void btnlimpiar_Click(object sender, EventArgs e)
    {
        this.Limpiar();
    }
}