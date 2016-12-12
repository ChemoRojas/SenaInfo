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
using System.Data.SqlClient;
using System.IO;
using System.Drawing;

public partial class mod_institucion_cierreinformeatencion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      mostrar_collapse(false);
      
        if (!IsPostBack)
        {
            getinstituciones();
            getproyectos();
            getanos();


            try
            {
                if (Request.QueryString["sw"] == "4")
                {
                    buscador_institucion bsc = new buscador_institucion();
                    int codinst = bsc.GetCodInstxCodProy(Convert.ToInt32(Request.QueryString["codinst"]));
                    ddown001.SelectedValue = Convert.ToString(codinst);
                    getproyectos();
                    ddown002.SelectedValue = Request.QueryString["codinst"];
                    ddown_AnoCierre.Items.FindByValue(Request.QueryString["A"]).Selected = true;
                    ddown_MesCierre.Items.FindByValue(Request.QueryString["M"]).Selected = true;
                    fn_buscar();
                }
            }
            catch { }
        }
    }

    private void getanos()
    {
        for (int i = 0; i < 7; i++)
        {
            ddown_AnoCierre.Items.Add(Convert.ToString(DateTime.Now.Year - i));
        }
    }

    private void getinstituciones()
    {
        institucioncoll icoll = new institucioncoll();

        DataTable dtinst = icoll.GetData(Convert.ToInt32(Session["IdUsuario"]));
        DataView dv = new DataView(dtinst);
        dv.Sort = "Nombre";
        ddown001.DataSource = dv;
        ddown001.DataTextField = "Nombre";
        ddown001.DataValueField = "Codinstitucion";
        ddown001.DataBind();
    }

    private void getproyectos()
    {
        if (ddown001.Items.Count > 0 && Convert.ToInt32(ddown001.SelectedValue) > 0)
        {
            proyectocoll pcoll = new proyectocoll();

            DataTable dtproy = pcoll.GetData(Convert.ToInt32(Session["IdUsuario"]), "V", Convert.ToInt32(ddown001.SelectedValue));
            DataView dv = new DataView(dtproy);
            dv.Sort = "Nombre";
            ddown002.DataSource = dv;
            ddown002.DataTextField = "Nombre";
            ddown002.DataValueField = "CodProyecto";
            ddown002.DataBind();
        }
    }

    protected void ddown001_SelectedIndexChanged(object sender, EventArgs e)
    {
        getproyectos();
        validatefields();
    }

    private DataTable callto_cierre_cabeceraproyecto(int codproyecto, int mesano)
    {
        
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "cierre_cabeceraproyecto";
        sqlc.Parameters.Add("@codproyecto", SqlDbType.Int, 4).Value = codproyecto;
        sqlc.Parameters.Add("@mesano", SqlDbType.Int, 4).Value = mesano;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    private DataTable callto_cierre_informeatencionmensual(int codproyecto, int mesano, string sexo)
    {
        
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "cierre_InformeAtencionMensual";
        sqlc.Parameters.Add("@codproyecto", SqlDbType.Int, 4).Value = codproyecto;
        sqlc.Parameters.Add("@mesano", SqlDbType.Int, 4).Value = mesano;
        sqlc.Parameters.Add("@sexo", SqlDbType.Char, 1).Value = sexo;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    private int CallTo_Cantidad_Meses_Ultimo_Evento(int CodProyecto, int AnoMes, int ICodIE)
    {
        //System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + objconn.Server + ";Database= " + objconn.DatabaseName + "; User ID= " + objconn.User + " ;Password= " + objconn.Password + ";Trusted_Connection=False");
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_UltimoEventoPPC";
        sqlc.Parameters.Add("@Codproyecto", SqlDbType.Int, 4).Value = CodProyecto;
        sqlc.Parameters.Add("@AnoMes", SqlDbType.Int, 4).Value = AnoMes;
        sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = ICodIE;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return Convert.ToInt32(dt.Rows[0][0]);
    }
    private int CallTo_Autoriza_PRI(int ICodIE, int AnoMes)
    {
        //System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + objconn.Server + ";Database= " + objconn.DatabaseName + "; User ID= " + objconn.User + " ;Password= " + objconn.Password + ";Trusted_Connection=False");
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_AutorizaPRI";
        sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = ICodIE;
        sqlc.Parameters.Add("@AnoMes", SqlDbType.Int, 4).Value = AnoMes;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return Convert.ToInt32(dt.Rows[0][0]);
    }
    private DataTable CallTo_Permanencia_AutorizaPAD(int ICodIE, int AnoMes)
    {
        //System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + objconn.Server + ";Database= " + objconn.DatabaseName + "; User ID= " + objconn.User + " ;Password= " + objconn.Password + ";Trusted_Connection=False");
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_Permanencia_AutorizaPAD";
        sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = ICodIE;
        sqlc.Parameters.Add("@AnoMes", SqlDbType.Int, 4).Value = AnoMes;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    private void fn_buscar()
    {
        if (ddown_MesCierre.SelectedIndex > 0 && ddown002.SelectedIndex > -1)
        {
            if (validatefields())
            {
                string sexo = "A";
                if (rdo_SexoM.Checked)
                {
                    sexo = "M";
                }
                if (rdo_SexoF.Checked)
                {
                    sexo = "F";
                }

                coordinador ccoll = new coordinador();

                string consulta = "Select t2.CreaPlanIntervencion, t2.LRPA from proyectos T1 " +
                "INNER JOIN parmodelointervencion T2 ON T1.CodModeloIntervencion = T2.CodModeloIntervencion Where t1.CodProyecto = " + Convert.ToInt32(ddown002.SelectedValue);
                DataTable dt1 = ccoll.ejecuta_SQL(consulta, null);


                DataTable dt0 = callto_cierre_cabeceraproyecto(Convert.ToInt32(ddown002.SelectedValue), Convert.ToInt32(ddown_AnoCierre.SelectedValue + ddown_MesCierre.SelectedValue));
                lbl001.Text = dt0.Rows[0][10].ToString() + " " + dt0.Rows[0][11].ToString();
                alerts.Visible = false;
                lblDosMeses.Visible = false;
                lblTresMeses.Visible = false;

                DataTable dt = callto_cierre_informeatencionmensual(Convert.ToInt32(ddown002.SelectedValue), Convert.ToInt32(ddown_AnoCierre.SelectedValue + ddown_MesCierre.SelectedValue), sexo);

                int diasantencion = 0; int diasausentes = 0; int diasantendido = 0; int numerointervenciones = 0; int diasintervencion = 0;
                int TotalASD = 0; int TotalASN = 0; int TotalASF = 0; int TotalAPS = 0; int TotalALA = 0; int TotalARD = 0; int TotalPagoPRJ = 0;
                int Total80BIS = 0;


                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        diasantencion += Convert.ToInt32(dt.Rows[i][11]);
                        
                        diasausentes += Convert.ToInt32(dt.Rows[i][7]);
                        diasantendido += Convert.ToInt32(dt.Rows[i][6]);
                        numerointervenciones += Convert.ToInt32(dt.Rows[i][8]);
                        diasintervencion += Convert.ToInt32(dt.Rows[i][9]);
                        // numerointervencionesotras += Convert.ToInt32(dt.Rows[i][13]); deshabilitada
                        if (Convert.ToInt32(dt.Rows[0][14].ToString()) == 128)
                        {
                            int NumeroIntervencionesPJC = 0;
                            if (Convert.ToInt32(dt.Rows[i]["IntervencionesASD"]) > 0)
                                NumeroIntervencionesPJC += 1;
                            if (Convert.ToInt32(dt.Rows[i]["IntervencionesASN"]) > 0)
                                NumeroIntervencionesPJC += 1;
                            if (Convert.ToInt32(dt.Rows[i]["IntervencionesASF"]) > 0)
                                NumeroIntervencionesPJC += 1;
                            if (Convert.ToInt32(dt.Rows[i]["IntervencionesAPS"]) > 0)
                                NumeroIntervencionesPJC += 1;
                            if (Convert.ToInt32(dt.Rows[i]["IntervencionesALA"]) > 0)
                                NumeroIntervencionesPJC += 1;
                            if (Convert.ToInt32(dt.Rows[i]["IntervencionesARD"]) > 0)
                                NumeroIntervencionesPJC += 1;

                            TotalPagoPRJ += NumeroIntervencionesPJC;
                            dt.Rows[i]["TotalPJC"] = NumeroIntervencionesPJC;
                            TotalASD += Convert.ToInt32(dt.Rows[i]["IntervencionesASD"]);
                            TotalASN += Convert.ToInt32(dt.Rows[i]["IntervencionesASN"]);
                            TotalASF += Convert.ToInt32(dt.Rows[i]["IntervencionesASF"]);
                            TotalAPS += Convert.ToInt32(dt.Rows[i]["IntervencionesAPS"]);
                            TotalALA += Convert.ToInt32(dt.Rows[i]["IntervencionesALA"]);
                            TotalARD += Convert.ToInt32(dt.Rows[i]["IntervencionesARD"]);
                        }
                        if (Convert.ToInt32(dt0.Rows[0]["CodDepartamentosSENAME"]) == 6 || Convert.ToInt32(dt0.Rows[0]["CodDepartamentosSENAME"]) == 9)
                            Total80BIS += Convert.ToInt32(dt.Rows[i]["Ingreso80Bis"]);
                    }
                    DataRow dr = dt.NewRow();
                    dr[11] = diasantencion;
                    dr[7] = diasausentes;
                    dr[6] = diasantendido;
                    dr[8] = numerointervenciones;
                    dr[9] = diasintervencion;
                    dr[2] = "Total";

                    if (Convert.ToInt32(dt.Rows[0][14].ToString()) == 128)
                    {
                        alerts.Visible = true;
                        lblPRI.Visible = true;
                        lblPRI.Text = "Esta información es el resumen del Cierre de cada línea, si no lo visualiza debe ir a la línea correspondiente.";
                        lblPRI.BackColor = System.Drawing.Color.Yellow;

                        dr["IntervencionesASD"] = TotalASD;
                        dr["IntervencionesASN"] = TotalASN;
                        dr["IntervencionesASF"] = TotalASF;
                        dr["IntervencionesAPS"] = TotalAPS;
                        dr["IntervencionesALA"] = TotalALA;
                        dr["IntervencionesARD"] = TotalARD;
                        dr["TotalPJC"] = TotalPagoPRJ; // TotalASD + TotalASN + TotalASF + TotalAPS + TotalALA + TotalARD;

                        bool existecolumna = false;
                        foreach (DataControlField item in grd001.Columns)
                        {
                            //if (item.HeaderText == "IntervencionesALA")
                            if (((BoundField)item).DataField == "IntervencionesALA")
                            {
                                existecolumna = true;
                                break;
                            }
                        }


                        if (existecolumna == false)
                        {
                            BoundField Columna10 = new BoundField();
                            BoundField Columna11 = new BoundField();
                            BoundField Columna12 = new BoundField();

                            Columna10.HeaderText = "ALA";
                            Columna10.DataField = "IntervencionesALA";


                            Columna11.HeaderText = "ARD";
                            Columna11.DataField = "IntervencionesARD";


                            Columna12.HeaderText = "Total a Pagar";
                            Columna12.DataField = "TotalPJC";


                            grd001.Columns.Add(Columna10);
                            grd001.Columns.Add(Columna11);
                            grd001.Columns.Add(Columna12);
                            grd001.Columns[5].Visible = false;
                        }
                    }
                    else
                    {
                        bool existecolumna = false;
                        foreach (DataControlField item in grd001.Columns)
                        {
                            //if (item.HeaderText == "ALA")
                            if (((BoundField)item).DataField == "IntervencionesALA")
                            {
                                existecolumna = true;
                                break;
                            }
                        }

                        if (existecolumna == true)
                        {
                            alerts.Visible = false;
                            lblPRI.Visible = false;
                            foreach (DataControlField col in grd001.Columns)
                            {
                                //if (col.HeaderText == "ALA")
                                if (((BoundField)col).DataField == "IntervencionesALA")
                                {
                                    grd001.Columns[grd001.Columns.IndexOf(col)].Visible = false;
                                }

                                //if (col.HeaderText == "ARD")
                                if (((BoundField)col).DataField == "IntervencionesARD")
                                {
                                    grd001.Columns[grd001.Columns.IndexOf(col)].Visible = false;
                                }

                                //if (col.HeaderText == "TotalPJC")
                                if (((BoundField)col).DataField == "TotalPJC")
                                {
                                    grd001.Columns[grd001.Columns.IndexOf(col)].Visible = false;
                                }
                            }



                            grd001.Columns[5].Visible = true;
                        }
                    }

                    if (Convert.ToInt32(dt0.Rows[0]["CodDepartamentosSENAME"]) == 6 || Convert.ToInt32(dt0.Rows[0]["CodDepartamentosSENAME"]) == 9)
                    {
                        bool existecolumna = false;
                        foreach (DataControlField item in grd001.Columns)
                        {
                            //if (item.HeaderText == "C80BIS")
                            if (((BoundField)item).DataField == "Ingreso80Bis")
                            {
                                existecolumna = true;
                                break;
                            }
                        }

                        if (existecolumna == false)
                        {
                            BoundField Columna80BIS = new BoundField();
                            Columna80BIS.HeaderText = "80 BIS";
                            Columna80BIS.DataField = "Ingreso80Bis";
                            grd001.Columns.Add(Columna80BIS);
                            //grd001.Columns.FromKey("C80BIS").BaseColumnName = "Ingreso80Bis";
                        }
                        dr["Ingreso80Bis"] = Total80BIS;
                    }

                    dt.Rows.Add(dr);
                    DataView dv = new DataView(dt);


                    grd001.DataSource = dv;
                    int indiceK6 = 0;
                    int indiceK7 = 0;
                    int indiceK8 = 0;
                    int indiceK9 = 0;
                    foreach (DataControlField item in grd001.Columns)
                    {
                        if (item.HeaderText == "Numero Intervenciones Directas")
                        {
                            indiceK6 = grd001.Columns.IndexOf(item);
                        }

                        if (item.HeaderText == "Total días a pagar por intervención")
                        {
                            indiceK7 = grd001.Columns.IndexOf(item);
                        }

                        if (item.HeaderText == "Total días a pagar por atención")
                        {
                            indiceK8 = grd001.Columns.IndexOf(item);
                        }

                        if (item.HeaderText == "Número Intervenciones Otras")
                        {
                            indiceK9 = grd001.Columns.IndexOf(item);
                        }
                    }
                    grd001.Columns[indiceK6].HeaderText = "Número intervenciones Directas";
                    ((BoundField)grd001.Columns[indiceK6]).DataField = "NumeroIntervenciones";

                    grd001.Columns[indiceK7].HeaderText = "Total días a pagar por intervención";
                    ((BoundField)grd001.Columns[indiceK7]).DataField = "DiasIntervencion";

                    grd001.Columns[indiceK8].HeaderText = "Total días a pagar por atención";
                    ((BoundField)grd001.Columns[indiceK8]).DataField = "DiasAtendido";

                    grd001.Columns[indiceK9].HeaderText = "Número intervenciones Otras";
                    ((BoundField)grd001.Columns[indiceK9]).DataField = "NumeroIntervencionesOtras";



                    //grd001.DataBind();
                    switch (Convert.ToInt32(dt.Rows[0][12].ToString())) // Pago Subvencion
                    {
                        case 4:

                            grd001.Columns[indiceK8].Visible = true;
                            grd001.Columns[indiceK7].Visible = false;
                            grd001.Columns[indiceK6].Visible = false;
                            grd001.Columns[indiceK9].Visible = true;//nuevo28072008

                            break;
                        case 10:

                            grd001.Columns[indiceK8].Visible = true;
                            grd001.Columns[indiceK7].Visible = false;
                            grd001.Columns[indiceK6].Visible = false;
                            grd001.Columns[indiceK9].Visible = false;//nuevo28072008


                            break;
                        case 5:

                            grd001.Columns[indiceK8].Visible = false;
                            grd001.Columns[indiceK7].Visible = true;
                            grd001.Columns[indiceK6].Visible = true;
                            grd001.Columns[indiceK9].Visible = false;//nuevo28072008

                            grd001.Columns[indiceK6].HeaderText = "Número Intervenciones";
                            grd001.Columns[indiceK7].HeaderText = "Total dias a pagar por intervención";
                            break;
                        case 16:

                            grd001.Columns[indiceK8].Visible = false;
                            grd001.Columns[indiceK7].Visible = true;
                            grd001.Columns[indiceK6].Visible = true;
                            grd001.Columns[indiceK9].Visible = false;//nuevo28072008

                            grd001.Columns[indiceK6].HeaderText = "Número Intervenciones";
                            grd001.Columns[indiceK7].HeaderText = "Total dias a pagar por intervención";
                            break;
                        case 14:

                            grd001.Columns[indiceK8].Visible = false;
                            grd001.Columns[indiceK7].Visible = true;
                            grd001.Columns[indiceK6].Visible = true;
                            grd001.Columns[indiceK9].Visible = false;//nuevo28072008

                            grd001.Columns[indiceK6].HeaderText = "Número Diagnósticos";
                            grd001.Columns[indiceK7].HeaderText = "Total de prestaciones a pagar";
                            break;
                        case 18:

                            grd001.Columns[indiceK8].Visible = false;
                            grd001.Columns[indiceK7].Visible = true;
                            grd001.Columns[indiceK6].Visible = true;
                            if (Convert.ToInt32(dt1.Rows[0][0]) == 1 && dt1.Rows[0][1].ToString() == "1")
                            {
                                grd001.Columns[indiceK9].Visible = true;//nuevo28072008
                            }
                            grd001.Columns[indiceK6].HeaderText = "Número Intervenciones";
                            grd001.Columns[indiceK7].HeaderText = "Total a pagar";

                            # region PRI
                            if (Convert.ToInt32(dt.Rows[0][14].ToString()) == 109)      // pri
                            {
                                int iAnoMes = Convert.ToInt32(ddown_AnoCierre.Text + ddown_MesCierre.SelectedValue);
                                int iICodIE;
                                int iCantidadMeses;
                                alerts.Visible = true;
                                lblPRI.Visible = true;
                                lblPri12.Visible = true;
                                lblPRI.Text = "Niño(a) con permanencia mayor a 6 meses y sin autorización de la Unidad Regional de Adopcion";
                                lblPri12.Text = "Niño(a) con permanencia mayor a 12 meses                                                  ";
                                lblPRI.BackColor = System.Drawing.Color.Pink;
                                lblPri12.BackColor = System.Drawing.Color.Yellow;
                                for (int i = 0; i < grd001.Rows.Count - 1; i++)
                                {
                                    iICodIE = Convert.ToInt32(grd001.Rows[i].Cells[0].Text);
                                    iCantidadMeses = CallTo_Autoriza_PRI(iICodIE, Convert.ToInt32(ddown_AnoCierre.Text + ddown_MesCierre.SelectedValue));

                                    if (iCantidadMeses == 0)
                                        grd001.Rows[i].BackColor = System.Drawing.Color.Pink;
                                    if (iCantidadMeses == 888)
                                        grd001.Rows[i].BackColor = System.Drawing.Color.Yellow;
                                }
                            }
                            #endregion

                            #region PPC
                            if (Convert.ToInt32(dt.Rows[0][14].ToString()) == 107)      // PPC - PROGRAMA PREVENCION COMUNITARIA
                            {
                                alerts.Visible = true;
                                lblDosMeses.Visible = true;
                                lblTresMeses.Visible = true;
                                lblDosMeses.BackColor = System.Drawing.Color.Yellow;
                                lblTresMeses.BackColor = System.Drawing.Color.Pink;

                                lblEventosProyecto.Width = grd001.Width;
                                lblEventosProyecto.Visible = true;
                                lblEventosProyecto.Text = "Cantidad de Eventos del Proyecto:  " + dt.Rows[0][10].ToString(); // Cantidad de Eventos del proyecto.

                                //grd001.Columns.FromKey("K6").BaseColumnName = "Intervenciones_a_Pagar";
                                ((BoundField)grd001.Columns[indiceK6]).DataField = "Intervenciones_a_Pagar";
                                grd001.Columns[indiceK6].HeaderText = "Total a pagar";
                                grd001.Columns[indiceK7].Visible = false;
                                grd001.Columns[indiceK9].Visible = false;
                                DataRow[] foundRows;
                                foundRows = dt.Select("Intervenciones_a_Pagar = 1");
                                dt.Rows[dt.Rows.Count - 1][15] = foundRows.Length;
                                //grd001.DataBind();

                                int iAnoMes = Convert.ToInt32(ddown_AnoCierre.Text + ddown_MesCierre.SelectedValue);
                                int iICodIE;
                                int iCantidadMeses;

                                for (int i = 0; i < grd001.Rows.Count - 1; i++)
                                {
                                    iICodIE = Convert.ToInt32(grd001.Rows[i].Cells[0].Text);
                                    iCantidadMeses = CallTo_Cantidad_Meses_Ultimo_Evento(Convert.ToInt32(ddown002.SelectedValue), Convert.ToInt32(ddown_AnoCierre.Text + ddown_MesCierre.SelectedValue), iICodIE);

                                    if (iCantidadMeses >= 3 || iCantidadMeses == -1)
                                        grd001.Rows[i].BackColor = System.Drawing.Color.Pink;
                                    if (iCantidadMeses == 2)
                                        grd001.Rows[i].BackColor = System.Drawing.Color.Yellow;
                                }
                            }
                            #endregion

                            #region PAD
                            if (Convert.ToInt32(dt.Rows[0][14].ToString()) == 83)       // PAD - PROGRAMA DE PROTECCIÓN AMBULATORIA PARA NIÑOS(AS) Y ADOLESC. CON DISCAPACIDAD GRAVE O PROFUNDA
                            {
                                alerts.Visible = true;
                                lblDosMeses.Visible = true;
                                lblTresMeses.Visible = true;
                                lblPRI.Visible = true;

                                lblDosMeses.Width = System.Web.UI.WebControls.Unit.Pixel(320);
                                lblTresMeses.Width = System.Web.UI.WebControls.Unit.Pixel(320);
                                lblPRI.Width = System.Web.UI.WebControls.Unit.Pixel(320);

                                lblDosMeses.BackColor = System.Drawing.Color.Yellow;
                                lblTresMeses.BackColor = System.Drawing.Color.PaleGreen;
                                lblPRI.BackColor = System.Drawing.Color.Pink;

                                lblDosMeses.Text = "Próximo a cumplir Permanencia máxima (2 años)";
                                lblTresMeses.Text = "Sobre Permanencia máxima (2 años) autorizada";
                                lblPRI.Text = "Sobre Permanencia máxima (2 años) NO autorizada";

                                grd001.Columns[indiceK8].Visible = true;
                                grd001.Columns[indiceK9].Visible = false;

                                ((BoundField)grd001.Columns[indiceK6]).DataField = "NumeroIntervenciones";
                                grd001.Columns[indiceK6].HeaderText = "Número Intervenciones";

                                ((BoundField)grd001.Columns[indiceK7]).DataField = "DiscapacidadGrave";
                                grd001.Columns[indiceK7].HeaderText = "Discapacidad Grave";

                                ((BoundField)grd001.Columns[indiceK8]).DataField = "DiscapacidadOtras";
                                grd001.Columns[indiceK8].HeaderText = "Otras";





                                DataRow[] foundRows;
                                foundRows = dt.Select("DiscapacidadGrave = 1");
                                dt.Rows[dt.Rows.Count - 1][16] = foundRows.Length;

                                foundRows = dt.Select("DiscapacidadOtras = 1");
                                dt.Rows[dt.Rows.Count - 1][17] = foundRows.Length;

                                int iICodIE;
                                int iAnoMes = Convert.ToInt32(ddown_AnoCierre.Text + ddown_MesCierre.SelectedValue);
                                //grd001.DataBind();

                                for (int i = 0; i < grd001.Rows.Count - 1; i++)
                                {
                                    iICodIE = Convert.ToInt32(grd001.Rows[i].Cells[0].Text);
                                    DataTable dtPAD = CallTo_Permanencia_AutorizaPAD(iICodIE, iAnoMes);

                                    if (dtPAD.Rows.Count > 0 && (Convert.ToDecimal(dtPAD.Rows[0]["PermanenciaMeses"]) == 23 || Convert.ToDecimal(dtPAD.Rows[0]["PermanenciaMeses"]) == 24) && Convert.ToDecimal(dtPAD.Rows[0]["Autoriza"]) == 0)
                                    {
                                        grd001.Rows[i].BackColor = System.Drawing.Color.Yellow; grd001.Rows[i].BackColor = System.Drawing.Color.Yellow;
                                    }
                                    if (dtPAD.Rows.Count > 0 && Convert.ToDecimal(dtPAD.Rows[0]["PermanenciaAnos"]) >= 2 && Convert.ToDecimal(dtPAD.Rows[0]["Autoriza"]) == 1)
                                    {
                                        grd001.Rows[i].BackColor = System.Drawing.Color.PaleGreen; grd001.Rows[i].BackColor = System.Drawing.Color.PaleGreen;
                                    }
                                    if (dtPAD.Rows.Count > 0 && Convert.ToDecimal(dtPAD.Rows[0]["PermanenciaAnos"]) > 2 && Convert.ToDecimal(dtPAD.Rows[0]["Autoriza"]) == 0)
                                    {
                                        grd001.Rows[i].BackColor = System.Drawing.Color.Pink; grd001.Rows[i].BackColor = System.Drawing.Color.Pink;
                                    }
                                }

                            }
                            #endregion

                            break;
                        case 12:    // POR REMESA
                            grd001.Columns[indiceK8].Visible = true;
                            grd001.Columns[indiceK7].Visible = false;
                            grd001.Columns[indiceK6].Visible = false;
                            if (Convert.ToInt32(dt1.Rows[0][0]) == 1 && Convert.ToInt32(dt1.Rows[0][1]) == 1)
                            {
                                grd001.Columns[indiceK9].Visible = true; //nuevo28072008
                            }

                            #region PJC CMN
                            if (Convert.ToInt32(dt.Rows[0][14].ToString()) == 128)       // PJC - PROGRAMA DE JUSTICIA JUVENIL COORDINADO
                            {
                                grd001.Columns[indiceK6].Visible = true;
                                grd001.Columns[indiceK7].Visible = true;
                                grd001.Columns[indiceK8].Visible = true;
                                grd001.Columns[indiceK9].Visible = true;

                                ((BoundField)grd001.Columns[indiceK9]).DataField = "IntervencionesASD";
                                grd001.Columns[indiceK9].HeaderText = "ASD";

                                ((BoundField)grd001.Columns[indiceK6]).DataField = "IntervencionesASN";
                                grd001.Columns[indiceK6].HeaderText = "ASN";

                                ((BoundField)grd001.Columns[indiceK7]).DataField = "IntervencionesASF";
                                grd001.Columns[indiceK7].HeaderText = "ASF";

                                ((BoundField)grd001.Columns[indiceK8]).DataField = "IntervencionesAPS";
                                grd001.Columns[indiceK8].HeaderText = "APS";

                                //grd001.DataBind();
                            }
                            #endregion

                            break;
                        default:
                            grd001.Columns[indiceK8].Visible = true;
                            grd001.Columns[indiceK7].Visible = false;
                            grd001.Columns[indiceK6].Visible = false;
                            if (Convert.ToInt32(dt1.Rows[0][0]) == 1 && Convert.ToInt32(dt1.Rows[0][1]) == 1)
                            {
                                grd001.Columns[indiceK9].Visible = true; //nuevo28072008
                            }
                            break;

                    }

                    grd001.DataBind();

                    grd001.Visible = true;
                    lbtn_ExportarExcel.Visible = true;
                    //WebImageButton1.Visible = true;
                    alerts.Visible = false;
                    lbl003.Visible = false;
                    //gfontbrevis
                    lbl_resumen_filtro.Text = " Resumen: ";
                    //lbl_resumen_filtro.Text += "- Institución: " + ddown001.SelectedItem.Text.Trim() + "<br>";
                    lbl_resumen_filtro.Text += ddown002.SelectedItem.Text.Trim() + " / ";
                    lbl_resumen_filtro.Text += ddown_MesCierre.SelectedItem.Text + " de " + ddown_AnoCierre.SelectedItem.Text + " / ";
                    lbl_resumen_filtro.Text += lbl001.Text;
                    if (rdo_SexoA.Checked == true)
                    {
                      lbl_resumen_filtro.Text += "/ Sexo: " + rdo_SexoA.Text + "";
                    }
                    if (rdo_SexoF.Checked == true)
                    {
                      lbl_resumen_filtro.Text += "/ Sexo: " + rdo_SexoF.Text + "";
                    }
                    if (rdo_SexoM.Checked == true)
                    {
                      lbl_resumen_filtro.Text += "/ Sexo: " + rdo_SexoM.Text + "";
                    }

                    lbl_resumen_filtro.Visible = true;
                    lbl_resumen_filtro.Style.Add("display", "none");
                }
                else
                {
                    grd001.Visible = false;
                    lbtn_ExportarExcel.Visible = false;
                    //WebImageButton1.Visible = false;
                    alerts.Visible = true;
                    lbl003.Visible = true;
                }
            }
        }
    }
    protected void Imb002_Click(object sender, EventArgs e)
    {

    }
    private bool validatefields()
    {
        bool v = true;
        if (ddown001.SelectedValue == null)
        {
            ddown001.BackColor = System.Drawing.Color.Pink;
            v = false;
        }
        if (ddown002.SelectedValue == null || ddown002.SelectedValue == "")
        {
            ddown002.BackColor = System.Drawing.Color.Pink;
            v = false;
        }
        else
        {
            ddown002.BackColor = System.Drawing.Color.White;
        }
        if (ddown_MesCierre.SelectedIndex == 0)
        {
            ddown_MesCierre.BackColor = System.Drawing.Color.Pink;
            v = false;
        }
        else
        {
            ddown_MesCierre.BackColor = System.Drawing.Color.White;
        }
        if (!v)
        {
            grd001.Visible = false;
        }
        return v;
    }
 
    //protected void WebImageButton1_Click(object sender, EventArgs e) //EXPORTAR EXCEL
    //{
    //    ExportarExcel();
    //}

    protected void ddown002_SelectedIndexChanged(object sender, EventArgs e)
    {
        grd001.Visible = false;
        lbtn_ExportarExcel.Visible = false;
        //WebImageButton1.Visible = false;
        fn_buscar();
    }
    protected void ddown_MesCierre_SelectedIndexChanged(object sender, EventArgs e)
    {
        fn_buscar();
    }
    protected void rdo_SexoA_CheckedChanged(object sender, EventArgs e)
    {
        fn_buscar();
    }

    protected void Imb001_Click(object sender, EventArgs e)
    {
        if (ddown_MesCierre.SelectedIndex > 0)
        {
            Response.Redirect("cierre_movmensual.aspx?sw=4&codinst=" + ddown002.SelectedValue + "&M=" + ddown_MesCierre.SelectedValue + "&A=" + ddown_AnoCierre.SelectedValue);
        }
    }

    protected void imb_volver_Click(object sender, EventArgs e)
    {
        //Response.Redirect("index_ninos.aspx");
        if (ddown_MesCierre.SelectedIndex > 0)
        {
            Response.Redirect("cierre_movmensual.aspx?sw=4&codinst=" + ddown002.SelectedValue + "&M=" + ddown_MesCierre.SelectedValue + "&A=" + ddown_AnoCierre.SelectedValue);
        }
    }

    //private void ExportarExcel() //recibe el html de la grilla
    //{
    //    //Response.ClearContent();
    //    //Response.Buffer = true;
    //    //Response.AddHeader("Content-Disposition", "attachment;filename=AsistenciaMensual.xls");
    //    //Response.ContentType = "application/ms-excel";
    //    //Response.Charset = "UTF-8";
    //    //Response.ContentEncoding = System.Text.Encoding.Unicode;
    //    //Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
    //    //this.EnableViewState = true;
    //    //Response.Write(output.ToString());
    //    //Response.End();


    //    Response.Clear();
    //    Response.AddHeader("Content-Disposition", "attachment;filename=AsistenciaMensual.xls");
    //    Response.ContentType = "application/vnd.xls";
    //    System.IO.StringWriter stringWrite = new System.IO.StringWriter();
    //    System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

    //    grd001.RenderControl(htmlWrite);
    //    Response.Write(stringWrite.ToString());
    //    Response.End();
    //}

    protected void lbtn_ExportarExcel_Click(object sender, EventArgs e)
    {
        //Response.ClearContent();
        //Response.AddHeader("content-disposition", "attachment;filename=Customers.xls");
        //Response.ContentType = "applicatio/excel";
        //StringWriter sw = new StringWriter(); ;
        //HtmlTextWriter htm = new HtmlTextWriter(sw);
        //grd001.RenderControl(htm);
        //Response.Write(sw.ToString());
        //Response.End();

        Response.Clear();
        Response.AddHeader("Content-Disposition", "attachment;filename=AsistenciaMensual.xls");
        Response.ContentType = "application/vnd.xls";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

        fn_buscar();
        grd001.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }

    private void mostrar_collapse(bool valor)
    {
      if (valor)
      {

        collapse_Form.Attributes.Remove("Class");
        collapse_Form.Attributes.Add("Class", "panel-collapse collapse in");
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "A", "$('#lbl_resumen_filtro').hide();", true);
      }
      if (!valor)
      {
        collapse_Form.Attributes.Remove("Class");
        collapse_Form.Attributes.Add("Class", "panel-collapse collapse out");
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "A", "$('#lbl_resumen_filtro').show();", true);
      }

    }

}