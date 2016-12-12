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

public partial class mod_reportes_RepTrabajadoresExcel : System.Web.UI.Page
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
                diagnosticoscoll dgcoll = new diagnosticoscoll();
                DataTable dt;
                if(Session["ReporteTrabajadoresRegion"] != null)
                {
                    Panel_Cambios.Visible = false;
                    Panel_Nuevo.Visible = false;
                    Panel_DataGrid.Visible = true;
                    imgbtn_guardar.Visible = true;
                    imgbtn_volver.Visible = true;
                    btn_Add.Visible = false;
                    btn_close.Visible = false;
                    string[] words = Session["ReporteTrabajadoresRegion"].ToString().Split(',');
                    int index = Convert.ToInt32(words[0]);
                    string vigencia = words[1];
                    dt = dgcoll.GetRepTrabajadoresxRegion(index, vigencia);
                    DataView dv = new DataView(dt);
                    grd001.DataSource = dv;
                    grd001.DataBind();
                    if (vigencia.Equals("C") || vigencia.Equals("T"))
                    {
                        grd001.Columns[15].Visible = false;
                        grd001.Columns[16].Visible = false;
                    }
                }
                if(Session["ReporteTrabajadoresInstitucion"] != null)
                {
                    Panel_Cambios.Visible = false;
                    Panel_Nuevo.Visible = false;
                    Panel_DataGrid.Visible = true;
                    imgbtn_guardar.Visible = true;
                    imgbtn_volver.Visible = true;
                    btn_Add.Visible = false;
                    btn_close.Visible = false;
                    string[] words = Session["ReporteTrabajadoresInstitucion"].ToString().Split(',');
                    int index = Convert.ToInt32(words[0]);
                    string vigencia = words[1];
                    dt = dgcoll.GetRepTrabajadoresxInstitucion(index, vigencia);
                    DataView dv = new DataView(dt);
                    grd001.DataSource = dv;
                     grd001.DataBind();
                    if (vigencia.Equals("C") || vigencia.Equals("T"))
                    {
                        grd001.Columns[15].Visible = false;
                        grd001.Columns[16].Visible = false;
                    }
                }
                if(Session["ReporteTrabajadoresProyecto"] != null)
                {
                    Panel_Cambios.Visible = false;
                    Panel_Nuevo.Visible = false;
                    Panel_DataGrid.Visible = true;
                    imgbtn_guardar.Visible = true;
                    imgbtn_volver.Visible = true;
                    btn_Add.Visible = false;
                    btn_close.Visible = false;
                    string[] words = Session["ReporteTrabajadoresProyecto"].ToString().Split(',');
                    int index = Convert.ToInt32(words[0]);
                    string vigencia = words[1];
                    dt = dgcoll.GetRepTrabajadoresxProyecto(index, vigencia);
                    DataView dv = new DataView(dt);
                    grd001.DataSource = dv;
                    grd001.DataBind();
                    if (vigencia.Equals("C") || vigencia.Equals("T"))
                    {
                        grd001.Columns[15].Visible = false;
                        grd001.Columns[16].Visible = false;
                    }
                }
                if (Session["addNewWorker"] != null)
                {
                    imgbtn_guardar.Visible = false;
                    imgbtn_volver.Visible = false;
                    btn_Add.Visible = true;
                    btn_close.Visible = true;
                    Panel_Cambios.Visible = false;
                    Panel_DataGrid.Visible = false;
                    Panel_Nuevo.Visible = true;
                    Limpiar();
                    Panel_DataGrid.Visible = false;
                    string[] words = Session["addNewWorker"].ToString().Split(',');
                    int index = Convert.ToInt32(words[0]);
                    string vigencia = words[1];
                    dt = dgcoll.GetRepTrabajadoresxProyecto(index, vigencia);
                    DataView dv = new DataView(dt);
                    grd001.DataSource = dv;
                    grd001.DataBind();
                    getprofesion();
                    getCargo();
                    if (vigencia.Equals("C") || vigencia.Equals("T"))
                    {
                        grd001.Columns[15].Visible = false;
                        grd001.Columns[16].Visible = false;
                    }
                }
                 trabajadorescoll tcol = new trabajadorescoll();
                 string rol1 = tcol.get_rol(Convert.ToInt32(Session["IdUsuario"]));
                 int rol = Convert.ToInt32(rol1);
                 if (rol != 265 & rol != 252)
                 {
                     grd001.Columns[15].Visible = false;
                     grd001.Columns[16].Visible = false;
                 }
                
            }
        }
    }
  
  
    protected void grd001_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Modificar")
        {
            getprofesion();
            getCargo();
            Panel_DataGrid.Visible = false;
            Panel_Cambios.Visible = true;
            txt_name.Text = HttpUtility.HtmlDecode(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[9].Text);
            txt_ApellidoP.Text = HttpUtility.HtmlDecode(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[7].Text);
            txt_ApellidoM.Text = HttpUtility.HtmlDecode(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[8].Text);
            txt_rut.Text = HttpUtility.HtmlDecode(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[6].Text);
            txt_OtraProfesion.Text = HttpUtility.HtmlDecode(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[10].Text);
            

            /*****************************************************************************************************/
            //lbl_CodEncuesta.Text = HttpUtility.HtmlDecode(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text);
            //txt_name.Text = HttpUtility.HtmlDecode(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[10].Text); 
            //txt_ApellidoP.Text = HttpUtility.HtmlDecode(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[8].Text);
            //txt_ApellidoM.Text = HttpUtility.HtmlDecode(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[9].Text);
            //txt_rut.Text = HttpUtility.HtmlDecode(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[7].Text);
            //txt_codProf.Text = HttpUtility.HtmlDecode(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[11].Text);
            //txt_Profesion.Text = HttpUtility.HtmlDecode(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[12].Text);
            //txt_codCargo.Text = HttpUtility.HtmlDecode(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[13].Text);
            //txt_Cargo.Text = HttpUtility.HtmlDecode(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[14].Text);
            //txt_OtraProfesion.Text = HttpUtility.HtmlDecode(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[15].Text);
            if(!HttpUtility.HtmlDecode(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[10].Text).Equals(""))
            {
                ddl_profesion.SelectedItem.Text = HttpUtility.HtmlDecode(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[10].Text);
            }
            if (!HttpUtility.HtmlDecode(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[12].Text).Equals(""))
            {
                ddl_cargo.SelectedItem.Text = HttpUtility.HtmlDecode(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[12].Text);
            }
        }

        if (e.CommandName == "Caducar")        
        {
            ClientScript.RegisterStartupScript(GetType(), "Caducar", "Validate()", true);
            Session["ValorSeleccionado"] = Convert.ToInt32(e.CommandArgument).ToString();
            //btn_invisibleEvent.OnClientClick;
            //btn_invisibleEvent_Click(sender, e);            
        }

    }
   
 
    private void Limpiar()
    {
        lbl_CodEncuesta.Text = string.Empty;
        txt_name.Text = string.Empty;
        txt_ApellidoP.Text = string.Empty;
        txt_ApellidoM.Text = string.Empty;
        txt_rut.Text = string.Empty;
        //txt_codProf.Text = string.Empty;
        //txt_Profesion.Text = string.Empty;
        //txt_codCargo.Text = string.Empty;
        //txt_Cargo.Text = string.Empty;
        txt_OtraProfesion.Text = string.Empty;
    }
    private void getprofesion()
    {

        parcoll pcoll = new parcoll();

        DataTable dtproy = pcoll.GetparProfesionOficio();
        ddl_profesion.DataSource = dtproy;
        ddl_profesion.DataTextField = "Descripcion";
        ddl_profesion.DataValueField = "CodProfesion";
        ddl_profesion.DataBind();
    }
    private void getCargo()
    {

        parcoll pcoll = new parcoll();

        DataTable dtcarg = pcoll.GetparCargo();
        ddl_cargo.DataSource = dtcarg;
        ddl_cargo.DataTextField = "Descripcion";
        ddl_cargo.DataValueField = "CodCargo";
        ddl_cargo.DataBind();
    }
    
    protected void btn_invisibleEvent_Click(object sender, EventArgs e)
    {
        int i = Convert.ToInt32(Session["ValorSeleccionado"]);
        lbl_CodEncuesta.Text = HttpUtility.HtmlDecode(grd001.Rows[i].Cells[0].Text);
        diagnosticoscoll dcoll = new diagnosticoscoll();
        dcoll.Caducar_EncuestaTrabajadoresDetalle(Convert.ToInt32(lbl_CodEncuesta.Text));
        Page.Response.Redirect(Page.Request.Url.ToString(), true);        
    }
    protected void imgbtn_Excel_Click(object sender, EventArgs e)
    {
        diagnosticoscoll dgcoll = new diagnosticoscoll();
        DataTable dt = new DataTable();
        if (Session["ReporteTrabajadoresRegion"] != null)
        {
            string[] words = Session["ReporteTrabajadoresRegion"].ToString().Split(',');
            int index = Convert.ToInt32(words[0]);
            string vigencia = words[1];
            dt = dgcoll.GetRepTrabajadoresxRegion(index, vigencia);
        }
        if (Session["ReporteTrabajadoresInstitucion"] != null)
        {
            string[] words = Session["ReporteTrabajadoresInstitucion"].ToString().Split(',');
            int index = Convert.ToInt32(words[0]);
            string vigencia = words[1];
            dt = dgcoll.GetRepTrabajadoresxInstitucion(index, vigencia);
        }
        if (Session["ReporteTrabajadoresProyecto"] != null)
        {
            string[] words = Session["ReporteTrabajadoresProyecto"].ToString().Split(',');
            int index = Convert.ToInt32(words[0]);
            string vigencia = words[1];
            dt = dgcoll.GetRepTrabajadoresxProyecto(index, vigencia);
        }
        DataView dv = new DataView(dt);
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=Reporte_Trabajadores.xls");
        Response.Charset = "";
        this.EnableViewState = false;

        System.IO.StringWriter tw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);

        if (dt.Rows.Count > 0)
        {
            GridView grd002 = new GridView();
            grd002.DataSource = dv;
            grd002.DataBind();
            grd002.RenderControl(hw);
            Response.ContentEncoding = System.Text.Encoding.Default;
            Response.Write(tw.ToString());
            Response.End();
        }
    }
  
    protected void imgbtn_addNew_Click(object sender, EventArgs e)
    {
        diagnosticoscoll dcoll = new diagnosticoscoll();
        DataTable dtTrabaj = dcoll.GetTrabajadoresPorRut(txt_newRut.Text);
        if (dtTrabaj.Rows.Count > 0)
        {
            txt_rut.Text = dtTrabaj.Rows[0][2].ToString();
            txt_ApellidoM.Text = dtTrabaj.Rows[0][4].ToString();
            txt_ApellidoP.Text = dtTrabaj.Rows[0][3].ToString();
            txt_name.Text = dtTrabaj.Rows[0][5].ToString();
            txt_OtraProfesion.Text = dtTrabaj.Rows[0][7].ToString();
            if (!dtTrabaj.Rows[0][8].ToString().Equals(""))
            {
                ddl_cargo.SelectedValue = dtTrabaj.Rows[0][8].ToString();
            }
            if (!dtTrabaj.Rows[0][6].ToString().Equals(""))
            {
                ddl_profesion.SelectedValue = dtTrabaj.Rows[0][6].ToString();
            }
            Panel_Cambios.Visible = true;
            Panel_Nuevo.Visible = false;
            lbl_text1.Text = "Recuerde Validar los datos del trabajador antes de ingresarlo al proyecto";
            //colocar texto de que el trabajador existe pero debe validar los datos
        }
        else
        {
            //colocar texto de que el trabajador es nuevo y requiere ingresar todos los datos
            lbl_text1.Text = "Esta persona es nueva, porfavor ingrese los datos siguientes:";
            Panel_Cambios.Visible = true;
            Panel_Nuevo.Visible = false;
            txt_rut.Text = txt_newRut.Text;
        }
    }
    protected void btn_Add_Click(object sender, EventArgs e)
    {
        string vigencia = "V";
        string[] words = Session["addNewWorker"].ToString().Split(',');
        int index = Convert.ToInt32(words[0]);
        diagnosticoscoll dcoll = new diagnosticoscoll();
        dcoll.Insert_ReporteTrabajadores(Convert.ToInt32(Session["IdUsuario"].ToString()), txt_name.Text, txt_ApellidoP.Text, txt_ApellidoM.Text, txt_rut.Text, Convert.ToInt32(ddl_profesion.SelectedValue.ToString()), txt_OtraProfesion.Text, Convert.ToInt32(ddl_cargo.SelectedValue.ToString()), vigencia, Convert.ToInt32(Session["IdUsuario"].ToString()), DateTime.Now, index);
        Session["ReporteTrabajadoresProyecto"] = Session["addNewWorker"];
        Session.Remove("addNewWorker");
        Page.Response.Redirect(Page.Request.Url.ToString(), true);
    }
    protected void btn_close_Click(object sender, EventArgs e)
    {
        window.close(this.Page);
    }
    protected void imgbtn_guardar_Click(object sender, EventArgs e)
    {
        int codCargo = 0;
        if (ddl_cargo.SelectedValue.ToString().Equals(""))
        {
            codCargo = 0;
        }
        else
        {
            codCargo = Convert.ToInt32(ddl_cargo.SelectedValue);
        }
        diagnosticoscoll dcoll = new diagnosticoscoll();
        dcoll.callto_update_ReporteTrabajadores(Convert.ToInt32(lbl_CodEncuesta.Text), txt_name.Text, txt_ApellidoP.Text, txt_ApellidoM.Text, txt_rut.Text, Convert.ToInt32(ddl_profesion.SelectedValue.ToString()), txt_OtraProfesion.Text, codCargo);
        Page.Response.Redirect(Page.Request.Url.ToString(), true);
    }
    protected void imgbtn_volver_Click(object sender, EventArgs e)
    {
        Limpiar();
        Panel_Cambios.Visible = false;
        Panel_DataGrid.Visible = true;
    }
    protected void imgbtn_Cerrar_Click(object sender, EventArgs e)
    {
        window.close(this.Page);
    }
}
