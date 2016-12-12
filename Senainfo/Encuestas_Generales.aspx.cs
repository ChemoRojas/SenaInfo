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

public partial class Encuestas_Generales : System.Web.UI.Page
{
    public DataSet dtEncuestasPreguntas
    {
        get { return (DataSet)Session["dtEncuestasPreguntas"]; }
        set { Session["dtEncuestasPreguntas"] = value; }
    }
    public DataSet dtEncuestas
    {
        get { return (DataSet)Session["dtEncuestas"]; }
        set { Session["dtEncuestas"] = value; }
    }
    public int NumeroRow
    {
        get { return (int)Session["NumeroRow"]; }
        set { Session["NumeroRow"] = value; }
    }
    public DataSet dtEncuestasPreguntasExperiencia
    {
        get { return (DataSet)Session["dtEncuestasPreguntasExperiencia"]; }
        set { Session["dtEncuestasPreguntasExperiencia"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dtEncuestasPreguntasExperiencia = EncuestasPreguntasExperiencia();
            //grdExperiencia.DataSource = dtEncuestasPreguntasExperiencia;
            //grdExperiencia.DataBind();
            dtEncuestasPreguntas = GetEncuestasPreguntas();
            dtEncuestas = GetEncuestas();
            NumeroRow = 0;
            grPreguntas.DataSource = dtEncuestas;
            dtEncuestas.Tables[0].DefaultView.RowFilter = "CodPregunta = " + Convert.ToString(dtEncuestasPreguntas.Tables[0].Rows[0]["CodPregunta"]);
            grPreguntas.DataBind();
            LlenaDropDownList();
            LlenaPreguntas(NumeroRow);
        }
    }

    private void LlenaDropDownList()
    {
        parcoll cpar = new parcoll();
        DataSet dv1 = new DataSet();
        dv1.Tables.Add(cpar.GetparEncuestaRespuesta(Convert.ToInt32(dtEncuestasPreguntas.Tables[0].Rows[0]["CodEncuesta"])));
        DropDownList ddownNota;
        for (int x = 0; x < dtEncuestas.Tables[0].Rows.Count; x++)
        {
            ddownNota = (DropDownList)grPreguntas.Rows[x].Cells[1].FindControl("ddownNota");
            ddownNota.DataSource = dv1;
            ddownNota.DataTextField = "Descripcion";
            ddownNota.DataValueField = "CodRespuesta";
            dv1.Tables[0].DefaultView.Sort = "CodRespuesta";
            ddownNota.DataBind();
        }
    }
    public DataSet GetEncuestasPreguntas()
    {
        EncuestasColl ecoll = new EncuestasColl();
        DataSet dtEncuestasPreguntas = new DataSet();
        dtEncuestasPreguntas.Tables.Add(ecoll.GetData2());
        return dtEncuestasPreguntas;
    }
    public DataSet GetEncuestas()
    {
        EncuestasColl ecoll = new EncuestasColl();
        DataSet dtEncuestas = new DataSet();
        dtEncuestas.Tables.Add(ecoll.GetData());
        return dtEncuestas;
    }

    public DataSet EncuestasPreguntasExperiencia()
    {
        EncuestasColl ecoll = new EncuestasColl();
        int CodEncuesta = ecoll.CodigoEncuesta();

        DataSet EncuestasPreguntasExperiencia = new DataSet();
        EncuestasPreguntasExperiencia.Tables.Add(ecoll.EncuestasPreguntasExperiencia(CodEncuesta));
        return EncuestasPreguntasExperiencia;
    }

    protected int GuardaRespuestas(int NumeroRow)
    {
        for (int x = 0; x < dtEncuestas.Tables[0].Rows.Count; x++)
        {
            //WebNumericEdit txNota = (WebNumericEdit)grPreguntas.Rows[x].Cells[1].FindControl("txNota");
            DropDownList ddownNota = (DropDownList)grPreguntas.Rows[x].Cells[1].FindControl("ddownNota");
            RadioButton rb001 = (RadioButton)grPreguntas.Rows[x].Cells[2].FindControl("rb001");
            RadioButton rb002 = (RadioButton)grPreguntas.Rows[x].Cells[2].FindControl("rb002");

            if (rb001.Checked)
                dtEncuestas.Tables[0].Rows[x]["NoCorresponde"] = 1;
            else
                dtEncuestas.Tables[0].Rows[x]["NoCorresponde"] = 0;

            if (rb002.Checked)
                dtEncuestas.Tables[0].Rows[x]["NoSabe"] = 1;
            else
                dtEncuestas.Tables[0].Rows[x]["NoSabe"] = 0;

            //if (txNota.ValueInt == 0)
            //    dtEncuestas[x]["Nota"] = 0;

            if (Convert.ToInt16(ddownNota.SelectedValue) > 0)
            {
                dtEncuestas.Tables[0].Rows[x]["Nota"] = Convert.ToInt16(ddownNota.SelectedValue);
                dtEncuestas.Tables[0].Rows[x]["NoCorresponde"] = 0;
                dtEncuestas.Tables[0].Rows[x]["NoSabe"] = 0;
                ddownNota.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                dtEncuestas.Tables[0].Rows[x]["Nota"] = 0;
                if (Convert.ToInt16(dtEncuestas.Tables[0].Rows[x]["NoCorresponde"]) == 0 && Convert.ToInt16(dtEncuestas.Tables[0].Rows[x]["NoSabe"]) == 0)
                    ddownNota.BackColor = System.Drawing.Color.Pink;
            }
            //if (txNota.ValueInt > 0)
            //{
            //    dtEncuestas[x]["Nota"] = Convert.ToUInt16(txNota.Value);
            //    dtEncuestas[x]["NoCorresponde"] = 0;
            //    dtEncuestas[x]["NoSabe"] = 0;
            //}
            dtEncuestas.Tables[0].Rows[x]["Observaciones"] = TextBox1.Text;
            if ((int)dtEncuestas.Tables[0].Rows[x]["Nota"] == 0 && (int)dtEncuestas.Tables[0].Rows[x]["NoSabe"] == 0 && (int)dtEncuestas.Tables[0].Rows[x]["NoCorresponde"] == 0)
            {
                lbError.Text = "Debe indicar una respuesta";
                grPreguntas.Focus();
                return 0;
            }
            else
                lbError.Text = "";
        }
        dtEncuestasPreguntas.Tables[0].Rows[NumeroRow]["Observaciones"] = TextBox1.Text;
        return 1;
    }
    protected int GuardaRespuestasExperiencia()
    {
        return 1;
    }

    protected void LlenaPreguntas(int NumeroRow)
    {
        txHeader.Text = (string)dtEncuestasPreguntas.Tables[0].Rows[NumeroRow]["Descripcion"];
        lbPregunta.Text = (string)dtEncuestasPreguntas.Tables[0].Rows[NumeroRow]["Pregunta"];
        for (int x = 0; x < dtEncuestas.Tables[0].Rows.Count; x++)
        {
            //WebNumericEdit txNota = (WebNumericEdit)grPreguntas.Rows[x].Cells[1].FindControl("txNota");
            DropDownList ddownNota = (DropDownList)grPreguntas.Rows[x].Cells[1].FindControl("ddownNota");
            RadioButton rb001 = (RadioButton)grPreguntas.Rows[x].Cells[2].FindControl("rb001");
            RadioButton rb002 = (RadioButton)grPreguntas.Rows[x].Cells[2].FindControl("rb002");

            if (Convert.ToInt32(dtEncuestas.Tables[0].Rows[x]["NoCorresponde"]) == 1)
                rb001.Checked = true;
            else
                rb001.Checked = false;

            if (Convert.ToInt32(dtEncuestas.Tables[0].Rows[x]["NoSabe"]) == 1)
                rb002.Checked = true;
            else
                rb002.Checked = false;

           // txNota.ValueInt = Convert.ToInt32(dtEncuestas[x]["Nota"]);
            ddownNota.SelectedValue = dtEncuestas.Tables[0].Rows[x]["Nota"].ToString();

            if (Convert.ToInt16(ddownNota.SelectedValue) > 0)
            {
                rb001.Checked = false;
                rb002.Checked = false;
            }
            //if (txNota.ValueInt > 0)
            //{
            //    rb001.Checked = false;
            //    rb002.Checked = false;
            //}
        }
        TextBox1.Text = (string)dtEncuestasPreguntas.Tables[0].Rows[NumeroRow]["Observaciones"];
        

    }

    //protected void btGrabar_Click(object sender, EventArgs e)
    //{
    //    dtEncuestas.Tables[0].DefaultView.RowFilter = "";
    //    grPreguntas.DataBind();

    //    int CodEncuenta = (int)dtEncuestasPreguntas.Tables[0].Rows[0]["CodEncuesta"];
    //    EncuestasColl ecoll = new EncuestasColl();
    //    int CodEncuestado = ecoll.InsertaRespuestaCabeza(ASP.global_asax.globaconn, CodEncuenta, Convert.ToString(Session["IdUsuario"]), txtObservacionGeneral.Text);
    //    int Respuesta = ecoll.InsertaRespuestaDetalle(ASP.global_asax.globaconn, CodEncuestado, dtEncuestas, Convert.ToInt32(Session["IdUsuario"]), CodEncuenta);
    //    ecoll.InsertaRespuestaExperiencia(ASP.global_asax.globaconn, CodEncuestado, dtEncuestasPreguntasExperiencia, Convert.ToInt32(Session["IdUsuario"]), CodEncuenta);
    //    Response.Redirect("default.aspx");
    //}
    protected void rb001_CheckedChanged(object sender, EventArgs e)
    {
    }
  
    protected void btAnterior_Click(object sender, EventArgs e)
    {
        grPreguntas.Visible = true; lblObservacion.Visible = true; TextBox1.Visible = true; lbPregunta.Visible = true;
        lblObservacionGeneral.Visible = false; txtObservacionGeneral.Visible = false;
        if (NumeroRow == 0)
        {
            lblInstrucciones.Visible = false; txHeader.Visible = false; lblAfirmacion.Visible = false; lbError.Visible = false;
            lbPregunta.Visible = false; grPreguntas.Visible = false; TextBox1.Visible = false; btAnterior.Visible = false; btSiguiente.Visible = false;
            return;
        }

        if (GuardaRespuestas(NumeroRow) == 0)
            return;

        NumeroRow -= 1;
        dtEncuestas.Tables[0].DefaultView.RowFilter = "CodPregunta = " + Convert.ToString(dtEncuestasPreguntas.Tables[0].Rows[NumeroRow]["CodPregunta"]);
        grPreguntas.DataSource = dtEncuestas;
        grPreguntas.DataBind();
        LlenaDropDownList();
        LlenaPreguntas(NumeroRow);

        if (NumeroRow == 0)
            btAnterior.Visible = false;
    }
    protected void WebImageButton2_Click(object sender, EventArgs e)
    {
        txHeader.Visible = false;
        if (GuardaRespuestas(NumeroRow) == 0)
            return;

        if (dtEncuestasPreguntas.Tables[0].Rows.Count - 1 == NumeroRow)
        {
            grPreguntas.Visible = false; lblObservacion.Visible = false; TextBox1.Visible = false; lbPregunta.Visible = false;
            lblObservacionGeneral.Visible = true; txtObservacionGeneral.Visible = true;
            btGrabar.Visible = true;
            return;
        }
        if (dtEncuestasPreguntas.Tables[0].Rows.Count != 0)
            btAnterior.Visible = true;

        if (dtEncuestas.Tables[0].Rows[NumeroRow]["Nota"].ToString() == "5")
        {
            grPreguntas.Visible = false; lblObservacion.Visible = false; TextBox1.Visible = false; lbPregunta.Visible = false;
            lblObservacionGeneral.Visible = true; txtObservacionGeneral.Visible = true;
            btGrabar.Visible = true;
            NumeroRow += 1;
            return;
        }
        //lblErrorExperiencia.Visible = false;
        dtEncuestas.Tables[0].DefaultView.RowFilter = "";
        NumeroRow += 1;
        dtEncuestas.Tables[0].DefaultView.RowFilter = "CodPregunta = " + Convert.ToString(dtEncuestasPreguntas.Tables[0].Rows[NumeroRow]["CodPregunta"]);
        grPreguntas.DataSource = dtEncuestas;
        grPreguntas.DataBind();
        LlenaDropDownList();
        LlenaPreguntas(NumeroRow);
    }
    protected void btGrabar_Click(object sender, EventArgs e)
    {
        dtEncuestas.Tables[0].DefaultView.RowFilter = "";
        grPreguntas.DataBind();

        int CodEncuenta = (int)dtEncuestasPreguntas.Tables[0].Rows[0]["CodEncuesta"];
        EncuestasColl ecoll = new EncuestasColl();
        int CodEncuestado = ecoll.InsertaRespuestaCabeza(CodEncuenta, Convert.ToString(Session["IdUsuario"]), txtObservacionGeneral.Text);
        int Respuesta = ecoll.InsertaRespuestaDetalle(CodEncuestado, dtEncuestas, Convert.ToInt32(Session["IdUsuario"]), CodEncuenta);
        ecoll.InsertaRespuestaExperiencia(CodEncuestado, dtEncuestasPreguntasExperiencia, Convert.ToInt32(Session["IdUsuario"]), CodEncuenta);
        Response.Redirect("default.aspx");
    }
}
