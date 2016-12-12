using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for Intitucion
/// </summary>
public class o_parTipoAtencion
{
    private int neo_CodTipoAtencion;
    public int CodTipoAtencion
    {
        get { return neo_CodTipoAtencion; }
        set { neo_CodTipoAtencion = value; }
    }

    private String neo_Descripcion;
    public String Descripcion
    {
        get { return neo_Descripcion; }
        set { neo_Descripcion = value; }
    }

    private String neo_IndVigencia;
    public String IndVigencia
    {
        get { return neo_IndVigencia; }
        set { neo_IndVigencia = value; }
    }

}