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
/// Summary description for proyecto
/// </summary>
/// 
[Serializable]
public class proyecto : proyectocoll
{
	public proyecto()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private int neo_CodProyecto;
    public int CodProyecto
    {
        get { return neo_CodProyecto; }
        set { neo_CodProyecto = value; }
    }
    private string neo_NombreCorto;
    public string NombreCorto
    {
        get { return neo_NombreCorto; }
        set { neo_NombreCorto = value; }
    }
    private int neo_codproyecto_coincidente;
    public int codproyecto_coincidente
    {
        get { return neo_codproyecto_coincidente; }
        set { neo_codproyecto_coincidente = value; }
    
    }

    private int _nombre;

    public int Nombre
    {
        get { return _nombre; }
        set { _nombre = value; }
    }

    private int _codRegion;

    public int CodRegionProyecto
    {
        get { return _codRegion; }
        set { _codRegion = value; }
    }

}
