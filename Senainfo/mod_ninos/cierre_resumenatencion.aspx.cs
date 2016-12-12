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
using System.Data.SqlClient;
using System.Drawing;

public partial class mod_institucion_cierre_resumenatencion : System.Web.UI.Page
{
    #region ViewState
    // JLBL: 06-2015
    //#region ViewState_CodProyecto
    //public int CodProyecto
    //{
    //    get
    //    {
    //        object o = ViewState["CodProyecto"];
    //        return (o == null) ? 0 : (int)o;
    //    }

    //    set
    //    {
    //        ViewState["CodProyecto"] = value;
    //    }
    //}
    //#endregion

    //#region ViewState_AnoMes
    //public int AnoMes
    //{
    //    get
    //    {
    //        object o = ViewState["AnoMes"];
    //        return (o == null) ? 0 : (int)o;
    //    }

    //    set
    //    {
    //        ViewState["AnoMes"] = value;
    //    }
    //}
    //#endregion

    //#region ViewState_IdUsr
    //public int IdUsr
    //{
    //    get
    //    {
    //        object o = ViewState["IdUsr"];
    //        return (o == null) ? 0 : (int)o;
    //    }

    //    set
    //    {
    //        ViewState["IdUsr"] = value;
    //    }
    //}
    //#endregion
    #endregion

    public ArrayList PageArrayList;

    protected void Page_Load(object sender, EventArgs e)
    {
      //mostrar_collapse(false);
        if (!IsPostBack)
        {
            getinstituciones();
            getproyectos();
            getanos();
            lbl_aviso4.Visible = false;
            try
            {
                if (Request.QueryString["sw"] == "4")
                {
                    buscador_institucion bsc = new buscador_institucion();
                    int codinst = bsc.GetCodInstxCodProy(Convert.ToInt32(Request.QueryString["codinst"]));
                    ddown001.SelectedValue = Convert.ToString(codinst);
                    getproyectos();
                    ddown002.SelectedValue = Request.QueryString["codinst"];
                    ddown_AnoCierre.Items.FindByValue(Request.QueryString["A"]).Selected = true;
                    ddown_MesCierre.Items.FindByValue(Request.QueryString["M"]).Selected = true;
                    getdata();
                }
            }
            catch { }
            validatescurity();

            ArrayList al = new ArrayList(3);
            al.Add(ddown002.SelectedValue);
            al.Add(Convert.ToInt32(Convert.ToString(ddown_AnoCierre.SelectedValue) + Convert.ToString(ddown_MesCierre.SelectedValue)));
            al.Add(Session["IdUsuario"]);
            Session["variables_impresion"] = al;
        }
    }

    #region VISIBILIDAD DE FUNCIONALIDADES SEGUN PERMISOS

    private void validatescurity()
    {
        //C06E3BDB-1478-4307-BDFA-64C8CB28E296 2.8_MODIFICAR
        if (!window.existetoken("C06E3BDB-1478-4307-BDFA-64C8CB28E296"))
        {
            Imb004.Visible = false; //9
        }

    }
    #endregion
    protected void Imb001_Click(object sender, EventArgs e)
    {
        if (ddown_MesCierre.SelectedIndex > 0)
        {
            Response.Redirect("cierre_movmensual.aspx?sw=4&codinst=" + ddown002.SelectedValue + "&M=" + ddown_MesCierre.SelectedValue + "&A=" + ddown_AnoCierre.SelectedValue);
        }
    }

    /* Boton Imprimir */
    protected void Imb002_Click(object sender, EventArgs e)
    {
        if (ddown002.Items.Count > 0 && Convert.ToInt32(ddown002.SelectedValue) > 0)
        {
            //string url = "CodProyecto=" + ddown002.SelectedValue + "&AnoMes=" + ddown_AnoCierre.SelectedValue + ddown_MesCierre.SelectedValue + "&IdUsr=" + Session["IdUsuario"].ToString();
            //window.open(Page, "Cierre_ResumenAtencionReporte.aspx?" + url, 600, 800);
        }
    }

