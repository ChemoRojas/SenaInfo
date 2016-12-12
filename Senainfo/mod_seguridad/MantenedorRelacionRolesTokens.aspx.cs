using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;

public partial class mod_seguridad_MantenedorRelacionRolesTokens : System.Web.UI.Page
{
    public System.Data.DataTable dt = null;
    public System.Data.DataTable dt_disponible = null;
    public System.Data.DataTable dt_asignado = null;
    //public System.Data.DataTable dt_envio = null;
    public System.Data.DataSet ds = null;
    
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
            GetData();
        }
    }

    private void GetData()
    {
        ConexionesSS con = new ConexionesSS();
        con.Autenticar();
        dt = con.TraerDataTable("Mantenedor_ObtenerRoles_RolesTokens", Session["IdUsuario"]);
        con.CerrarConexion();

        ddl_roles.DataSource = dt.DefaultView;
        ddl_roles.DataValueField = "IdRol";
        ddl_roles.DataTextField = "Nombre";
        ddl_roles.DataBind();
    }

    protected void lnb_buscar_Click(object sender, EventArgs e)
    {
        ConexionesSS con = new ConexionesSS();
        con.Autenticar();
        ds = con.TraerDataSet("Mantenedor_ObtenerTokens_RolesTokens", ddl_roles.SelectedValue, Session["IdUsuario"]);
        con.CerrarConexion();

        dt_disponible = ds.Tables[0];
        dt_asignado = ds.Tables[1];

        lb_cantidad_disponible.Text = dt_disponible.Rows.Count.ToString();
        lb_cantidad_asignado.Text = dt_asignado.Rows.Count.ToString();

        ddl_disponible.DataSource = dt_disponible.DefaultView;
        ddl_disponible.DataValueField = "IdToken";
        ddl_disponible.DataTextField = "TokenDescripcion";
        ddl_disponible.DataBind();

        ddl_asignado.DataSource = dt_asignado.DefaultView;
        ddl_asignado.DataValueField = "IdToken";
        ddl_asignado.DataTextField = "TokenDescripcion";
        ddl_asignado.DataBind();

        lnb_actualizar.Visible = true;
        lnb_buscar.Visible = false;
        ddl_roles.Enabled = false;
    }

    protected void lnb_actualizar_Click(object sender, EventArgs e)
    {
        if (ddl_asignado.Items.Count > 0)
        {
            SqlTransaction sqlt;
            SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionesSS"].ToString());
            sconn.Open();
            sqlt = sconn.BeginTransaction();
            try
            {
                DataTable dt_envio = new DataTable();

                DataColumn column;
                DataRow row;

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "IdToken";
                dt_envio.Columns.Add(column);

                column = new DataColumn();
                column.DataType = Type.GetType("System.Int32");
                column.ColumnName = "IdRol";
                dt_envio.Columns.Add(column);

                for (int i = 0; i < ddl_asignado.Items.Count; i++)
                {
                    row = dt_envio.NewRow();
                    row["IdToken"] = ddl_asignado.Items[i].Value;
                    row["IdRol"] = ddl_roles.SelectedItem.Value;
                    dt_envio.Rows.Add(row);
                }

                System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand("Mantenedor_Actualizar_RolesTokens", sqlt.Connection);
                sqlc.CommandType = System.Data.CommandType.StoredProcedure;
                sqlc.Connection = sqlt.Connection;
                sqlc.Transaction = sqlt;
                sqlc.Parameters.Add(Conexiones.CrearParametro("@IdRol", SqlDbType.Int, 4, ddl_roles.SelectedItem.Value));
                sqlc.Parameters.Add(Conexiones.CrearParametro("@tokens", SqlDbType.Structured, 16, dt_envio));
                sqlc.Parameters.Add(Conexiones.CrearParametro("@IdUsuario", SqlDbType.Int, 16, Session["IdUsuario"]));
                sqlc.ExecuteNonQuery();

                sqlt.Commit();
                sconn.Close();
                Limpiar();

                lb_informacion.Text = "Todo OK";
            }
            catch (Exception ex)
            {
                try
                {
                    sqlt.Rollback();
                    lb_informacion.Text = "Actualización no realizada, por favor intentar nuevamente.";
                }
                catch (Exception exRollback)
                {
                    lb_informacion.Text = "Actualización realizada con errores, por favor contactarse con mesa de ayuda.";
                }
            }
        }
        else
        {
            lb_informacion.Text = "Debe haber al menos un token asignado";
        }
    }

    protected void lbn_Limpiar_Click(object sender, EventArgs e)
    {
        Limpiar();
    }

    private void Limpiar()
    {
        lnb_actualizar.Visible = false;
        lnb_buscar.Visible = true;
        ddl_roles.Enabled = true;

        ddl_disponible.Items.Clear();
        ddl_asignado.Items.Clear();

        lb_cantidad_disponible.Text = "0";
        lb_cantidad_asignado.Text = "0";
    }

    protected void lnb_agregar_uno_Click(object sender, EventArgs e)
    {
        if (ddl_disponible.SelectedItem != null)
        {
            ddl_asignado.Items.Add(ddl_disponible.SelectedItem);
            ddl_disponible.Items.Remove(ddl_disponible.SelectedItem);
            ddl_disponible.ClearSelection();
            ddl_asignado.ClearSelection();
            lb_cantidad_disponible.Text = (Convert.ToInt32(lb_cantidad_disponible.Text) - 1).ToString();
            lb_cantidad_asignado.Text = (Convert.ToInt32(lb_cantidad_asignado.Text) + 1).ToString();
            lb_informacion.Text = string.Empty;
        }
        else
        {
            lb_informacion.Text = "Debe seleccionar un token";
        }
    }

    protected void lnb_quitar_uno_Click(object sender, EventArgs e)
    {
        if (ddl_asignado.SelectedItem != null)
        {
            ddl_disponible.Items.Add(ddl_asignado.SelectedItem);
            ddl_asignado.Items.Remove(ddl_asignado.SelectedItem);
            ddl_asignado.ClearSelection();
            ddl_disponible.ClearSelection();
            lb_cantidad_disponible.Text = (Convert.ToInt32(lb_cantidad_disponible.Text) + 1).ToString();
            lb_cantidad_asignado.Text = (Convert.ToInt32(lb_cantidad_asignado.Text) - 1).ToString();
            lb_informacion.Text = string.Empty;
        }
        else
        {
            lb_informacion.Text = "Debe seleccionar un token";
        }
    }
}