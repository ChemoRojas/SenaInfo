/*
 * 
 * GMP
 * 08/05/2015
 * Revisión windows.open, validación de fecha, no hay descargas excel
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

using System.Collections.Generic;
using System.Data.Common;

public partial class mod_ninos_bsc_PII : System.Web.UI.Page
{
    #region Sesiones
   
    public DataTable DtBusqueda
    {
        get { return (DataTable)Session["DtBusqueda"]; }
        set { Session["DtBusqueda"] = value; }
    }
    public DataSet dv
    {
        get { return (DataSet)Session["dv"]; }
        set { Session["dv"] = value; }
    }
    public string bscq
    {
        get { return (string)Session["bscq"]; }
        set { Session["bscq"] = value; }
    }
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["param001"] != null)
            {
                lbl001.Text = Request.QueryString["param001"];

            }
            if (Request.QueryString["param002"] != null)
            {
                lbl002.Text = Request.QueryString["param002"];

            }
            if (Request.QueryString["param003"] != null)
            {
                lbl003.Text = Request.QueryString["param003"];

            }
            if (Request.QueryString["param004"] != null)
            {
                lbl004.Text = Request.QueryString["param004"];

            }
           
        }
    }
    private void getGrupo()
    {
        pintervencion pcoll = new pintervencion();
        DataView dv1 = new DataView(pcoll.GetGrupoxCodProyecto(Convert.ToInt32(lbl003.Text)));
        ddown001.DataSource = dv1;
        ddown001.DataTextField = "Descripcion";
        ddown001.DataValueField = "CodGrupo";
        dv1.Sort = "Descripcion";
        ddown001.DataBind();
    }
    private void getTrabajadores()
    {
        pintervencion pcoll = new pintervencion();
        DataView dv1 = new DataView(pcoll.GetTrabajadoresxCodProyecto(Convert.ToInt32(lbl003.Text)));
        ddown002.DataSource = dv1;
        ddown002.DataTextField = "Nombres";
        ddown002.DataValueField = "ICodTrabajador";
        dv1.Sort = "Nombres";
        ddown002.DataBind();
    }

    //protected void imb001_Click(object sender, EventArgs e)
    //{
    //    // Function_Genera_String_Consulta(SParametrosConsultas);
    //    int ICodTrabajador; int CodGrupo; int CodPlanIntervencion; int CodNino;

    //    if (txt001.Text == "") CodPlanIntervencion = 0; else CodPlanIntervencion = Convert.ToInt32(txt001.Text);
    //    if (txt002.Text == "") CodNino = 0; else CodNino = Convert.ToInt32(txt002.Text);

    //    if (ddown002.SelectedValue == "") ICodTrabajador = 0; else ICodTrabajador = Convert.ToInt32(ddown002.SelectedValue);
    //    if (ddown001.SelectedValue == "") CodGrupo = 0; else CodGrupo = Convert.ToInt32(ddown001.SelectedValue);

    //    pintervencion bsc_int = new pintervencion();
    //    DataTable dt = bsc_int.Get_PII_Ninos(Convert.ToInt32(lbl003.Text), CodPlanIntervencion, CodNino, txt007.Text, ICodTrabajador, txt004.Text, txt005.Text, txt006.Text, CodGrupo);

    //    if (dt.Rows.Count > 0 && dt.Rows.Count < 300)
    //    {
    //        lbl0013.Visible = true;
    //        lbl0014.Visible = true;
    //        lbl0015.Visible = true;
    //        lbl0014.Text = "Coincidencias";
    //        lbl0013.Text = Convert.ToString(dt.Rows.Count);

    //        DtBusqueda = dt;

    //    }
    //    else if (dt.Rows.Count == 0)
    //    {
    //        lbl0013.Visible = true;
    //        lbl0014.Visible = true;
    //        lbl0015.Visible = false;
    //        lbl0014.Text = "Coincidencias";
    //        lbl0013.Text = Convert.ToString(dt.Rows.Count);
    //    }
    //    else if (dt.Rows.Count > 300)
    //    {
    //        lbl0013.Visible = false;
    //        lbl0014.Visible = true;
    //        lbl0015.Visible = false;
    //        lbl0014.Text = "Búsqueda demasiado ambigua, Ingrese parámetros.";
    //    }
    //}
    private void Function_Genera_String_Consulta(string sParametrosConsulta)
    {
        List<DbParameter> listDbParameter = new List<DbParameter>();
               sParametrosConsulta = "Select distinct top 201  T1.CodPlanIntervencion, T1.CodProyecto,"+
                                    "T1.CodNino,T2.Apellido_Paterno, T2.Apellido_Materno, T2.Nombres,T1.FechaInicioPII, " +
                                    "T1.FechaIngreso, T5.Nombres as NombreTrabajador, T5.Paterno, T5.Materno, "+
                                    "T6.Descripcion as NombreGrupo, T1.CodGrupo From PlanIntervencion T1 "+
                                    "Inner Join NINOS T2 On T1.CodNino = T2.CodNino "+
                                    "Inner Join EstadosPlanIntervencion T3 On T1.CodPlanIntervencion = T3.CodPlanIntervencion "+
                                    "Inner Join PlanIntervencionGrupo T6 on T1.CodGrupo = T6.CodGrupo "+
                                    "Inner Join Trabajadores T5 ON T1.Icodtrabajador = T5.IcodTrabajador "+ 
                                    "Inner Join Ingresos_Egresos T7 ON T2.CodNino = T7.CodNino "+
                                    "Where  T1.FechaTerminoRealPII='01/01/1900' and T1.CodGradoCumplimiento=-1 and T1.HabilitadoParaEgreso=-1 and T1.IntervencionCompleta=-1 "+
                                    "and  T7.FechaEgreso is null and T7.EstadoIE=0 AND T1.CodProyecto =@pCodProyecto ";

               listDbParameter.Add(Conexiones.CrearParametro("@pCodProyecto", SqlDbType.Int, 4, Convert.ToInt32(lbl003.Text)));

               if (ddown001.SelectedValue != "0" && ddown001.SelectedValue.Trim() != "")
                {
                    if (ddown001.SelectedValue != "0" && ddown001.SelectedValue != "")
                    {
                        sParametrosConsulta = sParametrosConsulta + "And T1.CodGrupo =@pCodGrupo And";

                        listDbParameter.Add(Conexiones.CrearParametro("@pCodGrupo", SqlDbType.Int, 4, Convert.ToInt32(ddown001.SelectedValue)));
                    }
                    if (sParametrosConsulta.Substring(sParametrosConsulta.Length - 3, 3) == "And")
                    {
                        sParametrosConsulta = sParametrosConsulta.Substring(0, sParametrosConsulta.Length - 3);
                    }
                }
                else
                {

                    if (txt001.Text != "" || txt002.Text != ""  || txt004.Text != "" || txt005.Text != ""
                         || txt006.Text != "" || txt007.Text != "" || (ddown002.SelectedValue != "0" && ddown002.SelectedValue != ""))
                    {
                        sParametrosConsulta = sParametrosConsulta + "And ";
                    }

                    if (txt001.Text != "")
                    {
                        sParametrosConsulta = sParametrosConsulta + " T1.CodPlanIntervencion =@pCodPlanIntervencion And";

                        listDbParameter.Add(Conexiones.CrearParametro("@pCodPlanIntervencion", SqlDbType.Int, 4, Convert.ToInt32(txt001.Text)));
                    }
                    if (txt002.Text != "")
                    {
                        sParametrosConsulta = sParametrosConsulta + " T1.CodNino =@pCodNino And";

                        listDbParameter.Add(Conexiones.CrearParametro("@pCodNino", SqlDbType.Int, 4, Convert.ToInt32(txt002.Text)));
                    }
                   

                    if (ddown002.SelectedValue != "0" && ddown002.SelectedValue.Trim() != "")
                    {
                        sParametrosConsulta = sParametrosConsulta + " T1.ICodTrabajador =@pICodTrabajador And";

                        listDbParameter.Add(Conexiones.CrearParametro("@pICodTrabajador", SqlDbType.Int, 4, Convert.ToInt32(ddown002.SelectedValue)));
                    }
                    if (txt004.Text != "")
                    {
                        sParametrosConsulta = sParametrosConsulta + " T2.Apellido_Paterno like @pApellido_Paterno And";

                        listDbParameter.Add(Conexiones.CrearParametro("@pApellido_Paterno", SqlDbType.VarChar, 50, "%" + txt004.Text + "%"));
                    }
                    if (txt005.Text != "")
                    {
                        sParametrosConsulta = sParametrosConsulta + " T2.Apellido_Materno like @pApellido_Materno And";

                        listDbParameter.Add(Conexiones.CrearParametro("@pApellido_Materno", SqlDbType.VarChar, 50, "%" + txt005.Text + "%"));
                    }
                    if (txt006.Text != "")
                    {
                        sParametrosConsulta = sParametrosConsulta + " T2.Nombres like @pNombres And";

                        listDbParameter.Add(Conexiones.CrearParametro("@pNombres", SqlDbType.VarChar, 100, "%" + txt006.Text + "%"));
                    }
                    if (txt007.Text != "")
                    {
                        sParametrosConsulta = sParametrosConsulta + " T2.Rut like @pRut And";

                        listDbParameter.Add(Conexiones.CrearParametro("@pRut", SqlDbType.VarChar, 11, "%" + txt007.Text + "%"));
                    }

                    
                    if (sParametrosConsulta.Substring(sParametrosConsulta.Length - 3, 3) == "And")
                    {
                        sParametrosConsulta = sParametrosConsulta.Substring(0, sParametrosConsulta.Length - 3);
                    }
                }

                pintervencion bsc_int = new pintervencion();
                DataTable dt = bsc_int.Get_Resultado_Busqueda(sParametrosConsulta, listDbParameter);

                if (dt.Rows.Count > 0 && dt.Rows.Count < 300)
                {
                    lbl0013.Visible = true;
                    lbl0014.Visible = true;
                    lbl0015.Visible = true;
                    lbl0014.Text = "Coincidencias";
                    lbl0013.Text = Convert.ToString(dt.Rows.Count);

                    DtBusqueda = dt;

                }
                else if (dt.Rows.Count == 0)
                {
                    lbl0013.Visible = true;
                    lbl0014.Visible = true;
                    lbl0015.Visible = false;
                    lbl0014.Text = "Coincidencias";
                    lbl0013.Text = Convert.ToString(dt.Rows.Count);
                }
                else if (dt.Rows.Count > 300)
                {
                    lbl0013.Visible = false;
                    lbl0014.Visible = true;
                    lbl0015.Visible = false;
                    lbl0014.Text = "Búsqueda demasiado ambigua, Ingrese parámetros.";
                }
    }

    protected void lbl0015_Click(object sender, EventArgs e)
    {
        lbl0013.Visible = false;
        lbl0014.Visible = false;
        lbl0015.Visible = false;
        imb001.Visible = false;
        Response.Write("<script language='JavaScript'>");
        Response.Write("window.resizeTo(800,600)");
        Response.Write("</script>");
        CargaGrilla();
    }
    private void CargaGrilla()
    {
       
            DataTable dt = DtBusqueda;
            DataView dv = new DataView(dt);
            dv.Sort = "";
            grd001.DataSource = dv;
            grd001.DataBind();
        
            pnl001.Visible = false;
            
            for (int i = 0; i < grd001.Rows.Count; i++)
            {
                if (grd001.Rows[i].Cells[14].Text == "0")
                {
                    //grd001.Rows[i].Cells[17].Visible = true;
                    grd001.Rows[i].Cells[16].Enabled=false  ;
                    //grd001.Rows[i].Cells[16].Visible = false;
                   
                }
                else
                {
                    //grd001.Rows[i].Cells[17].Visible = false;
                    //grd001.Rows[i].Cells[16].Visible = true;
                }
            }
            grd001.Visible = true;
            
        
     
    }

    //protected void grd001_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
       
    //    if (e.CommandName == "VerNino")
    //    {
    //        String cod = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
    //        String cod2 = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[14].Text;

    //        if (((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[14].Text != "0")
    //        {
    //            bscq = "EGRUPO";
    //        }
    //        else
    //        {
    //            bscq = "NGRUPO";
    //        }

    //        //string url = "pi_gestion.aspx?sw=1&planinterv=" + cod;
    //        //ClientScript.RegisterStartupScript(this.GetType(), "", "AbrirURLFancybox('" + url + "')", true);


    //    }
    //    if (e.CommandName == "VerGrupo")
    //        {
    //            //String cod = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
    //            String cod2 = ((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[14].Text;
    //            bscq = "NGRUPO";
                
    //            string url = "pi_gestion.aspx?sw=2&grupo=" + Convert.ToInt32(cod2);
    //            ClientScript.RegisterStartupScript(this.GetType(), "", "AbrirURLFancybox('" + url + "')", true);
    //        }
        
        
    //}
   
    protected void grd001_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd001.PageIndex = e.NewPageIndex;
        CargaGrilla();
    }
    
    protected void lnk001_Click(object sender, EventArgs e)
    {
        getGrupo();
        lnk001.Visible = false;
        ddown001.Visible = true;
        
    }
    protected void lnk002_Click(object sender, EventArgs e)
    {
        getTrabajadores();
        lnk002.Visible = false;
        ddown002.Visible = true;
    }
    protected void imb001_Click(object sender, EventArgs e)
    {
        //System.Threading.Thread.Sleep(3000);
        int ICodTrabajador; int CodGrupo; int CodPlanIntervencion; int CodNino;

            if (txt001.Text == "") CodPlanIntervencion = 0; else CodPlanIntervencion = Convert.ToInt32(txt001.Text);
        if (txt002.Text == "") CodNino = 0; else CodNino = Convert.ToInt32(txt002.Text);

        if (ddown002.SelectedValue == "") ICodTrabajador = 0; else ICodTrabajador = Convert.ToInt32(ddown002.SelectedValue);
        if (ddown001.SelectedValue == "") CodGrupo = 0; else CodGrupo = Convert.ToInt32(ddown001.SelectedValue);

        pintervencion bsc_int = new pintervencion();
        DataTable dt = bsc_int.Get_PII_Ninos(Convert.ToInt32(lbl003.Text), CodPlanIntervencion, CodNino, txt007.Text, ICodTrabajador, txt004.Text, txt005.Text, txt006.Text, CodGrupo);

        if (dt.Rows.Count > 0 && dt.Rows.Count < 300)
        {
            lbl0013.Visible = true;
            lbl0014.Visible = true;
            lbl0015.Visible = true;
            lbl0014.Text = "Coincidencias";
            lbl0013.Text = Convert.ToString(dt.Rows.Count);

            DtBusqueda = dt;

        }
        else if (dt.Rows.Count == 0)
        {
            lbl0013.Visible = true;
            lbl0014.Visible = true;
            lbl0015.Visible = false;
            lbl0014.Text = "Coincidencias";
            lbl0013.Text = Convert.ToString(dt.Rows.Count);
        }
        else if (dt.Rows.Count > 300)
        {
            lbl0013.Visible = false;
            lbl0014.Visible = true;
            lbl0015.Visible = false;
            lbl0014.Text = "Búsqueda demasiado ambigua, Ingrese parámetros.";
        }
    }
    protected void imb002_Click(object sender, EventArgs e)
    {
        for (int j = 0; j < this.Controls.Count; j++)
        {
            for (int i = 0; i < this.Controls[j].Controls.Count; i++)
            {
                try
                {
                    ((TextBox)this.Controls[j].Controls[i]).Text = "";
                }
                catch { }
                try
                {
                    ((DropDownList)this.Controls[j].Controls[i]).SelectedIndex = 0;
                }
                catch { }
            }
        }
        pnl001.Visible = true;
        grd001.Visible = false;
        imb001.Visible = true;
        Response.Write("<script language='JavaScript'>");
        Response.Write("window.resizeTo(650,350)");
        Response.Write("</script>");
    }
}
