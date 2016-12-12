using System;
using System.Text;
using System.Net;
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
using System.Drawing;
using System.IO;
using System.Globalization;



public partial class mod_institucion_cierre_registroatencion : System.Web.UI.Page
{
    private ArrayList arrindexm
    {
        get
        {
            if (ViewState["arrindexm"] == null)
            {
                ViewState["arrindexm"] = new ArrayList();
            }

            return (ArrayList)ViewState["arrindexm"];
        }
        set { ViewState["arrindexm"] = value; }
    }
    private ArrayList arrcolumn
    {
        get
        {
            if (ViewState["arrcolumn"] == null)
            {
                ViewState["arrcolumn"] = new ArrayList();
            }

            return (ArrayList)ViewState["arrcolumn"];
        }
        set { ViewState["arrcolumn"] = value; }
    }

    private bool IsClosed
    {
        get
        {
            if (ViewState["IsClosed"] == null)
            {
                ViewState["IsClosed"] = new bool();
            }

            return (bool)ViewState["IsClosed"];
        }
        set { ViewState["IsClosed"] = value; }
    }

    private int CodProyecto
    {
        get { return Convert.ToInt32(ViewState["CodProyecto"]); }
        set { ViewState["CodProyecto"] = value; }
    }
    private bool Bloquear
    {
        get { return Convert.ToBoolean(ViewState["Bloquear"]); }
        set { ViewState["Bloquear"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
      mostrar_collapse(false);
        if (!IsPostBack)
        {
            getinstituciones();
            getproyectos();
            getanos();
            IsClosed = false;

            ReLoad();
            //try
            //{
            //    if (Request.QueryString["sw"] == "4")
            //    {
            //        buscador_institucion bsc = new buscador_institucion();
            //        int codinst = bsc.GetCodInstxCodProy(Convert.ToInt32(Request.QueryString["codinst"]));
            //        ddown001.SelectedValue = Convert.ToString(codinst);
            //        getproyectos();
            //        ddown002.SelectedValue = Request.QueryString["codinst"];
            //        ddown_AnoCierre.Items.FindByValue(Request.QueryString["A"]).Selected = true;
            //        ddown_MesCierre.Items.FindByValue(Request.QueryString["M"]).Selected = true;
            //        ddown_MesCierre.SelectedIndex = Convert.ToInt32(Request.QueryString["M"].ToString());
            //        getinmueble();
            //        fn_buscar();
            //    }
            //}
            //catch { }

        }

       
        validatescurity();

        #region Variable Session Modal
        ArrayList al = new ArrayList(3);
        al.Add(ddown002.SelectedValue);
        al.Add(Convert.ToInt32(Convert.ToString(ddown_AnoCierre.SelectedValue) + Convert.ToString(ddown_MesCierre.SelectedValue)));
        al.Add(Session["IdUsuario"]);
        Session["variables_impresion"] = al;
        #endregion
    }

    #region VISIBILIDAD DE FUNCIONALIDADES SEGUN PERMISOS

    private void validatescurity()
    {
        //C06E3BDB-1478-4307-BDFA-64C8CB28E296 2.8_MODIFICAR
        if (!window.existetoken("C06E3BDB-1478-4307-BDFA-64C8CB28E296"))
        {
            Imb003.Visible = false; //9
        }
        //F1315126-A9BB-443D-8040-44F721B97EB2 2.8_Regenerar
        if (!window.existetoken("F1315126-A9BB-443D-8040-44F721B97EB2"))
        {
            imb005.Visible = false; //9
        }
        if (!window.existetoken("49E9FC7F-D444-43EE-8061-8845AB345DF1"))
        {
            Imb006.Visible = false;
        }
    }
    #endregion

    private void ReLoad()
    {
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
                ddown_MesCierre.SelectedIndex = Convert.ToInt32(Request.QueryString["M"].ToString());
                getinmueble();
                fn_buscar();
            }
        }
        catch { }
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
        DataSet ds = (DataSet)Session["dsParametricas"];
        // << --- DPL 20-08-2015 --- >
        //institucioncoll icoll = new institucioncoll();
        //DataTable dtinst = icoll.GetData(Convert.ToInt32(Session["IdUsuario"]));
        // << --- DPL 20-08-2015 --- >
        DataTable dtinst = ds.Tables["dtInstituciones"];
        DataView dv = new DataView(dtinst);
        dv.Sort = "Nombre ASC";
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
    private void getinmueble()
    {
        inmueblecoll icoll = new inmueblecoll();
        DataTable dt = icoll.GetInmueble(ddown002.SelectedValue);
        ddown003.DataSource = dt;
        ddown003.DataTextField = "Nombre";
        ddown003.DataValueField = "ICodInmueble";
        ddown003.DataBind();

    }

    #region llama a la base
    private DataTable callto_cierre_cabeceraproyecto(int codproyecto, int mesano)
    {
        Conexiones con = new Conexiones();

        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + con.Servidor + ";Database= " + con.Base + "; User ID= " + con.Usuario + " ;Password= " + con.Passw + ";Trusted_Connection=False");
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

    private DataTable callto_cierre_registroatencion(int codproyecto, int mesano, string sexo)
    {
        Conexiones con = new Conexiones();
        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + con.Servidor + " ;Database= " + con.Base + " ; User ID= " + con.Usuario + " ;Password= " + con.Passw + " ;Trusted_Connection=False");
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "cierre_registroatencion";
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
    private DataTable callto_cierre_diashabiles(int codproyecto, int mesano)
    {
        Conexiones con = new Conexiones();
        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + con.Servidor + " ;Database= " + con.Base + " ; User ID= " + con.Usuario + " ;Password= " + con.Passw + " ;Trusted_Connection=False");
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "cierre_diashabiles";
        sqlc.Parameters.Add("@codproyecto", SqlDbType.Int, 4).Value = codproyecto;
        sqlc.Parameters.Add("@mesano", SqlDbType.Int, 4).Value = mesano;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    private DataTable callto_cierre_guardaregistro(int icodie, int mesano, string d1, string d2, string d3, string d4, string d5, string d6, string d7, string d8, string d9, string d10, string d11, string d12, string d13, string d14, string d15, string d16, string d17, string d18, string d19, string d20, string d21, string d22, string d23, string d24, string d25, string d26, string d27, string d28, string d29, string d30, string d31, int idusuarioactualizacion)
    {
        Conexiones con = new Conexiones();
        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + con.Servidor + " ;Database= " + con.Base + " ; User ID= " + con.Usuario + " ;Password= " + con.Passw + " ;Trusted_Connection=False");
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "cierre_guardaregistro";
        sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = icodie;
        sqlc.Parameters.Add("@MesAno", SqlDbType.Int, 4).Value = mesano;
        sqlc.Parameters.Add("@d1", SqlDbType.NVarChar, 4).Value = d1;
        sqlc.Parameters.Add("@d2", SqlDbType.NVarChar, 4).Value = d2;
        sqlc.Parameters.Add("@d3", SqlDbType.NVarChar, 4).Value = d3;
        sqlc.Parameters.Add("@d4", SqlDbType.NVarChar, 4).Value = d4;
        sqlc.Parameters.Add("@d5", SqlDbType.NVarChar, 4).Value = d5;
        sqlc.Parameters.Add("@d6", SqlDbType.NVarChar, 4).Value = d6;
        sqlc.Parameters.Add("@d7", SqlDbType.NVarChar, 4).Value = d7;
        sqlc.Parameters.Add("@d8", SqlDbType.NVarChar, 4).Value = d8;
        sqlc.Parameters.Add("@d9", SqlDbType.NVarChar, 4).Value = d9;
        sqlc.Parameters.Add("@d10", SqlDbType.NVarChar, 4).Value = d10;
        sqlc.Parameters.Add("@d11", SqlDbType.NVarChar, 4).Value = d11;
        sqlc.Parameters.Add("@d12", SqlDbType.NVarChar, 4).Value = d12;
        sqlc.Parameters.Add("@d13", SqlDbType.NVarChar, 4).Value = d13;
        sqlc.Parameters.Add("@d14", SqlDbType.NVarChar, 4).Value = d14;
        sqlc.Parameters.Add("@d15", SqlDbType.NVarChar, 4).Value = d15;
        sqlc.Parameters.Add("@d16", SqlDbType.NVarChar, 4).Value = d16;
        sqlc.Parameters.Add("@d17", SqlDbType.NVarChar, 4).Value = d17;
        sqlc.Parameters.Add("@d18", SqlDbType.NVarChar, 4).Value = d18;
        sqlc.Parameters.Add("@d19", SqlDbType.NVarChar, 4).Value = d19;
        sqlc.Parameters.Add("@d20", SqlDbType.NVarChar, 4).Value = d20;
        sqlc.Parameters.Add("@d21", SqlDbType.NVarChar, 4).Value = d21;
        sqlc.Parameters.Add("@d22", SqlDbType.NVarChar, 4).Value = d22;
        sqlc.Parameters.Add("@d23", SqlDbType.NVarChar, 4).Value = d23;
        sqlc.Parameters.Add("@d24", SqlDbType.NVarChar, 4).Value = d24;
        sqlc.Parameters.Add("@d25", SqlDbType.NVarChar, 4).Value = d25;
        sqlc.Parameters.Add("@d26", SqlDbType.NVarChar, 4).Value = d26;
        sqlc.Parameters.Add("@d27", SqlDbType.NVarChar, 4).Value = d27;
        sqlc.Parameters.Add("@d28", SqlDbType.NVarChar, 4).Value = d28;
        sqlc.Parameters.Add("@d29", SqlDbType.NVarChar, 4).Value = d29;
        sqlc.Parameters.Add("@d30", SqlDbType.NVarChar, 4).Value = d30;
        sqlc.Parameters.Add("@d31", SqlDbType.NVarChar, 4).Value = d31;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = idusuarioactualizacion;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    private DataTable callto_cierre_regenerar(int codproyecto, int mesano, int idusuarioactualizacion)
    {
        Conexiones con = new Conexiones();
        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + con.Servidor + " ;Database= " + con.Base + " ; User ID= " + con.Usuario + " ;Password= " + con.Passw + " ;Trusted_Connection=False");
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "cierre_regenerar";
        sqlc.Parameters.Add("@codproyecto", SqlDbType.Int, 4).Value = codproyecto;
        sqlc.Parameters.Add("@mesano", SqlDbType.Int, 4).Value = mesano;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = idusuarioactualizacion;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    #endregion


    private DataTable callto_proyectos_asistencia()
    {
        Conexiones con = new Conexiones();
        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + con.Servidor + ";Database= " + con.Base + "; User ID= " + con.Usuario + " ;Password= " + con.Passw + ";Trusted_Connection=False");
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Get_ProyectosAsistencia";
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    private void fn_buscar()
    {
        Imb006.Visible = false;
        Imb003.Visible = false;

        DataTable dtx = callto_cierre_cabeceraproyecto(Convert.ToInt32(ddown002.SelectedValue), Convert.ToInt32(ddown_AnoCierre.SelectedValue + ddown_MesCierre.SelectedValue));
        if (Convert.ToInt32(dtx.Rows[0][12]) == 1)
        {
            alerts.Visible = true;
            lbl002.Visible = true;
        }
        else
        {
            alerts.Visible = false;
            lbl002.Visible = false;
        }

        if (ddown002.SelectedIndex > -1 && ddown003.SelectedIndex > -1 && ddown_MesCierre.SelectedIndex > 0)
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
                DataTable dt0 = callto_cierre_cabeceraproyecto(Convert.ToInt32(ddown002.SelectedValue), Convert.ToInt32(ddown_AnoCierre.SelectedValue + ddown_MesCierre.SelectedValue));


                lbl001.Text = dt0.Rows[0][10].ToString() + " " + dt0.Rows[0][11].ToString();
                if (Convert.ToInt32(dt0.Rows[0][12]) == 1)
                {
                    IsClosed = true;
                }
                else
                {
                    IsClosed = false;
                }
                DataTable dt = callto_cierre_registroatencion(Convert.ToInt32(ddown002.SelectedValue), Convert.ToInt32(ddown_AnoCierre.SelectedValue + ddown_MesCierre.SelectedValue), sexo);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (dt.Columns[j].ColumnName.Length < 4)
                        {
                            if (dt.Rows[i][j].ToString() == "X")
                            {
                                dt.Rows[i][j] = "";
                            }
                        }
                    }
                }

