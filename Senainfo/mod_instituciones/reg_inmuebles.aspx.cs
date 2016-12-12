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
using System.Drawing;

public partial class mod_institucion_reg_inmuebles : System.Web.UI.Page
{
    public int vCodPaso
    {
        get { return (int)Session["vCodPaso"]; }
        set { Session["vCodPaso"] = value; }
    }
    public string vsBuscaEspecifica
    {
        get { return (string)Session["vsBuscaEspecifica"]; }
        set { Session["vsBuscaEspecifica"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //string url_lupita1 = "bsc_institucion.aspx?param001=" + lbl001.Text + "&dir=reg_inmuebles.aspx&param002=SI";
        //A1.HRef = url_lupita1;

        //string url_lupita2 = "bsc_institucion.aspx?param001=" + lbl001.Text + "&dir=reg_inmuebles.aspx&codinst=" + ddown001.SelectedValue ;
        //A2.HRef = url_lupita2;

        if (!IsPostBack)
        {
            if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
            {
                Response.Redirect("~/logout.aspx");
            }
            else
            {
                if (!window.existetoken("54E1332C-4FD5-4034-8596-E097C6CFA58C"))
                {
                    Response.Redirect("~/logout.aspx");
                }
                getinstituciones();

                getregion();
                getcomuna();
                gettipoinmueble();
                getsituacionlegal();

                if (Request.QueryString["sw"] == "1" && vsBuscaEspecifica == null)
                {
                    Get_Resultado_Busqueda(vCodPaso);

                }
                else
                {
                    ddown001.SelectedValue = Convert.ToString(vsBuscaEspecifica);
                    vsBuscaEspecifica = null;
                }

                validatescurity(); //LO ULTIMO DEL LOAD
            }
        }

    }

    private void validatescurity()
    {
        //050866FC-1A2B-4D38-91C2-6D7E6796A175 1.3_INGRESAR
        if (!window.existetoken("050866FC-1A2B-4D38-91C2-6D7E6796A175"))
        {
           // WebImageButton2.Visible = false;
            WebImageButton1.Visible = false;
            //block();

        }
        //2A6F6013-9230-43E5-90EF-E14BA3B07EC4 1.3_MODIFICAR
        if (!window.existetoken("2A6F6013-9230-43E5-90EF-E14BA3B07EC4"))
        {
            WebImageButton4.Visible = false;
           // WebImageButton2.Visible = false;
            //block();

        }
        //2A3EE049-3FA8-43C1-B3A0-47D1D2299846 1.3_ELIMINAR
        if (!window.existetoken("2A3EE049-3FA8-43C1-B3A0-47D1D2299846"))
        {
            
        }

    }
    private void getinstituciones()
    {

        institucioncoll ncoll = new institucioncoll();
        DataView dv1 = new DataView(ncoll.GetData(Convert.ToInt32(Session["IdUsuario"])));
        ddown001.DataSource = dv1;
        ddown001.DataTextField = "Nombre";
        ddown001.DataValueField = "CodInstitucion";
        dv1.Sort = "Nombre";
        DataBind();


    }
    
   
    private void getregion()
    {


        parcoll par = new parcoll();
        DataView dv6 = new DataView(par.GetparRegion());
        ddown004.DataSource = dv6;
        ddown004.DataTextField = "Descripcion";
        ddown004.DataValueField = "CodRegion";
        dv6.Sort = "CodRegion";
        ddown004.DataBind();


    }
    private void getcomuna()
    {
        if (Convert.ToInt32(ddown004.SelectedValue)!= 0)
        {

            parcoll par = new parcoll();
            DataView dv6 = new DataView(par.GetparComunas(ddown004.SelectedValue));
            ddown009.Items.Clear();
            ddown009.DataSource = dv6;
            ddown009.DataTextField = "Descripcion";
            ddown009.DataValueField = "CodComuna";
            dv6.Sort = "Descripcion";
            ddown009.DataBind();


        }
        else
        {
            ddown009.Items.Clear();
        }
    }
    private void gettipoinmueble()
    {

        inmueblecoll icoll = new inmueblecoll();

        DataTable dtproy = icoll.GetparTipoInmueble();
        ddown005.DataSource = dtproy;
        ddown005.DataTextField = "Descripcion";
        ddown005.DataValueField = "TipoInmueble";
        ddown005.DataBind();
    }
    private void getsituacionlegal()
    {

        parcoll pcoll = new parcoll();

        DataTable dtproy = pcoll.GetparSituacionLegalInmueble();
        ddown006.DataSource = dtproy;
        ddown006.DataTextField = "Descripcion";
        ddown006.DataValueField = "CodsituacionLegalInmueble";
        ddown006.DataBind();
    }

    //protected void Webmaskedit5_ValueChange(object sender, EventArgs e)
    //{

    //}
    protected void ddown001_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }

    protected void ddown008_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void ddown004_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddown004.SelectedValue != "0")
        {
            ddown004.BackColor = System.Drawing.Color.White;    
        }
        getcomuna();
    }


    public void Get_Resultado_Busqueda(int codinmueble)
    {
        string sParametrosConsulta = "Select T1.CodInstitucion,T1.ICodInmueble,T1.CodInmueble,T1.IdUsuarioActualizacion,T1.CodSituacionLegalInmueble," +
                                    "T1.CodComuna,T1.TipoInmueble,T1.Nombre,T1.Direccion,T1.Telefono," +
                                    "T1.Fax,T1.CodigoPostal,T1.m2Construidos,T1.m2totales,T1.NumeroDormitorios," +
                                    "T1.CapacidadNinos,T1.NumeroBanos,T1.CantidadPisos,T1.AreasVerdes,T1.IndVigencia,T1.FechaActualizacion " +
                                    "From Inmueble T1 Where T1.ICodInmueble =" + codinmueble;

        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(sParametrosConsulta, out datareader);
        while (datareader.Read())
        {
            try
            {
                WebImageButton1.Visible = false;
                WebImageButton4.Visible = true;
                ddown001.SelectedValue = Convert.ToString((int)datareader["CodInstitucion"]);
                txt0015.Text = (String)datareader["Nombre"];
                txt002.Text = (String)datareader["Direccion"];
                
                parcoll par = new parcoll();
                int codRegion = par.Getregionxcomuna((int)datareader["CodComuna"]);
                ddown004.SelectedValue = Convert.ToString(codRegion);
                getcomuna();
                ddown009.SelectedValue = Convert.ToString((int)datareader["CodComuna"]);
                
                txt005.Text = (String)datareader["Telefono"];
                txt007.Text = (String)datareader["Fax"];
                txt008.Text = datareader["CodigoPostal"].ToString();
                ddown005.SelectedValue = Convert.ToString((int)datareader["TipoInmueble"]);
                ddown006.SelectedValue = Convert.ToString((int)datareader["CodSituacionLegalInmueble"]);
                txt009.Text =(String)datareader["m2Construidos"].ToString();
                txt0010.Text = (String)datareader["m2totales"].ToString() ;
                txt0011.Text = (String)datareader["NumeroDormitorios"].ToString();
                txt0012.Text = (String)datareader["CapacidadNinos"].ToString();
                txt0013.Text = (String)datareader["NumeroBanos"].ToString();
                txt0014.Text = (String)datareader["CantidadPisos"].ToString();
                ddown007.SelectedValue = (String)datareader["AreasVerdes"].ToString();
               
                ddown001.Enabled = false;

            }
            catch { }
        }
        con.Desconectar();

    }

    private void funcion_guardar()
    {
        int ICodInmueble = -1;
        lblMsgSuccess.Visible = false;
        alertS.Visible = false;
        alertW.Visible = false;
        lblMsgWarning.Visible = false;
        try
        {
            ICodInmueble = vCodPaso;
        }
        catch { }
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        if (txt0015.Text == "" || ddown004.SelectedValue == "0" || ddown009.SelectedValue == "0" || ddown005.SelectedValue == "0" ||
           ddown006.SelectedValue == "0" || txt002.Text == "" || txt005.Text.Trim() == "" || ddown009.SelectedValue == "")
        {
            if (ddown001.SelectedValue == "0")
            { ddown001.BackColor = colorCampoObligatorio; }
            else { ddown001.BackColor = System.Drawing.Color.White; }

            if (txt0015.Text == "")
            { txt0015.BackColor = colorCampoObligatorio; }
            else { txt0015.BackColor = System.Drawing.Color.White; }

            if (ddown004.SelectedValue == "0")
            { ddown004.BackColor = colorCampoObligatorio; }
            else { ddown004.BackColor = System.Drawing.Color.White; }

            if (ddown009.SelectedValue == "0" || ddown009.SelectedValue == "")
            { ddown009.BackColor = colorCampoObligatorio; }
            else { ddown009.BackColor = System.Drawing.Color.White; }

            if (ddown005.SelectedValue == "0")
            { ddown005.BackColor = colorCampoObligatorio; }
            else { ddown005.BackColor = System.Drawing.Color.White; }

            if (ddown006.SelectedValue == "0")
            { ddown006.BackColor = colorCampoObligatorio; }
            else { ddown006.BackColor = System.Drawing.Color.White; }

            if (txt002.Text == "")
            { txt002.BackColor = colorCampoObligatorio; }
            else { txt002.BackColor = System.Drawing.Color.White; }

            if (txt005.Text.Trim() == "")
            { txt005.BackColor = colorCampoObligatorio; }
            else { txt005.BackColor = colorCampoObligatorio; }
            alertW.Visible = true;
            lblMsgWarning.Visible = true;
        }
        else
        {
            if (txt007.Text.Trim() == "")
            { txt007.Text = "0"; }

            if (txt008.Text.Trim() == "")
            { txt008.Text = "0"; }

            if (txt009.Text.Trim() == "")
            { txt009.Text = "0"; }

            if (txt0010.Text.Trim() == "")
            { txt0010.Text = "0"; }

            if (txt0011.Text.Trim() == "")
            { txt0011.Text = "0"; }

            if (txt0012.Text.Trim() == "")
            { txt0012.Text = "0"; }

            if (txt0013.Text.Trim() == "")
            { txt0013.Text = "0"; }

            if (txt0014.Text.Trim() == "")
            { txt0014.Text = "0"; }

            int CodInstitucion = Convert.ToInt32(ddown001.SelectedValue);
            String Nombre = txt0015.Text.ToUpper();
            String Direccion = txt002.Text.ToUpper();
            int CodComuna = Convert.ToInt32(ddown009.SelectedValue);
            String Fono = txt005.Text.ToUpper();
            String Fax = txt007.Text.ToUpper();
            int CodPostal = Convert.ToInt32(txt008.Text);
            int TipoInmueble = Convert.ToInt32(ddown005.SelectedValue);
            int CodSituacionLegal = Convert.ToInt32(ddown006.SelectedValue);
            int mconstruidos = Convert.ToInt32(txt009.Text);
            int mtotales = Convert.ToInt32(txt0010.Text);
            int ndormitorios = Convert.ToInt32(txt0011.Text);
            int capacidadninos = Convert.ToInt32(txt0012.Text);
            int nbancos = Convert.ToInt32(txt0013.Text);
            int npisos = Convert.ToInt32(txt0014.Text);
            String Averdes = ddown007.SelectedValue;

            insert_instproy insup = new insert_instproy();
            int retorno = insup.Insert_Update_Inmueble(CodInstitucion, ICodInmueble, -1, Convert.ToInt32(Session["IdUsuario"]), CodSituacionLegal, CodComuna
                , TipoInmueble, Nombre, Direccion, Fono, Fax, CodPostal, mconstruidos, mtotales, ndormitorios, capacidadninos, nbancos,
                npisos, Averdes, "V");

            if (retorno == 0)
            {
                string cadena = string.Empty;
                cadena = @"alert('Grabacion Exitosa')";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);
            }

            WebImageButton1.Visible = true;
            WebImageButton4.Visible = false;
            validatescurity();

            txt0015.BackColor = System.Drawing.Color.White;
            ddown004.BackColor = System.Drawing.Color.White;
            ddown009.BackColor = System.Drawing.Color.White;
            ddown005.BackColor = System.Drawing.Color.White;
            ddown006.BackColor = System.Drawing.Color.White;
            txt002.BackColor = System.Drawing.Color.White;
            txt005.BackColor = System.Drawing.Color.White;
            ddown001.BackColor = System.Drawing.Color.White;

            //Response.Write("<script>alert('Datos Registrados Exitosamente');</script>");

            funcion_limpiar();
            
            //limpiarForm();
            lblMsgSuccess.Visible = true;
            alertS.Visible = true;
            
        }
    
    }
    //protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    //{
    //    string etiqueta = lbl001.Text;
    //    string cadena = string.Empty;

    //    cadena = @"window.open(this.Page, 'bsc_institucion.aspx?param001="+etiqueta+"&param002=SI', 'Buscador', false, true, '770', '420', false, false, true)";
    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);
    //}
    private void clean_Txt(TextBox Txt)
    {
        Txt.BackColor = System.Drawing.Color.Empty;
        Txt.Text = "";
    }

    private void clean_Ddl(DropDownList Ddl)
    {
        Ddl.SelectedIndex = 0;
        Ddl.BackColor = System.Drawing.Color.Empty;
    }

    private void clean_Chk(CheckBox Chk)
    {
        Chk.Checked = false;
        Chk.BackColor = System.Drawing.Color.Empty;
    }
    private void funcion_limpiar()
    {
        clean_Txt(txt0015);
        clean_Txt(txt002);
        clean_Txt(txt005);
        clean_Txt(txt007);
        clean_Txt(txt008);
        clean_Txt(txt009);
        clean_Txt(txt0010);
        clean_Txt(txt0011);
        clean_Txt(txt0012);
        clean_Txt(txt0013);
        clean_Txt(txt0014);

        clean_Ddl(ddown007);
        clean_Ddl(ddown001);
        clean_Ddl(ddown004);
        clean_Ddl(ddown009);
        clean_Ddl(ddown005);
        clean_Ddl(ddown006);
        clean_Ddl(ddown007);
        ddown001.Enabled = true;

    }




    //protected void imb001_Click(object sender, EventArgs e)
    //{
    //    string etiqueta = lbl001.Text;
    //    string cadena = string.Empty;

    //    cadena = @"window.open(this.Page, 'bsc_institucion.aspx?param001=" + etiqueta + "&codinst=" + ddown001.SelectedValue + "', 'Buscador', false, true, '770', '420', false, false, true)";
    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Buscador", cadena, true);
    //}
    protected void WebImageButton4_Click(object sender, EventArgs e)
    {
        funcion_guardar();
    }
    protected void WebImageButton1_Click(object sender, EventArgs e)
    {
        funcion_guardar();
    }
    protected void WebImageButton2_Click(object sender, EventArgs e)
    {
        funcion_limpiar();
    }
    protected void WebImageButton3_Click(object sender, EventArgs e)
    {
        Response.Redirect("index_instituciones.aspx");
    }

    public void limpiarForm()
    {
        Response.Redirect("reg_inmuebles.aspx");
    }
}
