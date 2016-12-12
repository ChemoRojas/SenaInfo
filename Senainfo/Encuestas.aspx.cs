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


public partial class Encuestas : System.Web.UI.Page
{
    public DataSet dtEncuestasPreguntas
    {
        get { return (DataSet)ViewState["dtEncuestasPreguntas"]; }
        set { ViewState["dtEncuestasPreguntas"] = value; }
    }
    public DataSet dtEncuestas
    {
        get { return (DataSet)ViewState["dtEncuestas"]; }
        set { ViewState["dtEncuestas"] = value; }
    }
    public int NumeroRow
    {
        get { return (int)Session["NumeroRow"]; }
        set { Session["NumeroRow"] = value; }
    }
    public DataSet dtEncuestasPreguntasExperiencia
    {
        get { return (DataSet)ViewState["dtEncuestasPreguntasExperiencia"]; }
        set { ViewState["dtEncuestasPreguntasExperiencia"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dtEncuestasPreguntasExperiencia = EncuestasPreguntasExperiencia();
            grdExperiencia.DataSource = dtEncuestasPreguntasExperiencia;
            grdExperiencia.DataBind();
            dtEncuestasPreguntas = GetEncuestasPreguntas();
            dtEncuestas = GetEncuestas();
            NumeroRow = 0;
            grPreguntas.DataSource = dtEncuestas;
            dtEncuestas.Tables[0].DefaultView.RowFilter = "CodPregunta = " + Convert.ToString(dtEncuestasPreguntas.Tables[0].Rows[0]["CodPregunta"]);
            grPreguntas.DataBind();
            LlenaPreguntas(NumeroRow);
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
        EncuestasPreguntasExperiencia.Tables.Add(ecoll.EncuestasPreguntasExperiencia( CodEncuesta));
        return EncuestasPreguntasExperiencia;
    }

    //protected void WebImageButton2_Click(object sender, EventArgs e)
    //{
    // // Botón Siguiente
    //    if (grdExperiencia.Visible)
    //    {
    //        GuardaRespuestasExperiencia();
    //        for (int x = 0; x < dtEncuestasPreguntasExperiencia.Tables[0].Rows.Count; x++)
    //        {
    //            if (Convert.ToInt32(dtEncuestasPreguntasExperiencia.Tables[0].Rows[x]["NotaFrecuencia"]) < 1 || Convert.ToInt32(dtEncuestasPreguntasExperiencia.Tables[0].Rows[x]["NotaTiempo"]) < 1)
    //            {
    //                lblErrorExperiencia.Visible = true;
    //                return;
    //            }
    //        }
    //        grdExperiencia.Visible = false;
    //        lblExperienciaHeader.Visible = false;
    //    }

    //    txHeader.Visible = false;
    //    if (GuardaRespuestas(NumeroRow) == 0)
    //        return;

    //    if (dtEncuestasPreguntas.Tables[0].Rows.Count - 1 == NumeroRow)
    //    {
    //        btGrabar.Visible = true;
    //        return;
    //    }

    //    lblErrorExperiencia.Visible = false;
    //    dtEncuestas.Tables[0].DefaultView.RowFilter = "";
    //    NumeroRow += 1;
    //    dtEncuestas.Tables[0].DefaultView.RowFilter = "CodPregunta = " + Convert.ToString(dtEncuestasPreguntas.Tables[0].Rows[NumeroRow]["CodPregunta"]);
    //    grPreguntas.DataSource = dtEncuestas;
    //    grPreguntas.DataBind();
    //    LlenaPreguntas(NumeroRow);
    //}
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
                lbError.Text = "Debe calificar con nota entre 1 y 7 o seleccionar las opciones No Sabe o No Corresponde";
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
        int intTodoContestado = 1;
        for (int x = 0; x < dtEncuestasPreguntasExperiencia.Tables[0].Rows.Count; x++)
        {
            //WebNumericEdit txNota = (WebNumericEdit)grPreguntas.Rows[x].Cells[1].FindControl("txNota");
            dtEncuestasPreguntasExperiencia.Tables[0].Rows[x]["NotaFrecuencia"] = 0;
            dtEncuestasPreguntasExperiencia.Tables[0].Rows[x]["NotaTiempo"] = 0;

            //DropDownList ddownNotaFrecuencia = (DropDownList)grdExperiencia.Rows[x].Cells[1].FindControl("ddlFrecuencia");
            //DropDownList ddownNotaTiempo = (DropDownList)grdExperiencia.Rows[x].Cells[2].FindControl("ddlTiempo");

            RadioButton rbFrecuencia001 = (RadioButton)grdExperiencia.Rows[x].Cells[1].FindControl("rbFrecuencia001");
            RadioButton rbFrecuencia002 = (RadioButton)grdExperiencia.Rows[x].Cells[1].FindControl("rbFrecuencia002");
            RadioButton rbFrecuencia003 = (RadioButton)grdExperiencia.Rows[x].Cells[1].FindControl("rbFrecuencia003");

            RadioButton rbTiempo001 = (RadioButton)grdExperiencia.Rows[x].Cells[1].FindControl("rbTiempo001");
            RadioButton rbTiempo002 = (RadioButton)grdExperiencia.Rows[x].Cells[1].FindControl("rbTiempo002");
            RadioButton rbTiempo003 = (RadioButton)grdExperiencia.Rows[x].Cells[1].FindControl("rbTiempo003");
            RadioButton rbTiempo004 = (RadioButton)grdExperiencia.Rows[x].Cells[1].FindControl("rbTiempo004");

            if (rbFrecuencia001.Checked == true) dtEncuestasPreguntasExperiencia.Tables[0].Rows[x]["NotaFrecuencia"] = 1;
            if (rbFrecuencia002.Checked == true) dtEncuestasPreguntasExperiencia.Tables[0].Rows[x]["NotaFrecuencia"] = 2;
            if (rbFrecuencia003.Checked == true)
            {
                dtEncuestasPreguntasExperiencia.Tables[0].Rows[x]["NotaFrecuencia"] = 3;
                rbTiempo001.Checked = false;
                rbTiempo002.Checked = false;
                rbTiempo003.Checked = false;
                rbTiempo004.Checked = true;
            }


            if (rbTiempo001.Checked == true) dtEncuestasPreguntasExperiencia.Tables[0].Rows[x]["NotaTiempo"] = 1;
            if (rbTiempo002.Checked == true) dtEncuestasPreguntasExperiencia.Tables[0].Rows[x]["NotaTiempo"] = 2;
            if (rbTiempo003.Checked == true) dtEncuestasPreguntasExperiencia.Tables[0].Rows[x]["NotaTiempo"] = 3;
            if (rbTiempo004.Checked == true) dtEncuestasPreguntasExperiencia.Tables[0].Rows[x]["NotaTiempo"] = 4;

            //dtEncuestasPreguntasExperiencia[x]["NotaFrecuencia"] = Convert.ToInt16(ddownNotaFrecuencia.SelectedValue);
            //dtEncuestasPreguntasExperiencia[x]["NotaTiempo"] = Convert.ToInt16(ddownNotaTiempo.SelectedValue);
            if (Convert.ToInt32(dtEncuestasPreguntasExperiencia.Tables[0].Rows[x]["NotaFrecuencia"]) < 1 || Convert.ToInt32(dtEncuestasPreguntasExperiencia.Tables[0].Rows[x]["NotaTiempo"]) < 1)
            {
                intTodoContestado = 0;
                if (Convert.ToInt32(dtEncuestasPreguntasExperiencia.Tables[0].Rows[x]["NotaFrecuencia"]) < 1)
                {
                    rbFrecuencia001.BackColor = System.Drawing.Color.Pink;
                    rbFrecuencia002.BackColor = System.Drawing.Color.Pink;
                    rbFrecuencia003.BackColor = System.Drawing.Color.Pink;
                }
                if (Convert.ToInt32(dtEncuestasPreguntasExperiencia.Tables[0].Rows[x]["NotaTiempo"]) < 1)
                {
                    rbTiempo001.BackColor = System.Drawing.Color.Pink;
                    rbTiempo002.BackColor = System.Drawing.Color.Pink;
                    rbTiempo003.BackColor = System.Drawing.Color.Pink;
                    rbTiempo004.BackColor = System.Drawing.Color.Pink;
                }
            }
            else
            {
                rbFrecuencia001.BackColor = System.Drawing.Color.Empty;
                rbFrecuencia002.BackColor = System.Drawing.Color.Empty;
                rbFrecuencia003.BackColor = System.Drawing.Color.Empty;

                rbTiempo001.BackColor = System.Drawing.Color.Empty;
                rbTiempo002.BackColor = System.Drawing.Color.Empty;
                rbTiempo003.BackColor = System.Drawing.Color.Empty;
                rbTiempo004.BackColor = System.Drawing.Color.Empty;
            }
        }
        return intTodoContestado;
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
    //protected void btAnterior_Click(object sender, EventArgs e)
    //{
    //    if (NumeroRow == 0)
    //    {
    //        lblInstrucciones.Visible = false; txHeader.Visible = false; lblAfirmacion.Visible = false; lbError.Visible = false;
    //        lbPregunta.Visible = false; grPreguntas.Visible = false; TextBox1.Visible = false; btAnterior.Visible = false; btSiguiente.Visible = false;
    //        grdExperiencia.Visible = true; lblExperienciaHeader.Visible = true; btnSiguienteExperiencia.Visible = true;
    //        lblErrorExperiencia.Visible = false;
    //        return;
    //    }

    //    if (GuardaRespuestas(NumeroRow) == 0)
    //        return;

    //    NumeroRow -= 1;
    //    dtEncuestas.Tables[0].DefaultView.RowFilter = "CodPregunta = " + Convert.ToString(dtEncuestasPreguntas.Tables[0].Rows[NumeroRow]["CodPregunta"]);
    //    grPreguntas.DataSource = dtEncuestas;
    //    grPreguntas.DataBind();
    //    LlenaPreguntas(NumeroRow);
    //    //if (NumeroRow == 0)
    //    //{
    //    //    grdExperiencia.Visible = true;
    //    //    lblExperienciaHeader.Visible = true;
    //    //}
    //}
    //protected void btGrabar_Click(object sender, EventArgs e)
    //{
    //    dtEncuestas.Tables[0].DefaultView.RowFilter = "";
    //    grPreguntas.DataBind();

    //    int CodEncuenta = (int)dtEncuestasPreguntas.Tables[0].Rows[0]["CodEncuesta"];
    //    EncuestasColl ecoll = new EncuestasColl();
    //    int CodEncuestado = ecoll.InsertaRespuestaCabeza(ASP.global_asax.globaconn, CodEncuenta, Convert.ToString(Session["IdUsuario"]));
    //    int Respuesta = ecoll.InsertaRespuestaDetalle(ASP.global_asax.globaconn, CodEncuestado, dtEncuestas, Convert.ToInt32(Session["IdUsuario"]), CodEncuenta);
    //    ecoll.InsertaRespuestaExperiencia(ASP.global_asax.globaconn, CodEncuestado, dtEncuestasPreguntasExperiencia, Convert.ToInt32(Session["IdUsuario"]), CodEncuenta);
    //    Response.Redirect("default.aspx");
    //}
    protected void rb001_CheckedChanged(object sender, EventArgs e)
    {
    }

    //protected void btnSiguienteExperiencia_Click(object sender, EventArgs e)
    //{
    //    int intContestaTodo;

    //    intContestaTodo = GuardaRespuestasExperiencia();

    //    if (intContestaTodo == 0)
    //    {
    //        lblErrorExperiencia.Visible = true;
    //        return;
    //    }
    //    lblInstrucciones.Visible = true; txHeader.Visible = true; lblAfirmacion.Visible = true; lbError.Visible = true;
    //    lbPregunta.Visible = true; grPreguntas.Visible = true; TextBox1.Visible = true; btAnterior.Visible = true; btSiguiente.Visible = true;
    //    grdExperiencia.Visible = false; lblExperienciaHeader.Visible = false; btnSiguienteExperiencia.Visible = false;
    //    lblErrorExperiencia.Visible = false;
    //}
    protected void btnSiguienteExperiencia_Click(object sender, EventArgs e)
    {
        int intContestaTodo;

        intContestaTodo = GuardaRespuestasExperiencia();

        if (intContestaTodo == 0)
        {
            lblErrorExperiencia.Visible = true;
            return;
        }
        lblInstrucciones.Visible = true; txHeader.Visible = true; lblAfirmacion.Visible = true; lbError.Visible = true;
        lbPregunta.Visible = true; grPreguntas.Visible = true; TextBox1.Visible = true; btAnterior.Visible = true; btSiguiente.Visible = true;
        grdExperiencia.Visible = false; lblExperienciaHeader.Visible = false; btnSiguienteExperiencia.Visible = false;
        lblErrorExperiencia.Visible = false;
    }
    protected void btAnterior_Click(object sender, EventArgs e)
    {
        if (NumeroRow == 0)
        {
            lblInstrucciones.Visible = false; txHeader.Visible = false; lblAfirmacion.Visible = false; lbError.Visible = false;
            lbPregunta.Visible = false; grPreguntas.Visible = false; TextBox1.Visible = false; btAnterior.Visible = false; btSiguiente.Visible = false;
            grdExperiencia.Visible = true; lblExperienciaHeader.Visible = true; btnSiguienteExperiencia.Visible = true;
            lblErrorExperiencia.Visible = false;
            return;
        }

        if (GuardaRespuestas(NumeroRow) == 0)
            return;

        NumeroRow -= 1;
        dtEncuestas.Tables[0].DefaultView.RowFilter = "CodPregunta = " + Convert.ToString(dtEncuestasPreguntas.Tables[0].Rows[NumeroRow]["CodPregunta"]);
        grPreguntas.DataSource = dtEncuestas;
        grPreguntas.DataBind();
        LlenaPreguntas(NumeroRow);
    }
    protected void WebImageButton2_Click(object sender, EventArgs e)
    {
        // Botón Siguiente
        if (grdExperiencia.Visible)
        {
            GuardaRespuestasExperiencia();
            for (int x = 0; x < dtEncuestasPreguntasExperiencia.Tables[0].Rows.Count; x++)
            {
                if (Convert.ToInt32(dtEncuestasPreguntasExperiencia.Tables[0].Rows[x]["NotaFrecuencia"]) < 1 || Convert.ToInt32(dtEncuestasPreguntasExperiencia.Tables[0].Rows[x]["NotaTiempo"]) < 1)
                {
                    lblErrorExperiencia.Visible = true;
                    return;
                }
            }
            grdExperiencia.Visible = false;
            lblExperienciaHeader.Visible = false;
        }

        txHeader.Visible = false;
        if (GuardaRespuestas(NumeroRow) == 0)
            return;

        if (dtEncuestasPreguntas.Tables[0].Rows.Count - 1 == NumeroRow)
        {
            btGrabar.Visible = true;
            return;
        }

        lblErrorExperiencia.Visible = false;
        dtEncuestas.Tables[0].DefaultView.RowFilter = "";
        NumeroRow += 1;
        dtEncuestas.Tables[0].DefaultView.RowFilter = "CodPregunta = " + Convert.ToString(dtEncuestasPreguntas.Tables[0].Rows[NumeroRow]["CodPregunta"]);
        grPreguntas.DataSource = dtEncuestas;
        grPreguntas.DataBind();
        LlenaPreguntas(NumeroRow);
    }
    protected void btGrabar_Click(object sender, EventArgs e)
    {
        dtEncuestas.Tables[0].DefaultView.RowFilter = "";
        grPreguntas.DataBind();

        int CodEncuenta = (int)dtEncuestasPreguntas.Tables[0].Rows[0]["CodEncuesta"];
        EncuestasColl ecoll = new EncuestasColl();
        int CodEncuestado = ecoll.InsertaRespuestaCabeza(CodEncuenta, Convert.ToString(Session["IdUsuario"]));
        int Respuesta = ecoll.InsertaRespuestaDetalle(CodEncuestado, dtEncuestas, Convert.ToInt32(Session["IdUsuario"]), CodEncuenta);
        ecoll.InsertaRespuestaExperiencia(CodEncuestado, dtEncuestasPreguntasExperiencia, Convert.ToInt32(Session["IdUsuario"]), CodEncuenta);
        Response.Redirect("default.aspx");
    }
}
