using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mod_seguridad_MantenedorDeRoles : System.Web.UI.Page
{

    public System.Data.DataTable dt = null;
    public int cantidad_registros = 0;

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
        }
        GetData();           
    }

    private void GetData()
    {
        ConexionesSS con = new ConexionesSS();
        con.Autenticar();
        dt = con.TraerDataTable("Mantenedor_ObtenerRoles", Session["IdUsuario"]);
        grd_resultado.DataSource = dt;
        grd_resultado.DataBind();
        grd_resultado.Visible = true;
        con.CerrarConexion();
    }

    protected void grd_resultado_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditarRol")
        {
            txt_descripcion.Text = grd_resultado.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text.ToString();
            txt_nombre.Text = grd_resultado.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text.ToString();
            hf_idrol.Value = grd_resultado.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text.ToString();
            ddl_vigencia.SelectedValue = grd_resultado.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text.ToString(); //Verificar este campo

            lnb_guardar.Visible = false;
            lnb_actualizar.Visible = true;
        }
    }

    protected void lnb_guardar_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(txt_descripcion.Text) || !String.IsNullOrEmpty(txt_nombre.Text))
        {
            ConexionesSS con = new ConexionesSS();
            con.Autenticar();
            //int salida = (int)con.TraerValorEscalar("Mantenedor_GuardarActualizarRol", txt_descripcion.Text, txt_nombre.Text, ddl_vigencia.SelectedIndex, 1, Session["IdUsuario"], hf_idrol.Value); //opcion 1: grabar
            int salida = (int)con.TraerValorEscalar("Mantenedor_GuardarActualizarRol", txt_descripcion.Text, txt_nombre.Text, ddl_vigencia.SelectedValue, 1, Session["IdUsuario"], hf_idrol.Value); //opcion 1: grabar
            con.CerrarConexion();
        }
        else
        {
            lb_informacion.Text = "Debe completar todos los campos.";
        }
    }

    protected void lnb_actualizar_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(txt_descripcion.Text) || !String.IsNullOrEmpty(txt_nombre.Text))
        {
            ConexionesSS con = new ConexionesSS();
            con.Autenticar();
            //int salida = (int)con.TraerValorEscalar("Mantenedor_GuardarActualizarRol", txt_descripcion.Text, txt_nombre.Text, ddl_vigencia.SelectedIndex, 2, Session["IdUsuario"], hf_idrol.Value); //opcion 2: actualizar
            int salida = (int)con.TraerValorEscalar("Mantenedor_GuardarActualizarRol", txt_descripcion.Text, txt_nombre.Text, ddl_vigencia.SelectedValue, 2, Session["IdUsuario"], hf_idrol.Value); //opcion 2: actualizar
            con.CerrarConexion();
        }
        else
        {
            lb_informacion.Text = "Debe completar todos los campos.";
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
        txt_nombre.Text = string.Empty;
        hf_idrol.Value = "0";
        //ddl_vigencia.SelectedValue = "Vigente";
        lnb_guardar.Visible = true;
        lnb_actualizar.Visible = false;
    }
}