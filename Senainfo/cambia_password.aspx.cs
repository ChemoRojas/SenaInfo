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
using System.Data.Common;
using System.Data.SqlClient;

using System.Collections.Generic;

public partial class cambia_password : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (pnlMensaje.Visible)
        {
            for (int i = 1; i <= 40; i++)
            {
                lbl_aviso.Text = "SU CONTRASEÑA HA SIDO CAMBIADA CORRECTAMENTE";
            }
            window.close(this.Page);
        }
        if (!IsPostBack)
        {
            if (Request.QueryString["lbl"] != null)
                lbl_aviso.Text = Request.QueryString["lbl"].ToString();
        }
    }
    //    protected void imb_ingresar_Click(object sender, EventArgs e)
    //    {
    //        SeguridadSENAINFO.Service1 ls = new SeguridadSENAINFO.Service1();

    //        //neows.neoportalservices ns = new neows.neoportalservices();

    //        //DataSet arr = ns.getusertokens(txt_usuario.Text, txt_password.Text);
    //        DataSet arr = ls.ObtenerTokensUsuario(txt_usuario.Text, txt_password.Text);


    //        Session["tokens"] = arr;


    //        if (window.existetoken("3E85C221-1603-4D99-AA31-9EFD971F7387"))
    //        {
    //            lbl_aviso.Visible = false;
    //            if (txt_nueva_password.Text == txt_repassword.Text)
    //            {
    //                if (txt_password.Text == txt_nueva_password.Text)
    //                {
    //                    lbl_aviso.Text = "La nueva contraseña NO puede ser igual a la actual.";
    //                    lbl_aviso.Visible = true;
    //                    return;
    //                }
    //                txt_repassword.BackColor = System.Drawing.Color.White;
    //                txt_password.BackColor = System.Drawing.Color.White;

    ////                bool v = ns.changepassword(txt_usuario.Text, txt_nueva_password.Text, txt_password.Text);
    //                bool v = ls.cambiarcontrasena(txt_usuario.Text, txt_nueva_password.Text, txt_password.Text);
    //                if (v)
    //                {
    //                    update_usuarios();
    //                    //window.alert(Page, "SU CONTRASEÑA HA SIDO CAMBIADA CORRECTAMENTE");
    //                    lbl_aviso.Text = "SU CONTRASEÑA HA SIDO CAMBIADA CORRECTAMENTE";
    //                    lblMensaje.Text = lbl_aviso.Text;
    //                    pnlCambio.Visible = false;
    //                    pnlMensaje.Visible = true;
    //                    lbl_aviso.Visible = true;

    //                    window.close(this.Page);
    //                    this.Page.Dispose();
    //                    return;
    //                }
    //                else
    //                {
    //                    window.alert(Page, "SE PRODUJO UN ERROR AL INTENTAR CAMBIAR SU CONTRASEÑA. <br> INTENTELO NUEVAMENTE.");
    //                }
    //            }
    //            else
    //            {
    //                txt_repassword.BackColor = System.Drawing.Color.Pink;
    //                txt_password.BackColor = System.Drawing.Color.Pink;
    //            }
    //        }
    //        else
    //        {
    //            lbl_aviso.Text = "El usuario o contraseña son incorrectas.";
    //            lbl_aviso.Visible = true;
    //        }

    //    }
    private void update_usuarios()
    {
        System.Data.Common.DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        List<DbParameter> listDbParameter = new List<DbParameter>();

        string sql = "SELECT * FROM usuarios WHERE usuario =@pusuario ";

        listDbParameter.Add(Conexiones.CrearParametro("@pusuario", SqlDbType.VarChar, 30, txt_usuario.Text.Trim()));

        con.ejecutar(sql, listDbParameter, out datareader);
        DataTable dt1 = new DataTable();
        DataRow dr;

        dt1.Columns.Add(new DataColumn("ICodTrabajador", typeof(int)));
        dt1.Columns.Add(new DataColumn("CodRegion", typeof(int)));
        dt1.Columns.Add(new DataColumn("Contrasena", typeof(String)));
        dt1.Columns.Add(new DataColumn("CodDireccionRegional", typeof(int)));
        dt1.Columns.Add(new DataColumn("IndVigencia", typeof(String)));

        while (datareader.Read())
        {
            try
            {
                dr = dt1.NewRow();
                dr[0] = (int)datareader["ICodTrabajador"];
                dr[1] = (int)datareader["CodRegion"];
                dr[2] = (String)datareader["Contrasena"];
                dr[3] = (int)datareader["CodDireccionRegional"];
                dr[4] = (String)datareader["IndVigencia"];
                dt1.Rows.Add(dr);
            }
            catch { }
        }

        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + con.Servidor + " ;Database= " + con.Base + " ; User ID= " + con.Usuario + " ;Password= " + con.Passw + " ;Trusted_Connection=False");
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Update_Usuarios";
        sqlc.Parameters.Add("@ICodTrabajador", SqlDbType.Int, 4).Value = Convert.ToInt32(dt1.Rows[0]["ICodTrabajador"].ToString());
        sqlc.Parameters.Add("@CodRegion", SqlDbType.Int, 4).Value = Convert.ToInt32(dt1.Rows[0]["CodRegion"].ToString()); ;
        sqlc.Parameters.Add("@Contrasena", SqlDbType.VarChar, 40).Value = dt1.Rows[0]["Contrasena"].ToString();
        sqlc.Parameters.Add("@IndVigencia", SqlDbType.VarChar, 40).Value = dt1.Rows[0]["IndVigencia"].ToString();
        sqlc.Parameters.Add("@CodDireccionRegional", SqlDbType.Int, 4).Value = Convert.ToInt32(dt1.Rows[0]["CodDireccionRegional"].ToString());
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
    }
    protected void imb_ingresar_Click(object sender, EventArgs e)
    {
        //SeguridadSENAINFO.Service1 ls = new SeguridadSENAINFO.Service1();
        SeguridadSENAINFO.SeguridadSENAINFOSoapClient ls = new SeguridadSENAINFO.SeguridadSENAINFOSoapClient();
        DataSet arr = ls.ObtenerTokensUsuario(txt_usuario.Text, txt_password.Text);
        Session["tokens"] = arr;


        if (window.existetoken("3E85C221-1603-4D99-AA31-9EFD971F7387"))
        {
            lbl_aviso.Visible = false;
            if (txt_nueva_password.Text == txt_repassword.Text)
            {
                if (txt_password.Text == txt_nueva_password.Text)
                {
                    lbl_aviso.Text = "La nueva contraseña NO puede ser igual a la actual.";
                    lbl_aviso.Visible = true;
                    return;
                }
                txt_repassword.BackColor = System.Drawing.Color.White;
                txt_password.BackColor = System.Drawing.Color.White;

                bool v = ls.CambiarContrasena(txt_usuario.Text, txt_nueva_password.Text, txt_password.Text);
                if (v)
                {
                    update_usuarios();
                    lbl_aviso.Text = "SU CONTRASEÑA HA SIDO CAMBIADA CORRECTAMENTE";
                    lblMensaje.Text = lbl_aviso.Text;
                    pnlCambio.Visible = false;
                    pnlMensaje.Visible = true;
                    lbl_aviso.Visible = true;

                    window.close(this.Page);
                    this.Page.Dispose();
                    return;
                }
                else
                {
                    window.alert(Page, "SE PRODUJO UN ERROR AL INTENTAR CAMBIAR SU CONTRASEÑA. <br> INTENTELO NUEVAMENTE.");
                }
            }
            else
            {
                txt_repassword.BackColor = System.Drawing.Color.Pink;
                txt_password.BackColor = System.Drawing.Color.Pink;
            }
        }
        else
        {
            lbl_aviso.Text = "El usuario o contraseña son incorrectas.";
            lbl_aviso.Visible = true;
        }
    }
}