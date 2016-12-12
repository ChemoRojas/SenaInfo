using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mod_mantenedores_editarPreguntasModulo : System.Web.UI.Page
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


                getModulosActividades();

                string Codpreguntamodulo = Request.QueryString["CodPreguntaModulo"].ToString();

                string consulta = "SELECT CodPreguntaModulo,TextoPregunta,Vigencia,CodModulo FROM PreguntaModulo where CodPreguntaModulo =" + Codpreguntamodulo;
                DbDataReader datareader = null;
                Conexiones con = new Conexiones();
                con.ejecutar(consulta, out datareader);

                while (datareader.Read())
                {
                    try
                    {
                        txtCodPreguntaModulo.Text = Codpreguntamodulo;
                        txtPregunta.Text = (String)datareader["TextoPregunta"];
                        ddownModulo.SelectedValue = Convert.ToString((int)datareader["CodModulo"]);




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
        if (txtPregunta.Text == "" || ddownModulo.SelectedValue == "-2")
        {
            alertW.Visible = true;
            alertS.Visible = false;

        }
        else
        {
            editarPreguntaModulo();
        }

    }


    private void getModulosActividades()
    {


        parcoll par = new parcoll();
        DataView dv6 = new DataView(par.GetModulosActividades());
        ddownModulo.DataSource = dv6;
        ddownModulo.DataTextField = "NombreModulo";
        ddownModulo.DataValueField = "CodModulo";
        dv6.Sort = "CodModulo";
        ddownModulo.DataBind();


    }


    private void editarPreguntaModulo()
    {

        int returnvalue = 0;
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */
        Conexiones con = new Conexiones();
        DbParameter[] parametros = {
        con.parametros("@CodPreguntaModulo", SqlDbType.Int, 4, txtCodPreguntaModulo.Text) , 
        con.parametros("@CodModulo", SqlDbType.Int, 4, ddownModulo.SelectedValue) , 
		con.parametros("@TextoPregunta", SqlDbType.VarChar, 30, txtPregunta.Text),
		con.parametros("@Vigencia", SqlDbType.Int, 4, txtVigencia.Text),
        con.parametros("@UsuarioModificacion", SqlDbType.VarChar, 30, Session["IdUsuario"].ToString())
		 
		//con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) 
		};
        con.ejecutarProcedimiento("Insert_Update_PreguntaModulo", parametros, out datareader);
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