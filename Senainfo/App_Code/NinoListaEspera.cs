using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de NinoListaEspera
/// </summary>
public class NinoListaEspera
{

    private int _iCodIngresoLE;

    public int CodIngresoLE
    {
        get { return _iCodIngresoLE; }
        set { _iCodIngresoLE = value; }
    }
    

    private int _codNino;

    public int CodNino
    {
        get { return _codNino; }
        set { _codNino = value; }
    }

    private int _icodie;

    public int ICodIE
    {
        get { return _icodie; }
        set { _icodie = value; }
    }

    private DateTime _fechaIngresoListaEspera;

    public DateTime FechaIngresoListaEspera
    {
        get { return _fechaIngresoListaEspera; }
        set { _fechaIngresoListaEspera = value; }
    }

    private DateTime _fechaEgresoListaEspera;

    public DateTime FechaEgresoListaEspera
    {
        get { return _fechaEgresoListaEspera; }
        set { _fechaEgresoListaEspera = value; }
    }

    private int _codTribunal;

    public int CodTribunal
    {
        get { return _codTribunal; }
        set { _codTribunal = value; }
    }

    private string _ruc;

    public string RUC
    {
        get { return _ruc; }
        set { _ruc = value; }
    }

    private string _rit;

    public string RIT
    {
        get { return _rit; }
        set { _rit = value; }
    }

    private DateTime _fechaOrden;

    public DateTime FechaOrden
    {
        get { return _fechaOrden; }
        set { _fechaOrden = value; }
    }

    private int _codCausalIngreso;

    public int CodCausalIngreso
    {
        get { return _codCausalIngreso; }
        set { _codCausalIngreso = value; }
    }

    private int _codProyecto;

    public int CodProyecto
    {
        get { return _codProyecto; }
        set { _codProyecto = value; }
    }

    //IdUsuario Actualizacion

    //FechaActualizacion

    private int _codEstado;

    public int CodEstado
    {
        get { return _codEstado; }
        set { _codEstado = value; }
    }

    private int _codComuna;

    public int CodComuna
    {
        get { return _codComuna; }
        set { _codComuna = value; }
    }

    private int _codSolicitanteIngreso;

    public int CodSolicitanteIngreso
    {
        get { return _codSolicitanteIngreso; }
        set { _codSolicitanteIngreso = value; }
    }

    private int _codInstitucion;

    public int CodInstitucion
    {
        get { return _codInstitucion; }
        set { _codInstitucion = value; }
    }

    private int _idUsuarioActualizacion;

    public int IdUsuarioActualizacion
    {
        get { return _idUsuarioActualizacion; }
        set { _idUsuarioActualizacion = value; }
    }

    private DateTime _fechaActualizacion;

    public DateTime FechaActualizacion
    {
        get { return _fechaActualizacion; }
        set { _fechaActualizacion = value; }
    }


    
    

    //private string _sexo;

    //public string Sexo
    //{
    //    get { return _sexo; }
    //    set { _sexo = value; }
    //}
    
    
    

    //callto_guardo_listaespera(codNino, ICodIE, fechaIngresoListaEspera, fechaEgresoListaEspera, codTribunal,
    //            RUC, RIT, fechaOrden, codCausalIngreso, codProyecto, Convert.ToInt32(Session["IdUsuario"].ToString()),
    //            DateTime.Now, 0, codComuna, codSolicitanteIngreso);

    public NinoListaEspera()
    {
        this._iCodIngresoLE = 0;
        this._codNino = 0;
        this._icodie = 0;
        this._fechaIngresoListaEspera = new DateTime(1900, 01, 01);
        this._fechaEgresoListaEspera = new DateTime(1900, 01, 01);
        this._codTribunal = 0;
        this._ruc = string.Empty;
        this._rit = string.Empty;
        this._fechaOrden = new DateTime(1900, 01, 01);
        this._codCausalIngreso = 0;
        this._codProyecto = 0;
        this._codEstado = 0;
        this._codComuna = 0;
        this._codSolicitanteIngreso = 0;
        this._codInstitucion = 0;
        this._idUsuarioActualizacion = 0;
        this._fechaActualizacion = new DateTime(1900, 01, 01);
        //this._sexo = string.Empty;
    }
}