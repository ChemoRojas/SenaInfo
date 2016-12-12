using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class buscador : System.Web.UI.Page
{
    DataTable dt1 = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //funciones que se ejecutan en la página (seteo de valores, etc.), cuando no se envía PostBack al servidor
            if (Request["Rut"] != null && Request["Rut"] != "")
                getSP_Antecedentes(Request["Rut"]);

        }
    }

  

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        getSP_Antecedentes(txtRun.Text + "-" + txtDv.Text);
        
    }


    private void getSP_Antecedentes(string Rut)
    {
        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "[dbo].[SP_getAntecedentes]";
        sqlc.Parameters.Add("@Rut", SqlDbType.VarChar, 100).Value = Rut;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();

        foreach (DataRow dr in dt.Rows)
        {
            lbl002panel.Visible = true;
            lblNombre.Text = dr["Nombre"].ToString();
            lblNombreAntecedentes.Text = dr["Nombre"].ToString();
            lblRut.Text = dr["Rut"].ToString();
            lblCodigo.Text = dr["CodNino"].ToString();

           getSP_MotivoAntecedentes(Int32.Parse(dr["CodNino"].ToString()));
           
        }
    }

    private void getSP_MotivoAntecedentes(int CodNino)
    {
        try
        {
            

            grdAntecedentes.Visible = true;
            System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
            System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
            sqlc.Connection = sconn;
            sqlc.CommandType = System.Data.CommandType.StoredProcedure;
            sqlc.CommandText = "[dbo].[SP_getMotivoAntecedentes]";
            sqlc.Parameters.Add("@CodNino", SqlDbType.Int).Value = CodNino;
        
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
            DataTable dt = new DataTable();
            sconn.Open();
            da.Fill(dt);
            sconn.Close();

            grdAntecedentes.DataSource = dt;
            grdAntecedentes.DataBind();


        }
        catch(Exception ex)
        {
            Response.Write("Error gravísimo: la Tefy se equivocó otra vez: " + ex.Message);

        }
    }


    /*protected void grdBusqueda_DataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string CodNino = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CodNino"));
            string Ruc = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Ruc"));
            HyperLink hyp = (HyperLink)e.Row.FindControl("hyp");
            hyp.NavigateUrl = "detalleNNA.aspx?CodNino=" + CodNino + "&amp;Ruc=" + Ruc;
        }
    }*/
    protected void grdBusqueda_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdAntecedentes.DataSource = dt1;
        grdAntecedentes.PageIndex = e.NewPageIndex;
        grdAntecedentes.DataBind();
    }


    protected void btnNuevaAnotacion_Click(object sender, EventArgs e)
    {
        Response.Redirect("nuevaAnotacion.aspx?CodNino=" + lblCodigo.Text+"&Rut="+lblRut.Text);
    }
   
}