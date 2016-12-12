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

public partial class mod_ninos_ninos_ingreso : System.Web.UI.UserControl
{
    public nino SSnino
    {
        get { return (nino)Session["neo_SSnino"]; } 
        set { Session["neo_SSnino"] = value; }
    }
    public DataTable DTordentribunales
    {
        get { return (DataTable)Session["DTordentribunales"]; }
        set { Session["DTordentribunales"] = value; }
    }
    public DataTable DTcausales
    {
        get { return (DataTable)Session["DTcausales"]; }
        set { Session["DTcausales"] = value; }
    }
    public DataTable DTlesiones
    {
        get { return (DataTable)Session["DTlesiones"]; }
        set { Session["DTlesiones"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
       
        
    }


    public void getdefaultdata()
    {
    
        inmueblecoll incoll = new inmueblecoll();


        DataTable dt = incoll.GetInmueble("0");
        DataView dv = new DataView(dt);
         ddown002.DataSource = dv;
        ddown002.DataTextField = "Nombre";
        ddown002.DataValueField = "CodInmueble";
        dv.Sort = "Nombre";
        ddown002.DataBind();

        atencioncoll acoll = new atencioncoll();
        

        DataView dv2 = new DataView(acoll.GetparTipoAtencion());
        ddown003.DataSource = dv2;
        ddown003.DataTextField = "Descripcion";
        ddown003.DataValueField = "CodTipoAtencion";
        dv2.Sort = "Descripcion";
        ddown003.DataBind();

        parcoll par = new parcoll();
        
        DataView dv3 = new DataView(par.GetparCalidadJuridica());
        ddown004.DataSource = dv3;
        ddown004.DataTextField = "Descripcion";
        ddown004.DataValueField = "CodCalidadJuridica";
        dv3.Sort = "Descripcion";
        ddown004.DataBind();

        DataView dv4 = new DataView(par.GetparEscolaridad());
        ddown005.DataSource = dv4;
        ddown005.DataTextField = "Descripcion";
        ddown005.DataValueField = "CodEscolaridad";
        dv4.Sort = "Descripcion";
        ddown005.DataBind();


        DataView dv5 = new DataView(par.GetparTipoAsistenciaEscolar());
        
        ddown006.DataSource = dv5;
        ddown006.DataTextField = "Descripcion";
        ddown006.DataValueField = "TipoAsistenciaEscolar";
        dv5.Sort = "Descripcion";
        ddown006.DataBind();

        DataView dv6 = new DataView(par.GetparRegion());
        
        ddown007a.DataSource = dv6;
        ddown007a.DataTextField = "Descripcion";
        ddown007a.DataValueField = "CodRegion";
        dv6.Sort = "Descripcion";
        ddown007a.DataBind();


        DataView dv7 = new DataView(par.GetparTipoRelacionConQuienVive());
        
        ddown008.DataSource = dv7;
        ddown008.DataTextField = "Descripcion";
        ddown008.DataValueField = "CodTipoRelacionConQuienVive";
        dv7.Sort = "Descripcion";
        ddown008.DataBind();

        DataView dv8 = new DataView(par.GetparTipoRelacionPersonaContacto());
        
        ddown009.DataSource = dv8;
        ddown009.DataTextField = "Descripcion";
        ddown009.DataValueField = "CodTipoRelacionPersonaContacto";
        dv8.Sort = "Descripcion";
        ddown009.DataBind();

        trabajadorescoll tcoll = new trabajadorescoll();
        DataView dv9 = new DataView(tcoll.GetTrabajadoresProyecto("0"));
        
        ddown010.DataSource = dv9;
        ddown010.DataTextField = "NombreCompleto";
        ddown010.DataValueField = "CodTrabajador";
        
        ddown011.DataSource = dv9;
        ddown011.DataTextField = "NombreCompleto";
        ddown011.DataValueField = "CodTrabajador";
        dv9.Sort = "NombreCompleto";
        ddown010.DataBind();
        ddown011.DataBind();

        DataView dv11 = new DataView(par.GetparTipoSolicitanteIngreso());
        ddown012.DataSource = dv11;
        ddown012.DataTextField = "Descripcion";
        ddown012.DataValueField = "TipoSolicitanteIngreso";
        dv11.Sort = "Descripcion";
        ddown012.DataBind();

       

        if (ddown018.Items.Count == 1)
        {
            getcausalesall();
        }



    }

    public void gettribunalesall()
    {
        parcoll par = new parcoll();

        DTordentribunales = new DataTable();

        DTordentribunales.Columns.Add(new DataColumn("CodTribunal", typeof(int)));
        DTordentribunales.Columns.Add(new DataColumn("Descripcion", typeof(string)));
        DTordentribunales.Columns.Add(new DataColumn("Fecha", typeof(DateTime)));
        DTordentribunales.Columns.Add(new DataColumn("Expediente", typeof(string)));

        grd001.Visible = false;

        DataView dv13 = new DataView(par.GetparRegion());
        ddown014.DataSource = dv13;
        ddown014.DataTextField = "Descripcion";
        ddown014.DataValueField = "CodRegion";
        dv13.Sort = "Descripcion";
        ddown014.DataBind();

        DataView dv14 = new DataView(par.GetparTipoTribunal());
        ddown015.DataSource = dv14;
        ddown015.DataTextField = "Descripcion";
        ddown015.DataValueField = "TipoTribunal";
        dv14.Sort = "Descripcion";
        ddown015.DataBind();

        gettribunales();

    }

    public void gettribunales()
    {
        parcoll par = new parcoll();

        DataView dv15 = new DataView(par.GetparTribunales(ddown014.SelectedValue, ddown015.SelectedValue));
        ddown016.DataSource = dv15;
        ddown016.DataTextField = "Descripcion";
        ddown016.DataValueField = "CodTribunal";
        dv15.Sort = "Descripcion";
        ddown016.DataBind();
    }

    protected void WebCombo1_SelectedRowChanged(object sender, EventArgs e)
    {

    }
    protected void rdo001_CheckedChanged(object sender, EventArgs e)
    {
        pnl001.Visible = true;
        gettribunalesall();
        rdo004.Focus();

    }
    protected void rdo002_CheckedChanged(object sender, EventArgs e)
    {
        pnl001.Visible = true;
        gettribunalesall();
        rdo004.Focus();
    }
    protected void rdo003_CheckedChanged(object sender, EventArgs e)
    {
        pnl001.Visible = false;
        rdo004.Focus();
    }
    protected void ddown015_SelectedIndexChanged(object sender, EventArgs e)
    {
        gettribunales();
        rdo004.Focus();
    }
    protected void ddown014_SelectedIndexChanged(object sender, EventArgs e)
    {
        gettribunales();
        rdo004.Focus();
    }
    protected void btn001_Click(object sender, EventArgs e)
    {
        DataRow dr = DTordentribunales.NewRow();
        dr[0] = Convert.ToInt32(ddown016.SelectedValue);
        dr[1] = ddown016.SelectedItem.Text;
        dr[2] = Convert.ToDateTime(ddown017.Text);
        dr[3] = txt005.Text;

        DTordentribunales.Rows.Add(dr);
        DataView dv = new DataView(DTordentribunales);
        grd001.DataSource = dv;
        grd001.DataBind();
        grd001.Visible = true;
        rdo004.Focus();

    }
    protected void grd001_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        DTordentribunales.Rows.Remove(DTordentribunales.Rows[Convert.ToInt32(e.CommandArgument)]);

        DataView dv = new DataView(DTordentribunales);
        grd001.DataSource = dv;
        grd001.DataBind();
        grd001.Visible = true;
        rdo004.Focus();
    }

    public void getcausalesall()
    {
        DTcausales = new DataTable();

        DTcausales.Columns.Add(new DataColumn("CodTipoCausalIngreso", typeof(int)));
        DTcausales.Columns.Add(new DataColumn("CodCausalIngreso", typeof(int)));
        DTcausales.Columns.Add(new DataColumn("DescripcionTipo", typeof(string)));
        DTcausales.Columns.Add(new DataColumn("Descripcion", typeof(string)));
        DTcausales.Columns.Add(new DataColumn("entidad", typeof(string)));

        grd002.Visible = false;

        parcoll par = new parcoll();

        DataView dv15 = new DataView(par.GetparTipoCausalIngreso());
        ddown018.DataSource = dv15;
        ddown018.DataTextField = "Descripcion";
        ddown018.DataValueField = "CodTipoCausalIngreso";
        dv15.Sort = "Descripcion";
        ddown018.DataBind();


        getcausales();


    }

    private void getcausales()
    {
        parcoll par = new parcoll();

        DataView dv16 = new DataView(par.GetparCausalesIngreso(ddown018.SelectedValue, SSnino.CodProyecto));
        ddown019.DataSource = dv16;
        ddown019.DataTextField = "Descripcion";
        ddown019.DataValueField = "CodCausalIngreso";
        dv16.Sort = "Descripcion";
        ddown019.DataBind();
    }

    protected void btn002_Click(object sender, EventArgs e)
    {
        DataRow dr = DTcausales.NewRow();
        dr[0] = Convert.ToInt32(ddown018.SelectedValue);
        dr[1] = Convert.ToInt32(ddown019.SelectedValue);
        dr[2] = ddown018.SelectedItem.Text;
        dr[3] = ddown019.SelectedItem.Text;
        dr[4] = ddown020.SelectedItem.Text;


        DTcausales.Rows.Add(dr);
        DataView dv = new DataView(DTcausales);
        grd002.DataSource = dv;
        grd002.DataBind();
        grd002.Visible = true;
        rdo004.Focus();
    }
    protected void ddown018_SelectedIndexChanged(object sender, EventArgs e)
    {
        getcausales();
        rdo004.Focus();
    }

    protected void grd002_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        DTcausales.Rows.Remove(DTcausales.Rows[Convert.ToInt32(e.CommandArgument)]);

        DataView dv = new DataView(DTcausales);
        grd002.DataSource = dv;
        grd002.DataBind();
        grd002.Visible = true;
        rdo004.Focus();
    }
    protected void btn003_Click(object sender, EventArgs e)
    {
        DataRow dr = DTlesiones.NewRow();
        dr[0] = Convert.ToInt32(ddown021.SelectedValue);
        dr[1] = Convert.ToInt32(ddown022.SelectedValue);
        dr[2] = ddown021.SelectedItem.Text;
        dr[3] = ddown022.SelectedItem.Text;
        dr[4] = txt007.Text;


        DTlesiones.Rows.Add(dr);
        DataView dv = new DataView(DTlesiones);
        grd003.DataSource = dv;
        grd003.DataBind();
        grd003.Visible = true;
        rdo004.Focus();
    }

