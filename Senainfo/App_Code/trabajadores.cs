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
public class o_Trabajadores
{
    private int neo_CodInstitucion;
    public int CodInstitucion
    {
        get { return neo_CodInstitucion; }
        set { neo_CodInstitucion = value; }
    }

    private int neo_CodTrabajador;
    public int CodTrabajador
    {
        get { return neo_CodTrabajador; }
        set { neo_CodTrabajador = value; }
    }

    private int neo_CodProfesion;
    public int CodProfesion
    {
        get { return neo_CodProfesion; }
        set { neo_CodProfesion = value; }
    }

    private String neo_Paterno;
    public String Paterno
    {
        get { return neo_Paterno; }
        set { neo_Paterno = value; }
    }

    private String neo_Materno;
    public String Materno
    {
        get { return neo_Materno; }
        set { neo_Materno = value; }
    }

    private String neo_Nombres;
    public String Nombres
    {
        get { return neo_Nombres; }
        set { neo_Nombres = value; }
    }

    private String neo_RutTrabajador;
    public String RutTrabajador
    {
        get { return neo_RutTrabajador; }
        set { neo_RutTrabajador = value; }
    }

    private String neo_Telefono;
    public String Telefono
    {
        get { return neo_Telefono; }
        set { neo_Telefono = value; }
    }

    private String neo_Mail;
    public String Mail
    {
        get { return neo_Mail; }
        set { neo_Mail = value; }
    }

    private String neo_Fax;
    public String Fax
    {
        get { return neo_Fax; }
        set { neo_Fax = value; }
    }

    private int neo_CodigoPostal;
    public int CodigoPostal
    {
        get { return neo_CodigoPostal; }
        set { neo_CodigoPostal = value; }
    }

    private String neo_IndVigencia;
    public String IndVigencia
    {
        get { return neo_IndVigencia; }
        set { neo_IndVigencia = value; }
    }

    private DateTime neo_FechaActualizacion;
    public DateTime FechaActualizacion
    {
        get { return neo_FechaActualizacion; }
        set { neo_FechaActualizacion = value; }
    }

    private int neo_IdUsuarioActualizacion;
    public int IdUsuarioActualizacion
    {
        get { return neo_IdUsuarioActualizacion; }
        set { neo_IdUsuarioActualizacion = value; }
    }

}