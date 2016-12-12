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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Drawing;

public partial class mod_reportes_Rep_Informes_Coordinador : System.Web.UI.Page
{
  private DataTable dt_02
  {
    get { return (DataTable)Session["dt_02"]; }
    set { Session["dt_02"] = value; }
  }

 
  protected void Page_Load(object sender, EventArgs e)
  {

    

    //ddown001.SelectedIndex = Convert.ToInt32(listadoSeleccionado);

    if (!IsPostBack)
    {
            if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
            {
                Response.Redirect("~/logout.aspx");
            }
            else
            {
                if (!window.existetoken("073242C5-B273-44C0-85F3-8BDA9627F9BC"))
                {
                    Response.Redirect("~/e403.aspx");
                }
                else
                {
                  CalendarExtende1393.StartDate = Convert.ToDateTime("01-06-2007");
                  CalendarExtende1405.StartDate = Convert.ToDateTime("01-06-2007");
                  CalendarExtende1393.EndDate = DateTime.Now;
                  CalendarExtende1405.EndDate = DateTime.Now;


                  ddown001.SelectedIndex = Convert.ToInt32(Session["indexSeleccionado"]);

                  if (ddown001.SelectedIndex == 0)
                  {
                    imb_05.Visible = false;
                    imb_3.Visible = false;
                  }

                  if (ddown001.SelectedIndex == 1)
                  {
                    imb_05.Visible = true;
                    imb_3.Visible = false;
                  }
                  if (ddown001.SelectedIndex == 2)
                  {

                    imb_3.Visible = true;
                    imb_05.Visible = false;
                  }
                  getmedida();
                  getinstituciones();
                  if (Request.QueryString["sw"] == "3")
                  {
                    ddown002.SelectedValue = Request.QueryString["codinst"];
                    getproyectos();
                  }
                  else if (Request.QueryString["sw"] == "4")
                  {
                    buscador_institucion bsc = new buscador_institucion();
                    int codinst = bsc.GetCodInstxCodProy(Convert.ToInt32(Request.QueryString["codinst"]));
                    ddown002.SelectedValue = Convert.ToString(codinst);
                    getproyectos();
                    ddown003.SelectedValue = Request.QueryString["codinst"];
                  }
               }
            }
      }
  }
  private bool valida()//// VALIDACIONES
  {
    bool sw = true;
    System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

    alerts.Visible = false;
    lbl006.Visible = false;

    if (cal001.Text.ToUpper() == "")
    {
      cal001.BackColor = colorCampoObligatorio;
      sw = false;
      alerts.Visible = true;
      lbl006.Visible = true;  
      lbl006.Text = "Fecha incorrecta, falta Tipo Listado, Institución o Proyecto";
    }
    else
    {
      cal001.BackColor = System.Drawing.Color.White;
    }

    if (cal002.Text.ToUpper() == "")
    {
        cal002.BackColor = colorCampoObligatorio;
      sw = false;
      alerts.Visible = true;
      lbl006.Visible = true;
      lbl006.Text = "Fecha incorrecta, falta Tipo Listado, Institución o Proyecto";
    }
    else
    {
        cal002.BackColor = System.Drawing.Color.White;
    }

    if (ddown001.SelectedIndex == 0)
    {
        ddown001.BackColor = colorCampoObligatorio;
      sw = false;
      alerts.Visible = true;
      lbl006.Visible = true;
      lbl006.Text = "Fecha incorrecta, falta Tipo Listado, Institución o Proyecto";
    }
    else
    {
        ddown001.BackColor = System.Drawing.Color.White;
    }
    if (ddown002.SelectedIndex == 0)
    {
      ddown002.BackColor = colorCampoObligatorio;
      sw = false;
      alerts.Visible = true;
      lbl006.Visible = true;
      lbl006.Text = "Fecha incorrecta, falta Tipo Listado, Institución o Proyecto";
    }
    else
    {
      ddown002.BackColor = System.Drawing.Color.White;
    }

    if (ddown003.SelectedIndex == 0)
    {
      ddown003.BackColor = colorCampoObligatorio;
      sw = false;
      alerts.Visible = true;
      lbl006.Visible = true;
      lbl006.Text = "Fecha incorrecta, falta Tipo Listado, Institución o Proyecto";
    }
    else
    {
      ddown003.BackColor = System.Drawing.Color.White;
    }

    if (cal001.Text != "" && cal002.Text != "")
    {
        if (Convert.ToDateTime(cal001.Text) > Convert.ToDateTime(cal002.Text))
        {
            alerts.Visible = true;
            lbl006.Visible = true;
            lbl006.Text = "Fecha incorrecta, falta Tipo Listado, Institución o Proyecto";
            cal001.BackColor = colorCampoObligatorio;
            cal002.BackColor = colorCampoObligatorio;
            sw = false;
        }
        else
        {
            alerts.Visible = false;
            lbl006.Visible = false;
            lbl006.Text = "Fecha incorrecta, falta Tipo Listado, Institución o Proyecto";
            cal001.BackColor = System.Drawing.Color.White;
            cal002.BackColor = System.Drawing.Color.White;
        }
    }
    
    
    return sw;

  }
  private void getmedida()
  {

    coordinador medida = new coordinador();
    DataView dv04 = new DataView(medida.GetParMedida());

    ddown004.Items.Clear();
    ddown004.DataSource = dv04;
    ddown004.DataTextField = "Descripcion";
    ddown004.DataValueField = "CodModeloIntervencion";
    dv04.Sort = "CodModeloIntervencion";
    ddown004.DataBind();
  }

