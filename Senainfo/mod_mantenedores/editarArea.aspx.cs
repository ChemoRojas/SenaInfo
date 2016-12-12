using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mod_mantenedores_editarArea : System.Web.UI.Page
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

                string codarea = Request.QueryString["CodArea"].ToString();

                string consulta = "select CodArea, NombreArea, Vigencia from Area where CodArea = "+ codarea;
                DbDataReader datareader = null;
                Conexiones con = new Conexiones();
                con.ejecutar(consulta, out datareader);

                while (datareader.Read())
                {
                    try
                    {
                        txtAreaEditar.Text = (String)datareader["NombreArea"];
                        txtCodArea.Text = Convert.ToString((int)datareader["CodArea"]);

                        if (Convert.ToString((bool)datareader["Vigencia"]) == "True")
                        {
                            txtVigencia.Text = "1";
                        }
                        else
                        {
                            txtVigencia.Text = "2";
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
        editarArea();
    }


    private void editarArea()
    {

        int returnvalue = 0;
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */
        Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@CodArea", SqlDbType.Int, 4, txtCodArea.Text) , 
        con.parametros("@NombreArea", SqlDbType.VarChar, 30, txtAreaEditar.Text),
		con.parametros("@Vigencia", SqlDbType.Int, 4, txtVigencia.Text)  
		 
		//con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) 
		};
        con.ejecutarProcedimiento("Insert_Update_Area", parametros, out datareader);
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