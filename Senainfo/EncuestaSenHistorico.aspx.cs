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

public partial class EncuestaSenHistorico : System.Web.UI.Page
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
            //grdPregunta01.DataSource = dtEncuestas;
            dtEncuestas.Tables[0].DefaultView.RowFilter = "CodPregunta = " + Convert.ToString(dtEncuestasPreguntas.Tables[0].Rows[0]["CodPregunta"]);
            //grdPregunta01.DataBind();
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
    protected void LlenaPreguntas(int NumeroRow)
    {
        lblPregunta.Text = (string)dtEncuestasPreguntas.Tables[0].Rows[NumeroRow]["Pregunta"];
        string Opcion = "";
        if (NumeroRow == 0)
        {
            Opcion = "rdb_" + Convert.ToString(NumeroRow + 1);
            string rb = Request[Opcion];

        }
    }
    public DataSet GetEncuestas()
    {
        EncuestasColl ecoll = new EncuestasColl();
        DataSet dtEncuestas = new DataSet();
        dtEncuestas.Tables.Add(ecoll.GetData());
        return dtEncuestas;
    }

    protected void btnAnterior_Click(object sender, EventArgs e)
    {
        NumeroRow -= 1;
        if (pnlPregunta03.Visible && rdb_1b.Checked)
            NumeroRow -= 1;

        if (pnlPregunta07.Visible)
            if (rdb_4b.Checked || rdb_4c.Checked)
                NumeroRow = NumeroRow;
            else
                if (rdb_4a.Checked || rdb_4c.Checked)
                    NumeroRow -= 1;

        if (pnlPregunta06.Visible && !(rdb_4a.Checked || rdb_4c.Checked))
                    NumeroRow -= 1;


        pnlPregunta01.Visible = false;
        pnlPregunta02.Visible = false;
        pnlPregunta03.Visible = false;
        pnlPregunta04.Visible = false;
        pnlPregunta05.Visible = false;
        pnlPregunta06.Visible = false;
        pnlPregunta07.Visible = false;
        btnGrabar.Visible = false;
        btnSiguiente.Visible = true;

        switch (NumeroRow)
        {
            case 0:
                pnlPregunta01.Visible = true;
                btnAnterior.Visible = false;
                btnSiguiente.Visible = true;
                break;
            case 1:
                pnlPregunta02.Visible = true;
                break;
            case 2:
                pnlPregunta03.Visible = true;
                break;
            case 3:
                pnlPregunta04.Visible = true;
                break;
            case 4:
                pnlPregunta05.Visible = true;
                break;
            case 5:
                pnlPregunta06.Visible = true;
                break;
            case 6:
                pnlPregunta07.Visible = true;
                break;
            default:
                pnlPregunta04.Visible = true;
                break;
        }

        LlenaPreguntas(NumeroRow);
    }
    protected void btnSiguiente_Click(object sender, EventArgs e)
    {
        if (pnlPregunta06.Visible)
        {
            pnlPregunta07.Visible = true;
            btnSiguiente.Visible = false;
            btnGrabar.Visible = true;
            pnlPregunta06.Visible = false;
        }

        if (pnlPregunta05.Visible)
        {
            if (rdb_4b.Checked || rdb_4c.Checked)
                pnlPregunta06.Visible = true;
            else
            {
                pnlPregunta07.Visible = true;
                NumeroRow += 1;
                btnSiguiente.Visible = false;
                btnGrabar.Visible = true;
            }
            pnlPregunta05.Visible = false;
        }
        //if (pnlPregunta04.Visible && (chk_4a.Checked || chk_4b.Checked || chk_4c.Checked))
        if (pnlPregunta04.Visible)
        {
            if (!(rdb_4a.Checked || rdb_4b.Checked  || rdb_4c.Checked))
                return;

            if (rdb_4a.Checked || rdb_4c.Checked)
            {
                pnlPregunta05.Visible = true;
            }
            else
                if (rdb_4b.Checked || rdb_4c.Checked)
                {
                    NumeroRow += 1;
                    pnlPregunta06.Visible = true;
                }
                else
                {
                    NumeroRow += 2;
                    pnlPregunta07.Visible = true;
                    btnSiguiente.Visible = false;
                    btnGrabar.Visible = true;
                }

            pnlPregunta04.Visible = false;
        }
        //if (pnlPregunta03.Visible && (chk_3a1.Checked || chk_3a2.Checked || chk_3b1.Checked || chk_3b2.Checked))
        if (pnlPregunta03.Visible)
        {
            pnlPregunta04.Visible = true;
            pnlPregunta03.Visible = false;
        }
        //        if (pnlPregunta02.Visible && (chk_2a.Checked || chk_2b.Checked || chk_2c.Checked || chk_2d.Checked || chk_2e.Checked || chk_2f.Checked || chk_2g.Checked))
        if (pnlPregunta02.Visible)
        {
            pnlPregunta03.Visible = true;
            pnlPregunta02.Visible = false;
        }
        if (pnlPregunta01.Visible)  // && (rdb_1a.Checked || rdb_1b.Checked))       //(chk_1a.Checked || chk_1b.Checked))
        {
            if (rdb_1a.Checked)
            {
                pnlPregunta02.Visible = true;
                btnSiguiente.Visible = false;
                btnGrabar.Visible = true;
            }
            else
            {
                if (rdb_1b.Checked)
                {
                    NumeroRow += 1;
                    pnlPregunta03.Visible = true;
                }
                else
                    return;
            }

            pnlPregunta01.Visible = false;
            btnAnterior.Visible = true;
        }
        NumeroRow += 1;
        LlenaPreguntas(NumeroRow);
    }
    protected void btnGrabar_Click(object sender, EventArgs e)
    {
        dtEncuestas.Tables[0].DefaultView.RowFilter = "";

        //------------- 1 ---------------------------------
        if (rdb_1a.Checked)
            dtEncuestas.Tables[0].Rows[0]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[0]["Nota"] = 0;

        if (rdb_1b.Checked)
            dtEncuestas.Tables[0].Rows[1]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[1]["Nota"] = 0;
        //------------- 2 ---------------------------------
        if (rdb_2a.Checked)
            dtEncuestas.Tables[0].Rows[2]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[2]["Nota"] = 0;

        if (rdb_2b.Checked)
            dtEncuestas.Tables[0].Rows[3]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[3]["Nota"] = 0;

        if (rdb_2c.Checked)
            dtEncuestas.Tables[0].Rows[4]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[4]["Nota"] = 0;

        if (rdb_2d.Checked)
            dtEncuestas.Tables[0].Rows[5]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[5]["Nota"] = 0;

        if (rdb_2e.Checked)
            dtEncuestas.Tables[0].Rows[6]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[6]["Nota"] = 0;

        if (rdb_2f.Checked)
            dtEncuestas.Tables[0].Rows[7]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[7]["Nota"] = 0;

        if (rdb_2g.Checked)
        {
            dtEncuestas.Tables[0].Rows[8]["Nota"] = 1;
            dtEncuestas.Tables[0].Rows[8]["Observaciones"] = txtObservacionPregunta02.Text;
        }
        else
            dtEncuestas.Tables[0].Rows[8]["Nota"] = 0;
        //------------- 3 ---------------------------------
        if (rdb_3a1.Checked)
            dtEncuestas.Tables[0].Rows[9]["Nota"] = 1;
        else
            if (rdb_3a2.Checked)
                dtEncuestas.Tables[0].Rows[9]["Nota"] = 2;

        if (rdb_3b1.Checked)
            dtEncuestas.Tables[0].Rows[10]["Nota"] = 1;
        else
            if (rdb_3b2.Checked)
                dtEncuestas.Tables[0].Rows[10]["Nota"] = 2;
        //------------- 4 ---------------------------------
        if (rdb_4a.Checked)
            dtEncuestas.Tables[0].Rows[11]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[11]["Nota"] = 0;

        if (rdb_4b.Checked)
            dtEncuestas.Tables[0].Rows[12]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[12]["Nota"] = 0;

        if (rdb_4c.Checked)
            dtEncuestas.Tables[0].Rows[13]["Nota"] = 1;
        else
            dtEncuestas.Tables[0].Rows[13]["Nota"] = 0;

        //------------- 5 ---------------------------------
        if (rdb_5a1.Checked)
            dtEncuestas.Tables[0].Rows[14]["Nota"] = 1;
        else
            if (rdb_5a2.Checked)
                dtEncuestas.Tables[0].Rows[14]["Nota"] = 2;
            else
                if (rdb_5a3.Checked)
                    dtEncuestas.Tables[0].Rows[14]["Nota"] = 3;
                else
                    if (rdb_5a4.Checked)
                        dtEncuestas.Tables[0].Rows[14]["Nota"] = 4;
                    else
                        if (rdb_5a5.Checked)
                            dtEncuestas.Tables[0].Rows[14]["Nota"] = 5;
                        else
                            if (rdb_5a6.Checked)
                                dtEncuestas.Tables[0].Rows[14]["Nota"] = 6;

        if (rdb_5b1.Checked)
            dtEncuestas.Tables[0].Rows[15]["Nota"] = 1;
        else
            if (rdb_5b2.Checked)
                dtEncuestas.Tables[0].Rows[15]["Nota"] = 2;
            else
                if (rdb_5b3.Checked)
                    dtEncuestas.Tables[0].Rows[15]["Nota"] = 3;
                else
                    if (rdb_5b4.Checked)
                        dtEncuestas.Tables[0].Rows[15]["Nota"] = 4;
                    else
                        if (rdb_5b5.Checked)
                            dtEncuestas.Tables[0].Rows[15]["Nota"] = 5;
                        else
                            if (rdb_5b6.Checked)
                                dtEncuestas.Tables[0].Rows[15]["Nota"] = 6;

        if (rdb_5c1.Checked)
            dtEncuestas.Tables[0].Rows[16]["Nota"] = 1;
        else
            if (rdb_5c2.Checked)
                dtEncuestas.Tables[0].Rows[16]["Nota"] = 2;
            else
                if (rdb_5c3.Checked)
                    dtEncuestas.Tables[0].Rows[16]["Nota"] = 3;
                else
                    if (rdb_5c4.Checked)
                        dtEncuestas.Tables[0].Rows[16]["Nota"] = 4;
                    else
                        if (rdb_5c5.Checked)
                            dtEncuestas.Tables[0].Rows[16]["Nota"] = 5;
                        else
                            if (rdb_5c6.Checked)
                                dtEncuestas.Tables[0].Rows[16]["Nota"] = 6;

        if (rdb_5d1.Checked)
            dtEncuestas.Tables[0].Rows[17]["Nota"] = 1;
        else
            if (rdb_5d2.Checked)
                dtEncuestas.Tables[0].Rows[17]["Nota"] = 2;
            else
                if (rdb_5d3.Checked)
                    dtEncuestas.Tables[0].Rows[17]["Nota"] = 3;
                else
                    if (rdb_5d4.Checked)
                        dtEncuestas.Tables[0].Rows[17]["Nota"] = 4;
                    else
                        if (rdb_5d5.Checked)
                            dtEncuestas.Tables[0].Rows[17]["Nota"] = 5;
                        else
                            if (rdb_5d6.Checked)
                                dtEncuestas.Tables[0].Rows[17]["Nota"] = 6;

        if (rdb_5e1.Checked)
            dtEncuestas.Tables[0].Rows[18]["Nota"] = 1;
        else
            if (rdb_5e2.Checked)
                dtEncuestas.Tables[0].Rows[18]["Nota"] = 2;
            else
                if (rdb_5e3.Checked)
                    dtEncuestas.Tables[0].Rows[18]["Nota"] = 3;
                else
                    if (rdb_5e4.Checked)
                        dtEncuestas.Tables[0].Rows[18]["Nota"] = 4;
                    else
                        if (rdb_5e5.Checked)
                            dtEncuestas.Tables[0].Rows[18]["Nota"] = 5;
                        else
                            if (rdb_5e6.Checked)
                                dtEncuestas.Tables[0].Rows[18]["Nota"] = 6;

        if (rdb_5f1.Checked)
            dtEncuestas.Tables[0].Rows[19]["Nota"] = 1;
        else
            if (rdb_5f2.Checked)
                dtEncuestas.Tables[0].Rows[19]["Nota"] = 2;
            else
                if (rdb_5f3.Checked)
                    dtEncuestas.Tables[0].Rows[19]["Nota"] = 3;
                else
                    if (rdb_5f4.Checked)
                        dtEncuestas.Tables[0].Rows[19]["Nota"] = 4;
                    else
                        if (rdb_5f5.Checked)
                            dtEncuestas.Tables[0].Rows[19]["Nota"] = 5;
                        else
                            if (rdb_5f6.Checked)
                                dtEncuestas.Tables[0].Rows[19]["Nota"] = 6;

        if (rdb_5g1.Checked)
            dtEncuestas.Tables[0].Rows[20]["Nota"] = 1;
        else
            if (rdb_5g2.Checked)
                dtEncuestas.Tables[0].Rows[20]["Nota"] = 2;
            else
                if (rdb_5g3.Checked)
                    dtEncuestas.Tables[0].Rows[20]["Nota"] = 3;
                else
                    if (rdb_5g4.Checked)
                        dtEncuestas.Tables[0].Rows[20]["Nota"] = 4;
                    else
                        if (rdb_5g5.Checked)
                            dtEncuestas.Tables[0].Rows[20]["Nota"] = 5;
                        else
                            if (rdb_5g6.Checked)
                                dtEncuestas.Tables[0].Rows[20]["Nota"] = 6;

        if (rdb_5h1.Checked)
            dtEncuestas.Tables[0].Rows[21]["Nota"] = 1;
        else
            if (rdb_5h2.Checked)
                dtEncuestas.Tables[0].Rows[21]["Nota"] = 2;
            else
                if (rdb_5h3.Checked)
                    dtEncuestas.Tables[0].Rows[21]["Nota"] = 3;
                else
                    if (rdb_5h4.Checked)
                        dtEncuestas.Tables[0].Rows[21]["Nota"] = 4;
                    else
                        if (rdb_5h5.Checked)
                            dtEncuestas.Tables[0].Rows[21]["Nota"] = 5;
                        else
                            if (rdb_5h6.Checked)
                                dtEncuestas.Tables[0].Rows[21]["Nota"] = 6;

        if (rdb_5i1.Checked)
            dtEncuestas.Tables[0].Rows[22]["Nota"] = 1;
        else
            if (rdb_5i2.Checked)
                dtEncuestas.Tables[0].Rows[22]["Nota"] = 2;
            else
                if (rdb_5i3.Checked)
                    dtEncuestas.Tables[0].Rows[22]["Nota"] = 3;
                else
                    if (rdb_5i4.Checked)
                        dtEncuestas.Tables[0].Rows[22]["Nota"] = 4;
                    else
                        if (rdb_5i5.Checked)
                            dtEncuestas.Tables[0].Rows[22]["Nota"] = 5;
                        else
                            if (rdb_5i6.Checked)
                                dtEncuestas.Tables[0].Rows[22]["Nota"] = 6;

        if (rdb_5j1.Checked)
            dtEncuestas.Tables[0].Rows[23]["Nota"] = 1;
        else
            if (rdb_5j2.Checked)
                dtEncuestas.Tables[0].Rows[23]["Nota"] = 2;
            else
                if (rdb_5j3.Checked)
                    dtEncuestas.Tables[0].Rows[23]["Nota"] = 3;
                else
                    if (rdb_5j4.Checked)
                        dtEncuestas.Tables[0].Rows[23]["Nota"] = 4;
                    else
                        if (rdb_5j5.Checked)
                            dtEncuestas.Tables[0].Rows[23]["Nota"] = 5;
                        else
                            if (rdb_5j6.Checked)
                                dtEncuestas.Tables[0].Rows[23]["Nota"] = 6;

        if (rdb_5k1.Checked)
            dtEncuestas.Tables[0].Rows[24]["Nota"] = 1;
        else
            if (rdb_5k2.Checked)
                dtEncuestas.Tables[0].Rows[24]["Nota"] = 2;
            else
                if (rdb_5k3.Checked)
                    dtEncuestas.Tables[0].Rows[24]["Nota"] = 3;
                else
                    if (rdb_5k4.Checked)
                        dtEncuestas.Tables[0].Rows[24]["Nota"] = 4;
                    else
                        if (rdb_5k5.Checked)
                            dtEncuestas.Tables[0].Rows[24]["Nota"] = 5;
                        else
                            if (rdb_5k6.Checked)
                                dtEncuestas.Tables[0].Rows[24]["Nota"] = 6;

        if (rdb_5l1.Checked)
            dtEncuestas.Tables[0].Rows[25]["Nota"] = 1;
        else
            if (rdb_5l2.Checked)
                dtEncuestas.Tables[0].Rows[25]["Nota"] = 2;
            else
                if (rdb_5l3.Checked)
                    dtEncuestas.Tables[0].Rows[25]["Nota"] = 3;
                else
                    if (rdb_5l4.Checked)
                        dtEncuestas.Tables[0].Rows[25]["Nota"] = 4;
                    else
                        if (rdb_5l5.Checked)
                            dtEncuestas.Tables[0].Rows[25]["Nota"] = 5;
                        else
                            if (rdb_5l6.Checked)
                                dtEncuestas.Tables[0].Rows[25]["Nota"] = 6;

        if (rdb_5ll1.Checked)
            dtEncuestas.Tables[0].Rows[26]["Nota"] = 1;
        else
            if (rdb_5ll2.Checked)
                dtEncuestas.Tables[0].Rows[26]["Nota"] = 2;
            else
                if (rdb_5ll3.Checked)
                    dtEncuestas.Tables[0].Rows[26]["Nota"] = 3;
                else
                    if (rdb_5ll4.Checked)
                        dtEncuestas.Tables[0].Rows[26]["Nota"] = 4;
                    else
                        if (rdb_5ll5.Checked)
                            dtEncuestas.Tables[0].Rows[26]["Nota"] = 5;
                        else
                            if (rdb_5ll6.Checked)
                                dtEncuestas.Tables[0].Rows[26]["Nota"] = 6;

        if (rdb_5m1.Checked)
            dtEncuestas.Tables[0].Rows[27]["Nota"] = 1;
        else
            if (rdb_5m2.Checked)
                dtEncuestas.Tables[0].Rows[27]["Nota"] = 2;
            else
                if (rdb_5m3.Checked)
                    dtEncuestas.Tables[0].Rows[27]["Nota"] = 3;
                else
                    if (rdb_5m4.Checked)
                        dtEncuestas.Tables[0].Rows[27]["Nota"] = 4;
                    else
                        if (rdb_5m5.Checked)
                            dtEncuestas.Tables[0].Rows[27]["Nota"] = 5;
                        else
                            if (rdb_5m6.Checked)
                                dtEncuestas.Tables[0].Rows[27]["Nota"] = 6;

        if (rdb_5n1.Checked)
            dtEncuestas.Tables[0].Rows[28]["Nota"] = 1;
        else
            if (rdb_5n2.Checked)
                dtEncuestas.Tables[0].Rows[28]["Nota"] = 2;
            else
                if (rdb_5n3.Checked)
                    dtEncuestas.Tables[0].Rows[28]["Nota"] = 3;
                else
                    if (rdb_5n4.Checked)
                        dtEncuestas.Tables[0].Rows[28]["Nota"] = 4;
                    else
                        if (rdb_5n5.Checked)
                            dtEncuestas.Tables[0].Rows[28]["Nota"] = 5;
                        else
                            if (rdb_5n6.Checked)
                                dtEncuestas.Tables[0].Rows[28]["Nota"] = 6;

        if (rdb_5o1.Checked)
            dtEncuestas.Tables[0].Rows[29]["Nota"] = 1;
        else
            if (rdb_5o2.Checked)
                dtEncuestas.Tables[0].Rows[29]["Nota"] = 2;
            else
                if (rdb_5o3.Checked)
                    dtEncuestas.Tables[0].Rows[29]["Nota"] = 3;
                else
                    if (rdb_5o4.Checked)
                        dtEncuestas.Tables[0].Rows[29]["Nota"] = 4;
                    else
                        if (rdb_5o5.Checked)
                            dtEncuestas.Tables[0].Rows[29]["Nota"] = 5;
                        else
                            if (rdb_5o6.Checked)
                                dtEncuestas.Tables[0].Rows[29]["Nota"] = 6;

        if (rdb_5p1.Checked)
            dtEncuestas.Tables[0].Rows[30]["Nota"] = 1;
        else
            if (rdb_5p2.Checked)
                dtEncuestas.Tables[0].Rows[30]["Nota"] = 2;
            else
                if (rdb_5p3.Checked)
                    dtEncuestas.Tables[0].Rows[30]["Nota"] = 3;
                else
                    if (rdb_5p4.Checked)
                        dtEncuestas.Tables[0].Rows[30]["Nota"] = 4;
                    else
                        if (rdb_5p5.Checked)
                            dtEncuestas.Tables[0].Rows[30]["Nota"] = 5;
                        else
                            if (rdb_5p6.Checked)
                                dtEncuestas.Tables[0].Rows[30]["Nota"] = 6;

        if (rdb_5q1.Checked)
            dtEncuestas.Tables[0].Rows[31]["Nota"] = 1;
        else
            if (rdb_5q2.Checked)
                dtEncuestas.Tables[0].Rows[31]["Nota"] = 2;
            else
                if (rdb_5q3.Checked)
                    dtEncuestas.Tables[0].Rows[31]["Nota"] = 3;
                else
                    if (rdb_5q4.Checked)
                        dtEncuestas.Tables[0].Rows[31]["Nota"] = 4;
                    else
                        if (rdb_5q5.Checked)
                            dtEncuestas.Tables[0].Rows[31]["Nota"] = 5;
                        else
                            if (rdb_5q6.Checked)
                                dtEncuestas.Tables[0].Rows[31]["Nota"] = 6;

        if (rdb_5r1.Checked)
            dtEncuestas.Tables[0].Rows[32]["Nota"] = 1;
        else
            if (rdb_5r2.Checked)
                dtEncuestas.Tables[0].Rows[32]["Nota"] = 2;
            else
                if (rdb_5r3.Checked)
                    dtEncuestas.Tables[0].Rows[32]["Nota"] = 3;
                else
                    if (rdb_5r4.Checked)
                        dtEncuestas.Tables[0].Rows[32]["Nota"] = 4;
                    else
                        if (rdb_5r5.Checked)
                            dtEncuestas.Tables[0].Rows[32]["Nota"] = 5;
                        else
                            if (rdb_5r6.Checked)
                                dtEncuestas.Tables[0].Rows[32]["Nota"] = 6;

        if (rdb_5s1.Checked)
            dtEncuestas.Tables[0].Rows[33]["Nota"] = 1;
        else
            if (rdb_5s2.Checked)
                dtEncuestas.Tables[0].Rows[33]["Nota"] = 2;
            else
                if (rdb_5s3.Checked)
                    dtEncuestas.Tables[0].Rows[33]["Nota"] = 3;
                else
                    if (rdb_5s4.Checked)
                        dtEncuestas.Tables[0].Rows[33]["Nota"] = 4;
                    else
                        if (rdb_5s5.Checked)
                            dtEncuestas.Tables[0].Rows[33]["Nota"] = 5;
                        else
                            if (rdb_5s6.Checked)
                                dtEncuestas.Tables[0].Rows[33]["Nota"] = 6;

        if (rdb_5t1.Checked)
            dtEncuestas.Tables[0].Rows[34]["Nota"] = 1;
        else
            if (rdb_5t2.Checked)
                dtEncuestas.Tables[0].Rows[34]["Nota"] = 2;
            else
                if (rdb_5t3.Checked)
                    dtEncuestas.Tables[0].Rows[34]["Nota"] = 3;
                else
                    if (rdb_5t4.Checked)
                        dtEncuestas.Tables[0].Rows[34]["Nota"] = 4;
                    else
                        if (rdb_5t5.Checked)
                            dtEncuestas.Tables[0].Rows[34]["Nota"] = 5;
                        else
                            if (rdb_5t6.Checked)
                                dtEncuestas.Tables[0].Rows[34]["Nota"] = 6;

        if (rdb_5u1.Checked)
            dtEncuestas.Tables[0].Rows[35]["Nota"] = 1;
        else
            if (rdb_5u2.Checked)
                dtEncuestas.Tables[0].Rows[35]["Nota"] = 2;
            else
                if (rdb_5u3.Checked)
                    dtEncuestas.Tables[0].Rows[35]["Nota"] = 3;
                else
                    if (rdb_5u4.Checked)
                        dtEncuestas.Tables[0].Rows[35]["Nota"] = 4;
                    else
                        if (rdb_5u5.Checked)
                            dtEncuestas.Tables[0].Rows[35]["Nota"] = 5;
                        else
                            if (rdb_5u6.Checked)
                                dtEncuestas.Tables[0].Rows[35]["Nota"] = 6;

        if (rdb_5v1.Checked)
            dtEncuestas.Tables[0].Rows[36]["Nota"] = 1;
        else
            if (rdb_5v2.Checked)
                dtEncuestas.Tables[0].Rows[36]["Nota"] = 2;
            else
                if (rdb_5v3.Checked)
                    dtEncuestas.Tables[0].Rows[36]["Nota"] = 3;
                else
                    if (rdb_5v4.Checked)
                        dtEncuestas.Tables[0].Rows[36]["Nota"] = 4;
                    else
                        if (rdb_5v5.Checked)
                            dtEncuestas.Tables[0].Rows[36]["Nota"] = 5;
                        else
                            if (rdb_5v6.Checked)
                                dtEncuestas.Tables[0].Rows[36]["Nota"] = 6;

        if (rdb_5w1.Checked)
            dtEncuestas.Tables[0].Rows[37]["Nota"] = 1;
        else
            if (rdb_5w2.Checked)
                dtEncuestas.Tables[0].Rows[37]["Nota"] = 2;
            else
                if (rdb_5w3.Checked)
                    dtEncuestas.Tables[0].Rows[37]["Nota"] = 3;
                else
                    if (rdb_5w4.Checked)
                        dtEncuestas.Tables[0].Rows[37]["Nota"] = 4;
                    else
                        if (rdb_5w5.Checked)
                            dtEncuestas.Tables[0].Rows[37]["Nota"] = 5;
                        else
                            if (rdb_5w6.Checked)
                                dtEncuestas.Tables[0].Rows[37]["Nota"] = 6;

        if (rdb_5x1.Checked)
            dtEncuestas.Tables[0].Rows[38]["Nota"] = 1;
        else
            if (rdb_5x2.Checked)
                dtEncuestas.Tables[0].Rows[38]["Nota"] = 2;
            else
                if (rdb_5x3.Checked)
                    dtEncuestas.Tables[0].Rows[38]["Nota"] = 3;
                else
                    if (rdb_5x4.Checked)
                        dtEncuestas.Tables[0].Rows[38]["Nota"] = 4;
                    else
                        if (rdb_5x5.Checked)
                            dtEncuestas.Tables[0].Rows[38]["Nota"] = 5;
                        else
                            if (rdb_5x6.Checked)
                                dtEncuestas.Tables[0].Rows[38]["Nota"] = 6;

        if (rdb_5y1.Checked)
            dtEncuestas.Tables[0].Rows[39]["Nota"] = 1;
        else
            if (rdb_5y2.Checked)
                dtEncuestas.Tables[0].Rows[39]["Nota"] = 2;
            else
                if (rdb_5y3.Checked)
                    dtEncuestas.Tables[0].Rows[39]["Nota"] = 3;
                else
                    if (rdb_5y4.Checked)
                        dtEncuestas.Tables[0].Rows[39]["Nota"] = 4;
                    else
                        if (rdb_5y5.Checked)
                            dtEncuestas.Tables[0].Rows[39]["Nota"] = 5;
                        else
                            if (rdb_5y6.Checked)
                                dtEncuestas.Tables[0].Rows[39]["Nota"] = 6;

        if (rdb_5z1.Checked)
            dtEncuestas.Tables[0].Rows[40]["Nota"] = 1;
        else
            if (rdb_5z2.Checked)
                dtEncuestas.Tables[0].Rows[40]["Nota"] = 2;
            else
                if (rdb_5z3.Checked)
                    dtEncuestas.Tables[0].Rows[40]["Nota"] = 3;
                else
                    if (rdb_5z4.Checked)
                        dtEncuestas.Tables[0].Rows[40]["Nota"] = 4;
                    else
                        if (rdb_5z5.Checked)
                            dtEncuestas.Tables[0].Rows[40]["Nota"] = 5;
                        else
                            if (rdb_5z6.Checked)
                                dtEncuestas.Tables[0].Rows[40]["Nota"] = 6;
        //------------- 6 ---------------------------------
        if (rdb_6a1.Checked)
            dtEncuestas.Tables[0].Rows[41]["Nota"] = 1;
        else
            if (rdb_6a2.Checked)
                dtEncuestas.Tables[0].Rows[41]["Nota"] = 2;
            else
                if (rdb_6a3.Checked)
                    dtEncuestas.Tables[0].Rows[41]["Nota"] = 3;
                else
                    if (rdb_6a4.Checked)
                        dtEncuestas.Tables[0].Rows[41]["Nota"] = 4;
                    else
                        if (rdb_6a5.Checked)
                            dtEncuestas.Tables[0].Rows[41]["Nota"] = 5;
                        else
                            if (rdb_6a6.Checked)
                                dtEncuestas.Tables[0].Rows[41]["Nota"] = 6;

        if (rdb_6b1.Checked)
            dtEncuestas.Tables[0].Rows[42]["Nota"] = 1;
        else
            if (rdb_6b2.Checked)
                dtEncuestas.Tables[0].Rows[42]["Nota"] = 2;
            else
                if (rdb_6b3.Checked)
                    dtEncuestas.Tables[0].Rows[42]["Nota"] = 3;
                else
                    if (rdb_6b4.Checked)
                        dtEncuestas.Tables[0].Rows[42]["Nota"] = 4;
                    else
                        if (rdb_6b5.Checked)
                            dtEncuestas.Tables[0].Rows[42]["Nota"] = 5;
                        else
                            if (rdb_6b6.Checked)
                                dtEncuestas.Tables[0].Rows[42]["Nota"] = 6;

        if (rdb_6c1.Checked)
            dtEncuestas.Tables[0].Rows[43]["Nota"] = 1;
        else
            if (rdb_6c2.Checked)
                dtEncuestas.Tables[0].Rows[43]["Nota"] = 2;
            else
                if (rdb_6c3.Checked)
                    dtEncuestas.Tables[0].Rows[43]["Nota"] = 3;
                else
                    if (rdb_6c4.Checked)
                        dtEncuestas.Tables[0].Rows[43]["Nota"] = 4;
                    else
                        if (rdb_6c5.Checked)
                            dtEncuestas.Tables[0].Rows[43]["Nota"] = 5;
                        else
                            if (rdb_6c6.Checked)
                                dtEncuestas.Tables[0].Rows[43]["Nota"] = 6;

        if (rdb_6d1.Checked)
            dtEncuestas.Tables[0].Rows[44]["Nota"] = 1;
        else
            if (rdb_6d2.Checked)
                dtEncuestas.Tables[0].Rows[44]["Nota"] = 2;
            else
                if (rdb_6d3.Checked)
                    dtEncuestas.Tables[0].Rows[44]["Nota"] = 3;
                else
                    if (rdb_6d4.Checked)
                        dtEncuestas.Tables[0].Rows[44]["Nota"] = 4;
                    else
                        if (rdb_6d5.Checked)
                            dtEncuestas.Tables[0].Rows[44]["Nota"] = 5;
                        else
                            if (rdb_6d6.Checked)
                                dtEncuestas.Tables[0].Rows[44]["Nota"] = 6;

        if (rdb_6e1.Checked)
            dtEncuestas.Tables[0].Rows[45]["Nota"] = 1;
        else
            if (rdb_6e2.Checked)
                dtEncuestas.Tables[0].Rows[45]["Nota"] = 2;
            else
                if (rdb_6e3.Checked)
                    dtEncuestas.Tables[0].Rows[45]["Nota"] = 3;
                else
                    if (rdb_6e4.Checked)
                        dtEncuestas.Tables[0].Rows[45]["Nota"] = 4;
                    else
                        if (rdb_6e5.Checked)
                            dtEncuestas.Tables[0].Rows[45]["Nota"] = 5;
                        else
                            if (rdb_6e6.Checked)
                                dtEncuestas.Tables[0].Rows[45]["Nota"] = 6;

        if (rdb_6f1.Checked)
            dtEncuestas.Tables[0].Rows[46]["Nota"] = 1;
        else
            if (rdb_6f2.Checked)
                dtEncuestas.Tables[0].Rows[46]["Nota"] = 2;
            else
                if (rdb_6f3.Checked)
                    dtEncuestas.Tables[0].Rows[46]["Nota"] = 3;
                else
                    if (rdb_6f4.Checked)
                        dtEncuestas.Tables[0].Rows[46]["Nota"] = 4;
                    else
                        if (rdb_6f5.Checked)
                            dtEncuestas.Tables[0].Rows[46]["Nota"] = 5;
                        else
                            if (rdb_6f6.Checked)
                                dtEncuestas.Tables[0].Rows[46]["Nota"] = 6;

        if (rdb_6g1.Checked)
            dtEncuestas.Tables[0].Rows[47]["Nota"] = 1;
        else
            if (rdb_6g2.Checked)
                dtEncuestas.Tables[0].Rows[47]["Nota"] = 2;
            else
                if (rdb_6g3.Checked)
                    dtEncuestas.Tables[0].Rows[47]["Nota"] = 3;
                else
                    if (rdb_6g4.Checked)
                        dtEncuestas.Tables[0].Rows[47]["Nota"] = 4;
                    else
                        if (rdb_6g5.Checked)
                            dtEncuestas.Tables[0].Rows[47]["Nota"] = 5;
                        else
                            if (rdb_6g6.Checked)
                                dtEncuestas.Tables[0].Rows[47]["Nota"] = 6;

        if (rdb_6h1.Checked)
            dtEncuestas.Tables[0].Rows[48]["Nota"] = 1;
        else
            if (rdb_6h2.Checked)
                dtEncuestas.Tables[0].Rows[48]["Nota"] = 2;
            else
                if (rdb_6h3.Checked)
                    dtEncuestas.Tables[0].Rows[48]["Nota"] = 3;
                else
                    if (rdb_6h4.Checked)
                        dtEncuestas.Tables[0].Rows[48]["Nota"] = 4;
                    else
                        if (rdb_6h5.Checked)
                            dtEncuestas.Tables[0].Rows[48]["Nota"] = 5;
                        else
                            if (rdb_6h6.Checked)
                                dtEncuestas.Tables[0].Rows[48]["Nota"] = 6;

        if (rdb_6i1.Checked)
            dtEncuestas.Tables[0].Rows[49]["Nota"] = 1;
        else
            if (rdb_6i2.Checked)
                dtEncuestas.Tables[0].Rows[49]["Nota"] = 2;
            else
                if (rdb_6i3.Checked)
                    dtEncuestas.Tables[0].Rows[49]["Nota"] = 3;
                else
                    if (rdb_6i4.Checked)
                        dtEncuestas.Tables[0].Rows[49]["Nota"] = 4;
                    else
                        if (rdb_6i5.Checked)
                            dtEncuestas.Tables[0].Rows[49]["Nota"] = 5;
                        else
                            if (rdb_6i6.Checked)
                                dtEncuestas.Tables[0].Rows[49]["Nota"] = 6;

        if (rdb_6j1.Checked)
            dtEncuestas.Tables[0].Rows[50]["Nota"] = 1;
        else
            if (rdb_6j2.Checked)
                dtEncuestas.Tables[0].Rows[50]["Nota"] = 2;
            else
                if (rdb_6j3.Checked)
                    dtEncuestas.Tables[0].Rows[50]["Nota"] = 3;
                else
                    if (rdb_6j4.Checked)
                        dtEncuestas.Tables[0].Rows[50]["Nota"] = 4;
                    else
                        if (rdb_6j5.Checked)
                            dtEncuestas.Tables[0].Rows[50]["Nota"] = 5;
                        else
                            if (rdb_6j6.Checked)
                                dtEncuestas.Tables[0].Rows[50]["Nota"] = 6;

        if (rdb_6k1.Checked)
            dtEncuestas.Tables[0].Rows[51]["Nota"] = 1;
        else
            if (rdb_6k2.Checked)
                dtEncuestas.Tables[0].Rows[51]["Nota"] = 2;
            else
                if (rdb_6k3.Checked)
                    dtEncuestas.Tables[0].Rows[51]["Nota"] = 3;
                else
                    if (rdb_6k4.Checked)
                        dtEncuestas.Tables[0].Rows[51]["Nota"] = 4;
                    else
                        if (rdb_6k5.Checked)
                            dtEncuestas.Tables[0].Rows[51]["Nota"] = 5;
                        else
                            if (rdb_6k6.Checked)
                                dtEncuestas.Tables[0].Rows[51]["Nota"] = 6;

        if (rdb_6l1.Checked)
            dtEncuestas.Tables[0].Rows[52]["Nota"] = 1;
        else
            if (rdb_6l2.Checked)
                dtEncuestas.Tables[0].Rows[52]["Nota"] = 2;
            else
                if (rdb_6l3.Checked)
                    dtEncuestas.Tables[0].Rows[52]["Nota"] = 3;
                else
                    if (rdb_6l4.Checked)
                        dtEncuestas.Tables[0].Rows[52]["Nota"] = 4;
                    else
                        if (rdb_6l5.Checked)
                            dtEncuestas.Tables[0].Rows[52]["Nota"] = 5;
                        else
                            if (rdb_6l6.Checked)
                                dtEncuestas.Tables[0].Rows[52]["Nota"] = 6;

        if (rdb_6ll1.Checked)
            dtEncuestas.Tables[0].Rows[53]["Nota"] = 1;
        else
            if (rdb_6ll2.Checked)
                dtEncuestas.Tables[0].Rows[53]["Nota"] = 2;
            else
                if (rdb_6ll3.Checked)
                    dtEncuestas.Tables[0].Rows[53]["Nota"] = 3;
                else
                    if (rdb_6ll4.Checked)
                        dtEncuestas.Tables[0].Rows[53]["Nota"] = 4;
                    else
                        if (rdb_6ll5.Checked)
                            dtEncuestas.Tables[0].Rows[53]["Nota"] = 5;
                        else
                            if (rdb_6ll6.Checked)
                                dtEncuestas.Tables[0].Rows[53]["Nota"] = 6;

        if (rdb_6m1.Checked)
            dtEncuestas.Tables[0].Rows[54]["Nota"] = 1;
        else
            if (rdb_6m2.Checked)
                dtEncuestas.Tables[0].Rows[54]["Nota"] = 2;
            else
                if (rdb_6m3.Checked)
                    dtEncuestas.Tables[0].Rows[54]["Nota"] = 3;
                else
                    if (rdb_6m4.Checked)
                        dtEncuestas.Tables[0].Rows[54]["Nota"] = 4;
                    else
                        if (rdb_6m5.Checked)
                            dtEncuestas.Tables[0].Rows[54]["Nota"] = 5;
                        else
                            if (rdb_6m6.Checked)
                                dtEncuestas.Tables[0].Rows[54]["Nota"] = 6;

        if (rdb_6n1.Checked)
            dtEncuestas.Tables[0].Rows[55]["Nota"] = 1;
        else
            if (rdb_6n2.Checked)
                dtEncuestas.Tables[0].Rows[55]["Nota"] = 2;
            else
                if (rdb_6n3.Checked)
                    dtEncuestas.Tables[0].Rows[55]["Nota"] = 3;
                else
                    if (rdb_6n4.Checked)
                        dtEncuestas.Tables[0].Rows[55]["Nota"] = 4;
                    else
                        if (rdb_6n5.Checked)
                            dtEncuestas.Tables[0].Rows[55]["Nota"] = 5;
                        else
                            if (rdb_6n6.Checked)
                                dtEncuestas.Tables[0].Rows[55]["Nota"] = 6;

        if (rdb_6o1.Checked)
            dtEncuestas.Tables[0].Rows[56]["Nota"] = 1;
        else
            if (rdb_6o2.Checked)
                dtEncuestas.Tables[0].Rows[56]["Nota"] = 2;
            else
                if (rdb_6o3.Checked)
                    dtEncuestas.Tables[0].Rows[56]["Nota"] = 3;
                else
                    if (rdb_6o4.Checked)
                        dtEncuestas.Tables[0].Rows[56]["Nota"] = 4;
                    else
                        if (rdb_6o5.Checked)
                            dtEncuestas.Tables[0].Rows[56]["Nota"] = 5;
                        else
                            if (rdb_6o6.Checked)
                                dtEncuestas.Tables[0].Rows[56]["Nota"] = 6;

        if (rdb_6p1.Checked)
            dtEncuestas.Tables[0].Rows[57]["Nota"] = 1;
        else
            if (rdb_6p2.Checked)
                dtEncuestas.Tables[0].Rows[57]["Nota"] = 2;
            else
                if (rdb_6p3.Checked)
                    dtEncuestas.Tables[0].Rows[57]["Nota"] = 3;
                else
                    if (rdb_6p4.Checked)
                        dtEncuestas.Tables[0].Rows[57]["Nota"] = 4;
                    else
                        if (rdb_6p5.Checked)
                            dtEncuestas.Tables[0].Rows[57]["Nota"] = 5;
                        else
                            if (rdb_6p6.Checked)
                                dtEncuestas.Tables[0].Rows[57]["Nota"] = 6;

        if (rdb_6q1.Checked)
            dtEncuestas.Tables[0].Rows[58]["Nota"] = 1;
        else
            if (rdb_6q2.Checked)
                dtEncuestas.Tables[0].Rows[58]["Nota"] = 2;
            else
                if (rdb_6q3.Checked)
                    dtEncuestas.Tables[0].Rows[58]["Nota"] = 3;
                else
                    if (rdb_6q4.Checked)
                        dtEncuestas.Tables[0].Rows[58]["Nota"] = 4;
                    else
                        if (rdb_6q5.Checked)
                            dtEncuestas.Tables[0].Rows[58]["Nota"] = 5;
                        else
                            if (rdb_6q6.Checked)
                                dtEncuestas.Tables[0].Rows[58]["Nota"] = 6;

        if (rdb_6r1.Checked)
            dtEncuestas.Tables[0].Rows[59]["Nota"] = 1;
        else
            if (rdb_6r2.Checked)
                dtEncuestas.Tables[0].Rows[59]["Nota"] = 2;
            else
                if (rdb_6r3.Checked)
                    dtEncuestas.Tables[0].Rows[59]["Nota"] = 3;
                else
                    if (rdb_6r4.Checked)
                        dtEncuestas.Tables[0].Rows[59]["Nota"] = 4;
                    else
                        if (rdb_6r5.Checked)
                            dtEncuestas.Tables[0].Rows[59]["Nota"] = 5;
                        else
                            if (rdb_6r6.Checked)
                                dtEncuestas.Tables[0].Rows[59]["Nota"] = 6;

        if (rdb_6s1.Checked)
            dtEncuestas.Tables[0].Rows[60]["Nota"] = 1;
        else
            if (rdb_6s2.Checked)
                dtEncuestas.Tables[0].Rows[60]["Nota"] = 2;
            else
                if (rdb_6s3.Checked)
                    dtEncuestas.Tables[0].Rows[60]["Nota"] = 3;
                else
                    if (rdb_6s4.Checked)
                        dtEncuestas.Tables[0].Rows[60]["Nota"] = 4;
                    else
                        if (rdb_6s5.Checked)
                            dtEncuestas.Tables[0].Rows[60]["Nota"] = 5;
                        else
                            if (rdb_6s6.Checked)
                                dtEncuestas.Tables[0].Rows[60]["Nota"] = 6;

        if (rdb_6t1.Checked)
            dtEncuestas.Tables[0].Rows[61]["Nota"] = 1;
        else
            if (rdb_6t2.Checked)
                dtEncuestas.Tables[0].Rows[61]["Nota"] = 2;
            else
                if (rdb_6t3.Checked)
                    dtEncuestas.Tables[0].Rows[61]["Nota"] = 3;
                else
                    if (rdb_6t4.Checked)
                        dtEncuestas.Tables[0].Rows[61]["Nota"] = 4;
                    else
                        if (rdb_6t5.Checked)
                            dtEncuestas.Tables[0].Rows[61]["Nota"] = 5;
                        else
                            if (rdb_6t6.Checked)
                                dtEncuestas.Tables[0].Rows[61]["Nota"] = 6;

        if (rdb_6u1.Checked)
            dtEncuestas.Tables[0].Rows[62]["Nota"] = 1;
        else
            if (rdb_6u2.Checked)
                dtEncuestas.Tables[0].Rows[62]["Nota"] = 2;
            else
                if (rdb_6u3.Checked)
                    dtEncuestas.Tables[0].Rows[62]["Nota"] = 3;
                else
                    if (rdb_6u4.Checked)
                        dtEncuestas.Tables[0].Rows[62]["Nota"] = 4;
                    else
                        if (rdb_6u5.Checked)
                            dtEncuestas.Tables[0].Rows[62]["Nota"] = 5;
                        else
                            if (rdb_6u6.Checked)
                                dtEncuestas.Tables[0].Rows[62]["Nota"] = 6;

        if (rdb_6v1.Checked)
            dtEncuestas.Tables[0].Rows[63]["Nota"] = 1;
        else
            if (rdb_6v2.Checked)
                dtEncuestas.Tables[0].Rows[63]["Nota"] = 2;
            else
                if (rdb_6v3.Checked)
                    dtEncuestas.Tables[0].Rows[63]["Nota"] = 3;
                else
                    if (rdb_6v4.Checked)
                        dtEncuestas.Tables[0].Rows[63]["Nota"] = 4;
                    else
                        if (rdb_6v5.Checked)
                            dtEncuestas.Tables[0].Rows[63]["Nota"] = 5;
                        else
                            if (rdb_6v6.Checked)
                                dtEncuestas.Tables[0].Rows[63]["Nota"] = 6;

        if (rdb_6w1.Checked)
            dtEncuestas.Tables[0].Rows[64]["Nota"] = 1;
        else
            if (rdb_6w2.Checked)
                dtEncuestas.Tables[0].Rows[64]["Nota"] = 2;
            else
                if (rdb_6w3.Checked)
                    dtEncuestas.Tables[0].Rows[64]["Nota"] = 3;
                else
                    if (rdb_6w4.Checked)
                        dtEncuestas.Tables[0].Rows[64]["Nota"] = 4;
                    else
                        if (rdb_6w5.Checked)
                            dtEncuestas.Tables[0].Rows[64]["Nota"] = 5;
                        else
                            if (rdb_6w6.Checked)
                                dtEncuestas.Tables[0].Rows[64]["Nota"] = 6;

        if (rdb_6x1.Checked)
            dtEncuestas.Tables[0].Rows[65]["Nota"] = 1;
        else
            if (rdb_6x2.Checked)
                dtEncuestas.Tables[0].Rows[65]["Nota"] = 2;
            else
                if (rdb_6x3.Checked)
                    dtEncuestas.Tables[0].Rows[65]["Nota"] = 3;
                else
                    if (rdb_6x4.Checked)
                        dtEncuestas.Tables[0].Rows[65]["Nota"] = 4;
                    else
                        if (rdb_6x5.Checked)
                            dtEncuestas.Tables[0].Rows[65]["Nota"] = 5;
                        else
                            if (rdb_6x6.Checked)
                                dtEncuestas.Tables[0].Rows[65]["Nota"] = 6;

        if (rdb_6y1.Checked)
            dtEncuestas.Tables[0].Rows[66]["Nota"] = 1;
        else
            if (rdb_6y2.Checked)
                dtEncuestas.Tables[0].Rows[66]["Nota"] = 2;
            else
                if (rdb_6y3.Checked)
                    dtEncuestas.Tables[0].Rows[66]["Nota"] = 3;
                else
                    if (rdb_6y4.Checked)
                        dtEncuestas.Tables[0].Rows[66]["Nota"] = 4;
                    else
                        if (rdb_6y5.Checked)
                            dtEncuestas.Tables[0].Rows[66]["Nota"] = 5;
                        else
                            if (rdb_6y6.Checked)
                                dtEncuestas.Tables[0].Rows[66]["Nota"] = 6;

        if (rdb_6z1.Checked)
            dtEncuestas.Tables[0].Rows[67]["Nota"] = 1;
        else
            if (rdb_6z2.Checked)
                dtEncuestas.Tables[0].Rows[67]["Nota"] = 2;
            else
                if (rdb_6z3.Checked)
                    dtEncuestas.Tables[0].Rows[67]["Nota"] = 3;
                else
                    if (rdb_6z4.Checked)
                        dtEncuestas.Tables[0].Rows[67]["Nota"] = 4;
                    else
                        if (rdb_6z5.Checked)
                            dtEncuestas.Tables[0].Rows[67]["Nota"] = 5;
                        else
                            if (rdb_6z6.Checked)
                                dtEncuestas.Tables[0].Rows[67]["Nota"] = 6;

        if (rdb_6aa1.Checked)
            dtEncuestas.Tables[0].Rows[68]["Nota"] = 1;
        else
            if (rdb_6aa2.Checked)
                dtEncuestas.Tables[0].Rows[68]["Nota"] = 2;
            else
                if (rdb_6aa3.Checked)
                    dtEncuestas.Tables[0].Rows[68]["Nota"] = 3;
                else
                    if (rdb_6aa4.Checked)
                        dtEncuestas.Tables[0].Rows[68]["Nota"] = 4;
                    else
                        if (rdb_6aa5.Checked)
                            dtEncuestas.Tables[0].Rows[68]["Nota"] = 5;
                        else
                            if (rdb_6aa6.Checked)
                                dtEncuestas.Tables[0].Rows[68]["Nota"] = 6;

        if (rdb_6bb1.Checked)
            dtEncuestas.Tables[0].Rows[69]["Nota"] = 1;
        else
            if (rdb_6bb2.Checked)
                dtEncuestas.Tables[0].Rows[69]["Nota"] = 2;
            else
                if (rdb_6bb3.Checked)
                    dtEncuestas.Tables[0].Rows[69]["Nota"] = 3;
                else
                    if (rdb_6bb4.Checked)
                        dtEncuestas.Tables[0].Rows[69]["Nota"] = 4;
                    else
                        if (rdb_6bb5.Checked)
                            dtEncuestas.Tables[0].Rows[69]["Nota"] = 5;
                        else
                            if (rdb_6bb6.Checked)
                                dtEncuestas.Tables[0].Rows[69]["Nota"] = 6;

        if (rdb_6cc1.Checked)
            dtEncuestas.Tables[0].Rows[70]["Nota"] = 1;
        else
            if (rdb_6cc2.Checked)
                dtEncuestas.Tables[0].Rows[70]["Nota"] = 2;
            else
                if (rdb_6cc3.Checked)
                    dtEncuestas.Tables[0].Rows[70]["Nota"] = 3;
                else
                    if (rdb_6cc4.Checked)
                        dtEncuestas.Tables[0].Rows[70]["Nota"] = 4;
                    else
                        if (rdb_6cc5.Checked)
                            dtEncuestas.Tables[0].Rows[70]["Nota"] = 5;
                        else
                            if (rdb_6cc6.Checked)
                                dtEncuestas.Tables[0].Rows[70]["Nota"] = 6;

        if (rdb_6dd1.Checked)
            dtEncuestas.Tables[0].Rows[71]["Nota"] = 1;
        else
            if (rdb_6dd2.Checked)
                dtEncuestas.Tables[0].Rows[71]["Nota"] = 2;
            else
                if (rdb_6dd3.Checked)
                    dtEncuestas.Tables[0].Rows[71]["Nota"] = 3;
                else
                    if (rdb_6dd4.Checked)
                        dtEncuestas.Tables[0].Rows[71]["Nota"] = 4;
                    else
                        if (rdb_6dd5.Checked)
                            dtEncuestas.Tables[0].Rows[71]["Nota"] = 5;
                        else
                            if (rdb_6dd6.Checked)
                                dtEncuestas.Tables[0].Rows[71]["Nota"] = 6;

        //------------- 7 ---------------------------------
        dtEncuestas.Tables[0].Rows[72]["Observaciones"] = txtObservacionPregunta07.Text;
        int CodEncuenta = (int)dtEncuestasPreguntas.Tables[0].Rows[0]["CodEncuesta"];
        
        EncuestasColl ecoll = new EncuestasColl();
        int CodEncuestado = ecoll.InsertaRespuestaCabeza(CodEncuenta, Convert.ToString(Session["IdUsuario"]));
        int Respuesta = ecoll.InsertaRespuestaDetalle(CodEncuestado, dtEncuestas, Convert.ToInt32(Session["IdUsuario"]), CodEncuenta);
        Response.Redirect("default.aspx");

    }
}