  private void getinstituciones()
  {

    coordinador Inst = new coordinador();
    DataView dv01 = new DataView(Inst.GetInsCordinador());
    //ddown002.Items.Clear();
    ddown002.Items.Clear();
    ddown002.DataSource = dv01;
    ddown002.DataTextField = "Nombre";
    ddown002.DataValueField = "CodInstitucion";
    dv01.Sort = "CodInstitucion";
    ddown002.DataBind();
  }

  private void getproyectos()
  {
    int User = Convert.ToInt32(Session["IdUsuario"]);
    coordinador cor02 = new coordinador();                  /////trae region del usuario
    DataTable dt02 = cor02.GetCodRegionUser(User);

    int codreg = Convert.ToInt32(dt02.Rows[0][1]);          /// region del usuario
    int codinst = Convert.ToInt32(ddown002.SelectedValue);

    coordinador proy = new coordinador();
    DataView dv02 = new DataView(proy.GetProyCor(codinst, codreg));
    ddown003.Items.Clear();
    ddown003.DataSource = dv02;
    ddown003.DataTextField = "Nombre";
    ddown003.DataValueField = "CodProyecto";
    dv02.Sort = "CodProyecto";
    ddown003.DataBind();


  }
  protected void imb_2_Click(object sender, EventArgs e)
  {
    Response.Redirect("../mod_coordinadores/index_coordinadores.aspx");
  }
  protected void btnBuscaProyecto_Click(object sender, ImageClickEventArgs e)
  {

  }
  protected void ddown002_SelectedIndexChanged(object sender, EventArgs e)
  {
    int User = Convert.ToInt32(Session["IdUsuario"]);
    coordinador cor02 = new coordinador();                  /////trae region del usuario
    DataTable dt02 = cor02.GetCodRegionUser(User);

    int codreg = Convert.ToInt32(dt02.Rows[0][1]);          /// region del usuario
    int codinst = Convert.ToInt32(ddown002.SelectedValue);

    coordinador proy = new coordinador();
    DataView dv02 = new DataView(proy.GetProyCor(codinst, codreg));
    ddown003.Items.Clear();
    ddown003.DataSource = dv02;
    ddown003.DataTextField = "Nombre";
    ddown003.DataValueField = "CodProyecto";
    dv02.Sort = "CodProyecto";
    ddown003.DataBind();



  }

