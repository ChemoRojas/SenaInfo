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
using System.Drawing;
using System.Data.Sql;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections.Generic;

//19877931-8
public partial class mod_coordinadores_Coordinadores_Ingreso : System.Web.UI.Page
{
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
    public DataTable DTBusqueda
    {
        get { return (DataTable)Session["DTBusqueda"]; }
        set { Session["DTBusqueda"] = value; }
    }

    public int IdUsuario
    {
        get { return (int)Session["IdUsuario"]; }
        set { Session["IdUsuario"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        alerts.Attributes.Add("style", "display:none");
        lbl005.Attributes.Add("style", "display:none");
        alerts2.Attributes.Add("style", "display:none");
        lbl0052.Attributes.Add("style", "display:none");
        //ddown_nacionalidad.Attributes.Add("disabled", "true");
        //ddown_nacionalidad.Enabled = false;

        if (!IsPostBack)
        {
            if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
            {
                Response.Redirect("~/logout.aspx");
            }
            else
            {
                //if (!window.existetoken("75E2E6CF-C6A2-4C32-A406-A862BCA719F8")) //AA938FAD-0140-474C-9DEA-6D6BF31E0A3D
                if (!window.existetoken("D7B92202-704C-4BA7-AA1B-9CB5EDD6E19E"))
                {
                    Response.Redirect("~/e403.aspx");
                }
                else
                {
                    CargoFolioNuevo();
                    if (Request.QueryString["ingreso"] != null)
                    {
                        btn_agregar.Text = "Modificar";
                        btn_limpiar.Enabled = false;
                        CargoDropDowns();

                        CoordinadorJudicialTableAdapter traigodata = new CoordinadorJudicialTableAdapter();
                        DataTable dtdata = traigodata.Get_xIcodIngreso(Convert.ToInt32(Request.QueryString["ingreso"]));
                        if (dtdata.Rows.Count > 0)
                        {
                            NinosTableAdapter traigodatosnino = new NinosTableAdapter();
                            DataTable dtnino1 = traigodatosnino.Get_nino_xcod(Convert.ToInt32(dtdata.Rows[0]["CodNino"]));

                            if (dtnino1.Rows.Count > 0 && Convert.ToInt32(dtdata.Rows[0]["CodProyecto"]) > 0)
                            {
                                txt_rut.Text = dtnino1.Rows[0]["Rut"].ToString();
                                txt_nombres.Text = dtnino1.Rows[0]["Nombres"].ToString();
                                txt_ap_paterno.Text = dtnino1.Rows[0]["Apellido_Paterno"].ToString();
                                txt_ap_materno.Text = dtnino1.Rows[0]["Apellido_Materno"].ToString();
                                rdbl_sexo.SelectedValue = dtnino1.Rows[0]["Sexo"].ToString();
                                wdc_Fnacimiento.Text = dtnino1.Rows[0]["FechaNacimiento"].ToString().Substring(0, 10);
                                ddown_nacionalidad.SelectedValue = dtnino1.Rows[0]["CodNacionalidad"].ToString();
                                lbl_CodNino.Text = dtdata.Rows[0]["CodNino"].ToString();
                                txt_ruc.Text = dtdata.Rows[0]["Ruc"].ToString();
                                txt_rit.Text = dtdata.Rows[0]["Rit"].ToString();
                                wdc_fecha.Text = dtdata.Rows[0]["FechaOrden"].ToString().Substring(0, 10);
                                

                                rdblst_Sancion.SelectedValue = dtdata.Rows[0]["SancionAccesoria"].ToString();
                                rdblst_Adn.SelectedValue = dtdata.Rows[0]["ADN"].ToString();
                                ddl_sancion.SelectedValue = dtdata.Rows[0]["CodSancionCoordinador"].ToString();
                                rdblst_Pena.SelectedValue = dtdata.Rows[0]["Pena"].ToString();
                                wdc_fechaRecepcion.Text = dtdata.Rows[0]["FechaRecepcion"].ToString().Substring(0, 10);
                                txt_Folio.Text = dtdata.Rows[0]["Folio"].ToString();
                                ImageButton1.Visible = false;

                                parCausalesIngresoTableAdapter consultocausal = new parCausalesIngresoTableAdapter();
                                DataTable dtcausa = consultocausal.Get_causal(Convert.ToInt32(dtdata.Rows[0]["CodCausalIngreso"]));

                                ddown_TipoCausal.SelectedValue = dtcausa.Rows[0]["CodTipoCausalIngreso"].ToString();

                                cargocausal();

                                ddown_Causal.SelectedValue = dtcausa.Rows[0]["CodCausalIngreso"].ToString();
                                txt_codDelito.Text = dtdata.Rows[0]["CodCausalIngreso"].ToString();

                                Proyectos3TableAdapter traigoReg = new Proyectos3TableAdapter();
                                DataTable dtreg = traigoReg.Get_XcodProyecto(Convert.ToInt32(dtdata.Rows[0]["CodProyecto"]));

                                ddown_RegionProyecto.SelectedValue = Convert.ToString(dtreg.Rows[0]["CodRegion"]);
                                ddown_RegionTribunal.SelectedValue = Convert.ToString(dtreg.Rows[0]["CodRegion"]);


                                parTribunalesTableAdapter traigoTrib = new parTribunalesTableAdapter();
                                DataTable dtTrib = traigoTrib.GetTribunales(Convert.ToInt32(dtdata.Rows[0]["CodTribunal"]), Convert.ToInt32(dtreg.Rows[0]["CodRegion"]));
                                if (dtTrib.Rows.Count > 0)
                                {
                                    ddown_TipoTribunal.SelectedValue = dtTrib.Rows[0]["TipoTribunal"].ToString(); ;
                                }
                                GetTribunales();
                                ddown_Tribunal.SelectedValue = dtdata.Rows[0]["CodTribunal"].ToString();
                                CargaProyectos();
                                ddown_Proyecto.SelectedValue = dtdata.Rows[0]["CodProyecto"].ToString();
                                /* para cargar correctamente los DDs de Tipo de Causal de Ingreso
                                 * debo hacer una carga inversa de datos, trayendo primero el CodCausalIngreso,
                                 * a travez de este obtengo el tipo al que corresponde y recien en ese momento
                                 * podré cargar los tipos en su DDs
                                 * */

                                parCausalesIngresoLRPA1TableAdapter traigocausales = new parCausalesIngresoLRPA1TableAdapter();
                                DataTable dtcausales = traigocausales.Get_Xcodcausal(Convert.ToInt32(ddown_TipoCausal.SelectedValue));
                                if (dtcausales.Rows.Count > 0)
                                {
                                    txt_codDelito.Text = dtcausales.Rows[0]["CodNumCausal"].ToString();
                                }
                                DeshabilitoCajas();
                            }
                        }
                        ValidoPermisos();

                    }
                    else
                    {
                        btn_agregar.Text = "Agregar";
                        btn_limpiar.Enabled = true;
                        CargoDropDowns();
                        CargaProyectos();

                        DataView dvx = new DataView((GetParTipoNacionalidad()));
                        ddown_tipo_nacionalidad.DataSource = dvx;
                        ddown_tipo_nacionalidad.DataTextField = "Descripcion";
                        ddown_tipo_nacionalidad.DataValueField = "CodTipoNacionalidad";
                        dvx.Sort = "CodTipoNacionalidad";
                        ddown_tipo_nacionalidad.DataBind();

                        ddown_tipo_nacionalidad.Enabled = false;
                        ddown_nacionalidad.Enabled = false;
                    }
                    //wdc_fecha.Value = DateTime.Now.ToShortDateString();
                    //wdc_fechaRecepcion.Value = DateTime.Now.ToShortDateString();
                }

                if (Request.QueryString["codproyecto"] != null && Request.QueryString["codproyecto"] != "")
                {
                    ddown_Proyecto.SelectedValue = Request.QueryString["codproyecto"];

                }
            }
        }
    }


    private DataTable GetParTipoNacionalidad()
    {
        DataTable dt = new DataTable();
        try
        {
            SqlDataReader reader;

            string consulta = "select CodTipoNacionalidad, Descripcion from parTipoNacionalidad where IndVigencia = 'V'";
            SqlConnection sqlConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
            SqlCommand cmd = new SqlCommand();


            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;

            sqlConnection1.Open();

            reader = cmd.ExecuteReader();
            dt.Load(reader);

            // Data is accessible through the DataReader object here.
            sqlConnection1.Close();
        }
        catch (Exception ex)
        {
        }
        return dt;

    }

    public void CargoFolioNuevo()
    {
        coordinador cr = new coordinador();
        List<DbParameter> listDbParameter = new List<DbParameter>();
        string sqlu = "Select codregion,coddireccionregional From usuarios WHERE idusuario =@pIdUsuario";
        listDbParameter.Add(Conexiones.CrearParametro("@pIdUsuario", SqlDbType.Int, 4, Convert.ToInt32(Session["IdUsuario"])));
        DataTable dt = cr.ejecuta_SQL(sqlu, listDbParameter);

        if (dt.Rows.Count > 0) // se encuentra al usuario, y su codigo de region
        {
            int codregion = Convert.ToInt32(dt.Rows[0]["codregion"]);

            CoordinadorJudicial_FolioTableAdapter cjta = new CoordinadorJudicial_FolioTableAdapter();
            DataTable dtfolios = cjta.Get_Folio_By_Region(codregion);
            if (dtfolios.Rows.Count > 0)
            {
                if (codregion.ToString().Length == 1)
                {
                    string foliosincodregion = dtfolios.Rows[0]["Folio"].ToString().Remove(0, 1);
                    int sumafolio = Convert.ToInt32(foliosincodregion) + 1;
                    txt_Folio.Text = codregion.ToString() + sumafolio.ToString(); //Convert.ToString(Convert.ToInt32(dtfolios.Rows[0]["Folio"]) + 1);
                    txt_Folio.Enabled = false;
                }
                else if (codregion.ToString().Length == 2)
                {
                    string foliosincodregion = dtfolios.Rows[0]["Folio"].ToString().Remove(0, 2);
                    int sumafolio = Convert.ToInt32(foliosincodregion) + 1;
                    txt_Folio.Text = codregion.ToString() + sumafolio.ToString(); //Convert.ToString(Convert.ToInt32(dtfolios.Rows[0]["Folio"]) + 1);
                    txt_Folio.Enabled = false;
                }
            }
            else
            {
                txt_Folio.Text = Convert.ToString(dt.Rows[0]["codregion"].ToString()) + "1";
                txt_Folio.Enabled = false;
            }
        }
        else
        {

        }
    }

    public void ValidoPermisos()
    {
        //F6DC09AD-5F04-4F95-BF81-B806C49B66BA coordinador nacional 
        if (window.existetoken("F6DC09AD-5F04-4F95-BF81-B806C49B66BA"))
        {
            btn_agregar.Visible = true;
        }
        else
        {
            //btn_agregar.Visible = false;
            if (Session["IdUsuario"] != null)
            {
                UsuariosTableAdapter usrta = new UsuariosTableAdapter();
                DataTable dtUser = usrta.Get_ById(Convert.ToInt32(Session["IdUsuario"]));
                if (dtUser.Rows.Count > 0)
                {
                    if (Request.QueryString["region"] != null)
                    {
                        if (Request.QueryString["region"].ToString() != dtUser.Rows[0]["codregion"].ToString())
                        {
                            btn_agregar.Visible = false;
                        }
                        else
                        {
                            btn_agregar.Visible = true;
                        }
                    }
                }
            }
        }
    }

    public void CargoDropDowns()
    {
        LRPAcoll LRPA = new LRPAcoll();
        parcoll par = new parcoll();
        coordinador cr = new coordinador();
        List<DbParameter> listDbParameter = new List<DbParameter>();
        string sqlu = "Select codregion,coddireccionregional From usuarios WHERE idusuario =@pIdUsuario";
        listDbParameter.Add(Conexiones.CrearParametro("@pIdUsuario", SqlDbType.Int, 4, Convert.ToInt32(Session["IdUsuario"])));
        DataTable dt = cr.ejecuta_SQL(sqlu, listDbParameter);

        DataView dv13 = new DataView(par.GetparRegion());

        //llenando el primer dropdown que usa region
        ddown_RegionTribunal.DataSource = dv13;
        ddown_RegionTribunal.DataTextField = "Descripcion";
        ddown_RegionTribunal.DataValueField = "CodRegion";
        dv13.Sort = "Descripcion";
        ddown_RegionTribunal.DataBind();
        //hasta aqui
        //comienzo a llenar el segundo dropdown que usa region

        ddown_RegionProyecto.DataSource = dv13;
        ddown_RegionProyecto.DataTextField = "Descripcion";
        ddown_RegionProyecto.DataValueField = "CodRegion";
        dv13.Sort = "Descripcion";
        ddown_RegionProyecto.DataBind();
        //hasta aqui

        //aqui seleccionare la region dependiendo del ID del usuario conectado (para ambos casos anteriores)
        ddown_RegionTribunal.SelectedValue = dt.Rows[0][0].ToString();
        ddown_RegionProyecto.SelectedValue = dt.Rows[0][0].ToString();
        //hasta aqui

        //llenando dropdown de Tipo de Tribunal
        ddown_TipoTribunal.Items.Clear();
        DataView dv15 = new DataView(LRPA.GetparTipoTribunalLRPA());
        ddown_TipoTribunal.DataSource = dv15;
        ddown_TipoTribunal.DataTextField = "Descripcion";
        ddown_TipoTribunal.DataValueField = "TipoTribunal";
        dv15.Sort = "Descripcion";
        ddown_TipoTribunal.DataBind();
        ddown_TipoTribunal.SelectedValue = "5";
        //hasta aqui

        //llenando dropdown de Tipo de Causal de Ingreso

        parTipoCausalIngresoLRPATableAdapter tipoCausal = new parTipoCausalIngresoLRPATableAdapter();
        DataTable dtTipoCausal = tipoCausal.Get_Tipos();


        DataTable dtTemp1 = new DataTable();
        dtTemp1.Columns.Add("CodTipoCausalIngreso");
        dtTemp1.Columns.Add("Descripcion");

        DataRow drTemp1;
        drTemp1 = dtTemp1.NewRow();
        drTemp1[0] = "0";
        drTemp1[1] = "Seleccionar";
        dtTemp1.Rows.Add(drTemp1);

        for (int i = 0; i <= dtTipoCausal.Rows.Count; i++)
        {
            try
            {
                drTemp1 = dtTemp1.NewRow();
                drTemp1[0] = Convert.ToString(dtTipoCausal.Rows[i]["CodTipoCausalIngreso"]);
                drTemp1[1] = Convert.ToString(dtTipoCausal.Rows[i]["Descripcion"]);
                dtTemp1.Rows.Add(drTemp1);
            }
            catch
            {
            }
        }

        if (dtTipoCausal.Rows.Count > 0)
        {
            ddown_TipoCausal.DataSource = dtTemp1;
            ddown_TipoCausal.DataTextField = "Descripcion";
            ddown_TipoCausal.DataValueField = "CodTipoCausalIngreso";
            ddown_TipoCausal.DataBind();
            cargocausal();
        }

        //hasta aqui

        parNacionalidadesTableAdapter nac = new parNacionalidadesTableAdapter();
        DataTable dtNac = nac.GetData();
        if (dtNac.Rows.Count > 0)
        {
            ddown_nacionalidad.Items.Clear();
            ddown_nacionalidad.DataSource = dtNac;
            ddown_nacionalidad.DataValueField = "CodNacionalidad";
            ddown_nacionalidad.DataTextField = "Descripcion";
            ddown_nacionalidad.DataBind();
        }

        parTribunalesTableAdapter trib = new parTribunalesTableAdapter();
        DataTable dtTrib = trib.GetTribunales(Convert.ToInt32(ddown_TipoTribunal.SelectedValue), Convert.ToInt32(ddown_RegionTribunal.SelectedValue));

        DataTable dtTempTribunal = new DataTable();
        dtTempTribunal.Columns.Add("CodTribunal");
        dtTempTribunal.Columns.Add("Descripcion");

        DataRow drTempTribunal;
        drTempTribunal = dtTempTribunal.NewRow();
        drTempTribunal[0] = "0";
        drTempTribunal[1] = "Seleccionar";
        dtTempTribunal.Rows.Add(drTempTribunal);

        for (int i = 0; i <= dtTrib.Rows.Count; i++)
        {
            try
            {
                drTempTribunal = dtTempTribunal.NewRow();
                drTempTribunal[0] = Convert.ToString(dtTrib.Rows[i]["CodTribunal"]);
                drTempTribunal[1] = Convert.ToString(dtTrib.Rows[i]["Descripcion"]);
                dtTempTribunal.Rows.Add(drTempTribunal);
            }
            catch
            {
            }
        }
        if (dtTrib.Rows.Count > 0)
        {
            ddown_Tribunal.Items.Clear();
            ddown_Tribunal.DataSource = dtTempTribunal;
            ddown_Tribunal.DataValueField = "CodTribunal";
            ddown_Tribunal.DataTextField = "Descripcion";
            ddown_Tribunal.DataBind();
        }

        parSancionCoordinadorTableAdapter pcsta = new parSancionCoordinadorTableAdapter();
        DataTable dtSancion = pcsta.GetData();
        if (dtSancion.Rows.Count > 0)
        {
            ddl_sancion.DataSource = dtSancion;
            ddl_sancion.DataValueField = "CodSancionCoordinador";
            ddl_sancion.DataTextField = "Descripcion";
            ddl_sancion.DataBind();
        }
    }

    //protected void btn_buscar_Click(object sender, EventArgs e)
    //{
    //    Function_Consulta();

    //    //Limpiar();
    //}
    //private void Function_Consulta()
    //{
    //    string sParametrosConsulta = "Select Distinct top 201 T2.CodNino,T2.Rut,T2.Sexo,T2.Nombres,T2.Apellido_paterno,T2.Apellido_Materno," +
    //                           "T2.FechaNacimiento, T2.CodNacionalidad From Ninos T2 ";

    //    if (txt_rut.Text.Trim() != "" || txt_ap_paterno.Text.Trim() != "" ||
    //            txt_ap_materno.Text.Trim() != "" || txt_nombres.Text.Trim() != "")
    //    {
    //        sParametrosConsulta = sParametrosConsulta + "Where ";
    //    }

    //    if (txt_ap_paterno.Text.Trim() != "")
    //    {
    //        sParametrosConsulta = sParametrosConsulta + " T2.Apellido_Paterno like  '%" + txt_ap_paterno.Text + "%' And";
    //    }
    //    if (txt_ap_materno.Text.Trim() != "")
    //    {
    //        sParametrosConsulta = sParametrosConsulta + " T2.Apellido_Materno like  '%" + txt_ap_materno.Text + "%' And";
    //    }
    //    if (txt_nombres.Text.Trim() != "")
    //    {
    //        sParametrosConsulta = sParametrosConsulta + " T2.Nombres like  '%" + txt_nombres.Text + "%' And";
    //    }
    //    if (txt_rut.Text.Trim() != "")
    //    {
    //        sParametrosConsulta = sParametrosConsulta + " T2.Rut ='" + txt_rut.Text.Trim() + "' And";
    //    }

    //    if (sParametrosConsulta.Substring(sParametrosConsulta.Length - 3, 3) == "And")
    //    {
    //        sParametrosConsulta = sParametrosConsulta.Substring(0, sParametrosConsulta.Length - 3);
    //    }


    //    ninocoll nic = new ninocoll();
    //    DataTable dt = nic.get_ninorelacionado(sParametrosConsulta);

    //    if (dt.Rows.Count == 1)
    //    {
    //        lnk_resultados.Visible = false;
    //        lnk_resultados.Visible = false;
    //        lbl_encontrados.Visible = false;
    //        lbl001.Visible = false;
    //        lbl_error.Visible = false;

    //        if (dt.Rows[0]["Rut"].ToString() == "0")
    //        {
    //            txt_rut.Text = string.Empty;
    //            rdblist_nacionalidad.SelectedValue = "Extranjero";
    //        }
    //        else
    //        {
    //            txt_rut.Text = Convert.ToString(dt.Rows[0]["Rut"]);
    //            rdblist_nacionalidad.SelectedValue = "Chileno";
    //        }

    //        txt_nombres.Text = Convert.ToString(dt.Rows[0]["Nombres"]);
    //        txt_ap_paterno.Text = Convert.ToString(dt.Rows[0]["Apellido_paterno"]);
    //        txt_ap_materno.Text = Convert.ToString(dt.Rows[0]["Apellido_materno"]);
    //        rdbl_sexo.SelectedValue = Convert.ToString(dt.Rows[0]["Sexo"]);
    //        wdc_Fnacimiento.Text = Convert.ToString(dt.Rows[0]["FechaNacimiento"]).Substring(0, 10);
    //        ddown_nacionalidad.SelectedValue = Convert.ToString(dt.Rows[0]["CodNacionalidad"]);
    //        lbl_CodNino.Text = dt.Rows[0]["CodNino"].ToString();
    //        grd004.Visible = false;
    //        DeshabilitoCajas();
    //    }

    //    else if (dt.Rows.Count > 0 && dt.Rows.Count < 200)
    //    {
    //        HabilitoCajas();
    //        //lnk_resultados.Visible = true;
    //        //lbl_encontrados.Text = dt.Rows.Count.ToString();
    //        //lbl_encontrados.Visible = true;
    //        //lbl001.Visible = true;
    //        lbl_error.Visible = false;
    //        DTBusqueda = dt;
    //        carga_grilla();
    //    }
    //    else if (dt.Rows.Count == 0)
    //    {
    //        HabilitoCajas();
    //        lnk_resultados.Visible = false;
    //        lnk_resultados.Visible = false;
    //        lbl_encontrados.Visible = false;
    //        lbl001.Visible = false;
    //        lbl_error.Visible = true;
    //        lbl_error.Text = "No se encontraron coincidencias.";
    //        grd004.Visible = false;
    //    }
    //    else if (dt.Rows.Count > 200)
    //    {
    //        HabilitoCajas();
    //        lnk_resultados.Visible = false;
    //        lnk_resultados.Visible = false;
    //        lbl_encontrados.Visible = false;
    //        lbl001.Visible = false;
    //        lbl_error.Visible = true;
    //        lbl_error.Text = "Búsqueda demasiado ambigua, Ingrese parámetros.";
    //        grd004.Visible = false;
    //    }
    //}

    public void HabilitoCajas()
    {
        txt_rut.Enabled = true;
        txt_nombres.Enabled = true;
        txt_ap_paterno.Enabled = true;
        txt_ap_materno.Enabled = true;
        rdbl_sexo.Enabled = true;
        wdc_Fnacimiento.Enabled = true;
        //ddown_nacionalidad.Enabled = true;
    }

    public void DeshabilitoCajas()
    {
        txt_rut.Enabled = false;
        txt_nombres.Enabled = false;
        txt_ap_paterno.Enabled = false;
        txt_ap_materno.Enabled = false;
        rdbl_sexo.Enabled = false;
        wdc_Fnacimiento.Enabled = false;
        ddown_nacionalidad.Enabled = false;
    }

    protected void grd004_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd004.PageIndex = e.NewPageIndex;
        carga_grilla();
    }
    protected void grd004_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string rutCompleto = txt_rut.Text;
        if (e.CommandName == "ver")
        {
            try
            {
                lbl_CodNino.Text = grd004.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
                txt_rut.Text = grd004.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text;
                txt_ap_paterno.Text = grd004.Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Text;
                txt_ap_materno.Text = grd004.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Text;
                rdbl_sexo.SelectedValue = grd004.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text;
                txt_nombres.Text = grd004.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text;
                wdc_Fnacimiento.Text = Convert.ToDateTime(grd004.Rows[Convert.ToInt32(e.CommandArgument)].Cells[6].Text).ToShortDateString();
                grd004.Visible = false;

                NinosTableAdapter busconino = new NinosTableAdapter();
                DataTable dtnino = busconino.Get_nino_xcod(Convert.ToInt32(lbl_CodNino.Text));
                ddown_nacionalidad.SelectedValue = dtnino.Rows[0]["CodNacionalidad"].ToString();

                DeshabilitoCajas();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (rutCompleto.Trim().Replace(".", "") == txt_rut.Text)
                    txt_rut.Text = rutCompleto;
            }
        }
    }