                DataView dv = new DataView(dt);
                DataTable dtdias = callto_cierre_diashabiles(Convert.ToInt32(ddown002.SelectedValue), Convert.ToInt32(ddown_AnoCierre.SelectedValue + ddown_MesCierre.SelectedValue));

                for (int i = 0; i < dtdias.Columns.Count; i++)
                {
                    if (dtdias.Rows[0][i].ToString() == "0")
                    {
                        dt.Columns.Remove(dtdias.Columns[i].ColumnName);
                    }
                }

                if (Convert.ToInt32(DateTime.Now.Month) == Convert.ToInt32(ddown_MesCierre.SelectedValue) && Convert.ToInt32(DateTime.Now.Year) == Convert.ToInt32(ddown_AnoCierre.SelectedItem.Text))
                {
                    DataTable dtProyectosAsistencia = callto_proyectos_asistencia(); // traigo los proyectos para aplicar filtros (Proyectos SENAME)
                    if (dtProyectosAsistencia.Rows.Count > 0)
                    {
                        Bloquear = false;
                        for (int i = 0; i < dtProyectosAsistencia.Rows.Count; i++)
                        {
                            if (dtProyectosAsistencia.Rows[i][1].ToString() == ddown002.SelectedValue.ToString())
                            {
                                CodProyecto = Convert.ToInt32(dtProyectosAsistencia.Rows[i][0]);
                                if (Convert.ToInt32(dtProyectosAsistencia.Rows[i][2]) == 0)
                                {
                                    Bloquear = true;
                                    CodProyecto = Convert.ToInt32(dtProyectosAsistencia.Rows[i][0]);
                                    Imb006.Visible = true;
                                    Imb003.Visible = true;
                                }
                                else
                                {

                                }
                            }
                            else
                            {

                            }
                        }
                    }
                }
                //GridItemStyle gis = new GridItemStyle();