    public void getlesionesall()
    {
        DTlesiones = new DataTable();

        DTlesiones.Columns.Add(new DataColumn("TipoLesiones", typeof(int)));
        DTlesiones.Columns.Add(new DataColumn("CodQuienOcasionaLesion", typeof(int)));
        DTlesiones.Columns.Add(new DataColumn("DescripcionTipo", typeof(string)));
        DTlesiones.Columns.Add(new DataColumn("Descripcion", typeof(string)));
        DTlesiones.Columns.Add(new DataColumn("observaciones", typeof(string)));

        grd002.Visible = false;

        parcoll par = new parcoll();

        DataView dv16 = new DataView(par.GetparTipoLesiones());
        ddown021.DataSource = dv16;
        ddown021.DataTextField = "Descripcion";
        ddown021.DataValueField = "TipoLesiones";
        dv16.Sort = "Descripcion";
        ddown021.DataBind();

        DataView dv17 = new DataView(par.GetparQuienOcasionaLesion());
        ddown022.DataSource = dv17;
        ddown022.DataTextField = "Descripcion";
        ddown022.DataValueField = "CodQuienOcasionaLesion";
        dv17.Sort = "Descripcion";
        ddown022.DataBind();




    }


    protected void rdo004_CheckedChanged(object sender, EventArgs e)
    {
        pnl002.Visible = true;
        getlesionesall();
        rdo004.Focus();
    }

    protected void grd003_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DTlesiones.Rows.Remove(DTlesiones.Rows[Convert.ToInt32(e.CommandArgument)]);

        DataView dv = new DataView(DTlesiones);
        grd003.DataSource = dv;
        grd003.DataBind();
        grd003.Visible = true;
        rdo004.Focus();
    }
    protected void rdo005_CheckedChanged(object sender, EventArgs e)
    {
        pnl002.Visible = false;
        rdo004.Focus();
    }
    protected void ddown007a_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ( Convert.ToInt32(ddown007a.SelectedValue) > 0)
        {
            parcoll par = new parcoll();
            DataView dv6 = new DataView(par.GetparComunas(ddown007a.SelectedValue));
            ddown007.Items.Clear();
            ddown007.DataSource = dv6;
            ddown007.DataTextField = "Descripcion";
            ddown007.DataValueField = "CodComuna";
            dv6.Sort = "Descripcion";
            ddown007.DataBind();

        }
        else
        {
            ddown007.Items.Clear();
        }
        rdo004.Focus();
    }
}