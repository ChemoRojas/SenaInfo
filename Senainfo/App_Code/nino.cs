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
/// Summary description for nino
/// </summary>
[Serializable]
public class nino
{
    public nino()
    {
        this.neo_FechaAdoptabilidad = new DateTime(1900, 01, 01);
        this.neo_OficinaInscripcion = "0";
        this.neo_NumeroInscripcionCivil = "0";
        this.neo_AnoInscripcion = 0;
        this.neo_AlergiasConocidas = "0";
        this.InscritoFONADIS = false;
        this.InscritoFONASA = false;
        this.neo_NinoSuceptibleAdopcion = false;
        this.neo_EstadoGestacion = "N";
        this.neo_MuestraADN = 0;
        this.neo_CodTipoUsuario = 0;
        this.neo_CodTipoNacionalidad = 0;
        

    }

    private string neo_rut;
    public string rut
    {
        get { return neo_rut; }
        set { neo_rut = value; }
    }
    private string neo_Apellido_Paterno;
    public string Apellido_Paterno
    {
        get { return neo_Apellido_Paterno; }
        set { neo_Apellido_Paterno = value; }
    }
    private string neo_Apellido_Materno;
    public string Apellido_Materno
    {
        get { return neo_Apellido_Materno; }
        set { neo_Apellido_Materno = value; }
    }
    private string neo_Nombres;
    public string Nombres
    {
        get { return neo_Nombres; }
        set { neo_Nombres = value; }
    }
    private DateTime neo_FechaNacimiento;
    public DateTime FechaNacimiento
    {
        get { return neo_FechaNacimiento; }
        set { neo_FechaNacimiento = value; }
    }
    private DateTime neo_FechaAdoptabilidad;
    public DateTime FechaAdoptabilidad
    {
        get { return neo_FechaAdoptabilidad; }
        set { neo_FechaAdoptabilidad = value; }
    }

    private string neo_sexo;
    public string sexo
    {
        get { return neo_sexo; }
        set { neo_sexo = value; }
    }
    private string neo_NombreInst;
    public string NombreInst
    {
        get { return neo_NombreInst; }
        set { neo_NombreInst = value; }
    }
    private int neo_CodInst;
    public int CodInst
    {
        get { return neo_CodInst; }
        set { neo_CodInst = value; }
    }
    private int neo_ICodIE;
    public int ICodIE
    {
        get { return neo_ICodIE; }
        set { neo_ICodIE = value; }
    }
    private int neo_CodProyecto;
    public int CodProyecto
    {
        get { return neo_CodProyecto; }
        set { neo_CodProyecto = value; }
    }
    private int neo_CodNino;
    public int CodNino
    {
        get { return neo_CodNino; }
        set { neo_CodNino = value; }
    }
    private string neo_NombreProy;
    public string NombreProy
    {
        get { return neo_NombreProy; }
        set { neo_NombreProy = value; }
    }
    private DateTime neo_fchingdesde;
    public DateTime fchingdesde
    {
        get { return neo_fchingdesde; }
        set { neo_fchingdesde = value; }
    }
    private DateTime neo_fchinghasta;
    public DateTime fchinghasta
    {
        get { return neo_fchinghasta; }
        set { neo_fchinghasta = value; }
    }
    private DateTime neo_fchegdesde;
    public DateTime fchegdesde
    {
        get { return neo_fchegdesde; }
        set { neo_fchegdesde = value; }
    }
    private DateTime neo_fcheghasta;
    public DateTime fcheghasta
    {
        get { return neo_fcheghasta; }
        set { neo_fcheghasta = value; }
    }
    private DateTime neo_vigenteen;
    public DateTime vigenteen
    {
        get { return neo_vigenteen; }
        set { neo_vigenteen = value; }
    }
    private string neo_engest;
    public string engest
    {
        get { return neo_engest; }
        set { neo_engest = value; }
    }
    private bool neo_insearch;
    public bool insearch
    {
        get { return neo_insearch; }
        set { neo_insearch = value; }
    }
    private int neo_ctrlload;
    public int ctrlload
    {
        get { return neo_ctrlload; }
        set { neo_ctrlload = value; }
    }
    private int neo_ICodinformediagnostico;
    public int ICodinformediagnostico
    {
        get { return neo_ICodinformediagnostico; }
        set { neo_ICodinformediagnostico = value; }
    }
    private DateTime neo_InicioInformeDiagnostico;
    public DateTime InicioInformeDiagnostico
    {
        get { return neo_InicioInformeDiagnostico; }
        set { neo_InicioInformeDiagnostico = value; }
    }
    private bool neo_IdentidadConfirmada;
    public bool IdentidadConfirmada
    {
        get { return neo_IdentidadConfirmada; }
        set { neo_IdentidadConfirmada = value; }
    }
    private int neo_CodNacionalidad;
    public int CodNacionalidad
    {
        get { return neo_CodNacionalidad; }
        set { neo_CodNacionalidad = value; }
    }

    private int neo_CodEtnia;
    public int CodEtnia
    {
        get { return neo_CodEtnia; }
        set { neo_CodEtnia = value; }
    }
    private int neo_Estado;
    public int Estado
    {
        get { return neo_Estado; }
        set { neo_Estado = value; }
    }

    private String neo_OficinaInscripcion;
    public String OficinaInscripcion
    {
        get { return neo_OficinaInscripcion; }
        set { neo_OficinaInscripcion = value; }
    }

    private int neo_AnoInscripcion;
    public int AnoInscripcion
    {
        get { return neo_AnoInscripcion; }
        set { neo_AnoInscripcion = value; }
    }