    private void getinstituciones()
    {
        DataSet ds = (DataSet)Session["dsParametricas"];
        // << --- DPL 20-08-2015 --- >
        //institucioncoll icoll = new institucioncoll();
        //DataTable dtinst = icoll.GetData(Convert.ToInt32(Session["IdUsuario"]));
        // << --- DPL 20-08-2015 --- >
        DataTable dtinst = ds.Tables["dtInstituciones"];
        DataView dv = new DataView(dtinst);
        dv.Sort = "Nombre ASC";
        ddown001.DataSource = dv;
        ddown001.DataTextField = "Nombre";
        ddown001.DataValueField = "Codinstitucion";
        ddown001.DataBind();

    }

    private void getproyectos()
    {
        if (ddown001.Items.Count > 0 && Convert.ToInt32(ddown001.SelectedValue) > 0)
        {
            proyectocoll pcoll = new proyectocoll();

            DataTable dtproy = pcoll.GetData(Convert.ToInt32(Session["IdUsuario"]), "V", Convert.ToInt32(ddown001.SelectedValue));
            DataView dv = new DataView(dtproy);
            dv.Sort = "Nombre";
            ddown002.DataSource = dv;
            ddown002.DataTextField = "Nombre";
            ddown002.DataValueField = "CodProyecto";
            ddown002.DataBind();
            lbl_aviso4.Visible = false;
        }
    }


    private void getanos()
    {
        for (int i = 0; i < 7; i++)
        {
            ddown_AnoCierre.Items.Add(Convert.ToString(DateTime.Now.Year - i));
        }

    }

    protected void ddown001_SelectedIndexChanged(object sender, EventArgs e)
    {
        getproyectos();
    }

    protected void ddown002_SelectedIndexChanged(object sender, EventArgs e)
    {
        ArrayList al = new ArrayList();
        al = (ArrayList)Session["variables_impresion"];
        al[0] = ddown002.SelectedValue;
        Session["variables_impresion"] = al;
    }

