using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mod_instituciones_RegistroFomentoALaParticipacion : System.Web.UI.Page
{
    public int IcodFomento
    {
        //1A55DD5E-8260-4392-9CC1-5D5D6329C4A8
        get { return (int)Session["IcodFomento"]; }
        set { Session["IcodFomento"] = value; }
    }  
    int IcodFomentoAsistencia;
    //int IcodFomento;
    int Icodie;
    int p1;
    int p2;
    int p3;
    int p4;
    int p5;
    int CodProyecto;
    int CodAmbito;
    int CodModulo;
    string fecha = string.Empty;
    int codInstitucion_;
    string nombreProyecto_ = string.Empty;
    string nombreInstituto_ = string.Empty;
    int asistencia;

    private void validatesecurity()
    {
        if (!window.existetoken("1A55DD5E-8260-4392-9CC1-5D5D6329C4A8"))
        {
            Response.Redirect("~/e403.aspx");
        }
    }

    protected void Page_Load(object sender, EventArgs e)
     {
        if (!IsPostBack)
        {
            getparambito();
            getparmodulo();
            IcodFomento = 0;
        }
    
    }
    private void ListadoAsistencia(int CodProyecto)
    {
        ninocoll ncoll = new ninocoll();
        // = ;
        int CodModeloIntervencion = 0;

        if (CodProyecto != 0)
            CodModeloIntervencion = (int)ncoll.callto_get_codmodelointervencion(CodProyecto);
        else
            return;

        if (WebDateChooser1.Text == null) //|| (CodModeloIntervencion != 107 && CodModeloIntervencion != 104))       // PPC - PROGRAMA PREVENCION COMUNITARIA
            return;

        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();


        int vCodPaso = -1;
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "GetNinosEventoProyecto_PPC";
        sqlc.Parameters.Add("@ICodEventosProyectos", SqlDbType.Int, 4).Value = vCodPaso;
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = CodProyecto;
        sqlc.Parameters.Add("@FechaVigencia", SqlDbType.DateTime, 16).Value = WebDateChooser1.Text;
        sqlc.Parameters.Add("@MesCerrado", SqlDbType.Int, 4).Value = cierre_mes();

        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();

        if (dt.Rows.Count > 0)
        {

            CheckBox chkPresente = new CheckBox();

            grd_ninosVigentes.DataSource = dt;
            grd_ninosVigentes.DataBind();
             lblCantidadVigentes.Visible = true;
            lblCantidadVigentes.Text = dt.Rows.Count.ToString() + " Niños vigentes al " + WebDateChooser1.Text;
            grd_ninosVigentes.Visible = true;
            grd_ninosVigentes.HeaderRow.TableSection = TableRowSection.TableHeader;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "e1", "generateDataTable($('#grd_ninosVigentes'));", true);
         //   SenainfoSdk.UI.AllInOne.Modificar(codInstitucion_, nombreInstituto_, CodProyecto, nombreProyecto_);
        }
        
        
    }
    private int cierre_mes()
    {
        diagnosticoscoll dgcol = new diagnosticoscoll();
        string mes = "";
        int anomes, cta;
        if (Convert.ToDateTime(WebDateChooser1.Text).Month.ToString().Length == 1)
        {
            try
            {
                mes = "0" + Convert.ToDateTime(WebDateChooser1.Text).Month.ToString();
            }
            catch
            {

            }
        }
        else
        {
            try
            {
                mes = Convert.ToDateTime(WebDateChooser1.Text).Month.ToString();
            }
            catch
            {

            }
        }
        anomes = Convert.ToInt32(Convert.ToDateTime(WebDateChooser1.Text).Year.ToString() + mes);
        int codigoProyecto = I_Institucion.CodInstitucionSeleccionado;
        cta = dgcol.callto_consulta_cierremes(codigoProyecto, anomes);
            //dgcol.callto_consulta_cierremes(Convert.ToInt32(ddown002.SelectedValue), anomes);

        return cta;
    }
    protected void WebImageButton1_Click(object sender, EventArgs e)
    {
        //ListadoAsistencia(I_Proyecto.CodProyectoSeleccionado);
        ObtenerFomentoParticipacion();
    }
    private void getparambito()
    {
        parcoll par = new parcoll();
        DataView dv = new DataView(par.GetParAmbito());
        ddl_ambito.DataSource = dv;
        ddl_ambito.DataTextField = "Descripcion";
        ddl_ambito.DataValueField = "CodAmbito";
        dv.Sort = "";
        ddl_ambito.DataBind();

    }
    private void getparmodulo()
    {
        parcoll par = new parcoll();
        DataView dv = new DataView(par.GetparModulo());
        ddl_modulo.DataSource = dv;
        ddl_modulo.DataTextField = "Descripcion";
        ddl_modulo.DataValueField = "CodModulo";
        dv.Sort = "";
        ddl_modulo.DataBind();
    }

    protected void lnk_guardar_Click(object sender, EventArgs e)
    {
        int resultado;
        int Institucion = I_Institucion.CodInstitucionSeleccionado;
        int proyecto = I_Proyecto.CodProyectoSeleccionado;
        int ambito = Convert.ToInt32(ddl_ambito.SelectedValue);
        int modulo = Convert.ToInt32(ddl_modulo.SelectedValue);
        DateTime fecha = Convert.ToDateTime(WebDateChooser1.Text);

        SqlCommand cmd = new SqlCommand();
        Conexiones con = new Conexiones();
        SqlConnection conex = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        con.Autenticar();

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "Insert_FomentoParticipacion";
        var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
        returnParameter.Direction = ParameterDirection.ReturnValue;
        //cmd.Parameters.Add("@idFomento", SqlDbType.Int).Value = 0;
        cmd.Parameters.Add("CodProyecto", SqlDbType.Int).Value = proyecto;

        cmd.Parameters.Add("CodAmbito", SqlDbType.Int).Value = ambito;
        cmd.Parameters.Add("CodModulo", SqlDbType.Int).Value = modulo;
        cmd.Parameters.Add("Fecha", SqlDbType.DateTime).Value = fecha;
        cmd.Connection = conex; 

        try
        {
            conex.Open();
            int valreturn = cmd.ExecuteNonQuery();
            resultado = (int)returnParameter.Value;
            Insert_FomentoParticipacion_AsistenciaNino(resultado);
            cmd.Connection.Close();
           
        }
        catch (Exception ex)
        {
        }
    }
    private void Insert_FomentoParticipacion_AsistenciaNino(int codfomento)
    {
        int contador = 0;
        foreach (GridViewRow grv_registro in grd_ninosVigentes.Rows)
        {
            int count = grd_ninosVigentes.Rows.Count;
            string p1 = "0";
            string p2 = "0";
            string p3 = "0";
            string p4 = "0";
            string p5 = "0";
            int asistencia = 0;

            TextBox txtaux = new TextBox();
            txtaux = grv_registro.FindControl("txt_P1") as TextBox;
            if (txtaux.Text != "")
            p1 = txtaux.Text;
            else txtaux.Text = "0";
            txtaux = grv_registro.FindControl("txt_p2") as TextBox;
            if(txtaux.Text != "")
            p2 = txtaux.Text;
            else txtaux.Text = "0";
            txtaux = grv_registro.FindControl("txt_p3") as TextBox;
            if(txtaux.Text != "")
            p3 = txtaux.Text;
            else txtaux.Text = "0";
            txtaux = grv_registro.FindControl("txt_p4") as TextBox;
            if(txtaux.Text != "")
            p4 = txtaux.Text;
            else txtaux.Text = "0";
            txtaux = grv_registro.FindControl("txt_p5a") as TextBox;
            if(txtaux.Text != "")
            p5 = txtaux.Text;
            else txtaux.Text = "0";

            CheckBox chk = new CheckBox();
            chk = grv_registro.FindControl("chkAsistencia") as CheckBox;
            if (chk.Checked != true)
                asistencia = 0;
            else asistencia = 1;

            int icodfomento = codfomento;
            int icodie = Convert.ToInt32(grv_registro.Cells[0].Text);
            int p1_ = Convert.ToInt32(p1);
            int p2_ = Convert.ToInt32(p2);
            int p3_ = Convert.ToInt32(p3);
            int p4_ = Convert.ToInt32(p4);
            int p5_ = Convert.ToInt32(p5);
            int asistencia_ = Convert.ToInt32(asistencia);
            DateTime FechaAtualizacion = DateTime.Now;
            int idUsuario = Convert.ToInt32(Session["IdUsuario"]);
            

            SqlCommand cmd = new SqlCommand();
            Conexiones con = new Conexiones();
            SqlConnection conex = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
            con.Autenticar();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Insert_FomentoParticipacion_AsistenciaNino";
            cmd.Parameters.Add("@IcodFomento", SqlDbType.Int).Value = icodfomento;
            cmd.Parameters.Add("@Icodie", SqlDbType.Int).Value = icodie;
            cmd.Parameters.Add("@p1", SqlDbType.Int).Value = p1_;
            cmd.Parameters.Add("@p2", SqlDbType.Int).Value = p2_;
            cmd.Parameters.Add("@p3", SqlDbType.Int).Value = p3_;
            cmd.Parameters.Add("@p4", SqlDbType.Int).Value = p4_;
            cmd.Parameters.Add("@p5", SqlDbType.Int).Value = p5_;
            cmd.Parameters.Add("@Asistencia", SqlDbType.Int).Value = asistencia_;
            cmd.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime).Value = FechaAtualizacion;
            cmd.Parameters.Add("idUsuario", SqlDbType.Int).Value = idUsuario;
            cmd.Connection = conex;
            try
            {  
              
                contador = contador + 1;
                lbl_contador.Text = Convert.ToString(contador);
                conex.Open();
                SqlDataReader Retornodata = cmd.ExecuteReader();
                cmd.Connection.Close();
                Retornodata.Close();
                lnk_guardar.Visible = false;
                lnk_modificar.Visible = true;

            }
            catch (Exception ex)
            {
            }
      
        }        
    }
    protected void ObtenerFomentoParticipacion_AsistenciaNino(int icodfomento_int)
    {
        DataTable dt_grv = new DataTable();
        dt_grv = obtengoNinosxCodigoFomento(icodfomento_int);
        if (dt_grv.Rows.Count > 0)
        {
            grd_ninosVigentes.DataSource = dt_grv;
            grd_ninosVigentes.DataBind();
            foreach (GridViewRow grow in grd_ninosVigentes.Rows)
            {
                TextBox txt1 = new TextBox();
                txt1 = grow.FindControl("txt_P1") as TextBox;
                txt1.Text = dt_grv.Rows[grow.RowIndex]["p1"].ToString();

                TextBox txt2 = new TextBox();
                txt2 = grow.FindControl("txt_P2") as TextBox;
                txt2.Text = dt_grv.Rows[grow.RowIndex]["p2"].ToString();

                TextBox txt3 = new TextBox();
                txt3 = grow.FindControl("txt_P3") as TextBox;
                txt3.Text = dt_grv.Rows[grow.RowIndex]["p3"].ToString();

                TextBox txt4 = new TextBox();
                txt4 = grow.FindControl("txt_P4") as TextBox;
                txt4.Text = dt_grv.Rows[grow.RowIndex]["p4"].ToString();


                TextBox txt5 = new TextBox();
                txt5 = grow.FindControl("txt_P5a") as TextBox;
                txt5.Text = dt_grv.Rows[grow.RowIndex]["p5"].ToString();

                CheckBox chk = new CheckBox();
                chk = grow.FindControl("chkAsistencia") as CheckBox;
                int check = Convert.ToInt32(dt_grv.Rows[grow.RowIndex]["Asistencia"].ToString());
                chk.Checked = Convert.ToBoolean(check);
            }

            grd_ninosVigentes.HeaderRow.TableSection = TableRowSection.TableHeader;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "e1", "generateDataTable($('#grd_ninosVigentes'));", true);
        }
        else
            ListadoAsistencia(I_Proyecto.CodProyectoSeleccionado);
        
        //Conexiones con = new Conexiones();
        //DataTable dt_get = (DataTable)con.TraerDataTable("Consulta_FomentoParticipacion_AsistenciaNino", icodfomento_int);
        //grd_ninosVigentes.DataSource = dt_get;
        //grd_ninosVigentes.DataBind();

        //foreach (GridViewRow grow in grd_ninosVigentes.Rows)
        //{
        //    ListadoAsistencia(CodProyecto);
        //    TextBox txt = new TextBox();
        
        //    txt = grd_ninosVigentes.FindControl("txt_p1") as TextBox;
        //}

        //foreach (DataRow dt in dt_get.Rows)
        //{
        //     IcodFomentoAsistencia = Convert.ToInt32(dt["IcodFomentoAsistencia"]);
        //     IcodFomento = Convert.ToInt32(dt["IcodFomento"]);
        //     Icodie = Convert.ToInt32(dt["Icodie"]);
        //     p1 = Convert.ToInt32(dt["p1"]);
        //     p2 = Convert.ToInt32(dt["p2"]);
        //     p3 = Convert.ToInt32(dt["p3"]);
        //     p4 = Convert.ToInt32(dt["p4"]);
        //     p5 = Convert.ToInt32(dt["p5"]);

        //     TextBox txt = new TextBox();
        //     txt = grd_ninosVigentes.FindControl("txt_P1") as TextBox;
        //     txt.Text = Convert.ToString(p1);

        //}
       // ListadoAsistencia(CodProyecto);
    }
    protected void ObtenerFomentoParticipacion()
    {
        int codproyecto_ = I_Proyecto.CodProyectoSeleccionado;
        int codambito_ = Convert.ToInt32(ddl_ambito.SelectedValue);
        int codmodulo_ = Convert.ToInt32(ddl_modulo.SelectedValue);
        DateTime fecha_ = Convert.ToDateTime(WebDateChooser1.Text);

        List<DbParameter> listDbParameter = new List<DbParameter>();
        coordinador cr = new coordinador();
        Conexiones con = new Conexiones();
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        SqlCommand sqlc = new SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = CommandType.StoredProcedure;
        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int).Value = codproyecto_;
        sqlc.Parameters.Add("@CodAmbito", SqlDbType.Int).Value = codambito_;
        sqlc.Parameters.Add("@CodModulo", SqlDbType.Int).Value = codmodulo_;
        sqlc.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = fecha_;
        sqlc.CommandText = "Consultar_FomentoParticipacion";
        SqlDataAdapter da = new SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        if (dt.Rows.Count > 0)
        {
            lnk_modificar.Visible = true;
            lnk_guardar.Visible = false;
            foreach (DataRow dr in dt.Rows)
            {
                CodProyecto = Convert.ToInt32(dr["CodProyecto"]);
                CodAmbito = Convert.ToInt32(dr["CodAmbito"]);
                CodModulo = Convert.ToInt32(dr["Codmodulo"]);
                fecha = dr["Fecha"].ToString();
                IcodFomento = Convert.ToInt32(dr["IcodFomento"]);
            }
            string sql = "select top 1 t1.CodProyecto,t1.CodInstitucion,t1.Nombre as NombreProyecto,t2.Nombre as NombreInstitucion from proyectos t1 left join Instituciones t2 on t1.CodInstitucion = t2.CodInstitucion where t1.CodProyecto = @CodProyecto";
            listDbParameter.Add(SenainfoSdk.Conexiones.CrearParametro("@CodProyecto", CodProyecto));
            DataTable dtProyecto = cr.ejecuta_SQL(sql, listDbParameter);
            foreach (DataRow dt2 in dtProyecto.Rows)
            {
                codInstitucion_ = Convert.ToInt32(dt2["CodInstitucion"]);
                nombreProyecto_ = dt2["NombreProyecto"].ToString();
                nombreInstituto_ = dt2["NombreInstitucion"].ToString();

            }

            //SenainfoSdk.UI.AllInOne.Modificar(codInstitucion_, nombreInstituto_, CodProyecto, nombreProyecto_);
        }
       
        //ddl_ambito.SelectedValue =Convert.ToString(CodAmbito);
        //WebDateChooser1.Text = fecha;
        //ddl_modulo.SelectedValue = Convert.ToString(CodModulo);
        ObtenerFomentoParticipacion_AsistenciaNino(IcodFomento);


    }
    protected DataTable obtengoNinosxCodigoFomento(int codfomento)
    {
        Conexiones con = new Conexiones();
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        SqlCommand sqlc = new SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = CommandType.StoredProcedure;
        sqlc.Parameters.Add("@IcodFomento", SqlDbType.Int).Value = codfomento;
        sqlc.CommandText = "getNinosxICodFomento";
        SqlDataAdapter da = new SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    protected void lnk_modificar_Click(object sender, EventArgs e)
    {
        int resultado;
        int Institucion = I_Institucion.CodInstitucionSeleccionado;
        int proyecto = I_Proyecto.CodProyectoSeleccionado;
        int ambito = Convert.ToInt32(ddl_ambito.SelectedValue);
        int modulo = Convert.ToInt32(ddl_modulo.SelectedValue);
        DateTime fecha = Convert.ToDateTime(WebDateChooser1.Text);

        SqlCommand cmd = new SqlCommand();
        Conexiones con = new Conexiones();
        SqlConnection conex = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        con.Autenticar();

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "Insert_FomentoParticipacion";
        var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
        returnParameter.Direction = ParameterDirection.ReturnValue;
       // cmd.Parameters.Add("@idFomento", SqlDbType.Int).Value = IcodFomento;
        cmd.Parameters.Add("CodProyecto", SqlDbType.Int).Value = proyecto;
        cmd.Parameters.Add("CodAmbito", SqlDbType.Int).Value = ambito;
        cmd.Parameters.Add("CodModulo", SqlDbType.Int).Value = modulo;
        cmd.Parameters.Add("Fecha", SqlDbType.DateTime).Value = fecha;
        cmd.Connection = conex;

        try 
        {
            conex.Open();
            int valreturn = cmd.ExecuteNonQuery();
            resultado = (int)returnParameter.Value;
            Insert_FomentoParticipacion_AsistenciaNino(IcodFomento);
            cmd.Connection.Close();
        
 

        }
        catch (Exception ex)
        {
        }
    }
    protected void WebImageButton2_Click(object sender, EventArgs e)
    {
        SenainfoSdk.UI.Util.CleanControl(Controls);
    }
}  