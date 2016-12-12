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

public partial class mod_mesa_mesa_HistoricoNino : System.Web.UI.Page
{
    public nino SSninoDiag
    {
        get
        {
            if (Session["neo_SSninoDiag"] == null)
            { Session["neo_SSninoDiag"] = new nino(); }
            return (nino)Session["neo_SSninoDiag"];
        }
        set { Session["neo_SSninoDiag"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if(Request.QueryString["CODNINO"] !=null)
            {
            int codnino = Convert.ToInt32(Request.QueryString["CODNINO"]);
            coordinador cr = new coordinador();
            DataTable dt = cr.callto_historico_ninos_coordinacion(codnino);
            DataView dv = new DataView(dt);
            ugrd001.DataSource = dv;
            ugrd001.DataBind();
            }
        }
    }


    //protected void WebImageButton1_Click(object sender, EventArgs e)
    //{
    //    window.close(this.Page);
    //}
    //protected void Webimagebutton2_Click(object sender, EventArgs e)
    //{
    //    Response.Clear();
    //    Response.Buffer = true;
    //    Response.ContentType = "application/vnd.ms-excel";
    //    Response.AddHeader("Content-Disposition", "attachment;filename=Historico_Nino.xls");



    //    this.EnableViewState = false;

    //    System.IO.StringWriter tw = new System.IO.StringWriter();
    //    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
    //    DataTable dt = new DataTable();
    //    if (Request.QueryString["CODNINO"] != null)
    //    {
    //        int codnino = Convert.ToInt32(Request.QueryString["CODNINO"]);
    //        coordinador cr = new coordinador();
    //        dt = cr.callto_historico_ninos_coordinacion(codnino, ASP.global_asax.globaconn);

    //    }

    //    dt.Columns[0].ColumnName = "FECHA";
    //    dt.Columns[1].ColumnName = "NOMBRE Y APELLIDOS";
    //    dt.Columns[2].ColumnName = "RUT";
    //    dt.Columns[3].ColumnName = "EDAD";
    //    dt.Columns[4].ColumnName = "SEXO";
    //    dt.Columns[5].ColumnName = "COMUNA";
    //    dt.Columns[6].ColumnName = "DESCRIPCIÓN DELITO";
    //    dt.Columns[7].ColumnName = "CÓDIGO DELITO";
    //    dt.Columns[8].ColumnName = "RUC";
    //    dt.Columns[9].ColumnName = "RIT";
    //    //dt.Columns[10].ColumnName = "TIPO DE AUDIENCIA";
    //    //dt.Columns[11].ColumnName = "RESOLUCIÓN TRIBUNAL";
    //    dt.Columns[10].ColumnName = "DERIVACIÓN A CENTRO O PROGRAMA SENAME";
    //    dt.Columns[11].ColumnName = "CENTRO O PROGRAMA DE ORIGEN";


    //    DataView dv = new DataView(dt);
    //    DataGrid d1 = new DataGrid();
    //    d1.DataSource = dv;
    //    d1.DataBind();


    //    d1.RenderControl(hw);
    //    Response.ContentEncoding = System.Text.Encoding.Default;
    //    Response.Write(tw.ToString());
    //    Response.End();
        
      
    //}
  
    protected void Webimagebutton2_Click(object sender, EventArgs e)
    {

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=Historico_Nino.xls");



        this.EnableViewState = false;

        System.IO.StringWriter tw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
        DataTable dt = new DataTable();
        if (Request.QueryString["CODNINO"] != null)
        {
            int codnino = Convert.ToInt32(Request.QueryString["CODNINO"]);
            coordinador cr = new coordinador();
            dt = cr.callto_historico_ninos_coordinacion(codnino);

        }

        dt.Columns[0].ColumnName = "FECHA";
        dt.Columns[1].ColumnName = "NOMBRE Y APELLIDOS";
        dt.Columns[2].ColumnName = "RUT";
        dt.Columns[3].ColumnName = "EDAD";
        dt.Columns[4].ColumnName = "SEXO";
        dt.Columns[5].ColumnName = "COMUNA";
        dt.Columns[6].ColumnName = "DESCRIPCIÓN DELITO";
        dt.Columns[7].ColumnName = "CÓDIGO DELITO";
        dt.Columns[8].ColumnName = "RUC";
        dt.Columns[9].ColumnName = "RIT";
        //dt.Columns[10].ColumnName = "TIPO DE AUDIENCIA";
        //dt.Columns[11].ColumnName = "RESOLUCIÓN TRIBUNAL";
        dt.Columns[10].ColumnName = "DERIVACIÓN A CENTRO O PROGRAMA SENAME";
        dt.Columns[11].ColumnName = "CENTRO O PROGRAMA DE ORIGEN";


        DataView dv = new DataView(dt);
        DataGrid d1 = new DataGrid();
        d1.DataSource = dv;
        d1.DataBind();


        d1.RenderControl(hw);
        Response.ContentEncoding = System.Text.Encoding.Default;
        Response.Write(tw.ToString());
        Response.End();
    }
    protected void WebImageButton1_Click(object sender, EventArgs e)
    {
        window.close(this.Page);
    }
}
