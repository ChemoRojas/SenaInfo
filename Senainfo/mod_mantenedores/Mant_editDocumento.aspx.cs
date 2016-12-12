using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mod_biblioteca_editDocumento : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!validatesecurity())
            {
                //valido si inicié sesión. Si no encuentra las variables de sesión, me envía al login
                Response.Redirect("~/logout.aspx");
            }

            //cargo la información del archivo, a partir de su ID
            txtId.Value = Request["Id"];
            CargaDatosArchivo(txtId.Value);
        }
    }

    private void CargaDatosArchivo(string Id)
    {
        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "[dbo].[sp_getDocumento]";
        sqlc.Parameters.Add("@Id", SqlDbType.Int).Value = Convert.ToInt32(Id);
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();

        foreach (DataRow dr in dt.Rows)
        {
            txtNombre.Text = dr["Nombre"].ToString();
            txtDescripcion.Text = dr["Descripcion"].ToString();
            chkVigencia.Checked = (bool)dr["Vigencia"];
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

        return respuesta;
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        guardaArchivo(txtNombre.Text, txtDescripcion.Text, chkVigencia.Checked);
        Response.Redirect("Mant_Documentos.aspx");
    }

    private void guardaArchivo(string nombre, string descripcion, bool Vigencia)
    {
        try
        {
            System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
            System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
            sqlc.Connection = sconn;
            sqlc.CommandType = System.Data.CommandType.StoredProcedure;
            sqlc.CommandText = "[dbo].[sp_updtDocumento]";
            sqlc.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
            sqlc.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = descripcion;
            sqlc.Parameters.Add("@vigencia", SqlDbType.VarChar).Value = Convert.ToString(Convert.ToInt32(Vigencia));
            sqlc.Parameters.Add("@usuario", SqlDbType.VarChar).Value = Session["IdUsuario"];
            sqlc.Parameters.Add("@id", SqlDbType.VarChar).Value = txtId.Value;

            if ((archivo1.PostedFile != null) && (archivo1.PostedFile.ContentLength > 0))
            {
                string contentType = archivo1.PostedFile.ContentType;
                string ext = Path.GetExtension(archivo1.PostedFile.FileName);
                using (Stream fs = archivo1.PostedFile.InputStream)
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        byte[] bytes = br.ReadBytes((Int32)fs.Length);

                        sqlc.Parameters.Add("@mimetype", SqlDbType.VarChar).Value = contentType;
                        sqlc.Parameters.Add("@extension", SqlDbType.VarChar).Value = ext;
                        sqlc.Parameters.Add("@contenido", SqlDbType.VarBinary).Value = bytes;
                    }
                }
            }
            else
            {
                sqlc.Parameters.Add("@mimetype", SqlDbType.VarChar).Value = "";
                sqlc.Parameters.Add("@extension", SqlDbType.VarChar).Value = "";
                sqlc.Parameters.Add("@contenido", SqlDbType.VarBinary).Value = new byte[] { };
            }

            sconn.Open();
            sqlc.ExecuteNonQuery();
            sconn.Close();
        }
        catch (Exception ex)
        {
            Response.Write("Error: " + ex.Message);
        }
    }
}