  protected void Buscar_click(object sender, ImageClickEventArgs e)
  {
    string etiqueta = "Busca Proyectos";
    string cadena = string.Empty;

    cadena = @"window.open(this.Page, '../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_reportes/Rep_Informes_Coordinador.aspx', 'Buscador', false, true, '790', '420', false, false, true)";
    ScriptManager.RegisterStartupScript(this, this.GetType(), "Buscador", cadena, true);
  }
  protected void btnBuscaInstitucion_Click(object sender, ImageClickEventArgs e)
  {
    string etiqueta = "Plan de Intervencion";
    string cadena = string.Empty;

    cadena = @"window.open(this.Page, '../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_reportes/Rep_Informes_Coordinador.aspx', 'Buscador', false, true, '770', '420', false, false, true)";
    ScriptManager.RegisterStartupScript(this, this.GetType(), "Buscador", cadena, true);
  }
  protected void imb_1_Click(object sender, EventArgs e)
  {
    ddown003.SelectedIndex = 0;
    ddown002.SelectedIndex = 0;
    ddown004.SelectedIndex = 0;
    ddown005.SelectedIndex = 0;
    ddown001.SelectedIndex = 0;
    cal001.Text = "";
    cal002.Text = "";
    alerts.Visible = false;
    lbl006.Visible = false;
    alert2.Visible = false;
    lblErrorFecha.Visible = false;
    imb_3.Visible = false;
    imb_05.Visible = false;
    Session["indexSeleccion"] = 0;
  }

