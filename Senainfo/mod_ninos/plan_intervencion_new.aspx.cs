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
using System.Data.SqlClient;
using System.Data.Common;
using System.Data.SqlTypes;


public partial class mod_ninos_Nuevo_Plan_de_Intervención_plan_intervencion : System.Web.UI.Page
{
    private const int C_IDTAB_DATOS = 1;
    private const int C_IDTAB_AREA = 2; 
    private const int C_IDTAB_SEGUIMIENTO = 3;
    private const int C_IDTAB_CON_QUIEN = 4;
    private const int C_IDTAB_TERMINO = 5;
    private static Dictionary<string, int> grd001_hash_map = new Dictionary<string, int>();//gfontbrevis usado para actualizar icono ok


    private DataTable PI_CdtTabla
    {
        get { return (DataTable)ViewState["dtTablaPersonaRelacionada"]; }
        set { ViewState["dtTablaPersonaRelacionada"] = value; }
    }

    private DataTable PI_AdtTabla
    {
        get { return (DataTable)ViewState["dtTablaAreaIntervencion"]; }
        set { ViewState["dtTablaAreaIntervencion"] = value; }
    }
    public int vCodPaso
    {
        get { return (int)Session["vCodPaso"]; }
        set { Session["vCodPaso"] = value; }
    }
    public int vCodPaso2
    {
        get { return (int)Session["vCodPaso2"]; }
        set { Session["vCodPaso2"] = value; }
    }
    public string CodProyecto
    {
        get { return (string)Session["CodProyecto"]; }
        set { Session["CodProyecto"] = value; }
    }
    public string CodInstitucion
    {
        get { return (string)Session["CodInstitucion"]; }
        set { Session["CodInstitucion"] = value; }
    }
    public int Check
    {
        get 
        {
            if (Session["Check"] != null)
            {return (int)Session["Check"]; }
            else
            {return 0;}
        }
        set { Session["Check"] = value; }
    }
    public DataSet DVNinos
    {
        get { return (DataSet)ViewState["DVNinos"]; }
        set { ViewState["DVNinos"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
      alerts.Attributes.Add("style", "display:none");
      lbl005.Attributes.Add("style", "display:none");
      alerts2.Attributes.Add("style", "display:none");
      lbl0052.Attributes.Add("style", "display:none");
      mostrar_collapse(true);

      if (!IsPostBack)
      {

          if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
          {
              Response.Redirect("~/logout.aspx");
          }
          else
          {
              mostrar_collapse(true);
              if (!window.existetoken("951B0D8E-CFF7-4DAC-889B-88D153390C75"))
              {
                  Response.Redirect("~/logout.aspx");
              }
              else
              {
                  //---------------------------------LOAD de la principal
                  getInstituciones();
                  switch (Request.QueryString["sw"])
                  {
                      case null:
                          vCodPaso2 = 0;
                          break;
                      case "3":
                          ddown001.SelectedValue = Request.QueryString["codinst"];
                          CodInstitucion = Request.QueryString["codinst"];
                          getProyectosPorCodigo();
                          break;
                      case "4":
                          buscador_institucion bsc = new buscador_institucion();
                          int codinst = bsc.GetCodInstxCodProy(Convert.ToInt32(Request.QueryString["codinst"]));
                          ddown001.SelectedValue = Convert.ToString(codinst);
                          getProyectosPorCodigo();
                          ddown002.SelectedValue = Request.QueryString["codinst"];
                          Carga_Ninos_Plan();
                          //wib002_Click(sender, e);
                          break;
                  }

                  if (Request.QueryString.Count > 0 && CodProyecto != null && CodInstitucion != null)
                  {
                      ddown001.SelectedValue = CodInstitucion;
                      getProyectosPorCodigo();
                      ddown002.SelectedValue = CodProyecto;
                      ddown001.Enabled = false;
                      ddown002.Enabled = false;
                      btnbuscar.Visible = true;
                  }
                  else
                  {
                      //Session["CodProyecto"] = null;
                      //Session["CodInstitucion"] = null;
                  }
                  //--------------------------------- LOAD de "datos"
                  if (Session["NNA"] != null)
                  {
                      oNNA NNA = (oNNA)Session["NNA"];

                      txt001.Text = HttpUtility.HtmlDecode(NNA.NNAApePaterno);
                      TextBox2.Text = HttpUtility.HtmlDecode(NNA.NNANombres);
                      TextBox1.Text = HttpUtility.HtmlDecode(NNA.NNAApeMaterno);
                      ddown001.SelectedValue = NNA.NNACodInstitucion;
                      getProyectosPorCodigo();
                      ddown002.SelectedValue = CodProyecto;
                      Carga_Ninos_Plan();
                      wib002_Click(sender, e);
                  }
                  else
                  {
                      oNNA NNA = new oNNA("", "", 0, 0, "", "", "", "", "", "");
                      Session["NNA"] = NNA;
                  }

              }
          }
      }
      else
      {
          RV_PIwdc001.Validate();
          if (PItxt002.Visible == true){
            ScriptManager.RegisterStartupScript(this, this.GetType(), "a", "max(PItxt002);CharLimit(PItxt002, 1000);", true);
          }
          if (PI_Stxt001.Visible == true)
          {
              ScriptManager.RegisterStartupScript(this, this.GetType(), "b", "max2(PI_Stxt001);CharLimit2(PI_Stxt001, 200);", true);
          }

      }
    }


    #region frame_termino
    private void PI_FgetGradoCumplimiento()
    {
        if (Session["PI_GradoCumplimiento"] != null)
        {
            DataTable dv1 = new DataTable();
            dv1 = ((DataSet)Session["PI_GradoCumplimiento"]).Tables[0];
            DataView view = new DataView(dv1);

            PI_Fddown001.DataSource = view;
            PI_Fddown001.DataTextField = "Descripcion";
            PI_Fddown001.DataValueField = "CodGradoCumplimiento";
            view.Sort = "CodGradoCumplimiento";
            PI_Fddown001.DataBind();
        }
    }

    private void PI_FFuncion_Inicia_Grabado()
    {
        if (PI_Fddown001.SelectedValue != "-1" || PI_Frdolist001.SelectedValue != "" || PI_Frdolist002.SelectedValue != "" || PI_Fwdc001.Text != "")
        {
            if (PI_Frdolist001.SelectedValue != "" && PI_Fwdc001.Text != null)
            {
                PI_FFuncion_Grabar();
                wib003_Click(null, null); //limpia
                lnb003_Click(null, null); //carga
            }
            else
            {
                PI_Flbl001.Text = "Para cerrar un plan debe ingresar Grado de Cumplimiento y Fecha de Término. <br>El plan no ha sido grabado.";
                PI_Flbl001.Visible = true;
            }
        }
        else
        {
            PI_FFuncion_Grabar();
            wib003_Click(null, null); //limpia
            lnb003_Click(null, null); //carga
        }
    }

    private void PI_FFuncion_Grabar()
    {
        pintervencion pin = new pintervencion();

        int intIntervencionCompleta = 0, intHabilitadoEgreso = 0, intIdPlanIntervencion = 0, intCodGrupo = 0;
        string strFechaTerminoReal = "";

        switch (PI_Frdolist001.SelectedValue)
        {
            case "1":
                intIntervencionCompleta = 1;
                break;
            case "2":
                intIntervencionCompleta = 0;
                break;
            default:
                intIntervencionCompleta = -1;
                break;
        }

        switch (PI_Frdolist002.SelectedValue)
        {
            case "1":
                intHabilitadoEgreso = 1;
                break;
            case "0":
                intHabilitadoEgreso = 0;
                break;
            default:
                intHabilitadoEgreso = -1;
                break;
        }

        if (PI_Fwdc001.Text == "")
        { strFechaTerminoReal = "01-01-1900"; }
        else
        { strFechaTerminoReal = PI_Fwdc001.Text; }

        char[] chrSeparador = { '|' };

        //string[] strRegistroInicio = Session["PI_registro_inicio"].ToString().Split(chrSeparador);
        string strCodPlan = grd002.Columns[0].Visible ? grd002.Rows[0].Cells[0].Text : "-1"; 
        string[] strRegistroInicio = (strCodPlan + "|" + grd002.Rows[0].Cells[2].Text + "|" + ddown002.SelectedValue + "|" + grd002.Rows[0].Cells[1].Text + "|" + grd002.Rows[0].Cells[9].Text).Split(chrSeparador);

        //string[] strRegistroDatos = Session["PI_registro_datos"].ToString().Split(chrSeparador);
        string[] strRegistroDatos = (PItxt001.Text + "|" + PIwdc001.Text + "|" + PIwdc002.Text + "|" + PIwdc003.Text + "|" + PIddown001.SelectedValue + "|" + PItxt002.Text).Split(chrSeparador);

        //string[] strRegistroSeguimiento = Session["PI_registro_seguimiento"].ToString().Split(chrSeparador);
        string strColabNino, strParticFamilia;
        strColabNino = PI_Schk001.Checked ? "1" : "0";
        strParticFamilia = PI_Schk002.Checked?"1":"0";
        string[] strRegistroSeguimiento = (PI_Sddown001.SelectedValue + "|" + strColabNino + "|" + strParticFamilia + "|" + PI_Stxt001.Text).Split(chrSeparador);

        SqlTransaction sqlt;

        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        sconn.Open();
        sqlt = sconn.BeginTransaction();
        try
        {


        if ((bool)Session["Grupo"])
        {
            intCodGrupo = pin.Insert_Update_PlanIntervencionGrupoTransaccional(sqlt,-1, strRegistroDatos[0], "V");

            DataTable dtNinosPlan = new DataTable();
            DataTable dtPlanIntervencion = new DataTable();
            DataRow dr;
            dtPlanIntervencion.Columns.Add(new DataColumn("PlanIntervencion", typeof(int)));

            dtNinosPlan = (DataTable)Session["PI_TablaNinosPlan"];

            for (int i = 0; i < dtNinosPlan.Rows.Count; i++)
            {
                dr = dtPlanIntervencion.NewRow();
                dr[0] = intIdPlanIntervencion = pin.Insert_Update_PlanIntervencionTransaccional(sqlt, -1, Convert.ToInt32(dtNinosPlan.Rows[i][1]),
                    Convert.ToInt32(strRegistroInicio[2]), Convert.ToInt32(dtNinosPlan.Rows[i][0]), Convert.ToDateTime(dtNinosPlan.Rows[i][7]),
                    Convert.ToDateTime(strRegistroDatos[1]), Convert.ToInt32(PI_Fddown001.SelectedValue), Convert.ToInt32(strRegistroSeguimiento[1]), Convert.ToInt32(strRegistroSeguimiento[2]),
                    Convert.ToInt32(strRegistroDatos[4]), 0, 0, Convert.ToDateTime(strRegistroDatos[2]), Convert.ToDateTime(strRegistroDatos[3]),
                    Convert.ToDateTime(strFechaTerminoReal), strRegistroDatos[5], strRegistroSeguimiento[3], intHabilitadoEgreso, intIntervencionCompleta,
                     Convert.ToInt32(Session["IdUsuario"]), intCodGrupo);
                dtPlanIntervencion.Rows.Add(dr);
            }

            DataTable dtAreaIntervencion = new DataTable();
            dtAreaIntervencion = (DataTable)ViewState["dtTablaAreaIntervencion"];

            for (int i = 0; i < dtPlanIntervencion.Rows.Count; i++)
            {
                for (int j = 0; j < dtAreaIntervencion.Rows.Count; j++)
                {
                    pin.Insert_IntervencionesTransaccional(sqlt, Convert.ToInt32(dtPlanIntervencion.Rows[i][0]), Convert.ToInt32(dtAreaIntervencion.Rows[j][0]), Convert.ToInt32(dtAreaIntervencion.Rows[j][2]), DateTime.Now, Convert.ToString(dtAreaIntervencion.Rows[j][5]));
                }
            }

            for (int j = 0; j < dtPlanIntervencion.Rows.Count; j++)
            {
                pin.Insert_Update_EstadosPlanIntervencionTransaccional(sqlt, -1, Convert.ToInt32(dtPlanIntervencion.Rows[j][0]), Convert.ToInt32(strRegistroSeguimiento[0]));
            }
        }
        else
        {
            intIdPlanIntervencion = pin.Insert_Update_PlanIntervencionTransaccional(sqlt, Convert.ToInt32(strRegistroInicio[0]), Convert.ToInt32(strRegistroInicio[1]),
                    Convert.ToInt32(strRegistroInicio[2]), Convert.ToInt32(strRegistroInicio[3]), Convert.ToDateTime(strRegistroInicio[4]), Convert.ToDateTime(strRegistroDatos[1])
                    , Convert.ToInt32(PI_Fddown001.SelectedValue), Convert.ToInt32(strRegistroSeguimiento[1]), Convert.ToInt32(strRegistroSeguimiento[2]), Convert.ToInt32(strRegistroDatos[4])
                    , 0, 0, Convert.ToDateTime(strRegistroDatos[2]), Convert.ToDateTime(strRegistroDatos[3]),
                    Convert.ToDateTime(strFechaTerminoReal), strRegistroDatos[5], strRegistroSeguimiento[3], intHabilitadoEgreso,
                    intIntervencionCompleta, Convert.ToInt32(Session["IdUsuario"]), 0);

            DataTable dtPersonaRelacionada = new DataTable();
            dtPersonaRelacionada = (DataTable)Session["dtTablaPersonaRelacionada"];

            for (int i = 0; i < dtPersonaRelacionada.Rows.Count; i++)
            {
                if (dtPersonaRelacionada.Rows[i][4].ToString() == "1")
                {
                    pin.Insert_Update_TrabajaEgresoTransaccional(sqlt, -1, intIdPlanIntervencion,
                        Convert.ToInt32(dtPersonaRelacionada.Rows[i][1]), DateTime.Now, Convert.ToDateTime("01-01-1900"), "V");
                }
            }

            DataTable dtAreaIntervencion = new DataTable();
            dtAreaIntervencion = (DataTable)ViewState["dtTablaAreaIntervencion"];

            for (int i = 0; i < dtAreaIntervencion.Rows.Count; i++)
            {
                if (dtAreaIntervencion.Rows[i][4].ToString() == "1")
                {
                    pin.Insert_IntervencionesTransaccional(sqlt, intIdPlanIntervencion, Convert.ToInt32(dtAreaIntervencion.Rows[i][0]), Convert.ToInt32(dtAreaIntervencion.Rows[i][2]), DateTime.Now, Convert.ToString(dtAreaIntervencion.Rows[i][5]));
                }
            }

            pin.Insert_Update_EstadosPlanIntervencionTransaccional(sqlt, -1, intIdPlanIntervencion, Convert.ToInt32(strRegistroSeguimiento[0]));

        }
        mostrar_collapse(true);


        sqlt.Commit();
        sconn.Close(); 
        }
        catch (Exception ex)
        {
            // Handle the exception if the transaction fails to commit.
            Response.Write("<script language='javascript'>alert('Guardado no realizado, intentar nuevamene.');</script>");
            Console.WriteLine(ex.Message);

            try
            {
                // Attempt to roll back the transaction.
                sqlt.Rollback();
            }
            catch (Exception exRollback)
            {
                // Throws an InvalidOperationException if the connection 
                // is closed or the transaction has already been rolled 
                // back on the server.
                Response.Write("<script language='javascript'>alert('Guardado Realizado Con errores, por favor contactarse con mesa de ayuda. ');</script>");
                Console.WriteLine(exRollback.Message);
            }
        }
    }


    protected void PI_Fwdc001_ValueChanged(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToDateTime(PI_Fwdc001.Text) < Convert.ToDateTime(Session["PI_FechaTermino"]))
            {
                PI_Flbl001.Text = "La Fecha de Termino debe ser Mayor que la de Inicio.";
                PI_Flbl001.Visible = true;
            }
            else
            { PI_Flbl001.Visible = false; }
        }
        catch { }
    }

