using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mod_buscador_DetallePII : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        //txtFecha.Text = CalFechaAnotacion.SelectedDate.ToString();
        //CalFechaAnotacion.Visible = false;
    }
    protected void btnFecha_Click(object sender, EventArgs e)
    {
        //CalFechaAnotacion.Visible = true;
    }


}