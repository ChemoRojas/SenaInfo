using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class mod_ninos_ninos_MedidaOSancion : System.Web.UI.UserControl
{
    public DataTable dt_gridsancion
    {
        get { return (DataTable)ViewState["dt_gridsancion"]; }
        set { ViewState["dt_gridsancion"] = value; }
    }
    
    public int VICodMedidaSancion
    {
        get
        {
            if (ViewState["ICodMedidaSancion"] == null)
            { ViewState["ICodMedidaSancion"] = -1; }
            return Convert.ToInt32(ViewState["ICodMedidaSancion"]);
        }
        set { ViewState["ICodMedidaSancion"] = value; }
    }
    public string IPSER
    {
        get { return (string)ViewState["IPSER"]; }
        set { ViewState["IPSER"] = value; }
    }
    public string TIPOBC
    {
        get { return (string)ViewState["TIPOBC"]; }
        set { ViewState["TIPOBC"] = value; }
    }
    public string AREATI
    {
        get { return (string)ViewState["AREATI"]; }
        set { ViewState["AREATI"] = value; }
    }
    public string SHORAS
    {
        get { return (string)ViewState["SHORAS"]; }
        set { ViewState["SHORAS"] = value; }
    }
    public bool opcact
    {
        get { return (bool)ViewState["opcact"]; }
        set { ViewState["opcact"] = value; }
    }
    
    public int UserId
    {
        get { return (int)Session["IdUsuario"]; }
        set { Session["IdUsuario"] = value; }
    }
    public string repdaño
    {
        get
        {
            if (ViewState["repdaño"] == null)
            { ViewState["repdaño"] = -1; }
            return Convert.ToString(ViewState["repdaño"]);
        }
        set { ViewState["repdaño"] = value; }
    }
    public int horas
    {
        get
        {
            if (ViewState["horas"] == null)
            { ViewState["horas"] = -1; }
            return Convert.ToInt32(ViewState["horas"]);
        }
        set { ViewState["horas"] = value; }
    }
    //public bool opc
    //{
    //    get { return (bool)Session["opc"]; }
    //    set { Session["opc"] = value; }
    //}

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
    public DataTable dt_coning
    {
        get { return (DataTable)ViewState[" dt_coning"]; }
        set { ViewState[" dt_coning"] = value; }
    }
    public bool grd_val
    {
        get { return (bool)Session["grd_val"]; }
        set { Session["grd_val"] = value; }
    }
    public DataTable DTTipoSancionAccesoria
    {
        get { return (DataTable)Session["DTTipoSancionAccesoria"]; }
        set { Session["DTTipoSancionAccesoria"] = value; }
    }
    public DataTable DTlesiones
    {
        get { return (DataTable)Session["DTlesiones"]; }
        set { Session["DTlesiones"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        lbl_avisoDuracionLRPA.Text = myInput.Value;
        if (!IsPostBack)
        {
            //lblfechaini2LRPA.Text = myInput.Value;
        }

    }

    private bool FiltroLRPA()
    {
        bool swLrpa;
        LRPAcoll LRPA = new LRPAcoll();
        DataTable dt = new DataTable();
        dt = LRPA.callto_get_proyectoslrpa(SSnino.CodProyecto);
        swLrpa = (Convert.ToInt32(dt.Rows[0][0]) > 0 && dt.Rows[0][1].ToString() == "20084");
        return (swLrpa);
    }

    public void CargaTodo()
    {
        parcoll pcoll = new parcoll();
        LRPAcoll LRPA = new LRPAcoll();

        DataView dv = new DataView(pcoll.GetparRegion());
        ddown003LRPA.Items.Clear();
        ddown003LRPA.DataSource = dv;
        ddown003LRPA.DataTextField = "Descripcion";
        ddown003LRPA.DataValueField = "CodRegion";
        dv.Sort = "CodRegion";
        ddown003LRPA.DataBind();
        ddown003LRPA.Focus();

        bool swLrpa = FiltroLRPA();

        if (swLrpa)
        {
            LRPAcoll LRPA1 = new LRPAcoll();
            ddown004LRPA.Items.Clear();
            DataView dv0 = new DataView(LRPA1.GetparTipoTribunalLRPA());
            ddown004LRPA.DataSource = dv0;
            ddown004LRPA.DataTextField = "Descripcion";
            ddown004LRPA.DataValueField = "TipoTribunal";
            dv0.Sort = "Descripcion";
            ddown004LRPA.DataBind();
            ddown004LRPA.Focus();
        }
        else
        {

            ddown004LRPA.Items.Clear();
            DataView dv1 = new DataView(pcoll.GetparTipoTribunal());
            ddown004LRPA.DataSource = dv1;
            ddown004LRPA.DataTextField = "Descripcion";
            ddown004LRPA.DataValueField = "TipoTribunal";
            dv1.Sort = "Descripcion";
            ddown004LRPA.DataBind();
            ddown004LRPA.Focus();
        }

        ddown008LRPA.Items.Clear();
        DataView dv2 = new DataView(LRPA.callto_get_parterminomedidasancion());
        ddown008LRPA.DataSource = dv2;
        ddown008LRPA.DataTextField = "Descripcion";
        ddown008LRPA.DataValueField = "CodTerminoSancion";
        dv2.Sort = "Descripcion";
        ddown008LRPA.DataBind();
        ddown008LRPA.Focus();

        ddown008LRPA.SelectedValue = "-1";


        DTTipoSancionAccesoria = new DataTable();

        DTTipoSancionAccesoria.Columns.Add(new DataColumn("CodSancion", typeof(string)));
        DTTipoSancionAccesoria.Columns.Add(new DataColumn("CodTipoSancionAccesoria", typeof(int)));
        DTTipoSancionAccesoria.Columns.Add(new DataColumn("Descripcion", typeof(int)));
        getdatossbcypsa();
        GetMedida(); MuestraTab();
    }

    public void getdatossbcypsa()
    {

        try
        {


            int codproy = Convert.ToInt32(SSnino.CodProyecto);
            LRPAcoll codmod = new LRPAcoll();
            DataTable dt2 = codmod.GetCodModIntervencion(codproy);
            int codemod = Convert.ToInt32(dt2.Rows[0][0]);

            if (codemod == 103 || codemod == 108)
            {
                PnlServicio.Visible = true;
                LRPAcoll cons = new LRPAcoll();
                DataView dv = new DataView(cons.GetPartiposancion());
                ddown_tsancion.Items.Clear();
                ddown_tsancion.DataSource = dv;
                ddown_tsancion.DataTextField = "Descripcion";
                ddown_tsancion.DataValueField = "CodTipoSancion";
                dv.Sort = "Descripcion";
                ddown_tsancion.DataBind();
                if (codemod == 103)
                {

                    ddown_tsancion.Items.RemoveAt(1);
                }

                LRPAcoll lrpa2 = new LRPAcoll();
                DataView dvconi = new DataView(lrpa2.callto_getpartipoConIngreso());
                ddown_conIng.Items.Clear();
                ddown_conIng.DataSource = dvconi;
                ddown_conIng.DataTextField = "Nemotecnico";
                ddown_conIng.DataValueField = "CodCondicionIngreso";
                dvconi.Sort = "CodCondicionIngreso";
                ddown_conIng.DataBind();

                dt_coning = new DataTable();

                dt_coning.Columns.Add(new DataColumn("CodCondicionIngreso", typeof(string)));
                dt_coning.Columns.Add(new DataColumn("CodMedidaSancion", typeof(string)));
                dt_coning.Columns.Add(new DataColumn("Descripcion", typeof(string)));


                LRPAcoll cons1 = new LRPAcoll();
                DataView dv1 = new DataView(cons1.GetParActividad());
                ddown_tipoBC.Items.Clear();
                ddown_tipoBC.DataSource = dv1;
                ddown_tipoBC.DataTextField = "Descripcion";
                ddown_tipoBC.DataValueField = "CodTipoActividad";
                dv1.Sort = "Descripcion";
                ddown_tipoBC.DataBind();


                LRPAcoll cons4 = new LRPAcoll();
                DataView dv4 = new DataView(cons4.GetParTipoInstitucion());
                ddown_IPSER.Items.Clear();
                ddown_IPSER.DataSource = dv4;
                ddown_IPSER.DataTextField = "Descripcion";
                ddown_IPSER.DataValueField = "TipoInstitucion";
                dv4.Sort = "Descripcion";
                ddown_IPSER.DataBind();


                LRPAcoll cons2 = new LRPAcoll();
                DataView dv2 = new DataView(cons2.GetAreaTrabajo());
                ddown_areaTI.Items.Clear();
                ddown_areaTI.DataSource = dv2;
                ddown_areaTI.DataTextField = "Descripcion";
                ddown_areaTI.DataValueField = "CodTipoAreaTrabajo";
                dv2.Sort = "Descripcion";
                ddown_areaTI.DataBind();


                LRPAcoll cons3 = new LRPAcoll();
                DataView dv3 = new DataView(cons3.GetReparacion());
                ddown_repdaño.Items.Clear();
                ddown_repdaño.DataSource = dv3;
                ddown_repdaño.DataTextField = "Descripcion";
                ddown_repdaño.DataValueField = "CodTipoReparacion";
                dv3.Sort = "Descripcion";
                ddown_repdaño.DataBind();


            }
            else
            {
                PnlServicio.Visible = false;
                ddown_tipoBC.Enabled = false;
                ddown_IPSER.Enabled = false;
                ddown_tsancion.Enabled = false;
                ddown_areaTI.Enabled = false;
                ddown_repdaño.Enabled = false;
                ddown_conIng.Enabled = false;
                txt_hservi.Enabled = true;
                btn_coning.Visible = false;
            }

            if (codemod == 103)
            {
                ddown_conIng.Enabled = false;
                btn_coning.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Log(ex.Message + " " + ex.InnerException);
        }

    }
    public void CargaOT()
    {
        LRPAcoll LRPA = new LRPAcoll();
        DataTable dtOT = LRPA.GetICodTribunalIngreso_LRPA(SSnino.ICodIE);
        if (dtOT.Rows.Count > 0)
        {
            ddl_OrdenDeTribunal_MedidaSancion.Items.Clear();
            ddl_OrdenDeTribunal_MedidaSancion.DataSource = dtOT;
            ddl_OrdenDeTribunal_MedidaSancion.DataTextField = "Descripcion";
            ddl_OrdenDeTribunal_MedidaSancion.DataValueField = "ICodTribunalIngreso";
            ddl_OrdenDeTribunal_MedidaSancion.DataBind();
        }
    }

    public void CargaSeleccion()
    {
        LRPAcoll LRPA = new LRPAcoll();
        DataTable dtLRPA = new DataTable();
        dtLRPA = LRPA.callto_get_sancionesbycodmedidasancion(SSnino.ICodIE);
        if (dtLRPA.Rows.Count > 0)
        {

            grdseleccionLRPA.DataSource = dtLRPA;
            grdseleccionLRPA.DataBind();
            grdseleccionLRPA.Visible = true;
        }
    }


    public void restart_utab()
    {

        //limpia medida o sanción
        if (ddl_OrdenDeTribunal_MedidaSancion.Items.Count > 0)
        {
            ddl_OrdenDeTribunal_MedidaSancion.SelectedIndex = 0;
        }

     
        ddl_OrdenDeTribunal_MedidaSancion.Items.Insert(0, " Seleccionar");

        txt_FechaInicioSancionLRPA.Text = "";
        txt001LRPA.Text = "";
        txt002LRPA.Text = "";
        txt007LRPA.Text = "";
        txt009LRPA.Text = "";
        txt003LRPA.Text = "";
        ddown011LRPA.Items.Clear();
        ddown005LRPA.Items.Clear();
        chk001LRPA.Checked = false;
        btnAgregarTsancionLRPA.Visible = false;
        ddown006LRPA.Visible = false;
        tr_tipo_sancion_accesoria.Visible = false;
        //ddown009LRPA.Text = "Seleccione Fecha";
        txt004LRPA.Text = "";
        txt005LRPA.Text = "";
        txt008LRPA.Text = "";
        txt006LRPA.Text = "";
        lbl_avisoLRPA.Visible = false;

        ddown004LRPA.BackColor = System.Drawing.Color.Empty;
        ddl_OrdenDeTribunal_MedidaSancion.BackColor = System.Drawing.Color.Empty;

        txt001LRPA.BackColor = System.Drawing.Color.Empty;
        txt002LRPA.BackColor = System.Drawing.Color.Empty;
        txt007LRPA.BackColor = System.Drawing.Color.Empty;
       
        //pnl_utab6.ForeColor = System.Drawing.Color.Black;

    }




    //protected void ddown_otm_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    //GMP muestra_pestaña(6);
    //    //MuestraTab();

    //    //opc = false;

    //    //int codproy = Convert.ToInt32(ddl_Proyecto.SelectedValue);
    //    //int codproy = Convert.ToInt32(SSnino.CodProyecto);
    //    //LRPAcoll codmod = new LRPAcoll();
    //    //DataTable dt2 = codmod.GetCodModIntervencion(codproy);
    //    //int codemod = Convert.ToInt32(dt2.Rows[0][0]);
    //    //if (ddl_OrdenDeTribunal_MedidaSancion.SelectedValue != Convert.ToString(0))
    //    //{
    //    //    //opc = (codemod == 100 || codemod == 102);
    //    //}
    //    //else
    //    //{
    //    //    //opc = false;
    //    //}
    //}
    protected void ddown001LRPA_ValueChanged(object sender, EventArgs e)
    {
        Calcula_Dias();
        //GMP SetFocus(dd_focus1);

    }
    protected void lnk001_Click1(object sender, EventArgs e)
    {
        //GMP muestra_pestaña(6);
        Calcula_Dias();
        //MuestraTab();
    }

    protected void ddown009LRPA_ValueChanged(object sender, EventArgs e)
    {
        Calcula_Dias_Mix();
    }

    protected void lnk_limpiaFechas_Click(object sender, EventArgs e)
    {

        txt001LRPA.Text = "";
        txt002LRPA.Text = "";
        txt003LRPA.Text = "";
        txt004LRPA.Text = "";
        txt005LRPA.Text = "";
        txt006LRPA.Text = "";
        txt007LRPA.Text = "";
        txt008LRPA.Text = "";
        txt009LRPA.Text = "";
        txt_FechaInicioSancionLRPA.Text = null;
        ddown009LRPA.Text = "";
        ddown007LRPA.Text = "";

        Chk002LRPAMixta.Checked = false;
        pnlLRPAmixta.Visible = false;
    }

    protected void ddown004LRPA_SelectedIndexChanged(object sender, EventArgs e)
    {
        //GMP muestra_pestaña(6);
        MuestraTab();
        if (ddown003LRPA.SelectedValue == "-2") return; //seleccionar
        if (ddown004LRPA.SelectedValue == "0") return; //seleccionar
        parcoll pcoll = new parcoll(); //                  region                          tipo tribunal
        DataView dv2 = new DataView(pcoll.GetparTribunales(ddown003LRPA.SelectedValue, ddown004LRPA.SelectedValue));
        ddown005LRPA.Items.Clear();
        ddown005LRPA.DataSource = dv2;
        ddown005LRPA.DataTextField = "Descripcion";
        ddown005LRPA.DataValueField = "CodTribunal";
        dv2.Sort = "Descripcion";
        ddown005LRPA.DataBind();
    }


    protected void chk001LRPA_CheckedChanged(object sender, EventArgs e)
    {
        //GMP muestra_pestaña(6);
        MuestraTab();
        if (chk001LRPA.Checked)
        {

            LRPAcoll lrpa = new LRPAcoll();
            DataView dv2 = new DataView(lrpa.callto_getpartiposancionaccesoria());
            ddown006LRPA.DataSource = dv2;
            ddown006LRPA.DataTextField = "Descripcion";
            ddown006LRPA.DataValueField = "CodTipoSancionAccesoria";
            dv2.Sort = "Descripcion";
            ddown006LRPA.DataBind();
             
            DTTipoSancionAccesoria = new DataTable();
            DTTipoSancionAccesoria.Columns.Add(new DataColumn("CodSancion", typeof(string)));
            DTTipoSancionAccesoria.Columns.Add(new DataColumn("CodTipoSancionAccesoria", typeof(int)));
            DTTipoSancionAccesoria.Columns.Add(new DataColumn("Descripcion", typeof(int)));


            pnl1LRPA.Visible = true;
            btnAgregarTsancionLRPA.Visible = true;
            grd001LRPA.Visible = true;
            ddown006LRPA.Visible = true;
            tr_tipo_sancion_accesoria.Visible = true;
        }
        else
        {
            pnl1LRPA.Visible = false;
            btnAgregarTsancionLRPA.Visible = false;
            grd001LRPA.Visible = false;
            ddown006LRPA.Visible = false;
            tr_tipo_sancion_accesoria.Visible = false;
        }
        focus1lrpachk.Focus();
        
    }
    protected void btnAgregarTsancionLRPA_Click(object sender, EventArgs e)
    {
        //GMP muestra_pestaña(6);
        
        DataRow dr = DTTipoSancionAccesoria.NewRow();
        bool chk_rep = false;

        if (ddown006LRPA.SelectedValue != Convert.ToString(0))
        {
            for (int i = 0; i < grd001LRPA.Rows.Count; i++)
            {
                if (grd001LRPA.Rows[i].Cells[1].Text == ddown006LRPA.SelectedValue)
                {
                    chk_rep = true;
                }
            }

            if (!chk_rep)
            {
                dr[0] = ddown006LRPA.SelectedItem;
                dr[1] = Convert.ToInt32(ddown006LRPA.SelectedValue);
                dr[2] = 3;

                DTTipoSancionAccesoria.Rows.Add(dr);
                DataView dv = new DataView(DTTipoSancionAccesoria);
                grd001LRPA.DataSource = dv;
                dv.Sort = "CodSancion";
                grd001LRPA.DataBind();
                grd001LRPA.Visible = true;

                ddown006LRPA.SelectedValue = Convert.ToString(0);
                ddown006LRPA.BackColor = System.Drawing.Color.Empty;
                lbl_avisoLRPA.Visible = false;
            }
            else
            {
                lbl_avisoLRPA.Text = "La sanción seleccionada ya ha sido ingresada";
                lbl_avisoLRPA.Visible = true;
            }
        }
        else
        {
            //ddown006LRPA.BackColor = System.Drawing.Color.P;
            lbl_avisoLRPA.Text = "Seleccione una opción válida";
            lbl_avisoLRPA.Visible = true;
        }
        MuestraTab();
    }
    protected void btnAgregar_coning_click(object sender, EventArgs e)
    {
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9");
        //muestra_pestaña(6);
        MuestraTab();

        DataRow dr = dt_coning.NewRow();
        bool chk_rep = false;

        if (ddown_conIng.SelectedValue != Convert.ToString(-1))
        {
            for (int i = 0; i < grd_LRPA02.Rows.Count; i++)
            {
                if (grd_LRPA02.Rows[i].Cells[0].Text == ddown_conIng.SelectedValue)
                {
                    chk_rep = true;

                }
            }

            if (!chk_rep)
            {
                LRPAcoll lrp2 = new LRPAcoll();
                DataTable dt2 = lrp2.Get_traenemotec(Convert.ToString(ddown_conIng.SelectedItem));
                string desc = Convert.ToString(dt2.Rows[0][0]);

                dr[0] = ddown_conIng.SelectedValue;
                dr[1] = "(" + ddown_conIng.SelectedItem + ")" + " - " + desc; 
                dr[2] = 3;

                dt_coning.Rows.Add(dr);
                DataView dv = new DataView(dt_coning);
                grd_LRPA02.DataSource = dv;
                dv.Sort = "CodCondicionIngreso";
                grd_LRPA02.DataBind();
                grd_LRPA02.Visible = true;

                ddown_conIng.SelectedValue = Convert.ToString(0);
                ddown_conIng.BackColor = System.Drawing.Color.Empty;
                Lbl_mensaje001.Visible = false;

            }
            else
            {
                Lbl_mensaje001.Text = "La Condición de Ingreso ya ha sido Ingresada";
                Lbl_mensaje001.Visible = true;
            }
        }
        else
        {
            ddown_conIng.BackColor = colorCampoObligatorio;
            ddown_conIng.Visible = true;

        }

    }

  
    protected void btnsaveingreso2_Click(object sender, EventArgs e)
    {
       
    }

    protected void grdseleccionLRPA_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int codmodel;

        IPSER = "0";
        TIPOBC = "0";
        AREATI = "0";
        SHORAS = "0";
            
        opcact = false;
        MuestraTab();
        if (e.CommandName == "ver")
        {
            lblbmsg.Visible = false; pnldatos.Visible = true;
            btn_GuardarLRPA.Text = "Modificar";
            DTTipoSancionAccesoria.Clear();
            string Cod = grdseleccionLRPA.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
            VICodMedidaSancion = Convert.ToInt32(Cod);
            LRPAcoll lrpa = new LRPAcoll();
            DataTable dtLRPA = lrpa.callto_get_sancionesbycodigo_2(Convert.ToInt32(Cod));
            if (dtLRPA.Rows.Count > 0)
            {

                int codproy = Convert.ToInt32(SSnino.CodProyecto);
                LRPAcoll codmod = new LRPAcoll();
                DataTable dt2 = codmod.GetCodModIntervencion(codproy);
                int codemod = Convert.ToInt32(dt2.Rows[0][0]);
                codmodel = codemod;// modelo intervencion
                CargaOT();
                try
                {
                    ddl_OrdenDeTribunal_MedidaSancion.SelectedValue = dtLRPA.Rows[0][17].ToString();
                }
                catch (Exception)
                {
                    ddl_OrdenDeTribunal_MedidaSancion.SelectedValue = "0";
                }

                txt001LRPA.Text = dtLRPA.Rows[0][1].ToString();
                txt002LRPA.Text = dtLRPA.Rows[0][0].ToString();
                txt007LRPA.Text = dtLRPA.Rows[0][18].ToString();
                txt001LRPA.Enabled = true;
                txt002LRPA.Enabled = true;
                txt007LRPA.Enabled = true;
                txt009LRPA.Enabled = true;
                txt_FechaInicioSancionLRPA.Text = Convert.ToDateTime(dtLRPA.Rows[0][2].ToString()).ToShortDateString();
                txt003LRPA.Text = Convert.ToDateTime(dtLRPA.Rows[0][3]).ToShortDateString();
                txt003LRPA.Enabled = false;
                ddown003LRPA.SelectedValue = dtLRPA.Rows[0][4].ToString();
                ddown004LRPA.SelectedValue = dtLRPA.Rows[0][5].ToString();


                if (codmodel == 103 || codmodel == 108)
                {
                    PnlServicio.Visible = true;
                    
                    try
                    {txt_hservi.Text = dtLRPA.Rows[0][22].ToString();}
                    catch
                    {txt_hservi.Text = "0";}
                    try
                    {ddown_repdaño.SelectedValue = Convert.ToString(dtLRPA.Rows[0][27]);}
                    catch
                    {ddown_repdaño.SelectedValue = "0";}

                    try
                    {ddown_areaTI.SelectedValue = dtLRPA.Rows[0][26].ToString();}
                    catch
                    {ddown_areaTI.SelectedValue = "0";}
                    try
                    {ddown_IPSER.SelectedValue = dtLRPA.Rows[0][25].ToString();}
                    catch
                    {ddown_IPSER.SelectedValue = "0";}
                    try
                    {ddown_tipoBC.SelectedValue = dtLRPA.Rows[0][24].ToString();}
                    catch
                    {ddown_tipoBC.SelectedValue = "0";}
                    try
                    {ddown_tsancion.SelectedValue = dtLRPA.Rows[0][23].ToString();}
                    catch
                    {ddown_tsancion.SelectedValue = "0";}
                }

                if (codemod == 103)
                {
                    ddown_conIng.Enabled = false;
                }

                if (codemod == 108)
                {
                    if (ddown_repdaño.SelectedValue == "3")
                    {
                        opcact = true;
                        SHORAS = txt_hservi.Text.ToString();
                        IPSER = ddown_IPSER.SelectedValue;
                        TIPOBC = ddown_tipoBC.SelectedValue;
                        AREATI = ddown_areaTI.SelectedValue;
                    }

                    LRPAcoll lrpa2 = new LRPAcoll();

                    DataTable dt3 = lrpa2.callto_getparcondicioningreso_2(VICodMedidaSancion);

                    dt_gridsancion = dt3;

                    if (dt3.Rows.Count > 0)
                    {

                        grd_LRPA02.DataSource = dt3;
                        grd_LRPA02.DataBind();
                        grd_LRPA02.Visible = true;
                    }
                    else
                    {
                        grd_LRPA02.Visible = false;
                    }

                }
                if ((codemod != 103) && (codemod != 108))
                {
                    PnlServicio.Visible = false;
                    txt_hservi.Enabled = false;
                    ddown_tipoBC.Enabled = false;
                    ddown_IPSER.Enabled = false;
                    ddown_areaTI.Enabled = false;
                    ddown_repdaño.Enabled = false;
                    ddown_tsancion.Enabled = false;
                    ddown_conIng.Enabled = false;
                    txt_hservi.Text = "0";

                }
                    

                //ddown_conIng.SelectedValue = dtLRPA.Rows[0][23].ToString();



                parcoll pcoll = new parcoll();

                DataView dv2 = new DataView(pcoll.GetparTribunales(dtLRPA.Rows[0][4].ToString(), dtLRPA.Rows[0][5].ToString()));
                ddown005LRPA.Items.Clear();
                ddown005LRPA.DataSource = dv2;
                ddown005LRPA.DataTextField = "Descripcion";
                ddown005LRPA.DataValueField = "CodTribunal";
                dv2.Sort = "Descripcion";
                ddown005LRPA.DataBind();
                ddown005LRPA.Focus();

                ddown005LRPA.SelectedValue = dtLRPA.Rows[0][6].ToString();
                if (dtLRPA.Rows[0][7].ToString() == "1")
                {
                    chk001LRPA.Checked = true;
                    pnl1LRPA.Visible = true;
                    grd001LRPA.Visible = true;
                    btnAgregarTsancionLRPA.Visible = true;
                }
                else
                {
                    chk001LRPA.Checked = false;
                    pnl1LRPA.Visible = false;
                }

                SancionACC();

                ddown006LRPA.SelectedValue = dtLRPA.Rows[0][7].ToString();
                if (Convert.ToDateTime(dtLRPA.Rows[0][16].ToString()) != Convert.ToDateTime("01-01-1900"))
                {
                    ddown007LRPA.Text = Convert.ToDateTime(dtLRPA.Rows[0][16].ToString()).ToShortDateString();
                }
                else
                    ddown007LRPA.Text = "";

                ddown008LRPA.SelectedValue = dtLRPA.Rows[0][10].ToString();
                txt009LRPA.Text = dtLRPA.Rows[0][21].ToString();
                if (Convert.ToDateTime(dtLRPA.Rows[0][14]).ToShortDateString() != "01-01-1900" &&
                     Convert.ToDateTime(dtLRPA.Rows[0][15]).ToShortDateString() != "01-01-1900")
                {
                    Chk002LRPAMixta.Checked = true;
                    pnlLRPAmixta.Visible = true;
                    txt006LRPA.Enabled = false;
                    ddown009LRPA.Text = Convert.ToDateTime(dtLRPA.Rows[0][15]).ToShortDateString(); //Fecha Inicio Sanción:
                    txt005LRPA.Text = dtLRPA.Rows[0][13].ToString();
                    txt004LRPA.Text = dtLRPA.Rows[0][12].ToString();
                    txt008LRPA.Text = dtLRPA.Rows[0][19].ToString();
                    ddown011LRPA.SelectedValue = dtLRPA.Rows[0][20].ToString();
                    txt006LRPA.Text = Convert.ToDateTime(dtLRPA.Rows[0][14]).ToShortDateString();
                }
                else
                {
                    Chk002LRPAMixta.Checked = false;
                    pnlLRPAmixta.Visible = false;
                    ddown009LRPA.Text = "";
                    txt005LRPA.Text = "";
                    txt004LRPA.Text = "";
                    txt008LRPA.Text = "";
                    ddown011LRPA.SelectedValue = "0"; // NO CORRESPONDE
                    txt006LRPA.Text = "";
                }
                #region GRILLA

                DataRow dr;//= DTTipoSancionAccesoria.NewRow();
                
                DTTipoSancionAccesoria.Rows.Clear();
                
                for (int i = 0; i < dtLRPA.Rows.Count; i++)
                {
                    try
                    {
                        dr = DTTipoSancionAccesoria.NewRow();
                        dr[0] = dtLRPA.Rows[i][9].ToString();
                        dr[1] = Convert.ToInt32(dtLRPA.Rows[i][8]);
                        dr[2] = Convert.ToInt32(dtLRPA.Rows[i][11]);
                        DTTipoSancionAccesoria.Rows.Add(dr);
                    }
                    catch
                    {

                    }
                }

                DataView dv = new DataView(DTTipoSancionAccesoria);
                grd001LRPA.DataSource = dv;
                dv.Sort = "CodSancion";
                grd001LRPA.DataBind();
                grd001LRPA.Focus();

                grd001LRPA.Visible = (DTTipoSancionAccesoria.Rows.Count > 0);

                ddown006LRPA.SelectedValue = Convert.ToString(0);
                ddown006LRPA.BackColor = System.Drawing.Color.Empty;
            }
            #endregion
        }
    }

    private void SancionACC()
    {
        LRPAcoll lrpa = new LRPAcoll();
        ddown006LRPA.Items.Clear();
        DataView dv2 = new DataView(lrpa.callto_getpartiposancionaccesoria());

        ddown006LRPA.DataSource = dv2;
        ddown006LRPA.DataTextField = "Descripcion";
        ddown006LRPA.DataValueField = "CodTipoSancionAccesoria";
        dv2.Sort = "Descripcion";
        ddown006LRPA.DataBind();
        ddown006LRPA.Focus();
    }

    #region calculos
    
    private void Calcula_Dias()
    {
        DateTime fechainiciosancion = Convert.ToDateTime("01/01/1900");

        if ((txt_FechaInicioSancionLRPA.Text.ToUpper() != "") && (txt_FechaInicioSancionLRPA.Text.ToUpper() != ""))
        {
            fechainiciosancion = Convert.ToDateTime(txt_FechaInicioSancionLRPA.Text);
            lblfechaini1LRPA.Text = "";

            if (txt001LRPA.Text.Trim() == "" && txt002LRPA.Text.Trim() == "" && txt007LRPA.Text.Trim() == "")
            {
                lbl_avisoDuracionLRPA.Text = "Ingrese al menos un parametro";
                lbl_avisoDuracionLRPA.Visible = true;
            }
            else
            {
                lbl_avisoDuracionLRPA.Visible = false;
                if (txt001LRPA.Text.Trim() == "")
                { txt001LRPA.Text = "0"; }
                if (txt002LRPA.Text.Trim() == "")
                { txt002LRPA.Text = "0"; }
                if (txt007LRPA.Text.Trim() == "")
                { txt007LRPA.Text = "0"; }

                DateTime fechatermino = Convert.ToDateTime(txt_FechaInicioSancionLRPA.Text).AddYears(Convert.ToInt32(txt001LRPA.Text.Trim()));
                fechatermino = fechatermino.AddMonths(Convert.ToInt32(txt002LRPA.Text.Trim()));
                fechatermino = fechatermino.AddDays(Convert.ToInt32(txt007LRPA.Text.Trim()));
                try
                {
                    fechatermino = fechatermino.AddDays(Convert.ToInt32(txt009LRPA.Text.Trim()));
                }
                catch
                {
                    fechatermino = fechatermino.AddDays(0);
                }

                txt003LRPA.Text = fechatermino.ToShortDateString();
                CalendarExtende1030.StartDate = fechatermino;
                CalendarExtende1030.SelectedDate = fechatermino;
                if (ddown009LRPA.Text.ToUpper() != "")
                {
                    ddown009LRPA.Text = Convert.ToDateTime(txt003LRPA.Text).AddDays(1).ToShortDateString();
                    //Calcula_Dias_Mix();
                }
            }


        }
        else
        {
            lblfechaini1LRPA.Text = "Ingrese Fecha de Inicio2";
            txt001LRPA.Text = "";
            txt002LRPA.Text = "";
        }
    }

    private void Calcula_Dias_Mix()
    {
        DateTime fechainiciosancion = Convert.ToDateTime("01/01/1900");
        try
        {
       
            if (ddown009LRPA.Text.ToUpper() != "")
            {
                fechainiciosancion = Convert.ToDateTime(ddown009LRPA.Text);
                lblfechaIni2LRPA.Text = "";

                if (txt004LRPA.Text.Trim() == "" && txt005LRPA.Text.Trim() == "" && txt008LRPA.Text.Trim() == "")
                {
                    lbl_avisoDuracion2LRPA.Text = "Ingrese al menos un parametro";
                    lbl_avisoDuracion2LRPA.Visible = true;
                }
                else
                {
                    lbl_avisoDuracion2LRPA.Visible = false;
                    if (txt004LRPA.Text.Trim() == "")
                    { txt004LRPA.Text = "0"; }
                    if (txt005LRPA.Text.Trim() == "")
                    { txt005LRPA.Text = "0"; }
                    if (txt008LRPA.Text == "")
                    { txt008LRPA.Text = "0"; }

                    DateTime fechatermino = Convert.ToDateTime(ddown009LRPA.Text).AddYears(Convert.ToInt32(txt004LRPA.Text.Trim()));
                    fechatermino = fechatermino.AddMonths(Convert.ToInt32(txt005LRPA.Text.Trim()));
                    try
                    {
                        fechatermino = fechatermino.AddDays(Convert.ToInt32(txt008LRPA.Text.Trim()));
                    }
                    catch
                    {
                        fechatermino = fechatermino.AddDays(0);
                    }
                    txt006LRPA.Text = fechatermino.ToShortDateString();

                    DateTime fechaterminoA = Convert.ToDateTime(txt003LRPA.Text);
                    if (fechatermino > fechaterminoA)
                        CalendarExtende1030.StartDate = fechatermino;
                        CalendarExtende1030.SelectedDate = fechatermino;
                
                }
            }
            else
            {
                lblfechaIni2LRPA.Text = "Ingrese Fecha de Inicio1";
                txt004LRPA.Text = "";
                txt005LRPA.Text = "";
                txt008LRPA.Text = "";

            }
        }
        catch (Exception e)
        {
            lblfechaIni2LRPA.Text = "Revise los datos ingresados";
        }


    }

    private void LimpiaControles()
    {
        txt_FechaInicioSancionLRPA.Text = null;
        ddown003LRPA.SelectedValue = "-2";
        ddown004LRPA.SelectedValue = "0";
        ddown005LRPA.SelectedValue = "0";
        ddown006LRPA.SelectedValue = "0";
        ddown007LRPA.Text = "";
        ddown008LRPA.SelectedValue = "-1";
        ddown009LRPA.Text = "";

        txt001LRPA.Text = "";
        txt002LRPA.Text = "";
        txt003LRPA.Text = "";
        txt004LRPA.Text = "";
        txt005LRPA.Text = "";
        txt006LRPA.Text = "";

        chk001LRPA.Checked = false;
        Chk002LRPAMixta.Checked = false;

        ddown006LRPA.Visible = false;
        btnAgregarTsancionLRPA.Visible = false;

        DataTable dt = new DataTable();
        dt.Rows.Clear();
        grd001LRPA.DataSource = dt;
        grd001LRPA.DataBind();
    }

    #endregion

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        txt001LRPA.Text= "";
        txt002LRPA.Text = "";
        txt007LRPA.Text = "";
        txt009LRPA.Text = "";
        txt001LRPA.Enabled = false;
        txt002LRPA.Enabled = false;
        txt007LRPA.Enabled = false;
        txt009LRPA.Enabled = false;

        grd_LRPA02.DataSource = dt_coning;
        grd_LRPA02.DataBind();
        grd_LRPA02.Visible = true;
        txt_hservi.Text = "";
        if (ddown_areaTI.SelectedValue == "-2")
        {
            ddown_areaTI.SelectedValue = "-2";
        }
        else
        {
            ddown_areaTI.SelectedValue = "0";
        }

        if (ddown_IPSER.SelectedValue == "-2")
        {
            ddown_IPSER.SelectedValue = "-2";
        }
        else
        {
            ddown_IPSER.SelectedValue = "0";
        }


        if (ddown_repdaño.SelectedValue == "-2")
        {
            ddown_repdaño.SelectedValue = "-2";
        }
        else
        {
            ddown_repdaño.SelectedValue = "0";

        }

        if (ddown_tipoBC.SelectedValue == "-2")
        {
            ddown_tipoBC.SelectedValue = "-2";
        }else{
            ddown_tipoBC.SelectedValue = "0";
        }

        if (ddown_tsancion.SelectedValue == "-2")
        {
            ddown_tsancion.SelectedValue = "-2";
        }else{
            ddown_tsancion.SelectedValue = "0";
        }

        btn_GuardarLRPA.Text = "Guardar";
        btn_GuardarLRPA.Visible = true;
        LimpiaControles();
        lbl_aviso2LRPA.Visible = false;
        lbl_aviso_graba.Visible = false;
        pnlLRPAmixta.Visible = false;
        //gmp Panel3.Visible = false;
        pnldatos.Visible = true;
        Lbl_mensaje001.Visible = false;

        ninocoll nin = new ninocoll();
        int codmodelo = nin.callto_get_codmodelointervencion(SSnino.CodProyecto);

        if (codmodelo == 108)
        {

            dt_coning.Clear();

            if (ddown_conIng.SelectedValue == "3")
            {
                opcact = true;
            }
            else
            {
                opcact = false;

            }
        }
        else if (codmodelo == 103)
        {
            ddown_conIng.Enabled = false;
        }
        else //if ((codmodelo != 103) & (codmodelo != 108))
        {
            ddown_areaTI.Enabled = false;
            ddown_IPSER.Enabled = false;
            ddown_tipoBC.Enabled = false;
            ddown_repdaño.Enabled = false;
            ddown_conIng.Enabled = false;

        }
        MuestraTab();
    }

    protected void Chk002LRPAMixta_CheckedChanged(object sender, EventArgs e)
    {
        LblfechaLRPA.Text = "";

        if (Chk002LRPAMixta.Checked)
        {
            if (txt003LRPA.Text.Trim() != "")
            {
                LblfechaLRPA.Text = "";
                LblfechaLRPA.Visible = false;
                //ddown009LRPA.Text = Convert.ToDateTime(txt003LRPA.Text).AddDays(1).ToShortDateString();
                //ddown009LRPA.Enabled = false;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "ObtenerFechaTerminoSancionMixta()", true);
                
                pnlLRPAmixta.Visible = true;
            }
            else
            {
                LblfechaLRPA.Text = "Ingrese fecha de primera sanción";
                LblfechaLRPA.Visible = true;
                Chk002LRPAMixta.Checked = false;

                pnlLRPAmixta.Visible = false;
                txt004LRPA.Text = "";
                txt005LRPA.Text = "";
                txt008LRPA.Text = "";
                txt006LRPA.Text = "";
                
            }
                       
        }
        else
        {
            LblfechaLRPA.Visible = false;
            pnlLRPAmixta.Visible = false;
            txt004LRPA.Text = "";
            txt005LRPA.Text = "";
            txt008LRPA.Text = "";
            txt006LRPA.Text = "";
        }
        //Chk002LRPAMixta.Focus();
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 700 }, 2000);", true);
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "errorFecha", "validaFecha();", true);
    }
    protected void lnk002_Click(object sender, EventArgs e)
    {
        Calcula_Dias_Mix();
    }

    protected void ddown_repdaño_SelectedIndexChanged(object sender, EventArgs e)
    {

        opcact =  (ddown_repdaño.SelectedValue == "3");

        if (SHORAS == "0" || SHORAS == "")
        {
            lbl_mensaje002.Text = "Debe Ingresar Horas de Servicio Comunitario";
        }
        else
        {
            lbl_mensaje002.Text = "";
            lbl_mensaje002.Visible = false;
        }

        if (opcact) /// se da cuando la opcion reparacion es igual a 3
        {
            ddown_areaTI.SelectedValue = AREATI;
            ddown_IPSER.SelectedValue = IPSER;
            ddown_tipoBC.SelectedValue = TIPOBC;
            txt_hservi.Text = SHORAS;
        }

        lbl_mensaje002.Visible = false;
    }
     
    protected void btnnext(object sender, EventArgs e)
    {

    }
    private void GetMedida()
    {

        LRPAcoll LRPA = new LRPAcoll();
        DataTable dtLRPA = new DataTable();
        dtLRPA = LRPA.callto_get_sancionesbycodmedidasancion(SSnino.ICodIE);
        DataTable dtOT = LRPA.GetICodTribunalIngreso_LRPA(SSnino.ICodIE);
        pnldatos.Visible = false;
        if (dtLRPA.Rows.Count > 0)
        {
            grdseleccionLRPA.DataSource = dtLRPA;
            grdseleccionLRPA.DataBind();
            grdseleccionLRPA.Visible = true;            
        }

        if (dtOT.Rows.Count > 0)
        {
            ddl_OrdenDeTribunal_MedidaSancion.Items.Clear();
            ddl_OrdenDeTribunal_MedidaSancion.DataSource = dtOT;
            ddl_OrdenDeTribunal_MedidaSancion.DataTextField = "Descripcion";
            ddl_OrdenDeTribunal_MedidaSancion.DataValueField = "ICodTribunalIngreso";
            ddl_OrdenDeTribunal_MedidaSancion.DataBind();
        }

        ddown011LRPA.Items.Clear();
        LRPAcoll lrpa = new LRPAcoll();
        DataTable dt = lrpa.callto_get_parmodelosancionmixta();
        ddown011LRPA.DataSource = dt;
        ddown011LRPA.DataTextField = "Descripcion";
        ddown011LRPA.DataValueField = "CodModeloSancionMixta";
        ddown011LRPA.DataBind();


    }
    protected void btn_GuardarLRPA_Click(object sender, EventArgs e)
    {
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9");
        bool msjtrue = false;
        int tipo_bc = 0;
        int ip_ser = 0;
        int area_ti = 0;
        int rep_daño = 0;

        #region LRPA

        string msj = "";
        #region Validacion
        bool swLRPA = true;
        bool chk = false;

        ninocoll nin = new ninocoll();
        int codmodelo = nin.callto_get_codmodelointervencion(SSnino.CodProyecto);

        //Asignar cero a los campos que vienen en blanco de fechas

        chk = (txt001LRPA.Text.Trim() != "" ||
                txt002LRPA.Text.Trim() != "" ||
                txt007LRPA.Text.Trim() != "" ||
                txt_FechaInicioSancionLRPA.Text.ToUpper() != "" ||
                ddown003LRPA.SelectedValue != Convert.ToString(-2) ||
                ddown004LRPA.SelectedValue != Convert.ToString(0) ||
                ddown005LRPA.SelectedValue != Convert.ToString(0) ||
                chk001LRPA.Checked == true) || (codmodelo == 103);

        chk = (btn_GuardarLRPA.Text == "Guardar");

        if (chk)
        {
            if (codmodelo == 108)
            {
                if (txt_hservi.Text == "" || txt_hservi.Text == "")///horas
                {
                    txt_hservi.BackColor = colorCampoObligatorio;
                    swLRPA = false;
                }
                else txt_hservi.BackColor = System.Drawing.Color.Empty;


                if (grd_LRPA02.Rows.Count == 0) {///Area Trabajo 
                    lblbmsg.Visible = true;
                    lblbmsg.Text = "Debe Ingresar a lo menos una de las siguientes opciones (C , D, H)";
                    ddown_conIng.BackColor = colorCampoObligatorio;
                    swLRPA = false;
                }
                else {
                    lblbmsg.Visible = false;
                    ddown_conIng.BackColor = System.Drawing.Color.Empty;
                }

                if (ddown_tsancion.SelectedValue == "0") {
                
                    ddown_tsancion.BackColor = colorCampoObligatorio;
                    swLRPA = false;
                }
                else ddown_tsancion.BackColor = System.Drawing.Color.Empty;

                if (ddown_tipoBC.SelectedValue == "0") 
                {
                    ddown_tipoBC.BackColor = colorCampoObligatorio;
                    swLRPA = false;
                }
                else ddown_tipoBC.BackColor = System.Drawing.Color.Empty;
            }


            //////////////////seccion 2/////////////////////
            if (codmodelo == 103)
            {
                if (txt_hservi.Text == "" || txt_hservi.Text == "") { ///horas
                
                    txt_hservi.BackColor = colorCampoObligatorio;
                    swLRPA = false;
                }
                else txt_hservi.BackColor = System.Drawing.Color.Empty;

                if (ddown_tsancion.SelectedValue == "0") { ///Area Trabajo
                    ddown_tsancion.BackColor = colorCampoObligatorio;
                    swLRPA = false;
                }
                else ddown_tsancion.BackColor = System.Drawing.Color.Empty;

                if (ddown_tipoBC.SelectedValue == "0") { 
                    ddown_tipoBC.BackColor = colorCampoObligatorio;
                    swLRPA = false;
                }
                else ddown_tipoBC.BackColor = System.Drawing.Color.Empty;
            }

            /////////////108////////////////
            if (codmodelo == 108)//////aqui////
            {
                bool grdval = false;
                DataRow dr = dt_coning.NewRow();

                if (grd_LRPA02.Rows.Count != 0)
                {
                    for (int i = 0; i < grd_LRPA02.Rows.Count; i++)
                    {
                        if (grd_LRPA02.Rows[i].Cells[0].Text == Convert.ToString(3) || grd_LRPA02.Rows[i].Cells[0].Text == Convert.ToString(4) || grd_LRPA02.Rows[i].Cells[0].Text == Convert.ToString(8))
                        {

                            if (grd_LRPA02.Rows[i].Cells[0].Text == Convert.ToString(3))
                            { grdval = true; }
                            if (grd_LRPA02.Rows[i].Cells[0].Text == Convert.ToString(4))
                            { grdval = true; }
                            if (grd_LRPA02.Rows[i].Cells[0].Text == Convert.ToString(8))
                            { grdval = true; }

                            // i = grd_LRPA02.Rows.Count + 1;
                            ddown_conIng.BackColor = System.Drawing.Color.Empty;
                            lblbmsg.Visible = false;
                        }
                    }
                    if (grdval) {
                        ddown_conIng.BackColor = System.Drawing.Color.Empty;
                        lblbmsg.Visible = false;
                    }
                    else {
                        ddown_conIng.BackColor = colorCampoObligatorio;
                        swLRPA = false;
                        lblbmsg.Visible = true;
                        lblbmsg.Text = "Debe Ingresar a lo menos una de las siguientes opciones (C, D, H)";
                    }
                }
                else
                {
                    ddown_conIng.BackColor = colorCampoObligatorio;
                    swLRPA = false;
                }
            }
            ////////////////////// fin 108

            ///
            if (codmodelo != 103)
            {
                if (txt003LRPA.Text.Trim() == "") {
                    txt003LRPA.BackColor = colorCampoObligatorio;
                    swLRPA = false;
                    //txt003LRPA.Text = "0";
                    
                }
                else txt003LRPA.BackColor = System.Drawing.Color.Empty;

                if (txt007LRPA.Text.Trim() == "") {
                    //txt007LRPA.BackColor = colorCampoObligatorio;
                    //swLRPA = false;
                    txt007LRPA.Text = "0";
                }
                else txt007LRPA.BackColor = System.Drawing.Color.Empty;

                if (txt001LRPA.Text.Trim() == "") {
                    //txt001LRPA.BackColor = colorCampoObligatorio;
                    //swLRPA = false;
                    txt001LRPA.Text = "0";
                }
                else txt001LRPA.BackColor = System.Drawing.Color.Empty;

                if (txt002LRPA.Text.Trim() == "") {
                    //txt002LRPA.BackColor = colorCampoObligatorio;
                    //swLRPA = false;
                    txt002LRPA.Text = "0";
                }
                else txt002LRPA.BackColor = System.Drawing.Color.Empty;

                if (txt_FechaInicioSancionLRPA.Text.ToUpper() == "") {
                    txt_FechaInicioSancionLRPA.BackColor = colorCampoObligatorio;
                    swLRPA = false;
                }
                else txt_FechaInicioSancionLRPA.BackColor = System.Drawing.Color.Empty;

                if (ddown003LRPA.SelectedValue == Convert.ToString(-2)) {
                    ddown003LRPA.BackColor = colorCampoObligatorio;
                    swLRPA = false;
                }
                else ddown003LRPA.BackColor = System.Drawing.Color.Empty;

                //txt001LRPA,txt002LRPA,txt007LRPA,txt004LRPA,txt005LRPA

                if (txt001LRPA.Text == "0" && txt002LRPA.Text == "0" && txt007LRPA.Text == "0")
                {
                    txt001LRPA.BackColor = colorCampoObligatorio;
                    txt002LRPA.BackColor = colorCampoObligatorio;
                    txt007LRPA.BackColor = colorCampoObligatorio;
                    txt001LRPA.Text = "";
                    txt002LRPA.Text = "";
                    txt007LRPA.Text = "";                    
                    swLRPA = false;
                }
                else
                {
                    txt001LRPA.BackColor = System.Drawing.Color.Empty;
                    txt002LRPA.BackColor = System.Drawing.Color.Empty;
                    txt007LRPA.BackColor = System.Drawing.Color.Empty;
                }
            }
            else
            {
                if (txt_FechaInicioSancionLRPA.Text.ToUpper() == "") {
                    txt_FechaInicioSancionLRPA.BackColor = colorCampoObligatorio;
                    swLRPA = false;
                }
                else txt_FechaInicioSancionLRPA.BackColor = System.Drawing.Color.Empty;
            }
        }

        if (Chk002LRPAMixta.Checked == true)
        {
            if (txt004LRPA.Text == "") {                
                txt004LRPA.Text = "0";
            }
            else txt004LRPA.BackColor = System.Drawing.Color.Empty;

            if (txt005LRPA.Text == "") {               
                txt005LRPA.Text = "0";
            }
            else txt005LRPA.BackColor = System.Drawing.Color.Empty;

            if (txt008LRPA.Text == "")
            {
                txt008LRPA.Text = "0";
            }
            else txt008LRPA.BackColor = System.Drawing.Color.Empty;

            if (txt006LRPA.Text == "") {
                txt006LRPA.BackColor = colorCampoObligatorio;
                swLRPA = false;
            }
            else txt006LRPA.BackColor = System.Drawing.Color.Empty;

            if (ddown009LRPA.Text.ToUpper() == "") {
                ddown009LRPA.BackColor = colorCampoObligatorio;
                swLRPA = false;
            }
            else ddown009LRPA.BackColor = System.Drawing.Color.Empty;

            if (txt004LRPA.Text == "0" && txt005LRPA.Text == "0" && txt008LRPA.Text == "0")
            {
                txt004LRPA.BackColor = colorCampoObligatorio;
                txt005LRPA.BackColor = colorCampoObligatorio;
                txt008LRPA.BackColor = colorCampoObligatorio;
                txt004LRPA.Text = "";
                txt005LRPA.Text = "";
                txt008LRPA.Text = "";
                swLRPA = false;
            }
            else
            {
                txt004LRPA.BackColor = System.Drawing.Color.Empty;
                txt005LRPA.BackColor = System.Drawing.Color.Empty;
                txt008LRPA.BackColor = System.Drawing.Color.Empty;
            }
        }

        if (ddl_OrdenDeTribunal_MedidaSancion.SelectedValue == "0") {
            ddl_OrdenDeTribunal_MedidaSancion.BackColor = colorCampoObligatorio;
            swLRPA = false;
        }
        else ddl_OrdenDeTribunal_MedidaSancion.BackColor = System.Drawing.Color.Empty;

        if (chk001LRPA.Checked) //------------------Sanción Accesoria (Sí)
        {
            if (DTTipoSancionAccesoria.Rows.Count == 0)
            {
                if (ddown006LRPA.SelectedValue == Convert.ToString(0)) {
                    ddown006LRPA.BackColor = colorCampoObligatorio;
                    swLRPA = false;
                }
                else ddown006LRPA.BackColor = System.Drawing.Color.Empty;

                try
                {
                    if (DTTipoSancionAccesoria.Rows.Count >= 0) {
                        lbl_avisoLRPA.Text = "";
                    }
                    else {
                        lbl_avisoLRPA.Text = "Debe ingresar una sación accesoria";
                        lbl_avisoLRPA.Visible = true;
                        swLRPA = false;
                    }
                }
                catch
                {
                    lbl_avisoLRPA.Text = "Debe ingresar una sación accesoria";
                    lbl_avisoLRPA.Visible = true;
                    swLRPA = false;
                }
            }
        }
        //----------------- Fecha de Termino Sanción:
        if (ddown007LRPA.Text.ToUpper() != "" || ddown008LRPA.SelectedValue != "-1")
        {
            if (ddown007LRPA.Text.ToUpper() == "")
            {
                if (ddown008LRPA.SelectedValue == "-1") {
                    ddown007LRPA.BackColor = System.Drawing.Color.Empty;
                }
                else {
                    swLRPA = false;
                    ddown007LRPA.BackColor = colorCampoObligatorio;
                }
            }
            else if (ddown008LRPA.SelectedValue == "-1")
            {
                if (ddown007LRPA.Text.ToUpper() == "") {
                    ddown008LRPA.BackColor = System.Drawing.Color.Empty;
                }
                else {
                    swLRPA = false;
                    ddown008LRPA.BackColor = colorCampoObligatorio;
                }
            }
        }

        DateTime TerminoSancion;
        try
        {
            TerminoSancion = (ddown007LRPA.Text.ToUpper() == "") ? Convert.ToDateTime("01-01-1900") : Convert.ToDateTime(ddown007LRPA.Text);
        }
        catch {
            TerminoSancion = Convert.ToDateTime("01-01-1900");
        }

        int situacionTermino = 0;
        situacionTermino = (ddown008LRPA.SelectedValue == "0")?-1:Convert.ToInt32(ddown008LRPA.SelectedValue);

        # endregion

        if (swLRPA)
        {
            if (btn_GuardarLRPA.Text == "Modificar")
            {

                #region Modificar
                
                LRPAcoll LRPA = new LRPAcoll();
                /////////////////////////////////////UPDATE PARA CODMODELO 103 Y 108///////////////
                if (codmodelo == 103 || codmodelo == 108)
                {
                    if (codmodelo == 103)
                    {
                        horas = Convert.ToInt32(txt_hservi.Text);
                        tipo_bc = Convert.ToInt32(ddown_tipoBC.SelectedValue);
                        ip_ser = Convert.ToInt32(ddown_IPSER.SelectedValue);
                        area_ti = Convert.ToInt32(ddown_areaTI.SelectedValue);
                        rep_daño = Convert.ToInt32(ddown_repdaño.SelectedValue);
                    }
                    else if (codmodelo == 108)
                    {
                        if (ddown_repdaño.SelectedValue != "3") //------------Tipo Reparación Daño
                        {
                            horas = Convert.ToInt32(txt_hservi.Text);
                            tipo_bc = Convert.ToInt32(ddown_tipoBC.SelectedValue);
                            ip_ser = Convert.ToInt32(ddown_IPSER.SelectedValue);
                            area_ti = Convert.ToInt32(ddown_areaTI.SelectedValue);
                            rep_daño = Convert.ToInt32(ddown_repdaño.SelectedValue);
                        }
                        else
                        {
                            horas = Convert.ToInt32(txt_hservi.Text);
                            tipo_bc = Convert.ToInt32(ddown_tipoBC.SelectedValue);
                            ip_ser = Convert.ToInt32(ddown_IPSER.SelectedValue);
                            area_ti = Convert.ToInt32(ddown_areaTI.SelectedValue);
                            rep_daño = Convert.ToInt32(ddown_repdaño.SelectedValue);
                        }
                    }

                    int MesDuracionMix = 0;
                    int AnoDuracionMix = 0;
                    int DiaDuracionMix = 0;
                    int codTerminoSancion = -1;
                    DateTime FechaTerminoMix = Convert.ToDateTime("01-01-1900");
                    DateTime FechaInicioMix = Convert.ToDateTime("01-01-1900");

                    if (txt008LRPA.Text.Trim() != "") DiaDuracionMix = Convert.ToInt32(txt008LRPA.Text.Trim()); 

                    if (txt005LRPA.Text.Trim() != "") MesDuracionMix = Convert.ToInt32(txt005LRPA.Text.Trim()); 
                    if (txt004LRPA.Text.Trim() != "") AnoDuracionMix = Convert.ToInt32(txt004LRPA.Text.Trim()); 

                    if (ddown008LRPA.SelectedValue != "-1") codTerminoSancion = Convert.ToInt32(ddown008LRPA.SelectedValue);

                    if (Chk002LRPAMixta.Checked)
                    {
                        if (txt006LRPA.Text.Trim() != "") FechaTerminoMix = Convert.ToDateTime(txt006LRPA.Text.Trim());
                        if (ddown009LRPA.Text.ToUpper() != "") FechaInicioMix = Convert.ToDateTime(ddown009LRPA.Text.Trim());
                    }

                    DateTime FechaTerminoSansion = Convert.ToDateTime("01-01-1900");
                    if (ddown007LRPA.Text.ToUpper() != "") FechaTerminoSansion = Convert.ToDateTime(ddown007LRPA.Text);


                    LRPA.callto_update_tipomedidassancioneslrpa_2(VICodMedidaSancion, Convert.ToDateTime(txt_FechaInicioSancionLRPA.Text),
                        Convert.ToDateTime(txt003LRPA.Text), Convert.ToInt32(txt002LRPA.Text), Convert.ToInt32(txt001LRPA.Text),
                        Convert.ToInt32(ddown005LRPA.SelectedValue), Convert.ToInt32(chk001LRPA.Checked), Convert.ToInt32(Session["IdUsuario"]),
                        DateTime.Now, codTerminoSancion, MesDuracionMix, AnoDuracionMix, FechaTerminoMix, FechaInicioMix,
                        FechaTerminoSansion, Convert.ToInt32(ddl_OrdenDeTribunal_MedidaSancion.SelectedValue), Convert.ToInt32(txt007LRPA.Text.Trim()), DiaDuracionMix,
                        Convert.ToInt32(ddown011LRPA.SelectedValue), Convert.ToInt32(txt009LRPA.Text.Trim()),
                        horas, Convert.ToInt32(ddown_tsancion.SelectedValue), tipo_bc, ip_ser, area_ti, rep_daño);

                    msj = "Los Datos fueron Actualizados exitosamente";
                    msjtrue = true;
                    if (chk001LRPA.Checked == true)
                        for (int i = 0; i < grd001LRPA.Rows.Count; i++)
                        {
                            LRPAcoll LRPA3 = new LRPAcoll();
                            LRPA3.callto_update_tiposancionaccesoria(Convert.ToInt32(grd001LRPA.Rows[i].Cells[1].Text), VICodMedidaSancion);
                        }
                    
                    ////////UPDATE CONDICION INGRESO/////
                    if (codmodelo == 108)
                        for (int i = 0; i < dt_coning.Rows.Count; i++)
                        {
                            LRPAcoll LRPA2 = new LRPAcoll();
                            LRPA2.callto_update_NemotecnicoLRPA(Convert.ToInt32(dt_coning.Rows[i][0]), VICodMedidaSancion);
                        }
                }
                else
                {
                    if (txt_hservi.Text == "" || txt_hservi.Text == "0" || txt_hservi.Text == "-1")
                    {
                        SHORAS = "0";
                    }

                    int MesDuracionMix = 0;
                    int AnoDuracionMix = 0;
                    int DiaDuracionMix = 0;
                    int codTerminoSancion = -1;
                    DateTime FechaTerminoMix = Convert.ToDateTime("01-01-1900");
                    DateTime FechaInicioMix = Convert.ToDateTime("01-01-1900");
                    if (txt008LRPA.Text.Trim() != "") DiaDuracionMix = Convert.ToInt32(txt008LRPA.Text.Trim()); 
                    if (txt005LRPA.Text.Trim() != "") MesDuracionMix = Convert.ToInt32(txt005LRPA.Text.Trim()); 
                    if (txt004LRPA.Text.Trim() != "") AnoDuracionMix = Convert.ToInt32(txt004LRPA.Text.Trim()); 

                    if (ddown008LRPA.SelectedValue != "-1") codTerminoSancion = Convert.ToInt32(ddown008LRPA.SelectedValue); 

                    if (txt006LRPA.Text.Trim() != "") FechaTerminoMix = Convert.ToDateTime(txt006LRPA.Text.Trim()); 
                    if (ddown009LRPA.Text.ToUpper() != "") FechaInicioMix = Convert.ToDateTime(ddown009LRPA.Text.Trim()); 

                    DateTime FechaTerminoSansion = Convert.ToDateTime("01-01-1900");
                    if (ddown007LRPA.Text.ToUpper() != "") FechaTerminoSansion = Convert.ToDateTime(ddown007LRPA.Text);

                    LRPA.callto_update_tipomedidassancioneslrpa
                        (VICodMedidaSancion,
                        Convert.ToDateTime(txt_FechaInicioSancionLRPA.Text),
                        Convert.ToDateTime(txt003LRPA.Text),
                        Convert.ToInt32(txt002LRPA.Text),
                        Convert.ToInt32(txt001LRPA.Text),
                        Convert.ToInt32(ddown005LRPA.SelectedValue),
                        Convert.ToInt32(chk001LRPA.Checked),
                        Convert.ToInt32(Session["IdUsuario"]),
                        DateTime.Now, codTerminoSancion,
                        MesDuracionMix,
                        AnoDuracionMix,
                        FechaTerminoMix,
                        FechaInicioMix,
                        FechaTerminoSansion,
                        Convert.ToInt32(ddl_OrdenDeTribunal_MedidaSancion.SelectedValue),
                        Convert.ToInt32(txt007LRPA.Text.Trim()),
                        DiaDuracionMix,
                        Convert.ToInt32(ddown011LRPA.SelectedValue),
                        Convert.ToInt32(txt009LRPA.Text.Trim()),
                        Convert.ToInt32(SHORAS));

                    msj = "Los Datos fueron Actualizados exitosamente";
                    msjtrue = true;
                    if (chk001LRPA.Checked)
                        for (int i = 0; i < grd001LRPA.Rows.Count; i++)
                            LRPA.callto_update_tiposancionaccesoria(Convert.ToInt32(grd001LRPA.Rows[i].Cells[1].Text), VICodMedidaSancion);
                }
                #endregion
            }
            else if (btn_GuardarLRPA.Text == "Guardar")
            {
                #region  Guardar
                
                if (codmodelo == 103 || codmodelo == 108)
                {
                    if (codmodelo == 103)
                    {
                        rep_daño = 0;
                        horas = 0;
                        tipo_bc = 0;
                        area_ti = 0;
                        ip_ser = 0;
                    } else  if (codmodelo == 108)
                    {
                        if (ddown_repdaño.SelectedValue != "3")
                        {
                            horas = Convert.ToInt32(txt_hservi.Text);
                            tipo_bc = Convert.ToInt32(ddown_tipoBC.SelectedValue);
                            ip_ser = Convert.ToInt32(ddown_IPSER.SelectedValue);
                            area_ti = Convert.ToInt32(ddown_areaTI.SelectedValue);
                            rep_daño = Convert.ToInt32(ddown_repdaño.SelectedValue);
                        }
                        else
                        {
                            horas = Convert.ToInt32(txt_hservi.Text);
                            tipo_bc = Convert.ToInt32(ddown_tipoBC.SelectedValue);
                            ip_ser = Convert.ToInt32(ddown_IPSER.SelectedValue);
                            area_ti = Convert.ToInt32(ddown_areaTI.SelectedValue);
                            rep_daño = Convert.ToInt32(ddown_repdaño.SelectedValue);
                        }
                    }
                }
                #endregion

                #region Agregar
                int inden;
                int LRPA009 = 0;

                int MesDuracionMix = 0;
                int AnoDuracionMix = 0;
                int DiaDuracionMix = 0;
                DateTime FechaTerminoMix = Convert.ToDateTime("01-01-1900");
                DateTime FechaInicioMix = Convert.ToDateTime("01-01-1900");

                MesDuracionMix = (txt005LRPA.Text.Trim() == "")?0:Convert.ToInt32(txt005LRPA.Text.Trim());

                AnoDuracionMix = (txt004LRPA.Text.Trim() == "")?0:Convert.ToInt32(txt004LRPA.Text.Trim());

                FechaTerminoMix = (txt006LRPA.Text.Trim() == "")?Convert.ToDateTime("01-01-1900"):Convert.ToDateTime(txt006LRPA.Text.Trim());


                if (txt008LRPA.Text.Trim() != "") DiaDuracionMix = Convert.ToInt32(txt008LRPA.Text.Trim());

                if (ddown009LRPA.Text.ToUpper() != "" ) FechaInicioMix = Convert.ToDateTime(ddown009LRPA.Text.Trim());

                DateTime FechaTerminoSansion = Convert.ToDateTime("01-01-1900");
                if (ddown007LRPA.Text.ToUpper() != "") FechaTerminoSansion = Convert.ToDateTime(ddown007LRPA.Text);

                if (codmodelo == 108) {
                    if (ddown_repdaño.SelectedValue == "3")///////solo es obligatorio para valor 3
                    {
                        horas = Convert.ToInt32(txt_hservi.Text);
                        rep_daño = Convert.ToInt32(ddown_repdaño.SelectedValue);
                    }
                    else
                    {
                        horas = Convert.ToInt32(txt_hservi.Text);
                        rep_daño = Convert.ToInt32(ddown_repdaño.SelectedValue);
                    }
                } else if (codmodelo == 103) {
                    horas = (Convert.ToString(txt_hservi.Text) == "0" || Convert.ToString(txt_hservi.Text) == "") ?Convert.ToInt32(0):Convert.ToInt32(txt_hservi.Text);
                    rep_daño = Convert.ToInt32(ddown_repdaño.SelectedValue);
                }


                if (codmodelo == 103 || codmodelo == 108)
                {
                    if (txt009LRPA.Text == "")
                    {
                        txt009LRPA.Text = "0";
                    }
                    if (txt007LRPA.Text == "")
                    {
                        txt007LRPA.Text = "0";
                    }
                    if (txt002LRPA.Text == "")
                    {
                        txt002LRPA.Text = "0";
                    }

                    if (txt001LRPA.Text == "")
                    {
                        txt001LRPA.Text = "0";
                    }



                    LRPAcoll LRPA = new LRPAcoll();
                    inden = LRPA.callto_insert_tipomedidassanciones2
                        (SSnino.ICodIE,
                        Convert.ToDateTime(txt_FechaInicioSancionLRPA.Text),
                         Convert.ToDateTime(txt003LRPA.Text),
                         Convert.ToInt32(txt002LRPA.Text),
                         Convert.ToInt32(txt001LRPA.Text),
                         Convert.ToInt32(ddown005LRPA.SelectedValue),
                         Convert.ToInt32(chk001LRPA.Checked),
                         Convert.ToInt32(Session["IdUsuario"]),
                         DateTime.Now,
                         -1,
                         Convert.ToInt32(ddown003LRPA.SelectedValue),
                         Convert.ToInt32(ddown004LRPA.SelectedValue),
                         MesDuracionMix,
                         AnoDuracionMix,
                         FechaTerminoMix,
                         FechaInicioMix,
                         FechaTerminoSansion,
                         Convert.ToInt32(ddl_OrdenDeTribunal_MedidaSancion.SelectedValue),
                         Convert.ToInt32(txt007LRPA.Text), DiaDuracionMix,
                         Convert.ToInt32(ddown011LRPA.SelectedValue),
                         Convert.ToInt32(txt009LRPA.Text.Trim()),

                         Convert.ToInt32(horas),              //Horas solo para PSA y Con Rep Daño
                         Convert.ToInt32(ddown_tsancion.SelectedValue),//SBC Y PSA
                         Convert.ToInt32(ddown_tipoBC.SelectedValue),  //SBC
                         Convert.ToInt32(ddown_IPSER.SelectedValue),   //SBC
                         Convert.ToInt32(ddown_areaTI.SelectedValue),  //SBC
                         Convert.ToInt32(rep_daño));

                    if (chk001LRPA.Checked) //---------------Sanción Accesoria (Sí)
                    {
                        for (int i = 0; i < DTTipoSancionAccesoria.Rows.Count; i++)
                        {
                            LRPA.callto_insert_tiposancionaccesoria((Convert.ToInt32(DTTipoSancionAccesoria.Rows[i][1])), inden);
                        }
                        msj = "Los Datos fueron Ingresados exitosamente";
                        msjtrue = true;
                    }

                    if (codmodelo == 108)
                    {
                        for (int i = 0; i < dt_coning.Rows.Count; i++)
                        {
                            LRPAcoll LRPA4 = new LRPAcoll();
                            LRPA4.Insert_NemoTecnicoLRPA(Convert.ToString(dt_coning.Rows[i][0]), inden);
                        }
                    }

                }
                else
                {
                    
                    if (txt009LRPA.Text == "")
                    {
                        LRPA009 = 0;
                    }

                    LRPAcoll LRPA = new LRPAcoll();
                    inden = LRPA.callto_insert_tipomedidassanciones2
                        (SSnino.ICodIE, //int
                        Convert.ToDateTime(txt_FechaInicioSancionLRPA.Text),
                         Convert.ToDateTime(txt003LRPA.Text),
                         Convert.ToInt32(txt002LRPA.Text),
                         Convert.ToInt32(txt001LRPA.Text),
                         Convert.ToInt32(ddown005LRPA.SelectedValue),
                         Convert.ToInt32(chk001LRPA.Checked),
                         Convert.ToInt32(Session["IdUsuario"]),
                         DateTime.Now,
                         -1,
                         Convert.ToInt32(ddown003LRPA.SelectedValue),
                         Convert.ToInt32(ddown004LRPA.SelectedValue),
                         MesDuracionMix,
                         AnoDuracionMix,
                         FechaTerminoMix,
                         FechaInicioMix,
                         FechaTerminoSansion,
                         Convert.ToInt32(ddl_OrdenDeTribunal_MedidaSancion.SelectedValue),
                         Convert.ToInt32(txt007LRPA.Text), 
                         DiaDuracionMix,
                         Convert.ToInt32(ddown011LRPA.SelectedValue),
                         LRPA009,
                         //Convert.ToInt32(txt009LRPA.Text.Trim()),
                         //Convert.ToInt32(LRPA009),

                        ////////////////////NUEVOS DATOS///////////////////
                         0,   //Horas solo para PSA y Con Rep Daño
                         0,   //SBC Y PSA
                         0,   //SBC
                         0,   //SBC
                         0,   //SBC
                         0   //PSA

                         //////////////////////////////////////////////////
                         );
                    //inden = LRPA.callto_insert_tipomedidassanciones2(
                    //    icodie,
                    //    fechainicio, 
                    //    fechatermino,
                    //    mesduracion,
                    //    anoduracion,
                    //    codtibunal,
                    //    sancionaccesoria,
                    //    idusuarioactualizacion,
                    //    fechaactualizacion,
                    //    codterminosancion,
                    //    codregion, codtipotribunal,
                    //    mesduracionmix,
                    //    anoduracionmix,
                    //    fechaterminomix,
                    //    fechainiciomix,
                    //    fechaterminosansion,
                    //    icodtribunalingreso,
                    //    diaduracion,
                    //    diaduracionmixta,
                    //    codmodelosancionmixta,
                    //    bono,
                    //    horas,
                    //    tsancion,
                    //    tipobc,
                    //    ip_ser,
                    //    areaTI);
                    msj = "Los Datos fueron Ingresados exitosamente";
                    msjtrue = true;
                    if (chk001LRPA.Checked) //-------------Sanción Accesoria (Sí)
                    {
                        for (int i = 0; i < DTTipoSancionAccesoria.Rows.Count; i++)
                        {
                            LRPA.callto_insert_tiposancionaccesoria((Convert.ToInt32(DTTipoSancionAccesoria.Rows[i][1])), inden);
                        }
                        msj = "Los Datos fueron Ingresados exitosamente";
                        msjtrue = true;
                    }
                }

                #endregion
            }////// FIN ELSE
            //SetFocus(dd_foco3);
            //dd_foco3.Focus();
            //Panel3.Visible = true;
            pnldatos.Visible = false;
            GetMedida();
        }
        else
        {
            msjtrue = false;
            msj = "Información erronea favor revisar datos ingresados.";
            //SetFocus(dd_foco3);
            //dd_foco3.Focus();
        }

        if (msj.Length > 0)
        {
            if (msjtrue)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "document.getElementById('alert2').style.display = ''; document.getElementById('lbl00552').style.display = ''; document.getElementById('lbl00552').innerHTML = '" + msj + "'; ", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "", "document.getElementById('alert').style.display = ''; document.getElementById('lbl0055').style.display = ''; document.getElementById('lbl0055').innerHTML = '" + msj + "'; ", true);
            }            
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "", "window.alert('" + msj + "');", true);   
        }
        //lbl_aviso_graba.Text = msj;
        //lbl_aviso_graba.Visible = true;

        # endregion

        txt007LRPA.Text = "";
    }


    private void MuestraTab()
    {
        //Page.RegisterStartupScript(this.GetType(), "", "window.parent.MuestraTab();", true);   
        ScriptManager.RegisterStartupScript(this,this.GetType(), "", "window.parent.MuestraTab();", true);   
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "", "window.parent.MuestraTab();", true);   
    }

    protected void txt001LRPA_TextChanged(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "CalculaFecha1);", true);   
    }

    protected void txt_FechaInicioSancionLRPA_TextChanged(object sender, EventArgs e)
    {
        RangeValidator930.Validate();

        if (RangeValidator930.IsValid)
        {
            txt001LRPA.Enabled = true;
            txt002LRPA.Enabled = true;
            txt007LRPA.Enabled = true;
            txt009LRPA.Enabled = true;
            
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "ObtenerFechaTerminoSancion()", true);
        }
        else
        {
            txt001LRPA.Enabled = false;
            txt002LRPA.Enabled = false;
            txt007LRPA.Enabled = false;
            txt009LRPA.Enabled = false;
            
        }
    }

    public void Log(string mensaje)
    {
        using (System.IO.StreamWriter escritor = new System.IO.StreamWriter(@"C:\website\Prueba.txt"))
        {

            escritor.WriteLine(mensaje);

        }
    }

    
}