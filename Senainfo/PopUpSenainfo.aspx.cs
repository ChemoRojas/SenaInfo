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
//using neocsharp.NeoDatabase;

public partial class PopUpSenainfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Conexiones con = new Conexiones();
        if (!IsPostBack)
        {
            if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
            {
                Response.Redirect("~/logout.aspx");
            }
            else
            {
                String UserID = Convert.ToString(Session["IdUsuario"]);
                String strSQL = "";
                int CodInstitucion;

                strSQL += "select top 1 t1.IdUsuario , t3.CodInstitucion, isnull(t4.ActualizaAntecedentes, 1) as ActualizaAntecedentes ";
                strSQL += "from Usuarios t1 ";
                strSQL += "left join TrabajadorProyecto t2 ON t1.ICodTrabajador = t2.ICodTrabajador ";
                strSQL += "left join Proyectos t3 ON t2.CodProyecto = t3.CodProyecto ";
                strSQL += "left join zz_DPL_InstitucionesActualizaAntecedentes t4 ON t3.CodInstitucion = t4.CodInstitucion ";
                strSQL += "where IdUsuario = " + UserID.ToString() + " ";
                strSQL += "and t1.IndVigencia = 'V' and t2.IndVigencia = 'V' and t3.IndVigencia = 'V' ";
                strSQL += "order by t2.ICodTrabajador desc";
                
                //objconnection objconn = ASP.global_asax.globaconn;
                System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + con.Servidor + " ;Database= " + con.Base + " ; User ID= " + con.Usuario + " ;Password= " + con.Passw + " ;Trusted_Connection=False");
                System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
                sqlc.Connection = sconn;
                sqlc.CommandType = System.Data.CommandType.Text;
                sqlc.CommandText = strSQL;
                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
                DataTable dt = new DataTable();
                sconn.Open();
                da.Fill(dt);
                sconn.Close();

                if (dt.Rows.Count == 0)
                    Response.Redirect("default.aspx");

                if (dt.Rows.Count != 0 && Convert.ToInt32(dt.Rows[0]["ActualizaAntecedentes"]) != 0)
                    Response.Redirect("default.aspx");
            }
        }
            
    }
}
