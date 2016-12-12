using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Collections.Generic;
using System.Data.SqlClient;
//using Argentis.Regmen;

public partial class _Index : System.Web.UI.Page
{

    Alerta a = null;
    //DataTable dtAlerta = null;
    nino n = null;
    institucioncoll i = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //getEgresosPendientes();
            getAlertas();

            //lb_NombreUsuario.Text = Session["Usuario"].ToString();
            //lb_NombreUsuario.Text += " " + Session["contrasena"].ToString();
            //mostrar_collapse(true);

        }
        catch
        {
        }

        if (!IsPostBack)
        {
            if (!validatesecurity())
            {
                Response.Redirect("~/logout.aspx");
            }

        }
    }

    private bool validatesecurity()
    {
        bool respuesta = false;

        if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
        {
            respuesta = false;
        }
        else if (!window.existetoken("3E85C221-1603-4D99-AA31-9EFD971F7387"))
        {
            respuesta = false;
        }
        else
        {
            respuesta = true;
        }

        if (!window.existetoken("79270734-C383-487D-8EAB-BC63F1521932"))
        {
            GridAlertasListaEsperaxAbuso.Columns[11].Visible = false;
        }


        //if (!window.existetoken(''))
        //{
        //    GridAlertasEgresosxTraslado.Columns[11].Visible = false;
        //}

        return respuesta;
    }

    private void getAlertas()
    {
        int idusuario;
        int codrol;

        a = new Alerta();

        DataTable dtAlertas = new DataTable();

        //Idusuario test DJJ 57050
        //CodRol = 267
        //Las alertas actualmente se encuentran almacenadas con el rol 252, modifique en este caso particular la alerta 228 para comprobar que este todo en orden

        idusuario = Convert.ToInt32(Session["IdUsuario"]);
        codrol = Convert.ToInt32(Session["contrasena"]);

        dtAlertas = a.getAlertas(idusuario, codrol);

        DataView dv = new DataView(dtAlertas);

        dv.RowFilter = "CodTipo = 1";
        GridAlertasEgresosPendientesxCausal.DataSource = dv;
        numAlertasEgresosPendientesxCausal.Text = dv.Count.ToString();
        GridAlertasEgresosPendientesxCausal.DataBind();

        dv.RowFilter = "CodTipo = 2";
        GridAlertasListaEsperaxAbuso.DataSource = dv;
        numAlertaListaEspera.Text = dv.Count.ToString();
        GridAlertasListaEsperaxAbuso.DataBind();

        dv.RowFilter = "CodTipo = 3";
        GridAlertasEgresosxTraslado.DataSource = dv;
        numAlertaEgresosxTraslado.Text = dv.Count.ToString();
        GridAlertasEgresosxTraslado.DataBind();

        //GridAlertas.DataSource = dv;
        //GridAlertas.DataBind();

        //NumeroAlertas.Text = dtAlertas.Rows.Count.ToString();

        //GridAlertas.HeaderRow.TableSection = TableRowSection.TableHeader;

        if (GridAlertasEgresosPendientesxCausal.Rows.Count > 0)
        {
            GridAlertasEgresosPendientesxCausal.HeaderRow.TableSection = TableRowSection.TableHeader;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "e1", "generateDataTable($('#GridAlertasEgresosPendientesxCausal'));", true);
        }
        else if (GridAlertasEgresosPendientesxCausal.Rows.Count == 0)
        {
            numAlertasEgresosPendientesxCausal.Visible = false;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "o1", "$('#A1').css('display', 'none');", true);
            //$('#numAlertasEgresosPendientesxCausal').css('display', 'none');
        }

        if (GridAlertasListaEsperaxAbuso.Rows.Count > 0)
        {
            GridAlertasListaEsperaxAbuso.HeaderRow.TableSection = TableRowSection.TableHeader;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "e2", "generateDataTable($('#GridAlertasListaEsperaxAbuso'));", true);
        }
        else if (GridAlertasListaEsperaxAbuso.Rows.Count == 0)
        {
            numAlertaListaEspera.Visible = false;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "o2", "$('#A2').css('display', 'none');", true);
        }

        if (GridAlertasEgresosxTraslado.Rows.Count > 0)
        {
            GridAlertasEgresosxTraslado.HeaderRow.TableSection = TableRowSection.TableHeader;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "e3", "generateDataTable($('#GridAlertasEgresosxTraslado'));", true);
        }
        else if (GridAlertasEgresosxTraslado.Rows.Count == 0)
        {
            numAlertaEgresosxTraslado.Visible = false;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "o3", "$('#A3').css('display', 'none');", true);
        }
        
        

    }

    private DataTable callto_get_avisos()
    {
        Conexiones con = new Conexiones();
        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + con.Servidor + " ;Database= " + con.Base + " ; User ID= " + con.Usuario + " ;Password= " + con.Passw + " ;Trusted_Connection=False");
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "get_avisos";
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    private DataTable callto_get_avisosII()
    {
        Conexiones con = new Conexiones();
        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + con.Servidor + " ;Database= " + con.Base + " ; User ID= " + con.Usuario + " ;Password= " + con.Passw + " ;Trusted_Connection=False");
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "get_avisosII";
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dtt = new DataTable();
        sconn.Open();
        da.Fill(dtt);
        sconn.Close();
        return dtt;
    }

    private Int32 ProyectosQueConfirmanAsistencia(int IdUsuario)
    {
        Conexiones con = new Conexiones();
        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + con.Servidor + " ;Database= " + con.Base + " ; User ID= " + con.Usuario + " ;Password= " + con.Passw + " ;Trusted_Connection=False");
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "get_ProyectosQueConfirmanAsistencia";
        sqlc.Parameters.Add("@IdUsuario", SqlDbType.Int, 4).Value = IdUsuario;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();

        return dt.Rows.Count;
    }

    //private void mostrar_collapse(bool valor)
    //{
    //    if (valor)
    //    {
    //        collapseOne.Attributes.Remove("class");
    //        collapseOne.Attributes.Add("class", "panel-collapse collapse in");
    //    }
    //    if (!valor)
    //    {
    //        collapseOne.Attributes.Remove("class");
    //        collapseOne.Attributes.Add("class", "panel-collapse collapse out");
    //    }

    //}

    //protected void GridAlertas_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    if (e.CommandName == "Resolver")
    //    {
    //        //ninocoll datosNino = new ninocoll();

    //        n = new nino();
    //        a = new Alerta();


    //        int CodInstitucion = 0;


    //        a.CodAlerta = Convert.ToInt32(GridAlertas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text);
    //        a.CodTipo = a.getTipoAlerta(a.CodAlerta);
    //        a.ICodIE = Convert.ToInt32(GridAlertas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text);
    //        a.CodNino = Convert.ToInt32(GridAlertas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text);
    //        n.Apellido_Paterno = GridAlertas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text;
    //        n.Apellido_Materno = GridAlertas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Text;
    //        n.Nombres = GridAlertas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Text;
    //        a.DescAlerta = GridAlertas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[6].Text;
    //        a.Url = GridAlertas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[7].Text;
    //        a.CodProyecto = Convert.ToInt32(GridAlertas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[8].Text);
    //        CodInstitucion = Convert.ToInt32(GridAlertas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[9].Text);
    //        a.Cua = GridAlertas.Rows[Convert.ToInt32(e.CommandArgument)].Cells[10].Text;
            

    //        //oNNA NNA = new oNNA(CodInstitucion.ToString(), a.CodProyecto.ToString(), a.ICodIE, a.CodNino, "", n.Nombres, n.Apellido_Paterno, n.Apellido_Materno, "", "");
    //        if (a.CodTipo == 3)
    //        {
    //            oNNA NNA = new oNNA("0", "0", a.ICodIE, a.CodNino, "", n.Nombres, n.Apellido_Paterno, n.Apellido_Materno, "", "", a.Cua);
    //            Session["NNA"] = NNA;
    //        }
    //        else
    //        {
    //            oNNA NNA = new oNNA(CodInstitucion.ToString(), a.CodProyecto.ToString(), a.ICodIE, a.CodNino, "", n.Nombres, n.Apellido_Paterno, n.Apellido_Materno, "", "", a.Cua);
    //            Session["NNA"] = NNA;
    //        }
            
            

    //        Response.Redirect(a.Url.ToString().Replace("&amp;", "&"));


    //    }
    //}

    protected void GridAlertasEgresosPendientesxCausal_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        n = new nino();
        a = new Alerta();


        int CodInstitucion = 0;


        a.CodAlerta = Convert.ToInt32(GridAlertasEgresosPendientesxCausal.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text);
        a.CodTipo = a.getTipoAlerta(a.CodAlerta);
        a.ICodIE = Convert.ToInt32(GridAlertasEgresosPendientesxCausal.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text);
        a.CodNino = Convert.ToInt32(GridAlertasEgresosPendientesxCausal.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text);
        n.Apellido_Paterno = HttpUtility.HtmlDecode(GridAlertasEgresosPendientesxCausal.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text);
        n.Apellido_Materno = HttpUtility.HtmlDecode(GridAlertasEgresosPendientesxCausal.Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Text);
        n.Nombres = HttpUtility.HtmlDecode(GridAlertasEgresosPendientesxCausal.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Text);
        a.DescAlerta = GridAlertasEgresosPendientesxCausal.Rows[Convert.ToInt32(e.CommandArgument)].Cells[6].Text;
        a.Url = GridAlertasEgresosPendientesxCausal.Rows[Convert.ToInt32(e.CommandArgument)].Cells[7].Text;
        a.CodProyecto = Convert.ToInt32(GridAlertasEgresosPendientesxCausal.Rows[Convert.ToInt32(e.CommandArgument)].Cells[8].Text);
        CodInstitucion = Convert.ToInt32(GridAlertasEgresosPendientesxCausal.Rows[Convert.ToInt32(e.CommandArgument)].Cells[9].Text);
        a.Cua = GridAlertasEgresosPendientesxCausal.Rows[Convert.ToInt32(e.CommandArgument)].Cells[10].Text;

        oNNA NNA = new oNNA(CodInstitucion.ToString(), a.CodProyecto.ToString(), a.ICodIE, a.CodNino, "", n.Nombres, n.Apellido_Paterno, n.Apellido_Materno, "", "", a.Cua);
        Session["NNA"] = NNA;

        Response.Redirect(a.Url.ToString().Replace("&amp;", "&"));

    }
    protected void GridAlertasListaEsperaxAbuso_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        n = new nino();
        a = new Alerta();


        int CodInstitucion = 0;


        a.CodAlerta = Convert.ToInt32(GridAlertasListaEsperaxAbuso.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text);
        a.CodTipo = a.getTipoAlerta(a.CodAlerta);
        a.ICodIE = Convert.ToInt32(GridAlertasListaEsperaxAbuso.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text);
        a.CodNino = Convert.ToInt32(GridAlertasListaEsperaxAbuso.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text);
        n.Apellido_Paterno = HttpUtility.HtmlDecode(GridAlertasListaEsperaxAbuso.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text);
        n.Apellido_Materno = HttpUtility.HtmlDecode(GridAlertasListaEsperaxAbuso.Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Text);
        n.Nombres = HttpUtility.HtmlDecode(GridAlertasListaEsperaxAbuso.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Text);
        a.DescAlerta = GridAlertasListaEsperaxAbuso.Rows[Convert.ToInt32(e.CommandArgument)].Cells[6].Text;
        a.Url = GridAlertasListaEsperaxAbuso.Rows[Convert.ToInt32(e.CommandArgument)].Cells[7].Text;
        a.CodProyecto = Convert.ToInt32(GridAlertasListaEsperaxAbuso.Rows[Convert.ToInt32(e.CommandArgument)].Cells[8].Text);
        CodInstitucion = Convert.ToInt32(GridAlertasListaEsperaxAbuso.Rows[Convert.ToInt32(e.CommandArgument)].Cells[9].Text);
        a.Cua = GridAlertasListaEsperaxAbuso.Rows[Convert.ToInt32(e.CommandArgument)].Cells[10].Text;


        oNNA NNA = new oNNA(CodInstitucion.ToString(), a.CodProyecto.ToString(), a.ICodIE, a.CodNino, "", n.Nombres, n.Apellido_Paterno, n.Apellido_Materno, "", "", a.Cua);
        Session["NNA"] = NNA;
        
        

        Response.Redirect(a.Url.ToString().Replace("&amp;", "&"));


    }
    protected void GridAlertasEgresosxTraslado_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        n = new nino();
        a = new Alerta();


        int CodInstitucion = 0;


        a.CodAlerta = Convert.ToInt32(GridAlertasEgresosxTraslado.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text);
        a.CodTipo = a.getTipoAlerta(a.CodAlerta);
        a.ICodIE = Convert.ToInt32(GridAlertasEgresosxTraslado.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text);
        a.CodNino = Convert.ToInt32(GridAlertasEgresosxTraslado.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text);
        n.Apellido_Paterno = HttpUtility.HtmlDecode(GridAlertasEgresosxTraslado.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text);
        n.Apellido_Materno = HttpUtility.HtmlDecode(GridAlertasEgresosxTraslado.Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Text);
        n.Nombres = HttpUtility.HtmlDecode(GridAlertasEgresosxTraslado.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Text);
        a.DescAlerta = GridAlertasEgresosxTraslado.Rows[Convert.ToInt32(e.CommandArgument)].Cells[6].Text;
        a.Url = GridAlertasEgresosxTraslado.Rows[Convert.ToInt32(e.CommandArgument)].Cells[7].Text;
        a.CodProyecto = Convert.ToInt32(GridAlertasEgresosxTraslado.Rows[Convert.ToInt32(e.CommandArgument)].Cells[8].Text);
        CodInstitucion = Convert.ToInt32(GridAlertasEgresosxTraslado.Rows[Convert.ToInt32(e.CommandArgument)].Cells[9].Text);
        a.Cua = GridAlertasEgresosxTraslado.Rows[Convert.ToInt32(e.CommandArgument)].Cells[10].Text;

        oNNA NNA = new oNNA("0", "0", a.ICodIE, a.CodNino, "", n.Nombres, n.Apellido_Paterno, n.Apellido_Materno, "", "", a.Cua);
        Session["NNA"] = NNA;

        Response.Redirect(a.Url.ToString().Replace("&amp;", "&"));

    }
}