  protected void imb_3_Click(object sender, EventArgs e)
  {

    if (valida() == true)
    {
      int media;
      int medida;
      int codproy;
      int codinst;

      alerts.Visible = false;
      lbl006.Text = "";

      if (ddown002.SelectedIndex == 0)
      {
        codinst = -1;
      }
      else
      {
        codinst = Convert.ToInt32(ddown002.SelectedValue);
      }

      if (ddown003.SelectedIndex == 0)
      {
        codproy = -1;
      }
      else
      {
        codproy = Convert.ToInt32(ddown003.SelectedValue);
      }


      if (ddown004.SelectedIndex == 0)
      {
        medida = -1;
      }
      else
      {
        medida = Convert.ToInt32(ddown004.SelectedValue);
      }
      if (ddown005.SelectedIndex == 0)
      {
        media = 0;
      }
      else
      {
        media = Convert.ToInt32(ddown005.SelectedValue);
      }

      if (cal001.Text == "Seleccione Fecha" || cal001.Text == "")
      {
          cal001.Text = "01-06-2007";
      }

      DateTime fechaini = Convert.ToDateTime(cal001.Text);
      DateTime fechater = Convert.ToDateTime(cal002.Text);

      if (fechaini < fechater)
      {
        coordinador bsq = new coordinador();
        int UserId = Convert.ToInt32(Session["IdUsuario"]);
        DataTable dt = bsq.getCertificadoI(UserId, codinst, codproy, medida, media, fechaini, fechater);


        DataTable dtCrtIngreso = dt;

        if (dtCrtIngreso.Rows.Count > 0)
        {
          ExportOptions crExportOptions = new ExportOptions();
          DiskFileDestinationOptions crDiskFileDestinationOptions = new DiskFileDestinationOptions();
          ReportDocument crReporteEventos = new ReportDocument();

          string rptPath = ConfigurationSettings.AppSettings["PathReportes"].ToString();//@"C:\Inetpub\wwwroot\ARGENTIS.SENAINFO\Reportes\";
          //DateTime dFecha = Convert.ToDateTime(cal001.Text);

          crReporteEventos.Load(@rptPath + "CrCertificadoIngreso.rpt");
          //  crReporteEventos.DataDefinition.FormulaFields["FechaVigencia"].Text = "date(" + dFecha.Year + "," + dFecha.Month + "," + dFecha.Day + ")";
          crReporteEventos.SetDataSource(dtCrtIngreso);
          crReporteEventos.Refresh();

          string Fname = ConfigurationSettings.AppSettings["PathReportes"].ToString() + "crCertificadoIngreso.pdf";//@"C:\Inetpub\wwwroot\ARGENTIS.SENAINFO\Reportes\crCatastroJueces.pdf";
          crReporteEventos.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
          crDiskFileDestinationOptions.DiskFileName = Fname;
          crExportOptions = crReporteEventos.ExportOptions;
          crExportOptions.DestinationOptions = crDiskFileDestinationOptions;
          crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
          crExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;

          crReporteEventos.Export();
          crReporteEventos.Dispose();
          		//System.Web.UI.Page sCDP = new Page();
          //Modifica el header de la página para descargar el archivo .pdf	
          this.Response.ClearContent();
          this.Response.ClearHeaders();
          this.Response.ContentType = "application/pdf";
          this.Response.AddHeader("content-disposition", "attachment;filename=Certificado.pdf");
          this.Response.WriteFile(Fname);
          this.Response.Flush();
          this.Response.Close();
          //delete the exported file from disk
          System.IO.File.Delete(Fname);
          crReporteEventos.Dispose();
          crReporteEventos.Close();
         
          //Limpia el form luego de imprimir
            imb_1_Click(null, null);
        }
        else
        {
          alerts.Visible = true;
          //lbl006.Visible = true;
          //alerts.Visible = true;
          lblSinResultados.Visible = true;
        }
      } else
      {
        alert2.Visible = true;
        lblErrorFecha.Visible = true;
        alerts.Visible = false;
        lbl006.Visible = false;
      }

       //coordinador bsq = new coordinador();
      //int UserId = Convert.ToInt32(Session["IdUsuario"]);
      //DataTable dt = bsq.getCertificadoI(UserId, codinst, codproy, medida, media, fechaini, fechater);


      //DataTable dtCrtIngreso = dt;

      //if (dtCrtIngreso.Rows.Count > 0)
      //{
      //  ExportOptions crExportOptions = new ExportOptions();
      //  DiskFileDestinationOptions crDiskFileDestinationOptions = new DiskFileDestinationOptions();
      //  ReportDocument crReporteEventos = new ReportDocument();

      //  string rptPath = ConfigurationSettings.AppSettings["PathReportes"].ToString();//@"C:\Inetpub\wwwroot\ARGENTIS.SENAINFO\Reportes\";
      //  //DateTime dFecha = Convert.ToDateTime(cal001.Text);

      //  crReporteEventos.Load(@rptPath + "CrCertificadoIngreso.rpt");
      //  //  crReporteEventos.DataDefinition.FormulaFields["FechaVigencia"].Text = "date(" + dFecha.Year + "," + dFecha.Month + "," + dFecha.Day + ")";
      //  crReporteEventos.SetDataSource(dtCrtIngreso);
      //  crReporteEventos.Refresh();

      //  string Fname = ConfigurationSettings.AppSettings["PathReportes"].ToString() + "crCertificadoIngreso.pdf";//@"C:\Inetpub\wwwroot\ARGENTIS.SENAINFO\Reportes\crCatastroJueces.pdf";
      //  crReporteEventos.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
      //  crDiskFileDestinationOptions.DiskFileName = Fname;
      //  crExportOptions = crReporteEventos.ExportOptions;
      //  crExportOptions.DestinationOptions = crDiskFileDestinationOptions;
      //  crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
      //  crExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;

      //  crReporteEventos.Export();
      //  crReporteEventos.Dispose();
      //  //		System.Web.UI.Page sCDP = new Page();
      //  //Modifica el header de la página para descargar el archivo .pdf	
      //  this.Response.ClearContent();
      //  this.Response.ClearHeaders();
      //  this.Response.ContentType = "application/pdf";
      //  this.Response.WriteFile(Fname);
      //  this.Response.Flush();
      //  this.Response.Close();
      //  //delete the exported file from disk
      //  System.IO.File.Delete(Fname);
      //  crReporteEventos.Dispose();
      //  crReporteEventos.Close();
      //}
      //else
      //{
      //  alerts.Visible = true;
      //  lbl005.Visible = true;
      //}
//

    }
  }

