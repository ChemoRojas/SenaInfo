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
public class Intitucion
{
	public Intitucion()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private int neo_CodInstitucion;
    public int CodInstitucion
    {
        get { return neo_CodInstitucion; }
        set { neo_CodInstitucion = value; }
    }
    private int neo_TipoInstitucion;
    public int TipoInstitucion
    {
        get { return neo_TipoInstitucion; }
        set { neo_TipoInstitucion = value; }
    }
    private int neo_codSistemaAdministrativo;
    public int codSistemaAdministrativo
    {
        get { return neo_codSistemaAdministrativo; }
        set { neo_codSistemaAdministrativo = value; }
    }
    private int neo_CodComuna;
    public int CodComuna
    {
        get { return neo_CodComuna; }
        set { neo_CodComuna = value; }
    }
    private string neo_RutInstitucion;
    public string RutInstitucion
    {
        get { return neo_RutInstitucion; }
        set { neo_RutInstitucion = value; }
    }
    private string neo_Nombre;
    public string Nombre
    {
        get { return neo_Nombre; }
        set { neo_Nombre = value; }
    }
    private string neo_NombreCorto;
    public string NombreCorto
    {
        get { return neo_NombreCorto; }
        set { neo_NombreCorto = value; }
    }
    private string neo_Direccion;
    public string Direccion
    {
        get { return neo_Direccion; }
        set { neo_Direccion = value; }
    }
    private string neo_Telefono;
    public string Telefono
    {
        get { return neo_Telefono; }
        set { neo_Telefono = value; }
    }
    private string neo_Mail;
    public string Mail
    {
        get { return neo_Mail; }
        set { neo_Mail = value; }
    }
    private string neo_Fax;
    public string Fax
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
    private string neo_RepresentanteLegal;
    public string RepresentanteLegal
    {
        get { return neo_RepresentanteLegal; }
        set { neo_RepresentanteLegal = value; }
    }
    private string neo_RutRepresentante;
    public string RutRepresentante
    {
        get { return neo_RutRepresentante; }
        set { neo_RutRepresentante = value; }
    }
    private string neo_PersonaContacto;
    public string PersonaContacto
    {
        get { return neo_PersonaContacto; }
        set { neo_PersonaContacto = value; }
    }
    private string neo_FechaAniversario;
    public string FechaAniversario
    {
        get { return neo_FechaAniversario; }
        set { neo_FechaAniversario = value; }
    }
    private string neo_NombrePrimeraAutoridad;
    public string NombrePrimeraAutoridad
    {
        get { return neo_NombrePrimeraAutoridad; }
        set { neo_NombrePrimeraAutoridad = value; }
    }
    private string neo_CargoPrimeraAutoridad;
    public string CargoPrimeraAutoridad
    {
        get { return neo_CargoPrimeraAutoridad; }
        set { neo_CargoPrimeraAutoridad = value; }
    }
    private string neo_NumeroPersonalidadJuridica;
    public string NumeroPersonalidadJuridica
    {
        get { return neo_NumeroPersonalidadJuridica; }
        set { neo_NumeroPersonalidadJuridica = value; }
    }
    private string neo_ModoInstitucion;
    public string ModoInstitucion
    {
        get { return neo_ModoInstitucion; }
        set { neo_ModoInstitucion = value; }
    }
    private string neo_DocumentoReconoce;
    public string DocumentoReconoce
    {
        get { return neo_DocumentoReconoce; }
        set { neo_DocumentoReconoce = value; }
    }
    private DateTime neo_FechaIngresoAlRegistro;
    public DateTime FechaIngresoAlRegistro
    {
        get { return neo_FechaIngresoAlRegistro; }
        set { neo_FechaIngresoAlRegistro = value; }
    }
    private string neo_NumeroDocumento;
    public string NumeroDocumento
    {
        get { return neo_NumeroDocumento; }
        set { neo_NumeroDocumento = value; }
    }
    private DateTime neo_FechaDocumento;
    public DateTime FechaDocumento
    {
        get { return neo_FechaDocumento; }
        set { neo_FechaDocumento = value; }
    }
    private string neo_IndVigencia;
    public string IndVigencia
    {
        get { return neo_IndVigencia; }
        set { neo_IndVigencia = value; }
    }
    private string neo_Personeria;
    public string Personeria
    {
        get { return neo_Personeria; }
        set { neo_Personeria = value; }
    }
    private string neo_RutInterventor;
    public string RutInterventor
    {
        get { return neo_RutInterventor; }
        set { neo_RutInterventor = value; }
    }
    private string neo_NombreInterventor;
    public string NombreInterventor
    {
        get { return neo_NombreInterventor; }
        set { neo_NombreInterventor = value; }
    }
    private int neo_IdAdministrador;
    public int IdAdministrador
    {
        get { return neo_IdAdministrador; }
        set { neo_IdAdministrador = value; }
    }
    private bool neo_FechaActualizacion;
    public bool FechaActualizacion
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
    private string neo_ObjetoSocial;
    public string ObjetoSocial
    {
        get { return neo_ObjetoSocial; }
        set { neo_ObjetoSocial = value; }
    }

    private int neo_TipoReconocimiento;
    public int TipoReconocimiento
    {
        get { return neo_TipoReconocimiento; }
        set { neo_TipoReconocimiento = value; }
    }
    private string neo_Vigencia;
    public string Vigencia
    {
        get { return neo_Vigencia; }
        set { neo_Vigencia = value; }
    }
    private int neo_CodAreaEspecializacion;
    public int CodAreaEspecializacion
    {
        get { return neo_CodAreaEspecializacion; }
        set { neo_CodAreaEspecializacion = value; }
    }
    private bool neo_Directorio;
    public bool Directorio
    {
        get { return neo_Directorio; }
        set { neo_Directorio = value; }
    }
    private string neo_MiembrosDirectorio;
    public string MiembrosDirectorio
    {
        get { return neo_MiembrosDirectorio; }
        set { neo_MiembrosDirectorio = value; }
    }
    private string neo_Antecedentesfinancieros;
    public string Antecedentesfinancieros
    {
        get { return neo_Antecedentesfinancieros; }
        set { neo_Antecedentesfinancieros = value; }
    }
    private string neo_MarcoLegal;
    public string MarcoLegal
    {
        get { return neo_MarcoLegal; }
        set { neo_MarcoLegal = value; }
    }
    private string neo_ObjetoTransferencia;
    public string ObjetoTransferencia
    {
        get { return neo_ObjetoTransferencia; }
        set { neo_ObjetoTransferencia = value; }
    }
    private string neo_TrabajosEncargados;
    public string TrabajosEncargados
    {
        get { return neo_TrabajosEncargados; }
        set { neo_TrabajosEncargados = value; }
    }
    private string neo_OrganismoContralor;
    public string OrganismoContralor
    {
        get { return neo_OrganismoContralor; }
        set { neo_OrganismoContralor = value; }
    }
    private string neo_ResultadoEvaluacion;
    public string ResultadoEvaluacion
    {
        get { return neo_ResultadoEvaluacion; }
        set { neo_ResultadoEvaluacion = value; }
    }
    private string neo_CertificadoAntecedentes;
    public string CertificadoAntecedentes
    {
        get { return neo_CertificadoAntecedentes; }
        set { neo_CertificadoAntecedentes = value; }
    }
    private string neo_DatosConstitucion;
    public string DatosConstitucion
    {
        get { return neo_DatosConstitucion; }
        set { neo_DatosConstitucion = value; }
    }

}