    #endregion

    #region frame_con_quien

    protected void PI_Cwib002_Click(object sender, EventArgs e) //desde con quien
    {
        //RegisterClientScriptBlock("CambioTab", "<script>window.parent.LlamaTab(4);</script>");
        muestra_pestaña(C_IDTAB_TERMINO);
        PI_FgetGradoCumplimiento();
    }

    private void PI_CArmaTabla()
    {
        if (PI_CdtTabla != null) return;
        DataTable dt = new DataTable();

        dt.Columns.Add(new DataColumn("nombres", typeof(string)));
        dt.Columns.Add(new DataColumn("CodPersonaRelacionada", typeof(int)));
        dt.Columns.Add(new DataColumn("descripcion", typeof(string)));
        dt.Columns.Add(new DataColumn("fecharelacion", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("chequea", typeof(int)));

        PI_CdtTabla = dt;
        PI_Cgrd001.DataSource = PI_CdtTabla;
        PI_Cgrd001.DataBind();
        grd001.HeaderRow.TableSection = TableRowSection.TableHeader;
        grd002.HeaderRow.TableSection = TableRowSection.TableHeader;

    }

    private void PI_CgetPersonaRelacionada()
    {
        if (Session["PI_Quien"] != null)
        {
            DataSet ds1 = new DataSet();
            ds1 = (DataSet)Session["PI_Quien"];
            DataView dv1 = new DataView();
            dv1 = ds1.Tables[0].DefaultView;

            PI_Cddown001.DataSource = dv1;
            PI_Cddown001.DataTextField = "nombres";
            PI_Cddown001.DataValueField = "CodPersonaRelacionada";
            dv1.Sort = "nombres";   
            PI_Cddown001.DataBind();
        }
    }

    protected void PI_Cwib001_Click(object sender, EventArgs e)
    {
        if (PI_Cddown001.SelectedValue != "0" && PI_Clbl003.Text.Trim() != "" && PI_Clbl004.Text.Trim() != "")
        {
            bool bolCheck = false;

            if (PI_Cgrd001.Rows.Count > 0)
            {
                for (int i = 0; i < PI_CdtTabla.Rows.Count; i++)
                {
                    if (Convert.ToInt32(PI_CdtTabla.Rows[i][1]) == Convert.ToInt32(PI_Cddown001.SelectedValue))
                    { bolCheck = true; }
                }
            }

            if (!bolCheck)
            {
                DataRow dr;

                dr = PI_CdtTabla.NewRow();
                dr[0] = PI_Clbl002.Text;
                dr[1] = Convert.ToInt32(PI_Cddown001.SelectedValue);
                dr[2] = PI_Clbl003.Text;
                dr[3] = Convert.ToDateTime(PI_Clbl004.Text).ToShortDateString();
                dr[4] = 1;
                PI_CdtTabla.Rows.Add(dr);

                PI_Cgrd001.Columns[3].Visible = true;
                PI_Cgrd001.DataSource = PI_CdtTabla;
                PI_Cgrd001.DataBind();
                grd001.HeaderRow.TableSection = TableRowSection.TableHeader;
                grd002.HeaderRow.TableSection = TableRowSection.TableHeader;

                for (int i = 0; i < PI_Cgrd001.Rows.Count; i++)
                {
                    if (PI_Cgrd001.Rows[i].Cells[5].Text == "0")
                    { PI_Cgrd001.Rows[i].Cells[4].Enabled = false; }
                    else
                    { PI_Cgrd001.Rows[i].Cells[4].Enabled = true; }
                }
            }
        }
        muestra_pestaña(C_IDTAB_CON_QUIEN);//TODO: gfontbrevis hacer que las otras pestañas se vean pero no esten activas
    }

    protected void PI_Cddown001_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds1 = new DataSet();
        ds1 = (DataSet)Session["PI_Quien"];
        DataView dv1 = new DataView();
        dv1 = ds1.Tables[0].DefaultView;
        try
        { 
            for (int i = 0; i < dv1.Count; i++)
            {
                if (Convert.ToInt32(PI_Cddown001.SelectedValue) == Convert.ToInt32(dv1.Table.Rows[i][1]))
                {
                    PI_Clbl002.Text = Convert.ToString(dv1.Table.Rows[i][0]);
                    PI_Clbl003.Text = Convert.ToString(dv1.Table.Rows[i][4]);
                    PI_Clbl004.Text = Convert.ToDateTime(dv1.Table.Rows[i][5]).ToShortDateString();
                }
            }
        }
        catch (Exception ex)
        {}
        muestra_pestaña(C_IDTAB_CON_QUIEN);
    }

