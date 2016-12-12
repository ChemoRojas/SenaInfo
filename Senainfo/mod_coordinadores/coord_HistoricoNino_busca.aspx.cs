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
            DataTable dt = cr.callto_historico_coordinadores_modifica(codnino);
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
    //        dt = cr.callto_historico_coordinadores_modifica(codnino, ASP.global_asax.globaconn);

    //    }

    //    dt.Columns[0].ColumnName = "COD. PROYECTO";
    //    dt.Columns[1].ColumnName = "NOMBRE PROYECTO";
    //    dt.Columns[2].ColumnName = "NEMOTECNICO";
    //    dt.Columns[3].ColumnName = "COD. INGRESO";
    //    dt.Columns[4].ColumnName = "APELLIDO PATERNO";
    //    dt.Columns[5].ColumnName = "APELLIDO MATERNO";
    //    dt.Columns[6].ColumnName = "NOMBRES";
    //    dt.Columns[7].ColumnName = "FECHA INGRESO";
    //    dt.Columns[8].ColumnName = "RUT";
    //    dt.Columns[9].ColumnName = "FECHA NACIMIENTO";
    //    dt.Columns[10].ColumnName = "EDAD";
    //    dt.Columns[11].ColumnName = "COMUNA ORIGEN";
    //    dt.Columns[12].ColumnName = "CAUSAL INGRESO";
    //    dt.Columns[13].ColumnName = "PRIORIDAD";
    //    dt.Columns[14].ColumnName = "REGION TRIBUNAL";
    //    dt.Columns[15].ColumnName = "RUC";
    //    dt.Columns[16].ColumnName = "RIT";
    //    dt.Columns[17].ColumnName = "FECHA INICIO";
    //    dt.Columns[18].ColumnName = "MES DURACION";
    //    dt.Columns[19].ColumnName = "AÑO DURACION";
    //    dt.Columns[20].ColumnName = "DIA DURACION";
    //    dt.Columns[21].ColumnName = "BONO";
    //    dt.Columns[22].ColumnName = "SANCCION ACCESORIA";
    //    dt.Columns[23].ColumnName = "FECHA TERMINO SANCION";
    //    dt.Columns[24].ColumnName = "FECHA TERMINO";


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
            dt = cr.callto_historico_coordinadores_modifica(codnino);

        }

        dt.Columns[0].ColumnName = "COD. PROYECTO";
        dt.Columns[1].ColumnName = "NOMBRE PROYECTO";
        dt.Columns[2].ColumnName = "NEMOTECNICO";
        dt.Columns[3].ColumnName = "COD. INGRESO";
        dt.Columns[4].ColumnName = "APELLIDO PATERNO";
        dt.Columns[5].ColumnName = "APELLIDO MATERNO";
        dt.Columns[6].ColumnName = "NOMBRES";
        dt.Columns[7].ColumnName = "FECHA INGRESO";
        dt.Columns[8].ColumnName = "RUT";
        dt.Columns[9].ColumnName = "FECHA NACIMIENTO";
        dt.Columns[10].ColumnName = "EDAD";
        dt.Columns[11].ColumnName = "COMUNA ORIGEN";
        dt.Columns[12].ColumnName = "CAUSAL INGRESO";
        dt.Columns[13].ColumnName = "PRIORIDAD";
        dt.Columns[14].ColumnName = "REGION TRIBUNAL";
        dt.Columns[15].ColumnName = "RUC";
        dt.Columns[16].ColumnName = "RIT";
        dt.Columns[17].ColumnName = "FECHA INICIO";
        dt.Columns[18].ColumnName = "MES DURACION";
        dt.Columns[19].ColumnName = "AÑO DURACION";
        dt.Columns[20].ColumnName = "DIA DURACION";
        dt.Columns[21].ColumnName = "BONO";
        dt.Columns[22].ColumnName = "SANCCION ACCESORIA";
        dt.Columns[23].ColumnName = "FECHA TERMINO SANCION";
        dt.Columns[24].ColumnName = "FECHA TERMINO";


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
