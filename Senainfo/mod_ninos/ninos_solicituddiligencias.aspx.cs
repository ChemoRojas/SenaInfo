/*
 * 
 * GMP
 * 08/05/2015
 * Revisión windows.open, validación de fecha, no hay descargas excel
 * 
 */
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


public partial class mod_ninos_ninos_solicituddiligencias : System.Web.UI.Page
{
  


         

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

    private string dir = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        dir = Request.QueryString["dir"];
      
        //lanza la accion de verificar las fechas de LosFormatter calendarios

        
        if (!IsPostBack)
         {
             if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
                {
                    Response.Redirect("~/logout.aspx");
                }
                else
                {
                getdata();
                //btn002aa.Visible = false;
                }

            

            //cal001.MinDate = SSnino.fchingdesde;
            //cal001.MaxDate = DateTime.Now;
            CalendarExtende1063.EndDate = DateTime.Now;
            rdo001.Enabled = false;
            //rdo002.Enabled = false;
            rdo003.Enabled = false;
            rdo004.Enabled = false;
            rdo005.Enabled = false;
            rdo006.Enabled = false;
            rdo007.Enabled = false;
            rdo008.Enabled = false;
            rdo009.Enabled = false;
            cal002.Attributes.Add("disabled", "disabled");
            //cal002.Enabled = false;
            ddown003.Attributes.Add("disabled","disabled");
            //ddown003.Attributes.Add("disabled", "disabled");
            //cal002.MinDate = SSnino.fchingdesde;
            //cal002.MaxDate = DateTime.Now;
            CalendarExtende1075.StartDate = SSnino.fchingdesde;
            CalendarExtende1075.EndDate = DateTime.Now;

            //if (ddown002.SelectedValue != "6")
            //{
            //    fila_03.Visible = false;
            //    fila_04.Visible = false;
            //}
            //else
            //{
            //    fila_03.Visible = true;
            //    fila_04.Visible = true;
            //}
            //if (rdo002.Checked == true)
            //{
            //    //cal002.Attributes.Add("disabled", "disabled");
            //    cal002.ReadOnly = true;
            //}

            //getdata();

            //if (Request.QueryString["ICodIE"] != null)
            //{
            //    modificardiligencias();
            //}
            if (Request.QueryString["ICodDiligencia"] != null)
            {
                modificardiligencias();
                fueRealizada.Visible = true;
            }
            else
            {
                rdo001.Enabled = false;
                rdo002.Enabled = false;
                rdo003.Enabled = false;
                rdo004.Enabled = false;
                rdo005.Enabled = false;
                rdo006.Enabled = false;
                rdo007.Enabled = false;
                rdo008.Enabled = false;
                rdo009.Enabled = false;
                cal002.Enabled = false;
                //--- esconde filas de la tabla
                fila_01.Visible = false;
                fila_02.Visible = false;
                fila_03.Visible = false;
                fila_04.Visible = false;
                cal002.Attributes.Remove("disabled");
                ddown003.Enabled = false;
                ddown003.Attributes.Remove("disabled");
            }

            //if (Request.QueryString["sw"] !=null )
            if (Request.QueryString["ICodDiligencia"] != null)
            {
                rdo001.Enabled = true;
                rdo002.Enabled = true;
                rdo003.Enabled = true;
                rdo004.Enabled = false;
                rdo005.Enabled = false;
                rdo006.Enabled = false;
                rdo007.Enabled = false;
                rdo008.Enabled = false;
                rdo009.Enabled = false;
                //--- muestra filas de la tabla
                fila_01.Visible = true;
                fila_02.Visible = true;
                fila_03.Visible = true;
                fila_04.Visible = true;
                //cal002.Enabled = true;
                cal002.Attributes.Remove("disabled");
                ddown003.Enabled = true;
                ddown003.Attributes.Remove("disabled");


            }
         }

