/*
 * GMP
 * 22/05/2015
 * Revisado, pero no tiene funcionalidad: carga cmb instituciones y con este carga proyectos.. nada más
 * 
 */
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

public partial class mod_ninos_Nuevo_Plan_de_Intervención_plan_intervencion_seleccion_nino : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            getInstituciones();
            getProyectosPorCodigo();
        }
    }

    //private int Get_Resultado_Busqueda(int PlanIntervencion, int CodGrupo, int grupo)
    //{
    //    DropDownList tddown001 = (DropDownList)utab.FindControl("ddown001");
    //    DropDownList tddown002 = (DropDownList)utab.FindControl("ddown002");
    //    DropDownList tddown001c = (DropDownList)utab.FindControl("ddown001c");
    //    DropDownList tddown002c = (DropDownList)utab.FindControl("ddown002c");
    //    DropDownList tddown001d = (DropDownList)utab.FindControl("ddown001d");
    //    DropDownList tddown001e = (DropDownList)utab.FindControl("ddown001e");
    //    DropDownList tddown001f = (DropDownList)utab.FindControl("ddown001f");
    //    DropDownList tddown002f = (DropDownList)utab.FindControl("ddown002f");
    //    DropDownList tddown003f = (DropDownList)utab.FindControl("ddown003f");
    //    DropDownList tddown001b = (DropDownList)utab.FindControl("ddown001b");
    //    WebMaskEdit ttxt001 = (TextBox)utab.FindControl("txt001");
    //    WebMaskEdit ttxt004b = (TextBox)utab.FindControl("txt004b");
    //    WebMaskEdit ttxt002b = (TextBox)utab.FindControl("txt002b");
    //    TextBox ttxt001b = (TextBox)utab.FindControl("txt001b");
    //    TextBox ttxt003b = (TextBox)utab.FindControl("txt003b");
    //    TextBox ttxt001d = (TextBox)utab.FindControl("txt001d");
    //    GridView tgrd001 = (GridView)utab.FindControl("grd001");
    //    GridView tgrd002 = (GridView)utab.FindControl("grd002");
    //    GridView tgrd001c = (GridView)utab.FindControl("grd001c");
    //    GridView tgrd001e = (GridView)utab.FindControl("grd001e");
    //    WebDateChooser twdc001 = (TextBox)utab.FindControl("wdc001");
    //    WebDateChooser twdc002 = (TextBox)utab.FindControl("wdc002");
    //    WebDateChooser twdc003 = (TextBox)utab.FindControl("wdc003");
    //    WebDateChooser twdc001f = (TextBox)utab.FindControl("wdc001f");
    //    CheckBox tchk001d = (CheckBox)utab.FindControl("chk001d");
    //    CheckBox tchk002d = (CheckBox)utab.FindControl("chk002d");
    //    Label tlbl001e = (Label)utab.FindControl("lbl001e");
    //    Label tlbl002e = (Label)utab.FindControl("lbl002e");
    //    RadioButtonList trdolist001 = (RadioButtonList)utab.FindControl("rdolist001");
    //    RadioButtonList trdolist002 = (RadioButtonList)utab.FindControl("rdolist002");
    //    WebImageButton twib005 = (WebImageButton)utab.FindControl("WebImageButton5");
    //    Label tlbl001d = (Label)utab.FindControl("lbl001d");
    //    Label tlbl001b = (Label)utab.FindControl("lbl001b");
    //    GridView tgrd001d = (GridView)utab.FindControl("grd001d");
    //    WebImageButton tWIB4 = (WebImageButton)utab.FindControl("WebImageButton4");
    //    WebImageButton tWIB9 = (WebImageButton)utab.FindControl("WebImageButton9");

    //    tWIB4.Visible = false;
    //    tWIB9.Visible = true;

    //    pintervencion pin = new pintervencion();
    //    tgrd001e.Columns[3].Visible = false;
    //    twib005.Visible = true;

    //    if (CodGrupo == 0)
    //    {


    //        ttxt004b.Visible = false;
    //        tlbl001b.Visible = false;

    //        DataView dv = new DataView(pin.get_nino_solo(vCodPaso));
    //        ttxt001.Enabled = false;
    //        tgrd001.Visible = false;
    //        tgrd002.Visible = true;
    //        tgrd002.Columns[9].Visible = true;
    //        tgrd002.Columns[10].Visible = false;
    //        tgrd002.Columns[0].Visible = true;
    //        tgrd002.DataSource = dv;
    //        tgrd002.DataBind();

    //        DataTable dt = pin.GetPlanIntervencionxNino(vCodPaso);
    //        ttxt004b.Text = Convert.ToString(dt.Rows[0][17]);
    //        twdc001.Value = Convert.ToDateTime(dt.Rows[0][3]);
    //        twdc002.Value = Convert.ToDateTime(dt.Rows[0][10]);
    //        twdc003.Value = Convert.ToDateTime(dt.Rows[0][11]);

    //        twdc001.Enabled = false;
    //        twdc002.MinDate = Convert.ToDateTime(twdc001.Value);

    //        ttxt003b.Text = Convert.ToString(dt.Rows[0][13]);
    //        tddown001b.SelectedValue = Convert.ToString(dt.Rows[0][7]);
    //        if (Convert.ToInt32(dt.Rows[0][5]) == 1)
    //        { tchk001d.Checked = true; }
    //        else { tchk001d.Checked = false; }
    //        if (Convert.ToInt32(dt.Rows[0][6]) == 1)
    //        { tchk002d.Checked = true; }
    //        else { tchk002d.Checked = false; }
    //        ttxt001d.Text = Convert.ToString(dt.Rows[0][14]);
    //        trdolist001.SelectedValue = Convert.ToString(Convert.ToInt32(dt.Rows[0][16]));
    //        trdolist002.SelectedValue = Convert.ToString(Convert.ToInt32(dt.Rows[0][15]));
    //        tddown003f.SelectedValue = Convert.ToString(dt.Rows[0][4]);
    //        if (Convert.ToString(dt.Rows[0][12]) == "01/01/1900 0:00:00")
    //        {

    //        }
    //        else
    //        {
    //            twdc001f.Value = null;
    //        }

    //        //   tddown001b.SelectedValue = Convert.ToString(dt.Rows[0][9]);

    //        ttxt004b.Visible = true;

    //        gettipointervencion(Convert.ToInt32(CodProyecto));
    //        getnivelintervencion();

    //        cargaareasintervencion();

    //        dt = pin.GetEstadoIntervencionxNino(vCodPaso);
    //        DTEI = dt;

    //        tddown001d.SelectedValue = Convert.ToString(dt.Rows[0][2]);
    //        getPersonaRelacionada(Convert.ToInt32(tgrd002.Rows[0].Cells[2].Text));

    //        dt = pin.GetTrabajaEgreso(vCodPaso);

    //        DataTable dt3 = new DataTable();
    //        DataRow dr3;
    //        dt3.Columns.Add(new DataColumn("nombres", typeof(String)));
    //        dt3.Columns.Add(new DataColumn("CodPersonaRelacionada", typeof(int)));
    //        dt3.Columns.Add(new DataColumn("descripcion", typeof(String)));
    //        dt3.Columns.Add(new DataColumn("fecharelacion", typeof(DateTime)));
    //        dt3.Columns.Add(new DataColumn("chequea", typeof(int)));


    //        for (int i = 0; i < dt.Rows.Count; i++)
    //        {
    //            dr3 = dt3.NewRow();
    //            dr3[0] = Convert.ToString(dt.Rows[i][0]);
    //            dr3[1] = Convert.ToInt32(dt.Rows[i][3]);
    //            tddown001e.SelectedValue = Convert.ToString(dt.Rows[i][3]);
    //            dr3[2] = tddown001e.SelectedItem.Text;
    //            dr3[3] = Convert.ToDateTime(dt.Rows[i][4]).ToShortDateString();
    //            dr3[4] = 0;
    //            dt3.Rows.Add(dr3);

    //        }
    //        tgrd001e.Columns[3].Visible = true;
    //        tgrd001e.DataSource = dt3;
    //        tgrd001e.DataBind();
    //        tgrd001e.Visible = true;

    //        for (int i = 0; i < tgrd001e.Rows.Count; i++)
    //        {
    //            tgrd001e.Rows[i].Cells[4].Enabled = false;

    //        }

    //        utab.Tabs[1].Visible = true;
    //        utab.Tabs[2].Visible = true;
    //        utab.Tabs[3].Visible = true;
    //        utab.Tabs[4].Visible = true;
    //        utab.Tabs[5].Visible = true;


    //        //vCodPaso2 = -1;
    //        dv = new DataView(pin.GetEstadosPlanIntevencion(vCodPaso));
    //        if (dv.Table.Rows.Count > 0)
    //        {
    //            dv.Sort = "FechaCreacion";
    //            tgrd001d.DataSource = dv;
    //            tgrd001d.DataBind();

    //            tgrd001d.Visible = true;
    //            tlbl001d.Visible = true;

    //        }

    //        getnivelintervencion();
    //        if (grupo != 0)
    //        {
    //            vCodPaso2 = grupo;
    //            for (int i = 1; i < (utab.Tabs.Count - 2); i++)
    //            {
    //                Infragistics.WebUI.UltraWebTab.Tab tab = this.utab.Tabs.GetTab(i);
    //                tab.Enabled = false;
    //                WebImageButton tWIB5 = (WebImageButton)utab.FindControl("WebImageButton5");
    //                tWIB5.Visible = false;
    //            }
    //        }
    //        else
    //        {
    //            for (int i = 1; i < (utab.Tabs.Count - 2); i++)
    //            {
    //                Infragistics.WebUI.UltraWebTab.Tab tab = this.utab.Tabs.GetTab(i);
    //                tab.Enabled = true;
    //                WebImageButton tWIB5 = (WebImageButton)utab.FindControl("WebImageButton5");
    //                tWIB5.Visible = true;
    //            }
    //        }
    //    }
    //    else
    //    {
    //        for (int i = 1; i < (utab.Tabs.Count - 2); i++)
    //        {
    //            Infragistics.WebUI.UltraWebTab.Tab tab = this.utab.Tabs.GetTab(i);
    //            tab.Enabled = true;
    //            WebImageButton tWIB5 = (WebImageButton)utab.FindControl("WebImageButton5");
    //            tWIB5.Visible = true;
    //        }

    //        tgrd001d.Visible = false;
    //        tlbl001d.Visible = false;
    //        ttxt004b.Visible = true;
    //        tlbl001b.Visible = true;

    //        DataView dv = new DataView(pin.get_ninos_grupo(vCodPaso2));
    //        ttxt001.Enabled = false;
    //        tgrd001.Visible = false;
    //        tgrd002.Visible = true;
    //        tgrd002.Columns[0].Visible = true;
    //        tgrd002.Columns[10].Visible = false;
    //        tgrd002.DataSource = dv;
    //        tgrd002.DataBind();

    //        DataTable dt = pin.GetPlanIntervencionxGrupo(vCodPaso2);
    //        ttxt004b.Text = Convert.ToString(dt.Rows[0][17]);
    //        twdc001.Value = Convert.ToDateTime(dt.Rows[0][3]);
    //        twdc002.Value = Convert.ToDateTime(dt.Rows[0][10]);
    //        twdc003.Value = Convert.ToDateTime(dt.Rows[0][11]);

    //        twdc001.Enabled = false;
    //        twdc002.MinDate = Convert.ToDateTime(twdc001.Value);

    //        ttxt003b.Text = Convert.ToString(dt.Rows[0][13]);
    //        tddown001b.SelectedValue = Convert.ToString(dt.Rows[0][7]);
    //        if (Convert.ToInt32(dt.Rows[0][5]) == 1)
    //        { tchk001d.Checked = true; }
    //        else { tchk001d.Checked = false; }
    //        if (Convert.ToInt32(dt.Rows[0][6]) == 1)
    //        { tchk002d.Checked = true; }
    //        else { tchk002d.Checked = false; }
    //        ttxt001d.Text = Convert.ToString(dt.Rows[0][14]);
    //        trdolist001.SelectedValue = Convert.ToString(Convert.ToInt32(dt.Rows[0][16]));
    //        trdolist002.SelectedValue = Convert.ToString(Convert.ToInt32(dt.Rows[0][15]));
    //        tddown003f.SelectedValue = Convert.ToString(dt.Rows[0][4]);
    //        if (Convert.ToString(dt.Rows[0][12]) == "01/01/1900 0:00:00")
    //        {

    //        }
    //        else
    //        {
    //            twdc001f.Value = null;
    //        }

    //        ttxt004b.Visible = true;

    //        gettipointervencion(Convert.ToInt32(CodProyecto));
    //        getnivelintervencion();
    //        cargaareadeintervenciongrupal();

    //        dt = pin.GetEstadoIntervencionxGrupo(vCodPaso2);
    //        DTEI = dt;
    //        tddown001d.SelectedValue = Convert.ToString(dt.Rows[0][2]);

    //        utab.Tabs[1].Visible = true;
    //        utab.Tabs[2].Visible = true;
    //        utab.Tabs[3].Visible = true;
    //        utab.Tabs[5].Visible = true;

    //        getnivelintervencion();

    //    }
    //    return 0;

    //}
    
    private void getInstituciones()
    {
        DataView dv1 = new DataView();
        dv1 = (DataView)Session["PI_Instituciones"];
        if (dv1 == null) {
            institucioncoll ncoll = new institucioncoll();
            dv1 = new DataView(ncoll.GetData(Convert.ToInt32(Session["IdUsuario"])));
            Session["PI_Instituciones"] = dv1;
        }

        ddown001.DataSource = dv1;
        ddown001.DataTextField = "Nombre";
        ddown001.DataValueField = "CodInstitucion";
        dv1.Sort = "Nombre";
        ddown001.DataBind();
        if (dv1.Count > 0)
        {
            ddown001.SelectedIndex = 1;
            ddown001_SelectedIndexChanged(new object(), new EventArgs());
        }
    }
   
    private void getProyectosPorCodigo()
    {
        proyectocoll pcoll = new proyectocoll();
        DataView dv = new DataView(pcoll.GetData(Convert.ToInt32(Session["IdUsuario"]), "V", Convert.ToInt32(ddown001.SelectedValue)));
        dv.Sort = "Nombre";
        ddown002.DataSource = dv;
        ddown002.DataTextField = "Nombre";
        ddown002.DataValueField = "CodProyecto";
        ddown002.DataBind();
    }

    protected void imb001_Click(object sender, ImageClickEventArgs e)
    {
        //string etiqueta = "Plan de Intervencion";
        //window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_ninos/plan_intervencion.aspx", "Buscador", false, true, 500, 650, false, false, true);
    }

    protected void imb002_Click(object sender, ImageClickEventArgs e)
    {
        //string etiqueta = "Busca Proyectos";
        //window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_ninos/plan_intervencion.aspx", "Buscador", false, true, 770, 420, false, false, true);
    }

    protected void ddown001_SelectedIndexChanged(object sender, EventArgs e)
    {
        getProyectosPorCodigo();
    }

}
