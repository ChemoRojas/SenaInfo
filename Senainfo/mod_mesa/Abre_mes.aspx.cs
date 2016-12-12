using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mod_mesa_Abre_mes : System.Web.UI.Page
{
    private string msgsp;
    protected void Page_Load(object sender, EventArgs e)    
    {
        if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
        {
            Response.Redirect("~/logout.aspx");
        }
        {
            if (!window.existetoken("470569C5-7672-4D14-9A0C-AD58A84B3786"))
            {
                Response.Redirect("~/e403.aspx");
            }
        }
        if (!IsPostBack)
        {
            this.Limpiar();

            int ano = DateTime.Now.Year;
            for (int a = ano; a >= (ano - 3); a--) 
            {
                ddl_anios.Items.Add(a.ToString());

            }
        }
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
            string fecha = ddl_anios.SelectedValue + ddl_mes.SelectedValue;
            sqlc.Connection = sconn;
            sqlc.CommandType = System.Data.CommandType.StoredProcedure;
            sqlc.CommandText = "Mesa_Abre_Mes";

            var returnParameter = sqlc.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            sqlc.Parameters.Add("@codproyecto", SqlDbType.Int).Value = this.C_buscar_x_institu_proyecto.CodProyectoSeleccionado;
            sqlc.Parameters.Add("@Periodo", SqlDbType.Int).Value = fecha;
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
                        this.C_modalPopUp.ShowMensaje("Confirmar Abrir Mes",
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
                        this.C_modalPopUp.ShowMensaje("Confirmar Abrir Mes",
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

                this.txt_comentarios.Text = string.Empty;
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
        logreg.Codproyecto = Convert.ToString(this.C_buscar_x_institu_proyecto.CodProyectoSeleccionado);
        logreg.anomes = DateTime.Now.ToShortDateString();
        logreg.datoanexo = "";
        logreg.mensaje = txt_comentarios.Text;
        logreg.msj_retorno_sp = this.msgsp;
        logreg.nombre_sp_ejecutado = "Mesa_Abre_Mes";
        logreg.insertLog();
    }
    protected void C_buscar_x_institu_proyecto1_CodProyectoSeleccionadoCambio(object sender, EventArgs e)
    {
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

        if (this.C_buscar_x_institu_proyecto.CodProyectoSeleccionado == 0)
        {
            valido = false;

            mensaje += "Debe seleccionar un proyecto.";

            this.C_buscar_x_institu_proyecto.MarcarRequeridos(true);
        }
        else
            this.C_buscar_x_institu_proyecto.MarcarRequeridos(false);


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
    protected void C_modalPopUp_ResultadoPopup(object sender, SenainfoSdk.UI.ModelPopupResultEventArgs e)
    {
        if (e.ModalPopupResult == SenainfoSdk.UI.ModalPopupResult.Yes)
            this.ExecProcedimiento(1);
    }
    protected void btnlimpiar_Click(object sender, EventArgs e)
    {
        this.Limpiar();
    }

    protected void Limpiar()
    {
        this.C_buscar_x_institu_proyecto.MarcarRequeridos(false);
        txt_comentarios.CssClass = SenainfoSdk.UI.Util.RemoveCssClass(txt_comentarios.CssClass,
         "campo-obligatorio");
        C_msgAlerta.Hide();
        SenainfoSdk.UI.Util.CleanControl(this.Controls);
    }

}