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
using System.Data;

public partial class mod_faltas_edit_falta : System.Web.UI.Page
{
    public int IcodFalta
    {
        get { return (int)Session["IcodFalta"]; }
        set { Session["IcodFalta"] = value; }
    }
    public int Icodie
    {
        get { return (int)Session["Icodie"]; }
        set { Session["Icodie"] = value; }
    }
    public string existe
    {
        get { return (string)Session["existe"]; }
        set { Session["existe"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Cargo_Faltas(1);
            Cargo_sanciones(1);
            cal001.Text = DateTime.Now.ToShortDateString();
            cal002.Text = DateTime.Now.ToShortDateString();
            if (Request.QueryString["Existe"] != null)
            {
                existe = Convert.ToString(Request.QueryString["Existe"]);
            }
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
            if (Request.QueryString["icodfalta"] != null && Request.QueryString["icodie"] != null)
            {
                IcodFalta = Convert.ToInt32(Request.QueryString["icodfalta"]);
                Icodie = Convert.ToInt32(Request.QueryString["icodie"]);
                FaltasTableAdapter TraigoFalta = new FaltasTableAdapter();
                DataTable DTfalta = TraigoFalta.Get_PorIdFalta(IcodFalta);

                if (DTfalta.Rows.Count > 0)
                { 
                    cal001.Text = DTfalta.Rows[0]["FechaEventoFalta"].ToString().Substring(0,10);
                    txt_descripcionevento.Text = DTfalta.Rows[0]["EventoDescripcionFalta"].ToString();
                    rdb_denuncia.SelectedValue = Convert.ToString(DTfalta.Rows[0]["PresentaDenunciaFalta_Afirmacion"]);
                    rdb_falta.SelectedValue = Convert.ToString(DTfalta.Rows[0]["AmeritaFalta_Afirmacion"]);
                    txt_numacta.Text = DTfalta.Rows[0]["NumeroActaCD"].ToString();
                    cal002.Text = DTfalta.Rows[0]["FechaSesionCD"].ToString().Substring(0, 10);
                    rdb_sansion.SelectedValue = Convert.ToString(DTfalta.Rows[0]["AplicaSancionCD_Afirmacion"]);
                    ddl_tipofalta.SelectedValue = Convert.ToString(DTfalta.Rows[0]["CodTipoFaltaCF"]);

                    Cargo_Faltas(Convert.ToInt32(DTfalta.Rows[0]["CodTipoFaltaCF"]));
                    Cargo_sanciones(Convert.ToInt32(DTfalta.Rows[0]["CodTipoFaltaCF"]));

                    ddl_f1.SelectedValue = Convert.ToString(DTfalta.Rows[0]["CodFalta1CF"]);
                    ddl_falta2.SelectedValue = Convert.ToString(DTfalta.Rows[0]["CodFalta2CF"]);
                    ddl_falta3.SelectedValue = Convert.ToString(DTfalta.Rows[0]["CodFalta3CF"]);
                    ddl_falta4.SelectedValue = Convert.ToString(DTfalta.Rows[0]["CodFalta4CF"]);
                    ddl_sansion1.SelectedValue = Convert.ToString(DTfalta.Rows[0]["CodSancionFalta1CF"]);
                    ddl_sansion2.SelectedValue = Convert.ToString(DTfalta.Rows[0]["CodSancionFalta2CF"]);
                    ddl_sansion3.SelectedValue = Convert.ToString(DTfalta.Rows[0]["CodSancionFalta3CF"]);
                    ddl_sansion4.SelectedValue = Convert.ToString(DTfalta.Rows[0]["CodSancionFalta4CF"]);
                    ddl_numdias.SelectedValue = Convert.ToString(DTfalta.Rows[0]["CodDiasDS"]);
                    ddl_numsemanas.SelectedValue = Convert.ToString(DTfalta.Rows[0]["CodSemanaDS"]);
                    ddl_nummeses.SelectedValue = Convert.ToString(DTfalta.Rows[0]["CodMesDS"]);
                    rdb_ratificacion.SelectedValue = Convert.ToString(DTfalta.Rows[0]["RatificaDirectorDS_Afirmacion"]);
                    ddl_notjoven.SelectedValue = Convert.ToString(DTfalta.Rows[0]["CodNotificacionJovenFRS"]);
                    rdb_regexpediente.SelectedValue = Convert.ToString(DTfalta.Rows[0]["RegistroExpedienteFRS_Afirmacion"]);
                    rdb_nottribunal.SelectedValue = Convert.ToString(DTfalta.Rows[0]["NotificacionTribunalFRS_Afirmacion"]);
                    ddl_medioNotTrib.SelectedValue = Convert.ToString(DTfalta.Rows[0]["CodMedioNotificacionTribunalFRS"]);
                    rdb_reportejoven.SelectedValue = Convert.ToString(DTfalta.Rows[0]["ConsideraReporteJovenEDP_Afirmacion"]);
                    rdb_gestionhecho.SelectedValue = Convert.ToString(DTfalta.Rows[0]["GestionesComprobacionEDP_Afirmacion"]);
                    rdb_cirresponsabilidad.SelectedValue = Convert.ToString(DTfalta.Rows[0]["RevisionCircunstanciasEDP_Afirmacion"]);
                    ddl_quienapela.SelectedValue = Convert.ToString(DTfalta.Rows[0]["CodQuienApelaRRS"]);
                    ddl_acogeapelacion.SelectedValue = Convert.ToString(DTfalta.Rows[0]["CodSeAcogeApelacionRRS"]);
                    rdb_aplica.SelectedValue = Convert.ToString(DTfalta.Rows[0]["SeAplicaSeparacionPS_Afirmacion"]);
                    ddl_DuracionSep.SelectedValue = Convert.ToString(DTfalta.Rows[0]["CodDuracionSeparacionPS"]);
                    ddl_espacioSep.SelectedValue = Convert.ToString(DTfalta.Rows[0]["CodEspacioSeparacionPS"]);
                    ddl_aplicacionInterv.SelectedValue = Convert.ToString(DTfalta.Rows[0]["CodAplicacionIntervencionISRN"]);
                    txt_descrpIntervencion.Text = DTfalta.Rows[0]["DescripcionIntervencionISRN"].ToString();
                    ddl_CodRefNegativo.SelectedValue = Convert.ToString(DTfalta.Rows[0]["CodRefuerzoNegativoAdicionalISRN"]);
                    txt_refuerzonegativo.Text= DTfalta.Rows[0]["DescripcionRefuerzoNegativoISRN"].ToString();
                    rdb_constituye.SelectedValue = Convert.ToString(DTfalta.Rows[0]["ConstituyeCC_Afirmacion"]);
                    ddl_ConflictoCritico.SelectedValue = Convert.ToString(DTfalta.Rows[0]["CodConflictoCriticoCC"]);
                    Session["ControlIndicador"] = Convert.ToString(DTfalta.Rows[0]["ControlIndicador"]);
                }

            }
            if (Request.QueryString["icodfalta"] == null && Request.QueryString["icodie"] != null)
            {
                Icodie = Convert.ToInt32(Request.QueryString["icodie"]);
            }
            if (Request.QueryString["icodie"] != null)
            {
                Icodie = Convert.ToInt32(Request.QueryString["icodie"]);
            }            
        }
    }

    public void Cargo_Faltas(int TipoFalta)
    {
        parFaltasTableAdapter TraigoFaltas = new parFaltasTableAdapter();
        DataTable dtFaltas = TraigoFaltas.Get_faltas_by_tfalta(TipoFalta);

        if (dtFaltas.Rows.Count > 0)
        {
            try
            {
                ddl_f1.DataSource = dtFaltas;
                ddl_f1.DataValueField = "CodFalta";
                ddl_f1.DataTextField = "Articulo";
                ddl_f1.DataBind();

                ddl_falta2.DataSource = dtFaltas;
                ddl_falta2.DataValueField = "CodFalta";
                ddl_falta2.DataTextField = "Articulo";
                ddl_falta2.DataBind();

                ddl_falta3.DataSource = dtFaltas;
                ddl_falta3.DataValueField = "CodFalta";
                ddl_falta3.DataTextField = "Articulo";
                ddl_falta3.DataBind();

                ddl_falta4.DataSource = dtFaltas;
                ddl_falta4.DataValueField = "CodFalta";
                ddl_falta4.DataTextField = "Articulo";
                ddl_falta4.DataBind();
            }
            catch
            { 
            
            }
        }
    }

    public void Cargo_sanciones(int codfalta)
    {
        parSancionFaltaTableAdapter traigo_sanciones = new parSancionFaltaTableAdapter();
        DataTable dtsancion = traigo_sanciones.Get_sancion_xfalta(codfalta);
        if (dtsancion.Rows.Count > 0)
        {
            try
            {
                ddl_sansion1.DataSource = dtsancion;
                ddl_sansion1.DataValueField = "CodSancionFalta";
                ddl_sansion1.DataTextField = "Articulo";
                ddl_sansion1.DataBind();

                ddl_sansion2.DataSource = dtsancion;
                ddl_sansion2.DataValueField = "CodSancionFalta";
                ddl_sansion2.DataTextField = "Articulo";
                ddl_sansion2.DataBind();

                ddl_sansion3.DataSource = dtsancion;
                ddl_sansion3.DataValueField = "CodSancionFalta";
                ddl_sansion3.DataTextField = "Articulo";
                ddl_sansion3.DataBind();

                ddl_sansion4.DataSource = dtsancion;
                ddl_sansion4.DataValueField = "CodSancionFalta";
                ddl_sansion4.DataTextField = "Articulo";
                ddl_sansion4.DataBind();
            }
            catch
            { 
            
            }
        }
    }

    protected void imgbtn_limpiar_Click(object sender, EventArgs e)
    {
        limpiar();
    }
    private void limpiar()
    {
        cal001.Text = "Seleccione Fecha";
         rdb_denuncia.SelectedValue = "0";
         txt_descripcionevento.Text = "";
         rdb_falta.SelectedValue = "0";
         txt_numacta.Text = "";
         cal002.Text = "Seleccione Fecha";
         rdb_sansion.SelectedValue = "0";
         ddl_tipofalta.SelectedValue = "1";
         ddl_f1.SelectedValue = "0";
         ddl_falta2.SelectedValue = "0";
         ddl_falta3.SelectedValue = "0";
         ddl_falta4.SelectedValue = "0";
         ddl_sansion1.SelectedValue = "0";
         ddl_sansion2.SelectedValue = "0";
         ddl_sansion3.SelectedValue = "0";
         ddl_sansion4.SelectedValue = "0";
         ddl_numdias.SelectedValue = "0";
         ddl_numsemanas.SelectedValue = "0";
         ddl_nummeses.SelectedValue = "0";
         rdb_ratificacion.SelectedValue = "0";
         ddl_notjoven.SelectedValue = "1";
         rdb_regexpediente.SelectedValue = "0";
         rdb_nottribunal.SelectedValue = "0";
         ddl_medioNotTrib.SelectedValue = "0";
         rdb_reportejoven.SelectedValue = "0";
         rdb_gestionhecho.SelectedValue = "0";
         rdb_cirresponsabilidad.SelectedValue = "0";
         ddl_quienapela.SelectedValue = "0";
         ddl_acogeapelacion.SelectedValue = "0";
         rdb_aplica.SelectedValue = "0";
         ddl_DuracionSep.SelectedValue = "0";
         ddl_espacioSep.SelectedValue = "0";
         ddl_aplicacionInterv.SelectedValue = "1";
         txt_descrpIntervencion.Text ="";
         ddl_CodRefNegativo.SelectedValue = "0";
         txt_refuerzonegativo.Text ="";
         rdb_constituye.SelectedValue = "0";
         ddl_ConflictoCritico.SelectedValue = "0";
    }

    protected void imgbtn_guardar_Click(object sender, EventArgs e)
    {
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        int valido = 0; //si esta en cero, esta validado y entra, si es 1 es error

        //if (txt_descripcionevento.Text == "")
        //{
        //    txt_descripcionevento.CssClass = "ddl_error";
        //}
        //else
        //{
        //    txt_descripcionevento.CssClass = "";
        //}

        //if (txt_descrpIntervencion.Text == "")
        //{
        //    txt_descrpIntervencion.CssClass = "ddl_error";
        //}
        //else
        //{
        //    txt_descrpIntervencion.CssClass = "";
        //}
        //if (txt_refuerzonegativo.Text == "")
        //{
        //    txt_refuerzonegativo.CssClass = "ddl_error";
        //}
        //else
        //{
        //    txt_refuerzonegativo.CssClass = "";
        //}

        if (ddl_medioNotTrib.SelectedItem.ToString().ToUpper() == "SELECCIONAR")
        {
            //ddl_medioNotTrib.CssClass = "ddl_error";
            ddl_medioNotTrib.BackColor = colorCampoObligatorio;
            ddl_medioNotTrib.Focus();
        }
        else
        {
            //ddl_medioNotTrib.CssClass = "";    
            ddl_medioNotTrib.BackColor = System.Drawing.Color.Empty;
        }

        if (ddl_notjoven.SelectedItem.ToString().ToUpper() == "SELECCIONAR")
        {
            //ddl_notjoven.CssClass = "ddl_error";
            ddl_notjoven.BackColor = colorCampoObligatorio;
            ddl_notjoven.Focus();

        }
        else
        {
            //ddl_notjoven.CssClass = "";
            ddl_notjoven.BackColor = System.Drawing.Color.Empty;
        }

        if (ddl_f1.SelectedItem.ToString().ToUpper() == "SELECCIONAR")
        {
            //ddl_f1.CssClass = "ddl_error";
            ddl_f1.BackColor = colorCampoObligatorio;
            ddl_f1.Focus();
            lbl_error_falta.Visible = true;
        }
        else
        {
            //ddl_f1.CssClass = "";
            ddl_f1.BackColor = System.Drawing.Color.Empty;
            lbl_error_falta.Visible = false;
        }

        if (ddl_sansion1.SelectedItem.ToString().ToUpper() == "SELECCIONAR")
        {
            //ddl_sansion1.CssClass = "ddl_error";
            ddl_sansion1.BackColor = colorCampoObligatorio;
            ddl_sansion1.Focus();
            lbl_error_sancion.Visible = true;
        }
        else
        {
            //ddl_sansion1.CssClass = "";
            ddl_sansion1.BackColor = System.Drawing.Color.Empty;
            lbl_error_sancion.Visible = false;
        }

        if (ddl_aplicacionInterv.SelectedItem.ToString().ToUpper() == "SELECCIONAR")
        {
            //ddl_aplicacionInterv.CssClass = "ddl_error";
            ddl_aplicacionInterv.BackColor = colorCampoObligatorio;
            ddl_aplicacionInterv.Focus();
        }
        else
        {
            //ddl_aplicacionInterv.CssClass = "";
            ddl_aplicacionInterv.BackColor = System.Drawing.Color.Empty;
        }
        if (rdb_constituye.SelectedItem.ToString().ToUpper() == "SI")
        {
            if (ddl_ConflictoCritico.SelectedItem.ToString().ToUpper() == "SELECCIONAR")
            {
                //ddl_ConflictoCritico.CssClass = "ddl_error";
                ddl_ConflictoCritico.BackColor = colorCampoObligatorio;
                ddl_ConflictoCritico.Focus();
                valido = 1;
            }
            else
            {
                //ddl_ConflictoCritico.CssClass = "";
                ddl_ConflictoCritico.BackColor = System.Drawing.Color.Empty;
                valido = 0;
            }
        }
        else
        {
            valido = 0;
        }

        if (existe == "si" 
            && ddl_medioNotTrib.SelectedItem.ToString().ToUpper() != "SELECCIONAR"
            && ddl_f1.SelectedItem.ToString().ToUpper() != "SELECCIONAR"
            && ddl_sansion1.SelectedItem.ToString().ToUpper() != "SELECCIONAR"
            && ddl_aplicacionInterv.SelectedItem.ToString().ToUpper() != "SELECCIONAR"
            && valido == 0)
        {
            //actualizar            
            try
            {
                FaltasTableAdapter updateFaltas = new FaltasTableAdapter();
                updateFaltas.Actualiza_Faltas(
                    Icodie,
                    Convert.ToDateTime(cal001.Text),
                    txt_descripcionevento.Text,
                    Convert.ToInt32(rdb_denuncia.SelectedValue),
                    Convert.ToInt32(rdb_falta.SelectedValue),
                    Convert.ToInt32(txt_numacta.Text),
                    Convert.ToDateTime(cal002.Text),
                    Convert.ToInt32(rdb_sansion.SelectedValue),
                    Convert.ToInt32(ddl_tipofalta.SelectedValue),
                    Convert.ToInt32(ddl_f1.SelectedValue),
                    Convert.ToInt32(ddl_falta2.SelectedValue),
                    Convert.ToInt32(ddl_falta3.SelectedValue),
                    Convert.ToInt32(ddl_falta4.SelectedValue),
                    Convert.ToInt32(ddl_sansion1.SelectedValue),
                    Convert.ToInt32(ddl_sansion2.SelectedValue),
                    Convert.ToInt32(ddl_sansion3.SelectedValue),
                    Convert.ToInt32(ddl_sansion4.SelectedValue),
                    Convert.ToInt32(ddl_numdias.SelectedValue),
                    Convert.ToInt32(ddl_numsemanas.SelectedValue),
                    Convert.ToInt32(ddl_nummeses.SelectedValue),
                    Convert.ToInt32(rdb_ratificacion.SelectedValue),
                    Convert.ToInt32(ddl_notjoven.SelectedValue),
                    Convert.ToInt32(rdb_regexpediente.SelectedValue),
                    Convert.ToInt32(rdb_nottribunal.SelectedValue),
                    Convert.ToInt32(ddl_medioNotTrib.SelectedValue),
                    Convert.ToInt32(rdb_reportejoven.SelectedValue),
                    Convert.ToInt32(rdb_gestionhecho.SelectedValue),
                    Convert.ToInt32(rdb_cirresponsabilidad.SelectedValue),
                    Convert.ToInt32(ddl_quienapela.SelectedValue),
                    Convert.ToInt32(ddl_acogeapelacion.SelectedValue),
                    Convert.ToInt32(rdb_aplica.SelectedValue),
                    Convert.ToInt32(ddl_DuracionSep.SelectedValue),
                    Convert.ToInt32(ddl_espacioSep.SelectedValue),
                    Convert.ToInt32(ddl_aplicacionInterv.SelectedValue),
                    txt_descrpIntervencion.Text,
                    Convert.ToInt32(ddl_CodRefNegativo.SelectedValue),
                    txt_refuerzonegativo.Text,
                    Convert.ToInt32(rdb_constituye.SelectedValue),
                    Convert.ToInt32(ddl_ConflictoCritico.SelectedValue),
                    Convert.ToInt32(Session["IdUsuario"]),
                    DateTime.Now,
                    0,
                    IcodFalta);

                

                //Response.Write("<script language='JavaScript'>var url = 'registro_faltas.aspx?icodie=" + Convert.ToString(Icodie) + "';");
                //Response.Write("window.opener.location = url;");
                //Response.Write("self.close();");
                //Response.Write("</script>");


                window.alert(this, "Infracción Actualizada Satisfactoriamente.");
                //Response.Write("<script language='javascript'>alert('Infracción Actualizada Satisfactoriamente. ');</script>");
                string url = "../mod_faltas/registro_faltas.aspx?icodie=" + Icodie;
                ClientScript.RegisterStartupScript(this.GetType(), "", "AbrirURLModalPopUp('" + url + "');", true);

               
            }
            catch
            {

            }

        }
        else if (existe == "no"
            && ddl_medioNotTrib.SelectedItem.ToString().ToUpper() != "SELECCIONAR"
            && ddl_f1.SelectedItem.ToString().ToUpper() != "SELECCIONAR"
            && ddl_sansion1.SelectedItem.ToString().ToUpper() != "SELECCIONAR"
            && ddl_aplicacionInterv.SelectedItem.ToString().ToUpper() != "SELECCIONAR"
            && valido == 0
            )
        {
            try
            {
                FaltasTableAdapter ingresaNUEVO = new FaltasTableAdapter();
                ingresaNUEVO.Insertar_Falta(
                    Icodie,
                    Convert.ToDateTime(cal001.Text),
                    txt_descripcionevento.Text,
                    Convert.ToInt32(rdb_denuncia.SelectedValue),
                    Convert.ToInt32(rdb_falta.SelectedValue),
                    Convert.ToInt32(txt_numacta.Text),
                    Convert.ToDateTime(cal002.Text),
                    Convert.ToInt32(rdb_sansion.SelectedValue),
                    Convert.ToInt32(ddl_tipofalta.SelectedValue),
                    Convert.ToInt32(ddl_f1.SelectedValue),
                    Convert.ToInt32(ddl_falta2.SelectedValue),
                    Convert.ToInt32(ddl_falta3.SelectedValue),
                    Convert.ToInt32(ddl_falta4.SelectedValue),
                    Convert.ToInt32(ddl_sansion1.SelectedValue),
                    Convert.ToInt32(ddl_sansion2.SelectedValue),
                    Convert.ToInt32(ddl_sansion3.SelectedValue),
                    Convert.ToInt32(ddl_sansion4.SelectedValue),
                    Convert.ToInt32(ddl_numdias.SelectedValue),
                    Convert.ToInt32(ddl_numsemanas.SelectedValue),
                    Convert.ToInt32(ddl_nummeses.SelectedValue),
                    Convert.ToInt32(rdb_ratificacion.SelectedValue),
                    Convert.ToInt32(ddl_notjoven.SelectedValue),
                    Convert.ToInt32(rdb_regexpediente.SelectedValue),
                    Convert.ToInt32(rdb_nottribunal.SelectedValue),
                    Convert.ToInt32(ddl_medioNotTrib.SelectedValue),
                    Convert.ToInt32(rdb_reportejoven.SelectedValue),
                    Convert.ToInt32(rdb_gestionhecho.SelectedValue),
                    Convert.ToInt32(rdb_cirresponsabilidad.SelectedValue),
                    Convert.ToInt32(ddl_quienapela.SelectedValue),
                    Convert.ToInt32(ddl_acogeapelacion.SelectedValue),
                    Convert.ToInt32(rdb_aplica.SelectedValue),
                    Convert.ToInt32(ddl_DuracionSep.SelectedValue),
                    Convert.ToInt32(ddl_espacioSep.SelectedValue),
                    Convert.ToInt32(ddl_aplicacionInterv.SelectedValue),
                    txt_descrpIntervencion.Text,
                    Convert.ToInt32(ddl_CodRefNegativo.SelectedValue),
                    txt_refuerzonegativo.Text,
                    Convert.ToInt32(rdb_constituye.SelectedValue),
                    Convert.ToInt32(ddl_ConflictoCritico.SelectedValue),
                    Convert.ToInt32(Session["IdUsuario"]),
                    DateTime.Now,
                    0);

                //Response.Write("<script language='JavaScript'>var url = 'registro_faltas.aspx?icodie=" + Convert.ToString(Icodie) + "';");
                //Response.Write("window.opener.location = url;");
                //Response.Write("self.close();");
                //Response.Write("</script>");

                window.alert(this, "Infracción Ingresada Satisfactoriamente.");
                //Response.Write("<script language='javascript'>alert('Infracción Ingresada Satisfactoriamente. ');</script>");
                string url = "../mod_faltas/registro_faltas.aspx?icodie=" + Icodie;
                ClientScript.RegisterStartupScript(this.GetType(), "", "AbrirURLModalPopUp('" + url + "');", true);
            }
            catch
            {

            }
        }

    }
   
    protected void ddl_tipofalta_SelectedIndexChanged(object sender, EventArgs e)
    {
        Cargo_Faltas(Convert.ToInt32(ddl_tipofalta.SelectedValue));
        Cargo_sanciones(Convert.ToInt32(ddl_tipofalta.SelectedValue));
    }
    protected void rv_fecha_Init(object sender, EventArgs e)
    {
        ((RangeValidator)sender).MaximumValue = DateTime.Today.ToString("dd-MM-yyyy");
        ((RangeValidator)sender).MinimumValue = "01-01-1900";

    }
}

