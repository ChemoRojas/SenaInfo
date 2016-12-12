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

public partial class mod_reportes_Rep_Diag_Ninos_DIAG_ESCOLAR : System.Web.UI.UserControl
{
    public DataTable dt_busqueda
    {
        get { return (DataTable)Session["dt_busqueda"]; }
        set { Session["dt_busqueda"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=Reporte_Diagnosticos.xls");

        this.EnableViewState = false;

        System.IO.StringWriter tw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

        DataTable dt = dt_busqueda;
        dt.Columns[0].ColumnName = "COD. NIÑO";	//0
        dt.Columns[1].ColumnName = "ICODIE";			//1
        dt.Columns[2].ColumnName = "APELLIDO PATERNO";		//2
        dt.Columns[3].ColumnName = "APELLIDO MATERNO";		    //3
        dt.Columns[4].ColumnName = "NOMBRES";	    //4
        dt.Columns[5].ColumnName = "RUT";	        //5
        dt.Columns[6].ColumnName = "SEXO";	        //6
        dt.Columns[7].ColumnName = "FECHA NACIMIENTO";	//7
        dt.Columns[8].ColumnName = "FECHA INGRESO";	//8
        dt.Columns[9].ColumnName = "FECHA EGRESO";	        //9
        dt.Columns[10].ColumnName = "COD. ESCOLAR";	//10
        dt.Columns[11].ColumnName = "COD. DIAGNOSTICO";	            //11
        dt.Columns[12].ColumnName = "COD. ESCOLARIDAD";	            //12
        dt.Columns[13].ColumnName = "ESCOLARIDAD";	//13
        dt.Columns[14].ColumnName = "FECHA DIAGNOSTICO";	//14
        dt.Columns[15].ColumnName = "AÑO ESCOLARIDAD";	            //15
        dt.Columns[16].ColumnName = "COD. TIPO ASISTENCIA";	            //16
        dt.Columns[17].ColumnName = "TIPO ASISTENCIA";	            //17
        dt.Columns[18].ColumnName = "TECNICO";		    //18
        dt.Columns[19].ColumnName = "FECHA ACTUALIZACION";	    //19

        //DataRow dr;

        //// Get the HTML for the control.
        //for (int i = 0; i < grd001.Rows.Count; i++)
        //{
        //    dr = dt.NewRow();
        //    for (int j = 0; j < grd001.Columns.Count; j++)
        //    {
        //        dr[j] = grd001.Rows[i].Cells[j].Text;
        //    }
        //    dt.Rows.Add(dr);
        //}

        DataView dv = new DataView(dt);
        DataGrid d1 = new DataGrid();
        d1.DataSource = dv;
        d1.DataBind();
        d1.RenderControl(hw);
        Response.ContentEncoding = System.Text.Encoding.Default;
        Response.Write(tw.ToString());
        Response.End();
    }
    protected void grd001_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd001.PageIndex = e.NewPageIndex;
        grd001.DataSource = dt_busqueda;
        grd001.DataBind();
    }
}
