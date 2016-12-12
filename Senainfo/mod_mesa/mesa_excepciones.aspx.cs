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
using System.Data.SqlClient;

public partial class mod_mesa_mesa_excepciones : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
        
            Get_NameSP();
            //newCargoGriview();
        }
        
    }
    protected int Get_IdRol_user()
    {
        int int_valor = 0;
        try 
        {
            
            
            coordinador cr = new coordinador();
            string sql = "Select  * From  usuarios  where idUsuario =" + Session["IdUsuario"].ToString();
            DataTable dtproy = cr.ejecuta_SQL(sql, null);
            string contrasena =  dtproy.Rows[0]["Contrasena"].ToString();
            int_valor = Convert.ToInt32(contrasena);
        }
        catch { }
        return int_valor;
    }
    protected void Get_NameSP()
    {
        try
        {
            coordinador cr = new coordinador();
            string sql = "Select  * From  ExcepcionAsistencia";
            DataTable dtproy = cr.ejecuta_SQL(sql, null);

            DataTable dtnew = new DataTable();
            dtnew.Columns.Add("Accion");
            dtnew.Columns.Add("Procedimiento");
            dtnew.Columns.Add("P1");
            dtnew.Columns.Add("P2");
            for (int x = 0; x < dtproy.Rows.Count; x++)
            {
                DataRow dtr = dtnew.NewRow();
                dtr["Accion"] = dtproy.Rows[x]["Descripcion"];
                dtr["Procedimiento"] = dtproy.Rows[x]["Procedimiento"];
                dtr["P1"] = dtproy.Rows[x]["P1"];
                dtr["P2"] = dtproy.Rows[x]["P2"];
                dtnew.Rows.Add(dtr);    
            }
            grv_excepciones.DataSource = dtnew;
            grv_excepciones.DataBind();
        }
        catch { }
    }
    public DataTable ejecuta_SQL(string sql)
    {
        Conexiones con = new Conexiones();
        System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + con.Servidor + " ;Database= " + con.Base + " ; User ID= " + con.Usuario + " ;Password= " + con.Passw + " ;Trusted_Connection=False");
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.Text;
        sqlc.CommandText = sql;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }


    protected void grv_excepciones_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try 
        {
            alertw.Visible = false;
            TextBox p1 = (TextBox)grv_excepciones.Rows[0].FindControl("txt_p1");
            TextBox p2 = (TextBox)grv_excepciones.Rows[0].FindControl("txt_p2");
            int p3 = 1;
          string estado = executeSP(Convert.ToInt32(p1.Text), Convert.ToInt32(p2.Text), p3);
          //lbl_mensaje.Text = estado;
          window.alert(this, estado);
          p1.Text = "";
          p2.Text = "";
        }
        catch { 
            lbl_mensaje.Text = "Error al ejecutar el proceso, verifique si ingresó los parámetros requeridos";
            alertw.Visible = true;
        }
    }
    protected string executeSP(int CodProy, int anomes, int modAsist)
    {
        string str_error = "";
        try
        {
            Conexiones con = new Conexiones();
            System.Data.SqlClient.SqlConnection sconn = new System.Data.SqlClient.SqlConnection("Server= " + con.Servidor + " ;Database= " + con.Base + " ; User ID= " + con.Usuario + " ;Password= " + con.Passw + " ;Trusted_Connection=False");
            System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();

            sqlc.Connection = sconn;
            sqlc.CommandType = System.Data.CommandType.StoredProcedure;
            sqlc.CommandText = "PA_PermiteModificarAsistencia";
            sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int).Value = CodProy;
            sqlc.Parameters.Add("@AnoMes", SqlDbType.Int).Value = anomes;
            sqlc.Parameters.Add("@ModificaAsistencia", SqlDbType.Int).Value = modAsist;

            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
            DataTable dt = new DataTable();
            sconn.Open();
            da.Fill(dt);
            sconn.Close();
            str_error = "Se Ejecuto el Proceso exitosamente";
            insertLog(CodProy, anomes, modAsist);
        }
        catch
        { str_error = "Error al Ejecutar el Proceso"; }
        return str_error;
    }
    protected void insertLog(int CodProy, int anomes, int modAsist)
    {
        //objconnection objconn = ASP.global_asax.globaconn;
        Conexiones con = new Conexiones();
        using (SqlConnection connection = new SqlConnection("Server= " + con.Servidor + " ;Database= " + con.Base + " ; User ID= " + con.Usuario + " ;Password= " + con.Passw + " ;Trusted_Connection=False"))
        {
           
            using (SqlCommand command = new SqlCommand())
            {
                int idUser = Convert.ToInt32(Session["IdUsuario"].ToString());
                DateTime dti = DateTime.Now;
                int idmesa = Get_IdRol_user();
                string spexe = "PA_PermiteModificarAsistencia";

                command.Connection = connection;            // <== lacking
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT into logexcepcionasistencia (IdUsuario, IdMesaDeAyuda, FechaActualizacion,P1,P2,P3,P4,P5,spEjecutado) VALUES (@IdUsuario, @IdMesaDeAyuda, @FechaActualizacion,@P1,@P2,@P3,@P4,@P5,@spEjecutado)";
                command.Parameters.AddWithValue("@IdUsuario",idUser);
                command.Parameters.AddWithValue("@IdMesaDeAyuda",idmesa);
                command.Parameters.AddWithValue("@FechaActualizacion", dti);
                command.Parameters.AddWithValue("@P1", CodProy);
                command.Parameters.AddWithValue("@P2", anomes);
                command.Parameters.AddWithValue("@P3", modAsist);
                command.Parameters.AddWithValue("@P4", "vacio");
                command.Parameters.AddWithValue("@P5", "vacio");
                command.Parameters.AddWithValue("@spEjecutado", spexe);
                
                try
                {
                    connection.Open();
                    int recordsAffected = command.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    // error here
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        ////////////////////////////////////////////////////////////////
        
        
    }
    protected void newCargoGriview()
    {
        try
        {
            coordinador cr = new coordinador();
            string sql = "Select  * From  ExcepcionAsistencia";
            DataTable dtproy = cr.ejecuta_SQL(sql, null);
            DataSet ds = new DataSet();
            ds.Tables.Add(dtproy);
            //Creamos nuestro gridView
            GridView gv1 = new GridView();
            //Llenamos nuestro gridView mediante un DataSet previamente creado.
            grv_datos.DataSource = ds;
            grv_datos.DataBind();
            //Ponemos la propiedad AutoGenerateColumns en False,
            //ya que nosotros las crearemos
            grv_datos.AutoGenerateColumns = false;
            //Creamos las columnas dinámicamente,
            //en mi caso tenemos una lista con las columnas.
            for (int i = 0; i < dtproy.Rows.Count; i++)
            {
                //Objeto Columna:
                BoundField ColumnBound;
                TemplateField template = new TemplateField();
                //Crear Columna:
                ColumnBound = new BoundField();
                //ColumnBound.DataField = dtproy.Rows[i].DATAFIELD.Trim();
                ColumnBound.DataField = ds.Tables[0].Columns[i].ToString();
                ColumnBound.HeaderText = ds.Tables[0].Columns[i].ToString();

                TemplateField temp = new TemplateField();
               
            }
            //LinkButton linkbtn = new LinkButton();
            //linkbtn.Text = "linkbot de prueba2";
            //linkbtn.ID = "lnktest";
            //linkbtn.CommandArgument = "Comando";
            //linkbtn.CommandName = "cmd name";
            //linkbtn.Command += new CommandEventHandler(lnkbtncommand);
            //TemplateField tempfield = new TemplateField();
            //tempfield.InsertItemTemplate.InstantiateIn(linkbtn);
            //grvLinkButton linkbtn = new LinkButton();
            //linkbtn.Text = "linkbot de prueba2";
            //linkbtn.ID = "lnktest";
            //linkbtn.CommandArgument = "Comando";
            //linkbtn.CommandName = "cmd name";
            //linkbtn.Command += new CommandEventHandler(lnkbtncommand);
            //TemplateField tempfield = new TemplateField();
            //tempfield.InsertItemTemplate.InstantiateIn(linkbtn);
            //grv_datos.Columns.Add(tempfield);


            //tempfield.ItemTemplate.InstantiateIn = ;.Columns.Add(tempfield);
            //tempfield.ItemTemplate.InstantiateIn = ;
        }
        catch
        { }
    }
}
