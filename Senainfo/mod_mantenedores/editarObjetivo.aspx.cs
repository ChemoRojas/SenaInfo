using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mod_mantenedores_editarObjetivo : System.Web.UI.Page
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

                string codobjetivo = Request.QueryString["CodObjetivo"].ToString();

                string consulta = "SELECT CodObjetivo,NombreObjetivo,Vigencia,RangoArea,CodArea FROM Objetivos where CodObjetivo =" + codobjetivo;
                DbDataReader datareader = null;
                Conexiones con = new Conexiones();
                con.ejecutar(consulta, out datareader);

                while (datareader.Read())
                {
                    try
                    {
                        txtCodObjetivo.Text = codobjetivo;
                        txtObjetivo.Text = (String)datareader["NombreObjetivo"];
                        ddownArea.SelectedValue = Convert.ToString((int)datareader["CodArea"]);
                        ddownRango.SelectedValue = Convert.ToString((int)datareader["RangoArea"]);
                        
                       

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
        if (txtObjetivo.Text == "" || ddownArea.SelectedValue == "0" || ddownRango.SelectedValue == "0")
        {
            alertW.Visible = true;
            alertS.Visible = false;
            
        }
        else
        {
            editarObjetivo();
        }
        
    }


    private void getAreasObjetivo()
    {


        parcoll par = new parcoll();
        DataView dv6 = new DataView(par.GetAreasObjetivo());
        ddownArea.DataSource = dv6;
        ddownArea.DataTextField = "NombreArea";
        ddownArea.DataValueField = "CodArea";
        dv6.Sort = "CodArea";
        ddownArea.DataBind();


    }


    private void editarObjetivo()
    {

        int returnvalue = 0;
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */
        Conexiones con = new Conexiones();
        DbParameter[] parametros = {
        con.parametros("@CodArea", SqlDbType.Int, 4, ddownArea.SelectedValue) , 
        con.parametros("@CodObjetivo", SqlDbType.Int, 4, txtCodObjetivo.Text) , 
		con.parametros("@NombreObjetivo", SqlDbType.VarChar, 30, txtObjetivo.Text),
		con.parametros("@Vigencia", SqlDbType.Int, 4, txtVigencia.Text),
        con.parametros("@RangoArea", SqlDbType.Int, 4, ddownRango.SelectedValue),
        con.parametros("@UsuarioModificacion", SqlDbType.VarChar, 30, Session["IdUsuario"].ToString())
		 
		//con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) 
		};
        con.ejecutarProcedimiento("Insert_Update_Objetivo", parametros, out datareader);
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