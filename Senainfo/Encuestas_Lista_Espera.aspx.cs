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

public partial class Encuestas_Lista_Espera : System.Web.UI.Page
{
    public int intCodProyecto
    {
        get { return (int)Session["intCodProyecto"]; }
        set { Session["intCodProyecto"] = value; }
    }
    public int intCodEncuesta
    {
        get { return (int)Session["intCodEncuesta"]; }
        set { Session["intCodEncuesta"] = value; }
    }
    public int intCodRol
    {
        get { return (int)Session["intCodRol"]; }
        set { Session["intCodRol"] = value; }
    }
    public int intFemenino
    {
        get { return (int)Session["intFemenino"]; }
        set { Session["intFemenino"] = value; }
    }
    public int intMasculino
    {
        get { return (int)Session["intMasculino"]; }
        set { Session["intMasculino"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            EncuestasColl ecoll = new EncuestasColl();
            string[] Arr_Devueltos = new string[4];
            Arr_Devueltos = ecoll.ExisteEncuesta(Arr_Devueltos);
            intCodEncuesta = Convert.ToInt16(Arr_Devueltos[1]);
            
            DataTable dt = ecoll.GetDataEncuestaListaEspera(Convert.ToString(Session["IdUsuario"]), intCodEncuesta);
            if (dt.Rows.Count == 0)
                Response.Redirect("default.aspx");

            txtInstitucion.Text = (string)dt.Rows[0]["NombreInstitucion"];
            txtProyecto.Text = (string)dt.Rows[0]["NombreProyecto"];
            txtModelo.Text = (string)dt.Rows[0]["NombreModeloIntervencion"];
            txtPlazas.Text = (string)dt.Rows[0]["NumeroPlazas"].ToString();
            intCodProyecto = (int)dt.Rows[0]["CodProyecto"];
            lblFechaObligatoria.Text = "ATENCIÓN, a partir del " + Arr_Devueltos[3].Substring(0, 10) + " la encuesta es obligatoria.";
            if (System.DateTime.Now >= Convert.ToDateTime(Arr_Devueltos[3]))
                rbEnOtraOpotunidad.Visible = false;
        }
    }
    //protected void btnContinuar_Click(object sender, EventArgs e)
    //{
    //    if (rbNo.Checked || rbEnOtraOpotunidad.Checked)
    //        btnGuarda_Click(sender, e);

    //    if (rbSi.Checked)
    //    {
    //        pnlDatos.Visible = true;
    //        lblPregunta.Visible = false;
    //        rbNo.Visible = false;
    //        rbSi.Visible = false;
    //        rbEnOtraOpotunidad.Visible = false;
    //        btnContinuar.Visible = false;
    //    }
    //    //if (rbEnOtraOpotunidad.Checked)
    //    //    Response.Redirect("default.aspx");
    //}
    protected void txtFemenino_ValueChange(object sender, EventArgs e)
    {
        //txtTotal.Value = txtFemenino.ValueInt + txtMasculino.ValueInt;
        //txtTribunales.MaxValue = txtTotal.ValueInt;

        //btnGuarda.Visible = txtTotal.ValueInt != 0;
        //txtMasculino.Focus();
    }
    protected void txtMasculino_ValueChange(object sender, EventArgs e)
    {
        txtFemenino_ValueChange(sender, e);
    }
    //protected void btnGuarda_Click(object sender, EventArgs e)
    //{
    //    if (Convert.ToInt32(txtTotal2.Value) < 1 && pnlDatos.Visible) 
    //    {
    //        lblError.Visible = true;

    //        if (Convert.ToInt32(txtFemenino2.Value) == 0)
    //            txtFemenino2.Focus();
    //        else
    //            txtMasculino2.Focus();

    //        return;
    //    }
    //    int intEnOtraOportunidad;
    //    if (rbEnOtraOpotunidad.Checked) intEnOtraOportunidad = 1; else intEnOtraOportunidad = 0;
        
    //    EncuestasColl ecoll = new EncuestasColl();
    //    ecoll.InsertaRespuestaListaEspera(ASP.global_asax.globaconn, Convert.ToInt32(Session["IdUsuario"]), intCodEncuesta, intCodProyecto, Convert.ToInt16(txtFemenino2.Value), Convert.ToInt16(txtMasculino2.Value), Convert.ToInt16(txtTotal2.Value), Convert.ToInt16(txtTribunales2.Text), intEnOtraOportunidad);
    //    Response.Redirect("default.aspx");
    //}
    protected void btnContinuar_Click(object sender, EventArgs e)
    {
        if (rbNo.Checked || rbEnOtraOpotunidad.Checked)
            btnGuarda_Click(sender, e);

        if (rbSi.Checked)
        {
            pnlDatos.Visible = true;
            lblPregunta.Visible = false;
            rbNo.Visible = false;
            rbSi.Visible = false;
            rbEnOtraOpotunidad.Visible = false;
            btnContinuar.Visible = false;
        }
        //if (rbEnOtraOpotunidad.Checked)
        //    Response.Redirect("default.aspx");
    }
    protected void btnGuarda_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(txtTotal2.Value) < 1 && pnlDatos.Visible)
        {
            lblError.Visible = true;

            if (Convert.ToInt32(txtFemenino2.Value) == 0)
                txtFemenino2.Focus();
            else
                txtMasculino2.Focus();

            return;
        }
        int intEnOtraOportunidad;
        if (rbEnOtraOpotunidad.Checked) intEnOtraOportunidad = 1; else intEnOtraOportunidad = 0;

        EncuestasColl ecoll = new EncuestasColl();
        ecoll.InsertaRespuestaListaEspera(Convert.ToInt32(Session["IdUsuario"]), intCodEncuesta, intCodProyecto, Convert.ToInt16(txtFemenino2.Value), Convert.ToInt16(txtMasculino2.Value), Convert.ToInt16(txtTotal2.Value), Convert.ToInt16(txtTribunales2.Text), intEnOtraOportunidad);
        Response.Redirect("default.aspx");
    }
}
