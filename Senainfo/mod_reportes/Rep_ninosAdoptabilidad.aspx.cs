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

public partial class mod_reportes_Rep_ninosAdoptabilidad : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RequiredFieldValidator1.Validate();
        if (!IsPostBack)
        {
            if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
            {
                Response.Redirect("~/logout.aspx");
            }

            else
            {
                if (!window.existetoken("C4BFE91D-C904-47B0-B2C9-FD558E25BF29"))
                {

                    Response.Redirect("~/logout.aspx");

                }
                else
                {
                    getparregion();

                }
            }
        }
    }
    protected void rv_fecha_Init(object sender, EventArgs e)
    {
        ((RangeValidator)sender).MaximumValue = DateTime.Today.ToString("dd-MM-yyyy");
        ((RangeValidator)sender).MinimumValue = "01-01-1900";

    }
    private void getparregion()
    {
        parcoll par = new parcoll();
        DataView dv1 = new DataView(par.GetDataRegion(Convert.ToInt32(Session["IdUsuario"])));
        // DataView dv1 = new DataView(par.GetparRegion());
        ddregion.DataSource = dv1;
        ddregion.DataTextField = "Descripcion";
        ddregion.DataValueField = "CodRegion";
        dv1.Sort = "CodRegion";
        ddregion.DataBind();
        if (ddregion.SelectedValue == "15")
        {
            ddregion.SelectedValue = "-1";
        }
    }

    
    protected void btn_limpiar_Click(object sender, EventArgs e)
    {
        ddregion.SelectedIndex = -1;
        cal_termino.Text =null;
        cal_inicio.Text = null;
        alerts.Visible = false;
        lbl_error.Visible = false;
    }
    protected void btn_volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("../mod_reportes/index_reportes.aspx");
    }
    protected void btn_buscar_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddregion.SelectedValue == "-2" || cal_inicio.Text == "" || cal_termino.Text == "")
            {
                if (ddregion.SelectedValue == "-2")
                { ddregion.BackColor = System.Drawing.Color.Pink; }
                else { ddregion.BackColor = System.Drawing.Color.White; }

                if (cal_inicio.Text == "")
                { cal_inicio.BackColor = System.Drawing.Color.Pink; }
                else { cal_inicio.BackColor = System.Drawing.Color.White; }

                if (cal_termino.Text == "")
                { cal_termino.BackColor = System.Drawing.Color.Pink; }
                else { cal_termino.BackColor = System.Drawing.Color.White; }
            }
            else
            {
                ddregion.BackColor = System.Drawing.Color.White;
                cal_inicio.BackColor = System.Drawing.Color.White;
                cal_termino.BackColor = System.Drawing.Color.White;

                ReporteNinoColl rp = new ReporteNinoColl();

                DataTable dt = rp.callto_reporte_susceptibleabandono(Convert.ToInt32(ddregion.SelectedValue),
                    Convert.ToDateTime(cal_inicio.Text), Convert.ToDateTime(cal_termino.Text));

                if (dt.Rows.Count > 0)
                {
                    Response.Clear();
                    Response.Buffer = true;

                    // Set the content type to Excel
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AddHeader("Content-Disposition", "attachment;filename=Reporte_Nino.xls");
                    // Remove the charset from the Content-Type header.
                    Response.Charset = "";
                    // Turn off the view state.
                    this.EnableViewState = false;

                    System.IO.StringWriter tw = new System.IO.StringWriter();
                    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);


                    dt.Columns[0].ColumnName = "COD. INSTITUCION";	//0
                    dt.Columns[1].ColumnName = "NOM. INSTITUCION";			//1
                    dt.Columns[2].ColumnName = "COD. PROYECTO";		//2
                    dt.Columns[3].ColumnName = "NOM. PROYECTO";		    //3
                    dt.Columns[4].ColumnName = "REGION";
                    dt.Columns[5].ColumnName = "COMUNA";
                    dt.Columns[6].ColumnName = "COD. NIÑO";	    //4
                    dt.Columns[7].ColumnName = "APELLIDO PATERNO";	        //5
                    dt.Columns[8].ColumnName = "APELLIDO MATERNO";	        //6
                    dt.Columns[9].ColumnName = "NOMBRES";	//7
                    dt.Columns[10].ColumnName = "FECHA NACIMIENTO";	//8
                    dt.Columns[11].ColumnName = "RUT";	        //9
                    dt.Columns[12].ColumnName = "FECHA INGRESO";	//10
                    dt.Columns[13].ColumnName = "FECHA EGRESO";	            //11
                    dt.Columns[14].ColumnName = "VIGENCIA";	//12
                    dt.Columns[15].ColumnName = "DESDE";	//13
                    dt.Columns[16].ColumnName = "HASTA";	            //14
                    dt.Columns[17].ColumnName = "REPORTE";
                    dt.Columns[18].ColumnName = "ICODIE";
                    dt.Columns[19].ColumnName = "SUSCEPTIBLE";
                    dt.Columns[20].ColumnName = "COEFICIENTE INTELECTUAL";
                    dt.Columns[21].ColumnName = "DISCAPACIDAD";
                    dt.Columns[22].ColumnName = "ESTADO ABANDONO";
                    dt.Columns[23].ColumnName = "COD. CAUSAL";
                    dt.Columns[24].ColumnName = "EXISTE PADRE";
                    dt.Columns[25].ColumnName = "PADRE COD. SITUACION1";
                    dt.Columns[26].ColumnName = "PADRE COD. SITUACION2";
                    dt.Columns[27].ColumnName = "PADRE COD. SITUACION3";
                    dt.Columns[28].ColumnName = "EXISTE MADRE";
                    dt.Columns[29].ColumnName = "MADRE COD. SITUACION1";
                    dt.Columns[30].ColumnName = "MADRE COD. SITUACION2";
                    dt.Columns[31].ColumnName = "MADRE COD. SITUACION3";
                    dt.Columns[32].ColumnName = "CAUSAL EGRESO";
                    dt.Columns[33].ColumnName = "CON QUIEN EGRESA";
                    dt.Columns[34].ColumnName = "SEXO";		    //16
                    dt.Columns[35].ColumnName = "EDAD";
                    dt.Columns[36].ColumnName = "ENF. CRONICA";
                    dt.Columns[37].ColumnName = "xCOEFICIENTE INTELECTUAL";
                    dt.Columns[38].ColumnName = "xDISCAPACIDAD";
                    dt.Columns[39].ColumnName = "xESTADO ABANDONO";
                    dt.Columns[40].ColumnName = "xCAUSAL INGRESO";
                    dt.Columns[41].ColumnName = "xPADRE SITUACION1";
                    dt.Columns[42].ColumnName = "xPADRE SITUACION2";
                    dt.Columns[43].ColumnName = "xPADRE SITUACION3";
                    dt.Columns[44].ColumnName = "xMADRE SITUACION1";
                    dt.Columns[45].ColumnName = "xMADRE SITUACION2";
                    dt.Columns[46].ColumnName = "xMADRE SITUACION3";
                    dt.Columns[47].ColumnName = "xCAUSAL EGRESO";
                    dt.Columns[48].ColumnName = "xCON QUIEN EGRESA";
                    dt.Columns[49].ColumnName = "xENFERMEDAD CRONICA";
                    dt.Columns[50].ColumnName = "EDAD AÑO";
                    dt.Columns[51].ColumnName = "FECHA INGRESO 2";
                    dt.Columns[52].ColumnName = "FECHA EGRESO 2";



                    DataView dv = new DataView(dt);
                    DataGrid d1 = new DataGrid();
                    d1.DataSource = dv;
                    d1.DataBind();
                    d1.RenderControl(hw);
                    Response.ContentEncoding = System.Text.Encoding.Default;
                    Response.Write(tw.ToString());
                    Response.End();
                }
                lbl_error.Text = "No se encontraron coincidencias";
                lbl_error.Visible = true;
                alerts.Visible = true;
            }
        }
        catch (Exception ex)
        {
            lbl_error.Text = ex.Message + " " + ex.InnerException;
            lbl_error.Visible = true;
            alerts.Visible = true;
        }
    }
    
}