    protected void PI_Cgrd001_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Quitar")
        {
            PI_CdtTabla.Rows.Remove(PI_CdtTabla.Rows[Convert.ToInt32(e.CommandArgument)]);
            PI_Cgrd001.DataSource = PI_CdtTabla;
            PI_Cgrd001.DataBind();
            grd001.HeaderRow.TableSection = TableRowSection.TableHeader;
            grd002.HeaderRow.TableSection = TableRowSection.TableHeader;
            muestra_pestaña(C_IDTAB_CON_QUIEN);
        }
    }

   

    //protected void PI_Clnb001_Click(object sender, EventArgs e)
    //{

    //}

    private void PI_CFuncion_Grabar()
    {
        pintervencion pin = new pintervencion();

        //int intIntervencionCompleta = 0, intHabilitadoEgreso = 0, intIdPlanIntervencion = 0, intCodGrupo = 0;
        int intIntervencionCompleta = -1, intHabilitadoEgreso = -1, intIdPlanIntervencion = 0, CodGradoCumplimiento = -1, intCodGrupo = 0;
        string strFechaTerminoReal = "01-01-1900";

        char[] chrSeparador = { '|' };

        //string[] strRegistroInicio = Session["PI_registro_inicio"].ToString().Split(chrSeparador);
        string strCodPlan = grd002.Columns[0].Visible ? grd002.Rows[0].Cells[0].Text : "-1";
        string[] strRegistroInicio = (strCodPlan + "|" + grd002.Rows[0].Cells[2].Text + "|" + ddown002.SelectedValue + "|" + grd002.Rows[0].Cells[1].Text + "|" + grd002.Rows[0].Cells[9].Text).Split(chrSeparador);

  
        //string[] strRegistroDatos = Session["PI_registro_datos"].ToString().Split(chrSeparador);
        string[] strRegistroDatos = (PItxt001.Text + "|" + PIwdc001.Text + "|" + PIwdc002.Text + "|" + PIwdc003.Text + "|" + PIddown001.SelectedValue + "|" + PItxt002.Text).Split(chrSeparador);

        string strColabNino, strParticFamilia;
        strColabNino = PI_Schk001.Checked ? "1" : "0";
        //if (PI_Schk002.Checked) strParticFamilia = "1";  else strParticFamilia = "0"; 
        strParticFamilia = PI_Schk002.Checked ? "1" : "0";
        //string[] strRegistroSeguimiento = Session["PI_registro_seguimiento"].ToString().Split(chrSeparador);
        string[] strRegistroSeguimiento = (PI_Sddown001.SelectedValue + "|" + strColabNino + "|" + strParticFamilia + "|" + PI_Stxt001.Text).Split(chrSeparador);


        SqlTransaction sqlt;
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        sconn.Open();
        sqlt = sconn.BeginTransaction();
        try
        {

        if ((bool)Session["Grupo"])
        {
            intCodGrupo = pin.Insert_Update_PlanIntervencionGrupoTransaccional(sqlt,-1, strRegistroDatos[0], "V");

            DataTable dtNinosPlan = new DataTable();
            DataTable dtPlanIntervencion = new DataTable();
            DataRow dr;
            dtPlanIntervencion.Columns.Add(new DataColumn("PlanIntervencion", typeof(int)));

            dtNinosPlan = (DataTable)Session["PI_TablaNinosPlan"];

            for (int i = 0; i < dtNinosPlan.Rows.Count; i++)
            {
                dr = dtPlanIntervencion.NewRow();
                dr[0] = intIdPlanIntervencion = pin.Insert_Update_PlanIntervencionTransaccional(sqlt, -1, Convert.ToInt32(dtNinosPlan.Rows[i][1]),
                    Convert.ToInt32(strRegistroInicio[2]), Convert.ToInt32(dtNinosPlan.Rows[i][0]), Convert.ToDateTime(dtNinosPlan.Rows[i][7]),
                    //GMP
                    Convert.ToDateTime(strRegistroDatos[1]), 0, Convert.ToInt32(strRegistroSeguimiento[1]), Convert.ToInt32(strRegistroSeguimiento[2]),
                    Convert.ToInt32(strRegistroDatos[4]), 0, 0, Convert.ToDateTime(strRegistroDatos[2]), Convert.ToDateTime(strRegistroDatos[3]),
                    Convert.ToDateTime(strFechaTerminoReal), strRegistroDatos[5], strRegistroSeguimiento[3], intHabilitadoEgreso, intIntervencionCompleta,
                     Convert.ToInt32(Session["IdUsuario"]), intCodGrupo);
                dtPlanIntervencion.Rows.Add(dr);
            }

            DataTable dtAreaIntervencion = new DataTable();
            dtAreaIntervencion = (DataTable)ViewState["dtTablaAreaIntervencion"];

            for (int i = 0; i < dtPlanIntervencion.Rows.Count; i++)
            {
                for (int j = 0; j < dtAreaIntervencion.Rows.Count; j++)
                {
                    pin.Insert_IntervencionesTransaccional(sqlt, Convert.ToInt32(dtPlanIntervencion.Rows[i][0]), Convert.ToInt32(dtAreaIntervencion.Rows[j][0]), Convert.ToInt32(dtAreaIntervencion.Rows[j][2]), DateTime.Now, Convert.ToString(dtAreaIntervencion.Rows[j][5]));
                }
            }

            for (int j = 0; j < dtPlanIntervencion.Rows.Count; j++)
            {
                pin.Insert_Update_EstadosPlanIntervencionTransaccional(sqlt, -1, Convert.ToInt32(dtPlanIntervencion.Rows[j][0]), Convert.ToInt32(strRegistroSeguimiento[0]));
            }
        }
        else
        {
            intIdPlanIntervencion = pin.Insert_Update_PlanIntervencionTransaccional(sqlt, Convert.ToInt32(strRegistroInicio[0]), Convert.ToInt32(strRegistroInicio[1]),
                    Convert.ToInt32(strRegistroInicio[2]), Convert.ToInt32(strRegistroInicio[3]), Convert.ToDateTime(strRegistroInicio[4]), Convert.ToDateTime(strRegistroDatos[1])
                    //GMP puse grado de cumplimiento 0
                    , -1, Convert.ToInt32(strRegistroSeguimiento[1]), Convert.ToInt32(strRegistroSeguimiento[2]), Convert.ToInt32(strRegistroDatos[4])
                    , 0, 0, Convert.ToDateTime(strRegistroDatos[2]), Convert.ToDateTime(strRegistroDatos[3]),
                    Convert.ToDateTime(strFechaTerminoReal), strRegistroDatos[5], strRegistroSeguimiento[3], intHabilitadoEgreso,
                    intIntervencionCompleta, Convert.ToInt32(Session["IdUsuario"]), 0);

            DataTable dtPersonaRelacionada = new DataTable();
            //dtPersonaRelacionada = (DataTable)Session["dtTablaPersonaRelacionada"];
            //dtPersonaRelacionada = PI_Cgrd001.DataSource as DataTable;
            for (int i = 0; i < PI_Cgrd001.Columns.Count; i++)
            {
                dtPersonaRelacionada.Columns.Add("column" + i.ToString());
            }
            foreach (GridViewRow row in PI_Cgrd001.Rows)
            {
                DataRow dr = dtPersonaRelacionada.NewRow();
                for (int j = 0; j < PI_Cgrd001.Columns.Count; j++)
                {
                    dr["column" + j.ToString()] = row.Cells[j].Text;
                }

                dtPersonaRelacionada.Rows.Add(dr);
            }

            for (int i = 0; i < dtPersonaRelacionada.Rows.Count; i++)
            {
                if (dtPersonaRelacionada.Rows[i][4].ToString() == "1")
                {
                    pin.Insert_Update_TrabajaEgresoTransaccional(sqlt, -1, intIdPlanIntervencion,
                        Convert.ToInt32(dtPersonaRelacionada.Rows[i][1]), DateTime.Now, Convert.ToDateTime("01-01-1900"), "V");
                }
            }

            DataTable dtAreaIntervencion = new DataTable();
            dtAreaIntervencion = (DataTable)ViewState["dtTablaAreaIntervencion"];

            for (int i = 0; i < dtAreaIntervencion.Rows.Count; i++)
            {
                if (dtAreaIntervencion.Rows[i][4].ToString() == "1")
                {
                    pin.Insert_IntervencionesTransaccional(sqlt, intIdPlanIntervencion, Convert.ToInt32(dtAreaIntervencion.Rows[i][0]), Convert.ToInt32(dtAreaIntervencion.Rows[i][2]), DateTime.Now, Convert.ToString(dtAreaIntervencion.Rows[i][5]));
                }
            }

            pin.Insert_Update_EstadosPlanIntervencionTransaccional(sqlt, -1, intIdPlanIntervencion, Convert.ToInt32(strRegistroSeguimiento[0]));

        }

        sqlt.Commit();
        sconn.Close();
        }
        catch (Exception ex)
        {
            // Handle the exception if the transaction fails to commit.
            Response.Write("<script language='javascript'>alert('Guardado no realizado, intentar nuevamene.');</script>");
            Console.WriteLine(ex.Message);

            try
            {
                // Attempt to roll back the transaction.
                sqlt.Rollback();
            }
            catch (Exception exRollback)
            {
                // Throws an InvalidOperationException if the connection 
                // is closed or the transaction has already been rolled 
                // back on the server.
                Response.Write("<script language='javascript'>alert('Guardado Realizado Con errores, por favor contactarse con mesa de ayuda. ');</script>");
                Console.WriteLine(exRollback.Message);
            }
        }
    }
    #endregion
    

    #region frame_seguimiento

    private void PI_SgetEstadoIntervencion()
    {
        string iSelVal = PI_Sddown001.SelectedValue;
        
        if (Session["PI_EstadoIntervencion"] == null) return;       

        DataTable dv1 = new DataTable();
        dv1 = ((DataSet)Session["PI_EstadoIntervencion"]).Tables[0];
        DataView view = new DataView(dv1);

        PI_Sddown001.DataSource = view;
        PI_Sddown001.DataTextField = "Descripcion";
        PI_Sddown001.DataValueField = "CodEstadoIntervencion";
        view.Sort = "CodEstadoIntervencion";
        PI_Sddown001.DataBind();
        try { PI_Sddown001.SelectedValue = iSelVal; }
        catch (Exception ex)
        { }
        
        
    }

    protected void PI_Swib001_Click(object sender, EventArgs e) //desde seguimiento
    {
        if (!(bool)Session["Grupo"])
        {
            muestra_pestaña(C_IDTAB_CON_QUIEN);
            PI_CgetPersonaRelacionada();
            PI_CArmaTabla();
        }
        else
        {
            muestra_pestaña(C_IDTAB_TERMINO);
            PI_FgetGradoCumplimiento();
        }
    }

    protected void PI_Sgrd001_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Quitar")
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new DataColumn("nombres", typeof(string)));
            dt.Columns.Add(new DataColumn("CodPersonaRelacionada", typeof(int)));
            dt.Columns.Add(new DataColumn("descripcion", typeof(string)));
            dt.Columns.Add(new DataColumn("fecharelacion", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("chequea", typeof(int)));

            for (int i = 0; i < PI_Sgrd001.Rows.Count; i++)
            {
                dr = dt.NewRow();
                dr[0] = PI_Sgrd001.Rows[i].Cells[0].Text;
                dr[1] = Convert.ToInt32(PI_Sgrd001.Rows[i].Cells[1].Text);
                dr[2] = PI_Sgrd001.Rows[i].Cells[2].Text;
                dr[3] = Convert.ToDateTime(PI_Sgrd001.Rows[i].Cells[3].Text).ToShortDateString();
                dr[4] = Convert.ToInt32(PI_Sgrd001.Rows[i].Cells[5].Text);
                dt.Rows.Add(dr);
            }

            dt.Rows.Remove(dt.Rows[Convert.ToInt32(e.CommandArgument)]);
            PI_Sgrd001.DataSource = dt;
            PI_Sgrd001.DataBind();
            grd001.HeaderRow.TableSection = TableRowSection.TableHeader;
            grd002.HeaderRow.TableSection = TableRowSection.TableHeader;


        }
    }

    //protected void PI_Slnb001_Click(object sender, EventArgs e)
    //{
        //string strColabNino, strParticFamilia;

        //if (PI_Schk001.Checked)
        //{ strColabNino = "1"; }
        //else
        //{ strColabNino = "0"; }

        //if (PI_Schk002.Checked)
        //{ strParticFamilia = "1"; }
        //else
        //{ strParticFamilia = "0"; }

        //Session["PI_registro_seguimiento"] = PI_Sddown001.SelectedValue + "|" + strColabNino + "|" + strParticFamilia + "|" + PI_Stxt001.Text;
        //RegisterClientScriptBlock("SesionesGraba", "<script>window.parent.LlamaSesiones(4);</script>");
        //muestra_pestaña(4);
    //}

    #endregion

    #region frame_area
    private void PI_AgetTipoIntervencion()
    {
        if (Session["PI_TipoIntervencion"] != null)
        {
            DataTable dv1 = new DataTable();
            dv1 = ((DataSet)Session["PI_TipoIntervencion"]).Tables[0];
            DataView view = new DataView(dv1);

            PI_Addown001.DataSource = view;
            PI_Addown001.DataTextField = "Descripcion";
            PI_Addown001.DataValueField = "TipoIntervencion";
            view.Sort = "Descripcion";
            PI_Addown001.DataBind();
        }
    }
    private void PI_AgetNivelIntervencion()
    {
        if (Session["PI_NivelIntervencion"] != null)
        {
            DataTable dv1 = new DataTable();
            dv1 = ((DataSet)Session["PI_NivelIntervencion"]).Tables[0];
            DataView view = new DataView(dv1);

            if ((bool)Session["Grupo"])
            { view.RowFilter = "CodNivelIntervencion <>'1'"; }
            else
            { view.RowFilter = "CodNivelIntervencion <>'3'"; }

            PI_Addown002.DataSource = view;
            PI_Addown002.DataTextField = "Descripcion";
            PI_Addown002.DataValueField = "CodNivelIntervencion";
            view.Sort = "Descripcion";
            PI_Addown002.DataBind();
        }
    }
    private void PI_AArmaTabla()
    {
        if (PI_AdtTabla != null) return;
        DataTable dt = new DataTable();
        //DataRow dr;
        dt.Columns.Add(new DataColumn("TipoIntervencion", typeof(int)));
        dt.Columns.Add(new DataColumn("DescripcionTipo", typeof(string)));
        dt.Columns.Add(new DataColumn("NivelIntervencion", typeof(int)));
        dt.Columns.Add(new DataColumn("DescripcionNivel", typeof(string)));
        dt.Columns.Add(new DataColumn("Chequea", typeof(int)));
        dt.Columns.Add(new DataColumn("IdGrupoIntervenciones", typeof(string)));

        PI_AdtTabla = dt;
        PI_Agrd001.DataSource = PI_AdtTabla;
        PI_Agrd001.DataBind();
        grd001.HeaderRow.TableSection = TableRowSection.TableHeader;
        grd002.HeaderRow.TableSection = TableRowSection.TableHeader;
    }

    protected void PI_Awib002_Click(object sender, EventArgs e)
    {

        if (PI_Agrd001.Rows.Count > 0)
        {
            //PI_Albl002.Visible = false;
            //GMP RegisterClientScriptBlock("CambioTab", "<script>window.parent.LlamaTab(2);</script>");
            muestra_pestaña(C_IDTAB_SEGUIMIENTO);
            PI_SgetEstadoIntervencion();
        }
        else
        {
          alerts.Attributes.Add("style", "");
          lbl005.Text = "Debe seleccionar Tipo Intervención y Nivel de Intervención.";
          lbl005.Attributes.Add("style", "");  
            //ScriptManager.RegisterStartupScript(this, typeof(string), "Agregar", "alert('Error, .');", true);
            muestra_pestaña(C_IDTAB_AREA);
            //PI_Albl002.Visible = true;
            
        }
    }
    protected void PI_Awib001_Click(object sender, EventArgs e) //agrega uno nuevo
    {
        pintervencion pin = new pintervencion();

        #region validaciones
        // ------ maximo 6
        if (PI_Agrd001.Rows.Count >= 6) return;

        // ------ debe seleccionar ambos combos
        if (PI_Addown001.SelectedValue == "0" || PI_Addown002.SelectedValue == "0")
        {
          alerts.Attributes.Add("style", "");
          lbl005.Text = "Debe seleccionar Tipo Intervención y Nivel de Intervención.";
          lbl005.Attributes.Add("style", "");  
            //ScriptManager.RegisterStartupScript(this, typeof(string), "Agregar", "alert('Error, ');", true);
            muestra_pestaña(C_IDTAB_AREA);
            //PI_Albl002.Text = "* Debe seleccionar Tipo Intervención y Nivel de Intervención.";
            //PI_Albl002.Visible = true;
            wib002.Visible = true;
            
            return;
        }
        // ------ no debe repetirse
        bool bolCheck = false;
        PI_Albl002.Visible = false;

        if (PI_Agrd001.Rows.Count > 0)
        {
            for (int i = 0; i < PI_AdtTabla.Rows.Count; i++)
            {
                if (Convert.ToInt32(PI_AdtTabla.Rows[i][0]) == Convert.ToInt32(PI_Addown001.SelectedValue) &&
                    Convert.ToInt32(PI_AdtTabla.Rows[i][2]) == Convert.ToInt32(PI_Addown002.SelectedValue))
                { bolCheck = true; }
            }
        }

        if (bolCheck)
        {
          alerts.Attributes.Add("style", "");
          lbl005.Text = "Ingrese una combinacion diferente.";
          lbl005.Attributes.Add("style", "");  
            //ScriptManager.RegisterStartupScript(this, typeof(string), "Agregar", "alert('Error, Ingrese una combinacion diferente.');", true);
            //PI_Albl002.Text = "Ingrese una combinacion diferente.";
            //PI_Albl002.Visible = true;
            return;
        }
        #endregion

        // ----- agrega nuevo
        string strGuid = Guid.NewGuid().ToString();
        DataRow dr;
        dr = PI_AdtTabla.NewRow();
        dr[0] = Convert.ToInt32(PI_Addown001.SelectedValue);
        dr[1] = Convert.ToString(PI_Addown001.SelectedItem.Text);
        dr[2] = Convert.ToInt32(PI_Addown002.SelectedValue);
        dr[3] = Convert.ToString(PI_Addown002.SelectedItem.Text);
        dr[4] = 1;
        dr[5] = strGuid;
        PI_AdtTabla.Rows.Add(dr);

        PI_Agrd001.DataSource = PI_AdtTabla;
        PI_Agrd001.DataBind();
        grd001.HeaderRow.TableSection = TableRowSection.TableHeader;
        grd002.HeaderRow.TableSection = TableRowSection.TableHeader;

        for (int i = 0; i < PI_Agrd001.Rows.Count; i++)
        {
            PI_Agrd001.Rows[i].Cells[4].Enabled = (PI_Agrd001.Rows[i].Cells[5].Text == "1");
            //if (PI_Agrd001.Rows[i].Cells[5].Text == "1")
            //{ PI_Agrd001.Rows[i].Cells[4].Enabled = true; }
            //else
            //{ PI_Agrd001.Rows[i].Cells[4].Enabled = false; }
        }

        muestra_pestaña(C_IDTAB_AREA);
    }

    protected void PI_Agrd001_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        pintervencion pin = new pintervencion();
        if (e.CommandName == "Quitar")
        {
            PI_AdtTabla.Rows.Remove(PI_AdtTabla.Rows[Convert.ToInt32(e.CommandArgument)]);
            PI_Agrd001.DataSource = PI_AdtTabla;
            PI_Agrd001.DataBind();

            grd001.HeaderRow.TableSection = TableRowSection.TableHeader;
            grd002.HeaderRow.TableSection = TableRowSection.TableHeader;
            
            for (int i = 0; i < PI_Agrd001.Rows.Count; i++)
            {
                PI_Agrd001.Rows[i].Cells[4].Enabled = (PI_Agrd001.Rows[i].Cells[5].Text == "1");

            //    if (PI_Agrd001.Rows[i].Cells[6].Text == "1")
            //    { PI_Agrd001.Rows[i].Cells[4].Enabled = true; } // el 4 es el "quitar"
            //    else
            //    { PI_Agrd001.Rows[i].Cells[4].Enabled = false; }

            //    int val = pin.chek_interv_evento(PI_Agrd001.Rows[i].Cells[6].Text);
            //    if (val != 0)
            //    { PI_Agrd001.Rows[i].Cells[5].Enabled = false; } // el 5 es el grupo de intervencion
            //    else
            //    { PI_Agrd001.Rows[i].Cells[5].Enabled = true; }
            }
            muestra_pestaña(C_IDTAB_AREA);
        }
    }
    #endregion

    #region frame_datos

    private void PIgetTrabajadores()
    {
        if (Session["PI_Trabajadores"] != null)
        {
            DataTable dv1 = new DataTable();
            dv1 = ((DataSet)Session["PI_Trabajadores"]).Tables[0];
            DataView view = new DataView(dv1);

            PIddown001.DataSource = view;
            PIddown001.DataTextField = "NombreCompleto";
            PIddown001.DataValueField = "ICodTrabajador";
            view.Sort = "NombreCompleto";
            PIddown001.DataBind();
        }
    }

    protected void PIwdc001_ValueChanged(object sender, EventArgs e)
    {
        try
        {
            PICalendarExtender_wdc002.StartDate = Convert.ToDateTime(PIwdc001.Text);
            PI_FCalendarExtender_wdc001.StartDate = Convert.ToDateTime(PIwdc001.Text);
            PI_FCalendarExtender_wdc001.EndDate = DateTime.Now;
            PIwdc002.Enabled = true;
            //PICalendarExtender_wdc002.EndDate = DateTime.Now;

            if (ConfigurationSettings.AppSettings["Cierre_mes"].ToString() == "1")
            {
                diagnosticoscoll dcoll = new diagnosticoscoll();
                string ano = ((DateTime.Parse(PIwdc001.Text)).Year.ToString());
                string mes = ((DateTime.Parse(PIwdc001.Text)).Month.ToString());

                if (mes.Length <= 1)
                { mes = 0 + mes; }

                int Periodo = Convert.ToInt32(ano + mes);
                int Estado_cierre = dcoll.callto_consulta_cierremes(Convert.ToInt32(PIddown001.SelectedValue), Periodo);

                if (Estado_cierre != 1)
                {
                    PIwib001.Visible = true;
                    PIlbl004.Visible = false;
                }
                else
                {
                    PIlbl004.Text = "EL MES ESTA CERRADO";
                    PIlbl004.Visible = true;
                    PIwib001.Visible = false;
                }
            }        
        }
        catch (Exception ex)
        { }


    }

    protected void PIwdc002_ValueChanged(object sender, EventArgs e)
    {
         try
        {
             PICalendarExtender_wdc003.StartDate = Convert.ToDateTime(PIwdc002.Text).AddDays(1);
             PIwdc003.Enabled = true;

        }
         catch (Exception ex)
         { }
    }

    protected void PIwib001b_Click(object sender, EventArgs e)
    {
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis
        if ((bool)Session["Grupo"])
        {
            if (PItxt001.Text.Trim() == "" || PIwdc001.Text == null || PIwdc001.Text.Trim() == "" || PIwdc002.Text == null || PIwdc002.Text.Trim() == "" || PIwdc003.Text == null || PIwdc003.Text.Trim() == "" || PIddown001.SelectedValue == "0")
            {
                if (PItxt001.Text.Trim() == "")
                { PItxt001.BackColor = colorCampoObligatorio; }
                else
                { PItxt001.BackColor = System.Drawing.Color.White; }

                if (PIwdc001.Text == null || PIwdc001.Text.Trim() == "")
                { PIwdc001.BackColor = colorCampoObligatorio; }
                else
                { PIwdc001.BackColor = System.Drawing.Color.White; }

                if (PIwdc002.Text == null || PIwdc002.Text.Trim() == "")
                { PIwdc002.BackColor = colorCampoObligatorio; }
                else
                { PIwdc002.BackColor = System.Drawing.Color.White; }

                if (PIwdc003.Text == null || PIwdc003.Text.Trim() == "")
                { PIwdc003.BackColor = colorCampoObligatorio; }
                else
                { PIwdc003.BackColor = System.Drawing.Color.White; }

                if (PIddown001.SelectedValue == "0")
                { PIddown001.BackColor = colorCampoObligatorio; }
                else
                { PIddown001.BackColor = System.Drawing.Color.White; }
            }
            else
            {
                PItxt001.BackColor = System.Drawing.Color.White;
                PIwdc001.BackColor = System.Drawing.Color.White;
                PIwdc002.BackColor = System.Drawing.Color.White;
                PIwdc003.BackColor = System.Drawing.Color.White;
                PIddown001.BackColor = System.Drawing.Color.White;
                //lblTitPIIdent.Visible = false;
                Session["PI_FechaTermino"] = PIwdc002.Text;

                //RegisterClientScriptBlock("CambioTab", "<script>window.parent.LlamaTab(1);</script>");
                muestra_pestaña(C_IDTAB_AREA);
                PI_AgetTipoIntervencion();
                PI_AgetNivelIntervencion();
                PI_AArmaTabla();
            }
        }
        else
        {
            if (PIwdc001.Text == null || PIwdc001.Text.Trim() == "" || PIwdc002.Text == null || PIwdc002.Text.Trim() == "" || PIwdc003.Text == null || PIwdc003.Text.Trim() == "" || PIddown001.SelectedValue == "0")
            {
                if (PIwdc001.Text == null || PIwdc001.Text.Trim() == "")
                { PIwdc001.BackColor = colorCampoObligatorio; }
                else
                { PIwdc001.BackColor = System.Drawing.Color.White; }

                if (PIwdc002.Text == null || PIwdc002.Text.Trim() == "")
                { PIwdc002.BackColor = colorCampoObligatorio; }
                else
                { PIwdc002.BackColor = System.Drawing.Color.White; }

                if (PIwdc003.Text == null || PIwdc003.Text.Trim() == "")
                { PIwdc003.BackColor = colorCampoObligatorio; }
                else
                { PIwdc003.BackColor = System.Drawing.Color.White; }

                if (PIddown001.SelectedValue == "0")
                { PIddown001.BackColor = colorCampoObligatorio; }
                else
                { PIddown001.BackColor = System.Drawing.Color.White; }
            }
            else
            {
                PIwdc001.BackColor = System.Drawing.Color.White;
                PIwdc002.BackColor = System.Drawing.Color.White;
                PIwdc003.BackColor = System.Drawing.Color.White;
                PIddown001.BackColor = System.Drawing.Color.White;
                //lblTitPIIdent.Visible = false;
                Session["PI_FechaTermino"] = PIwdc002.Text;

                //RegisterClientScriptBlock("CambioTab", "<script>window.parent.LlamaTab(1);</script>");
                muestra_pestaña(C_IDTAB_AREA);
                PI_AgetTipoIntervencion();
                PI_AgetNivelIntervencion();
                PI_AArmaTabla();
                
            }
        }
    }

    #endregion

    private void getGradoCumplimiento()
    {
        pintervencion pcoll = new pintervencion();
        DataSet dv1 = new DataSet();
        dv1.Tables.Add(pcoll.GetparGradoCumplimiento());
        Session["PI_GradoCumplimiento"] = dv1;
    }
    private void getNivelIntervencion()
    {
        parcoll pcoll = new parcoll();
        DataSet dv1 = new DataSet();
        dv1.Tables.Add(pcoll.GetparNivelIntervencion());
        Session["PI_NivelIntervencion"] = dv1;
    }
    private void getInstituciones()
    {
        institucioncoll ncoll = new institucioncoll();
        DataView dv1 = new DataView(ncoll.GetData(Convert.ToInt32(Session["IdUsuario"])));
        ddown001.DataSource = dv1;
        ddown001.DataTextField = "Nombre";
        ddown001.DataValueField = "CodInstitucion";
        dv1.Sort = "Nombre";
        ddown001.DataBind();
        ddown001.DataBind();
        // <---------- DPL ---------->  09-08-2010
        if (dv1.Count == 2)
        {
            //ddown001.SelectedIndex = 1;
            ddown001_SelectedIndexChanged(new object(), new EventArgs());
        }
        else
        {
            ddown001.SelectedIndex = 0;
        }
        // <---------- DPL ---------->  09-08-2010
        //--------------------------------------------------------
        //institucioncoll ncoll = new institucioncoll();
        //DataSet dv1 = new DataSet();
        //dv1.Tables.Add(ncoll.GetData(Convert.ToInt32(Session["IdUsuario"])));
        //ddown001.DataSource = dv1;
        //ddown001.DataTextField = "Nombre";
        //ddown001.DataValueField = "CodInstitucion";
        //dv1.Tables[0].DefaultView.Sort = "Nombre";
        //ddown001.DataBind();
         //<---------- DPL ---------->  09-08-2010
        //if (dv1.Tables[0].Rows.Count > 0)
        //{
        //    ddown001.SelectedIndex = 1;
        //    ddown001_SelectedIndexChanged(new object(), new EventArgs());
        //}
         //<---------- DPL ---------->  09-08-2010
    }
    private void getProyectosPorCodigo()
    {
        //proyectocoll pcoll = new proyectocoll();
        //DataView dv = new DataView(pcoll.GetData(Convert.ToInt32(Session["IdUsuario"]), "V", Convert.ToInt32(ddown001.SelectedValue)));
        //dv.Sort = "Nombre";
        //dv.RowFilter = "isnull(CodModeloIntervencion, 0) not in(115, 111, 113)";       // Excluye a los PER (programas de Residencias), PDC y PDE
        //ddown002.DataSource = dv;
        //ddown002.DataTextField = "Nombre";
        //ddown002.DataValueField = "CodProyecto";
        //ddown002.DataBind();
        //if (dv.Count == 2)
        //{
        //    ddown002.SelectedIndex = 1;
        //    ddown002_SelectedIndexChanged(new object(), new EventArgs());
        //}
        //------------------
        proyectocoll pcoll = new proyectocoll();
        DataSet dv = new DataSet();
        dv.Tables.Add(pcoll.GetData(Convert.ToInt32(Session["IdUsuario"]), "V", Convert.ToInt32(ddown001.SelectedValue)));
        dv.Tables[0].DefaultView.Sort = "nombre";
        // <---------- DPL ---------->  09-08-2010
        dv.Tables[0].DefaultView.RowFilter = "isnull(CodModeloIntervencion, 0) not in(115, 111, 113)";       // Excluye a los PER (programas de Residencias), PDC y PDE
        // <---------- DPL ---------->  09-08-2010
        ddown002.DataSource = dv.Tables[0].DefaultView;
        ddown002.DataTextField = "nombre";
        ddown002.DataValueField = "CodProyecto";
        ddown002.DataBind();
        if (dv.Tables[0].Rows.Count == 2)
        {
            //ddown002.SelectedIndex = 1;
            ddown002_SelectedIndexChanged(new object(), new EventArgs());
        }
        //else
        //{
        //    ddown002.SelectedIndex = 0;
        //}

        

    }
    private void getTrabajadores()
    {
        trabajadorescoll tcoll = new trabajadorescoll();
        if (CodProyecto == null)
        { CodProyecto = "0"; }
        DataSet dv1 = new DataSet();
        dv1.Tables.Add(tcoll.GetTrabajadoresProyecto(CodProyecto));
        Session["PI_Trabajadores"] = dv1;
    }
    private void getTipoIntervencion()
    {
        parcoll pcoll = new parcoll();
        DataSet dv1 = new DataSet();
        dv1.Tables.Add(pcoll.GetparEventosIntervencionCantidadxModelo(Convert.ToInt32(ddown002.SelectedValue)));
        Session["PI_TipoIntervencion"] = dv1;
    }
    private void getEstadoIntervencion()
    {
        pintervencion pcoll = new pintervencion();
        DataSet dv1 = new DataSet();
        dv1.Tables.Add(pcoll.GetparEStadoIntervencion());
        Session["PI_EstadoIntervencion"] = dv1;
    }
    private void getPersonaRelacionada(int CodIE)
    {
        pintervencion pcoll = new pintervencion();
        DataSet dv1 = new DataSet();
        dv1.Tables.Add(pcoll.GetPersonaRelacionadaNinos(CodIE));
        Session["PI_Quien"] = dv1;
    }

    private void Carga_Ninos_Plan()
    {
        pintervencion pii = new pintervencion();
        DataTable dt = pii.GetNinosProyecto(Convert.ToInt32(ddown002.SelectedValue));
        DVNinos = new DataSet();
        DVNinos.Tables.Add(dt);

        CodProyecto = ddown002.SelectedValue;
        CodInstitucion = ddown001.SelectedValue;
        //getTipoIntervencion(Convert.ToInt32(CodProyecto));

        //CargaGrilla(txt001.Text.Trim());
        CargaGrilla(TextBox2.Text.Trim(), txt001.Text.Trim(), TextBox1.Text.Trim());

        if (grd001.Rows.Count > 0)
        {
            trgrd001.Visible = true;
            ddown002.Enabled = false;
            //btnbuscar.Visible = false; se oculta el filtrar ahora
            btnbuscar.Visible = true;
            ddown001.Enabled = false;
            txt001.Enabled = true;
            TextBox1.Enabled = true;
            TextBox2.Enabled = true;
            wib002.Visible = true;
            //lbl002.Visible = true;
            
            trmenu.Visible = true;
            generarGrd001HashMap();//gfontbrevis
        }
        else
        {
          btnbuscar.Visible = true;
            ddown002.Enabled = true;
            btnbuscar.Visible = true;
            ddown001.Enabled = true;
            txt001.Enabled = false;
            TextBox1.Enabled = false;
            TextBox2.Enabled = false;
            //lbl002.Visible = false;
            wib002.Visible = false;
            trmenu.Visible = false;
        }

        getTrabajadores();
        lbl_resumen_filtro.Text = "<br>";
        lbl_resumen_filtro.Text += "<strong>Busqueda: </strong>";
        //lbl_resumen_filtro.Text += "- Institución: " + ddown001.SelectedItem.Text + "<br>";
        lbl_resumen_filtro.Text += "" + ddown002.SelectedItem.Text + " ";
        

        lbl_resumen_filtro.Visible = true;
        lbl_resumen_filtro.Style.Add("display", "none");
        //ScriptManager.RegisterStartupScript(this, typeof(string), "esconderForm", "clickCollapse();", true);

    }
    private void CargaGrilla(string Filtro)
    {
        DataSet dv = DVNinos;
        grd001.Columns[1].Visible = false;

        //grd001.Page.Items.Clear();
        if (Filtro.Trim() != "")
        { dv.Tables[0].DefaultView.RowFilter = "Apellido_paterno LIKE '" + Filtro.ToUpper() + "%'"; }
        else
        { dv.Tables[0].DefaultView.RowFilter = "Apellido_paterno LIKE '%'"; }

        dv.Tables[0].DefaultView.Sort = "Apellido_paterno";
        grd001.DataSource = dv.Tables[0].DefaultView;
        grd001.DataBind();
        if (grd001.Rows.Count > 0)
        {
            grd001.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        //grd002.HeaderRow.TableSection = TableRowSection.TableHeader;

        if (grd001.Rows.Count > 15)
        {
            //ScriptManager.RegisterStartupScript(this, GetType(), "fixNHeaders", "fixNHeaders('#grd001', '#tableHeader1','#tableContainer1',1);", true);
            //ScriptManager.RegisterStartupScript(this, GetType(), "fixHeader_", "fixHeader_('#grd001', '1' );", true);

        }
    }

    private void CargaGrilla(string nombres, string apellidoPaterno, string apellidoMaterno)
    {
        DataSet dv = DVNinos;
        grd001.Columns[1].Visible = false;

        bool filtroNombres = false, filtroApellidoPaterno = false, filtroApellidoMaterno = false;

        #region valida Datos
        if (!string.IsNullOrEmpty(nombres))
        {
            filtroNombres = true;
        }

        if (!string.IsNullOrEmpty(apellidoPaterno))
        {
            filtroApellidoPaterno = true;
        }

        if (!string.IsNullOrEmpty(apellidoMaterno))
        {
            filtroApellidoMaterno = true;
        }
        #endregion
        

        if (filtroNombres && filtroApellidoPaterno && filtroApellidoMaterno)
        {
            dv.Tables[0].DefaultView.RowFilter = "Nombres LIKE '" + nombres + "%' AND Apellido_paterno LIKE '" + apellidoPaterno + "' AND Apellido_materno LIKE '" + apellidoMaterno + "'";
        }
        else if(filtroNombres && filtroApellidoPaterno)
        {
            dv.Tables[0].DefaultView.RowFilter = "Nombres LIKE '" + nombres + "%' AND Apellido_paterno LIKE '" + apellidoMaterno + "'";
        }
        else if (filtroNombres && filtroApellidoMaterno)
        {
            dv.Tables[0].DefaultView.RowFilter = "Nombres LIKE '" + nombres + "%' AND Apellido_materno LIKE '" + apellidoMaterno + "'";
        }
        else if (filtroApellidoPaterno && filtroApellidoMaterno)
        {
            dv.Tables[0].DefaultView.RowFilter = "Apellido_paterno LIKE '" + apellidoPaterno + "%' AND Apellido_materno LIKE '" + apellidoMaterno + "'";
        }
        else if (filtroNombres)
        {
            dv.Tables[0].DefaultView.RowFilter = "Nombres LIKE '" + nombres + "%'";
        }
        else if (filtroApellidoPaterno)
        {
            dv.Tables[0].DefaultView.RowFilter = "Apellido_paterno LIKE '" + apellidoPaterno + "%'";
        }
        else if (filtroApellidoMaterno)
        {
            dv.Tables[0].DefaultView.RowFilter = "Apellido_materno LIKE '" + apellidoMaterno + "%'";
        }
        else
        {
            dv.Tables[0].DefaultView.RowFilter = "Apellido_paterno LIKE '%'"; 
        }

        dv.Tables[0].DefaultView.Sort = "Apellido_paterno";
        grd001.DataSource = dv.Tables[0].DefaultView;
        grd001.DataBind();
        if (grd001.Rows.Count > 0)
        {
            grd001.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        //grd002.HeaderRow.TableSection = TableRowSection.TableHeader;

        if (grd001.Rows.Count > 15)
        {
            //ScriptManager.RegisterStartupScript(this, GetType(), "fixNHeaders", "fixNHeaders('#grd001', '#tableHeader1','#tableContainer1',1);", true);
            //ScriptManager.RegisterStartupScript(this, GetType(), "fixHeader_", "fixHeader_('#grd001', '1' );", true);

        }


    }

    private void generarGrd001HashMap() {
        /*gfontbrevis
         * funcion que genera hash map CodNino->N°Fila, usado para poner simbolo ok en niños ya agregados
         * TODO: se cae al cambiar de pagina.
         */
        grd001_hash_map.Clear();
        for (int i = 0; i < grd001.Rows.Count; i++) {
            grd001_hash_map.Add(grd001.Rows[i].Cells[0].Text , i);
        
        }
           
    }
    private void mostrarIconoOkGrd001() {
        /*gfontbrevis
         * llamada por command agregar y command quitar, para actualizar iconos ok segun contenido de grd002.
         */
        for (int i = 0; i < grd002.Rows.Count; i++) { 
            string codigo_nino= grd002.Rows[i].Cells[1].Text;
            int fila = grd001_hash_map[codigo_nino];
            grd001.Rows[fila].Cells[10].Text = "<span class='glyphicon glyphicon-ok-sign' style='color:green;' ></span>";
        }
    
    }
    private void Limpiagrd002()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("CodNino", typeof(int))); //0
        dt.Columns.Add(new DataColumn("ICodIE", typeof(int))); //1
        dt.Columns.Add(new DataColumn("Rut", typeof(string))); //2
        dt.Columns.Add(new DataColumn("Apellido_paterno", typeof(string))); //5
        dt.Columns.Add(new DataColumn("Apellido_Materno", typeof(string))); //6   
        dt.Columns.Add(new DataColumn("Nombres", typeof(string)));    //4
        dt.Columns.Add(new DataColumn("Sexo", typeof(string)));       //3
        dt.Columns.Add(new DataColumn("FechaNacimiento", typeof(DateTime)));  //8
        dt.Columns.Add(new DataColumn("FechaIngreso", typeof(DateTime)));  //7
        grd002.DataSource = dt;
        grd002.DataBind();
    }
    private void Agrega_Ninos(GridViewCommandEventArgs e)
    {

        int var = 0;
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add(new DataColumn("CodNino", typeof(int))); //0
        dt.Columns.Add(new DataColumn("ICodIE", typeof(int))); //1
        dt.Columns.Add(new DataColumn("Rut", typeof(string))); //2
        dt.Columns.Add(new DataColumn("Apellido_paterno", typeof(string))); //5
        dt.Columns.Add(new DataColumn("Apellido_Materno", typeof(string))); //6   
        dt.Columns.Add(new DataColumn("Nombres", typeof(string)));    //4
        dt.Columns.Add(new DataColumn("Sexo", typeof(string)));       //3

        dt.Columns.Add(new DataColumn("FechaNacimiento", typeof(DateTime)));  //8
        //dt.Columns.Add(new DataColumn("FechaNacimiento", typeof(string)));  //8

        dt.Columns.Add(new DataColumn("FechaIngreso", typeof(DateTime)));  //7
        

        for (int i = 0; i < grd002.Rows.Count; i++)
        {
            dr = dt.NewRow();
            dr[0] = HttpUtility.HtmlDecode(grd002.Rows[i].Cells[1].Text);
            dr[1] = HttpUtility.HtmlDecode(grd002.Rows[i].Cells[2].Text);
            dr[2] = HttpUtility.HtmlDecode(grd002.Rows[i].Cells[3].Text);
            dr[3] = HttpUtility.HtmlDecode(grd002.Rows[i].Cells[4].Text);
            dr[4] = HttpUtility.HtmlDecode(grd002.Rows[i].Cells[5].Text);
            dr[5] = HttpUtility.HtmlDecode(grd002.Rows[i].Cells[6].Text);
            dr[6] = HttpUtility.HtmlDecode(grd002.Rows[i].Cells[7].Text);

            try
            { dr[7] = Convert.ToDateTime(grd002.Rows[i].Cells[8].Text).ToShortDateString(); }
            catch
            //{ dr[7] = Convert.ToDateTime("01/01/1900").ToShortDateString(); }
            { }
            try
            { dr[8] = Convert.ToDateTime(grd002.Rows[i].Cells[9].Text).ToShortDateString(); }
            catch
            { dr[8] = Convert.ToDateTime("01/01/1900").ToShortDateString(); }

            dt.Rows.Add(dr);
        }

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text == grd002.Rows[i].Cells[1].Text)
            { var = 1; }
        }

        if (var == 0)
        {
            dr = dt.NewRow();
            dr[0] = HttpUtility.HtmlDecode(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text);
            dr[1] = HttpUtility.HtmlDecode(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text);
            dr[2] = HttpUtility.HtmlDecode(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text);
            dr[3] = HttpUtility.HtmlDecode(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Text);
            dr[4] = HttpUtility.HtmlDecode(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Text);
            dr[5] = HttpUtility.HtmlDecode(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[6].Text);
            dr[6] = HttpUtility.HtmlDecode(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[7].Text);

            if ((HttpUtility.HtmlDecode(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[8].Text)).Trim() != "")
            {
                dr[7] = (HttpUtility.HtmlDecode(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[8].Text)).Trim();
            }

            try
            { dr[8] = grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[9].Text; }
            catch { }
            dt.Rows.Add(dr);

            //grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[10].Visible = false;//gfontbrevis
            //grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[10].Enabled = false;
            //grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[10].Text="<span class='glyphicon glyphicon-ok-sign' ></span>";
            //grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[10].BackColor = System.Drawing.Color.Green;
            //grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[10].Attributes.Add("Class","glyphicon glyphicon-ok-sign");
            //TODO: hacer funcion que chequee todos las filas de grd002: y cambie el texto por "<span class='glyphicon glyphicon-ok-sign' ></span>";
            //mostrarIconoOkGrd001();
            if (dt.Rows.Count > 0)
            {
                Session["PI_TablaNinosPlan"] = dt;
                grd002.DataSource = dt;
                grd002.DataBind();
                grd002.Visible = true;
                //wib001.Visible = true;
                wib001.Visible = true;
                lbl001.Visible = true;
                
            }
            else
            {
                lbl001.Visible = true;
                grd002.Visible = false;
                //wib001.Visible = false;
                wib001.Visible = false;
            }
        }
        else
        {
            alerts.Attributes.Add("style", "");
            lbl005.Text = "El niño seleccionado ya ha sido ingresado.";
            lbl005.Attributes.Add("style", "");  
            //lbl003.Text = ".";
            //lbl003.Visible = true;
        }
    }

    //protected void imb001_Click(object sender, ImageClickEventArgs e)
    //{
    //    string etiqueta = "Plan de Intervencion";
    //    window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_ninos/plan_intervencion_new.aspx", "Buscador", false, true, 500, 650, false, false, true);
    //    //Response.Redirect("'../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_ninos/plan_intervencion_new.aspx', 'Buscador', false, true, '500', '650', false, false, true");        
    //}
    //protected void imb002_Click(object sender, ImageClickEventArgs e)
    //{
    //    string etiqueta = "Busca Proyectos";
    //    window.open(this.Page, "../mod_instituciones/bsc_institucion.aspx?param001=" + etiqueta + "&dir=../mod_ninos/plan_intervencion_new.aspx", "Buscador", false, true, 770, 420, false, false, true);
    //}
    protected void ddown001_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        if (Session["NNA"] == null)
        {
            oNNA NNA = new oNNA();
            NNA.NNACodInstitucion = ddown001.SelectedValue;
            Session["NNA"] = NNA;
        }

        else
        {
            oNNA NNA = (oNNA)Session["NNA"];
            NNA.NNACodInstitucion = ddown001.SelectedValue;
        }
        
        getProyectosPorCodigo();
    }
    protected void ddown002_SelectedIndexChanged(object sender, EventArgs e)
    {
        oNNA NNA = (oNNA)Session["NNA"];
        NNA.NNACodInstitucion = ddown001.SelectedValue;
        NNA.NNACodProyecto = ddown002.SelectedValue;
        Session["NNA"] = NNA;
        Carga_Ninos_Plan();
        //ScriptManager.RegisterStartupScript(this, GetType(), "", "clickCollapse();", true);
        wib002_Click(sender, e);
        btnbuscar.Visible = false;  
    }
    protected void btnbuscar_Click(object sender, EventArgs e)
    {
        Carga_Ninos_Plan();
        wib002_Click(sender, e);
        btnbuscar.Visible = false;
    }  
    protected void grd001_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Agregar")
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "", "clickCollapse();", true);
                pintervencion pin = new pintervencion();
                int Existe;

                if (grd002.Rows.Count < 20)
                {
                    Existe = pin.get_planintervencion_vigente(Convert.ToInt32(grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text));
                    //grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[10].Text = "<span class='glyphicon glyphicon-ok-sign' style='color:green;' ></span>";
                    switch (Existe)
                    {

                        case 0:
                            if (Check != 2)
                            {

                                lbl003.Visible = false;
                                Agrega_Ninos(e);
                            }
                            break;
                        case 1:
                            alerts.Attributes.Add("style", "");
                            lbl005.Text = "El niño seleccionado solo puede ser ingresado Grupalmente.<br> Ya existe en un plan Individual.";
                            lbl005.Attributes.Add("style", "");
                            //lbl003.Text = "";
                            //lbl003.Visible = true;
                            Check = 1;
                            Agrega_Ninos(e);
                            if (grd002.Rows.Count > 1)
                            { wib001.Visible = true; }
                            else
                            { wib001.Visible = false; }
                            break;
                        case 2:
                            alerts.Attributes.Add("style", "");
                            lbl005.Text = "El niño seleccionado solo puede ser ingresado Individualmente.<br> Ya existe en un plan Grupal";
                            lbl005.Attributes.Add("style", "");
                            //lbl003.Text = ".";
                            //lbl003.Visible = true;

                            if (grd002.Rows.Count == 0)
                            {
                                Check = 2;
                                Agrega_Ninos(e);
                                grd001.Columns[9].Visible = false;//gfontbrevis todo:corregir, debiera ser 10?????
                            }
                            break;
                        case 3:
                            alerts.Attributes.Add("style", "");
                            lbl005.Text = "El niño seleccionado no puede ser ingresado.<br> Ya existe en forma grupal e individual en otros planes.";
                            lbl005.Attributes.Add("style", "");
                            //lbl003.Text = "";
                            //lbl003.Visible = true;
                            Check = 3;
                            break;
                    }
                }
                //gfontbrevis
                // LO quito temporalmente, ya lo aplico directamente sobre la fila seleccionada por el evento row_command JVR
                if (grd002.Rows.Count > 0)
                {
                    mostrarIconoOkGrd001();
                }

                if (grd001.Rows.Count > 15)
                {
                    //ScriptManager.RegisterStartupScript(this, GetType(), "fixNHeaders", "fixNHeaders('#grd001', '#tableHeader1','#tableContainer1',1);", true);
                    //ScriptManager.RegisterStartupScript(this, GetType(), "fixHeader_", "fixHeader_('#grd001', '1' );", true);
                }
                grd001.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
        }
        catch (Exception ex)
        {
            Log(ex.Message + " " + ex.InnerException);
        }
    }
    
    protected void grd002_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Quitar")
        {
            for (int i = 0; i < grd001.Rows.Count; i++)
            {
                if (grd002.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text == grd001.Rows[i].Cells[0].Text)
                {
                    grd001.Rows[i].Cells[10].Visible = true;

                    grd001.Columns[10].Visible = true;
                    lbl003.Visible = false;
                }
            }

            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new DataColumn("CodNino", typeof(int))); //0
            dt.Columns.Add(new DataColumn("ICodIE", typeof(int))); //1
            dt.Columns.Add(new DataColumn("Rut", typeof(string))); //2
            dt.Columns.Add(new DataColumn("Sexo", typeof(string)));       //3
            dt.Columns.Add(new DataColumn("Nombres", typeof(string)));    //4
            dt.Columns.Add(new DataColumn("Apellido_paterno", typeof(string))); //5
            dt.Columns.Add(new DataColumn("Apellido_Materno", typeof(string))); //6   
            dt.Columns.Add(new DataColumn("FechaNacimiento", typeof(DateTime)));  //7
            dt.Columns.Add(new DataColumn("FechaIngreso", typeof(DateTime)));  //8
            

            for (int i = 0; i < grd002.Rows.Count; i++)
            {
                dr = dt.NewRow();
                dr[0] = grd002.Rows[i].Cells[1].Text;
                dr[1] = grd002.Rows[i].Cells[2].Text;
                dr[2] = grd002.Rows[i].Cells[3].Text;
                dr[3] = grd002.Rows[i].Cells[4].Text;
                dr[4] = grd002.Rows[i].Cells[5].Text;
                dr[5] = grd002.Rows[i].Cells[6].Text;
                dr[6] = grd002.Rows[i].Cells[7].Text;
                try
                {
                    dr[7] = Convert.ToDateTime(grd002.Rows[i].Cells[8].Text).ToShortDateString();
                }
                catch { }
                dr[8] = Convert.ToDateTime(grd002.Rows[i].Cells[9].Text).ToShortDateString();                
                dt.Rows.Add(dr);
            }

            dt.Rows.Remove(dt.Rows[Convert.ToInt32(e.CommandArgument)]);
            if (Check == 2) Check = 0;
                        
            if (dt.Rows.Count > 0)
            {
                grd002.DataSource = dt;
                grd002.DataBind();
                grd002.Visible = true;
                wib001.Visible = true;
            }
            else
            {
                wib001.Visible = false;
                grd002.Visible = false;
                DataTable dt2 = new DataTable();
                grd002.DataSource = dt2;
                grd002.DataBind();
            }
        }
        //gfontbrevis
        if (grd002.Rows.Count > 0)
        {
            mostrarIconoOkGrd001();
        }

        grd001.HeaderRow.TableSection = TableRowSection.TableHeader;
    }



    protected void grd001_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        lbl003.Visible = false; 
        grd001.Columns[1].Visible = false;
        grd001.PageIndex = e.NewPageIndex;
        CargaGrilla(txt001.Text.Trim());
        wib002_Click(sender, e);
        //ScriptManager.RegisterStartupScript(this, GetType(), "", "clickCollapse();", true);
    }
    
    protected void lnk002_Click(object sender, EventArgs e)
    {
        if (ddown001.SelectedValue != "" && ddown002.SelectedValue != "")
        {
            Carga_Ninos_Plan();

        }
    }
  
    protected void lnb003_Click(object sender, EventArgs e)
    {
        //Response.Redirect("index_pintervencion.aspx");
        Carga_Ninos_Plan();
        //utab.Visible = false;
        DataTable dt = new DataTable();
        grd002.DataSource = dt;
        grd002.DataBind();
        lbl001.Visible = false;
        lbl003.Visible = false;
        wib001.Visible = false;
        grd001.PageIndex = 0;
        //utab.ActiveTabIndex = 0;
        //utab.Tabs[1].Visible = false;
        //utab.Tabs[2].Visible = false;
        //utab.Tabs[3].Visible = false;
        //utab.Tabs[4].Visible = false;
    }

    protected void wib002_Click(object sender, EventArgs e)
    {
        pintervencion pi = new pintervencion();
        string grupal = "";
        grd001.Columns[1].Visible = true;

        for (int i = 0; i < grd001.Rows.Count; i++)
        {
            int retorno = pi.callto_get_planintervencion_vigente(Convert.ToInt32(grd001.Rows[i].Cells[2].Text));

            switch (retorno)
            {
                case 0:
                    grupal = "No Asignado";
                    break;
                case 1:
                    grupal = "Individual";
                    break;
                case 2:
                    grupal = "Grupal";
                    break;
                case 3:
                    grupal = "Grupal e Individual";
                    break;
            }

            grd001.Rows[i].Cells[1].Text = grupal;
        }
    }

    protected void wib001_Click(object sender, EventArgs e) // crear plan de intervención
    {
        DateTime FecMin = Convert.ToDateTime(grd002.Rows[0].Cells[9].Text); // C.E.T se modifica de columna 8 a 9 ya que se modifico anteriormente el orden visual del grd002

        for (int i = 1; i < grd002.Rows.Count; i++) 
        {
            if (Convert.ToDateTime(grd002.Rows[i].Cells[9].Text) < FecMin)
            { FecMin = Convert.ToDateTime(grd002.Rows[i].Cells[9].Text); }
        }

        Session["PI_FechaMinMax"] = FecMin + "|" + DateTime.Now;

        PI_AdtTabla = null;
        Session["PI_EstadoIntervencion"] = null;
        PI_CdtTabla = null;
        Session["PI_GradoCumplimiento"] = null;
        ViewState["TabActivo"] = null;

        //muestra_pestaña(1);

        if (grd002.Rows.Count > 0)
        {
            txt001.Enabled = false;
            TextBox1.Enabled = false;
            TextBox2.Enabled = false;
            Button1.Visible = false;

            //lbl002.Visible = false;
            wib002.Visible = false;
            trmenu.Visible = false;

            //utab.Visible = true;
            div_panel.Visible = true;
            
            
            if (grd002.Rows.Count > 1)
            { 
                Session["Grupo"] = true;
                //lblTitPIIdent.Visible = true;
                PItxt001.Visible = true;
                lblTitPIIdent.Visible = true;
                //txt001.Visible = false;
                //TextBox1.Visible = false;
                //TextBox2.Visible = false;
                tr_Nombres.Visible = false;
                tr_apellidoPaterno.Visible = false;
                tr_apellidoMaterno.Visible = false;
                PIwdc002.Enabled = false;
                PIwdc003.Enabled = false;
            }
            else
            { 
                Session["Grupo"] = false;
                //lblTitPIIdent.Visible = false;
                PItxt001.Visible = false;
                lblTitPIIdent.Visible = false;
                TextBox2.Text = HttpUtility.HtmlDecode(grd002.Rows[0].Cells[6].Text);
                TextBox1.Text = HttpUtility.HtmlDecode(grd002.Rows[0].Cells[4].Text);
                txt001.Text = HttpUtility.HtmlDecode(grd002.Rows[0].Cells[5].Text);
                PIwdc002.Enabled = false;
                PIwdc003.Enabled = false;
            }


            //if (Session["Grupo"] != null)
            //    if ((bool)Session["Grupo"])
            //    {
            //        lblTitPIIdent.Visible = true;
            //        PItxt001.Visible = true;
            //    }
            //    else
            //    {
            //        lblTitPIIdent.Visible = false;
            //        PItxt001.Visible = false;
            //    }
            if (Session["PI_FechaMinMax"] != null)
            {
                if (Session["PI_FechaMinMax"].ToString() != "")
                {
                    char[] chrSeparador = { '|' };
                    string[] strFechas = Session["PI_FechaMinMax"].ToString().Split(chrSeparador);

                    PICalendarExtender_wdc001.StartDate = Convert.ToDateTime(strFechas[0]);
                    PICalendarExtender_wdc001.EndDate = Convert.ToDateTime(strFechas[1]);
                                     

                    RV_PIwdc001.MinimumValue = Convert.ToDateTime(strFechas[0]).ToShortDateString();
                    RV_PIwdc001.MaximumValue = Convert.ToDateTime(strFechas[1]).ToShortDateString();


                }
            }
            PIgetTrabajadores();

            //GMP utab.Tabs[0].Visible = true;
            tab1.Attributes.Add("class", "tab-pane fade in active");
            li_nav1.Attributes.Add("class", "active");

            trgrd001.Visible = false;
            wib002.Visible = false;

            grd002.Columns[10].Visible = false;
            wib001.Visible = false;

            //imb001.Visible = false;



            getTrabajadores();
            getEstadoIntervencion();
            getGradoCumplimiento();
            getTipoIntervencion();
            getNivelIntervencion();

            if (grd002.Rows.Count == 1)
            { getPersonaRelacionada(Convert.ToInt32(grd002.Rows[0].Cells[2].Text)); }

            string strCodPlan;

            if (grd002.Columns[0].Visible)
            { strCodPlan = grd002.Rows[0].Cells[0].Text; }
            else
            { strCodPlan = "-1"; }

            //Session["PI_registro_inicio"] = strCodPlan + "|" + grd002.Rows[0].Cells[2].Text + "|" + ddown002.SelectedValue + "|" + grd002.Rows[0].Cells[1].Text + "|" + grd002.Rows[0].Cells[8].Text;

            if (Convert.ToInt32(ddown002.Text) > 0)
            {
                string strSQL = "SELECT CodCausalTerminoProyecto FROM Proyectos WHERE CodProyecto = " + ddown002.Text;
                parcoll pcoll = new parcoll();
                DataSet dv1 = new DataSet();
                dv1.Tables.Add(pcoll.ejecuta_SQL(strSQL));
                if (dv1.Tables[0].Rows[0][0].ToString() == "20084")
                    Session["PI_FechaMinMax"] = "01-01-1900" + "|" + DateTime.Now;

                
            }

            PIwdc002.Enabled = false;
            PIwdc003.Enabled = false;

            lbl_resumen_filtro.Text = "";
            lbl_resumen_filtro.Text = "<strong>Busqueda </strong>";

            if (ddown002.SelectedIndex != 0)
            {
                lbl_resumen_filtro.Text += "" + ddown002.SelectedItem.Text.Trim() + " ";
            }
            if (txt001.Text.Trim() != "")
            {
                lbl_resumen_filtro.Text += "//" + " " + txt001.Text.Trim() + " ";
            }
            if (TextBox1.Text.Trim() != "")
            {
                lbl_resumen_filtro.Text += " " + TextBox1.Text + " ";
            }
            if (TextBox2.Text.Trim() != "")
            {
                lbl_resumen_filtro.Text += "" + TextBox2.Text + " ";
            }
           

            lbl_resumen_filtro.Visible = true;
            lbl_resumen_filtro.Style.Add("display", "none");
            //gfontbrevis
            if ((bool)Session["Grupo"])
            {
                li_nav4.Attributes.Add("style", "display:none");
                link_tab4.Attributes.Add("style", "display:none");

            }
            else
            {
                li_nav5.Attributes.Add("style", "display:none");
                link_tab5.Attributes.Add("style", "display:none");
            }
        }
        else
        {
            //utab.Visible = false;
            //utab.Tabs[0].Visible = false;

            trgrd001.Visible = true;
            wib002.Visible = true;

            grd002.Columns[10].Visible = true;
            wib001.Visible = true;
            //imb001.Visible = true;
        }
    }

    // boton limpiar
    protected void wib003_Click(object sender, EventArgs e)
    {
        wib002.Visible = false;
      wib001.Visible = false;
      alerts.Attributes.Add("style", "display:none");
      lbl005.Attributes.Add("style", "display:none");

      alerts2.Attributes.Add("style", "display:none");
      lbl0052.Attributes.Add("style", "display:none");
        // filtro
        ddown001.Enabled = true;
        ddown002.Enabled = true;
        btnbuscar.Visible = true;
        btnbuscar.Visible = true;
        //ddown001.SelectedValue = "0";
        //ddown002.SelectedValue = "0";
        txt001.Enabled = true;
        TextBox1.Enabled = true;
        TextBox2.Enabled = true;
        //txt001.Visible = true;
        //TextBox1.Visible = true;
        //TextBox2.Visible = true;

        tr_Nombres.Visible = true;
        tr_apellidoMaterno.Visible = true;
        tr_apellidoPaterno.Visible= true;
        //ddown001.SelectedIndex = 0;
        //ddown002.SelectedIndex = 0;
        //vacio el AIO
        //oNNA NNA = (oNNA)Session["NNA"];
        //NNA.NNACodInstitucion = "";
        //NNA.NNACodProyecto = "";
        //Session["NNA"] = NNA;

        txt001.Text = "";
        TextBox1.Text = "";
        TextBox2.Text = "";

        Limpiagrd002();
        trgrd001.Visible = false;
        grd002.Visible = false;

        Button1.Visible = false;
        lbl001.Visible = false;
        lbl003.Visible = false;

        //PItxt001.Text = "";
        //PItxt002.Text = "";
        //PIwdc001.Text = "Seleccione Fecha";
        //PIwdc002.Text = "Seleccione Fecha";
        //PIwdc003.Text = "Seleccione Fecha";
        //PIddown001.SelectedIndex = 0;

        //PI_Stxt001.Text = "";
        //PI_Schk001.Checked = false;
        //PI_Schk002.Checked = false;
        //PI_Sddown001.SelectedIndex = 0;

        PI_AdtTabla = null;

        Session["PI_EstadoIntervencion"] = null;
        PI_CdtTabla = null;
        Session["PI_GradoCumplimiento"] = null;
        
        ViewState["TabActivo"] = null;
        muestra_pestaña(1);

        div_panel.Visible = false;
        lbl_resumen_filtro.Text = "";
        //gfontbrevis
        link_tab4.Attributes.Remove("style");
        li_nav4.Attributes.Remove("style");
        link_tab5.Attributes.Remove("style");
        li_nav5.Attributes.Remove("style");

        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //Corrección Temporal al filtrar
        Carga_Ninos_Plan();
        wib002_Click(sender, e);


      ////Materno
      //  if(TextBox1.Text != ""){
      //    CargaGrilla1(TextBox1.Text.Trim());
      //  }
      ////Nombres
      //  else if (TextBox2.Text != "")
      //  {
      //    CargaGrilla2(TextBox2.Text.Trim());
      //    wib002_Click(sender, e);
      //  }
      //  else if (txt001.Text != "")
      //  {
      //    CargaGrilla(txt001.Text.Trim());
      //    wib002_Click(sender, e);
      //  }
      //  else
      //  {
      //    CargaGrilla(txt001.Text.Trim());
      //    wib002_Click(sender, e);
      //  }


    }
    private void CargaGrilla1(string Filtro)
    {
      DataSet dv = DVNinos;
      grd001.Columns[1].Visible = false;

      //grd001.Page.Items.Clear();
      if (Filtro.Trim() != "")
      { dv.Tables[0].DefaultView.RowFilter = "Apellido_materno LIKE '" + Filtro.ToUpper() + "%'"; }
      else
      { dv.Tables[0].DefaultView.RowFilter = "Apellido_materno LIKE '%'"; }

      dv.Tables[0].DefaultView.Sort = "Apellido_materno";
      grd001.DataSource = dv.Tables[0].DefaultView;
      grd001.DataBind();
      grd001.HeaderRow.TableSection = TableRowSection.TableHeader;
      grd002.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
    private void CargaGrilla2(string Filtro)
    {
      DataSet dv = DVNinos;
      grd001.Columns[1].Visible = false;

      //grd001.Page.Items.Clear();
      if (Filtro.Trim() != "")
      { dv.Tables[0].DefaultView.RowFilter = "Nombres LIKE '" + Filtro.ToUpper() + "%'"; }
      else
      { dv.Tables[0].DefaultView.RowFilter = "Nombres LIKE '%'"; }

      dv.Tables[0].DefaultView.Sort = "Nombres";
      grd001.DataSource = dv.Tables[0].DefaultView;
      grd001.DataBind();
      grd001.HeaderRow.TableSection = TableRowSection.TableHeader;
      grd002.HeaderRow.TableSection = TableRowSection.TableHeader;
    }

    private void AgregaTabActivo(string num_tab)
    {
        if (ViewState["TabActivo"] == null)
        {
            ViewState["TabActivo"] = num_tab;
            return;
        }

        if (!ViewState["TabActivo"].ToString().Contains(num_tab))
        {
            ViewState["TabActivo"] = ViewState["TabActivo"] + num_tab;
        }
    }
    private void habilita_tab(int num_tab) {
        switch (num_tab) {
            case C_IDTAB_DATOS:
                link_tab1.Attributes.Add("data-toggle", "tab"); link_tab1.Attributes.Remove("class");
                break;

            case C_IDTAB_AREA:
                link_tab1.Attributes.Add("data-toggle", "tab"); link_tab1.Attributes.Remove("class");
                link_tab2.Attributes.Add("data-toggle", "tab"); link_tab2.Attributes.Remove("class");
                break;

            case C_IDTAB_SEGUIMIENTO:
                link_tab1.Attributes.Add("data-toggle", "tab"); link_tab1.Attributes.Remove("class");
                link_tab2.Attributes.Add("data-toggle", "tab"); link_tab2.Attributes.Remove("class");
                link_tab3.Attributes.Add("data-toggle", "tab"); link_tab3.Attributes.Remove("class");
                break;

            case C_IDTAB_CON_QUIEN:
                link_tab1.Attributes.Add("data-toggle", "tab"); link_tab1.Attributes.Remove("class");
                link_tab2.Attributes.Add("data-toggle", "tab"); link_tab2.Attributes.Remove("class");
                link_tab3.Attributes.Add("data-toggle", "tab"); link_tab3.Attributes.Remove("class");
                link_tab4.Attributes.Add("data-toggle", "tab"); link_tab4.Attributes.Remove("class");
                break;

            case C_IDTAB_TERMINO:
                link_tab1.Attributes.Add("data-toggle", "tab"); link_tab1.Attributes.Remove("class");
                link_tab2.Attributes.Add("data-toggle", "tab"); link_tab2.Attributes.Remove("class");
                link_tab3.Attributes.Add("data-toggle", "tab"); link_tab3.Attributes.Remove("class");
                link_tab5.Attributes.Add("data-toggle", "tab"); link_tab5.Attributes.Remove("class");
                break;
        
        }
        

    }
    
    private void muestra_pestaña(int num_tab)
    {
        habilita_tab(num_tab);
        AgregaTabActivo(num_tab.ToString());
        string tabactivo = ViewState["TabActivo"].ToString();
        if (tabactivo.Contains("1")) li_nav1.Attributes.Remove("style");
        if (tabactivo.Contains("2")) li_nav2.Attributes.Remove("style");
        if (tabactivo.Contains("3")) li_nav3.Attributes.Remove("style");
        if (tabactivo.Contains("4")) li_nav4.Attributes.Remove("style");
        if (tabactivo.Contains("5")) li_nav5.Attributes.Remove("style");    
                
            switch (num_tab)
            {
                case C_IDTAB_DATOS:
                    tab1.Attributes.Add("class", "tab-pane fade in active");
                    tab2.Attributes.Add("class", "tab-pane fade");
                    tab3.Attributes.Add("class", "tab-pane fade");
                    tab4.Attributes.Add("class", "tab-pane fade");
                    tab5.Attributes.Add("class", "tab-pane fade");
                    li_nav1.Attributes.Add("class", "active");
                    li_nav2.Attributes.Remove("class");
                    li_nav3.Attributes.Remove("class");
                    li_nav4.Attributes.Remove("class");
                    li_nav5.Attributes.Remove("class");
                    break;
                case C_IDTAB_AREA:
                    tab1.Attributes.Add("class", "tab-pane fade");
                    tab2.Attributes.Add("class", "tab-pane fade in active");
                    tab3.Attributes.Add("class", "tab-pane fade");
                    tab4.Attributes.Add("class", "tab-pane fade");
                    tab5.Attributes.Add("class", "tab-pane fade");
                    li_nav1.Attributes.Remove("class");
                    li_nav2.Attributes.Add("class", "active");
                    li_nav3.Attributes.Remove("class");
                    li_nav4.Attributes.Remove("class");
                    li_nav5.Attributes.Remove("class");
                    break;

                case C_IDTAB_SEGUIMIENTO:
                    tab1.Attributes.Add("class", "tab-pane fade");
                    tab2.Attributes.Add("class", "tab-pane fade");
                    tab3.Attributes.Add("class", "tab-pane fade in active");
                    tab4.Attributes.Add("class", "tab-pane fade");
                    tab5.Attributes.Add("class", "tab-pane fade");
                    li_nav1.Attributes.Remove("class");
                    li_nav2.Attributes.Remove("class");
                    li_nav3.Attributes.Add("class", "active");
                    li_nav4.Attributes.Remove("class");
                    li_nav5.Attributes.Remove("class");
                    break;

                case C_IDTAB_CON_QUIEN:
                    tab1.Attributes.Add("class", "tab-pane fade");
                    tab2.Attributes.Add("class", "tab-pane fade");
                    tab3.Attributes.Add("class", "tab-pane fade");
                    tab4.Attributes.Add("class", "tab-pane fade in active");
                    tab5.Attributes.Add("class", "tab-pane fade");
                    li_nav1.Attributes.Remove("class");
                    li_nav2.Attributes.Remove("class");
                    li_nav3.Attributes.Remove("class");
                    li_nav4.Attributes.Add("class", "active");
                    li_nav5.Attributes.Remove("class");
                    break;

                case C_IDTAB_TERMINO:
                    tab1.Attributes.Add("class", "tab-pane fade");
                    tab2.Attributes.Add("class", "tab-pane fade");
                    tab3.Attributes.Add("class", "tab-pane fade");
                    tab4.Attributes.Add("class", "tab-pane fade");
                    tab5.Attributes.Add("class", "tab-pane fade in active");
                    li_nav1.Attributes.Remove("class");
                    li_nav2.Attributes.Remove("class");
                    li_nav3.Attributes.Remove("class");
                    li_nav4.Attributes.Remove("class");
                    li_nav5.Attributes.Add("class", "active");
                    break;
            }
    }
    /*
    protected void link_tab2_Click(object sender, EventArgs e)
    {
        muestra_pestaña(C_IDTAB_AREA);
    }
    protected void link_tab1_Click(object sender, EventArgs e)
    {
        muestra_pestaña(C_IDTAB_DATOS);
    }
    protected void link_tab3_Click(object sender, EventArgs e)
    {
        muestra_pestaña(C_IDTAB_SEGUIMIENTO);
    }
    protected void link_tab4_Click(object sender, EventArgs e)
    {
        muestra_pestaña(C_IDTAB_CON_QUIEN);
    }
    protected void link_tab5_Click(object sender, EventArgs e)
    {
        muestra_pestaña(C_IDTAB_TERMINO);
    }*/
    //protected void PI_Clnb002_Click(object sender, EventArgs e)
    //{
    //    PI_CFuncion_Grabar();
    //    RegisterClientScriptBlock("RedirectBusqueda", "<script>window.parent.LlamaBuscador();</script>");
    //}
    protected void PI_Cbut001_Click(object sender, EventArgs e)
    {
        PI_CFuncion_Grabar();
        alerts2.Attributes.Add("style", "");
        lbl0052.Text = " Plan de Intervencion Actualizado con exito";
        lbl0052.Attributes.Add("style", "");
        clean();
        Clean2();
        //ScriptManager.RegisterStartupScript(this, typeof(string), "Actualizar", "alert('Se actualizo.');", true);
        //ScriptManager.RegisterStartupScript(this, typeof(string), "Actualizar", "window.location.reload(true);", true);
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "JSscript", "alert('this is a test');", true);
        //muestra_pestaña(C_IDTAB_TERMINO);
        //PI_FgetGradoCumplimiento();
    }
    protected void PI_Flnb001_Click1(object sender, EventArgs e)
    {
        //muestra_pestaña(C_IDTAB_TERMINO);
        PI_FFuncion_Inicia_Grabado();
        alerts2.Attributes.Add("style", "");
        lbl0052.Text = " Plan de Intervencion Actualizado con exito";
        lbl0052.Attributes.Add("style", "");
        clean();
        Clean2();
        //ScriptManager.RegisterStartupScript(this, typeof(string), "Actualizar", "alert('Se actualizo.');", true);
        //ScriptManager.RegisterStartupScript(this, typeof(string), "Actualizar", "window.location.reload(true);", true);
        //Response.Write("<script type='text/javascript'></script>");
    }

    private void Clean2()
    {
        wib002.Visible = false;
      txt001.Visible = true;
      TextBox1.Visible = true;
      TextBox2.Visible = true;
      alerts.Attributes.Add("style", "display:none");
      lbl005.Attributes.Add("style", "display:none");

      //alerts2.Attributes.Add("style", "display:none");
      //lbl0052.Attributes.Add("style", "display:none");
      // filtro
      //ddown001.SelectedValue = "0";
      //ddown002.SelectedValue = "0";
      txt001.Enabled = true;
      TextBox1.Enabled = true;
      TextBox2.Enabled = true;
      //ddown001.SelectedIndex = 0;
      
      //vacio el AIO
      //oNNA NNA = (oNNA)Session["NNA"];
      //NNA.NNACodInstitucion = "";
      //NNA.NNACodProyecto = "";
      //Session["NNA"] = NNA;

      txt001.Text = "";
      TextBox1.Text = "";
      TextBox2.Text = "";

      Limpiagrd002();
      trgrd001.Visible = false;

      Button1.Visible = false;
      lbl001.Visible = false;
      lbl003.Visible = false;

      //PItxt001.Text = "";
      //PItxt002.Text = "";
      //PIwdc001.Text = "Seleccione Fecha";
      //PIwdc002.Text = "Seleccione Fecha";
      //PIwdc003.Text = "Seleccione Fecha";
      //PIddown001.SelectedIndex = 0;

      //PI_Stxt001.Text = "";
      //PI_Schk001.Checked = false;
      //PI_Schk002.Checked = false;
      //PI_Sddown001.SelectedIndex = 0;
      
      PI_AdtTabla = null;

      Session["PI_EstadoIntervencion"] = null;
      PI_CdtTabla = null;
      Session["PI_GradoCumplimiento"] = null;

      ViewState["TabActivo"] = null;
      muestra_pestaña(1);
      grd002.Visible = false;
      ddown001.Enabled = true;
      ddown002.Enabled = true;
      btnbuscar.Visible = true;
      lbl001.Visible = false;
      lbl003.Visible = false;
      //ddown002.SelectedIndex = 0;
      div_panel.Visible = false;
      //gfontbrevis
      link_tab4.Attributes.Remove("style");
      li_nav4.Attributes.Remove("style");
      link_tab5.Attributes.Remove("style");
      li_nav5.Attributes.Remove("style");

      ScriptManager.RegisterStartupScript(this, typeof(string), "Agregar", "clean()", true);
      
    }

    private void clean(){
      PItxt001.Text = "";
      PIwdc001.Text = "";
      PIwdc002.Text = "";
      PIwdc003.Text = "";
      PI_Sddown001.SelectedIndex = 0;
      PI_Schk001.Checked = false;
      PI_Schk002.Checked = false;
      PI_Frdolist001.SelectedIndex = -1; 
      PI_Frdolist002.SelectedIndex = -1;
      PI_Fwdc001.Text = "";

    }

    private void mostrar_collapse(bool valor)
    {
        if (valor)
        {
            collapse_Form.Attributes.Remove("Class");
            collapse_Form.Attributes.Add("Class", "panel-collapse collapse in");
        }
        if (!valor)
        {
            collapse_Form.Attributes.Remove("Class");
            collapse_Form.Attributes.Add("Class", "panel-collapse collapse out");

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
