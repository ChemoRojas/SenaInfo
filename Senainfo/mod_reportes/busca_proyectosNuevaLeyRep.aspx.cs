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
//////using neocsharp.NeoDatabase;

using System.Data.Common;
using System.Collections.Generic;

public partial class mod_coordinadores_busca_proyectosNuevaLey : System.Web.UI.Page
{
  private DataTable DtBusqueda
  {
    get { return (DataTable)Session["DtBusqueda"]; }
    set { Session["DtBusqueda"] = value; }
  }
  public string CodInst
  {
    get { return (string)Session["CodInst"]; }
    set { Session["CodInst"] = value; }
  }
  public string CodProy
  {
    get { return (string)Session["CodProy"]; }
    set { Session["CodProy"] = value; }
  }
  public string NomProy
  {
    get { return (string)Session["NomProy"]; }
    set { Session["NomProy"] = value; }
  }
  private DataTable dtRol
  {
    get { return (DataTable)Session["dtRol"]; }
    set { Session["dtRol"] = value; }
  }
  protected void Page_Load(object sender, EventArgs e)
  {
    if (!IsPostBack)
    {
      coordinador cr = new coordinador();
      dtRol = cr.consulta_rol(Convert.ToInt32(Session["IdUsuario"]));
      getmedida();
      getinstituciones();
      imb001.Visible = true;
    }
  }