                if (dt.Rows.Count > 0)
                {
                    Imb003.Visible = true;
                    Imb007.Visible = true;
                    alerts.Visible = false;
                    lbl003.Visible = false;

                    DataTable dtProyectosAsistencia = callto_proyectos_asistencia(); // traigo los proyectos para aplicar filtros (Proyectos SENAME)
                    if (dtProyectosAsistencia.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtProyectosAsistencia.Rows.Count; i++)
                        {
                            if (dtProyectosAsistencia.Rows[i][1].ToString() == ddown002.SelectedValue.ToString())
                            {
                                CodProyecto = Convert.ToInt32(dtProyectosAsistencia.Rows[i][0]);
                                Imb006.Visible = true;
                                Imb003.Visible = true;
                            }
                        }
                    }
                    try
                    {
                        contadorgeneral();
                    }
                    catch { }

                    NuevaGrilla.Rows.Clear();
                    DateTime ahora = DateTime.Now;

                    TableRow fila = new TableRow(); fila.ID = "fila1header"; fila.TableSection = TableRowSection.TableHeader;
                    TableCell celda = new TableCell();

                    //gfontbrevis: cabecera con mes y semanas;
                    anioConsultado.Value = ddown_AnoCierre.SelectedValue; anioConsultado.Visible = true;
                    mesConsultado.Value = (ddown_MesCierre.SelectedIndex).ToString(); mesConsultado.Visible = true;
                    celda = new TableHeaderCell(); celda.ColumnSpan = 7; celda.ForeColor = Color.White; celda.CssClass = "titulo-tabla-centrado";
                    celda.Text = ddown_MesCierre.SelectedItem.ToString().ToUpper() + " " + ddown_AnoCierre.SelectedValue;
                    
                    fila.Cells.Add(celda);
                    celda = new TableHeaderCell(); celda.ColumnSpan = 7; celda.ID = "tabsSemanas"; celda.CssClass = "no-padding"; fila.Cells.Add(celda);

                    fila.BackColor = System.Drawing.Color.SteelBlue;
                    NuevaGrilla.Rows.Add(fila);
                    fila = new TableRow(); fila.ID = "fila2header"; fila.TableSection = TableRowSection.TableHeader;

                    
                    celda = new TableHeaderCell(); celda.Text = "Apellido Paterno"; fila.Cells.Add(celda);
                    celda = new TableHeaderCell(); celda.Text = "Apellido Materno"; celda.HorizontalAlign = HorizontalAlign.Left; fila.Cells.Add(celda);
                    celda = new TableHeaderCell(); celda.Text = "Nombres"; celda.HorizontalAlign = HorizontalAlign.Left; fila.Cells.Add(celda);
                    celda = new TableHeaderCell(); celda.Text = "Cod. Ingreso Egreso"; celda.HorizontalAlign = HorizontalAlign.Center; fila.Cells.Add(celda);
                    celda = new TableHeaderCell(); celda.Text = "Codigo Niño"; celda.HorizontalAlign = HorizontalAlign.Center; fila.Cells.Add(celda);
                    celda = new TableHeaderCell(); celda.Text = "Sexo"; celda.HorizontalAlign = HorizontalAlign.Center; fila.Cells.Add(celda);
                    celda = new TableHeaderCell(); celda.Text = "Cod. Dias Atención"; celda.HorizontalAlign = HorizontalAlign.Center; fila.Cells.Add(celda);

