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


public partial class EncuestasFES : System.Web.UI.Page
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
            dtEncuestasPreguntas = GetEncuestasPreguntas();
            dtEncuestas = GetEncuestas();
            NumeroRow = 0;
            grPreguntas.DataSource = dtEncuestas;
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
        EncuestasPreguntasExperiencia.Tables.Add(ecoll.EncuestasPreguntasExperiencia(CodEncuesta));
        return EncuestasPreguntasExperiencia;
    }

    protected void WebImageButton2_Click(object sender, EventArgs e)
    {
     // Botón Siguiente

        txHeader.Visible = false;
        if (GuardaRespuestas(NumeroRow) == 0)
            return;

        if (dtEncuestasPreguntas.Tables[0].Rows.Count - 1 == NumeroRow)
        {
            btGrabar.Visible = true;
            return;
        }

        dtEncuestas.Tables[0].DefaultView.RowFilter = "";
        NumeroRow += 1;
        dtEncuestas.Tables[0].DefaultView.RowFilter = "CodPregunta = " + Convert.ToString(dtEncuestasPreguntas.Tables[0].Rows[NumeroRow]["CodPregunta"]);
        grPreguntas.DataSource = dtEncuestas;
        grPreguntas.DataBind();
        LlenaPreguntas(NumeroRow);
    }
    protected int GuardaRespuestas(int NumeroRow)
    {
        for (int x = 0; x < dtEncuestas.Tables[0].Rows.Count; x++)
        {
            DropDownList ddownNota = (DropDownList)grPreguntas.Rows[x].Cells[1].FindControl("ddownNota");

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
            }
            if ((int)dtEncuestas.Tables[0].Rows[x]["Nota"] == 0)
            {
                Label1.Text = "Debe calificar con nota entre 1 y 7";
                grPreguntas.Focus();
                return 0;
            }
            else
                Label1.Text = String.Empty;
        }
        return 1;
    }
    protected int GuardaRespuestasExperiencia()
    {
        int intTodoContestado = 1;
        for (int x = 0; x < dtEncuestasPreguntasExperiencia.Tables[0].Rows.Count; x++)
        {
            dtEncuestasPreguntasExperiencia.Tables[0].Rows[x]["NotaFrecuencia"] = 0;
            dtEncuestasPreguntasExperiencia.Tables[0].Rows[x]["NotaTiempo"] = 0;
        }
        return intTodoContestado;
    }

    protected void LlenaPreguntas(int NumeroRow)
    {
        txHeader.Text = (string)dtEncuestasPreguntas.Tables[0].Rows[NumeroRow]["Descripcion"];
        lbPregunta.Text = (string)dtEncuestasPreguntas.Tables[0].Rows[NumeroRow]["Pregunta"];
        for (int x = 0; x < dtEncuestas.Tables[0].Rows.Count; x++)
        {
            DropDownList ddownNota = (DropDownList)grPreguntas.Rows[x].Cells[1].FindControl("ddownNota");
            ddownNota.SelectedValue = dtEncuestas.Tables[0].Rows[x]["Nota"].ToString();
        }
    }
    protected void btAnterior_Click(object sender, EventArgs e)
    {
        if (NumeroRow == 0)
        {
            lblInstrucciones.Visible = false; txHeader.Visible = false; lblAfirmacion.Visible = false; lbError.Visible = false;
            lbPregunta.Visible = false; grPreguntas.Visible = false;
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
    //protected void btGrabar_Click(object sender, EventArgs e)
    //{
    //    int i = GuardaRespuestas(0);
    //    if (i == 0)
    //        return;

    //    int CodEncuenta = (int)dtEncuestasPreguntas.Tables[0].Rows[0]["CodEncuesta"];
    //    EncuestasColl ecoll = new EncuestasColl();
    //    int CodEncuestado = ecoll.InsertaRespuestaCabeza(ASP.global_asax.globaconn, CodEncuenta, Convert.ToString(Session["IdUsuario"]));
    //    int Respuesta = ecoll.InsertaRespuestaDetalle(ASP.global_asax.globaconn, CodEncuestado, dtEncuestas, Convert.ToInt32(Session["IdUsuario"]), CodEncuenta);
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
    //        return;
    //    }
    //    lblInstrucciones.Visible = true; txHeader.Visible = true; lblAfirmacion.Visible = true; lbError.Visible = true;
    //    lbPregunta.Visible = true; grPreguntas.Visible = true;
    //}
    protected void btGrabar_Click(object sender, EventArgs e)
    {
        int i = GuardaRespuestas(0);
        if (i == 0)
            return;

        int CodEncuenta = (int)dtEncuestasPreguntas.Tables[0].Rows[0]["CodEncuesta"];
        EncuestasColl ecoll = new EncuestasColl();
        int CodEncuestado = ecoll.InsertaRespuestaCabeza(CodEncuenta, Convert.ToString(Session["IdUsuario"]));
        int Respuesta = ecoll.InsertaRespuestaDetalle(CodEncuestado, dtEncuestas, Convert.ToInt32(Session["IdUsuario"]), CodEncuenta);
        Response.Redirect("default.aspx");
    }
}
