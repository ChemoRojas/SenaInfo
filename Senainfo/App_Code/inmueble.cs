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

    public class o_parTipoInmueble
    {
        private int neo_TipoInmueble;
        public int TipoInmueble
        {
            get { return neo_TipoInmueble; }
            set { neo_TipoInmueble = value; }
        }

        private String neo_Descripcion;
        public String Descripcion
        {
            get { return neo_Descripcion; }
            set { neo_Descripcion = value; }
        }

        private String neo_Indvigencia;
        public String Indvigencia
        {
            get { return neo_Indvigencia; }
            set { neo_Indvigencia = value; }
        }

    }
public class o_Inmueble
{
    private int neo_CodInstitucion;
    public int CodInstitucion
    {
        get { return neo_CodInstitucion; }
        set { neo_CodInstitucion = value; }
    }

    private int neo_CodInmueble;
    public int CodInmueble
    {
        get { return neo_CodInmueble; }
        set { neo_CodInmueble = value; }
    }

    private int neo_IdUsuarioActualizacion;
    public int IdUsuarioActualizacion
    {
        get { return neo_IdUsuarioActualizacion; }
        set { neo_IdUsuarioActualizacion = value; }
    }

    private int neo_CodsituacionLegalInmueble;
    public int CodsituacionLegalInmueble
    {
        get { return neo_CodsituacionLegalInmueble; }
        set { neo_CodsituacionLegalInmueble = value; }
    }

    private int neo_CodComuna;
    public int CodComuna
    {
        get { return neo_CodComuna; }
        set { neo_CodComuna = value; }
    }

    private int neo_TipoInmueble;
    public int TipoInmueble
    {
        get { return neo_TipoInmueble; }
        set { neo_TipoInmueble = value; }
    }

    private String neo_Nombre;
    public String Nombre
    {
        get { return neo_Nombre; }
        set { neo_Nombre = value; }
    }

    private String neo_Direccion;
    public String Direccion
    {
        get { return neo_Direccion; }
        set { neo_Direccion = value; }
    }

    private String neo_Telefono;
    public String Telefono
    {
        get { return neo_Telefono; }
        set { neo_Telefono = value; }
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

    private int neo_m2Construidos;
    public int m2Construidos
    {
        get { return neo_m2Construidos; }
        set { neo_m2Construidos = value; }
    }

    private int neo_m2totales;
    public int m2totales
    {
        get { return neo_m2totales; }
        set { neo_m2totales = value; }
    }

    private int neo_NumeroDormitorios;
    public int NumeroDormitorios
    {
        get { return neo_NumeroDormitorios; }
        set { neo_NumeroDormitorios = value; }
    }

    private int neo_CapacidadNinos;
    public int CapacidadNinos
    {
        get { return neo_CapacidadNinos; }
        set { neo_CapacidadNinos = value; }
    }

    private int neo_NumeroBanos;
    public int NumeroBanos
    {
        get { return neo_NumeroBanos; }
        set { neo_NumeroBanos = value; }
    }

    private int neo_CantidadPisos;
    public int CantidadPisos
    {
        get { return neo_CantidadPisos; }
        set { neo_CantidadPisos = value; }
    }

    private String neo_AreasVerdes;
    public String AreasVerdes
    {
        get { return neo_AreasVerdes; }
        set { neo_AreasVerdes = value; }
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

}


