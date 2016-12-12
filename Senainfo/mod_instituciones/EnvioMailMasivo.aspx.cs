
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mod_instituciones_EnvioMailMasivo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnEnviarCorreos_Click(object sender, EventArgs e)
    {
        int contador = 0;
        int milisegundos = 30000;  //5 min 300000

        DataTable dtCorreos = new DataTable();
        //1.Obtener correos.
        dtCorreos = obtener_correos();

        //2.Obtener plantilla
        string body = string.Empty;
        using (StreamReader reader = new StreamReader(Server.MapPath("../TemplateMailNvaCta.html")))
        {
            body = reader.ReadToEnd();
        }
        string baseURL = ConfigurationManager.AppSettings["URLBase"];

        SenainfoSdk.Net.SendMail objMail = new SenainfoSdk.Net.SendMail();
                
        foreach (DataRow reg in dtCorreos.Rows)
        {
            if (!string.IsNullOrEmpty(reg["TokenMail"].ToString()))
            {
                String linkmailstring = "<a href=" + baseURL + ConfigurationManager.AppSettings["UrlValidaCorreo"] + "?tid=" + reg["TokenMail"].ToString() + ">Aquí</a>";
                
                string bodyConLink = body.Replace("{%aqui%}", linkmailstring);

                objMail.Enviar(
                    "Senainfo"
                    , reg["Email"].ToString()
                    , string.Empty
                    , string.Empty
                    , ConfigurationManager.AppSettings["SubjectMail"]
                    , bodyConLink);

           
                //Stop cada 5 envios de correo
                //Tiempo de espera 
                contador++;
                if (contador >= 5)
                {
                    contador = 0;
                    //System.Threading.Tasks.Task.Delay(milisegundos);
                    System.Threading.Thread.Sleep(milisegundos);
                }

            }
        }
    }

    private DataTable obtener_correos()
    {
        string sQuery = string.Format(@"
                Select TokenMail, Email from Usuarios where EmailConfirmado = 0"
            );
    
        SqlConnection sconn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConexionesSS"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = sQuery;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
}