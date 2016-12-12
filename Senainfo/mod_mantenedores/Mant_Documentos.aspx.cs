using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mod_mantenedores_Mant_Documentos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!validatesecurity())
                Response.Redirect("~/logout.aspx");
            else
                cargaDocumentos();
        }
    }

    private void cargaDocumentos()
    {
        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "[dbo].[sp_getAllDocumentos]";
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();

        grdDocumentos.DataSource = dt;
        grdDocumentos.DataBind();
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

        return respuesta;
    }
    protected void btnNuevoDoc_Click(object sender, EventArgs e)
    {
        Response.Redirect("Mant_addDocumento.aspx");
    }

    protected void lnkDownload_Click(object sender, EventArgs e)
    {
        int id = int.Parse((sender as LinkButton).CommandArgument);
        byte[] bytes = null;
        string fileName = "";
        string contentType = "";

        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "[dbo].[sp_getDocumento]";
        sqlc.Parameters.Add("@Id", SqlDbType.Int).Value = Convert.ToInt32(id);
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();

        foreach (DataRow dr in dt.Rows)
        {
            fileName = CleanInput(dr["Nombre"].ToString()) + dr["Extension"].ToString();
            bytes = (byte[])dr["Contenido"];
            contentType = dr["Mimetype"].ToString();
        }

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = contentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
        Response.BinaryWrite(bytes);
        Response.Flush();
        Response.End();
    }

    static string CleanInput(string strIn)
    {
        // Replace invalid characters with empty strings.
        try
        {
            return Regex.Replace(strIn, @"[^\w\.@-]", "");
        }
        catch (RegexMatchTimeoutException)
        {
            return String.Empty;
        }
    }
}