  protected void ddown001_SelectedIndexChanged(object sender, EventArgs e)
  {
    if (ddown001.SelectedIndex == 1)
    {
      imb_05.Visible = true;
      imb_3.Visible = false;
      Session["indexSeleccionado"] = ddown001.SelectedIndex;
    }

    if (ddown001.SelectedIndex == 2)
    {
      imb_3.Visible = true;
      imb_05.Visible = false;
      Session["indexSeleccionado"] = ddown001.SelectedIndex;
    }

    if (ddown001.SelectedIndex == 0)
    {
      imb_3.Visible = false;
      imb_05.Visible = false;
      Session["indexSeleccionado"] = ddown001.SelectedIndex;
    }
    alerts.Visible = false;
    lbl006.Visible = false;
  }
  protected void ddown003_SelectedIndexChanged(object sender, EventArgs e)
  {
    alerts.Visible = false;
    lbl006.Visible = false;
  }
  protected void imb_05_Click(object sender, EventArgs e)
  {
      alerts.Visible = false;
      lblSinResultados.Visible = false;
    if (valida() == true)
    {
      
      int media;
      int medida;
      int codproy;
      int codinst;

      alerts.Visible = false;
      lbl006.Text = "";
      int UserId = Convert.ToInt32(Session["IdUsuario"]);

      if (ddown002.SelectedIndex == 0)
      {
          codinst = -1;
      }
      else
      {
          codinst = Convert.ToInt32(ddown002.SelectedValue);
      }

      if (ddown003.SelectedIndex == 0)
      {
          codproy = -1;
      }
      else
      {
          codproy = Convert.ToInt32(ddown003.SelectedValue);
      }


      if (ddown004.SelectedIndex == 0)
      {
          medida = -1;
      }
      else
      {
          medida = Convert.ToInt32(ddown004.SelectedValue);
      }
      if (ddown005.SelectedIndex == 0)
      {
          media = 0;
      }
      else
      {
          media = Convert.ToInt32(ddown005.SelectedValue);
      }

      DateTime fechaini = Convert.ToDateTime(cal001.Text);
      DateTime fechater = Convert.ToDateTime(cal002.Text);

      if (fechaini > fechater)
      {
          cal001.BackColor = Color.Pink;
          cal002.BackColor = Color.Pink;
          alerts.Visible = true;
          lbl006.Visible = true;
          lbl006.Text = "Fecha incorrecta, Falta Tipo Listado, Institución o Proyecto";
      }
      else
      {
          alerts.Visible = false;
          lbl006.Visible = false;
          lbl006.Text = "Fecha incorrecta, Falta Tipo Listado, Institución o Proyecto";
      }

      coordinador bsq = new coordinador();
      DataTable dt = bsq.getexcelcordina(UserId, codinst, codproy, medida, media, fechaini, fechater);


      if (dt.Rows.Count > 0)
      {
          
          Response.Clear();
          Response.Buffer = true;
          Response.ContentType = "application/vnd.ms-excel";
          Response.AddHeader("Content-Disposition", "attachment;filename=Reporte_Nino.xls");
          Response.Charset = "";
          this.EnableViewState = false;

          System.IO.StringWriter tw = new System.IO.StringWriter();
          System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

          DataView dv = new DataView(dt);

          DataGrid d1 = new DataGrid();

          d1.DataSource = dv;
          d1.DataBind();
          d1.RenderControl(hw);
          Response.ContentEncoding = System.Text.Encoding.Default;
          Response.Write(tw.ToString());
          Response.End();

          //Limpia el form luego de imprimir
          imb_1_Click(null, null);
          
      }
      else
      {
          alerts.Visible = true;
          lblSinResultados.Visible = true;
      }
    }
  }

  protected void ddown004_SelectedIndexChanged(object sender, EventArgs e)
  {
    alerts.Visible = false;
    lbl006.Visible = false;
  }
  protected void ddown005_SelectedIndexChanged(object sender, EventArgs e)
  {
    alerts.Visible = false;
    lbl006.Visible = false;
  }
  protected void cal001_TextChanged(object sender, EventArgs e)
  {
    CalendarExtende1405.StartDate = Convert.ToDateTime(cal001.Text.Substring(0,10));
    CalendarExtende1405.EndDate = DateTime.Now;
  }
  protected void UpdateProgress1_Init(object sender, EventArgs e)
  {

  }
  
}