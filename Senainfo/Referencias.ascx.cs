using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Windows.Forms;
//using Argentis.Regmen;

public partial class Referencias : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Write(AppRelativeVirtualPath.);
        Response.Write(Parent.AppRelativeTemplateSourceDirectory.ToString());

        if (Parent.AppRelativeTemplateSourceDirectory.ToString().Contains("~/mod"))
        {
            if (IsViewStateEnabled)
            {

                //Response.Write("es mod");

                Page.Header.Controls.Add(
                  new System.Web.UI.LiteralControl("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + ResolveUrl("css/bootstrap.min.css") + "\" />"));

                Page.Header.Controls.Add(
                  new System.Web.UI.LiteralControl("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + ResolveUrl("css/bootstrap-theme.min.css") + "\" />"));

                Page.Header.Controls.Add(
                  new System.Web.UI.LiteralControl("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + ResolveUrl("css/theme.css") + "\" />"));

                //Page.Header.Controls.Remove(
                //  new System.Web.UI.LiteralControl("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + ResolveUrl("../css/bootstrap.min.css") + "\" />"));

                //Page.Header.Controls.Remove(
                //  new System.Web.UI.LiteralControl("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + ResolveUrl("../css/bootstrap-theme.min.css") + "\" />"));

                //Page.Header.Controls.Remove(
                //  new System.Web.UI.LiteralControl("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + ResolveUrl("../css/theme.css") + "\" />"));

            }
        }
        else
        {
            if (IsViewStateEnabled)
            {

                //Response.Write("no es mod");

                Page.Header.Controls.Add(
                  new System.Web.UI.LiteralControl("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + ResolveUrl("css/bootstrap.min.css") + "\" />"));

                Page.Header.Controls.Add(
                  new System.Web.UI.LiteralControl("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + ResolveUrl("css/bootstrap-theme.min.css") + "\" />"));

                Page.Header.Controls.Add(
                  new System.Web.UI.LiteralControl("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + ResolveUrl("css/theme.css") + "\" />"));

                //Page.Header.Controls.Remove(
                //  new System.Web.UI.LiteralControl("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + ResolveUrl("../css/bootstrap.min.css") + "\" />"));

                //Page.Header.Controls.Remove(
                //  new System.Web.UI.LiteralControl("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + ResolveUrl("../css/bootstrap-theme.min.css") + "\" />"));

                //Page.Header.Controls.Remove(
                //  new System.Web.UI.LiteralControl("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + ResolveUrl("../css/theme.css") + "\" />"));

            }
        }
    }
}