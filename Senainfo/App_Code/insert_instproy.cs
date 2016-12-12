using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.Common;
////////using neocsharp.NeoDatabase;

/// <summary>
/// Descripción breve de insert_instproy
/// </summary>
public class insert_instproy
{
	public insert_instproy()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    public int Insert_Update_Inmueble(
int CodInstitucion, int ICodInmueble, int CodInmueble, int IdUsuarioActualizacion, int CodsituacionLegalInmueble,
int CodComuna, int TipoInmueble, String Nombre, String Direccion, String Telefono, String Fax, int CodigoPostal, 
int m2Construidos, int m2totales, int NumeroDormitorios, int CapacidadNinos, int NumeroBanos, int CantidadPisos, 
String AreasVerdes, String IndVigencia)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@CodInstitucion", SqlDbType.Int, 4, CodInstitucion) , 
		con.parametros("@ICodInmueble", SqlDbType.Int, 4, ICodInmueble) , 
		con.parametros("@CodInmueble", SqlDbType.Int, 4, CodInmueble) , 
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion) , 
		con.parametros("@CodsituacionLegalInmueble", SqlDbType.Int, 4, CodsituacionLegalInmueble) , 
		con.parametros("@CodComuna", SqlDbType.Int, 4, CodComuna) , 
		con.parametros("@TipoInmueble", SqlDbType.Int, 4, TipoInmueble) , 
		con.parametros("@Nombre", SqlDbType.VarChar, 100, Nombre) , 
		con.parametros("@Direccion", SqlDbType.VarChar, 100, Direccion) , 
		con.parametros("@Telefono", SqlDbType.VarChar, 30, Telefono) , 
		con.parametros("@Fax", SqlDbType.VarChar, 30, Fax) , 
		con.parametros("@CodigoPostal", SqlDbType.Int, 4, CodigoPostal) , 
		con.parametros("@m2Construidos", SqlDbType.Int, 4, m2Construidos) , 
		con.parametros("@m2totales", SqlDbType.Int, 4, m2totales) , 
		con.parametros("@NumeroDormitorios", SqlDbType.Int, 4, NumeroDormitorios) , 
		con.parametros("@CapacidadNinos", SqlDbType.Int, 4, CapacidadNinos) , 
		con.parametros("@NumeroBanos", SqlDbType.Int, 4, NumeroBanos) , 
		con.parametros("@CantidadPisos", SqlDbType.Int, 4, CantidadPisos) , 
		con.parametros("@AreasVerdes", SqlDbType.Char, 1, AreasVerdes) , 
		con.parametros("@IndVigencia", SqlDbType.Char, 1, IndVigencia)  
		//con.parametros("@FechaActualizacion", SqlDbType.DateTime, 16, FechaActualizacion) 
		};
        con.ejecutarProcedimiento("Insert_Update_Inmueble", parametros, out datareader);
        if (datareader.Read())
        {
            returnvalue = Convert.ToInt32(datareader["retorno"]);
        }
        con.Desconectar();
        return returnvalue;
    }

    public int Insert_Update_ProyectoInmueble(
    int CodProyecto, int ICodInmueble, DateTime FechaInicioVigencia, int IdUsuarioActualizacion, 
    DateTime FechaFinVigencia, String IndVigencia)
    {
        object objFechaTermino = DBNull.Value;
        if (FechaFinVigencia != Convert.ToDateTime("01-01-1900").Date)
        {
            objFechaTermino = FechaFinVigencia;
        };
        int returnvalue = 0;
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@CodProyecto", SqlDbType.Int, 4, CodProyecto) , 
		con.parametros("@ICodInmueble", SqlDbType.Int, 4, ICodInmueble) , 
		con.parametros("@FechaInicioVigencia", SqlDbType.DateTime, 16, FechaInicioVigencia) , 
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion) , 
		con.parametros("@FechaFinVigencia", SqlDbType.DateTime, 16, objFechaTermino) , 
		con.parametros("@IndVigencia", SqlDbType.Char, 1, IndVigencia)  
		
		};
        con.ejecutarProcedimiento("Insert_Update_ProyectoInmueble", parametros, out datareader);
        if (datareader.Read())
        {
           returnvalue = Convert.ToInt32(datareader["retorno"]);
        }
        con.Desconectar();
        return returnvalue;
        

    }
    public int Insert_Update_EventosProyecto( 
        int ICodEventosProyectos, int CodProyecto, int TipoEventos, DateTime FechaEvento, 
        int IdUsuarioActualizacion, int CodComuna, String Descripcion, int CantidadAsistentes, String IndVigencia,
        int CantAsistNinosAdolecentesFemenino, int CantAsistNinosAdolecentesMasculino, int CantAsistAdultoFemenino,
        int CantAsistAdultoMasculino/*DateTime FechaActualizacion*/) 
{
	DbDataReader datareader = null;
	/* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
	DbParameter[] parametros = {
		con.parametros("@ICodEventosProyectos", SqlDbType.Int, 4, ICodEventosProyectos) , 
		con.parametros("@CodProyecto", SqlDbType.Int, 4, CodProyecto) , 
		con.parametros("@TipoEventos", SqlDbType.Int, 2, TipoEventos) , 
		con.parametros("@FechaEvento", SqlDbType.DateTime, 16, FechaEvento) , 
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 2, IdUsuarioActualizacion) , 
		con.parametros("@CodComuna", SqlDbType.Int, 2, CodComuna) , 
		con.parametros("@Descripcion", SqlDbType.VarChar, 200, Descripcion) , 
		con.parametros("@CantidadAsistentes", SqlDbType.Int, 4, CantidadAsistentes) , 
		con.parametros("@IndVigencia", SqlDbType.Char, 1, IndVigencia),
		con.parametros("@CantAsistNinosAdolecentesFemenino", SqlDbType.Int, 4, CantAsistNinosAdolecentesFemenino) , 
		con.parametros("@CantAsistNinosAdolecentesMasculino", SqlDbType.Int, 4, CantAsistNinosAdolecentesMasculino) , 
		con.parametros("@CantAsistAdultoFemenino", SqlDbType.Int, 4, CantAsistAdultoFemenino) , 
		con.parametros("@CantAsistAdultoMasculino", SqlDbType.Int, 4, CantAsistAdultoMasculino) 
		};
         
	con.ejecutarProcedimiento("Insert_Update_EventosProyecto", parametros ,out datareader);

    int returnvalue = 0;
    if (datareader.Read())
    {
        returnvalue = Convert.ToInt32(datareader["identidad"]);
    }
	con.Desconectar();
    return returnvalue;
	
}
    //public int InsertUpdate_EventosProyectoTaller
    //{
         
    //}

    public int Insert_Update_EventosProyectoAsistencia_PPC( GridView dg, int ICodEventosProyectos)
    {
        int returnvalue = 0;
        int intPresente = 0;
        CheckBox chkPresente = new CheckBox();
        DbDataReader datareader = null;

        for (int i = 0; i < dg.Rows.Count; i++)
        {
            chkPresente = (CheckBox)dg.Rows[i].Cells[5].FindControl("chkPresente");
            if (chkPresente.Checked == true)
                intPresente = 1;
            else
                intPresente = 0;

		    //con.parametros("@ICodEventosProyectos", SqlDbType.Int, 4, Convert.ToInt32(dg.Rows[i].Cells[6].Text)) , 

            /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
            //if (intPresente == 1)
            //{
                DbParameter[] parametros = {
		    con.parametros("@ICodEventoProyectoAsistenciaNinos", SqlDbType.Int, 4, Convert.ToInt32(dg.Rows[i].Cells[0].Text)) , 
		    con.parametros("@ICodEventosProyectos", SqlDbType.Int, 4, ICodEventosProyectos) , 
		    con.parametros("@ICodIE", SqlDbType.Int, 4, Convert.ToInt32(dg.Rows[i].Cells[1].Text)) , 
		    con.parametros("@Presente", SqlDbType.Int, 4, intPresente)  
            };

                con.ejecutarProcedimiento("Insert_Update_EventosProyectoAsistencia_PPC", parametros, out datareader);
                if (datareader.Read())
                {
                    returnvalue = Convert.ToInt32(datareader["retorno"]);
                }
            //}
            con.Desconectar();
        }

        return returnvalue;
    }

    public int Insert_Update_Instituciones(
        int CodInstitucion, int TipoInstitucion, int codSistemaAdministrativo, int CodComuna, String RutInstitucion, 
        String Nombre, String NombreCorto, String Direccion, String Telefono, String Mail, String Fax, 
        int CodigoPostal, String RepresentanteLegal, String RutRepresentante, String PersonaContacto, 
        String FechaAniversario, String NombrePrimeraAutoridad, String CargoPrimeraAutoridad, String NumeroPersonalidadJuridica, 
        String ModoInstitucion, String DocumentoReconoce, DateTime FechaIngresoAlRegistro, String NumeroDocumento, 
        DateTime FechaDocumento, String IndVigencia, String Personeria, String RutInterventor,
        String NombreInterventor, int IdAdministrador, DateTime FechaActualizacion, int IdUsuarioActualizacion, String ObjetoSocial, int TipoReconocimiento, String Vigencia, int CodAreaEspecializacion, int Directorio, String MiembrosDirectorio, String Antecedentesfinancieros, String MarcoLegal, String ObjetoTransferencia, String TrabajosEncargados, String OrganismoContralor, String ResultadoEvaluacion, String CertificadoAntecedentes, String DatosConstitucion)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@CodInstitucion", SqlDbType.Int, 4, CodInstitucion) , 
		con.parametros("@TipoInstitucion", SqlDbType.Int, 4, TipoInstitucion) , 
		con.parametros("@codSistemaAdministrativo", SqlDbType.Int, 4, codSistemaAdministrativo) , 
		con.parametros("@CodComuna", SqlDbType.Int, 4, CodComuna) , 
		con.parametros("@RutInstitucion", SqlDbType.VarChar, 11, RutInstitucion) , 
		con.parametros("@Nombre", SqlDbType.VarChar, 100, Nombre) , 
		con.parametros("@NombreCorto", SqlDbType.VarChar, 50, NombreCorto) , 
		con.parametros("@Direccion", SqlDbType.VarChar, 100, Direccion) , 
		con.parametros("@Telefono", SqlDbType.VarChar, 30, Telefono) , 
		con.parametros("@Mail", SqlDbType.VarChar, 100, Mail) , 
		con.parametros("@Fax", SqlDbType.VarChar, 30, Fax) , 
		con.parametros("@CodigoPostal", SqlDbType.Int, 4, CodigoPostal) , 
		con.parametros("@RepresentanteLegal", SqlDbType.VarChar, 100, RepresentanteLegal) , 
		con.parametros("@RutRepresentante", SqlDbType.VarChar, 11, RutRepresentante) , 
		con.parametros("@PersonaContacto", SqlDbType.VarChar, 100, PersonaContacto) , 
		con.parametros("@FechaAniversario", SqlDbType.VarChar, 4, FechaAniversario) , 
		con.parametros("@NombrePrimeraAutoridad", SqlDbType.VarChar, 100, NombrePrimeraAutoridad) , 
		con.parametros("@CargoPrimeraAutoridad", SqlDbType.VarChar, 100, CargoPrimeraAutoridad) , 
		con.parametros("@NumeroPersonalidadJuridica", SqlDbType.VarChar, 200, NumeroPersonalidadJuridica) , 
		con.parametros("@ModoInstitucion", SqlDbType.Char, 1, ModoInstitucion) , 
		con.parametros("@DocumentoReconoce", SqlDbType.Char, 1, DocumentoReconoce) , 
		con.parametros("@FechaIngresoAlRegistro", SqlDbType.DateTime, 16, FechaIngresoAlRegistro) , 
		con.parametros("@NumeroDocumento", SqlDbType.VarChar, 200, NumeroDocumento) , 
		con.parametros("@FechaDocumento", SqlDbType.DateTime, 16, FechaDocumento) , 
		con.parametros("@IndVigencia", SqlDbType.Char, 1, IndVigencia) , 
		con.parametros("@Personeria", SqlDbType.VarChar, 200, Personeria) , 
		con.parametros("@RutInterventor", SqlDbType.VarChar, 11, RutInterventor) , 
		con.parametros("@NombreInterventor", SqlDbType.VarChar, 50, NombreInterventor) , 
		con.parametros("@IdAdministrador", SqlDbType.Int, 4, IdAdministrador) , 
        con.parametros("@FechaActualizacion",SqlDbType.DateTime,16,FechaActualizacion),
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion) , 
		con.parametros("@ObjetoSocial", SqlDbType.VarChar, 300, ObjetoSocial) , 
		con.parametros("@TipoReconocimiento", SqlDbType.Int, 4, TipoReconocimiento) , 
		con.parametros("@Vigencia", SqlDbType.VarChar, 200, Vigencia) , 
		con.parametros("@CodAreaEspecializacion", SqlDbType.Int, 4, CodAreaEspecializacion) , 
		con.parametros("@Directorio", SqlDbType.Int, 1, Directorio) , 
		con.parametros("@MiembrosDirectorio", SqlDbType.VarChar, 300, MiembrosDirectorio) , 
		con.parametros("@Antecedentesfinancieros", SqlDbType.VarChar, 300, Antecedentesfinancieros) , 
		con.parametros("@MarcoLegal", SqlDbType.VarChar, 300, MarcoLegal) , 
		con.parametros("@ObjetoTransferencia", SqlDbType.VarChar, 300, ObjetoTransferencia) , 
		con.parametros("@TrabajosEncargados", SqlDbType.VarChar, 300, TrabajosEncargados) , 
		con.parametros("@OrganismoContralor", SqlDbType.VarChar, 200, OrganismoContralor) , 
		con.parametros("@ResultadoEvaluacion", SqlDbType.VarChar, 300, ResultadoEvaluacion) , 
		con.parametros("@CertificadoAntecedentes", SqlDbType.VarChar, 200, CertificadoAntecedentes) , 
		con.parametros("@DatosConstitucion", SqlDbType.VarChar, 300, DatosConstitucion) 
		};
        con.ejecutarProcedimiento("Insert_Update_Instituciones", parametros, out datareader);
        if (datareader.Read())
        {
            returnvalue = Convert.ToInt32(datareader["retorno"]);
        }
        con.Desconectar();
        return returnvalue;
        

    }

    public int Insert_Update_Trabajadores(
    int ICodTrabajador, int CodInstitucion, int CodTrabajador, int CodProfesion, String Paterno, String Materno, 
    String Nombres, String RutTrabajador, String Telefono, String Mail, String Fax, int CodigoPostal, 
    String IndVigencia, int IdUsuarioActualizacion)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
        DbParameter[] parametros = {
		con.parametros("@ICodTrabajador", SqlDbType.Int, 4, ICodTrabajador) , 
		con.parametros("@CodInstitucion", SqlDbType.Int, 4, CodInstitucion) , 
		con.parametros("@CodTrabajador", SqlDbType.Int, 4, CodTrabajador) , 
		con.parametros("@CodProfesion", SqlDbType.Int, 4, CodProfesion) , 
		con.parametros("@Paterno", SqlDbType.VarChar, 50, Paterno) , 
		con.parametros("@Materno", SqlDbType.VarChar, 50, Materno) , 
		con.parametros("@Nombres", SqlDbType.VarChar, 50, Nombres) , 
		con.parametros("@RutTrabajador", SqlDbType.VarChar, 11, RutTrabajador) , 
		con.parametros("@Telefono", SqlDbType.VarChar, 30, Telefono) , 
		con.parametros("@Mail", SqlDbType.VarChar, 100, Mail) , 
		con.parametros("@Fax", SqlDbType.VarChar, 30, Fax) , 
		con.parametros("@CodigoPostal", SqlDbType.Int, 4, CodigoPostal) , 
		con.parametros("@IndVigencia", SqlDbType.Char, 1, IndVigencia) , 
		con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion) 
		};
        con.ejecutarProcedimiento("Insert_Update_Trabajadores", parametros, out datareader);
        if (datareader.Read())
        {
            
            returnvalue = Convert.ToInt32(datareader["identidad"]);
        }
        con.Desconectar();
        return returnvalue;
       

    }
    public int Insert_Update_TrabajadorProyecto(int ICodTrabajador, int CodProyecto, 
                DateTime FechaIngreso, int CodCargo, int TipoCargo, int CodProfesion, int CodCausalEgresoTrabajador, 
                String ResponsableIngreso, DateTime FechaEgreso, String ResponsableEgreso, DateTime FechaUltimoIngresoEgreso, 
                String IndVigencia, int IdUsuarioActualizacion)
    {
        int returnvalue = 0;
        DbDataReader datareader = null;
        /* Database db = new Database(objconn); */ Conexiones con = new Conexiones();
       

        object objFechaEgreso = DBNull.Value;
        if (FechaEgreso != Convert.ToDateTime("01-01-1900").Date)
        {
            objFechaEgreso = FechaEgreso;
        };
           
            DbParameter[] parametros = {
		    con.parametros("@ICodTrabajador", SqlDbType.Int, 4, ICodTrabajador) , 
		    con.parametros("@CodProyecto", SqlDbType.Int, 4, CodProyecto) , 
		    con.parametros("@FechaIngreso", SqlDbType.DateTime, 16, FechaIngreso) , 
		    con.parametros("@CodCargo", SqlDbType.Int, 4, CodCargo) , 
		    con.parametros("@TipoCargo", SqlDbType.Int, 4, TipoCargo) , 
		    con.parametros("@CodProfesion", SqlDbType.Int, 4, CodProfesion) , 
		    con.parametros("@CodCausalEgresoTrabajador", SqlDbType.Int, 4, CodCausalEgresoTrabajador) , 
		    con.parametros("@ResponsableIngreso", SqlDbType.VarChar, 50, ResponsableIngreso) , 
		    con.parametros("@FechaEgreso", SqlDbType.DateTime, 16, objFechaEgreso), 
		    con.parametros("@ResponsableEgreso", SqlDbType.VarChar, 50, ResponsableEgreso) , 
		    con.parametros("@FechaUltimoIngresoEgreso", SqlDbType.DateTime, 16, FechaUltimoIngresoEgreso) , 
		    con.parametros("@IndVigencia", SqlDbType.Char, 1, IndVigencia) , 
		    con.parametros("@IdUsuarioActualizacion", SqlDbType.Int, 4, IdUsuarioActualizacion) 
		    };
       
            
        con.ejecutarProcedimiento("Insert_Update_TrabajadorProyecto", parametros, out datareader);
        if (datareader.Read())
        {
            returnvalue = Convert.ToInt32(datareader["retorno"]);
        }
        con.Desconectar();
        return returnvalue;
        

    }

}
