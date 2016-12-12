using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mod_seguridad_MantenedorDeTokens : System.Web.UI.Page
{
    public System.Data.DataTable dt = null;
    public System.Data.DataTable dt2 = null;
    public static DataView dv2 = new DataView();
    public int cantidad_registros = 0;
    //public string newId = string.Empty;

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
                if (!window.existetoken("B5173CC3-9837-4410-88FB-244483548B2F"))
                {
                    Response.Redirect("~/e403.aspx");
                }
            }
            GetData_SoloMenu();
            cambiarPadre();
            //txt_cadena.Text = Guid.NewGuid().ToString().ToUpper();
        }
    }

    private void GetData_SoloMenu()
    {
        ConexionesSS con = new ConexionesSS();
        con.Autenticar();
        dt = con.TraerDataTable("Mantenedor_ObtenerTokens_SoloMenu", Session["IdUsuario"]);
        grd_resultado.DataSource = dt;
        grd_resultado.DataBind();
        grd_resultado.Visible = true;
        int NivelesTokens = (int)con.TraerValorEscalar("Mantenedor_NivelesTokens");
        con.CerrarConexion();

        int nivel = 0;
        while (nivel <= NivelesTokens)
        {
            ddl_nivel.Items.Add(nivel.ToString());
            nivel++;
        }
    }

    protected void lnb_todoslostokens_Click(object sender, EventArgs e)
    {
        GetData_Todos();
    }

    private void GetData_Todos()
    {
        grd_resultado.DataSource = null;
        grd_resultado.Visible = false;
        grd_resultado.Dispose();

        //dt.Clear();
        ddl_nivel.Items.Clear();

        ConexionesSS con = new ConexionesSS();
        con.Autenticar();
        dt = con.TraerDataTable("Mantenedor_ObtenerTokens_Todos", Session["IdUsuario"]);
        grd_resultado.DataSource = dt;
        grd_resultado.DataBind();
        grd_resultado.Visible = true;
        int NivelesTokens = (int)con.TraerValorEscalar("Mantenedor_NivelesTokens");
        con.CerrarConexion();

        int nivel = 0;
        while (nivel <= NivelesTokens)
        {
            ddl_nivel.Items.Add(nivel.ToString());
            nivel++;
        }
    }

    protected void grd_resultado_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditarToken")
        {
            hf_idtoken.Value = grd_resultado.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text.ToString();

            txt_cadena.Text = grd_resultado.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text.ToString();
            txt_descripcion.Text = grd_resultado.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text.ToString();
            ddl_nivel.SelectedValue = grd_resultado.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text.ToString();
            ddl_padre.SelectedValue = grd_resultado.Rows[Convert.ToInt32(e.CommandArgument)].Cells[4].Text.ToString();
            txt_menu.Text = grd_resultado.Rows[Convert.ToInt32(e.CommandArgument)].Cells[5].Text.ToString();
            txt_url.Text = grd_resultado.Rows[Convert.ToInt32(e.CommandArgument)].Cells[6].Text.ToString();
            ddl_target.SelectedValue = grd_resultado.Rows[Convert.ToInt32(e.CommandArgument)].Cells[7].Text.ToString();
            ddl_vigencia.SelectedValue = grd_resultado.Rows[Convert.ToInt32(e.CommandArgument)].Cells[8].Text.ToString();

            tr_cadena.Visible = true;
            lnb_guardar.Visible = false;
            lnb_actualizar.Visible = true;
        }
    }

    private void LimpiarGrilla()
    {
        grd_resultado.DataSource = null;
        grd_resultado.Dispose();
    }

    protected void lbn_Limpiar_Click(object sender, EventArgs e)
    {
        LimpiarGrilla();
        txt_descripcion.Text = string.Empty;
        //txt_nombre.Text = string.Empty;
        //hf_idrol.Value = "0";
        //ddl_vigencia.SelectedValue = "Vigente";
        lnb_guardar.Visible = true;
        lnb_actualizar.Visible = false;
    }

    protected void ddl_nivel_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_nivel.SelectedItem.Value == "0")
        {
            ddl_padre.Enabled = false;
            txt_menu.Enabled = false;
            txt_url.Enabled = false;
            ddl_target.Enabled = false;
            cb_externo.Enabled = false;
        }
        else
        {
            ddl_padre.Enabled = true;
            txt_menu.Enabled = true;
            txt_url.Enabled = true;
            ddl_target.Enabled = true;
            cb_externo.Enabled = true;

            cambiarPadre();
        }
    }

    private void cambiarPadre()
    {
        //ConexionesSS con = new ConexionesSS();
        //con.Autenticar();
        //dt2 = con.TraerDataTable("Mantenedor_TokensPadre", ddl_nivel.SelectedValue, Session["IdUsuario"]);
        //con.CerrarConexion();

        //ddl_padre.DataSource = dt2.DefaultView;
        //ddl_padre.DataValueField = "IdToken";
        //ddl_padre.DataTextField = "TokenDescripcion";
        //ddl_padre.DataBind();

        //if (dt2.Rows.Count > 0)
        if (dt2 != null)
        {
            dv2 = dt2.DefaultView;
            dv2.RowFilter = "TokenNivel = " + ddl_nivel.SelectedValue;
            actualizaCambiaPadre();
        }
        else
        {
            ConexionesSS con = new ConexionesSS();
            con.Autenticar();
            dt2 = con.TraerDataTable("Mantenedor_TokensPadre", (int)Session["IdUsuario"]);
            con.CerrarConexion();

            dv2 = dt2.DefaultView;
            dv2.RowFilter = "TokenNivel = " + ddl_nivel.SelectedValue; // (.)(.) (·)(·) (°)(°)
            actualizaCambiaPadre();
        }
    }

    private void actualizaCambiaPadre()
    {
        ddl_padre.DataSource = dv2;
        ddl_padre.DataValueField = "IdToken";
        ddl_padre.DataTextField = "TokenDescripcion";
        ddl_padre.DataBind();
    }

    protected void cb_externo_CheckedChanged(object sender, EventArgs e)
    {
        if (cb_externo.Checked)
        {
            txt_enalce_externo.Enabled = true;
            txt_url.Enabled = false;
        }
        else
        {
            txt_enalce_externo.Enabled = false;
            txt_url.Enabled = true;
        }
    }

    protected void lnb_guardar_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(txt_descripcion.Text))//|| !String.IsNullOrEmpty(txt_nombre.Text))
        {
            ConexionesSS con = new ConexionesSS();
            con.Autenticar();
            //int salida = (int)con.TraerValorEscalar("Mantenedor_GuardarActualizarToken", txt_descripcion.Text, ddl_nivel.SelectedItem.Value, ddl_padre.SelectedItem.Value, txt_menu.Text, txt_url.Text, ddl_target.SelectedItem.Value, ddl_vigencia.SelectedValue, 1, Session["IdUsuario"], hf_idtoken.Value); //opcion 1: grabar
            int salida = (int)con.TraerValorEscalar("Mantenedor_GuardarActualizarToken", txt_descripcion.Text, ddl_nivel.SelectedItem.Value, ddl_padre.SelectedItem.Value, txt_menu.Text, txt_url.Text, ddl_target.SelectedItem.Value, ddl_vigencia.SelectedValue, 1, Session["IdUsuario"]); //opcion 1: grabar
            con.CerrarConexion();
        }
        else
        {
            lb_informacion.Text = "Debe completar todos los campos.";
        }
    }

    protected void lnb_actualizar_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(txt_descripcion.Text))//|| !String.IsNullOrEmpty(txt_nombre.Text))
        {
            ConexionesSS con = new ConexionesSS();
            con.Autenticar();
            int salida = (int)con.TraerValorEscalar("Mantenedor_GuardarActualizarToken", txt_descripcion.Text, ddl_nivel.SelectedItem.Value, ddl_padre.SelectedItem.Value, txt_menu.Text, txt_url.Text, ddl_target.SelectedItem.Value, ddl_vigencia.SelectedValue, 2, Session["IdUsuario"], hf_idtoken.Value); //opcion 2: actualizar
            con.CerrarConexion();
        }
        else
        {
            lb_informacion.Text = "Debe completar todos los campos.";
        }
    }
}