  
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

public partial class mod_reportes_Rep_OcupacionDiariaCentros : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    if (!IsPostBack)
    {
      if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
      {
          Response.Redirect("~/logout.aspx");
          
      }
      else
      {
        //cal001.MaxDate = DateTime.Now.AddDays(-1);
        CalendarExtender3.EndDate = DateTime.Now;
      }
    }
  }
  protected void cal001_ValueChanged(object sender, EventArgs e)
  {

  }

  protected void imb_004_Click(object sender, EventArgs e)
  {

  }
  protected void imb_001d_Click(object sender, EventArgs e)
  {
    
    bool sw = Valida();
    if (sw == true)
    {
      exportarExcel.Visible = true;
      pnlError.Visible = false;
      lblError.Visible = false;
      alerts.Visible = false;
      lblError.Text = "";
      ReporteNinoColl repcoll = new ReporteNinoColl();
      //DateTime fecha = Convert.ToDateTime(cal001.Value);
      DateTime fecha = Convert.ToDateTime(txtFecha.Text);
      int dia = fecha.Day;
      int mes = fecha.Month;
      int ano = fecha.Year;
      DataTable dt = repcoll.Reporte_AsistenciaDiariaAADD(Convert.ToDateTime(dia + "/" + mes + "/" + ano), Convert.ToInt32(Session["IdUsuario"]));
      lblaviso.Visible = false;

      if (dt.Rows.Count <= 0)
      {
          alerts.Visible = true;
        pnlError.Visible = true;
        lblError.Visible = true;
        lblError.Text = "No se han encontrado registros";
        exportarExcel.Visible = false;

      }
      else
      {
        //dt.Columns[0].ColumnName = "FechaAsistencia";
        dt.Columns[0].ColumnName = "CodRegion";
        dt.Columns[1].ColumnName = "Proyecto";
        dt.Columns[2].ColumnName = "CodProyecto";
        dt.Columns[3].ColumnName = "Presentes";
        dt.Columns[4].ColumnName = "Ausentes";
        dt.Columns[5].ColumnName = "Permisos";

        DataView dv = new DataView(dt);

        //GridView grd001 = new GridView();
        grd001.Visible = true;
        grd001.DataSource = dv;
        grd001.DataBind();
      }
    }
  }
  protected void imb_003d_Click(object sender, EventArgs e)
  {
    //cal001.Value = "Seleccione Fecha";
    txtFecha.Text = "";
  }
  protected void imb_004d_Click(object sender, EventArgs e)
  {
    Response.Redirect("../mod_reportes/Rep_ReportesLRPA.aspx");
  }
  private bool Valida()
  {
    bool sw = false;
    //if(cal001.Value.ToString() == "Seleccione Fecha")
    if (txtFecha.Text == "")
    {
      //cal001.BackColor = System.Drawing.Color.Yellow;
      txtFecha.BackColor = System.Drawing.Color.Yellow;
      sw = false;
    }
    else
    {
      //cal001.BackColor = System.Drawing.Color.White;
      txtFecha.BackColor = System.Drawing.Color.White;
      sw = true;
    }
    return (sw);
  }
  protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
  {
    //if (cal001.Text.ToString() == "Seleccione Fecha")
    if (txtFecha.Text == "")
    {
      lblaviso.Text = "Ingrese una fecha valida";
      lblaviso.Visible = true;
    }
    else
    {

      lblaviso.Text = "";
      lblaviso.Visible = false;

      ReporteNinoColl rpn = new ReporteNinoColl();
      //DataTable dt = rpn.Reporte_AsistenciaDiariaAADD(Convert.ToDateTime(Convert.ToDateTime(cal001.Text).ToShortDateString()), Convert.ToInt32(Session["IdUsuario"]) );
      DataTable dt = rpn.Reporte_AsistenciaDiariaAADD(Convert.ToDateTime(Convert.ToDateTime(txtFecha.Text).ToShortDateString()), Convert.ToInt32(Session["IdUsuario"]));


      Response.Clear();
      Response.Buffer = true;
      Response.ContentType = "application/vnd.ms-excel";
      Response.AddHeader("Content-Disposition", "attachment;filename=Reporte_OcupacionDiariaCentros.xls");

      this.EnableViewState = false;

      System.IO.StringWriter tw = new System.IO.StringWriter();
      System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);


      if (dt.Rows.Count <= 0)
      {
          alerts.Visible = true;
          pnlError.Visible = true;
          lblError.Text = "No se han encontrado registros";
          lblError.Visible = true;
          exportarExcel.Visible = false;
      }

      else
      {
          alerts.Visible = false;
          lblError.Visible = false;
          ////dt.Columns[0].ColumnName = "FechaAsistencia";
          dt.Columns[0].ColumnName = "CodRegion";
          dt.Columns[1].ColumnName = "Proyecto";
          dt.Columns[2].ColumnName = "CodProyecto";
          dt.Columns[3].ColumnName = "Presentes";
          dt.Columns[4].ColumnName = "Ausentes";
          dt.Columns[5].ColumnName = "PermisosSalidas";

          DataView dv = new DataView(dt);

          GridView grd001 = new GridView();
          grd001.DataSource = dv;
          grd001.DataBind();
          grd001.RenderControl(hw);

          Response.ContentEncoding = System.Text.Encoding.Default;
          Response.Write(tw.ToString());
          Response.End();
      }

      //dt.Columns[0].ColumnName = "FechaAsistencia";
      //dt.Columns[1].ColumnName = "CodRegion";
      //dt.Columns[2].ColumnName = "Proyecto";
      //dt.Columns[3].ColumnName = "CodProyecto";
      //dt.Columns[4].ColumnName = "Presentes";
      //dt.Columns[5].ColumnName = "Ausentes";
      //dt.Columns[6].ColumnName = "PermisosSalidas";

    }

  }

  /*-----------------------------------------------------------------------------------------
  // 29/12/2014
  // Juan Valenzuela.
  // Se modifican botones para descartar uso de libreria Infragistics.
  //-----------------------------------------------------------------------------------------*/

  protected void btnLimpiar_NEW_Click(object sender, EventArgs e)
  {
    //cal001.Value = "Seleccione Fecha";
    txtFecha.Text = "";
  }
  protected void btnVolver_NEW_Click(object sender, EventArgs e)
  {
    Response.Redirect("../mod_reportes/Rep_ReportesLRPA.aspx");
  }
  //protected void ImbCalFecha_Click(object sender, ImageClickEventArgs e)
  //{
  //    CalFecha.Visible = !(CalFecha.Visible);
  //}
  //protected void CalFecha_SelectionChanged(object sender, EventArgs e)
  //{
  //    txtFecha.Text = CalFecha.SelectedDate.ToString();
  //    txtFecha.Text = txtFecha.Text.Substring(0, 10);
  //    CalFecha.Visible = false;
  //}
  protected void btnLimpiar_Click(object sender, EventArgs e)
  {
    grd001.Visible = false;
    txtFecha.Text = string.Empty;
    exportarExcel.Visible = false;
    alerts.Visible = false;

    
  }
  protected void exportarExcel_Click(object sender, EventArgs e)
  {
    //if (cal001.Text.ToString() == "Seleccione Fecha")
    if (txtFecha.Text == "")
    {
      lblaviso.Text = "Ingrese una fecha valida";
      lblaviso.Visible = true;
    }
    else
    {

      lblaviso.Text = "";
      lblaviso.Visible = false;

      ReporteNinoColl rpn = new ReporteNinoColl();
      //DataTable dt = rpn.Reporte_AsistenciaDiariaAADD(Convert.ToDateTime(Convert.ToDateTime(cal001.Text).ToShortDateString()), Convert.ToInt32(Session["IdUsuario"]) );
      DataTable dt = rpn.Reporte_AsistenciaDiariaAADD(Convert.ToDateTime(Convert.ToDateTime(txtFecha.Text).ToShortDateString()), Convert.ToInt32(Session["IdUsuario"]));


      Response.Clear();
      Response.Buffer = true;
      Response.ContentType = "application/vnd.ms-excel";
      Response.AddHeader("Content-Disposition", "attachment;filename=Reporte_OcupacionDiariaCentros.xls");

      this.EnableViewState = false;

      System.IO.StringWriter tw = new System.IO.StringWriter();
      System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);


      ////dt.Columns[0].ColumnName = "FechaAsistencia";
      dt.Columns[0].ColumnName = "CodRegion";
      dt.Columns[1].ColumnName = "Proyecto";
      dt.Columns[2].ColumnName = "CodProyecto";
      dt.Columns[3].ColumnName = "Presentes";
      dt.Columns[4].ColumnName = "Ausentes";
      dt.Columns[5].ColumnName = "PermisosSalidas";


      //dt.Columns[0].ColumnName = "FechaAsistencia";
      //dt.Columns[1].ColumnName = "CodRegion";
      //dt.Columns[2].ColumnName = "Proyecto";
      //dt.Columns[3].ColumnName = "CodProyecto";
      //dt.Columns[4].ColumnName = "Presentes";
      //dt.Columns[5].ColumnName = "Ausentes";
      //dt.Columns[6].ColumnName = "PermisosSalidas";

      DataView dv = new DataView(dt);

      GridView grd001 = new GridView();
      grd001.DataSource = dv;
      grd001.DataBind();
      grd001.RenderControl(hw);

      Response.ContentEncoding = System.Text.Encoding.Default;
      Response.Write(tw.ToString());
      Response.End();
    }
  }
}