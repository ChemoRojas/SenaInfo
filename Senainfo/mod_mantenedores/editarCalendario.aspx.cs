using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mod_mantenedores_editarCalendario : System.Web.UI.Page
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
                getinstituciones();
                

                string codcalendario = Request.QueryString["CodCalendario"].ToString();

                string consulta = "SELECT CodCalendario, CodModulo, FechaInicioModulo, FechaFinModulo, ResponsableModulo, Institucion, Vigencia FROM CalendarioModulo where CodCalendario =" + codcalendario;
                DbDataReader datareader = null;
                Conexiones con = new Conexiones();
                con.ejecutar(consulta, out datareader);

               


                while (datareader.Read())
                {
                    try
                    {
                        txtCodCalendario.Text = codcalendario;
                        txtFechaInicio.Text = Convert.ToString(datareader["FechaInicioModulo"]);
                        txtFechaFin.Text = Convert.ToString(datareader["FechaFinModulo"]);
                        ddownModulo.SelectedValue = Convert.ToString((int)datareader["CodModulo"]);
                        ddownInstitucion.SelectedValue = Convert.ToString((int)datareader["Institucion"]);
                        ddownProfesional.SelectedValue = Convert.ToString((int)datareader["ResponsableModulo"]);

                        parcoll par = new parcoll();
                        DataView dv1 = new DataView(par.Profesionales(Convert.ToInt32(Convert.ToString((int)datareader["Institucion"]))));
                        ddownProfesional.DataSource = dv1;
                        ddownProfesional.DataTextField = "Nombres";
                        ddownProfesional.DataValueField = "ICodTrabajador";
                        dv1.Sort = "Nombres";
                        DataBind();




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
        else
        {
            
        }
    }



    protected void WebImageButton1_Click(object sender, EventArgs e)
    {
        if (ddownInstitucion.SelectedValue == "0" || ddownModulo.SelectedValue == "-2" || ddownProfesional.SelectedValue == "0" || txtFechaInicio.Text == "" || txtFechaFin.Text == "")
        {
            alertW.Visible = true;
            alertS.Visible = false;

        }
        else
        {
            editarCalendario();
        }

    }

    protected void mostrar_profesionales(object sender, EventArgs e)
    {

        getProfesionales();

    }





    private void editarCalendario()
    {

        int returnvalue = 0;
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */
        Conexiones con = new Conexiones();
        DbParameter[] parametros = {
        con.parametros("@CodCalendario", SqlDbType.Int, 4, txtCodCalendario.Text) , 
        con.parametros("@CodModulo", SqlDbType.Int, 4, ddownModulo.SelectedValue) , 
		con.parametros("@FechaInicioModulo", SqlDbType.Date, 30, txtFechaInicio.Text),
        con.parametros("@FechaFinModulo", SqlDbType.Date, 30, txtFechaFin.Text),
        con.parametros("@Institucion", SqlDbType.Int, 4, ddownInstitucion.SelectedValue) , 
        con.parametros("@ResponsableModulo", SqlDbType.Int, 4, ddownProfesional.SelectedValue) , 
        con.parametros("@Estado", SqlDbType.Int, 4, 1) , 
		con.parametros("@Vigencia", SqlDbType.Int, 4, txtVigencia.Text),
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





        }
        else
        {

            alertS.Visible = false;
            alertW.Visible = true;




        }






    }





}