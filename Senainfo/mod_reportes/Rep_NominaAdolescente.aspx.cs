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
using System.Drawing;

public partial class mod_reportes_Rep_NominaAdolescente : System.Web.UI.Page
{
    public string FechaConsulta
    {
        get { return (string)Session["FechaConsulta"]; }
        set { Session["FechaConsulta"] = value; }
    }

    public string CodInst
    {
        get { return (string)Session["CodInst"]; }
        set { Session["CodInst"] = value; }
    }

    public string CodProy
    {
        get { return (string)Session["CodProy"]; }
        set { Session["CodProy"] = value; }
    }
    public string NomProy
    {
        get { return (string)Session["NomProy"]; }
        set { Session["NomProy"] = value; }
    }
    public DataTable DTAno
    {
        get { return (DataTable)Session["DTAno"]; }
        set { Session["DTAno"] = value; }
    }
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
                lblmes.Visible = false;
                lblano.Visible = false;
                lbl_periodo.Visible = false;
                ddown004.Visible = false;
                wne001.Visible = false;
                // JOVM - 29/12/2014
                //cal001.Visible = true;
                txtFecha.Visible = false;
                divFecha.Visible = false;
                divPeriodo.Visible = false;
                //ImbCalFecha.Visible = true;

                calExtender.EndDate = DateTime.Now;

                getinstituciones();
                getproyecto();

                ddownProyectos.Items.Add(new ListItem(" Seleccionar", "-1"));

                wne001.Items.Clear();

                ListItem oItem = new ListItem("Seleccionar", "0");
                wne001.Items.Add(oItem);
                int iAno;