    private String neo_NumeroInscripcionCivil;
    public String NumeroInscripcionCivil
    {
        get { return neo_NumeroInscripcionCivil; }
        set { neo_NumeroInscripcionCivil = value; }
    }

    private String neo_AlergiasConocidas;
    public String AlergiasConocidas
    {
        get { return neo_AlergiasConocidas; }
        set { neo_AlergiasConocidas = value; }
    }

    private bool neo_InscritoFONADIS;
    public bool InscritoFONADIS
    {
        get { return neo_InscritoFONADIS; }
        set { neo_InscritoFONADIS = value; }
    }

    private bool neo_InscritoFONASA;
    public bool InscritoFONASA
    {
        get { return neo_InscritoFONASA; }
        set { neo_InscritoFONASA = value; }
    }

    private bool neo_NinoSuceptibleAdopcion;
    public bool NinoSuceptibleAdopcion
    {
        get { return neo_NinoSuceptibleAdopcion; }
        set { neo_NinoSuceptibleAdopcion = value; }
    }

    private String neo_EstadoGestacion;
    public String EstadoGestacion
    {
        get { return neo_EstadoGestacion; }
        set { neo_EstadoGestacion = value; }
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
    private int neo_tipobusqueda;
    public int tipobusqueda
    {
        get { return neo_tipobusqueda; }
        set { neo_tipobusqueda = value; }
    }

    // desde aqui nuevos valores agregados por HPP Argentis para uso en la lista de espera//

    private int neo_CodTribunal;
    public int CodTribunal
    {
        get { return neo_CodTribunal; }
        set { neo_CodTribunal = value; }
    }

    private int neo_Tribunal;
    public int Tribunal
    {
        get { return neo_Tribunal; }
        set { neo_Tribunal = value; }
    }

    private String neo_RUC;
    public String RUC
    {
        get { return neo_RUC; }
        set { neo_RUC = value; }
    }

    private String neo_RIT;
    public String RIT
    {
        get { return neo_RIT; }
        set { neo_RIT = value; }
    }

    private DateTime neo_FechaOrden;
    public DateTime FechaOrden
    {
        get { return neo_FechaOrden; }
        set { neo_FechaOrden = value; }
    }

    private int neo_Tipo_Tribunal;
    public int Tipo_Tribunal
    {
        get { return neo_Tipo_Tribunal; }
        set { neo_Tipo_Tribunal = value; }
    }

    private String neo_DesTipoTribunal;
    public String DesTipoTribunal
    {
        get { return neo_DesTipoTribunal; }
        set { neo_DesTipoTribunal = value; }
    }

    private int neo_CodRegion;
    public int CodRegion
    {
        get { return neo_CodRegion; }
        set { neo_CodRegion = value; }
    }

    private String neo_Region;
    public String Region
    {
        get { return neo_Region; }
        set { neo_Region = value; }
    }

    private int neo_CodTipoCausalIngreso;
    public int CodTipoCausalIngreso
    {
        get { return neo_CodTipoCausalIngreso; }
        set { neo_CodTipoCausalIngreso = value; }
    }

    private int neo_CodCausal;
    public int CodCausal
    {
        get { return neo_CodCausal; }
        set { neo_CodCausal = value; }
    }

    private int neo_CodNumCausal;
    public int CodNumCausal
    {
        get { return neo_CodNumCausal; }
        set { neo_CodNumCausal = value; }
    }

    //hasta aqui HPP Argentis //

    private int neo_MuestraADN;

    public int MuestraADN
    {
        get { return neo_MuestraADN; }
        set { neo_MuestraADN = value; }
    }

    private int neo_CodTipoUsuario;

    public int CodTipoUsuario
    {
        get { return neo_CodTipoUsuario; }
        set { neo_CodTipoUsuario = value; }
    }

    private int neo_CodTipoNacionalidad;

    public int CodTipoNacionalidad
    {
        get { return neo_CodTipoNacionalidad; }
        set { neo_CodTipoNacionalidad = value; }
    }

    private string neo_Cua;
    public string Cua
    {
        get { return neo_Cua; }
        set { neo_Cua = value; }
    }

    private string _causalDefuncion;

    public string CausalDefuncion
    {
        get { return _causalDefuncion; }
        set { _causalDefuncion = value; }
    }

    private DateTime _fechaDefuncion;

    public DateTime FechaDefuncion
    {
        get { return _fechaDefuncion; }
        set { _fechaDefuncion = value; }
    }

    private int _codLugarDefuncion;

    public int CodLugarDefuncion
    {
        get { return _codLugarDefuncion; }
        set { _codLugarDefuncion = value; }
    }

    private int _regionDefuncion;

    public int CodRegionDefuncion
    {
        get { return _regionDefuncion; }
        set { _regionDefuncion = value; }
    }

    private int _codComunaDefuncion;

    public int CodComunaDefuncion
    {
        get { return _codComunaDefuncion; }
        set { _codComunaDefuncion = value; }
    }

    private DateTime _fechaDenunciaMP;

    public DateTime FechaDenunciaMP
    {
        get { return _fechaDenunciaMP; }
        set { _fechaDenunciaMP = value; }
    }

    private DateTime _fechaQuerella;

    public DateTime FechaQuerella
    {
        get { return _fechaQuerella; }
        set { _fechaQuerella = value; }
    }

    private int _seActivaCircular;

    public int SeActivaCircular
    {
        get { return _seActivaCircular; }
        set { _seActivaCircular = value; }
    }

    private DateTime _fechaCertificado;

    public DateTime FechaCertificado
    {
        get { return _fechaCertificado; }
        set { _fechaCertificado = value; }
    }

    private string _numeroCertificado;

    public string NumeroCertificado
    {
        get { return _numeroCertificado; }
        set { _numeroCertificado = value; }
    }
}