    public void carga_grilla()
    {
        DataView dv = new DataView(DTBusqueda);
        dv.Sort = "Apellido_paterno, Apellido_Materno, Nombres";
        grd004.DataSource = dv;
        grd004.DataBind();
        grd004.Visible = true;
    }
    protected void lnk_resultados_Click(object sender, EventArgs e)
    {
        carga_grilla();
    }

    public void Limpiar()
    {

        HabilitoCajas();
        ImageButton1.Visible = true;
        //ddown_RegionTribunal.SelectedItem.Value = "-2";

        alerts.Attributes.Add("style", "display:none");
        lbl005.Attributes.Add("style", "display:none");
        alerts2.Attributes.Add("style", "display:none");
        lbl0052.Attributes.Add("style", "display:none");

        CargoDropDowns();
        txt_rut.Text = string.Empty;
        txt_nombres.Text = string.Empty;
        txt_ap_paterno.Text = string.Empty;
        txt_ap_materno.Text = string.Empty;
        wdc_fecha.Text = string.Empty;
        wdc_fechaRecepcion.Text = string.Empty;
        //rdbl_sexo.SelectedValue = "F";
        wdc_Fnacimiento.Text = string.Empty;
        ddown_Tribunal.SelectedValue = "0";
        ddown_TipoCausal.SelectedValue = "0";
        ddown_Causal.SelectedValue = "0";
        txt_codDelito.Text = string.Empty;
        txt_rit.Text = string.Empty;
        txt_ruc.Text = string.Empty;
        ddown_Proyecto.SelectedValue = "0";
        //ddown_RegionTribunal.SelectedValue = "0";
        ddown_TipoTribunal.SelectedValue = "0";
        //ddown_RegionProyecto.SelectedValue = "0";
        //grd004.Visible = false;
        rdblist_nacionalidad.SelectedValue = "Chileno";
        rdblst_Sancion.SelectedValue = "0";
        rdblst_Adn.SelectedValue = "0";
        ddl_sancion.SelectedValue = "0";
        rdblst_Pena.SelectedValue = "0";
        txt_Folio.Text = "0";
        ddown_nacionalidad.Enabled = false;
        ddown_RegionTribunal.SelectedValue = "-2";
    }
    public void Limpiar2()
    {
        ddown_RegionProyecto.SelectedValue = "-2";
        ddown_RegionTribunal.SelectedValue = "-2";
        alerts.Attributes.Add("style", "display:none");
        lbl005.Attributes.Add("style", "display:none");
        CargoDropDowns();
        txt_rut.Text = string.Empty;
        txt_nombres.Text = string.Empty;
        txt_ap_paterno.Text = string.Empty;
        txt_ap_materno.Text = string.Empty;
        wdc_fecha.Text = string.Empty;
        wdc_fechaRecepcion.Text = string.Empty;
        rdbl_sexo.SelectedValue = "F";
        wdc_Fnacimiento.Text = "";
        ddown_Tribunal.SelectedValue = "0";
        ddown_TipoCausal.SelectedValue = "0";
        ddown_Causal.SelectedValue = "0";
        txt_codDelito.Text = string.Empty;
        txt_rit.Text = string.Empty;
        txt_ruc.Text = string.Empty;
        ddown_Proyecto.SelectedValue = "0";
        //ddown_RegionTribunal.SelectedValue = "0";
        ddown_TipoTribunal.SelectedValue = "0";
        //ddown_RegionProyecto.SelectedValue = "0";
        //grd004.Visible = false;
        rdblst_Sancion.SelectedValue = "0";
        rdblst_Adn.SelectedValue = "0";
        ddl_sancion.SelectedValue = "0";
        rdblst_Pena.SelectedValue = "0";
        txt_Folio.Text = "0";
    }

