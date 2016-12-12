using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EncuestaEMAIL : System.Web.UI.Page
{
    System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9");
    int cod_institucion = 0;
    int cod_proyecto = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        Conexiones con = new Conexiones();
        try
        {
            DbDataReader datareader = null;
            string sql = Resources.Procedures.GetProyectoxIdusuario + Session["IdUsuario"];
            con.ejecutar(sql, out datareader);

            while (datareader.Read())
            {
                try
                {
                    //cod_institucion = (int)datareader["CodInstitucion"];
                    //cod_proyecto = (int)datareader["CodProyecto"];
                    if (datareader["CodInstitucion"].ToString() != "") { cod_proyecto = (int)datareader["CodInstitucion"]; }
                    if (datareader["CodProyecto"].ToString() != "") { cod_proyecto = (int)datareader["CodProyecto"]; }
                }
                catch { }
            }
            datareader.Close();
        }
        catch { }
        

        DataTable dt = con.TraerDataTable("PA_Get_Contesto_Proyecto", 23, cod_proyecto);
        con.Desconectar();
        if (dt.Rows.Count != 0)
        {
            Response.Redirect("index.aspx");
        }
        

    }

    protected void lnb_grabar_Click(object sender, EventArgs e)
    {
        if (txt_nombrerepleg.Text == "" || txt_email.Text == "" || txt_telefono.Text == "" || txt_direccion.Text == "")
        {
            alerts.Visible = true;
            lb_mensaje.Text = "Debe completar todos los campos.";
            lb_mensaje.Visible = true;
        }
        else
        {
            string resultado = grabarDatos();
            if (resultado == "OK")
            {
                Response.Redirect("index.aspx");
            }
            else
            {
                alerts.Visible = true;
                lb_mensaje.Text = "Hubo un error al grabar, intente nuevamente.";
                lb_mensaje.Visible = true;
            }
        }

    }

    protected void lbn_Limpiar_Click(object sender, EventArgs e)
    {
        txt_nombrerepleg.Text = string.Empty;
        txt_email.Text = string.Empty;
        txt_telefono.Text = string.Empty;
        txt_direccion.Text = string.Empty;
    }

    protected string grabarDatos()
    {
        string respuesta = string.Empty;
        
        Conexiones con = new Conexiones();
        try
        {
            DbDataReader datareader = null;
            string sql = Resources.Procedures.GetProyectoxIdusuario + Session["IdUsuario"];
            con.ejecutar(sql, out datareader);

            while (datareader.Read())
            {
                try
                {
                    //cod_institucion = (int)datareader["CodInstitucion"];
                    //cod_proyecto = (int)datareader["CodProyecto"];
                    if (datareader["CodInstitucion"].ToString() != "")
                    {
                        cod_proyecto = (int)datareader["CodInstitucion"];
                    }

                    if (datareader["CodProyecto"].ToString() != "")
                    {
                        cod_proyecto = (int)datareader["CodProyecto"];
                    }
                }
                catch { }
            }

            string sql1 = "INSERT INTO EncuestaEMAIL VALUES (" + Session["IdUsuario"] + ", " + cod_institucion + ", getdate(), '" + txt_nombrerepleg.Text.Trim().ToString() + "', '" + txt_email.Text.Trim().ToString() + "', '" + txt_telefono.Text.Trim().ToString() + "', '" + txt_direccion.Text.Trim().ToString() + "')";
            con.ejecutar(sql1);

            string sql2 = "INSERT INTO EncuestasUsuarios (CodEncuestas, IdUsuario, CodProyecto) VALUES (23, " + Convert.ToString(Session["IdUsuario"]) + ", " + cod_proyecto + ")";
            con.ejecutar(sql2);

            respuesta = "OK";
        }
        catch (Exception e)
        {
            respuesta = "ERROR: " + e;
        }
        con.Desconectar();
        return respuesta;

        //Conexiones con = new Conexiones();
        //List<DbParameter> listDbParameter = new List<DbParameter>();
        //string sql = Resources.Procedures.GetVigencia_Usuario + "@puser";

        //listDbParameter.Add(Conexiones.CrearParametro("@puser", SqlDbType.VarChar, 30, txt_nombrerepleg.Text.Trim().ToString()));

        //con.ejecutar(sql, listDbParameter);
    }
}