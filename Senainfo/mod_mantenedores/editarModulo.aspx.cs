using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mod_mantenedores_editarModulo : System.Web.UI.Page
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


                getAreasObjetivo();

                string codmodulo = Request.QueryString["CodModulo"].ToString();

                string consulta = "SELECT CodModulo,NombreModulo,Vigencia,CodObjetivo FROM Modulo where CodModulo =" + codmodulo;
                DbDataReader datareader = null;
                Conexiones con = new Conexiones();
                con.ejecutar(consulta, out datareader);

                while (datareader.Read())
                {
                    try
                    {
                        txtCodModulo.Text = codmodulo;
                        txtModulo.Text = (String)datareader["NombreModulo"];
                        ddownObjetivo.SelectedValue = Convert.ToString((int)datareader["CodObjetivo"]);
                        



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
        if (txtModulo.Text == "" || ddownObjetivo.SelectedValue == "0")
        {
            alertW.Visible = true;
            alertS.Visible = false;

        }
        else
        {
            editarModulo();
        }

    }


    private void getAreasObjetivo()
    {


        parcoll par = new parcoll();
        DataView dv6 = new DataView(par.GetObjetivoModulos());
        ddownObjetivo.DataSource = dv6;
        ddownObjetivo.DataTextField = "NombreObjetivo";
        ddownObjetivo.DataValueField = "CodObjetivo";
        dv6.Sort = "CodObjetivo";
        ddownObjetivo.DataBind();


    }


    private void editarModulo()
    {

        int returnvalue = 0;
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */
        Conexiones con = new Conexiones();
        DbParameter[] parametros = {
        con.parametros("@CodModulo", SqlDbType.Int, 4, txtCodModulo.Text) , 
        con.parametros("@CodObjetivo", SqlDbType.Int, 4, ddownObjetivo.SelectedValue) , 
		con.parametros("@NombreModulo", SqlDbType.VarChar, 30, txtModulo.Text),
		con.parametros("@Vigencia", SqlDbType.Int, 4, txtVigencia.Text),
        con.parametros("@UsuarioModificacion", SqlDbType.VarChar, 30, Session["IdUsuario"].ToString())
		 
		//con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) 
		};
        con.ejecutarProcedimiento("Insert_Update_Modulo", parametros, out datareader);
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