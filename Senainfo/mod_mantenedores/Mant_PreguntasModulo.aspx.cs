using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mod_mantenedores_Mant_PreguntasModulo : System.Web.UI.Page
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
        //string url_lupita1 = "bsc_institucion.aspx?param001=" + lbl001.Text + "&dir=reg_inmuebles.aspx&param002=SI";
        //A1.HRef = url_lupita1;

        //string url_lupita2 = "bsc_institucion.aspx?param001=" + lbl001.Text + "&dir=reg_inmuebles.aspx&codinst=" + ddown001.SelectedValue ;
        //A2.HRef = url_lupita2;

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

                alertS.Visible = false;
                alertW.Visible = false;
                alertEli.Visible = false;
                AlertNumero.Visible = false;
                getModulosActividades();

                //txtCodObjetivo.Text = Session["IdUsuario"].ToString();



                try
                {
                    string Codpreguntamodulo = Request.QueryString["CodPreguntaModulo"].ToString();

                    string consulta = "SELECT CodPreguntaModulo,TextoPregunta,Vigencia,CodModulo FROM PreguntaModulo where CodPreguntaModulo =" + Codpreguntamodulo;
                    DbDataReader datareader1 = null;
                    Conexiones con = new Conexiones();
                    con.ejecutar(consulta, out datareader1);

                    while (datareader1.Read())
                    {


                        int Vigencia = 0;

                        String TextoPregunta = (String)datareader1["TextoPregunta"];
                        String CodigoModulo = Convert.ToString((int)datareader1["CodModulo"]);




                        if (Convert.ToString((bool)datareader1["Vigencia"]) == "True")
                        {
                            Vigencia = 0;
                        }
                        else
                        {
                            Vigencia = 1;
                        }














                        datareader1.Close();

                        if (Codpreguntamodulo != "0" || Codpreguntamodulo != "")
                        {

                            if (Vigencia == 1)
                            {

                                string consultaContador = "SELECT count(*) as Contador FROM PreguntaModulo where Vigencia = 1 and CodModulo =" + Request["CodModulo"];
                                DbDataReader datareader2 = null;

                                con.ejecutar(consultaContador, out datareader2);

                                while (datareader2.Read())
                                {
                                    if ((int)datareader2["Contador"] >= 5)
                                    {

                                        AlertNumero.Visible = true;
                                        alertW.Visible = false;
                                        alertS.Visible = false;
                                        alertEli.Visible = false;


                                    }
                                    else
                                    {


                                        datareader2.Close();
                                        int returnvalue = 0;
                                        DbDataReader datareader = null;
                                        /* Database db = new Database(objconn); */

                                        DbParameter[] parametros = {
                                            con.parametros("@CodPreguntaModulo", SqlDbType.Int, 4, Codpreguntamodulo) , 
                                            con.parametros("@CodModulo", SqlDbType.Int, 4, CodigoModulo) , 
		                                    con.parametros("@TextoPregunta", SqlDbType.VarChar, 30, TextoPregunta),
		                                    con.parametros("@Vigencia", SqlDbType.Int, 4, Vigencia),
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

                                            alertEli.Visible = true;
                                            alertW.Visible = false;
                                            alertS.Visible = false;

                                        }
                                        else
                                        {
                                            alertEli.Visible = false;
                                            alertW.Visible = true;
                                            alertS.Visible = false;


                                        }

                                        



                                    }
                                }




                            }
                            else
                            {

                                int returnvalue = 0;
                                DbDataReader datareader = null;
                                /* Database db = new Database(objconn); */

                                DbParameter[] parametros = {
                                con.parametros("@CodPreguntaModulo", SqlDbType.Int, 4, Codpreguntamodulo) , 
                                con.parametros("@CodModulo", SqlDbType.Int, 4, CodigoModulo) , 
		                        con.parametros("@TextoPregunta", SqlDbType.VarChar, 30, TextoPregunta),
		                        con.parametros("@Vigencia", SqlDbType.Int, 4, Vigencia),
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

                                    alertEli.Visible = true;
                                    alertW.Visible = false;
                                    alertS.Visible = false;

                                }
                                else
                                {
                                    alertEli.Visible = false;
                                    alertW.Visible = true;
                                    alertS.Visible = false;


                                }
                            }
                        }
                      

                    }
                }
                catch
                {

                }





                validatescurity(); //LO ULTIMO DEL LOAD
            }
        }

    }

    private void validatescurity()
    {

        //2A3EE049-3FA8-43C1-B3A0-47D1D2299846 1.3_ELIMINAR
        if (!window.existetoken("2A3EE049-3FA8-43C1-B3A0-47D1D2299846"))
        {

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


    private void guardarPreguntaModulo()
    {

        int returnvalue = 0;
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */
        Conexiones con = new Conexiones();
        DbParameter[] parametros = {
        con.parametros("@CodPreguntaModulo", SqlDbType.Int, 4, 0) , 
        con.parametros("@CodModulo", SqlDbType.Int, 4, ddownModulo.SelectedValue) , 
		con.parametros("@TextoPregunta", SqlDbType.VarChar, 30, txtPregunta.Text),
		con.parametros("@Vigencia", SqlDbType.Int, 4, 1),
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

            grabar.Visible = false;
            txtCodPregunta.Text = "";

            grdBusqueda.DataSource = null;
            grdBusqueda.DataBind();

        }
        else
        {

            alertS.Visible = false;
            alertW.Visible = true;
            grabar.Visible = false;
            txtCodPregunta.Text = "";

            grdBusqueda.DataSource = null;
            grdBusqueda.DataBind();

        }






    }

    protected void WebImageButton1_Click(object sender, EventArgs e)
    {
        if (txtPregunta.Text == "" || ddownModulo.SelectedValue == "0")
        {
            alertW.Visible = true;
            alertS.Visible = false;
            alertEli.Visible = false;
        }
        else
        {
             string consulta = "SELECT count(*) as Contador FROM PreguntaModulo where Vigencia = 1 and CodModulo =" + ddownModulo.SelectedValue;
                    DbDataReader datareader = null;
                    Conexiones con = new Conexiones();
                    con.ejecutar(consulta, out datareader);

                    while (datareader.Read())
                    {
                        if ((int)datareader["Contador"] >= 5)
                        {
                            AlertNumero.Visible = true;
                            alertW.Visible = false;
                            alertS.Visible = false;
                            alertEli.Visible = false;
                        }
                        else
                        {
                            guardarPreguntaModulo();
                        }


                    }
            
        }


    }










    private void clean_Txt(TextBox Txt)
    {
        Txt.BackColor = System.Drawing.Color.Empty;
        Txt.Text = "";
    }




    private void funcion_limpiar()
    {
        clean_Txt(txtCodPregunta);
    }




    protected void WebImageButton2_Click(object sender, EventArgs e)
    {
        funcion_limpiar();
    }


    public void limpiarForm()
    {
        Response.Redirect("Mant_PreguntasModulo.aspx");
    }


    private DataTable resultadoBusqueda(string CodPreguntaModulo)
    {
        Conexiones con = new Conexiones();



        //System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + con.Servidor + " ;Database= " + con.Base + " ; User ID= " + con.Usuario + " ;Password= " + con.Passw + " ;Trusted_Connection=False");
        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "EXEC [dbo].[SP_getPreguntasModulo] '" + CodPreguntaModulo + "' ";
        //sqlc.Parameters.Add("@Rut", SqlDbType.VarChar, 4).Value = Rut;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        DataTable dt1 = resultadoBusqueda(txtCodPregunta.Text);
        grdBusqueda.DataSource = dt1;
        grabar.Visible = false;

        grdBusqueda.DataBind();
    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        txtCodPregunta.Text = "";

        grdBusqueda.DataSource = null;
        grdBusqueda.DataBind();
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        grabar.Visible = true;
        txtCodPregunta.Text = "";

        grdBusqueda.DataSource = null;
        grdBusqueda.DataBind();
    }






}