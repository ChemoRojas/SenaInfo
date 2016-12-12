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
/// Summary description for Madre
/// </summary>
/// 
[Serializable]
public class Madre
{
	public Madre()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private string neo_rut_madre;
    public string rut_madre
    {
        get { return neo_rut_madre; }
        set { neo_rut_madre = value; }
    }
    private string neo_Nombres;
    public string Nombres
    {
        get { return neo_Nombres; }
        set { neo_Nombres = value; }
    }
    private string neo_ApePat;
    public string ApePat
    {
        get { return neo_ApePat; }
        set { neo_ApePat = value; }
    }
    private string neo_ApeMat;
    public string ApeMat
    {
        get { return neo_ApeMat; }
        set { neo_ApeMat = value; }
    }
}