        if (ddown002.SelectedValue != "6")
        {
            fila_03.Visible = false;
            fila_04.Visible = false;
        }
        else
        {
            fila_03.Visible = true;
            fila_04.Visible = true;
        }
    }

    #region VISIBILIDAD DE FUNCIONALIDADES SEGUN PERMISOS

    private void validatescurity()
    {
        #region Ingreso

        //79270734-C383-487D-8EAB-BC63F1521932 2.2
        //if (!window.existetoken("79270734-C383-487D-8EAB-BC63F1521932"))
        //{

        //    lbtn004.Visible = false;

        //}
        #endregion


        #region VALIDA DATOS DE GESTION


        //B122B56F-15E0-4488-B5FE-FEADD035CF36 2.4
        if (!window.existetoken("B122B56F-15E0-4488-B5FE-FEADD035CF36"))
        {

        }

        //169A2222-0D01-4B62-A224-41B67BAD0387 2.4_INGRESAR
        if (!window.existetoken("169A2222-0D01-4B62-A224-41B67BAD0387"))
        {


            //INFORME DE DIAGNOSTICO



        }

        //21A824F4-19EC-4D44-9C44-C4136DD5AC66 2.4_MODIFICAR
        if (!window.existetoken("21A824F4-19EC-4D44-9C44-C4136DD5AC66"))
        {
            //SOLICITUD DE DILIGENCIAS

        }

        //9273FC38-331B-4E54-B78E-1E7CB41CB0B5 2.4_ELIMINAR
        if (!window.existetoken("9273FC38-331B-4E54-B78E-1E7CB41CB0B5"))
        {

            //SOLICITUD DE DILIGENCIAS

            //PERSONA RELACIONADA
            // No se eliminan personas relacionadas




        }


        #endregion


    }

    #endregion

    private void modificardiligencias()
    {



        // Response.Write(Request.QueryString["ICodDiligencia"]);  
        dilegenciascoll dicoll = new dilegenciascoll();
        DataTable dt = dicoll.GetDiligenciasBycCode(Request.QueryString[/*"ICodIE"*/"ICodDiligencia"]);
        //cal001.Value = dt.Rows[0][4];
        try
        {
            cal001.Text = FormatFecha(dt.Rows[0][3].ToString());
        }
        catch
        {
            cal001.Text = "";
        }

        try
        {
            ddown001.Items.FindByValue(ddown001.SelectedValue).Selected = false;
            ddown001.Items.FindByValue(dt.Rows[0][4].ToString()).Selected = true;
        }
        catch
        {
            ddown001.SelectedIndex = 0;
        }

        try
        {
            ddown002.Items.FindByValue(ddown002.SelectedValue).Selected = false;
            ddown002.Items.FindByValue(dt.Rows[0][1].ToString()).Selected = true;
        }
        catch
        {
            ddown002.SelectedIndex = 0;
        }

        
        try
        {
            ddown003.Items.FindByValue(ddown003.SelectedValue).Selected = false;
            ddown003.Items.FindByValue(dt.Rows[0][8].ToString()).Selected = true;
        }
        catch { }
        if (Convert.ToDateTime(dt.Rows[0][6]).ToShortDateString() == Convert.ToString("01-01-0001"))
        {
            cal002.Text = "";
        }
        else
        {
            cal002.Text = FormatFecha(dt.Rows[0][6].ToString());

        }


        switch (dt.Rows[0][5].ToString())
        {
            case "S":
                rdo001.Checked = true;
                break;
            case "N":
                rdo002.Checked = true;
                break;
            case "I":
                rdo003.Checked = true;
                break;


        }
        switch (dt.Rows[0][9].ToString())
        {
            case "CD":
                rdo004.Checked = true;
                break;
            case "SD":
                rdo005.Checked = true;
                break;
            case "0":
                rdo006.Checked = true;
                break;


        }
        switch (dt.Rows[0][10].ToString())
        {
            case "CD":
                rdo007.Checked = true;
                break;
            case "SD":
                rdo008.Checked = true;
                break;
            case "0":
                rdo009.Checked = true;
                break;


        }

        exp_discernimiento();
        //btn001.Text = "<span class='glyphicon glyphicon-ok'></span>&nbsp;Modificar";
        btn001.Text = "Modificar";//ocupa texto para comprobar otras cosas...
        btn001.Attributes.Add("class", "btn btn-danger btn-sm fixed-width-button");//gfontbrevis


        diagnosticoscoll diacoll = new diagnosticoscoll();
        string ano = Convert.ToString(Convert.ToDateTime(cal001.Text).Year);//DateTime.Now.Year.ToString();
        string mes = Convert.ToString(Convert.ToDateTime(cal001.Text).Month);//DateTime.Now.Month.ToString();
        if (mes.Length <= 1)
        {
            mes = 0 + mes;
        }

        int Periodo = Convert.ToInt32(ano + mes);
        int estado = diacoll.callto_consulta_cierremes(SSnino.CodProyecto, Periodo);
        int Estado_cierre = estado;

        if (Estado_cierre == 1)
        {
            cal001.ReadOnly = true;
        }
    }

    private bool FiltroLRPA()
    {
        #region FiltroLRPA

        bool swLrpa = false;

        LRPAcoll LRPA = new LRPAcoll();

        DataTable dt = new DataTable();
        dt = LRPA.callto_get_proyectoslrpa(Convert.ToInt32(SSnino.CodProyecto));
        try
        {
            if (Convert.ToInt32(dt.Rows[0][0]) > 0 && dt.Rows[0][1].ToString() == "20084")
            {
                swLrpa = true;
            }
            else
            {
                swLrpa = false;
            }
        }
        catch
        {
            Response.Redirect("~/logout.aspx");
        }

        return (swLrpa);


        #endregion

    }

    private void getdata()
    {
        parcoll par = new parcoll();
        trabajadorescoll tcoll = new trabajadorescoll();

        DataView dv1 = new DataView(par.GetparTipoSolicitanteDiligencia());
        ddown001.DataSource = dv1;
        ddown001.DataTextField = "Descripcion";
        ddown001.DataValueField = "TipoSolicitanteDiligencia";
        dv1.Sort = "Descripcion";
        ddown001.DataBind();

        bool swLrpa = FiltroLRPA();
        if (par.GetModeloIntevencion_ProyectosDAM(SSnino.CodProyecto) == 74)
        {
            DataView dv2 = new DataView(par.GetparDiligencia_FiltroPago());
            ddown002.DataSource = dv2;
            ddown002.DataTextField = "Descripcion";
            ddown002.DataValueField = "CodDiligencia";
            dv2.Sort = "Descripcion";
            ddown002.DataBind();
        }
        else if (swLrpa)
        {
            LRPAcoll LRPA = new LRPAcoll();
            DataView dv2 = new DataView(LRPA.GetparDiligenciaLRPA());
            ddown002.DataSource = dv2;
            ddown002.DataTextField = "Descripcion";
            ddown002.DataValueField = "CodDiligencia";
            dv2.Sort = "Descripcion";
            ddown002.DataBind();
        }
        else
        {
            DataView dv2 = new DataView(par.GetparDiligencia());
            ddown002.DataSource = dv2;
            ddown002.DataTextField = "Descripcion";
            ddown002.DataValueField = "CodDiligencia";
            dv2.Sort = "Descripcion";
            ddown002.DataBind();
        }
        DataView dv3 = new DataView(tcoll.GetTrabajadoresProyecto(SSnino.CodProyecto.ToString()));
        ddown003.DataSource = dv3;
        ddown003.DataTextField = "NombreCompleto";
        ddown003.DataValueField = "ICodTrabajador";
        dv3.Sort = "NombreCompleto";
        ddown003.DataBind();





    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void btn001_Click(object sender, EventArgs e)
    {
        //try
        //{
        //using (TransactionScope t = new TransactionScope())
        //{
        dilegenciascoll dcoll = new dilegenciascoll();
        diagnosticoscoll dicoll = new diagnosticoscoll();
        DataTable dt = new DataTable();

        //if (btn001.Text.ToUpper() == "MODIFICAR")
        //{
        //    string ano = Convert.ToString(Convert.ToDateTime(cal002.Text).Year);
        //    string mes = Convert.ToString(Convert.ToDateTime(cal002.Text).Month);

        //    if (mes.Length <= 1)
        //    {
        //        mes = 0 + mes;
        //    }

        //    int Periodo = Convert.ToInt32(ano + mes);
        //    int estado = dicoll.callto_consulta_cierremes(SSnino.CodProyecto, Periodo);
        //    int Estado_cierre = estado;
        //}
        //else
        //{
        //    string ano = Convert.ToString(Convert.ToDateTime(cal001.Text).Year);
        //    string mes = Convert.ToString(Convert.ToDateTime(cal001.Text).Month);

        //    if (mes.Length <= 1)
        //    {
        //        mes = 0 + mes;
        //    }

        //    int Periodo = Convert.ToInt32(ano + mes);
        //    int estado = dicoll.callto_consulta_cierremes(SSnino.CodProyecto, Periodo);
        //    int Estado_cierre = estado;
        //}


        if (btn001.Text.ToUpper() == "MODIFICAR")
        {
            if (validate() == true)
            {

                rdo002.Enabled = true;
                rdo003.Enabled = true;
                rdo004.Enabled = false;
                rdo005.Enabled = false;
                rdo006.Enabled = false;
                rdo007.Enabled = false;
                rdo008.Enabled = false;
                rdo009.Enabled = false;
                DateTime fecha;

                if (rdo002.Checked == true)
                {
                    if (cal002.Text.Trim() == "Seleccione Fecha" || cal002.Text == "")
                    {
                        fecha = Convert.ToDateTime("01-01-1900");
                    }
                    else
                    {
                        fecha = Convert.ToDateTime(cal002.Text);
                    }
                }
                else
                {
                    if (cal002.Text.Trim() == "" || cal002.Text == "")
                    {
                        fecha = Convert.ToDateTime("01-01-1900");
                    }
                    else
                    {
                        fecha = Convert.ToDateTime(cal002.Text);
                    }
                }


                dcoll.Update_Diligencias(Convert.ToInt32(Request.QueryString["ICodDiligencia"]),      //1
                Convert.ToInt32(ddown002.SelectedValue),                    //2
                SSnino.ICodIE,                                              //3
                Convert.ToDateTime(cal001.Text),                           //4
                Convert.ToInt32(ddown001.SelectedValue),                    //5
                FueRealizada(),                                             //6
                FechaRealizada(),                                           //7
                SSnino.CodInst,                                             //8
                Convert.ToInt32(ddown003.SelectedValue),                    //9
                PropuestaTecnica(),                                         //10
                ResultadoDiscernimiento()                                   //11
                , Convert.ToInt32(Session["IdUsuario"]),                       //12
                DateTime.Now);                                              //13

                //ScriptManager.RegisterStartupScript(this.GetType(), "", "RefrescaPadre();", true);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "a", "RefrescaPadre();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "a", "window.parent.closemodal();", true);



            }
        }
        else
        {
            if (validate())
            {
                SSnino.Estado = 0;
                int indice = dcoll.Insert_Diligencias(Convert.ToInt32(ddown002.SelectedValue),
                    SSnino.ICodIE,
                    Convert.ToDateTime(cal001.Text),
                    Convert.ToInt32(ddown001.SelectedValue),
                    "0",
                    Convert.ToDateTime("01-01-1900"),
                    SSnino.CodInst,
                    -1,
                    -1,
                    "0",
                    "0"
                    , Convert.ToInt32(Session["IdUsuario"])
                   , DateTime.Now);

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "b", "RefrescaPadre();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "b", "window.parent.closemodal();", true);
            }
        }
    }

    private bool validate()
    {

        bool n = true;


        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        if (cal001.Text == "Seleccione Fecha" || cal001.Text == "")
        {

            cal001.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {

            if (ConfigurationSettings.AppSettings["Cierre_mes"].ToString() == "1")
            {
                if (btn001.Text.ToUpper() == "MODIFICAR")
                {
                    if (rdo001.Checked == true)
                    {
                        if (cal002.Text != "")
                        {
                            DateTime fecha = Convert.ToDateTime(cal002.Text);
                            string ano = Convert.ToDateTime(fecha).Year.ToString();// fecha.Year.ToString();
                            string mes = Convert.ToDateTime(fecha).Month.ToString();  //DateTime.Now.Month.ToString();
                            oNNA NNA = (oNNA)Session["NNA"];

                            if (mes.Length <= 1)
                            {
                                mes = 0 + mes;
                            }

                            diagnosticoscoll dcoll = new diagnosticoscoll();

                            int Periodo = Convert.ToInt32(ano + mes);
                            int Estado_cierre = dcoll.callto_consulta_cierremes(Convert.ToInt32(NNA.NNACodProyecto), Periodo);
                            if (Estado_cierre != 1)
                            {
                                cal002.BackColor = System.Drawing.Color.White;
                            }
                            else
                            {
                                cal002.BackColor = colorCampoObligatorio;
                                lbl002.Text = "Mes seleccionado se encuentra cerrado";
                                lbl002.Visible = true;
                                n = false;
                            }
                        }
                        else
                        {
                            n = false;
                        }

                    }
                    else
                    {
                        string mes = (DateTime.Now.Month).ToString();
                        string ano = (DateTime.Now.Year).ToString();
                        oNNA NNA = (oNNA)Session["NNA"];
                        if (mes.Length <= 1)
                        {
                            mes = 0 + mes;
                        }

                        diagnosticoscoll dcoll = new diagnosticoscoll();

                        int Periodo = Convert.ToInt32(ano + mes);
                        int Estado_cierre = dcoll.callto_consulta_cierremes(Convert.ToInt32(NNA.NNACodProyecto), Periodo);

                        if (Estado_cierre != 1)
                        {
                            cal002.BackColor = System.Drawing.Color.White;
                        }
                        else
                        {
                            cal002.BackColor = colorCampoObligatorio;
                            lbl002.Text = "Mes seleccionado se encuentra cerrado";
                            lbl002.Visible = true;
                            n = false;
                        }
                    }

                    //diagnosticoscoll dcoll = new diagnosticoscoll();

                    //int Periodo = Convert.ToInt32(ano + mes);
                    //int Estado_cierre = dcoll.callto_consulta_cierremes(Convert.ToInt32(NNA.NNACodProyecto), Periodo);

                    //if (Estado_cierre != 1)
                    //{
                    //    cal002.BackColor = System.Drawing.Color.White;
                    //}
                    //else
                    //{
                    //    cal002.BackColor = colorCampoObligatorio;
                    //    lbl002.Text = "Mes seleccionado se encuentra cerrado";
                    //    lbl002.Visible = true;
                    //    n = false;
                    //}
                }
                else
                {
                    n = true;
                }
            }

        }

        if (Convert.ToInt32(ddown001.SelectedValue) == 0)
        {
            ddown001.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown001.BackColor = System.Drawing.Color.White;

        }

        if (Convert.ToInt32(ddown002.SelectedValue) == 0)
        {
            ddown002.BackColor = colorCampoObligatorio;
            n = false;
        }
        else
        {
            ddown002.BackColor = System.Drawing.Color.White;

        }

        if (Convert.ToInt32(ddown002.SelectedValue) == 6)
        {
            if (rdo004.Checked == true || rdo005.Checked == true || rdo006.Checked == true)
            {
                rdo004.BackColor = System.Drawing.Color.White;
                rdo005.BackColor = System.Drawing.Color.White;
                rdo006.BackColor = System.Drawing.Color.White;
            }
            else
            {
                if (btn001.Text.ToUpper() == "MODIFICAR")
                {
                    rdo004.BackColor = colorCampoObligatorio;
                    rdo005.BackColor = colorCampoObligatorio;
                    rdo006.BackColor = colorCampoObligatorio;
                    n = false;
                }
            }

            if (rdo007.Checked == true || rdo008.Checked == true || rdo009.Checked == true)
            {
                rdo007.BackColor = System.Drawing.Color.White;
                rdo008.BackColor = System.Drawing.Color.White;
                rdo009.BackColor = System.Drawing.Color.White;
            }
            else
            {
                if (btn001.Text.ToUpper() == "MODIFICAR")
                {
                    rdo007.BackColor = colorCampoObligatorio;
                    rdo008.BackColor = colorCampoObligatorio;
                    rdo009.BackColor = colorCampoObligatorio;
                    n = false;
                }
            }
        }


        //if (rdo001.Checked == true || rdo002.Checked == true || rdo003.Checked == true)
        if (rdo001.Checked == true) //karina se modica para que pida en cualquier condicion la fecha y el usuario (Vuelve a ser como antes) JVR
        {
            if (cal002.Text == "")
            //if (cal002.Text == "Seleccione Fecha" || cal002.Text == "")
            {

                cal002.BackColor = colorCampoObligatorio;
                n = false;
            }
            else
            {
                cal002.BackColor = System.Drawing.Color.White;
                lbl001.Visible = false;
                if (lbl002.Visible == true)
                {
                    cal002.BackColor = colorCampoObligatorio;
                }

            }



            if (Convert.ToInt32(ddown003.SelectedValue) == 0 || Convert.ToInt32(ddown003.SelectedValue) == -1)
            {
                ddown003.BackColor = colorCampoObligatorio;
                n = false;
            }
            else
            {
                ddown003.BackColor = System.Drawing.Color.White;

            }

        }
        else
        {

            ddown003.BackColor = System.Drawing.Color.White;
            cal002.BackColor = System.Drawing.Color.White;

        }
        if ((cal002.Text.Trim() != "") && (!rdo001.Checked && !rdo002.Checked && !rdo003.Checked))
        {
            if (btn001.Text.ToUpper() == "MODIFICAR")
            {
                n = false;
                rdo001.BackColor = colorCampoObligatorio;
                rdo002.BackColor = colorCampoObligatorio;
                rdo003.BackColor = colorCampoObligatorio;
            }
        }
        else
        {
            rdo001.BackColor = System.Drawing.Color.White;
            rdo002.BackColor = System.Drawing.Color.White;
            rdo003.BackColor = System.Drawing.Color.White;
        }
        return n;

    }

    private void cleanPantalla()
    {

        for (int j = 0; j < this.Form.Controls.Count; j++)
        {
            for (int i = 0; i < this.Form.Controls[j].Controls.Count; i++)
            {


                try
                {
                    ((TextBox)this.Controls[j].Controls[i]).Text = "";
                }
                catch { }
                try
                {
                    ((DropDownList)this.Controls[j].Controls[i]).SelectedIndex = 0;
                }
                catch { }


            }

        }



    }

    private string FueRealizada()
    {
        if (rdo001.Checked)
        {
            return "S";
        }
        else if (rdo002.Checked)
        {
            return "N";
        }
        else if (rdo003.Checked)
        {
            return "I";
        }
        else
        {
            return "0";
        }
    }

    private DateTime FechaRealizada()
    {
        if (cal002.Text == null || cal002.Text.Trim() == "" || cal002.Text == "Seleccione Fecha")
        {
            return Convert.ToDateTime("01/01/1900");
        }
        else
        {
            return Convert.ToDateTime(cal002.Text);
        }

    }

    private String PropuestaTecnica()
    {
        if (rdo004.Checked)
        {
            return "CD";
        }
        else if (rdo005.Checked)
        {
            return "SD";
        }
        else if (rdo006.Checked)
        {
            return "SI";
        }
        else
        {
            return "0";
        }

    }

    private String ResultadoDiscernimiento()
    {
        if (rdo007.Checked)
        {
            return "CD";
        }
        else if (rdo008.Checked)
        {
            return "SD";
        }
        else if (rdo009.Checked)
        {
            return "SI";
        }
        else
        {
            return "0";
        }

    }

    protected void ddown002_SelectedIndexChanged(object sender, EventArgs e)
    {
        exp_discernimiento();
        if (ddown002.SelectedValue != "6")
        {
            fila_03.Visible = false;
            fila_04.Visible = false;
        }
        else
        {
            fila_03.Visible = true;
            fila_04.Visible = true;
        }

        //rdo004.Checked = false;
        //rdo005.Checked = false;
        //rdo006.Checked = false;
        //rdo007.Checked = false;
        //rdo008.Checked = false;
        //rdo009.Checked = false;
    }

    private void exp_discernimiento()
    {
        if (ddown002.SelectedValue.Equals("6") && btn001.Text.ToUpper() == "MODIFICAR")
        {
            rdo001.Enabled = true;
            rdo002.Enabled = true;
            rdo003.Enabled = true;
            rdo004.Enabled = true;
            rdo005.Enabled = true;
            rdo006.Enabled = true;
            rdo007.Enabled = true;
            rdo008.Enabled = true;
            rdo009.Enabled = true;
        }
        else if (!ddown002.SelectedValue.Equals("6") && rdo002.Checked == true || rdo003.Checked == true || rdo002.Checked == false && btn001.Text.ToUpper() == "MODIFICAR" || rdo003.Checked == false && btn001.Text.ToUpper() == "MODIFICAR")
        {
            rdo001.Enabled = true;
            rdo002.Enabled = true;
            rdo003.Enabled = true;
            cal002.Attributes.Remove("disabled");
            ddown003.Attributes.Remove("disabled");
            rdo004.Enabled = false;
            rdo005.Enabled = false;
            rdo006.Enabled = false;
            rdo007.Enabled = false;
            rdo008.Enabled = false;
            rdo009.Enabled = false;

            rdo006.Checked = true;
            rdo009.Checked = true;

        }
        else if (!ddown002.SelectedValue.Equals("6") && rdo001.Checked == true && btn001.Text.ToUpper() == "MODIFICAR")
        {
            cal002.Attributes.Remove("disabled");
            ddown003.Attributes.Remove("disabled");
            rdo004.Enabled = false;
            rdo005.Enabled = false;
            rdo006.Enabled = false;
            rdo007.Enabled = false;
            rdo008.Enabled = false;
            rdo009.Enabled = false;

            rdo006.Checked = true;
            rdo009.Checked = true;
        }
        else
        {
            rdo001.Enabled = false;
            rdo002.Enabled = false;
            rdo003.Enabled = false;
            rdo004.Enabled = false;
            rdo005.Enabled = false;
            rdo006.Enabled = false;
            rdo007.Enabled = false;
            rdo008.Enabled = false;
            rdo009.Enabled = false;
            fila_03.Visible = false;
            fila_04.Visible = false;
        }
    }
  
    protected void btn003_Click(object sender, EventArgs e)
    {
        cal001.Text = "";
        cal002.Text = "";
        ddown001.SelectedValue = Convert.ToString("0");
        ddown002.SelectedValue = Convert.ToString("0");
        ddown003.SelectedValue = Convert.ToString("0");
        
        rdo001.Checked = true;
    }

    protected void cal002_ValueChanged(object sender, EventArgs e)
    {
        diagnosticoscoll diacoll = new diagnosticoscoll();
       try
       {
            string ano = Convert.ToString(Convert.ToDateTime(cal002.Text).Year);//DateTime.Now.Year.ToString();
            string mes = Convert.ToString(Convert.ToDateTime(cal002.Text).Month);//DateTime.Now.Month.ToString();
        
       
        if (mes.Length <= 1)
        {
            mes = 0 + mes;
        }

        int Periodo = Convert.ToInt32(ano + mes);
        int estado = diacoll.callto_consulta_cierremes(SSnino.CodProyecto, Periodo);
        int Estado_cierre = estado;

        if (cal002.Text != "" || cal001.Text != "")
        {

            if (Convert.ToDateTime(cal002.Text) > Convert.ToDateTime(cal001.Text))
            {
                //cal002.Text = "";
                lbl001.Text = "La fecha de Realización debe ser mayor a la fecha de Solicitud";
            }
            else if (Estado_cierre == 1)
            {
                //cal002.Text = "";
                lbl001.Text = "El mes seleccionado no debe estar cerrado";

            }
            else
            {
                lbl001.Text = "";
                lbl001.Visible = false;
            }
        }
            }
           catch(Exception ex)
            {
                lbl001.Text = "No ha ingresado datos validos";
            }

    }

    protected void rdo001_CheckedChanged(object sender, EventArgs e) // check SI
    {
        //cal002.Enabled = true;
        //cal002.Attributes.Remove("disabled");
        cal002.ReadOnly = false;

        if (rdo001.Checked == true && ddown002.SelectedValue.ToUpper().Trim() == "6")
        {
            rdo004.Enabled = true;
            rdo005.Enabled = true;
            rdo006.Enabled = true;
            rdo007.Enabled = true;
            rdo008.Enabled = true;
            rdo009.Enabled = true;

        }
        else
        {
            rdo004.Enabled = false;
            rdo005.Enabled = false;
            rdo006.Enabled = false;
            rdo007.Enabled = false;
            rdo008.Enabled = false;
            rdo009.Enabled = false;

        }
        //fila_01.Visible = true;
        //fila_02.Visible = true;
    }

    protected void rdo002_CheckedChanged(object sender, EventArgs e) //check NO
    {
        //cal002.Enabled = false;
        //cal002.Enabled =true;
        //cal002.Attributes.Remove("disabled");
        //cal002.Attributes.Add("disabled", "disabled");
        cal002.ReadOnly = true;
        //cal002.Text = "";
        
        rdo004.Enabled = false;
        rdo005.Enabled = false;
        rdo006.Enabled = false;
        rdo007.Enabled = false;
        rdo008.Enabled = false;
        rdo009.Enabled = false;

        rdo006.Checked = true;
        rdo009.Checked = true;

        //fila_01.Visible = false;
        //fila_02.Visible = false;
    }

    protected void rdo003_CheckedChanged(object sender, EventArgs e) // no fue posible
    {
        //cal002.Enabled = true;
        cal002.Attributes.Add("disabled", "disabled");
        rdo004.Enabled = false;
        rdo005.Enabled = false;
        rdo006.Enabled = false;
        rdo007.Enabled = false;
        rdo008.Enabled = false;
        rdo009.Enabled = false;

        rdo006.Checked = true;
        rdo009.Checked = true;

        //fila_01.Visible = false;
        //fila_02.Visible = false;
    }



    private string FormatFecha(string fecha) {
        string salida = string.Empty;
        try
        {
            salida = Convert.ToDateTime(fecha).ToString("dd-MM-yyyy"); 
        }
        catch { return string.Empty; }

        if (salida == "01-01-1900") salida = string.Empty;
        return salida;
    }

    protected void ddown003_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