    public bool ValidaFolio(int folio)
    {
        bool valido = false;

        coordinador cr = new coordinador();
        List<DbParameter> listDbParameter = new List<DbParameter>();
        string sqlu = "Select codregion,coddireccionregional From usuarios WHERE idusuario =@pIdUsuario";
        listDbParameter.Add(Conexiones.CrearParametro("@pIdUsuario", SqlDbType.Int, 4, Convert.ToInt32(Session["IdUsuario"])));
        DataTable dt = cr.ejecuta_SQL(sqlu, listDbParameter);

        if (dt.Rows.Count > 0) // se encuentra al usuario, y su codigo de region
        {
            while (!valido)
            {
                int codregion = Convert.ToInt32(dt.Rows[0]["codregion"]);
                CoordinadorJudicial_FolioValidaTableAdapter validafolioTA = new CoordinadorJudicial_FolioValidaTableAdapter();
                DataTable dtValida = validafolioTA.Get_ValidaFolio_By_CodFolio(codregion, folio);

                if (dtValida.Rows.Count > 0) // encontro un valor igual en la BD, debo sumar 1 mas y volver a validar
                {
                    if (codregion.ToString().Length == 1)
                    {
                        string foliosincodregion = txt_Folio.Text.Remove(0, 1);
                        int sumafolio = Convert.ToInt32(foliosincodregion) + 1;
                        txt_Folio.Text = codregion.ToString() + sumafolio.ToString();
                        folio++;
                    }
                    else if (codregion.ToString().Length == 2)
                    {
                        string foliosincodregion = txt_Folio.Text.Remove(0, 2);
                        int sumafolio = Convert.ToInt32(foliosincodregion) + 1;
                        txt_Folio.Text = codregion.ToString() + sumafolio.ToString();
                        folio++;
                    }

                    //int valorFolio = Convert.ToInt32(txt_Folio.Text);
                    //valorFolio++;
                    //folio++;
                    //txt_Folio.Text = valorFolio.ToString();
                    valido = false;

                }
                else
                {
                    valido = true;

                }
            }
        }
        else
        {
            valido = true;
        }

        return valido;

    }