                    for (int i = 1; i <= dtdias.Columns.Count; i++)
                    {
                        if (Convert.ToInt16(dtdias.Rows[0][i - 1]) != 0)
                        {
                            celda = new TableHeaderCell();
                            celda.Text = i.ToString();
                            //gfontbrevis; asigna clase a dias segun semana que le corresponde
                            int semana = (i-1) / 7 + 1;
                            celda.CssClass = "semana" + semana.ToString();
                            celda.BackColor = Color.Orange;
                            //si el mes esta ABIERTO y es el mes actual se marca el dia actual
                            if ((ahora.Month == ddown_MesCierre.SelectedIndex) && (ahora.Year == Convert.ToInt16(ddown_AnoCierre.SelectedItem.ToString())))
                            {
                                if ((!IsClosed) && (i == ahora.Day))
                                    celda.BackColor = Color.DarkOrange;
                                    
                                
                            }

                            celda.HorizontalAlign = HorizontalAlign.Center;
                            fila.Cells.Add(celda);
                        }
                    }
                    
                    celda = new TableHeaderCell();
                    celda.Text = "Dias Atendidos"; celda.HorizontalAlign = HorizontalAlign.Center; fila.Cells.Add(celda);
                    fila.BackColor = System.Drawing.Color.SteelBlue;
                    fila.ForeColor = System.Drawing.Color.White;
                    NuevaGrilla.Rows.Add(fila);

                    
                    celda = new TableHeaderCell();
                    celda.ColumnSpan = NuevaGrilla.Rows[1].Cells.Count - 14; celda.ID = "rellenofila1header"; celda.CssClass = "no-padding"; NuevaGrilla.Rows[0].Cells.Add(celda);

                    int[,] arr_Resumen = new int[2, NuevaGrilla.Rows[1].Cells.Count + 1];
                    for (int x = 0; x < dt.Rows.Count; x++)
                    {
                        fila = new TableRow();
                        for (int y = 0; y < dt.Columns.Count; y++)
                        {
                            celda = new TableCell();
                            if (y < 3)
                                celda.HorizontalAlign = HorizontalAlign.Left;
                            else
                                celda.HorizontalAlign = HorizontalAlign.Center;

                            if (y == dt.Columns.Count - 1)
                            {

                                celda.HorizontalAlign = HorizontalAlign.Center;
                            }

                            if (y > 6)
                            {
                                switch (dt.Rows[x][y].ToString())
                                {
                                    case "P":
                                    case "I":
                                    case "F":
                                    case "H":
                                        arr_Resumen[0, y] += 1;
                                        arr_Resumen[0, NuevaGrilla.Rows[1].Cells.Count - 1] += 1;
                                        break;
                                    case "A":
                                    case "C":
                                        arr_Resumen[1, y] += 1;
                                        arr_Resumen[1, NuevaGrilla.Rows[1].Cells.Count - 1] += 1;
                                        break;
                                    case "": break;
                                }

                                if (y < 38)
                                {
                                    //gfontbrevis: asigna clase a dias segun semana que le corresponde
                                    if (Convert.ToInt16(dtdias.Rows[0][y - 7]) != 0)
                                         {
                                            int semana = (y - 7) / 7 + 1;
                                            celda.CssClass = "semana" + semana.ToString();
                                        }
                                    
                                    ////si el mes es anterior
                                    if ((ahora.Month == ddown_MesCierre.SelectedIndex) && (ahora.Year == Convert.ToInt16(ddown_AnoCierre.SelectedItem.ToString())))
                                    {
                                        if (!Bloquear)
                                        {
                                            //si el mes esta abierto solo DESDE el dia que se abre para atras
                                            if ((!IsClosed) && ((y - 6) <= ahora.Day))
                                            {
                                                celda.Attributes.Add("OnClick", "javascript:return getVal(this);");
                                            }
                                        }
                                        else
                                            if ((!IsClosed) && ((y - 6) == ahora.Day))
                                                celda.Attributes.Add("OnClick", "javascript:return getVal(this);");
                                                
                                    }
                                    else
                                    {
                                        if (!Bloquear)
                                        {
                                            //si el mes esta abierto se abre todo
                                            if (!IsClosed)
                                                celda.Attributes.Add("OnClick", "javascript:return getVal(this);");
                                        }
                                    }
                                    //celda.Attributes.Add("Class", "mira2");


                                }
                            }
                            celda.Text = dt.Rows[x][y].ToString();
//                            celda.Width = 21;
                            celda.Width = 10;
                            fila.Cells.Add(celda);
                        }
                        NuevaGrilla.Rows.Add(fila);

                    }

                    for (int x = 0; x < 2; x++)
                    {
                        fila = new TableRow();
                        celda = new TableCell();
                        celda.Font.Bold = true;
                        celda.ColumnSpan = 7;
                        celda.HorizontalAlign = HorizontalAlign.Right;
                        if (x == 0)
                            celda.Text = "Total Atendidos";
                        else
                            celda.Text = "Total Inasistencia";
                        fila.Cells.Add(celda);

                        for (int y = 0; y < dt.Columns.Count; y++)
                        {
                            if (y > 6)
                            {
                                celda = new TableCell();
                                celda.Font.Bold = true;
                                if (arr_Resumen[x, y].ToString() != "0")
                                    celda.Text = arr_Resumen[x, y].ToString();
                                celda.HorizontalAlign = HorizontalAlign.Right;
                                //gfontbrevis; asigna clase a dias segun semana que le corresponde
                                if (y < dt.Columns.Count - 1) {
                                    int semana = (y - 7) / 7 + 1;
                                    celda.CssClass = "semana" + semana.ToString();
                                }
                                fila.Cells.Add(celda);
                            }
                        }
                        
                        fila.ForeColor = System.Drawing.Color.SteelBlue;
                        NuevaGrilla.Rows.Add(fila);
                    }
                    //gfontbrevis
                    lbl_resumen_filtro.Text = " Resumen: ";
                    //lbl_resumen_filtro.Text += "- Institución: " + ddown001.SelectedItem.Text.Trim() + "<br>";
                    lbl_resumen_filtro.Text += ddown002.SelectedItem.Text.Trim() + " / " ;
                    if (ddown003.SelectedIndex > 0)
                    {
                      lbl_resumen_filtro.Text += ddown003.SelectedItem.Text.Trim() + " / ";
                    }

