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
using System.Text.RegularExpressions;

public partial class mod_ninos_AntecedentesJudicialesPRJ : System.Web.UI.Page
{

    public enum querytype
    {
        Categoria,
        SubCategoria,
        CausaFamilia = 1,
        CausaPenal = 2
    }

    public DataTable DTMateria
    {
        get { return (DataTable)Session["DTMateria"]; }
        set { Session["DTMateria"] = value; }
    }
    public DataTable DTAudiencia
    {
        get { return (DataTable)Session["DTAudiencia"]; }
        set { Session["DTAudiencia"] = value; }
    }

    public DataTable DTMedidasCautelares
    {
        get { return (DataTable)Session["DTMedidasCautelares"]; }
        set { Session["DTMedidasCautelares"] = value; }
    }

    public DataTable DTCategoriaAcusacion
    {
        get { return (DataTable)Session["DTCategoriaAcusacion"]; }
        set { Session["DTCategoriaAcusacion"] = value; }
    }

    public nino SSninoDiag
    {
        get
        {
            if (Session["neo_SSninoDiag"] == null)
            { Session["neo_SSninoDiag"] = new nino(); }
            return (nino)Session["neo_SSninoDiag"];
        }
        set { Session["neo_SSninoDiag"] = value; }
    }

    private int CodAntecedenteJudicialPRJ
    {
        get { return (int)Session["CodAntecedenteJudicialPRJ"]; }
        set { Session["CodAntecedenteJudicialPRJ"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            # region VALIDACION USUARIO
            if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "RedirectScript", "parent.location.reload();", true);                
            }
            else
            {
                //053760A4-E027-40D6-8F8A-3F8A64DD075C 2.1 
                //79270734-C383-487D-8EAB-BC63F1521932 2.2
                //3FE17A39-80A0-4F7A-9A46-EC2BB934697D 2.3
                //B122B56F-15E0-4488-B5FE-FEADD035CF36 2.4
                //45442D35-CC14-45C6-89F8-C7F6892D919A 2.5
                if (window.existetoken("053760A4-E027-40D6-8F8A-3F8A64DD075C") || window.existetoken("79270734-C383-487D-8EAB-BC63F1521932") || window.existetoken("3FE17A39-80A0-4F7A-9A46-EC2BB934697D") || window.existetoken("B122B56F-15E0-4488-B5FE-FEADD035CF36") || window.existetoken("45442D35-CC14-45C6-89F8-C7F6892D919A"))
                {
                    int v = 0;
                }
                else
                {
                    Response.Redirect("~/logout.aspx");
                }
            }
            #endregion


            getDefaultData();
            SetAllDT();
            GetAntecedentesJudicialesPRJ();
        }
    }

    private void GetAntecedentesJudicialesPRJ()
    {
        DataView dvAntecedenteJudicialPRJ = new DataView(GetAntecedenteJudicialPRJ(0)); // si es 0 trae todos los antecedentes judiciales asociados al niño

        grdAntecedentesJudicialesPRJ.DataSource = dvAntecedenteJudicialPRJ;
        dvAntecedenteJudicialPRJ.Sort = "FechaActualizacion ASC";
        grdAntecedentesJudicialesPRJ.DataBind();

        if (dvAntecedenteJudicialPRJ.Table.Rows.Count == 0)
        {
            pnlAvisoAntecedente.Visible = true;
        }
        else
        {
            pnlAvisoAntecedente.Visible = false;
        }
    }
    private void SetAllDT()
    {
        DTMateria = new DataTable();
        DTMateria.Columns.Add(new DataColumn("DescripcionTipoMateria", typeof(string)));
        DTMateria.Columns.Add(new DataColumn("CodTipoMateria", typeof(int)));
        DTMateria.Columns.Add(new DataColumn("DescripcionMateria", typeof(string)));
        DTMateria.Columns.Add(new DataColumn("CodMateria", typeof(int)));
        DTMateria.Clear();

        DTAudiencia = new DataTable();
        DTAudiencia.Columns.Add(new DataColumn("DescripcionEstadoCausaFamilia", typeof(string)));
        DTAudiencia.Columns.Add(new DataColumn("CodEstadoCausaFamilia", typeof(int)));
        DTAudiencia.Columns.Add(new DataColumn("DescripcionAudiencia", typeof(string)));
        DTAudiencia.Columns.Add(new DataColumn("CodAudiencia", typeof(int)));        
        DTAudiencia.Clear();

        DTMedidasCautelares = new DataTable();
        DTMedidasCautelares.Columns.Add(new DataColumn("DescripcionMedidaCautelar", typeof(string)));
        DTMedidasCautelares.Columns.Add(new DataColumn("CodMedidaCautelar", typeof(int)));        
        DTMedidasCautelares.Clear();

        DTCategoriaAcusacion = new DataTable();
        DTCategoriaAcusacion.Columns.Add(new DataColumn("DescripcionCategoriaInvestigacion", typeof(string)));
        DTCategoriaAcusacion.Columns.Add(new DataColumn("CodCategoriaInvestigacion", typeof(int)));
        DTCategoriaAcusacion.Clear();
    }

    private void getDefaultData()
    {
        DataSet ds = (DataSet)Session["dsParametricas"];

        //Session["dvparTribunales"] = new DataView(GetparTribunales(Convert.ToInt32(ddlRegion.SelectedValue)));
        //DataView dvparTribunales = (DataView)Session["dvparTribunales"];

        DataView dvRegiones = new DataView(ds.Tables["dtparRegion"]);
        DataView dvRepresentante = new DataView(ds.Tables["dtRelacionPresuntoMaltratador"]);
        trabajadorescoll tcoll = new trabajadorescoll();

        ddlRegion.DataSource = dvRegiones;
        ddlRegion.DataTextField = "Descripcion";
        ddlRegion.DataValueField = "CodRegion";
        dvRegiones.Sort = "Descripcion";
        dvRegiones.RowFilter = "CodRegion <> -2 and CodRegion <> -1 and CodRegion <> 16 ";
        ddlRegion.DataBind();

        dvRepresentante.RowFilter = "TipoRelacion = 14 or TipoRelacion = 15 or TipoRelacion = 43";
        dvRepresentante.Sort = "Descripcion";
        ddlRepresentanteLegal.DataSource = dvRepresentante;
        ddlRepresentanteLegal.DataTextField = "Descripcion";
        ddlRepresentanteLegal.DataValueField = "TipoRelacion";
        ddlRepresentanteLegal.DataBind();

        dvRepresentante.RowFilter = "TipoRelacion <> 0";
        ddlRepresentanteJudicial.DataSource = dvRepresentante;
        ddlRepresentanteJudicial.DataTextField = "Descripcion";
        ddlRepresentanteJudicial.DataValueField = "TipoRelacion";        
        ddlRepresentanteJudicial.DataBind();        

        ddlVinculoOfensor.DataSource = dvRepresentante;
        ddlVinculoOfensor.DataTextField = "Descripcion";
        ddlVinculoOfensor.DataValueField = "TipoRelacion";
        ddlVinculoOfensor.DataBind();

        ddlVinculoVictimario.DataSource = dvRepresentante;
        ddlVinculoVictimario.DataTextField = "Descripcion";
        ddlVinculoVictimario.DataValueField = "TipoRelacion";
        ddlVinculoVictimario.DataBind();

        DataView dvparCuradorAdLitem = new DataView(GetparCuradorAdLitem());
        ddlNNACuradorAdLitem.DataSource = dvparCuradorAdLitem;
        ddlNNACuradorAdLitem.DataTextField = "Descripcion";
        ddlNNACuradorAdLitem.DataValueField = "CodCuradorAdLitem";
        dvparCuradorAdLitem.Sort = "Descripcion";
        ddlNNACuradorAdLitem.DataBind();

        DataView dvparTipoMateria = new DataView(GetparTipoMateria());
        ddlTipoMateria.DataSource = dvparTipoMateria;
        ddlTipoMateria.DataTextField = "Descripcion";
        ddlTipoMateria.DataValueField = "TipoMateriaCausa";
        dvparTipoMateria.Sort = "Descripcion";
        ddlTipoMateria.DataBind();


        DataView dvparTipoCuidadoPersonal = new DataView(GetparTipoCuidadoPersonal());
        ddlTipoCuidadoPersonal.DataSource = dvparTipoCuidadoPersonal;
        ddlTipoCuidadoPersonal.DataTextField = "Descripcion";
        ddlTipoCuidadoPersonal.DataValueField = "CodTipoCuidadoPersonal";
        dvparTipoCuidadoPersonal.Sort = "Descripcion";
        ddlTipoCuidadoPersonal.DataBind();

        DataView dvparSusceptibilidadAdopcion = new DataView(GetparSusceptibilidadAdopcion());
        ddlSusceptibilidad.DataSource = dvparSusceptibilidadAdopcion;
        ddlSusceptibilidad.DataTextField = "Descripcion";
        ddlSusceptibilidad.DataValueField = "CodSusceptibilidadAdopcion";
        dvparSusceptibilidadAdopcion.Sort = "Descripcion";
        ddlSusceptibilidad.DataBind();

        DataView dvparMotivoUltimaEntrevista = new DataView(GetparMotivoUltimaEntrevista());
        ddlMotivoUltimaEntrevista.DataSource = dvparMotivoUltimaEntrevista;
        ddlMotivoUltimaEntrevista.DataTextField = "Descripcion";
        ddlMotivoUltimaEntrevista.DataValueField = "CodMotivoUltimaEntrevista";
        dvparMotivoUltimaEntrevista.Sort = "Descripcion";
        ddlMotivoUltimaEntrevista.DataBind();

        DataView dvparCalidadComparecePRJ = new DataView(GetparCalidadComparecePRJ());
        DataView dvparCalidadComparecePRJCausaPenal = new DataView(GetparCalidadComparecePRJ());

        dvparCalidadComparecePRJ.RowFilter = "CodTipoMateriaCausa = 1";
        dvparCalidadComparecePRJ.Sort = "Descripcion";
        ddlCalidadComparecePRJCausaFamilia.DataSource = dvparCalidadComparecePRJ;
        ddlCalidadComparecePRJCausaFamilia.DataTextField = "Descripcion";
        ddlCalidadComparecePRJCausaFamilia.DataValueField = "CodCalidadComparecePRJ";
        ddlCalidadComparecePRJCausaFamilia.DataBind();

        dvparCalidadComparecePRJ.RowFilter = "CodTipoMateriaCausa = 2";
        ddlCalidadComparecePRJCausaPenal.DataSource = dvparCalidadComparecePRJ;
        ddlCalidadComparecePRJCausaPenal.DataTextField = "Descripcion";
        ddlCalidadComparecePRJCausaPenal.DataValueField = "CodCalidadComparecePRJ";
        ddlCalidadComparecePRJCausaPenal.DataBind();

        DataView dvparRequirenteMedidaProteccion = new DataView(GetparRequirenteMedidaProteccion());
        ddlRequirenteMedida.DataSource = dvparRequirenteMedidaProteccion;
        ddlRequirenteMedida.DataTextField = "Descripcion";
        ddlRequirenteMedida.DataValueField = "CodRequirenteMedidaProteccion";
        dvparRequirenteMedidaProteccion.Sort = "Descripcion";
        ddlRequirenteMedida.DataBind();

        DataView dvparEstadoCausa = new DataView(GetparEstadoCausa());

        dvparEstadoCausa.RowFilter = "CodTipoMateriaCausa = 1";
        ddlEstadoCausaFamilia.DataSource = dvparEstadoCausa;
        ddlEstadoCausaFamilia.DataTextField = "Descripcion";
        ddlEstadoCausaFamilia.DataValueField = "CodEstadoCausaPRJ";
        ddlEstadoCausaFamilia.DataBind();
        
        dvparEstadoCausa.RowFilter = "CodTipoMateriaCausa = 2";
        ddlEstadoCausaPenal.DataSource = dvparEstadoCausa;
        ddlEstadoCausaPenal.DataTextField = "Descripcion";
        ddlEstadoCausaPenal.DataValueField = "CodEstadoCausaPRJ";
        ddlEstadoCausaPenal.DataBind();

        DataView dvparMedidasCautelares = new DataView(GetparMedidasCautelares());
        ddlMedidaCautelar.DataSource = dvparMedidasCautelares;
        ddlMedidaCautelar.DataTextField = "Descripcion";
        ddlMedidaCautelar.DataValueField = "CodMedidasCautelares";
        dvparMedidasCautelares.Sort = "Descripcion";
        ddlMedidaCautelar.DataBind();

        DataView dvDenunciante = new DataView(GetparTipoDenunciante());
        ddlQuienDenunciante.DataSource = dvDenunciante;
        ddlQuienDenunciante.DataTextField = "Descripcion";
        ddlQuienDenunciante.DataValueField = "CodTipoDenunciante";
        dvDenunciante.Sort = "Descripcion";
        ddlQuienDenunciante.DataBind();

        DataView dvparFiscalia = new DataView(GetparFiscalias());

        ddlFiscaliaInvestigacion.DataSource = dvparFiscalia;
        ddlFiscaliaInvestigacion.DataTextField = "Descripcion";
        ddlFiscaliaInvestigacion.DataValueField = "CodFiscalia";
        dvparFiscalia.Sort = "Descripcion";
        ddlFiscaliaInvestigacion.DataBind();

        DataView dvparSentencia = new DataView(GetparSentencia());
        ddlSentencia.DataSource = dvparSentencia;
        ddlSentencia.DataTextField = "Descripcion";
        ddlSentencia.DataValueField = "CodTipoSentencia";
        dvparSentencia.Sort = "Descripcion";
        ddlSentencia.DataBind();

        DataView dvparInterponeRecursos = new DataView(GetparInterponeRecursos());
        ddlQuienInterponeRecursos.DataSource = dvparInterponeRecursos;
        ddlQuienInterponeRecursos.DataTextField = "Descripcion";
        ddlQuienInterponeRecursos.DataValueField = "CodInterponeRecursos";
        dvparInterponeRecursos.Sort = "Descripcion";
        ddlQuienInterponeRecursos.DataBind();

        DataView dvparFalloRecurso = new DataView(GetparFalloRecurso());
        ddlFalloRecurso.DataSource = dvparFalloRecurso;
        ddlFalloRecurso.DataTextField = "Descripcion";
        ddlFalloRecurso.DataValueField = "CodFalloRecurso";
        dvparFalloRecurso.Sort = "Descripcion";
        ddlFalloRecurso.DataBind();
        
        DataView dvparTrabajadores = new DataView(tcoll.GetTrabajadoresProyecto(Convert.ToString(SSninoDiag.CodProyecto)));
        ddlProfesionalTecnico.Items.Clear();
        ddlProfesionalTecnico.DataSource = dvparTrabajadores;
        ddlProfesionalTecnico.DataTextField = "NombreCompleto";
        ddlProfesionalTecnico.DataValueField = "ICodTrabajador";
        dvparTrabajadores.Sort = "NombreCompleto";
        ddlProfesionalTecnico.DataBind();
    }


    public DataTable ExisteMateria(int CodAntecedenteJudicialPRJ)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "Select CodMateriasAntecedenteJudicialPRJ, CodTipoMateriaCausa, CodAntecedenteJudicialPRJ from MateriasAntecedenteJudicialPRJ where CodAntecedenteJudicialPRJ = @CodAntecedenteJudicialPRJ";
        sqlc.Parameters.AddWithValue("@CodAntecedenteJudicialPRJ", CodAntecedenteJudicialPRJ);        
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt;
    }


    public DataTable GetCategoriaAcusacion(int CodEstadoCausaAntecedentePRJ)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "Select T2.Descripcion as DescripcionCategoriaInvestigacion, CodCategoriaInvestigacionAcusacion as CodCategoriaInvestigacion from CategoriaAcusacion T1 JOIN parCategoriasInvestigacion T2 on T1.CodCategoriaInvestigacionAcusacion = T2.CodCategoriasInvestigacion where T1.CodEstadoCausaAntecedentePRJ = @CodEstadoCausaAntecedentePRJ";
        sqlc.Parameters.AddWithValue("@CodEstadoCausaAntecedentePRJ", CodEstadoCausaAntecedentePRJ);
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt;
    }

    public DataTable GetEstadoCausaMedidasCautelares(int CodEstadoCausaAntecedentePRJ)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "Select T2.Descripcion as DescripcionMedidaCautelar, T1.CodMedidasCautelares as CodMedidaCautelar from EstadoCausaMedidasCautelaresPRJ T1 JOIN parMedidasCautelares T2 on T1.CodMedidasCautelares = T2.CodMedidasCautelares where T1.CodEstadoCausaAntecedentePRJ = @CodEstadoCausaAntecedentePRJ ";
        sqlc.Parameters.AddWithValue("@CodEstadoCausaAntecedentePRJ", CodEstadoCausaAntecedentePRJ);
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt;
    }

    public DataTable GetEstadoCausaAntecedentePRJ(int CodMateriasAntecedenteJudicialPRJ)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "Select T1.CodEstadoCausaPRJ as CodEstadoCausa, T3.Descripcion as DescripcionEstadoCausa, T2.CodEstadoCausaAntecedentePRJ, T2.CodMateriasAntecedenteJudicialPRJ, T2.CodTipoEstadoCausaPRJ as CodTipoEstadoCausa,T4.Descripcion as DescripcionTipoEstadoCausa, T2.CodInvestigacionCerrada, " +
                           "T2.CodCategoriaInvestigacionAudiencia from MateriasAntecedenteJudicialPRJ T1 JOIN EstadoCausaAntecedentePRJ T2 on T1.CodMateriasAntecedenteJudicialPRJ = T2.CodMateriasAntecedenteJudicialPRJ " +
                           "JOIN parEstadoCausaPRJ T3 on T1.CodEstadoCausaPRJ = T3.CodEstadoCausaPRJ JOIN parTipoEstadoCausaPRJ T4 on T2.CodTipoEstadoCausaPRJ = T4.CodTipoEstadoCausaPRJ where T2.CodMateriasAntecedenteJudicialPRJ = @CodMateriasAntecedenteJudicialPRJ";
        sqlc.Parameters.AddWithValue("@CodMateriasAntecedenteJudicialPRJ", CodMateriasAntecedenteJudicialPRJ);
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt;
    }


    public DataTable GetTipoVulneracionDelitosPRJ(int CodMateriasAntecedenteJudicialPRJ)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "Select T3.Descripcion as DescripcionTipoMateria, T2.CodTipoMateriaCausa as CodTipoMateria, T2.Descripcion as DescripcionMateria, T2.CodMateriaCausaPRJ as CodMateria from TipoVulneracionDelitosPRJ T1 JOIN parMateriaCausaPRJ T2 on T1.CodMateriaCausaPRJ = T2.CodMateriaCausaPRJ " +
                            "Join parTipoMateriaCausa T3 on T2.CodTipoMateriaCausa = T3.TipoMateriaCausa   where CodMateriasAntecedenteJudicialPRJ = @CodMateriasAntecedenteJudicialPRJ ";
        sqlc.Parameters.AddWithValue("@CodMateriasAntecedenteJudicialPRJ", CodMateriasAntecedenteJudicialPRJ);
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt;
    }

    public DataTable GetMateria(int CodAntecedenteJudicialPRJ)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "Select CodMateriasAntecedenteJudicialPRJ, CodTipoMateriaCausa, CodAntecedenteJudicialPRJ, CodTribunal, RUC, RIT, CodCalidadComparecePRJ, DirectorTieneClaveSITFA, CodRequirenteMedidaProteccion, CodTipoRelacionOfensor, FechaDenuncia, CodTipoRelacionDenunciante, " +
                            "PresentaQuerella, FechaQuerella, CodTipoRelacionVictimario, CodFiscalia, ProcedimientoAbreviado, CodTipoSentencia, RecursoNulidad, CodInterponeRecursos, CodFalloRecurso, CodEstadoCausaPRJ, FechaEstadoCausaPRJ, " +
                            "DuracionJuicioTipo, DuracionJuicioCantidad, FechaAudienciaJuicio from MateriasAntecedenteJudicialPRJ where CodAntecedenteJudicialPRJ = @CodAntecedenteJudicialPRJ order by CodTipoMateriaCausa asc ";
        sqlc.Parameters.AddWithValue("@CodAntecedenteJudicialPRJ", CodAntecedenteJudicialPRJ);
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable(); 
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt;
    }

    public DataTable GetAntecedenteJudicialPRJ(int CodAntecedenteJudicial)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "select T1.CodAntecedenteJudicialPRJ, T1.CodDiagnostico, T1.FechaAntecedente, T1.CodComuna, T1.RepresentanteLegal, T1.CodTipoRelacionLegal, T1.RepresentanteJudicial, " +
                            "T1.CodTipoRelacionJudicial, T1.CodTipoCuidadoPersonal, T1.CodSusceptibilidadAdopcion, T1.CuradorAdLitem, T1.CodCuradorAdLitem, T1.AbogadoSostuvoEntrevista, T1.FechaEntrevista, T1.CodMotivoUltimaEntrevista, " +
                            "T1.SintesisEntrevista, T1.FechaActualizacion, T1.IdUsuarioActualizacion, T1.CodTrabajador, T1.Descripcion as Observaciones, T3.RIT, T4.Descripcion as DescripcionTribunal, T5.Descripcion as DescripcionTipoMateria " +
                            "from AntecedenteJudicialPRJ T1 " +
                            "JOIN DiagnosticoGeneral T2 on T1.CodDiagnostico = T2.CodDiagnostico " +
                            "JOIN MateriasAntecedenteJudicialPRJ T3 on T1.CodAntecedenteJudicialPRJ = T3.CodAntecedenteJudicialPRJ " +
                            "JOIN parTribunales T4 on T3.CodTribunal = T4.CodTribunal " +
                            "JOIN parTipoMateriaCausa T5 on T3.CodTipoMateriaCausa = T5.TipoMateriaCausa " +
                            "where T2.ICodIE = @ICodIE ";
        if (CodAntecedenteJudicial > 0)
        {
            sqlc.CommandText = sqlc.CommandText + " and T1.CodAntecedenteJudicialPRJ = @CodAntecedenteJudicialPRJ";
        }

        sqlc.Parameters.AddWithValue("@ICodIE", SSninoDiag.ICodIE);
        sqlc.Parameters.AddWithValue("@CodAntecedenteJudicialPRJ", CodAntecedenteJudicial);
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt;
    }

    public DataTable GetparTipoDenunciante()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "select CodTipoDenunciante, Descripcion from parTipoDenunciante where indVigencia = 'V'";
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt;
    }

    public DataTable GetparTipoMateria()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "select TipoMateriaCausa, Descripcion from parTipoMateriaCausa where indVigencia = 'V'";
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt;
    }

    public DataTable GetparMateria(int TipoMateria)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "select CodMateriaCausaPRJ, Descripcion from parMateriaCausaPRJ where CodTipoMateriaCausa = @TipoMateria and indVigencia = 'V'";
        sqlc.Parameters.AddWithValue("@TipoMateria", TipoMateria);       
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt;
    }

    public DataTable GetparTipoCuidadoPersonal()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "select CodTipoCuidadoPersonal, Descripcion from parTipoCuidadoPersonal where indVigencia = 'V'";
        
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt;
    }

    public DataTable GetparSusceptibilidadAdopcion()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "select CodSusceptibilidadAdopcion, Descripcion from parSusceptibilidadAdopcion where indVigencia = 'V'";

        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt;
    }

    public DataTable GetparMotivoUltimaEntrevista()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "select CodMotivoUltimaEntrevista, Descripcion from parMotivoUltimaEntrevista where indVigencia = 'V'";

        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt;
    }

    public DataTable GetparTribunales(int CodRegion)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "select CodTribunal, TipoTribunal, Descripcion from parTribunales where CodRegion = @CodRegion and indVigencia = 'V'";
        sqlc.Parameters.AddWithValue("@CodRegion", CodRegion);      
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt;
    }

    public DataTable GetparCalidadComparecePRJ()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "select CodCalidadComparecePRJ, CodTipoMateriaCausa, Descripcion from parCalidadComparecePRJ where indVigencia = 'V'";        
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt;
    }

    public DataTable GetparRequirenteMedidaProteccion()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "select CodRequirenteMedidaProteccion, Descripcion from parRequirenteMedidaProteccion where indVigencia = 'V'";        
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt;
    }

    public DataTable GetparEstadoCausa()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "select CodEstadoCausaPRJ, CodTipoMateriaCausa, Descripcion from parEstadoCausaPRJ where indVigencia = 'V'";        
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt;
    }

    public DataTable GetparTipoEstadoCausa(int CodEstadoCausaPRJ)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "select CodTipoEstadoCausaPRJ, Descripcion from parTipoEstadoCausaPRJ where CodEstadoCausaPRJ = @CodEstadoCausaPRJ and indVigencia = 'V'";
        sqlc.Parameters.AddWithValue("@CodEstadoCausaPRJ", CodEstadoCausaPRJ);
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt;
    }

    public DataTable GetparMedidasCautelares()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "select CodMedidasCautelares, Descripcion from parMedidasCautelares where indVigencia = 'V'";        
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt;
    }

    public DataTable GetparFiscalias()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "select CodFiscalia, Descripcion from parFiscalia where indVigencia = 'V'";
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt;
    }

    public DataTable GetparCategoriasInvestigacion(querytype TipoCategoria, int Cod)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "select CodCategoriasInvestigacion, Descripcion from parCategoriasInvestigacion where indVigencia = 'V'";

        if (TipoCategoria == querytype.Categoria)
        {
            sqlc.CommandText = sqlc.CommandText + " and CodTipoEstadoCausaPRJ = @Cod ";
        }
        if (TipoCategoria == querytype.SubCategoria)
        {
            sqlc.CommandText = sqlc.CommandText + " and CodCategoriaInvestigacionPadre = @Cod ";
        }
        sqlc.Parameters.AddWithValue("@Cod", Cod);
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt;
    }

    public DataTable GetparSentencia()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "select CodTipoSentencia, Descripcion from parTipoSentecia where indVigencia = 'V'";
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt;
    }

    public DataTable GetparInterponeRecursos()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "select CodInterponeRecursos, Descripcion from parInterponeRecursos where indVigencia = 'V'";
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt;
    }

    public DataTable GetparFalloRecurso()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "select CodFalloRecurso, Descripcion from parFalloRecurso where indVigencia = 'V'";
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt;
    }

    public DataTable GetparCuradorAdLitem()
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = "select CodCuradorAdLitem, Descripcion from parCuradorAdLitem where indVigencia = 'V'";
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        sconn.Dispose();
        return dt;
    }

    private int InsertUpdateAntecedenteJudicialPRJ(SqlTransaction sqlt,
        int CodAntecedenteJudicialPRJ,
        int CodDiagnostico,
        DateTime FechaAntecedente,
        int CodComuna,
        int RepresentanteLegal,
        int CodTipoRelacionLegal,
        int RepresentanteJudicial,
        int CodTipoRelacionJudicial,
        int CodTipoCuidadoPersonal,
        int CodSusceptibilidadAdopcion,
        int CuradorAdLitem,
        int CodCuradorAdLitem,
        int AbogadoSostuvoEntrevista,
        DateTime FechaEntrevista,
        int CodMotivoUltimaEntrevista,
        string SintesisEntrevista,
        DateTime FechaActualizacion,
        int IdUsuarioActualizacion,
        int CodTrabajador,
        string Descripcion
        )
    {
        int returnvalue = 0;
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand("Insert_Update_AntecedenteJudicialPRJ", sqlt.Connection);
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.Transaction = sqlt;
        
        sqlc.Parameters.AddWithValue("@CodAntecedenteJudicialPRJ", CodAntecedenteJudicialPRJ);
        sqlc.Parameters.AddWithValue("@CodDiagnostico", CodDiagnostico);
        sqlc.Parameters.AddWithValue("@FechaAntecedente", FechaAntecedente);    
        sqlc.Parameters.AddWithValue("@CodComuna", CodComuna);
        sqlc.Parameters.AddWithValue("@RepresentanteLegal", RepresentanteLegal);
        sqlc.Parameters.AddWithValue("@CodTipoRelacionLegal", CodTipoRelacionLegal);
        sqlc.Parameters.AddWithValue("@RepresentanteJudicial", RepresentanteJudicial);
        sqlc.Parameters.AddWithValue("@CodTipoRelacionJudicial", CodTipoRelacionJudicial);
        sqlc.Parameters.AddWithValue("@CodTipoCuidadoPersonal", CodTipoCuidadoPersonal);
        sqlc.Parameters.AddWithValue("@CodSusceptibilidadAdopcion", CodSusceptibilidadAdopcion);
        sqlc.Parameters.AddWithValue("@CuradorAdLitem",CuradorAdLitem);
        sqlc.Parameters.AddWithValue("@CodCuradorAdLitem", CodCuradorAdLitem);
        sqlc.Parameters.AddWithValue("@AbogadoSostuvoEntrevista", AbogadoSostuvoEntrevista);
        sqlc.Parameters.AddWithValue("@FechaEntrevista", FechaEntrevista);    
        sqlc.Parameters.AddWithValue("@CodMotivoUltimaEntrevista", CodMotivoUltimaEntrevista);
        sqlc.Parameters.AddWithValue("@SintesisEntrevista", SintesisEntrevista);
        sqlc.Parameters.AddWithValue("@FechaActualizacion", FechaActualizacion); 
        sqlc.Parameters.AddWithValue("@IdUsuarioActualizacion", IdUsuarioActualizacion);
        sqlc.Parameters.AddWithValue("@CodTrabajador", CodTrabajador);
        sqlc.Parameters.AddWithValue("@Descripcion", Descripcion);

        if (CodAntecedenteJudicialPRJ == 0)
        {
            returnvalue = Convert.ToInt32(sqlc.ExecuteScalar());
        }
        else
        {
            sqlc.ExecuteNonQuery();
        }
        
        return returnvalue;
    }

    private int InsertEstadoCausaAntecedentePRJ(SqlTransaction sqlt,        
        int CodMateriasAntecedenteJudicialPRJ,
        int CodTipoEstadoCausaPRJ,
        int CodInvestigacionCerrada,
        int CodCategoriaInvestigacionAudiencia)
    {
        int returnvalue = 0;
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand("Insert_EstadoCausaAntecedentePRJ", sqlt.Connection);
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.Transaction = sqlt;
        
        sqlc.Parameters.AddWithValue("@CodMateriasAntecedenteJudicialPRJ",CodMateriasAntecedenteJudicialPRJ);
        sqlc.Parameters.AddWithValue("@CodTipoEstadoCausaPRJ", CodTipoEstadoCausaPRJ);
        sqlc.Parameters.AddWithValue("@CodInvestigacionCerrada", CodInvestigacionCerrada);
        sqlc.Parameters.AddWithValue("@CodCategoriaInvestigacionAudiencia", CodCategoriaInvestigacionAudiencia);    
        returnvalue = Convert.ToInt32(sqlc.ExecuteScalar());
        return returnvalue;
    }

    private int InsertCategoriaAcusacion(SqlTransaction sqlt,
        int CodEstadoCausaAntecedentePRJ,
        int CodCategoriaInvestigacionAcusacion)
    {
        int returnvalue = 0;
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand("Insert_CategoriaAcusacionPRJ", sqlt.Connection);
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.Transaction = sqlt;

        sqlc.Parameters.AddWithValue("@CodEstadoCausaAntecedentePRJ", CodEstadoCausaAntecedentePRJ);
        sqlc.Parameters.AddWithValue("@CodCategoriaInvestigacionAcusacion", CodCategoriaInvestigacionAcusacion);        
        returnvalue = Convert.ToInt32(sqlc.ExecuteScalar());
        return returnvalue;
    }

    private void InsertEstadoCausaMedidasCautelaresPRJ(SqlTransaction sqlt,
        int CodEstadoCausaAntecedentePRJ,
        int CodMedidasCautelares)
    {
        
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand("Insert_EstadoCausaMedidasCautelaresPRJ", sqlt.Connection);
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.Transaction = sqlt;
        sqlc.Parameters.AddWithValue("@CodEstadoCausaAntecedentePRJ", CodEstadoCausaAntecedentePRJ);
        sqlc.Parameters.AddWithValue("@CodMedidasCautelares", CodMedidasCautelares);
        sqlc.ExecuteNonQuery();
        //returnvalue = Convert.ToInt32(sqlc.ExecuteScalar());
        //return returnvalue;
    }

    private void InsertTipoVulneracionDelitosPRJ(SqlTransaction sqlt,
        int CodMateriasAntecedenteJudicialPRJ,
        int CodMateriaCausaPRJ)
    {        
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand("Insert_TipoVulneracionDelitosPRJ", sqlt.Connection);
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.Transaction = sqlt;
        sqlc.Parameters.AddWithValue("@CodMateriasAntecedenteJudicialPRJ", CodMateriasAntecedenteJudicialPRJ);        
        sqlc.Parameters.AddWithValue("@CodMateriaCausaPRJ", CodMateriaCausaPRJ);
        sqlc.ExecuteNonQuery();
        //returnvalue = Convert.ToInt32(sqlc.ExecuteScalar());
        //return returnvalue;
    }

    private int InsertCausaFamiliaAntecedenteJudicialPRJ(SqlTransaction sqlt,
        int CodTipoMateriaCausa,        
        int CodAntecedenteJudicialPRJ,
        int CodTribunal,
        string RUC,
        string RIT,
        int CodCalidadComparecePRJ,
        int DirectorTieneClaveSITFA,
        int CodRequirenteMedidaProteccion,
        int CodTipoRelacionOfensor,
        int CodEstadoCausaPRJ,
        DateTime FechaEstadoCausaPRJ) //'@CodRequirenteMedidaProteccion', 
    {
        int returnvalue = 0;
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand("Insert_CausaFamiliaAntecedenteJudicialPRJ", sqlt.Connection);
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.Transaction = sqlt;

        sqlc.Parameters.AddWithValue("@CodTipoMateriaCausa", CodTipoMateriaCausa);
        sqlc.Parameters.AddWithValue("@CodAntecedenteJudicialPRJ", CodAntecedenteJudicialPRJ);
        sqlc.Parameters.AddWithValue("@CodTribunal", CodTribunal);
        sqlc.Parameters.AddWithValue("@RUC", RUC);
        sqlc.Parameters.AddWithValue("@RIT", RIT);
        sqlc.Parameters.AddWithValue("@CodCalidadComparecePRJ", CodCalidadComparecePRJ);
        sqlc.Parameters.AddWithValue("@DirectorTieneClaveSITFA", DirectorTieneClaveSITFA);
        sqlc.Parameters.AddWithValue("@CodRequirenteMedidaProteccion", CodRequirenteMedidaProteccion);
        sqlc.Parameters.AddWithValue("@CodTipoRelacionOfensor", CodTipoRelacionOfensor);
        sqlc.Parameters.AddWithValue("@CodEstadoCausaPRJ", CodEstadoCausaPRJ);
        sqlc.Parameters.AddWithValue("@FechaEstadoCausaPRJ", FechaEstadoCausaPRJ);
        returnvalue = Convert.ToInt32(sqlc.ExecuteScalar());
        return returnvalue;
    }

    private int InsertCausaPenalAntecedenteJudicialPRJ(SqlTransaction sqlt,
        int CodTipoMateriaCausa,
        int CodAntecedenteJudicialPRJ,
        int CodCalidadComparecePRJ,
        DateTime FechaDenuncia,
        int CodTipoRelacionDenunciante,
        int PresentaQuerella,
        DateTime FechaQuerella,
        int CodTipoRelacionVictimario,
        int CodTribunal,
        int CodFiscalia,
        string RUC,
        string RIT,
        int CodEstadoCausaPRJ,
        DateTime FechaEstadoCausaPRJ,
        int ProcedimientoAbreviado,
        int CodTipoSentencia,
        int RecursoNulidad,
        int CodInterponeRecursos,
        int CodFalloRecurso,
        string DuracionJuicioTipo,
        int DuracionJuicioCantidad,
        DateTime FechaAudienciaJuicio)
    {
        int returnvalue = 0;
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand("Insert_CausaPenalAntecedenteJudicialPRJ", sqlt.Connection);
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.Transaction = sqlt;

        sqlc.Parameters.AddWithValue("@CodTipoMateriaCausa", CodTipoMateriaCausa);
        sqlc.Parameters.AddWithValue("@CodAntecedenteJudicialPRJ", CodAntecedenteJudicialPRJ);
        sqlc.Parameters.AddWithValue("@CodCalidadComparecePRJ", CodCalidadComparecePRJ);
        sqlc.Parameters.AddWithValue("@FechaDenuncia", FechaDenuncia);
        sqlc.Parameters.AddWithValue("@CodTipoRelacionDenunciante", CodTipoRelacionDenunciante);
        sqlc.Parameters.AddWithValue("@PresentaQuerella", PresentaQuerella);
        sqlc.Parameters.AddWithValue("@FechaQuerella", FechaQuerella);
        sqlc.Parameters.AddWithValue("@CodTipoRelacionVictimario", CodTipoRelacionVictimario);
        sqlc.Parameters.AddWithValue("@CodTribunal", CodTribunal);
        sqlc.Parameters.AddWithValue("@CodFiscalia", CodFiscalia);
        sqlc.Parameters.AddWithValue("@RUC", RUC);
        sqlc.Parameters.AddWithValue("@RIT", RIT);
        sqlc.Parameters.AddWithValue("@CodEstadoCausaPRJ", CodEstadoCausaPRJ);
        sqlc.Parameters.AddWithValue("@FechaEstadoCausaPRJ", FechaEstadoCausaPRJ);
        sqlc.Parameters.AddWithValue("@ProcedimientoAbreviado", ProcedimientoAbreviado);
        sqlc.Parameters.AddWithValue("@CodTipoSentencia", CodTipoSentencia);
        sqlc.Parameters.AddWithValue("@RecursoNulidad", RecursoNulidad);
        sqlc.Parameters.AddWithValue("@CodInterponeRecursos", CodInterponeRecursos);
        sqlc.Parameters.AddWithValue("@CodFalloRecurso",CodFalloRecurso);
        sqlc.Parameters.AddWithValue("@DuracionJuicioTipo", DuracionJuicioTipo.Trim());
        sqlc.Parameters.AddWithValue("@DuracionJuicioCantidad", DuracionJuicioCantidad);
        sqlc.Parameters.AddWithValue("@FechaAudienciaJuicio", FechaAudienciaJuicio);
        
        returnvalue = Convert.ToInt32(sqlc.ExecuteScalar());
        return returnvalue;
    }
    

    protected void rbtnRepresentanteLegal_CheckedChanged(object sender, EventArgs e)
    {
        if (rbtnRepresentanteLegalSi.Checked == true)
        {
            thQuienRepresentanteLegal.Visible = true;
            tdQuienRepresentanteLegal.Visible = true;
        }
        else
        {
            thQuienRepresentanteLegal.Visible = false;
            tdQuienRepresentanteLegal.Visible = false;
            ddlRepresentanteLegal.SelectedValue = "0";
        }
    }
    protected void rbtnNNACuradorAdLitem_CheckedChanged(object sender, EventArgs e)
    {
        if (rbtnNNACuradorAdLitemSi.Checked == true)
        {
            thNNACuradorAdLitem.Visible = true;
            tdNNACuradorAdLitem.Visible = true;
        }
        else
        {
            thNNACuradorAdLitem.Visible = false;
            tdNNACuradorAdLitem.Visible = false;
            ddlNNACuradorAdLitem.SelectedValue = "0";
        }
    }

    protected void lnkAgregarAudiencia_Click(object sender, EventArgs e)
    {        
        bool chk_rep = false;

        if (Convert.ToInt32(ddlEstadoCausaFamilia.SelectedValue) > 0 && Convert.ToInt32(ddlAudiencia.SelectedValue) > 0 )
        {
            for (int i = 0; i < grdAudiencia.Rows.Count; i++)
            {
                if (HttpUtility.HtmlDecode(grdAudiencia.Rows[i].Cells[1].Text) == ddlAudiencia.SelectedItem.ToString())
                {
                    chk_rep = true;
                }
            }

            if (!chk_rep)
            {
                if (ddlEstadoCausaFamilia.SelectedValue == "1" || ddlEstadoCausaFamilia.SelectedValue == "2")
                {
                    AgregaAudienciaProteccional();
                }

                if (ddlEstadoCausaFamilia.SelectedValue == "3" || ddlEstadoCausaFamilia.SelectedValue == "4")
                {
                    if (grdAudiencia.Rows.Count == 0)
                    {
                        AgregaAudienciaProteccional();
                    }
                    else
                    {
                        
                        lblAvisoAudiencia.Text = "Solo se Puede Ingresar una Audiencia de Revisión de Medidas";
                        trAvisoAudiencia.Visible = true;
                    }
                }                
            }            
            else
            {
                lblAvisoAudiencia.Text = "La Audiencia Seleccionada ya ha sido Ingresada";
                trAvisoAudiencia.Visible = true;
            }            
        }
        else
        {
            lblAvisoAudiencia.Text = "Faltan Campos para el Ingreso de la Causa.";
            trAvisoAudiencia.Visible = true;
        }
    }

    private void ValidaMedidasCautelares()
    {
        //Medidas CAUTELARES

        if (DTAudiencia.Rows.Count > 0)
        {
            int cMedida = 0;
            for (int i = 0; i < DTAudiencia.Rows.Count; i++)
            {
                if ((DTAudiencia.Rows[i][1].ToString() == "1" && DTAudiencia.Rows[i][3].ToString() == "4") ||
                   (DTAudiencia.Rows[i][1].ToString() == "2" && DTAudiencia.Rows[i][3].ToString() == "7") ||
                   (DTAudiencia.Rows[i][1].ToString() == "3" && DTAudiencia.Rows[i][3].ToString() == "10") ||
                   (DTAudiencia.Rows[i][1].ToString() == "3" && DTAudiencia.Rows[i][3].ToString() == "11") ||
                   (DTAudiencia.Rows[i][1].ToString() == "4" && DTAudiencia.Rows[i][3].ToString() == "12"))
                {                    
                    cMedida++;
                }                
            }
            
            if(cMedida > 0)
            {
                trMedidaCautelar.Visible = true;
                    
            }
            else
            {
                trMedidaCautelar.Visible = false;
                DTMedidasCautelares.Clear();
            }
        }
        else
        {
            trMedidaCautelar.Visible = false;
            DTMedidasCautelares.Clear();
            trGrdMedidaCautelar.Visible = false;
            DataView dv = null;
            grdMedidaCautelar.DataSource = dv;
            grdMedidaCautelar.DataBind();
        }
    }

    
    private void AgregaAudienciaProteccional()
    {
        
        DataRow dr = DTAudiencia.NewRow();
        dr[0] = ddlEstadoCausaFamilia.SelectedItem;
        dr[1] = ddlEstadoCausaFamilia.SelectedValue;
        dr[2] = ddlAudiencia.SelectedItem;
        dr[3] = ddlAudiencia.SelectedValue;        
        DTAudiencia.Rows.Add(dr);
        DataView dv = new DataView(DTAudiencia);
        grdAudiencia.DataSource = dv;
        dv.Sort = "DescripcionAudiencia";
        grdAudiencia.DataBind();
        grdAudiencia.Visible = true;
        trGrdAudiencia.Visible = true;
        //ddlEstadoCausaFamilia.SelectedValue = Convert.ToString(0);
        ddlAudiencia.SelectedValue = Convert.ToString(0);
        trAvisoAudiencia.Visible = false;
        lblAvisoAudiencia.Text = "";

        ValidaMedidasCautelares();
    }

    protected void lnkAgregarCategoriaAcusacion_Click(object sender, EventArgs e)
    {
        DataRow dr = DTCategoriaAcusacion.NewRow();
        bool chk_rep = false;

        if (Convert.ToInt32(ddlCategoriaAcusacion.SelectedValue) > 0)
        {
            for (int i = 0; i < grdCategoriaAcusacion.Rows.Count; i++)
            {
                if (HttpUtility.HtmlDecode(grdCategoriaAcusacion.Rows[i].Cells[0].Text) == ddlCategoriaAcusacion.SelectedItem.ToString())
                {
                    chk_rep = true;
                }
            }
            if (!chk_rep)
            {
                dr[0] = ddlCategoriaAcusacion.SelectedItem;
                dr[1] = ddlCategoriaAcusacion.SelectedValue;

                DTCategoriaAcusacion.Rows.Add(dr);
                DataView dv = new DataView(DTCategoriaAcusacion);
                grdCategoriaAcusacion.DataSource = dv;
                dv.Sort = "DescripcionCategoriaInvestigacion";
                grdCategoriaAcusacion.DataBind();
                grdCategoriaAcusacion.Visible = true;
                trGrdCategoriaAcusacion.Visible = true;
                ddlCategoriaAcusacion.SelectedValue = Convert.ToString(0);
                trAvisoCategoriaAcusacion.Visible = false;

                ValidaCategoriaAcusacion();
            }
            else
            {
                lblAvisoCategoriaAcusacion.Text = "La Categoría ya ha sido Ingresada";
                trAvisoCategoriaAcusacion.Visible = true;
            }
        }
        else
        {
            lblAvisoMedidaCautelar.Text = "Faltan Campos para el Ingreso de la Categoría Acusación.";
            trAvisoMedidaCautelar.Visible = true;
        }
    }
    protected void lnkAgregarMedidaCautelar_Click(object sender, EventArgs e)
    {
        DataRow dr = DTMedidasCautelares.NewRow();
        bool chk_rep = false;

        if (Convert.ToInt32(ddlMedidaCautelar.SelectedValue) > 0)
        {
            
            for (int i = 0; i < grdMedidaCautelar.Rows.Count; i++)
            {
                if (HttpUtility.HtmlDecode(grdMedidaCautelar.Rows[i].Cells[0].Text) == ddlMedidaCautelar.SelectedItem.ToString())
                {
                    chk_rep = true;
                }
            }

            if (!chk_rep)
            {
                dr[0] = ddlMedidaCautelar.SelectedItem;
                dr[1] = ddlMedidaCautelar.SelectedValue;

                DTMedidasCautelares.Rows.Add(dr);
                DataView dv = new DataView(DTMedidasCautelares);
                grdMedidaCautelar.DataSource = dv;
                dv.Sort = "DescripcionMedidaCautelar";
                grdMedidaCautelar.DataBind();
                grdMedidaCautelar.Visible = true;
                trGrdMedidaCautelar.Visible = true;
                ddlMedidaCautelar.SelectedValue = Convert.ToString(0);
                trAvisoMedidaCautelar.Visible = false;
            }
            else
            {
                lblAvisoMedidaCautelar.Text = "La Medida Cautelar ya ha sido Ingresada";
                trAvisoMedidaCautelar.Visible = true;
            }
        }
        else
        {
            lblAvisoMedidaCautelar.Text = "Faltan Campos para el Ingreso de la Medida Cautelar.";
            trAvisoMedidaCautelar.Visible = true;
        }
    }

    protected void btnAgregarMateria_Click(object sender, EventArgs e)
    {
        DataRow dr = DTMateria.NewRow();
        bool chk_rep = false;
        bool TipoMateriaDiferente = false;

        if (Convert.ToInt32(ddlTipoMateria.SelectedValue) > 0 && Convert.ToInt32(ddlMateria.SelectedValue) > 0)
        {
            for (int i = 0; i < grdMateria.Rows.Count; i++)
            {
                if (HttpUtility.HtmlDecode(grdMateria.Rows[i].Cells[1].Text) == ddlMateria.SelectedItem.ToString())
                {
                    chk_rep = true;
                }

                if (HttpUtility.HtmlDecode(grdMateria.Rows[0].Cells[0].Text) != ddlTipoMateria.SelectedItem.ToString())
                {
                    TipoMateriaDiferente = true;
                }
            }

            if (!chk_rep)
            {
                if (!TipoMateriaDiferente)
                {
                    dr[0] = ddlTipoMateria.SelectedItem;
                    dr[1] = ddlTipoMateria.SelectedValue;
                    dr[2] = ddlMateria.SelectedItem;
                    dr[3] = ddlMateria.SelectedValue;

                    DTMateria.Rows.Add(dr);
                    DataView dv = new DataView(DTMateria);
                    grdMateria.DataSource = dv;
                    dv.Sort = "DescripcionTipoMateria";
                    grdMateria.DataBind();
                    grdMateria.Visible = true;
                    trGrdMateria.Visible = true;
                    ddlTipoMateria.SelectedValue = Convert.ToString(0);
                    ddlMateria.SelectedValue = Convert.ToString(0);
                    trAvisoMateria.Visible = false;

                    FiltroMateria();
                }
                else
                {
                    lblAvisoMateria.Text = "El Tipo de Materia Seleccionada es Diferente a la Ingresada";
                    trAvisoMateria.Visible = true;
                }
            }
            else
            {
                lblAvisoMateria.Text = "La Materia Seleccionada ya ha sido Ingresada";
                trAvisoMateria.Visible = true;
            }

        }
        else
        {
            lblAvisoMateria.Text = "Faltan Campos para el Ingreso de la Materia.";
            trAvisoMateria.Visible = true;
        }

    }

    private void LimpiaCausaFamilia()
    {
        ddlTribunalCausaFamilia.SelectedValue = "0";
        txtRUCCausaFamilia.Text = "";
        txtRITCausaFamilia.Text = "";
        ddlCalidadComparecePRJCausaFamilia.SelectedValue = "0";
        rbtnDirectorClaveSITFASi.Checked = false;
        rbtnDirectorClaveSITFANo.Checked = false;
        ddlRequirenteMedida.SelectedValue = "0";
        ddlVinculoOfensor.SelectedValue = "0";
        ddlEstadoCausaFamilia.SelectedValue = "0";        
        ResetDropDown(ddlAudiencia);
        DTAudiencia.Clear();
        DataView dv = null;
        grdAudiencia.DataSource = dv;
        grdAudiencia.Visible = false;
        grdAudiencia.DataBind();
        trGrdAudiencia.Visible = false;        
        ddlMedidaCautelar.SelectedValue = "0";
        DTMedidasCautelares.Clear();
        grdMedidaCautelar.DataSource = dv;
        grdMedidaCautelar.Visible = false;
        grdMedidaCautelar.DataBind();
        trMedidaCautelar.Visible = false;
        trGrdMedidaCautelar.Visible = false;
        txtFechaAudienciaFamilia.Text = "";
    }

    private void LimpiaCausaPenal()
    {
        ddlCalidadComparecePRJCausaPenal.SelectedValue = "0";
        txtFechaDenuncia.Text = "";
        ddlQuienDenunciante.SelectedValue = "0";
        rbtnPRJPresentaQuerellaSi.Checked = false;
        rbtnPRJPresentaQuerellaNo.Checked = false;
        thPRJFechaPresentacionQuerella.Visible = false;
        tdPRJFechaPresentacionQuerella.Visible = false;
        txtPRJFechaPresentacionQuerella.Text = "";
        ddlVinculoVictimario.SelectedValue = "0";
        ddlTribunalCausaPenal.SelectedValue = "0";
        ddlFiscaliaInvestigacion.SelectedValue = "0";
        txtRUCCausaPenal.Text = "";
        txtRitCausaPenal.Text = "";
        ddlEstadoCausaPenal.SelectedValue = "0";
        ddlCategoriaInvestigación.Items.Clear();
        ddlCategoriaInvestigación.Items.Add(new ListItem("Seleccionar","0"));        
        DTCategoriaAcusacion.Clear();
        DataView dv = null;
        grdCategoriaAcusacion.DataSource = dv;
        trGrdCategoriaAcusacion.Visible = false;
        grdCategoriaAcusacion.DataBind();
        grdCategoriaAcusacion.Visible = false;
        thCategoriaInvestigacionCerrada.Visible = false;
        tdCategoriaInvestigacionCerrada.Visible = false;
        ddlCategoriaInvestigacionCerrada.SelectedValue = "0";
        trAcusacion.Visible = false;
        ddlCategoriaAcusacion.SelectedValue = "0";
        ddlCategoriaConAcusacion.SelectedValue = "0";
        trCategoriaConAcusacion.Visible = false;
        rbtnProcedimientoAbreviadoNo.Checked = true;
        rbtnProcedimientoAbreviadoSi.Checked = false;
        trProcedimientoAbreviado.Visible = false;
        trSentencia.Visible = false;
        ddlSentencia.SelectedValue = "0";
        trDuracionJuicio.Visible = false;
        ddlTipoDuracionJuicio.SelectedValue = "0";
        txtCantidadDuracionJuicio.Text = "";
        trCategoriaRecursoNulidad.Visible = false;
        rbtnCategoriaRecursoNulidadSi.Checked = false;
        rbtnCategoriaRecursoNulidadNo.Checked = false;
        rbtnCategoriaRecursoNulidadPlazoVigente.Checked = false;
        trPersonayFalloRecursoNulidad.Visible = false;
        ddlQuienInterponeRecursos.SelectedValue = "0";
        ddlFalloRecurso.SelectedValue = "0";
        txtFechaFormalizacion.Text = "";
    }


    private void FiltroMateria()
    {
        if (DTMateria.Rows.Count > 0)
        {
            int CountFamilia = 0;
            int CountPenal = 0;
            for (int i = 0; i < DTMateria.Rows.Count; i++)
            {
                if (DTMateria.Rows[i][0].ToString().Trim() == "CAUSA FAMILIA (PROTECCION)")
                {
                    CountFamilia++;
                }

                if (DTMateria.Rows[i][0].ToString().Trim() == "CAUSA PENAL")
                {
                    CountPenal++;
                }
            }

            if (CountFamilia > 0)
            {
                tblCausaFamilia.Visible = true;
            }
            else
            {
                tblCausaFamilia.Visible = false;
                LimpiaCausaFamilia(); 
            }

            if (CountPenal > 0)
            {
                tblCausaPenal.Visible = true;
            }
            else
            {
                tblCausaPenal.Visible = false;
                LimpiaCausaPenal(); 
            }
        }
        else
        {
            tblCausaFamilia.Visible = false;
            tblCausaPenal.Visible = false;
            LimpiaCausaFamilia();
            LimpiaCausaPenal();
            
        } 
    }

    protected void grdMateria_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DTMateria.Rows.Remove(DTMateria.Rows[Convert.ToInt32(e.CommandArgument)]);

        DataView dv = new DataView(DTMateria);
        grdMateria.DataSource = dv;
        dv.Sort = "DescripcionTipoMateria";
        grdMateria.DataBind();

        FiltroMateria();

        trAvisoMateria.Visible = false;
        lblAvisoMateria.Text = "";
    }
  
    
    protected void rbtnPRJPresentaQuerella_CheckedChanged(object sender, EventArgs e)
    {
        if (rbtnPRJPresentaQuerellaSi.Checked == true)
        {
            thPRJFechaPresentacionQuerella.Visible = true;
            tdPRJFechaPresentacionQuerella.Visible = true;
        }
        else
        {
            thPRJFechaPresentacionQuerella.Visible = false;
            tdPRJFechaPresentacionQuerella.Visible = false;
        }
    }
    protected void rv_fecha_Init(object sender, EventArgs e)
    {
        ((RangeValidator)sender).MaximumValue = DateTime.Today.ToString("dd-MM-yyyy");
        ((RangeValidator)sender).MinimumValue = "01-01-1900";

    }

    protected void rv_fecha_Init2(object sender, EventArgs e)
    {
        ((RangeValidator)sender).MaximumValue = "31-12-" + (Convert.ToInt32(DateTime.Now.Year) + 1);
        ((RangeValidator)sender).MinimumValue = DateTime.Today.ToString("dd-MM-yyyy");

    }
    protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetComunaTribunales();
    }

    private void GetComunaTribunales()
    {
        ResetDropDown(ddlComuna);
        ResetDropDown(ddlTribunalCausaFamilia);
        ResetDropDown(ddlTribunalCausaPenal);

        if (Convert.ToInt32(ddlRegion.SelectedValue) > 0)
        {
            parcoll par = new parcoll();
            DataView dvparComuna = new DataView(par.GetparComunas(ddlRegion.SelectedValue));

            ddlComuna.Items.Clear();
            ddlComuna.DataSource = dvparComuna;
            ddlComuna.DataTextField = "Descripcion";
            ddlComuna.DataValueField = "CodComuna";
            dvparComuna.Sort = "Descripcion";
            ddlComuna.DataBind();

            DataView dvparTribunales = new DataView(GetparTribunales(Convert.ToInt32(ddlRegion.SelectedValue)));

            ddlTribunalCausaFamilia.DataSource = dvparTribunales;
            ddlTribunalCausaFamilia.DataTextField = "Descripcion";
            ddlTribunalCausaFamilia.DataValueField = "CodTribunal";
            dvparTribunales.Sort = "Descripcion";
            ddlTribunalCausaFamilia.DataBind();

            ddlTribunalCausaPenal.DataSource = dvparTribunales;
            ddlTribunalCausaPenal.DataTextField = "Descripcion";
            ddlTribunalCausaPenal.DataValueField = "CodTribunal";
            ddlTribunalCausaPenal.DataBind();
        }
    }

    protected void rbtnRepresentanteJudicial_CheckedChanged(object sender, EventArgs e)
    {
        if (rbtnRepresentanteJudicialSi.Checked == true)
        {
            thQuienRepresentanteJudicial.Visible = true;
            tdQuienRepresentanteJudicial.Visible = true;
        }
        else
        {
            thQuienRepresentanteJudicial.Visible = false;
            tdQuienRepresentanteJudicial.Visible = false;
            ddlRepresentanteJudicial.SelectedValue = "0";
        }
    }

    private void CargaMateria(int CodTipoMateria)
    {
        DataView dvMateria = new DataView(GetparMateria(CodTipoMateria));
        ddlMateria.Items.Clear();
        ddlMateria.DataSource = dvMateria;
        ddlMateria.DataValueField = "CodMateriaCausaPRJ";
        ddlMateria.DataTextField = "Descripcion";
        dvMateria.Sort = "Descripcion";
        ddlMateria.Items.Add(new ListItem("Seleccionar", "0"));
        ddlMateria.DataBind();
    }

    protected void ddlTipoMateria_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(ddlTipoMateria.SelectedValue) > 0)
        {
            CargaMateria(Convert.ToInt32(ddlTipoMateria.SelectedValue));
        }
        else
        {
            ddlMateria.SelectedValue = "0";
        }
    }
    protected void rbtnAbogadoEntrevistaRepresentanteNNA_CheckedChanged(object sender, EventArgs e)
    {
        if (rbtnAbogadoEntrevistaRepresentanteNNASi.Checked == true)
        {
            trEntrevistaRepresentanteNNA.Visible = true;
            trSintesisEntrevistaRepresentanteNNA.Visible = true;
        }
        else
        {
            trEntrevistaRepresentanteNNA.Visible = false;
            trSintesisEntrevistaRepresentanteNNA.Visible = false;
            txtFechaUltimaEntrevista.Text = "";
            ddlMotivoUltimaEntrevista.SelectedValue = "0";
            txtSintesisEntrevistaRepresentanteNNA.Text = "";
        }
    }

    private void CargaAudiencia(int CodEstadoCausaFamilia)
    {
        DataView dvparTipoEstadoCausa = new DataView(GetparTipoEstadoCausa(CodEstadoCausaFamilia));
        ddlAudiencia.DataSource = dvparTipoEstadoCausa;
        ddlAudiencia.DataTextField = "Descripcion";
        ddlAudiencia.DataValueField = "CodTipoEstadoCausaPRJ";
        dvparTipoEstadoCausa.Sort = "Descripcion";
        ddlAudiencia.DataBind();
        ddlAudiencia.Enabled = true;
        lnkAgregarAudiencia.Attributes.Remove("Disabled");
        trMedidaCautelar.Visible = false;
            
    }

    protected void ddlEstadoCausaFamilia_SelectedIndexChanged(object sender, EventArgs e)
    {
        DTMedidasCautelares.Clear();
        DTAudiencia.Clear();        
        DataView dv = null;
        grdAudiencia.DataSource = dv;
        grdAudiencia.DataBind();
        grdMedidaCautelar.DataSource = dv;
        grdMedidaCautelar.DataBind();
        trGrdAudiencia.Visible = false;
        lblAvisoAudiencia.Text = "";
        trAvisoAudiencia.Visible = false;
        ddlAudiencia.Items.Clear();
        ddlAudiencia.Items.Add(new ListItem("Seleccionar","0"));

        if (Convert.ToInt32(ddlEstadoCausaFamilia.SelectedValue) > 0)
        {
            CargaAudiencia(Convert.ToInt32(ddlEstadoCausaFamilia.SelectedValue));
            
        }
        else
        {
            ddlAudiencia.SelectedValue = "0";
        }
    }

    protected void grdAudiencia_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DTAudiencia.Rows.Remove(DTAudiencia.Rows[Convert.ToInt32(e.CommandArgument)]);
        DataView dv = new DataView(DTAudiencia);
        grdAudiencia.DataSource = dv;
        dv.Sort = "DescripcionAudiencia";
        grdAudiencia.DataBind();
        trAvisoAudiencia.Visible = false;
        lblAvisoAudiencia.Text = "";
        ValidaMedidasCautelares();
    }

    protected void grdMedidaCautelar_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DTMedidasCautelares.Rows.Remove(DTMedidasCautelares.Rows[Convert.ToInt32(e.CommandArgument)]);
        DataView dv = new DataView(DTMedidasCautelares);
        grdMedidaCautelar.DataSource = dv;
        dv.Sort = "DescripcionMedidaCautelar";
        grdMedidaCautelar.DataBind();
        trAvisoMedidaCautelar.Visible = false;
        lblAvisoMedidaCautelar.Text = "";
    }

    private void CargaCategoriaInvestigacion(int CodEstadoCausaPenal)
    {        
        ResetDropDown(ddlCategoriaInvestigación);
        DataView dvparTipoEstadoCausa = new DataView(GetparTipoEstadoCausa(CodEstadoCausaPenal));
        ddlCategoriaInvestigación.DataSource = dvparTipoEstadoCausa;
        ddlCategoriaInvestigación.DataTextField = "Descripcion";
        ddlCategoriaInvestigación.DataValueField = "CodTipoEstadoCausaPRJ";
        dvparTipoEstadoCausa.Sort = "Descripcion";
        ddlCategoriaInvestigación.DataBind();
    }
    protected void ddlEstadoCausaPenal_SelectedIndexChanged(object sender, EventArgs e)
    {       
        ResetDropDown(ddlCategoriaInvestigación);
        DTCategoriaAcusacion.Clear();
        DataView dv = null;
        grdCategoriaAcusacion.DataSource = dv;
        trGrdCategoriaAcusacion.Visible = false;
        grdCategoriaAcusacion.DataBind();
        grdCategoriaAcusacion.Visible = false;
        thCategoriaInvestigacionCerrada.Visible = false;
        tdCategoriaInvestigacionCerrada.Visible = false;
        ddlCategoriaInvestigacionCerrada.SelectedValue = "0";
        trAcusacion.Visible = false;
        ddlCategoriaAcusacion.SelectedValue = "0";
        ddlCategoriaConAcusacion.SelectedValue = "0";
        trCategoriaConAcusacion.Visible = false;
        rbtnProcedimientoAbreviadoNo.Checked = true;
        rbtnProcedimientoAbreviadoSi.Checked = false;
        trProcedimientoAbreviado.Visible = false;
        trSentencia.Visible = false;
        ddlSentencia.SelectedValue = "0";
        trDuracionJuicio.Visible = false;
        ddlTipoDuracionJuicio.SelectedValue = "0";
        txtCantidadDuracionJuicio.Text = "";
        trCategoriaRecursoNulidad.Visible = false;
        rbtnCategoriaRecursoNulidadSi.Checked = false;
        rbtnCategoriaRecursoNulidadNo.Checked = false;
        rbtnCategoriaRecursoNulidadPlazoVigente.Checked = false;
        trPersonayFalloRecursoNulidad.Visible = false;
        ddlQuienInterponeRecursos.SelectedValue = "0";
        ddlFalloRecurso.SelectedValue = "0";
        txtFechaFormalizacion.Text = "";

        if (Convert.ToInt32(ddlEstadoCausaPenal.SelectedValue) > 0)
        {
            CargaCategoriaInvestigacion(Convert.ToInt32(ddlEstadoCausaPenal.SelectedValue));

            if (Convert.ToInt32(ddlEstadoCausaPenal.SelectedValue) == 6)
            {
                thFechaFormalizacion.Visible = true;
                tdFechaFormalizacion.Visible = true;
            }
            else
            {
                thFechaFormalizacion.Visible = false;
                tdFechaFormalizacion.Visible = false;
            }
        }
        
    }

    private void ResetDropDown(DropDownList ddl)
    {
        ddl.Items.Clear();
        ddl.Items.Add(new ListItem("Seleccionar","0"));
    }

    private void CargaCategoriaInvestigacionCerrada()
    {
        ResetDropDown(ddlCategoriaInvestigacionCerrada);

        DataView dvCategoriasInvestigacionCerrada = new DataView(GetparCategoriasInvestigacion(querytype.Categoria, Convert.ToInt32(ddlCategoriaInvestigación.SelectedValue)));
        ddlCategoriaInvestigacionCerrada.DataSource = dvCategoriasInvestigacionCerrada;
        ddlCategoriaInvestigacionCerrada.DataTextField = "Descripcion";
        ddlCategoriaInvestigacionCerrada.DataValueField = "CodCategoriasInvestigacion";
        dvCategoriasInvestigacionCerrada.Sort = "Descripcion";
        ddlCategoriaInvestigacionCerrada.DataBind();
        thCategoriaInvestigacionCerrada.Visible = true;
        tdCategoriaInvestigacionCerrada.Visible = true;
    }

    protected void ddlCategoriaInvestigación_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(ddlCategoriaInvestigación.SelectedValue) == 18)// Investigación Cerrada
        {
            CargaCategoriaInvestigacionCerrada();
        }
        else
        {
            DTCategoriaAcusacion.Clear();
            DataView dv = null;
            grdCategoriaAcusacion.DataSource = dv;
            trGrdCategoriaAcusacion.Visible = false;
            grdCategoriaAcusacion.DataBind();
            grdCategoriaAcusacion.Visible = false;
            thCategoriaInvestigacionCerrada.Visible = false;
            tdCategoriaInvestigacionCerrada.Visible = false;
            ddlCategoriaInvestigacionCerrada.SelectedValue = "0";
            trAcusacion.Visible = false;
            ddlCategoriaAcusacion.SelectedValue = "0";
            ddlCategoriaConAcusacion.SelectedValue = "0";
            trCategoriaConAcusacion.Visible = false;
            rbtnProcedimientoAbreviadoNo.Checked = true;
            rbtnProcedimientoAbreviadoSi.Checked = false;
            trProcedimientoAbreviado.Visible = false;
            trSentencia.Visible = false;
            ddlSentencia.SelectedValue = "0";
            trDuracionJuicio.Visible = false;
            ddlTipoDuracionJuicio.SelectedValue = "0";
            txtCantidadDuracionJuicio.Text = "";
            trCategoriaRecursoNulidad.Visible = false;
            rbtnCategoriaRecursoNulidadSi.Checked = false;
            rbtnCategoriaRecursoNulidadNo.Checked = false;
            rbtnCategoriaRecursoNulidadPlazoVigente.Checked = false;
            trPersonayFalloRecursoNulidad.Visible = false;
            ddlQuienInterponeRecursos.SelectedValue = "0";
            ddlFalloRecurso.SelectedValue = "0";

        }

    }
    protected void ddlCategoriaInvestigacionCerrada_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(ddlCategoriaInvestigacionCerrada.SelectedValue) == 6)
        {
            ResetDropDown(ddlCategoriaAcusacion);

            DataView dvCategoriaAcusacion = new DataView(GetparCategoriasInvestigacion(querytype.SubCategoria, Convert.ToInt32(ddlCategoriaInvestigacionCerrada.SelectedValue)));
            ddlCategoriaAcusacion.DataSource = dvCategoriaAcusacion;
            ddlCategoriaAcusacion.DataTextField = "Descripcion";
            ddlCategoriaAcusacion.DataValueField = "CodCategoriasInvestigacion";
            dvCategoriaAcusacion.Sort = "Descripcion";
            ddlCategoriaAcusacion.DataBind();
            trAcusacion.Visible = true;
        }
        else
        {
            DTCategoriaAcusacion.Clear();
            DataView dv = null;
            grdCategoriaAcusacion.DataSource = dv;
            trGrdCategoriaAcusacion.Visible = false;
            grdCategoriaAcusacion.DataBind();
            grdCategoriaAcusacion.Visible = false;
            trAcusacion.Visible = false;
            ddlCategoriaAcusacion.SelectedValue = "0";
            ddlCategoriaConAcusacion.SelectedValue = "0";
            trCategoriaConAcusacion.Visible = false;
            rbtnProcedimientoAbreviadoNo.Checked = true;
            rbtnProcedimientoAbreviadoSi.Checked = false;
            trProcedimientoAbreviado.Visible = false;
            trSentencia.Visible = false;
            ddlSentencia.SelectedValue = "0";
            trDuracionJuicio.Visible = false;
            ddlTipoDuracionJuicio.SelectedValue = "0";
            txtCantidadDuracionJuicio.Text = "";
            trCategoriaRecursoNulidad.Visible = false;
            rbtnCategoriaRecursoNulidadSi.Checked = false;
            rbtnCategoriaRecursoNulidadNo.Checked = false;
            rbtnCategoriaRecursoNulidadPlazoVigente.Checked = false;
            trPersonayFalloRecursoNulidad.Visible = false;
            ddlQuienInterponeRecursos.SelectedValue = "0";
            ddlFalloRecurso.SelectedValue = "0";
        }
        
    }

    private void ValidaCategoriaAcusacion()
    {
        if (DTCategoriaAcusacion.Rows.Count > 0)
        {
            ResetDropDown(ddlCategoriaConAcusacion);

            DataView dvCategoriaConAcusacion = new DataView(GetparCategoriasInvestigacion(querytype.SubCategoria, Convert.ToInt32(DTCategoriaAcusacion.Rows[0][1].ToString())));
            ddlCategoriaConAcusacion.DataSource = dvCategoriaConAcusacion;
            ddlCategoriaConAcusacion.DataTextField = "Descripcion";
            ddlCategoriaConAcusacion.DataValueField = "CodCategoriasInvestigacion";
            dvCategoriaConAcusacion.Sort = "Descripcion";
            ddlCategoriaConAcusacion.DataBind();
            trCategoriaConAcusacion.Visible = true;
        }
        else
        {
            ddlCategoriaConAcusacion.SelectedValue = "0";
            trCategoriaConAcusacion.Visible = false;
            rbtnProcedimientoAbreviadoNo.Checked = true;
            rbtnProcedimientoAbreviadoSi.Checked = false;
            trProcedimientoAbreviado.Visible = false;
            trSentencia.Visible = false;
            ddlSentencia.SelectedValue = "0";
            trDuracionJuicio.Visible = false;
            ddlTipoDuracionJuicio.SelectedValue = "0";
            txtCantidadDuracionJuicio.Text = "";
            trCategoriaRecursoNulidad.Visible = false;
            rbtnCategoriaRecursoNulidadSi.Checked = false;
            rbtnCategoriaRecursoNulidadNo.Checked = false;
            rbtnCategoriaRecursoNulidadPlazoVigente.Checked = false;
            trPersonayFalloRecursoNulidad.Visible = false;
            ddlQuienInterponeRecursos.SelectedValue = "0";
            ddlFalloRecurso.SelectedValue = "0";
        }
    }

    protected void grdCategoriaAcusacion_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (DTCategoriaAcusacion.Rows.Count > 0)
        {
            DTCategoriaAcusacion.Rows.Remove(DTCategoriaAcusacion.Rows[Convert.ToInt32(e.CommandArgument)]);
            DataView dv = new DataView(DTCategoriaAcusacion);
            grdCategoriaAcusacion.DataSource = dv;
            dv.Sort = "DescripcionCategoriaInvestigacion";
            grdCategoriaAcusacion.DataBind();
            trAvisoCategoriaAcusacion.Visible = false;
            lblAvisoCategoriaAcusacion.Text = "";

            ValidaCategoriaAcusacion();
        }
        
    }

    
    protected void ddlCategoriaConAcusacion_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtCantidadDuracionJuicio.Text = "";
        trDuracionJuicio.Visible = false;
        ddlSentencia.SelectedValue = "0";
        ddlTipoDuracionJuicio.SelectedValue = "0";
        rbtnCategoriaRecursoNulidadSi.Checked = false;
        rbtnCategoriaRecursoNulidadNo.Checked = false;
        rbtnCategoriaRecursoNulidadPlazoVigente.Checked = false;
        trCategoriaRecursoNulidad.Visible = false;
        trPersonayFalloRecursoNulidad.Visible = false;
        ddlQuienInterponeRecursos.SelectedValue = "0";
        ddlFalloRecurso.SelectedValue = "0";

        if (Convert.ToInt32(ddlCategoriaConAcusacion.SelectedValue) == 10 || Convert.ToInt32(ddlCategoriaConAcusacion.SelectedValue) == 12 || Convert.ToInt32(ddlCategoriaConAcusacion.SelectedValue) == 14)
        { // AUDIENCIA PREPARATORIA DEL JUICIO ORAL
            trProcedimientoAbreviado.Visible = true;
            trFechaProgramadaAudiencia.Visible = true;
            trSentencia.Visible = false;
        }
        else if (Convert.ToInt32(ddlCategoriaConAcusacion.SelectedValue) == 11 || Convert.ToInt32(ddlCategoriaConAcusacion.SelectedValue) == 13 || Convert.ToInt32(ddlCategoriaConAcusacion.SelectedValue) == 15)
        { // AUDIENCIA DE JUICIO
            rbtnProcedimientoAbreviadoNo.Checked = true;
            rbtnProcedimientoAbreviadoSi.Checked = false;
            trProcedimientoAbreviado.Visible = false;
            trSentencia.Visible = true;
            trFechaProgramadaAudiencia.Visible = false;
            txtFechaProgramadaAudiencia.Text = "";
        }
        else
        {
            rbtnProcedimientoAbreviadoNo.Checked = true;
            rbtnProcedimientoAbreviadoSi.Checked = false;
            trProcedimientoAbreviado.Visible = false;
            trSentencia.Visible = false;
        }
    }

    
    protected void rbtnProcedimientoAbreviado_CheckedChanged(object sender, EventArgs e)
    {
        if (rbtnProcedimientoAbreviadoSi.Checked == true)
        {
            trSentencia.Visible = true;
            trFechaProgramadaAudiencia.Visible = false;
            txtFechaProgramadaAudiencia.Text = "";
        }
        else 
        {
            trFechaProgramadaAudiencia.Visible = true;

            trSentencia.Visible = false;
            ddlSentencia.SelectedValue = "0";
            trDuracionJuicio.Visible = false;
            ddlTipoDuracionJuicio.SelectedValue = "0";
            txtCantidadDuracionJuicio.Text = "";
            trCategoriaRecursoNulidad.Visible = false;
            rbtnCategoriaRecursoNulidadSi.Checked = false;
            rbtnCategoriaRecursoNulidadNo.Checked = false;
            rbtnCategoriaRecursoNulidadPlazoVigente.Checked = false;
            trPersonayFalloRecursoNulidad.Visible = false;
            ddlQuienInterponeRecursos.SelectedValue = "0";
            ddlFalloRecurso.SelectedValue = "0";
        }
    }
    protected void ddlSentencia_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(ddlSentencia.SelectedValue) > 0)
        {
            trCategoriaRecursoNulidad.Visible = true;
            trDuracionJuicio.Visible = true;            
        }
        else
        {
            trDuracionJuicio.Visible = false;
            ddlTipoDuracionJuicio.SelectedValue = "0";
            txtCantidadDuracionJuicio.Text = "";
            trCategoriaRecursoNulidad.Visible = false;
            rbtnCategoriaRecursoNulidadSi.Checked = false;
            rbtnCategoriaRecursoNulidadNo.Checked = false;
            rbtnCategoriaRecursoNulidadPlazoVigente.Checked = false;
            trPersonayFalloRecursoNulidad.Visible = false;
            ddlQuienInterponeRecursos.SelectedValue = "0";
            ddlFalloRecurso.SelectedValue = "0";
        }
    }
    protected void rbtnCategoriaRecursoNulidad_CheckedChanged(object sender, EventArgs e)
    {
        if (rbtnCategoriaRecursoNulidadSi.Checked == true)
        {
            trPersonayFalloRecursoNulidad.Visible = true;
        }
        else
        {
            trPersonayFalloRecursoNulidad.Visible = false;
            ddlQuienInterponeRecursos.SelectedValue = "0";
            ddlFalloRecurso.SelectedValue = "0";
        }
    }

    private void LimpiarTodoAntecedentesJudicialesPRJ()
    {
        txtFechaAntecedenteJudicial.Text = "";
        txtFechaAntecedenteJudicial.BackColor = System.Drawing.Color.Empty;
        ddlRegion.SelectedValue = "0";
        ddlRegion.BackColor = System.Drawing.Color.Empty;
        ddlComuna.Items.Clear();
        ddlComuna.Items.Add(new ListItem("Seleccionar", "0"));
        ddlComuna.BackColor = System.Drawing.Color.Empty;
        rbtnRepresentanteLegalSi.Checked = false;
        rbtnRepresentanteLegalNo.Checked = true;
        thQuienRepresentanteLegal.Visible = false;
        tdQuienRepresentanteLegal.Visible = false;
        ddlRepresentanteLegal.SelectedValue = "0";
        ddlRepresentanteLegal.BackColor = System.Drawing.Color.Empty;
        rbtnRepresentanteJudicialSi.Checked = false;
        rbtnRepresentanteJudicialNo.Checked = true;
        thQuienRepresentanteJudicial.Visible = false;
        tdQuienRepresentanteJudicial.Visible = false;
        ddlRepresentanteJudicial.SelectedValue = "0";
        ddlRepresentanteJudicial.BackColor = System.Drawing.Color.Empty;
        ddlTipoCuidadoPersonal.SelectedValue = "0";
        ddlTipoCuidadoPersonal.BackColor = System.Drawing.Color.Empty;
        ddlSusceptibilidad.SelectedValue = "0";
        ddlSusceptibilidad.BackColor = System.Drawing.Color.Empty;
        rbtnNNACuradorAdLitemSi.Checked = false;
        rbtnNNACuradorAdLitemNo.Checked = true;
        thNNACuradorAdLitem.Visible = false;
        tdNNACuradorAdLitem.Visible = false;
        ddlNNACuradorAdLitem.SelectedValue = "0";
        ddlNNACuradorAdLitem.BackColor = System.Drawing.Color.Empty;
        rbtnAbogadoEntrevistaRepresentanteNNASi.Checked = false;
        rbtnAbogadoEntrevistaRepresentanteNNANo.Checked = true;
        trEntrevistaRepresentanteNNA.Visible = false;
        trSintesisEntrevistaRepresentanteNNA.Visible = false;
        txtSintesisEntrevistaRepresentanteNNA.Text = "";
        txtSintesisEntrevistaRepresentanteNNA.BackColor = System.Drawing.Color.Empty;
        ddlMotivoUltimaEntrevista.SelectedValue = "0";
        ddlMotivoUltimaEntrevista.BackColor = System.Drawing.Color.Empty;
        txtFechaUltimaEntrevista.Text = "";
        txtFechaUltimaEntrevista.BackColor = System.Drawing.Color.Empty;
        ddlProfesionalTecnico.SelectedValue = "0";
        ddlProfesionalTecnico.BackColor = System.Drawing.Color.Empty;
        txtObservaciones.Text = "";
        ddlTipoMateria.SelectedValue = "0";        
        ddlMateria.Items.Clear();
        ddlMateria.Items.Add(new ListItem("Seleccionar", "0"));
        trGrdMateria.Visible = false;
        DataView dv = null;
        grdMateria.DataSource = dv;
        grdMateria.DataBind();
        DTMateria.Clear();

        LimpiaCausaFamilia();
        LimpiaCausaPenal();

        tblCausaFamilia.Visible = false;
        tblCausaPenal.Visible = false;
        btnGatillo.Attributes.Add("disabled", "disabled"); 


        grdMateria.Columns[2].Visible = true;
        grdAudiencia.Columns[2].Visible = true;
        grdMedidaCautelar.Columns[1].Visible = true;
        grdCategoriaAcusacion.Columns[1].Visible = true;
        btnAgregarMateria.Visible = true;
        lnkAgregarMedidaCautelar.Visible = true;
        lnkAgregarCategoriaAcusacion.Visible = true;
        lnkAgregarAudiencia.Visible = true;       
        BtnLimpiar.Visible = true;
    }
    protected void BtnLimpiar_Click(object sender, EventArgs e)
    {
        LimpiarTodoAntecedentesJudicialesPRJ();
    }

    private int GetRadioButton(RadioButton rbtnSi, RadioButton rbtnNo)
    {
        if (rbtnSi.Checked == true || rbtnNo.Checked == true)
        {
            if (rbtnSi.Checked == true)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        else
        {
            return 0;
        }
    }

    private int GetRadioButton(RadioButton rbtnSi, RadioButton rbtnNo, RadioButton rbtnOtros)
    {
        if (rbtnSi.Checked == true || rbtnNo.Checked == true || rbtnOtros.Checked == true)
        {
            if (rbtnSi.Checked == true)
            {
                return 1;
            }
            else if (rbtnNo.Checked == true)
            {
                return 0;
            }
            else if(rbtnOtros.Checked == true)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        else
        {
            return 0;
        }
    }

    private DateTime GetDateTime(TextBox txt)
    {
        if (txt.Text == "")
        {
            return Convert.ToDateTime("01-01-1900");
        }
        else
        {
            return Convert.ToDateTime(txt.Text);
        }

    }

    private bool ValidaDropDownList(DropDownList ddl)
    {
        bool rechazo = false;
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9");

        if (ddl.SelectedValue == "0")
        {
            rechazo = true;
            ddl.BackColor = colorCampoObligatorio;
        }
        else
        {
            ddl.BackColor = System.Drawing.Color.Empty;
        }
        return rechazo;
    }

    private bool ValidaTextBox(TextBox txt)
    {
        bool rechazo = false;
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9");

        if (txt.Text == "")
        {
            rechazo = true;
            txt.BackColor = colorCampoObligatorio;
        }
        else
        {
            txt.BackColor = System.Drawing.Color.Empty;
        }

        return rechazo;
    }
    private bool ValidaRadioButton(RadioButton rbtnSi, RadioButton rbtnNo)
    {
        bool rechazo = false;
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9");

        if (rbtnSi.Checked == false && rbtnNo.Checked == false)
        {
            rechazo = true;
            rbtnSi.BackColor = colorCampoObligatorio;
            rbtnNo.BackColor = colorCampoObligatorio;
        }
        else
        {
            rbtnSi.BackColor = System.Drawing.Color.Empty;
            rbtnNo.BackColor = System.Drawing.Color.Empty;
        }

        return rechazo;
    }

    private bool ValidaRadioButton(RadioButton rbtnSi, RadioButton rbtnNo, RadioButton rbtnOtros)
    {
        bool rechazo = false;
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9");

        if (rbtnSi.Checked == false && rbtnNo.Checked == false && rbtnOtros.Checked == false)
        {
            rechazo = true;
            rbtnSi.BackColor = colorCampoObligatorio;
            rbtnNo.BackColor = colorCampoObligatorio;
            rbtnOtros.BackColor = colorCampoObligatorio;
        }
        else
        {
            rbtnSi.BackColor = System.Drawing.Color.Empty;
            rbtnNo.BackColor = System.Drawing.Color.Empty;
            rbtnOtros.BackColor = System.Drawing.Color.Empty;
        }

        return rechazo;
    }

    private bool ValidaAntecedenteJudicialPRJ()
    {
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9");

        int familia = 0;
        int penal = 0;
        for (int i = 0; i < DTMateria.Rows.Count; i++)
        {
            if (DTMateria.Rows[i][0].ToString().Trim() == "CAUSA FAMILIA (PROTECCION)")
            {
                familia++;
            }
            else if (DTMateria.Rows[i][0].ToString().Trim() == "CAUSA PENAL")
            {
                penal++;
            }
        }


        bool rechazo = false;

        if (ValidaTextBox(txtFechaAntecedenteJudicial))
        { rechazo = true; }

        if (ValidaDropDownList(ddlRegion)) 
        { rechazo = true; }

        if (ValidaDropDownList(ddlComuna))
        { rechazo = true; }

        if(rbtnRepresentanteLegalSi.Checked == true)
        {
            if(ValidaDropDownList(ddlRepresentanteLegal))
            { rechazo = true; }
        }

        if (rbtnRepresentanteJudicialSi.Checked == true)
        {
            if (ValidaDropDownList(ddlRepresentanteJudicial))
            { rechazo = true; }
        }

        if (ValidaDropDownList(ddlTipoCuidadoPersonal))
        { rechazo = true; }

        //if (ValidaDropDownList(ddlSusceptibilidad))
        //{ rechazo = true; }

        if (rbtnNNACuradorAdLitemSi.Checked == true)
        {
            if (ValidaDropDownList(ddlNNACuradorAdLitem))
            { rechazo = true; }
        }

        if (rbtnAbogadoEntrevistaRepresentanteNNASi.Checked == true)
        {
            if (ValidaTextBox(txtFechaUltimaEntrevista))
            { rechazo = true; }

            if (ValidaDropDownList(ddlMotivoUltimaEntrevista))
            { rechazo = true; }

            if (ValidaTextBox(txtSintesisEntrevistaRepresentanteNNA))
            { rechazo = true; }
        }

        if(ValidaDropDownList(ddlProfesionalTecnico))
        { rechazo = true; }

        if (DTMateria.Rows.Count == 0)
        {
            lblAvisoMateria.Text = "Se Requiere Agregar una Materia";
            trAvisoMateria.Visible = true;
            { rechazo = true; }
        }
        else
        {
            lblAvisoMateria.Text = "";
            trAvisoMateria.Visible = false;

            if (familia > 0)
            {
                if (ValidaDropDownList(ddlTribunalCausaFamilia))
                { rechazo = true; }

                if (ValidaTextBox(txtRUCCausaFamilia))
                { rechazo = true; }

                if (ValidaTextBox(txtRITCausaFamilia))
                { rechazo = true; }

                if (ValidaDropDownList(ddlCalidadComparecePRJCausaFamilia))
                { rechazo = true; }

                if (ValidaRadioButton(rbtnDirectorClaveSITFASi, rbtnDirectorClaveSITFANo))
                { rechazo = true; }

                if (ValidaDropDownList(ddlRequirenteMedida))
                { rechazo = true; }

                if (ValidaDropDownList(ddlVinculoOfensor))
                { rechazo = true; }

                if (ValidaTextBox(txtFechaAudienciaFamilia))
                { rechazo = true; }

                if (DTAudiencia.Rows.Count == 0)
                {
                    lblAvisoAudiencia.Text = "Se Requiere Agregar una Audiencia";
                    trAvisoAudiencia.Visible = true;
                    rechazo = true;
                }
                else
                {
                    lblAvisoAudiencia.Text = "";
                    trAvisoAudiencia.Visible = false;
                    int MedidaCautelar = 0;
                    for (int i = 0; i < DTAudiencia.Rows.Count; i++) // Valida si se ingresó una medida cautelar
                    {
                        if ((DTAudiencia.Rows[i][1].ToString() == "1" && DTAudiencia.Rows[i][3].ToString() == "4") || // condiciones para que sea medida cautelar
                               (DTAudiencia.Rows[i][1].ToString() == "2" && DTAudiencia.Rows[i][3].ToString() == "7") ||
                               (DTAudiencia.Rows[i][1].ToString() == "3" && DTAudiencia.Rows[i][3].ToString() == "10") ||
                               (DTAudiencia.Rows[i][1].ToString() == "3" && DTAudiencia.Rows[i][3].ToString() == "11") ||
                               (DTAudiencia.Rows[i][1].ToString() == "4" && DTAudiencia.Rows[i][3].ToString() == "12"))
                        {
                            MedidaCautelar++;
                        }
                    }

                    if (MedidaCautelar > 0)
                    {
                        if (DTMedidasCautelares.Rows.Count == 0)
                        {
                            lblAvisoMedidaCautelar.Text = "Se Requiere Agregar al Menos una Medida Cautelar";
                            trAvisoMedidaCautelar.Visible = true;
                            rechazo = true;
                        }
                        else
                        {
                            lblAvisoMedidaCautelar.Text = "";
                            trAvisoMedidaCautelar.Visible = false;
                        }
                    }

                }
            }

            if (penal > 0)
            {
                if (ValidaDropDownList(ddlCalidadComparecePRJCausaPenal))
                { rechazo = true; }

                if (ValidaTextBox(txtFechaDenuncia))
                { rechazo = true; }

                if(ValidaDropDownList(ddlQuienDenunciante))
                { rechazo = true; }

                if(ValidaRadioButton(rbtnPRJPresentaQuerellaSi,rbtnPRJPresentaQuerellaNo))
                { rechazo = true; }
                else
                {
                    if (rbtnPRJPresentaQuerellaSi.Checked == true)
                    {
                        if(ValidaTextBox(txtPRJFechaPresentacionQuerella))
                        { rechazo = true; }
                    }
                }

                if (ValidaDropDownList(ddlVinculoVictimario))
                { rechazo = true; }

                if (ValidaDropDownList(ddlTribunalCausaPenal))
                { rechazo = true; }

                if (ValidaDropDownList(ddlFiscaliaInvestigacion))
                { rechazo = true; }

                if (ValidaTextBox(txtRUCCausaPenal))
                { rechazo = true; }

                if (ValidaTextBox(txtRitCausaPenal))
                { rechazo = true; }
                
                if (ValidaDropDownList(ddlEstadoCausaPenal))
                { rechazo = true; }

                if (ValidaDropDownList(ddlCategoriaInvestigación))
                { rechazo = true; }

                if (Convert.ToInt32(ddlEstadoCausaPenal.SelectedValue) == 6) // Estado Causa Formalizada
                {
                    if (ValidaTextBox(txtFechaFormalizacion))
                    { rechazo = true; }

                    if (ValidaDropDownList(ddlCategoriaInvestigación))
                    { 
                        rechazo = true; 
                    }
                    else if(Convert.ToInt32(ddlCategoriaInvestigación.SelectedValue) == 18) // Investigación Cerrada
                    {
                        if (ValidaDropDownList(ddlCategoriaInvestigacionCerrada))
                        { 
                            rechazo = true; 
                        }
                        else if (Convert.ToInt32(ddlCategoriaInvestigacionCerrada.SelectedValue) == 6) // Categoría investigación Cerrada "Acusación"
                        {
                            if (DTCategoriaAcusacion.Rows.Count == 0) // Categoría Acusación
                            {
                                lblAvisoCategoriaAcusacion.Text = "Se Requiere Agregar al Menos una Categoría Acusación";
                                trAvisoCategoriaAcusacion.Visible = true;
                            }
                            else
                            {
                                lblAvisoCategoriaAcusacion.Text = "";
                                trAvisoCategoriaAcusacion.Visible = false;

                                if (ValidaDropDownList(ddlCategoriaConAcusacion))
                                { 
                                    rechazo = true; 
                                }
                                else if (Convert.ToInt32(ddlCategoriaConAcusacion.SelectedValue) == 11 || Convert.ToInt32(ddlCategoriaConAcusacion.SelectedValue) == 13 || Convert.ToInt32(ddlCategoriaConAcusacion.SelectedValue) == 15) //Audiencia de juicio
                                {
                                    if (ValidaDropDownList(ddlSentencia))
                                    { rechazo = true; }
                                    else
                                    {
                                        if (ValidaDropDownList(ddlTipoDuracionJuicio))
                                        { rechazo = true; }

                                        if (ValidaTextBox(txtCantidadDuracionJuicio))
                                        { rechazo = true; }

                                        if (ValidaRadioButton(rbtnCategoriaRecursoNulidadSi, rbtnCategoriaRecursoNulidadNo, rbtnCategoriaRecursoNulidadPlazoVigente))
                                        { rechazo = true; }
                                        else
                                        {
                                            if (rbtnCategoriaRecursoNulidadSi.Checked == true)
                                            {
                                                if (ValidaDropDownList(ddlQuienInterponeRecursos))
                                                { rechazo = true; }

                                                if (ValidaDropDownList(ddlFalloRecurso))
                                                { rechazo = true; }
                                            }
                                        }
                                    }
                                }


                                else if (Convert.ToInt32(ddlCategoriaConAcusacion.SelectedValue) == 10 || Convert.ToInt32(ddlCategoriaConAcusacion.SelectedValue) == 12 || Convert.ToInt32(ddlCategoriaConAcusacion.SelectedValue) == 14) // Audiencia de preparación del juicio oral
                                {
                                    if (rbtnProcedimientoAbreviadoSi.Checked == true)
                                    {
                                        if (ValidaDropDownList(ddlSentencia))
                                        {
                                            rechazo = true;
                                        }
                                        else
                                        {
                                            if (ValidaDropDownList(ddlTipoDuracionJuicio))
                                            { rechazo = true; }

                                            if (ValidaTextBox(txtCantidadDuracionJuicio))
                                            { rechazo = true; }

                                            if(ValidaRadioButton(rbtnCategoriaRecursoNulidadSi,rbtnCategoriaRecursoNulidadNo,rbtnCategoriaRecursoNulidadPlazoVigente))
                                            { rechazo = true; }
                                            else
                                            {
                                                if (rbtnCategoriaRecursoNulidadSi.Checked == true)
                                                {
                                                    if (ValidaDropDownList(ddlQuienInterponeRecursos))
                                                    { rechazo = true; }

                                                    if (ValidaDropDownList(ddlFalloRecurso))
                                                    { rechazo = true; }
                                                }
                                            }
                                        }
                                    }
                                    else if (rbtnProcedimientoAbreviadoNo.Checked == true)
                                    {
                                        if (ValidaTextBox(txtFechaProgramadaAudiencia))
                                        { rechazo = true; }
                                    }

                                }
                            
                            }
                        }
                    }
                }
            }
        }

        return rechazo;

    }

    protected void BtnAgregarDiagnostico_Click(object sender, EventArgs e)
    {
        ninocoll ncoll = new ninocoll();
        diagnosticoscoll dcoll = new diagnosticoscoll();

        if (!ValidaAntecedenteJudicialPRJ())
        {
            SqlTransaction sqlt;
            SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
            sconn.Open();
            sqlt = sconn.BeginTransaction();
            try
            {

                int inden = ncoll.Insert_DiagnosticoGeneralTransaccional(sqlt, 12, SSninoDiag.CodNino, SSninoDiag.ICodIE, Convert.ToDateTime(txtFechaAntecedenteJudicial.Text));
                ViewState["CodDiagnostico"] = inden;
                CodAntecedenteJudicialPRJ = InsertUpdateAntecedenteJudicialPRJ(
                                                    sqlt,
                                                    0,
                                                    inden,
                                                    GetDateTime(txtFechaAntecedenteJudicial),
                                                    Convert.ToInt32(ddlComuna.SelectedValue),
                                                    GetRadioButton(rbtnRepresentanteLegalSi, rbtnRepresentanteLegalNo),
                                                    Convert.ToInt32(ddlRepresentanteLegal.SelectedValue),
                                                    GetRadioButton(rbtnRepresentanteJudicialSi, rbtnRepresentanteJudicialNo),
                                                    Convert.ToInt32(ddlRepresentanteJudicial.SelectedValue),
                                                    Convert.ToInt32(ddlTipoCuidadoPersonal.SelectedValue),
                                                    Convert.ToInt32(ddlSusceptibilidad.SelectedValue),
                                                    GetRadioButton(rbtnNNACuradorAdLitemSi, rbtnNNACuradorAdLitemNo),
                                                    Convert.ToInt32(ddlNNACuradorAdLitem.SelectedValue),
                                                    GetRadioButton(rbtnAbogadoEntrevistaRepresentanteNNASi, rbtnAbogadoEntrevistaRepresentanteNNANo),
                                                    GetDateTime(txtFechaUltimaEntrevista),
                                                    Convert.ToInt32(ddlMotivoUltimaEntrevista.SelectedValue),
                                                    txtSintesisEntrevistaRepresentanteNNA.Text,
                                                    Convert.ToDateTime(DateTime.Now),
                                                    Convert.ToInt32(Session["IdUsuario"]),
                                                    Convert.ToInt32(ddlProfesionalTecnico.SelectedValue),
                                                    txtObservaciones.Text);
                

            if (DTMateria.Rows.Count > 0 && CodAntecedenteJudicialPRJ > 0)
            {
                int familia = 0;
                int penal = 0;
                for (int i = 0; i < DTMateria.Rows.Count; i++)
                {
                    if (DTMateria.Rows[i][0].ToString().Trim() == "CAUSA FAMILIA (PROTECCION)")
                    {
                        familia++;
                    }
                    else if (DTMateria.Rows[i][0].ToString().Trim() == "CAUSA PENAL")
                    {
                        penal++;
                    }
                }

                if (familia > 0)
                {
                    if (DTAudiencia.Rows.Count > 0)
                    {
                        int CodMateriaCausaFamilia = InsertCausaFamiliaAntecedenteJudicialPRJ(
                            sqlt,
                            Convert.ToInt32(querytype.CausaFamilia),
                            CodAntecedenteJudicialPRJ,
                            Convert.ToInt32(ddlTribunalCausaFamilia.SelectedValue),
                            txtRUCCausaFamilia.Text,
                            txtRITCausaFamilia.Text,
                            Convert.ToInt32(ddlCalidadComparecePRJCausaFamilia.SelectedValue),
                            GetRadioButton(rbtnDirectorClaveSITFASi, rbtnDirectorClaveSITFANo),
                            Convert.ToInt32(ddlRequirenteMedida.SelectedValue),
                            Convert.ToInt32(ddlVinculoOfensor.SelectedValue),
                            Convert.ToInt32(DTAudiencia.Rows[0]["CodEstadoCausaFamilia"].ToString()),
                            GetDateTime(txtFechaAudienciaFamilia));

                            Session["CodMateriaCausaFamilia"] = CodMateriaCausaFamilia;
                        
                    
                        for (int i = 0; i < DTAudiencia.Rows.Count; i++)
                        {
                            int CodEstadoCausaAntecentePRJ = InsertEstadoCausaAntecedentePRJ(
                                sqlt,
                                CodMateriaCausaFamilia,
                                Convert.ToInt32(DTAudiencia.Rows[i][3].ToString()),
                                0, //Investigacion Cerrada que solo se utiliza en Penal
                                0); // Categoría con Acusación que solo se utiliza en Penal

                            if ((DTAudiencia.Rows[i][1].ToString() == "1" && DTAudiencia.Rows[i][3].ToString() == "4") || // solo cuando es medida cautelar, ingresa a este if solo una vez.
                               (DTAudiencia.Rows[i][1].ToString() == "2" && DTAudiencia.Rows[i][3].ToString() == "7") ||
                               (DTAudiencia.Rows[i][1].ToString() == "3" && DTAudiencia.Rows[i][3].ToString() == "10") ||
                               (DTAudiencia.Rows[i][1].ToString() == "3" && DTAudiencia.Rows[i][3].ToString() == "11") ||
                               (DTAudiencia.Rows[i][1].ToString() == "4" && DTAudiencia.Rows[i][3].ToString() == "12"))
                            {
                                for (int j = 0; j < DTMedidasCautelares.Rows.Count; j++)
			                    {
                                    InsertEstadoCausaMedidasCautelaresPRJ(sqlt, CodEstadoCausaAntecentePRJ, Convert.ToInt32(DTMedidasCautelares.Rows[j][1].ToString()));
			                    }
                                
                            }
                        }
                    }

                }
                

                if (penal > 0)
                {
                    int CantidadDuracionJuicio = 0;
                    if (txtCantidadDuracionJuicio.Text != "")
                    { CantidadDuracionJuicio = Convert.ToInt32(txtCantidadDuracionJuicio.Text); }

                    int CodMateriaCausaPenal = InsertCausaPenalAntecedenteJudicialPRJ(
                        sqlt,
                        Convert.ToInt32(querytype.CausaPenal),
                        CodAntecedenteJudicialPRJ,
                        Convert.ToInt32(ddlCalidadComparecePRJCausaPenal.SelectedValue),
                        GetDateTime(txtFechaDenuncia),
                        Convert.ToInt32(ddlQuienDenunciante.SelectedValue),
                        GetRadioButton(rbtnPRJPresentaQuerellaSi, rbtnPRJPresentaQuerellaNo),
                        GetDateTime(txtPRJFechaPresentacionQuerella),
                        Convert.ToInt32(ddlVinculoVictimario.SelectedValue),
                        Convert.ToInt32(ddlTribunalCausaPenal.SelectedValue),
                        Convert.ToInt32(ddlFiscaliaInvestigacion.SelectedValue),
                        txtRUCCausaPenal.Text,
                        txtRitCausaPenal.Text,
                        Convert.ToInt32(ddlEstadoCausaPenal.SelectedValue),
                        GetDateTime(txtFechaFormalizacion),
                        GetRadioButton(rbtnProcedimientoAbreviadoSi, rbtnProcedimientoAbreviadoNo),
                        Convert.ToInt32(ddlSentencia.SelectedValue),
                        GetRadioButton(rbtnCategoriaRecursoNulidadSi, rbtnCategoriaRecursoNulidadNo,rbtnCategoriaRecursoNulidadPlazoVigente),
                        Convert.ToInt32(ddlQuienInterponeRecursos.SelectedValue),
                        Convert.ToInt32(ddlFalloRecurso.SelectedValue),
                        ddlTipoDuracionJuicio.SelectedValue.ToString(),
                        CantidadDuracionJuicio,
                        GetDateTime(txtFechaProgramadaAudiencia));

                    Session["CodMateriaCausaPenal"] = CodMateriaCausaPenal;


                    if (Convert.ToInt32(ddlCategoriaInvestigación.SelectedValue) > 0)
                    {
                        if (Convert.ToInt32(ddlCategoriaInvestigación.SelectedValue) == 18) // Investigación Cerrada
                        {
                            int CodEstadoCausaAntecentePRJ = InsertEstadoCausaAntecedentePRJ(
                            sqlt,
                            CodMateriaCausaPenal,
                            Convert.ToInt32(ddlCategoriaInvestigación.SelectedValue),
                            Convert.ToInt32(ddlCategoriaInvestigacionCerrada.SelectedValue),
                            Convert.ToInt32(ddlCategoriaConAcusacion.SelectedValue));

                            if (Convert.ToInt32(ddlCategoriaInvestigacionCerrada.SelectedValue) == 6)
                            {
                                if (DTCategoriaAcusacion.Rows.Count > 0)
                                {
                                    for (int i = 0; i < DTCategoriaAcusacion.Rows.Count; i++)
                                    {
                                        InsertCategoriaAcusacion(
                                            sqlt,
                                            CodEstadoCausaAntecentePRJ,
                                            Convert.ToInt32(DTCategoriaAcusacion.Rows[i][1].ToString()));
                                    }
                                }
                            }

                        }
                        else
                        {
                            int CodEstadoCausaAntecentePRJ = InsertEstadoCausaAntecedentePRJ(
                            sqlt,
                            CodMateriaCausaPenal,
                            Convert.ToInt32(ddlCategoriaInvestigación.SelectedValue),
                            0, // No se guarda la categoría Investigación Cerrada Cuando la Categría de la investigación es diferente a Cerrada (Abierta)
                            0);// no se guarda Categoría con Acusación
                        }
                    }

                }

                for (int i = 0; i < DTMateria.Rows.Count; i++)
                {
                    if (DTMateria.Rows[i][0].ToString().Trim() == "CAUSA FAMILIA (PROTECCION)" && Session["CodMateriaCausaFamilia"].ToString() != "")
                    {
                        InsertTipoVulneracionDelitosPRJ(sqlt, Convert.ToInt32(Session["CodMateriaCausaFamilia"].ToString()), Convert.ToInt32(DTMateria.Rows[i][3].ToString()));
                    }
                    else if (DTMateria.Rows[i][0].ToString().Trim() == "CAUSA PENAL" && Session["CodMateriaCausaPenal"].ToString() != "")
                    {
                        InsertTipoVulneracionDelitosPRJ(sqlt, Convert.ToInt32(Session["CodMateriaCausaPenal"]), Convert.ToInt32(DTMateria.Rows[i][3].ToString()));
                    }
                }


            }


            sqlt.Commit();
            sconn.Close();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MensajeGuardado", "alert('Registro Exitoso');", true);
            LimpiarTodoAntecedentesJudicialesPRJ();
            btnGatillo.Attributes.Remove("disabled");
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 500);", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mostrarCollapse", "mostrarCollapse(false);", true);
            GetAntecedentesJudicialesPRJ();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MensajeGuardado", "alert('Guardado no realizado, Intentar Nuevamene.');", true);                
                Console.WriteLine(ex.Message);
                try
                {
                    sqlt.Rollback();
                }
                catch (Exception exRollback)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MensajeGuardado", "alert('Guardado de diagnóstico Realizado Con errores, por favor contactarse con mesa de ayuda. ');", true);                    
                    Console.WriteLine(exRollback.Message);
                }


            }

        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mostrarCollapse", "mostrarCollapse(true);", true);            
            btnGatillo.Attributes.Add("disabled", "disabled");
            btnGatilloCancelar.Visible = true;
        }
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
    protected void grdAntecedentesJudicialesPRJ_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        LimpiarTodoAntecedentesJudicialesPRJ();

        //grdMateria.Columns[2].Visible = false;
        //grdAudiencia.Columns[2].Visible = false;
        //grdMedidaCautelar.Columns[1].Visible = false;
        //grdCategoriaAcusacion.Columns[1].Visible = false;
        //btnAgregarMateria.Visible = false;
        //lnkAgregarMedidaCautelar.Visible = false;
        //lnkAgregarCategoriaAcusacion.Visible = false;
        //lnkAgregarAudiencia.Visible = false;
        //ScriptManager.RegisterStartupScript(this, this.GetType(), "disableAntecedenteJudicialPRJ", " $('#collapse_Form').find('input,button,textarea,select').attr('disabled', 'disabled');", true);
        //BtnLimpiar.Visible = false;
        //BtnAgregarDiagnostico.Visible = false;
        
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MostrarAntecedenteJudicialPRJ", "mostrarBotonCancelar();", true);
        parcoll par = new parcoll();
        CodAntecedenteJudicialPRJ = Convert.ToInt32(((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text);
        DataView dvAntecedenteJudicialPRJ = new DataView(GetAntecedenteJudicialPRJ(Convert.ToInt32(((GridView)sender).Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text)));
        int CodDiagnostico = Convert.ToInt32(dvAntecedenteJudicialPRJ.Table.Rows[0]["CodDiagnostico"].ToString());

        //sqlc.CommandText = "select T1.CodAntecedenteJudicialPRJ, T1.CodDiagnostico, T1.FechaAntecedente, T1.CodComuna, T1.RepresentanteLegal, CodTipoRelacionLegal, RepresentanteJudicial, " +
        //                  "CodTipoRelacionJudicial, CodTipoCuidadoPersonal, CodSusceptibilidadAdopcion, CuradorAdLitem, CodCuradorAdLitem, AbogadoSostuvoEntrevista, FechaEntrevista, CodMotivoUltimaEntrevista, " +
        //                "SintesisEntrevista, FechaActualizacion, IdUsuarioActualizacion, CodTrabajador, Descripcion from AntecedenteJudicialPRJ T1 JOIN DiagnosticoGeneral T2 on T1.CodDiagnostico = T2.CodDiagnostico where T2.ICodIE = @ICodIE";

        if (Convert.ToDateTime(dvAntecedenteJudicialPRJ.Table.Rows[0]["FechaAntecedente"].ToString()).ToShortDateString() != "01-01-1900")
        {
            txtFechaAntecedenteJudicial.Text = Convert.ToDateTime(dvAntecedenteJudicialPRJ.Table.Rows[0]["FechaAntecedente"].ToString()).ToShortDateString();
        }
        ddlRegion.SelectedValue = Convert.ToString(par.Getregionxcomuna(Convert.ToInt32(dvAntecedenteJudicialPRJ.Table.Rows[0]["CodComuna"].ToString())));
        GetComunaTribunales();
        ddlComuna.SelectedValue = dvAntecedenteJudicialPRJ.Table.Rows[0]["CodComuna"].ToString();

        if (Convert.ToInt32(dvAntecedenteJudicialPRJ.Table.Rows[0]["RepresentanteLegal"].ToString()) == 1)
        {
            rbtnRepresentanteLegalSi.Checked = true;
            rbtnRepresentanteLegalNo.Checked = false;
            thQuienRepresentanteLegal.Visible = true;
            tdQuienRepresentanteLegal.Visible = true;
            ddlRepresentanteLegal.SelectedValue = dvAntecedenteJudicialPRJ.Table.Rows[0]["CodTipoRelacionLegal"].ToString();
        }
        if (Convert.ToInt32(dvAntecedenteJudicialPRJ.Table.Rows[0]["RepresentanteJudicial"].ToString()) == 1)
        {
            rbtnRepresentanteJudicialSi.Checked = true;
            rbtnRepresentanteJudicialNo.Checked = false;
            thQuienRepresentanteJudicial.Visible = true;
            tdQuienRepresentanteJudicial.Visible = true;
            ddlRepresentanteJudicial.SelectedValue = dvAntecedenteJudicialPRJ.Table.Rows[0]["CodTipoRelacionJudicial"].ToString();
        }

        ddlTipoCuidadoPersonal.SelectedValue = dvAntecedenteJudicialPRJ.Table.Rows[0]["CodTipoCuidadoPersonal"].ToString();
        ddlSusceptibilidad.SelectedValue = dvAntecedenteJudicialPRJ.Table.Rows[0]["CodSusceptibilidadAdopcion"].ToString();

        if (Convert.ToInt32(dvAntecedenteJudicialPRJ.Table.Rows[0]["CuradorAdLitem"].ToString()) == 1)
        {
            rbtnNNACuradorAdLitemSi.Checked = true;
            rbtnNNACuradorAdLitemNo.Checked = false;
            thNNACuradorAdLitem.Visible = true;
            tdNNACuradorAdLitem.Visible = true;
            ddlNNACuradorAdLitem.SelectedValue = dvAntecedenteJudicialPRJ.Table.Rows[0]["CodCuradorAdLitem"].ToString();
        }

        if (Convert.ToInt32(dvAntecedenteJudicialPRJ.Table.Rows[0]["AbogadoSostuvoEntrevista"].ToString()) == 1)
        {
            rbtnAbogadoEntrevistaRepresentanteNNASi.Checked = true;
            rbtnAbogadoEntrevistaRepresentanteNNANo.Checked = false;
            trEntrevistaRepresentanteNNA.Visible = true;
            if (Convert.ToDateTime(dvAntecedenteJudicialPRJ.Table.Rows[0]["FechaEntrevista"].ToString()).ToShortDateString() != "01-01-1900")
            {
                txtFechaUltimaEntrevista.Text = Convert.ToDateTime(dvAntecedenteJudicialPRJ.Table.Rows[0]["FechaEntrevista"].ToString()).ToShortDateString();
            }
            ddlMotivoUltimaEntrevista.SelectedValue = dvAntecedenteJudicialPRJ.Table.Rows[0]["CodMotivoUltimaEntrevista"].ToString();
            txtSintesisEntrevistaRepresentanteNNA.Text = dvAntecedenteJudicialPRJ.Table.Rows[0]["SintesisEntrevista"].ToString();
            trSintesisEntrevistaRepresentanteNNA.Visible = true;
        }

        ddlProfesionalTecnico.SelectedValue = dvAntecedenteJudicialPRJ.Table.Rows[0]["CodTrabajador"].ToString();
        txtObservaciones.Text = dvAntecedenteJudicialPRJ.Table.Rows[0]["Observaciones"].ToString();

        DataView dvMaterias = new DataView(GetMateria(Convert.ToInt32(dvAntecedenteJudicialPRJ.Table.Rows[0]["CodAntecedenteJudicialPRJ"].ToString())));
        
        //Select Materias
        //"Select CodMateriasAntecedenteJudicialPRJ, CodTipoMateriaCausa, CodAntecedenteJudicialPRJ, CodTribunal, RUC, RIT, CodCalidadComparecePRJ, DirectorTieneClaveSITFA, CodRequirenteMedidaProteccion, CodTipoRelacionOfensor, 
        //FechaDenuncia, CodTipoRelacionDenunciante, PresentaQuerella, FechaQuerella, CodTipoRelacionVictimario, CodFiscalia, ProcedimientoAbreviado, CodTipoSentencia, RecursoNulidad, CodInterponeRecursos, CodFalloRecurso, 
        //CodEstadoCausaPRJ, FechaEstadoCausaPRJ, DuracionJuicioTipo, DuracionJuicioCantidad, FechaAudienciaJuicio from MateriasAntecedenteJudicialPRJ where CodAntecedenteJudicialPRJ = @CodAntecedenteJudicialPRJ order by CodTipoMateriaCausa asc ";

        for (int i = 0; i < dvMaterias.Table.Rows.Count; i++)
        {
            DataView dvTipoVulneracionDelitosPRJ =  new DataView(GetTipoVulneracionDelitosPRJ(Convert.ToInt32(dvMaterias.Table.Rows[i]["CodMateriasAntecedenteJudicialPRJ"].ToString())));

            for (int j = 0; j < dvTipoVulneracionDelitosPRJ.Table.Rows.Count; j++)
            {
                DataRow dr = DTMateria.NewRow();
                dr[0] = dvTipoVulneracionDelitosPRJ.Table.Rows[j]["DescripcionTipoMateria"].ToString();
                dr[1] = dvTipoVulneracionDelitosPRJ.Table.Rows[j]["CodTipoMateria"].ToString();
                dr[2] = dvTipoVulneracionDelitosPRJ.Table.Rows[j]["DescripcionMateria"].ToString();
                dr[3] = dvTipoVulneracionDelitosPRJ.Table.Rows[j]["CodMateria"].ToString();
                DTMateria.Rows.Add(dr);
            }            

            if (Convert.ToInt32(dvMaterias.Table.Rows[i]["CodTipoMateriaCausa"].ToString()) == 1)// CAUSA FAMILIA
            {
                if (Convert.ToInt32(ddlRegion.SelectedValue) > 0)
                {
                    ddlTribunalCausaFamilia.SelectedValue = dvMaterias.Table.Rows[i]["CodTribunal"].ToString();
                }

                txtRUCCausaFamilia.Text = dvMaterias.Table.Rows[i]["RUC"].ToString();
                txtRITCausaFamilia.Text = dvMaterias.Table.Rows[i]["RIT"].ToString();
                ddlCalidadComparecePRJCausaFamilia.SelectedValue = dvMaterias.Table.Rows[i]["CodCalidadComparecePRJ"].ToString();
                SetRadioButton(dvMaterias.Table.Rows[i]["DirectorTieneClaveSITFA"].ToString(), rbtnDirectorClaveSITFASi, rbtnDirectorClaveSITFANo);
                ddlRequirenteMedida.SelectedValue = dvMaterias.Table.Rows[i]["CodRequirenteMedidaProteccion"].ToString();
                ddlVinculoOfensor.SelectedValue = dvMaterias.Table.Rows[i]["CodTipoRelacionOfensor"].ToString();

                if (Convert.ToDateTime(dvMaterias.Table.Rows[i]["FechaEstadoCausaPRJ"].ToString()).ToShortDateString() != "01-01-1900")
                {
                    txtFechaAudienciaFamilia.Text = Convert.ToDateTime(dvMaterias.Table.Rows[i]["FechaEstadoCausaPRJ"].ToString()).ToShortDateString();
                }

                DataView dvEstadoCausaAntecedentePRJ = new DataView(GetEstadoCausaAntecedentePRJ(Convert.ToInt32(dvMaterias.Table.Rows[i]["CodMateriasAntecedenteJudicialPRJ"].ToString())));

                for (int k = 0; k < dvEstadoCausaAntecedentePRJ.Table.Rows.Count; k++)
                {
                    DataRow dr2 = DTAudiencia.NewRow();
                    dr2[0] = dvEstadoCausaAntecedentePRJ.Table.Rows[k]["DescripcionEstadoCausa"].ToString();
                    dr2[1] = dvEstadoCausaAntecedentePRJ.Table.Rows[k]["CodEstadoCausa"].ToString();
                    dr2[2] = dvEstadoCausaAntecedentePRJ.Table.Rows[k]["DescripcionTipoEstadoCausa"].ToString();
                    dr2[3] = dvEstadoCausaAntecedentePRJ.Table.Rows[k]["CodTipoEstadoCausa"].ToString();
                    DTAudiencia.Rows.Add(dr2);

                    DataView dvMedidasCautelares = new DataView(GetEstadoCausaMedidasCautelares(Convert.ToInt32(dvEstadoCausaAntecedentePRJ.Table.Rows[k]["CodEstadoCausaAntecedentePRJ"].ToString())));

                    for (int l = 0; l < dvMedidasCautelares.Table.Rows.Count; l++)
                    {
                        DataRow dr3 = DTMedidasCautelares.NewRow();
                        dr3[0] = dvMedidasCautelares.Table.Rows[l]["DescripcionMedidaCautelar"].ToString();
                        dr3[1] = dvMedidasCautelares.Table.Rows[l]["CodMedidaCautelar"].ToString();
                        DTMedidasCautelares.Rows.Add(dr3);
                    }
                }

                if (DTAudiencia.Rows.Count > 0 )
                {
                    DataView dv = new DataView(DTAudiencia);
                    grdAudiencia.DataSource = dv;
                    dv.Sort = "DescripcionAudiencia";
                    grdAudiencia.DataBind();
                    grdAudiencia.Visible = true;
                    trGrdAudiencia.Visible = true;
                    //ddlEstadoCausaFamilia.SelectedValue = Convert.ToString(0);
                    ddlAudiencia.SelectedValue = Convert.ToString(0);
                    trAvisoAudiencia.Visible = false;
                    lblAvisoAudiencia.Text = "";
                    ValidaMedidasCautelares();
                }

                if (DTMedidasCautelares.Rows.Count > 0)
                {
                    DataView dv3 = new DataView(DTMedidasCautelares);
                    grdMedidaCautelar.DataSource = dv3;
                    dv3.Sort = "DescripcionMedidaCautelar";
                    grdMedidaCautelar.DataBind();
                    grdMedidaCautelar.Visible = true;
                    trGrdMedidaCautelar.Visible = true;
                    ddlMedidaCautelar.SelectedValue = Convert.ToString(0);
                    trAvisoMedidaCautelar.Visible = false;
                }
            }
            else if (Convert.ToInt32(dvMaterias.Table.Rows[i]["CodTipoMateriaCausa"].ToString()) == 2)// CAUSA PENAL
            {
                //Select Materias
                //"Select CodMateriasAntecedenteJudicialPRJ, CodTipoMateriaCausa, CodAntecedenteJudicialPRJ, CodTribunal, RUC, RIT, CodCalidadComparecePRJ, DirectorTieneClaveSITFA, CodRequirenteMedidaProteccion, CodTipoRelacionOfensor, 
                //FechaDenuncia, CodTipoRelacionDenunciante, PresentaQuerella, FechaQuerella, CodTipoRelacionVictimario, CodFiscalia, ProcedimientoAbreviado, CodTipoSentencia, RecursoNulidad, CodInterponeRecursos, CodFalloRecurso, 
                //CodEstadoCausaPRJ, FechaEstadoCausaPRJ, DuracionJuicioTipo, DuracionJuicioCantidad, FechaAudienciaJuicio from MateriasAntecedenteJudicialPRJ where CodAntecedenteJudicialPRJ = @CodAntecedenteJudicialPRJ order by CodTipoMateriaCausa asc ";

                ddlCalidadComparecePRJCausaPenal.SelectedValue = dvMaterias.Table.Rows[i]["CodCalidadComparecePRJ"].ToString();

                if (Convert.ToDateTime(dvMaterias.Table.Rows[i]["FechaDenuncia"].ToString()).ToShortDateString() != "01-01-1900")
                {
                    txtFechaDenuncia.Text = Convert.ToDateTime(dvMaterias.Table.Rows[i]["FechaDenuncia"].ToString()).ToShortDateString();
                }
                ddlQuienDenunciante.SelectedValue = dvMaterias.Table.Rows[i]["CodTipoRelacionDenunciante"].ToString();
                SetRadioButton(dvMaterias.Table.Rows[i]["PresentaQuerella"].ToString(), rbtnPRJPresentaQuerellaSi, rbtnPRJPresentaQuerellaNo);
                if (dvMaterias.Table.Rows[i]["PresentaQuerella"].ToString() == "1")
                {
                    
                    if (Convert.ToDateTime(dvMaterias.Table.Rows[i]["FechaQuerella"].ToString()).ToShortDateString() != "01-01-1900")
                    {
                        thPRJFechaPresentacionQuerella.Visible = true;
                        tdPRJFechaPresentacionQuerella.Visible = true;
                        txtPRJFechaPresentacionQuerella.Text = Convert.ToDateTime(dvMaterias.Table.Rows[i]["FechaQuerella"].ToString()).ToShortDateString();
                    }
                    else
                    {
                        thPRJFechaPresentacionQuerella.Visible = false;
                        tdPRJFechaPresentacionQuerella.Visible = false;
                    }
                
                }
                ddlVinculoVictimario.SelectedValue = dvMaterias.Table.Rows[i]["CodTipoRelacionVictimario"].ToString();
                ddlTribunalCausaPenal.SelectedValue = dvMaterias.Table.Rows[i]["CodTribunal"].ToString();
                ddlFiscaliaInvestigacion.SelectedValue = dvMaterias.Table.Rows[i]["CodFiscalia"].ToString();
                txtRUCCausaPenal.Text = dvMaterias.Table.Rows[i]["RUC"].ToString();
                txtRitCausaPenal.Text = dvMaterias.Table.Rows[i]["RIT"].ToString();

                ddlEstadoCausaPenal.SelectedValue = dvMaterias.Table.Rows[i]["CodEstadoCausaPRJ"].ToString();
                DataView dvEstadoCausaAntecedentePRJ = new DataView(GetEstadoCausaAntecedentePRJ(Convert.ToInt32(dvMaterias.Table.Rows[i]["CodMateriasAntecedenteJudicialPRJ"].ToString())));

                //Select EstadoCausa
                //"Select T1.CodEstadoCausaPRJ as CodEstadoCausa, T3.Descripcion as DescripcionEstadoCausa, T2.CodEstadoCausaAntecedentePRJ, T2.CodMateriasAntecedenteJudicialPRJ, T2.CodTipoEstadoCausaPRJ as CodTipoEstadoCausa,
                //T4.Descripcion as DescripcionTipoEstadoCausa, T2.CodInvestigacionCerrada, T2.CodCategoriaInvestigacionAudiencia 
                //from MateriasAntecedenteJudicialPRJ T1 JOIN EstadoCausaAntecedentePRJ T2 on T1.CodMateriasAntecedenteJudicialPRJ = T2.CodMateriasAntecedenteJudicialPRJ " +
                //"JOIN parEstadoCausaPRJ T3 on T1.CodEstadoCausaPRJ = T3.CodEstadoCausaPRJ JOIN parTipoEstadoCausaPRJ T4 on T2.CodTipoEstadoCausaPRJ = T4.CodTipoEstadoCausaPRJ where T2.CodMateriasAntecedenteJudicialPRJ = @CodMateriasAntecedenteJudicialPRJ";

                CargaCategoriaInvestigacion(Convert.ToInt32(dvMaterias.Table.Rows[i]["CodEstadoCausaPRJ"].ToString()));

                if (Convert.ToInt32(ddlEstadoCausaPenal.SelectedValue) == 6)
                {
                    thFechaFormalizacion.Visible = true;
                    tdFechaFormalizacion.Visible = true;

                    if (Convert.ToDateTime(dvMaterias.Table.Rows[i]["FechaEstadoCausaPRJ"].ToString()).ToShortDateString() != "01-01-1900")
                    {
                        txtFechaFormalizacion.Text = Convert.ToDateTime(dvMaterias.Table.Rows[i]["FechaEstadoCausaPRJ"].ToString()).ToShortDateString();
                    }
                }
                else
                {
                    thFechaFormalizacion.Visible = false;
                    tdFechaFormalizacion.Visible = false;
                }

                ddlCategoriaInvestigación.SelectedValue = dvEstadoCausaAntecedentePRJ.Table.Rows[0]["CodTipoEstadoCausa"].ToString();

                if (Convert.ToInt32(dvEstadoCausaAntecedentePRJ.Table.Rows[0]["CodTipoEstadoCausa"].ToString()) == 18 && Convert.ToInt32(dvEstadoCausaAntecedentePRJ.Table.Rows[0]["CodInvestigacionCerrada"].ToString()) > 0)
                { // Investigación Cerrada

                    CargaCategoriaInvestigacionCerrada();
                    ddlCategoriaInvestigacionCerrada.SelectedValue = dvEstadoCausaAntecedentePRJ.Table.Rows[0]["CodInvestigacionCerrada"].ToString();

                    if (Convert.ToInt32(dvEstadoCausaAntecedentePRJ.Table.Rows[0]["CodInvestigacionCerrada"].ToString()) == 6) //Acusación
                    {                      

                        DataView dvCategoriaAcusacion = new DataView(GetCategoriaAcusacion(Convert.ToInt32(dvEstadoCausaAntecedentePRJ.Table.Rows[0]["CodEstadoCausaAntecedentePRJ"].ToString())));

                        for (int j = 0; j < dvCategoriaAcusacion.Table.Rows.Count; j++)
                        {
                            DataRow dr = DTCategoriaAcusacion.NewRow();
                            dr[0] = dvCategoriaAcusacion.Table.Rows[j]["DescripcionCategoriaInvestigacion"].ToString();
                            dr[1] = dvCategoriaAcusacion.Table.Rows[j]["CodCategoriaInvestigacion"].ToString();

                            DTCategoriaAcusacion.Rows.Add(dr);
                        }

                        if (DTCategoriaAcusacion.Rows.Count > 0)
                        {
                            trAcusacion.Visible = true;
                            DataView dv = new DataView(DTCategoriaAcusacion);
                            grdCategoriaAcusacion.DataSource = dv;
                            dv.Sort = "DescripcionCategoriaInvestigacion";
                            grdCategoriaAcusacion.DataBind();
                            grdCategoriaAcusacion.Visible = true;
                            trGrdCategoriaAcusacion.Visible = true;
                            ddlCategoriaAcusacion.SelectedValue = Convert.ToString(0);
                            trAvisoCategoriaAcusacion.Visible = false;
                            ValidaCategoriaAcusacion();
                        }

                        ddlCategoriaConAcusacion.SelectedValue = dvEstadoCausaAntecedentePRJ.Table.Rows[0]["CodCategoriaInvestigacionAudiencia"].ToString();

                        //Select Materias
                        //"Select CodMateriasAntecedenteJudicialPRJ, CodTipoMateriaCausa, CodAntecedenteJudicialPRJ, CodTribunal, RUC, RIT, CodCalidadComparecePRJ, DirectorTieneClaveSITFA, CodRequirenteMedidaProteccion, CodTipoRelacionOfensor, 
                        //FechaDenuncia, CodTipoRelacionDenunciante, PresentaQuerella, FechaQuerella, CodTipoRelacionVictimario, CodFiscalia, ProcedimientoAbreviado, CodTipoSentencia, RecursoNulidad, CodInterponeRecursos, CodFalloRecurso, 
                        //CodEstadoCausaPRJ, FechaEstadoCausaPRJ, DuracionJuicioTipo, DuracionJuicioCantidad, FechaAudienciaJuicio from MateriasAntecedenteJudicialPRJ where CodAntecedenteJudicialPRJ = @CodAntecedenteJudicialPRJ order by CodTipoMateriaCausa asc ";


                        if (Convert.ToInt32(ddlCategoriaConAcusacion.SelectedValue) == 10 || Convert.ToInt32(ddlCategoriaConAcusacion.SelectedValue) == 12 || Convert.ToInt32(ddlCategoriaConAcusacion.SelectedValue) == 14)
                        { // AUDIENCIA PREPARATORIA DEL JUICIO ORAL 
                           
                            SetRadioButton(dvMaterias.Table.Rows[i]["ProcedimientoAbreviado"].ToString(), rbtnProcedimientoAbreviadoSi, rbtnProcedimientoAbreviadoNo);
                            trProcedimientoAbreviado.Visible = true;

                            if (Convert.ToInt32(dvMaterias.Table.Rows[i]["ProcedimientoAbreviado"].ToString()) == 0)
                            {
                                if (Convert.ToDateTime(dvMaterias.Table.Rows[i]["ProcedimientoAbreviado"].ToString()).ToShortDateString() != "01-01-1900")
                                {
                                    trFechaProgramadaAudiencia.Visible = true;
                                    txtFechaProgramadaAudiencia.Text = Convert.ToDateTime(dvMaterias.Table.Rows[i]["ProcedimientoAbreviado"].ToString()).ToShortDateString();
                                }
                            }
                            else
                            {
                                trSentencia.Visible = true;
                                trFechaProgramadaAudiencia.Visible = false;
                                if (Convert.ToInt32(dvMaterias.Table.Rows[i]["CodTipoSentencia"].ToString()) > 0)
                                { 
                                    ddlSentencia.SelectedValue = dvMaterias.Table.Rows[i]["CodTipoSentencia"].ToString();
                                    ddlTipoDuracionJuicio.SelectedValue = dvMaterias.Table.Rows[i]["DuracionJuicioTipo"].ToString();
                                    txtCantidadDuracionJuicio.Text = dvMaterias.Table.Rows[i]["DuracionJuicioCantidad"].ToString();
                                    trDuracionJuicio.Visible = true;

                                    SetRadioButton(dvMaterias.Table.Rows[i]["RecursoNulidad"].ToString(), rbtnCategoriaRecursoNulidadSi, rbtnCategoriaRecursoNulidadNo,rbtnCategoriaRecursoNulidadPlazoVigente);
                                    trCategoriaRecursoNulidad.Visible = true;

                                    if (Convert.ToInt32(dvMaterias.Table.Rows[i]["RecursoNulidad"].ToString()) == 1)
                                    {
                                        ddlQuienInterponeRecursos.SelectedValue = dvMaterias.Table.Rows[i]["CodInterponeRecursos"].ToString();
                                        ddlFalloRecurso.SelectedValue = dvMaterias.Table.Rows[i]["CodFalloRecurso"].ToString();
                                        trPersonayFalloRecursoNulidad.Visible = true;
                                    }
                                }
                            }
                        }
                        else if (Convert.ToInt32(ddlCategoriaConAcusacion.SelectedValue) == 11 || Convert.ToInt32(ddlCategoriaConAcusacion.SelectedValue) == 13 || Convert.ToInt32(ddlCategoriaConAcusacion.SelectedValue) == 15)
                        { // AUDIENCIA DE JUICIO

                            trSentencia.Visible = true;
                            trFechaProgramadaAudiencia.Visible = false;
                            if (Convert.ToInt32(dvMaterias.Table.Rows[i]["CodTipoSentencia"].ToString()) > 0)
                            {
                                ddlSentencia.SelectedValue = dvMaterias.Table.Rows[i]["CodTipoSentencia"].ToString();
                                ddlTipoDuracionJuicio.SelectedValue = dvMaterias.Table.Rows[i]["DuracionJuicioTipo"].ToString();
                                txtCantidadDuracionJuicio.Text = dvMaterias.Table.Rows[i]["DuracionJuicioCantidad"].ToString();
                                trDuracionJuicio.Visible = true;

                                SetRadioButton(dvMaterias.Table.Rows[i]["RecursoNulidad"].ToString(), rbtnCategoriaRecursoNulidadSi, rbtnCategoriaRecursoNulidadNo, rbtnCategoriaRecursoNulidadPlazoVigente);
                                trCategoriaRecursoNulidad.Visible = true;

                                if (Convert.ToInt32(dvMaterias.Table.Rows[i]["RecursoNulidad"].ToString()) == 1)
                                {
                                    ddlQuienInterponeRecursos.SelectedValue = dvMaterias.Table.Rows[i]["CodInterponeRecursos"].ToString();
                                    ddlFalloRecurso.SelectedValue = dvMaterias.Table.Rows[i]["CodFalloRecurso"].ToString();
                                    trPersonayFalloRecursoNulidad.Visible = true;
                                }
                            }

                        }
                        else
                        {
                            rbtnProcedimientoAbreviadoNo.Checked = true;
                            rbtnProcedimientoAbreviadoSi.Checked = false;
                            trProcedimientoAbreviado.Visible = false;
                            trSentencia.Visible = false;
                        }
                    }
                }
            }
        }

        if (DTMateria.Rows.Count > 0)
        {
            DataView dv = new DataView(DTMateria);
            grdMateria.DataSource = dv;
            dv.Sort = "DescripcionTipoMateria";
            grdMateria.DataBind();
            grdMateria.Visible = true;
            trGrdMateria.Visible = true;
            ddlTipoMateria.SelectedValue = Convert.ToString(0);
            ddlMateria.SelectedValue = Convert.ToString(0);
            trAvisoMateria.Visible = false;
            FiltroMateria();
        }
       
    }

    private void SetRadioButton(string Valor, RadioButton rbtnSi, RadioButton rbtnNo)
    {
        if (Valor.Trim() == "1")
        {
            rbtnSi.Checked = true;
            rbtnNo.Checked = false;
        }
        if (Valor.Trim() == "0")
        {
            rbtnSi.Checked = false;
            rbtnNo.Checked = true;
        }
    }

    private void SetRadioButton(string Valor, RadioButton rbtnSi, RadioButton rbtnNo, RadioButton rbtnOtros)
    {
        if (Valor.Trim() == "1")
        {
            rbtnSi.Checked = true;
            rbtnNo.Checked = false;
            rbtnOtros.Checked = false;
        }
        if (Valor.Trim() == "0")
        {
            rbtnSi.Checked = false;
            rbtnNo.Checked = true;
            rbtnOtros.Checked = false;
        }
        if (Valor.Trim() == "-1")
        {
            rbtnSi.Checked = false;
            rbtnNo.Checked = false;
            rbtnOtros.Checked = true;
        }
    }
    protected void BtnModificarDiagnostico_Click(object sender, EventArgs e) // no se utiliza ya que se genera un nuevo diagnóstico al momento de modificar 
    {
         ninocoll ncoll = new ninocoll();
        diagnosticoscoll dcoll = new diagnosticoscoll();
        bool sw = false;        

        if (!sw && !ValidaAntecedenteJudicialPRJ())
        {
            SqlTransaction sqlt;
            SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
            sconn.Open();
            sqlt = sconn.BeginTransaction();
            try
            {
                InsertUpdateAntecedenteJudicialPRJ(
                            sqlt,
                            CodAntecedenteJudicialPRJ,
                            0,
                            GetDateTime(txtFechaAntecedenteJudicial),
                            Convert.ToInt32(ddlComuna.SelectedValue),
                            GetRadioButton(rbtnRepresentanteLegalSi, rbtnRepresentanteLegalNo),
                            Convert.ToInt32(ddlRepresentanteLegal.SelectedValue),
                            GetRadioButton(rbtnRepresentanteJudicialSi, rbtnRepresentanteJudicialNo),
                            Convert.ToInt32(ddlRepresentanteJudicial.SelectedValue),
                            Convert.ToInt32(ddlTipoCuidadoPersonal.SelectedValue),
                            Convert.ToInt32(ddlSusceptibilidad.SelectedValue),
                            GetRadioButton(rbtnNNACuradorAdLitemSi, rbtnNNACuradorAdLitemNo),
                            Convert.ToInt32(ddlNNACuradorAdLitem.SelectedValue),
                            GetRadioButton(rbtnAbogadoEntrevistaRepresentanteNNASi, rbtnAbogadoEntrevistaRepresentanteNNANo),
                            GetDateTime(txtFechaUltimaEntrevista),
                            Convert.ToInt32(ddlMotivoUltimaEntrevista.SelectedValue),
                            txtSintesisEntrevistaRepresentanteNNA.Text,
                            Convert.ToDateTime(DateTime.Now),
                            Convert.ToInt32(Session["IdUsuario"]),
                            Convert.ToInt32(ddlProfesionalTecnico.SelectedValue),
                            txtObservaciones.Text);

                DataView dvMateriasAntecedenteJudicialPRJ = new DataView(ExisteMateria(CodAntecedenteJudicialPRJ));

                int ExisteFamilia = 0;
                int ExistePenal = 0;
                int FamiliaAgregada = 0;
                int PenalAgregada = 0;

                for (int i = 0; i < dvMateriasAntecedenteJudicialPRJ.Table.Rows.Count; i++)
			    {
                    if (Convert.ToInt32(dvMateriasAntecedenteJudicialPRJ.Table.Rows[i]["CodTipoMateriaCausa"]) == 1)
                    {
                        ExisteFamilia++;
                    }
                    if (Convert.ToInt32(dvMateriasAntecedenteJudicialPRJ.Table.Rows[i]["CodTipoMateriaCausa"]) == 1)
                    {
                        ExistePenal++;
                    }
			    }
                if (DTMateria.Rows.Count > 0 && CodAntecedenteJudicialPRJ > 0)
                {
                    
                    for (int i = 0; i < DTMateria.Rows.Count; i++)
                    {
                        if (DTMateria.Rows[i][0].ToString().Trim() == "CAUSA FAMILIA (PROTECCION)")
                        {
                            FamiliaAgregada++;
                        }
                        else if (DTMateria.Rows[i][0].ToString().Trim() == "CAUSA PENAL")
                        {
                            PenalAgregada++;
                        }
                    }
                }

                if (ExisteFamilia == 1)// EXISTE UNA CAUSA FAMILIA 
                {
                    if (FamiliaAgregada > 0)// HAY AGREGADAS CAUSA FAMILIA
                    {
                        // SE ACTUALIZA LA CAUSA FAMILIA EXISTENTE
                    }
                    else
                    {
                        //SE ELIMINA LA CAUSA FAMILIA Y TODO QUE QUE DEPENDA DE ELLA
                    }
                }
                else
                {
                    if (FamiliaAgregada > 0)// HAY AGREGADAS CAUSA FAMILIA
                    {
                        //SE INSERTA UNA NUEVA CAUSA FAMILIA

                    }
                }

                if (ExistePenal == 1)// EXISTE UNA CAUSA FAMILIA  
                {
                    if (PenalAgregada > 0)// HAY AGREGADAS CAUSA PENAL
                    {
                        // SE ACTUALIZA LA CAUSA FAMILIA EXISTENTE
                    }
                    else
                    {
                        //SE ELIMINA LA CAUSA PENAL Y TODO QUE QUE DEPENDA DE ELLA
                    }
                }
                else
                {
                    if (PenalAgregada > 0)
                    {
                        //SE INSERTA UNA NUEVA CAUSA PENAL
                    }
                }
                

                sqlt.Commit();
                sconn.Close();

                LimpiarTodoAntecedentesJudicialesPRJ();
                btnGatillo.Attributes.Remove("disabled");
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "toTop", "$('html, body').animate({ scrollTop: 0 }, 500);", true);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mostrarCollapse", "mostrarCollapse(false);", true);

            }
            catch (Exception ex)
            {
                Response.Write("<script language='javascript'>alert('Guardado no realizado, Intentar Nuevamene.');</script>");
                Console.WriteLine(ex.Message);
                try
                {
                    sqlt.Rollback();
                }
                catch (Exception exRollback)
                {
                    Response.Write("<script language='javascript'>alert('Guardado de diagnóstico Realizado Con errores, por favor contactarse con mesa de ayuda. ');</script>");
                    Console.WriteLine(exRollback.Message);
                }


            }


        }
    }
    protected void btnGatillo_Click(object sender, EventArgs e)
    {
        LimpiarTodoAntecedentesJudicialesPRJ();
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MostrarAntecedenteJudicialPRJ", "mostrarBotonCancelar();", true);
        BtnAgregarDiagnostico.Visible = true;
        BtnModificarDiagnostico.Visible = false;
        BtnLimpiar.Visible = true;
    }
}