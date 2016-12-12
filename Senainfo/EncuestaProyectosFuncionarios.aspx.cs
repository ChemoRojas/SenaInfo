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

using System.Collections.Generic;

public partial class EncuestaProyectosFuncionarios : System.Web.UI.Page
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
    public DataTable dtTrabajadores
    {
        get { return (DataTable)Session["dtTrabajadores"]; }
        set { Session["dtTrabajadores"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    dtEncuestasPreguntas = GetEncuestasPreguntas();
        //    dtEncuestas = GetEncuestas();
        //    NumeroRow = 0;
        //    LlenaPreguntas(NumeroRow);
        //    getprofesion();
        //    DataTable dtTrabajadores = new DataTable();

        //    dtTrabajadores.Columns.Add(new DataColumn("Rut", typeof(String)));              //0
        //    dtTrabajadores.Columns.Add(new DataColumn("Apellido_Paterno", typeof(String))); //1
        //    dtTrabajadores.Columns.Add(new DataColumn("Apellido_Materno", typeof(String))); //2   
        //    dtTrabajadores.Columns.Add(new DataColumn("Nombres", typeof(String)));          //3
        //    dtTrabajadores.Columns.Add(new DataColumn("CodProfesion", typeof(int)));        //4
        //    dtTrabajadores.Columns.Add(new DataColumn("Profesion", typeof(String)));        //5
        //    dtTrabajadores.Columns.Add(new DataColumn("OtraProfesionOficio", typeof(String)));  //6

        //    grdTrabajadores.DataSource = dtTrabajadores;
        //    grdTrabajadores.DataBind();
        //    Session["tblSession"] = dtTrabajadores;

        //    EncuestasColl ecoll = new EncuestasColl();
        //    string[] Arr_Devueltos = new string[4];
        //    Arr_Devueltos = ecoll.ExisteEncuesta(ASP.global_asax.globaconn, Arr_Devueltos);
        //    intCodEncuesta = Convert.ToInt16(Arr_Devueltos[1]);
            
        //    DataTable dt = ecoll.GetDataEncuestaListaEspera(ASP.global_asax.globaconn, Convert.ToString(Session["IdUsuario"]), intCodEncuesta);
        //    if (dt.Rows.Count == 0)
        //        Response.Redirect("default.aspx");

        //    txtInstitucion.Text = (string)dt.Rows[0]["NombreInstitucion"];
        //    txtProyecto.Text = (string)dt.Rows[0]["NombreProyecto"];
        //    txtModelo.Text = (string)dt.Rows[0]["NombreModeloIntervencion"];
        //    intCodProyecto = (int)dt.Rows[0]["CodProyecto"];
        //}
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
        LlenaPreguntas(NumeroRow);
    }
    protected int GuardaRespuestas(int NumeroRow)
    {
        //for (int x = 0; x < dtEncuestas.Tables[0].Rows.Count; x++)
        //{
        //    DropDownList ddownNota = (DropDownList)grPreguntas.Rows[x].Cells[1].FindControl("ddownNota");

        //    if (Convert.ToInt16(ddownNota.SelectedValue) > 0)
        //    {
        //        dtEncuestas.Tables[0].Rows[x]["Nota"] = Convert.ToInt16(ddownNota.SelectedValue);
        //        dtEncuestas.Tables[0].Rows[x]["NoCorresponde"] = 0;
        //        dtEncuestas.Tables[0].Rows[x]["NoSabe"] = 0;
        //        ddownNota.BackColor = System.Drawing.Color.Empty;
        //    }
        //    else
        //    {
        //        dtEncuestas.Tables[0].Rows[x]["Nota"] = 0;
        //    }
        //    if ((int)dtEncuestas.Tables[0].Rows[x]["Nota"] == 0)
        //    {
        //        Label1.Text = "Debe calificar con nota entre 1 y 7";
        //        grPreguntas.Focus();
        //        return 0;
        //    }
        //    else
        //        Label1.Text = String.Empty;
        //}
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
    }
    protected void btAnterior_Click(object sender, EventArgs e)
    {
        //if (NumeroRow == 0)
        //{
        //    lblInstrucciones.Visible = false; txHeader.Visible = false; lblAfirmacion.Visible = false; lbError.Visible = false;
        //    lbPregunta.Visible = false; grPreguntas.Visible = false;
        //    return;
        //}

        //if (GuardaRespuestas(NumeroRow) == 0)
        //    return;

        //NumeroRow -= 1;
        //dtEncuestas.Tables[0].DefaultView.RowFilter = "CodPregunta = " + Convert.ToString(dtEncuestasPreguntas.Tables[0].Rows[NumeroRow]["CodPregunta"]);
        //grPreguntas.DataSource = dtEncuestas;
        //grPreguntas.DataBind();
        //LlenaPreguntas(NumeroRow);
    }
    //protected void btGrabar_Click(object sender, EventArgs e)
    //{
    //    //EncuestasColl ecoll = new EncuestasColl();
    //    //ecoll.InsertaRespuestaListaEspera(ASP.global_asax.globaconn, Convert.ToInt32(Session["IdUsuario"]), intCodEncuesta, intCodProyecto, 0, 0, 0, 0, 0);
    //    if (grdTrabajadores.Rows.Count == 0)
    //    {
    //        lbError.Visible = true;
    //        return;
    //    }
    //    GuardaInformacion();

    //    Response.Redirect("default.aspx");
    //}

    private void GuardaInformacion()
    {
        int returnvalue = 0;
        DbDataReader datareader = null;
        //Database db = new Database(ASP.global_asax.globaconn);

        Conexiones con = new Conexiones();
          DbParameter[] neoprms = {
        con.parametros("@CodEncuesta", SqlDbType.Int, 4, intCodEncuesta),
        con.parametros("@IdUsuario", SqlDbType.Int, 4, Convert.ToInt32(Session["IdUsuario"])),
        con.parametros("@CodProyecto", SqlDbType.Int, 4, intCodProyecto)};

        con.ejecutarProcedimiento("pa_InsertaCabezaRespuestaTrabajadores",neoprms, out datareader);

           

      

        //DbParameter[] neoprms =
        //{
        //    db.neoinprms("@CodEncuesta", DbTypes.Int, 4, intCodEncuesta) ,
        //    db.neoinprms("@IdUsuario", DbTypes.Int, 4, Convert.ToInt32(Session["IdUsuario"])) ,
        //    db.neoinprms("@CodProyecto", DbTypes.Int, 4, intCodProyecto) ,
        //    };

        //db.execproecedure("pa_InsertaCabezaRespuestaTrabajadores", neoprms, out datareader);
        if (datareader.Read())
        {
            returnvalue = Convert.ToInt32(datareader["Retorno"]);
            if (returnvalue != 0)
            {
                List<DbParameter> listDbParameter = new List<DbParameter>();
                string SQL = "INSERT INTO EncuestasUsuarios (CodEncuestas, IdUsuario, CodProyecto) VALUES (@pCodEncuestas, @pIdUsuario, @pCodProyecto)";

                listDbParameter.Add(Conexiones.CrearParametro("@pCodEncuestas", SqlDbType.Int, 4, intCodEncuesta));
                listDbParameter.Add(Conexiones.CrearParametro("@pIdUsuario", SqlDbType.Int, 4, Convert.ToInt32(Session["IdUsuario"])));
                listDbParameter.Add(Conexiones.CrearParametro("@pCodProyecto", SqlDbType.Int, 4, intCodProyecto));

                //db.Execute(SQL);
                con.ejecutar(SQL, listDbParameter);

                DataTable dt = new DataTable();

                dt = (DataTable)Session["tblSession"];
                
                listDbParameter = new List<DbParameter>();
                
                SQL = "INSERT INTO EncuestaTrabajadoresDetalle (iCodEncuestasUsuarios, RUT, Apellido_Paterno, Apellido_Materno, Nombres, CodProfesion, OtraProfesionOficio) "
                    + "VALUES (@piCodEncuestasUsuarios, @pRUT, @pApellido_Paterno, @pApellido_Materno, @pNombres, @pCodProfesion, @pOtraProfesionOficio)";

                listDbParameter.Add(Conexiones.CrearParametro("@piCodEncuestasUsuarios", SqlDbType.Int, 4, returnvalue));
                listDbParameter.Add(Conexiones.CrearParametro("@pRUT", SqlDbType.VarChar, 11, ""));
                listDbParameter.Add(Conexiones.CrearParametro("@pApellido_Paterno", SqlDbType.VarChar, 50, ""));
                listDbParameter.Add(Conexiones.CrearParametro("@pApellido_Materno", SqlDbType.VarChar, 50, ""));
                listDbParameter.Add(Conexiones.CrearParametro("@pNombres", SqlDbType.VarChar, 50, ""));
                listDbParameter.Add(Conexiones.CrearParametro("@pCodProfesion", SqlDbType.Int, 4, -1));
                listDbParameter.Add(Conexiones.CrearParametro("@pOtraProfesionOficio", SqlDbType.VarChar, 100, ""));

                foreach (DataRow row in dt.Rows)
                {
                    listDbParameter[1].Value = row["RUT"];
                    listDbParameter[2].Value = row["Apellido_Paterno"];
                    listDbParameter[3].Value = row["Apellido_Materno"];
                    listDbParameter[4].Value = row["Nombres"];
                    listDbParameter[5].Value = Convert.ToInt32(row["CodProfesion"]);
                    listDbParameter[6].Value = row["OtraProfesionOficio"];

                    
//                    SQL = "INSERT INTO EncuestaTrabajadoresDetalle (iCodEncuestasUsuarios, RUT, Apellido_Paterno, Apellido_Materno, Nombres, CodProfesion) VALUES ('" + row["RUT"] + "', '" + row["Apellido_Paterno"] + "', '" + row["Apellido_Materno"] + "', '" + row["Nombres"] + "', " + row["CodProfesion"] + ")";
                    //db.Execute(SQL);
                    con.ejecutar(SQL, listDbParameter);
                }
            }
        }

        //db.Close();
    }
    protected void rb001_CheckedChanged(object sender, EventArgs e)
    {
    }
    
    //protected void btnSiguienteExperiencia_Click(object sender, EventArgs e)
    //{
        //int intContestaTodo;

        //intContestaTodo = GuardaRespuestasExperiencia();

        //if (intContestaTodo == 0)
        //{
        //    return;
        //}
        //lblInstrucciones.Visible = true; txHeader.Visible = true; lblAfirmacion.Visible = true; lbError.Visible = true;
        //lbPregunta.Visible = true; grPreguntas.Visible = true;
    //}
    //protected void txtRut_ValueChange(object sender, EventArgs e)
    //{
    //    bool sw = false;
    //    try
    //    {
    //        if (txtRut.Text.Length > 3)
    //        {
    //            string rutsinnada = txtRut.Text.Replace(".", "").Replace(",", "").Replace("-", "").Trim();
    //            string digitoingresado = rutsinnada.Substring(rutsinnada.Length - 1, 1);

    //            string digitocalculado = digitoVerificador(Convert.ToInt32(rutsinnada.ToUpper().Replace("K", "").Substring(0, rutsinnada.Length - 1)));
    //            if (digitocalculado.ToUpper() == digitoingresado.ToUpper())
    //            {
    //                string punorut = rutsinnada.ToUpper().Replace("K", "").Substring(0, rutsinnada.Length - 1).Trim();
    //                string rcompleto = punorut + "-" + digitocalculado.ToUpper();
    //                txtRut.Text = rcompleto;
    //                sw = true;
    //                //lblErrorRut.Visible = false;
    //                txtApellidoPaterno.Focus();
    //            }
    //            else
    //            {
    //                txtRut.Text = "";
    //                //lblErrorRut.Text = "RUT INGRESADO NO ES VALIDO";
    //                //lblErrorRut.Visible = true;
    //                txtRut.Focus();
    //            }

    //        }
    //        else
    //        {
    //            txtRut.Text = "";
    //            //lblErrorRut.Text = "RUT INGRESADO NO ES VALIDO";
    //            //this.Form.FindControl("lblErrorRut").Visible = true;
    //                txtRut.Focus();
    //        }
    //    }
    //    catch
    //    {
    //        //lblErrorRut.Text = "RUT INGRESADO NO ES VALIDO";
    //        //lblErrorRut.Visible = true;
    //        txtRut.Focus();
    //    }
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
    //protected void btnContinuar_Click(object sender, EventArgs e)
    //{

    //}
    //protected void btnAgregar_Click(object sender, EventArgs e)
    //{

    //    pnlIngresoTrabajador.Visible = true;
    //}
    private void getprofesion()
    {
        parcoll pcoll = new parcoll();

        DataTable dtproy = pcoll.GetparProfesionOficio();
        ddlCargoFuncion.DataSource = dtproy;
        ddlCargoFuncion.DataTextField = "Descripcion";
        ddlCargoFuncion.DataValueField = "CodProfesion";
        ddlCargoFuncion.DataBind();
    }

    //protected void btnGuardaIngreso_Click(object sender, EventArgs e)
    //{
    //    //if (lblErrorRut.Visible || txtApellidoPaterno.Text == "" || txtApellidoMaterno.Text == "" || txtNombres.Text == "" || ddlCargoFuncion.SelectedItem.Text == "Seleccionar")
    //    if (txtApellidoPaterno.Text == "" || txtApellidoMaterno.Text == "" || txtNombres.Text == "" || ddlCargoFuncion.SelectedItem.Text == "Seleccionar")
    //    {
    //        lbError.Visible = true;
    //        return;
    //    }
    //    lbError.Visible = false;
    //    DataTable dt = new DataTable();

    //    dt = (DataTable)Session["tblSession"];
    //    DataRow dr;
    //    dr = dt.NewRow();
    //    dr["Rut"] = txtRut.Text;
    //    dr["Apellido_Paterno"] = txtApellidoPaterno.Text.ToUpper();
    //    dr["Apellido_Materno"] = txtApellidoMaterno.Text.ToUpper();
    //    dr["Nombres"] = txtNombres.Text.ToUpper();
    //    dr["CodProfesion"] = ddlCargoFuncion.SelectedValue;
    //    dr["Profesion"] = ddlCargoFuncion.SelectedItem.Text;
    //    dr["OtraProfesionOficio"] = txtCargoFuncion.Text.Trim();
    //    dt.Rows.Add(dr);
    //    Session["tblSession"] = dt;
    //    grdTrabajadores.DataSource = dt;
    //    grdTrabajadores.DataBind();
    //    pnlTrabajadores.Visible = true;

    //    txtRut.Text = "";
    //    txtApellidoPaterno.Text = "";
    //    txtApellidoMaterno.Text = "";
    //    txtNombres.Text = "";
    //    getprofesion();
    //    txtCargoFuncion.Text = "";
    //}
    protected void grdTrabajadores_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToLower() == "eliminar")
        {
            int i = 0;
            i = Convert.ToUInt16(e.CommandArgument);
            DataTable dt = (DataTable)Session["tblSession"];         
            dt.Rows.RemoveAt(i);
            Session["tblSession"] = dt;
            grdTrabajadores.DataSource = dt;
            grdTrabajadores.DataBind();
        }
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        pnlIngresoTrabajador.Visible = true;
    }
    protected void ValidarRut()
    {
        bool sw = false;
        try
        {
            if (txtRut.Text.Length > 3)
            {
                string rutsinnada = txtRut.Text.Replace(".", "").Replace(",", "").Replace("-", "").Trim();
                string digitoingresado = rutsinnada.Substring(rutsinnada.Length - 1, 1);

                string digitocalculado = digitoVerificador(Convert.ToInt32(rutsinnada.ToUpper().Replace("K", "").Substring(0, rutsinnada.Length - 1)));
                if (digitocalculado.ToUpper() == digitoingresado.ToUpper())
                {
                    string punorut = rutsinnada.ToUpper().Replace("K", "").Substring(0, rutsinnada.Length - 1).Trim();
                    string rcompleto = punorut + "-" + digitocalculado.ToUpper();
                    txtRut.Text = rcompleto;
                    sw = true;
                    lblErrorRut.Visible = false;
                    txtApellidoPaterno.Focus();
                }
                else
                {
                    txtRut.Text = "";
                    lblErrorRut.Text = "RUT INGRESADO NO ES VALIDO";
                    lblErrorRut.Visible = true;
                    txtRut.Focus();
                }

            }
            else
            {
                txtRut.Text = "";
                lblErrorRut.Text = "RUT INGRESADO NO ES VALIDO";
                this.Form.FindControl("lblErrorRut").Visible = true;
                txtRut.Focus();
            }
        }
        catch
        {
            lblErrorRut.Text = "RUT INGRESADO NO ES VALIDO";
            lblErrorRut.Visible = true;
            txtRut.Focus();
        }
    }
    protected void btnGuardaIngreso_Click(object sender, EventArgs e)
    {
        ValidarRut();

        if (lblErrorRut.Visible || txtApellidoPaterno.Text == "" || txtApellidoMaterno.Text == "" || txtNombres.Text == "" || ddlCargoFuncion.SelectedItem.Text == "Seleccionar")
        {
            lbError.Visible = true;
            return;
        }
        lbError.Visible = false;
        DataTable dt = new DataTable();

        dt = (DataTable)Session["tblSession"];
        DataRow dr;
        dr = dt.NewRow();
        dr["Rut"] = txtRut.Text;
        dr["Apellido_Paterno"] = txtApellidoPaterno.Text.ToUpper();
        dr["Apellido_Materno"] = txtApellidoMaterno.Text.ToUpper();
        dr["Nombres"] = txtNombres.Text.ToUpper();
        dr["CodProfesion"] = ddlCargoFuncion.SelectedValue;
        dr["Profesion"] = ddlCargoFuncion.SelectedItem.Text;
        dr["OtraProfesionOficio"] = txtCargoFuncion.Text.Trim();
        dt.Rows.Add(dr);
        Session["tblSession"] = dt;
        grdTrabajadores.DataSource = dt;
        grdTrabajadores.DataBind();
        pnlTrabajadores.Visible = true;

        txtRut.Text = "";
        txtApellidoPaterno.Text = "";
        txtApellidoMaterno.Text = "";
        txtNombres.Text = "";
        getprofesion();
        txtCargoFuncion.Text = "";
    }
    protected void btGrabar_Click(object sender, EventArgs e)
    {
        if (grdTrabajadores.Rows.Count == 0)
        {
            lbError.Visible = true;
            return;
        }
        GuardaInformacion();
        Response.Redirect("default.aspx");
    }
}
