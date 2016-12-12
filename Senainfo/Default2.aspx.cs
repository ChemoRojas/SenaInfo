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

public partial class Default2 : System.Web.UI.Page
{

    protected SqlDataSource sql = new SqlDataSource("Data Source=KRONOS;Initial Catalog=senainfo;Persist Security Info=True;User ID=neoportal;Password=neoportal", "select * from ninos where apellido_paterno = 'cruzat'");
 
    protected void Page_Load(object sender, EventArgs e)
    {
        Button1.Attributes.Add("onclick", "__doPostBack(\'DropDownList1\',\'\')");
    }

    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
 
    //protected void WebImageButton1_Click(object sender, EventArgs e)
    //{
        
    //}
    protected void WebImageButton1_Click(object sender, EventArgs e)
    {

    }
}
