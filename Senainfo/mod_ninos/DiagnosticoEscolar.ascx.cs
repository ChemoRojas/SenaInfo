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

using Argentis.Regmen;


using System.Drawing;
using CustomWebControls;

public partial class DiagnosticoEscolar : System.Web.UI.UserControl
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

    #region ViewState
    public int VCod_diagnostico
    {
        get
        {
            if (ViewState["Cod_diagnostico"] == null)
            { ViewState["Cod_diagnostico"] = -1; }
            return Convert.ToInt32(ViewState["Cod_diagnostico"]);
        }
        set { ViewState["Cod_diagnostico"] = value; }
    }
    public DateTime VFecha_diagnostico
    {
        get
        {
            if (ViewState["Fecha_diagnostico"] == null)
            { ViewState["Fecha_diagnostico"] = -1; }
            return Convert.ToDateTime(ViewState["Fecha_diagnostico"]);
        }
        set { ViewState["Fecha_diagnostico"] = value; }
    }
    public int AuxEscolar
    {
        get
        {
            if (ViewState["AuxEscolar"] == null)
            { ViewState["AuxEscolar"] = -1; }
            return Convert.ToInt32(ViewState["AuxEscolar"]);
        }
        set { ViewState["AuxEscolar"] = value; }
    }
    # endregion




    protected void Page_Load(object sender, EventArgs e)
    {
        # region CargaInicial
    
       

        if (!IsPostBack)
        {

           
            GetData();
            btn002aa.Visible = false;
        }
        # endregion
    }
    protected void txt001_wn_ValueChange(object sender, EventArgs e)
    {


        if (txt001_wn.Text.Trim().Length > 0 && Convert.ToInt32(txt001_wn.Text) > DateTime.Now.Year)
        {
            //txt001_wn.Text = Convert.ToString(DateTime.Now.Year);
            lbl001aa.Text = "El año Ingresado es mayor al año actual";


        }
        else
        {
            lbl001aa.Text = "";
        }


        //grd001aa.Focus();
    }
    protected void imb_001aa_Click(object sender, EventArgs e)
    {
        //    WebDateChooser tcal001 = (TextBox)utab4.FindControl("cal001");
        //    DropDownList tddown001 = (DropDownList)utab4.FindControl("ddown001");
        //    DropDownList tddown002 = (DropDownList)utab4.FindControl("ddown002");
        //    DropDownList tddown003 = (DropDownList)utab4.FindControl("ddown003");
        //    WebMaskEdit ttxt001_wn = (TextBox)utab4.FindControl("txt001_wn");
        //    SenameTextBox ttxt002_te = (SenameTextBox)utab4.FindControl("txt002_te");
        //    GridView tgrd001aa = (GridView)utab4.FindControl("grd001aa");
        //    Label tlbl001aa = (Label)utab4.FindControl("lbl001aa");
        //    Label tlbl002aa = (Label)utab4.FindControl("lbl002aa");


        bool sw = false;

        ninocoll ncoll = new ninocoll();
        diagnosticoscoll dcoll = new diagnosticoscoll();

        for (int i = 0; i < grd001aa.Rows.Count; i++)
        {
        //    if (Server.HtmlDecode((grd001aa.Rows[i].Cells[3]).Text.ToUpper().Trim()) == Server.HtmlDecode(ddown001.SelectedItem.Text.ToUpper().Trim()) &&
        //        Server.HtmlDecode((grd001aa.Rows[i].Cells[5]).Text.ToUpper().Trim()) == Server.HtmlDecode(txt001_wn.Text.ToUpper().Trim()) &&
        //        Server.HtmlDecode((grd001aa.Rows[i].Cells[6]).Text.ToUpper().Trim()) == Server.HtmlDecode(ddown003.SelectedItem.Text.ToUpper().Trim()))
            if(Server.HtmlDecode((grd001aa.Rows[i].Cells[6]).Text.Trim()) == Server.HtmlDecode(cal01.Text.Trim()))
            {
                lbl002aa.Text = "Para realizar este ingreso, Debe cambiar la fecha de Diagnostico";
                sw = true;
            }


        }

        if (validateDE() == true && sw == false)
        {

            //utab4.Tabs[0].Style.ForeColor = System.Drawing.Color.Black;
            if (txt002_te.Text == null)
            {
                txt002_te.Text = "SIN OBSERVACION";
            }

            //int inden = ncoll.Insert_DiagnosticoGeneral(1, SSninoDiag.CodNino, SSninoDiag.ICodIE, Convert.ToDateTime(cal01.Text));
            //dcoll.Insert_DiagnosticosEscolar(inden, DateTime.Now, Convert.ToInt32(ddown001.SelectedValue)
            //    , Convert.ToDateTime(cal01.Text), Convert.ToInt32(ddown002.SelectedValue), Convert.ToInt32(ddown001.SelectedValue), Convert.ToInt32(ddown002.SelectedValue),
            //    Convert.ToInt32(ddown003.SelectedValue), Convert.ToInt32(txt001_wn.Text),
            //    Convert.ToString(txt002_te.Text).ToUpper(), false, DateTime.Now, Convert.ToInt32(Session["IdUsuario"]));


            lbl002aa.Text = "";

        }
        else
        {

            //  utab4.Tabs[0].Style.ForeColor = System.Drawing.Color.Red;

        }

        DataTable dt = dcoll.GetDiagnosticoEscolar(SSninoDiag.ICodIE);
        DataView dv = new DataView(dt);
        dv.Sort = "FechaDiagnostico";
        grd001aa.DataSource = dv;

        grd001aa.DataBind();
        grd001aa.Visible = true;
        //utab4.Visible = true;

        for (int i = 0; i < grd001aa.Rows.Count; i++)
        {
            int ALING = Convert.ToInt32(grd001aa.Rows[i].Cells[0].Text);
            if (ALING == 1)
            {
                grd001aa.Rows[i].Cells[7].Enabled = false;

            }

        }

        if (dv.Count == 0)
        {
            lbl001aa.Text = "Este Niño(a) no Posee Diagnostico Escolar";
        }
        else
        {
            lbl001aa.Text = "";

        }

        grd001aa.Focus();
    }
    protected void imb_002aa_Click(object sender, EventArgs e)
    {
        //WebDateChooser tcal001a = (TextBox)utab4.FindControl("cal001");
        //DropDownList tddown001a = (DropDownList)utab4.FindControl("ddown001");
        //DropDownList tddown002a = (DropDownList)utab4.FindControl("ddown002");
        //DropDownList tddown003a = (DropDownList)utab4.FindControl("ddown003");
        //WebMaskEdit ttxt001_wna = (TextBox)utab4.FindControl("txt001_wn");
        //TextBox ttxt002_tea = (TextBox)utab4.FindControl("txt002_te");
        //GridView tgrd001aa = (GridView)utab4.FindControl("grd001aa");
        //SenameTextBox ttxt002_te = (SenameTextBox)utab4.FindControl("txt002_te");
        //Label tlbl001aa = (Label)utab4.FindControl("lbl001aa");
        //Label tlbl002aa = (Label)utab4.FindControl("lbl002aa");
        bool sw = false;

        ninocoll ncoll = new ninocoll();
        diagnosticoscoll dcoll = new diagnosticoscoll();

        //for (int i = 0; i < tgrd001aa.Rows.Count; i++)
        //{
        //    if (Server.HtmlDecode((tgrd001aa.Rows[i].Cells[2]).Text.ToUpper().Trim()) == Server.HtmlDecode(tddown001a.SelectedItem.Text.ToUpper().Trim()) &&
        //        Server.HtmlDecode((tgrd001aa.Rows[i].Cells[4]).Text.ToUpper().Trim()) == Server.HtmlDecode(ttxt001_wna.Text.ToUpper().Trim()) &&
        //        Server.HtmlDecode((tgrd001aa.Rows[i].Cells[5]).Text.ToUpper().Trim()) == Server.HtmlDecode(tddown003a.SelectedItem.Text.ToUpper().Trim()))
        //    {
        //        tlbl002aa.Text = "El menor ya posee diagnostico, Intentelo nuevamente";
        //        sw = true;
        //    }
        //    else
        //    {
        //        sw = false;
        //        tlbl002aa.Text = "";
        //    }

        //}



        if (validateDE() == true && sw == false)
        {
            //utab4.Tabs[0].Style.ForeColor = System.Drawing.Color.Black;
            if (txt002_te.Text == null)
            {
                txt002_te.Text = "SIN OBSERVACION";
            }

            ncoll.Update_DiagnosticosEscolar(AuxEscolar,
            VCod_diagnostico, Convert.ToDateTime(cal01.Text),
            Convert.ToInt32(ddown001.SelectedValue), VFecha_diagnostico,
            Convert.ToInt32(ddown002.SelectedValue), Convert.ToInt32(ddown001.SelectedValue), Convert.ToInt32(ddown002.SelectedValue),
            Convert.ToInt32(ddown003.SelectedValue), Convert.ToInt32(txt001_wn.Text),
            Convert.ToString(txt002_te.Text).ToUpper(), Convert.ToInt32(false), DateTime.Now, Convert.ToInt32(Session["IdUsuario"]));

            clean_tab4();
            lbl002aa.Text = "";

            //WebImageButton tbtn001aa = (WebImageButton)utab4.FindControl("btn001aa");
            //WebImageButton tbtn002aa = (WebImageButton)utab4.FindControl("btn002aa");

            btn001aa.Visible = true;
            btn002aa.Visible = false;


        }
        else
        {

            //utab4.Tabs[0].Style.ForeColor = System.Drawing.Color.Red;

        }
        // tgrd001aa.Columns.Clear();
        //  Label tlbl001aa = (Label)utab4.FindControl("lbl001aa");
        DataTable dt = dcoll.GetDiagnosticoEscolar(SSninoDiag.ICodIE);
        DataView dv = new DataView(dt);

        //dv.Sort = "Alingreso";

        grd001aa.DataSource = dv;

        grd001aa.DataBind();
        grd001aa.Visible = true;
        //utab4.Visible = true;

        for (int i = 0; i < grd001aa.Rows.Count; i++)
        {
            int ALING = Convert.ToInt32(grd001aa.Rows[i].Cells[0].Text);
            if (ALING == 1)
            {
                grd001aa.Rows[i].Cells[7].Enabled = false;

            }

        }

        if (dv.Count == 0)
        {
            lbl001aa.Text = "Este Niño(a) no Posee Diagnostico Escolar";
        }
        else
        {
            lbl001aa.Text = "";
            //    (tgrd001aa.Rows[0].Cells[6]).Enabled = false;
        }

        // GridView tgrd001aa = (GridView)utab4.FindControl("grd001aa");
        grd001aa.Focus();

    }
    protected void imb_003aa_Click(object sender, EventArgs e)
    {
        //WebImageButton tbtn001aa = (WebImageButton)utab4.FindControl("btn001aa");
        //WebImageButton tbtn002aa = (WebImageButton)utab4.FindControl("btn002aa");
        clean_tab4();
        btn002aa.Visible = false;
        btn001aa.Visible = true;
        // GridView tgrd001aa = (GridView)utab4.FindControl("grd001aa");
        //grd001aa.Focus();
    }
    protected void btn004aa_Click(object sender, EventArgs e)
    {
        window.open(this.Page, "ninos_HistoricoDiagnosticoEscolar.aspx", 770, 420);
    }
    protected void btn005aa_Click(object sender, EventArgs e)
    {
        // Getninos();
        clean_tab4();
        //  utab4.Visible = false;
    }
    protected void grd001aa_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        diagnosticoscoll dcoll = new diagnosticoscoll();

        string ICodEscolar = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text;
        AuxEscolar = Convert.ToInt32(ICodEscolar);


        string codDiagnostico = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text;
        VCod_diagnostico = Convert.ToInt32(codDiagnostico);

        string FechaDiagnostico = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Text;
        VFecha_diagnostico = Convert.ToDateTime(FechaDiagnostico);

        DataTable dt = dcoll.GetDiagnosticoEscolarMostrar(VCod_diagnostico);

        cal01.Text = dt.Rows[0][0].ToString();
        try
        {
            ddown001.Items.FindByValue(ddown001.SelectedValue).Selected = false;
            ddown001.Items.FindByValue(dt.Rows[0][6].ToString()).Selected = true;
        }
        catch {
            ddown001.SelectedIndex = 0;
        }

        
        try
        {
            ddown002.Items.FindByValue(ddown002.SelectedValue).Selected = false;
            ddown002.Items.FindByValue(dt.Rows[0][4].ToString()).Selected = true;
        }
        catch
        {
            //ddown002.Items.FindByValue("0").Selected = true;
            ddown002.SelectedIndex = 0;
        }

        try
        {
            ddown003.Items.FindByValue(ddown003.SelectedValue).Selected = false;
            ddown003.Items.FindByValue(dt.Rows[0][7].ToString()).Selected = true;
        }
        catch
        {
            ddown003.SelectedIndex = 0;
        }


        txt001_wn.Text = dt.Rows[0][1].ToString();

        txt002_te.Text = Convert.ToString(dt.Rows[0][2]);

        btn001aa.Visible = false;
        btn002aa.Visible = true;
        //grd001aa.Focus();
    }


    private bool validateDE()
    {
        bool n = true;


        //  WebDateChooser tcal001 = (TextBox)utab4.FindControl("cal001");
        if (cal01.Text == "Seleccione Fecha")
        {

            cal01.BackColor = System.Drawing.Color.Pink;
            n = false;
        }
        else
        {
            cal01.BackColor = System.Drawing.Color.White;

        }
        // DropDownList tddown001 = (DropDownList)utab4.FindControl("ddown001");
        if (Convert.ToInt32(ddown001.SelectedValue) == 0)
        {
            ddown001.BackColor = System.Drawing.Color.Pink;
            n = false;
        }
        else
        {
            ddown001.BackColor = System.Drawing.Color.White;

        }

        // DropDownList tddown002 = (DropDownList)utab4.FindControl("ddown002");
        if (Convert.ToInt32(ddown002.SelectedValue) == 0 || Convert.ToInt32(ddown002.SelectedValue) == -1)
        {
            ddown002.BackColor = System.Drawing.Color.Pink;
            n = false;
        }
        else
        {
            ddown002.BackColor = System.Drawing.Color.White;

        }

        // DropDownList tddown003 = (DropDownList)utab4.FindControl("ddown003");
        if (Convert.ToInt32(ddown003.SelectedValue) == 0)
        {
            ddown003.BackColor = System.Drawing.Color.Pink;
            n = false;
        }
        else
        {
            ddown003.BackColor = System.Drawing.Color.White;

        }

        //WebMaskEdit ttxt001_wn = (TextBox)utab4.FindControl("txt001_wn");
        if (txt001_wn.Text.Trim() == "")
        {
            txt001_wn.BackColor = System.Drawing.Color.Pink;
            n = false;
        }
        else
        {
            txt001_wn.BackColor = System.Drawing.Color.White;

        }
        //  Label tlbl001aa = (Label)utab4.FindControl("lbl001aa");
        if (lbl001aa.Text == "El año Ingresado es mayor al año actual")
        {
            lbl001aa.BackColor = System.Drawing.Color.Pink;
            n = false;
        }
        else
        {
            lbl001aa.BackColor = System.Drawing.Color.White;

        }


        return n;

    }

    private void GetData()
    {

        diagnosticoscoll dcoll = new diagnosticoscoll();
        parcoll par = new parcoll();
        ninocoll ncoll = new ninocoll();
        trabajadorescoll tcoll = new trabajadorescoll();



        DataTable dt = dcoll.GetDiagnosticoEscolar(SSninoDiag.ICodIE);
        DataView dv = new DataView(dt);


        dv.Sort = "Alingreso";
        grd001aa.DataSource = dv;
        grd001aa.DataBind();
        grd001aa.Visible = true;

        for (int i = 0; i < grd001aa.Rows.Count; i++)
        {
            int ALING = Convert.ToInt32(grd001aa.Rows[i].Cells[0].Text);
            if (ALING == 1)
            {
                grd001aa.Rows[i].Cells[7].Enabled = false;

            }

        }


        if (dv.Count == 0)
        {
            lbl001aa.Text = "Este Niño(a) no Posee Diagnostico Escolar";
        }
        else
        {


            lbl001aa.Text = "";
        }

        int Edad = Convert.ToInt32(DateTime.Now.Year) - Convert.ToInt32(SSninoDiag.FechaNacimiento.Year);

        DateTime itime = DateTime.Now;
        TimeSpan compare = itime.Date - SSninoDiag.FechaNacimiento.Date;
        int y = Convert.ToInt32(compare.Days / 365);



        DataView dv13 = new DataView(par.GetparEscolaridad(y));//, Edad));
        ddown001.Items.Clear();
        ddown001.DataSource = dv13;
        ddown001.DataTextField = "Descripcion";
        ddown001.DataValueField = "CodEscolaridad";
        dv13.Sort = "CodEscolaridad";
        ddown001.DataBind();

        DataView dv14 = new DataView(tcoll.GetTrabajadoresProyecto(SSninoDiag.CodProyecto.ToString()));
        ddown002.Items.Clear();
        ddown002.DataSource = dv14;
        ddown002.DataTextField = "NombreCompleto";
        ddown002.DataValueField = "ICodTrabajador";
        dv14.Sort = "NombreCompleto";
        ddown002.DataBind();

        DataView dv15 = new DataView(par.GetparTipoAsistenciaEscolar());
        ddown003.Items.Clear();
        ddown003.DataSource = dv15;
        ddown003.DataTextField = "Descripcion";
        ddown003.DataValueField = "TipoAsistenciaEscolar";
        dv15.Sort = "Descripcion";
        ddown003.DataBind();



    }


    //private void Getninos()
    //{
    //    if (Convert.ToInt32(ddown002.SelectedValue) != 0 || ddown002.SelectedValue != "")
    //    {
    //        ninocoll ncoll = new ninocoll();
    //        DataTable dt = ncoll.callto_getninosxproyectos(Convert.ToInt32(ddown002.SelectedValue));
    //        if (dt.Rows.Count > 0)
    //        {
    //            DataView dv = new DataView(dt);
    //            grd001.Page.Items.Clear();
    //            if (txt002.Text.Trim() != "")
    //            {
    //                dv.RowFilter = "NombreCompleto like '" + txt002.Text.Trim() + "%'";
    //            }

    //            dv.Sort = "NombreCompleto";
    //            grd001.DataSource = dv;
    //            grd001.DataBind();
    //            grd001.Visible = true;
    //        }
    //        else
    //        {

    //            lbl001_aviso.Text = "No existen niños vigentes en para este proyecto";
    //            grd001.Visible = false;

    //        }
    //    }
    //    else
    //    {
    //        lbl001_aviso.Text = "Debe seleccionar un proyecto";
    //    }


    //}




    private void clean_tab4()
    {
    }

    
}
