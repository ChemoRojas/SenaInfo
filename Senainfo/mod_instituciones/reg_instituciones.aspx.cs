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


public partial class mod_institucion_reg_instituciones2 : System.Web.UI.Page
{
    public int vCodPaso
    {
        get { return (int)Session["vCodPaso"]; }
        set { Session["vCodPaso"] = value; }
    }
    public int vCodInst
    {
        get { return (int)Session["vCodInst"]; }
        set { Session["vCodInst"] = value; }
    }
    public int actual
    {
        get { return (int)Session["actual"]; }
        set { Session["actual"] = value; }
    }

    public string rutInstitucion { get; set; }

    public string rutRepresentanteLegal { get; set; }


    protected void Page_Load(object sender, EventArgs e)
    {
        //A1.HRef = "bsc_institucion.aspx?param001=" + lbl001.Text + "&dir=reg_instituciones.aspx";
        //A2.HRef = "bsc_institucion.aspx?param001=" + lbl001.Text + "&dir=reg_instituciones.aspx";

        rutInstitucion = txtRutInstitucion.Text;
        rutRepresentanteLegal = txtRutRepLegal.Text;

        if (!IsPostBack)
        {
            if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
            {
                Response.Redirect("~/logout.aspx");
            }
            else
            {
                if (!window.existetoken("200E217F-71E6-4DBB-95EE-816A86198D58"))
                {
                    Response.Redirect("~/logout.aspx");
                }

                // JOVM - 05/01/2015
                //wdc002.Value = DateTime.Now;
                txtFecIngreso.Text = DateTime.Today.ToString();
                txtFecIngreso.Text=txtFecIngreso.Text.Remove(11).Trim();

                

                actual = 0;
                //  getinstituciones();
                getregion();
                getcomuna();
                getareaespecializacion();
                getsistemaadm();
                ddown0011.SelectedValue = "V";

                if (Request.QueryString["sw"] != null)
                {
                    if (Request.QueryString["sw"] == "1")
                    {
                        nuevoCodigo.Attributes.Add("disabled", "disabled");
                        gettipoinstitucion(0);
                        Get_Resultado_Busqueda(vCodPaso);
                    }
                }
                else
                {
                    gettipoinstitucion(1);

                }



                validatescurity(); //LO ULTIMO DEL LOAD
            }
        }

    }

    private void validatescurity()
    {
        //D0001462-4D7E-4579-B871-D568661FD5E9 1.1_INGRESAR
        if (!window.existetoken("D0001462-4D7E-4579-B871-D568661FD5E9"))
        {
            btnGrabar.Visible = false;
            btnLimpiar_NEW.Visible = false;
            //block();

        }
        //0DD7623B-A889-4BC3-8AE0-3E17156BF488 1.1_MODIFICAR
        if (!window.existetoken("0DD7623B-A889-4BC3-8AE0-3E17156BF488"))
        {
            this.Form.FindControl("btnActualizar").Visible = false;
            btnLimpiar_NEW.Visible = false;
            //block();

        }
        //37F4E811-1E41-4A77-A53B-D53A1D48EB5A 1.1_MODIFICAR_ADMINST
        if (window.existetoken("37F4E811-1E41-4A77-A53B-D53A1D48EB5A"))
        {
          
            block();
            txt004.ReadOnly = false;
            txtRutRepLegal.ReadOnly = false;
            txt006.ReadOnly = false;
            ddown002.Enabled = true;
            ddown003.Enabled = true;
            txtCodigoPostal.ReadOnly = false;
            txtTelefono.ReadOnly = false;
            txtFax.ReadOnly = false;
            txt0010.ReadOnly = false;
            chk001.Enabled = true;
            //txt0017.ReadOnly = false;
            txtMiembrosDirectorio.ReadOnly = false;
            //txt0022.ReadOnly = false;
            txtTrabajosEncargados.ReadOnly = false;
            txt0025.ReadOnly = false;
            //txt0028.ReadOnly = false;
            txtDia.ReadOnly = false;
            ddown0010.Enabled = true;
            txt0026.ReadOnly = false;
            txt0027.ReadOnly = false;
            
        
        }
     }

    private void block()
    {
        for (int j = 0; j < this.Controls.Count; j++)
        {
            for (int i = 0; i < this.Controls[j].Controls.Count; i++)
            {
                try
                {
                    ((TextBox)this.Controls[j].Controls[i]).ReadOnly = true;
                }
                catch { }
                try
                {
                    ((DropDownList)this.Controls[j].Controls[i]).Enabled = false;
                }
                catch { }

                try
                {
                    //((TextBox)this.Controls[j].Controls[i]).ReadOnly = true;
                }
                catch { }
                try
                {
                    //((TextBox)this.Controls[j].Controls[i]).ReadOnly = true;
                }
                catch { }


            }
        }
       
    }
    private void codinstitucion()
    {
        int CodValor = 0;
        institucioncoll icoll = new institucioncoll();
        int CodInst = icoll.GeneraCodProy(CodValor);
        txt0029.Text = Convert.ToString(CodInst);
        this.Form.FindControl("pnl001").Visible = false;
        btnGrabar.Visible = true;
    }

