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

using System.Data.Common;
using System.Collections.Generic;

public partial class mod_coordinadores_ingreso_coordinadores : System.Web.UI.Page
{

    public nino SSnino
    {
        get
        {
            if (Session["neo_SSnino"] == null)
            { Session["neo_SSnino"] = new nino(); }
            return (nino)Session["neo_SSnino"];
        }
        set { 
            Session["neo_SSnino"] = value; 
            }
    }
   
    public ListItem OtItem
    {
        get { return (ListItem)Session["OtItem"]; }
        set { Session["OtItem"] = value; }
    }



    public string Vruc
    {
        get
        {
            if (ViewState["Vruc"] == null)
            { ViewState["Vruc"] = -1; }
            return Convert.ToString(ViewState["Vruc"]);
        }
        set { ViewState["Vruc"] = value; }
    }
    public string Vrit
    {
        get
        {
            if (ViewState["Vrit"] == null)
            { ViewState["Vrit"] = -1; }
            return Convert.ToString(ViewState["Vrit"]);
        }
        set { ViewState["Vrit"] = value; }
    }

    public string VOT
    {
        get
        {
            if (ViewState["VOT"] == null)
            { ViewState["VOT"] = -1; }
            return Convert.ToString(ViewState["VOT"]);
        }
        set { ViewState["VOT"] = value; }
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
    public int VICodOrdenTribunal
    {
        get
        {
            if (ViewState["VICodOrdenTribunal"] == null)
            { ViewState["VICodOrdenTribunal"] = -1; }
            return Convert.ToInt32(ViewState["VICodOrdenTribunal"]);
        }
        set { ViewState["VICodOrdenTribunal"] = value; }
    }
    public int VCodSancion
    {
        get
        {
            if (ViewState["VCodSancion"] == null)
            { ViewState["VCodSancion"] = -1; }
            return Convert.ToInt32(ViewState["VCodSancion"]);
        }
        set { ViewState["VCodSancion"] = value; }
    }
    public int VProy
    {
        get
        {
            if (ViewState["VProy"] == null)
            { ViewState["VProy"] = -1; }
            return Convert.ToInt32(ViewState["VProy"]);
        }
        set { ViewState["VProy"] = value; }
    }
      
    public int VIngreso_Mod
    {
        // ingreso: 0
        // Modificacion: 1
        get
        {
            if (ViewState["VIngreso_Mod"] == null)
            { ViewState["VIngreso_Mod"] = -1; }
            return Convert.ToInt32(ViewState["VIngreso_Mod"]);
        }
        set { ViewState["VIngreso_Mod"] = value; }
    }

    #region DEFINICION DE DATATABLE



    public DataTable DTAmpliaPLazo
    {
        get { return (DataTable)Session["DTAmpliaPLazo"]; }
        set { Session["DTAmpliaPLazo"] = value; }
    }

    
    public DateTime VFechaderivacion
    {
        get
        {
            if (ViewState["VFechaderivacion"] == null)
            { ViewState["VFechaderivacion"] = -1; }
            return Convert.ToDateTime(ViewState["VFechaderivacion"]);
        }
        set { ViewState["VFechaderivacion"] = value; }
    }
    public DataTable DTTipoSancionAccesoria
    {
        get { return (DataTable)Session["DTTipoSancionAccesoria"]; }
        set { Session["DTTipoSancionAccesoria"] = value; }
    }
    public DataTable DTSancionAccesoria
    {
        get { return (DataTable)Session["DTSancionAccesoria"]; }
        set { Session["DTSancionAccesoria"] = value; }
    
    }    
    public DataTable DTMedidasSancion
    {
        get { return (DataTable)Session["DTMedidasSancion"]; }
        set { Session["DTMedidasSancion"] = value; }
    }
    public DataTable DTSancion
    {
        get { return (DataTable)Session["DTSancion"]; }
        set { Session["DTSancion"] = value; }
    }
    public DataTable DTResoluciones
    {
        get { return (DataTable)Session["DTResoluciones"]; }
        set { Session["DTResoluciones"] = value; }
    }
    public DataTable DTAmpliacionesMedidas
    {
        get { return (DataTable)Session["DTAmpliacionesMedidas"]; }
        set { Session["DTAmpliacionesMedidas"] = value; }
    }
    public DataTable DTordentribunales
    {
        get { return (DataTable)Session["DTordentribunales"]; }
        set { Session["DTordentribunales"] = value; }
    }
    public DataTable DTBusqueda
    {
        get { return (DataTable)Session["DTBusqueda"]; }
        set { Session["DTBusqueda"] = value; }
    }
    public DataTable DTSancionV2
    {
        get { return (DataTable)Session["DTSancionV2"]; }
        set { Session["DTSancionV2"] = value; }
    }
    public DataTable DTSancionV3
    {
        get { return (DataTable)Session["DTSancionV3"]; }
        set { Session["DTSancionV3"] = value; }
    }
    public DataTable DTcausales
    {
        get { return (DataTable)Session["DTcausales"]; }
        set { Session["DTcausales"] = value; }
    }
    public DataTable DTmedidas
    {
        get { return (DataTable)Session["DTmedidas"]; }
        set { Session["DTmedidas"] = value; }
    }

    public DataTable DTPlazoMedInv
    {
        get { return (DataTable)Session["DTPlazoMedInv"]; }
        set { Session["DTPlazoMedInv"] = value; }
    }
    public DataTable DTICodOrdenTrubunal
    {
        get { return (DataTable)Session["DTICodOrdenTrubunal"]; }
        set { Session["DTICodOrdenTrubunal"] = value; }
    }
    public DataTable DTaudiencia
    {
        get { return (DataTable)Session["DTaudiencia"]; }
        set { Session["DTaudiencia"] = value; }
    }
    
    #endregion

    public string CodProy
    {
        get { return (string)Session["CodProy"]; }
        set { Session["CodProy"] = value; }
    }

    public string NomProy
    {
        get { return (string)Session["NomProy"]; }
        set { Session["NomProy"] = value; }
    }
    
    public string RUC_Rep
    {
        get { return (string)Session["RUC_Rep"]; }
        set { Session["RUC_Rep"] = value; }
    }
    
    protected void Page_Load(object sender, EventArgs e) 
    {
        DropDownList tddown011LRPA = (DropDownList)Tabs.FindControl("ddown011LRPA");
        DropDownList tddown003LRPA = (DropDownList)Tabs.FindControl("ddown003LRPA");
        DropDownList tddown004LRPA = (DropDownList)Tabs.FindControl("ddown004LRPA");
        DropDownList tddown005LRPA = (DropDownList)Tabs.FindControl("ddown005LRPA");
        //Ajax.Utility.RegisterTypeForAjax(typeof(mod_coordinadores_ingreso_coordinadores)); 
        if (!IsPostBack)
        {
            if (Request.QueryString["CODNUEVO"] != null)
            {
                carga_ninoNuevo(Convert.ToInt32(Request.QueryString["CODNUEVO"]));
            }

           

            if (Request.QueryString["sw"] == "4")
            {
                TextBox txt001 = (TextBox)Tabs.FindControl("txt001");
                txt001.Text = Request.QueryString["codinst"].ToString();
            }
            parcoll pcoll = new parcoll();

            DataView dv = new DataView(pcoll.GetparRegion());
            tddown003LRPA.Items.Clear();
            tddown003LRPA.DataSource = dv;
            tddown003LRPA.DataTextField = "Descripcion";
            tddown003LRPA.DataValueField = "CodRegion";
            dv.Sort = "CodRegion";
            tddown003LRPA.DataBind();
            tddown003LRPA.Focus();


            LRPAcoll LRPA1 = new LRPAcoll();
            tddown004LRPA.Items.Clear();
            DataView dv0 = new DataView(LRPA1.GetparTipoTribunalLRPA());
            tddown004LRPA.DataSource = dv0;
            tddown004LRPA.DataTextField = "Descripcion";
            tddown004LRPA.DataValueField = "TipoTribunal";
            dv0.Sort = "Descripcion";
            tddown004LRPA.DataBind();
            tddown004LRPA.Focus();

        }
     
    }
    
    private void validate()
    {
        //F6DC09AD-5F04-4F95-BF81-B806C49B66BA coordinador nacional 
        if (window.existetoken("F6DC09AD-5F04-4F95-BF81-B806C49B66BA"))
        {

            Button btnactualizaingreso = (Button)Tabs.FindControl("btnactualizaingreso");
            Button btn001AgregarAudiencia = (Button)Tabs.FindControl("btn001AgregarAudiencia");
            Button btnAgregarMedida = (Button)Tabs.FindControl("btnAgregarMedida");
            Button btn002 = (Button)Tabs.FindControl("btn002");
            Button btn001 = (Button)Tabs.FindControl("btn001");
            GridView grd001 = (GridView)Tabs.FindControl("grd001");
            GridView grd002 = (GridView)Tabs.FindControl("grd002");
            GridView grd001LRPA = (GridView)Tabs.FindControl("grd001LRPA");
            GridView grd001Audiencia = (GridView)Tabs.FindControl("grd001Audiencia");
            

            btnactualizaingreso.Visible = false;
            btn001AgregarAudiencia.Visible = false;
           // btnAgregarMedida.Visible = false; modificado 14/07/2008
            btn001.Visible = false;
            btn002.Visible = false;

            grd001.Columns[7].Visible = false;
            grd002.Columns[6].Visible = false;
            //  grd001LRPA.Columns[8].Visible = false; modificado 14/07/2008
            grd001Audiencia.Columns[5].Visible = false;

        }
        ////8C83A0F6-76FA-448E-9F19-E83805BA7001 coordinador regional
        //if (window.existetoken("AA938FAD-0140-474C-9DEA-6D6BF31E0A3D"))
        //{
            
        //}
    
    }
    
    private void carga_ninoNuevo(int codnino)
    {
        txt002.Text = codnino.ToString();

        #region Busca_Nino
        Function_Consulta();
        lblSwich.Text = "B";
        grd003.Visible = false;
        lblbmsg.Visible = false;
        #endregion
        #region Despliega
        carga_grilla();
        lbl0013.Visible = false;
        lbl0014.Visible = false;
        lbl0015.Visible = false;
        lnk001.Visible = false;
        lnk002.Visible = false;
        #endregion
        #region ingresa
        lbl003.Text = Server.HtmlDecode(grd003.Rows[0].Cells[6].Text);
        lbl004.Text = Server.HtmlDecode(grd003.Rows[0].Cells[0].Text);
        grd003.Visible = false;
        pnl001.Visible = true;
        Tabs.Visible = true;

        txt007.Text = Server.HtmlDecode(grd003.Rows[0].Cells[1].Text);
        txt002.Text = Server.HtmlDecode(grd003.Rows[0].Cells[0].Text);
        txt004.Text = Server.HtmlDecode(grd003.Rows[0].Cells[4].Text);
        txt005.Text = Server.HtmlDecode(grd003.Rows[0].Cells[5].Text);
        txt006.Text = Server.HtmlDecode(grd003.Rows[0].Cells[3].Text);

        txt002.Enabled = false;
        txt004.Enabled = false;
        txt005.Enabled = false;
        txt006.Enabled = false;
        txt007.Enabled = false;

        btn_buscar.Visible = false;
        btn_modificar.Visible = false;

        carga_info();
        #endregion
    }
    private void carga_info()
    {
        #region Definicion  DataTable

        LRPAcoll LRPA = new LRPAcoll();
        parcoll par = new parcoll();
        coordinador cr = new coordinador();

        #region DTOrdenTribunales
        DTordentribunales = new DataTable();
        DTordentribunales.Columns.Add(new DataColumn("CodTribunal", typeof(int)));
        DTordentribunales.Columns.Add(new DataColumn("Descripcion", typeof(string)));
        DTordentribunales.Columns.Add(new DataColumn("Fecha", typeof(DateTime)));
        DTordentribunales.Columns.Add(new DataColumn("sentenciaejecutoriada", typeof(string)));
        DTordentribunales.Columns.Add(new DataColumn("RUC", typeof(string)));
        DTordentribunales.Columns.Add(new DataColumn("RIT", typeof(string)));
        DTordentribunales.Columns.Add(new DataColumn("codigo", typeof(string)));
        DTordentribunales.Columns.Add(new DataColumn("codordentribunal", typeof(string)));
        DTordentribunales.Clear();
        #endregion
       
        #region DTSancionV2

        DTSancionV2 = new DataTable();
        DTSancionV2.Columns.Add(new DataColumn("ICodOrdenTribunal",typeof(int)));          //1
        DTSancionV2.Columns.Add(new DataColumn("FechaInicio",typeof(DateTime)));           //2
        DTSancionV2.Columns.Add(new DataColumn("FechaTermino",typeof(DateTime)));          //3
        DTSancionV2.Columns.Add(new DataColumn("DuracionAno",typeof(int)));                //4
        DTSancionV2.Columns.Add(new DataColumn("DuracionMes",typeof(int)));                //5
        DTSancionV2.Columns.Add(new DataColumn("DuracionDia",typeof(int)));                //6
        DTSancionV2.Columns.Add(new DataColumn("CodTribunal",typeof(int)));                //7
        DTSancionV2.Columns.Add(new DataColumn("SancionAccesoria",typeof(int)));           //8
        DTSancionV2.Columns.Add(new DataColumn("Abono",typeof(int)));                      //9
        DTSancionV2.Columns.Add(new DataColumn("Horas",typeof(int)));                      //10
        DTSancionV2.Columns.Add(new DataColumn("FechaInicioMixta",typeof(DateTime)));      //11
        DTSancionV2.Columns.Add(new DataColumn("FechaTerminoMixta",typeof(DateTime)));     //12
        DTSancionV2.Columns.Add(new DataColumn("DuracionAnoMixta",typeof(int)));           //13
        DTSancionV2.Columns.Add(new DataColumn("DuracionMesMixta",typeof(int)));           //14
        DTSancionV2.Columns.Add(new DataColumn("DuracionDiaMixta",typeof(int)));           //15
        DTSancionV2.Columns.Add(new DataColumn("CodTerminoSancion",typeof(int)));          //18
        DTSancionV2.Columns.Add(new DataColumn("FechaTerminoSancion",typeof(DateTime)));   //17
        DTSancionV2.Columns.Add(new DataColumn("CodModeloSancionMixta",typeof(int)));      //19
        DTSancionV2.Columns.Add(new DataColumn("IdUsuarioActualizacion",typeof(int)));     //20
        DTSancionV2.Columns.Add(new DataColumn("FechaActualizacion",typeof(DateTime)));    //21
        
        #endregion  

        #region DTAmpliaPLazo

        DTAmpliaPLazo = new DataTable();
        DTAmpliaPLazo.Columns.Add(new DataColumn("CodSancion",typeof(int)));
        DTAmpliaPLazo.Columns.Add(new DataColumn("Dias", typeof(int)));
        DTAmpliaPLazo.Columns.Add(new DataColumn("FechaActualizacion", typeof(DateTime)));
        DTAmpliaPLazo.Columns.Add(new DataColumn("IdUsuarioActualizacion", typeof(DateTime)));

        #endregion


        #region DTSancionV3

        DTSancionV3 = new DataTable();
        DTSancionV3.Columns.Add(new DataColumn("ICodOrdenTribunal", typeof(int)));          //1
        DTSancionV3.Columns.Add(new DataColumn("FechaInicio", typeof(DateTime)));           //2
        DTSancionV3.Columns.Add(new DataColumn("FechaTermino", typeof(DateTime)));          //3
        
        #endregion

        #region DTSancionAccesoria

        DTSancionAccesoria = new DataTable();
        DTSancionAccesoria.Columns.Add(new DataColumn("SancionAccesoria",typeof(int)));
        DTSancionAccesoria.Columns.Add(new DataColumn("CodSancion", typeof(int)));
        

        #endregion

        #region DTSancion
        DTSancion = new DataTable();   
        DTSancion.Columns.Add(new DataColumn("@ICodOrdenTribunal",typeof(int)));            //0
        DTSancion.Columns.Add(new DataColumn("@FechaInicio",typeof(DateTime)));             //1
        DTSancion.Columns.Add(new DataColumn("@FechaTermino",typeof(DateTime)));            //2
        DTSancion.Columns.Add(new DataColumn("@DuracionAno",typeof(int)));                  //3
        DTSancion.Columns.Add(new DataColumn("@DuracionMes",typeof(int)));                  //4
        DTSancion.Columns.Add(new DataColumn("@DuracionDia",typeof(int)));                  //5    
        DTSancion.Columns.Add(new DataColumn("@CodTribunal",typeof(int)));                  //6
        DTSancion.Columns.Add(new DataColumn("@SancionAccesoria",typeof(int)));             //7
        DTSancion.Columns.Add(new DataColumn("@Abono",typeof(int)));                        //8
        DTSancion.Columns.Add(new DataColumn("@Horas",typeof(int)));                        //9 
        DTSancion.Columns.Add(new DataColumn("@FechaInicioMixta",typeof(DateTime)));        //10
        DTSancion.Columns.Add(new DataColumn("@FechaTerminoMixta",typeof(DateTime)));       //11
        DTSancion.Columns.Add(new DataColumn("@DuracionAnoMixta",typeof(int)));             //12    
        DTSancion.Columns.Add(new DataColumn("@DuracionMesMixta",typeof(int)));             //13
        DTSancion.Columns.Add(new DataColumn("@DuracionDiaMixta",typeof(int)));             //14
        DTSancion.Columns.Add(new DataColumn("@CodTerminoSancion",typeof(int)));            //15    
        DTSancion.Columns.Add(new DataColumn("@FechaTerminoSancion",typeof(int)));          //16    
        DTSancion.Columns.Add(new DataColumn("@CodModeloSancionMixta",typeof(int)));        //17
        DTSancion.Columns.Add(new DataColumn("@IdUsuarioActualizacion",typeof(int)));       //18
        DTSancion.Columns.Add(new DataColumn("@FechaActualizacion",typeof(DateTime)));      //19
   
        #endregion

        #region DTICodOrdenTrubunal

        DTICodOrdenTrubunal = new DataTable();
        DTICodOrdenTrubunal.Columns.Add(new DataColumn("ICodOrdenTribunal", typeof(int)));
        DTICodOrdenTrubunal.Clear();

        #endregion

        #region DTCausales
        DTcausales = new DataTable();
        DTcausales.Columns.Add(new DataColumn("CodTipoCausalIngreso", typeof(int)));
        DTcausales.Columns.Add(new DataColumn("CodCausalIngreso", typeof(int)));
        DTcausales.Columns.Add(new DataColumn("DescripcionTipo", typeof(string)));
        DTcausales.Columns.Add(new DataColumn("Descripcion", typeof(string)));
        DTcausales.Columns.Add(new DataColumn("coddelito", typeof(int)));
        DTcausales.Columns.Add(new DataColumn("codigo", typeof(string)));
        DTcausales.Columns.Add(new DataColumn("ICodCausalIngreso", typeof(int)));
    
        DTcausales.Clear();
        #endregion

        #region DTPlazoMedInv

        DTPlazoMedInv = new DataTable();
        DTPlazoMedInv.Columns.Add(new DataColumn("codSancion", typeof(int)));               //0 
        DTPlazoMedInv.Columns.Add(new DataColumn("ICodOrdenTribunal", typeof(int)));        //1
        DTPlazoMedInv.Columns.Add(new DataColumn("finicio", typeof(DateTime)));             //2
        DTPlazoMedInv.Columns.Add(new DataColumn("ftermino", typeof(DateTime)));            //3
        //DTPlazoMedInv.Columns.Add(new DataColumn("ano", typeof(int)));                    //
        //DTPlazoMedInv.Columns.Add(new DataColumn("mes", typeof(int)));                    //
        DTPlazoMedInv.Columns.Add(new DataColumn("dia", typeof(int)));                      //4
        //DTPlazoMedInv.Columns.Add(new DataColumn("abono", typeof(int)));                    // 
        //DTPlazoMedInv.Columns.Add(new DataColumn("horas", typeof(int)));                    //
        //DTPlazoMedInv.Columns.Add(new DataColumn("codot", typeof(string)));                 //
        
        //agregados
        
        DTPlazoMedInv.Columns.Add(new DataColumn("IdUsuarioActualizacion", typeof(int)));     //5
        DTPlazoMedInv.Columns.Add(new DataColumn("FechaActualizacion", typeof(DateTime)));    //6
        //DTPlazoMedInv.Columns.Add(new DataColumn("FechaTerminoMixta", typeof(DateTime)));   //
        //DTPlazoMedInv.Columns.Add(new DataColumn("DuracionAnoMixta", typeof(int)));         //
        //DTPlazoMedInv.Columns.Add(new DataColumn("DuracionMesMixta", typeof(int)));         //    
        //DTPlazoMedInv.Columns.Add(new DataColumn("DuracionDiaMixta", typeof(int)));         //
        //DTPlazoMedInv.Columns.Add(new DataColumn("CodTerminoSancion", typeof(int)));        //
        //DTPlazoMedInv.Columns.Add(new DataColumn("FechaTerminoSancion", typeof(DateTime))); //
        //DTPlazoMedInv.Columns.Add(new DataColumn("CodmodelosancionMixta", typeof(int)));    //    
        DTPlazoMedInv.Clear();

        #endregion
        
        #region DTMedidas
        DTmedidas = new DataTable();
        DTmedidas.Columns.Add(new DataColumn("finicio",typeof(DateTime)));              //1
        DTmedidas.Columns.Add(new DataColumn("ftermino", typeof(DateTime)));            //2
        DTmedidas.Columns.Add(new DataColumn("ano", typeof(int)));                      //3
        DTmedidas.Columns.Add(new DataColumn("mes", typeof(int)));                      //4
        DTmedidas.Columns.Add(new DataColumn("dia", typeof(int)));                      //5
        DTmedidas.Columns.Add(new DataColumn("abono", typeof(int)));                    //6 
        DTmedidas.Columns.Add(new DataColumn("horas", typeof(int)));                    //7
        DTmedidas.Columns.Add(new DataColumn("codot", typeof(string)));                 //8
        DTmedidas.Columns.Add(new DataColumn("codSancion", typeof(int)));               //9 
        //agregados
        DTmedidas.Columns.Add(new DataColumn("CodTribunal", typeof(int)));              //10
        DTmedidas.Columns.Add(new DataColumn("SancionAccesoria", typeof(int)));         //11
        DTmedidas.Columns.Add(new DataColumn("FechaInicioMixta", typeof(DateTime)));    //12
        DTmedidas.Columns.Add(new DataColumn("FechaTerminoMixta", typeof(DateTime)));   //13
        DTmedidas.Columns.Add(new DataColumn("DuracionAnoMixta", typeof(int)));         //14
        DTmedidas.Columns.Add(new DataColumn("DuracionMesMixta", typeof(int)));         //15    
        DTmedidas.Columns.Add(new DataColumn("DuracionDiaMixta", typeof(int)));         //16
        DTmedidas.Columns.Add(new DataColumn("CodTerminoSancion", typeof(int)));        //17
        DTmedidas.Columns.Add(new DataColumn("FechaTerminoSancion", typeof(DateTime))); //18
        DTmedidas.Columns.Add(new DataColumn("CodmodelosancionMixta", typeof(int)));    //19    
        DTmedidas.Clear();
        #endregion

        #region DTAudiencia
        DTaudiencia = new DataTable();
        DTaudiencia.Columns.Add(new DataColumn("codot", typeof(string)));
        DTaudiencia.Columns.Add(new DataColumn("fecha", typeof(DateTime)));
        DTaudiencia.Columns.Add(new DataColumn("codtipoaudiencia", typeof(int)));
        DTaudiencia.Columns.Add(new DataColumn("tipoaudiencia", typeof(string)));
        DTaudiencia.Columns.Add(new DataColumn("resolucion", typeof(string)));
        DTaudiencia.Columns.Add(new DataColumn("ICodTipoAdiencia", typeof(int)));
        DTaudiencia.Clear();
        #endregion

        #region DTResoluciones
        DTResoluciones = new DataTable();
        //DTResoluciones.Columns.Add(new DataColumn("Codigo", typeof(string)));
        DTResoluciones.Columns.Add(new DataColumn("OrdenTribunal", typeof(string)));
        DTResoluciones.Columns.Add(new DataColumn("ResolucionTribunal", typeof(string)));
        DTResoluciones.Columns.Add(new DataColumn("Proyecto", typeof(string)));
        DTResoluciones.Columns.Add(new DataColumn("FechaDerivacion", typeof(DateTime)));
        DTResoluciones.Columns.Add(new DataColumn("IcodIngreso", typeof(int)));
        DTResoluciones.Columns.Add(new DataColumn("IcodOrdenTribunal", typeof(int)));
        DTResoluciones.Columns.Add(new DataColumn("CodResolucionTribunal", typeof(int)));
        DTResoluciones.Columns.Add(new DataColumn("CodProyecto", typeof(int)));
        DTResoluciones.Clear();
        #endregion

        #region DTAmpliacionesMedidas
        DTAmpliacionesMedidas = new DataTable();
        DTAmpliacionesMedidas.Columns.Add(new DataColumn("FechaActualizacion",typeof(DateTime)));
        DTAmpliacionesMedidas.Columns.Add(new DataColumn("Usuario",typeof(string)));
        DTAmpliacionesMedidas.Columns.Add(new DataColumn("Dias",typeof(string)));
        #endregion

        #region DTMedidasSancion

        //dr[0] = Convert.ToString(tddown4_otm.SelectedValue);
        //dr[1] = Convert.ToDateTime(twdcMedInv.Value);
        //dr[2] = Convert.ToDateTime(tTxtLrpa_FechPlazMed.Text);
        //dr[3] = Convert.ToDateTime(tTxtLrpa_PlazMed.Text);
        //dr[4] = Convert.ToInt32(ttxtLrpa_PlazInv.Text);
        //dr[5] = Convert.ToDateTime(tTxtLrpa_FechPlazInv.Text);


        DTMedidasSancion = new DataTable();
        DTMedidasSancion.Columns.Add(new DataColumn("IcodOrdenTribunal", typeof(string)));
        DTMedidasSancion.Columns.Add(new DataColumn("FechaInicio", typeof(DateTime)));
        DTMedidasSancion.Columns.Add(new DataColumn("FechaTermino", typeof(DateTime)));
       // DTMedidasSancion.Columns.Add(new DataColumn("", typeof(DateTime)));
        DTMedidasSancion.Columns.Add(new DataColumn("DuracionDia", typeof(int)));
        DTMedidasSancion.Columns.Add(new DataColumn("PlazoInvestigacion", typeof(int)));
        DTMedidasSancion.Columns.Add(new DataColumn("FechaPlazoInvestigacion", typeof(DateTime)));
        
        #endregion

        #region DTTipoSancionAccesoria
        DTTipoSancionAccesoria = new DataTable();

        DTTipoSancionAccesoria.Columns.Add(new DataColumn("CodSancion", typeof(string)));
        DTTipoSancionAccesoria.Columns.Add(new DataColumn("CodTipoSancionAccesoria", typeof(int)));
        DTTipoSancionAccesoria.Columns.Add(new DataColumn("Descripcion", typeof(int)));
        DTTipoSancionAccesoria.Columns.Add(new DataColumn("SancionAccesoria", typeof(string)));

        #endregion

        #endregion
        
        #region CargaDropDown
        DropDownList tddown014 = (DropDownList)Tabs.FindControl("ddown014");
        tddown014.Items.Clear();


        List<DbParameter> listDbParameter = new List<DbParameter>();

        string sqlu = "Select codregion,coddireccionregional From usuarios WHERE idusuario =@pIdUsuario";
        listDbParameter.Add(Conexiones.CrearParametro("@pIdUsuario", SqlDbType.Int, 4, Convert.ToInt32(Session["IdUsuario"])));
        DataTable dt = cr.ejecuta_SQL(sqlu, listDbParameter);

        //if (dt.Rows[0][0].ToString() == "13" && (dt.Rows[0][1].ToString() == "15" || dt.Rows[0][1].ToString() == "0"))
        //{
            DataView dv13 = new DataView(par.GetparRegion());
            tddown014.DataSource = dv13;
           tddown014.DataTextField = "Descripcion";
            tddown014.DataValueField = "CodRegion";
            dv13.Sort = "Descripcion";
            tddown014.DataBind();
        //}
        //else
        //{
        //    sqlu = "select * from parregion where codregion in (Select  CodRegion From usuarios " +
        //    "WHERE idusuario = "+ Session["IdUsuario"].ToString() +" )";
        //    dt = cr.ejecuta_SQL(sqlu);

        //    DataView dv13 = new DataView(dt);
        //    tddown014.DataSource = dv13;
        //    tddown014.DataTextField = "Descripcion";
        //    tddown014.DataValueField = "CodRegion";
        //    dv13.Sort = "Descripcion";
        //    tddown014.DataBind();
        //}

        DropDownList tddown015 = (DropDownList)Tabs.FindControl("ddown015");
        tddown015.Items.Clear();
        DataView dv15 = new DataView(LRPA.GetparTipoTribunalLRPA());
        tddown015.DataSource = dv15;
        tddown015.DataTextField = "Descripcion";
        tddown015.DataValueField = "TipoTribunal";
        dv15.Sort = "Descripcion";
        tddown015.DataBind();

        DropDownList tddown018 = (DropDownList)Tabs.FindControl("ddown018");
        tddown018.Items.Clear();
        DataView dv16 = new DataView(LRPA.GetparTipoCausalIngresoLRPA());
        tddown018.DataSource = dv16;
        tddown018.DataTextField = "Descripcion";
        tddown018.DataValueField = "CodTipoCausalIngreso";
        dv16.Sort = "Descripcion";
        tddown018.DataBind();

        DropDownList tddown021 = (DropDownList)Tabs.FindControl("ddown021");
        tddown021.Items.Clear();
        DataView dv17 = new DataView(cr.ejecuta_SQL(Resources.Procedures.GetParTipoAudiencia, null));
        tddown021.DataSource = dv17;
        tddown021.DataTextField = "Descripcion";
        tddown021.DataValueField = "CodTipoAudiencia";
        dv17.Sort = "Descripcion";
        tddown021.DataBind();

        #endregion

        #region FechasMax WebDateChooser

        TextBox tddown001 = (TextBox)Tabs.FindControl("ddown001");
        TextBox tddown017 = (TextBox)Tabs.FindControl("ddown017");
       // tddown017.MaxDate = DateTime.Now;
       // tddown001.MaxDate = DateTime.Now;
        //CalendarExtender1.EndDate.GetValueOrDefault(DateTime.Now);
        //CalendarExtender4.EndDate.GetValueOrDefault(DateTime.Now);
        #endregion

        Panel tpnlTermino2 = (Panel)Tabs.FindControl("pnlTermino2");
        if (VIngreso_Mod == 0)
        {
            tpnlTermino2.Visible = false;
        }
        else 
        {
            tpnlTermino2.Visible = true;
        }

      
    }

   
    private void getcausales()
    {
        parcoll par = new parcoll();
        DropDownList tddown018 = (DropDownList)Tabs.FindControl("ddown018");
        DataView dv16 = new DataView(par.GetparCausalesIngreso(tddown018.SelectedValue, SSnino.CodProyecto));
        DropDownList tddown019 = (DropDownList)Tabs.FindControl("ddown019");
        tddown019.Items.Clear();
        tddown019.DataSource = dv16;
        tddown019.DataTextField = "Descripcion";
        tddown019.DataValueField = "CodCausalIngreso";
        dv16.Sort = "Descripcion";
        tddown019.DataBind();

    }
    public void gettribunales()
    {

        parcoll par = new parcoll();
        DropDownList tddown016 = (DropDownList)Tabs.FindControl("ddown016");
        DropDownList tddown014 = (DropDownList)Tabs.FindControl("ddown014");
        DropDownList tddown015 = (DropDownList)Tabs.FindControl("ddown015");
        DataView dv15 = new DataView(par.GetparTribunales(tddown014.SelectedValue, tddown015.SelectedValue));
        tddown016.Items.Clear();
        tddown016.DataSource = dv15;
        tddown016.DataTextField = "Descripcion";
        tddown016.DataValueField = "CodTribunal";
        dv15.Sort = "Descripcion";
        tddown016.DataBind();
    }
    
    private void Busca_ingresos()
    {
        List<DbParameter> listDbParameter = new List<DbParameter>();
        coordinador cr = new coordinador();
        DataTable dt = new DataTable();
        dt = cr.consulta_rol(Convert.ToInt32(Session["IdUsuario"]));
        int codrol = Convert.ToInt32(dt.Rows[0][1]);
        string sParametrosConsulta = "";

        if (codrol == 278) //Rol Coordinador Nacional ex 275
        {
            sParametrosConsulta = "Select Distinct top 201 T2.CodNino,T2.sexo,T2.Rut,T2.Nombres,T2.Apellido_paterno," +
        "T2.Apellido_Materno , T2.FechaNacimiento,t1.ICodIngreso,t1.FechaDerivacion,t3.ruc,t3.rit,t4.codregion " +
        "From Ninos T2 Inner join CoordinacionIngreso t1 on t1.CodNino = T2.CodNino " +
        "inner join CoordinacionOrdenTribunal t3 on t1.ICodOrdenTribunal = t3.ICodOrdenTribunal Inner Join proyectos t4 on " +
        "t4.codproyecto = t1.codproyecto AND ";
        }
        else if (codrol == 277 || codrol == 252) //Rol Coordinador Regional ex 276
        {
            sParametrosConsulta = "Select Distinct top 201 T2.CodNino,T2.sexo,T2.Rut,T2.Nombres,T2.Apellido_paterno," +
         "T2.Apellido_Materno , T2.FechaNacimiento,t1.ICodIngreso,t1.FechaDerivacion,t3.ruc,t3.rit,t4.codregion " +
         "From Ninos T2 Inner join CoordinacionIngreso t1 on t1.CodNino = T2.CodNino " +
         "inner join CoordinacionOrdenTribunal t3 on t1.ICodOrdenTribunal = t3.ICodOrdenTribunal inner join proyectos t4 on " +
         "t4.codproyecto = t1.codproyecto where t4.codregion=@pCodRegion And";

            listDbParameter.Add(Conexiones.CrearParametro("@pCodRegion", SqlDbType.Int, 4, Convert.ToInt32(dt.Rows[0][2])));
        }
      
        if (txt002.Text.Trim() != "")
        {
            sParametrosConsulta = sParametrosConsulta + " T2.CodNino =@pCodNino And";

            listDbParameter.Add(Conexiones.CrearParametro("@pCodNino", SqlDbType.Int, 4, Convert.ToInt32(txt002.Text.Trim())));
        }
        if (txt004.Text != "")
        {
            sParametrosConsulta = sParametrosConsulta + " T2.Apellido_Paterno like @pApellido_Paterno And";

            listDbParameter.Add(Conexiones.CrearParametro("@pApellido_Paterno", SqlDbType.VarChar, 50, "%" + txt004.Text + "%"));
        }
        if (txt005.Text != "")
        {
            sParametrosConsulta = sParametrosConsulta + " T2.Apellido_Materno like @pApellido_Materno  And";

            listDbParameter.Add(Conexiones.CrearParametro("@pApellido_Materno", SqlDbType.VarChar, 50, "%" + txt005.Text + "%"));
        }
        if (txt006.Text != "")
        {
            sParametrosConsulta = sParametrosConsulta + " T2.Nombres like @pNombres And";

            listDbParameter.Add(Conexiones.CrearParametro("@pNombres", SqlDbType.VarChar, 50, "%" + txt006.Text + "%"));
        }
        if (txt007.Text.Trim() != "")
        {
            sParametrosConsulta = sParametrosConsulta + " T2.Rut =@pRut And";

            listDbParameter.Add(Conexiones.CrearParametro("@pRut", SqlDbType.VarChar, 11, txt007.Text.Trim()));
        }

        if (sParametrosConsulta.Substring(sParametrosConsulta.Length - 3, 3) == "And")
        {
            sParametrosConsulta = sParametrosConsulta.Substring(0, sParametrosConsulta.Length - 3);
        }



        dt = cr.ejecuta_SQL(sParametrosConsulta, listDbParameter);

        if (dt.Rows.Count > 0 && dt.Rows.Count < 200)
        {
            //DataTable dtOT = new DataTable();

            //string sqlOT = "Select t1.ICodOrdenTribunal " +
            //"From Ninos T2 Inner join CoordinacionIngreso t1 on t1.CodNino = T2.CodNino " +
            //"inner join CoordinacionOrdenTribunal t3 on t1.ICodOrdenTribunal = t3.ICodOrdenTribunal Inner Join proyectos t4 on " +
            //"t4.codproyecto = t1.codproyecto ";

            //dtOT = cr.ejecuta_SQL(sqlOT);
            //VICodOrdenTribunal = Convert.ToInt32(dtOT.Rows[0][0]);


            lnk001.Visible = false;
            lnk002.Visible = true;
            lbl0013.Text = dt.Rows.Count.ToString();
            lbl0013.Visible = true;
            lbl0015.Visible = false;
            lbl0014.Visible = true;

            DTBusqueda = dt;


           

            
        }
        else if (dt.Rows.Count == 0)
        {
            grd003.Visible = false;
            lnk001.Visible = true;
            lnk002.Visible = false;
            lbl0013.Text = "0";
            lbl0013.Visible = true;
            lbl0014.Visible = true;
            lbl0015.Visible = false;
            grd003.Visible = false;
        }
        else if (dt.Rows.Count > 200)
        {
            grd003.Visible = false;
            lbl0013.Visible = false;
            lbl0014.Visible = false;
            lbl0015.Text = "Búsqueda demasiado ambigua, Ingrese parámetros.";
            lbl0015.Visible = true;
            lnk001.Visible = false;
            grd003.Visible = false;
        }
    }
    private void Function_Consulta()
    {
        List<DbParameter> listDbParameter = new List<DbParameter>();

       string sParametrosConsulta = "Select Distinct top 201 T2.CodNino,T2.Rut,T2.Sexo,T2.Nombres,T2.Apellido_paterno,T2.Apellido_Materno," +
                              "T2.FechaNacimiento, T2.CodNacionalidad From Ninos T2 ";

        if (txt007.Text.Trim() != "" || txt002.Text.Trim() != "" ||
                txt004.Text.Trim() != "" || txt005.Text.Trim() != "" || txt006.Text.Trim() != "")
        {
            sParametrosConsulta = sParametrosConsulta + "Where ";
        }


        if (txt002.Text.Trim() != "")
        {
            sParametrosConsulta = sParametrosConsulta + " T2.CodNino =@pCodNino And";

            listDbParameter.Add(Conexiones.CrearParametro("@pCodNino", SqlDbType.Int, 4, Convert.ToInt32(txt002.Text.Trim())));
        }
        if (txt004.Text.Trim() != "")
        {
            sParametrosConsulta = sParametrosConsulta + " T2.Apellido_Paterno like @pApellido_Paterno And";

            listDbParameter.Add(Conexiones.CrearParametro("@pApellido_Paterno", SqlDbType.VarChar, 50, "%" + txt004.Text + "%"));
        }
        if (txt005.Text.Trim() != "")
        {
            sParametrosConsulta = sParametrosConsulta + " T2.Apellido_Materno like @pApellido_Materno And";

            listDbParameter.Add(Conexiones.CrearParametro("@pApellido_Materno", SqlDbType.VarChar, 50, "%" + txt005.Text + "%"));
        }
        if (txt006.Text.Trim() != "")
        {
            sParametrosConsulta = sParametrosConsulta + " T2.Nombres like @pNombres And";

            listDbParameter.Add(Conexiones.CrearParametro("@pNombres", SqlDbType.VarChar, 100, "%" + txt006.Text + "%"));
        }
        if (txt007.Text.Trim() != "")
        {
            sParametrosConsulta = sParametrosConsulta + " T2.Rut =@pRut And";

            listDbParameter.Add(Conexiones.CrearParametro("@pRut", SqlDbType.VarChar, 11, txt007.Text.Trim()));
        }
       
        if (sParametrosConsulta.Substring(sParametrosConsulta.Length - 3, 3) == "And")
        {
            sParametrosConsulta = sParametrosConsulta.Substring(0, sParametrosConsulta.Length - 3);
        }


        ninocoll nic = new ninocoll();
        DataTable dt = nic.get_ninorelacionado(sParametrosConsulta, listDbParameter);

        if (dt.Rows.Count > 0 && dt.Rows.Count < 200)
        {
            lnk001.Visible = false;
            lnk002.Visible = true;
            lbl0013.Text = dt.Rows.Count.ToString();
            lbl0013.Visible = true;
            lbl0015.Visible = false;
            lbl0014.Visible = true;

            DTBusqueda = dt;
        }
        else if (dt.Rows.Count == 0)
        {
            grd003.Visible = false;
            lnk001.Visible = true;
            lnk002.Visible = false;
            lbl0013.Text = "0";
            lbl0013.Visible = true;
            lbl0014.Visible = true;
            lbl0015.Visible = false;
            grd003.Visible = false;
        }
        else if (dt.Rows.Count > 200)
        {
            grd003.Visible = false;
            lbl0013.Visible = false;
            lbl0014.Visible = false;
            lbl0015.Text = "Búsqueda demasiado ambigua, Ingrese parámetros.";
            lbl0015.Visible = true;
            lnk001.Visible = false;
            grd003.Visible = false;
        }

    

    }
    //protected void btn_buscar_Click(object sender, EventArgs e)
    //{
    //    Function_Consulta();
    //    lblSwich.Text = "B";
    //    grd003.Visible = false;
    //    grd004.Visible = false;
    //    lblbmsg.Visible = false;
        
    //}
    protected void grd003_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd003.PageIndex = e.NewPageIndex;
        carga_grilla();
    }
    protected void grd003_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ingresar")
          {

              VIngreso_Mod = 0;
            Button btnactualizaingreso = (Button)Tabs.FindControl("btnactualizaingreso");
            Button btn001AgregarAudiencia = (Button)Tabs.FindControl("btn001AgregarAudiencia");
            Button btnAgregarMedida = (Button)Tabs.FindControl("btnAgregarMedida");
            Button btn002 = (Button)Tabs.FindControl("btn002");
            Button btn001 = (Button)Tabs.FindControl("btn001");
            GridView grd001 = (GridView)Tabs.FindControl("grd001");
            GridView grd002 = (GridView)Tabs.FindControl("grd002");
            GridView grd001LRPA = (GridView)Tabs.FindControl("grd001LRPA");
            GridView grd001Audiencia = (GridView)Tabs.FindControl("grd001Audiencia");
            ImageButton tbtnBuscaProyecto = (ImageButton)Tabs.FindControl("btnBuscaProyecto");
            Button tbtn001 = (Button)Tabs.FindControl("btn001");
            tbtn001.Enabled = true;
            

            btnactualizaingreso.Visible = false;
            btn001AgregarAudiencia.Visible = true;
           //btnAgregarMedida.Visible = true;
            btn001.Visible = true;
            btn002.Visible = true;

            grd001.Columns[7].Visible = true;
            grd002.Columns[6].Visible = true;
           // grd001LRPA.Columns[8].Visible = true;
            grd001Audiencia.Columns[5].Visible = true;

            lbl003.Text = Server.HtmlDecode(grd003.Rows[Convert.ToInt32(e.CommandArgument)].Cells[6].Text);
            lbl004.Text = Server.HtmlDecode( grd003.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text);
            grd003.Visible = false;
            pnl001.Visible = true;
            Tabs.Visible = true;

            txt007.Text = Server.HtmlDecode( grd003.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text);
            txt002.Text = Server.HtmlDecode( grd003.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text);
            txt004.Text = Server.HtmlDecode( grd003.Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Text);
            txt005.Text = Server.HtmlDecode( grd003.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Text);
            txt006.Text = Server.HtmlDecode( grd003.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text);

            txt002.Enabled = false;
            txt004.Enabled = false;
            txt005.Enabled = false;
            txt006.Enabled = false;
            txt007.Enabled = false;

            btn_buscar.Visible = false;
            btn_modificar.Visible = false;


            carga_info();
            Tabs.Tabs[1].Visible = false;
            Tabs.Tabs[2].Visible = false;
            Tabs.Tabs[3].Visible = false;
            Tabs.Tabs[4].Visible = false;
            Tabs.Tabs[5].Visible = false;
            Tabs.Tabs[6].Visible = false;
           // Tabs.Tabs[7].Visible = false;  //REVISAR ESTA ELIMINACION
        }
        if (e.CommandName == "Historial")
        {

            window.open(this.Page, "../mod_coordinadores/coord_HistoricoNino_busca.aspx?CODNINO=" + grd003.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text, "Historicos", true, 1000, 430, false, false, true);
        
        }
    }
    
    
    protected void grd001_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridView tgrd001 = (GridView)Tabs.FindControl("grd001");
       
            bool ex_de = false;
            bool ex_ms = false;
            bool ex_ad = false;
            
            GridView grd003 = (GridView)Tabs.FindControl("grd003");
            GridView grd002 = (GridView)Tabs.FindControl("grd002");
            GridView grd001LRPA = (GridView)Tabs.FindControl("grd001LRPA");
            GridView grd001Audiencia = (GridView)Tabs.FindControl("grd001Audiencia");
            

            Label lbl_mensajeOT = (Label)Tabs.FindControl("lbl_mensajeOT");
            
            for (int i = 0; i < grd002.Rows.Count; i++)
            {
                if(DTordentribunales.Rows[Convert.ToInt32(e.CommandArgument)].ItemArray[6].ToString().Trim() == grd002.Rows[i].Cells[5].Text.Trim())
                {
                    ex_de = true;
                }
            }
            for (int i = 0; i < grd001LRPA.Rows.Count; i++)
            {
                if (DTordentribunales.Rows[Convert.ToInt32(e.CommandArgument)].ItemArray[6].ToString().Trim() == grd001LRPA.Rows[i].Cells[7].Text.Trim())
                {
                    ex_ms = true;
                }
            }
            for (int i = 0; i < grd001Audiencia.Rows.Count; i++)
            {
                if (DTordentribunales.Rows[Convert.ToInt32(e.CommandArgument)].ItemArray[6].ToString().Trim() == grd001Audiencia.Rows[i].Cells[0].Text.Trim())
                {
                    ex_ad = true;
                }
            }

            if (ex_de || ex_ms || ex_ad)
            {
                if (ex_de)
                  lbl_mensajeOT.Text = "- Error, primero debe eliminar la Causal de Ingreso relacionada con la Orden de Tribunal que desea quitar <br>";
                
                if(ex_ms)
                    lbl_mensajeOT.Text += "- Error, primero debe eliminar la medida  relacionada con la Orden de Tribunal que desea quitar <br>";

                if(ex_ad)
                    lbl_mensajeOT.Text += "- Error, primero debe eliminar la Audiencia relacionada con la Orden de Tribunal que desea quitar <br>";
                
                
                lbl_mensajeOT.Visible = true;
            }
            else
            {
                
                DTordentribunales.Rows.Remove(DTordentribunales.Rows[Convert.ToInt32(e.CommandArgument)]);

                DataView dv = new DataView(DTordentribunales);
                tgrd001.DataSource = dv;
                tgrd001.DataBind();
                tgrd001.Visible = true;
           

                #region elimina_ddownOT
                DropDownList tddown_otc = (DropDownList)Tabs.FindControl("ddown_otc");
                DropDownList tddown3_ot = (DropDownList)Tabs.FindControl("ddown03_ot");
                DropDownList tddown_otm = (DropDownList)Tabs.FindControl("ddown_otm");
                DropDownList tddown_ota = (DropDownList)Tabs.FindControl("ddown_ota");
                DropDownList tddown4_otm = (DropDownList)Tabs.FindControl("ddown4_otm");


                tddown_otc.Items.Clear();
                tddown3_ot.Items.Clear();
                tddown4_otm.Items.Clear();
                tddown_otm.Items.Clear();
                tddown_ota.Items.Clear();
                

                DataTable dt = DTordentribunales;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i][1] = "(" + dt.Rows[i][0].ToString() + ") - " + dt.Rows[i][1].ToString();
                }

                
                tddown_otc.DataSource = dt;
                tddown_otc.DataTextField = "Descripcion";
                tddown_otc.DataValueField = "codigo";
                tddown_otc.DataBind();

                tddown3_ot.DataSource = dt;
                tddown3_ot.DataTextField = "Descripcion";
                tddown3_ot.DataValueField = "codigo";
                tddown3_ot.DataBind();

                tddown4_otm.DataSource = dt;
                tddown4_otm.DataTextField = "Descripcion";
                tddown4_otm.DataValueField = "codigo";
                tddown4_otm.DataBind();

                tddown_otm.DataSource = dt;
                tddown_otm.DataTextField = "Descripcion";
                tddown_otm.DataValueField = "codigo";
                tddown_otm.DataBind();

                tddown_ota.DataSource = dt;
                tddown_ota.DataTextField = "Descripcion";
                tddown_ota.DataValueField = "codigo";
                tddown_ota.DataBind();
                                #endregion
                lbl_mensajeOT.Visible = false;
                TextBox ttxtfoco = (TextBox)Tabs.FindControl("txtfoco");
                ttxtfoco.Focus();
            }
    }
    protected void ddown014_SelectedIndexChanged(object sender, EventArgs e)
    {
        gettribunales();
        TextBox ttxtfoco = (TextBox)Tabs.FindControl("txtfoco");
        ttxtfoco.Focus();
    }
    protected void ddown015_SelectedIndexChanged(object sender, EventArgs e)
    {
        gettribunales();
        TextBox ttxtfoco = (TextBox)Tabs.FindControl("txtfoco");
        ttxtfoco.Focus();
    }
   
    
    //protected void btnnext(object sender, EventArgs e)
    //{

    //        //if (Tabs.SelectedTabIndex == 2)
    //        //{

    //        //    ReporteNinoColl rpn = new ReporteNinoColl();
    //        //    DataTable dt0 = rpn.Reporte_GetProyectosLPRA(Convert.ToInt32(CodProy));
                


    //        //    if (dt0.Rows[0][0].ToString() != "2" && dt0.Rows[0][1].ToString() != "20084")//&& Tabs.SelectedTabIndex = 3)
    //        //    {
    //        //        validatedata(Tabs.SelectedTabIndex, false);
    //        //       // Tabs.SelectedTab += 1; //
    //        //        Tabs.SelectedTab = 4;

    //        //    }
    //        //    else
    //        //    {
    //        //        validatedata(Tabs.SelectedTabIndex, false);
    //        //        Tabs.SelectedTab = 4;

    //        //    }
    //        //}
    //        //else
    //        //{
    //            validatedata(Tabs.SelectedTabIndex, false);

    //        //    if (Tabs.SelectedTabIndex == 3)
    //        //    {
    //        //        Tabs.SelectedTab += 2;
    //        //    }
    //        //    if (Tabs.SelectedTabIndex == 4)
    //        //    {
    //        //        Tabs.SelectedTab += 1;
    //        //    }
    //        //    else
    //        //    {
    //                Tabs.SelectedTab += 1;
    //            //}

    //      // }

        
      
        
       




    //}
    private bool validatedata(int tabindex, bool full)
    {

        //   validacion de datos obligatorios en tabs

        bool fullbool = false;
        bool vtab1 = false;
        bool vtab2 = false;
        bool vtab3 = false;
        bool vtab4 = false;
        bool vtab5 = false;
        bool vtab6 = false;
        bool vtab7 = false;
      
       

        //primer tabs
        if (tabindex == 0 || full)
        {
            DropDownList tddown014 = (DropDownList)Tabs.FindControl("ddown014");
            DropDownList tddown015 = (DropDownList)Tabs.FindControl("ddown015");
            DropDownList tddown016 = (DropDownList)Tabs.FindControl("ddown016");
            TextBox tddown017 = (TextBox)Tabs.FindControl("ddown017");
            TextBox ttxt006F2 = (TextBox)Tabs.FindControl("txt006F2");
            TextBox ttxt007F2 = (TextBox)Tabs.FindControl("txt006F2");
            
            GridView tgrd001 = (GridView)Tabs.FindControl("grd001");


            if((tddown014.SelectedValue == "0" || tddown015.SelectedValue=="0"|| tddown016.SelectedValue == "0" || ttxt006F2.Text.Trim() == "" || ttxt007F2.Text.Trim() == "" || tddown017.Text == "") && tgrd001.Rows.Count == 0)
           
            {
                Tabs.Tabs[0].ForeColor = System.Drawing.Color.Red;
                vtab1 = true;

                for (int i = 0; i < Tabs.Tabs.Count; i++)
                {
                    if (i > Tabs.ActiveTabIndex)
                    {
                        Tabs.Tabs[i].Visible = false;
                    }
                }
            }
            else
            {
                Tabs.Tabs[0].ForeColor= System.Drawing.Color.Black;
                vtab1 = false;
                Tabs.Tabs[tabindex + 1].Visible = true;
            }
        }


        // segundo tabs
      if (tabindex == 1 || full)
        {
            GridView tgrd002 = (GridView)Tabs.FindControl("grd002");

            if (tgrd002.Rows.Count == 0)
                {
                    Tabs.Tabs[1].ForeColor = System.Drawing.Color.Red;
                    vtab2 = true;
                    for (int i = 0; i < Tabs.Tabs.Count; i++)
                    {
                        if (i > Tabs.ActiveTabIndex)
                        {
                            Tabs.Tabs[i].Visible = false;
                        }
                    }
                }
                else
                {
                    Tabs.Tabs[1].ForeColor = System.Drawing.Color.Black;
                    vtab2 = false;
                    Tabs.Tabs[tabindex + 1].Visible = true;
                }


                DropDownList tddown03_Proy = (DropDownList)Tabs.FindControl("ddown03_Proy");

                coordinador coord = new coordinador();

                String RegionUsuario = "Select CodRegion From Usuarios Where IdUsuario =" + Convert.ToInt32(Session["IdUsuario"]);
                
                DataView dvUser = new DataView(coord.Get_RegionByUsers(RegionUsuario));


        }

        
        if (tabindex == 2 || full)
        {
            

            GridView tgrd001_Resolucion = (GridView)Tabs.FindControl("grd001_Resolucion");
            if (tgrd001_Resolucion.Rows.Count > 0)
                {
                    ((DropDownList)Tabs.FindControl("ddown03_ot")).BackColor = System.Drawing.Color.White;
                    ((DropDownList)Tabs.FindControl("ddown03_rt")).BackColor = System.Drawing.Color.White;
                    ((TextBox)Tabs.FindControl("ddown001")).BackColor = System.Drawing.Color.White;//calendar
                  


                    coordinador cr1 = new coordinador();
                    parcoll pcoll = new parcoll();
                    LRPAcoll LRPA = new LRPAcoll();

                    DropDownList tddownMC_Region = (DropDownList)Tabs.FindControl("ddownMC_Region");
                    DropDownList tddownMC_TipTribunal = (DropDownList)Tabs.FindControl("ddownMC_TipTribunal");
                    DropDownList tddownMC_situaTerSanc = (DropDownList)Tabs.FindControl("ddownMC_situaTerSanc");
                    DropDownList tddownMC_ot = (DropDownList)Tabs.FindControl("ddownMC_ot");


                    //GetMedida();

                    /////////////////////inicio carga/////////////////

                  
                    DropDownList tddown003LRPA = (DropDownList)Tabs.FindControl("ddown003LRPA");
                    DropDownList tddown004LRPA = (DropDownList)Tabs.FindControl("ddown004LRPA");
                    DropDownList tddown008LRPA = (DropDownList)Tabs.FindControl("ddown008LRPA");


                    DataView dv = new DataView(pcoll.GetparRegion());
                    tddown003LRPA.Items.Clear();
                    tddown003LRPA.DataSource = dv;
                    tddown003LRPA.DataTextField = "Descripcion";
                    tddown003LRPA.DataValueField = "CodRegion";
                    dv.Sort = "CodRegion";
                    tddown003LRPA.DataBind();
                    tddown003LRPA.Focus();

                    bool swLrpa = FiltroLRPA(); //no existe interrupcion a la visibilidad

                    if (swLrpa)
                    {
                        LRPAcoll LRPA1 = new LRPAcoll();
                        tddown004LRPA.Items.Clear();
                        DataView dv0 = new DataView(LRPA1.GetparTipoTribunalLRPA());
                        tddown004LRPA.DataSource = dv0;
                        tddown004LRPA.DataTextField = "Descripcion";
                        tddown004LRPA.DataValueField = "TipoTribunal";
                        dv0.Sort = "Descripcion";
                        tddown004LRPA.DataBind();
                        tddown004LRPA.Focus();
                    }
                    else
                    {

                        tddown004LRPA.Items.Clear();
                        DataView dv1 = new DataView(pcoll.GetparTipoTribunal());
                        tddown004LRPA.DataSource = dv1;
                        tddown004LRPA.DataTextField = "Descripcion";
                        tddown004LRPA.DataValueField = "TipoTribunal";
                        dv1.Sort = "Descripcion";
                        tddown004LRPA.DataBind();
                        tddown004LRPA.Focus();
                    }

                    tddown008LRPA.Items.Clear();
                    DataView dv2 = new DataView(LRPA.callto_get_parterminomedidasancion());
                    tddown008LRPA.DataSource = dv2;
                    tddown008LRPA.DataTextField = "Descripcion";
                    tddown008LRPA.DataValueField = "CodTerminoSancion";
                    dv2.Sort = "Descripcion";
                    tddown008LRPA.DataBind();
                    tddown008LRPA.Focus();

                    tddown008LRPA.SelectedValue = "-1"; //no existe interrupcion a la visibilidad

                    GetMedida();


                    //////////////////////fin carga/////////////////


                    ReporteNinoColl rpn = new ReporteNinoColl();
                    DropDownList tddown03_Proy = (DropDownList)Tabs.FindControl("down03_Proy");
                   // GridView tgrd001_Resolucion = (GridView)Tabs.FindControl("grd001_Resolucion");

                    

                    DataTable dt0 = rpn.Reporte_GetProyectosLPRA(Convert.ToInt32(CodProy));
                    if (dt0.Rows[0][0].ToString() == "2" && dt0.Rows[0][1].ToString() == "20084")  //no existe interrupcion a la visibilidad
                    {
                        vtab3 = false;
                        Tabs.Tabs[2].ForeColor = System.Drawing.Color.Black;
                        Tabs.Tabs[tabindex + 1].Visible = true; //modificado 01062008
                        Tabs.Tabs[4].Visible = true;
                    }
                    else 
                    {
                        //vtab3 = false;
                        Tabs.Tabs[2].ForeColor = System.Drawing.Color.Black;
                       Tabs.Tabs[tabindex + 1].Visible = true;

                        //vtab3 = false;
                       Tabs.Tabs[2].ForeColor = System.Drawing.Color.Black;
                        //Tabs.Tabs[tabindex + 2].Visible = true;
                        Tabs.Tabs[4].Visible = true;
                        //Tabs.Tabs.GetTab(4);
                    }


                
               
                       
                }
                else
                {
                    bool vtab3_1 = validateddownTabs("ddown03_ot");
                    bool vtab3_2 = validateddownTabs("ddown03_rt");
                    //bool vtab3_3 = validateddownTabs("ddown001");


                    if (vtab3_1 == true)
                    {
                        ((DropDownList)Tabs.FindControl("ddown03_ot")).BackColor = System.Drawing.Color.Pink;
                    }
                    else 
                    {
                        ((DropDownList)Tabs.FindControl("ddown03_ot")).BackColor = System.Drawing.Color.White;
                    }

                    if (vtab3_2 == true)
                    {
                        ((DropDownList)Tabs.FindControl("ddown03_rt")).BackColor = System.Drawing.Color.Pink;
                    }
                    else
                    {
                        ((DropDownList)Tabs.FindControl("ddown03_rt")).BackColor = System.Drawing.Color.White;
                    }

                    if (((TextBox)Tabs.FindControl("ddown001")).Text == "Seleccione Fecha")
                    {
                        ((TextBox)Tabs.FindControl("ddown001")).BackColor = System.Drawing.Color.Pink;//calendar
                    }
                    else
                    {
                        ((TextBox)Tabs.FindControl("ddown001")).BackColor = System.Drawing.Color.White;//calendar
                    }

                   
                    vtab3 = true;
                    Tabs.Tabs[2].ForeColor = System.Drawing.Color.Red;
                    for (int i = 0; i < Tabs.Tabs.Count; i++)
                    {
                        if (i > Tabs.ActiveTabIndex)
                        {
                            Tabs.Tabs[i].Visible = false;
                        }
                    }
                }
            
        }
        // validar tabs sancion
       if (tabindex == 3 || full)
        {

            GridView tgrd004_lrpaMedInv = (GridView)Tabs.FindControl("grd004_lrpaMedInv");

            if (tgrd004_lrpaMedInv.Rows.Count > 0)
            {
                



                vtab4 = false;
                Tabs.Tabs[tabindex].ForeColor = System.Drawing.Color.Black;
                Tabs.ActiveTabIndex = 5;
            }
            else
            {
                vtab4 = false;
                Tabs.Tabs[tabindex].ForeColor = System.Drawing.Color.Black;
                //Tabs.Tabs[tabindex + 1].Visible = true;
            }

            

            coordinador cr1 = new coordinador();
            parcoll pacoll = new parcoll();
            LRPAcoll LRPAc = new LRPAcoll();

            DropDownList tddownMC_Region = (DropDownList)Tabs.FindControl("ddownMC_Region");
            DropDownList tddownMC_TipTribunal = (DropDownList)Tabs.FindControl("ddownMC_TipTribunal");
            DropDownList tddownMC_situaTerSanc = (DropDownList)Tabs.FindControl("ddownMC_situaTerSanc");
            DropDownList tddownMC_ot = (DropDownList)Tabs.FindControl("ddownMC_ot");
    
        }


        
        if (tabindex == 4 || full)
        {
            vtab5 = false;
            Tabs.Tabs[tabindex].ForeColor = System.Drawing.Color.Black;
            Tabs.Tabs[tabindex + 1].Visible = true;

         }       
        
        if (tabindex == 5 || full)
        {

            vtab6 = false;
            Tabs.Tabs[tabindex].ForeColor = System.Drawing.Color.Black;
            Tabs.Tabs[tabindex + 1].Visible = true;



        }
        if (tabindex == 6 || full)
        {
            vtab7 = false;
            Tabs.Tabs[tabindex].ForeColor = System.Drawing.Color.Black;
            //Tabs.Tabs[tabindex + 1].Visible = true;  // no existe otro tabs
        }
       
        
        
        GridView tgrd001Audiencia = (GridView)Tabs.FindControl("grd001Audiencia");
        DropDownList tddown_ota = (DropDownList)Tabs.FindControl("ddown_ota");
        DropDownList tddown021 = (DropDownList)Tabs.FindControl("ddown021");
        TextBox ttxt007 = (TextBox)Tabs.FindControl("txt007");
        DropDownList tddown_otm = (DropDownList)Tabs.FindControl("ddown_otm");
        DropDownList tddown4_otm = (DropDownList)Tabs.FindControl("ddown4_otm");

        DropDownList tddown03_rt = (DropDownList)Tabs.FindControl("ddown03_rt");
        coordinador coor = new coordinador();
        DataView dvresol1 = new DataView(coor.callto_getparresoluciontribunal());

        tddown03_rt.Items.Clear();
        tddown03_rt.DataSource = dvresol1;
        tddown03_rt.DataTextField = "Descripcion";
        tddown03_rt.DataValueField = "CodResolucionTribunal";
        dvresol1.Sort = "Descripcion";
        tddown03_rt.DataBind();


        // verificacion de Tabs total OK

        if (vtab1 || vtab2 || vtab3 || vtab4 || vtab5 || vtab6)
        {
            fullbool = true;

        }

        return fullbool;

    }
    private bool validateddownTabs(string ddown)
    {
        return validateddown((DropDownList)Tabs.FindControl(ddown));

    }
    private bool validateddown(DropDownList ddown)
    {
        if (ddown.SelectedValue == null || ddown.SelectedValue == "0")
        {
            ddown.BackColor = System.Drawing.Color.Pink;
            return true;

        }
        else
        {
            ddown.BackColor = System.Drawing.Color.White;
            return false;

        }

    }
    //protected void btnback(object sender, EventArgs e)
    //{
    //    Tabs.SelectedTab -= 1;
    //    for (int i = 0; i < Tabs.Tabs.Count; i++)
    //    {
    //        if (i > Tabs.SelectedTab)
    //        {
    //            Tabs.Tabs[i].Visible = false;
    //        }
    //    }
    //}
    protected void grd002_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridView tgrd002 = (GridView)Tabs.FindControl("grd002");
        DTcausales.Rows.Remove(DTcausales.Rows[Convert.ToInt32(e.CommandArgument)]);
        
        tgrd002.DataSource = DTcausales;
        tgrd002.DataBind();
        
        if (tgrd002.Rows.Count > 0)
           tgrd002.Visible = true;
        else
           tgrd002.Visible = false;

       TextBox ttxtfoco2 = (TextBox)Tabs.FindControl("txtfoco2");
       ttxtfoco2.Focus();

   }
    protected void ddown018_SelectedIndexChanged(object sender, EventArgs e)
    {
        parcoll par = new parcoll();
        DropDownList tddown018 = (DropDownList)Tabs.FindControl("ddown018");
        DataView dv16 = new DataView(par.GetparCausalesIngreso(tddown018.SelectedValue, SSnino.CodProyecto));
        DropDownList tddown019 = (DropDownList)Tabs.FindControl("ddown019");
        tddown019.Items.Clear();
        tddown019.DataSource = dv16;
        tddown019.DataTextField = "Descripcion";
        tddown019.DataValueField = "CodCausalIngreso";
        dv16.Sort = "Descripcion";
        tddown019.DataBind();

        TextBox ttxtfoco2 = (TextBox)Tabs.FindControl("txtfoco2");
        ttxtfoco2.Focus();
    }
    protected void ddown019_SelectedIndexChanged1(object sender, EventArgs e)
    {
        DropDownList tddown019 = (DropDownList)Tabs.FindControl("ddown019");
        TextBox ttxt006 = (TextBox)Tabs.FindControl("txt006");
        parcoll pcoll = new parcoll();

        int codcausal = pcoll.GetparCausalesIngresoCodNumCausal(Convert.ToInt32(tddown019.SelectedValue));

        ttxt006.Text = codcausal.ToString();

        TextBox ttxtfoco2 = (TextBox)Tabs.FindControl("txtfoco2");
        ttxtfoco2.Focus();

    }
    
    
    
    //protected void ddown001LRPA_ValueChanged(object sender, EventArgs e)
    //{
    //    LinkButton tlnb001 = (LinkButton)Tabs.FindControl("lnb001");
    //    GridView tgrd001LRPA = (GridView)Tabs.FindControl("grd001LRPA");
    //    Calcula_Dias();
    //    tgrd001LRPA.Focus();
    //    tlnb001.Focus();

    //}
    private void Calcula_Dias()//legal
    {
        DateTime fechainiciosancion = Convert.ToDateTime("01/01/1900");

        TextBox tddown001LRPA = (TextBox)Tabs.FindControl("ddown001LRPA");
        TextBox tddown009LRPA = (TextBox)Tabs.FindControl("ddown009LRPA");
        Label tlblfechaini1LRPA = (Label)Tabs.FindControl("lblfechaini1LRPA");
        Label tlbl_avisoDuracionLRPA = (Label)Tabs.FindControl("lbl_avisoDuracionLRPA");

        TextBox ttxt001LRPA = (TextBox)Tabs.FindControl("txt001LRPA");
        TextBox ttxt002LRPA = (TextBox)Tabs.FindControl("txt002LRPA");
        TextBox ttxt007LRPA = (TextBox)Tabs.FindControl("txt007LRPA");
        TextBox ttxt009LRPA = (TextBox)Tabs.FindControl("txt009LRPA");
        TextBox ttxt003LRPA = (TextBox)Tabs.FindControl("txt003LRPA");

        if (tddown001LRPA.Text.ToUpper() != "SELECCIONE FECHA")
        {
            fechainiciosancion = Convert.ToDateTime(tddown001LRPA.Text);
            tlblfechaini1LRPA.Text = "";

            if (ttxt001LRPA.Text.Trim() == "" && ttxt002LRPA.Text.Trim() == "" && ttxt007LRPA.Text.Trim() == "")
            {
                tlbl_avisoDuracionLRPA.Text = "Ingrese al menos un parametro";
                tlbl_avisoDuracionLRPA.Visible = true;

            }
            else
            {
                tlbl_avisoDuracionLRPA.Visible = false;
                if (ttxt001LRPA.Text.Trim() == "")
                { ttxt001LRPA.Text = "0"; }
                if (ttxt002LRPA.Text.Trim() == "")
                { ttxt002LRPA.Text = "0"; }
                if (ttxt007LRPA.Text == "")
                { ttxt007LRPA.Text = "0"; }



                DateTime fechatermino = Convert.ToDateTime(tddown001LRPA.Text).AddYears(Convert.ToInt32(ttxt001LRPA.Text.Trim()));
                fechatermino = fechatermino.AddMonths(Convert.ToInt32(ttxt002LRPA.Text.Trim()));
                fechatermino = fechatermino.AddDays(Convert.ToInt32(ttxt007LRPA.Text.Trim()));
                fechatermino = fechatermino.AddDays(-Convert.ToInt32(ttxt009LRPA.Text.Trim()));
                ttxt003LRPA.Text = fechatermino.ToShortDateString();

                if (tddown009LRPA.Text.ToUpper() != "SELECCIONE FECHA")
                {
                    tddown009LRPA.Text = Convert.ToDateTime(ttxt003LRPA.Text).AddDays(1).ToString();
                    Calcula_Dias_Mix();
                }
            }


        }
        else
        {
            tlblfechaini1LRPA.Text = "Ingrese Fecha de Inicio";
            ttxt001LRPA.Text = "";
            ttxt002LRPA.Text = "";

        }

    }
    private void Calcula_Dias_Mix()//legal
    {
        TextBox tddown009LRPA = (TextBox)Tabs.FindControl("ddown009LRPA");
        Label tlblfechaini2LRPA = (Label)Tabs.FindControl("lblfechaini2LRPA");
        Label tlbl_avisoDuracion2LRPA = (Label)Tabs.FindControl("lbl_avisoDuracion2LRPA");
        TextBox ttxt004LRPA = (TextBox)Tabs.FindControl("txt004LRPA");
        TextBox ttxt005LRPA = (TextBox)Tabs.FindControl("txt005LRPA");
        TextBox ttxt006LRPA = (TextBox)Tabs.FindControl("txt006LRPA");
        TextBox ttxt008LRPA = (TextBox)Tabs.FindControl("txt008LRPA");    


        DateTime fechainiciosancion = Convert.ToDateTime("01/01/1900");

        if (tddown009LRPA.Text.ToUpper() != "SELECCIONE FECHA")
        {
            fechainiciosancion = Convert.ToDateTime(tddown009LRPA.Text);
            tlblfechaini2LRPA.Text = "";

            if (ttxt004LRPA.Text.Trim() == "" && ttxt005LRPA.Text.Trim() == "" && ttxt008LRPA.Text.Trim() == "")
            {
                tlbl_avisoDuracion2LRPA.Text = "Ingrese al menos un parametro";
                tlbl_avisoDuracion2LRPA.Visible = true;

            }
            else
            {
                tlbl_avisoDuracion2LRPA.Visible = false;
                if (ttxt004LRPA.Text.Trim() == "")
                { ttxt004LRPA.Text = "0"; }
                if (ttxt005LRPA.Text.Trim() == "")
                { ttxt005LRPA.Text = "0"; }
                if (ttxt008LRPA.Text == "")
                { ttxt008LRPA.Text = "0"; }

                DateTime fechatermino = Convert.ToDateTime(tddown009LRPA.Text).AddYears(Convert.ToInt32(ttxt005LRPA.Text.Trim()));
                fechatermino = fechatermino.AddMonths(Convert.ToInt32(ttxt004LRPA.Text.Trim()));
                fechatermino = fechatermino.AddDays(Convert.ToInt32(ttxt008LRPA.Text.Trim()));
                ttxt006LRPA.Text = fechatermino.ToShortDateString();

            }


        }
        else
        {
            tlblfechaini2LRPA.Text = "Ingrese Fecha de Inicio";
            ttxt004LRPA.Text = "";
            ttxt005LRPA.Text = "";
            ttxt008LRPA.Text = "";

        }


    }
   
  
  
    //protected void Tabs_TabClick(object sender, EventArgs e)
    //{
    //    validatedata(Tabs.ActiveTabIndex, false);
       
    //}
    protected void lnk001_Click(object sender, EventArgs e)
    {
        window.open(this.Page, "ninos_ingresonuevo.aspx", "", 550, 650, true);
    }
    protected void lnk002_Click1(object sender, EventArgs e)
    {
        carga_grilla();
        lbl0013.Visible = false;
        lbl0014.Visible = false;
        lbl0015.Visible = false;
        lnk001.Visible = false;
        lnk002.Visible = false;
    }
    private void carga_grilla()
    {
        if (lblSwich.Text == "B")
        {
            DataView dv = new DataView(DTBusqueda);
            dv.Sort = "Apellido_paterno, Apellido_Materno, Nombres";
            grd003.DataSource = dv;
            grd003.DataBind();
            grd003.Visible = true;

         
        }
        else
        {
            DataView dv = new DataView(DTBusqueda);
            grd004.DataSource = dv;
            grd004.DataBind();
            grd004.Visible = true;
        }
    }
    protected void btnBuscaProyecto_Click(object sender, ImageClickEventArgs e)
    {
        window.open(this.Page, "../mod_coordinadores/busca_proyectosNuevaLey.aspx", "Buscador", false, false, 750, 300, false, false, true);
    }
    protected void btn002_Click(object sender, EventArgs e)
    {
       
        
        
            GridView grd001 = (GridView)Tabs.FindControl("grd001");
            GridView grd002 = (GridView)Tabs.FindControl("grd002");
            DropDownList tddown018 = (DropDownList)Tabs.FindControl("ddown018");
            DropDownList tddown019 = (DropDownList)Tabs.FindControl("ddown019");
            DropDownList tddown_otc = (DropDownList)Tabs.FindControl("ddown_otc");
            TextBox ttxt006 = (TextBox)Tabs.FindControl("txt006");

            // DropDownList tddown021 = (DropDownList)Tabs.FindControl("ddown021");
            Label tlbl_causales = (Label)Tabs.FindControl("lbl_causales");

            if (tddown_otc.SelectedValue == "0" || tddown018.SelectedValue == "0" || tddown019.SelectedValue == "0")
            {
                if (tddown_otc.SelectedValue == "0")
                { tddown_otc.BackColor = System.Drawing.Color.Pink; }
                else
                { tddown_otc.BackColor = System.Drawing.Color.White; }

                if (tddown018.SelectedValue == "0")
                { tddown018.BackColor = System.Drawing.Color.Pink; }
                else { tddown018.BackColor = System.Drawing.Color.White; }

                if (tddown019.SelectedValue == "0")
                { tddown019.BackColor = System.Drawing.Color.Pink; }
                else { tddown019.BackColor = System.Drawing.Color.White; }
            }
            else
            {

                DataRow dr = DTcausales.NewRow();

                tlbl_causales.Text = "";

                bool validaOT = false;
                if (tddown_otc.SelectedValue == "0")
                {
                    validaOT = true;
                }
                else
                {
                    validaOT = false;
                }

                if (!validaOT)
                {
                    tddown_otc.BackColor = System.Drawing.Color.White;
                    if (grd002.Rows.Count != 0)
                    {

                        bool swf = false;

                        if (grd002.Rows.Count == 2)
                        {
                            if ((grd002.Rows[1].Cells[3].Text) == Convert.ToString(tddown019.SelectedItem))
                            {
                                tlbl_causales.Text = "Esta Causal ya existe, Ingrese una distinta";
                                tlbl_causales.Visible = true;
                                swf = true;

                            }
                        }


                        for (int j = 0; j < grd002.Rows.Count;j++)
                        {
                            if (Server.HtmlDecode((grd002.Rows[j].Cells[3].Text)) != Convert.ToString(tddown019.SelectedItem) && swf == false) //|| (grd002.Rows[1].Cells[2].Text) != Convert.ToString(tddown018.SelectedItem))
                            {
                                dr[0] = Convert.ToInt32(tddown018.SelectedValue);
                                dr[1] = Convert.ToInt32(tddown019.SelectedValue);
                                dr[2] = tddown018.SelectedItem.Text;
                                dr[3] = tddown019.SelectedItem.Text;
                                dr[4] = ttxt006.Text.Trim();
                                dr[5] = tddown_otc.SelectedValue;
                               
                                DTcausales.Rows.Add(dr);

                            }
                            else
                            {
                                tlbl_causales.Text = "Esta Causal ya existe, Ingrese una distinta";
                                tlbl_causales.Visible = true;
                            }
                            break;
                        }
                    }
                    else
                    {
                        tlbl_causales.Text = "";
                        dr[0] = Convert.ToInt32(tddown018.SelectedValue);
                        dr[1] = Convert.ToInt32(tddown019.SelectedValue);
                        dr[2] = tddown018.SelectedItem.Text;
                        dr[3] = tddown019.SelectedItem.Text;
                        dr[4] = ttxt006.Text.Trim();
                        dr[5] = tddown_otc.SelectedValue;

                        DTcausales.Rows.Add(dr);

                    }


                    DataView dv = new DataView(DTcausales);
                    grd002.DataSource = dv;
                    grd002.DataBind();
                    grd002.Visible = true;

                    tddown_otc.SelectedValue = Convert.ToString(0);
                    tddown018.SelectedValue = Convert.ToString(0);
                    tddown019.SelectedValue = Convert.ToString(0);
                    ttxt006.Text = String.Empty;
                }
                else
                {
                    tddown_otc.BackColor = System.Drawing.Color.Pink;
                }
            }
            TextBox ttxtfoco2 = (TextBox)Tabs.FindControl("txtfoco2");
            ttxtfoco2.Focus();
    }
    protected void grd001LRPA_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        GridView tgrd001LRPA = (GridView)Tabs.FindControl("grd001LRPA");
        DTmedidas.Rows.Remove(DTmedidas.Rows[Convert.ToInt32(e.CommandArgument)]);

        tgrd001LRPA.DataSource = DTmedidas;
        tgrd001LRPA.DataBind();
           
        if (tgrd001LRPA.Rows.Count > 0)
            tgrd001LRPA.Visible = true;
        else
            tgrd001LRPA.Visible = false;

        TextBox ttxtfoco3 = (TextBox)Tabs.FindControl("txtfoco3");
        ttxtfoco3.Focus();
        
    }


    protected void grd001Audiencia_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       GridView tgrd001Audiencia = (GridView)Tabs.FindControl("grd001Audiencia");
       DTaudiencia.Rows.Remove(DTaudiencia.Rows[Convert.ToInt32(e.CommandArgument)]);

       tgrd001Audiencia.DataSource = DTaudiencia;
       tgrd001Audiencia.DataBind();

       if (tgrd001Audiencia.Rows.Count > 0)
        tgrd001Audiencia.Visible = true;
       else
        tgrd001Audiencia.Visible = false;

        TextBox ttxtfoco4 = (TextBox)Tabs.FindControl("txtfoco4");
        ttxtfoco4.Focus();

        
    }
  
    protected void btn001AgregarAudiencia_Click(object sender, EventArgs e)
    {
        GridView tgrd001Audiencia = (GridView)Tabs.FindControl("grd001Audiencia");
        DropDownList tddown_ota = (DropDownList)Tabs.FindControl("ddown_ota");
        DropDownList tddown021 = (DropDownList)Tabs.FindControl("ddown021");
        TextBox ttxt007 = (TextBox)Tabs.FindControl("txt007");
        TextBox tddown001Audiencia = (TextBox)Tabs.FindControl("ddown001Audiencia");

        if (tddown021.SelectedValue == "0" || tddown_ota.SelectedValue == "" || tddown001Audiencia.Text == "Seleccione Fecha")
        {

            if (tddown021.SelectedValue == "0")
            { tddown021.BackColor = System.Drawing.Color.Pink; }
            else { tddown021.BackColor = System.Drawing.Color.White; }
            
            if (tddown_ota.SelectedValue == "")
            { tddown_ota.BackColor = System.Drawing.Color.Pink; }
            else { tddown_ota.BackColor = System.Drawing.Color.White; }

            if (tddown001Audiencia.Text == "Seleccione Fecha")
            { tddown001Audiencia.BackColor = System.Drawing.Color.Pink; }
            else { tddown001Audiencia.BackColor = System.Drawing.Color.White; }


        }
        else
        {
            bool chk = false;
            for (int i=0; i < tgrd001Audiencia.Rows.Count; i++)
            {
                if (Convert.ToDateTime(tgrd001Audiencia.Rows[i].Cells[4].Text).ToShortDateString() == Convert.ToDateTime(tddown001Audiencia.Text).ToShortDateString() &&
                   tddown021.SelectedItem.Text == Server.HtmlDecode(tgrd001Audiencia.Rows[i].Cells[2].Text))
                {
                    chk = true;
                }


            }

            if (!chk)
            {

                DataRow dr = DTaudiencia.NewRow();
                dr[0] = tddown_ota.SelectedValue.ToString();
                dr[1] = Convert.ToDateTime(tddown001Audiencia.Text);
                dr[2] = Convert.ToInt32(tddown021.SelectedValue);
                dr[3] = tddown021.SelectedItem.Text;
                dr[4] = ttxt007.Text;
                DTaudiencia.Rows.Add(dr);

                tgrd001Audiencia.DataSource = DTaudiencia;
                tgrd001Audiencia.DataBind();
                tgrd001Audiencia.Visible = true;


                tddown_ota.SelectedValue = "0";
                tddown001Audiencia.Text = "Seleccione Fecha";
                
                ttxt007.Text = "";

                tddown_ota.BackColor = System.Drawing.Color.White;
                tddown021.BackColor = System.Drawing.Color.White;
                tddown001Audiencia.BackColor = System.Drawing.Color.White;
            }
        }
       // tddown021.SelectedValue = "0";
        TextBox ttxtfoco4 = (TextBox)Tabs.FindControl("txtfoco4");
        ttxtfoco4.Focus();
    }
    protected void btnproy_Click(object sender, EventArgs e)
    {
        TextBox txt001 = (TextBox)Tabs.FindControl("txt001");
        txt001.Text = "(" + CodProy + ") " + Server.HtmlDecode(NomProy);
    }
    
    //protected void btnsaveingreso_Click1(object sender, EventArgs e)
    //{
    //    Ingreso();
        
    //    limpia_controles();

       
    //}
    private void Ingreso()
    {
        if (validatedata(0, true))
        {
            lblbmsg.Text = "Faltan datos para completar el Ingreso";
            lblbmsg.Visible = true;
        }
        else
        {

            TextBox tddown001 = (TextBox)Tabs.FindControl("ddown001");
            DropDownList tddown_ota = (DropDownList)Tabs.FindControl("ddown_ota");
            TextBox ttxt007 = (TextBox)Tabs.FindControl("txt007");
            
            coordinador cr = new coordinador();
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();

#region Insert ORDENDETRIBUNAL
            int sentenciaejec = 0;
            for (int i = 0; i < DTordentribunales.Rows.Count; i++)//ORGENDETRIBUNAL
            {

                if (DTordentribunales.Rows[i][3].ToString() == "Si")
                {
                    sentenciaejec = 1;
                }
                else if (DTordentribunales.Rows[i][3].ToString() == "No")
                {
                    sentenciaejec = 0;
                }
                else
                {
                    sentenciaejec = 2;
                }
                dt = cr.callto_insert_coordinacionordentribunal(Convert.ToInt32(DTordentribunales.Rows[i][0]),
                DTordentribunales.Rows[i][4].ToString(), DTordentribunales.Rows[i][5].ToString(), Convert.ToDateTime(DTordentribunales.Rows[i][2]),
                sentenciaejec, Convert.ToInt32(Session["IdUsuario"]), DateTime.Now);

                DTordentribunales.Rows[i][7] = dt.Rows[0][0].ToString();
                VICodOrdenTribunal = Convert.ToInt32(DTordentribunales.Rows[i][7].ToString());


                DropDownList tddown03_ot = (DropDownList)Tabs.FindControl("ddown03_ot");
                DropDownList tddown03_rt = (DropDownList)Tabs.FindControl("tddown03_rt");
                GridView tgrd001_resolucion = (GridView)Tabs.FindControl("grd001_resolucion");
                
                int icodie = Convert.ToInt32(dt.Rows[0][0]);
                dt.Clear();
                
                
                
                dt.Clear();


                for (int j = 0; tgrd001_resolucion.Rows.Count > j; j++)
                {

                    dt1 = cr.callto_insert_coordinacioningreso(
                        Convert.ToInt32(DTordentribunales.Rows[i][7])
                        , Convert.ToInt32(DTResoluciones.Rows[j][5])
                        , Convert.ToInt32(lbl004.Text)
                        , Convert.ToInt32(DTResoluciones.Rows[j][7])/*Convert.ToInt32(CodProy)*/
                        , VFechaderivacion
                        , Convert.ToInt32(Session["IdUsuario"])
                        , DateTime.Now
                        );

                }

            
            }

                        int codorden = 0;
#endregion

#region Insert Causales 
            for (int i = 0; i < DTcausales.Rows.Count; i++)
            {
                for (int j = 0; j < DTordentribunales.Rows.Count; j++)
                {
                    if (DTordentribunales.Rows[j][6].ToString() == DTcausales.Rows[i][5].ToString())
                    {
                        codorden = Convert.ToInt32(DTordentribunales.Rows[j][7]);
                    }
                }
                dt = cr.callto_insert_coordinacioncausalingreso(Convert.ToInt32(DTcausales.Rows[i][1]),
                Convert.ToInt32(DTcausales.Rows[i][4]), codorden, Convert.ToInt32(Session["IdUsuario"]), DateTime.Now);

            }
            dt.Clear();
            codorden = 0;
#endregion

#region Insert PlazoMedida e Investigacion
    
    GridView tgrd004_lrpaMedInv = (GridView)Tabs.FindControl("grd004_lrpaMedInv");

    if (tgrd004_lrpaMedInv.Rows.Count > 0)
    {
        for (int i = 0; i < DTMedidasSancion.Rows.Count; i++)
        { 

            dt = cr.callto_insert_MedidasInvestigacion(
                Convert.ToInt32(VICodOrdenTribunal),
                Convert.ToDateTime(DTMedidasSancion.Rows[i][1]),
                Convert.ToDateTime(DTMedidasSancion.Rows[i][2]),
                Convert.ToInt32(DTMedidasSancion.Rows[i][3]),
                Convert.ToInt32(DTMedidasSancion.Rows[i][4]),
                Convert.ToDateTime(DTMedidasSancion.Rows[i][5]),
                Convert.ToInt32(Session["IdUsuario"]),
                DateTime.Now);

            int iden = Convert.ToInt32(dt.Rows[0][0]);

            for (int j = 0; j < DTAmpliacionesMedidas.Rows.Count; j++)
            {
                if (DTAmpliacionesMedidas.Rows.Count > 0)
                {
                    dt = cr.callto_insert_CoordinacionAmpliaInvestigacion(iden
                        , Convert.ToInt32(DTAmpliacionesMedidas.Rows[j][2])
                        , Convert.ToDateTime(DTAmpliacionesMedidas.Rows[j][0])
                        , Convert.ToInt32(Session["IdUsuario"])
                        );
                }
            }
         
        
        }

       
    }


#endregion

#region MEDIDAS ANTIGUAS

            GridView tgrd001LRPA = (GridView)Tabs.FindControl("grd001LRPA");

          //  for (int i = 0; i < DTMedidasSancion.Rows.Count; i++)
            for(int i = 0; i < DTSancionV2.Rows.Count; i++)
            {
                for (int j = 0; j < DTordentribunales.Rows.Count; j++)
                { 
                    //if (DTordentribunales.Rows[j][6].ToString() == DTmedidas.Rows[i][7].ToString())
                    //{
                        codorden = Convert.ToInt32(DTordentribunales.Rows[j][7]);
                    //} 
    
                }
                
                dt = cr.callto_insert_coordinacionsancion(codorden
                    , Convert.ToDateTime(DTSancionV2.Rows[i][1])
                    , Convert.ToDateTime(DTSancionV2.Rows[i][2])
                    , Convert.ToInt32(DTSancionV2.Rows[i][3])
                    , Convert.ToInt32(DTSancionV2.Rows[i][4])
                    , Convert.ToInt32(DTSancionV2.Rows[i][5])
                    , Convert.ToInt32(DTSancionV2.Rows[i][6])
                    , Convert.ToInt32(DTSancionV2.Rows[i][7])
                    , Convert.ToInt32(DTSancionV2.Rows[i][8])
                    , Convert.ToInt32(DTSancionV2.Rows[i][9])
                    , Convert.ToDateTime(DTSancionV2.Rows[i][10])
                    , Convert.ToDateTime(DTSancionV2.Rows[i][11])
                    , Convert.ToInt32(DTSancionV2.Rows[i][12])
                    , Convert.ToInt32(DTSancionV2.Rows[i][13])
                    , Convert.ToInt32(DTSancionV2.Rows[i][14])
                    , -1                                         //Convert.ToInt32(DTSancionV2.Rows[i][15])
                    , Convert.ToDateTime("01-01-1900")          // Convert.ToDateTime(DTSancionV2.Rows[i][16])
                    , Convert.ToInt32(DTSancionV2.Rows[i][17])
                    , Convert.ToInt32(Session["IdUsuario"])
                    , DateTime.Now
                    );

                for (int k = 0; k < tgrd001LRPA.Rows.Count; k++)
                {
                    cr.callto_insert_coordinacionsancionaccesoria(Convert.ToInt32(DTTipoSancionAccesoria.Rows[k][2]), Convert.ToInt32(dt.Rows[i][0]));//Convert.ToInt32(DTTipoSancionAccesoria.Rows[i][3]));
                }
              
            }
             
            dt.Clear();
            codorden = 0;

           
                  
#endregion

#region INSERT AUDIENCIA

            for (int i = 0; i < DTaudiencia.Rows.Count; i++)
            {
                for (int j = 0; j < DTordentribunales.Rows.Count; j++)
                {
                    if (DTordentribunales.Rows[j][6].ToString() == DTaudiencia.Rows[i][0].ToString())
                    {
                        codorden = Convert.ToInt32(DTordentribunales.Rows[j][7]);
                    }
                }
                dt = cr.callto_insert_coordinacionaudiencia(codorden, 
                    Convert.ToInt32(DTaudiencia.Rows[i][2]),
                    DTaudiencia.Rows[i][4].ToString().ToUpper(),
                    Convert.ToDateTime(DTaudiencia.Rows[i][1]), 
                    Convert.ToInt32(Session["IdUsuario"]), 
                    DateTime.Now);
            }

#endregion

            lblbmsg.Text = "INGRESO EFECTUADO SATISFACTORIAMENTE.";
            lblbmsg.Visible = true;

            pnl001.Visible = false;
            Tabs.Visible = false;

        }
    }
    private void limpia_controles()
    {
        #region Limpia_buscador
        txt007.Text = "";
        txt002.Text = "";
        txt004.Text = "";
        txt005.Text = "";
        txt006.Text = "";

        txt002.Enabled = true;
        txt004.Enabled = true;
        txt005.Enabled = true;
        txt006.Enabled = true;
        txt007.Enabled = true;


        btn_buscar.Visible = true;
        btn_modificar.Visible = true;

        grd003.Visible = false;
        grd004.Visible = false;
        #endregion

        #region Limpia_Tabs
        DataTable dt = new DataTable();
        for (int i = 0; i < Tabs.Tabs.Count; i++)
        {
            Tabs.Tabs[i].ForeColor = System.Drawing.Color.Black;
        }
        for (int i = 1; i < Tabs.Tabs.Count; i++)
        {
            Tabs.Tabs[i].Visible = false;
        }
        Tabs.TabIndex = 0;
        pnl001.Visible = false;
        Tabs.Visible = false;
        #endregion
        
        #region Limpia_tab1 Ordenes del tribunal
        DropDownList tddown016 = (DropDownList)Tabs.FindControl("ddown016");
        DropDownList tddown014 = (DropDownList)Tabs.FindControl("ddown014");
        DropDownList tddown015 = (DropDownList)Tabs.FindControl("ddown015");
        //DropDownList tddown_ota = (DropDownList)Tabs.FindControl("ddown_ota");
        //DropDownList tddown_otc = (DropDownList)Tabs.FindControl("ddown_otc");
        //DropDownList tddown_otm = (DropDownList)Tabs.FindControl("ddown_otm");
        GridView tgrd001 = (GridView)Tabs.FindControl("grd001");
        TextBox tddown017 = (TextBox)Tabs.FindControl("ddown017");
        TextBox ttxt006F2 = (TextBox)Tabs.FindControl("txt006F2");
        TextBox ttxt007F2 = (TextBox)Tabs.FindControl("txt007F2");
        RadioButtonList trdo001 = (RadioButtonList)Tabs.FindControl("rdo001");

        tddown014.SelectedIndex = -1;
        tddown015.SelectedIndex = -1;
        tddown016.SelectedIndex = -1;
        //tddown_ota.Items.Clear();
        //tddown_otc.Items.Clear();
        // tddown_otm.Items.Clear();
        ListItem item = new ListItem("Seleccionar", "0");
        //tddown_ota.Items.Add(item);
        //tddown_otc.Items.Add(item);
        // tddown_otm.Items.Add(item);
        tgrd001.DataSource = dt;
        tgrd001.DataBind();
        tgrd001.Visible = false;
        tddown017.Text = null;
        ttxt006F2.Text = "";
        ttxt007F2.Text = "";
        trdo001.SelectedValue = "0";

        tddown014.BackColor = System.Drawing.Color.White;
        tddown015.BackColor = System.Drawing.Color.White;
        tddown016.BackColor = System.Drawing.Color.White;
        //tddown_ota.BackColor = System.Drawing.Color.White;
        //tddown_otc.BackColor = System.Drawing.Color.White;
        // tddown_otm.BackColor = System.Drawing.Color.White;
        ttxt006F2.BackColor = System.Drawing.Color.White;
        ttxt007F2.BackColor = System.Drawing.Color.White;

        #endregion

        #region Limpia_tab2 Delito
        GridView grd002 = (GridView)Tabs.FindControl("grd002");
        DropDownList tddown_otc = (DropDownList)Tabs.FindControl("ddown_otc");
        DropDownList tddown018 = (DropDownList)Tabs.FindControl("ddown018");
        DropDownList tddown019 = (DropDownList)Tabs.FindControl("ddown019");
        TextBox ttxt006 = (TextBox)Tabs.FindControl("txt006");
        Label tlbl_causales = (Label)Tabs.FindControl("lbl_causales");

        grd002.DataSource = dt;
        grd002.DataBind();
        grd002.Visible = false;
        tddown_otc.Items.Add(item);
        tddown018.SelectedIndex = -1;
        tddown019.SelectedIndex = -1;
        ttxt006.Text = "";
        tlbl_causales.Visible = false;

        tddown018.BackColor = System.Drawing.Color.White;
        tddown019.BackColor = System.Drawing.Color.White;
        ttxt006.BackColor = System.Drawing.Color.White;
        tddown_otc.BackColor = System.Drawing.Color.White;

        #endregion

        #region Limpia_tab3 ResolucionTribunal
       // TextBox ttxt001 = (TextBox)Tabs.FindControl("txt001");
        DropDownList tddown03_ot = (DropDownList)Tabs.FindControl("ddown03_ot");
        DropDownList tddown03_rt = (DropDownList)Tabs.FindControl("ddown03_rt");
        DropDownList tddown003_proy = (DropDownList)Tabs.FindControl("ddown003_proy");
        TextBox tddown001 = (TextBox)Tabs.FindControl("ddown001");
        GridView tgrd001_Resolucion = (GridView)Tabs.FindControl("grd001_Resolucion");



       // ttxt001.Text = "";
        tddown03_ot.Items.Add(item);
        tddown03_rt.SelectedIndex = -1;
        //tddown003_proy.SelectedIndex = -1;
        tddown001.Text = null;
        tgrd001_Resolucion.DataSource = dt;
        tgrd001_Resolucion.DataBind();
        tgrd001_Resolucion.Visible = false;
       // ttxt001.BackColor = System.Drawing.Color.White;
        
        tddown03_ot.BackColor = System.Drawing.Color.White;
        tddown03_rt.BackColor = System.Drawing.Color.White;
        //tddown003_proy.BackColor = System.Drawing.Color.White;
        tddown001.BackColor = System.Drawing.Color.White;

       

        #endregion
             
        #region Limpia_tab4.1 Palzos Medida e Investigacion

        DropDownList tddown4_otm = (DropDownList)Tabs.FindControl("ddown4_otm");
        TextBox twdcMedInv = (TextBox)Tabs.FindControl("wdcMedInv");
        TextBox ttxtLRPA_PlazMed = (TextBox)Tabs.FindControl("txtLRPA_PlazMed");
        TextBox ttxtLRPA_PlazInv = (TextBox)Tabs.FindControl("txtLRPA_PlazInv");
        TextBox ttxtLrpa_FechPlazMed = (TextBox)Tabs.FindControl("txtLrpa_FechPlazMed");
        TextBox ttxtLrpa_FechPlazInv = (TextBox)Tabs.FindControl("txtLrpa_FechPlazInv");
        TextBox ttxtAmplDias = (TextBox)Tabs.FindControl("txtAmplDias");
        //WebNumericEdit ttxt002LRPA = (WebNumericEdit)Tabs.FindControl("txt002LRPA");
        //WebNumericEdit ttxt007LRPA = (WebNumericEdit)Tabs.FindControl("txt007LRPA");
        //WebNumericEdit ttxt009LRPA = (WebNumericEdit)Tabs.FindControl("txt009LRPA");
        //TextBox ttxt003LRPA = (TextBox)Tabs.FindControl("txt003LRPA");
        //Label tlbl_avisoDuracionLRPA = (Label)Tabs.FindControl("lbl_avisoDuracionLRPA");
        //WebDateChooser tddown001LRPA = (TextBox)Tabs.FindControl("ddown001LRPA");
        //Label tllblfechaini1LRPA = (Label)Tabs.FindControl("lblfechaini1LRPA");
        //GridView tgrd001LRPA = (GridView)Tabs.FindControl("grd001LRPA");
        GridView tgrd004_LrpaMedInv = (GridView)Tabs.FindControl("grd004_LrpaMedInv");
        GridView tgrdLrpa_Actuaplazo = (GridView)Tabs.FindControl("grdLrpa_Actuaplazo");

        tddown4_otm.Items.Add(item);
        twdcMedInv.Text = null;
        ttxtLRPA_PlazMed.Text = "";
        ttxtLRPA_PlazInv.Text = "";
        ttxtLrpa_FechPlazMed.Text = "";
        ttxtLrpa_FechPlazInv.Text = "";
        ttxtLrpa_FechPlazMed.Text = "";
        ttxtLrpa_FechPlazInv.Text = "";
        ttxtAmplDias.Text = "";


        tgrd004_LrpaMedInv.DataSource = dt;
        tgrd004_LrpaMedInv.DataBind();
        tgrd004_LrpaMedInv.Visible = false;

        tgrdLrpa_Actuaplazo.DataSource = dt;
        tgrdLrpa_Actuaplazo.DataBind();
        tgrdLrpa_Actuaplazo.Visible = false;

        tddown4_otm.BackColor = System.Drawing.Color.White;
        twdcMedInv.BackColor = System.Drawing.Color.White;
        ttxtLRPA_PlazMed.BackColor = System.Drawing.Color.White;
        ttxtLRPA_PlazInv.BackColor = System.Drawing.Color.White; 
        ttxtLrpa_FechPlazMed.BackColor = System.Drawing.Color.White; 
        ttxtLrpa_FechPlazInv.BackColor = System.Drawing.Color.White; 
        ttxtLrpa_FechPlazMed.BackColor = System.Drawing.Color.White; 
        ttxtLrpa_FechPlazInv.BackColor = System.Drawing.Color.White;
        ttxtAmplDias.BackColor = System.Drawing.Color.White; 



        #endregion
        
        #region Limpia_tab4.2 Sancion

        GridView tgrdseleccionLrpa = (GridView)Tabs.FindControl("grdseleccionLrpa");
        GridView tgrd001LRPA = (GridView)Tabs.FindControl("grd001LRPA");
        DropDownList tddown_otm = (DropDownList)Tabs.FindControl("ddown_otm");
        TextBox tddown001LRPA = (TextBox)Tabs.FindControl("ddown001LRPA");
        TextBox ttxt0010LRPA = (TextBox)Tabs.FindControl("txt0010LRPA");
        TextBox ttxt001LRPA = (TextBox)Tabs.FindControl("txt001LRPA");
        TextBox ttxt002LRPA = (TextBox)Tabs.FindControl("txt002LRPA");
        TextBox ttxt007LRPA = (TextBox)Tabs.FindControl("txt007LRPA");
        TextBox ttxt009LRPA = (TextBox)Tabs.FindControl("txt009LRPA");
        TextBox ttxt003LRPA = (TextBox)Tabs.FindControl("txt003LRPA");
        CheckBox tchk002LRPAMixta = (CheckBox)Tabs.FindControl("chk002LRPAMixta");
        TextBox tddown009LRPA = (TextBox)Tabs.FindControl("ddown009LRPA");
        TextBox ttxt005LRPA = (TextBox)Tabs.FindControl("txt005LRPA");
        TextBox ttxt004LRPA = (TextBox)Tabs.FindControl("txt004LRPA");
        TextBox ttxt008LRPA = (TextBox)Tabs.FindControl("txt008LRPA");
        TextBox ttxt006LRPA = (TextBox)Tabs.FindControl("txt006LRPA");
        DropDownList tddown011LRPA = (DropDownList)Tabs.FindControl("ddown011LRPA");
        DropDownList tddown003LRPA = (DropDownList)Tabs.FindControl("ddown003LRPA");
        DropDownList tddown004LRPA = (DropDownList)Tabs.FindControl("ddown004LRPA");
        DropDownList tddown005LRPA = (DropDownList)Tabs.FindControl("ddown005LRPA");
        DropDownList tddown006LRPA = (DropDownList)Tabs.FindControl("ddown006LRPA");
        TextBox tddown007LRPA = (TextBox)Tabs.FindControl("ddown007LRPA");
       

        tddown_otm.SelectedValue = "0";
        tddown011LRPA.SelectedValue = "-1";//////error
        tddown003LRPA.SelectedValue = "-2";
        tddown004LRPA.SelectedValue = "0";
        tddown005LRPA.SelectedValue = "0";
        tddown006LRPA.SelectedValue = "0";
        tddown007LRPA.Text = "Seleccione Fecha";
        tddown009LRPA.Text = "Seleccione Fecha";
        tddown001LRPA.Text = "Seleccione Fecha";
        //tddown007LRPA.Value = "Seleccione Fecha";
        ttxt0010LRPA.Text = "";
        ttxt001LRPA.Text = "";
        ttxt002LRPA.Text = "";
        ttxt003LRPA.Text = "";
        ttxt004LRPA.Text = "";
        ttxt005LRPA.Text = "";
        ttxt006LRPA.Text = "";
        ttxt007LRPA.Text = ""; ttxt008LRPA.Text = "";
        ttxt009LRPA.Text = "";
        tgrdseleccionLrpa.Columns.Clear();
        tgrdLrpa_Actuaplazo.Columns.Clear();
        tgrdseleccionLrpa.Columns.Clear();
        tgrd001LRPA.Columns.Clear();
        tddown4_otm.SelectedValue = "0";
        twdcMedInv.Text = "Seleccione Fecha";
        


        #endregion
        
        #region Limpia_tab5 Audiencia

        GridView tgrd001Audiencia = (GridView)Tabs.FindControl("grd001Audiencia");
        DropDownList tddown_ota = (DropDownList)Tabs.FindControl("ddown_ota");
       // DropDownList tddown001audiencia = (DropDownList)Tabs.FindControl("ddown001audiencia");
        DropDownList tddown021 = (DropDownList)Tabs.FindControl("ddown021");
        TextBox ttxt007 = (TextBox)Tabs.FindControl("txt007");

        tgrd001Audiencia.DataSource = dt;
        tgrd001Audiencia.DataBind();
        tgrd001Audiencia.Visible = false;
        tddown_ota.Items.Add(item);
        //tddown001audiencia.SelectedIndex = -1;
        tddown021.SelectedIndex = -1;
        txt007.Text = "";
       

        tddown_ota.BackColor = System.Drawing.Color.White;
       // tddown001audiencia.BackColor = System.Drawing.Color.White;
        tddown021.BackColor = System.Drawing.Color.White;
        ttxt007.BackColor = System.Drawing.Color.White;

        #endregion

        # region Limpia Orenes de tribunales (Todos Los Tabs) 


        tddown_otc.Items.Clear();
        tddown_otm.Items.Clear();
        tddown_ota.Items.Clear();
        tddown4_otm.Items.Clear();
        tddown03_ot.Items.Clear();
        


        //tddown_otc.SelectedValue = "0";
        //tddown03_ot.SelectedValue = "0";
        //tddown4_otm.SelectedValue = "0";
        //tddown_otm.SelectedValue = "0";
        //tddown_ota.SelectedValue = "0";
        //    //DTordentribunales.Clear();


        //tddown_otc.Items.Remove(VOT);
        //tddown_otm.Items.Remove(VOT);
        //tddown_ota.Items.Remove(VOT);
        //tddown_otm.Items.Remove(VOT);

     

       



        # endregion 
        
    }


    //protected void btn_limpiar_Click(object sender, EventArgs e)
    //{
    //    limpia_controles();
    //    lblbmsg.Visible = false;
    //}
    //protected void btn_modificar_Click(object sender, EventArgs e)
    //{
    //    VIngreso_Mod = 1;
    //    Busca_ingresos();
    //    lblSwich.Text = "M";
    //    grd003.Visible = false;
    //    grd004.Visible = false;
    //    lblbmsg.Visible = false;
    //}
    protected void grd004_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ver")
        {
            lbl003.Text = grd004.Rows[Convert.ToInt32(e.CommandArgument)].Cells[7].Text;
            lbl004.Text = grd004.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
            lbl005.Text = grd004.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text;
            RUC_Rep = grd004.Rows[Convert.ToInt32(e.CommandArgument)].Cells[10].Text;
            lbl004.Visible = true;
            lbl005.Visible = true;
            lbl006.Visible = true;
            pnl001.Visible = true;
            Tabs.Visible = true;
            grd004.Visible = false;

            txt007.Text = grd004.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text;
            txt002.Text = grd004.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
            txt004.Text = grd004.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Text;
            txt005.Text = grd004.Rows[Convert.ToInt32(e.CommandArgument)].Cells[6].Text;
            txt006.Text = grd004.Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Text;

            txt002.Enabled = false;
            txt004.Enabled = false;
            txt005.Enabled = false;
            txt006.Enabled = false;
            txt007.Enabled = false;


            SSnino.CodNino = Convert.ToInt32(grd004.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text);
            btn_buscar.Visible = false;
            btn_modificar.Visible = false;

            coordinador cr = new coordinador();
            DataTable dt = new DataTable();
            DataTable dtOT = new DataTable();
            List<DbParameter> listDbParameter = new List<DbParameter>();

            string sqlOT = "Select t1.ICodOrdenTribunal " +
            "From Ninos T2 Inner join CoordinacionIngreso t1 on t1.CodNino = T2.CodNino " +
            "inner join CoordinacionOrdenTribunal t3 on t1.ICodOrdenTribunal = t3.ICodOrdenTribunal Inner Join proyectos t4 on " +
            "t4.codproyecto = t1.codproyecto Where t1.codnino =@pCodNino ";

            listDbParameter.Add(Conexiones.CrearParametro("@pCodNino", SqlDbType.Int, 4, Convert.ToInt32(grd004.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text)));

            dtOT = cr.ejecuta_SQL(sqlOT, listDbParameter);
            VICodOrdenTribunal = Convert.ToInt32(dtOT.Rows[0][0]);


            dt = cr.callto_get_coordinacioningreso(Convert.ToInt32(grd004.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text));

            CodProy = dt.Rows[0][2].ToString();

            #region EscondeTab
            
            ReporteNinoColl rpn = new ReporteNinoColl();
            DropDownList tddown03_Proy = (DropDownList)Tabs.FindControl("down03_Proy");
            
            
            DataTable dt0 = rpn.Reporte_GetProyectosLPRA(Convert.ToInt32(CodProy));
            
            //if (dt0.Rows[0][0].ToString() == "2" && dt0.Rows[0][1].ToString() == "20084")
            //{
            //    Tabs.Tabs[2].Style.ForeColor = System.Drawing.Color.Black;
            //    Tabs.Tabs[3].Visible = true;
            //    Tabs.Tabs[2].Style.ForeColor = System.Drawing.Color.Black;
            //    Tabs.Tabs[4].Visible = false;
            //}
            //else
            //{
            //    Tabs.Tabs[2].Style.ForeColor = System.Drawing.Color.Black;
            //    Tabs.Tabs[3].Visible = false;
            //    Tabs.Tabs[2].Style.ForeColor = System.Drawing.Color.Black;
            //    Tabs.Tabs[4].Visible = true;
            //}

            #endregion 

            carga_info();
            carga_ninosIngresados();

            if (VIngreso_Mod == 1)
            {
                Button tbtn002 = (Button)Tabs.FindControl("btn002");
                Button tbtn003 = (Button)Tabs.FindControl("btn003");
                Button tbtnAgregarMedSanc = (Button)Tabs.FindControl("btnAgregarMedSanc");
                Button tbtn_AmpliaPLazo = (Button)Tabs.FindControl("btn_AmpliaPLazo");
                //tbtn003 = (Button)Tabs.FindControl("");
                //tbtn002.Enabled = false;
                //tbtn003.Enabled = false;
                //tbtnAgregarMedSanc.Enabled = false;
                //tbtn_AmpliaPLazo.Enabled = false;
            }




            validate();
                    
        }
        if (e.CommandName == "eliminar")
        {
            pnl_coordinador.Visible = false;
            pnlAvisoElimina.Visible = true;
            lbl005.Text = grd004.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text;
            lbl_nino.Text = grd004.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Text;
            lbl_CodNino.Text = grd004.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;

        }
        if (e.CommandName == "historico")
        {

            window.open(this.Page, "../mod_coordinadores/coord_HistoricoNino_modifica.aspx?CODNINO=" + grd004.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text, "Historicos", true, 1000, 430, false, false, true);
        }
        if (e.CommandName == "ruc")
        {
            string icodie = grd004.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
            string ruc = grd004.Rows[Convert.ToInt32(e.CommandArgument)].Cells[10].Text;
            window.open(this.Page, "../mod_coordinadores/coord_historiconino_audiencia .aspx?CODNINO=" + icodie +"&RUC="+ruc , "Historicos", true, 600, 400, false, false, true);
        
        }

    }
    private void carga_ninosIngresados()
    {
        coordinador cr = new coordinador();
        DataTable dt = new DataTable();
        DataTable dt_OT = new DataTable();
        DataTable dt_sp = new DataTable();
        DataTable dt_sancion = new DataTable();
        Button tbtnsaveingreso = (Button)Tabs.FindControl("btnsaveingreso");
        Button tbtnactualizaingreso = (Button)Tabs.FindControl("btnactualizaingreso");
        Label tlbl004 = (Label)Tabs.FindControl("lbl004");
        tbtnsaveingreso.Visible = false;
        tbtnactualizaingreso.Visible = true;

        #region carga_Tab1 Ordenes de Tribunal

        DropDownList tddown_ota = (DropDownList)Tabs.FindControl("ddown_ota");
        DropDownList tddown_otc = (DropDownList)Tabs.FindControl("ddown_otc");
        DropDownList tddown_otm = (DropDownList)Tabs.FindControl("ddown_otm");
        DropDownList tddown4_otm = (DropDownList)Tabs.FindControl("ddown4_otm");
        DropDownList tddown_ot = (DropDownList)Tabs.FindControl("ddown_ot");
        DropDownList tddown03_ot = (DropDownList)Tabs.FindControl("ddown03_ot");
        GridView tgrd001 = (GridView)Tabs.FindControl("grd001");
        GridView tgrd004_lrpaMedInv = (GridView)Tabs.FindControl("grd004_lrpaMedInv");
        Button tbtn001 = (Button)Tabs.FindControl("btn001");
        tbtn001.Enabled = false;
        dt = cr.callto_get_coordinacionordentribunal(VICodOrdenTribunal);//Convert.ToInt32(lbl005.Text));

        DataRow dr;

        string sql;
        List<DbParameter> listDbParameter = new List<DbParameter>();

        sql = "select Descripcion from parTribunales where codtribunal =@pcodtribunal";

        listDbParameter.Add(Conexiones.CrearParametro("@pcodtribunal", SqlDbType.Int, 4, -1));

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            listDbParameter[0].Value = Convert.ToInt32(dt.Rows[i][1].ToString());
            dt_sp = cr.ejecuta_SQL(sql, listDbParameter);
            string se = "No"; 
            if (dt.Rows[i][5].ToString() == "1")
            {
                se = "Si";
            }
            else if (dt.Rows[i][5].ToString() == "0")
            {
                se = "No";
            }
            else
            {
                se = "Sin Información";
            }
            dr = DTordentribunales.NewRow();
            dr[0] = Convert.ToInt32(dt.Rows[i][1]);
            dr[1] = dt_sp.Rows[0][0].ToString();
            dr[2] = Convert.ToDateTime(dt.Rows[i][4]);
            dr[3] = se;
            dr[4] = dt.Rows[i][2].ToString();
            dr[5] = dt.Rows[i][3].ToString();
            dr[6] = Convert.ToInt32(dt.Rows[i][0]);
            dr[7] = Convert.ToInt32(dt.Rows[i][0]);

            DTordentribunales.Rows.Add(dr);
            
            //ddown_otc
            //ddown4_otm nuevo

            ListItem oItem = new ListItem("(" + dt.Rows[i][2].ToString() + ")" + "-" + dt_sp.Rows[0][0].ToString(), dt.Rows[i][2].ToString());
            tddown_otc.Items.Add(oItem);
            tddown4_otm.Items.Add(oItem);
            tddown_otm.Items.Add(oItem);
            tddown_ota.Items.Add(oItem);
            tddown03_ot.Items.Add(oItem);

        }
        tgrd001.DataSource = DTordentribunales;
        tgrd001.DataBind();
        tgrd001.Visible = true;

        //coordinador cr = new coordinador();
        //DataTable dt = new DataTable();
        DropDownList tddown016 = (DropDownList)Tabs.FindControl("ddown016");
        //DropDownList tddown_otc = (DropDownList)Tabs.FindControl("ddown_otc");
        //DropDownList tddown03_ot = (DropDownList)Tabs.FindControl("ddown03_ot");
        //DropDownList tddown_otm = (DropDownList)Tabs.FindControl("ddown_otm");
        //DropDownList tddown4_otm = (DropDownList)Tabs.FindControl("ddown4_otm");
        //DropDownList tddown_ota = (DropDownList)Tabs.FindControl("ddown_ota");
        //GridView tgrd001 = (GridView)Tabs.FindControl("grd001");
        string iden = Guid.NewGuid().ToString();

        if (tddown016.SelectedValue.ToString() != "")
        {

            ListItem oItem = new ListItem("(" + tddown016.SelectedValue.ToString() + ")" + "-" + tddown016.SelectedItem.Text, iden);
            tddown_otc.Items.Add(oItem);
            tddown03_ot.Items.Add(oItem);
            tddown_otm.Items.Add(oItem);
            tddown4_otm.Items.Add(oItem);
            tddown_ota.Items.Add(oItem);

        }
        if(tddown016.SelectedValue.ToString() != "" && tgrd001.Rows.Count>0)
        {

            string sParametrosConsulta = "";
            sParametrosConsulta = "Select CodTribunal From ParTribunales" +
            " WHERE CodTribunal =@pCodTribunal ";

            listDbParameter.Clear();
            listDbParameter.Add(Conexiones.CrearParametro("@pCodTribunal", SqlDbType.Int, 4, Convert.ToInt32(DTordentribunales.Rows[0][0].ToString())));

            dt = cr.ejecuta_SQL(sParametrosConsulta, listDbParameter);

            ListItem oItem = new ListItem("(" + dt.Rows[0][0].ToString() + ")" + "-" + DTordentribunales.Rows[0][1].ToString(), iden);
            tddown_otc.Items.Add(oItem);
            tddown03_ot.Items.Add(oItem);
            tddown_otm.Items.Add(oItem);
            tddown4_otm.Items.Add(oItem);
            tddown_ota.Items.Add(oItem);

        }


        Tabs.Tabs[1].Visible = true;

       
        #endregion
        #region carga_Tab2  Delito

        TextBox tddown001 = (TextBox)Tabs.FindControl("ddown001");
        DropDownList tddown03_Proy = (DropDownList)Tabs.FindControl("ddown03_Proy");


        dt = cr.callto_get_coordinacioningreso(Convert.ToInt32(lbl005.Text));
        tddown001.Text = Convert.ToDateTime(dt.Rows[0][3]).ToString();
        CodProy = dt.Rows[0][2].ToString();
        VProy = Convert.ToInt32(dt.Rows[0][2]);

        proyectocoll pro = new proyectocoll();
        dt = pro.GetProyectos(CodProy);

        sql = "Select IcodOrdenTribunal  from CoordinacionIngreso where ICodIngreso =@pICodIngreso";

        listDbParameter.Clear();
        listDbParameter.Add(Conexiones.CrearParametro("@pICodIngreso", SqlDbType.Int, 4, Convert.ToInt32(lbl005.Text)));

        dt_OT = cr.ejecuta_SQL(sql, listDbParameter);

        VICodOrdenTribunal = Convert.ToInt32(dt_OT.Rows[0][0]);

        #endregion
        #region carga_Tab3 Resolucion del Tribunal

         //WebDateChooser tddown017 = (TextBox)Tabs.FindControl("ddown017");
         //tddown017.MaxDate = DateTime.Now;

         string SQL0 = "select T1.IcodIngreso,T1.IcodOrdenTribunal, T2.Descripcion, T1.CodProyecto,('('+ cast(T1.CodProyecto as varchar) +')-'+T3.nombre) AS Proyecto, T3.nombre AS Proyecto,T1.CodResolucionTribunal, " +
             "T1.FechaDerivacion,('(' + cast( T4.Codtribunal as varchar )+')-'+ T5.Descripcion) AS OrdenTribunal, T6.descripcion as Resoluciontribunal  " +  
             "FROM CoordinacionIngreso T1 " +
             "INNER JOIN parResolucionTribunal T2 ON T1.CodResolucionTribunal = T2.CodResolucionTribunal " +
             "INNER JOIN Proyectos T3 ON T1.CodProyecto = T3.CodProyecto " +
             "INNER JOIN  CoordinacionOrdenTribunal T4 ON T1.IcodOrdenTribunal = T4.IcodOrdenTribunal " +
             "INNER JOIN parTribunales T5 ON T4.CodTribunal = T5.CodTribunal " +
             "INNER JOIN parResoluciontribunal T6 ON  T1.CodResolucionTribunal = T6.CodResolucionTribunal " +
             "WHERE T1.IcodOrdentribunal =@pIcodOrdentribunal ";

         listDbParameter.Clear();
         listDbParameter.Add(Conexiones.CrearParametro("@pIcodOrdentribunal", SqlDbType.Int, 4, VICodOrdenTribunal));

            DataTable dt_sp1 = new DataTable();
            dt_sp1 = cr.ejecuta_SQL(SQL0, listDbParameter);
            GridView tgrd001_Resolucion = (GridView)Tabs.FindControl("grd001_Resolucion");
            tgrd001_Resolucion.DataSource = dt_sp1;
            tgrd001_Resolucion.DataBind();
            tgrd001_Resolucion.Visible = true;

         dt = cr.callto_get_coordinacioncausalingreso(VICodOrdenTribunal);//Convert.ToInt32(lbl005.Text));

         sql = "Select a.Descripcion as causal,b.CodTipoCausalIngreso,b.descripcion as tipocausal " +
             "from parcausalesingreso a inner join parTipoCausalIngreso b on a.CodTipoCausalIngreso = b.CodTipoCausalIngreso " +
             "where a.codcausalingreso =@pcodcausalingreso ";

         listDbParameter.Clear();
         listDbParameter.Add(Conexiones.CrearParametro("@pcodcausalingreso", SqlDbType.Int, 4, -1));
 
         for (int i = 0; i < dt.Rows.Count; i++)
         {
             listDbParameter[0].Value = Convert.ToInt32(dt.Rows[i][1].ToString());
             dt_sp = cr.ejecuta_SQL(sql, listDbParameter);


             dr = DTcausales.NewRow();
             dr[0] = Convert.ToInt32(dt_sp.Rows[0][1]);
             dr[1] = Convert.ToInt32(dt.Rows[i][2]);
             dr[2] = dt_sp.Rows[0][2].ToString();
             dr[3] = dt_sp.Rows[0][0].ToString();
             dr[4] = Convert.ToInt32(dt.Rows[i][3]);
             dr[5] = Convert.ToInt32(dt.Rows[i][4]);
             dr[6] = Convert.ToInt32(dt.Rows[i][0]);
             DTcausales.Rows.Add(dr);

                     
         }
         GridView grd002 = (GridView)Tabs.FindControl("grd002");
         grd002.DataSource = DTcausales;
         grd002.DataBind();
         grd002.Visible = true;

         Tabs.Tabs[2].Visible = true;


        #endregion
        #region carga_Tab4 - 4.1  Plazo Med e Invst. / Sancion
         dt = cr.callto_get_coordinacionsancion(VICodOrdenTribunal);//Convert.ToInt32(lbl005.Text));

         string SQLPMI = "Select T1.CodSAncion, T1.ICodOrdenTribunal, T1.FechaInicio, T1.FechaTermino, T1.DuracionDia, "+
                         "T1.IdUsuarioActualizacion, T1.FechaActualizacion, T1.PlazoInvestigacion, T1.FechaPlazoInvestigacion, "+
                         "T2.Codsancion,T2.dias, T2.FechaActualizacion, T2.IdusuarioActualizacion "+
                         "From CoordinacionSancion T1 "+ 
                         "Inner Join CoordinacionAmpliaInvestigacion T2 ON T1.CodSancion = T2.CodSancion "+
                         "Inner Join CoordinacionOrdenTribunal T3 ON T3.ICodOrdenTribunal = T1.ICodOrdenTribunal "+
                         "Inner Join CoordinacionIngreso T4 ON T3.ICodOrdenTribunal = T4.ICodOrdenTribunal "+
                         "WHERE T4.codnino =@pcodnino ";

         listDbParameter.Clear();
         listDbParameter.Add(Conexiones.CrearParametro("@pcodnino", SqlDbType.Int, 4, SSnino.CodNino));

         DataTable DTPMI = new DataTable();
         DTPMI = cr.ejecuta_SQL(SQLPMI, listDbParameter);

         if (DTPMI.Rows.Count > 0)
            {
                tgrd004_lrpaMedInv.DataSource = DTPMI;
                tgrd004_lrpaMedInv.DataBind();
                tgrd004_lrpaMedInv.Visible = true;
            }
        
        
        for (int i = 0; i < dt.Rows.Count; i++)
         {
             if (dt.Rows[i][4].ToString().Trim() != "") //SAncion
             {
                 dr = DTmedidas.NewRow();
                 dr[0] = Convert.ToDateTime(dt.Rows[i][2]);
                 dr[1] = Convert.ToDateTime(dt.Rows[i][3]);
                 dr[2] = Convert.ToInt32(dt.Rows[i][4]);
                 dr[3] = Convert.ToInt32(dt.Rows[i][5]);
                 dr[4] = Convert.ToInt32(dt.Rows[i][6]);
                 dr[5] = Convert.ToInt32(dt.Rows[i][7]);
                 dr[6] = Convert.ToInt32(dt.Rows[i][10]);
                 dr[7] = Convert.ToInt32(dt.Rows[i][1]);
                 dr[8] = Convert.ToInt32(dt.Rows[i][0]);
                 DTmedidas.Rows.Add(dr);
             }
             else 
             {
                 dr = DTPlazoMedInv.NewRow();
                 dr[0] = Convert.ToInt32(dt.Rows[i][0]);
                 dr[1] = Convert.ToInt32(dt.Rows[i][1]);
                 dr[2] = Convert.ToDateTime(dt.Rows[i][2]);
                 dr[3] = Convert.ToDateTime(dt.Rows[i][3]);
                 dr[4] = Convert.ToInt32(dt.Rows[i][6]);
                 dr[5] = Convert.ToInt32(dt.Rows[i][8]);
                 dr[6] = Convert.ToDateTime(dt.Rows[i][9]);
                 //dr[7] = Convert.ToInt32(dt.Rows[i][1]);
                 //dr[8] = Convert.ToInt32(dt.Rows[i][0]);
                 DTPlazoMedInv.Rows.Add(dr);
             
             }
         
         }
         GridView tgrd001LRPA = (GridView)Tabs.FindControl("grd001LRPA");
         if (DTmedidas.Rows.Count > 0)
         {
             tgrd001LRPA.DataSource = DTmedidas;
           //  tgrd001LRPA.DataBind();
             tgrd001LRPA.Visible = true;
         }
         else
         {
             tgrd001LRPA.Visible = false;

         }
         Tabs.Tabs[3].Visible = true;


         
         LRPAcoll LRPA = new LRPAcoll();
         DataTable dtLRPA = new DataTable();
        // dtLRPA = LRPA.callto_get_sancionesbycodigo(VICodMedidaSancion);



         GridView grdseleccionLRPA = (GridView)Tabs.FindControl("grdseleccionLRPA");

         sql = "Select CodSancion AS ICodOrdenTribunal, FechaInicio, FechaTermino from CoordinacionSancion Where IcodOrdenTribunal =@pIcodOrdenTribunal";

         listDbParameter.Clear();
         listDbParameter.Add(Conexiones.CrearParametro("@pIcodOrdenTribunal", SqlDbType.Int, 4, VICodOrdenTribunal));

         dtLRPA = cr.ejecuta_SQL(sql, listDbParameter);

         if (dtLRPA.Rows.Count > 0)
         {
             grdseleccionLRPA.DataSource = dtLRPA;
             grdseleccionLRPA.DataBind();
             grdseleccionLRPA.Visible = true;

         }
         
  

        #endregion
        #region carga_Tab5 Audiencia
         dt = cr.callto_get_coordinacionaudiencia(VICodOrdenTribunal);//Convert.ToInt32(lbl005.Text));

         string cns = "Select descripcion from parTipoAudiencia Where CodTipoAudiencia =@pCodTipoAudiencia";

         listDbParameter.Clear();
         listDbParameter.Add(Conexiones.CrearParametro("@pCodTipoAudiencia", SqlDbType.Int, 4, -1));
         for (int i = 0; i < dt.Rows.Count; i++)
         {
             listDbParameter[0].Value = Convert.ToInt32(dt.Rows[i][2].ToString());
             dt_sp = cr.ejecuta_SQL(cns, listDbParameter);

             dr = DTaudiencia.NewRow();
             dr[0] = Convert.ToInt32(dt.Rows[i][1]);
             dr[1] = Convert.ToDateTime(dt.Rows[i][6]);
             dr[2] = Convert.ToInt32(dt.Rows[i][2]);
             dr[3] = dt_sp.Rows[0][0].ToString();
             dr[4] = dt.Rows[i][3].ToString();
             dr[5] = Convert.ToInt32(dt.Rows[i][0]);
             DTaudiencia.Rows.Add(dr);
         }
         GridView tgrd001Audiencia = (GridView)Tabs.FindControl("grd001Audiencia");
         if (DTaudiencia.Rows.Count > 0)
         {
             tgrd001Audiencia.DataSource = DTaudiencia;
             tgrd001Audiencia.DataBind();
             tgrd001Audiencia.Visible = true;
         }
         else
         {
             tgrd001Audiencia.Visible = false;
         }
         Tabs.Tabs[4].Visible = true;
         Tabs.Tabs[5].Visible = true;
        #endregion
        #region carga_Tab6 Cierre Causa
         GridView grd001CierreCausa = (GridView)Tabs.FindControl("grd001CierreCausa");
         dt = cr.callto_historico_cierrecausa(Convert.ToInt32(lbl004.Text),RUC_Rep.Trim());
         if (dt.Rows.Count > 0)
         {
             grd001CierreCausa.DataSource = dt;
             grd001CierreCausa.DataBind();
             grd001CierreCausa.Visible = true;
             Tabs.Tabs[6].Visible = true;

         }
         else
         {
             grd001CierreCausa.Visible = false;
             Tabs.Tabs[6].Visible = false;
         }


         sql = "Select CodProyecto  from CoordinacionIngreso where ICodIngreso =@pICodIngreso";

         listDbParameter.Clear();
         listDbParameter.Add(Conexiones.CrearParametro("@pICodIngreso", SqlDbType.Int, 4, Convert.ToInt32(lbl005.Text)));

         //coordinador cr = new coordinador();
         DataTable dt1 = cr.ejecuta_SQL(sql, listDbParameter);

         ReporteNinoColl rpn = new ReporteNinoColl();
         DataTable dt0 = rpn.Reporte_GetProyectosLPRA(Convert.ToInt32(dt1.Rows[0][0]));
         //if (dt0.Rows[0][0].ToString() == "2" && dt0.Rows[0][1].ToString() == "20084")//
         //{
         //    //vtab3 = false;
         //    //Tabs.Tabs[2].Style.ForeColor = System.Drawing.Color.Black;
         //    Tabs.Tabs[4].Visible = true;
         //    Tabs.Tabs[5].Visible = false;
         //    // Tabs.Tabs[7].Visible = true;
         //}
         //else
         //{
         //    //vtab3 = false;
         //    //Tabs.Tabs[2].Style.ForeColor = System.Drawing.Color.Black;
         //    Tabs.Tabs[4].Visible = false;
         //    Tabs.Tabs[5].Visible = true; 
            
             
         //}

      
        #endregion



     }
    //protected void btnactualizaingreso_Click(object sender, EventArgs e)
    //{
    //    if (validatedata(0, true))
    //    {
    //        lblbmsg.Text = "Faltan datos para completar el Ingreso";
    //        lblbmsg.Visible = true;
    //    }
    //    else
    //    {
    //        coordinador cr = new coordinador();
    //        DataTable dt_OT = new DataTable();
    //        dt_OT = cr.ejecuta_SQL("Select IcodOrdenTribunal  from CoordinacionIngreso where ICodIngreso =" + lbl005.Text);//ESTE ES EL CODIGO DERL NIÑO NO EL INGRESO

    //        VICodOrdenTribunal = Convert.ToInt32(dt_OT.Rows[0][0]);


    //        WebDateChooser tddown001 = (TextBox)Tabs.FindControl("ddown001");
           
    //        DataTable dt = new DataTable();
    //        int icodie = Convert.ToInt32(lbl005.Text);



    //        string SQL02 = "select T1.CodResolucionTribunal, T1.FechaDerivacion " +
    //        "FROM CoordinacionIngreso T1 " +
    //        "INNER JOIN parResolucionTribunal T2 ON T1.CodResolucionTribunal = T2.CodResolucionTribunal " +
    //        "INNER JOIN Proyectos T3 ON T1.CodProyecto = T3.CodProyecto " +
    //        "INNER JOIN  CoordinacionOrdenTribunal T4 ON T1.IcodOrdenTribunal = T4.IcodOrdenTribunal " +
    //        "INNER JOIN parTribunales T5 ON T4.CodTribunal = T5.CodTribunal " +
    //        "INNER JOIN parResoluciontribunal T6 ON  T1.CodResolucionTribunal = T6.CodResolucionTribunal " +
    //        "WHERE T1.IcodOrdentribunal = " + VICodOrdenTribunal;

    //        DataTable dt_sp1 = new DataTable();
    //        dt_sp1 = cr.ejecuta_SQL(SQL02);

    //        #region Update_Tab1
    //        cr.callto_update_coordinacioningreso(/*icodie,*/Convert.ToInt32(lbl005.Text)
    //            , VICodOrdenTribunal
    //            , Convert.ToInt32(lbl004.Text)
    //            , Convert.ToInt32(CodProy)
    //            , Convert.ToInt32(dt_sp1.Rows[0][0])
    //            , Convert.ToDateTime(dt_sp1.Rows[0][1])
    //            , Convert.ToInt32(Session["IdUsuario"])
    //            , DateTime.Now
    //            );

         


    //        #endregion




    //        #region Delete_Tables
    //        string SQL03 = "select CodSancion " +
    //        "FROM CoordinacionSancion " +
    //        "WHERE IcodOrdentribunal = " + VICodOrdenTribunal;

    //        dt_sp1 = cr.ejecuta_SQL(SQL03);

    //        string sqlDelete = "";

    //      //  string sqlDelete = "DELETE FROM CoordinacionSancionAccesoria WHERE CodSancion =" + Convert.ToInt32(dt_sp1.Rows[0][0]);//+ lbl005.Text;//"DELETE FROM CoordinacionAudiencia WHERE ICodIE =" + lbl005.Text;
    //       // cr.ejecuta_SQL(sqlDelete);

    //       DataTable DTSanc = new DataTable();
    //       string SQLSancion = "SELECT CodSancion FROM CoordinacionSancion WHERE ICodOrdenTribunal =" + VICodOrdenTribunal;
    //       DTSanc = cr.ejecuta_SQL(SQLSancion);
    //        if(Convert.ToInt32(DTSanc.Rows.Count)>0)
    //        {
    //       sqlDelete = "DELETE FROM CoordinacionAmpliaInvestigacion WHERE CodSancion =" + Convert.ToInt32(DTSanc.Rows[0][0]);
    //       cr.ejecuta_SQL(sqlDelete);
    //        }
    //       sqlDelete = "DELETE FROM CoordinacionSancion WHERE ICodOrdenTribunal =" + VICodOrdenTribunal;//+ lbl005.Text;//"DELETE FROM CoordinacionSancion WHERE ICodIE =" + lbl005.Text;
    //       cr.ejecuta_SQL(sqlDelete);
          
    //        sqlDelete = "DELETE FROM CoordinacionAudiencia WHERE ICodOrdenTribunal =" + VICodOrdenTribunal;//+ lbl005.Text;//"DELETE FROM CoordinacionAudiencia WHERE ICodIE =" + lbl005.Text;
    //        cr.ejecuta_SQL(sqlDelete);
    //        sqlDelete = "DELETE FROM CoordinacionCausalIngreso WHERE ICodOrdenTribunal=" + VICodOrdenTribunal;//lbl005.Text;//"DELETE FROM CoordinacionCausalIngreso WHERE ICodIE=" + lbl005.Text;
    //        cr.ejecuta_SQL(sqlDelete);
    //        sqlDelete = "DELETE FROM CoordinacionIngreso WHERE ICodOrdenTribunal =" + VICodOrdenTribunal;//lbl005.Text;//"DELETE FROM CoordinacionOrdenTribunal WHERE ICodIE =" + lbl005.Text;
    //        cr.ejecuta_SQL(sqlDelete);
    //       // sqlDelete = "DELETE FROM CoordinacionOrdenTribunal WHERE ICodOrdenTribunal =" + VICodOrdenTribunal;//lbl005.Text;//"DELETE FROM CoordinacionOrdenTribunal WHERE ICodIE =" + lbl005.Text;
    //       // cr.ejecuta_SQL(sqlDelete);
                       
           




         
    //        #endregion

    //        #region Insert_Tables
    //        int sentenciaejec = 0;

    //        //Areglo de edicion Sabado04 comienzo bloque Update

    //        //for (int i = 0; i < DTordentribunales.Rows.Count; i++)
    //        //{

    //        //    if (DTordentribunales.Rows[i][3].ToString() == "Si")
    //        //        sentenciaejec = 1;

    //        //    dt = cr.callto_insert_coordinacionordentribunal(Convert.ToInt32(DTordentribunales.Rows[i][0])
    //        //        , DTordentribunales.Rows[i][4].ToString()
    //        //        , DTordentribunales.Rows[i][5].ToString()
    //        //        , Convert.ToDateTime(DTordentribunales.Rows[i][2])
    //        //        , sentenciaejec
    //        //        , Convert.ToInt32(Session["IdUsuario"])
    //        //        , DateTime.Now
    //        //        );

    //        //    //DTICodOrdenTrubunal.Rows[i][1] = Convert.ToInt32(dt.Rows[i][1].ToString());
    //        //    DTordentribunales.Rows[i][7] = dt.Rows[0][0].ToString();
    //        //    VICodOrdenTribunal = Convert.ToInt32(dt.Rows[0][0].ToString());

    //        //    dt.Clear();
    //        //}

    //        int codorden = 0;
    //        //for (int i = 0; i < DTcausales.Rows.Count; i++)
    //        //{
    //        //    for (int j = 0; j < DTordentribunales.Rows.Count; j++)
    //        //    {
    //        //        if (DTordentribunales.Rows[j][6].ToString() == DTcausales.Rows[i][5].ToString())
    //        //        {
    //        //            codorden = Convert.ToInt32(DTordentribunales.Rows[j][7]);
    //        //        }
    //        //    }
    //        //    dt = cr.callto_insert_coordinacioncausalingreso(Convert.ToInt32(DTcausales.Rows[i][0])
    //        //        , Convert.ToInt32(DTcausales.Rows[i][4])
    //        //        ,VICodOrdenTribunal// codorden
    //        //        , Convert.ToInt32(Session["IdUsuario"])
    //        //        , DateTime.Now
    //        //        );

    //        //}
    //        //dt.Clear();
    //        //codorden = 0;

    //        //GridView tgrd001LRPA = (GridView)Tabs.FindControl("grd001LRPA");

    //        ////  for (int i = 0; i < DTMedidasSancion.Rows.Count; i++)
    //        //for (int i = 0; i < DTSancionV2.Rows.Count; i++)
    //        //{
    //        //    for (int j = 0; j < DTordentribunales.Rows.Count; j++)
    //        //    {
    //        //        //if (DTordentribunales.Rows[j][6].ToString() == DTmedidas.Rows[i][7].ToString())
    //        //        //{
    //        //        codorden = Convert.ToInt32(DTordentribunales.Rows[j][7]);
    //        //        //} 

    //        //    }


    //        //    dt = cr.callto_insert_coordinacionsancion(VICodOrdenTribunal//codorden
    //        //        , Convert.ToDateTime(DTSancionV2.Rows[i][1])
    //        //        , Convert.ToDateTime(DTSancionV2.Rows[i][2])
    //        //        , Convert.ToInt32(DTSancionV2.Rows[i][3])
    //        //        , Convert.ToInt32(DTSancionV2.Rows[i][4])
    //        //        , Convert.ToInt32(DTSancionV2.Rows[i][5])
    //        //        , Convert.ToInt32(DTSancionV2.Rows[i][6])
    //        //        , Convert.ToInt32(DTSancionV2.Rows[i][7])
    //        //        , Convert.ToInt32(DTSancionV2.Rows[i][8])
    //        //        , Convert.ToInt32(DTSancionV2.Rows[i][9])
    //        //        , Convert.ToDateTime(DTSancionV2.Rows[i][10])
    //        //        , Convert.ToDateTime(DTSancionV2.Rows[i][11])
    //        //        , Convert.ToInt32(DTSancionV2.Rows[i][12])
    //        //        , Convert.ToInt32(DTSancionV2.Rows[i][13])
    //        //        , Convert.ToInt32(DTSancionV2.Rows[i][14])
    //        //        , -1                                         //Convert.ToInt32(DTSancionV2.Rows[i][15])
    //        //        , Convert.ToDateTime("01-01-1900")          // Convert.ToDateTime(DTSancionV2.Rows[i][16])
    //        //        , Convert.ToInt32(DTSancionV2.Rows[i][17])
    //        //        , Convert.ToInt32(Session["IdUsuario"])
    //        //        , DateTime.Now
    //        //        );

    //        //    if (tgrd001LRPA.Rows.Count > 0)
    //        //    {

    //        //        for (int k = 0; k < tgrd001LRPA.Rows.Count; k++)
    //        //        {
    //        //            cr.callto_insert_coordinacionsancionaccesoria(Convert.ToInt32(DTTipoSancionAccesoria.Rows[k][1]), Convert.ToInt32(dt.Rows[i][0]));//Convert.ToInt32(DTTipoSancionAccesoria.Rows[i][3]));
    //        //        }
    //        //    }

    //        //}

    //        //dt.Clear();
    //        ////codorden = 0;


    //        ////for (int i = 0; i < DTmedidas.Rows.Count; i++)  INSERT ANTERIOR
    //        ////{
    //        ////    for (int j = 0; j < DTordentribunales.Rows.Count; j++)
    //        ////    {
    //        ////        if (DTordentribunales.Rows[j][6].ToString() == DTmedidas.Rows[i][7].ToString())
    //        ////        {
    //        ////            codorden = Convert.ToInt32(DTordentribunales.Rows[j][7]);
    //        ////        }
    //        ////    }

    //        ////    dt = cr.callto_insert_coordinacionsancion(codorden, Convert.ToDateTime(DTmedidas.Rows[i][0]) 
    //        ////        , Convert.ToDateTime(DTmedidas.Rows[i][1])
    //        ////        , Convert.ToInt32(DTmedidas.Rows[i][2])
    //        ////        , Convert.ToInt32(DTmedidas.Rows[i][3])
    //        ////        , Convert.ToInt32(DTmedidas.Rows[i][4])
    //        ////        ,/*CodTribunal*/1
    //        ////        ,/*SancionAccesoria*/2
    //        ////        , Convert.ToInt32(DTmedidas.Rows[i][5])
    //        ////        , Convert.ToInt32(DTmedidas.Rows[i][6])
    //        ////        ,/*fechainiciomixta*/Convert.ToDateTime("10-10-1900")
    //        ////        ,/*fechaTerminomixta*/Convert.ToDateTime("10-10-1900")
    //        ////        ,/*DuracionAnoMixta*/1
    //        ////        ,/*DuracionMesMixta*/1
    //        ////        ,/*DuracionDiaMixta*/1
    //        ////        ,/*CodTerminoSancion*/1
    //        ////        ,/*fechaTerminoSancion*/Convert.ToDateTime("10-10-1900")
    //        ////        ,/*CodModeloSancionMixta*/1
    //        ////        , Convert.ToInt32(Session["IdUsuario"])
    //        ////        , DateTime.Now);
    //        ////}
    //        ////dt.Clear();

    //        #region ActualizacionDelito (CoordinacionCausalIngreso)

    //            for(int i = 0; i<DTcausales.Rows.Count; i++)
    //                {

    //                    //DTcausales.Columns.Add(new DataColumn("CodTipoCausalIngreso", typeof(int)));
    //                    //DTcausales.Columns.Add(new DataColumn("CodCausalIngreso", typeof(int)));
    //                    //DTcausales.Columns.Add(new DataColumn("DescripcionTipo", typeof(string)));
    //                    //DTcausales.Columns.Add(new DataColumn("Descripcion", typeof(string)));
    //                    //DTcausales.Columns.Add(new DataColumn("coddelito", typeof(int)));
    //                    //DTcausales.Columns.Add(new DataColumn("codigo", typeof(string)));
    //                    //DTcausales.Columns.Add(new DataColumn("ICodCausalIngreso", typeof(int)));

    //                    for (int j = 0; j < DTordentribunales.Rows.Count; j++)
    //                    {
    //                            cr.callto_insert_coordinacioncausalingreso(Convert.ToInt32(DTcausales.Rows[i][0]), Convert.ToInt32(DTcausales.Rows[i][4])
    //                          , VICodOrdenTribunal, Convert.ToInt32(Session["IdUsuario"]), DateTime.Now);
                            
    //                    }

                      

    //                }

    //        #endregion


    //        #region ActualizacionResoluciondelTribunal


    //            for (int i = 0; i < DTResoluciones.Rows.Count; i++)
    //               {
    //                    cr.callto_insert_coordinacioningreso(VICodOrdenTribunal, Convert.ToInt32(DTResoluciones.Rows[i][6]), Convert.ToInt32(lbl004.Text),Convert.ToInt32(DTResoluciones.Rows[i][7])
    //                    , Convert.ToDateTime(DTResoluciones.Rows[i][3]), Convert.ToInt32(Session["IdUsuario"]), DateTime.Now);

            
    //               }

    //        #endregion 
            

    //        #region ActualizacionPlazoMedida
    //                for (int i = 0; i<DTMedidasSancion.Rows.Count; i++)
    //                {
    //                    DataTable DTPMI = new DataTable();
    //                    DTPMI = cr.callto_insert_MedidasInvestigacion(VICodOrdenTribunal, Convert.ToDateTime(DTMedidasSancion.Rows[i][1]), Convert.ToDateTime(DTMedidasSancion.Rows[i][2]),
    //                    Convert.ToInt32(DTMedidasSancion.Rows[i][3]), Convert.ToInt32(DTMedidasSancion.Rows[i][4]), Convert.ToDateTime(DTMedidasSancion.Rows[i][5]), Convert.ToInt32(Session["IdUsuario"]),
    //                    DateTime.Now);                  
    //                    int iden = Convert.ToInt32(DTPMI.Rows[0][0]); 
                
                
    //                     if (DTAmpliacionesMedidas.Rows.Count > 0)
    //                        {
    //                            cr.callto_insert_CoordinacionAmpliaInvestigacion(iden, Convert.ToInt32(DTAmpliacionesMedidas.Rows[i][2]), Convert.ToDateTime(DTAmpliacionesMedidas.Rows[i][0]),
    //                            Convert.ToInt32(Session["IdUsuario"]));
    //                        }
    //                 }

    //        #endregion
                      

    //        #region ActualizacionSancion

    //              for(int i = 0; i< DTSancionV2.Rows.Count; i++)
    //                {
    //                    dt =cr.callto_insert_coordinacionsancion(VICodOrdenTribunal,Convert.ToDateTime(DTSancionV2.Rows[i][1]),Convert.ToDateTime(DTSancionV2.Rows[i][2]),
    //                    Convert.ToInt32(DTSancionV2.Rows[i][3]),Convert.ToInt32(DTSancionV2.Rows[i][4]),Convert.ToInt32(DTSancionV2.Rows[i][5]),Convert.ToInt32(DTSancionV2.Rows[i][6]),
    //                    Convert.ToInt32(DTSancionV2.Rows[i][7]),Convert.ToInt32(DTSancionV2.Rows[i][8]),Convert.ToInt32(DTSancionV2.Rows[i][9]),Convert.ToDateTime(DTSancionV2.Rows[i][10]),
    //                    Convert.ToDateTime(DTSancionV2.Rows[i][11]),Convert.ToInt32(DTSancionV2.Rows[i][12]),Convert.ToInt32(DTSancionV2.Rows[i][13]),Convert.ToInt32(DTSancionV2.Rows[i][14]),
    //                    Convert.ToInt32(DTSancionV2.Rows[i][15]),Convert.ToDateTime(DTSancionV2.Rows[i][16]),Convert.ToInt32(DTSancionV2.Rows[i][17]),Convert.ToInt32(DTSancionV2.Rows[i][18]),
    //                    Convert.ToDateTime(DTSancionV2.Rows[i][19]));

    //                if (DTTipoSancionAccesoria.Rows.Count > 0)
    //                    {
    //                    for(int j = 1; j<DTTipoSancionAccesoria.Rows.Count; j++)
    //                        {
    //                            DataTable DtTSA = new DataTable();
    //                            DtTSA = cr.callto_insert_coordinacionsancionaccesoria(Convert.ToInt32(DTTipoSancionAccesoria.Rows[j][1]),Convert.ToInt32(DTTipoSancionAccesoria.Rows[j][2]));
    //                        }
    //                    }                
    //                }

    //        #endregion ActualizacionSancion
            
            
    //        #region Actualizacion Audiencia
    //        codorden = 0;
            
    //        for (int i = 0; i < DTaudiencia.Rows.Count; i++)
    //        {
    //            for (int j = 0; j < DTordentribunales.Rows.Count; j++)
    //            {
    //                if (DTordentribunales.Rows[j][6].ToString() == DTaudiencia.Rows[i][0].ToString())
    //                {
    //                    codorden = Convert.ToInt32(DTordentribunales.Rows[j][7]);
    //                }
    //            }
    //                dt = cr.callto_insert_coordinacionaudiencia(VICodOrdenTribunal//codorden
    //                ,Convert.ToInt32(DTaudiencia.Rows[i][2])
    //                , /*validar campo Observacion*/DTaudiencia.Rows[i][4].ToString()
    //                ,Convert.ToDateTime(DTaudiencia.Rows[i][1])
    //                , Convert.ToInt32(Session["IdUsuario"])
    //                , DateTime.Now
    //                );

    //        }
    //        #endregion
            

    //        #endregion


    //        pnl001.Visible = false;
    //        Tabs.Visible = false;
    //        limpia_controles();

    //    }
    //}

    //protected void btn_Acepta_Click(object sender, EventArgs e)
    //{
    //    coordinador cr = new coordinador();

    //    //string sqlDelete = "DELETE FROM CoordinacionOrdenTribunal WHERE ICodOrdenTribunal =" + VICodOrdenTribunal; //lbl005.Text;
    //    //cr.ejecuta_SQL(sqlDelete);
    //    //sqlDelete = "DELETE FROM CoordinacionCausalIngreso WHERE ICodOrdenTribunal=" + VICodOrdenTribunal;//lbl005.Text;
    //    //cr.ejecuta_SQL(sqlDelete);
    //    //sqlDelete = "DELETE FROM CoordinacionSancion WHERE ICodOrdenTribunal =" + VICodOrdenTribunal;//lbl005.Text;
    //    //cr.ejecuta_SQL(sqlDelete);
    //    //sqlDelete = "DELETE FROM CoordinacionAudiencia WHERE ICodOrdenTribunal =" + VICodOrdenTribunal;//lbl005.Text;
    //    //cr.ejecuta_SQL(sqlDelete);
    //    //sqlDelete = "DELETE FROM CoordinacionIngreso WHERE ICodIE =" + VICodOrdenTribunal; //lbl005.Text;
    //    //cr.ejecuta_SQL(sqlDelete);

        
    //    pnl_coordinador.Visible = true;
    //    pnlAvisoElimina.Visible = false;

    //    Busca_ingresos();
    //    lblSwich.Text = "M";
    //    grd003.Visible = false;
    //    lblbmsg.Visible = false;

    //}
    //protected void btnCancelar_Click(object sender, EventArgs e)
    //{
    //    pnlAvisoElimina.Visible = false;
    //    pnl_coordinador.Visible = true;
    //}
    //protected void btn_volver_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("index_coordinadores.aspx");
    //}

    //protected void btnvolverAudiencia_Click(object sender, EventArgs e)
    //{
    //    DataTable dt = new DataTable();
         
    //    txt002.Enabled = true;
    //    txt004.Enabled = true;
    //    txt005.Enabled = true;
    //    txt006.Enabled = true;
    //    txt007.Enabled = true;


    //    btn_buscar.Visible = true;
    //    btn_modificar.Visible = true;

    //    if(lblSwich.Text == "M")
    //        grd004.Visible = true;
    //    else
    //        grd003.Visible = true;

    //    pnl001.Visible = false;
    //    Tabs.Visible = false;

    //    Tabs.TabIndex = 0;

    //    #region Limpia_tab1
    //    TextBox ttxt001 = (TextBox)Tabs.FindControl("txt001");
    //    WebDateChooser tddown001 = (TextBox)Tabs.FindControl("ddown001");
    //    ttxt001.Text = "";
    //    tddown001.Value = null;
    //    ttxt001.BackColor = System.Drawing.Color.White;
    //    tddown001.BackColor = System.Drawing.Color.White;
    //    #endregion

    //    #region Limpia_tab2
    //    DropDownList tddown016 = (DropDownList)Tabs.FindControl("ddown016");
    //    DropDownList tddown014 = (DropDownList)Tabs.FindControl("ddown014");
    //    DropDownList tddown015 = (DropDownList)Tabs.FindControl("ddown015");
    //    DropDownList tddown_ota = (DropDownList)Tabs.FindControl("ddown_ota");
    //    DropDownList tddown_otc = (DropDownList)Tabs.FindControl("ddown_otc");
    //    DropDownList tddown_otm = (DropDownList)Tabs.FindControl("ddown_otm");
    //    GridView tgrd001 = (GridView)Tabs.FindControl("grd001");
    //    WebDateChooser tddown017 = (TextBox)Tabs.FindControl("ddown017");
    //    WebMaskEdit ttxt006F2 = (TextBox)Tabs.FindControl("txt006F2");
    //    WebMaskEdit ttxt007F2 = (TextBox)Tabs.FindControl("txt007F2");
    //    RadioButtonList trdo001 = (RadioButtonList)Tabs.FindControl("rdo001");

    //    tddown014.SelectedIndex = -1;
    //    tddown015.SelectedIndex = -1;
    //    tddown016.SelectedIndex = -1;
    //    tddown_ota.Items.Clear();
    //    tddown_otc.Items.Clear();
    //    tddown_otm.Items.Clear();
    //    ListItem item = new ListItem("Seleccionar", "0");
    //    tddown_ota.Items.Add(item);
    //    tddown_otc.Items.Add(item);
    //    tddown_otm.Items.Add(item);
    //    tgrd001.DataSource = dt;
    //    tgrd001.DataBind();
    //    tgrd001.Visible = false;
    //    tddown017.Value = null;
    //    ttxt006F2.Text = "";
    //    ttxt007F2.Text = "";
    //    trdo001.SelectedValue = "0";

    //    tddown014.BackColor = System.Drawing.Color.White;
    //    tddown015.BackColor = System.Drawing.Color.White;
    //    tddown016.BackColor = System.Drawing.Color.White;
    //    tddown_ota.BackColor = System.Drawing.Color.White;
    //    tddown_otc.BackColor = System.Drawing.Color.White;
    //    tddown_otm.BackColor = System.Drawing.Color.White;
    //    ttxt006F2.BackColor = System.Drawing.Color.White;
    //    ttxt007F2.BackColor = System.Drawing.Color.White;

    //    #endregion

    //    #region Limpia_tab3
    //    GridView grd002 = (GridView)Tabs.FindControl("grd002");
    //    DropDownList tddown018 = (DropDownList)Tabs.FindControl("ddown018");
    //    DropDownList tddown019 = (DropDownList)Tabs.FindControl("ddown019");
    //    WebMaskEdit ttxt006 = (TextBox)Tabs.FindControl("txt006");
    //    Label tlbl_causales = (Label)Tabs.FindControl("lbl_causales");

    //    grd002.DataSource = dt;
    //    grd002.DataBind();
    //    grd002.Visible = false;

    //    tddown018.SelectedIndex = -1;
    //    tddown019.SelectedIndex = -1;
    //    ttxt006.Text = "";
    //    tlbl_causales.Visible = false;

    //    tddown018.BackColor = System.Drawing.Color.White;
    //    tddown019.BackColor = System.Drawing.Color.White;
    //    ttxt006.BackColor = System.Drawing.Color.White;

    //    #endregion

    //    #region Limpia_tab4
    //    WebNumericEdit ttxt001LRPA = (WebNumericEdit)Tabs.FindControl("txt001LRPA");
    //    WebNumericEdit ttxt002LRPA = (WebNumericEdit)Tabs.FindControl("txt002LRPA");
    //    WebNumericEdit ttxt007LRPA = (WebNumericEdit)Tabs.FindControl("txt007LRPA");
    //    WebNumericEdit ttxt009LRPA = (WebNumericEdit)Tabs.FindControl("txt009LRPA");
    //    TextBox ttxt003LRPA = (TextBox)Tabs.FindControl("txt003LRPA");
    //    Label tlbl_avisoDuracionLRPA = (Label)Tabs.FindControl("lbl_avisoDuracionLRPA");
    //    WebDateChooser tddown001LRPA = (TextBox)Tabs.FindControl("ddown001LRPA");
    //    Label tllblfechaini1LRPA = (Label)Tabs.FindControl("lblfechaini1LRPA");
    //    GridView tgrd001LRPA = (GridView)Tabs.FindControl("grd001LRPA");

    //    ttxt001LRPA.Text = "";
    //    ttxt002LRPA.Text = "";
    //    ttxt003LRPA.Text = "";
    //    ttxt007LRPA.Text = "";
    //    ttxt009LRPA.Text = "";
    //    tlbl_avisoDuracionLRPA.Visible = false;
    //    tllblfechaini1LRPA.Visible = false;
    //    tddown001LRPA.Value = null;

    //    tgrd001LRPA.DataSource = dt;
    //    tgrd001LRPA.DataBind();
    //    tgrd001LRPA.Visible = false;



    //    #endregion

    //    #region Limpia_tab5
    //    GridView tgrd001Audiencia = (GridView)Tabs.FindControl("grd001Audiencia");
    //    DropDownList tddown021 = (DropDownList)Tabs.FindControl("ddown021");
    //    TextBox ttxt007 = (TextBox)Tabs.FindControl("txt007");

    //    tgrd001Audiencia.DataSource = dt;
    //    tgrd001Audiencia.DataBind();
    //    tgrd001Audiencia.Visible = false;
    //    tddown021.SelectedIndex = -1;
    //    txt007.Text = "";

    //    tddown021.BackColor = System.Drawing.Color.White;
    //    ttxt007.BackColor = System.Drawing.Color.White;

    //    #endregion

    //}
    protected void grd004_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd004.PageIndex = e.NewPageIndex;
        carga_grilla();
    }
    //protected void wib001ExpXls_Click(object sender, EventArgs e)
    //{

    //}

    protected void btn001_Click(object sender, EventArgs e)
    {
        #region Definicion de Controles

        DropDownList tddown016 = (DropDownList)Tabs.FindControl("ddown016");
        DropDownList tddown014 = (DropDownList)Tabs.FindControl("ddown014");
        DropDownList tddown015 = (DropDownList)Tabs.FindControl("ddown015");
        DropDownList tddown_ota = (DropDownList)Tabs.FindControl("ddown_ota");
        DropDownList tddown_otc = (DropDownList)Tabs.FindControl("ddown_otc");
        DropDownList tddown03_ot = (DropDownList)Tabs.FindControl("ddown03_ot");
        DropDownList tddown_otm = (DropDownList)Tabs.FindControl("ddown_otm");
        DropDownList ttddownMC_ot = (DropDownList)Tabs.FindControl("ddownMC_ot");// revisar que control es este
        GridView tgrd001 = (GridView)Tabs.FindControl("grd001");
        TextBox ttxt005 = (TextBox)Tabs.FindControl("txt005");
        //Infragistics.WebUI.WebSchedule.WebDateChooser tddown017 = (Infragistics.WebUI.WebSchedule.WebDateChooser)Tabs.FindControl("ddown017");
        TextBox tddown017 = (TextBox)Tabs.FindControl("ddown017");
        TextBox ttxt006F2 = (TextBox)Tabs.FindControl("txt006F2");
        TextBox ttxt007F2 = (TextBox)Tabs.FindControl("txt007F2");
        RadioButtonList trdo001 = (RadioButtonList)Tabs.FindControl("rdo001");///ddown_otm

        #endregion

        #region Validacion
        if (tddown014.SelectedValue == "0" || tddown015.SelectedValue == "0" || tddown016.SelectedValue == "0" ||
            ttxt006F2.Text.Trim() == "" || ttxt007F2.Text.Trim() == "")
        {
            if (ttxt006F2.Text.Trim() == "")
            { ttxt006F2.BackColor = System.Drawing.Color.Pink; }
            else { ttxt006F2.BackColor = System.Drawing.Color.White; }

            if (ttxt007F2.Text.Trim() == "")
            { ttxt007F2.BackColor = System.Drawing.Color.Pink; }
            else { ttxt007F2.BackColor = System.Drawing.Color.White; }

            if (tddown014.SelectedValue == "0")
            { tddown014.BackColor = System.Drawing.Color.Pink; }
            else { tddown014.BackColor = System.Drawing.Color.White; }

            if (tddown015.SelectedValue == "0")
            { tddown015.BackColor = System.Drawing.Color.Pink; }
            else { tddown015.BackColor = System.Drawing.Color.White; }

            if (tddown016.SelectedValue == "0")
            { tddown016.BackColor = System.Drawing.Color.Pink; }
            else { tddown016.BackColor = System.Drawing.Color.White; }
        }
        #endregion
        
        else
        {
            //coordinador cr = new coordinador();

            //DataTable dt = cr.callto_get_coordinacionninoingresorep(Convert.ToInt32(lbl004.Text), Convert.ToInt32(CodProy),
            //ttxt006F2.Text, ttxt007F2.Text);
            
            //if (dt.Rows[0][0].ToString() == "0")
            //{
                DateTime fecha;
                if (tddown017.Text != null)
                {
                    if (tddown017.Text.ToString() != "")
                    { fecha = Convert.ToDateTime(tddown017.Text.ToString()); }
                    else
                    { fecha = Convert.ToDateTime(DateTime.Now.ToShortDateString()); }
                }
                else
                {
                    fecha = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                }

                string iden = Guid.NewGuid().ToString();

                Vruc = ttxt006F2.Text.Trim();
                Vrit = ttxt007F2.Text.Trim();

                DataRow dr = DTordentribunales.NewRow();
                dr[0] = Convert.ToInt32(tddown016.SelectedValue);
                dr[1] = tddown016.SelectedItem.Text;
                dr[2] = fecha;
                if (trdo001.Text == "0")
                { dr[3] = "No";}
                else if (trdo001.Text == "1")
                { dr[3] = "Si"; }
                else
                { dr[3] = "Sin Información"; }
            
                dr[4] = ttxt006F2.Text;
                dr[5] = ttxt007F2.Text;
                dr[6] = iden;

                DTordentribunales.Rows.Add(dr);
                DataView dv = new DataView(DTordentribunales);
                tgrd001.DataSource = dv;
                tgrd001.DataBind();
                tgrd001.Visible = true;
                tddown014.Focus();

               
            
            ///// cero en OT
            
            
                DataTable dtOt = new DataTable();
                DataRow drOt;
                dtOt.Columns.Add(new DataColumn("Cod", typeof(string)));
                dtOt.Columns.Add(new DataColumn("Descripcion", typeof(string)));


                drOt = dtOt.NewRow();
                drOt[0] = "0";
                drOt[1] = " Seleccionar";
                dtOt.Rows.Add(drOt);

                drOt = dtOt.NewRow();
                drOt[0] = iden;
                drOt[1] = "(" + tddown016.SelectedValue.ToString() + ")" + "-" + tddown016.SelectedItem.Text;
                dtOt.Rows.Add(drOt);

                DataView dvOt = new DataView(dtOt);

          //fin OT      



                ListItem oItem = new ListItem("(" + tddown016.SelectedValue.ToString() + ")" + "-" + tddown016.SelectedItem.Text, iden);
                
                
                
                //tddown_otc.Items.Add(oItem);
                //tddown03_ot.Items.Add(oItem);
                //tddown_otm.Items.Add(oItem);
                DropDownList tddown4_otm = (DropDownList)Tabs.FindControl("ddown4_otm");
                DropDownList tddownMC_ot = (DropDownList)Tabs.FindControl("ddownMC_ot");
                VOT = oItem.Text;
            
                //tddown4_otm.Items.Add(oItem);
                //tddown_ota.Items.Add(oItem);

            // continuacio OT


                tddown_otc.DataSource = dvOt;
                tddown_otc.DataTextField = "Descripcion";
                tddown_otc.DataValueField = "Cod";
                dvOt.Sort = "Descripcion";
                tddown_otc.DataBind();

                //tddown_otm.DataSource = dvOt;
                //tddown_otm.DataTextField = "Descripcion";
                //tddown_otm.DataValueField = "Cod";
                //dvOt.Sort = "Descripcion";
                //tddown_otm.DataBind();

                tddown_ota.DataSource = dvOt;
                tddown_ota.DataTextField = "Descripcion";
                tddown_ota.DataValueField = "Cod";
                dvOt.Sort = "Descripcion";
                tddown_ota.DataBind();

                tddown_otm.DataSource = dvOt;
                tddown_otm.DataTextField = "Descripcion";
                tddown_otm.DataValueField = "Cod";
                dvOt.Sort = "Descripcion";
                tddown_otm.DataBind();

                tddown03_ot.DataSource = dvOt;
                tddown03_ot.DataTextField = "Descripcion";
                tddown03_ot.DataValueField = "Cod";
                dvOt.Sort = "Descripcion";
                tddown03_ot.DataBind();

                tddown4_otm.DataSource = dvOt;
                tddown4_otm.DataTextField = "Descripcion";
                tddown4_otm.DataValueField = "Cod";
                dvOt.Sort = "Descripcion";
                tddown4_otm.DataBind();



                //tddown_otc.DataSource = dvOt;
                //tddown_otm.DataSource = dvOt;
                //tddown_ota.DataSource = dvOt;
                //tddown_otm.DataSource = dvOt;
                //tddown03_ot.DataSource = dvOt;

               

            // fin OT

                trdo001.SelectedValue = "0";
                ttxt006F2.Text = "";
                ttxt007F2.Text = "";
                tddown014.SelectedIndex = -1;
                tddown016.SelectedIndex = -1;
                tddown015.SelectedIndex = -1;
                tddown017.Text = "Seleccione Fecha";
                ttxt006F2.BackColor = System.Drawing.Color.White;
                ttxt007F2.BackColor = System.Drawing.Color.White;
                tddown014.BackColor = System.Drawing.Color.White;
                tddown015.BackColor = System.Drawing.Color.White;
                tddown016.BackColor = System.Drawing.Color.White;
                tddown017.BackColor = System.Drawing.Color.White;

                
           
        }

        TextBox ttxtfoco = (TextBox)Tabs.FindControl("txtfoco");
        ttxtfoco.Focus();

    }

    protected bool validatribunal()
    {
        DropDownList tddown03_Proy = (DropDownList)Tabs.FindControl("ddown03_Proy");
        DropDownList tddown03_ot = (DropDownList)Tabs.FindControl("ddown03_ot");
        DropDownList tddown03_rt = (DropDownList)Tabs.FindControl("ddown03_rt");
        TextBox tddown001 = (TextBox)Tabs.FindControl("ddown001");

        bool sw = false;

        if (tddown03_Proy.SelectedValue == "0")
        {
            tddown03_Proy.BackColor = System.Drawing.Color.Pink;
            sw = true;
        }
        else
        {
            tddown03_Proy.BackColor = System.Drawing.Color.White;

        }


        if (tddown03_rt.SelectedValue == "0")
        {
            tddown03_rt.BackColor = System.Drawing.Color.Pink;
            sw = true;
        }
        else
        {
            tddown03_rt.BackColor = System.Drawing.Color.White;

        }

        if (tddown03_ot.SelectedValue == "0")
        {
            tddown03_ot.BackColor = System.Drawing.Color.Pink;
            sw = true;
        }
        else
        {
            tddown03_ot.BackColor = System.Drawing.Color.White;

        }

        if (tddown001.Text.ToUpper() == "SELECCIONE FECHA")
        {
            tddown001.BackColor = System.Drawing.Color.Pink;
            sw = true;
        }
        else
        {
            tddown001.BackColor = System.Drawing.Color.White;

        }

        return sw;
    }

    protected void btn003_Click(object sender, EventArgs e)
    {
        coordinador cr = new coordinador();
        GridView tgrd001 = (GridView)Tabs.FindControl("grd001");
        DropDownList tddown03_Proy = (DropDownList)Tabs.FindControl("ddown03_Proy");
        TextBox ttxt006F2 = (TextBox)Tabs.FindControl("txt006F2");
        TextBox ttxt007F2 = (TextBox)Tabs.FindControl("txt007F2");
        TextBox tddown001 = (TextBox)Tabs.FindControl("ddown001");

        if (validatribunal()==false)
        {



            DataTable dt = cr.callto_get_coordinacionninoingresorep(Convert.ToInt32(lbl004.Text), Convert.ToInt32(tddown03_Proy.SelectedValue), /*Server.HtmlDecode( tgrd001.Rows[0].Cells[4].Text)*/
                    Vruc, /*Server.HtmlDecode(tgrd001.Rows[0].Cells[5].Text)*/Convert.ToDateTime(tddown001.Text));
            VFechaderivacion = Convert.ToDateTime(tddown001.Text);
            if (dt.Rows[0][0].ToString() == "0")
            {
                DropDownList tddown03_ot = (DropDownList)Tabs.FindControl("ddown03_ot");
                DropDownList tddown03_rt = (DropDownList)Tabs.FindControl("ddown03_rt");
                //DropDownList tddown03_Proy = (DropDownList)Tabs.FindControl("ddown03_Proy");
                //WebDateChooser tddown001 = (TextBox)Tabs.FindControl("ddown001");
                TextBox ttxt001 = (TextBox)Tabs.FindControl("txt001");
                GridView tgrd001_Resolucion = (GridView)Tabs.FindControl("grd001_Resolucion");


                if (tddown03_ot.SelectedValue == "0" || tddown03_rt.SelectedValue == "0" || tddown001.Text == "0" ||
                    tddown03_Proy.SelectedValue == "0")//ttxt001.Text.Trim() == "")
                {
                    //if (ttxt001.Text.Trim() == "")
                    //{ ttxt001.BackColor = System.Drawing.Color.Pink; }
                    //else { ttxt001.BackColor = System.Drawing.Color.White; }

                    //if (tddown03_ot.SelectedValue == "0")
                    //{ tddown03_ot.BackColor = System.Drawing.Color.Pink; }
                    //else { tddown03_ot.BackColor = System.Drawing.Color.White; }

                    //if (tddown03_rt.SelectedValue == "0")
                    //{ tddown03_rt.BackColor = System.Drawing.Color.Pink; }
                    //else { tddown03_rt.BackColor = System.Drawing.Color.White; }

                    //if (tddown001.SelectedValue == "0")
                    //{ tddown001.BackColor = System.Drawing.Color.Pink; }
                    //else { tddown001.BackColor = System.Drawing.Color.White; }
                }

                else
                {


                    DateTime fecha;

                    fecha = Convert.ToDateTime(DateTime.Now.ToShortDateString());




                    bool sw = true;

                    DataRow dr;

                    if (tgrd001_Resolucion.Rows.Count > 0)
                    {

                        bool sw1 = false;
                        for (int i = 0; i < tgrd001_Resolucion.Rows.Count; i++)
                        {
                            //DTResoluciones.Columns.Add(new DataColumn("OrdenTribunal", typeof(string)));
                            //DTResoluciones.Columns.Add(new DataColumn("ResolucionTribunal", typeof(string)));
                            //DTResoluciones.Columns.Add(new DataColumn("Proyecto", typeof(string)));
                            //DTResoluciones.Columns.Add(new DataColumn("FechaDerivacion", typeof(DateTime)));
                            //DTResoluciones.Columns.Add(new DataColumn("IcodIngreso", typeof(int)));
                            //DTResoluciones.Columns.Add(new DataColumn("IcodOrdenTribunal", typeof(int)));
                            //DTResoluciones.Columns.Add(new DataColumn("CodResolucionTribunal", typeof(int)));
                            //DTResoluciones.Columns.Add(new DataColumn("CodProyecto", typeof(int)));
                            dr = DTResoluciones.NewRow();
                            //dr[0] = Server.HtmlDecode(tgrd001_Resolucion.Rows[0].Cells[0].Text);
                            //dr[1] = Server.HtmlDecode(tgrd001_Resolucion.Rows[0].Cells[1].Text);
                            //dr[2] = Server.HtmlDecode(tgrd001_Resolucion.Rows[0].Cells[2].Text);
                            //dr[3] = Server.HtmlDecode(tgrd001_Resolucion.Rows[0].Cells[3].Text);
                            ////dr[4] = "3";
                            //dr[5] = VICodOrdenTribunal;
                            //dr[6] = Convert.ToInt32(tddown03_rt.SelectedValue);
                            //dr[7] = Convert.ToInt32(tddown03_Proy.SelectedValue);

                            dr[0] = tddown03_ot.SelectedItem;
                            dr[1] = tddown03_rt.SelectedItem;
                            dr[6] = tddown03_rt.SelectedValue;
                            dr[2] = tddown03_Proy.SelectedItem;
                            dr[7] = tddown03_Proy.SelectedValue;

                            if (tddown001.Text.ToUpper() == "SELECCIONE FECHA")
                            {
                                tddown001.BackColor = System.Drawing.Color.Pink;
                            }
                            else
                            {
                                dr[3] = Convert.ToDateTime(tddown001.Text);
                                sw = true;

                            }


                            if (tddown03_rt.SelectedValue == "0")
                            {
                                tddown03_rt.BackColor = System.Drawing.Color.Pink;
                                sw = false;
                            }
                            else
                            {
                                dr[5] = tddown03_rt.SelectedValue;
                            }

                            DTResoluciones.Rows.Add(dr);

                            VProy = Convert.ToInt32(tddown03_Proy.SelectedValue);

                            CodProy = tddown03_Proy.SelectedValue;
                            // DTResoluciones.Rows.Add(dr);
                        }

                        // DTResoluciones.Clear();
                        DataView dv = new DataView(DTResoluciones);
                        tgrd001_Resolucion.DataSource = dv;
                        tgrd001_Resolucion.DataBind();
                        tgrd001_Resolucion.Visible = true;


                        //tddown03_ot.SelectedValue = "0";

                        //tddown001.Value = "Seleccione Fecha";

                        //tddown03_rt.SelectedValue = "0";
                        //tddown03_Proy.SelectedValue = "0";
                        //tddown03_ot.BackColor = System.Drawing.Color.White;
                        //tddown03_rt.BackColor = System.Drawing.Color.White;
                        //tddown001.BackColor = System.Drawing.Color.White;


                        //Tabs.Tabs[0].Style.ForeColor = System.Drawing.Color.Black;
                        //Tabs.Tabs[2].Style.ForeColor = System.Drawing.Color.Black;
                        //tddown001.BackColor = System.Drawing.Color.White;
                        //tddown03_Proy.BackColor = System.Drawing.Color.White;



                    }
                    else
                    {
                        VFechaderivacion = Convert.ToDateTime(tddown001.Text);
                        dr = DTResoluciones.NewRow();
                        dr[0] = tddown03_ot.SelectedItem;
                        dr[1] = tddown03_rt.SelectedItem;
                        dr[6] = tddown03_rt.SelectedValue;
                        dr[2] = tddown03_Proy.SelectedItem;
                        dr[7] = tddown03_Proy.SelectedValue;
                        if (tddown001.Text.ToUpper() == "SELECCIONE FECHA")
                        {
                            tddown001.BackColor = System.Drawing.Color.Pink;
                        }
                        else
                        {
                            dr[3] = Convert.ToDateTime(tddown001.Text);
                            sw = true;

                        }


                        if (tddown03_rt.SelectedValue == "0")
                        {
                            tddown03_rt.BackColor = System.Drawing.Color.Pink;
                            sw = false;
                        }
                        else
                        {
                            dr[5] = tddown03_rt.SelectedValue;
                        }




                        if (sw == true)
                        {
                            VProy = Convert.ToInt32(tddown03_Proy.SelectedValue);

                            CodProy = tddown03_Proy.SelectedValue;
                            DTResoluciones.Rows.Add(dr);
                            DataView dv = new DataView(DTResoluciones);
                            tgrd001_Resolucion.DataSource = dv;
                            tgrd001_Resolucion.DataBind();
                            tgrd001_Resolucion.Visible = true;

                            tddown03_ot.SelectedValue = "0";

                            tddown001.Text = "Seleccione Fecha";


                            tddown03_rt.SelectedValue = "0";
                            tddown03_Proy.SelectedValue = "0";
                            tddown03_ot.BackColor = System.Drawing.Color.White;
                            tddown03_rt.BackColor = System.Drawing.Color.White;
                            tddown001.BackColor = System.Drawing.Color.White;


                            Tabs.Tabs[0].ForeColor = System.Drawing.Color.Black;
                            Tabs.Tabs[2].ForeColor = System.Drawing.Color.Black;
                            tddown001.BackColor = System.Drawing.Color.White;
                            tddown03_Proy.BackColor = System.Drawing.Color.White;


                        }

                    }
                }
            }
            else
            {

                Tabs.Tabs[0].ForeColor = System.Drawing.Color.Red;
                Tabs.Tabs[2].ForeColor = System.Drawing.Color.Red;
                tddown001.BackColor = System.Drawing.Color.Pink;
                tddown03_Proy.BackColor = System.Drawing.Color.Pink;

                Response.Write("<script languaje='javascript'>alert('La causa ya ha sido ingresada para el niño y proyecto seleccionados.');</script>");
            }
        }
        else
        { }
       
    }

    protected void lnk001_Click1(object sender, EventArgs e)
    {
        Calcula_Dias();
        TextBox ttxtfoco3 = (TextBox)Tabs.FindControl("txtfoco3");
        ttxtfoco3.Focus();
    }
  
    private void Calcula_DiasMedida2()
    {
        TextBox ttxtLRPA_PlazMed = (TextBox)Tabs.FindControl("txtLRPA_PlazMed");
        TextBox ttxtLrpa_PlazInv = (TextBox)Tabs.FindControl("txtLrpa_PlazInv");
        TextBox tTxtLrpa_FechPlazMed = (TextBox)Tabs.FindControl("TxtLrpa_FechPlazMed");
        TextBox tTxtLrpa_FechPlazInv = (TextBox)Tabs.FindControl("TxtLrpa_FechPlazInv");
        TextBox ttxtLrpa_AmpPlaz = (TextBox)Tabs.FindControl("txtLrpa_AmpPlaz");

        Label tlblmsg_plazo = (Label)Tabs.FindControl("lblmsg_plazo");
        TextBox twdcMedInv = (TextBox)Tabs.FindControl("wdcMedInv");




        DateTime fechainicioMedida = Convert.ToDateTime("01/01/1900");

        if (twdcMedInv.Text.ToUpper() != "SELECCIONE FECHA")
        {
            fechainicioMedida = Convert.ToDateTime(twdcMedInv.Text);
            tlblmsg_plazo.Text = "";

            if (ttxtLrpa_PlazInv.Text.Trim() == "" && ttxtLRPA_PlazMed.Text.Trim() == "")
            {
                tlblmsg_plazo.Text = "Ingrese los parametros";
                tlblmsg_plazo.Visible = true;
            }
            else
            {
                tlblmsg_plazo.Visible = false;
                if (ttxtLrpa_PlazInv.Text.Trim() == "")
                { ttxtLrpa_PlazInv.Text = "0"; }
                if (ttxtLRPA_PlazMed.Text.Trim() == "")
                { ttxtLRPA_PlazMed.Text = "0"; }


                DateTime fechaterplazo = Convert.ToDateTime(twdcMedInv.Text).AddDays(Convert.ToInt32(ttxtLRPA_PlazMed.Text.Trim()));

                if (ttxtLrpa_PlazInv.Text != "0" || ttxtLrpa_PlazInv.Text != "")
                {
                    DateTime fechaterpalzoInv = Convert.ToDateTime(twdcMedInv.Text).AddDays(Convert.ToInt32(ttxtLrpa_PlazInv.Text.Trim()));
                    tTxtLrpa_FechPlazInv.Text = fechaterpalzoInv.ToShortDateString();
                }
                else
                {
                    tTxtLrpa_FechPlazInv.Text = "";
                }
                tTxtLrpa_FechPlazMed.Text = fechaterplazo.ToShortDateString();

            }
        }
        else
        {
            tlblmsg_plazo.Text = "Ingrese Fecha de Inicio";
            ttxtLRPA_PlazMed.Text = "";
            ttxtLrpa_PlazInv.Text = "";

        }
    }

    private void Calcula_Dias2()
    {
        TextBox ttxtLrpa_PlazMed = (TextBox)Tabs.FindControl("txtLrpa_PlazMed");
        TextBox ttxtLrpa_PlazInv = (TextBox)Tabs.FindControl("txtLrpa_PlazInv");
        TextBox twdcMedInv = (TextBox)Tabs.FindControl("wdcMedInv");
        TextBox tTxtLrpa_FechPlazMed = (TextBox)Tabs.FindControl("TxtLrpa_FechPlazMed");
        TextBox tTxtLrpa_FechPlazInv = (TextBox)Tabs.FindControl("TxtLrpa_FechPlazInv");
        Label tlbl_avisoDuracionLRPA = (Label)Tabs.FindControl("lbl_avisoDuracionLRPA");
        TextBox tddown001LRPA = (TextBox)Tabs.FindControl("ddown001LRPA");
        Label tlblmsg_plazo = (Label)Tabs.FindControl("lblmsg_plazo");

        DateTime fechainiciosancion = Convert.ToDateTime("01/01/1900");

        if (twdcMedInv.Text.ToUpper() != "SELECCIONE FECHA")
        {
            fechainiciosancion = Convert.ToDateTime(twdcMedInv.Text);
            tlblmsg_plazo.Text = "";

            if (twdcMedInv.Text.Trim() == "" && ttxtLrpa_PlazMed.Text.Trim() == "" && ttxtLrpa_PlazInv.Text.Trim() == "")
            {
                tlblmsg_plazo.Text = "Ingrese al menos un parametro";
                tlblmsg_plazo.Visible = true;
            }
            else
            {
                tlblmsg_plazo.Visible = false;
                if (tTxtLrpa_FechPlazMed.Text.Trim() == "")
                { tTxtLrpa_FechPlazMed.Text = "0"; }
                if (tTxtLrpa_FechPlazInv.Text.Trim() == "")
                { tTxtLrpa_FechPlazInv.Text = "0"; }
             

                DateTime fechatermino = Convert.ToDateTime(twdcMedInv.Text);
                fechatermino = fechatermino.AddDays(Convert.ToInt32(ttxtLrpa_PlazMed.Text.Trim()));
                

                tTxtLrpa_FechPlazMed.Text = fechatermino.ToShortDateString();
                tTxtLrpa_FechPlazMed.Enabled = false;
            }
        }
        else
        {
            tlblmsg_plazo.Text = "Ingrese Fecha de Inicio";
            tTxtLrpa_FechPlazMed.Text = "";
            tTxtLrpa_FechPlazInv.Text = "";

        }
        //ttxt001LRPA.FindControl();
    }

    private void Calcula_DiasMedida()
    {
        TextBox ttxtLRPA_PlazMed = (TextBox)Tabs.FindControl("txtLRPA_PlazMed");
        TextBox ttxtLrpa_PlazInv = (TextBox)Tabs.FindControl("txtLrpa_PlazInv");
        TextBox tTxtLrpa_FechPlazMed = (TextBox)Tabs.FindControl("TxtLrpa_FechPlazMed");
        TextBox tTxtLrpa_FechPlazInv = (TextBox)Tabs.FindControl("TxtLrpa_FechPlazInv");
        TextBox ttxtLrpa_AmpPlaz = (TextBox)Tabs.FindControl("txtLrpa_AmpPlaz");

        Label tlblmsg_plazo = (Label)Tabs.FindControl("lblmsg_plazo");
        TextBox twdcMedInv = (TextBox)Tabs.FindControl("wdcMedInv");
       
        
        
       
        DateTime fechainicioMedida = Convert.ToDateTime("01/01/1900");

        if (twdcMedInv.Text.ToUpper() != "SELECCIONE FECHA")
        {
            fechainicioMedida = Convert.ToDateTime(twdcMedInv.Text);
            tlblmsg_plazo.Text = "";

            if (ttxtLrpa_PlazInv.Text.Trim() == "" && ttxtLRPA_PlazMed.Text.Trim() == "")
            {
                tlblmsg_plazo.Text = "Ingrese los parametros";
                tlblmsg_plazo.Visible = true;
            }
            else
            {
                tlblmsg_plazo.Visible = false;
                if (ttxtLrpa_PlazInv.Text.Trim() == "")
                { ttxtLrpa_PlazInv.Text = "0"; }
                if (ttxtLRPA_PlazMed.Text.Trim() == "")
                { ttxtLRPA_PlazMed.Text = "0"; }


                DateTime fechaterplazo = Convert.ToDateTime(twdcMedInv.Text).AddDays(Convert.ToInt32(ttxtLRPA_PlazMed.Text.Trim()));

                if (ttxtLrpa_PlazInv.Text != "0" || ttxtLrpa_PlazInv.Text != "")
                {
                    DateTime fechaterpalzoInv = Convert.ToDateTime(twdcMedInv.Text).AddDays(Convert.ToInt32(ttxtLrpa_PlazInv.Text.Trim()));
                    tTxtLrpa_FechPlazInv.Text = fechaterpalzoInv.ToShortDateString();
                }
                else 
                {
                    tTxtLrpa_FechPlazInv.Text = ""; 
                }
                tTxtLrpa_FechPlazMed.Text = fechaterplazo.ToShortDateString();
                
            }
        }
        else
        {
            tlblmsg_plazo.Text = "Ingrese Fecha de Inicio";
            ttxtLRPA_PlazMed.Text = "";
            ttxtLrpa_PlazInv.Text = "";

        }
    }
    private bool FiltroLRPA()
    {

        DropDownList tddown03_Proy = (DropDownList)Tabs.FindControl("ddown03_Proy");
        #region FiltroLRPA

        bool swLrpa;

        LRPAcoll LRPA = new LRPAcoll();

        DataTable dt = new DataTable();

        dt = LRPA.callto_get_proyectoslrpa(VProy);//Convert.ToInt32(tddown03_Proy.SelectedValue));//SSnino.CodProyecto);

        if(Convert.ToInt32(dt.Rows[0][0]) > 0 && dt.Rows[0][1].ToString() == "20084")
        {
            swLrpa = true;
        }
        else
        {
            swLrpa = false;
        }

        return (swLrpa);


        #endregion

    }

    protected void btn_AmpliaPLazo_Click(object sender, EventArgs e)
    {
        Label tlblAmpliaInvestigacion = (Label)Tabs.FindControl("lblAmpliaInvestigacion");
        Label tlblmsg_plazo = (Label)Tabs.FindControl("lblmsg_plazo");
        Label tlblAmpl = (Label)Tabs.FindControl("lblAmpl");
        TextBox tTxtLrpa_FechPlazInv = (TextBox)Tabs.FindControl("TxtLrpa_FechPlazInv");
        TextBox ttxtAmplDias = (TextBox)Tabs.FindControl("txtAmplDias");
        GridView tgrdLrpa_Actuaplazo = (GridView)Tabs.FindControl("grdLrpa_Actuaplazo");
        TextBox twdcMedInv = (TextBox)Tabs.FindControl("wdcMedInv");

        DateTime fechainicioMedida = Convert.ToDateTime("01/01/1900");

        if (twdcMedInv.Text.ToUpper() != "SELECCIONE FECHA")
        {
            fechainicioMedida = Convert.ToDateTime(twdcMedInv.Text);
            tlblmsg_plazo.Text = "";

            if (ttxtAmplDias.Text.Trim() == "")
            {
                tlblAmpl.Text = "Ingrese Días de Ampliación";
                tlblAmpl.Visible = true;
            }
            else
            {
                tlblAmpl.Visible = false;
                if (ttxtAmplDias.Text.Trim() == "")
                { ttxtAmplDias.Text = "0"; }

                DateTime fechaAmpSancion = Convert.ToDateTime(twdcMedInv.Text).AddDays(Convert.ToInt32(ttxtAmplDias.Text.Trim()));

                tTxtLrpa_FechPlazInv.Text = fechaAmpSancion.ToShortDateString();


                DataRow dr = DTAmpliacionesMedidas.NewRow();
                string User = Function_ConsultaUsuario(Session["IdUsuario"].ToString());

                dr[0] = fechaAmpSancion.ToShortDateString();
                dr[1] = User;
                dr[2] = ttxtAmplDias.Text;
              

                DTAmpliacionesMedidas.Rows.Add(dr);
                DataView dv = new DataView(DTAmpliacionesMedidas);
                tgrdLrpa_Actuaplazo.DataSource = dv;
                tgrdLrpa_Actuaplazo.DataBind();
                tgrdLrpa_Actuaplazo.Visible = true;
                                                          
            }
        }
        else
        {
            tlblAmpl.Text = "Ingrese Fecha de Inicio";
            ttxtAmplDias.Text = "";
            

        }




    }



    //**************Rescata Usuario******************//Convert.ToInt32(Session["IdUsuario"])
    private string Function_ConsultaUsuario(string userID)
    {
        List<DbParameter> listDbParameter = new List<DbParameter>();
        coordinador cr = new coordinador();

        string sqlSelect = "SELECT Usuario FROM Usuarios WHERE Idusuario =@pIdUsuario";

        listDbParameter.Add(Conexiones.CrearParametro("@pIdUsuario", SqlDbType.Int, 4, Convert.ToInt32(userID)));

        DataTable dt = new DataTable();
        dt = cr.ejecuta_SQL(sqlSelect, listDbParameter);

        string Usuario = (dt.Rows[0][0]).ToString();
        return (Usuario);
       


    }


    protected void btnAgregarMedida_Click(object sender, EventArgs e)
    {
        TextBox ttxt001LRPA = (TextBox)Tabs.FindControl("txt001LRPA");
        TextBox ttxt002LRPA = (TextBox)Tabs.FindControl("txt002LRPA");
        TextBox ttxt007LRPA = (TextBox)Tabs.FindControl("txt007LRPA");
        TextBox ttxt009LRPA = (TextBox)Tabs.FindControl("txt009LRPA");
        TextBox ttxt004LRPA = (TextBox)Tabs.FindControl("txt004LRPA");
        TextBox ttxt003LRPA = (TextBox)Tabs.FindControl("txt003LRPA");

        Label tlbl_avisoDuracionLRPA = (Label)Tabs.FindControl("lbl_avisoDuracionLRPA");
        TextBox tddown001LRPA = (TextBox)Tabs.FindControl("ddown001LRPA");
        Label tllblfechaini1LRPA = (Label)Tabs.FindControl("lblfechaini1LRPA");
        DateTime fechainiciosancion = Convert.ToDateTime("01/01/1900");
        DropDownList tddown_otm = (DropDownList)Tabs.FindControl("ddown_otm");

        GridView tgrd001LRPA = (GridView)Tabs.FindControl("grd001LRPA");
        bool chk = true;

        if (Convert.ToInt32(ttxt004LRPA.Text) > 0)
        {
            chk = true;
            if (tddown001LRPA.Text.ToUpper() != "SELECCIONE FECHA" || ttxt003LRPA.Text.Trim() != "")
            {
                chk = false;
                if (tddown001LRPA.Text.ToUpper() == "SELECCIONE FECHA")
                { tddown001LRPA.BackColor = System.Drawing.Color.Pink; }
                else { tddown001LRPA.BackColor = System.Drawing.Color.White; }

                if (ttxt003LRPA.Text.Trim() == "")
                { ttxt003LRPA.BackColor = System.Drawing.Color.Pink; }
                else { ttxt003LRPA.BackColor = System.Drawing.Color.White; }
            }
            else if (tddown001LRPA.Text.ToUpper() == "SELECCIONE FECHA" && ttxt003LRPA.Text.Trim() == "")
            {
                tddown001LRPA.Text = Convert.ToDateTime("01-01-1900").ToString();
                ttxt003LRPA.Text = "01-01-1900";
                ttxt001LRPA.Text = "0";
                ttxt002LRPA.Text = "0";
                ttxt007LRPA.Text = "0";
                ttxt009LRPA.Text = "0";

                tddown001LRPA.BackColor = System.Drawing.Color.White;
                ttxt003LRPA.BackColor = System.Drawing.Color.White;
            }


        }
        else if (tddown001LRPA.Text.ToUpper() == "SELECCIONE FECHA" || ttxt003LRPA.Text.Trim() == "")
        {
            chk = false;
            if (tddown001LRPA.Text.ToUpper() == "SELECCIONE FECHA")
            { tddown001LRPA.BackColor = System.Drawing.Color.Pink; }
            else { tddown001LRPA.BackColor = System.Drawing.Color.White; }

            if (ttxt003LRPA.Text.Trim() == "")
            { ttxt003LRPA.BackColor = System.Drawing.Color.Pink; }
            else { ttxt003LRPA.BackColor = System.Drawing.Color.White; }

        }

        if (tddown_otm.SelectedValue == "0")
        {
            tddown_otm.BackColor = System.Drawing.Color.Pink;
            chk = false; ;
        }
        else
        {
            tddown_otm.BackColor = System.Drawing.Color.White;
            chk = true;
        }

        if (chk)
        {
            DataRow dr = DTmedidas.NewRow();
            dr[0] = Convert.ToDateTime(tddown001LRPA.Text);
            dr[1] = Convert.ToDateTime(ttxt003LRPA.Text);
            dr[2] = Convert.ToInt32(ttxt001LRPA.Text);
            dr[3] = Convert.ToInt32(ttxt002LRPA.Text);
            dr[4] = Convert.ToInt32(ttxt007LRPA.Text);
            dr[5] = Convert.ToInt32(ttxt009LRPA.Text);
            dr[6] = Convert.ToInt32(ttxt004LRPA.Text);
            dr[7] = tddown_otm.SelectedValue.ToString();
            DTmedidas.Rows.Add(dr);

            tgrd001LRPA.DataSource = DTmedidas;
            tgrd001LRPA.DataBind();
            tgrd001LRPA.Visible = true;

            tddown001LRPA.BackColor = System.Drawing.Color.White;
            ttxt003LRPA.BackColor = System.Drawing.Color.White;
            tddown_otm.BackColor = System.Drawing.Color.White;

            ttxt001LRPA.Text = "";
            ttxt002LRPA.Text = "";
            ttxt003LRPA.Text = "";
            ttxt004LRPA.Text = "0";
            ttxt007LRPA.Text = "";
            ttxt009LRPA.Text = "";
            tddown_otm.SelectedIndex = -1;
            tddown001LRPA.Text = null;

        }
        TextBox ttxtfoco3 = (TextBox)Tabs.FindControl("txtfoco3");
        ttxtfoco3.Focus();
    }
    
    
    protected void btnAgregarMedSanc_Click(object sender, EventArgs e)
    {
        DropDownList tddown4_otm = (DropDownList)Tabs.FindControl("ddown4_otm");
        TextBox twdcMedInv = (TextBox)Tabs.FindControl("wdcMedInv");
        TextBox tTxtLrpa_PlazMed = (TextBox)Tabs.FindControl("txtLrpa_PlazMed");
        TextBox ttxtLrpa_PlazInv = (TextBox)Tabs.FindControl("txtLrpa_PlazInv");
        TextBox tTxtLrpa_FechPlazMed = (TextBox)Tabs.FindControl("TxtLrpa_FechPlazMed");
        TextBox tTxtLrpa_FechPlazInv = (TextBox)Tabs.FindControl("TxtLrpa_FechPlazInv");
        TextBox ttxtAmplDias = (TextBox)Tabs.FindControl("txtAmplDias");
        GridView tgrd004_lrpaMedInv = (GridView)Tabs.FindControl("grd004_lrpaMedInv");

      
           
                DataRow dr = DTMedidasSancion.NewRow();
                dr[0] = Convert.ToString(VICodOrdenTribunal);
                dr[1] = Convert.ToDateTime(twdcMedInv.Text);
                dr[2] = Convert.ToDateTime(tTxtLrpa_FechPlazMed.Text);
                dr[3] = Convert.ToInt32(tTxtLrpa_PlazMed.Text);
                dr[4] = Convert.ToInt32(ttxtLrpa_PlazInv.Text);
                dr[5] = Convert.ToDateTime(tTxtLrpa_FechPlazInv.Text);
                
                DTMedidasSancion.Rows.Add(dr);

                tgrd004_lrpaMedInv.DataSource = DTMedidasSancion;
                tgrd004_lrpaMedInv.DataBind();
                tgrd004_lrpaMedInv.Visible = true;

                //twdcMedInv.Text = "";
                tTxtLrpa_PlazMed.Text = "";
                ttxtLrpa_PlazInv.Text = "";
                tTxtLrpa_FechPlazMed.Text = "";
                tTxtLrpa_FechPlazInv.Text = "";
                ttxtAmplDias.Text = "";
                tddown4_otm.SelectedValue = "0";
                twdcMedInv.Text = "Seleccione Fecha";

            
           
        }
    
   
    private void Calcula_DiasSancion()
    {
        DateTime fechainiciosancion = Convert.ToDateTime("01/01/1900");
        TextBox tddownMC_FecIniSan = (TextBox)Tabs.FindControl("ddownMC_FecIniSan");
        TextBox tddownMC_FecIniSanMix = (TextBox)Tabs.FindControl("ddownMC_FecIniSanMix");
        TextBox ttxtMC_DuracionAbono = (TextBox)Tabs.FindControl("txtMC_DuracionAbono");
        TextBox ttxtMC_DuracionAno = (TextBox)Tabs.FindControl("txtMC_DuracionAno");
        TextBox ttxtMC_DuracionMes = (TextBox)Tabs.FindControl("txtMC_DuracionMes");
        TextBox ttxtMC_DuracionDias = (TextBox)Tabs.FindControl("txtMC_DuracionDias");
        Label tlblMC_fechaini1 = (Label)Tabs.FindControl("lblMC_fechaini1");
        Label tlblMC_avisoDuracion = (Label)Tabs.FindControl("lblMC_avisoDuracion");
        TextBox ttxtMC_FechaSancion = (TextBox)Tabs.FindControl("txtMC_FechaSancion");
 


        if (tddownMC_FecIniSan.Text.ToUpper() != "SELECCIONE FECHA")
        {
            fechainiciosancion = Convert.ToDateTime(tddownMC_FecIniSan.Text);
            tlblMC_fechaini1.Text = "";


            if (ttxtMC_DuracionAno.Text.Trim() == "" && ttxtMC_DuracionMes.Text.Trim() == "" && ttxtMC_DuracionDias.Text.Trim() == "")
            {
                tlblMC_avisoDuracion.Text = "Ingrese al menos un parametro";
                tlblMC_avisoDuracion.Visible = true;

            } 
            else
            {
                tlblMC_avisoDuracion.Visible = false;
                if (ttxtMC_DuracionAno.Text.Trim() == "")
                { ttxtMC_DuracionAno.Text = "0"; }
                if (ttxtMC_DuracionMes.Text.Trim() == "")
                { ttxtMC_DuracionMes.Text = "0"; }
                if (ttxtMC_DuracionDias.Text == "")
                { ttxtMC_DuracionDias.Text = "0"; }

                DateTime fechatermino = Convert.ToDateTime(tddownMC_FecIniSan.Text).AddYears(Convert.ToInt32(ttxtMC_DuracionAno.Text.Trim()));
                fechatermino = fechatermino.AddMonths(Convert.ToInt32(ttxtMC_DuracionMes.Text.Trim()));
                fechatermino = fechatermino.AddDays(Convert.ToInt32(ttxtMC_DuracionDias.Text.Trim()));
                fechatermino = fechatermino.AddDays(-Convert.ToInt32(ttxtMC_DuracionAbono.Text.Trim()));
                ttxtMC_FechaSancion.Text = fechatermino.ToShortDateString();
                ttxtMC_FechaSancion.Enabled = false;

                if (tddownMC_FecIniSanMix.Text.ToUpper() != "SELECCIONE FECHA")
                {
                    tddownMC_FecIniSanMix.Text = Convert.ToDateTime(ttxtMC_FechaSancion.Text).AddDays(1).ToString();
                    Calcula_Dias_Mix();
                }
            }


        }
        else
        {
            tlblMC_fechaini1.Text = "Ingrese Fecha de Inicio";
            ttxtMC_DuracionAno.Text = "";
            ttxtMC_DuracionMes.Text = "";

        }
        ttxtMC_FechaSancion.Focus();
    }


    protected void ddownMC_FecIniSanMix_ValueChanged(object sender, EventArgs e)
    {
        Calcula_Dias_Mix();
    }
    protected void ddownMC_FecIniSan_ValueChanged(object sender, EventArgs e)
    {
        Calcula_DiasSancion();
    }
    protected void lnkMC_Calfecha2_Click(object sender, EventArgs e)
    {
        Calcula_Dias_Mix();
    }
    protected void lnkMC_Calfecha1_Click(object sender, EventArgs e)
    {
        Calcula_DiasSancion();
    }
    protected void ddownMC_TipTribunal_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList tddownMc_Tribunal = (DropDownList)Tabs.FindControl("ddownMc_Tribunal");
        DropDownList tddownMC_TipTribunal = (DropDownList)Tabs.FindControl("ddownMC_TipTribunal");
        DropDownList tddownMC_Region = (DropDownList)Tabs.FindControl("ddownMC_Region");
        

        parcoll pcoll = new parcoll();
        tddownMc_Tribunal.Items.Clear();
        DataView dv2 = new DataView(pcoll.GetparTribunales(tddownMC_Region.SelectedValue, tddownMC_TipTribunal.SelectedValue));

        tddownMc_Tribunal.Items.Clear();
        tddownMc_Tribunal.DataSource = dv2;
        tddownMc_Tribunal.DataTextField = "Descripcion";
        tddownMc_Tribunal.DataValueField = "CodTribunal";
        dv2.Sort = "Descripcion";
        tddownMc_Tribunal.DataBind();
        tddownMC_TipTribunal.Focus();
        


    }
    protected void ChkMC_Mixta_CheckedChanged(object sender, EventArgs e)
    {
        Panel tpnlMC_mixta = (Panel)Tabs.FindControl("pnlMC_mixta");
        CheckBox tChkMC_Mixta = (CheckBox)Tabs.FindControl("ChkMC_Mixta");

        if (tChkMC_Mixta.Checked)
        {
            tpnlMC_mixta.Visible = true;
        }
        else 
        {
            tpnlMC_mixta.Visible = false;
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

        Button tbtn_GuardarLRPA = (Button)Tabs.FindControl("btn_GuardarLRPA");
        Label tlbl_aviso2LRPA = (Label)Tabs.FindControl("lbl_aviso2LRPA");
        Label tlbl_aviso_graba = (Label)Tabs.FindControl("lbl_aviso_graba");
        Panel tpnlLRPAmixta = (Panel)Tabs.FindControl("pnlLRPAmixta");
        Panel tPanel3 = (Panel)Tabs.FindControl("Panel3");
        Panel tpnldatos = (Panel)Tabs.FindControl("pnldatos");
        
        tbtn_GuardarLRPA.Text = "Guardar";
        tbtn_GuardarLRPA.Visible = true;
        
        LimpiaControles();
        tlbl_aviso2LRPA.Visible = false;
        tlbl_aviso_graba.Visible = false;
        tpnlLRPAmixta.Visible = false;
        tPanel3.Visible = false;
        tpnldatos.Visible = true;
    }
    private void LimpiaControles()
    {
        //DropDownList tddown001LRPA = (DropDownList)Tabs.FindControl("ddown001LRPA");
        DropDownList tddown003LRPA = (DropDownList)Tabs.FindControl("ddown003LRPA");
        DropDownList tddown004LRPA = (DropDownList)Tabs.FindControl("ddown004LRPA");
        DropDownList tddown005LRPA = (DropDownList)Tabs.FindControl("ddown005LRPA");
        DropDownList tddown006LRPA = (DropDownList)Tabs.FindControl("ddown006LRPA");
        //DropDownList tddown007LRPA = (DropDownList)Tabs.FindControl("ddown007LRPA");
        DropDownList tddown008LRPA = (DropDownList)Tabs.FindControl("ddown008LRPA");
        //DropDownList tddown009LRPA = (DropDownList)Tabs.FindControl("ddown009LRPA");
        TextBox tddown001LRPA = (TextBox)Tabs.FindControl("ddown001LRPA");
        TextBox tddown007LRPA = (TextBox)Tabs.FindControl("ddown007LRPA");
        TextBox tddown009LRPA = (TextBox)Tabs.FindControl("ddown009LRPA");

        tddown001LRPA.Text = null;
        tddown003LRPA.SelectedValue = "-2";
        tddown004LRPA.SelectedValue = "0";
        tddown005LRPA.SelectedValue = "0";
        tddown006LRPA.SelectedValue = "0";
        tddown007LRPA.Text = null;
        tddown008LRPA.SelectedValue = "-1";
        tddown009LRPA.Text = null;     //8

        TextBox ttxt001LRPA = (TextBox)Tabs.FindControl("txt001LRPA");
        TextBox ttxt002LRPA = (TextBox)Tabs.FindControl("txt002LRPA");
        TextBox ttxt003LRPA = (TextBox)Tabs.FindControl("txt003LRPA");
        TextBox ttxt004LRPA = (TextBox)Tabs.FindControl("txt004LRPA");
        TextBox ttxt005LRPA = (TextBox)Tabs.FindControl("txt005LRPA");
        TextBox ttxt006LRPA = (TextBox)Tabs.FindControl("txt006LRPA");

        ttxt001LRPA.Text = "";
        ttxt002LRPA.Text = "";
        ttxt003LRPA.Text = "";
        ttxt004LRPA.Text = "";
        ttxt005LRPA.Text = "";
        ttxt006LRPA.Text = "";      //6


        CheckBox tchk001LRPA = (CheckBox)Tabs.FindControl("chk001LRPA");
        CheckBox tChk002LRPAMixta = (CheckBox)Tabs.FindControl("Chk002LRPAMixta");
        tchk001LRPA.Checked = false;
        tChk002LRPAMixta.Checked = false;

        tddown006LRPA.Visible = false;
        Button tbtnAgregarTsancionLRPA = (Button)Tabs.FindControl("btnAgregarTsancionLRPA");
        tbtnAgregarTsancionLRPA.Visible = false;

        GridView tgrd001LRPA = (GridView)Tabs.FindControl("grd001LRPA");
        DataTable dt = new DataTable();
        dt.Rows.Clear();
        tgrd001LRPA.DataSource = dt;
        tgrd001LRPA.DataBind();
    }
    //protected void btn_GuardarLRPA(object sender, EventArgs e)
    //{
    //    GetMedida2();
    //}
    private void GetMedida2()
    {
        DropDownList tddownMC_ModSancMix = (DropDownList)Tabs.FindControl("ddownMC_ModSancMix");
        DropDownList tddownMC_ot = (DropDownList)Tabs.FindControl("ddownMC_ot");
        GridView tgrd_mc_sancion = (GridView)Tabs.FindControl("grd_mc_sancion");

        LRPAcoll LRPA = new LRPAcoll();
        DataTable dtLRPA = new DataTable();
        dtLRPA = LRPA.callto_get_sancionesbycodmedidasancion(SSnino.ICodIE);
        DataTable dtOT = LRPA.GetICodTribunalIngreso_LRPA(SSnino.ICodIE);
        if (dtLRPA.Rows.Count > 0)
        {

            tgrd_mc_sancion.DataSource = dtLRPA;
            tgrd_mc_sancion.DataBind();
            tgrd_mc_sancion.Visible = true;
            //Panel3.Visible = true;


        }

        if (dtOT.Rows.Count > 0)
        {
            tddownMC_ot.Items.Clear();
            tddownMC_ot.DataSource = dtOT;
            tddownMC_ot.DataTextField = "Descripcion";
            tddownMC_ot.DataValueField = "ICodTribunalIngreso";
            tddownMC_ot.DataBind();
        }
      
        tddownMC_ModSancMix.Items.Clear();
        LRPAcoll lrpa = new LRPAcoll();
        DataTable dt = lrpa.callto_get_parmodelosancionmixta();
        tddownMC_ModSancMix.DataSource = dt;
        tddownMC_ModSancMix.DataTextField = "Descripcion";
        tddownMC_ModSancMix.DataValueField = "CodModeloSancionMixta";
        tddownMC_ModSancMix.DataBind();


    }
    protected void chkMC_TipoSanc_CheckedChanged(object sender, EventArgs e)
    {
          grdSanciones();
          SancionACC();
    }
    private void grdSanciones()
    {
        Panel tPnlMC_TipoSancion = (Panel)Tabs.FindControl("PnlMC_TipoSancion");
        CheckBox tchkMC_TipoSanc = (CheckBox)Tabs.FindControl("chkMC_TipoSanc");
        
        if (tchkMC_TipoSanc.Checked)
        {
            tPnlMC_TipoSancion.Visible = true;
        }
        else 
        {
            tPnlMC_TipoSancion.Visible = false;
        }
    }

    protected void lnk001coor_Click(object sender, EventArgs e)
    {
        LinkButton tlnb001 = (LinkButton)Tabs.FindControl("lnb001");
      
        Calcula_Dias();
        
        tlnb001.Focus();
    }
    protected void Chk002LRPAMixta_CheckedChanged(object sender, EventArgs e)
    {
        LinkButton tlnb001 = (LinkButton)Tabs.FindControl("lnb001");
        TextBox tddown009LRPA = (TextBox)Tabs.FindControl("ddown009LRPA");
        CheckBox tChk002LRPAMixta = (CheckBox)Tabs.FindControl("Chk002LRPAMixta");
        TextBox ttxt003LRPA = (TextBox)Tabs.FindControl("txt003LRPA");
        Label tLblfechaLRPA = (Label)Tabs.FindControl("LblfechaLRPA");
        Panel tpnlLRPAmixta = (Panel)Tabs.FindControl("pnlLRPAmixta");
        GridView tgrd001LRPA = (GridView)Tabs.FindControl("grd001LRPA");
        if (tChk002LRPAMixta.Checked)
        {
            if (ttxt003LRPA.Text.Trim() != "")
            {
                tddown009LRPA.Text = Convert.ToDateTime(ttxt003LRPA.Text).AddDays(1).ToString();
                tLblfechaLRPA.Text = "";
            }
            else
            {
                tLblfechaLRPA.Text = "Ingrese fecha de primera sanción";
            }
            tpnlLRPAmixta.Visible = true;
        }
        else
        {
            tpnlLRPAmixta.Visible = false;
        }
        tgrd001LRPA.Focus();
        tlnb001.Focus();
    }
    protected void ddown009LRPA_ValueChanged(object sender, EventArgs e)
    {
        LinkButton tlnb001 = (LinkButton)Tabs.FindControl("lnb001");
        GridView tgrd001LRPA = (GridView)Tabs.FindControl("grd001LRPA");
        Calcula_Dias_Mix();
        tgrd001LRPA.Focus();
        tlnb001.Focus();
    }
    protected void lnk002_Click(object sender, EventArgs e)
    {
        LinkButton tlnb001 = (LinkButton)Tabs.FindControl("lnb001");
        GridView tgrd001LRPA = (GridView)Tabs.FindControl("grd001LRPA");
        Calcula_Dias_Mix();
        tgrd001LRPA.Focus();
        tlnb001.Focus();
    }
    protected void ddown004LRPA_SelectedIndexChanged(object sender, EventArgs e)
    {
    //    /// ver  en sancion.
    //    LinkButton tlnb001 = (LinkButton)Tabs.FindControl("lnb001");
      DropDownList tddown005LRPA = (DropDownList)Tabs.FindControl("ddown005LRPA");
      DropDownList tddown003LRPA = (DropDownList)Tabs.FindControl("ddown003LRPA");
      DropDownList tddown004LRPA = (DropDownList)Tabs.FindControl("ddown004LRPA");
        GridView tgrd001LRPA = (GridView)Tabs.FindControl("grd001LRPA");      
    //    parcoll pcoll = new parcoll();
    //    tddown005LRPA.Items.Clear();
    //    DataView dv2 = new DataView(pcoll.GetparTribunales(tddown003LRPA.SelectedValue, tddown004LRPA.SelectedValue));
    //    tddown005LRPA.Items.Clear();
    //    tddown005LRPA.DataSource = dv2;
    //    tddown005LRPA.DataTextField = "Descripcion";
    //    tddown005LRPA.DataValueField = "CodTribunal";
    //    dv2.Sort = "Descripcion";
    //    tddown005LRPA.DataBind();
    //    //tddown005LRPA.Focus();
    //    tgrd001LRPA.Focus();
        parcoll pcoll = new parcoll();
        tddown005LRPA.Items.Clear();
        DataView dv2 = new DataView(pcoll.GetparTribunales(tddown003LRPA.SelectedValue, tddown004LRPA.SelectedValue));
        tddown005LRPA.Items.Clear();
        tddown005LRPA.DataSource = dv2;
        tddown005LRPA.DataTextField = "Descripcion";
        tddown005LRPA.DataValueField = "CodTribunal";
        dv2.Sort = "Descripcion";
        tddown005LRPA.DataBind();
       // tddown004LRPA.Focus();
        
    }
    protected void lnk_limpiaFechas_Click(object sender, EventArgs e)
    {
        LinkButton tlnb001 = (LinkButton)Tabs.FindControl("lnb001");
        TextBox tddown001LRPA = (TextBox)Tabs.FindControl("ddown001LRPA");
        TextBox tddown009LRPA = (TextBox)Tabs.FindControl("ddown009LRPA");
        //WebDateChooser tddown001LRPA = (TextBox)Tabs.FindControl("ddown001LRPA");
        TextBox ttxt001LRPA = (TextBox)Tabs.FindControl("txt001LRPA");
        TextBox ttxt002LRPA = (TextBox)Tabs.FindControl("txt002LRPA");
        TextBox ttxt003LRPA = (TextBox)Tabs.FindControl("txt003LRPA");
        TextBox ttxt004LRPA = (TextBox)Tabs.FindControl("txt004LRPA");
        TextBox ttxt005LRPA = (TextBox)Tabs.FindControl("txt005LRPA");
        TextBox ttxt006LRPA = (TextBox)Tabs.FindControl("txt006LRPA");
        TextBox ttxt007LRPA = (TextBox)Tabs.FindControl("txt007LRPA");
        TextBox ttxt008LRPA = (TextBox)Tabs.FindControl("txt008LRPA");
        CheckBox tChk002LRPAMixta = (CheckBox)Tabs.FindControl("Chk002LRPAMixta");
        Panel tpnlLRPAmixta = (Panel)Tabs.FindControl("pnlLRPAmixta");
        
        ttxt001LRPA.Text = "";
        ttxt002LRPA.Text = "";
        ttxt003LRPA.Text = "";
        ttxt004LRPA.Text = "";
        ttxt005LRPA.Text = "";
        ttxt006LRPA.Text = "";
        ttxt007LRPA.Text = "";
        ttxt008LRPA.Text = "";
        tddown001LRPA.Text = null;
        tddown009LRPA.Text = null;
        tChk002LRPAMixta.Checked = false;
        tpnlLRPAmixta.Visible = false;
        tlnb001.Focus();
    }
    protected void chk001LRPA_CheckedChanged(object sender, EventArgs e)
    {
        LinkButton tlnb001 = (LinkButton)Tabs.FindControl("lnb001");
        CheckBox tchk001LRPA = (CheckBox)Tabs.FindControl("chk001LRPA");
        Button tbtnAgregarTsancionLRPA = (Button)Tabs.FindControl("btnAgregarTsancionLRPA");
        GridView tgrd001LRPA = (GridView)Tabs.FindControl("grd001LRPA");
        DropDownList tddown006LRPA = (DropDownList)Tabs.FindControl("ddown006LRPA");



        if (tchk001LRPA.Checked)
        {
            // pnl1LRPA.Visible = true;
            tbtnAgregarTsancionLRPA.Visible = true;
            tgrd001LRPA.Visible = true;
            tddown006LRPA.Visible = true;
        }
        else
        {
            // pnl1LRPA.Visible = false;
            tbtnAgregarTsancionLRPA.Visible = false;
            tgrd001LRPA.Visible = false;
            tddown006LRPA.Visible = false;
        }

        SancionACC();

         tlnb001.Focus();
    }
    private void SancionACC()
    {
        DropDownList tddown006LRPA = (DropDownList)Tabs.FindControl("ddown006LRPA");

        LRPAcoll lrpa = new LRPAcoll();
        tddown006LRPA.Items.Clear();
        DataView dv2 = new DataView(lrpa.callto_getpartiposancionaccesoria());

        tddown006LRPA.DataSource = dv2;
        tddown006LRPA.DataTextField = "Descripcion";
        tddown006LRPA.DataValueField = "CodTipoSancionAccesoria";
        dv2.Sort = "Descripcion";
        tddown006LRPA.DataBind();
        tddown006LRPA.Focus();
    }

    //protected void btnAgregarTsancionLRPA_Click(object sender, EventArgs e)
    //{
    //    bool chk_rep = false;
    //    DTTipoSancionAccesoria.Clear();
    //    if (DTTipoSancionAccesoria.Columns.Count == Convert.ToInt32(4))
    //    {
    //        DTTipoSancionAccesoria.Columns.Remove(DTTipoSancionAccesoria.Columns[3]);
    //    }
    //    LinkButton tlnb001 = (LinkButton)Tabs.FindControl("lnb001");
    //    DropDownList tddown006LRPA = (DropDownList)Tabs.FindControl("ddown006LRPA");
    //    GridView tgrd001LRPA = (GridView)Tabs.FindControl("grd001LRPA");
    //    Label tlbl_avisoLRPA = (Label)Tabs.FindControl("lbl_avisoLRPA");


    //    if (tddown006LRPA.SelectedValue != Convert.ToString(0))
    //    {
           
    //        for (int i = 0; i < tgrd001LRPA.Rows.Count; i++)
    //        {
    //            DataRow dr = DTTipoSancionAccesoria.NewRow();
    //            dr[0] = Server.HtmlDecode(tgrd001LRPA.Rows[i].Cells[1].Text);
    //            dr[1] = Server.HtmlDecode(tgrd001LRPA.Rows[i].Cells[2].Text);
    //            dr[2] = Server.HtmlDecode(tgrd001LRPA.Rows[i].Cells[0].Text);
    //            DTTipoSancionAccesoria.Rows.Add(dr);

    //            if (tgrd001LRPA.Rows[i].Cells[0].Text == tddown006LRPA.SelectedValue)
    //            {
    //                chk_rep = true;
    //            }
    //        }

    //        if (!chk_rep)
    //        {
             
               
    //            DataRow dr =  DTTipoSancionAccesoria.NewRow();
    //            dr[0] = tddown006LRPA.SelectedItem;
    //            dr[1] = 3;
    //            dr[2] = Convert.ToInt32(tddown006LRPA.SelectedValue); 
                
    //           // dr[3] = Convert.ToInt32(tddown006LRPA.SelectedValue);
    //            DTTipoSancionAccesoria.Rows.Add(dr);
    //            DataView dv = new DataView( DTTipoSancionAccesoria);
    //            tgrd001LRPA.DataSource = dv;
    //            dv.Sort = "CodSancion";
    //            tgrd001LRPA.DataBind();
    //            tgrd001LRPA.Visible = true;
    //            tgrd001LRPA.Focus();

    //           // tddown006LRPA.SelectedValue = Convert.ToString(0);
    //            tddown006LRPA.BackColor = System.Drawing.Color.White;
    //            tlbl_avisoLRPA.Visible = false;
    //        }
    //        else
    //        {
    //            tlbl_avisoLRPA.Text = "La sanción seleccionada ya ha sido ingresada";
    //            tlbl_avisoLRPA.Visible = true;
    //        }
    //    }
    //    else
    //    {
    //        tddown006LRPA.BackColor = System.Drawing.Color.Pink;
    //    tlbl_avisoLRPA.Text = "Debe ingresar una sanción";
    //        tlbl_avisoLRPA.Visible = true;

    //    }
    //    tlnb001.Focus();
    //    tddown006LRPA.SelectedValue = "0";
    //    //tddown006LRPA.Text = "";
       
    //}
    protected void lnb001_Click(object sender, EventArgs e)
    {
        DropDownList tddown_otm = (DropDownList)Tabs.FindControl("ddown_otm");
        Label tlbl_otm = (Label)Tabs.FindControl("lbl_otm");

        tddown_otm.Items.Add(OtItem);
        tddown_otm.Visible = true;
        tlbl_otm.Visible = true;
    }


    #region insertantiguo
    
    #endregion


    private void GetMedida()
    {

        GridView tgrdseleccionLRPA = (GridView)Tabs.FindControl("grdseleccionLRPA");
        Panel tPanel3 = (Panel)Tabs.FindControl("Panel3");
        DropDownList tddown_otm = (DropDownList)Tabs.FindControl("ddown_otm");
        DropDownList tddown011LRPA = (DropDownList)Tabs.FindControl("ddown011LRPA");


        coordinador ccoll = new coordinador();
        LRPAcoll LRPA = new LRPAcoll();
        DataTable dtLRPA = new DataTable();
        dtLRPA = LRPA.callto_get_sancionesbycodigo(VICodMedidaSancion);
        //dtLRPA = LRPA.callto_get_sancionesbycodmedidasancion(SSnino.ICodIE);
        DataTable dtOT = ccoll.callto_getOrdenTribunalCoor();//LRPA.GetICodTribunalIngreso_LRPA(ASP.global_asax.globaconn, SSnino.ICodIE);
        if (dtLRPA.Rows.Count > 0)//para llenar grilla inicial
        {

            tgrdseleccionLRPA.DataSource = dtLRPA;
            tgrdseleccionLRPA.DataBind();
            tgrdseleccionLRPA.Visible = true;
            tPanel3.Visible = true;


        }

        tddown011LRPA.Items.Clear();
        LRPAcoll lrpa = new LRPAcoll();
        DataTable dt = lrpa.callto_get_parmodelosancionmixta();
        tddown011LRPA.DataSource = dt;
        tddown011LRPA.DataTextField = "Descripcion";
        tddown011LRPA.DataValueField = "CodModeloSancionMixta";
        tddown011LRPA.DataBind();


    }
    //protected void btnAtras_Click(object sender, EventArgs e)
    //{
    //    Panel tPanel3 = (Panel)Tabs.FindControl("Panel3");
    //    Panel tpnldatos = (Panel)Tabs.FindControl("pnldatos");
    //    LimpiaControles();
    //    tPanel3.Visible = true;
    //    tpnldatos.Visible = false;
    //}
    protected void grdseleccionLRPA_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        //DropDownList tddown001LRPA = (DropDownList)Tabs.FindControl("ddown001LRPA");
        DropDownList tddown003LRPA = (DropDownList)Tabs.FindControl("ddown003LRPA");
        DropDownList tddown004LRPA = (DropDownList)Tabs.FindControl("ddown004LRPA");
        DropDownList tddown005LRPA = (DropDownList)Tabs.FindControl("ddown005LRPA");
        DropDownList tddown006LRPA = (DropDownList)Tabs.FindControl("ddown006LRPA");
        //DropDownList tddown007LRPA = (DropDownList)Tabs.FindControl("ddown007LRPA");
        DropDownList tddown008LRPA = (DropDownList)Tabs.FindControl("ddown008LRPA");
        //DropDownList tddown009LRPA = (DropDownList)Tabs.FindControl("ddown009LRPA");
        DropDownList tddown011LRPA = (DropDownList)Tabs.FindControl("ddown011LRPA");
        DropDownList tddown_otm = (DropDownList)Tabs.FindControl("ddown_otm");

        TextBox tddown009LRPA = (TextBox)Tabs.FindControl("ddown009LRPA");
        TextBox tddown001LRPA = (TextBox)Tabs.FindControl("ddown001LRPA");
        TextBox tddown007LRPA = (TextBox)Tabs.FindControl("ddown007LRPA");

        TextBox ttxt001LRPA = (TextBox)Tabs.FindControl("txt001LRPA");
        TextBox ttxt002LRPA = (TextBox)Tabs.FindControl("txt002LRPA");
        TextBox ttxt003LRPA = (TextBox)Tabs.FindControl("txt003LRPA");
        TextBox ttxt004LRPA = (TextBox)Tabs.FindControl("txt004LRPA");
        TextBox ttxt005LRPA = (TextBox)Tabs.FindControl("txt005LRPA");
        TextBox ttxt006LRPA = (TextBox)Tabs.FindControl("txt006LRPA");
        TextBox ttxt007LRPA = (TextBox)Tabs.FindControl("txt007LRPA");
        TextBox ttxt008LRPA = (TextBox)Tabs.FindControl("txt008LRPA");
        TextBox ttxt009LRPA = (TextBox)Tabs.FindControl("txt009LRPA");
        TextBox ttxt0010LRPA = (TextBox)Tabs.FindControl("txt0010LRPA");

        Panel tpnldatos = (Panel)Tabs.FindControl("pnldatos");
        Panel tPanel3 = (Panel)Tabs.FindControl("Panel3");
        Panel tpnlLRPAmixta = (Panel)Tabs.FindControl("pnlLRPAmixta");

        CheckBox tchk001LRPA = (CheckBox)Tabs.FindControl("chk001LRPA");
        CheckBox tChk002LRPAMixta = (CheckBox)Tabs.FindControl("Chk002LRPAMixta");

        Label tlbl_avisoLRPA = (Label)Tabs.FindControl("lbl_avisoLRPA");
        Label tlbl_aviso_graba = (Label)Tabs.FindControl("lbl_aviso_graba");

        Button tbtn_GuardarLRPA = (Button)Tabs.FindControl("btn_GuardarLRPA");
        Button tbtnAgregarTsancionLRPA = (Button)Tabs.FindControl("btnAgregarTsancionLRPA");
      
        GridView tgrd001LRPA = (GridView)Tabs.FindControl("grd001LRPA");
        GridView tgrdseleccionLRPA = (GridView)Tabs.FindControl("grdseleccionLRPA");

        if (e.CommandName == "ver")
        {
            tlbl_aviso_graba.Visible = false;
            tbtn_GuardarLRPA.Text = "Modificar";
            DTTipoSancionAccesoria.Clear();
            string Cod = tgrdseleccionLRPA.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
            VICodMedidaSancion = Convert.ToInt32(Cod);
            LRPAcoll lrpa = new LRPAcoll();
            DataTable dtLRPA = lrpa.callto_get_sancionesbycodigo(Convert.ToInt32(Cod));
            if (dtLRPA.Rows.Count > 0)
            {
                tddown_otm.SelectedValue = dtLRPA.Rows[0][17].ToString();

                ttxt001LRPA.Text = dtLRPA.Rows[0][1].ToString();
                ttxt002LRPA.Text = dtLRPA.Rows[0][0].ToString();
                ttxt007LRPA.Text = dtLRPA.Rows[0][18].ToString();
                tddown001LRPA.Text = Convert.ToDateTime(dtLRPA.Rows[0][2].ToString()).ToShortDateString();
                ttxt003LRPA.Text = Convert.ToDateTime(dtLRPA.Rows[0][3]).ToShortDateString();
                ttxt003LRPA.Enabled = false;
                tddown003LRPA.SelectedValue = dtLRPA.Rows[0][4].ToString();
                tddown004LRPA.SelectedValue = dtLRPA.Rows[0][5].ToString();
                ttxt0010LRPA.Text = dtLRPA.Rows[0][22].ToString();
                parcoll pcoll = new parcoll();

                DataView dv2 = new DataView(pcoll.GetparTribunales(dtLRPA.Rows[0][4].ToString(), dtLRPA.Rows[0][5].ToString()));
                tddown005LRPA.Items.Clear();
                tddown005LRPA.DataSource = dv2;
                tddown005LRPA.DataTextField = "Descripcion";
                tddown005LRPA.DataValueField = "CodTribunal";
                dv2.Sort = "Descripcion";
                tddown005LRPA.DataBind();
                tddown005LRPA.Focus();

                tddown005LRPA.SelectedValue = dtLRPA.Rows[0][6].ToString();
                if (dtLRPA.Rows[0][7].ToString() == "1")
                {
                    tchk001LRPA.Checked = true;
                    tgrd001LRPA.Visible = true;
                    tbtnAgregarTsancionLRPA.Visible = true;
                }
                else
                {
                    tchk001LRPA.Checked = false;
                }

                SancionACC();

                tddown006LRPA.SelectedValue = dtLRPA.Rows[0][7].ToString();
                if (Convert.ToDateTime(dtLRPA.Rows[0][16].ToString()) != Convert.ToDateTime("01-01-1900"))
                {
                    tddown007LRPA.Text = Convert.ToDateTime(dtLRPA.Rows[0][16].ToString()).ToString();
                }

                tddown008LRPA.SelectedValue = dtLRPA.Rows[0][10].ToString();
                ttxt009LRPA.Text = dtLRPA.Rows[0][21].ToString();
                if (Convert.ToDateTime(dtLRPA.Rows[0][14]).ToShortDateString() != "01-01-1900" &&
                     Convert.ToDateTime(dtLRPA.Rows[0][15]).ToShortDateString() != "01-01-1900")
                {
                    tpnlLRPAmixta.Visible = true;
                    tChk002LRPAMixta.Checked = true;
                    ttxt006LRPA.Enabled = false;
                    tddown009LRPA.Text = Convert.ToDateTime(dtLRPA.Rows[0][15]).ToString();
                    ttxt005LRPA.Text = dtLRPA.Rows[0][13].ToString();
                    ttxt004LRPA.Text = dtLRPA.Rows[0][12].ToString();
                    ttxt008LRPA.Text = dtLRPA.Rows[0][19].ToString();
                    tddown011LRPA.SelectedValue = dtLRPA.Rows[0][20].ToString();
                    ttxt006LRPA.Text = Convert.ToDateTime(dtLRPA.Rows[0][14]).ToShortDateString();

                }


                #region GRILLA

                DataRow dr;//= DTTipoSancionAccesoria.NewRow();

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

                if (DTTipoSancionAccesoria.Rows.Count > 0)
                {
                    DataView dv = new DataView(DTTipoSancionAccesoria);
                    tgrd001LRPA.DataSource = dv;
                    dv.Sort = "CodSancion";
                    tgrd001LRPA.DataBind();
                    tgrd001LRPA.Focus();
                    tgrd001LRPA.Visible = true;
                }

                tddown006LRPA.SelectedValue = Convert.ToString(0);
                tddown006LRPA.BackColor = System.Drawing.Color.White;

                tPanel3.Visible = false;
                tpnldatos.Visible = true;

            }
            if (DTSancionV2.Rows.Count > 0)
            {
               // tgrdseleccionLRPA.DeleteRow(Convert.ToInt32(e.CommandArgument.ToString()));
                DTSancionV2.Rows.Remove(DTSancionV2.Rows[Convert.ToInt32(e.CommandArgument)]);
                DataView dv = new DataView(DTSancionV2);
                tgrdseleccionLRPA.DataSource = dv;
                tgrdseleccionLRPA.DataBind();
                tgrdseleccionLRPA.Visible = true;

            }


                #endregion
            

        }
        //tgrdseleccionLRPA.DeleteRow(Convert.ToInt32(e.CommandArgument));
    }
    //protected void btnnextcoor(object sender, EventArgs e)
    //{

    //     //DropDownList tddown001LRPA = (DropDownList)Tabs.FindControl("ddown001LRPA");
    //    DropDownList tddown003LRPA = (DropDownList)Tabs.FindControl("ddown003LRPA");
    //    DropDownList tddown004LRPA = (DropDownList)Tabs.FindControl("ddown004LRPA");
    //    DropDownList tddown005LRPA = (DropDownList)Tabs.FindControl("ddown005LRPA");
    //    DropDownList tddown006LRPA = (DropDownList)Tabs.FindControl("ddown006LRPA");
    //    //DropDownList tddown007LRPA = (DropDownList)Tabs.FindControl("ddown007LRPA");
    //    DropDownList tddown008LRPA = (DropDownList)Tabs.FindControl("ddown008LRPA");
    //    //DropDownList tddown009LRPA = (DropDownList)Tabs.FindControl("ddown009LRPA");
    //    DropDownList tddown011LRPA = (DropDownList)Tabs.FindControl("ddown011LRPA");
    //    DropDownList tddown_otm = (DropDownList)Tabs.FindControl("ddown_otm");

    //    WebDateChooser tddown009LRPA = (TextBox)Tabs.FindControl("ddown009LRPA");
    //    WebDateChooser tddown001LRPA = (TextBox)Tabs.FindControl("ddown001LRPA");
    //    WebDateChooser tddown007LRPA = (TextBox)Tabs.FindControl("ddown007LRPA");

    //    WebNumericEdit ttxt001LRPA = (WebNumericEdit)Tabs.FindControl("txt001LRPA");
    //    WebNumericEdit ttxt002LRPA = (WebNumericEdit)Tabs.FindControl("txt002LRPA");
    //    TextBox ttxt003LRPA = (TextBox)Tabs.FindControl("txt003LRPA");
    //    WebNumericEdit ttxt004LRPA = (WebNumericEdit)Tabs.FindControl("txt004LRPA");
    //    WebNumericEdit ttxt005LRPA = (WebNumericEdit)Tabs.FindControl("txt005LRPA");
    //    TextBox ttxt006LRPA = (TextBox)Tabs.FindControl("txt006LRPA");
    //    WebNumericEdit ttxt007LRPA = (WebNumericEdit)Tabs.FindControl("txt007LRPA");
    //    WebNumericEdit ttxt008LRPA = (WebNumericEdit)Tabs.FindControl("txt008LRPA");
    //    WebNumericEdit ttxt009LRPA = (WebNumericEdit)Tabs.FindControl("txt009LRPA");
    //    WebNumericEdit ttxt0010LRPA = (WebNumericEdit)Tabs.FindControl("txt0010LRPA");

    //    Panel tpnldatos = (Panel)Tabs.FindControl("pnldatos");
    //    Panel tPanel3 = (Panel)Tabs.FindControl("Panel3");
    //    Panel tpnlLRPAmixta = (Panel)Tabs.FindControl("pnlLRPAmixta");

    //    CheckBox tchk001LRPA = (CheckBox)Tabs.FindControl("chk001LRPA");
    //    CheckBox tChk002LRPAMixta = (CheckBox)Tabs.FindControl("Chk002LRPAMixta");

    //    Label tlbl_avisoLRPA = (Label)Tabs.FindControl("lbl_avisoLRPA");
    //    Label tlbl_aviso_graba = (Label)Tabs.FindControl("lbl_aviso_graba");

        
        
    //    GridView tgrd001LRPA = (GridView)Tabs.FindControl("grd001LRPA");
    //    GridView tgrdseleccionLRPA = (GridView)Tabs.FindControl("grdseleccionLRPA");
        
        
    //    DataRow dr = DTSancionV2.NewRow();
    //    dr[0] = 1;
    //    dr[1] = Convert.ToDateTime(tddown001LRPA.Text);
    //    if (ttxt003LRPA.Text.Trim() == "")
    //    {
    //        dr[2] = "01-01-1900";
    //    }
    //    else
    //    {
    //        dr[2] = Convert.ToDateTime(ttxt003LRPA.Text);
    //    }
    //    dr[3] = Convert.ToInt32(ttxt001LRPA.Text);
    //    dr[4] = Convert.ToInt32(ttxt002LRPA.Text);
    //    dr[5] = Convert.ToInt32(ttxt007LRPA.Text);
    //    dr[6] = Convert.ToInt32(tddown005LRPA.SelectedValue);
    //    if(tchk001LRPA.Checked)
    //    {
    //    dr[7] = Convert.ToInt32(tddown006LRPA.SelectedValue);
    //    }
    //    else
    //    {
    //    dr[7]= 0;
    //    }
    //    dr[8] = Convert.ToInt32(ttxt009LRPA.Text);
    //    dr[9] = Convert.ToInt32(ttxt0010LRPA.Text);
    //    if (tddown009LRPA.Text == "Seleccione Fecha")
    //    {
    //        dr[10] = "01-01-1900";
    //    }
    //    else 
    //    {
    //        dr[10] = Convert.ToDateTime(tddown009LRPA.Text);
    //    }

    //    if (ttxt006LRPA.Text.Trim() == "")
    //    {
    //        dr[11] = "01-01-1900";
    //    }
    //    else 
    //    {
    //        dr[11] = Convert.ToDateTime(ttxt006LRPA.Text);
    //    }


    //    if (ttxt005LRPA.Text == "")
    //    { dr[12] = 0; }
    //    else
    //    { dr[12] = Convert.ToInt32(ttxt005LRPA.Text); }


    //    if (ttxt004LRPA.Text == "")
    //    { dr[13] = 0; }
    //    else
    //    { dr[13] = Convert.ToInt32(ttxt004LRPA.Text); }


    //    if (ttxt008LRPA.Text == "")
    //    { dr[14] = 0; }
    //    else
    //    { dr[14] = Convert.ToInt32(ttxt008LRPA.Text); }
       
    //    dr[15] = Convert.ToInt32(tddown008LRPA.SelectedValue);;
        
        
        
    //    dr[16] = Convert.ToDateTime("01-01-1900");//Convert.ToDateTime(tddown007LRPA.Text);
    //    dr[17] = Convert.ToInt32(tddown011LRPA.SelectedValue);
    //    dr[18] = Convert.ToInt32(Session["IdUsuario"]);
    //    dr[19] = DateTime.Now;
        
    //    DTSancionV2.Rows.Add(dr);

    //    bool SW = validasancion();

    //    if (SW == false)
    //    {
    //        DataView dv = new DataView(DTSancionV2);
    //        tgrdseleccionLRPA.DataSource = dv;
    //        // dv.Sort = "ICodOrdenTribunal";
    //        tgrdseleccionLRPA.DataBind();
    //        tPanel3.Visible = true;
    //        tgrdseleccionLRPA.Visible = true;
    //        tgrdseleccionLRPA.Focus();
    //    }
    //}
    private bool validasancion()
    {
        DropDownList tddown003LRPA = (DropDownList)Tabs.FindControl("ddown003LRPA");
        DropDownList tddown004LRPA = (DropDownList)Tabs.FindControl("ddown004LRPA");
        DropDownList tddown005LRPA = (DropDownList)Tabs.FindControl("ddown005LRPA");
        DropDownList tddown006LRPA = (DropDownList)Tabs.FindControl("ddown006LRPA");
        //DropDownList tddown007LRPA = (DropDownList)Tabs.FindControl("ddown007LRPA");
        DropDownList tddown008LRPA = (DropDownList)Tabs.FindControl("ddown008LRPA");
        //DropDownList tddown009LRPA = (DropDownList)Tabs.FindControl("ddown009LRPA");
        DropDownList tddown011LRPA = (DropDownList)Tabs.FindControl("ddown011LRPA");
        DropDownList tddown_otm = (DropDownList)Tabs.FindControl("ddown_otm");

        TextBox tddown009LRPA = (TextBox)Tabs.FindControl("ddown009LRPA");
        TextBox tddown001LRPA = (TextBox)Tabs.FindControl("ddown001LRPA");
        TextBox tddown007LRPA = (TextBox)Tabs.FindControl("ddown007LRPA");

        TextBox ttxt001LRPA = (TextBox)Tabs.FindControl("txt001LRPA");
        TextBox ttxt002LRPA = (TextBox)Tabs.FindControl("txt002LRPA");
        TextBox ttxt003LRPA = (TextBox)Tabs.FindControl("txt003LRPA");
        TextBox ttxt004LRPA = (TextBox)Tabs.FindControl("txt004LRPA");
        TextBox ttxt005LRPA = (TextBox)Tabs.FindControl("txt005LRPA");
        TextBox ttxt006LRPA = (TextBox)Tabs.FindControl("txt006LRPA");
        TextBox ttxt007LRPA = (TextBox)Tabs.FindControl("txt007LRPA");
        TextBox ttxt008LRPA = (TextBox)Tabs.FindControl("txt008LRPA");
        TextBox ttxt009LRPA = (TextBox)Tabs.FindControl("txt009LRPA");
        TextBox ttxt0010LRPA = (TextBox)Tabs.FindControl("txt0010LRPA");

        Panel tpnldatos = (Panel)Tabs.FindControl("pnldatos");
        Panel tPanel3 = (Panel)Tabs.FindControl("Panel3");
        Panel tpnlLRPAmixta = (Panel)Tabs.FindControl("pnlLRPAmixta");

        CheckBox tchk001LRPA = (CheckBox)Tabs.FindControl("chk001LRPA");
        CheckBox tChk002LRPAMixta = (CheckBox)Tabs.FindControl("Chk002LRPAMixta");
        
        Label tlbl_avisoDuracionLRPA = (Label)Tabs.FindControl("lbl_avisoDuracionLRPA");
        Label tlbl_avisoDuracion2LRPA = (Label)Tabs.FindControl("lbl_avisoDuracion2LRPA");
        Label tlbl_avisoLRPA = (Label)Tabs.FindControl("lbl_avisoLRPA");
        Label tlbl_aviso_graba = (Label)Tabs.FindControl("lbl_aviso_graba");

      
        GridView tgrd001LRPA = (GridView)Tabs.FindControl("grd001LRPA");
        GridView tgrdseleccionLRPA = (GridView)Tabs.FindControl("grdseleccionLRPA");


        bool sw = false;
        if (tddown_otm.SelectedValue == "0")
        {
            tddown_otm.BackColor = System.Drawing.Color.Pink;
            sw = true;
        }
        else 
        {
            tddown_otm.BackColor = System.Drawing.Color.White;
            
        }

        if (tddown001LRPA.Text.ToUpper() == "SELECCIONE FECHA")
        {
            tddown001LRPA.BackColor = System.Drawing.Color.Pink;
            sw = true;
        }
        else
        {
            tddown001LRPA.BackColor = System.Drawing.Color.White;
            
        }

        //if (CodProy == "103")
        //{
            //if (ttxt0010LRPA.Text == "0")
            //{
            //    tlbl_avisoDuracionLRPA.Visible = true;
            //    tlbl_avisoDuracionLRPA.Text = "Debe ingresar Horas ó Años ó Mes ó Días";
            //    ttxt0010LRPA.BackColor = System.Drawing.Color.Pink;
            //    sw = true;
            //}
            //else
            //{
            //    tlbl_avisoDuracionLRPA.Visible = false;
            //    ttxt0010LRPA.BackColor = System.Drawing.Color.Pink;
            //}


            //if (ttxt001LRPA.Text == "0" && ttxt002LRPA.Text == "0" && ttxt007LRPA.Text == "0" && ttxt009LRPA.Text == "0")
            //{
            //    ttxt001LRPA.BackColor = System.Drawing.Color.Pink;
            //    ttxt002LRPA.BackColor = System.Drawing.Color.Pink;
            //    ttxt007LRPA.BackColor = System.Drawing.Color.Pink;
            //    ttxt009LRPA.BackColor = System.Drawing.Color.Pink;
            //    tlbl_avisoDuracionLRPA.Text = "Debe ingresar Horas ó Años ó Mes ó Días";
            //    tlbl_avisoDuracionLRPA.Visible = true;
            //    sw = true;
            //}
            //else
            //{
            //    ttxt001LRPA.BackColor = System.Drawing.Color.White;
            //    ttxt002LRPA.BackColor = System.Drawing.Color.White;
            //    ttxt007LRPA.BackColor = System.Drawing.Color.White;
            //    ttxt009LRPA.BackColor = System.Drawing.Color.White;
            //    tlbl_avisoDuracionLRPA.Text = "";
            //    tlbl_avisoDuracionLRPA.Visible = false;
            //}
            ////}
            ////else
            ////{
            if (ttxt001LRPA.Text == "" && ttxt002LRPA.Text == "" && ttxt007LRPA.Text == "" && ttxt009LRPA.Text == "0")
            {
                //ttxt0010LRPA.BackColor = System.Drawing.Color.Pink;
                ttxt001LRPA.BackColor = System.Drawing.Color.Pink;
                ttxt002LRPA.BackColor = System.Drawing.Color.Pink;
                ttxt007LRPA.BackColor = System.Drawing.Color.Pink;
                ttxt009LRPA.BackColor = System.Drawing.Color.Pink;
//                tlbl_avisoDuracionLRPA.Text = "Debe ingresar Horas ó Años ó Mes ó Días";
                //tlbl_avisoDuracionLRPA.Visible = true;
                sw = true;
            }
            else
            {
                //ttxt0010LRPA.BackColor = System.Drawing.Color.White;
                ttxt001LRPA.BackColor = System.Drawing.Color.White;
                ttxt002LRPA.BackColor = System.Drawing.Color.White;
                ttxt007LRPA.BackColor = System.Drawing.Color.White;
                ttxt009LRPA.BackColor = System.Drawing.Color.White;
                tlbl_avisoDuracionLRPA.Text = "";
                tlbl_avisoDuracionLRPA.Visible = false;
            }
            if (tddown003LRPA.SelectedValue == "0")
            {
                tddown003LRPA.BackColor = System.Drawing.Color.Pink;
                sw = true;
            }
            else
            {
                tddown003LRPA.BackColor = System.Drawing.Color.White;
            }

            if (tddown004LRPA.SelectedValue == "0")
            {
                tddown004LRPA.BackColor = System.Drawing.Color.Pink;
                sw = true;
            }
            else
            {
                tddown004LRPA.BackColor = System.Drawing.Color.White;
            }

        //////// termino sancion///////
            //if (tddown008LRPA.SelectedValue == "0")
            //{
            //    tddown008LRPA.BackColor = System.Drawing.Color.Pink;
            //    sw = true;
            //}
            //else
            //{
            //    tddown008LRPA.BackColor = System.Drawing.Color.White;
            //}
            //if (tddown007LRPA.Text.ToUpper() == "SELECCIONE FECHA")
            //{
            //    tddown007LRPA.BackColor = System.Drawing.Color.Pink;
            //    sw = true;
            //}
            //else
            //{
            //    tddown007LRPA.BackColor = System.Drawing.Color.White;
            //}
        //////////FIN TERMINO SANCION////////



            if (tddown005LRPA.SelectedValue == "0")
            {
                tddown005LRPA.BackColor = System.Drawing.Color.Pink;
                sw = true;
            }
            else
            {
                tddown005LRPA.BackColor = System.Drawing.Color.White;
            }
        //}
        if (tChk002LRPAMixta.Checked)
        {
            if (ttxt005LRPA.Text == "0" && ttxt004LRPA.Text == "0" && ttxt008LRPA.Text == "0")
            {
                ttxt005LRPA.BackColor = System.Drawing.Color.Pink;
                ttxt004LRPA.BackColor = System.Drawing.Color.Pink;
                ttxt008LRPA.BackColor = System.Drawing.Color.Pink;
                sw = true;
                tlbl_avisoDuracion2LRPA.Text = "Debe ingresar Años ó Mes ó Días";
                tlbl_avisoDuracion2LRPA.Visible = true;
            }
            else
            {
                ttxt005LRPA.BackColor = System.Drawing.Color.White;
                ttxt004LRPA.BackColor = System.Drawing.Color.White;
                ttxt008LRPA.BackColor = System.Drawing.Color.White;
                tlbl_avisoDuracion2LRPA.Text = "";
                tlbl_avisoDuracion2LRPA.Visible = false;
            }

            if (tddown011LRPA.SelectedValue == "0")
            {
                tddown011LRPA.BackColor = System.Drawing.Color.Pink;
                sw = true;
            }
            else
            {
                tddown011LRPA.BackColor = System.Drawing.Color.White;
            }

            //if (tddown003LRPA.SelectedValue == "0")
            //{
            //    tddown003LRPA.BackColor = System.Drawing.Color.Pink;
            //    sw = true;
            //}
            //else
            //{
            //    tddown003LRPA.BackColor = System.Drawing.Color.White;
            //}

            //if (tddown004LRPA.SelectedValue == "0")
            //{
            //    tddown004LRPA.BackColor = System.Drawing.Color.Pink;
            //    sw = true;
            //}
            //else
            //{
            //    tddown004LRPA.BackColor = System.Drawing.Color.White;
            //}


            //if (tddown005LRPA.SelectedValue == "0")
            //{
            //    tddown005LRPA.BackColor = System.Drawing.Color.Pink;
            //    sw = true;
            //}
            //else
            //{
            //    tddown005LRPA.BackColor = System.Drawing.Color.White;
            //}
        }
        if(tchk001LRPA.Checked)
        {

            if (tgrd001LRPA.Rows.Count > 0)
            {
                tddown006LRPA.BackColor = System.Drawing.Color.White;
                tlbl_avisoLRPA.Text = "";
                tlbl_avisoLRPA.Visible = false;
            }
            else
            {
                tlbl_avisoLRPA.Text = "Debe ingresar un tipo de sanción accesoria";
                tlbl_avisoLRPA.Visible = true;
                tddown006LRPA.BackColor = System.Drawing.Color.Pink;
                sw = true;
            }
            //if(tgrd001LRPA.Rows.Count > 0)
            //{
            //    tlbl_avisoLRPA.Text = "";
            //    tlbl_avisoLRPA.Visible = false;
            //}
            //else
            //{
            //    tlbl_avisoLRPA.Text = "Debe ingresar un tipo de sanción accesoria";
            //    tlbl_avisoLRPA.Visible = true;
            //}
        }
        return sw;

    }
 
    protected void btnnextcoor(object sender, EventArgs e)
    {
        bool nuevo = false;
        bool mixta = false;
        //DropDownList tddown001LRPA = (DropDownList)Tabs.FindControl("ddown001LRPA");
        DropDownList tddown003LRPA = (DropDownList)Tabs.FindControl("ddown003LRPA");
        DropDownList tddown004LRPA = (DropDownList)Tabs.FindControl("ddown004LRPA");
        DropDownList tddown005LRPA = (DropDownList)Tabs.FindControl("ddown005LRPA");
        DropDownList tddown006LRPA = (DropDownList)Tabs.FindControl("ddown006LRPA");
        //DropDownList tddown007LRPA = (DropDownList)Tabs.FindControl("ddown007LRPA");
        DropDownList tddown008LRPA = (DropDownList)Tabs.FindControl("ddown008LRPA");
        //DropDownList tddown009LRPA = (DropDownList)Tabs.FindControl("ddown009LRPA");
        DropDownList tddown011LRPA = (DropDownList)Tabs.FindControl("ddown011LRPA");
        DropDownList tddown_otm = (DropDownList)Tabs.FindControl("ddown_otm");

        TextBox tddown009LRPA = (TextBox)Tabs.FindControl("ddown009LRPA");
        TextBox tddown001LRPA = (TextBox)Tabs.FindControl("ddown001LRPA");
        TextBox tddown007LRPA = (TextBox)Tabs.FindControl("ddown007LRPA");

        TextBox ttxt001LRPA = (TextBox)Tabs.FindControl("txt001LRPA");
        TextBox ttxt002LRPA = (TextBox)Tabs.FindControl("txt002LRPA");
        TextBox ttxt003LRPA = (TextBox)Tabs.FindControl("txt003LRPA");
        TextBox ttxt004LRPA = (TextBox)Tabs.FindControl("txt004LRPA");
        TextBox ttxt005LRPA = (TextBox)Tabs.FindControl("txt005LRPA");
        TextBox ttxt006LRPA = (TextBox)Tabs.FindControl("txt006LRPA");
        TextBox ttxt007LRPA = (TextBox)Tabs.FindControl("txt007LRPA");
        TextBox ttxt008LRPA = (TextBox)Tabs.FindControl("txt008LRPA");
        TextBox ttxt009LRPA = (TextBox)Tabs.FindControl("txt009LRPA");
        TextBox ttxt0010LRPA = (TextBox)Tabs.FindControl("txt0010LRPA");

        Panel tpnldatos = (Panel)Tabs.FindControl("pnldatos");
        Panel tPanel3 = (Panel)Tabs.FindControl("Panel3");
        Panel tpnlLRPAmixta = (Panel)Tabs.FindControl("pnlLRPAmixta");

        CheckBox tchk001LRPA = (CheckBox)Tabs.FindControl("chk001LRPA");
        CheckBox tChk002LRPAMixta = (CheckBox)Tabs.FindControl("Chk002LRPAMixta");

        Label tlbl_avisoLRPA = (Label)Tabs.FindControl("lbl_avisoLRPA");
        Label tlbl_aviso_graba = (Label)Tabs.FindControl("lbl_aviso_graba");

        
        GridView tgrd001LRPA = (GridView)Tabs.FindControl("grd001LRPA");
        GridView tgrdseleccionLRPA = (GridView)Tabs.FindControl("grdseleccionLRPA");





        coordinador ccoll = new coordinador();
        List<DbParameter> listDbParameter = new List<DbParameter>();

        string sqlIntervencion = "select  T2.CodModeloIntervencion, T2.LRPA from proyectos T1 INNER JOIN parmodelointervencion T2 " +
                                 "ON T1.CodModeloIntervencion = T2.codmodeloIntervencion where CodProyecto =@pCodProyecto ";

        listDbParameter.Add(Conexiones.CrearParametro("@pCodProyecto", SqlDbType.Int, 4, VProy));

        DataTable dt = new DataTable();
        dt = ccoll.ejecuta_SQL(sqlIntervencion, listDbParameter);

        if (dt.Rows[0][0].ToString() == "103" && dt.Rows[0][1].ToString() == "1")
        {

            bool sw = true;
            //DTSancionV2 = new DataTable();
            //DTSancionV2.Columns.Add(new DataColumn("ICodOrdenTribunal", typeof(int)));          //1
            //DTSancionV2.Columns.Add(new DataColumn("FechaInicio", typeof(DateTime)));           //2
            //DTSancionV2.Columns.Add(new DataColumn("FechaTermino", typeof(DateTime)));          //3
            //DTSancionV2.Columns.Add(new DataColumn("DuracionAno", typeof(int)));                //4
            //DTSancionV2.Columns.Add(new DataColumn("DuracionMes", typeof(int)));                //5
            //DTSancionV2.Columns.Add(new DataColumn("DuracionDia", typeof(int)));                //6
            //DTSancionV2.Columns.Add(new DataColumn("CodTribunal", typeof(int)));                //7
            //DTSancionV2.Columns.Add(new DataColumn("SancionAccesoria", typeof(int)));           //8
            //DTSancionV2.Columns.Add(new DataColumn("Abono", typeof(int)));                      //9
            //DTSancionV2.Columns.Add(new DataColumn("Horas", typeof(int)));                      //10
            //DTSancionV2.Columns.Add(new DataColumn("FechaInicioMixta", typeof(DateTime)));      //11
            //DTSancionV2.Columns.Add(new DataColumn("FechaTerminoMixta", typeof(DateTime)));     //12
            //DTSancionV2.Columns.Add(new DataColumn("DuracionAnoMixta", typeof(int)));           //13
            //DTSancionV2.Columns.Add(new DataColumn("DuracionMesMixta", typeof(int)));           //14
            //DTSancionV2.Columns.Add(new DataColumn("DuracionDiaMixta", typeof(int)));           //15
            //DTSancionV2.Columns.Add(new DataColumn("CodTerminoSancion", typeof(int)));          //18
            //DTSancionV2.Columns.Add(new DataColumn("FechaTerminoSancion", typeof(DateTime)));   //17
            //DTSancionV2.Columns.Add(new DataColumn("CodModeloSancionMixta", typeof(int)));      //19
            //DTSancionV2.Columns.Add(new DataColumn("IdUsuarioActualizacion", typeof(int)));     //20
            //DTSancionV2.Columns.Add(new DataColumn("FechaActualizacion", typeof(DateTime)));    //21

            DataRow dr = DTSancionV2.NewRow();
            dr[0] = 1;

            bool SW2 = true;

            if (tddown001LRPA.Text == "Seleccione Fecha")
            {
                sw = false;
                ttxt001LRPA.BackColor = System.Drawing.Color.Pink;
            }
            else
            {
                dr[1] = Convert.ToDateTime(tddown001LRPA.Text);
                ttxt001LRPA.BackColor = System.Drawing.Color.White;
                SW2 = false;

            }
            if (ttxt003LRPA.Text.Trim() == "")
            {
                dr[2] = "01-01-1900";
            }
            else
            {
                dr[2] = Convert.ToDateTime(ttxt003LRPA.Text);
            }

            if (ttxt0010LRPA.Text == "")
            {
                dr[3] = 0;
            }
            else
            {
                dr[3] = Convert.ToInt32(ttxt0010LRPA.Text);
                SW2 = false;
            }
            if (ttxt002LRPA.Text == "")
            {
                dr[4] = 0;
            }
            else
            {
                dr[4] = Convert.ToInt32(ttxt002LRPA.Text);
            }
            if (ttxt007LRPA.Text == "")
            {
                dr[5] = 0;
            }
            else
            {
                dr[5] = Convert.ToInt32(ttxt007LRPA.Text);
            }
            dr[6] = Convert.ToInt32(tddown005LRPA.SelectedValue);
            if (tchk001LRPA.Checked)
            {
                dr[7] = Convert.ToInt32(tddown006LRPA.SelectedValue);
            }
            else
            {
                dr[7] = 0;
            }

            if (ttxt009LRPA.Text == "")
            {
                dr[8] = 0;
            }
            else
            {
                dr[8] = Convert.ToInt32(ttxt009LRPA.Text);
            }
            if (ttxt0010LRPA.Text != "")
            {
                dr[9] = Convert.ToInt32(ttxt0010LRPA.Text);
                ttxt001LRPA.BackColor = System.Drawing.Color.White;
            }
            else
            {
                sw = false;
                ttxt0010LRPA.BackColor = System.Drawing.Color.Pink;

            }
            if (tddown009LRPA.Text == "Seleccione Fecha")
            {
                dr[10] = "01-01-1900";
            }
            else
            {
                dr[10] = Convert.ToDateTime(tddown009LRPA.Text);
            }

            if (ttxt006LRPA.Text.Trim() == "")
            {
                dr[11] = "01-01-1900";
            }
            else
            {
                dr[11] = Convert.ToDateTime(ttxt006LRPA.Text);
            }


            if (ttxt005LRPA.Text == "")
            { dr[12] = 0; }
            else
            { dr[12] = Convert.ToInt32(ttxt005LRPA.Text); }


            if (ttxt004LRPA.Text == "")
            { dr[13] = 0; }
            else
            { dr[13] = Convert.ToInt32(ttxt004LRPA.Text); }


            if (ttxt008LRPA.Text == "")
            { dr[14] = 0; }
            else
            { dr[14] = Convert.ToInt32(ttxt008LRPA.Text); }

            if (tddown008LRPA.SelectedValue == "0")
            {
                dr[15] = "";
            }
            else
            {
                dr[15] = Convert.ToInt32(tddown008LRPA.SelectedValue); ;
            }


            dr[16] = Convert.ToDateTime("01-01-1900");//Convert.ToDateTime(tddown007LRPA.Text);
            if (tddown011LRPA.SelectedValue == "0")
            {
                dr[17] = 0;
            }
            else
            {
                dr[17] = Convert.ToInt32(tddown011LRPA.SelectedValue);
            }
            dr[18] = Convert.ToInt32(Session["IdUsuario"]);
            dr[19] = DateTime.Now;

            DTSancionV2.Rows.Add(dr);

            bool SW = validasancion();

            if (SW2 == false)
            {
                DataView dv = new DataView(DTSancionV2);
                tgrdseleccionLRPA.DataSource = dv;
                // dv.Sort = "ICodOrdenTribunal";
                tgrdseleccionLRPA.DataBind();
                tPanel3.Visible = true;
                tgrdseleccionLRPA.Visible = true;
                tgrdseleccionLRPA.Focus();

            }




            if (SW == true)
            {
                DataView dv = new DataView(DTSancionV2);
                tgrdseleccionLRPA.DataSource = dv;
                // dv.Sort = "ICodOrdenTribunal";
                tgrdseleccionLRPA.DataBind();
                tPanel3.Visible = true;
                tgrdseleccionLRPA.Visible = true;
                tgrdseleccionLRPA.Focus();
            }


        }
        else
        {
            if (validasancion() == false)
            {


                DataRow dr = DTSancionV2.NewRow();
                dr[0] = 1;
                dr[1] = Convert.ToDateTime(tddown001LRPA.Text);
                dr[2] = Convert.ToDateTime(ttxt003LRPA.Text);

                dr[3] = Convert.ToInt32(ttxt001LRPA.Text);
                dr[4] = Convert.ToInt32(ttxt002LRPA.Text);
                dr[5] = Convert.ToInt32(ttxt007LRPA.Text);
                dr[6] = Convert.ToInt32(tddown005LRPA.SelectedValue);

                if (tchk001LRPA.Checked)
                {
                    dr[7] = Convert.ToInt32(tddown006LRPA.SelectedValue);
                }
                else
                {
                    dr[7] = 0;
                }
                dr[8] = Convert.ToInt32(ttxt009LRPA.Text);
                dr[9] = Convert.ToInt32(ttxt0010LRPA.Text);

                /////////mixta/////////
                if (tddown009LRPA.Text == "Seleccione Fecha")
                {
                    dr[10] = "01-01-1900";
                }
                else
                {
                    dr[10] = Convert.ToDateTime(tddown009LRPA.Text);
                }

                if (ttxt006LRPA.Text.Trim() == "")
                {
                    dr[11] = "01-01-1900";
                }
                else
                {
                    dr[11] = Convert.ToDateTime(ttxt006LRPA.Text);
                }


                if (ttxt005LRPA.Text == "")
                { dr[12] = 0; }
                else
                { dr[12] = Convert.ToInt32(ttxt005LRPA.Text); }


                if (ttxt004LRPA.Text == "")
                { dr[13] = 0; }
                else
                { dr[13] = Convert.ToInt32(ttxt004LRPA.Text); }


                if (ttxt008LRPA.Text == "")
                { dr[14] = 0; }
                else
                { dr[14] = Convert.ToInt32(ttxt008LRPA.Text); }
                ///////fin mixta///////
                dr[15] = Convert.ToInt32(tddown008LRPA.SelectedValue);
                dr[16] = Convert.ToDateTime("01-01-1900");//Convert.ToDateTime(tddown007LRPA.Text);
                dr[17] = Convert.ToInt32(tddown011LRPA.SelectedValue);
                dr[18] = Convert.ToInt32(Session["IdUsuario"]);
                dr[19] = DateTime.Now;

                DTSancionV2.Rows.Add(dr);

                bool SW = validasancion();

                if (SW == false)
                {
                    /////////////
                    ////tddown008LRPA.Text = "Seleccionar";
                    //tddown001LRPA.Value = "Seleccione Fecha";
                    //ttxt001LRPA.Text = "";
                    //ttxt004LRPA.Text = "";
                    //ttxt0010LRPA.Text = "";
                    //ttxt002LRPA.Text = "";
                    //ttxt007LRPA.Text = "";
                    //ttxt009LRPA.Text = "";
                    //ttxt003LRPA.Text = "";
                    //tddown011LRPA.SelectedValue = "0";
                    //tddown_otm.SelectedValue = "0";

                    //tddown003LRPA.SelectedValue = "0";
                    //tddown004LRPA.SelectedValue = "0";
                    //tddown005LRPA.SelectedValue = "0";
                    //tddown006LRPA.SelectedValue = "0";
                    ////tddown009LRPA.Text = "Seleccionar";

                    DataView dv = new DataView(DTSancionV2);
                    tgrdseleccionLRPA.DataSource = dv;
                    // dv.Sort = "ICodOrdenTribunal";
                    tgrdseleccionLRPA.DataBind();
                    tPanel3.Visible = true;
                    tgrdseleccionLRPA.Visible = true;
                    tgrdseleccionLRPA.Focus();
                }
            


            //tddown_otm.SelectedValue = "0";
            //tddown011LRPA.SelectedValue = "0";
            //tddown003LRPA.SelectedValue = "-2";
            //tddown004LRPA.SelectedValue = "0";
            //tddown005LRPA.SelectedValue = "0";
            //tddown006LRPA.SelectedValue = "0";
            //tddown007LRPA.Value = "Seleccione Fecha";
            //tddown009LRPA.Value = "Seleccione Fecha";
            //tddown001LRPA.Value = "Seleccione Fecha";
            //tddown007LRPA.Value = "Seleccione Fecha";
            //ttxt0010LRPA.Text = "";
            //ttxt001LRPA.Text = "";
            //ttxt002LRPA.Text = "";
            //ttxt003LRPA.Text = "";
            //ttxt004LRPA.Text = "";
            //ttxt005LRPA.Text = "";
            //ttxt006LRPA.Text = "";
            //ttxt007LRPA.Text = ""; ttxt008LRPA.Text = "";
            //ttxt009LRPA.Text = "";
        }
        }

    }
    protected void ddown03_rt_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList tddown03_rt = (DropDownList)Tabs.FindControl("ddown03_rt");
        DropDownList tddown03_Proy = (DropDownList)Tabs.FindControl("ddown03_Proy");

        coordinador coord = new coordinador();

        
        DataTable dt = new DataTable();
        dt = coord.consulta_rol(Convert.ToInt32(Session["IdUsuario"]));
        int codrol = Convert.ToInt32(dt.Rows[0][1]);
        string Consulta;


        String RegionUsuario = "Select CodRegion From Usuarios Where IdUsuario =" + Convert.ToInt32(Session["IdUsuario"]);

        DataView dvUser = new DataView(coord.Get_RegionByUsers(RegionUsuario));

        if (codrol == 252 || codrol ==278 )
        
             Consulta = "SELECT t1.CodProyecto, ('(' + cast( t1.CodProyecto as varchar )+')'+ Nombre) AS Nombre " +
                            "FROM proyectos T1 " +
                            "INNER JOIN parResolucionTribunal_ModeloIntervencion T2 ON T1.CodModeloIntervencion = T2.CodModeloIntervencion " +
                            "WHERE T2.CodResolucionTribunal = " + Convert.ToInt32(tddown03_rt.SelectedValue) ;
        else 
             Consulta = "SELECT t1.CodProyecto, ('(' + cast( t1.CodProyecto as varchar )+')'+ Nombre) AS Nombre " +
                        "FROM proyectos T1 " +
                        "INNER JOIN parResolucionTribunal_ModeloIntervencion T2 ON T1.CodModeloIntervencion = T2.CodModeloIntervencion " +
                        "WHERE T2.CodResolucionTribunal = " + Convert.ToInt32(tddown03_rt.SelectedValue) + " AND T1.CodRegion =" + Convert.ToInt32(dvUser[0][0].ToString());
            
            
            
        DataView dvPr = new DataView(coord.Get_ProyectosLRPA(Consulta));

        tddown03_Proy.Items.Clear();
        tddown03_Proy.DataSource = dvPr;
        tddown03_Proy.DataTextField = "Nombre";
        tddown03_Proy.DataValueField = "CodProyecto";
        //dvPr.Sort = "Nombre";
        tddown03_Proy.DataBind();
    }
    protected void ddown03_Proy_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddown005LRPA_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btn_buscar_Click(object sender, EventArgs e)
    {
        Function_Consulta();
        lblSwich.Text = "B";
        grd003.Visible = false;
        grd004.Visible = false;
        lblbmsg.Visible = false;
    }
    protected void btn_modificar_Click(object sender, EventArgs e)
    {
        VIngreso_Mod = 1;
        Busca_ingresos();
        lblSwich.Text = "M";
        grd003.Visible = false;
        grd004.Visible = false;
        lblbmsg.Visible = false;
    }
    protected void btn_limpiar_Click(object sender, EventArgs e)
    {
        limpia_controles();
        lblbmsg.Visible = false;
    }
    protected void btn_volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("index_coordinadores.aspx");
    }

    protected void btnnext(object sender, EventArgs e)
    {
        validatedata(Tabs.ActiveTabIndex, false);
        Tabs.ActiveTabIndex += 1;
    }
    protected void btnback(object sender, EventArgs e)
    {
        Tabs.ActiveTabIndex -= 1;
        for (int i = 0; i < Tabs.Tabs.Count; i++)
        {
            if (i > Tabs.ActiveTabIndex)
            {
                Tabs.Tabs[i].Visible = false;
            }
        }
    }
    protected void btn_Acepta_Click(object sender, EventArgs e)
    {
        coordinador cr = new coordinador();

        //string sqlDelete = "DELETE FROM CoordinacionOrdenTribunal WHERE ICodOrdenTribunal =" + VICodOrdenTribunal; //lbl005.Text;
        //cr.ejecuta_SQL(sqlDelete);
        //sqlDelete = "DELETE FROM CoordinacionCausalIngreso WHERE ICodOrdenTribunal=" + VICodOrdenTribunal;//lbl005.Text;
        //cr.ejecuta_SQL(sqlDelete);
        //sqlDelete = "DELETE FROM CoordinacionSancion WHERE ICodOrdenTribunal =" + VICodOrdenTribunal;//lbl005.Text;
        //cr.ejecuta_SQL(sqlDelete);
        //sqlDelete = "DELETE FROM CoordinacionAudiencia WHERE ICodOrdenTribunal =" + VICodOrdenTribunal;//lbl005.Text;
        //cr.ejecuta_SQL(sqlDelete);
        //sqlDelete = "DELETE FROM CoordinacionIngreso WHERE ICodIE =" + VICodOrdenTribunal; //lbl005.Text;
        //cr.ejecuta_SQL(sqlDelete);


        pnl_coordinador.Visible = true;
        pnlAvisoElimina.Visible = false;

        Busca_ingresos();
        lblSwich.Text = "M";
        grd003.Visible = false;
        lblbmsg.Visible = false;
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        pnlAvisoElimina.Visible = false;
        pnl_coordinador.Visible = true;
    }
    protected void btnAgregarTsancionLRPA_Click(object sender, EventArgs e)
    {
        bool chk_rep = false;
        DTTipoSancionAccesoria.Clear();
        if (DTTipoSancionAccesoria.Columns.Count == Convert.ToInt32(4))
        {
            DTTipoSancionAccesoria.Columns.Remove(DTTipoSancionAccesoria.Columns[3]);
        }
        LinkButton tlnb001 = (LinkButton)Tabs.FindControl("lnb001");
        DropDownList tddown006LRPA = (DropDownList)Tabs.FindControl("ddown006LRPA");
        GridView tgrd001LRPA = (GridView)Tabs.FindControl("grd001LRPA");
        Label tlbl_avisoLRPA = (Label)Tabs.FindControl("lbl_avisoLRPA");


        if (tddown006LRPA.SelectedValue != Convert.ToString(0))
        {

            for (int i = 0; i < tgrd001LRPA.Rows.Count; i++)
            {
                DataRow dr = DTTipoSancionAccesoria.NewRow();
                dr[0] = Server.HtmlDecode(tgrd001LRPA.Rows[i].Cells[1].Text);
                dr[1] = Server.HtmlDecode(tgrd001LRPA.Rows[i].Cells[2].Text);
                dr[2] = Server.HtmlDecode(tgrd001LRPA.Rows[i].Cells[0].Text);
                DTTipoSancionAccesoria.Rows.Add(dr);

                if (tgrd001LRPA.Rows[i].Cells[0].Text == tddown006LRPA.SelectedValue)
                {
                    chk_rep = true;
                }
            }

            if (!chk_rep)
            {


                DataRow dr = DTTipoSancionAccesoria.NewRow();
                dr[0] = tddown006LRPA.SelectedItem;
                dr[1] = 3;
                dr[2] = Convert.ToInt32(tddown006LRPA.SelectedValue);

                // dr[3] = Convert.ToInt32(tddown006LRPA.SelectedValue);
                DTTipoSancionAccesoria.Rows.Add(dr);
                DataView dv = new DataView(DTTipoSancionAccesoria);
                tgrd001LRPA.DataSource = dv;
                dv.Sort = "CodSancion";
                tgrd001LRPA.DataBind();
                tgrd001LRPA.Visible = true;
                tgrd001LRPA.Focus();

                // tddown006LRPA.SelectedValue = Convert.ToString(0);
                tddown006LRPA.BackColor = System.Drawing.Color.White;
                tlbl_avisoLRPA.Visible = false;
            }
            else
            {
                tlbl_avisoLRPA.Text = "La sanción seleccionada ya ha sido ingresada";
                tlbl_avisoLRPA.Visible = true;
            }
        }
        else
        {
            tddown006LRPA.BackColor = System.Drawing.Color.Pink;
            tlbl_avisoLRPA.Text = "Debe ingresar una sanción";
            tlbl_avisoLRPA.Visible = true;

        }
        tlnb001.Focus();
        tddown006LRPA.SelectedValue = "0";
        //tddown006LRPA.Text = "";
    }
    protected void btnAtras_Click(object sender, EventArgs e)
    {
        Panel tPanel3 = (Panel)Tabs.FindControl("Panel3");
        Panel tpnldatos = (Panel)Tabs.FindControl("pnldatos");
        LimpiaControles();
        tPanel3.Visible = true;
        tpnldatos.Visible = false;
    }
    protected void btnsaveingreso_Click1(object sender, EventArgs e)
    {
        Ingreso();

        limpia_controles();
    }
    protected void btnactualizaingreso_Click(object sender, EventArgs e)
    {
        if (validatedata(0, true))
        {
            lblbmsg.Text = "Faltan datos para completar el Ingreso";
            lblbmsg.Visible = true;
        }
        else
        {
            coordinador cr = new coordinador();
            DataTable dt_OT = new DataTable();
            List<DbParameter> listDbParameter = new List<DbParameter>();

            string sql = "Select IcodOrdenTribunal  from CoordinacionIngreso where ICodIngreso =@pICodIngreso"; //ESTE ES EL CODIGO DERL NIÑO NO EL INGRESO

            listDbParameter.Add(Conexiones.CrearParametro("@pICodIngreso", SqlDbType.Int, 4, Convert.ToInt32(lbl005.Text)));

            dt_OT = cr.ejecuta_SQL(sql, listDbParameter);

            VICodOrdenTribunal = Convert.ToInt32(dt_OT.Rows[0][0]);


            TextBox tddown001 = (TextBox)Tabs.FindControl("ddown001");

            DataTable dt = new DataTable();
            int icodie = Convert.ToInt32(lbl005.Text);



            string SQL02 = "select T1.CodResolucionTribunal, T1.FechaDerivacion " +
            "FROM CoordinacionIngreso T1 " +
            "INNER JOIN parResolucionTribunal T2 ON T1.CodResolucionTribunal = T2.CodResolucionTribunal " +
            "INNER JOIN Proyectos T3 ON T1.CodProyecto = T3.CodProyecto " +
            "INNER JOIN  CoordinacionOrdenTribunal T4 ON T1.IcodOrdenTribunal = T4.IcodOrdenTribunal " +
            "INNER JOIN parTribunales T5 ON T4.CodTribunal = T5.CodTribunal " +
            "INNER JOIN parResoluciontribunal T6 ON  T1.CodResolucionTribunal = T6.CodResolucionTribunal " +
            "WHERE T1.IcodOrdentribunal =@pIcodOrdentribunal ";

            listDbParameter.Clear();
            listDbParameter.Add(Conexiones.CrearParametro("@pIcodOrdentribunal", SqlDbType.Int, 4, VICodOrdenTribunal));

            DataTable dt_sp1 = new DataTable();
            dt_sp1 = cr.ejecuta_SQL(SQL02, listDbParameter);

            #region Update_Tab1
            cr.callto_update_coordinacioningreso(/*icodie,*/Convert.ToInt32(lbl005.Text)
                , VICodOrdenTribunal
                , Convert.ToInt32(lbl004.Text)
                , Convert.ToInt32(CodProy)
                , Convert.ToInt32(dt_sp1.Rows[0][0])
                , Convert.ToDateTime(dt_sp1.Rows[0][1])
                , Convert.ToInt32(Session["IdUsuario"])
                , DateTime.Now
                );




            #endregion




            #region Delete_Tables
            string SQL03 = "select CodSancion " +
            "FROM CoordinacionSancion " +
            "WHERE IcodOrdentribunal =@pIcodOrdentribunal ";

            listDbParameter.Clear();
            listDbParameter.Add(Conexiones.CrearParametro("@pIcodOrdentribunal", SqlDbType.Int, 4, VICodOrdenTribunal));

            dt_sp1 = cr.ejecuta_SQL(SQL03, listDbParameter);

            string sqlDelete = "";

            //  string sqlDelete = "DELETE FROM CoordinacionSancionAccesoria WHERE CodSancion =" + Convert.ToInt32(dt_sp1.Rows[0][0]);//+ lbl005.Text;//"DELETE FROM CoordinacionAudiencia WHERE ICodIE =" + lbl005.Text;
            // cr.ejecuta_SQL(sqlDelete);

            DataTable DTSanc = new DataTable();
            string SQLSancion = "SELECT CodSancion FROM CoordinacionSancion WHERE ICodOrdenTribunal =@pICodOrdenTribunal";

            listDbParameter.Clear();
            listDbParameter.Add(Conexiones.CrearParametro("@pICodOrdenTribunal", SqlDbType.Int, 4, VICodOrdenTribunal));

            DTSanc = cr.ejecuta_SQL(SQLSancion, listDbParameter);
            if (Convert.ToInt32(DTSanc.Rows.Count) > 0)
            {
                sqlDelete = "DELETE FROM CoordinacionAmpliaInvestigacion WHERE CodSancion =@pCodSancion";

                listDbParameter.Clear();
                listDbParameter.Add(Conexiones.CrearParametro("@pCodSancion", SqlDbType.Int, 4, Convert.ToInt32(DTSanc.Rows[0][0])));

                cr.ejecuta_SQL(sqlDelete, listDbParameter);
            }
            sqlDelete = "DELETE FROM CoordinacionSancion WHERE ICodOrdenTribunal =@pICodOrdenTribunal";//+ lbl005.Text;//"DELETE FROM CoordinacionSancion WHERE ICodIE =" + lbl005.Text;

            listDbParameter.Clear();
            listDbParameter.Add(Conexiones.CrearParametro("@pICodOrdenTribunal", SqlDbType.Int, 4, VICodOrdenTribunal));

            cr.ejecuta_SQL(sqlDelete, listDbParameter);

            sqlDelete = "DELETE FROM CoordinacionAudiencia WHERE ICodOrdenTribunal =@pICodOrdenTribunal";//+ lbl005.Text;//"DELETE FROM CoordinacionAudiencia WHERE ICodIE =" + lbl005.Text;

            listDbParameter.Clear();
            listDbParameter.Add(Conexiones.CrearParametro("@pICodOrdenTribunal", SqlDbType.Int, 4, VICodOrdenTribunal));

            cr.ejecuta_SQL(sqlDelete, listDbParameter);
            sqlDelete = "DELETE FROM CoordinacionCausalIngreso WHERE ICodOrdenTribunal=@pICodOrdenTribunal";//lbl005.Text;//"DELETE FROM CoordinacionCausalIngreso WHERE ICodIE=" + lbl005.Text;

            listDbParameter.Clear();
            listDbParameter.Add(Conexiones.CrearParametro("@pICodOrdenTribunal", SqlDbType.Int, 4, VICodOrdenTribunal));

            cr.ejecuta_SQL(sqlDelete, listDbParameter);
            sqlDelete = "DELETE FROM CoordinacionIngreso WHERE ICodOrdenTribunal =@pICodOrdenTribunal";//lbl005.Text;//"DELETE FROM CoordinacionOrdenTribunal WHERE ICodIE =" + lbl005.Text;

            listDbParameter.Clear();
            listDbParameter.Add(Conexiones.CrearParametro("@pICodOrdenTribunal", SqlDbType.Int, 4, VICodOrdenTribunal));

            cr.ejecuta_SQL(sqlDelete, listDbParameter);
            // sqlDelete = "DELETE FROM CoordinacionOrdenTribunal WHERE ICodOrdenTribunal =" + VICodOrdenTribunal;//lbl005.Text;//"DELETE FROM CoordinacionOrdenTribunal WHERE ICodIE =" + lbl005.Text;
            // cr.ejecuta_SQL(sqlDelete);







            #endregion

            #region Insert_Tables
            int sentenciaejec = 0;

            //Areglo de edicion Sabado04 comienzo bloque Update

            //for (int i = 0; i < DTordentribunales.Rows.Count; i++)
            //{

            //    if (DTordentribunales.Rows[i][3].ToString() == "Si")
            //        sentenciaejec = 1;

            //    dt = cr.callto_insert_coordinacionordentribunal(Convert.ToInt32(DTordentribunales.Rows[i][0])
            //        , DTordentribunales.Rows[i][4].ToString()
            //        , DTordentribunales.Rows[i][5].ToString()
            //        , Convert.ToDateTime(DTordentribunales.Rows[i][2])
            //        , sentenciaejec
            //        , Convert.ToInt32(Session["IdUsuario"])
            //        , DateTime.Now
            //        );

            //    //DTICodOrdenTrubunal.Rows[i][1] = Convert.ToInt32(dt.Rows[i][1].ToString());
            //    DTordentribunales.Rows[i][7] = dt.Rows[0][0].ToString();
            //    VICodOrdenTribunal = Convert.ToInt32(dt.Rows[0][0].ToString());

            //    dt.Clear();
            //}

            int codorden = 0;
            //for (int i = 0; i < DTcausales.Rows.Count; i++)
            //{
            //    for (int j = 0; j < DTordentribunales.Rows.Count; j++)
            //    {
            //        if (DTordentribunales.Rows[j][6].ToString() == DTcausales.Rows[i][5].ToString())
            //        {
            //            codorden = Convert.ToInt32(DTordentribunales.Rows[j][7]);
            //        }
            //    }
            //    dt = cr.callto_insert_coordinacioncausalingreso(Convert.ToInt32(DTcausales.Rows[i][0])
            //        , Convert.ToInt32(DTcausales.Rows[i][4])
            //        ,VICodOrdenTribunal// codorden
            //        , Convert.ToInt32(Session["IdUsuario"])
            //        , DateTime.Now
            //        );

            //}
            //dt.Clear();
            //codorden = 0;

            //GridView tgrd001LRPA = (GridView)Tabs.FindControl("grd001LRPA");

            ////  for (int i = 0; i < DTMedidasSancion.Rows.Count; i++)
            //for (int i = 0; i < DTSancionV2.Rows.Count; i++)
            //{
            //    for (int j = 0; j < DTordentribunales.Rows.Count; j++)
            //    {
            //        //if (DTordentribunales.Rows[j][6].ToString() == DTmedidas.Rows[i][7].ToString())
            //        //{
            //        codorden = Convert.ToInt32(DTordentribunales.Rows[j][7]);
            //        //} 

            //    }


            //    dt = cr.callto_insert_coordinacionsancion(VICodOrdenTribunal//codorden
            //        , Convert.ToDateTime(DTSancionV2.Rows[i][1])
            //        , Convert.ToDateTime(DTSancionV2.Rows[i][2])
            //        , Convert.ToInt32(DTSancionV2.Rows[i][3])
            //        , Convert.ToInt32(DTSancionV2.Rows[i][4])
            //        , Convert.ToInt32(DTSancionV2.Rows[i][5])
            //        , Convert.ToInt32(DTSancionV2.Rows[i][6])
            //        , Convert.ToInt32(DTSancionV2.Rows[i][7])
            //        , Convert.ToInt32(DTSancionV2.Rows[i][8])
            //        , Convert.ToInt32(DTSancionV2.Rows[i][9])
            //        , Convert.ToDateTime(DTSancionV2.Rows[i][10])
            //        , Convert.ToDateTime(DTSancionV2.Rows[i][11])
            //        , Convert.ToInt32(DTSancionV2.Rows[i][12])
            //        , Convert.ToInt32(DTSancionV2.Rows[i][13])
            //        , Convert.ToInt32(DTSancionV2.Rows[i][14])
            //        , -1                                         //Convert.ToInt32(DTSancionV2.Rows[i][15])
            //        , Convert.ToDateTime("01-01-1900")          // Convert.ToDateTime(DTSancionV2.Rows[i][16])
            //        , Convert.ToInt32(DTSancionV2.Rows[i][17])
            //        , Convert.ToInt32(Session["IdUsuario"])
            //        , DateTime.Now
            //        );

            //    if (tgrd001LRPA.Rows.Count > 0)
            //    {

            //        for (int k = 0; k < tgrd001LRPA.Rows.Count; k++)
            //        {
            //            cr.callto_insert_coordinacionsancionaccesoria(Convert.ToInt32(DTTipoSancionAccesoria.Rows[k][1]), Convert.ToInt32(dt.Rows[i][0]));//Convert.ToInt32(DTTipoSancionAccesoria.Rows[i][3]));
            //        }
            //    }

            //}

            //dt.Clear();
            ////codorden = 0;


            ////for (int i = 0; i < DTmedidas.Rows.Count; i++)  INSERT ANTERIOR
            ////{
            ////    for (int j = 0; j < DTordentribunales.Rows.Count; j++)
            ////    {
            ////        if (DTordentribunales.Rows[j][6].ToString() == DTmedidas.Rows[i][7].ToString())
            ////        {
            ////            codorden = Convert.ToInt32(DTordentribunales.Rows[j][7]);
            ////        }
            ////    }

            ////    dt = cr.callto_insert_coordinacionsancion(codorden, Convert.ToDateTime(DTmedidas.Rows[i][0]) 
            ////        , Convert.ToDateTime(DTmedidas.Rows[i][1])
            ////        , Convert.ToInt32(DTmedidas.Rows[i][2])
            ////        , Convert.ToInt32(DTmedidas.Rows[i][3])
            ////        , Convert.ToInt32(DTmedidas.Rows[i][4])
            ////        ,/*CodTribunal*/1
            ////        ,/*SancionAccesoria*/2
            ////        , Convert.ToInt32(DTmedidas.Rows[i][5])
            ////        , Convert.ToInt32(DTmedidas.Rows[i][6])
            ////        ,/*fechainiciomixta*/Convert.ToDateTime("10-10-1900")
            ////        ,/*fechaTerminomixta*/Convert.ToDateTime("10-10-1900")
            ////        ,/*DuracionAnoMixta*/1
            ////        ,/*DuracionMesMixta*/1
            ////        ,/*DuracionDiaMixta*/1
            ////        ,/*CodTerminoSancion*/1
            ////        ,/*fechaTerminoSancion*/Convert.ToDateTime("10-10-1900")
            ////        ,/*CodModeloSancionMixta*/1
            ////        , Convert.ToInt32(Session["IdUsuario"])
            ////        , DateTime.Now);
            ////}
            ////dt.Clear();

            #region ActualizacionDelito (CoordinacionCausalIngreso)

            for (int i = 0; i < DTcausales.Rows.Count; i++)
            {

                //DTcausales.Columns.Add(new DataColumn("CodTipoCausalIngreso", typeof(int)));
                //DTcausales.Columns.Add(new DataColumn("CodCausalIngreso", typeof(int)));
                //DTcausales.Columns.Add(new DataColumn("DescripcionTipo", typeof(string)));
                //DTcausales.Columns.Add(new DataColumn("Descripcion", typeof(string)));
                //DTcausales.Columns.Add(new DataColumn("coddelito", typeof(int)));
                //DTcausales.Columns.Add(new DataColumn("codigo", typeof(string)));
                //DTcausales.Columns.Add(new DataColumn("ICodCausalIngreso", typeof(int)));

                for (int j = 0; j < DTordentribunales.Rows.Count; j++)
                {
                    cr.callto_insert_coordinacioncausalingreso(Convert.ToInt32(DTcausales.Rows[i][0]), Convert.ToInt32(DTcausales.Rows[i][4])
                  , VICodOrdenTribunal, Convert.ToInt32(Session["IdUsuario"]), DateTime.Now);

                }



            }

            #endregion


            #region ActualizacionResoluciondelTribunal


            for (int i = 0; i < DTResoluciones.Rows.Count; i++)
            {
                cr.callto_insert_coordinacioningreso(VICodOrdenTribunal, Convert.ToInt32(DTResoluciones.Rows[i][6]), Convert.ToInt32(lbl004.Text), Convert.ToInt32(DTResoluciones.Rows[i][7])
                , Convert.ToDateTime(DTResoluciones.Rows[i][3]), Convert.ToInt32(Session["IdUsuario"]), DateTime.Now);


            }

            #endregion


            #region ActualizacionPlazoMedida
            for (int i = 0; i < DTMedidasSancion.Rows.Count; i++)
            {
                DataTable DTPMI = new DataTable();
                DTPMI = cr.callto_insert_MedidasInvestigacion(VICodOrdenTribunal, Convert.ToDateTime(DTMedidasSancion.Rows[i][1]), Convert.ToDateTime(DTMedidasSancion.Rows[i][2]),
                Convert.ToInt32(DTMedidasSancion.Rows[i][3]), Convert.ToInt32(DTMedidasSancion.Rows[i][4]), Convert.ToDateTime(DTMedidasSancion.Rows[i][5]), Convert.ToInt32(Session["IdUsuario"]),
                DateTime.Now);
                int iden = Convert.ToInt32(DTPMI.Rows[0][0]);


                if (DTAmpliacionesMedidas.Rows.Count > 0)
                {
                    cr.callto_insert_CoordinacionAmpliaInvestigacion(iden, Convert.ToInt32(DTAmpliacionesMedidas.Rows[i][2]), Convert.ToDateTime(DTAmpliacionesMedidas.Rows[i][0]),
                    Convert.ToInt32(Session["IdUsuario"]));
                }
            }

            #endregion


            #region ActualizacionSancion

            for (int i = 0; i < DTSancionV2.Rows.Count; i++)
            {
                dt = cr.callto_insert_coordinacionsancion(VICodOrdenTribunal, Convert.ToDateTime(DTSancionV2.Rows[i][1]), Convert.ToDateTime(DTSancionV2.Rows[i][2]),
                Convert.ToInt32(DTSancionV2.Rows[i][3]), Convert.ToInt32(DTSancionV2.Rows[i][4]), Convert.ToInt32(DTSancionV2.Rows[i][5]), Convert.ToInt32(DTSancionV2.Rows[i][6]),
                Convert.ToInt32(DTSancionV2.Rows[i][7]), Convert.ToInt32(DTSancionV2.Rows[i][8]), Convert.ToInt32(DTSancionV2.Rows[i][9]), Convert.ToDateTime(DTSancionV2.Rows[i][10]),
                Convert.ToDateTime(DTSancionV2.Rows[i][11]), Convert.ToInt32(DTSancionV2.Rows[i][12]), Convert.ToInt32(DTSancionV2.Rows[i][13]), Convert.ToInt32(DTSancionV2.Rows[i][14]),
                Convert.ToInt32(DTSancionV2.Rows[i][15]), Convert.ToDateTime(DTSancionV2.Rows[i][16]), Convert.ToInt32(DTSancionV2.Rows[i][17]), Convert.ToInt32(DTSancionV2.Rows[i][18]),
                Convert.ToDateTime(DTSancionV2.Rows[i][19]));

                if (DTTipoSancionAccesoria.Rows.Count > 0)
                {
                    for (int j = 1; j < DTTipoSancionAccesoria.Rows.Count; j++)
                    {
                        DataTable DtTSA = new DataTable();
                        DtTSA = cr.callto_insert_coordinacionsancionaccesoria(Convert.ToInt32(DTTipoSancionAccesoria.Rows[j][1]), Convert.ToInt32(DTTipoSancionAccesoria.Rows[j][2]));
                    }
                }
            }

            #endregion ActualizacionSancion


            #region Actualizacion Audiencia
            codorden = 0;

            for (int i = 0; i < DTaudiencia.Rows.Count; i++)
            {
                for (int j = 0; j < DTordentribunales.Rows.Count; j++)
                {
                    if (DTordentribunales.Rows[j][6].ToString() == DTaudiencia.Rows[i][0].ToString())
                    {
                        codorden = Convert.ToInt32(DTordentribunales.Rows[j][7]);
                    }
                }
                dt = cr.callto_insert_coordinacionaudiencia(VICodOrdenTribunal//codorden
                , Convert.ToInt32(DTaudiencia.Rows[i][2])
                , /*validar campo Observacion*/DTaudiencia.Rows[i][4].ToString()
                , Convert.ToDateTime(DTaudiencia.Rows[i][1])
                , Convert.ToInt32(Session["IdUsuario"])
                , DateTime.Now
                );

            }
            #endregion


            #endregion


            pnl001.Visible = false;
            Tabs.Visible = false;
            limpia_controles();

        }
    }
    protected void btnvolverAudiencia_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();

        txt002.Enabled = true;
        txt004.Enabled = true;
        txt005.Enabled = true;
        txt006.Enabled = true;
        txt007.Enabled = true;


        btn_buscar.Visible = true;
        btn_modificar.Visible = true;

        if (lblSwich.Text == "M")
            grd004.Visible = true;
        else
            grd003.Visible = true;

        pnl001.Visible = false;
        Tabs.Visible = false;

        Tabs.TabIndex = 0;

        #region Limpia_tab1
        TextBox ttxt001 = (TextBox)Tabs.FindControl("txt001");
        TextBox tddown001 = (TextBox)Tabs.FindControl("ddown001");
        ttxt001.Text = "";
        tddown001.Text = null;
        ttxt001.BackColor = System.Drawing.Color.White;
        tddown001.BackColor = System.Drawing.Color.White;
        #endregion

        #region Limpia_tab2
        DropDownList tddown016 = (DropDownList)Tabs.FindControl("ddown016");
        DropDownList tddown014 = (DropDownList)Tabs.FindControl("ddown014");
        DropDownList tddown015 = (DropDownList)Tabs.FindControl("ddown015");
        DropDownList tddown_ota = (DropDownList)Tabs.FindControl("ddown_ota");
        DropDownList tddown_otc = (DropDownList)Tabs.FindControl("ddown_otc");
        DropDownList tddown_otm = (DropDownList)Tabs.FindControl("ddown_otm");
        GridView tgrd001 = (GridView)Tabs.FindControl("grd001");
        TextBox tddown017 = (TextBox)Tabs.FindControl("ddown017");
        TextBox ttxt006F2 = (TextBox)Tabs.FindControl("txt006F2");
        TextBox ttxt007F2 = (TextBox)Tabs.FindControl("txt007F2");
        RadioButtonList trdo001 = (RadioButtonList)Tabs.FindControl("rdo001");

        tddown014.SelectedIndex = -1;
        tddown015.SelectedIndex = -1;
        tddown016.SelectedIndex = -1;
        tddown_ota.Items.Clear();
        tddown_otc.Items.Clear();
        tddown_otm.Items.Clear();
        ListItem item = new ListItem("Seleccionar", "0");
        tddown_ota.Items.Add(item);
        tddown_otc.Items.Add(item);
        tddown_otm.Items.Add(item);
        tgrd001.DataSource = dt;
        tgrd001.DataBind();
        tgrd001.Visible = false;
        tddown017.Text = null;
        ttxt006F2.Text = "";
        ttxt007F2.Text = "";
        trdo001.SelectedValue = "0";

        tddown014.BackColor = System.Drawing.Color.White;
        tddown015.BackColor = System.Drawing.Color.White;
        tddown016.BackColor = System.Drawing.Color.White;
        tddown_ota.BackColor = System.Drawing.Color.White;
        tddown_otc.BackColor = System.Drawing.Color.White;
        tddown_otm.BackColor = System.Drawing.Color.White;
        ttxt006F2.BackColor = System.Drawing.Color.White;
        ttxt007F2.BackColor = System.Drawing.Color.White;

        #endregion

        #region Limpia_tab3
        GridView grd002 = (GridView)Tabs.FindControl("grd002");
        DropDownList tddown018 = (DropDownList)Tabs.FindControl("ddown018");
        DropDownList tddown019 = (DropDownList)Tabs.FindControl("ddown019");
        TextBox ttxt006 = (TextBox)Tabs.FindControl("txt006");
        Label tlbl_causales = (Label)Tabs.FindControl("lbl_causales");

        grd002.DataSource = dt;
        grd002.DataBind();
        grd002.Visible = false;

        tddown018.SelectedIndex = -1;
        tddown019.SelectedIndex = -1;
        ttxt006.Text = "";
        tlbl_causales.Visible = false;

        tddown018.BackColor = System.Drawing.Color.White;
        tddown019.BackColor = System.Drawing.Color.White;
        ttxt006.BackColor = System.Drawing.Color.White;

        #endregion

        #region Limpia_tab4
        TextBox ttxt001LRPA = (TextBox)Tabs.FindControl("txt001LRPA");
        TextBox ttxt002LRPA = (TextBox)Tabs.FindControl("txt002LRPA");
        TextBox ttxt007LRPA = (TextBox)Tabs.FindControl("txt007LRPA");
        TextBox ttxt009LRPA = (TextBox)Tabs.FindControl("txt009LRPA");
        TextBox ttxt003LRPA = (TextBox)Tabs.FindControl("txt003LRPA");
        Label tlbl_avisoDuracionLRPA = (Label)Tabs.FindControl("lbl_avisoDuracionLRPA");
        TextBox tddown001LRPA = (TextBox)Tabs.FindControl("ddown001LRPA");
        Label tllblfechaini1LRPA = (Label)Tabs.FindControl("lblfechaini1LRPA");
        GridView tgrd001LRPA = (GridView)Tabs.FindControl("grd001LRPA");

        ttxt001LRPA.Text = "";
        ttxt002LRPA.Text = "";
        ttxt003LRPA.Text = "";
        ttxt007LRPA.Text = "";
        ttxt009LRPA.Text = "";
        tlbl_avisoDuracionLRPA.Visible = false;
        tllblfechaini1LRPA.Visible = false;
        tddown001LRPA.Text = null;

        tgrd001LRPA.DataSource = dt;
        tgrd001LRPA.DataBind();
        tgrd001LRPA.Visible = false;



        #endregion

        #region Limpia_tab5
        GridView tgrd001Audiencia = (GridView)Tabs.FindControl("grd001Audiencia");
        DropDownList tddown021 = (DropDownList)Tabs.FindControl("ddown021");
        TextBox ttxt007 = (TextBox)Tabs.FindControl("txt007");

        tgrd001Audiencia.DataSource = dt;
        tgrd001Audiencia.DataBind();
        tgrd001Audiencia.Visible = false;
        tddown021.SelectedIndex = -1;
        txt007.Text = "";

        tddown021.BackColor = System.Drawing.Color.White;
        ttxt007.BackColor = System.Drawing.Color.White;

        #endregion
    }
    protected void wib001ExpXls_Click(object sender, EventArgs e)
    {

    }
    protected void lnkLrpa_calculaPlazofunc(object sender, EventArgs e)
    {
        Calcula_DiasMedida2();
        TextBox tTxtLrpa_FechPlazMed = (TextBox)Tabs.FindControl("TxtLrpa_FechPlazMed");
        tTxtLrpa_FechPlazMed.Focus();
    }
}

