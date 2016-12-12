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
using System.Drawing;
using System.Data.Sql;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections.Generic;

public partial class mod_coordinadores_InstructivoCoordinadorJudicial : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Tokens"] == null || ((DataSet)Session["Tokens"]).Tables[0].Rows.Count == 0)
                Response.Redirect("~/logout.aspx");
            else
            {
                if (!window.existetoken("AA938FAD-0140-474C-9DEA-6D6BF31E0A3D"))
                    Response.Redirect("~/logout.aspx");
                else
                {
                    Response.Redirect("www.senainfo.cl/links/INSTRUCTIVO-COORDINADORES.pdf");
                }
            }
        }
    }
}