    private void getregion()
    {


        parcoll par = new parcoll();
        DataView dv6 = new DataView(par.GetparRegion());
        ddown002.DataSource = dv6;
        ddown002.DataTextField = "Descripcion";
        ddown002.DataValueField = "CodRegion";
        dv6.Sort = "CodRegion";
        ddown002.DataBind();


    }
    private void getcomuna()
    {
        //if (Convert.ToInt32(ddown002.SelectedValue) > 0)
        //{

            parcoll par = new parcoll();
            DataView dv6 = new DataView(par.GetparComunas(ddown002.SelectedValue));
            ddown003.Items.Clear();
            ddown003.DataSource = dv6;
            ddown003.DataTextField = "Descripcion";
            ddown003.DataValueField = "CodComuna";
            dv6.Sort = "Descripcion";
            ddown003.DataBind();


        //}
        //else
        //{
        //    ddown003.Items.Clear();
        //}
    }
    private void gettipoinstitucion(int sem)
    {


        institucioncoll par = new institucioncoll();
        DataView dv6 = new DataView(par.GetparTipoInstitucion());
        if (sem == 1)
        {
            dv6.RowFilter = "IndVigencia ='V'";
        }
        else
        {

            dv6.RowFilter = "IndVigencia LIKE '%'";
        }
        dd0012.DataSource = dv6;
        dd0012.DataTextField = "Descripcion";
        dd0012.DataValueField = "TipoInstitucion";
        dv6.Sort = "TipoInstitucion";
        dd0012.DataBind();


    }
    private void getareaespecializacion()
    {


        parcoll par = new parcoll();
        DataView dv6 = new DataView(par.GetparAreaEspecializacion());
        ddown005.DataSource = dv6;
        ddown005.DataTextField = "Descripcion";
        ddown005.DataValueField = "CodAreaEspecializacion";
        dv6.Sort = "CodAreaEspecializacion";
        ddown005.DataBind();


    }
    private void getsistemaadm()
    {


        parcoll par = new parcoll();
        DataView dv6 = new DataView(par.GetparSistemaAdministrativo());
        ddown007.DataSource = dv6;
        ddown007.DataTextField = "Descripcion";
        ddown007.DataValueField = "codSistemaAdministrativo";
        dv6.Sort = "codSistemaAdministrativo";
        ddown007.DataBind();


    }
    protected void ddown001_SelectedIndexChanged(object sender, EventArgs e)
    {
        getcomuna();
    }
    protected void ddown008_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        string etiqueta = lbl001.Text;
        Boolean yes = Convert.ToBoolean(1);
        string cadena = string.Empty;

