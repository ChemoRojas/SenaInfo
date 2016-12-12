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

public partial class mod_coordinadores_coord_historiconino_audiencia_ : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            CargarData();
    }

    private void CargarData()
    {
        if (Request.QueryString["CODNINO"] != null)
        {
            int icodie = Convert.ToInt32(Request.QueryString["CODNINO"]);
            string ruc = Request.QueryString["RUC"].ToString();
            coordinador cr = new coordinador();
            DataTable dt = cr.callto_historico_ninos_coordinacion_audiencia(icodie, ruc);

            if (dt.Rows.Count > 0)
            {
                ugrd001.DataSource = dt;
                ugrd001.DataBind();
                ugrd001.Visible = true;
            }
        }
    }

    protected void GoPage(object sender,EventArgs e)
    {
        DropDownList oIraPag = (DropDownList) sender;
        int iNumPag;
        
        if (Int32.TryParse(oIraPag.Text.Trim(), out iNumPag) && iNumPag >0 && iNumPag <= ugrd001.PageCount)
        if (Int32.TryParse(oIraPag.Text.Trim(), out iNumPag) && iNumPag > 0 && iNumPag <= ugrd001.PageCount)
            ugrd001.PageIndex = iNumPag -1;
        else
             ugrd001.PageIndex = 0;

        CargarData();
    }


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
    //        int icodie = Convert.ToInt32(Request.QueryString["CODNINO"]);
    //        string ruc = Request.QueryString["RUC"].ToString();
    //        coordinador cr = new coordinador();
    //        dt = cr.callto_historico_ninos_coordinacion_audiencia(icodie, ruc, ASP.global_asax.globaconn);

    //    }

    //    dt.Columns[0].ColumnName = "COD. TIPO AUDIENCIA";
    //    dt.Columns[1].ColumnName = "DESCRIPCION";
    //    dt.Columns[2].ColumnName = "RESOLUCION TRIBUNAL";
    //    dt.Columns[3].ColumnName = "FECHA AUDIENCIA";

    //    DataView dv = new DataView(dt);
    //    DataGrid d1 = new DataGrid();
    //    d1.DataSource = dv;
    //    d1.DataBind();


    //    d1.RenderControl(hw);
    //    Response.ContentEncoding = System.Text.Encoding.Default;
    //    Response.Write(tw.ToString());
    //    Response.End();

    //}
    //protected void WebImageButton1_Click(object sender, EventArgs e)
    //{
    //    window.close(this.Page);
    //}
    protected void ugrd001_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        ugrd001.PageIndex = e.NewPageIndex;
        CargarData();
    }
    protected void ugrd001_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager && ugrd001.DataSource != null)
        {
            //TRAE EL TOTAL DE PAGINAS
            Label _TotalPags = (Label)e.Row.FindControl("lblTotalNumberOfPages");
            _TotalPags.Text = ugrd001.PageCount.ToString();
            //LLENA LA LISTA CON EL NUMERO DE PAGINAS

            DropDownList list = (DropDownList)e.Row.FindControl("paginasDropDownList");
            for (int i = 0; i < ugrd001.PageCount; i++)
            {
                list.Items.Add(i.ToString());
            }
            list.SelectedValue = (ugrd001.PageIndex + 1).ToString(); 
        }
    }
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
            int icodie = Convert.ToInt32(Request.QueryString["CODNINO"]);
            string ruc = Request.QueryString["RUC"].ToString();
            coordinador cr = new coordinador();
            dt = cr.callto_historico_ninos_coordinacion_audiencia(icodie, ruc);

        }

        dt.Columns[0].ColumnName = "COD. TIPO AUDIENCIA";
        dt.Columns[1].ColumnName = "DESCRIPCION";
        dt.Columns[2].ColumnName = "RESOLUCION TRIBUNAL";
        dt.Columns[3].ColumnName = "FECHA AUDIENCIA";

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