    protected void ddown_RegionTribunal_SelectedIndexChanged1(object sender, EventArgs e)
    {
        parTribunalesTableAdapter trib = new parTribunalesTableAdapter();
        DataTable dtTrib = trib.GetTribunales(Convert.ToInt32(ddown_TipoTribunal.SelectedValue), Convert.ToInt32(ddown_RegionTribunal.SelectedValue));

        DataTable dtTempTribunal = new DataTable();
        dtTempTribunal.Columns.Add("CodTribunal");
        dtTempTribunal.Columns.Add("Descripcion");

        DataRow drTempTribunal;
        drTempTribunal = dtTempTribunal.NewRow();
        drTempTribunal[0] = "0";
        drTempTribunal[1] = "Seleccionar";
        dtTempTribunal.Rows.Add(drTempTribunal);

        for (int i = 0; i <= dtTrib.Rows.Count; i++)
        {
            try
            {
                drTempTribunal = dtTempTribunal.NewRow();
                drTempTribunal[0] = Convert.ToString(dtTrib.Rows[i]["CodTribunal"]);
                drTempTribunal[1] = Convert.ToString(dtTrib.Rows[i]["Descripcion"]);
                dtTempTribunal.Rows.Add(drTempTribunal);
            }
            catch
            {
            }
        }
        if (dtTrib.Rows.Count > 0)
        {
            ddown_Tribunal.Items.Clear();
            ddown_Tribunal.DataSource = dtTempTribunal;
            ddown_Tribunal.DataValueField = "CodTribunal";
            ddown_Tribunal.DataTextField = "Descripcion";
            ddown_Tribunal.DataBind();
        }
    }
    protected void ddown_TipoTribunal_SelectedIndexChanged1(object sender, EventArgs e)
    {
        GetTribunales();
    }
    public void GetTribunales()
    {
        parTribunalesTableAdapter trib = new parTribunalesTableAdapter();
        DataTable dtTrib = trib.GetTribunales(Convert.ToInt32(ddown_TipoTribunal.SelectedValue), Convert.ToInt32(ddown_RegionTribunal.SelectedValue));

        DataTable dtTempTribunal = new DataTable();
        dtTempTribunal.Columns.Add("CodTribunal");
        dtTempTribunal.Columns.Add("Descripcion");

        DataRow drTempTribunal;
        drTempTribunal = dtTempTribunal.NewRow();
        drTempTribunal[0] = "0";
        drTempTribunal[1] = "Seleccionar";
        dtTempTribunal.Rows.Add(drTempTribunal);

        for (int i = 0; i <= dtTrib.Rows.Count; i++)
        {
            try
            {
                drTempTribunal = dtTempTribunal.NewRow();
                drTempTribunal[0] = Convert.ToString(dtTrib.Rows[i]["CodTribunal"]);
                drTempTribunal[1] = Convert.ToString(dtTrib.Rows[i]["Descripcion"]);
                dtTempTribunal.Rows.Add(drTempTribunal);
            }
            catch
            {
            }
        }
        if (dtTrib.Rows.Count > 0)
        {
            ddown_Tribunal.Items.Clear();
            ddown_Tribunal.DataSource = dtTempTribunal;
            ddown_Tribunal.DataValueField = "CodTribunal";
            ddown_Tribunal.DataTextField = "Descripcion";
            ddown_Tribunal.DataBind();
        }
    }

    protected void grd004_PageIndexChanged(object sender, EventArgs e)
    {

    }