                    lbl_resumen_filtro.Text += ddown_MesCierre.SelectedItem.Text + " de " + ddown_AnoCierre.SelectedItem.Text + " / ";
                    lbl_resumen_filtro.Text += lbl001.Text;
                    if (rdo_SexoA.Checked == true)
                    {
                      //lbl_resumen_filtro.Text += " / Sexo: " + rdo_SexoA.Text + "";
                    }
                    if (rdo_SexoF.Checked == true)
                    {
                      lbl_resumen_filtro.Text += " / Sexo: " + rdo_SexoF.Text + "";
                    }
                    if (rdo_SexoM.Checked == true)
                    {
                      lbl_resumen_filtro.Text += " / Sexo: " + rdo_SexoM.Text + "";
                    }

                    lbl_resumen_filtro.Visible = true;
                    lbl_resumen_filtro.Style.Add("display", "none");

                    if (!IsClosed)
                    {
                        Imb003.Visible = !Imb006.Visible;
                    }
                }
                else
                {
                    //Imb003.Visible = true;
                    Imb003.Visible = false; // se agrega para ocultar los botones cuando no hay resultados
                    Imb004.Visible = false;

                    Imb007.Visible = false;
                    alerts.Visible = true;
                    lbl003.Visible = true;
                }
                if (IsClosed)
                {
                    Imb003.Visible = false;
                    imb005.Visible = false;
                }

            }
        }
        if (NuevaGrilla.Rows.Count > 0)
            //imb005.Visible = true;
            imb005.Visible = false; //JLBL-20150618: No mostar Regenerar
        else
            imb005.Visible = false;

        //alerts.Visible = false;
        lbl004.Visible = false;
        lbl005.Visible = false;
        alertSuccess.Visible = false;
        lbl_error_dia.Visible = false;
        //gfontbrevis: para cuando se habiliten el cambio de proyecto en asistencia.
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "setearTabsSemanas", "setearTabsSemanas();", true);

        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "guardagrilla", "guardagrilla();", true);
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ConfirmaAsistencia(1)", "$('#ConfirmaAsistencia').val('1');", true);
        
      
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
            //ddown002.BackColor = System.Drawing.Color.White;
        }
        if (ddown_MesCierre.SelectedIndex == 0)
        {
            ddown_MesCierre.BackColor = System.Drawing.Color.Pink;
            v = false;
        }
        else
        {
            //ddown_MesCierre.BackColor = System.Drawing.Color.White;
        }
        return v;
    }

    protected void ddown001_SelectedIndexChanged(object sender, EventArgs e)
    {
        getproyectos();

        if (ddown002.SelectedIndex > -1)
        {
            getinmueble();
        }
        validatefields();
        fn_buscar();
    }
    protected void ddown002_SelectedIndexChanged(object sender, EventArgs e)
    {
        getinmueble();
        validatefields();
        fn_buscar();

        ArrayList al = new ArrayList();
        al = (ArrayList)Session["variables_impresion"];
        al[0] = ddown002.SelectedValue;
        Session["variables_impresion"] = al;
    }
    //protected void grd001_ClickCellButton(object sender, CellEventArgs e)
    //{
    //    e.Cell.Text = "A";
    //}
    //protected void grd001_Click(object sender, ClickEventArgs e)
    //{
    //    if (e.Cell != null && !IsClosed && e.Cell.Key.Length < 4)
    //    {
    //        DataTable dt = new DataTable();
    //        proyectocoll pc = new proyectocoll();
    //        dt = pc.GetProyectos2(ASP.global_asax.globaconn, Convert.ToInt32(ddown002.SelectedValue));

    //        if (Bloquear)
    //        {
    //            if (Convert.ToInt32(e.Cell.Column.Index) == Convert.ToInt32(DateTime.Now.Day) + 6
    //                && Convert.ToInt32(ddown_MesCierre.SelectedValue) == Convert.ToInt32(DateTime.Now.Month)
    //                && Convert.ToInt32(ddown_AnoCierre.SelectedItem.ToString()) == Convert.ToInt32(DateTime.Now.Year))
    //            {
    //                lbl_error_dia.Visible = false;
    //                if (e.Cell.Text == "P")
    //                {
    //                    e.Cell.Text = "A";
    //                    e.Cell.Style.BackColor = System.Drawing.Color.Red;
    //                }
    //                else if (e.Cell.Text == "A")
    //                {
    //                    e.Cell.Text = "F";
    //                    e.Cell.Style.BackColor = System.Drawing.Color.Yellow;
    //                }
    //                //kvega
    //                else if (e.Cell.Text == "F")
    //                {
    //                    e.Cell.Text = "H";
    //                    e.Cell.Style.BackColor = System.Drawing.Color.Aquamarine;
    //                }
    //                //else if (e.Cell.Text == "F") kvega
    //                else if (e.Cell.Text == "H")
    //                {
    //                    if (dt.Rows[0]["CodInstitucion"].ToString() == "6050" && dt.Rows[0]["CodCausalTerminoProyecto"].ToString() == "20084" && dt.Rows[0]["CodRegion"].ToString() == "13")    // AADD de la LRPA en la RM
    //                    {
    //                        e.Cell.Text = "C";
    //                        e.Cell.Style.BackColor = System.Drawing.Color.PaleVioletRed;
    //                    }
    //                    else
    //                    {
    //                        e.Cell.Text = "P";
    //                        e.Cell.Style.BackColor = System.Drawing.Color.Green;
    //                    }
    //                }
    //                else if (e.Cell.Text == "C")
    //                {
    //                    e.Cell.Text = "P";
    //                    e.Cell.Style.BackColor = System.Drawing.Color.Green;
    //                }
    //                addmodindex(e.Cell.Row.Index, e.Cell.Column.Index - 6);
    //            }
    //            else
    //            {
    //                lbl_error_dia.Visible = true;
    //            }
    //        }
    //        else
    //        {
    //          if (e.Cell.Text == "P")
    //            {
    //                e.Cell.Text = "A";
    //                e.Cell.Style.BackColor = System.Drawing.Color.Red;
    //            }
    //            else if (e.Cell.Text == "A")
    //            {
    //                e.Cell.Text = "F";
    //                e.Cell.Style.BackColor = System.Drawing.Color.Yellow;
    //            }
    //            //kvega
    //            else if (e.Cell.Text == "F")
    //            {
    //                e.Cell.Text = "H";
    //                e.Cell.Style.BackColor = System.Drawing.Color.Aquamarine;
    //            }
    //            //else if (e.Cell.Text == "F") kvega
    //            else if (e.Cell.Text == "H")
    //            {
    //                if (dt.Rows[0]["CodInstitucion"].ToString() == "6050" && dt.Rows[0]["CodCausalTerminoProyecto"].ToString() == "20084")    // AADD de la LRPA
    //                {
    //                    e.Cell.Text = "C";
    //                    e.Cell.Style.BackColor = System.Drawing.Color.PaleVioletRed;
    //                }
    //                else
    //                {
    //                    e.Cell.Text = "P";
    //                    e.Cell.Style.BackColor = System.Drawing.Color.Green;
    //                }
    //            }
    //            else if (e.Cell.Text == "C")
    //            {
    //                e.Cell.Text = "P";
    //                e.Cell.Style.BackColor = System.Drawing.Color.Green;
    //            }
    //            addmodindex(e.Cell.Row.Index, e.Cell.Column.Index - 6);


    //        }
    //        lbl004.Visible = false;
    //        lbl005.Visible = false;
    //    }

    //}

    private void addmodindex(int index, int column)
    {
        if (arrindexm.IndexOf(index) == -1)
        {
            arrindexm.Add(index);
            arrcolumn.Add(column);
        }
    }

    protected void Imb007_Click1(object sender, EventArgs e)
    {
        ExportarExcel(GrillaHTML.Value);
    }

    private void ExportarExcel(string output) //recibe el html de la grilla
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("Content-Disposition", "attachment;filename=AsistenciaExport.xls");
        Response.ContentType = "application/ms-excel";
        Response.Charset = "UTF-8";
        Response.ContentEncoding = System.Text.Encoding.Unicode;
        Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
        this.EnableViewState = true;
        Response.Write(output.ToString());
        Response.End();
    }

    private DataTable Ordenar_Cadena(string cadenaIN)
    {
        DataTable mydt = new DataTable();
        //ordena y tabula el chorizo que entra y entrega un datatable ordenado
        if (cadenaIN != "VACIO")
        {

            //primero obtener un array con las filas
            string[] filas = cadenaIN.Split(Convert.ToChar("|"));

            //crear las columnas en el DT
            if (filas.Length >= 1)
            {
                
                mydt.Columns.Add("ap_pat", typeof(string));
                mydt.Columns.Add("ap_mat", typeof(string));
                mydt.Columns.Add("nombre", typeof(string));//gfontbrevis
                mydt.Columns.Add("ICodIE", typeof(string));
                mydt.Columns.Add("codnino", typeof(string));
                mydt.Columns.Add("sexo", typeof(string));
                mydt.Columns.Add("cod_diasat", typeof(string));
                mydt.Columns.Add("d1", typeof(string)); //dias 1-31
                mydt.Columns.Add("d2", typeof(string));
                mydt.Columns.Add("d3", typeof(string));
                mydt.Columns.Add("d4", typeof(string));
                mydt.Columns.Add("d5", typeof(string));
                mydt.Columns.Add("d6", typeof(string));
                mydt.Columns.Add("d7", typeof(string));
                mydt.Columns.Add("d8", typeof(string));
                mydt.Columns.Add("d9", typeof(string));
                mydt.Columns.Add("d10", typeof(string));
                mydt.Columns.Add("d11", typeof(string));
                mydt.Columns.Add("d12", typeof(string));
                mydt.Columns.Add("d13", typeof(string));
                mydt.Columns.Add("d14", typeof(string));
                mydt.Columns.Add("d15", typeof(string));
                mydt.Columns.Add("d16", typeof(string));
                mydt.Columns.Add("d17", typeof(string));
                mydt.Columns.Add("d18", typeof(string));
                mydt.Columns.Add("d19", typeof(string));
                mydt.Columns.Add("d20", typeof(string));
                mydt.Columns.Add("d21", typeof(string));
                mydt.Columns.Add("d22", typeof(string));
                mydt.Columns.Add("d23", typeof(string));
                mydt.Columns.Add("d24", typeof(string));
                mydt.Columns.Add("d25", typeof(string));
                mydt.Columns.Add("d26", typeof(string));
                mydt.Columns.Add("d27", typeof(string));
                mydt.Columns.Add("d28", typeof(string));
                mydt.Columns.Add("d29", typeof(string));
                mydt.Columns.Add("d30", typeof(string));
                mydt.Columns.Add("d31", typeof(string));
                mydt.Columns.Add("dias_at", typeof(string));



                //segundo obtener las columnas y crear la tabla
                foreach (string fila in filas)
                {
                    //creo fila temporal
                    DataRow DR;
                    DR = mydt.NewRow();

                    //columnas
                    string[] columnas = fila.Split(Convert.ToChar(";"));

                    //cargar la data de la fila en la tabla
                    int indicecol = 0;
                    foreach (string col in columnas)
                    {
                        //carga data
                        DR[indicecol] = col;
                        indicecol += 1;
                    }
                    //anexo fila 
                    mydt.Rows.Add(DR);
                }
            }
        }
        else
        {
            mydt = null;
        }

        return mydt;
    }

    private void contadorgeneral()
    {
        DataTable dtdias = callto_cierre_diashabiles(Convert.ToInt32(ddown002.SelectedValue), Convert.ToInt32(ddown_AnoCierre.SelectedValue + ddown_MesCierre.SelectedValue));

        DataRow dr = dtdias.NewRow();
        DataRow drA = dtdias.NewRow();
        string celltext = string.Empty;
        int totalesIPF = 0;
        int totalesA = 0;

        dtdias.Rows.Add(dr);
        dtdias.Rows.Add(drA);

        ArrayList arrdias = new ArrayList();
        for (int i = 0; i < dtdias.Columns.Count; i++)
        {
            if (dtdias.Rows[0][i].ToString() == "0")
            {
                arrdias.Add(dtdias.Columns[i].ColumnName);
            }
        }
        for (int i = 0; i < arrdias.Count; i++)
        {
            dtdias.Columns.Remove(arrdias[i].ToString());
        }

        dtdias.Rows.RemoveAt(0);
        dtdias.Columns.Add("Item");
        dtdias.Rows[0]["Item"] = "Total Atendidos";
        dtdias.Rows[1]["Item"] = "Total Inasistencia";

        dtdias.Columns.Add("Totales");
        dtdias.Rows[0]["Totales"] = totalesIPF.ToString();
        dtdias.Rows[1]["Totales"] = totalesA.ToString();

        Imb003.Visible = !Imb006.Visible;
    }
    protected void ddown003_SelectedIndexChanged(object sender, EventArgs e)
    {
        alerts.Visible = false;
        lbl_error_dia.Visible = false;
        fn_buscar();

        ArrayList al = new ArrayList();
        al = (ArrayList)Session["variables_impresion"];
        al[1] = Convert.ToInt32(Convert.ToString(ddown_AnoCierre.SelectedValue) + Convert.ToString(ddown_MesCierre.SelectedValue));
        Session["variables_impresion"] = al;
    }
    protected void rdo_SexoA_CheckedChanged(object sender, EventArgs e)
    {
        fn_buscar();
    }


    private DataTable get_asistenciavalidado(int mesano, int dia, int ProyectoId)
    {
        Conexiones con = new Conexiones();
        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + con.Servidor + " ;Database= " + con.Base + " ; User ID= " + con.Usuario + " ;Password= " + con.Passw + " ;Trusted_Connection=False");
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "get_asistenciavalidado";
        sqlc.Parameters.Add("@MesAno", SqlDbType.Int, 4).Value = mesano;
        sqlc.Parameters.Add("@Dia", SqlDbType.Int, 5).Value = dia;
        sqlc.Parameters.Add("@ProyectoId", SqlDbType.Int, 5).Value = ProyectoId;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    private DataTable callto_cierre_ConfirmaRegistro(int mesano, int dia, int ProyectoId, int IdUsuarioActualizacion, DateTime fecha)
    {
        Conexiones con = new Conexiones();
        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + con.Servidor + " ;Database= " + con.Base + " ; User ID= " + con.Usuario + " ;Password= " + con.Passw + " ;Trusted_Connection=False");
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "insert_asistenciaValidado";
        sqlc.Parameters.Add("@MesAno", SqlDbType.Int, 4).Value = mesano;
        sqlc.Parameters.Add("@Dia", SqlDbType.Int, 5).Value = dia;
        sqlc.Parameters.Add("@ProyectoId", SqlDbType.Int, 5).Value = ProyectoId;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 6).Value = IdUsuarioActualizacion;
        sqlc.Parameters.Add("@Estado", SqlDbType.Bit).Value = 1;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime).Value = fecha;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
    public void metodoclick_grilla()
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
        DataTable dt = callto_cierre_registroatencion(Convert.ToInt32(ddown002.SelectedValue), Convert.ToInt32(ddown_AnoCierre.SelectedValue + ddown_MesCierre.SelectedValue), sexo);

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

    //protected void Imb003_Click(object sender, EventArgs e)
    //{
    //    DataTable mydt = new DataTable();
    //    mydt = Ordenar_Cadena(CampoDatosAsistencia.Value);

    //    try
    //    {

    //        foreach (DataRow fila in mydt.Rows)
    //        {
    //            callto_cierre_guardaregistro(Convert.ToInt32(fila["ICodIE"]), Convert.ToInt32(ddown_AnoCierre.SelectedValue + ddown_MesCierre.SelectedValue),
    //                       fila["d1"].ToString(), fila["d2"].ToString(), fila["d3"].ToString(), fila["d4"].ToString(), fila["d5"].ToString(), fila["d6"].ToString(),
    //                        fila["d7"].ToString(), fila["d8"].ToString(), fila["d9"].ToString(), fila["d10"].ToString(), fila["d11"].ToString(), fila["d12"].ToString(),
    //                        fila["d13"].ToString(), fila["d14"].ToString(), fila["d15"].ToString(), fila["d16"].ToString(), fila["d17"].ToString(), fila["d18"].ToString(),
    //                        fila["d19"].ToString(), fila["d20"].ToString(), fila["d21"].ToString(), fila["d22"].ToString(), fila["d23"].ToString(), fila["d24"].ToString(),
    //                        fila["d25"].ToString(), fila["d26"].ToString(), fila["d27"].ToString(), fila["d28"].ToString(), fila["d29"].ToString(), fila["d30"].ToString(),
    //                        fila["d31"].ToString(), 1);
    //        }

    //        imb005_Click(sender, e);
    //        fn_buscar();
    //        contadorgeneral();

    //        //Response.Redirect("cierre_registroatencion.aspx?sw=4&codinst=" + ddown002.SelectedValue + "&M=" + ddown_MesCierre.SelectedValue + "&A=" + ddown_AnoCierre.SelectedValue);
    //    }
    //    catch
    //    {

    //    }



    //}
    protected void Imb004_Click(object sender, EventArgs e)
    {
        if (ddown002.Items.Count > 0 && Convert.ToInt32(ddown002.SelectedValue) > 0)
        {
            //string url = string.Format("Cierre_RegistroAtencionReporte.aspx?CodProyecto=" + ddown002.SelectedValue + "&AnoMes=" + ddown_AnoCierre.SelectedValue + ddown_MesCierre.SelectedValue + "&IdUsr=" + Session["IdUsuario"].ToString());
            //iframe_imprimir.Attributes.Add("src", url);
            //modal_imprimir.Visible = true;
        }
    }
    protected void imb005_Click(object sender, EventArgs e)
    {
        DataTable dt0 = callto_cierre_regenerar(Convert.ToInt32(ddown002.SelectedValue), Convert.ToInt32(ddown_AnoCierre.SelectedValue + ddown_MesCierre.SelectedValue), 1);
    }

    protected void btnGuardaAsistencia_Click(object sender, EventArgs e)
    {
        // se agrega valor a variable de forma temporal 
        //ConfirmaAsistencia.Value = "1";

        if (ConfirmaAsistencia.Value == "1")
        {

            DataTable mydt = new DataTable();
            mydt = Ordenar_Cadena(CampoDatosAsistencia.Value);

            try
            {

            foreach (DataRow fila in mydt.Rows)
            {
                callto_cierre_guardaregistro(Convert.ToInt32(fila["ICodIE"]), Convert.ToInt32(ddown_AnoCierre.SelectedValue + ddown_MesCierre.SelectedValue),
                           fila["d1"].ToString(), fila["d2"].ToString(), fila["d3"].ToString(), fila["d4"].ToString(), fila["d5"].ToString(), fila["d6"].ToString(),
                            fila["d7"].ToString(), fila["d8"].ToString(), fila["d9"].ToString(), fila["d10"].ToString(), fila["d11"].ToString(), fila["d12"].ToString(),
                            fila["d13"].ToString(), fila["d14"].ToString(), fila["d15"].ToString(), fila["d16"].ToString(), fila["d17"].ToString(), fila["d18"].ToString(),
                            fila["d19"].ToString(), fila["d20"].ToString(), fila["d21"].ToString(), fila["d22"].ToString(), fila["d23"].ToString(), fila["d24"].ToString(),
                            fila["d25"].ToString(), fila["d26"].ToString(), fila["d27"].ToString(), fila["d28"].ToString(), fila["d29"].ToString(), fila["d30"].ToString(),
                            fila["d31"].ToString(), 1);
            }
                imb005_Click(sender, e);
                arrindexm = new ArrayList();
                fn_buscar();
                contadorgeneral();

            }
            catch {
            
            }


            DataTable dt1 = get_asistenciavalidado(Convert.ToInt32(ddown_AnoCierre.SelectedValue + ddown_MesCierre.SelectedValue), Convert.ToInt32(DateTime.Now.Day), CodProyecto);
            if (dt1.Rows.Count > 0) // tiene registro en el mismo dia, no se puede volver a grabar
            {
                alerts.Visible = false;
                lbl004.Visible = true;
                lbl005.Visible = false;
                alertSuccess.Visible = true;

                lbl_error_dia.Visible = false;
            }
            else
            {
                try
                {
                    callto_cierre_ConfirmaRegistro(Convert.ToInt32(ddown_AnoCierre.SelectedValue + ddown_MesCierre.SelectedValue),
                        Convert.ToInt32(DateTime.Now.Day),
                        CodProyecto, Convert.ToInt32(Session["IdUsuario"]), DateTime.Now);
                    arrindexm = new ArrayList();
                    fn_buscar();
                    contadorgeneral();
                    alerts.Visible = false;
                    lbl004.Visible = false;
                    lbl005.Visible = true;
                    alertSuccess.Visible = true;

                    lbl_error_dia.Visible = false;
                }
                catch (Exception ex)
                {

                }
            }
            ConfirmaAsistencia.Value = "0";
        }
        else
        {
            fn_buscar();
        }
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
    protected void btnGuardaAsistenciaSinConfirmar_Click(object sender, EventArgs e)
    {
        DataTable mydt = new DataTable();
        mydt = Ordenar_Cadena(CampoDatosAsistencia.Value);

        try
        {

            foreach (DataRow fila in mydt.Rows)
            {
                callto_cierre_guardaregistro(Convert.ToInt32(fila["ICodIE"]), Convert.ToInt32(ddown_AnoCierre.SelectedValue + ddown_MesCierre.SelectedValue),
                           fila["d1"].ToString(), fila["d2"].ToString(), fila["d3"].ToString(), fila["d4"].ToString(), fila["d5"].ToString(), fila["d6"].ToString(),
                            fila["d7"].ToString(), fila["d8"].ToString(), fila["d9"].ToString(), fila["d10"].ToString(), fila["d11"].ToString(), fila["d12"].ToString(),
                            fila["d13"].ToString(), fila["d14"].ToString(), fila["d15"].ToString(), fila["d16"].ToString(), fila["d17"].ToString(), fila["d18"].ToString(),
                            fila["d19"].ToString(), fila["d20"].ToString(), fila["d21"].ToString(), fila["d22"].ToString(), fila["d23"].ToString(), fila["d24"].ToString(),
                            fila["d25"].ToString(), fila["d26"].ToString(), fila["d27"].ToString(), fila["d28"].ToString(), fila["d29"].ToString(), fila["d30"].ToString(),
                            fila["d31"].ToString(), 1);
            }

            imb005_Click(sender, e);
            fn_buscar();
            contadorgeneral();

            alerts.Visible = false;
            lbl004.Visible = true;
            lbl005.Visible = false;
            alertSuccess.Visible = true;
        }
        catch
        {

        }
    }
}