using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


/// <summary>
/// Descripción breve de oNNA
/// </summary>
public class oNNA
{


    #region Constructor
    public oNNA()
    {
    }
    public oNNA(string cinstitucion, string cproyecto, Int32 codie, Int32 cnino, string rut, string nombres, string apepat, string apemat, string fingreso, string fnacimiento)
    {
        nNACodInstitucion = cinstitucion;
        nNACodProyecto = cproyecto;
        nNACodIE= codie;
        nNACodNino = cnino;
        nNARut = rut;
        nNANombres = nombres;
        nNAApePaterno = apepat;
        nNAApeMaterno = apemat;
        nNAFechaIngreso = fingreso;
        nNAFechaNacimiento = fnacimiento;
    }

    public oNNA(string cinstitucion, string cproyecto, Int32 codie, Int32 cnino, string rut, string nombres, string apepat, string apemat, string fingreso, string fnacimiento, string cua)
    {
        nNACodInstitucion = cinstitucion;
        nNACodProyecto = cproyecto;
        nNACodIE = codie;
        nNACodNino = cnino;
        nNARut = rut;
        nNANombres = nombres;
        nNAApePaterno = apepat;
        nNAApeMaterno = apemat;
        nNAFechaIngreso = fingreso;
        nNAFechaNacimiento = fnacimiento;
        nNACua = cua;
    }

    #endregion

    #region Miembros
    private string nNACodProyecto;
    private string nNACodInstitucion;
    private Int32 nNACodIE;
    private Int32 nNACodNino;
    private string nNARut;
    private string nNANombres;
    private string nNAApePaterno;
    private string nNAApeMaterno;
    private string nNAFechaIngreso;
    private string nNAFechaNacimiento;
    private string nNACua;
    #endregion

    #region Propiedades
    public string NNACodInstitucion
    {
        get
        {
            return nNACodInstitucion;
        }
        set
        {
            nNACodInstitucion = value;
        }
    }
    public string NNACodProyecto
    {
        get
        {
            return nNACodProyecto;
        }
        set
        {
            nNACodProyecto = value;
        }
    }
    public Int32 NNACodIE
    {
        get
        {
            return nNACodIE;
        }
        set
        {
            nNACodIE = value;
        }
    }
    public Int32 NNACodNino
    {
        get
        {
            return nNACodNino;
        }
        set
        {
            nNACodNino = value;
        }
    }
    public string NNARut
    {
        get
        {
            return nNARut;
        }
        set
        {
            nNARut = value;
        }
    }
    public string NNANombres
    {
        get
        {
            return nNANombres;
        }
        set
        {
            nNANombres = value;
        }
    }
    public string NNAApePaterno
    {
        get
        {
            return nNAApePaterno;
        }
        set
        {
            nNAApePaterno = value;
        }
    }
    public string NNAApeMaterno
    {
        get
        {
            return nNAApeMaterno;
        }
        set
        {
            nNAApeMaterno = value;
        }
    }
    public string NNAFechaIngreso
    {
        get
        {
            return nNAFechaIngreso;
        }
        set
        {
            nNAFechaIngreso = value;
        }
    }
    public string NNAFechaNacimiento
    {
        get
        {
            return nNAFechaNacimiento;
        }
        set
        {
            nNAFechaNacimiento = value;
        }
    }
    public string NNACua
    {
        get {
            return nNACua;
        }
        set
        {
            nNACua = value;
        }
    }

    #endregion
}
