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
//using neocsharp.NeoDatabase;
using System.Data.Common;

using System.Data.Common;
using System.Collections.Generic;

public partial class ActualizacionProyectos : System.Web.UI.Page
{
    public DataTable dtProyectos
    {
        get { return (DataTable)Session["dtProyectos"]; }
        set { Session["dtProyectos"] = value; }
    }
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            EncuestasColl ecoll = new EncuestasColl();
            string[] Arr_Devueltos = new string[4];
            Arr_Devueltos = ecoll.ExisteEncuesta(Arr_Devueltos);
            intCodEncuesta = Convert.ToInt16(Arr_Devueltos[1]);

            dtProyectos = ecoll.GetDataEncuestaListaEspera(Convert.ToString(Session["IdUsuario"]), intCodEncuesta);
            if (dtProyectos.Rows.Count == 0)
                Response.Redirect("default.aspx");

            txtInstitucion.Text = (string)dtProyectos.Rows[0]["NombreInstitucion"].ToString().Trim();
            txtProyecto.Text = "(" + dtProyectos.Rows[0]["CodProyecto"].ToString().Trim() + ") " + (string)dtProyectos.Rows[0]["NombreProyecto"].ToString().Trim();
            txtModelo.Text = (string)dtProyectos.Rows[0]["NombreModeloIntervencion"].ToString().Trim();
            txtPlazas.Text = (string)dtProyectos.Rows[0]["NumeroPlazas"].ToString().Trim();
            intCodProyecto = (int)dtProyectos.Rows[0]["CodProyecto"];

            lblFechaObligatoria.Text = "ATENCIÓN, a partir del " + Arr_Devueltos[3].Substring(0, 10) + " la actualización es obligatoria.";
            if (System.DateTime.Now >= Convert.ToDateTime(Arr_Devueltos[3]))
            {
                rbEnOtraOpotunidad.Visible = false;
                rbSi.Checked = true;
                Continuar();
            }

