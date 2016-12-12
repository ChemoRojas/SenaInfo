using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mod_mantenedores_Mant_RespuestasDiagnostico : System.Web.UI.Page
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
                getAreasObjetivo();

                try
                {
                    string codPregunta = Request.QueryString["CodPregunta"].ToString();

                    string consulta = "select CodPregunta, Texto, CodArea, Orden, Puntaje, Tipo, Vigencia from PreguntaDisgnostico where PreguntaPadre = " + codPregunta;
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
                        /*
                        if (codHerramienta != "0" || codHerramienta != "")
                        {
                            
                            int returnvalue = 0;
                            DbDataReader datareader = null;

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
                        else
                        {
                            txtCodPregunta.Text = "";
                        }
*/
                    }
                }
                catch
                {

                }
            }
        }
    }

    private void getAreasObjetivo()
    {


        parcoll par = new parcoll();
        DataView dv6 = new DataView(par.GetAreasObjetivo());
        CodAreaPregunta.DataSource = dv6;
        CodAreaPregunta.DataTextField = "NombreArea";
        CodAreaPregunta.DataValueField = "CodArea";
        dv6.Sort = "CodArea";
        CodAreaPregunta.DataBind();


    }

    private DataTable resultadoBusqueda(string CodPregunta)
    {
        Conexiones con = new Conexiones();



        //System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + con.Servidor + " ;Database= " + con.Base + " ; User ID= " + con.Usuario + " ;Password= " + con.Passw + " ;Trusted_Connection=False");
        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "EXEC [dbo].[SP_getPreguntasDiagnosticoBusqueda] '" + CodPregunta + "' ";
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
        DataTable dt1 = resultadoBusqueda(txtCodRespuesta.Text);
        grdBusqueda.DataSource = dt1;
        grabar.Visible = false;

        grdBusqueda.DataBind();
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        txtCodRespuesta.Text = "";

        grdBusqueda.DataSource = null;
        grdBusqueda.DataBind();
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        grabar.Visible = true;
        txtCodRespuesta.Text = "";
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
            con.parametros("@CodPregunta", SqlDbType.Int, 4, 0),
            con.parametros("@Texto", SqlDbType.VarChar, 250, txtTextoPregunta.Text),
            con.parametros("@CodArea", SqlDbType.Text, 250, CodAreaPregunta.SelectedValue),
            con.parametros("@PreguntaPadre", SqlDbType.Int, 4, DBNull.Value),
            con.parametros("@Orden", SqlDbType.Int, 4, txtOrdenPregunta.Text),
            con.parametros("@Puntaje", SqlDbType.Int, 4, DBNull.Value),
            con.parametros("@Tipo", SqlDbType.Int, 4, txtTipoPregunta.Text),
            con.parametros("@Vigencia", SqlDbType.Int, 4, 1),
            con.parametros("@UsuarioModificacion", SqlDbType.VarChar, 30, Session["IdUsuario"].ToString())
        };

        con.ejecutarProcedimiento("Insert_Update_PreguntaDiagnostico", parametros, out dataReader);

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
            txtCodRespuesta.Text = "";

            grdBusqueda.DataSource = null;
            grdBusqueda.DataBind();
        }
        else
        {
            alertS.Visible = false;
            alertW.Visible = true;
            grabar.Visible = false;
            txtCodRespuesta.Text = "";

            grdBusqueda.DataSource = null;
            grdBusqueda.DataBind();
        }
    }
}