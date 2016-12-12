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

using Argentis.Regmen;


using System.Drawing;

using System.Collections.Generic;
using System.Data.Common;

public partial class mod_jueces_ImageNow_CapturaInf : System.Web.UI.Page
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Request.QueryString["icodie"] != null && Request.QueryString["ruc"] != null)
            {
                List<DbParameter> listDbParameter = new List<DbParameter>();

                string sParametrosConsulta = "select a.ICodIE, a.CodNino  , c.Rut, c.CodNacionalidad, " +
                                " c.Apellido_Paterno, c.Apellido_Materno, c.Nombres, c.Sexo, c.FechaNacimiento, d.Descripcion Nacionalidad," +
                                " e.CodTribunal, " +
                                " (select z2.Descripcion from parTribunales z, parRegion z2  " +
                                " where e.CodTribunal = z.CodTribunal " +
                                " and z.CodRegion = z2.CodRegion ) RegionTribunal, " +
                                " (select z2.Descripcion from parTribunales z, parTipoTribunal z2  " +
                                " where e.CodTribunal = z.CodTribunal " +
                                "  and z.TipoTribunal = z2.TipoTribunal) TipoTribunal, " +
                                " (select z.Descripcion from parTribunales z " +
                                " where e.CodTribunal = z.CodTribunal) Tribunal, " +
                                " e.Ruc, e.Rit, f.CodCausalIngreso, g.CodTipoCausalIngreso , " +
                                " (select z.Descripcion from parTipoCausalIngreso z where g.CodTipoCausalIngreso = z.CodTipoCausalIngreso) TipoDelito, " +
                                " g.Descripcion Delito, g.CodNumCausal CodigoDelito, b.CodRegion , h.Descripcion RegionProyecto, a.CodProyecto , ltrim(rtrim(b.Nombre)) NombreProyecto, " +
                                " cast(cast(a.CodProyecto as CHAR(10)) +  ltrim(rtrim(b.Nombre)) as char(200)) Proyecto" +
                                " from Ingresos_Egresos a inner join Proyectos b on a.CodProyecto = b.CodProyecto " +
                                " inner join Ninos c on a.CodNino = c.CodNino " +
                                " inner join parNacionalidades d on c.CodNacionalidad = d.CodNacionalidad " +
                                " left join OrdenTribunalIngreso e on a.ICodIE = e.ICodIE " +
                                " left join CausalesIngreso f on a.ICodIE = f.ICodIE and e.ICodTribunalIngreso = f.ICodTribunalIngreso " +
                                " left join parCausalesIngreso g on f.CodCausalIngreso = g.CodCausalIngreso " +
                                " inner join parRegion h on b.CodRegion = h.CodRegion " +
                                " where a.ICodIE =@pICodIE " + 
                                " and  e.Ruc = @pRuc ";

                listDbParameter.Add(Conexiones.CrearParametro("@pICodIE", SqlDbType.Int, 4, Convert.ToInt32(Request.QueryString["icodie"])));
                listDbParameter.Add(Conexiones.CrearParametro("@pRuc", SqlDbType.VarChar, 100, Request.QueryString["ruc"].ToString().Trim()));

                ninocoll nic = new ninocoll();
                DataTable dt = nic.get_CapturaRucIcodei(sParametrosConsulta, listDbParameter);

                if (dt.Rows.Count == 1)
                {
                    TxtICodIE.Text = Convert.ToString(dt.Rows[0]["icodie"]);
                    TxtCodNino.Text = Convert.ToString(dt.Rows[0]["Codnino"]);
                    if (dt.Rows[0]["Rut"].ToString() == "0")
                    {
                        txt_rut.Text = string.Empty;
                        rdblist_nacionalidad.SelectedValue = "Extranjero";
                    }
                    else
                    {
                        txt_rut.Text = Convert.ToString(dt.Rows[0]["Rut"]);
                        rdblist_nacionalidad.SelectedValue = "Chileno";
                    }
                    txt_ap_paterno.Text = Convert.ToString(dt.Rows[0]["Apellido_paterno"]);
                    txt_ap_materno.Text = Convert.ToString(dt.Rows[0]["Apellido_materno"]);
                    txt_nombres.Text = Convert.ToString(dt.Rows[0]["Nombres"]);
                    rdbl_sexo.SelectedValue = Convert.ToString(dt.Rows[0]["Sexo"]);
                    wdc_Fnacimiento.Text = Convert.ToString(dt.Rows[0]["FechaNacimiento"]).Substring(0, 10);
                    txt_nacionalidad.Text = Convert.ToString(dt.Rows[0]["Nacionalidad"]);
                    TxtRegionTribunal.Text = Convert.ToString(dt.Rows[0]["RegionTribunal"]);
                    TxtTipoTribunal.Text = Convert.ToString(dt.Rows[0]["tipotribunal"]);
                    TxtTribunal.Text = Convert.ToString(dt.Rows[0]["tribunal"]);
                    txt_ruc.Text = Convert.ToString(dt.Rows[0]["ruc"]);
                    txt_rit.Text = Convert.ToString(dt.Rows[0]["rit"]);
                    TxtTipoDelito.Text = Convert.ToString(dt.Rows[0]["tipodelito"]);
                    TxtDelito.Text = Convert.ToString(dt.Rows[0]["delito"]);
                    txt_codDelito.Text = Convert.ToString(dt.Rows[0]["CodigoDelito"]);
                    TxtRegionProyecto.Text = Convert.ToString(dt.Rows[0]["RegionProyecto"]);
                    TxtProyecto.Text = Convert.ToString(dt.Rows[0]["proyecto"]);
                }
                else
                {


                }
            }

        }
    }

    public void ValidoPermisos()
    {
        //F6DC09AD-5F04-4F95-BF81-B806C49B66BA coordinador nacional 
        if (window.existetoken("F6DC09AD-5F04-4F95-BF81-B806C49B66BA"))
        {
            //btn_agregar.Visible = true;
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
                            //btn_agregar.Visible = false;
                        }
                        else
                        {
                            //btn_agregar.Visible = true;
                        }
                    }
                }
            }
        }
    }



    protected void btn_buscar_Click(object sender, EventArgs e)
    {


    }
    private void Function_Consulta()
    {
        List<DbParameter> listDbParameter = new List<DbParameter>();

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

            listDbParameter.Add(Conexiones.CrearParametro("@pRut", SqlDbType.VarChar, 11, txt_rut.Text.Trim()));
        }

        if (sParametrosConsulta.Substring(sParametrosConsulta.Length - 3, 3) == "And")
        {
            sParametrosConsulta = sParametrosConsulta.Substring(0, sParametrosConsulta.Length - 3);
        }


        ninocoll nic = new ninocoll();
        DataTable dt = nic.get_ninorelacionado(sParametrosConsulta, listDbParameter);

        if (dt.Rows.Count == 1)
        {
            //lnk_resultados.Visible = false;
            //lnk_resultados.Visible = false;
            //lbl_encontrados.Visible = false;
            //lbl001.Visible = false;
            //lbl_error.Visible = false;

            if (dt.Rows[0]["Rut"].ToString() == "0")
            {
                txt_rut.Text = string.Empty;
                rdblist_nacionalidad.SelectedValue = "Extranjero";
            }
            else
            {
                txt_rut.Text = Convert.ToString(dt.Rows[0]["Rut"]);
                rdblist_nacionalidad.SelectedValue = "Chileno";
            }

            txt_nombres.Text = Convert.ToString(dt.Rows[0]["Nombres"]);
            txt_ap_paterno.Text = Convert.ToString(dt.Rows[0]["Apellido_paterno"]);
            txt_ap_materno.Text = Convert.ToString(dt.Rows[0]["Apellido_materno"]);
            rdbl_sexo.SelectedValue = Convert.ToString(dt.Rows[0]["Sexo"]);
            wdc_Fnacimiento.Text = Convert.ToString(dt.Rows[0]["FechaNacimiento"]).Substring(0, 10);

        }

        else if (dt.Rows.Count > 0 && dt.Rows.Count < 200)
        {
        }
        else if (dt.Rows.Count == 0)
        {
        }
        else if (dt.Rows.Count > 200)
        {
        }
    }





    protected void grd004_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //grd004.PageIndex = e.NewPageIndex;
        carga_grilla();
    }
    protected void grd004_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    public void carga_grilla()
    {

    }
    protected void lnk_resultados_Click(object sender, EventArgs e)
    {
        carga_grilla();
    }


    protected void btn_Cerrar_Click(object sender, EventArgs e)
    {

        window.close(this.Page);
    }

    protected void ddown_TipoCausal_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


    protected void ddown_Proyecto_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Function_Consulta();
    }


    protected void rdblist_rut_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdblist_nacionalidad.SelectedValue == "Extranjero")
        {
            txt_rut.Text = string.Empty;
            txt_rut.Enabled = false;
        }
        else
        {
            txt_rut.Enabled = true;
        }
    }

    protected void txt_rut_ValueChange(object sender, EventArgs e)
    {

    }
    protected void ddown_RegionProyecto_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddown_TipoTribunal_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void ddown_RegionTribunal_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void txt_ruc_ValueChange(object sender, EventArgs e)
    {

    }
}