        cadena = @"window.open(this.Page, 'bsc_institucion.aspx?param001=" + etiqueta + "', 'Buscador', false, false, '500', '650', false, false, true)";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);
    }

    public void Get_Resultado_Busqueda(int codInstitucion)
    {
        Conexiones con = new Conexiones();
        actual = 1;
        ddown0011.Enabled = true;
        string sParametrosConsulta = "Select CodInstitucion,TipoInstitucion,codSistemaAdministrativo,CodComuna,RutInstitucion,Nombre,NombreCorto,Direccion,Telefono,Mail,Fax,CodigoPostal,RepresentanteLegal," +
                            "RutRepresentante,PersonaContacto,FechaAniversario,NombrePrimeraAutoridad," +
                            "CargoPrimeraAutoridad,NumeroPersonalidadJuridica,ModoInstitucion,DocumentoReconoce,NumeroDocumento," +
                            "FechaDocumento,IndVigencia,Personeria,RutInterventor,IdAdministrador,FechaActualizacion," +
                            "IdUsuarioActualizacion,ObjetoSocial,TipoReconocimiento,Vigencia,CodAreaEspecializacion," +
                            "Directorio,MiembrosDirectorio,AntecedentesFinancieros,MarcoLegal,ObjetoTransferencia," +
                            "TrabajosEncargados,OrganismoContralor,ResultadoEvaluacion,CertificadoAntecedentes,FechaIngresoAlRegistro," +
                            "DatosConstitucion From Instituciones " +
                            "Where CodInstitucion=" + codInstitucion;

        DbDataReader datareader = null;
        //Database db = new Database(objconn);
        //db.Execute(sParametrosConsulta, out datareader);
        con.ejecutar(sParametrosConsulta, out datareader);
        while (datareader.Read())
        {
            try
            {
                this.Form.FindControl("btnActualizar").Visible = true;
                btnGrabar.Visible = false;

                txt001.Text = (String)datareader["Nombre"].ToString().Trim();
                txt0029.Text = Convert.ToString((int)datareader["CodInstitucion"]).Trim();
                dd0012.SelectedValue = Convert.ToString((int)datareader["TipoInstitucion"]).Trim();
                ddown007.SelectedValue = Convert.ToString((int)datareader["codSistemaAdministrativo"]).Trim();
                //dd0012.SelectedValue = Convert.ToString((int)datareader["codSistemaAdministrativo"]);
                //TipoReconocimiento
                parcoll par = new parcoll();
                int codRegion = par.Getregionxcomuna((int)datareader["CodComuna"]);
                ddown002.SelectedValue = Convert.ToString(codRegion);
                getcomuna();
                ddown003.SelectedValue = Convert.ToString((int)datareader["CodComuna"]);
                
                // JOVM - 30/12/2014
                //txt002.Text = (String)datareader["RutInstitucion"];
                txtRutInstitucion.Text = (String)datareader["RutInstitucion"].ToString().Trim();

                // ddown001.SelectedValue = Convert.ToString((int)datareader["CodInstitucion"]);
                txt003.Text = (String)datareader["NombreCorto"].ToString().Trim();
                txt006.Text = (String)datareader["Direccion"].ToString().Trim();
                // JOVM - 30/12/2014
                //txt007.Text = (String)datareader["Telefono"];
                txtTelefono.Text = (String)datareader["Telefono"].ToString().Trim(); ;

                txt0010.Text = (String)datareader["Mail"].ToString().Trim();
                //txt0015.Text = (String)datareader["NumeroDocumento"];
                txtDoctoReconoce.Text = (String)datareader["NumeroDocumento"].ToString().Trim();
                
                // JOVM - 30/12/2014
                //txt008.Text = (String)datareader["Fax"];
                //txt009.Text = Convert.ToString((int)datareader["CodigoPostal"]);
                txtFax.Text = (String)datareader["Fax"].ToString().Trim();
                txtCodigoPostal.Text = Convert.ToString((int)datareader["CodigoPostal"]).Trim();

                                
                txt004.Text = (String)datareader["RepresentanteLegal"].ToString().Trim();

                // JOVM - 30/12/2014
                //txt005.Text = (String)datareader["RutRepresentante"];
                txtRutRepLegal.Text = (String)datareader["RutRepresentante"].ToString().Trim();

                txt0025.Text = (String)datareader["PersonaContacto"].ToString().Trim();
                string fAniversario = (String)datareader["FechaAniversario"].ToString().Trim();

                if (fAniversario != "00" && fAniversario != "0")
                {
                    // JOVM - 30/12/2014
                    //txt0028.Text = fAniversario.Substring(2, 2);
                    txtDia.Text = fAniversario.Substring(2, 2).Trim();

                    if (fAniversario.Substring(0, 1) == "0")
                    {
                        ddown0010.SelectedValue = fAniversario.Substring(1, 1);
                    }
                    else
                    {
                        ddown0010.SelectedValue = fAniversario.Substring(0, 2);
                    }
                }
                txt0026.Text = (String)datareader["NombrePrimeraAutoridad"].ToString().Trim();
                txt0027.Text = (String)datareader["CargoPrimeraAutoridad"].ToString().Trim();
                //txt0012.Text = (String)datareader["NumeroPersonalidadJuridica"];
                txtDecreto.Text = (String)datareader["NumeroPersonalidadJuridica"].ToString().Trim();
                ddown006.SelectedValue = (String)datareader["ModoInstitucion"];
                ddown008.SelectedValue = (String)datareader["DocumentoReconoce"];
                if (Convert.ToString((DateTime)datareader["FechaDocumento"]) == "01/01/1900 0:00:00")
                {
                    // JOVM - 30/12/2014
                    //wdc001.Value = null;
                    txtFecDocReconoce.Text= null;
                }
                else
                {
                    // JOVM - 30/12/2014
                    //txtFecDocReconoce.Text = (String)datareader["FechaDocumento"];
                    txtFecDocReconoce.Text = Convert.ToString((DateTime)datareader["FechaDocumento"]).Substring(0, 10);
                }


                // JOVM - 30/12/2014
                //wdc002.Value = Convert.ToString((DateTime)datareader["FechaIngresoAlRegistro"]);
                txtFecIngreso.Text = Convert.ToString((DateTime)datareader["FechaIngresoAlRegistro"]).Substring(0, 10);

                ddown0011.SelectedValue = (String)datareader["IndVigencia"];
                //txt0016.Text = (String)datareader["Personeria"];
                txtPersoneria.Text = (String)datareader["Personeria"].ToString().Trim();
                //dr[24] = (String)datareader["RutInterventor"];
                //dr[25] = (int)datareader["IdAdministrador"];
                //dr[26] = (DateTime)datareader["FechaActualizacion"];
                //dr[27] = (int)datareader["IdUsuarioActualizacion"];
                //txt0013.Text = (String)datareader["ObjetoSocial"];
                txtObjetoSocial.Text = (String)datareader["ObjetoSocial"].ToString().Trim();
                //dr[29] = (int)datareader["TipoReconocimiento"];
                //txt0014.Text = (String)datareader["Vigencia"];
                txtVigencia.Text = (String)datareader["Vigencia"].ToString().ToString();
                ddown005.SelectedValue = Convert.ToString((int)datareader["CodAreaEspecializacion"]);
                if ((Boolean)datareader["Directorio"] == true)
                {
                    chk001.Checked = true;
                }
                else
                {
                    chk001.Checked = false;
                }
                //txt0017.Text = (String)datareader["MiembrosDirectorio"];
                txtMiembrosDirectorio.Text = (String)datareader["MiembrosDirectorio"].ToString().Trim();
                //txt0019.Text = (String)datareader["AntecedentesFinancieros"];
                txtAntecedFinancieros.Text = (String)datareader["AntecedentesFinancieros"].ToString().Trim();
                //txt0020.Text = (String)datareader["MarcoLegal"];
                txtMarcoLegal.Text = (String)datareader["MarcoLegal"].ToString().Trim();
                //txt0021.Text = (String)datareader["ObjetoTransferencia"];
                txtObjTransferencia.Text = (String)datareader["ObjetoTransferencia"].ToString().Trim();
                //txt0022.Text = (String)datareader["TrabajosEncargados"];
                txtTrabajosEncargados.Text = (String)datareader["TrabajosEncargados"].ToString().Trim();
                //txt0023.Text = (String)datareader["OrganismoContralor"];
                txtOrganismoContralor.Text = (String)datareader["OrganismoContralor"].ToString().Trim();
                //txt0024.Text = (String)datareader["ResultadoEvaluacion"];
                txtResultEvaluacion.Text = (String)datareader["ResultadoEvaluacion"].ToString().Trim();
                //txt0018.Text = (String)datareader["CertificadoAntecedentes"];
                txtCertifAntecedentes.Text = (String)datareader["CertificadoAntecedentes"].ToString().Trim();
                //txt0011.Text = (String)datareader["DatosConstitucion"];
                // JOVM - 12/01/2015
                txtDatosConstitucion.Text = (String)datareader["DatosConstitucion"].ToString().Trim();

                //((ImageButton)Form.FindControl("imb_transferencias")).Enabled = true;
                ((LinkButton)Form.FindControl("lbn_buscar_transferencia")).Enabled = true;
                lbn_buscar_transferencia.Attributes.Remove("disabled");
                



            }
            catch { }
        }
        //db.Close();

       
        //txt0029.ReadOnly = true;

        //wdc002.Enabled = false;

    }




    
    private void funciongrabar()
    {
        //ddown0011.Enabled = false;

        // JOVM - 30/12/2014
        lblMsgSuccess.Visible = false;
        alertS.Visible = false;
        alertW.Visible = false;
        lblMsgWarning.Visible = false;
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis
        if (txtRutInstitucion.Text.Trim().Replace(".","") == "" || txt001.Text == "" || txt004.Text == "" ||
            txtRutRepLegal.Text.Trim() == "" || txt006.Text.Trim() == "" || ddown002.SelectedValue == "-2" ||
            ddown003.SelectedValue == "0" || ddown003.SelectedValue == "" || txtDecreto.Text == "" ||
            dd0012.SelectedValue == "0" || ddown005.SelectedValue == "0" || ddown007.SelectedValue == "0" ||
            ddown008.SelectedValue == "0" || ddown006.SelectedValue== "0" || txtDoctoReconoce.Text == "" || txtFecDocReconoce.Text.Trim() == "" || txt0029.Text == "" || (ddown0011.Enabled && ddown0011.SelectedIndex == 0))
        {
            if (txtRutInstitucion.Text.Trim().Replace(".","") == "") { 
                txtRutInstitucion.BackColor = colorCampoObligatorio; } 
            else { txtRutInstitucion.BackColor = System.Drawing.Color.Empty; }

            if (txt001.Text == "") { 
                txt001.BackColor = colorCampoObligatorio; } 
            else { txt001.BackColor = System.Drawing.Color.Empty; }

            if (txt004.Text == "") { 
                txt004.BackColor = colorCampoObligatorio; } 
            else { txt004.BackColor = System.Drawing.Color.Empty; }

            if (txtRutRepLegal.Text.Trim() == "") { 
                txtRutRepLegal.BackColor = colorCampoObligatorio; } 
            else { txtRutRepLegal.BackColor = System.Drawing.Color.Empty; }

            if (txt006.Text.Trim() == "") { 
                txt006.BackColor = colorCampoObligatorio; } 
            else { txt006.BackColor = System.Drawing.Color.Empty; }

            if (ddown002.SelectedValue == "-2") { 
                ddown002.BackColor = colorCampoObligatorio; } 
            else { ddown002.BackColor = System.Drawing.Color.Empty; }

            if (ddown003.SelectedValue == "0") { 
                ddown003.BackColor = colorCampoObligatorio; } 
            //else { ddown003.BackColor = System.Drawing.Color.Empty; }

            if (ddown003.SelectedValue == "") { 
                ddown003.BackColor = colorCampoObligatorio; } 
            //else { ddown003.BackColor = System.Drawing.Color.Empty; }

            if (txtDecreto.Text == "") { 
                txtDecreto.BackColor = colorCampoObligatorio; } 
            else { txtDecreto.BackColor = System.Drawing.Color.Empty; }

            if (dd0012.SelectedValue == "0") { 
                dd0012.BackColor = colorCampoObligatorio; } 
            else { dd0012.BackColor = System.Drawing.Color.Empty; }

            if (ddown005.SelectedValue == "0") { 
                ddown005.BackColor = colorCampoObligatorio; } 
            else { ddown005.BackColor = System.Drawing.Color.Empty; }

            if (ddown007.SelectedValue == "0") { 
                ddown007.BackColor = colorCampoObligatorio; } 
            else { ddown007.BackColor = System.Drawing.Color.Empty; }

            if (ddown008.SelectedValue == "0") { 
                ddown008.BackColor = colorCampoObligatorio; } 
            else { ddown008.BackColor = System.Drawing.Color.Empty; }

            if (txt0010.Text == "")
            {
                txt0010.BackColor = colorCampoObligatorio;
            }
            else { ddown008.BackColor = System.Drawing.Color.Empty; }

            if (ddown006.SelectedValue == "0")
            { 
                ddown006.BackColor = colorCampoObligatorio; } 
            else { ddown006.BackColor = System.Drawing.Color.Empty; }

            if (txtDoctoReconoce.Text == "") { 
                txtDoctoReconoce.BackColor = colorCampoObligatorio; } 
            else { txtDoctoReconoce.BackColor = System.Drawing.Color.Empty; }

            if (txtFecDocReconoce.Text.Trim() == "") { 
                txtFecDocReconoce.BackColor = colorCampoObligatorio; } 
            else { txtFecDocReconoce.BackColor = System.Drawing.Color.Empty; }

            if (txt0029.Text == "") { 
                txt0029.BackColor = colorCampoObligatorio; } 
            else { txt0029.BackColor = System.Drawing.Color.Empty; }

            if (ddown0011.SelectedIndex == 0) {
                ddown0011.BackColor = colorCampoObligatorio;
                ddown0011.Focus();
            }
            else
            {
                ddown0011.BackColor = System.Drawing.Color.Empty;
            }
            alertW.Visible = true;
            lblMsgWarning.Visible = true;

            //window.alert(this, "Faltan datos obligatorios para realizar el registro.");
            traerRut();
        }
        else
        {
            int codinst = Convert.ToInt32(txt0029.Text);
            int TipoInstitucion = Convert.ToInt32(dd0012.SelectedValue);
            int CodSistemaAdm = Convert.ToInt32(ddown007.SelectedValue);
            int CodComuna = Convert.ToInt32(ddown003.SelectedValue);
            int CodRegion = Convert.ToInt32(ddown002.SelectedValue);
            string RutInstitucion = txtRutInstitucion.Text.Trim().Replace(".", "");
            string Nombre = txt001.Text.ToUpper();
            string NombreCorto = "";
            if (txt003.Text != "") { NombreCorto = txt003.Text.ToUpper(); }
            string Direccion = txt006.Text.ToUpper();
            string Fono = "";
            if (txtTelefono.Text.Trim() != "") { Fono = txtTelefono.Text; }
            string Mail = "";
            if (txt0010.Text != "") { Mail = txt0010.Text.ToUpper(); }
            string Fax = "";
            if (txtFax.Text.Trim() != "") { Fax = txtFax.Text; }
            int CodPostal = 0;
            if (txtCodigoPostal.Text.Trim() != "") { CodPostal = Convert.ToInt32(txtCodigoPostal.Text); }
            string RepresentanteLegal = txt004.Text.ToUpper();
            string RutRepresentante = txtRutRepLegal.Text.Trim().Replace(".", "");
            string PersonaContacto = "";
            if (txt0025.Text != "") { PersonaContacto = txt0025.Text.ToUpper(); }

            
            string diaA;
            if (txtDia.Text.Trim().Length == 1)
            {
                diaA = "0" + txtDia.Text;
            }
            else
            {
                diaA = txtDia.Text;
            }
            string mesA;
            if (ddown0010.SelectedValue.Trim().Length == 1)
            {
                mesA = "0" + ddown0010.SelectedValue;
            }
            else
            {
                mesA = ddown0010.SelectedValue;
            }



            string faniversario = mesA + diaA;
            string NombrePrimeraAutoridad = "";
            if (txt0026.Text != "") { NombrePrimeraAutoridad = txt0026.Text.ToUpper(); }
            string CargoPrimeraAutoridad = "";
            if (txt0027.Text != "") { CargoPrimeraAutoridad = txt0027.Text.ToUpper(); }
            string NumeroPersonalidadJuridica = txtDecreto.Text.ToUpper();
            string ModoInstitucion = ddown006.SelectedValue;
            string DocumentoReconoce = ddown008.SelectedValue;
            DateTime FechaDocumento = Convert.ToDateTime("01-01-1900");

            // JOVM - 30/12/2014
            if (txtFecDocReconoce.Text != "")
            {
                FechaDocumento = Convert.ToDateTime(txtFecDocReconoce.Text);
            }
            string IndVigencia = ddown0011.SelectedValue;
            string Personeria = "";
            if (txtPersoneria.Text != "") { Personeria = txtPersoneria.Text.ToUpper(); }
            //dr[24] = (String)datareader["RutInterventor"];
            //dr[25] = (int)datareader["IdAdministrador"];
            //dr[26] = (DateTime)datareader["FechaActualizacion"];
            //dr[27] = (int)datareader["IdUsuarioActualizacion"];
            string ObjetoSocial = "";
            if (txtObjetoSocial.Text != "") { ObjetoSocial = txtObjetoSocial.Text.ToUpper(); }
            int TipoReconocimiento = Convert.ToInt32(ddown007.SelectedValue);
            string Vigencia = "";
            if (txtVigencia.Text != "") { Vigencia = txtVigencia.Text.ToUpper(); }
            int CodAreaEspecializacion = Convert.ToInt32(ddown005.SelectedValue);
            int Directorio = 0;
            if (chk001.Checked == true)
            {
                Directorio = 1;
            }
            string MiembrosDirectorio = "";
            if (txtMiembrosDirectorio.Text != "") { MiembrosDirectorio = txtMiembrosDirectorio.Text.ToUpper(); }
            string AntecedentesFinancieros = "";
            if (txtAntecedFinancieros.Text != "") { AntecedentesFinancieros = txtAntecedFinancieros.Text.ToUpper(); }
            string MarcoLegal = "";
            if (txtMarcoLegal.Text != "") { MarcoLegal = txtMarcoLegal.Text.ToUpper(); }
            string ObjetoTransferencia = "";
            if (txtObjTransferencia.Text != "") { ObjetoTransferencia = txtObjTransferencia.Text.ToUpper(); }
            string TrabajosEncargados = "";
            if (txtTrabajosEncargados.Text != "") { TrabajosEncargados = txtTrabajosEncargados.Text.ToUpper(); }
            string OrganismoContralor = "";
            if (txtOrganismoContralor.Text != "") { OrganismoContralor = txtOrganismoContralor.Text.ToUpper(); }
            string ResultadoEvaluacion = "";
            if (txtResultEvaluacion.Text != "") { ResultadoEvaluacion = txtResultEvaluacion.Text.ToUpper(); }
            string CertificadoAntecedentes = "";
            if (txtCertifAntecedentes.Text != "") { CertificadoAntecedentes = txtCertifAntecedentes.Text.ToUpper(); }
            string DatosConstitucion = "";
            
            // JOVM - 12/01/2015
            //if (txt0011.Text != "") { DatosConstitucion = txt0011.Text.ToUpper(); }
            if (txtDatosConstitucion.Text != "") { DatosConstitucion = txtDatosConstitucion.Text.ToUpper(); }

            DateTime FechaIngresoRegistro;
            if (actual == 0)
            {
                FechaIngresoRegistro = DateTime.Now;
            }
            else
            {
                // JOVM - 05/01/2015
                //FechaIngresoRegistro = Convert.ToDateTime(wdc002.Text);
                FechaIngresoRegistro = Convert.ToDateTime(txtFecIngreso.Text);
            }
            
            string numerodcto = txtDoctoReconoce.Text.ToUpper();
            //btnGrabar.Visible = true;
            //this.Form.FindControl("btnActualizar").Visible = false;
            validatescurity();

            insert_instproy insup = new insert_instproy();
            int retorno = insup.Insert_Update_Instituciones( codinst, TipoInstitucion, CodSistemaAdm, CodComuna,
                RutInstitucion, Nombre, NombreCorto, Direccion, Fono, Mail, Fax, CodPostal, RepresentanteLegal, RutRepresentante, PersonaContacto, faniversario,
                NombrePrimeraAutoridad, CargoPrimeraAutoridad, NumeroPersonalidadJuridica, ModoInstitucion, DocumentoReconoce, FechaIngresoRegistro,
                numerodcto, FechaDocumento, ddown0011.SelectedValue, Personeria, "0", "0", 0, DateTime.Now, Convert.ToInt32(Session["IdUsuario"]) /*USR*/, ObjetoSocial, TipoReconocimiento, Vigencia, CodAreaEspecializacion, Directorio,
                MiembrosDirectorio, AntecedentesFinancieros, MarcoLegal, ObjetoTransferencia, TrabajosEncargados, OrganismoContralor, ResultadoEvaluacion,
                CertificadoAntecedentes, DatosConstitucion);

                // JOVM - 30/12/2014
                txtRutInstitucion.BackColor = System.Drawing.Color.Empty;
                txt001.BackColor = System.Drawing.Color.Empty;
                txt004.BackColor = System.Drawing.Color.Empty;
                txtRutRepLegal.BackColor = System.Drawing.Color.Empty;
                txt006.BackColor = System.Drawing.Color.Empty;
                ddown002.BackColor = System.Drawing.Color.Empty;
                ddown003.BackColor = System.Drawing.Color.Empty;
                ddown006.BackColor = System.Drawing.Color.Empty;
                txtDecreto.BackColor = System.Drawing.Color.Empty;
                dd0012.BackColor = System.Drawing.Color.Empty;
                ddown005.BackColor = System.Drawing.Color.Empty;
                ddown007.BackColor = System.Drawing.Color.Empty;
                ddown008.BackColor = System.Drawing.Color.Empty;
                txtDoctoReconoce.BackColor = System.Drawing.Color.Empty;
                txtFecDocReconoce.BackColor = System.Drawing.Color.Empty;
                txt0029.BackColor = System.Drawing.Color.Empty;
                ddown0011.BackColor = System.Drawing.Color.Empty;
                //funcion_limpiar();
                ddown0011.SelectedValue = "V";
                ddown0011.Enabled = false;

                if (btnActualizar.Visible == true)
                {
                    //Response.Write("<script language='javascript'>alert(' ');</script>");
                    lblMsgSuccess.Text = "Actualización realizada satisfactoriamente.";
                }
                if (btnActualizar.Visible == false)
                {
                    //Response.Write("<script language='javascript'>alert('Ingreso realizado satisfactoriamente. ');</script>");
                    lblMsgSuccess.Text = "Ingreso realizado satisfactoriamente.";
                    
                    
                }
                lblMsgSuccess.Visible = true;
                alertS.Visible = true;
                
                funcion_limpiar();
        }

        
        


        //Response.Redirect("~/mod_instituciones/reg_instituciones.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        funciongrabar();
    }


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
        
        //((ImageButton)Form.FindControl("imb_transferencias")).Enabled = false;
        ((LinkButton)Form.FindControl("lbn_buscar_transferencia")).Enabled = false;
        lbn_buscar_transferencia.Attributes.Add("disabled","disabled");
        btnGrabar.Visible = false;
        btnActualizar.Visible = false;
        nuevoCodigo.Attributes.Remove("disabled");

        clean_Txt(txt0029);
        clean_Txt(txtRutInstitucion);
        clean_Txt(txt001);
        clean_Txt(txt003);
        clean_Txt(txt004);
        clean_Txt(txtRutRepLegal);
        clean_Txt(txt006);
        clean_Ddl(ddown002);
        clean_Ddl(ddown003);
        clean_Txt(txtCodigoPostal);
        clean_Txt(txtTelefono);
        clean_Txt(txtFax);
        clean_Txt(txt0010);
        clean_Txt(txtDatosConstitucion);
        clean_Txt(txtDecreto);
        clean_Ddl(dd0012);
        clean_Txt(txtObjetoSocial);
        clean_Txt(txtVigencia);
        clean_Ddl(ddown005);
        clean_Ddl(ddown006);
        clean_Ddl(ddown007);
        clean_Ddl(ddown008);
        clean_Txt(txtDoctoReconoce);
        clean_Txt(txtFecDocReconoce);
        clean_Txt(txtFecIngreso);
        clean_Txt(txtPersoneria);
        clean_Chk(chk001);
        clean_Txt(txtMiembrosDirectorio);
        clean_Txt(txtCertifAntecedentes);
        clean_Txt(txtAntecedFinancieros);
        clean_Txt(txtMarcoLegal);
        clean_Txt(txtObjTransferencia);
        clean_Txt(txtTrabajosEncargados);
        clean_Txt(txtOrganismoContralor);
        clean_Txt(txtResultEvaluacion);
        clean_Txt(txt0025);
        clean_Txt(txtDia);
        clean_Ddl(ddown0010);
        clean_Txt(txt0026);
        clean_Txt(txt0027);


        //for (int j = 0; j < this.Controls.Count; j++)
        //{
        //    for (int i = 0; i < this.Controls[j].Controls.Count; i++)
        //    {
        //        try
        //        {
        //            ((TextBox)this.Controls[j].Controls[i]).Text = "";
        //        }
        //        catch { }
        //        try
        //        {
        //            ((DropDownList)this.Controls[j].Controls[i]).SelectedIndex = 0;
        //        }
        //        catch { }
        //        try
        //        {
        //            ((TextBox)this.Controls[j].Controls[i]).Value = "";
        //        }
        //        catch { }
        //    }

        //}

        //for (int j = 0; j < this.Controls.Count; j++)
        //{
        //    for (int i = 0; i < this.Controls[j].Controls.Count; i++)
        //    {
        //        try
        //        {
        //            ((TextBox)this.Controls[j].Controls[i]).ReadOnly = false;
        //        }
        //        catch { }
        //        try
        //        {
        //            ((DropDownList)this.Controls[j].Controls[i]).Enabled = true;
        //        }
        //        catch { }

        //        try
        //        {
        //            ((TextBox)this.Controls[j].Controls[i]).ReadOnly = false;
        //        }
        //        catch { }
        //        try
        //        {
        //            ((TextBox)this.Controls[j].Controls[i]).ReadOnly = false;
        //        }
        //        catch { }


        //    }
        //}

        // JOVM - 30/12/2014
        //txtRutInstitucion.BackColor = System.Drawing.Color.Empty;
        //txt001.BackColor = System.Drawing.Color.Empty;
        //txt004.BackColor = System.Drawing.Color.Empty;
        //txtRutRepLegal.BackColor = System.Drawing.Color.Empty;
        //txt006.BackColor = System.Drawing.Color.Empty;
        //ddown002.BackColor = System.Drawing.Color.Empty;
        //ddown003.BackColor = System.Drawing.Color.Empty;
        //ddown006.BackColor = System.Drawing.Color.Empty;
        //txtDecreto.BackColor = System.Drawing.Color.Empty;
        //dd0012.BackColor = System.Drawing.Color.Empty;
        //ddown005.BackColor = System.Drawing.Color.Empty;
        //ddown007.BackColor = System.Drawing.Color.Empty;
        //ddown008.BackColor = System.Drawing.Color.Empty;
        //txtDoctoReconoce.BackColor = System.Drawing.Color.Empty;
        //txtFecDocReconoce.BackColor = System.Drawing.Color.Empty;
        //txt0029.BackColor = System.Drawing.Color.Empty;
        //this.Form.FindControl("pnl001").Visible = false;
        
        // JOVM - 05/01/2015
        //wdc002.Enabled = true;
        //txtFecIngreso.Enabled = true;

        //txtFecDocReconoce.Text = "";
        //chk001.Checked = false;
        //txt0028.Value = null;
        //txtDia.Text = null;


    }
    protected void txt0029_TextChanged(object sender, EventArgs e)
    {
        string mensaje = "";
        int CodValor = 0;
        if (txt0029.Text.Replace("-","").Trim() == "")
        {
            CodValor = 0;
        }
        else
        {
            CodValor = Convert.ToInt32(txt0029.Text.ToUpper().Replace("-", "").Trim());
            
        }
        if (txt0029.Text != "")
        {
            institucioncoll icoll = new institucioncoll();
            int CodInst = icoll.GeneraCodProy(CodValor);
            if (CodInst == -1)
            {
                mensaje = "Error, el código ingresado ya existe.";
                 this.Form.FindControl("btnMantener").Visible = false;
            }
            else
            {
                mensaje = "Usted ha ingresado un código, <br> Si lo desea el sistema puede sugerirle uno";
                 this.Form.FindControl("btnMantener").Visible = true;
            }
            ((Label)Form.FindControl("lbl003")).Text = mensaje;
            this.Form.FindControl("pnl001").Visible = true;
        }
        else
        {
             this.Form.FindControl("btnMantener").Visible = false;
            this.Form.FindControl("pnl001").Visible = true;
            ((Label)Form.FindControl("lbl003")).Text = "Error, campo vacío";
        }
    }

    //protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    //{
    //    codinstitucion();
    //}

    protected void nuevoCodigo_Click(object sender, EventArgs e)
    {
        if (txt0029.Text == "")
        {
            codinstitucion();
            nuevoCodigo.Attributes.Add("disabled", "disabled");
            traerRut();
        }

    }

    protected void traerRut()
    {
        txtRutInstitucion.Text = rutInstitucion;
        txtRutRepLegal.Text = rutRepresentanteLegal;
    }
    
    //protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    //{
    //    string cadena = string.Empty;

    //    cadena = @"window.open(this.Page, 'Transferencias.aspx?param001="+txt0029.Text+"&param002=" + txt001.Text + "', 'Transferencia', false, false, '350', '250', false, false, true)";
    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "Transferencia", cadena, true);
    //}
    
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
    

    /*-----------------------------------------------------------------------------------------
    // 30/12/2014
    // Juan Valenzuela.
    // Se modifican botones y voids para descartar uso de libreria Infragistics.
    //-----------------------------------------------------------------------------------------*/

    protected void btnBuscar_NEW_Click(object sender, EventArgs e)
    {

    }
    //protected void btnBuscar_NEW_Click(object sender, EventArgs e)
    //{
    //    string etiqueta = lbl001.Text;
    //    Boolean yes = Convert.ToBoolean(1);

    //    string cadena = string.Empty;

    //    cadena = @"window.open(this.Page, 'bsc_institucion.aspx?param001=" + etiqueta + "', 'Buscador', false, false, '770', '420', false, false, true)";
    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "", cadena, true);
    //}
    protected void btnSugerir_NEW_Click(object sender, EventArgs e)
    {
        codinstitucion();
    }
    protected void btnMantener_NEW_Click(object sender, EventArgs e)
    {
        this.Form.FindControl("pnl001").Visible = false;
    }
    protected void btnActualizar_NEW_Click(object sender, EventArgs e)
    {
        funciongrabar();
        
    }
    protected void btnGrabar_NEW_Click(object sender, EventArgs e)
    {
        funciongrabar();
        
    }
    protected void btnLimpiar_NEW_Click(object sender, EventArgs e)
    {
        lbl002.Text = "";
        lbl003.Text = "";
        lbl004.Text = "";
        funcion_limpiar();
    }
    //protected void btnVolver_NEW_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("index_instituciones.aspx");
    //}
    protected void txtRutInstitucion_TextChanged(object sender, EventArgs e)
    {
        ((Label)Form.FindControl("lbl002")).Text = "";

        try
        {
            if ( txtRutInstitucion.Text.Length > 3)
            {
                string rutsinnada = txtRutInstitucion.Text.ToUpper().Replace(".", "").Replace(",", "").Replace("-", "").Trim();
                string digitoingresado = rutsinnada.Substring(rutsinnada.Length - 1, 1);

                string digitocalculado = digitoVerificador(Convert.ToInt32(rutsinnada.ToUpper().Replace("K", "").Substring(0, rutsinnada.Length - 1).Trim()));
                if (digitocalculado.ToUpper() == digitoingresado.ToUpper())
                {
                    this.Form.FindControl("pnl002").Visible = false;
                    string punorut = rutsinnada.ToUpper().Replace("K", "").Substring(0, rutsinnada.Length - 1).Trim();
                    string rcompleto = punorut + "-" + digitocalculado.ToUpper();
                    txtRutInstitucion.Text = rcompleto;
                    institucioncoll icoll = new institucioncoll();
                    DataTable dt = icoll.GetRutInst(rcompleto);

                    if (dt.Rows.Count > 0)
                    {
                        if (Convert.ToString(dt.Rows[0][2]).Trim() == txtRutInstitucion.Text.Trim())
                        {
                            this.Form.FindControl("pnl002").Visible = true;
                            lbl002.Text = "Error, el Rut ingresado ya existe.<br> Corresponde a : " + Convert.ToString(dt.Rows[0][1]);
                        }
                    }
                    if (((Label)Form.FindControl("lbl002")).Text != "")
                    {
                        this.Form.FindControl("pnl002").Visible = true;
                    }
                    else
                    {
                        this.Form.FindControl("pnl002").Visible = false;

                    }


                }
                else
                {
                    ((Label)Form.FindControl("lbl002")).Text = "RUT INGRESADO NO ES VALIDO";
                    this.Form.FindControl("pnl002").Visible = true;
                }
            }
            else
            {
                ((Label)Form.FindControl("lbl002")).Text = "RUT INGRESADO NO ES VALIDO";
                this.Form.FindControl("pnl002").Visible = true;
            }

            if (txtRutInstitucion.Text.Length == 0)
            {
                ((Label)Form.FindControl("lbl002")).Text = "";
                this.Form.FindControl("pnl002").Visible = false;
            }
        }
        catch
        {
            ((Label)Form.FindControl("lbl002")).Text = "RUT INGRESADO NO ES VALIDO";
            this.Form.FindControl("pnl002").Visible = true;
        }



    }
    protected void txtRutRepLegal_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtRutRepLegal.Text.Length > 3)
            {
                string rutsinnada = txtRutRepLegal.Text.Replace(".", "").Replace(",", "").Replace("-", "").Trim();
                string digitoingresado = rutsinnada.Substring(rutsinnada.Length - 1, 1);

                string digitocalculado = digitoVerificador(Convert.ToInt32(rutsinnada.ToUpper().Replace("K", "").Substring(0, rutsinnada.Length - 1)));
                if (digitocalculado.ToUpper() == digitoingresado.ToUpper())
                {
                    this.Form.FindControl("pnl003").Visible = false;
                    string punorut = rutsinnada.ToUpper().Replace("K", "").Substring(0, rutsinnada.Length - 1).Trim();
                    string rcompleto = punorut + "-" + digitocalculado.ToUpper();
                    txtRutRepLegal.Text = rcompleto;
                }
                else
                {
                    ((Label)Form.FindControl("lbl004")).Text = "RUT INGRESADO NO ES VALIDO";
                    this.Form.FindControl("pnl003").Visible = true;
                }
            }
            else
            {
                ((Label)Form.FindControl("lbl004")).Text = "RUT INGRESADO NO ES VALIDO";
                this.Form.FindControl("pnl004").Visible = true;
            }
           
        }
        catch
        {
            ((Label)Form.FindControl("lbl004")).Text = "RUT INGRESADO NO ES VALIDO";
            this.Form.FindControl("pnl003").Visible = true;
        }
    }
    
    protected void txtDia_TextChanged(object sender, EventArgs e)
    {
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis
        if (Convert.ToInt32(txtDia.Text.Trim()) < 1 || Convert.ToInt32(txtDia.Text.Trim()) > 31)
        {
            txtDia.Text = "";
            txtDia.Focus();
            txtDia.BackColor = colorCampoObligatorio;

        }
        else
            txtDia.BackColor = System.Drawing.Color.Empty;
    }

}