  private void getmedida()
  {
    coordinador cr = new coordinador();
    string sql = "Select  * From parmodelointervencion WHERE LRPA > 0";
    DataTable dtproy = cr.ejecuta_SQL(sql, null);

    DataRow dr;
    dr = dtproy.NewRow();
    dr[0] = "0";
    dr[1] = "Seleccionar";
    dtproy.Rows.Add(dr);

    DataView dv = new DataView(dtproy);
    dv.Sort = "CodModeloIntervencion";

    ddown002.DataSource = dv;
    ddown002.DataTextField = "Descripcion";
    ddown002.DataValueField = "CodModeloIntervencion";
    ddown002.DataBind();

    ddown002.SelectedValue = "0";
  }
  private void getinstituciones()
  {

    institucioncoll ncoll = new institucioncoll();
    DataView dv1 = new DataView(ncoll.GetData(Convert.ToInt32(Session["IdUsuario"])));
    ddown003.DataSource = dv1;
    ddown003.DataTextField = "Nombre";
    ddown003.DataValueField = "CodInstitucion";
    dv1.Sort = "Nombre";
    DataBind();


  }
  protected void imb001_Click(object sender, EventArgs e)
  {
    FunctionSelectProyecto();
  }
  private void FunctionSelectProyecto()
  {
      Conexiones con = new Conexiones();
      List<DbParameter> listDbParameter = new List<DbParameter>();

      string sParametrosConsulta = "";
    int codrol = Convert.ToInt32(dtRol.Rows[0][1]);
    if (codrol == 275 || codrol == 252 || codrol == 253 || codrol == 258 || codrol == 260 || codrol == 261 || codrol == 255 || codrol == 257 || codrol == 254 || codrol == 256 || codrol == 259 || codrol == 275 || codrol == 283)
    {
      sParametrosConsulta = "Select  t1.CodProyecto,t1.CodInstitucion,t1.codcausalterminoproyecto, " +
     "t2.Descripcion as TipoProyecto,t1.Nombre,t1.CodSistemaAsistencial " +
     "from Proyectos t1  inner join partipoproyecto  t2 ON t1.tipoproyecto = t2.tipoproyecto " +
     "where t1.IndVigencia = 'V' and t1.EstadoProyecto = 1 and t1.codcausalterminoproyecto = '20084' ";
    }
    else //if (codrol == 276)
    {
      if (codrol == 263 || codrol == 262 || codrol == 264 || codrol == 248 || codrol == 249 || codrol == 282)
      {
        //Convert.ToInt32(Session["IdUsuario"])
        sParametrosConsulta = "Select  t1.CodProyecto,t1.CodInstitucion,t1.codcausalterminoproyecto, " +
    "t2.Descripcion as TipoProyecto,t1.Nombre,t1.CodSistemaAsistencial " +
    "from Proyectos t1 inner join partipoproyecto  t2 ON t1.tipoproyecto = t2.tipoproyecto " +
    "where t1.IndVigencia = 'V' and t1.EstadoProyecto = 1 and t1.codcausalterminoproyecto = '20084' " +
    "and t1.CodRegion=(select CodRegion  from usuarios where idusuario =@pIdUsuario)";
        //"and t3.ICodTrabajador =" + Convert.ToInt32(dtRol.Rows[0][3]) + " ";

        listDbParameter.Add(con.parametros("@pIdUsuario", SqlDbType.Int, 4, Convert.ToInt32(Session["IdUsuario"])));
      }
      else
      {
        sParametrosConsulta = "Select  t1.CodProyecto,t1.CodInstitucion,t1.codcausalterminoproyecto, " +
       "t2.Descripcion as TipoProyecto,t1.Nombre,t1.CodSistemaAsistencial " +
       "from Proyectos t1 inner join partipoproyecto  t2 ON t1.tipoproyecto = t2.tipoproyecto " +
       "inner join TrabajadorProyecto t3 ON t1.CodProyecto = t3.CodProyecto " +
       "where t1.IndVigencia = 'V' and t1.EstadoProyecto = 1 and t1.codcausalterminoproyecto = '20084' " +
       "and t1.CodRegion=@pCodRegion " +
       "and t3.ICodTrabajador =@pICodTrabajador ";

        listDbParameter.Add(con.parametros("@pCodRegion", SqlDbType.Int, 4, Convert.ToInt32(dtRol.Rows[0][2])));
        listDbParameter.Add(con.parametros("@pICodTrabajador", SqlDbType.Int, 4, Convert.ToInt32(dtRol.Rows[0][3])));
      }
      // sParametrosConsulta = "Select  t1.CodProyecto,t1.CodInstitucion,t1.codcausalterminoproyecto, " +
      //"t2.Descripcion as TipoProyecto,t1.Nombre,t1.CodSistemaAsistencial " +
      //"from Proyectos t1  inner join partipoproyecto  t2 ON t1.tipoproyecto = t2.tipoproyecto " +
      //"where t1.IndVigencia = 'V' and t1.EstadoProyecto = 1 and t1.codcausalterminoproyecto = '20084' " +
      //"and t1.CodRegion=" + Convert.ToInt32(dtRol.Rows[0][2]) + " ";


    }


    if (txt001.Text != "" || txt0011.Text != "" || txt0012.Text != "" || ddown002.SelectedValue != "0")
    {
      sParametrosConsulta = sParametrosConsulta + " And";
    }
    if (txt001.Text != "")
    {
        sParametrosConsulta = sParametrosConsulta + " t1.CodInstitucion =@pCodInstitucion And";

        listDbParameter.Add(con.parametros("@pCodInstitucion", SqlDbType.Int, 4, Convert.ToInt32(txt001.Text)));
    }
    if (txt0011.Text != "")
    {
        sParametrosConsulta = sParametrosConsulta + " t1.Nombre like @pNombre And";

        listDbParameter.Add(con.parametros("@pNombre", SqlDbType.VarChar, 100, "%" + txt0011.Text + "%"));
    }
    if (txt0012.Text != "")
    {
        sParametrosConsulta = sParametrosConsulta + " t1.CodProyecto =@pCodProyecto And";

        listDbParameter.Add(con.parametros("@pCodProyecto", SqlDbType.Int, 4, Convert.ToInt32(txt0012.Text)));
    }
    if (ddown002.SelectedValue != "0")
    {
        sParametrosConsulta = sParametrosConsulta + " t1.CodModeloIntervencion =@pCodModeloIntervencion And";

        listDbParameter.Add(con.parametros("@pCodModeloIntervencion", SqlDbType.Int, 4, Convert.ToInt32(ddown002.SelectedValue)));
    }
    if (sParametrosConsulta.Substring(sParametrosConsulta.Length - 3, 3) == "And")
    {
      sParametrosConsulta = sParametrosConsulta.Substring(0, sParametrosConsulta.Length - 3);
    }

    buscador_institucion bsc_inst = new buscador_institucion();
    DataTable dt = bsc_inst.Get_Resultado_Busqueda(sParametrosConsulta, listDbParameter, "Busca Proyectos");

    if (dt.Rows.Count > 0 && dt.Rows.Count < 200)
    {
      //lbl0013.Visible = true;
      //lbl0014.Visible = true;
      //lbl0015.Visible = true;
      //lbl0014.Text = "Coincidencias";
      //lbl0013.Text = Convert.ToString(dt.Rows.Count);

      DtBusqueda = dt;
      CargaGrilla();
      imb001.Visible = false;

    }
    else if (dt.Rows.Count == 0)
    {
      //lbl0013.Visible = true;
      //lbl0014.Visible = true;
      //lbl0015.Visible = false;
      //lbl0014.Text = "Coincidencias";
      //lbl0013.Text = Convert.ToString(dt.Rows.Count); 
      DtBusqueda = dt;
      CargaGrilla();
      imb001.Visible = false;
    }
    else if (dt.Rows.Count >= 200)
    {
      lbl0013.Visible = false;
      lbl0014.Visible = true;
      lbl0015.Visible = false;
      lbl0014.Text = "Búsqueda demasiado ambigua, Ingrese parámetros.";
    }

  }
  protected void imb002_Click(object sender, EventArgs e)
  {
      grd001.DataSource = null;
      grd001.DataBind();
      grd001.Visible = false;
      pnl001.Visible = true;
    imb001.Visible = true;
    txt001.Text = "";
    txt0011.Text = "";
    txt0012.Text = "";
    ddown002.SelectedValue = "0";
    ddown003.SelectedValue = "0";
  }
  protected void ImageButton1_Click(object sender, EventArgs e)
  {
    if (txt001.Text != "")
    {
      ListItem val = ddown003.Items.FindByValue(txt001.Text);
      if (val != null)
      {
        ddown003.SelectedValue = txt001.Text;
        ddown003.Visible = true;
      }
    }
  }
  protected void ddown003_SelectedIndexChanged(object sender, EventArgs e)
  {
    txt001.Text = ddown003.SelectedValue;
  }
  protected void imb003_Click(object sender, EventArgs e)
  {
    window.close(this.Page);
  }
  protected void lnkbtnver_Click(object sender, EventArgs e)
  {
    lbl0013.Visible = false;
    lbl0014.Visible = false;
    lbl0015.Visible = false;
    imb001.Visible = false;
    Response.Write("<script language='JavaScript'>");
    Response.Write("window.resizeTo(770,420)");
    Response.Write("</script>");
    CargaGrilla();
  }
  private void CargaGrilla()
  {
    DataTable dt = DtBusqueda;

    grd001.Visible = true;
    DataView dv = new DataView(dt);
    grd001.DataSource = dv;
    grd001.DataBind();    
    pnl001.Visible = false;

  }
  protected void grd001_PageIndexChanging(object sender, GridViewPageEventArgs e)
  {
    grd001.PageIndex = e.NewPageIndex;
    CargaGrilla();
  }
  protected void grd001_rowcommand(object sender, GridViewCommandEventArgs e)
  {
    if (e.CommandName == "V")
    {

      CodProy = grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text;
      NomProy = grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text;
      CodInst = grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
      //ClientScript.RegisterClientScriptBlock(typeof(string), "SENAINFO2", "<script  languaje=javascript> window.parent.__doPostBack('btnproy',''); </script>");
      ////window.close(this.Page);
      //ClientScript.RegisterStartupScript(this.GetType(), "", "CerrarFancybox()", true);

      //string codproy = grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[1].Text; ;
      //string ccodinst = grd001.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;

      string url = "../mod_coordinadores/Coordinadores_Ingreso.aspx?codproyecto=" + CodProy;
      ClientScript.RegisterStartupScript(this.GetType(), "", "AbrirURLModalPopUp('" + url + "');", true);

    }
  }
}
