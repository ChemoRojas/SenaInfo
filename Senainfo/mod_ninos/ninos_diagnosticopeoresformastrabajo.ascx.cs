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

public partial class mod_ninos_ninos_diagnosticopeoresformastrabajo : System.Web.UI.UserControl
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
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void getdata()
    {
        parcoll par = new parcoll();
        trabajadorescoll tcoll = new trabajadorescoll();
        ninocoll ncoll = new ninocoll();


        DataView dv0 = new DataView(par.GetparRegion());
        ddown_region.DataSource = dv0;
        ddown_region.DataTextField = "Descripcion";
        ddown_region.DataValueField = "CodRegion";
        dv0.Sort = "Descripcion";
        ddown_region.DataBind();

        DataView dv1 = new DataView(par.GetparCategoriasPFMI());
        ddown001.DataSource = dv1;
        ddown001.DataTextField = "Nombre";
        ddown001.DataValueField = "CodCategoria";
        dv1.Sort = "Nombre";
        ddown001.DataBind();

        DataView dv2 = new DataView(ncoll.GetPersonasRelacionadas(SSnino.ICodIE.ToString()));
        ddown002.DataSource = dv2;
        ddown002.DataTextField = "Agresor";
        ddown002.DataValueField = "CodPersonaRelacionada";
        dv2.Sort = "Agresor";
        ddown002.DataBind();


        DataView dv3 = new DataView(tcoll.GetTrabajadoresProyecto(SSnino.CodProyecto.ToString()));
        ddown003.DataSource = dv3;
        ddown003.DataTextField = "NombreCompleto";
        ddown003.DataValueField = "ICodTrabajador";
        dv3.Sort = "NombreCompleto";
        ddown003.DataBind();





    }
    protected void btn001_Click(object sender, EventArgs e)
    {
        ninocoll ncoll = new ninocoll();
        diagnosticoscoll dcoll = new diagnosticoscoll();



        if (validate())
        {
            int inden = ncoll.Insert_DiagnosticoGeneral(1, SSnino.CodNino, SSnino.ICodIE, DateTime.Now);
            dcoll.Insert_DiagnosticosPeoresFormaTrabajo(inden, Convert.ToInt32(ddown001.SelectedValue), Convert.ToDateTime(cal001.Text), PresentaAgrecion(), 0, ViveConAgresor(), Convert.ToString(txt001_wt.Text), Convert.ToInt32(ddown003.SelectedValue), SSnino.CodInst, Convert.ToInt32(ddown003.SelectedValue), DateTime.Now, Convert.ToInt32(Session["IdUsuario"]), Convert.ToInt32(ddown_Comuna.SelectedValue), Convert.ToDateTime(cal002h.Text), Convert.ToInt32(ddown_relacion));
            window.close(this.Page);
        }
    }

    private Boolean PresentaAgrecion()
    {
        if (rdo001.Checked)
        {
            return true;
        }
        else if (rdo002.Checked)
        {
            return false;
        }
        else
        {
            return false;
        }

    }
    private Boolean ViveConAgresor()
    {
      
        if (chk001.Checked == true)
        {
            return true;
        }
        else if (chk001.Checked == false)
        {
            return false;
        }
        else
        {
            return false;
        }
    }



    private bool validate()
    {

        bool v = true;

        if (cal001.Text == null)
        {

            cal001.BackColor = System.Drawing.Color.Pink;

            v = false;

        }

        //if ((!rdo001.Checked || !rdo002.Checked))
        //{

        //    rdo001.BackColor = System.Drawing.Color.Pink;

        //    rdo002.BackColor = System.Drawing.Color.Pink;

        //    v = false;

        //}



        if (ddown001.SelectedValue == "0")
        {

            ddown001.BackColor = System.Drawing.Color.Pink;

            v = false;

        }

        if (ddown002.SelectedValue == "0")
        {

            ddown002.BackColor = System.Drawing.Color.Pink;

            v = false;

        }

        if (ddown003.SelectedValue == "0")
        {
            ddown003.BackColor = System.Drawing.Color.Pink;
        }

        return v;

    }



    //public nino SSnino
    //{
    //    get
    //    {
    //        if (Session["neo_SSnino"] == null)
    //        { Session["neo_SSnino"] = new nino(); }
    //        return (nino)Session["neo_SSnino"];
    //    }
    //    set { Session["neo_SSnino"] = value; }
    //}
    //protected void Page_Load(object sender, EventArgs e)
    //{

    //}
    //public void getdata()
    //{
    //    parcoll par = new parcoll();
    //    trabajadorescoll tcoll = new trabajadorescoll();
    //    ninocoll ncoll = new ninocoll();

    //    DataView dv1 = new DataView(par.GetparCategoriasPFMI());
    //    ddown001.DataSource = dv1;
    //    ddown001.DataTextField = "Nombre";
    //    ddown001.DataValueField = "CodCategoria";
    //    dv1.Sort = "Nombre";
    //    ddown001.DataBind();

    //    DataView dv2 = new DataView(ncoll.GetPersonasRelacionadas(SSnino.CodNino.ToString()));
    //    ddown002.DataSource = dv2;
    //    ddown002.DataTextField = "NombreCompleto";
    //    ddown002.DataValueField = "CodPersonaRelacionada";
    //    dv2.Sort = "NombreCompleto";
    //    ddown002.DataBind();


    //    DataView dv3 = new DataView(tcoll.GetTrabajadoresProyecto(SSnino.CodProyecto.ToString()));
    //    ddown003.DataSource = dv3;
    //    ddown003.DataTextField = "NombreCompleto";
    //    ddown003.DataValueField = "ICodTrabajador";
    //    dv3.Sort = "NombreCompleto";
    //    ddown003.DataBind();





    //}
}
