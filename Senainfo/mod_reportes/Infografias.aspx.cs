using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mod_reportes_Infografias : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack){
            if (Request.QueryString["i"] != "")
            {
                //int opcion = int.Parse(window.Base64Decode(Request.QueryString["i"].ToString()));
                //DataTable dt = Session["Infografias"] as DataTable;
                //DataRow[] row;
                //row = dt.Select("Opcion = " + opcion);
                
                //lb_infografia.Text = row[0][1].ToString();
                //lt_uri.Text = row[0][2].ToString();

                int opcion = int.Parse(window.Base64Decode(Request.QueryString["i"].ToString()));
                switch (opcion)
                {
                    case 1:
                        lb_infografia.Text = "Vista global: Reingresos. Enfoque regional y evolución en el tiempo";
                        lt_uri.Text = "https://public.tableau.com/views/Infografan1_2SENAME/Dashboard4? amp;:embed=y&:display_count=yes&:showTabs=y?:showVizHome=no";
                        //MQ==
                        break;
                    case 2:
                        lb_infografia.Text = "Análisis detallado: Reingresos. Tiempo promedio de reingresos y las causas de egresos previos";
                        lt_uri.Text = "https://public.tableau.com/views/Infografan2SENAME/Dashboard1? amp;:embed=y&:display_count=yes&:showTabs=y?:showVizHome=no";
                        //Mg==
                        break;
                    case 3:
                        lb_infografia.Text = "Análisis detallado: Reingresos. Enfoque regional según modalidad del programa";
                        lt_uri.Text = "https://public.tableau.com/views/InfografaN3SENAME/Panel1? amp;:embed=y&:display_count=yes&:showTabs=y?:showVizHome=no";
                        //Mw==
                        break;
                    case 4:
                        lb_infografia.Text = "Análisis detallado: Reingresos según delito. Enfoque en jóvenes con múltiples reingresos";
                        lt_uri.Text = "https://public.tableau.com/views/Infografan4SENAME/Propuesta1? amp;:embed=y&:display_count=yes&:showTabs=y?:showVizHome=no";
                        //NA==
                        break;
                    case 5:
                        lb_infografia.Text = "Ingresos según sanciones";
                        lt_uri.Text = "https://public.tableau.com/views/InfografaN2IngresossegnSancin/Ingresadosporsancin_1?amp;:embed=y&amp;:display_count=yes&amp;:showTabs=y?:showVizHome=no";
                        //NQ==
                        break;
                    case 6:
                        lb_infografia.Text = "Ingresos según medidas";
                        lt_uri.Text = "https://public.tableau.com/views/InfografaN1IngresossegnMedidas/Dashboard2?%20amp;:embed=y&:display_count=yes&:showTabs=y?:showVizHome=no";
                        //Ng==
                        break;
                    
                    //default:
                    //    lb_infografia.Text = "";
                    //    lt_uri.Text = "";
                    //    break;
                }
            }
        }
    }
}