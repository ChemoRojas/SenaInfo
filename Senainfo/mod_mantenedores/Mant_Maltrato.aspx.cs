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

public partial class Mant_DetalleIngreso : System.Web.UI.Page
{
    CargaDDL ddl = new CargaDDL();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            DataView dv = new DataView(ddl.TipoMaltrato());
            ddl_tipomaltrato.DataSource = dv;
            ddl_tipomaltrato.DataTextField = "Descripcion";
            ddl_tipomaltrato.DataValueField = "TipoMaltrato";
            dv.Sort = "TipoMaltrato";
            ddl_tipomaltrato.DataBind();
        }
    }
    protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
    {
        Panel1.Visible = true;
    }
    protected void ImageButton2_Click1(object sender, ImageClickEventArgs e)
    {
        
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        Panel1.Visible = false;
    }
    protected void btn_volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("index_mantenedores.aspx");
    }
}
