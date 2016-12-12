using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mod_mesa_Regenerar_10_ActualizaFecha : System.Web.UI.Page
{
    string msgsp = string.Empty;
    //  string date = string.Empty;
    public string date
    {
        get { return (string)Session["CODEVENTPROYECTO"]; }
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
            if (!window.existetoken("DDDC8BAF-A5C2-420D-930F-CC8D89BBAA7E"))
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
        //if (txt_comentario.Text != "" && this.C_seleccionIcodie1.ICodIE != SenainfoSdk.UI.AllInOne.ICodIEEmpty)
        //{
        //    this.ExecProcedimiento(0);
        //}
        //else
        //{
        //    if (txt_comentario.Text == "")
        //    {
        //        this.C_msgAlerta.Show("Debe Ingresar un comentario...",
        //             SenainfoSdk.UI.TipoMsgAlerta.Warning,
        //             false);
        //    }
        //    else if (this.C_seleccionIcodie1.ICodIE == SenainfoSdk.UI.AllInOne.ICodIEEmpty)
        //    {
        //        this.C_msgAlerta.Show("Debe Ingresar un comentario...",
        //                           SenainfoSdk.UI.TipoMsgAlerta.Warning,
        //                           false);
        //    }
        //    if (string.IsNullOrWhiteSpace(txt_comentario.Text))
        //    {
        //        txt_comentario.CssClass = SenainfoSdk.UI.Util.AddCssClass(txt_comentario.CssClass,
        //            "campo-obligatorio");
        //    }
        //    else
        //    {
        //        txt_comentario.CssClass = SenainfoSdk.UI.Util.RemoveCssClass(txt_comentario.CssClass,
        //            "campo-obligatorio");
        //    }

        //    this.C_seleccionIcodie1.MarcarRequeridos(true);
        //}
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

        if (this.C_seleccionIcodie1.CodProyecto == 0)
        {
            valido = false;

            mensaje += "Debe seleccionar un proyecto.";

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
    protected void rv_fecha_Init(object sender, EventArgs e)
    {
        ((RangeValidator)sender).MaximumValue = DateTime.Today.ToString("dd-MM-yyyy");
        ((RangeValidator)sender).MinimumValue = "01-01-1900";

    }
    public void ExecProcedimiento(int confirmar)
    {
        int resultado;
        string str_error = "";
        DateTime fecha = Convert.ToDateTime(cal_inicio.Text);
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
            sqlc.CommandText = "Mesa_Regenerar_10_ActualizaFecha";
            var returnParameter = sqlc.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            sqlc.Parameters.Add("@icodie", SqlDbType.Int).Value = this.C_seleccionIcodie1.ICodIE;
            sqlc.Parameters.Add("@FechaIngresoNueva", SqlDbType.DateTime).Value = fecha;
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
                        this.C_modalPopUp.ShowMensaje("Confirmar Abrir Egreso",
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
                        this.C_modalPopUp.ShowMensaje("Confirmar Abrir Egreso",
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
        logreg.Codproyecto = Convert.ToString(this.C_seleccionIcodie1.CodProyecto);
        logreg.anomes = DateTime.Now.ToShortDateString();
        logreg.datoanexo = Convert.ToString(this.C_seleccionIcodie1.ICodIE);
        logreg.mensaje = txt_comentario.Text;
        logreg.msj_retorno_sp = msgsp;
        logreg.nombre_sp_ejecutado = "Mesa_Regenerar_10_ActualizaFecha";
        logreg.insertLog();
    }

    protected void cal_inicio_TextChanged(object sender, EventArgs e)
    {
        DateTime fechaaux = Convert.ToDateTime(cal_inicio.Text);
        date = string.Format("{0:yyyy-MM-dd}", fechaaux).Replace("-", "");
    }


    protected void btnlimpiar_Click(object sender, EventArgs e)
    {
        this.C_msgAlerta.Hide();
        txt_comentario.CssClass = SenainfoSdk.UI.Util.RemoveCssClass(txt_comentario.CssClass,
         "campo-obligatorio");
        SenainfoSdk.UI.Util.CleanControl(this.Controls);
        this.C_seleccionIcodie1.MarcarRequeridos(false);
    }

    protected void C_modalPopUp_ResultadoPopup(object sender, SenainfoSdk.UI.ModelPopupResultEventArgs e)
    {
        if (e.ModalPopupResult == SenainfoSdk.UI.ModalPopupResult.Yes)
            this.ExecProcedimiento(1);
    }
}