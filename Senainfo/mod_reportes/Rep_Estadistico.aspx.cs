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
using System.IO;

public partial class mod_reportes_Rep_Estadistico : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    
    {
        if (!IsPostBack)
        {
                # region VALIDACION USUARIO


                if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
                {
                    Response.Redirect("~/logout.aspx");
                }
                else
                {
                    if (!window.existetoken("DE3CC676-1886-446D-BE05-7B6EBD91E31E"))
                    {
                        Response.Redirect("~/e403.aspx");
                    }
                }
                #endregion
                rellenar();
        }
        
        alerts.Visible = false;
    }

    private void rellenar()
    {
        try
        {
            dtgv_pdf.Visible = true;
            lbl_error.Visible = false;
            DirectoryInfo di = new DirectoryInfo(ConfigurationSettings.AppSettings["PathReportesCDC"].ToString());//);
            DirectoryInfo[] diArr = di.GetDirectories();
            ddl_año.Items.Clear();
            foreach (DirectoryInfo dri in diArr)
            {
                ddl_año.Items.Add(Convert.ToString(dri));
            }
            ddl_año.SelectedIndex = ddl_año.Items.Count - 1;
            getMes(ddl_año.SelectedValue);
        }
        catch(Exception ex)
        {

        }
    }

    private void getMes(string año)
    {
        try
        {
            dtgv_pdf.Visible = true;
            lbl_error.Visible = false;
            DirectoryInfo di = new DirectoryInfo(ConfigurationSettings.AppSettings["PathReportesCDC"].ToString() + "\\" + año);
            DirectoryInfo[] diArr = di.GetDirectories();
            ddl_mes.Items.Clear();
            ddl_mes.Items.Add("Seleccione Mes");
            foreach (DirectoryInfo dri in diArr)
            {
                string nombre = dri.Name;
                int a = Convert.ToInt32(nombre);
                ListItem lI = new ListItem();
                switch (a)
                {
                    case 1:
                        lI.Text = "Enero";
                        break;
                    case 2:
                        lI.Text = "Febrero";
                        break;
                    case 3:
                        lI.Text = "Marzo";
                        break;
                    case 4:
                        lI.Text = "Abril";
                        break;
                    case 5:
                        lI.Text = "Mayo";
                        break;
                    case 6:
                        lI.Text = "Junio";
                        break;
                    case 7:
                        lI.Text = "Julio";
                        break;
                    case 8:
                        lI.Text = "Agosto";
                        break;
                    case 9:
                        lI.Text = "Septiembre";
                        break;
                    case 10:
                        lI.Text = "Octubre";
                        break;
                    case 11:
                        lI.Text = "Noviembre";
                        break;
                    case 12:
                        lI.Text = "Diciembre";
                        break;
                    default:
                        //Fecha = "Fecha Invalida";
                        lI.Text = "Fecha Invalida";
                        break;
                }
                //ddl_mes.Items.Add(Convert.ToString(Fecha));
                lI.Value = nombre;
                ddl_mes.Items.Add(lI);
            }
            //ddl_mes.SelectedValue = "Seleccione Mes";
            ddl_mes.SelectedIndex = ddl_mes.Items.Count - 1;
            ddl_mes.DataBind();
            EventArgs e = new EventArgs();
            Object o = new System.Object();

            ddl_mes_SelectedIndexChanged(o, e);
        }
        catch(Exception ex)
        {
            lbl_error.Visible = false;
            ddl_mes.Items.Clear();
            ddl_mes.Items.Add("No existen Meses en este año");
            ddl_mes.DataBind();
        }

    }
    protected void ddl_mes_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            dtgv_pdf.Visible = true;
            lbl_error.Visible = false;
            int me = ddl_mes.SelectedIndex - 1;
            string mes = Convert.ToString(me);
            ListItemCollection lst = new ListItemCollection();
            DirectoryInfo di = new DirectoryInfo(ConfigurationSettings.AppSettings["PathReportesCDC"].ToString() + "\\" + ddl_año.SelectedValue + "\\" + ddl_mes.Items[ddl_mes.SelectedIndex].Value);
            FileInfo[] diArr = di.GetFiles();
            DataTable dt = new DataTable();
            DataColumn da = new DataColumn();
            dt.Columns.Add("Nombre", typeof(string));
            //dt.Columns.Add("Ver");

            foreach (FileInfo fi in diArr)
            {
                DataRow NewRow = dt.NewRow();
                NewRow[0] = fi.Name;
                dt.Rows.Add(NewRow);
            }
            dtgv_pdf.DataSource = dt;
            dtgv_pdf.DataBind();
            dtgv_pdf.Visible = true;
        }
        catch (Exception ex)
        {
            lbl_error.Visible = true;
            dtgv_pdf.Visible = false;
            alerts.Visible = true;
        }
    }
    protected void ddl_año_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            dtgv_pdf.Visible = true;
            lbl_error.Visible = false;
            string año = string.Empty;
            año = ddl_año.SelectedValue;
            ddl_mes.Items.Clear();
            getMes(año);
            ddl_mes_SelectedIndexChanged(sender, e);
        }
        catch (Exception ex)
        {
        }
    }  
    protected void gv_pdf_RowCommand(object sender, GridViewCommandEventArgs e)
    {
     
        try
        {
            int me = ddl_mes.SelectedIndex - 1;
            string mes = Convert.ToString(me);
            string name = string.Empty;
            int index = Convert.ToInt32(e.CommandArgument);
            //name = Convert.ToString(dtgv_pdf.Rows[index].Cells[1].Text);
            name = HttpUtility.HtmlDecode(dtgv_pdf.Rows[index].Cells[1].Text);
            //System.Diagnostics.Process.Start(ConfigurationSettings.AppSettings["PathReportesCDC"].ToString() + "\\" + ddl_año.SelectedValue + "\\" + ddl_mes.Items[ddl_mes.SelectedIndex].Value + "\\" + name);
            //Response.Redirect(ConfigurationSettings.AppSettings["PathReportesCDC"].ToString() + "\\" + ddl_año.SelectedValue + "\\" + ddl_mes.Items[ddl_mes.SelectedIndex].Value + "\\" + name);
            //string strPATH = ConfigurationSettings.AppSettings["PathReportesCDC"].ToString() + "\\" + ddl_año.SelectedValue + "\\" + ddl_mes.Items[ddl_mes.SelectedIndex].Value + "\\" + name;
            string rutaAux = "..\\rpt\\Reportes\\ReporteCDC";
            string strPathAux = rutaAux + "\\" + ddl_año.SelectedValue + "\\" + ddl_mes.Items[ddl_mes.SelectedIndex].Value + "\\" + name;
            //Session["StrPath"] = strPATH;
            Session["StrPath"] = strPathAux;
           // window.open(this.Page, "Reg_Reportes.aspx?param001=7", "Reportes", false, true, 800, 600, false, false, true);
            Response.Redirect(strPathAux, false);
            //this.Response.Write("<script>window.open('http://www.google.com.hk/','_blank');</script>");


            //Response.Write("<script>");
            //Response.Write("window.open('" + strPathAux + "'_blank')");
            //Response.Write("<" + "/script>");
            
            //this.Response.ClearContent();
            //this.Response.ClearHeaders();
            //this.Response.ContentType = "application/pdf";
            //this.Response.WriteFile(strPathAux);
            //this.Response.TransmitFile(strPathAux);
            //this.Response.Flush();
            //this.Response.Close();

            //Response.Clear();
            //Response.ClearContent();
            //Response.ClearHeaders();
            //Response.AddHeader("Content-Disposition", "attachment; filename=" + name);
            //Response.ContentType = "application/pdf";
            //Response.TransmitFile(strPATH);
            //Response.Close();

            //System.Diagnostics.Process proc = new System.Diagnostics.Process();
            //proc.StartInfo.FileName = strPATH;
            //proc.Start();
            //proc.Close();

            //int i = Convert.ToInt32(Session["ValorSeleccionado"]);
            //lbl_CodEncuesta.Text = HttpUtility.HtmlDecode(grd001.Rows[i].Cells[0].Text);
            //diagnosticoscoll dcoll = new diagnosticoscoll();
            //dcoll.Caducar_EncuestaTrabajadoresDetalle(Convert.ToInt32(lbl_CodEncuesta.Text));
            //Page.Response.Redirect(Page.Request.Url.ToString(), true);       
        }
        catch (Exception ex)
        { }
      
    }
   
    protected void btn_volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("Index_Reportes.aspx");
    }

}