    private void getdata()
    {
        DataTable dt = callto_cierre_cabeceraproyecto(Convert.ToInt32(ddown002.SelectedValue), Convert.ToInt32(ddown_AnoCierre.SelectedValue + ddown_MesCierre.SelectedValue));
        DataTable dt2 = callto_cierre_resumenatencionmensual(Convert.ToInt32(ddown002.SelectedValue), Convert.ToInt32(ddown_AnoCierre.SelectedValue + ddown_MesCierre.SelectedValue), -1);
        if (dt.Rows.Count > 0)
        {
            lbl001.Text = dt.Rows[0][5].ToString();
            lbl002.Text = dt.Rows[0][6].ToString();
            lbl003.Text = dt.Rows[0][7].ToString();
            lbl004.Text = dt.Rows[0][8].ToString();
            lbl005.Text = dt.Rows[0][9].ToString();
            if (Convert.ToInt32(dt.Rows[0][12]) == 0)
            {
                Imb002.Visible = false;
                Imb004.Visible = true;
                alert_lb_5y4.Visible = false;
                lbl_aviso5.Visible = false;
            }
            else
            {
                Imb002.Visible = true;
                Imb004.Visible = false;
                alert_lb_5y4.Visible = true;
                lbl_aviso5.Visible = true;
            }
        }
        if (dt2.Rows.Count > 0)
        {
            lbl006.Text = dt2.Rows[0][2].ToString();
            lbl007.Text = dt2.Rows[0][3].ToString();
            lbl008.Text = Convert.ToString(Convert.ToInt32(dt2.Rows[0][2]) + Convert.ToInt32(dt2.Rows[0][3]));

            lbl009.Text = dt2.Rows[0][4].ToString();
            lbl010.Text = dt2.Rows[0][5].ToString();
            lbl011.Text = Convert.ToString(Convert.ToInt32(dt2.Rows[0][4]) + Convert.ToInt32(dt2.Rows[0][5]));

            lbl012.Text = dt2.Rows[0][6].ToString();
            lbl013.Text = dt2.Rows[0][7].ToString();
            lbl014.Text = Convert.ToString(Convert.ToInt32(dt2.Rows[0][6]) + Convert.ToInt32(dt2.Rows[0][7]));

            lbl015.Text = Convert.ToString(Convert.ToInt32(dt2.Rows[0][2]) + Convert.ToInt32(dt2.Rows[0][4]) - Convert.ToInt32(dt2.Rows[0][6]));
            lbl016.Text = Convert.ToString(Convert.ToInt32(dt2.Rows[0][3]) + Convert.ToInt32(dt2.Rows[0][5]) - Convert.ToInt32(dt2.Rows[0][7]));
            lbl017.Text = Convert.ToString(Convert.ToInt32(dt2.Rows[0][2]) + Convert.ToInt32(dt2.Rows[0][4]) - Convert.ToInt32(dt2.Rows[0][6]) + Convert.ToInt32(dt2.Rows[0][3]) + Convert.ToInt32(dt2.Rows[0][5]) - Convert.ToInt32(dt2.Rows[0][7]));

            lbl018.Text = dt2.Rows[0][8].ToString();
            lbl019.Text = dt2.Rows[0][9].ToString();
            lbl020.Text = Convert.ToString(Convert.ToInt32(dt2.Rows[0][8]) + Convert.ToInt32(dt2.Rows[0][9]));
            lbl021.Text = dt2.Rows[0][10].ToString();
            lbl022.Text = dt2.Rows[0][11].ToString();
            lbl023.Text = Convert.ToString(Convert.ToInt32(dt2.Rows[0][10]) + Convert.ToInt32(dt2.Rows[0][11]));
            lbl024.Text = dt2.Rows[0][12].ToString();
            lbl025.Text = dt2.Rows[0][13].ToString();
            lbl026.Text = Convert.ToString(Convert.ToInt32(dt2.Rows[0][12]) + Convert.ToInt32(dt2.Rows[0][13]));

            lbl027.Text = dt2.Rows[0][14].ToString();

            lbl028.Text = dt2.Rows[0][15].ToString();
            lbl029.Text = dt2.Rows[0][16].ToString();
            lbl030.Text = Convert.ToString(Convert.ToInt32(dt2.Rows[0][15]) + Convert.ToInt32(dt2.Rows[0][16]));

            lbl031.Text = dt2.Rows[0][17].ToString();
            lbl032.Text = dt2.Rows[0][18].ToString();
            lbl033.Text = Convert.ToString(Convert.ToInt32(dt2.Rows[0][17]) + Convert.ToInt32(dt2.Rows[0][18]));

            lbl034.Text = dt2.Rows[0][19].ToString();
            lbl035.Text = dt2.Rows[0][20].ToString();
            lbl036.Text = Convert.ToString(Convert.ToInt32(dt2.Rows[0][19]) + Convert.ToInt32(dt2.Rows[0][20]));

            lbl037.Text = dt2.Rows[0][21].ToString();
            lbl038.Text = dt2.Rows[0][22].ToString();
            lbl039.Text = Convert.ToString(Convert.ToInt32(dt2.Rows[0][21]) + Convert.ToInt32(dt2.Rows[0][22]));

            lbl040.Text = dt2.Rows[0][23].ToString();
            lbl041.Text = dt2.Rows[0][24].ToString();
            lbl042.Text = Convert.ToString(Convert.ToInt32(dt2.Rows[0][23]) + Convert.ToInt32(dt2.Rows[0][24]));

            lbl043.Text = dt2.Rows[0][25].ToString();
            lbl044.Text = dt2.Rows[0][26].ToString();
            lbl045.Text = Convert.ToString(Convert.ToInt32(dt2.Rows[0][25]) + Convert.ToInt32(dt2.Rows[0][26]));

            lbl046.Text = dt2.Rows[0][25].ToString();
            lbl047.Text = dt2.Rows[0][26].ToString();
            lbl048.Text = Convert.ToString(Convert.ToInt32(dt2.Rows[0][25]) + Convert.ToInt32(dt2.Rows[0][26]));

            lbl049.Text = dt2.Rows[0][25].ToString();
            lbl050.Text = dt2.Rows[0][26].ToString();
            lbl051.Text = Convert.ToString(Convert.ToInt32(dt2.Rows[0][25]) + Convert.ToInt32(dt2.Rows[0][26]));

            lbl052.Text = dt2.Rows[0][29].ToString();
            lbl053.Text = dt2.Rows[0][30].ToString();
            lbl054.Text = Convert.ToString(Convert.ToInt32(dt2.Rows[0][29]) + Convert.ToInt32(dt2.Rows[0][30]));

            lbl055.Text = dt2.Rows[0][31].ToString();
            lbl056.Text = dt2.Rows[0][32].ToString();
            lbl057.Text = Convert.ToString(Convert.ToInt32(dt2.Rows[0][31]) + Convert.ToInt32(dt2.Rows[0][32]));

            switch (Convert.ToInt32(dt2.Rows[0][28]))    // Tipo de Subvencion
            {
                case 5:
                    pnl001.Visible = true;
                    pnl002.Visible = false;
                    pnl003.Visible = false;
                    break;
                case 16:
                    pnl001.Visible = true;
                    pnl002.Visible = false;
                    pnl003.Visible = false;
                    break;
                case 14:
                    pnl001.Visible = false;
                    pnl002.Visible = true;
                    pnl003.Visible = false;
                    break;
                case 18:
                    pnl001.Visible = false;
                    pnl002.Visible = false;
                    pnl003.Visible = true;

                    // < DPL 11-09-2008 > 
                    ninocoll ncoll = new ninocoll();
                    int CodModeloIntervencion = (int)ncoll.callto_get_codmodelointervencion(Convert.ToInt32(ddown002.SelectedValue));
                    if (CodModeloIntervencion == 83)     // PPC - PROGRAMA PREVENCION COMUNITARIA
                    {
                        pnl004.Visible = true;
                        pnl003.Visible = false;
                    }
                    // < DPL 11-09-2008 > 
                    break;
            }

            if (dt.Rows[0]["CodModeloIntervencion"].ToString() == "128")
            {
                //pnlBody.Visible = false;
                int TotalPJC = 0;
                pnlPJC.Visible = true;
                lblASD.Text = dt2.Rows[0]["IntervencionesASD"].ToString();
                lblASN.Text = dt2.Rows[0]["IntervencionesASN"].ToString();
                lblASF.Text = dt2.Rows[0]["IntervencionesASF"].ToString();
                lblAPS.Text = dt2.Rows[0]["IntervencionesAPS"].ToString();
                lblALA.Text = dt2.Rows[0]["IntervencionesALA"].ToString();
                lblARD.Text = dt2.Rows[0]["IntervencionesARD"].ToString();

                if (lblASD.Text != "0") TotalPJC += Convert.ToInt32(dt2.Rows[0]["IntervencionesASD"]);
                if (lblASN.Text != "0") TotalPJC += Convert.ToInt32(dt2.Rows[0]["IntervencionesASN"]);
                if (lblASF.Text != "0") TotalPJC += Convert.ToInt32(dt2.Rows[0]["IntervencionesASF"]);
                if (lblAPS.Text != "0") TotalPJC += Convert.ToInt32(dt2.Rows[0]["IntervencionesAPS"]);
                if (lblALA.Text != "0") TotalPJC += Convert.ToInt32(dt2.Rows[0]["IntervencionesALA"]);
                if (lblARD.Text != "0") TotalPJC += Convert.ToInt32(dt2.Rows[0]["IntervencionesARD"]);

                lblTotalPJC1.Text = TotalPJC.ToString();
            }

            // < DPL 24-04-2012 > 
            if (Convert.ToInt32(dt.Rows[0]["CodDepartamentosSENAME"]) == 6 || Convert.ToInt32(dt.Rows[0]["CodDepartamentosSENAME"]) == 9)
            {
                pnl80Bis.Visible = true;

                lbl80BisFemenino.Text = dt2.Rows[0]["Total80BisF"].ToString();
                lbl80BisMasculino.Text = dt2.Rows[0]["Total80BisM"].ToString();
                lblTotal80Bis.Text = Convert.ToString(Convert.ToInt32(dt2.Rows[0]["Total80BisF"]) + Convert.ToInt32(dt2.Rows[0]["Total80BisM"]));

                lbl80BisFemeninoOtros.Text = dt2.Rows[0]["TotalNo80BisF"].ToString();
                lbl80BisMasculinoOtros.Text = dt2.Rows[0]["TotalNo80BisM"].ToString();
                lblTotal80BisOtros.Text = Convert.ToString(Convert.ToInt32(dt2.Rows[0]["TotalNo80BisF"]) + Convert.ToInt32(dt2.Rows[0]["TotalNo80BisM"]));
            }
            // < DPL 24-04-2012 > 

            switch (Convert.ToInt32(dt2.Rows[0][0]))
            {
                case 0:
                    alerts.Visible = false;
                    lbl_aviso1.Visible = false;
                    lbl_aviso2.Visible = false;
                    lbl_aviso3.Visible = false;

                    break;
                case 1:
                    alerts.Visible = true;
                    lbl_aviso1.Visible = true;
                    lbl_aviso2.Visible = false;
                    lbl_aviso3.Visible = false;

                    break;
                case 2:
                    alerts.Visible = true;
                    lbl_aviso1.Visible = false;
                    lbl_aviso2.Visible = true;
                    lbl_aviso3.Visible = false;

                    break;
                case 3:
                    alerts.Visible = true;
                    lbl_aviso1.Visible = true;
                    lbl_aviso2.Visible = true;
                    lbl_aviso3.Visible = false;

                    break;
                case 4:
                    alerts.Visible = true;
                    lbl_aviso1.Visible = false;
                    lbl_aviso2.Visible = false;
                    lbl_aviso3.Visible = true;

                    break;
                case 5:
                    alerts.Visible = true;
                    lbl_aviso1.Visible = true;
                    lbl_aviso2.Visible = false;
                    lbl_aviso3.Visible = true;

                    break;
                case 6:
                    alerts.Visible = true;
                    lbl_aviso1.Visible = false;
                    lbl_aviso2.Visible = true;
                    lbl_aviso3.Visible = true;

                    break;
                case 7:
                    alerts.Visible = true;
                    lbl_aviso1.Visible = true;
                    lbl_aviso2.Visible = true;
                    lbl_aviso3.Visible = true;

                    break;
            }
        }
        //gfontbrevis
        //lbl_resumen_filtro.Text = "<br>";
        //lbl_resumen_filtro.Text += "<strong>Has filtrado utilizando los siguientes datos: </strong>";
        //lbl_resumen_filtro.Text += "<br>";
        //lbl_resumen_filtro.Text += "- Institución: " + ddown001.SelectedItem.Text.Trim() + "<br>";
        lbl_resumen_filtro.Text =  ddown002.SelectedItem.Text.Trim() + " / " ;
        lbl_resumen_filtro.Text +=  ddown_MesCierre.SelectedItem.Text + " de " + ddown_AnoCierre.SelectedItem.Text ;
        //lbl_resumen_filtro.Text += "- Región: " + lbl001.Text + "<br>";
        //lbl_resumen_filtro.Text += "- Sistema Asistencial: " + lbl002.Text + "<br>";
        //lbl_resumen_filtro.Text += "- Modelo de Intervención: " + lbl003.Text + "<br>";
        //lbl_resumen_filtro.Text += "- Tipo Pago: " + lbl004.Text + "<br>";
        lbl_resumen_filtro.Text += " / " + lbl005.Text ;

        lbl_resumen_filtro.Visible = true;
        //lbl_resumen_filtro.Style.Add("display", "none");

    }

