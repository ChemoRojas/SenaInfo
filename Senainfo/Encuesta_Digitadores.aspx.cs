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

public partial class Encuesta_Digitadores : System.Web.UI.Page
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dtEncuestasPreguntas = GetEncuestasPreguntas();
            dtEncuestas = GetEncuestas();
            NumeroRow = 0;
            dtEncuestas.Tables[0].DefaultView.RowFilter = "CodPregunta = " + Convert.ToString(dtEncuestasPreguntas.Tables[0].Rows[0]["CodPregunta"]);
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
    protected void LlenaPreguntas(int NumeroRow)
    {
        lblPregunta.Text = (string)dtEncuestasPreguntas.Tables[0].Rows[NumeroRow]["Pregunta"];
    }

    protected void btnSiguiente_Click(object sender, EventArgs e)
    {
        pnlPregunta21.Visible = (NumeroRow + 2) == 21;
        pnlPregunta20.Visible = (NumeroRow + 2) == 20;
        pnlPregunta19.Visible = (NumeroRow + 2) == 19;
        pnlPregunta18.Visible = (NumeroRow + 2) == 18;
        pnlPregunta17.Visible = (NumeroRow + 2) == 17;
        pnlPregunta16.Visible = (NumeroRow + 2) == 16;
        pnlPregunta15.Visible = (NumeroRow + 2) == 15;
        pnlPregunta14.Visible = (NumeroRow + 2) == 14;
        pnlPregunta13.Visible = (NumeroRow + 2) == 13;
        pnlPregunta12.Visible = (NumeroRow + 2) == 12;
        pnlPregunta11.Visible = (NumeroRow + 2) == 11;
        pnlPregunta10.Visible = (NumeroRow + 2) == 10;
        pnlPregunta09.Visible = (NumeroRow + 2) == 9;
        pnlPregunta08.Visible = (NumeroRow + 2) == 8;
        pnlPregunta07.Visible = (NumeroRow + 2) == 7;
        pnlPregunta06.Visible = (NumeroRow + 2) == 6;
        pnlPregunta05.Visible = (NumeroRow + 2) == 5;
        pnlPregunta04.Visible = (NumeroRow + 2) == 4;
        pnlPregunta03.Visible = (NumeroRow + 2) == 3;
        pnlPregunta02.Visible = (NumeroRow + 2) == 2;
        pnlPregunta01.Visible = (NumeroRow + 2) == 1;

        NumeroRow += 1;
        LlenaPreguntas(NumeroRow);
        btnSiguiente.Visible = !(pnlPregunta21.Visible);
        btnAnterior.Visible = !(pnlPregunta01.Visible);
        btnGrabar.Visible = pnlPregunta21.Visible;
    }
    protected void btnAnterior_Click(object sender, EventArgs e)
    {
        pnlPregunta21.Visible = NumeroRow == 21;
        pnlPregunta20.Visible = NumeroRow == 20;
        pnlPregunta19.Visible = NumeroRow == 19;
        pnlPregunta18.Visible = NumeroRow == 18;
        pnlPregunta17.Visible = NumeroRow == 17;
        pnlPregunta16.Visible = NumeroRow == 16;
        pnlPregunta15.Visible = NumeroRow == 15;
        pnlPregunta14.Visible = NumeroRow == 14;
        pnlPregunta13.Visible = NumeroRow == 13;
        pnlPregunta12.Visible = NumeroRow == 12;
        pnlPregunta11.Visible = NumeroRow == 11;
        pnlPregunta10.Visible = NumeroRow == 10;
        pnlPregunta09.Visible = NumeroRow == 9;
        pnlPregunta08.Visible = NumeroRow == 8;
        pnlPregunta07.Visible = NumeroRow == 7;
        pnlPregunta06.Visible = NumeroRow == 6;
        pnlPregunta05.Visible = NumeroRow == 5;
        pnlPregunta04.Visible = NumeroRow == 4;
        pnlPregunta03.Visible = NumeroRow == 3;
        pnlPregunta02.Visible = NumeroRow == 2;
        pnlPregunta01.Visible = NumeroRow == 1;

        NumeroRow -= 1;
        LlenaPreguntas(NumeroRow);
        btnAnterior.Visible = !(pnlPregunta01.Visible);
        btnSiguiente.Visible = !(pnlPregunta21.Visible);
        btnGrabar.Visible = pnlPregunta21.Visible;
    }
    protected void btnGrabar_Click(object sender, EventArgs e)
    {
        dtEncuestas.Tables[0].DefaultView.RowFilter = "";
        //------------- 1 ---------------------------------
        dtEncuestas.Tables[0].Rows[0]["Nota"] = txt_1.Value;

        //------------- 2 ---------------------------------
        dtEncuestas.Tables[0].Rows[1]["Nota"] = txt_2a.Value;
        dtEncuestas.Tables[0].Rows[2]["Nota"] = txt_2b.Value;
        //------------- 3 ---------------------------------
        if (rdb_3a.Checked)
            dtEncuestas.Tables[0].Rows[3]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[3]["Nota"] = 0;

        if (rdb_3b.Checked)
            dtEncuestas.Tables[0].Rows[4]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[4]["Nota"] = 0;
        //------------- 4 ---------------------------------
        if (rdb_4a.Checked)
            dtEncuestas.Tables[0].Rows[5]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[5]["Nota"] = 0;

        if (rdb_4b.Checked)
            dtEncuestas.Tables[0].Rows[6]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[6]["Nota"] = 0;
        //------------- 5 ---------------------------------
        if (rdb_5a.Checked)
            dtEncuestas.Tables[0].Rows[7]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[7]["Nota"] = 0;

        if (rdb_5b.Checked)
            dtEncuestas.Tables[0].Rows[8]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[8]["Nota"] = 0;
        //------------- 6 ---------------------------------
        if (rdb_6a.Checked)
            dtEncuestas.Tables[0].Rows[9]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[9]["Nota"] = 0;

        if (rdb_6b.Checked)
            dtEncuestas.Tables[0].Rows[10]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[10]["Nota"] = 0;
        //------------- 7 ---------------------------------
        if (chk_7a.Checked)
            dtEncuestas.Tables[0].Rows[11]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[11]["Nota"] = 0;

        if (chk_7b.Checked)
            dtEncuestas.Tables[0].Rows[12]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[12]["Nota"] = 0;

        if (chk_7c.Checked)
            dtEncuestas.Tables[0].Rows[13]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[13]["Nota"] = 0;

        if (chk_7d.Checked)
            dtEncuestas.Tables[0].Rows[14]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[14]["Nota"] = 0;

        if (chk_7e.Checked)
            dtEncuestas.Tables[0].Rows[15]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[15]["Nota"] = 0;

        if (chk_7f.Checked)
            dtEncuestas.Tables[0].Rows[16]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[16]["Nota"] = 0;

        //------------- 8 ---------------------------------
        if (rdb_8a.Checked)
            dtEncuestas.Tables[0].Rows[17]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[17]["Nota"] = 0;

        if (rdb_8b.Checked)
            dtEncuestas.Tables[0].Rows[18]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[18]["Nota"] = 0;

        if (rdb_8c.Checked)
            dtEncuestas.Tables[0].Rows[19]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[19]["Nota"] = 0;

        //------------- 9 ---------------------------------
        if (rdb_9a.Checked)
            dtEncuestas.Tables[0].Rows[20]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[20]["Nota"] = 0;

        if (rdb_9b.Checked)
            dtEncuestas.Tables[0].Rows[21]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[21]["Nota"] = 0;

        if (rdb_9c.Checked)
            dtEncuestas.Tables[0].Rows[22]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[22]["Nota"] = 0;

        //------------- 10 --------------------------------
        if (rdb_10a.Checked)
            dtEncuestas.Tables[0].Rows[23]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[23]["Nota"] = 0;

        if (rdb_10b.Checked)
            dtEncuestas.Tables[0].Rows[24]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[24]["Nota"] = 0;

        if (rdb_10c.Checked)
            dtEncuestas.Tables[0].Rows[25]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[25]["Nota"] = 0;

        //------------- 11 --------------------------------
        if (rdb_11a1.Checked)
            dtEncuestas.Tables[0].Rows[26]["Nota"] = 1;
        else
            if (rdb_11a2.Checked)
                dtEncuestas.Tables[0].Rows[26]["Nota"] = 2;
            else
                if (rdb_11a3.Checked)
                    dtEncuestas.Tables[0].Rows[26]["Nota"] = 3;

        if (rdb_11b1.Checked)
            dtEncuestas.Tables[0].Rows[27]["Nota"] = 1;
        else
            if (rdb_11b2.Checked)
                dtEncuestas.Tables[0].Rows[27]["Nota"] = 2;
            else
                if (rdb_11b3.Checked)
                    dtEncuestas.Tables[0].Rows[27]["Nota"] = 3;

        if (rdb_11c1.Checked)
            dtEncuestas.Tables[0].Rows[28]["Nota"] = 1;
        else
            if (rdb_11c2.Checked)
                dtEncuestas.Tables[0].Rows[28]["Nota"] = 2;
            else
                if (rdb_11c3.Checked)
                    dtEncuestas.Tables[0].Rows[28]["Nota"] = 3;

        if (rdb_11d1.Checked)
            dtEncuestas.Tables[0].Rows[29]["Nota"] = 1;
        else
            if (rdb_11d2.Checked)
                dtEncuestas.Tables[0].Rows[29]["Nota"] = 2;
            else
                if (rdb_11d3.Checked)
                    dtEncuestas.Tables[0].Rows[29]["Nota"] = 3;

        if (rdb_11e1.Checked)
            dtEncuestas.Tables[0].Rows[30]["Nota"] = 1;
        else
            if (rdb_11e2.Checked)
                dtEncuestas.Tables[0].Rows[30]["Nota"] = 2;
            else
                if (rdb_11e3.Checked)
                    dtEncuestas.Tables[0].Rows[30]["Nota"] = 3;

        //------------- 12 --------------------------------
        if (rdb_12a1.Checked)
        {
            if (rdb_12a3.Checked)
                dtEncuestas.Tables[0].Rows[31]["Nota"] = 1;
            else
                if (rdb_12a4.Checked)
                    dtEncuestas.Tables[0].Rows[31]["Nota"] = 2;
                else
                    if (rdb_12a5.Checked)
                        dtEncuestas.Tables[0].Rows[31]["Nota"] = 3;

            dtEncuestas.Tables[0].Rows[31]["Observaciones"] = txt_12a.Value;
        }

        if (rdb_12b1.Checked)
        {
            if (rdb_12b3.Checked)
                dtEncuestas.Tables[0].Rows[32]["Nota"] = 1;
            else
                if (rdb_12b4.Checked)
                    dtEncuestas.Tables[0].Rows[32]["Nota"] = 2;
                else
                    if (rdb_12b5.Checked)
                        dtEncuestas.Tables[0].Rows[32]["Nota"] = 3;

            dtEncuestas.Tables[0].Rows[32]["Observaciones"] = txt_12b.Value;
        }

        if (rdb_12c1.Checked)
        {
            if (rdb_12c3.Checked)
                dtEncuestas.Tables[0].Rows[33]["Nota"] = 1;
            else
                if (rdb_12c4.Checked)
                    dtEncuestas.Tables[0].Rows[33]["Nota"] = 2;
                else
                    if (rdb_12c5.Checked)
                        dtEncuestas.Tables[0].Rows[33]["Nota"] = 3;

            dtEncuestas.Tables[0].Rows[33]["Observaciones"] = txt_12c.Value;
        }

        if (rdb_12d1.Checked)
        {
            if (rdb_12d3.Checked)
                dtEncuestas.Tables[0].Rows[34]["Nota"] = 1;
            else
                if (rdb_12d4.Checked)
                    dtEncuestas.Tables[0].Rows[34]["Nota"] = 2;
                else
                    if (rdb_12d5.Checked)
                        dtEncuestas.Tables[0].Rows[34]["Nota"] = 3;

            //dtEncuestas.Tables[0].Rows[34]["Observaciones"] = txt_12d.Value;
        }

        if (rdb_12e1.Checked)
        {
            if (rdb_12e3.Checked)
                dtEncuestas.Tables[0].Rows[35]["Nota"] = 1;
            else
                if (rdb_12e4.Checked)
                    dtEncuestas.Tables[0].Rows[35]["Nota"] = 2;
                else
                    if (rdb_12e5.Checked)
                        dtEncuestas.Tables[0].Rows[35]["Nota"] = 3;

            //dtEncuestas.Tables[0].Rows[35]["Observaciones"] = txt_12e.Value;
        }

        if (rdb_12f1.Checked)
        {
            if (rdb_12f3.Checked)
                dtEncuestas.Tables[0].Rows[36]["Nota"] = 1;
            else
                if (rdb_12f4.Checked)
                    dtEncuestas.Tables[0].Rows[36]["Nota"] = 2;
                else
                    if (rdb_12f5.Checked)
                        dtEncuestas.Tables[0].Rows[36]["Nota"] = 3;

            //dtEncuestas.Tables[0].Rows[36]["Observaciones"] = txt_12f.Value;
        }

        //------------- 13 --------------------------------
        if (rdb_13a.Checked)
            dtEncuestas.Tables[0].Rows[37]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[37]["Nota"] = 0;

        if (rdb_13b.Checked)
            dtEncuestas.Tables[0].Rows[38]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[38]["Nota"] = 0;

        if (rdb_13c.Checked)
            dtEncuestas.Tables[0].Rows[39]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[39]["Nota"] = 0;

        if (rdb_13d.Checked)
            dtEncuestas.Tables[0].Rows[40]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[40]["Nota"] = 0;

        //------------- 14 --------------------------------
        if (rdb_14a.Checked)
            dtEncuestas.Tables[0].Rows[41]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[41]["Nota"] = 0;

        if (rdb_14b.Checked)
            dtEncuestas.Tables[0].Rows[42]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[42]["Nota"] = 0;

        if (rdb_14c.Checked)
            dtEncuestas.Tables[0].Rows[43]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[43]["Nota"] = 0;

        if (rdb_14d.Checked)
            dtEncuestas.Tables[0].Rows[44]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[44]["Nota"] = 0;

        //------------- 15 --------------------------------
        if (rdb_15a.Checked)
            dtEncuestas.Tables[0].Rows[45]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[45]["Nota"] = 0;

        if (rdb_15b.Checked)
            dtEncuestas.Tables[0].Rows[46]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[46]["Nota"] = 0;

        if (rdb_15c.Checked)
            dtEncuestas.Tables[0].Rows[47]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[47]["Nota"] = 0;

        //------------- 16 --------------------------------
        if (rdb_16a.Checked)
            dtEncuestas.Tables[0].Rows[48]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[48]["Nota"] = 0;

        if (rdb_16b.Checked)
            dtEncuestas.Tables[0].Rows[49]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[49]["Nota"] = 0;

        //------------- 17 --------------------------------
        if (rdb_17a.Checked)
            dtEncuestas.Tables[0].Rows[50]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[50]["Nota"] = 0;

        if (rdb_17b.Checked)
            dtEncuestas.Tables[0].Rows[51]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[51]["Nota"] = 0;

        //------------- 18 --------------------------------
        if (rdb_18a.Checked)
            dtEncuestas.Tables[0].Rows[52]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[52]["Nota"] = 0;

        if (rdb_18b.Checked)
            dtEncuestas.Tables[0].Rows[53]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[53]["Nota"] = 0;

        if (rdb_18c.Checked)
            dtEncuestas.Tables[0].Rows[54]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[54]["Nota"] = 0;

        //------------- 19 --------------------------------
        if (rdb_19a.Checked)
            dtEncuestas.Tables[0].Rows[55]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[55]["Nota"] = 0;

        if (rdb_19b.Checked)
            dtEncuestas.Tables[0].Rows[56]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[56]["Nota"] = 0;

        if (rdb_19c.Checked)
            dtEncuestas.Tables[0].Rows[57]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[57]["Nota"] = 0;

        //------------- 20 --------------------------------
        dtEncuestas.Tables[0].Rows[58]["Observaciones"] = txt_20.Value;

        //------------- 21 --------------------------------
        if (rdb_21a.Checked)
            dtEncuestas.Tables[0].Rows[59]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[59]["Nota"] = 0;

        if (rdb_21b.Checked)
            dtEncuestas.Tables[0].Rows[60]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[60]["Nota"] = 0;

        if (rdb_21c.Checked)
            dtEncuestas.Tables[0].Rows[61]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[61]["Nota"] = 0;

        if (rdb_21d.Checked)
            dtEncuestas.Tables[0].Rows[62]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[62]["Nota"] = 0;

        if (rdb_21e.Checked)
        {
            dtEncuestas.Tables[0].Rows[63]["Nota"] = 1;
            dtEncuestas.Tables[0].Rows[63]["Observaciones"] = txt_21.Value;
        }
        else
            dtEncuestas.Tables[0].Rows[63]["Nota"] = 0;

        //-------------------------------------------------
        int CodEncuenta = (int)dtEncuestasPreguntas.Tables[0].Rows[0]["CodEncuesta"];

        EncuestasColl ecoll = new EncuestasColl();
        int CodEncuestado = ecoll.InsertaRespuestaCabeza(CodEncuenta, Convert.ToString(Session["IdUsuario"]));
        int Respuesta = ecoll.InsertaRespuestaDetalle(CodEncuestado, dtEncuestas, Convert.ToInt32(Session["IdUsuario"]), CodEncuenta);
        Response.Redirect("default.aspx");
    }
}
