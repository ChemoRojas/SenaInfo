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

public partial class links_link : System.Web.UI.Page
{

    public string res
    {
        get { return (string)Session["res"]; }
        set { Session["res"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //protected void btnnext(object sender, EventArgs e)
    //{

    //    //string vdir = "22";
    //    //Response.Write("<script language='JavaScript'>var url =../SENAME.SENAINFO/mod_niños/ninos_index.aspx?sw=4&codinst=2130550&codproy=6938&delta='"+vdir+"';");
    //    //Response.Write("window.opener.location = url;");
    //    //Response.Write("self.close();");
    //    //Response.Write("</script>");
    //    res = "si";
    //    ClientScript.RegisterClientScriptBlock(typeof(string), "SENAINFO2", "<script  languaje=javascript> window.opener.__doPostBack('btnbind',''); </script>");
    //    window.close(this.Page);
    //}
    //protected void btnnext_no(object sender, EventArgs e)
    //{
    //    res = "no";
    //    ClientScript.RegisterClientScriptBlock(typeof(string), "SENAINFO2", "<script  languaje=javascript> window.opener.__doPostBack('btnbind',''); </script>");
    //    window.close(this.Page);
    //}
    protected void btnnext(object sender, EventArgs e)
    {
        //string vdir = "22";
        //Response.Write("<script language='JavaScript'>var url =../SENAME.SENAINFO/mod_niños/ninos_index.aspx?sw=4&codinst=2130550&codproy=6938&delta='"+vdir+"';");
        //Response.Write("window.opener.location = url;");
        //Response.Write("self.close();");
        //Response.Write("</script>");
        res = "si";
        ClientScript.RegisterClientScriptBlock(typeof(string), "SENAINFO2", "<script  languaje=javascript> window.opener.__doPostBack('btnbind',''); </script>");
        window.close(this.Page);
    }
    protected void btnnext_no(object sender, EventArgs e)
    {
        res = "no";
        ClientScript.RegisterClientScriptBlock(typeof(string), "SENAINFO2", "<script  languaje=javascript> window.opener.__doPostBack('btnbind',''); </script>");
        window.close(this.Page);
    }
}
