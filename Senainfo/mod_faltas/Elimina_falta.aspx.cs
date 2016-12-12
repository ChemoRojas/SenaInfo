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
using regfaltas2TableAdapters;

public partial class mod_faltas_Elimina_falta : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lbl_error.Visible = false;
            if (Request.QueryString["icodfalta"] != null)
            {
                string IdFalta = Convert.ToString(Request.QueryString["icodfalta"]);
                FaltasTableAdapter Buscar1 = new FaltasTableAdapter();
                DataTable dtbusqueda1 = Buscar1.Get_PorIdFalta(Convert.ToInt32(IdFalta));

                lbl_IdFalta.Text = Convert.ToString(dtbusqueda1.Rows[0]["ICodFalta"]);

                if (Request.QueryString["codnino"] != null)
                {
                    NinosTableAdapter traigodatosnino = new NinosTableAdapter();
                    DataTable dtnino = traigodatosnino.Get_nino_xcod(Convert.ToInt32(Request.QueryString["codnino"]));

                    if (dtnino.Rows.Count > 0)
                    {
                        try
                        {
                            lbl_nino.Text = dtnino.Rows[0]["Nombres"].ToString() + " " + dtnino.Rows[0]["Apellido_Paterno"].ToString() + " " + dtnino.Rows[0]["Apellido_Materno"].ToString();
                        }
                        catch
                        {
                            lbl_nino.Text = "Sin Información";
                        }
                    }
                }
            }
        }
    }
    //protected void img_btn_si_Click(object sender, ImageClickEventArgs e)
    //{
    //    if (Request.QueryString["icodfalta"] != null && Request.QueryString["icodie"] != null)
    //    {

    //        string IdFalta = Convert.ToString(Request.QueryString["icodfalta"]);
    //        Session["idfalta"] = IdFalta;

    //        string idcodie = Convert.ToString(Request.QueryString["icodie"]);
    //        Session["icodie"] = idcodie;
    //        try
    //        {
    //            FaltasTableAdapter Buscar = new FaltasTableAdapter();
    //            DataTable dtbusqueda = Buscar.Get_PorIdFalta(Convert.ToInt32(IdFalta));

    //            if (dtbusqueda.Rows.Count > 0)
    //            {
    //                int ControlIndicador = Convert.ToInt32(dtbusqueda.Rows[0]["ControlIndicador"]);
    //                if (ControlIndicador != 1)
    //                {
    //                    FaltasTableAdapter BorrarFalta = new FaltasTableAdapter();
    //                    BorrarFalta.Borrar_Falta(Convert.ToInt32(IdFalta));
    //                    Response.Write("<script language='JavaScript'>var url = 'registro_faltas.aspx?icodie=" + idcodie + "';");
    //                    Response.Write("window.opener.location = url;");
    //                    Response.Write("self.close();");
    //                    Response.Write("</script>");
    //                }
    //                else
    //                {
    //                    lbl_error.Visible = true;
    //                }
    //            }
                
    //        }
    //        catch
    //        { 
            
    //        }            
    //    }
    //}
    //protected void img_btn_no_Click(object sender, ImageClickEventArgs e)
    //{
    //    string idcodie = Convert.ToString(Request.QueryString["icodie"]);
    //    Session["icodie"] = idcodie;

    //    Response.Write("<script language='JavaScript'>var url = 'registro_faltas.aspx?icodie=" + idcodie + "';");
    //    Response.Write("window.opener.location = url;");
    //    Response.Write("self.close();");
    //    Response.Write("</script>");
    //}
    protected void img_btn_si_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["icodfalta"] != null && Request.QueryString["icodie"] != null)
        {

            string IdFalta = Convert.ToString(Request.QueryString["icodfalta"]);
            Session["idfalta"] = IdFalta;

            string idcodie = Convert.ToString(Request.QueryString["icodie"]);
            Session["icodie"] = idcodie;
            try
            {
                FaltasTableAdapter Buscar = new FaltasTableAdapter();
                DataTable dtbusqueda = Buscar.Get_PorIdFalta(Convert.ToInt32(IdFalta));

                if (dtbusqueda.Rows.Count > 0)
                {
                    int ControlIndicador = Convert.ToInt32(dtbusqueda.Rows[0]["ControlIndicador"]);
                    if (ControlIndicador != 1)
                    {
                        FaltasTableAdapter BorrarFalta = new FaltasTableAdapter();
                        BorrarFalta.Borrar_Falta(Convert.ToInt32(IdFalta));

                        window.alert(this, "Infracción Eliminada Satisfactoriamente.");

                        string url = "registro_faltas.aspx?icodie=" + idcodie;
                        ClientScript.RegisterStartupScript(this.GetType(), "", "AbrirURLModalPopUp('" + url + "');", true);

                        //Response.Write("<script language='JavaScript'>var url = 'registro_faltas.aspx?icodie=" + idcodie + "';");
                        //Response.Write("window.opener.location = url;");
                        //Response.Write("self.close();");
                        //Response.Write("</script>");
                    }
                    else
                    {
                        lbl_error.Visible = true;
                    }
                }

            }
            catch
            {

            }
        }

    }
}
