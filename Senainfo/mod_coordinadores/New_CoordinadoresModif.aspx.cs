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
using regfaltas2TableAdapters;

using System.Collections.Generic;
using System.Data.Common;

public partial class mod_coordinadores_New_CoordinadoresModif : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["tokens"] == null || ((DataSet)Session["tokens"]).Tables[0].Rows.Count == 0)
            {
                Response.Redirect("~/logout.aspx");
            }
            else
            {
                if (!window.existetoken("582C86A0-4085-40BF-A6CB-4F33EB88D0A9"))
                {
                    Response.Redirect("~/e403.aspx");
                }
            }
        }
    }
    protected void grd004_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName != "Page")
        {
            string codingreso = e.CommandName.ToString();//grd004.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
            Response.Redirect("coordinadores_ingreso.aspx?ingreso=" + codingreso + "&region=" + e.CommandArgument.ToString());
        }
    }
    protected void grd004_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        
    }
    private void Function_Consulta()
    {
        string rutsinnada = txt_rut.Text.Trim().Replace("-","");
        rutsinnada = rutsinnada.Replace(".", "");
        string rutconguion = string.Empty;

        if (txt_rut.Text.Length > 3)
        {   
            //x si viene sin guion
            if (txt_rut.Text.IndexOf("-") == -1)
                rutconguion = txt_rut.Text.Substring(0, txt_rut.Text.Length - 1) + "-" + txt_rut.Text.Substring(txt_rut.Text.Length - 1);
            else
                rutconguion = txt_rut.Text.Trim();

            txt_rut.Text = rutconguion;
        }
        try
        {
            List<DbParameter> listDbParameter = new List<DbParameter>();

            string sParametrosConsulta = "Select Distinct T2.CodNino,T2.Rut,T2.Sexo,T2.Nombres,T2.Apellido_paterno,T2.Apellido_Materno," +
                                   "T2.FechaNacimiento, T2.CodNacionalidad From Ninos T2 ";

            if (txt_rut.Text.Trim() != "" || txt_ap_paterno.Text.Trim() != "" ||
                    txt_ap_materno.Text.Trim() != "" || txt_nombres.Text.Trim() != "" || txt_codnino.Text.Trim() != "")
            {
                sParametrosConsulta = sParametrosConsulta + "Where ";
            }

            if (txt_ap_paterno.Text.Trim() != "")
            {
                sParametrosConsulta = sParametrosConsulta + " T2.Apellido_Paterno like @pApellido_Paterno And";

                listDbParameter.Add(Conexiones.CrearParametro("@pApellido_Paterno", SqlDbType.VarChar, 50, "%" + txt_ap_paterno.Text + "%"));
            }
            if (txt_ap_materno.Text.Trim() != "")
            {
                sParametrosConsulta = sParametrosConsulta + " T2.Apellido_Materno like @pApellido_Materno And";

                listDbParameter.Add(Conexiones.CrearParametro("@pApellido_Materno", SqlDbType.VarChar, 50, "%" + txt_ap_materno.Text + "%"));
            }
            if (txt_nombres.Text.Trim() != "")
            {
                sParametrosConsulta = sParametrosConsulta + " T2.Nombres like @pNombres And";

                listDbParameter.Add(Conexiones.CrearParametro("@pNombres", SqlDbType.VarChar, 100, "%" + txt_nombres.Text + "%"));
            }
            if (txt_rut.Text.Trim() != "")
            {
                sParametrosConsulta = sParametrosConsulta + " T2.Rut =@pRut And";

                listDbParameter.Add(Conexiones.CrearParametro("@pRut", SqlDbType.VarChar, 100, txt_rut.Text.Trim()));
            }
            if (txt_codnino.Text.Trim() != "")
            {

                sParametrosConsulta = sParametrosConsulta + " T2.CodNino =@pCodNino And";

                listDbParameter.Add(Conexiones.CrearParametro("@pCodNino", SqlDbType.Int, 4, Convert.ToInt32(txt_codnino.Text.Trim())));

                txt_codnino.Text = Session["cod"].ToString();
            }

            if (sParametrosConsulta.Substring(sParametrosConsulta.Length - 3, 3) == "And")
            {
                sParametrosConsulta = sParametrosConsulta.Substring(0, sParametrosConsulta.Length - 3);
            }


            ninocoll nic = new ninocoll();
            DataTable dt = nic.get_ninorelacionado(sParametrosConsulta, listDbParameter);

            DataTable dtNinos2 = new DataTable();
            dtNinos2.Columns.Add("IcodIngreso");
            dtNinos2.Columns.Add("CodNino");
            dtNinos2.Columns.Add("CodTribunal");
            dtNinos2.Columns.Add("Ruc");
            dtNinos2.Columns.Add("Rit");
            dtNinos2.Columns.Add("FechaOrden");
            dtNinos2.Columns.Add("CodCausalIngreso");
            dtNinos2.Columns.Add("CodProyecto");
            dtNinos2.Columns.Add("IdUsuarioActualizacion");
            dtNinos2.Columns.Add("FechaActualizacion");
            dtNinos2.Columns.Add("Rut");
            dtNinos2.Columns.Add("Sexo");
            dtNinos2.Columns.Add("Nombres");
            dtNinos2.Columns.Add("Apellido_paterno");
            dtNinos2.Columns.Add("Apellido_Materno");
            dtNinos2.Columns.Add("FechaNacimiento");
            dtNinos2.Columns.Add("CodRegion");

            DataRow drNombre;

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    CoordinadorJudicialTableAdapter registros = new CoordinadorJudicialTableAdapter();
                    int codnino = Convert.ToInt32(dt.Rows[i][0]);
                    DataTable dt_temp = new DataTable();
                    dt_temp = registros.Get_xCodNino(codnino);
                    

                    if (dt_temp.Rows.Count > 0)
                    {
                        try
                        {
                            for (int j = 0; j < dt_temp.Rows.Count; j++)
                            {
                                drNombre = dtNinos2.NewRow();
                                drNombre[0] = Convert.ToString(dt_temp.Rows[j][0]);
                                drNombre[1] = Convert.ToString(dt_temp.Rows[j][1]);
                                drNombre[2] = Convert.ToString(dt_temp.Rows[j][2]);
                                drNombre[3] = Convert.ToString(dt_temp.Rows[j][3]);
                                drNombre[4] = Convert.ToString(dt_temp.Rows[j][4]);
                                drNombre[5] = Convert.ToString(dt_temp.Rows[j][5]).Substring(0, 10);
                                drNombre[6] = Convert.ToString(dt_temp.Rows[j][6]);
                                drNombre[7] = Convert.ToString(dt_temp.Rows[j][7]);
                                drNombre[8] = Convert.ToString(dt_temp.Rows[j][8]);
                                drNombre[9] = Convert.ToString(dt_temp.Rows[j][9]).Substring(0, 10);
                                drNombre[10] = Convert.ToString(dt.Rows[i]["Rut"]);
                                drNombre[11] = Convert.ToString(dt.Rows[i]["Sexo"]);
                                drNombre[12] = Convert.ToString(dt.Rows[i]["Nombres"]);
                                drNombre[13] = Convert.ToString(dt.Rows[i]["Apellido_paterno"]);
                                drNombre[14] = Convert.ToString(dt.Rows[i]["Apellido_Materno"]);
                                drNombre[15] = Convert.ToString(dt.Rows[i]["FechaNacimiento"]).Substring(0, 10);
                                

                                Proyectos3TableAdapter traigoReg = new Proyectos3TableAdapter();
                                DataTable dtreg = traigoReg.Get_XcodProyecto(Convert.ToInt32(dt_temp.Rows[j]["CodProyecto"]));

                                if (dtreg.Rows.Count > 0)
                                    drNombre[16] = Convert.ToString(dtreg.Rows[0]["CodRegion"]);
                                else
                                    drNombre[16] = "0";

                                dtNinos2.Rows.Add(drNombre);
                            }
                        }
                        catch
                        {
                        }
                    }
                }
            }
            if (dtNinos2.Rows.Count > 0)
            {
                ViewState["dt"] = dtNinos2;
                grd004.DataSource = dtNinos2;
                grd004.DataBind();
                grd004.Visible = true;
                Limpiar();
                //lbl_error.Visible = false;
            }
            else
            {
                //ScriptManager.RegisterStartupScript(this, typeof(string), "Coincidencias", "alert('No se encontraron coincidencias para su busqueda.');", true);
                pnlError.Visible = true;
                lblAlertError.Visible = true;
                lblAlertError.Text = "No se encontraron coincidencias para su busqueda.";

                //lbl_error.Visible = true;
                //lbl_error.Text = "No se encontraron coincidencias para su busqueda.";
            }
        }
        catch (Exception)
        {


        }
        finally
        {

        }
                
        
        

    }

    public void Limpiar()
    {
        txt_rut.Text = string.Empty;
        txt_codnino.Text = string.Empty;
        txt_ap_paterno.Text = string.Empty;
        txt_ap_materno.Text = string.Empty;
        txt_nombres.Text = string.Empty;
        
    }
    //protected void btn_limpiar_Click(object sender, EventArgs e)
    //{
    //    Limpiar();
    //    grd004.Visible = false;
    //}
    protected void grd004_PageIndexChanging1(object sender, GridViewPageEventArgs e)
    {
            grd004.PageIndex = e.NewPageIndex;
            grd004.DataSource = (DataTable) ViewState["dt"];
            grd004.DataBind();
    }
    protected void btn_buscar_Click(object sender, EventArgs e)
    {
        Session["cod"] = txt_codnino.Text;
        System.Drawing.Color colorCampoObligatorio = System.Drawing.ColorTranslator.FromHtml("#F2F5A9"); //gfontbrevis

        if (txt_rut.Text == "")
        {
            txt_rut.BackColor = colorCampoObligatorio;
        }
        else
        {
            txt_rut.BackColor = System.Drawing.Color.White;
            Function_Consulta();
        }
        
    }
    protected void btn_limpiar_Click(object sender, EventArgs e)
    {
        Limpiar();
        grd004.Visible = false;
        pnlError.Visible = false;
    }
    protected void btn_volver_Click(object sender, EventArgs e)
    {
        Response.Redirect("index_coordinadores.aspx");
    }
}