                for (int i = 0; i <= (System.DateTime.Now.Year - 2007); i++)
                {
                    iAno = 2007 + i;
                    oItem = new ListItem(iAno.ToString(), iAno.ToString());
                    wne001.Items.Add(oItem);
                }

                
            }
            if (Request.QueryString["sw"] == "4")
            {
              if (Request.QueryString["codinst"] != "")
              {
                ddownProyectos.SelectedValue = Request.QueryString["codinst"];
                ddown001.SelectedValue = Request.QueryString["codproy"];
                txt001.Text = Request.QueryString["codinst"];
              }
            }
        }
       

    }
    protected void ddown003_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddown003.SelectedValue == "0")
        {
            lblaviso.Text = "Ingrese un Tipo de Listado";
            lblaviso.Visible = true;
            errorPanel.Visible = true;
            panelCorrecto.Visible = false;
            lblCorrecto.Visible = false;
            ddown004.Visible = false;
            wne001.Visible = false;
            lblano.Visible = false;
            lblmes.Visible = false;
            lbl_periodo.Visible = false;
            divPeriodo.Visible = false;
        }
        else if (ddown003.SelectedValue == "1" || ddown003.SelectedValue == "2" || ddown003.SelectedValue == "4")
        {

            lbl_periodo.Visible = true;
            divPeriodo.Visible = true;

            ddown004.Visible = true;
            wne001.Visible = true;
            lblano.Visible = true;
            lblmes.Visible = true;
            panelCorrecto.Visible = false;
            lblCorrecto.Visible = false;

            // JOVM - 29/12/2014
            //cal001.Visible = false;
            txtFecha.Visible = false;
            lbl_fecha.Visible = false;
            divFecha.Visible = false;
            //ImbCalFecha.Visible = false;

            lblaviso.Visible = false;
            errorPanel.Visible = false;

            
           
        }
        else 
        {
            ddown004.Visible = false;
            wne001.Visible = false;
            lblano.Visible = false;
            lblmes.Visible = false;

            // JOVM - 29/12/2014
            //cal001.Visible = true;
            lbl_periodo.Visible = false;
            divPeriodo.Visible = false;

            lbl_fecha.Visible = true;
            divFecha.Visible = true;
            txtFecha.Visible = true;
            //ImbCalFecha.Visible = true;

            lblaviso.Visible = false;
            errorPanel.Visible = false;

            txtFecha.Enabled = true;
            panelCorrecto.Visible = false;
            lblCorrecto.Visible = false;


    
        }

    }
    protected void cal001_ValueChanged(object sender, EventArgs e)
    {

    }
    protected void ddown004_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void wne001_ValueChange(object sender, EventArgs e)
    {
        if (Convert.ToInt32(wne001.Text) < 2.007)
        {
            wne001.SelectedValue = "0";
            lblaviso.Text = "Ingrese un Año Mayor a 2007";
            lblaviso.Visible = true;
        }
        else 
        {
            lblaviso.Text = "";
            lblaviso.Visible = false;
        }
    }
    protected void imb_003_Click(object sender, EventArgs e)
    {
        Response.Redirect("../mod_reportes/Rep_ReportesLRPA.aspx");
    }
    protected void imb_002_Click(object sender, EventArgs e)
    {
        Limpiaformulario();
    }
    private void Limpiaformulario()
    {
        ddown001.SelectedValue = "0";
        ddown003.SelectedValue = "0";
        ddown004.SelectedValue = "0";
        wne001.SelectedValue = "0";
        txt001.Text = "";
        ddown004.Visible = true;

        // JOVM - 29/12/2014
        //cal001.Visible = false;
        txtFecha.Visible = false;
        divFecha.Visible = true;
        lbl_fecha.Visible = true;
        //ImbCalFecha.Visible = false;
        lbl_periodo.Visible = true;
        divPeriodo.Visible = true;

        lblmes.Visible = true;
        lblano.Visible = true;
        lblaviso.Visible = false;

    
    }


    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        //Get_Nomina_LPRA


        ReporteNinoColl rpn = new ReporteNinoColl();

        // JOVM - 29/12/2014
        //DateTime fecha = Convert.ToDateTime(cal001.Value);
        DateTime fecha = Convert.ToDateTime(txtFecha.Text);
        String MesAno = "0";
        if (Convert.ToInt32(Convert.ToString(fecha.Month).Length) < 10)
        {
           MesAno = Convert.ToString(fecha.Year) + "0" + Convert.ToString(fecha.Month);
        }
        else 
        {
            MesAno = Convert.ToString(fecha.Year) + Convert.ToString(fecha.Month);
        }
        string CodProyecto = txt001.Text.Substring(1,7);
        // JOVM - 29/12/2014
        //DataTable dt = rpn.Reporte_Nomina_LPRA(Convert.ToInt32(ddown003.SelectedValue),Convert.ToInt32(CodProyecto), Convert.ToDateTime(cal001.Value), Convert.ToInt32(MesAno), ASP.global_asax.globaconn);
        DataTable dt = rpn.Reporte_Nomina_LPRA(Convert.ToInt32(ddown003.SelectedValue), Convert.ToInt32(CodProyecto), Convert.ToDateTime(txtFecha.Text), Convert.ToInt32(MesAno));
           
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=Nomina_LRPA.xls");

        this.EnableViewState = false;

        System.IO.StringWriter tw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

              
        dt.Columns[0].ColumnName = "CodProyecto";
        dt.Columns[1].ColumnName = "NombreProyecto";
        dt.Columns[2].ColumnName = "CodRegion";
        dt.Columns[3].ColumnName = "Region";
        dt.Columns[4].ColumnName = "Medio";
        dt.Columns[5].ColumnName = "icodie";
        dt.Columns[6].ColumnName = "FechaIngreso";
        dt.Columns[7].ColumnName = "FechaEgreso";
        dt.Columns[8].ColumnName = "Nombres";
        dt.Columns[9].ColumnName = "Apellido_Materno";
        dt.Columns[10].ColumnName = "Apellido_Paterno";
        dt.Columns[11].ColumnName = "rut";
        dt.Columns[12].ColumnName = "FechaNacimineto";
        dt.Columns[13].ColumnName = "sexo";
        dt.Columns[14].ColumnName = "EdadAlIngreso";
        dt.Columns[15].ColumnName = "RegionOrigen";
        dt.Columns[16].ColumnName = "CausalEgreso";
        dt.Columns[17].ColumnName = "RegionTribunal";
        dt.Columns[18].ColumnName = "RUC";
        dt.Columns[19].ColumnName = "RIT";
        dt.Columns[20].ColumnName = "FechaInicio";
        dt.Columns[21].ColumnName = "AnoDuracion";
        dt.Columns[22].ColumnName = "MesDuracion";
        dt.Columns[23].ColumnName = "DiaDuracion";
        dt.Columns[24].ColumnName = "FechaTermino";
        dt.Columns[25].ColumnName = "Abono";
        dt.Columns[26].ColumnName = "Horas";
        dt.Columns[27].ColumnName = "SancionAccesoria";
        dt.Columns[28].ColumnName = "escolaridadIngreso";
        dt.Columns[29].ColumnName = "anoescolar";
        dt.Columns[30].ColumnName = "FechaElaboracionPII";
        dt.Columns[31].ColumnName = "codmodelointervencion";
        dt.Columns[32].ColumnName = "ModeloIntervencion";
        dt.Columns[33].ColumnName = "Nemotecnico";


        Response.ContentEncoding = System.Text.Encoding.Default;
        Response.Write(tw.ToString());
        Response.End();
       
    }
    private void getinstituciones()
    {
        institucioncoll ncoll = new institucioncoll();
        DataView dv1 = new DataView(ncoll.GetData(Convert.ToInt32(Session["IdUsuario"]) ));
        ddown001.DataSource = dv1;
        ddown001.DataTextField = "Nombre";
        ddown001.DataValueField = "CodInstitucion";
        dv1.Sort = "Nombre";
        ddown001.DataBind();

    }


    private void getproyecto()
    {

      proyectocoll proy = new proyectocoll();
      //proy.GetProyectos_Region_Institucion
      DataView dv3 = new DataView(proy.GetDataII(Convert.ToInt32(Session["IdUsuario"]), "V", Convert.ToInt32(ddown001.SelectedValue)));

      ddownProyectos.DataSource = dv3;
      ddownProyectos.DataTextField = "Nombre";
      ddownProyectos.DataValueField = "CodProyecto";
      dv3.Sort = "CodProyecto";
      ddownProyectos.DataBind();

   
    }
    protected void ddown001_SelectedIndexChanged(object sender, EventArgs e)
    {
        getproyecto();
    }

    private bool validacion()
    {
        bool sw = true;
    
        //if (txt001.Text.Trim() == "")
        //{
        //    txt001.BackColor = System.Drawing.Color.Pink;
        //    sw = false;
        //}
        //else 
        //{
        //    txt001.BackColor = System.Drawing.Color.White;
        //}
       
        if (ddown003.SelectedValue != "0")
        {
            //sw = true;
            ddown003.BackColor = System.Drawing.Color.White;
        }
        else
        {
            ddown003.BackColor = System.Drawing.Color.Pink;
            sw = false;

        }
        if (ddown003.SelectedValue == "3")
        {
            // JOVM - 29/12/2014
            //if (cal001.Text == "Seleccione Fecha")
            if (txtFecha.Text=="")
            {
                // JOVM - 29/12/2014
                //cal001.BackColor = System.Drawing.Color.Pink;
                txtFecha.BackColor = System.Drawing.Color.Pink;
                sw = false;
            }
            else
            {
                // JOVM - 29/12/2014
                //cal001.BackColor = System.Drawing.Color.White;
                txtFecha.BackColor = System.Drawing.Color.White;
                // JOVM - 29/12/2014
                //FechaConsulta = cal001.Text;
                FechaConsulta = txtFecha.Text;
                
                //sw = true;        
            }
        }
        else 
        {
            if (ddown004.SelectedValue == "0" || wne001.SelectedValue == "0")
            {
                if (ddown004.SelectedValue == "0")
                {
                    ddown004.BackColor = System.Drawing.Color.Pink;
                    sw = false;
                }
                if (wne001.SelectedValue == "0")
                {
                    ddown004.BackColor = System.Drawing.Color.Pink;
                    sw = false;
                }
                
            }
            else 
            {
                ddown004.BackColor = System.Drawing.Color.White;
                ddown004.BackColor = System.Drawing.Color.White;
                sw = true;
                FechaConsulta = "01-01-1900";
            }
            if (Convert.ToInt32(ddown004.SelectedValue) < 9)
            {
                FechaConsulta = Convert.ToString("01-" + "0"+ddown004.SelectedValue + "-" + wne001.SelectedValue);
            }
            else 
            {
                FechaConsulta = Convert.ToString("01-" + ddown004.SelectedValue + "-" + wne001.SelectedValue);
            }
        
        }
        return (sw);
    
    }
    
    protected void imb001_Click(object sender, ImageClickEventArgs e)
    {       
        bool sw = validacion();

        if (txt001.Text.Length <= 3)
            sw = false;

        if (sw == true)
        {
            lblaviso.Visible = false;
            ReporteNinoColl rpn = new ReporteNinoColl();
           
            String MesAno = "0";
            if (Convert.ToDateTime(FechaConsulta).Month < 9)
            {
                MesAno = Convert.ToString(Convert.ToDateTime(FechaConsulta).Year) + "0" + Convert.ToString(Convert.ToDateTime(FechaConsulta).Month);
            }
            else
            {
                MesAno = Convert.ToString(Convert.ToDateTime(FechaConsulta).Year) + Convert.ToString(Convert.ToDateTime(FechaConsulta).Month);
            }
           
            String CodProyecto2 = txt001.Text.Substring(1, 7);
            DataTable dt0 = rpn.Reporte_GetProyectosLPRA(Convert.ToInt32(CodProyecto2) );
            if (dt0.Rows[0][0].ToString() == "1")
            {
                txt001.BackColor = Color.White;
                ddown003.BackColor = Color.White;
                ddown004.BackColor = Color.White;
                wne001.BackColor = Color.White;
                ddown001.BackColor = Color.White;

                //Get_Nomina_LRPA
                DataTable dt = rpn.Reporte_Nomina_LPRA(Convert.ToInt32(ddown003.SelectedValue), Convert.ToInt32(CodProyecto2), Convert.ToDateTime(FechaConsulta), Convert.ToInt32(MesAno.Trim()) );

                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", "attachment;filename=Nomina_LRPA.xls");

                this.EnableViewState = false;

                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);



                dt.Columns[0].ColumnName ="CodProyecto";
                dt.Columns[1].ColumnName = "NombreProyecto";
                dt.Columns[2].ColumnName ="CodRegion";
                dt.Columns[3].ColumnName ="Region";
                dt.Columns[4].ColumnName ="Nemotecnico";
                dt.Columns[5].ColumnName ="Medio";
                dt.Columns[6].ColumnName ="icodie";
                dt.Columns[7].ColumnName ="codnino";
                dt.Columns[8].ColumnName ="Nombres";
                dt.Columns[9].ColumnName ="Apellido_Paterno";
                dt.Columns[10].ColumnName = "Apellido_Materno";
                dt.Columns[11].ColumnName ="rut";
                dt.Columns[12].ColumnName ="FechaNacimiento";
                dt.Columns[13].ColumnName ="sexo";
                dt.Columns[14].ColumnName ="EdadAlIngreso";
                dt.Columns[15].ColumnName ="RegionOrigen";
                dt.Columns[16].ColumnName ="FechaIngreso";
                dt.Columns[17].ColumnName ="codcalidadjuridica";
                dt.Columns[18].ColumnName ="CalidadJuridica";
                dt.Columns[19].ColumnName ="TribunalOrden";
                dt.Columns[20].ColumnName ="RegionTribunal";
                dt.Columns[21].ColumnName ="RUC";
                dt.Columns[22].ColumnName ="RIT";
                dt.Columns[23].ColumnName ="CodTribunal";
                dt.Columns[24].ColumnName ="TribunalSeguimientoCausa";
                dt.Columns[25].ColumnName ="FechaInicio";
                dt.Columns[26].ColumnName ="AnoDuracion";
                dt.Columns[27].ColumnName ="MesDuracion";
                dt.Columns[28].ColumnName ="DiaDuracion";
                dt.Columns[29].ColumnName ="FechaTermino";
                dt.Columns[30].ColumnName ="Abono";
                dt.Columns[31].ColumnName ="Horas";
                dt.Columns[32].ColumnName ="SancionAccesoria";
                dt.Columns[33].ColumnName ="TipoSancionAccesoria";
                dt.Columns[34].ColumnName ="escolaridadIngreso";
                dt.Columns[35].ColumnName ="AnoEscolaridad";
                dt.Columns[36].ColumnName ="TipoAsistenciaEscolar";
                dt.Columns[37].ColumnName ="FechaElaboracionPII";
                dt.Columns[38].ColumnName ="FechaEgreso";
                dt.Columns[39].ColumnName ="CausalEgreso";
                dt.Columns[40].ColumnName = "Delito";
                dt.Columns[41].ColumnName = "CodigoDelito";
                dt.Columns[42].ColumnName = "MuestraADN";

                DataView dv = new DataView(dt);

                GridView grd001 = new GridView();
                grd001.DataSource = dv;
                grd001.DataBind();
                grd001.RenderControl(hw);

                Response.ContentEncoding = System.Text.Encoding.Default;
                Response.Write(tw.ToString());
                Response.End();

                txt001.BackColor = Color.White;
                ddown003.BackColor = Color.White;
                ddown004.BackColor = Color.White;
                wne001.BackColor = Color.White;
                ddown001.BackColor = Color.White;
            }
            else if (dt0.Rows[0][0].ToString()=="2")
            {
                txt001.BackColor = Color.White;
                ddown003.BackColor = Color.White;
                ddown004.BackColor = Color.White;
                wne001.BackColor = Color.White;
                ddown001.BackColor = Color.White;

                //Get_Nomina_LRPA_II
                DataTable dt = rpn.Reporte_Nomina_LPRAII(Convert.ToInt32(ddown003.SelectedValue), Convert.ToInt32(CodProyecto2), Convert.ToDateTime(FechaConsulta), Convert.ToInt32(MesAno.Trim()) );

                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", "attachment;filename=Nomina_LRPA.xls");

                this.EnableViewState = false;

                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

                dt.Columns[0].ColumnName = "CodProyecto";                 //0
                dt.Columns[1].ColumnName = "NombreProyecto";              //1
                dt.Columns[2].ColumnName = "CodRegion";                      //2
                dt.Columns[3].ColumnName = "Region";                      //3
                dt.Columns[4].ColumnName = "Nemotecnico";                 //4
                dt.Columns[5].ColumnName = "Medio";                       //5
                dt.Columns[6].ColumnName = "icodie";                         //6
                dt.Columns[7].ColumnName = "codnino";                        //7
                dt.Columns[8].ColumnName = "Nombres";                     //8
                dt.Columns[9].ColumnName = "Apellido_Paterno";            //9
                dt.Columns[10].ColumnName = "Apellido_Materno";            //10   
                dt.Columns[11].ColumnName = "rut";                         //11
                dt.Columns[12].ColumnName = "FechaNacimiento";             //12
                dt.Columns[13].ColumnName = "sexo";                        //13
                dt.Columns[14].ColumnName = "EdadAlIngreso";               //14
                dt.Columns[15].ColumnName = "RegionOrigen";                //15
                dt.Columns[16].ColumnName = "FechaIngreso";                //16    
                dt.Columns[17].ColumnName = "codcalidadjuridica";             //17    
                dt.Columns[18].ColumnName = "CalidadJuridica";             //18
                dt.Columns[19].ColumnName = "TribunalOrden";               //19
                dt.Columns[20].ColumnName = "RegionTribunal";              //20
                dt.Columns[21].ColumnName = "RUC";                         //21
                dt.Columns[22].ColumnName = "RIT";                         //22
                dt.Columns[23].ColumnName = "escolaridadIngreso";          //23
                dt.Columns[24].ColumnName = "AnoEscolaridad";              //24
                dt.Columns[25].ColumnName = "TipoAsistenciaEscolar";       //25
                dt.Columns[26].ColumnName = "FechaElaboracionPII";         //26    
                dt.Columns[27].ColumnName = "FechaEgreso";                 //27
                dt.Columns[28].ColumnName = "CausalEgreso";                //28
                dt.Columns[29].ColumnName = "Delito";                      //29
                dt.Columns[30].ColumnName = "CodigoDelito";                //30
                               

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
        else 
        {
            lblaviso.Text = "Debe Ingresar los datos requeridos";
            lblaviso.Visible= true;
            errorPanel.Visible = true;
        }

    }

    protected void btnBuscaProyecto_Click(object sender, ImageClickEventArgs e)
    {
        window.open(this.Page, "../mod_reportes/busca_proyectosNuevaLeyRep.aspx", "Buscador", false, false, 750, 300, false, false, true);
    }
    protected void btnproy_Click(object sender, EventArgs e)
    {
        txt001.Text = "(" + CodProy + ") " + Server.HtmlDecode(NomProy);

        ddown001.SelectedValue = CodInst;
        ddown001.Enabled = false;
    }

/*-----------------------------------------------------------------------------------------
// 29/12/2014
// Juan Valenzuela.
// Se modifican botones para descartar uso de librería Infragistics.
//-----------------------------------------------------------------------------------------*/

    protected void btnLimpiar_NEW_Click(object sender, EventArgs e)
    {
        Limpiaformulario();
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
    protected void exportarExcel_Click(object sender, EventArgs e)
    {
      bool sw = validacion();

      //if (txt001.Text.Length <= 3)
        //sw = false;
      try
      {
          if (sw == true)
          {
              lblaviso.Visible = false;
              ReporteNinoColl rpn = new ReporteNinoColl();

              String MesAno = "0";
              if (Convert.ToDateTime(FechaConsulta).Month < 9)
              {
                  MesAno = Convert.ToString(Convert.ToDateTime(FechaConsulta).Year) + "0" + Convert.ToString(Convert.ToDateTime(FechaConsulta).Month);
              }
              else
              {
                  MesAno = Convert.ToString(Convert.ToDateTime(FechaConsulta).Year) + Convert.ToString(Convert.ToDateTime(FechaConsulta).Month);
              }

              //String CodProyecto2 = txt001.Text.Substring(1, 7);
              //string CodProyecto2 = Request.QueryString["codinst"];
              string CodProyecto2 = ddownProyectos.SelectedValue;
              DataTable dt0 = rpn.Reporte_GetProyectosLPRA(Convert.ToInt32(CodProyecto2));
              if (dt0.Rows[0][0].ToString() == "1")
              {
                  txt001.BackColor = Color.White;
                  ddown003.BackColor = Color.White;
                  ddown004.BackColor = Color.White;
                  wne001.BackColor = Color.White;
                  ddown001.BackColor = Color.White;

                  //Get_Nomina_LRPA
                  DataTable dt = rpn.Reporte_Nomina_LPRA(Convert.ToInt32(ddown003.SelectedValue), Convert.ToInt32(CodProyecto2), Convert.ToDateTime(FechaConsulta), Convert.ToInt32(MesAno.Trim()));

                  Response.Clear();
                  Response.Buffer = true;
                  Response.ContentType = "application/vnd.ms-excel";
                  Response.AddHeader("Content-Disposition", "attachment;filename=Nomina_LRPA.xls");

                  this.EnableViewState = false;

                  System.IO.StringWriter tw = new System.IO.StringWriter();
                  System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);



                  dt.Columns[0].ColumnName = "CodProyecto";
                  dt.Columns[1].ColumnName = "NombreProyecto";
                  dt.Columns[2].ColumnName = "CodRegion";
                  dt.Columns[3].ColumnName = "Region";
                  dt.Columns[4].ColumnName = "Nemotecnico";
                  dt.Columns[5].ColumnName = "Medio";
                  dt.Columns[6].ColumnName = "icodie";
                  dt.Columns[7].ColumnName = "codnino";
                  dt.Columns[8].ColumnName = "Nombres";
                  dt.Columns[9].ColumnName = "Apellido_Paterno";
                  dt.Columns[10].ColumnName = "Apellido_Materno";
                  dt.Columns[11].ColumnName = "rut";
                  dt.Columns[12].ColumnName = "FechaNacimiento";
                  dt.Columns[13].ColumnName = "sexo";
                  dt.Columns[14].ColumnName = "EdadAlIngreso";
                  dt.Columns[15].ColumnName = "RegionOrigen";
                  dt.Columns[16].ColumnName = "FechaIngreso";
                  dt.Columns[17].ColumnName = "codcalidadjuridica";
                  dt.Columns[18].ColumnName = "CalidadJuridica";
                  dt.Columns[19].ColumnName = "TribunalOrden";
                  dt.Columns[20].ColumnName = "RegionTribunal";
                  dt.Columns[21].ColumnName = "RUC";
                  dt.Columns[22].ColumnName = "RIT";
                  dt.Columns[23].ColumnName = "CodTribunal";
                  dt.Columns[24].ColumnName = "TribunalSeguimientoCausa";
                  dt.Columns[25].ColumnName = "FechaInicio";
                  dt.Columns[26].ColumnName = "AnoDuracion";
                  dt.Columns[27].ColumnName = "MesDuracion";
                  dt.Columns[28].ColumnName = "DiaDuracion";
                  dt.Columns[29].ColumnName = "FechaTermino";
                  dt.Columns[30].ColumnName = "Abono";
                  dt.Columns[31].ColumnName = "Horas";
                  dt.Columns[32].ColumnName = "SancionAccesoria";
                  dt.Columns[33].ColumnName = "TipoSancionAccesoria";
                  dt.Columns[34].ColumnName = "escolaridadIngreso";
                  dt.Columns[35].ColumnName = "AnoEscolaridad";
                  dt.Columns[36].ColumnName = "TipoAsistenciaEscolar";
                  dt.Columns[37].ColumnName = "FechaElaboracionPII";
                  dt.Columns[38].ColumnName = "FechaEgreso";
                  dt.Columns[39].ColumnName = "CausalEgreso";
                  dt.Columns[40].ColumnName = "Delito";
                  dt.Columns[41].ColumnName = "CodigoDelito";
                  dt.Columns[42].ColumnName = "MuestraADN";

                  DataView dv = new DataView(dt);

                  GridView grd001 = new GridView();
                  grd001.DataSource = dv;
                  grd001.DataBind();
                  grd001.RenderControl(hw);

                  Response.ContentEncoding = System.Text.Encoding.Default;
                  Response.Write(tw.ToString());
                  Response.End();

                  txt001.BackColor = Color.White;
                  ddown003.BackColor = Color.White;
                  ddown004.BackColor = Color.White;
                  wne001.BackColor = Color.White;
                  ddown001.BackColor = Color.White;

                  panelCorrecto.Visible = true;
                  lblCorrecto.Visible = true;
              }
              else if (dt0.Rows[0][0].ToString() == "2")
              {
                  txt001.BackColor = Color.White;
                  ddown003.BackColor = Color.White;
                  ddown004.BackColor = Color.White;
                  wne001.BackColor = Color.White;
                  ddown001.BackColor = Color.White;

                  //Get_Nomina_LRPA_II
                  DataTable dt = rpn.Reporte_Nomina_LPRAII(Convert.ToInt32(ddown003.SelectedValue), Convert.ToInt32(CodProyecto2), Convert.ToDateTime(FechaConsulta), Convert.ToInt32(MesAno.Trim()));

                  Response.Clear();
                  Response.Buffer = true;
                  Response.ContentType = "application/vnd.ms-excel";
                  Response.AddHeader("Content-Disposition", "attachment;filename=Nomina_LRPA.xls");

                  this.EnableViewState = false;

                  System.IO.StringWriter tw = new System.IO.StringWriter();
                  System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

                  dt.Columns[0].ColumnName = "CodProyecto";                  //0
                  dt.Columns[1].ColumnName = "NombreProyecto";               //1
                  dt.Columns[2].ColumnName = "CodRegion";                    //2
                  dt.Columns[3].ColumnName = "Region";                       //3
                  dt.Columns[4].ColumnName = "Nemotecnico";                  //4
                  dt.Columns[5].ColumnName = "Medio";                        //5
                  dt.Columns[6].ColumnName = "icodie";                       //6
                  dt.Columns[7].ColumnName = "codnino";                      //7
                  dt.Columns[8].ColumnName = "Nombres";                      //8
                  dt.Columns[9].ColumnName = "Apellido_Paterno";             //9
                  dt.Columns[10].ColumnName = "Apellido_Materno";            //10   
                  dt.Columns[11].ColumnName = "rut";                         //11
                  dt.Columns[12].ColumnName = "FechaNacimiento";             //12
                  dt.Columns[13].ColumnName = "sexo";                        //13
                  dt.Columns[14].ColumnName = "EdadAlIngreso";               //14
                  dt.Columns[15].ColumnName = "RegionOrigen";                //15
                  dt.Columns[16].ColumnName = "FechaIngreso";                //16    
                  dt.Columns[17].ColumnName = "codcalidadjuridica";          //17    
                  dt.Columns[18].ColumnName = "CalidadJuridica";             //18
                  dt.Columns[19].ColumnName = "TribunalOrden";               //19
                  dt.Columns[20].ColumnName = "RegionTribunal";              //20
                  dt.Columns[21].ColumnName = "RUC";                         //21
                  dt.Columns[22].ColumnName = "RIT";                         //22
                  dt.Columns[23].ColumnName = "escolaridadIngreso";          //23
                  dt.Columns[24].ColumnName = "AnoEscolaridad";              //24
                  dt.Columns[25].ColumnName = "TipoAsistenciaEscolar";       //25
                  dt.Columns[26].ColumnName = "FechaElaboracionPII";         //26    
                  dt.Columns[27].ColumnName = "FechaEgreso";                 //27
                  dt.Columns[28].ColumnName = "CausalEgreso";                //28
                  dt.Columns[29].ColumnName = "Delito";                      //29
                  dt.Columns[30].ColumnName = "CodigoDelito";                //30


                  DataView dv = new DataView(dt);

                  GridView grd001 = new GridView();
                  grd001.DataSource = dv;
                  grd001.DataBind();
                  grd001.RenderControl(hw);

                  Response.ContentEncoding = System.Text.Encoding.Default;
                  Response.Write(tw.ToString());
                  Response.End();
                  panelCorrecto.Visible = true;
                  lblCorrecto.Visible = true;
              }
              else 
              {
                  alerts.Visible = true;
                  lblaviso.Text = "No se encontraron coincidencias....";
                  lblaviso.Visible = true;
                  errorPanel.Visible = true;
              }

          }
          else
          {
              alerts.Visible = true;
              lblaviso.Text = "Debe Ingresar los datos requeridos";
              lblaviso.Visible = true;
              errorPanel.Visible = true;
          }
      }
      catch (Exception ex)
      {
          alerts.Visible = true;
          lblError.Visible = true;
          lblError.Text = ex.Message + " " + ex.InnerException;
      }
    }
    protected void imb_lupa_modal_proyecto_Click(object sender, EventArgs e)
    {
      window.open(this.Page, "../mod_reportes/busca_proyectosNuevaLeyRep.aspx", "Buscador", false, false, 750, 300, false, false, true);
    }
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        ddown001.SelectedIndex = -1;
        ddownProyectos.SelectedIndex = -1;
        ddown003.SelectedIndex = -1;
        lblmes.Visible = false;
        lblano.Visible = false;
        lbl_periodo.Visible = false;
        divPeriodo.Visible = false;
        lbl_fecha.Visible = false;
        divFecha.Visible = false;
        ddown004.Visible = false;
        wne001.Visible = false; 
        alerts.Visible = false;
        lblError.Visible = false;


    }
}
