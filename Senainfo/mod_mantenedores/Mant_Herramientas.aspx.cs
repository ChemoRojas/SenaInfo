using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mod_mantenedores_Mant_Herramientas : System.Web.UI.Page
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

                // Do something
                alertS.Visible = false;
                alertW.Visible = false;

                try
                {
                    string codHerramienta = Request.QueryString["CodHerramienta"].ToString();

                    string consulta = "select CodHerramienta, NombreHerramienta, DescripcionHerramienta, Vigencia from Herramienta where CodHerramienta = " + codHerramienta;
                    DbDataReader datareader1 = null;
                    Conexiones con = new Conexiones();
                    con.ejecutar(consulta, out datareader1);

                    while (datareader1.Read())
                    {

                        String nombreAreaEliminar = (String)datareader1["NombreArea"];
                        int Vigencia = 0;

                        if (Convert.ToString((bool)datareader1["Vigencia"]) == "True")
                        {
                            Vigencia = 0;
                        }
                        else
                        {
                            Vigencia = 1;
                        }

                        datareader1.Close();

                        if (codHerramienta != "0" || codHerramienta != "")
                        {
                            int returnvalue = 0;
                            DbDataReader datareader = null;
                            /* Database db = new Database(objconn); */

                            DbParameter[] parametros = {
                                con.parametros("@CodHerramienta", SqlDbType.Int, 4, 0),
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
                                grabar.Visible = false;
                                txtCodHerramienta.Text = "";

                                grdBusqueda.DataSource = null;
                                grdBusqueda.DataBind();
                            }
                            else
                            {
                                alertS.Visible = false;
                                alertW.Visible = true;
                                grabar.Visible = false;
                                txtCodHerramienta.Text = "";

                                grdBusqueda.DataSource = null;
                                grdBusqueda.DataBind();
                            }
                        }
                        else
                        {
                            txtCodHerramienta.Text = "";
                        }

                    }
                }
                catch
                {

                }
            }
        }
    }

    private DataTable resultadoBusqueda(string CodHerramienta)
    {
        Conexiones con = new Conexiones();



        //System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + con.Servidor + " ;Database= " + con.Base + " ; User ID= " + con.Usuario + " ;Password= " + con.Passw + " ;Trusted_Connection=False");
        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "EXEC [dbo].[SP_getHerramientasBusqueda] '" + CodHerramienta + "' ";
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
        DataTable dt1 = resultadoBusqueda(txtCodHerramienta.Text);
        grdBusqueda.DataSource = dt1;
        grabar.Visible = false;

        grdBusqueda.DataBind();
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        txtCodHerramienta.Text = "";

        grdBusqueda.DataSource = null;
        grdBusqueda.DataBind();
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        grabar.Visible = true;
        txtCodHerramienta.Text = "";
        grdBusqueda.DataSource = null;
        grdBusqueda.DataBind();
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        guardarHerramienta();
    }

    private void guardarHerramienta()
    {
        int returnvalue = 0;

        DbDataReader dataReader = null;
        Conexiones con = new Conexiones();
        DbParameter[] parametros = {
            con.parametros("@CodHerramienta", SqlDbType.Int, 4, 0),
            con.parametros("@NombreHerramienta", SqlDbType.VarChar, 250, txtNombreHerramienta.Text),
            con.parametros("@DescripcionHerramienta", SqlDbType.Text, 250, txtDescripcionHerramienta.Text),
            con.parametros("@Vigencia", SqlDbType.Int, 4, 1),
            con.parametros("@UsuarioModificacion", SqlDbType.VarChar, 30, Session["IdUsuario"].ToString())
        };

        con.ejecutarProcedimiento("Insert_Update_Herramienta", parametros, out dataReader);

        if (dataReader.Read())
        {
            returnvalue = Convert.ToInt32(dataReader["retorno"]);
        }
        con.Desconectar();

        if (returnvalue == 0)
        {
            alertS.Visible = true;
            alertW.Visible = false;
            grabar.Visible = false;
            txtCodHerramienta.Text = "";

            grdBusqueda.DataSource = null;
            grdBusqueda.DataBind();
        }
        else
        {
            alertS.Visible = false;
            alertW.Visible = true;
            grabar.Visible = false;
            txtCodHerramienta.Text = "";

            grdBusqueda.DataSource = null;
            grdBusqueda.DataBind();
        }
    }
}