    private DataTable callto_cierre_cabeceraproyecto(int codproyecto, int mesano)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "cierre_cabeceraproyecto";
        sqlc.Parameters.Add("@codproyecto", SqlDbType.Int, 4).Value = codproyecto;
        sqlc.Parameters.Add("@mesano", SqlDbType.Int, 4).Value = mesano;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    private DataTable callto_cierre_resumenatencionmensual(int codproyecto, int mesano, int id_usr)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "cierre_resumenatencionmensual";
        sqlc.Parameters.Add("@codproyecto", SqlDbType.Int, 4).Value = codproyecto;
        sqlc.Parameters.Add("@MesAno", SqlDbType.Int, 4).Value = mesano;
        sqlc.Parameters.Add("@id_usr", SqlDbType.Int, 4).Value = id_usr;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    protected void ddown_MesCierre_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddown_MesCierre.SelectedIndex != 0)
        {
            getdata();
            ArrayList al = new ArrayList();
            al = (ArrayList)Session["variables_impresion"];
            al[1] = Convert.ToInt32(Convert.ToString(ddown_AnoCierre.SelectedValue) + Convert.ToString(ddown_MesCierre.SelectedValue));
            Session["variables_impresion"] = al;
        }
    }

    protected void Imb004_Click(object sender, EventArgs e)
    {
        string strMessage = "¿Está seguro de Cerrar/Firmar el mes de " + ddown_MesCierre.SelectedItem + " de " + ddown_AnoCierre.SelectedItem + "?";
        RendicionCuentasColl rC = new RendicionCuentasColl();

        DataView dv1 = new DataView(rC.Get_DirectoresProyectosFirma(Convert.ToInt32(ddown002.Text), 1));
        ddlFirma.DataSource = dv1;
        ddlFirma.DataTextField = "Nombre";
        ddlFirma.DataValueField = "IdUsuario";

        ddlFirma.DataBind();
        SetMessageBox(true, 5, strMessage);
    }

    private DataTable callto_cierre_cerrarmes(int codproyecto, int mesano, int id_usr, string Firma, string Cargo)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "cierre_cerrarmes";
        sqlc.Parameters.Add("@codproyecto", SqlDbType.Int, 4).Value = codproyecto;
        sqlc.Parameters.Add("@MesAno", SqlDbType.Int, 4).Value = mesano;
        sqlc.Parameters.Add("@id_usr", SqlDbType.Int, 4).Value = id_usr;
        sqlc.Parameters.Add("@Firma", SqlDbType.VarChar, 200).Value = Firma;
        sqlc.Parameters.Add("@Cargo", SqlDbType.VarChar, 200).Value = Cargo;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        try
        {
            da.Fill(dt);
        }
        catch
        {
            dt.Columns.Add("aviso");
            DataRow dr = dt.NewRow();
            dr[0] = 0;
            dt.Rows.Add(dr);
        }
        sconn.Close();
        return dt;
    }

    protected void imb_volver_Click(object sender, EventArgs e)
    {
        //Response.Redirect("index_ninos.aspx");
        if (ddown_MesCierre.SelectedIndex > 0)
        {
            Response.Redirect("cierre_movmensual.aspx?sw=4&codinst=" + ddown002.SelectedValue + "&M=" + ddown_MesCierre.SelectedValue + "&A=" + ddown_AnoCierre.SelectedValue);
        }
    }

    protected void btn_MessageBox(object sender, CommandEventArgs e)
    {
        if (ddlFirma.SelectedValue == "0" && e.CommandName != "7")
        {
            lblFirma.Visible = true;
            ddlFirma.BackColor = System.Drawing.Color.Pink;
            ddlFirma.Focus();
            return;
        }
        SetMessageBox(false, 0, "");
        if (e.CommandName == "6")
            CierraResumenAtencion();
    }

    private void CierraResumenAtencion()
    {
        string strFirma = string.Empty;
        string strCargo = string.Empty;
        //if (ddlFirma.SelectedValue != string.Empty)
        //{
        //    strFirma = ddlFirma.SelectedItem.Text;
        //    strCargo = ddlFirma.SelectedValue;
        //}
        if (ddlFirma.SelectedValue != string.Empty)
        {
            strFirma = ddlFirma.SelectedItem.Text;
            RendicionCuentasColl rC = new RendicionCuentasColl();
            DataView dv1 = new DataView(rC.Get_DirectoresProyectosFirma(Convert.ToInt32(ddown002.SelectedValue), 2));
            dv1.Sort = "IdUsuario";
            int rowIndex = dv1.Find(ddlFirma.SelectedValue);
            if (rowIndex != 0)
                strCargo = dv1[rowIndex]["Cargo"].ToString();

        }

        if (ddown002.SelectedValue == "1131260")
        {
            DataTable dt0 = callto_cierre_cabeceraproyecto(Convert.ToInt32(ddown002.SelectedValue), Convert.ToInt32(ddown_AnoCierre.SelectedValue + ddown_MesCierre.SelectedValue));
            if (Convert.ToInt32(dt0.Rows[0]["cerrado"]) == 1)
            {
            }
        }

        DataTable dt = callto_cierre_cerrarmes(Convert.ToInt32(ddown002.SelectedValue), Convert.ToInt32(ddown_AnoCierre.SelectedValue + ddown_MesCierre.SelectedValue), Convert.ToInt32(Session["IdUsuario"]), strFirma, strCargo);

        if (Convert.ToInt32(dt.Rows[0][0]) == 0)
        {
            lbl_aviso4.Text = "<span  class='glyphicon glyphicon-remove' ></span> Cierre no realizado, hubo errores";
            //lbl_aviso4.ForeColor = System.Drawing.Color.Red;
            alert_lb_5y4.Visible = true;
            alert_lb_5y4.Attributes.Remove("class");
            alert_lb_5y4.Attributes.Add("class", "text-center alert alert-warning");
            lbl_aviso4.Visible = true;
            Imb002.Visible = false;
            //gfontbrevis: esconder otras alertas
            lbl_aviso5.Visible = false;
            alerts.Visible = false;

        }
        else
        {
            lbl_aviso4.Text = "<span  class='glyphicon glyphicon-ok' ></span> Cierre realizado con éxito";
            //lbl_aviso4.ForeColor = System.Drawing.Color.Green;
            alert_lb_5y4.Visible = true;
            lbl_aviso4.Visible = true;
            alert_lb_5y4.Attributes.Remove("class");
            alert_lb_5y4.Attributes.Add("class", "text-center alert alert-success");
            Imb002.Visible = true;
            Imb004.Visible = false;
            //gfontbrevis: esconder otras alertas
            lbl_aviso5.Visible = false;
            alerts.Visible = false;

        }
    }

    protected void SetMessageBox(bool Habilita, int intBotones, string strMessage)
    {
        pnlBody.Visible = !Habilita;
        pnlMessageBox.Visible = Habilita;

        if (!Habilita)
            return;

        btnSi.Visible = false;
        btnNo.Visible = false;

        lblMessage.Text = strMessage;
        switch (intBotones)
        {
            case 5:
                btnSi.Visible = true;
                btnNo.Visible = true;
                break;
            case 6:
                btnSi.Visible = true;
                btnNo.Visible = true;
                break;
        }
    }

   /* private void mostrar_collapse(bool valor)
    {
      if (valor)
      {

        collapse_Form.Attributes.Remove("Class");
        collapse_Form.Attributes.Add("Class", "panel-collapse collapse in");
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "A", "$('#lbl_resumen_filtro').hide();", true);
      }
      if (!valor)
      {
        collapse_Form.Attributes.Remove("Class");
        collapse_Form.Attributes.Add("Class", "panel-collapse collapse out");
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "A", "$('#lbl_resumen_filtro').show();", true);
      }

    }*/
}
