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

public partial class mod_instituciones_Talleres_Proyecto : System.Web.UI.Page
{
    private string msgsp;
    private void validatesecurity()
    {
        if (!window.existetoken("90F0F6A9-160A-41D7-A584-EB3A616A6D50"))
        { 
            Response.Redirect("~/e403.aspx");
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //1A55DD5E-8260-4392-9CC1-5D5D6329C4A8
        if (!IsPostBack)
        {
            //vistaFormulario("Planificacion");
            tr_proyeccion.Visible = true;
            tr_compraBienes.Visible = false;
            tr_gastoejecutado.Visible = false;
            tr_registroTotal.Visible = false;
            tr_proyeccion.Visible = true;
            tr_reporteCierreRealizado.Visible = false;
            btn_update_Planificacion.Visible = true;
            tr_gastoplanificado.Visible = true;
            txt_gasto_planificado.Visible = true;
            tr_numSessiones.Visible = true;
            
            limpiaAlertas();
            
            getpartalleres();
            GetallTalleres();
        }
    }
    protected void limpiaAlertas()
    {
        alertSuccess.Visible = false;
        alerts.Visible = false;
        lbl_alertSuccess.Text = string.Empty;
        lbl_error_dia.Text = string.Empty;
    }
    private void getpartalleres()
    {
        parcoll par = new parcoll();
        DataView dv = new DataView(par.GetParTalleres()); 
        ddl_tipoTaller.DataSource = dv;
        ddl_tipoTaller.DataTextField = "Descripcion";
        ddl_tipoTaller.DataValueField = "CodTipoTaller";
        dv.Sort = "";
        ddl_tipoTaller.DataBind();
        
    }
    private void GetNombreTalleres(int codtaller)
    {
        parcoll par = new parcoll();
        DataView dv = new DataView(par.GetNombreTalleres(codtaller));
        ddl_nombreTaller.DataSource = dv;
        ddl_nombreTaller.DataTextField = "Descripcion";
        ddl_nombreTaller.DataValueField = "CodTaller";
        ddl_nombreTaller.DataBind();
       // DataView dv = new DataView(par.GetNombreTalleres(5));
        //ddl_tipoTaller.DataSource = dv;
        //ddl_tipoTaller.DataTextField = "Descripcion"; 
        //ddl_tipoTaller.DataValueField = "CodTipoTaller";
        //dv.Sort = "";
        //ddl_tipoTaller.DataBind();

        // int resultado;

        //Conexiones con = new Conexiones();
        //System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + con.Servidor + " ;Database= " + con.Base + " ; User ID= " + con.Usuario + " ;Password= " + con.Passw + " ;Trusted_Connection=False");
        //System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        //sconn.InfoMessage += (object sender, SqlInfoMessageEventArgs e) =>
        //{
        //   msgsp += e.Message;
        //};
        //try
        //{
           
        //    sqlc.Connection = sconn;
        //    sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        //    sqlc.CommandText = "GetNombreTalleres";

        //    var returnParameter = sqlc.Parameters.Add("@ReturnVal", SqlDbType.Int);
        //    returnParameter.Direction = ParameterDirection.ReturnValue;
        //    sqlc.Parameters.Add("@codTaller", SqlDbType.Int).Value = codtaller;


        //    this.msgsp = string.Empty;

        //    sconn.Open();

        //    sqlc.ExecuteNonQuery();

        //    resultado = (int)returnParameter.Value;

        //    sconn.Close();
        //}
        //catch (Exception ex)
        //{ }


    }
    protected void btn_update_situacionMigratoria_Click(object sender, EventArgs e)
    {
        ViewState["estado"] = "Cierre";
        GuardarInfoTaller();
    }
    protected void Obtenertalleres(int icodtaller)
    {
        int codInstitucion_ = 0;
        string nombreProyecto_ = "";
        string nombreInstituto_ = "";
        List<DbParameter> listDbParameter = new List<DbParameter>();
        coordinador cr = new coordinador();
        parcoll par = new parcoll();
        DataTable dt_get = (DataTable)par.ConsultoTaller2(icodtaller);
        //DataTable dt_get = (DataTable)con.TraerDataTable("Consulta_Taller2",1);
        try
        {
            grd_taller.DataSource = dt_get;
            grd_taller.DataBind();
        }
        catch (Exception ex)
        { }
        foreach (DataRow dt in dt_get.Rows)
        {
            ViewState["VS_IcodTaller"] = dt["icodtaller"];
            int codproyecto = Convert.ToInt32(dt["CodProyecto"]);
            string tipoTaller = dt["CodTaller"].ToString();
            string nombreTaller = dt["NombreTaller"].ToString();
            int cbs = Convert.ToInt32(dt["CompraBienesServicio"]);
            int rte = Convert.ToInt32(dt["SesionesExpediente"]);
            int rcr = Convert.ToInt32(dt["CierreRealizado"]);
            DateTime fechaInicio = Convert.ToDateTime(dt["FechaInicio"].ToString());
            DateTime fechaTermino = Convert.ToDateTime(dt["FechaTermino"].ToString());
            string descripcion = dt["Descripcion"].ToString();
            string gastoPlanificado = dt["GastoPlanificado"].ToString();
            string gastoEjecutado = dt["GastoEjecutado"].ToString();
            string numeSessiones =  dt["NumSessiones"].ToString();

            ddl_tipoTaller.SelectedValue = tipoTaller;
            if (cbs == 1)
                chk_cbs.Checked = true;
            else chk_cbs.Checked = false;
            if (rte == 1) 
                chk_rsE.Checked = true;
            else chk_rsE.Checked = false;
            if (rcr == 1)
                chk_rcr.Checked = true;
            else chk_rcr.Checked = false;
            if (rbl_conProyProd.SelectedValue == "1")
            { rbl_conProyProd.SelectedValue = "1"; }
            else { rbl_conProyProd.SelectedValue = "0"; }
            txt_fechaInicio.Text = fechaInicio.ToShortDateString();
            txt_fechaTermino.Text = fechaTermino.ToShortDateString();
            txt_descripcion.Text = descripcion;
            txt_gasto_planificado.Text = gastoPlanificado;
            txt_gasto_ejecutado.Text = gastoEjecutado;
            txt_nSessiones.Text = numeSessiones;
            //I_Proyecto.Modificar(
            //string sql = "SELECT t1.CodPlanIntervencion, upper(t1.Descripcion) as Descripcion FROM planintervencion as t1 where icodie = @IcodIE";
          
           // string sql = "select codProyecto,CodInstitucion, Nombre from proyectos where CodProyecto = @CodProyecto";
            string sql = "select t1.CodProyecto,t1.CodInstitucion,t1.Nombre as NombreProyecto,t2.Nombre as NombreInstitucion from proyectos t1 left join Instituciones t2 on t1.CodInstitucion = t2.CodInstitucion where t1.CodProyecto = @CodProyecto";
            listDbParameter.Add(SenainfoSdk.Conexiones.CrearParametro("@CodProyecto", codproyecto));
            DataTable dtProyecto = cr.ejecuta_SQL(sql, listDbParameter);
            foreach (DataRow dt2 in dtProyecto.Rows)
            {
                 codInstitucion_ = Convert.ToInt32(dt2["CodInstitucion"]);
                 nombreProyecto_ = dt2["NombreProyecto"].ToString();
                 nombreInstituto_ = dt2["NombreInstitucion"].ToString();

            }
           // I_Institucion.Modificar(codInstitucion_, nombreInstituto_);
           // I_Proyecto.Modificar(codInstitucion_, nombreInstituto_, codproyecto, nombreProyecto_);
            SenainfoSdk.UI.AllInOne.Modificar(codInstitucion_, nombreInstituto_, codproyecto, nombreProyecto_);
            int codtaller = Convert.ToInt32(ddl_tipoTaller.SelectedValue);
            GetNombreTalleres(codtaller);
            ddl_nombreTaller.SelectedItem.Text = nombreTaller;
            string valEstado = dt["Estado"].ToString();
            vistaFormulario(valEstado);
            //deshabilito controles para que no se modifiquen
 
        }
    }
    protected void ddl_tipoTaller_SelectedIndexChanged(object sender, EventArgs e)
    {
        int codtaller = Convert.ToInt32(ddl_tipoTaller.SelectedValue);
        GetNombreTalleres(codtaller);
        
    }
    protected void GetallTalleres()
    {
        parcoll par = new parcoll();
        DataTable dt_get = (DataTable)par.ConsultoTaller();
        //DataTable dt_get = (DataTable)con.TraerDataTable("Consulta_Taller",1);
        try
        {
            grd_taller.DataSource = dt_get;
            grd_taller.DataBind();

            int icodtaller = Convert.ToInt32(dt_get.Rows[0]["IcodTaller"].ToString());
           
        }
        catch (Exception ex)
        { }
    }
    protected void grd_taller_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string icodtaller =  e.CommandArgument.ToString();
        vistaFormulario(e.CommandName.ToString());
        Obtenertalleres(Convert.ToInt32(icodtaller));
        limpiaAlertas();
        lbl_error_dia.Visible = true;
        lbl_error_dia.Text = "Usted se encuentra en etapa de" + " " + e.CommandName.ToString();
        alerts.Visible = true;
        GetallTalleres();
    }
    protected void btn_update_Planificacion_Click(object sender, EventArgs e)
    {
        ViewState["estado"] = "Planificacion";
        if (ddl_nombreTaller.SelectedValue != "")
        {
            if (txt_fechaInicio.Text != "" && txt_fechaTermino.Text != "")
            { GuardarInfoTaller(); alerts.Visible = false; lbl_error_dia.Text = string.Empty; }
            else
            {
                lbl_error_dia.Visible = true;
                lbl_error_dia.Text = "Debe ingresa los campos solicitados";
                alerts.Visible = true;
            }
        }
        else
        {
            lbl_error_dia.Visible = true;
            lbl_error_dia.Text = "Debe ingresa los campos solicitados";
            alerts.Visible = true;
        }
        
    }
    protected void GuardarInfoTaller()
    {
        int id_codtaller = 0;
        id_codtaller = Convert.ToInt32(ViewState["VS_IcodTaller"]);
        int proyec = this.I_Proyecto.CodProyectoSeleccionado;
        //int codproyecto =  C_buscar_x_institu_proyecto.CodProyectoSeleccionado;
        //int codInstitucion = C_buscar_x_institu_proyecto.CodInstitucionesSeleccionado;       
        int codInstitucion = I_Institucion.CodInstitucionSeleccionado;
        int codproyecto = I_Proyecto.CodProyectoSeleccionado;
        int codTaller = int.Parse(ddl_nombreTaller.SelectedValue);
        DateTime fechaIncio = DateTime.Parse(txt_fechaInicio.Text);
        DateTime fechaTermino = DateTime.Parse(txt_fechaTermino.Text);
        bool compraBienesServicios = chk_cbs.Checked;
        bool SesionesExpediente = chk_rsE.Checked;
        bool CierreRealizado = chk_rcr.Checked;
        string Descripcion = txt_descripcion.Text.Trim();
        DateTime fechaActualizacion = DateTime.Now;
        string usuario = Session["IdUsuario"].ToString();
        string NombreTaller = ddl_nombreTaller.SelectedItem.Text;
        string gastoPlanificado = txt_gasto_planificado.Text;
        string gastoEjecutado = txt_gasto_ejecutado.Text;
        string Conproyeccionproductiva = rbl_conProyProd.SelectedValue;
        string estado = ViewState["estado"].ToString();
        string Numsesiones = txt_nSessiones.Text;


        SqlCommand cmd = new SqlCommand();
        Conexiones con = new Conexiones();
        SqlConnection conex = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        con.Autenticar();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "Insert_Taller";
        cmd.Parameters.Add("IcodTaller", SqlDbType.Int).Value = id_codtaller;
        cmd.Parameters.Add("Codproyecto", SqlDbType.Int).Value = codproyecto;
        cmd.Parameters.Add("CodTaller", SqlDbType.Int).Value = codTaller;
        cmd.Parameters.Add("FechaInicio", SqlDbType.DateTime).Value = fechaIncio;
        cmd.Parameters.Add("FechaTermino", SqlDbType.DateTime).Value = fechaTermino;
        cmd.Parameters.Add("Conproyeccionproductiva", SqlDbType.VarChar).Value = Conproyeccionproductiva;
        cmd.Parameters.Add("CompraBienesServicio", SqlDbType.Bit).Value = compraBienesServicios;
        cmd.Parameters.Add("SesionesExpediente", SqlDbType.Bit).Value = SesionesExpediente;
        cmd.Parameters.Add("CierreRealizado", SqlDbType.Bit).Value = CierreRealizado;
        cmd.Parameters.Add("Descripcion", SqlDbType.VarChar).Value = Descripcion;
        cmd.Parameters.Add("FechaActualizacion", SqlDbType.VarChar).Value = fechaActualizacion;
        cmd.Parameters.Add("Usuario", SqlDbType.VarChar).Value = usuario;
        cmd.Parameters.Add("NombreTaller", SqlDbType.VarChar).Value = NombreTaller;
        cmd.Parameters.Add("GastoPlanificado", SqlDbType.VarChar).Value = gastoPlanificado;
        cmd.Parameters.Add("GastoEjecutado", SqlDbType.VarChar).Value = gastoEjecutado;
        cmd.Parameters.Add("Estado", SqlDbType.VarChar).Value = estado;
        cmd.Parameters.Add("NumSessiones", SqlDbType.VarChar).Value = Numsesiones;
        cmd.Connection = conex;

        try
        {
            conex.Open();
            SqlDataReader Retornodata = cmd.ExecuteReader();
            cmd.Connection.Close();
            Retornodata.Close();
            alertSuccess.Visible = true;
            lbl_alertSuccess.Visible = true;
            lbl_alertSuccess.Text = "Registro realizado Correctamente...";
            GetallTalleres();
        }
        catch (Exception ex)
        {
            alerts.Visible = true;
            lbl_error_dia.Visible = true;
            lbl_error_dia.Text = "Error al procesar la información"+" "+ ex.Message;
        }     
    }
    protected void btn_update_Ejecucion_Click(object sender, EventArgs e)
    {
        ViewState["estado"] = "Ejecucion";
        vistaFormulario("visible");
        
        GuardarInfoTaller();
    }
    protected void vistaFormulario(string vista)
    {
        switch (vista)
        {
                //cuando entre a planificacion hacer visible lo de ejecucion
            case "Planificacion":
               //btn_update_Planificacion.Visible = false;
               // btn_update_Ejecucion.Visible = true;
               // btn_update_situacionMigratoria.Visible = false;
               // tr_proyeccion.Visible = true;
               // tr_compraBienes.Visible = true;
               // tr_gastoejecutado.Visible = true;
               // tr_gastoplanificado.Visible = true;
               // tr_registroTotal.Visible = true;
               // tr_proyeccion.Visible = true;
               // tr_reporteCierreRealizado.Visible = true;
                btn_limpiar.Visible = true;
                btn_update_Planificacion.Visible = false;
                btn_update_Ejecucion.Visible = true;
                btn_update_situacionMigratoria.Visible = false;
                tr_proyeccion.Visible = true;
                tr_compraBienes.Visible = false;
                tr_gastoejecutado.Visible = true;
                tr_gastoplanificado.Visible = true;
                txt_gasto_ejecutado.Visible = true;
                tr_registroTotal.Visible = true;
                tr_proyeccion.Visible = true;
                tr_reporteCierreRealizado.Visible = false;

                break;
            case "Ejecucion":
                //btn_limpiar.Visible = true;
                //btn_update_Planificacion.Visible = false;
                //btn_update_Ejecucion.Visible = true;
                //btn_update_situacionMigratoria.Visible = false;
                //tr_proyeccion.Visible = true;
                //tr_compraBienes.Visible = true;
                //tr_gastoejecutado.Visible = true;
                //tr_gastoplanificado.Visible = true;
                //txt_gasto_ejecutado.Visible = true;
                //tr_registroTotal.Visible = true;
                //tr_proyeccion.Visible = true;
                //tr_reporteCierreRealizado.Visible = true;

                ////deshabilito controles para que no se modifiquen
                //ddl_tipoTaller.Enabled = true;
                //ddl_nombreTaller.Enabled = true;
                //rbl_conProyProd.Enabled = true;
                //chk_cbs.Enabled = true;
                //chk_rsE.Enabled = true;
                //chk_rcr.Enabled = true;
                    btn_limpiar.Visible = true;
                btn_update_Planificacion.Visible = false;
                btn_update_Ejecucion.Visible = false;
                btn_update_situacionMigratoria.Visible = false;
                btn_update_Cierre.Visible = true;
                tr_proyeccion.Visible = true;
                tr_compraBienes.Visible = true;
                tr_gastoejecutado.Visible = true;
                tr_gastoplanificado.Visible = true;
                tr_registroTotal.Visible = true;
                tr_proyeccion.Visible = true;
                tr_reporteCierreRealizado.Visible = true;

                //deshabilito controles para que no se modifiquen
                ddl_tipoTaller.Enabled = false;
                ddl_nombreTaller.Enabled = false;
                rbl_conProyProd.Enabled = true;
                chk_cbs.Enabled = true;
                chk_rsE.Enabled = true;
                chk_rcr.Enabled = true;

                break;
            case "Cierre":
                btn_limpiar.Visible = true;
                btn_update_Planificacion.Visible = false;
                btn_update_Ejecucion.Visible = false;
                btn_update_situacionMigratoria.Visible = false;
                btn_update_Cierre.Visible = true;
                tr_proyeccion.Visible = true;
                tr_compraBienes.Visible = true;
                tr_gastoejecutado.Visible = true;
                tr_gastoplanificado.Visible = true;
                tr_registroTotal.Visible = true;
                tr_proyeccion.Visible = true;
                tr_reporteCierreRealizado.Visible = true;

                //deshabilito controles para que no se modifiquen
                ddl_tipoTaller.Enabled = true;
                ddl_nombreTaller.Enabled = true;
                rbl_conProyProd.Enabled = true;
                chk_cbs.Enabled = true;
                chk_rsE.Enabled = true;
                chk_rcr.Enabled = true;

                break;
           
        }
       
    }

    protected void btn_update_Cierre_Click(object sender, EventArgs e)
    {
        ViewState["estado"] = "Cierre";
        GuardarInfoTaller();
    }
    protected void btn_limpiar_Click(object sender, EventArgs e)
    {
        SenainfoSdk.UI.Util.CleanControl(Controls);
        Response.Redirect("Talleres_Proyecto.aspx");
    }
    protected void grd_taller_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd_taller.PageIndex = e.NewPageIndex;
        grd_taller.DataBind();
    }
}  