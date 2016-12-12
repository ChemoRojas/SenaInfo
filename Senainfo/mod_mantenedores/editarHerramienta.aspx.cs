using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mod_mantenedores_editarHerramienta : System.Web.UI.Page
{
    public int vCodPaso
    {
        get { return (int)Session["vCodPaso"]; }
        set { Session["vCodPaso"] = value; }
    }
    public string vsBuscaEspecifica
    {
        get { return (string)Session["vsBuscaEspecifica"]; }
        set { Session["vsBuscaEspecifica"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
            {
                Response.Redirect("~/logout.aspx");
            }
            else
            {
                if (!window.existetoken("54E1332C-4FD5-4034-8596-E097C6CFA58C"))
                {
                    Response.Redirect("~/logout.aspx");
                }

                string codHerramienta = Request.QueryString["CodHerramienta"].ToString();

                string consulta = "select CodHerramienta, NombreHerramienta, DescripcionHerramienta, Vigencia from Herramienta where CodHerramienta = " + codHerramienta;

                DbDataReader datareader = null;
                Conexiones con = new Conexiones();
                con.ejecutar(consulta, out datareader);

                while (datareader.Read())
                {
                    try
                    {
                        txtCodHerramienta.Text = codHerramienta;
                        txtNombreHerramienta.Text = (String)datareader["NombreHerramienta"];
                        txtDescripcionHerramienta.Text = (String)datareader["DescripcionHerramienta"];
                        




                        if (Convert.ToString((bool)datareader["Vigencia"]) == "True")
                        {
                            txtVigencia.Text = "1";
                        }
                        else
                        {
                            txtVigencia.Text = "0";
                        }


                    }
                    catch { }
                }
                con.Desconectar();






            }
        }

    }
    protected void WebImageButton1_Click(object sender, EventArgs e)
    {
        if (txtNombreHerramienta.Text == "" || txtDescripcionHerramienta.Text == "")
        {
            alertW.Visible = true;
            alertS.Visible = false;

        }
        else
        {
            editarObjetivo();
        }

    }


   


    private void editarObjetivo()
    {

        int returnvalue = 0;
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */
        Conexiones con = new Conexiones();
        DbParameter[] parametros = {
            con.parametros("@CodHerramienta", SqlDbType.Int, 4, txtCodHerramienta.Text),
            con.parametros("@NombreHerramienta", SqlDbType.VarChar, 250, txtNombreHerramienta.Text),
            con.parametros("@DescripcionHerramienta", SqlDbType.Text, 250, txtDescripcionHerramienta.Text),
            con.parametros("@Vigencia", SqlDbType.Int, 4, 1),
            con.parametros("@UsuarioModificacion", SqlDbType.VarChar, 30, Session["IdUsuario"].ToString())
        };

        con.ejecutarProcedimiento("Insert_Update_Herramienta", parametros, out datareader);
        if (datareader.Read())
        {
            returnvalue = Convert.ToInt32(datareader["retorno"]);
        }
        con.Desconectar();
        if (returnvalue == 0)
        {
            alertS.Visible = true;
            alertW.Visible = false;
        }
        else
        {
            alertS.Visible = false;
            alertW.Visible = true;
        }
    }
}