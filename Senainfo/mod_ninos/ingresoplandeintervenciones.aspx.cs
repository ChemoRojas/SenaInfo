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
//////using neocsharp.NeoDatabase;

public partial class mod_ninos_IngresoPlandeIntervenciones : System.Web.UI.Page
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

    public int VCodTecnico
    {
        get
        {
            if (ViewState["neo_vcodtecnico"] == null)
            { ViewState["neo_vcodtecnico"] = -1; }
            return Convert.ToInt32(ViewState["neo_vcodtecnico"]);
        }
        set { ViewState["neo_vcodtecnico"] = value; }
    }

    public DataTable DTAreaIntervencion
    {
        get { return (DataTable)Session["DTAreaIntervencion"]; }
        set { Session["DTAreaIntervencion"] = value; }
    }

    public DataTable DTPersonasRelacionadas
    {
        get { return (DataTable)Session["DTPersonasRelacionadas"]; }
        set { Session["DTPersonasRelacionadas"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetPlan();
            GetNino();
            GetTecnico();
            GetNivelIntervencion();
            GetTipoIntervencion();
            GetGrAreaIntervencion();
            GetGrPersonasRelacionadas();
        }
    }


    public void GetPlan()
    {

        // SSnino.CodNino = 228725;
        Intervencionescoll intervenciones = new Intervencionescoll();

        DataView dv1 = new DataView(intervenciones.GetIntervenciones(SSnino.CodNino));

        ddown001.DataSource = dv1;
        ddown001.DataTextField = "CodPlanIntervencion";
        ddown001.DataValueField = "CodPlanIntervencion";
        dv1.Sort = "CodPlanIntervencion";
        ddown001.DataBind();
        cal001.Text = dv1[0][2].ToString();
        cal002.Text = dv1[0][8].ToString();
        cal003.Text = dv1[0][9].ToString();
        txt005.Text = dv1[0][11].ToString();
        cal004.Text = dv1[0][10].ToString();
        Chk001.Checked = Convert.ToBoolean(dv1[0][4]);
        Chk002.Checked = Convert.ToBoolean(dv1[0][5]);
        txt006.Text = dv1[0][12].ToString();
        lbl001.Text = dv1[0][3].ToString();

        parcoll par = new parcoll();
        DataView dv4 = new DataView(par.GetparGradoCumplimiento(Convert.ToInt32(dv1[0][3].ToString())));
        txt007.Text = dv4[0][1].ToString();



        personascoll percoll = new personascoll();
        DataView dv5 = new DataView(percoll.GetpersonaRelacionadatrabajar(SSnino.CodNino));

        ddown006.DataSource = dv5;
        ddown006.DataTextField = "NombreCompleto";
        ddown006.DataValueField = "CodPersonaRelacionada";
        dv5.Sort = "NombreCompleto";
        ddown006.DataBind();


        DataView dv6 = new DataView(par.GetparEStadoIntervencion(Convert.ToInt32(dv1[0][1].ToString())));

        ddown005.DataSource = dv6;
        ddown005.DataTextField = "Descripcion";
        ddown005.DataValueField = "CodEstadoIntervencion";
        dv6.Sort = "Descripcion";
        ddown005.DataBind();


    }


    private Boolean Colaboración_Niño()
    {


        if (Chk001.Checked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    private Boolean Participación_Familia()
    {
        if (Chk002.Checked == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }



    public void GetNivelIntervencion()
    {
        parcoll par = new parcoll();
        DataView dv1 = new DataView(par.GetparNivelIntervencion());
        ddown003.DataSource = dv1;
        ddown003.DataTextField = "Descripcion";
        ddown003.DataValueField = "CodNivelIntervencion";
        dv1.Sort = "Descripcion";
        ddown003.DataBind();
    }

    public void GetTipoIntervencion()
    {

        parcoll par = new parcoll();
        DataView dv2 = new DataView(par.GetparTipoIntervencion());
        ddown004.DataSource = dv2;
        ddown004.DataTextField = "Descripcion";
        ddown004.DataValueField = "TipoIntervencion";
        dv2.Sort = "Descripcion";
        ddown004.DataBind();
    }
    public void GetNino()
    {

        // SSnino.CodNino = 228725;

        ninocoll ncoll = new ninocoll();
        nino n = ncoll.GetData(SSnino.CodNino.ToString(),SSnino.ICodIE.ToString());
        txt001.Text = n.Apellido_Paterno.ToString().ToUpper() + ' ' + n.Apellido_Materno.ToString() + ' ' + n.Nombres.ToString();
        txt002.Text = n.NombreProy.ToString().ToUpper();


    }
    public void GetProyecto()
    {

    }

    public void GetTecnico()
    {

        // SSnino.CodProyecto = 1130385;


        trabajadorescoll tcoll = new trabajadorescoll();
        DataView dv3 = new DataView(tcoll.GetTrabajadoresProyecto(SSnino.CodProyecto.ToString()));
        txt003.Text = dv3[1][15].ToString();
        txt004.Text = dv3[1][14].ToString();
        VCodTecnico = Convert.ToInt32(dv3[1][0].ToString());



    }


    protected void ddown001_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetNino();
    }



    private void GetGrAreaIntervencion()
    {
        DTAreaIntervencion = new DataTable();

        DTAreaIntervencion.Columns.Add(new DataColumn("Tipo de Intervención", typeof(string)));
        DTAreaIntervencion.Columns.Add(new DataColumn("Nivel de Intervención", typeof(string)));
        DTAreaIntervencion.Columns.Add(new DataColumn("# Eventos", typeof(int)));
        DTAreaIntervencion.Columns.Add(new DataColumn("Quitar", typeof(int)));

        grd001.Visible = false;
    }

    protected void grd001_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        DTAreaIntervencion.Rows.Remove(DTAreaIntervencion.Rows[Convert.ToInt32(e.CommandArgument)]);
        DataView dv = new DataView(DTAreaIntervencion);
        grd001.DataSource = dv;
        grd001.DataBind();
        grd001.Visible = true;
    }

    protected void btn001_Click(object sender, EventArgs e)
    {
        DataRow dr = DTAreaIntervencion.NewRow();


        dr[0] = ddown003.SelectedItem;
        dr[1] = ddown004.SelectedItem;
        dr[2] = 3;
        dr[3] = DTAreaIntervencion.Rows.Count + 1;

        if (Convert.ToInt32(ddown003.SelectedValue) != 0)
        {

            DTAreaIntervencion.Rows.Add(dr);
            DataView dv = new DataView(DTAreaIntervencion);
            grd001.DataSource = dv;
            dv.Sort = "Quitar";
            grd001.DataBind();
            grd001.Visible = true;
        }


    }

    private void GetGrPersonasRelacionadas()
    {
        DTPersonasRelacionadas = new DataTable();

        DTPersonasRelacionadas.Columns.Add(new DataColumn("Persona Relacionada", typeof(string)));
        DTPersonasRelacionadas.Columns.Add(new DataColumn("Tipo de Relación", typeof(string)));
        DTPersonasRelacionadas.Columns.Add(new DataColumn("Fecha Relación", typeof(DateTime)));
        DTPersonasRelacionadas.Columns.Add(new DataColumn("Quitar", typeof(int)));

        grd002.Visible = false;

    }
    protected void grd002_RowCommand2(object sender, GridViewCommandEventArgs e)
    {
        DTPersonasRelacionadas.Rows.Remove(DTPersonasRelacionadas.Rows[Convert.ToInt32(e.CommandArgument)]);
        DataView dv = new DataView(DTPersonasRelacionadas);
        grd002.DataSource = dv;
        grd002.DataBind();
        grd002.Visible = true;
    }
    protected void btn004_Click(object sender, EventArgs e)
    {
        grillaperrel();
    }


    private void grillaperrel()
    {


        // Borar parametro en duro


        // SSnino.ICodIE = 11911695;

        personascoll percoll = new personascoll();
        DataView dv = new DataView(percoll.GetGrillaPerRel(SSnino.ICodIE));


        DataRow dr = DTPersonasRelacionadas.NewRow();
        dr[0] = dv[0][0].ToString();
        dr[1] = dv[0][1].ToString();
        dr[2] = dv[0][2].ToString();
        dr[3] = DTPersonasRelacionadas.Rows.Count + 1;






        //// GetGrPersonasRelacionadas();
        // int J = 0;
        // for (int I = 0; I < dv.Count; I++)
        // {
        //     if (I == 1)
        //     {
        //         J = 0;
        //     }
        //     while(J < 4)
        //     {

        //         DataRow dr = DTPersonasRelacionadas.NewRow();

        //         if (J == 3)
        //         {

        //             dr[I][J] = DTPersonasRelacionadas.Rows.Count + 1;

        //         }
        //         else
        //         {

        //         dr[J] = dv[I][J].ToString();
        //         }

        //         //if (Convert.ToInt32(ddown003.SelectedValue) != 0)
        //         //{
        //         //    //lbl001.Visible = false;

        //         //    //if (DTinmueble.Rows.Count < 3)
        //         //    //{
        //         //    DTAreaIntervencion.Rows.Add(dr);
        //         //    //  }
        //         //    DataView dv = new DataView(DTAreaIntervencion);
        //         //    grd001.DataSource = dv;
        //         //    dv.Sort = "Quitar";
        //         //    grd001.DataBind();
        //         //    grd001.Visible = true;
        //         // }

        //         J = J + 1;
        //     }

        // }

        //DataView dv = new DataView(DTPersonasRelacionadas);
        //grd002.DataSource = dv;
        //dv.Sort = "Quitar";
        //grd002.DataBind();
        //grd002.Visible = true;



    }
    protected void btn003_Click(object sender, EventArgs e)
    {
        ninocoll ncoll = new ninocoll();
        Intervencionescoll intercoll = new Intervencionescoll();

        //parametro en duro debe ser borrado
        //   SSnino.CodInst = 12345;


        intercoll.Update_PlanIntervencion(Convert.ToInt32(ddown001.SelectedValue),
        SSnino.ICodIE, Convert.ToDateTime(cal001.Text), Convert.ToInt32(lbl001.Text), Colaboración_Niño(),
        Participación_Familia(), SSnino.CodInst, VCodTecnico, Convert.ToDateTime(cal002.Text),
        Convert.ToDateTime(cal003.Text), Convert.ToDateTime(cal004.Text), txt005.Text, txt006.Text,
        Convert.ToBoolean(ddown007.SelectedValue), Convert.ToBoolean(ddown008.SelectedValue), DateTime.Now, Convert.ToInt32(Session["IdUsuario"]));

        window.close(this);

    }
}