            txtDireccion.Text = dtProyectos.Rows[0]["Direccion"].ToString().Trim();
            txtTelefono.Text = dtProyectos.Rows[0]["Telefono"].ToString().Trim();
            txtMail.Text = dtProyectos.Rows[0]["Mail"].ToString().Trim();
            txtFax.Text = dtProyectos.Rows[0]["Fax"].ToString().Trim();
            txtDirector.Text = dtProyectos.Rows[0]["Director"].ToString().Trim();
            txtRutDirector.Text = dtProyectos.Rows[0]["RutDirector"].ToString().Trim();
        }
    }
    //protected void btnContinuar_Click(object sender, EventArgs e)
    //{
    //    Continuar();
    //}

    private void Continuar()
    {
        if (rbSi.Checked)
        {
            pnlDatos.Visible = true;
            rbSi.Visible = false;
            rbEnOtraOpotunidad.Visible = false;
            btnContinuar.Visible = false;
        }
        if (rbEnOtraOpotunidad.Checked)
            Response.Redirect("default.aspx");
    }
    //protected void txt011_ValueChange(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (txtRutDirector.Text.Length > 3)
    //        {
    //            string rutsinnada = txtRutDirector.Text.Replace(".", "").Replace(",", "").Replace("-", "").Trim();
    //            string digitoingresado = rutsinnada.Substring(rutsinnada.Length - 1, 1);

    //            string digitocalculado = digitoVerificador(Convert.ToInt32(rutsinnada.ToUpper().Replace("K", "").Substring(0, rutsinnada.Length - 1)));
    //            if (digitocalculado.ToUpper() == digitoingresado.ToUpper())
    //            {
    //                pnl002.Visible = false;
    //                string punorut = rutsinnada.ToUpper().Replace("K", "").Substring(0, rutsinnada.Length - 1).Trim();
    //                string rcompleto = punorut + "-" + digitocalculado.ToUpper();
    //                txtRutDirector.Text = rcompleto;
    //            }
    //            else
    //            {
    //                lbl002.Text = "RUT INGRESADO NO ES VALIDO";
    //                pnl002.Visible = true;
    //            }
    //        }
    //        else
    //        {
    //            lbl002.Text = "RUT INGRESADO NO ES VALIDO";
    //            pnl002.Visible = true;
    //        }
    //    }
    //    catch
    //    {
    //        lbl002.Text = "RUT INGRESADO NO ES VALIDO";
    //        pnl002.Visible = true;
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
    //protected void btnGuarda_Click(object sender, EventArgs e)
    //{
    //    if (txtDireccion.Text.Trim() == string.Empty)
    //    {
    //        txtDireccion.BackColor = System.Drawing.Color.Pink;
    //        txtDireccion.Focus();
    //        return;
    //    }
    //    else
    //        txtDireccion.BackColor = System.Drawing.Color.White;

    //    if (txtDirector.Text.Trim() == string.Empty)
    //    {
    //        txtDirector.BackColor = System.Drawing.Color.Pink;
    //        txtDirector.Focus();
    //        return;
    //    }
    //    else
    //        txtDirector.BackColor = System.Drawing.Color.White;

    //    if (txtRutDirector.Text.Trim() == string.Empty)
    //    {
    //        txtRutDirector.BackColor = System.Drawing.Color.Pink;
    //        txtRutDirector.Focus();
    //        return;
    //    }
    //    else
    //        txtRutDirector.BackColor = System.Drawing.Color.White;

    //    Database db = new Database(ASP.global_asax.globaconn);
    //    string SQL = "";
    //    SQL += "INSERT INTO EncuestasUsuarios ";
    //    SQL += "(CodEncuestas, IdUsuario, CodProyecto) ";
    //    SQL += "VALUES (" + Convert.ToString(intCodEncuesta) + ", " + Convert.ToString(Session["IdUsuario"]) + ", " + Convert.ToInt32(dtProyectos.Rows[0]["CodProyecto"]) + ")";
    //    db.Execute(SQL);
    //    SQL = "";
    //    SQL += "UPDATE Proyectos ";
    //    SQL += "SET Direccion = '" + txtDireccion.Text.Trim() + "', ";
    //    SQL += "Telefono = '" + txtTelefono.Text.Trim() + "', ";
    //    SQL += "FechaActualizacion = '" + System.DateTime.Now.ToString() + "', ";
    //    SQL += "IdUsuarioActualizacion = '" + Convert.ToString(Session["IdUsuario"]) + "', ";
    //    SQL += "Mail = '" + txtMail.Text.Trim() + "', ";
    //    SQL += "Fax = '" + txtFax.Text.Trim() + "', ";
    //    SQL += "Director = '" + txtDirector.Text.Trim() + "', ";
    //    SQL += "RutDirector = '" + txtRutDirector.Text.Trim() + "' ";
    //    SQL += "WHERE CodProyecto = " + dtProyectos.Rows[0]["CodProyecto"].ToString();
    //    db.Execute(SQL);

    //    db.Close();
    //    Response.Redirect("default.aspx");
    //}
    protected void btnContinuar_Click(object sender, EventArgs e)
    {
        Continuar();
    }
    protected void btnGuarda_Click(object sender, EventArgs e)
    {
        Conexiones con = new Conexiones();
        List<DbParameter> listDbParameter = new List<DbParameter>();

        if (txtDireccion.Text.Trim() == string.Empty)
        {
            txtDireccion.BackColor = System.Drawing.Color.Pink;
            txtDireccion.Focus();
            return;
        }
        else
            txtDireccion.BackColor = System.Drawing.Color.White;

        if (txtDirector.Text.Trim() == string.Empty)
        {
            txtDirector.BackColor = System.Drawing.Color.Pink;
            txtDirector.Focus();
            return;
        }
        else
            txtDirector.BackColor = System.Drawing.Color.White;

        if (txtRutDirector.Text.Trim() == string.Empty)
        {
            txtRutDirector.BackColor = System.Drawing.Color.Pink;
            txtRutDirector.Focus();
            return;
        }
        else
            txtRutDirector.BackColor = System.Drawing.Color.White;

  
        string SQL = "";
        SQL += "INSERT INTO EncuestasUsuarios ";
        SQL += "(CodEncuestas, IdUsuario, CodProyecto) ";
        SQL += "VALUES (@pCodEncuestas, @pIdUsuario, @pCodProyecto)";

        listDbParameter.Add(con.parametros("@pCodEncuestas", SqlDbType.Int, 4, intCodEncuesta));
        listDbParameter.Add(con.parametros("@pIdUsuario", SqlDbType.Int, 4, Convert.ToString(Session["IdUsuario"])));
        listDbParameter.Add(con.parametros("@pCodProyecto", SqlDbType.Int, 4, Convert.ToString(dtProyectos.Rows[0]["CodProyecto"])));

        con.ejecutar(SQL, listDbParameter);


        SQL = "";
        SQL += "UPDATE Proyectos ";
        SQL += "SET Direccion = @pDireccion, ";
        SQL += "Telefono = @pTelefono, ";
        SQL += "FechaActualizacion = @pFechaActualizacion, ";
        SQL += "IdUsuarioActualizacion = @pIdUsuarioActualizacion, ";
        SQL += "Mail = @pMail, ";
        SQL += "Fax = @pFax, ";
        SQL += "Director = @pDirector, ";
        SQL += "RutDirector = @pRutDirector ";
        SQL += "WHERE CodProyecto = @pCodProyecto";
        //db.Execute(SQL);
        //System.Data.SqlClient.SqlParameterCollection sqlParameterCollection = new System.Data.SqlClient.SqlParameterCollection();
        //sqlParameterCollection.AddWithValue(
        //System.Data.SqlClient.SqlCommand sc = new System.Data.SqlClient.SqlCommand();
        //sc.Parameters

        listDbParameter.Clear();
        listDbParameter.Add(con.parametros("@pDireccion", SqlDbType.VarChar, 100, txtDireccion.Text.Trim()));
        listDbParameter.Add(con.parametros("@pTelefono", SqlDbType.VarChar, 50, txtTelefono.Text.Trim()));
        listDbParameter.Add(con.parametros("@pFechaActualizacion", SqlDbType.DateTime, 8, System.DateTime.Now.ToString()));
        listDbParameter.Add(con.parametros("@pIdUsuarioActualizacion", SqlDbType.Int, 4, Convert.ToInt32(Session["IdUsuario"])));
        listDbParameter.Add(con.parametros("@pMail", SqlDbType.VarChar, 50, txtMail.Text.Trim()));
        listDbParameter.Add(con.parametros("@pFax", SqlDbType.VarChar, 30, txtFax.Text.Trim()));
        listDbParameter.Add(con.parametros("@pDirector", SqlDbType.VarChar, 50, txtDirector.Text.Trim()));
        listDbParameter.Add(con.parametros("@pRutDirector", SqlDbType.VarChar, 11, txtRutDirector.Text.Trim()));
        listDbParameter.Add(con.parametros("@pCodProyecto", SqlDbType.Int, 4, Convert.ToInt32(dtProyectos.Rows[0]["CodProyecto"])));

        con.ejecutar(SQL, listDbParameter);

        //db.Close();
        Response.Redirect("default.aspx");
    }
    protected void txt011_ValueChange(object sender, EventArgs e)
    {
        try
        {
            if (txtRutDirector.Text.Length > 3)
            {
                string rutsinnada = txtRutDirector.Text.Replace(".", "").Replace(",", "").Replace("-", "").Trim();
                string digitoingresado = rutsinnada.Substring(rutsinnada.Length - 1, 1);

                string digitocalculado = digitoVerificador(Convert.ToInt32(rutsinnada.ToUpper().Replace("K", "").Substring(0, rutsinnada.Length - 1)));
                if (digitocalculado.ToUpper() == digitoingresado.ToUpper())
                {
                    pnl002.Visible = false;
                    string punorut = rutsinnada.ToUpper().Replace("K", "").Substring(0, rutsinnada.Length - 1).Trim();
                    string rcompleto = punorut + "-" + digitocalculado.ToUpper();
                    txtRutDirector.Text = rcompleto;
                }
                else
                {
                    lbl002.Text = "RUT INGRESADO NO ES VALIDO";
                    pnl002.Visible = true;
                }
            }
            else
            {
                lbl002.Text = "RUT INGRESADO NO ES VALIDO";
                pnl002.Visible = true;
            }
        }
        catch
        {
            lbl002.Text = "RUT INGRESADO NO ES VALIDO";
            pnl002.Visible = true;
        }
    }
}
