using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mod_mesa_Elimina_plan_Intervencion : System.Web.UI.Page
{
    string msgsp = string.Empty;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
        {
            Response.Redirect("~/logout.aspx");
        }
        else
        {
            if (!window.existetoken("B173FDB7-B94D-4C93-9FF2-3396540F64EC"))
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

    protected void C_modalPopUp_ResultadoPopup(object sender, SenainfoSdk.UI.ModelPopupResultEventArgs e)
    {
        if (e.ModalPopupResult == SenainfoSdk.UI.ModalPopupResult.Yes)
            this.ExecProcedimiento(1);
    }

    protected void btnlimpiar_Click(object sender, EventArgs e)
    {
        this.Limpiar();
    }


    private bool EntradaValida()
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

        if (this.C_codplanIntervencion1.CodPlanIntervencion == 0)
        {
            valido = false;

            mensaje += "Debe Seleccionar un Plan de Intervención.";

            this.C_codplanIntervencion1.MarcarRequeridos(true);
        }
        else
            this.C_codplanIntervencion1.MarcarRequeridos(false);


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

    private void ExecProcedimiento(int confirmar)
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
            sqlc.CommandText = "Mesa_Elimina_PlanIntervencion";
            var returnParameter = sqlc.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            sqlc.Parameters.Add("@codplanintervencion", SqlDbType.Int).Value = this.C_codplanIntervencion1.CodPlanIntervencion;
            //sqlc.Parameters.Add("@elimina", SqlDbType.Int).Value = 1;
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
                        this.C_modalPopUp.ShowMensaje("Confirmar Eliminar Plan de Intervención",
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
                        this.C_modalPopUp.ShowMensaje("Confirmar Eliminar Plan de Intervención",
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

                this.C_codplanIntervencion1.Actualizar();
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

    private void registrolog()
    {
        SenainfoSdk.Log_mesa_ayuda logreg = new SenainfoSdk.Log_mesa_ayuda();
        logreg.Codproyecto = Convert.ToString(this.C_codplanIntervencion1.CodProyecto);
        logreg.anomes = DateTime.Now.ToShortDateString();
        logreg.datoanexo = Convert.ToString(this.C_codplanIntervencion1.CodPlanIntervencion);
        logreg.mensaje = txt_comentario.Text;
        logreg.msj_retorno_sp = msgsp;
        logreg.nombre_sp_ejecutado = "Mesa_Elimina_PlanIntervencion";
        logreg.insertLog();
    }

    private void Limpiar()
    {
        this.C_codplanIntervencion1.MarcarRequeridos(false);
        this.txt_comentario.Text = string.Empty;
        this.txt_comentario.CssClass = SenainfoSdk.UI.Util.RemoveCssClass(this.txt_comentario.CssClass,
            "campo-obligatorio");
        this.C_msgAlerta.Hide();

        SenainfoSdk.UI.Util.CleanControl(this.Controls);
    }
}