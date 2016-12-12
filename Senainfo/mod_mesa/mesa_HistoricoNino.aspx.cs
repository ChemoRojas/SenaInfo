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
        ninocoll ncoll = new ninocoll();

        DataTable dt = ncoll.callto_historico_ingresos(SSninoDiag.CodNino);
        DataView dv = new DataView(dt);
        ugrd001.DataSource = dv;
        ugrd001.DataBind();
    }


    protected void WebImageButton1_Click(object sender, EventArgs e)
    {
        window.close(this.Page);
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

        ninocoll ncoll = new ninocoll();
        DataTable dt = ncoll.callto_historico_ingresos(SSninoDiag.CodNino);
        dt.Columns[0].ColumnName = "ICODIE";
        dt.Columns[1].ColumnName = "COD. NINO";
        dt.Columns[2].ColumnName = "FECHA INGRESO";
       // dt.Columns[3].ColumnName = "COD. CAUSAL INGRESO 1";
       //dt.Columns[4].ColumnName = "COD. CAUSAL INGRESO 2";
       //  dt.Columns[5].ColumnName = "COD. CAUSAL INGRESO 3";
        dt.Columns[3].ColumnName = "CAUSAL INGRESO 1";
        dt.Columns[4].ColumnName = "CAUSAL INGRESO 2";
        dt.Columns[5].ColumnName = "CAUSAL INGRESO 3";
        dt.Columns[6].ColumnName = "RUT";
        dt.Columns[7].ColumnName = "APELLIDO PATERNO";
        dt.Columns[8].ColumnName = "APELLIDO MATERNO";
        dt.Columns[9].ColumnName = "NOMBRES";
        dt.Columns[10].ColumnName = "COD. PROYECTO";
        dt.Columns[11].ColumnName = "PROYECTO";
        dt.Columns[12].ColumnName = "COD. INSTITUCION";
        dt.Columns[13].ColumnName = "NOMBRE INSTITUCION";
        //dt.Columns[17].ColumnName = "COD. MODELO INTERV.";
        dt.Columns[14].ColumnName = "MODELO INTERVENCION";
        dt.Columns[15].ColumnName = "FECHA EGRESO";
        //dt.Columns[20].ColumnName = "COD. CAUSAL EGRESO";
        dt.Columns[16].ColumnName = "CAUSAL EGRESO";
        //dt.Columns[22].ColumnName = "COD. CON QUIEN EGRESA";
        dt.Columns[17].ColumnName = "CON QUIEN EGRESA";
        dt.Columns[18].ColumnName = "ORDENES TRIBUNAL";
        dt.Columns[19].ColumnName = "TRIBUNAL";
        dt.Columns[20].ColumnName = "EXPEDIENTE";
        dt.Columns[21].ColumnName = "RUC";
        dt.Columns[22].ColumnName = "RIT";
        dt.Columns[23].ColumnName = "DIRECCION";
        //dt.Columns[30].ColumnName = "COD. DIRECCION";
        dt.Columns[24].ColumnName = "COMUNA";

        DataView dv = new DataView(dt);
        DataGrid d1 = new DataGrid();
        d1.DataSource = dv;
        d1.DataBind();
        
        //d1.Columns[3].Visible = false;
        //d1.Columns[4].Visible = false;
        //d1.Columns[5].Visible = false;
        //d1.Columns[17].Visible = false;
        //d1.Columns[20].Visible = false;
        //d1.Columns[22].Visible = false;
        //d1.Columns[30].Visible = false;
        
        d1.RenderControl(hw);
        Response.ContentEncoding = System.Text.Encoding.Default;
        Response.Write(tw.ToString());
        Response.End();
      
    }
    protected void UltraWebGrid1_InitializeLayout(object sender, EventArgs e)
    {

    }
}
