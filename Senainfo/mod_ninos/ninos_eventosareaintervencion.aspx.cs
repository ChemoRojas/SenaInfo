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


public partial class mod_ninos_ninos_eventosareaintervencion : System.Web.UI.Page
{
    public nino SSnino
    {
        get
        {
            if (Session["neo_SSnino"] == null)
            { Session["neo_SSnino"] = new nino(); }
            return (nino)Session["neo_SSnino"];
        }
        set { Session["neo_SSnino"] = value; }

    }
    public int VCodIntervenciones
    {
        get
        {
            if (ViewState["neo_vcodintervenciones"] == null)
            { ViewState["neo_vcodintervenciones"] = -1; }
            return Convert.ToInt32(ViewState["neo_vcodintervenciones"]);
        }
        set { ViewState["neo_vcodintervenciones"] = value; }
    }

    public DataTable DTAreaintervencion
    {
        get { return (DataTable)Session["DTAreaintervencion"]; }
        set { Session["DTAreaintervencion"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            GetPlan();
            GetGrAreaIntervencion();
        }
    }

    private void GetPlan()
    {

        Intervencionescoll intervenciones = new Intervencionescoll();
        DataView dv1 = new DataView(intervenciones.GetIntervenciones(SSnino.CodNino));

        ddown001.DataSource = dv1;
        ddown001.DataTextField = "CodPlanIntervencion";
        ddown001.DataValueField = "CodPlanIntervencion";
        dv1.Sort = "CodPlanIntervencion";
        ddown001.DataBind();
        txt_002.Text = dv1[0][8].ToString();
        txt_003.Text = dv1[0][10].ToString();

        VCodIntervenciones = Convert.ToInt32(dv1[0][3].ToString());

        ninocoll ncoll = new ninocoll();
        nino n = ncoll.GetData(SSnino.CodNino.ToString(), SSnino.ICodIE.ToString());
        txt_004.Text = n.Apellido_Paterno.ToString().ToUpper() + ' ' + n.Apellido_Materno.ToString() + ' ' + n.Nombres.ToString();
        txt_005.Text = n.NombreProy.ToString().ToUpper();

        DataView dv2 = new DataView(intervenciones.GetTipoNivelIntervencion(Convert.ToInt32(ddown001.Text)));
        ddown002.DataSource = dv2;
        ddown002.DataTextField = "Tipos";
        ddown002.DataValueField = "CodPlanIntervencion";
        dv2.Sort = "Tipos";
        ddown002.DataBind();

        DataView dv3 = new DataView(intervenciones.GetparTipoEventos());
        ddown003.DataSource = dv3;
        ddown003.DataTextField = "Descripcion";
        ddown003.DataValueField = "TipoEventos";
        dv3.Sort = "Descripcion";
        ddown003.DataBind();

        trabajadorescoll tcoll = new trabajadorescoll();
        DataView dv4 = new DataView(tcoll.GetTrabajadoresProyecto(Convert.ToString(SSnino.CodProyecto)));
        ddown004.DataSource = dv4;
        ddown004.DataTextField = "NombreCompleto";
        ddown004.DataValueField = "ICodTrabajador";
        dv4.Sort = "NombreCompleto";
        ddown004.DataBind();



    }

    private void GetGrAreaIntervencion()
    {
        DTAreaintervencion = new DataTable();

        DTAreaintervencion.Columns.Add(new DataColumn("Fecha de Evento", typeof(string)));
        DTAreaintervencion.Columns.Add(new DataColumn("Tipo de evento", typeof(string)));
        DTAreaintervencion.Columns.Add(new DataColumn("Técnico", typeof(string)));
        DTAreaintervencion.Columns.Add(new DataColumn("Descripción", typeof(string)));
        DTAreaintervencion.Columns.Add(new DataColumn("Quitar", typeof(int)));

        grd001.Visible = false;
    }

    protected void grd001_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        DTAreaintervencion.Rows.Remove(DTAreaintervencion.Rows[Convert.ToInt32(e.CommandArgument)]);
        DataView dv = new DataView(DTAreaintervencion);
        grd001.DataSource = dv;
        grd001.DataBind();
        grd001.Visible = true;
    }


    protected void btn001_Click(object sender, EventArgs e)
    {
        DataRow dr = DTAreaintervencion.NewRow();


        dr[0] = cal001.Text;
        dr[1] = ddown003.SelectedValue;
        dr[2] = ddown004.SelectedValue;
        dr[3] = txt_007.Text;
        dr[4] = DTAreaintervencion.Rows.Count + 1;

        if (Convert.ToInt32(ddown003.SelectedValue) != 0)
        {
            lbl001.Visible = false;

            //if (DTinmueble.Rows.Count < 3)
            //{
            DTAreaintervencion.Rows.Add(dr);
            //  }
            DataView dv = new DataView(DTAreaintervencion);
            grd001.DataSource = dv;
            dv.Sort = "Quitar";
            grd001.DataBind();
            grd001.Visible = true;
        }
        else
        {
            lbl001.Visible = true;

        }
    }
    protected void btn002_Click(object sender, EventArgs e)
    {
        ninocoll ncoll = new ninocoll();
        Intervencionescoll intervenciones = new Intervencionescoll();

        intervenciones.Update_EventosIntervencion(Convert.ToInt32(ddown003.SelectedValue), VCodIntervenciones,
            Convert.ToDateTime(cal001.Text), txt_007.Text,
            SSnino.CodInst, Convert.ToInt32(ddown004.SelectedValue), DateTime.Now, Convert.ToInt32(Session["IdUsuario"]));
    }
}
