using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mod_mantenedores_Mant_Calendario : System.Web.UI.Page
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
                alertafechainiciomayor.Visible = false;
                getModulosActividades();
                getinstituciones();


                //txtCodObjetivo.Text = Session["IdUsuario"].ToString();



                try
                {
                    string codcalendario = Request.QueryString["CodCalendario"].ToString();

                    string consulta = "SELECT CodCalendario, CodModulo, FechaInicioModulo, FechaFinModulo, ResponsableModulo, Institucion, Vigencia FROM CalendarioModulo where CodCalendario =" + codcalendario;
                    DbDataReader datareader1 = null;
                    Conexiones con = new Conexiones();
                    con.ejecutar(consulta, out datareader1);

                    while (datareader1.Read())
                    {


                        int Vigencia = 0;

                        String CodigoCalendario = Convert.ToString((int)datareader1["CodCalendario"]);
                        String CodigoModulo = Convert.ToString((int)datareader1["CodModulo"]);
                        DateTime FechaInicio = Convert.ToDateTime(datareader1["FechaInicioModulo"]);
                        DateTime FechaFin = Convert.ToDateTime(datareader1["FechaFinModulo"]);
                        String CodigoResponsable = Convert.ToString((int)datareader1["ResponsableModulo"]);
                        String CodigoInstitucion = Convert.ToString((int)datareader1["Institucion"]);





                        if (Convert.ToString((bool)datareader1["Vigencia"]) == "True")
                        {
                            Vigencia = 0;
                        }
                        else
                        {
                            Vigencia = 1;
                        }














                        datareader1.Close();

                        if (codcalendario != "0" || codcalendario != "")
                        {
                            int returnvalue = 0;
                            DbDataReader datareader = null;
                            /* Database db = new Database(objconn); */

                            DbParameter[] parametros = {
                            con.parametros("@CodCalendario", SqlDbType.Int, 4, codcalendario) , 
                            con.parametros("@CodModulo", SqlDbType.Int, 4, CodigoModulo) , 
		                    con.parametros("@FechaInicioModulo", SqlDbType.Date, 30, FechaInicio),
                            con.parametros("@FechaFinModulo", SqlDbType.Date, 30, FechaFin),
                            con.parametros("@Institucion", SqlDbType.Int, 4, CodigoInstitucion) , 
                            con.parametros("@ResponsableModulo", SqlDbType.Int, 4, CodigoResponsable) , 
                            con.parametros("@Estado", SqlDbType.Int, 4, 1) , 
		                    con.parametros("@Vigencia", SqlDbType.Int, 4, Vigencia),
                            con.parametros("@UsuarioModificacion", SqlDbType.VarChar, 30, Session["IdUsuario"].ToString())
		 
		                    //con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) 
		                    };
                            con.ejecutarProcedimiento("Insert_Update_CalendarioModulo", parametros, out datareader);
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
                        else
                        {
                            //txtCodArea.Text = "";
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

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        txtFechaInicio.Text = CalFechaInicio.SelectedDate.ToString();
        CalFechaInicio.Visible = false;
        if (txtFechaFin.Text != "")
        {
            if (Convert.ToDateTime(txtFechaInicio.Text) > Convert.ToDateTime(txtFechaFin.Text))
            {
                alertafechainiciomayor.Visible = true;
                txtFechaInicio.Text = "";
                txtFechaFin.Text = "";

            }
        }


    }
    protected void btnFechaInicio_Click(object sender, EventArgs e)
    {
        CalFechaInicio.Visible = true;
    }

    protected void Calendar2_SelectionChanged(object sender, EventArgs e)
    {

        txtFechaFin.Text = CalFechaFin.SelectedDate.ToString();
        CalFechaFin.Visible = false;

        if (txtFechaInicio.Text != "")
        {
            if (Convert.ToDateTime(txtFechaInicio.Text) > Convert.ToDateTime(txtFechaFin.Text))
            {
                alertafechainiciomayor.Visible = true;
                txtFechaInicio.Text = "";
                txtFechaFin.Text = "";

            }
        }
        



        
    }
    protected void btnFechaFin_Click(object sender, EventArgs e)
    {
        CalFechaFin.Visible = true;
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

    private void getinstituciones()
    {

        institucioncoll ncoll = new institucioncoll();
        DataView dv1 = new DataView(ncoll.GetData(Convert.ToInt32(Session["IdUsuario"])));
        ddownInstitucion.DataSource = dv1;
        ddownInstitucion.DataTextField = "Nombre";
        ddownInstitucion.DataValueField = "CodInstitucion";
        dv1.Sort = "Nombre";
        DataBind();


    }

    private void getProfesionales()
    {
        if (ddownInstitucion.SelectedValue != "0")
        {
            parcoll par = new parcoll();
            DataView dv1 = new DataView(par.Profesionales(Convert.ToInt32(ddownInstitucion.SelectedValue)));
            ddownProfesional.DataSource = dv1;
            ddownProfesional.DataTextField = "Nombres";
            ddownProfesional.DataValueField = "ICodTrabajador";
            dv1.Sort = "Nombres";
            DataBind();
        }
    }


    private void guardarCalendarioModulo()
    {

        int returnvalue = 0;
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */
        Conexiones con = new Conexiones();
        DbParameter[] parametros = {
        con.parametros("@CodCalendario", SqlDbType.Int, 4, 0) , 
        con.parametros("@CodModulo", SqlDbType.Int, 4, ddownModulo.SelectedValue) , 
		con.parametros("@FechaInicioModulo", SqlDbType.Date, 30, txtFechaInicio.Text),
        con.parametros("@FechaFinModulo", SqlDbType.Date, 30, txtFechaFin.Text),
        con.parametros("@Institucion", SqlDbType.Int, 4, ddownInstitucion.SelectedValue) , 
        con.parametros("@ResponsableModulo", SqlDbType.Int, 4, ddownProfesional.SelectedValue) , 
        con.parametros("@Estado", SqlDbType.Int, 4, 1) , 
		con.parametros("@Vigencia", SqlDbType.Int, 4, 1),
        con.parametros("@UsuarioModificacion", SqlDbType.VarChar, 30, Session["IdUsuario"].ToString())
		 
		//con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) 
		};
        con.ejecutarProcedimiento("Insert_Update_CalendarioModulo", parametros, out datareader);
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
            txtCodCalendario.Text = "";

            grdBusqueda.DataSource = null;
            grdBusqueda.DataBind();

        }
        else
        {

            alertS.Visible = false;
            alertW.Visible = true;
            grabar.Visible = false;
            txtCodCalendario.Text = "";

            grdBusqueda.DataSource = null;
            grdBusqueda.DataBind();

        }






    }

    protected void WebImageButton1_Click(object sender, EventArgs e)
    {
        if (ddownInstitucion.SelectedValue == "0" || ddownModulo.SelectedValue == "-2" || ddownProfesional.SelectedValue == "0" || txtFechaInicio.Text == "" || txtFechaFin.Text == "")
        {
            alertW.Visible = true;
            alertS.Visible = false;
            alertEli.Visible = false;
        }
        else
        {
            guardarCalendarioModulo();
        }


    }

    protected void mostrar_profesionales(object sender, EventArgs e)
    {

        getProfesionales();

    }










    private void clean_Txt(TextBox Txt)
    {
        Txt.BackColor = System.Drawing.Color.Empty;
        Txt.Text = "";
    }




    private void funcion_limpiar()
    {
        clean_Txt(txtCodCalendario);
    }




    protected void WebImageButton2_Click(object sender, EventArgs e)
    {
        funcion_limpiar();
    }


    public void limpiarForm()
    {
        Response.Redirect("Mant_Modulos.aspx");
    }


    private DataTable resultadoBusqueda(string CodCalendario)
    {
        Conexiones con = new Conexiones();



        //System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + con.Servidor + " ;Database= " + con.Base + " ; User ID= " + con.Usuario + " ;Password= " + con.Passw + " ;Trusted_Connection=False");
        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "EXEC [dbo].[SP_getCalendarioBusqueda] '" + CodCalendario + "' ";
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
        DataTable dt1 = resultadoBusqueda(txtCodCalendario.Text);
        grdBusqueda.DataSource = dt1;
        grabar.Visible = false;

        grdBusqueda.DataBind();
    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        txtCodCalendario.Text = "";

        grdBusqueda.DataSource = null;
        grdBusqueda.DataBind();
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        grabar.Visible = true;
        txtCodCalendario.Text = "";

        grdBusqueda.DataSource = null;
        grdBusqueda.DataBind();
    }






}