    protected void ddown_TipoCausal_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargocausal();
    }

    public void cargocausal()
    {
        //test
        parCausalesIngresoTableAdapter caulrpa = new parCausalesIngresoTableAdapter();
        //DataTable dtcausal = caulrpa.Get_PorTipo(Convert.ToInt32(ddown_TipoCausal.SelectedValue));
        DataTable dtcausal = caulrpa.GetData_rp(Convert.ToInt32(ddown_TipoCausal.SelectedValue));

        DataTable dtTemp1 = new DataTable();
        dtTemp1.Columns.Add("CodCausalIngreso");
        dtTemp1.Columns.Add("Descripcion");

        DataRow drTemp1;
        drTemp1 = dtTemp1.NewRow();
        drTemp1[0] = "0";
        drTemp1[1] = "Seleccionar";
        dtTemp1.Rows.Add(drTemp1);

        if (dtcausal.Rows.Count > 0)
        {
            for (int i = 0; i <= dtcausal.Rows.Count; i++)
            {
                try
                {
                    drTemp1 = dtTemp1.NewRow();
                    drTemp1[0] = Convert.ToString(dtcausal.Rows[i]["CodCausalIngreso"]);
                    drTemp1[1] = Convert.ToString(dtcausal.Rows[i]["Descripcion"]);
                    dtTemp1.Rows.Add(drTemp1);
                }
                catch
                {
                }
            }
        }
        if (dtTemp1.Rows.Count > 1)
        {
            try
            {
                ddown_Causal.Items.Clear();
                ddown_Causal.DataSource = dtTemp1;
                ddown_Causal.DataValueField = "CodCausalIngreso";
                ddown_Causal.DataTextField = "Descripcion";
                ddown_Causal.DataBind();

                parCausalesIngresoLRPA1TableAdapter traigocausales = new parCausalesIngresoLRPA1TableAdapter();
                DataTable dtcausales = traigocausales.Get_Xcodcausal(Convert.ToInt32(ddown_TipoCausal.SelectedValue));
                if (dtcausales.Rows.Count > 0)
                {
                    txt_codDelito.Text = dtcausales.Rows[0]["CodNumCausal"].ToString();
                }
                CargoDelito();
            }
            catch (Exception ex)
            {

            }
        }
        else
        {
            ddown_Causal.Items.Clear();
            DataTable dt = new DataTable();
            dt.Columns.Add("CodCausalIngreso");
            dt.Columns.Add("Descripcion");
            DataRow dr = dt.NewRow();

            dr[0] = "0";
            dr[1] = "No disponible";

            dt.Rows.Add(dr);

            ddown_Causal.DataSource = dt;
            ddown_Causal.DataValueField = "CodCausalIngreso";
            ddown_Causal.DataTextField = "Descripcion";
            ddown_Causal.DataBind();
        }
    }

    protected void ddown_Causal_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargoDelito();
    }

    private void CargoDelito()
    {
        parCausalesIngresoLRPA1TableAdapter traigocausales = new parCausalesIngresoLRPA1TableAdapter();
        DataTable dtcausales = traigocausales.Get_Xcodcausal(Convert.ToInt32(ddown_Causal.SelectedValue));
        if (dtcausales.Rows.Count > 0)
        {
            txt_codDelito.Text = dtcausales.Rows[0]["CodNumCausal"].ToString();
        }
    }

    protected void ddown_Proyecto_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddown_RegionProyecto_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargaProyectos();
    }
    public void CargaProyectos()
    {
        Proyectos2TableAdapter proy = new Proyectos2TableAdapter();
        DataTable dtProyectos = proy.Get_ProyectoXregion(Convert.ToInt32(ddown_RegionProyecto.SelectedValue));

        DataTable dtProy = new DataTable();
        dtProy.Columns.Add("CodNombre");
        dtProy.Columns.Add("CodProyecto");

        DataRow drProyecto;
        drProyecto = dtProy.NewRow();
        drProyecto[0] = "Seleccione";
        drProyecto[1] = "0";
        dtProy.Rows.Add(drProyecto);
        for (int i = 0; i <= dtProyectos.Rows.Count; i++)
        {
            try
            {
                drProyecto = dtProy.NewRow();
                drProyecto[0] = "(" + dtProyectos.Rows[i]["Codproyecto"].ToString() + ") " + dtProyectos.Rows[i]["NombreCorto"].ToString();
                drProyecto[1] = dtProyectos.Rows[i]["Codproyecto"].ToString();
                dtProy.Rows.Add(drProyecto);
            }
            catch
            {
            }
        }

        if (dtProy.Rows.Count > 0)
        {
            try
            {
                ddown_Proyecto.Items.Clear();
                ddown_Proyecto.DataSource = dtProy;
                ddown_Proyecto.DataValueField = "Codproyecto";
                ddown_Proyecto.DataTextField = "CodNombre";
                ddown_Proyecto.DataBind();
            }
            catch (Exception ex)
            {

            }
        }
    }
    protected void btnBuscaProyecto_Click(object sender, ImageClickEventArgs e)
    {
        //window.open(this.Page, "../mod_reportes/busca_proyectosNuevaLeyRep.aspx", "Buscador", false, false, 750, 300, false, false, true);
        string cadena = string.Empty;

        cadena = @"window.open(this.Page, '../mod_reportes/busca_proyectosNuevaLeyRep.aspx', 'Buscador', false, false, '750', '300', false, false, true)";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Buscador", cadena, true);
    }


    private bool validarRuc()
    { //true valido
        bool ouput = false;
        if ((String)txt_ruc.Text == "")
        {
            ouput = false;
            return ouput;
        }

        String sConsulta = "select dbo.f_tmpValidaRuc('" + txt_ruc.Text + "')";
        parcoll pc = new parcoll();
        DataTable dt = pc.ejecuta_SQL(sConsulta);
        if (!(dt.Rows.Count > 0 && (bool)dt.Rows[0][0]))
        {
            alerts.Attributes.Add("style", "");
            lbl005.Attributes.Add("style", "");
            lbl005.Text = "RUN INGRESADO NO ES VALIDO.";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "window.alert('RUC INGRESADO NO ES VALIDO.')", true);
            //lblErrorRUC.Visible = true;
            //txt_ruc.BackColor = System.Drawing.colorCampoObligatorio;
            txt_ruc.Text = "";
            ouput = true;
        }
        else
        {
            //lblErrorRUC.Visible = false;
            txt_ruc.BackColor = System.Drawing.Color.Empty;
            ouput = true;
        }
        return ouput;
    }


    protected void btnproy_Click(object sender, EventArgs e)
    {
        //TextBox txt001 = (TextBox)utab.FindControl("txt_test");
        ddown_Proyecto.Items.Clear();
        DataTable dtproy = new DataTable();
        DataRow dr = dtproy.NewRow();
        DataRow dr2 = dtproy.NewRow();
        dtproy.Columns.Add("CodProyecto");
        dtproy.Columns.Add("CodNombre");

        dr[0] = "0";
        dr[1] = "Seleccionar";
        dtproy.Rows.Add(dr);
        dr2[0] = CodProy;
        dr2[1] = "(" + CodProy + ") " + Server.HtmlDecode(NomProy);
        dtproy.Rows.Add(dr2);
        ddown_Proyecto.DataSource = dtproy;
        ddown_Proyecto.DataBind();
        ddown_Proyecto.SelectedValue = CodProy;
    }





    private bool ValidarRut()
    {
        bool output = false;
        if (txt_rut.Text.Trim() != "")
        {
            //lblErrorRut.Visible = false;
            btn_agregar.Visible = true;
            try
            {
                if (txt_rut.Text.Length > 3)
                {
                    string rutsinnada = txt_rut.Text.Replace(".", "").Replace(",", "").Replace("-", "").Trim();
                    string digitoingresado = rutsinnada.Substring(rutsinnada.Length - 1, 1); //aca comienso a buscar usuario

                    string digitocalculado = digitoVerificador(Convert.ToInt32(rutsinnada.ToUpper().Replace("K", "").Substring(0, rutsinnada.Length - 1)));
                    if (digitocalculado.ToUpper() == digitoingresado.ToUpper())
                    {
                        string punorut = rutsinnada.ToUpper().Replace("K", "").Substring(0, rutsinnada.Length - 1).Trim();
                        string rcompleto = punorut + "-" + digitocalculado.ToUpper();
                        //txt_rut.Text = rcompleto;
                        output = true;
                    }
                    else
                    {
                        txt_rut.Text = "";
                        alerts.Attributes.Add("style", "");
                        lbl005.Attributes.Add("style", "");
                        lbl005.Text = "RUN INGRESADO NO ES VALIDO.";
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "window.alert('RUT INGRESADO NO ES VALIDO.')", true);
                        //lblErrorRut.Text = "RUT INGRESADO NO ES VALIDO";
                        //lblErrorRut.Visible = true;
                        btn_agregar.Visible = false;
                    }
                }
                else
                {
                    txt_rut.Text = "";
                    alerts.Attributes.Add("style", "");
                    lbl005.Attributes.Add("style", "");
                    lbl005.Text = "RUN INGRESADO NO ES VALIDO.";
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "window.alert('RUT INGRESADO NO ES VALIDO.')", true);
                    //lblErrorRut.Text = "RUT INGRESADO NO ES VALIDO";
                    //lblErrorRut.Visible = true;
                    btn_agregar.Visible = false;
                }
            }
            catch
            {
                alerts.Attributes.Add("style", "");
                lbl005.Attributes.Add("style", "");
                lbl005.Text = "RUN INGRESADO NO ES VALIDO.";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "window.alert('RUT INGRESADO NO ES VALIDO.')", true);
                //lblErrorRut.Text = "RUT INGRESADO NO ES VALIDO";
                //lblErrorRut.Visible = true;
                btn_agregar.Visible = false;
            }
        }
        return output;
    }

    private string digitoVerificador(int rut)
    {
        int Digito;
        int Contador;
        int Multiplo;
        int Acumulador;
        string RutDigito;

        Contador = 2;
        Acumulador = 0;

        while (rut != 0)
        {
            Multiplo = (rut % 10) * Contador;
            Acumulador = Acumulador + Multiplo;
            rut = rut / 10;
            Contador = Contador + 1;
            if (Contador == 8)
            {
                Contador = 2;
            }

        }

        Digito = 11 - (Acumulador % 11);
        RutDigito = Digito.ToString().Trim();
        if (Digito == 10)
        {
            RutDigito = "K";
        }
        if (Digito == 11)
        {
            RutDigito = "0";
        }
        return (RutDigito);
    }
    protected void rdblist_rut_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdblist_nacionalidad.SelectedValue == "Extranjero")
        {
            txt_rut.Text = string.Empty;
            txt_rut.Enabled = false;
            //ddown_nacionalidad.Enabled = true;
            //ddown_nacionalidad.Items.RemoveAt(0);
            //ddown_tipo_nacionalidad.Items.RemoveAt(0);
            //ddown_tipo_nacionalidad.Items.RemoveAt(0);
            //ddown_tipo_nacionalidad.Items.RemoveAt(2);

            //ddown_tipo_nacionalidad.Enabled = true;
            //ddown_nacionalidad.Enabled = true;

            ddown_nacionalidad.Enabled = true;
            ddown_tipo_nacionalidad.Enabled = true;
        }
        else
        {
            txt_rut.Enabled = true;
            //ddown_nacionalidad.Items.Insert(0, "CHILENA");
            //ddown_nacionalidad.Items.FindByText("CHILENA").Value = "1";
            //ddown_nacionalidad.SelectedIndex = 0;
            //ddown_tipo_nacionalidad.Enabled = false;
            //ddown_nacionalidad.Enabled = false;
            ddown_nacionalidad.Enabled = false;
            ddown_tipo_nacionalidad.Enabled = false;
            ddown_nacionalidad.SelectedValue = "1";

        }
    }



    protected void btn_agregar_Click(object sender, EventArgs e)
    {
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        string rut = txt_rut.Text.Trim();
        string rutsinnada = txt_rut.Text.Trim().Replace(".", "");

        int valido_exito = 0;
        Ninos1TableAdapter nino1 = new Ninos1TableAdapter();
        DataTable dtninoencontrado = new DataTable();
        if (rdblist_nacionalidad.SelectedValue != "Extranjero")
        {
            dtninoencontrado = nino1.Get_nino_por_rut(rutsinnada);
        }

        bool datos_vacios = false;

        if (IdUsuario == null || IdUsuario == 0)
        {
            datos_vacios = true;
        }

        
        if (txt_rut.Text.Trim() == "")
        {
            txt_rut.BackColor = colorCampoObligatorio;
            datos_vacios = true;
        }
        else
        {
            txt_rut.BackColor = Color.Empty;
        }

        if (rdbl_sexo.Items[0].Selected == false && rdbl_sexo.Items[1].Selected == false)
        {
            rdbl_sexo.BackColor = colorCampoObligatorio;
            datos_vacios = true;
        }
        else
        {
            rdbl_sexo.BackColor = Color.Empty;
        }

        if (txt_nombres.Text.Trim() == "")
        {
            txt_nombres.BackColor = colorCampoObligatorio;
            datos_vacios = true;
        }
        else
        {
            txt_nombres.BackColor = Color.Empty;

        }

        if (txt_ap_paterno.Text.Trim() == "")
        {
            txt_ap_paterno.BackColor = colorCampoObligatorio;
            datos_vacios = true;
        }
        else
        {
            txt_ap_paterno.BackColor = Color.Empty;
        }

        if (txt_ap_materno.Text.Trim() == "")
        {
            txt_ap_materno.BackColor = colorCampoObligatorio;
            datos_vacios = true;
        }
        else
        {
            txt_ap_materno.BackColor = Color.Empty;
        }


        if (wdc_Fnacimiento.Text.Trim() == "")
        {
            wdc_Fnacimiento.BackColor = colorCampoObligatorio;
            datos_vacios = true;
        }
        else
        {
            wdc_Fnacimiento.BackColor = Color.Empty;
        }


        if (ddown_nacionalidad.SelectedItem.ToString().Trim() == "Seleccionar")
        {
            ddown_nacionalidad.BackColor = colorCampoObligatorio;
            datos_vacios = true;
        }
        else
        {
            ddown_nacionalidad.BackColor = Color.Empty;
        }
        if (ddown_RegionTribunal.SelectedItem.ToString().Trim() == "Seleccionar")
        {
            ddown_RegionTribunal.BackColor = colorCampoObligatorio;
            datos_vacios = true;
        }
        else
        {
            ddown_RegionTribunal.BackColor = Color.Empty;
        }

        if (ddown_TipoTribunal.SelectedItem.ToString().Trim() == "Seleccionar")
        {
            ddown_TipoTribunal.BackColor = colorCampoObligatorio;
            datos_vacios = true;
        }
        else
        {
            ddown_TipoTribunal.BackColor = Color.Empty;
        }
        if (ddown_Tribunal.SelectedItem.ToString().Trim() == "Seleccionar")
        {
            ddown_Tribunal.BackColor = colorCampoObligatorio;
            datos_vacios = true;
        }
        else
        {
            ddown_Tribunal.BackColor = Color.Empty;
        }
        if (ddown_TipoCausal.SelectedItem.ToString().Trim() == "Seleccionar")
        {
            ddown_TipoCausal.BackColor = colorCampoObligatorio;
            datos_vacios = true;
        }
        else
        {
            ddown_TipoCausal.BackColor = Color.Empty;
        }
        if (ddown_Causal.SelectedItem.ToString().Trim() == "Seleccionar")
        {
            ddown_Causal.BackColor = colorCampoObligatorio;
            datos_vacios = true;
        }
        else
        {
            ddown_Causal.BackColor = Color.Empty;
        }
        if (ddown_RegionProyecto.SelectedItem.ToString().Trim() == "Seleccionar")
        {
            ddown_RegionProyecto.BackColor = colorCampoObligatorio;
            datos_vacios = true;
        }
        else
        {
            ddown_RegionProyecto.BackColor = Color.Empty;
        }
        if (ddown_Proyecto.SelectedItem.ToString().Trim() == "Seleccione")
        {
            ddown_Proyecto.BackColor = colorCampoObligatorio;
            datos_vacios = true;
        }
        else
        {
            ddown_Proyecto.BackColor = Color.Empty;
        }

        if (wdc_fechaRecepcion.Text == "")
        {
            wdc_fechaRecepcion.BackColor = colorCampoObligatorio;
            datos_vacios = true;
        }
        else
        {
            wdc_fechaRecepcion.BackColor = Color.Empty;
        }

        if (wdc_fecha.Text == "")
        {
            wdc_fecha.BackColor = colorCampoObligatorio;
            datos_vacios = true;
        }
        else
        {
            wdc_fecha.BackColor = Color.Empty;
        }


        if (txt_Folio.Text == " ")
        {
            txt_Folio.BackColor = colorCampoObligatorio;
            datos_vacios = true;
        }
        else
        {
            txt_Folio.BackColor = Color.Empty;
        }
        if (txt_ruc.Text == "")
        {
            txt_ruc.BackColor = colorCampoObligatorio;
            datos_vacios = true;
        }
        else
        {
            if (validarRuc())
            {
                txt_ruc.BackColor = Color.Empty;
            }
        }



        if (dtninoencontrado.Rows.Count > 0 && datos_vacios == false && rdblist_nacionalidad.SelectedValue != "Extranjero") // encontro a un niño
        {
            CoordinadorJudicialTableAdapter getcoord = new CoordinadorJudicialTableAdapter();
            DataTable dtcoord = getcoord.Get_xCodNino(Convert.ToInt32(dtninoencontrado.Rows[0]["codnino"]));

            bool exists = false;

            if (dtcoord.Rows.Count > 0)
            {
                for (int i = 0; i < dtcoord.Rows.Count; i++)
                {
                    if ((dtcoord.Rows[i]["CodCausalIngreso"].ToString() == ddown_Causal.SelectedValue.ToString()) && (dtcoord.Rows[i]["CodProyecto"].ToString() == ddown_Proyecto.SelectedValue.ToString())) //&& (Request.QueryString["ingreso"] == null))
                    {
                        if (dtcoord.Rows[i]["RUC"].ToString() == txt_ruc.Text && dtcoord.Rows[i]["CodSancionCoordinador"].ToString() == ddl_sancion.SelectedValue.ToString())
                        {
                            exists = true;
                        }
                        else
                        {
                            //exists = false;
                        }
                    }
                }
            }
            if (exists == false)
            {
                //lbl_existe.Visible = false;
                try
                {
                    if (Request.QueryString["ingreso"] != null) // actualizar
                    {

                        CoordinadorJudicialTableAdapter actualizoCJ = new CoordinadorJudicialTableAdapter();
                        actualizoCJ.Update_coordinador(
                            Convert.ToInt32(lbl_CodNino.Text),
                            Convert.ToInt32(ddown_Tribunal.SelectedValue),
                            txt_ruc.Text.Trim(),
                            txt_rit.Text.Trim(),
                            Convert.ToDateTime(wdc_fecha.Text),
                            Convert.ToInt32(ddown_Causal.SelectedValue),
                            Convert.ToInt32(ddown_Proyecto.SelectedValue),
                            //Convert.ToInt32(Session["IdUsuario"].ToString()),
                            IdUsuario,
                            Convert.ToDateTime(DateTime.Now),
                            Convert.ToInt32(rdblst_Sancion.SelectedValue),
                            Convert.ToInt32(rdblst_Adn.SelectedValue),
                            Convert.ToInt32(ddl_sancion.SelectedValue),
                            Convert.ToInt32(rdblst_Pena.SelectedValue),
                            Convert.ToDateTime(wdc_fechaRecepcion.Text),
                            Convert.ToInt32(txt_Folio.Text),
                            Convert.ToInt32(Request.QueryString["ingreso"]));

                        Limpiar();
                        valido_exito = 1;


                    }
                    else // insertar
                    {
                        if (ValidaFolio(Convert.ToInt32(txt_Folio.Text)))
                        {
                            CoordinadorJudicialTableAdapter insertarCJ = new CoordinadorJudicialTableAdapter();
                            insertarCJ.Insertar_coordinadorj(
                                Convert.ToInt32(lbl_CodNino.Text),
                                Convert.ToInt32(ddown_Tribunal.SelectedValue),
                                txt_ruc.Text.Trim(),
                                txt_rit.Text.Trim(),
                                Convert.ToDateTime(wdc_fecha.Text),
                                Convert.ToInt32(ddown_Causal.SelectedValue),
                                Convert.ToInt32(ddown_Proyecto.SelectedValue),
                                //Convert.ToInt32(Session["IdUsuario"].ToString()),
                                IdUsuario,
                                Convert.ToDateTime(DateTime.Now),
                                Convert.ToInt32(rdblst_Sancion.SelectedValue),
                                Convert.ToInt32(rdblst_Adn.SelectedValue),
                                Convert.ToInt32(ddl_sancion.SelectedValue),
                                Convert.ToInt32(rdblst_Pena.SelectedValue),
                                Convert.ToDateTime(wdc_fechaRecepcion.Text),
                                Convert.ToInt32(txt_Folio.Text)
                                );

                            Limpiar();
                            valido_exito = 2;
                        }
                    }
                }
                catch (Exception ex)
                {
                    valido_exito = 0;
                }
                finally
                {
                    //lbl_existe.Visible = false;
                    if (valido_exito == 1)
                    {
                        alerts2.Attributes.Add("style", "");
                        lbl0052.Attributes.Add("style", "");
                        lbl0052.Text = "Se ha Agregado con Éxito.";
                        ///Response.Redirect("successwindow.aspx?pag=actualizo");
                    }
                    else if (valido_exito == 2)
                    {
                        alerts2.Attributes.Add("style", "");
                        lbl0052.Attributes.Add("style", "");
                        lbl0052.Text = "Se ha Agregado con Éxito.";
                    }
                    else
                    {
                        alerts.Attributes.Add("style", "");
                        lbl005.Attributes.Add("style", "");
                        lbl005.Text = "Hay un Error con los Datos Ingresados, Favor Revisar.";
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "window.alert('Se ha producido un error inesperado, reintente mas tarde.')", true);                        
                        //lbl_existe.Text = "Se ha producido un error inesperado, reintente mas tarde.";
                        //lbl_existe.Visible = true;
                    }
                    //txt_rut.Text = rutsinnada;
                }
            }

            else if (exists && Request.QueryString["ingreso"] != null)
            {
                try
                {
                    if (Request.QueryString["ingreso"] != null) // actualizar
                    {

                        CoordinadorJudicialTableAdapter actualizoCJ = new CoordinadorJudicialTableAdapter();
                        actualizoCJ.Update_coordinador(
                            Convert.ToInt32(lbl_CodNino.Text),
                            Convert.ToInt32(ddown_Tribunal.SelectedValue),
                            txt_ruc.Text.Trim(),
                            txt_rit.Text.Trim(),
                            Convert.ToDateTime(wdc_fecha.Text),
                            Convert.ToInt32(ddown_Causal.SelectedValue),
                            Convert.ToInt32(ddown_Proyecto.SelectedValue),
                            //Convert.ToInt32(Session["IdUsuario"].ToString()),
                            IdUsuario,
                            Convert.ToDateTime(DateTime.Now),
                            Convert.ToInt32(rdblst_Sancion.SelectedValue),
                            Convert.ToInt32(rdblst_Adn.SelectedValue),
                            Convert.ToInt32(ddl_sancion.SelectedValue),
                            Convert.ToInt32(rdblst_Pena.SelectedValue),
                            Convert.ToDateTime(wdc_fechaRecepcion.Text),
                            Convert.ToInt32(txt_Folio.Text),
                            Convert.ToInt32(Request.QueryString["ingreso"]));

                        Limpiar();
                        valido_exito = 1;
                    }
                }
                catch (Exception ex)
                {
                    valido_exito = 0;
                }
                finally
                {
                    //lbl_existe.Visible = false;
                    if (valido_exito == 1)
                    {
                        alerts2.Attributes.Add("style", "");
                        lbl0052.Attributes.Add("style", "");
                        lbl0052.Text = "Se ha actualizado con exito.";
                        //Response.Redirect("successwindow.aspx?pag=actualizo");
                    }
                    else
                    {
                        alerts.Attributes.Add("style", "");
                        lbl005.Attributes.Add("style", "");
                        lbl005.Text = "Hay un Error con los Datos Ingresados, Favor Revisar.";
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "window.alert('Se ha producido un error inesperado, reintente mas tarde.')", true);
                        //lbl_existe.Text = "Se ha producido un error inesperado, reintente mas tarde.";
                        //lbl_existe.Visible = true;
                    }
                    //txt_rut.Text = rutsinnada;
                    //txt_rut.Text = rut;
                }
            }
            else // el niño ya tiene un registro en el mismo proyecto, NO SE INGRESAN DATOS Y SE DA ALERTA
            {
                alerts.Attributes.Add("style", "");
                lbl005.Attributes.Add("style", "");
                lbl005.Text = "Ingreso no válido, ya se encontraron registros para este niño(a).";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "window.alert('Ingreso no válido, ya se encontraron registros para este niño(a).')", true);
                //lbl_existe.Text = "Ingreso no válido, ya se encontraron registros para este niño(a).";
                //lbl_existe.Visible = true;
            }
        }
        else if (dtninoencontrado.Rows.Count == 0 && datos_vacios == false && rdblist_nacionalidad.SelectedValue != "Extranjero")// no encontro niño, por lo cual no solo registramos en coordinador judicial sino que agregamos al niño en la tabla ninos
        {
            try
            {
                Ninos1TableAdapter ingresonuevo = new Ninos1TableAdapter();
                ingresonuevo.Insert_nino(
                    Convert.ToDateTime("1900-01-01 00:00:00.000"),
                    false,
                    rutsinnada,
                    Convert.ToString(rdbl_sexo.SelectedValue),
                    txt_nombres.Text.Trim().ToUpper(),
                    txt_ap_paterno.Text.Trim().ToUpper(),
                    txt_ap_materno.Text.Trim().ToUpper(),
                    Convert.ToDateTime(wdc_Fnacimiento.Text),
                    Convert.ToInt32(ddown_nacionalidad.SelectedValue),
                    0,
                    "0",
                    0,
                    "0",
                    "0",
                    false,
                    false,
                    false,
                    "N",
                    DateTime.Now,
                    //Convert.ToInt32(Session["IdUsuario"]),
                    IdUsuario,
                    0,
                    null, 0);

                Ninos1TableAdapter nino2 = new Ninos1TableAdapter();
                DataTable dtninoencontrado2 = nino1.Get_nino_por_rut(rutsinnada); //(txt_rut.Text.Trim());
                lbl_CodNino.Text = dtninoencontrado2.Rows[0]["CodNino"].ToString();

                if (Request.QueryString["ingreso"] != null) // actualizar
                {
                    CoordinadorJudicialTableAdapter actualizoCJ = new CoordinadorJudicialTableAdapter();
                    actualizoCJ.Update_coordinador(
                        Convert.ToInt32(lbl_CodNino.Text),
                        Convert.ToInt32(ddown_Tribunal.SelectedValue),
                        txt_ruc.Text.Trim(),
                        txt_rit.Text.Trim(),
                        Convert.ToDateTime(wdc_fecha.Text),
                        Convert.ToInt32(ddown_Causal.SelectedValue),
                        Convert.ToInt32(ddown_Proyecto.SelectedValue),
                        Convert.ToInt32(Session["IdUsuario"].ToString()),
                        Convert.ToDateTime(DateTime.Now),
                        Convert.ToInt32(rdblst_Sancion.SelectedValue),
                        Convert.ToInt32(rdblst_Adn.SelectedValue),
                        Convert.ToInt32(ddl_sancion.SelectedValue),
                        Convert.ToInt32(rdblst_Pena.SelectedValue),
                        Convert.ToDateTime(wdc_fechaRecepcion.Text),
                        Convert.ToInt32(txt_Folio.Text),
                        Convert.ToInt32(Request.QueryString["ingreso"]));

                    Limpiar();
                    valido_exito = 3;

                }
                else // insertar
                {
                    if (ValidaFolio(Convert.ToInt32(txt_Folio.Text)))
                    {
                        CoordinadorJudicialTableAdapter insertarCJ = new CoordinadorJudicialTableAdapter();
                        insertarCJ.Insertar_coordinadorj(
                            Convert.ToInt32(lbl_CodNino.Text),
                            Convert.ToInt32(ddown_Tribunal.SelectedValue),
                            txt_ruc.Text.Trim(),
                            txt_rit.Text.Trim(),
                            Convert.ToDateTime(wdc_fecha.Text),
                            Convert.ToInt32(ddown_Causal.SelectedValue),
                            Convert.ToInt32(ddown_Proyecto.SelectedValue),
                            //Convert.ToInt32(Session["IdUsuario"].ToString()),
                            IdUsuario,
                            Convert.ToDateTime(DateTime.Now),
                            Convert.ToInt32(rdblst_Sancion.SelectedValue),
                            Convert.ToInt32(rdblst_Adn.SelectedValue),
                            Convert.ToInt32(ddl_sancion.SelectedValue),
                            Convert.ToInt32(rdblst_Pena.SelectedValue),
                            Convert.ToDateTime(wdc_fechaRecepcion.Text),
                            Convert.ToInt32(txt_Folio.Text)
                            );

                        Limpiar();
                        valido_exito = 4;
                    }
                }
            }
            catch (Exception ex)
            {
                valido_exito = 0;
            }
            finally
            {
                if (valido_exito == 3)
                {
                    alerts2.Attributes.Add("style", "");
                    lbl0052.Attributes.Add("style", "");
                    lbl0052.Text = "Se ha Actualizado con Éxito.";
                    //Response.Redirect("successwindow.aspx?pag=actualizo");
                }
                else if (valido_exito == 4)
                {
                    alerts2.Attributes.Add("style", "");
                    lbl0052.Attributes.Add("style", "");
                    lbl0052.Text = "Se ha Agregado con Éxito.";
                    //Response.Redirect("successwindow.aspx?pag=ingreso");
                }
                else
                {
                    alerts.Attributes.Add("style", "");
                    lbl005.Attributes.Add("style", "");
                    lbl005.Text = "Hay un Error con los Datos Ingresados, Favor Revisar.";
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "window.alert('Se ha producido un error inesperado, reintente mas tarde.')", true);
                    //lbl_existe.Text = "Se ha producido un error inesperado, reintente mas tarde.";
                    //lbl_existe.Visible = true;
                }
                //txt_rut.Text = rutsinnada;
            }
        }
        else if (dtninoencontrado.Rows.Count == 0 && datos_vacios == false && rdblist_nacionalidad.SelectedValue == "Extranjero")// no encontro niño, ademas es extranjero, por lo cual no solo registramos en coordinador judicial sino que agregamos al niño en la tabla ninos con rut 0
        {
            try
            {
                Ninos1TableAdapter ingresonuevo = new Ninos1TableAdapter();
                ingresonuevo.Insert_nino(
                    Convert.ToDateTime("1900-01-01 00:00:00.000"),
                    false,
                    "0",
                    Convert.ToString(rdbl_sexo.SelectedValue),
                    txt_nombres.Text.Trim().ToUpper(),
                    txt_ap_paterno.Text.Trim().ToUpper(),
                    txt_ap_materno.Text.Trim().ToUpper(),
                    Convert.ToDateTime(wdc_Fnacimiento.Text),
                    Convert.ToInt32(ddown_nacionalidad.SelectedValue),
                    0,
                    "0",
                    0,
                    "0",
                    "0",
                    false,
                    false,
                    false,
                    "N",
                    DateTime.Now,
                    //Convert.ToInt32(Session["IdUsuario"]),
                    IdUsuario,
                    0,
                    null, 0);

                NinosTableAdapter nino2 = new NinosTableAdapter();
                DataTable dtninoencontrado2 = nino2.Get_extranjero
                    (rdbl_sexo.SelectedValue,
                    txt_nombres.Text.Trim().ToUpper(),
                    txt_ap_paterno.Text.Trim().ToUpper(),
                    txt_ap_materno.Text.Trim().ToUpper(),
                    Convert.ToDateTime(wdc_Fnacimiento.Text));

                lbl_CodNino.Text = dtninoencontrado2.Rows[0]["CodNino"].ToString();

                if (Request.QueryString["ingreso"] != null) // actualizar
                {
                    CoordinadorJudicialTableAdapter actualizoCJ = new CoordinadorJudicialTableAdapter();
                    actualizoCJ.Update_coordinador(
                        Convert.ToInt32(lbl_CodNino.Text),
                        Convert.ToInt32(ddown_Tribunal.SelectedValue),
                        txt_ruc.Text.Trim(),
                        txt_rit.Text.Trim(),
                        Convert.ToDateTime(wdc_fecha.Text),
                        Convert.ToInt32(ddown_Causal.SelectedValue),
                        Convert.ToInt32(ddown_Proyecto.SelectedValue),
                        //Convert.ToInt32(Session["IdUsuario"].ToString()),
                        IdUsuario,
                        Convert.ToDateTime(DateTime.Now),
                        Convert.ToInt32(rdblst_Sancion.SelectedValue),
                        Convert.ToInt32(rdblst_Adn.SelectedValue),
                        Convert.ToInt32(ddl_sancion.SelectedValue),
                        Convert.ToInt32(rdblst_Pena.SelectedValue),
                        Convert.ToDateTime(wdc_fechaRecepcion.Text),
                        Convert.ToInt32(txt_Folio.Text),
                        Convert.ToInt32(Request.QueryString["ingreso"]));

                    Limpiar();
                    valido_exito = 3;

                }
                else // insertar
                {
                    if (ValidaFolio(Convert.ToInt32(txt_Folio.Text)))
                    {
                        CoordinadorJudicialTableAdapter insertarCJ = new CoordinadorJudicialTableAdapter();
                        insertarCJ.Insertar_coordinadorj(
                            Convert.ToInt32(lbl_CodNino.Text),
                            Convert.ToInt32(ddown_Tribunal.SelectedValue),
                            txt_ruc.Text.Trim(),
                            txt_rit.Text.Trim(),
                            Convert.ToDateTime(wdc_fecha.Text),
                            Convert.ToInt32(ddown_Causal.SelectedValue),
                            Convert.ToInt32(ddown_Proyecto.SelectedValue),
                            //Convert.ToInt32(Session["IdUsuario"].ToString()),
                            IdUsuario,
                            Convert.ToDateTime(DateTime.Now),
                            Convert.ToInt32(rdblst_Sancion.SelectedValue),
                            Convert.ToInt32(rdblst_Adn.SelectedValue),
                            Convert.ToInt32(ddl_sancion.SelectedValue),
                            Convert.ToInt32(rdblst_Pena.SelectedValue),
                            Convert.ToDateTime(wdc_fechaRecepcion.Text),
                            Convert.ToInt32(txt_Folio.Text)
                            );

                        Limpiar();
                        valido_exito = 4;
                    }
                }
            }
            catch (Exception ex)
            {
                valido_exito = 0;
            }
            finally
            {
                if (valido_exito == 3)
                {
                    alerts2.Attributes.Add("style", "");
                    lbl0052.Attributes.Add("style", "");
                    lbl0052.Text = "Actualizo Satisfactoriamente.";
                    Limpiar2();
                    //Response.Write("<script language='javascript'>alert('Actualizo Satisfactoriamente. ');</script>");  
                    //Response.Redirect("successwindow.aspx?pag=actualizo");
                }
                else if (valido_exito == 4)
                {
                    alerts2.Attributes.Add("style", "");
                    lbl0052.Attributes.Add("style", "");
                    lbl0052.Text = "Ingreso Satisfactoriamente.";
                    //Response.Write("<script language='javascript'>alert('Ingreso Satisfactoriamente. ');</script>");  
                    //Response.Redirect("successwindow.aspx?pag=ingreso");
                    Limpiar2();
                }
                else
                {
                    alerts.Attributes.Add("style", "");
                    lbl005.Attributes.Add("style", "");
                    lbl005.Text = "Hay un Error con los Datos Ingresados, Favor Revisar.";
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "window.alert('Se ha producido un error inesperado, reintente mas tarde.')", true);
                    //lbl_existe.Text = "Se ha producido un error inesperado, reintente mas tarde.";
                    //lbl_existe.Visible = true;
                }
                //txt_rut.Text = rutsinnada;
            }
        }
    }
    protected void btn_limpiar_Click(object sender, EventArgs e)
    {
        Limpiar();
        HabilitoCajas();
        CargoFolioNuevo();
        ddown_RegionTribunal.SelectedValue = "-2";
    }
    protected void btn_Cerrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("index_coordinadores.aspx");
    }
    protected void ImageButton1_Click(object sender, EventArgs e)
    {
        if (ValidarRut())
        //if (validarRuc())
        {
            Function_Consulta();
        }

    }

    private void Function_Consulta()
    {
        List<DbParameter> listDbParameter = new List<DbParameter>();

        string rut = txt_rut.Text.Trim();

        string sParametrosConsulta = "Select Distinct top 201 T2.CodNino,T2.Rut,T2.Sexo,T2.Nombres,T2.Apellido_paterno,T2.Apellido_Materno," +
                               "T2.FechaNacimiento, T2.CodNacionalidad From Ninos T2 ";

        if (txt_rut.Text.Trim() != "" || txt_ap_paterno.Text.Trim() != "" ||
                txt_ap_materno.Text.Trim() != "" || txt_nombres.Text.Trim() != "")
        {
            sParametrosConsulta = sParametrosConsulta + "Where ";
        }

        if (txt_ap_paterno.Text.Trim() != "")
        {
            sParametrosConsulta = sParametrosConsulta + " T2.Apellido_Paterno like @pApellido_Paterno And";

            listDbParameter.Add(Conexiones.CrearParametro("@pApellido_Paterno", SqlDbType.VarChar, 50, "%" + txt_ap_paterno.Text + "%"));
        }
        if (txt_ap_materno.Text.Trim() != "")
        {
            sParametrosConsulta = sParametrosConsulta + " T2.Apellido_Materno like @pApellido_Materno And";

            listDbParameter.Add(Conexiones.CrearParametro("@pApellido_Materno", SqlDbType.VarChar, 50, "%" + txt_ap_materno.Text + "%"));
        }
        if (txt_nombres.Text.Trim() != "")
        {
            sParametrosConsulta = sParametrosConsulta + " T2.Nombres like @pNombres And";

            listDbParameter.Add(Conexiones.CrearParametro("@pNombres", SqlDbType.VarChar, 100, "%" + txt_nombres.Text + "%"));
        }
        if (txt_rut.Text.Trim() != "")
        {
            sParametrosConsulta = sParametrosConsulta + " T2.Rut =@pRut And";

            listDbParameter.Add(Conexiones.CrearParametro("@pRut", SqlDbType.VarChar, 11, txt_rut.Text.Trim().Replace(".","")));
        }

        if (sParametrosConsulta.Substring(sParametrosConsulta.Length - 3, 3) == "And")
        {
            sParametrosConsulta = sParametrosConsulta.Substring(0, sParametrosConsulta.Length - 3);
        }


        ninocoll nic = new ninocoll();
        DataTable dt = nic.get_ninorelacionado(sParametrosConsulta, listDbParameter);

        if (dt.Rows.Count == 1)
        {

            if (dt.Rows[0]["Rut"].ToString() == "0")
            {
                txt_rut.Text = string.Empty;
                rdblist_nacionalidad.SelectedValue = "Extranjero";
            }
            else
            {
                //txt_rut.Text = Convert.ToString(dt.Rows[0]["Rut"]); 
                txt_rut.Text = rut;
                rdblist_nacionalidad.SelectedValue = "Chileno";
            }

            txt_nombres.Text = Convert.ToString(dt.Rows[0]["Nombres"]);
            txt_ap_paterno.Text = Convert.ToString(dt.Rows[0]["Apellido_paterno"]);
            txt_ap_materno.Text = Convert.ToString(dt.Rows[0]["Apellido_materno"]);
            rdbl_sexo.SelectedValue = Convert.ToString(dt.Rows[0]["Sexo"]);
            wdc_Fnacimiento.Text = Convert.ToString(dt.Rows[0]["FechaNacimiento"]).Substring(0, 10);
            ddown_nacionalidad.SelectedValue = Convert.ToString(dt.Rows[0]["CodNacionalidad"]);
            lbl_CodNino.Text = dt.Rows[0]["CodNino"].ToString();
            //falta llenar todos los otros combos ?
            //grd004.Visible = false;
            ImageButton1.Visible = false;
            DeshabilitoCajas();
        }
        else if (dt.Rows.Count == 0)
        {
            alerts.Attributes.Add("style", "");
            lbl005.Attributes.Add("style", "");
            lbl005.Text = "RUN Ingresado no se Encuentra.";
        }
        else
        {
            DTBusqueda = dt;
            carga_grilla();
        }
        
    }

    protected void ddownTipoNac_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddown_nacionalidad.Items.FindByValue("1").Enabled = true;
        if (ddown_tipo_nacionalidad.SelectedValue == "1" || ddown_tipo_nacionalidad.SelectedValue == "3") // verifica si se selecciona tipo de nacionalidad chileno o nacionalizado 
        {
            if (ddown_nacionalidad.Items.FindByValue("2").Enabled == true) //verifica si las nacionalidades que no son chilenas estan visibles
            {
                for (int i = 2; i <= ddown_nacionalidad.Items.Count; i++)
                {
                    if (i != 8) //no existe el value 8
                    {
                        ddown_nacionalidad.Items.FindByValue(Convert.ToString(i)).Enabled = false;
                        ddown_nacionalidad.Enabled = true;
                    }
                }
            }
            ddown_nacionalidad.SelectedValue = "1";
        }
        else // todas las demas
        {
            if (ddown_nacionalidad.Items.FindByValue("2").Enabled == false) //verifica si las nacionalidades que no son chilenas estan ocultas
            {
                for (int i = 2; i <= ddown_nacionalidad.Items.Count; i++)
                {
                    if (i != 8) //no existe el value 8
                    {
                        ddown_nacionalidad.Items.FindByValue(Convert.ToString(i)).Enabled = true;
                        ddown_nacionalidad.Enabled = true;
                    }
                }
            }
            if (ddown_tipo_nacionalidad.SelectedValue == "2") // verifica si se selecciona tipo de nacionalidad extrangero (ocultar nacionalidad chilena)
            {
                ddown_nacionalidad.Items.FindByValue("1").Enabled = false; // oculta nacionalidad chilena
                ddown_nacionalidad.Enabled = true;
            }
        }
    }
}
