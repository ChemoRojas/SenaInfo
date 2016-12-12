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
using System.Data.SqlClient;
////////using neocsharp.NeoDatabase;

using System.Collections.Generic;

/// <summary>
/// Descripción breve de adncolls
/// </summary>
public class adncolls
{
    public adncolls()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //

    } ///////////////////////////////michael///////////////////////////////////

    public DataTable GetMuestraADN(int CodProy, int sw)
    {

        DbDataReader datareader = null;
       
        
        Conexiones con = new Conexiones();
        if (sw==0)
        con.ejecutar(Resources.Procedures.GetNinoADN + CodProy, out datareader); 
        else
        con.ejecutar(Resources.Procedures.GetNinoADN_Todos + CodProy, out datareader); 

        DataTable dt = new DataTable();
        DataRow dr;
      
        dt.Columns.Add(new DataColumn("ICodIE", typeof(int))); //0
        dt.Columns.Add(new DataColumn("Nombres", typeof(String)));    //4
        dt.Columns.Add(new DataColumn("Apellido_paterno", typeof(String))); //5
        dt.Columns.Add(new DataColumn("Apellido_Materno", typeof(String))); //6   
        dt.Columns.Add(new DataColumn("FechaIngreso", typeof(DateTime)));  //8
        dt.Columns.Add(new DataColumn("MuestraNino", typeof(int)));  //8
        dt.Columns.Add(new DataColumn("CodNino", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaIngreso2", typeof(String)));
        dt.Columns.Add(new DataColumn("Consentimiento", typeof(int)));
        dt.Columns.Add(new DataColumn("Estado", typeof(String)));

        dt.Columns.Add(new DataColumn("Notificacion", typeof(int)));
        dt.Columns.Add(new DataColumn("FechaNotificacion", typeof(DateTime)));  //8
        dt.Columns.Add(new DataColumn("FechaCita", typeof(DateTime)));  //8
        dt.Columns.Add(new DataColumn("HoraCita", typeof(int)));  //8
        dt.Columns.Add(new DataColumn("MinutosCita", typeof(int)));  //8
        dt.Columns.Add(new DataColumn("CodProyecto", typeof(int)));  //8
        dt.Columns.Add(new DataColumn("SentenciaExpresa", typeof(String)));
       // dt.Columns.Add(new DataColumn("Consentimiento", typeof(int)));
       // dt.Columns.Add(new DataColumn("MEstado", typeof(String)));
        //string estado;
        string fecha = string.Empty;
        string estado = "";
     
        while (datareader.Read())
        {
           
            try
            {
                estado = "Sin Muestra ADN";
                dr = dt.NewRow();
                dr["CodProyecto"] = (int)datareader["CodProyecto"];
                dr[0] = (int)datareader["ICodIE"];
                dr[1] = (String)datareader["Nombres"];
                dr[2] = (String)datareader["Apellido_paterno"];
                dr[3] = (String)datareader["Apellido_Materno"];
                if ((DateTime)datareader["FechaIngreso"] != null)
                    fecha = ((DateTime)datareader["FechaIngreso"]).ToString("dd/MM/yyyy");
                
                dr[5] = (int)datareader["MuestraNino"];
                dr[6] = (int)datareader["CodNino"];
                dr[7] = fecha;

                try
                {
                    if ((int)datareader["Notificacion"] == 1) estado = "Notificado";
                    if ((int)datareader["Consentimiento"] == 2) estado = "Negado";
                    if ((int)datareader["Consentimiento"] == 3) estado = "No se Presenta";
                }
                catch
                {
                    estado = "Sin Muestra ADN";
                }

                dr[9] = estado;

                if (datareader["FechaNotificacion"].ToString() != "" && datareader["FechaNotificacion"].ToString().Substring(0, 10) != "01-01-1900")
                    dr[11] = ((DateTime)datareader["FechaNotificacion"]).ToString("dd/MM/yyyy");
                if (datareader["FechaCita"].ToString() != "" && datareader["FechaCita"].ToString().Substring(0, 10) != "01-01-1900")
                    dr[12] = ((DateTime)datareader["FechaCita"]).ToString("dd/MM/yyyy");
                if (datareader["HoraCita"].ToString() != "")
                    dr[13] = (int)datareader["HoraCita"];
                if (datareader["MinutosCita"].ToString() != "")
                    dr[14] = (int)datareader["MinutosCita"];

                if (datareader["SentenciaExpresa"].ToString() == "1")
                    dr[16] = "SI";
                else if (datareader["SentenciaExpresa"].ToString() == "0")
                    dr[16] = "NO";
                else
                    dr[16] = "";

                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        
        return dt;

    }
    public DataTable GetMuestraADNIECOD(int CodProy,int codnino)
    {


        DbDataReader datareader = null;
        Conexiones con = new Conexiones();

        //con.ejecutar(Resources.Procedures.GetNinoADN + CodProy, out datareader);
        con.ejecutar("SELECT CodNino,ICodIE, CodProyecto from ingresos_egresos where Codproyecto = '"+ CodProy +"' and CodNino ='"+ codnino +"'",  out datareader); 
        DataTable dtmIE = new DataTable();
        DataRow dr;

        dtmIE.Columns.Add(new DataColumn("ICodIE", typeof(int))); //0
        dtmIE.Columns.Add(new DataColumn("CodNIno", typeof(int))); //0
        

       
        while (datareader.Read())
        {
            try
            {
                dr = dtmIE.NewRow();
                dr[0] = (int)datareader["ICodIE"];
                dr[1] = (int)datareader["CodNino"];
                dtmIE.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dtmIE;

    }
 //////////////////////////////////////////////////////////////////

    public DataTable GetADNNinos(int ICodIE)
    {


        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetADNNinos + ICodIE, out datareader);
        DataTable dtn = new DataTable();
        DataRow dr;

        dtn.Columns.Add(new DataColumn("CodNino", typeof(int))); //0
        dtn.Columns.Add(new DataColumn("Nombres", typeof(String)));
        dtn.Columns.Add(new DataColumn("FechaIngreso", typeof(DateTime)));//4
        dtn.Columns.Add(new DataColumn("MuestraNino", typeof(int)));  //8
        while (datareader.Read())
        {
            try
            {
                dr = dtn.NewRow();
                dr[0] = (int)datareader["CodNino"];
                dr[1] = (String)datareader["Nombres"];
                dr[2] = (DateTime)datareader["FechaIngreso"];
                dr[3] = (int)datareader["MuestraNino"];
                dtn.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dtn;

    }

    public DataTable GetADNNotificacion(int ICodIE)
    {
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar("SELECT Notificacion, FechaNotificacion , FechaCita, HoraCita, MinutosCita from MuestraADN where ICodIE = '" + ICodIE + "'", out datareader);
        DataTable dtn = new DataTable();
        DataRow dr;

        dtn.Columns.Add(new DataColumn("Notificacion", typeof(int))); //0
        dtn.Columns.Add(new DataColumn("FechaNotificacion", typeof(DateTime)));//4
        dtn.Columns.Add(new DataColumn("FechaCita", typeof(DateTime)));//4
        dtn.Columns.Add(new DataColumn("HoraCita", typeof(int)));  //8
        dtn.Columns.Add(new DataColumn("MinutosCita", typeof(int)));  //8
        while (datareader.Read())
        {
            try
            {
                dr = dtn.NewRow();
                dr[0] = (int)datareader["Notificacion"];
                dr[1] = (DateTime)datareader["FechaNotificacion"];
                dr[2] = (DateTime)datareader["FechaCita"];
                dr[3] = (int)datareader["HoraCita"];
                dr[4] = (int)datareader["MinutosCita"];
                dtn.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dtn;

    }

    public DataTable GetADN(int CodNino)
    {


        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetADN + CodNino, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("CodNino", typeof(int))); //0
        dt.Columns.Add(new DataColumn("Nombres", typeof(String)));    
        dt.Columns.Add(new DataColumn("Apellido_Paterno", typeof(String)));
        dt.Columns.Add(new DataColumn("Apellido_Materno", typeof(String)));
        dt.Columns.Add(new DataColumn("MuestraADN", typeof(int)));  //8
        dt.Columns.Add(new DataColumn("Rut", typeof(String)));
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (int)datareader["CodNino"];
                dr[1] = (String)datareader["Nombres"];
                dr[2] = (String)datareader["Apellido_Paterno"];
                dr[3] = (String)datareader["Apellido_Materno"];
                dr[4] = (int)datareader["MuestraADN"];
                dr[5] = (String)datareader["Rut"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;

    }
    public DataTable GetTipoTribunalADN(int CodRegion)
    {

        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetTipoTribunalADN + CodRegion, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("Descripcion", typeof(String))); //0
        dt.Columns.Add(new DataColumn("TipoTribunal", typeof(int)));
        dt.Columns.Add(new DataColumn("CodRegion", typeof(int)));
     
        
   
        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (String)datareader["Descripcion"];
                dr[1] = (int)datareader["TipoTribunal"];
                dr[2] = (int)datareader["CodRegion"];
                dt.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt;

    }

    //public DataTable GetTipoTribunalADN(int tipotribunal)
    //{

    //    DbDataReader datareader = null;
    //    Conexiones con = new Conexiones();
    //    con.ejecutar(Resources.Procedures.GetTipoTribunalADN + tipotribunal, out datareader);
    //    DataTable dt = new DataTable();
    //    DataRow dr;

    //    dt.Columns.Add(new DataColumn("Descripcion", typeof(int))); //0
  
    //    while (datareader.Read())
    //    {
    //        try
    //        {
    //            dr = dt.NewRow();
    //            dr[0] = (int)datareader["Descripcion"];
    //            dt.Rows.Add(dr);
    //        }
    //        catch { }
    //    }
    //    con.Desconectar();
    //    return dt;

    //}

    public DataTable GetTipoTribunalADN2(int CodRegion, int Tribunal)
    {

        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        //con.ejecutar("select CodTribunal, Descripcion from partribunales where Tipotribunal = '" + Tipotribunal + "  'And Codregion ='" + Codregion + "'", out datareader);
        con.ejecutar("SELECT t1.tipotribunal, t1.codregion, t2.descripcion, t1.codtribunal, t2.tipotribunal, t2.descripcion from partribunales t1 inner join partipotribunal t2 on t2.tipotribunal =  t1.tipotribunal  where  codtribunal ='" + Tribunal + "  ' and codregion = '" + CodRegion + "'", out datareader); 
       
        DataTable dt2 = new DataTable();
        DataRow dr;

        dt2.Columns.Add(new DataColumn("Descripcion", typeof(String))); //0
        dt2.Columns.Add(new DataColumn("CodTribunal", typeof(int)));
        dt2.Columns.Add(new DataColumn("CodRegion", typeof(int)));



        while (datareader.Read())
        {
            try
            {
                dr = dt2.NewRow();
                dr[0] = (String)datareader["Descripcion"];
                dr[1] = (int)datareader["CodTribunal"];
                dr[2] = (int)datareader["CodRegion"];
                dt2.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt2;

    }

    public DataTable GetTraeCodTribunal(string Tribunal)
    {
        List<DbParameter> listDbParameter = new List<DbParameter>();

        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        //con.ejecutar("select CodTribunal, Descripcion from partribunales where Tipotribunal = '" + Tipotribunal + "  'And Codregion ='" + Codregion + "'", out datareader);

        string sql = "SELECT codregion, descripcion, codtribunal from partribunales where descripcion =@pDescripcion";

        listDbParameter.Add(con.parametros("@pDescripcion", SqlDbType.VarChar, 100, Tribunal));

        con.ejecutar(sql, listDbParameter, out datareader);

        

        DataTable dt2 = new DataTable();
        DataRow dr;

        dt2.Columns.Add(new DataColumn("Descripcion", typeof(String))); //0
        dt2.Columns.Add(new DataColumn("CodTribunal", typeof(int)));
        dt2.Columns.Add(new DataColumn("CodRegion", typeof(int)));



        while (datareader.Read())
        {
            try
            {
                dr = dt2.NewRow();
                dr[0] = (String)datareader["Descripcion"];
                dr[1] = (int)datareader["CodTribunal"];
                dr[2] = (int)datareader["CodRegion"];
                dt2.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dt2;

    }

    public DataTable GetTraeFdesde(int CodNino, int Codp)
    {

        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        
        con.ejecutar("Select FechaIngreso From Ingresos_Egresos where CodNino ='" + CodNino+"' and CodProyecto="+Codp, out datareader);

        DataTable dtfecha = new DataTable();
        DataRow dr;

        dtfecha.Columns.Add(new DataColumn("FechaIngreso", typeof(DateTime))); //0

        while (datareader.Read())
        {
            try
            {
                dr = dtfecha.NewRow();
                dr[0] = (DateTime)datareader["FechaIngreso"];
                dtfecha.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dtfecha;
    }



    public DataTable GetTraeFIngreso(int Icodie)
    {

        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        
        con.ejecutar("Select FechaIngreso From Ingresos_Egresos where Icodie =" + Icodie , out datareader);

        DataTable dtfecha = new DataTable();
        DataRow dr;

        dtfecha.Columns.Add(new DataColumn("FechaIngreso", typeof(DateTime))); //0

        while (datareader.Read())
        {
            try
            {
                dr = dtfecha.NewRow();
                dr[0] = (DateTime)datareader["FechaIngreso"];
                dtfecha.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dtfecha;
    }




    public DataTable GetTraeCodTrabajador(int userid)
    {

        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        //con.ejecutar("select CodTribunal, Descripcion from partribunales where Tipotribunal = '" + Tipotribunal + "  'And Codregion ='" + Codregion + "'", out datareader);
        con.ejecutar("Select ICodTrabajador From Usuarios where  IdUsuario =" + userid, out datareader);

        DataTable dtuser = new DataTable();
        DataRow dr;

        dtuser.Columns.Add(new DataColumn("ICodTrabajador", typeof(int))); //0

        while (datareader.Read())
        {
            try
            {
                dr = dtuser.NewRow();
                dr[0] = (int)datareader["ICodTrabajador"];
                dtuser.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dtuser;
    }

    public DataTable GetTraeDatosTrabajador(int idtrabajador)
    {

        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        //con.ejecutar("select CodTribunal, Descripcion from partribunales where Tipotribunal = '" + Tipotribunal + "  'And Codregion ='" + Codregion + "'", out datareader);
        con.ejecutar("Select Nombres, RutTrabajador, Paterno, Materno From Trabajadores where  ICodTrabajador =" + idtrabajador, out datareader);

        DataTable dtuser2 = new DataTable();
        DataRow dr;

        dtuser2.Columns.Add(new DataColumn("Nombres", typeof(String))); //0
        dtuser2.Columns.Add(new DataColumn("Paterno", typeof(String))); //0
        dtuser2.Columns.Add(new DataColumn("Materno", typeof(String))); //0
        dtuser2.Columns.Add(new DataColumn("RutTrabajador", typeof(String))); //0
        while (datareader.Read())
        {
            try
            {
                dr = dtuser2.NewRow();
                dr[0] = (String)datareader["Nombres"];
                dr[1] = (String)datareader["Paterno"];
                dr[2] = (String)datareader["Materno"];
                dr[3] = (String)datareader["RutTrabajador"];
                dtuser2.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dtuser2;
    }


    public DataTable GetTraeCodCargo(int idtrabajador)
    {

        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        //con.ejecutar("select CodTribunal, Descripcion from partribunales where Tipotribunal = '" + Tipotribunal + "  'And Codregion ='" + Codregion + "'", out datareader);
        con.ejecutar("Select CodCargo From TrabajadorProyecto where ICodTrabajador =" + idtrabajador, out datareader);

        DataTable dtuser3 = new DataTable();
        DataRow dr;

        dtuser3.Columns.Add(new DataColumn("CodCargo", typeof(int))); //0

        if (datareader.Read())
        {

            while (datareader.Read())
            {
                try
                {
                    dr = dtuser3.NewRow();
                    dr[0] = (int)datareader["CodCargo"];
                    dtuser3.Rows.Add(dr);
                }
                catch
                {
                    dr = dtuser3.NewRow();
                    dr[0] = 57;
                    dtuser3.Rows.Add(dr);
                }
            }
            

        }
        else
        {
            dr = dtuser3.NewRow();
            dr[0] = 57;
            dtuser3.Rows.Add(dr);
        }

        /* JLBL: 20150120*/
        //if (datareader.Reader.Depth == 0x00000000)
        //{
        //    dr = dtuser3.NewRow();
        //    dr[0] = 57;
        //    dtuser3.Rows.Add(dr);
        //}

        con.Desconectar();
        return dtuser3;
    }


    public DataTable GetTraeCargo(int codcargo)
    {

        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        //con.ejecutar("select CodTribunal, Descripcion from partribunales where Tipotribunal = '" + Tipotribunal + "  'And Codregion ='" + Codregion + "'", out datareader);
        con.ejecutar("Select Descripcion From ParCargos where CodCargo =" + codcargo, out datareader);

        DataTable dtuser4 = new DataTable();
        DataRow dr;

        dtuser4.Columns.Add(new DataColumn("Descripcion", typeof(String))); //0

        while (datareader.Read())
        {
            try
            {
                dr = dtuser4.NewRow();
                dr[0] = (String)datareader["Descripcion"];
                dtuser4.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dtuser4;
    }

   // public DataTable callto_update_diagnosticosdiscapacidad_2f(int icoddiscapacidad, int icodie, int tipodiscapacidad, DateTime fechadiagnostico, string observacion, int codniveldiscapacidad, int icodtrabajador, int codinstitucion, int codtrabajador, string indvigencia, DateTime fechaactualizacion, int idusuarioactualizacion, DateTime fechainscripcion, int InscritoFonadis)
    public DataTable Update_ADN(int ICodIE, int Consentimiento, DateTime FechaConsentimiento, int MuestraADN, int MuestraDactilar, 
        DateTime FechaMuestra, string NUE, int CodTribunal, 
        DateTime FechaOrdenTribunal, string IdOrdenTribunal, int IdUsuarioActualizacion, 
        DateTime FechaActualizacion, int Notificacion, DateTime FechaNotificacion, DateTime FechaCita, int HoraCita, int MinutosCita, int SentenciaExpresa)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Update_ADN";  /////ME FALTA CREAR EL PROCEDIMIENTO ALMACENADO 
        sqlc.Parameters.Add("@ICodIE", SqlDbType.Int, 4).Value = ICodIE;
        sqlc.Parameters.Add("@Consentimiento", SqlDbType.Int, 4).Value = Consentimiento;
        sqlc.Parameters.Add("@FechaConsentimiento", SqlDbType.DateTime, 8).Value = FechaConsentimiento;
        sqlc.Parameters.Add("@MuestraADN", SqlDbType.Int, 4).Value = MuestraADN;
        sqlc.Parameters.Add("@MuestraDactilar", SqlDbType.Int, 4).Value = MuestraDactilar;
        sqlc.Parameters.Add("@FechaMuestra", SqlDbType.DateTime, 8).Value = FechaMuestra;
        sqlc.Parameters.Add("@NUE", SqlDbType.VarChar, 20).Value = NUE;
        sqlc.Parameters.Add("@CodTribunal", SqlDbType.Int, 4).Value = CodTribunal;
        sqlc.Parameters.Add("@FechaOrdenTribunal", SqlDbType.DateTime, 8).Value = FechaOrdenTribunal;
        sqlc.Parameters.Add("@IdOrdenTribunal", SqlDbType.VarChar, 20).Value = IdOrdenTribunal;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = IdUsuarioActualizacion;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 8).Value = FechaActualizacion;

        sqlc.Parameters.Add("@Notificacion", SqlDbType.Int, 4).Value = Notificacion;
        sqlc.Parameters.Add("@FechaNotificacion", SqlDbType.DateTime, 8).Value = FechaNotificacion;
        sqlc.Parameters.Add("@FechaCita", SqlDbType.DateTime, 8).Value = FechaCita;
        sqlc.Parameters.Add("@HoraCita", SqlDbType.Int, 4).Value = HoraCita;
        sqlc.Parameters.Add("@MinutosCita", SqlDbType.Int, 4).Value = MinutosCita;
        sqlc.Parameters.Add("@SentenciaExpresa", SqlDbType.Int, 4).Value = SentenciaExpresa;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable GetTraeICodIE(int CodNino)
    {

        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        //con.ejecutar("select CodTribunal, Descripcion from partribunales where Tipotribunal = '" + Tipotribunal + "  'And Codregion ='" + Codregion + "'", out datareader);
        con.ejecutar("Select ICodIE From Ingresos_Egresos where  CodNino =" + CodNino, out datareader);

        DataTable dtIE = new DataTable();
        DataRow dr;

        dtIE.Columns.Add(new DataColumn("ICodIE", typeof(int))); //0

        while (datareader.Read())
        {
            try
            {
                dr = dtIE.NewRow();
                dr[0] = (int)datareader["ICodIE"];
                dtIE.Rows.Add(dr);
            }
            catch { }
        }
        con.Desconectar();
        return dtIE;
    }


    public DataTable GetNinoMUESTRA(int CodIE)
    {

        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        //con.ejecutar("select CodTribunal, Descripcion from partribunales where Tipotribunal = '" + Tipotribunal + "  'And Codregion ='" + Codregion + "'", out datareader);
        con.ejecutar("Select ICodIE From MuestraADN where  ICodIE =" + CodIE, out datareader);

        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("ICodIE", typeof(int))); //0
        if (datareader.Read())
        {
            //while (datareader.Read())
            //{
            //    try
            //    {
                    dr = dt.NewRow();
                    dr[0] = (int)datareader["ICodIE"];
                    dt.Rows.Add(dr);
                //}
                //catch { }
            //}
        }
        else
        {
            dr = dt.NewRow();
            dr[0] = 0;
            dt.Rows.Add(dr);
        
        
        }
        con.Desconectar();
        return dt;
    }


    public DataTable Insert_ADN(int ICodIE, int Consentimiento, DateTime FechaConsentimiento, int MuestraADN, int MuestraDactilar, DateTime FechaMuestra, 
        string NUE, int CodTribunal, DateTime FechaOrdenTribunal, string IdOrdenTribunal, int IdUsuarioActualizacion, DateTime FechaActualizacion,
        DateTime FechaCita, int HoraCita, int MinutosCita, int SentenciaExpresa)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Insert_ADN";  /////PROCEDIMIENTO QUE INSERTA
        sqlc.Parameters.Add("@cod", SqlDbType.Int, 4).Value = ICodIE;
        sqlc.Parameters.Add("@Consentimiento", SqlDbType.Int, 4).Value = Consentimiento;
        sqlc.Parameters.Add("@FechaConsentimiento", SqlDbType.DateTime, 8).Value = FechaConsentimiento;
        sqlc.Parameters.Add("@MuestraADN", SqlDbType.Int, 4).Value = MuestraADN;
        sqlc.Parameters.Add("@MuestraDactilar", SqlDbType.Int, 4).Value = MuestraDactilar;
        sqlc.Parameters.Add("@FechaMuestra", SqlDbType.DateTime, 8).Value = FechaMuestra;
        sqlc.Parameters.Add("@NUE", SqlDbType.VarChar, 20).Value = NUE;
        sqlc.Parameters.Add("@CodTribunal", SqlDbType.Int, 4).Value = CodTribunal;
        sqlc.Parameters.Add("@FechaOrdenTribunal", SqlDbType.DateTime, 8).Value = FechaOrdenTribunal;
        sqlc.Parameters.Add("@IdOrdenTribunal", SqlDbType.VarChar, 20).Value = IdOrdenTribunal;
        sqlc.Parameters.Add("@IdUsuarioActualizacion", SqlDbType.Int, 4).Value = IdUsuarioActualizacion;
        sqlc.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime, 8).Value = FechaActualizacion;
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        sqlc.Parameters.Add("@SentenciaExpresa", SqlDbType.Int, 4).Value = SentenciaExpresa;
        sqlc.Parameters.Add("@FechaCita", SqlDbType.DateTime, 8).Value = FechaCita;
        sqlc.Parameters.Add("@HoraCita", SqlDbType.Int, 4).Value = HoraCita;
        sqlc.Parameters.Add("@MinutoCita", SqlDbType.Int, 4).Value = MinutosCita;
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }

    public DataTable Update_NinosADN(int CodNino, int MuestraADN)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "Update_NinosADN";  /////ME FALTA CREAR EL PROCEDIMIENTO ALMACENADO 
        sqlc.Parameters.Add("@CodNino", SqlDbType.Int, 4).Value = CodNino;
        sqlc.Parameters.Add("@MuestraADN", SqlDbType.Int, 4).Value = MuestraADN;   
        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }


    public DataTable GetADNSI(int CodProy)
    {


        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        con.ejecutar(Resources.Procedures.GetADNCON2 + CodProy, out datareader);
        DataTable dt2 = new DataTable();
        
        DataRow dr;
        
        dt2.Columns.Add(new DataColumn("CodProyecto", typeof(int))); //0
        dt2.Columns.Add(new DataColumn("ICodIE", typeof(int))); //0
        dt2.Columns.Add(new DataColumn("Nombres", typeof(String)));
        dt2.Columns.Add(new DataColumn("Apellido_paterno", typeof(String))); //5//4
       
        dt2.Columns.Add(new DataColumn("Apellido_Materno", typeof(String))); //6   
        dt2.Columns.Add(new DataColumn("NUE", typeof(String)));
        dt2.Columns.Add(new DataColumn("MuestraDactilar", typeof(int)));
        dt2.Columns.Add(new DataColumn("MuestraADN", typeof(int)));
        dt2.Columns.Add(new DataColumn("FechaMuestra", typeof(DateTime)));


        dt2.Columns.Add(new DataColumn("FechaIngreso", typeof(DateTime)));  //8 
        dt2.Columns.Add(new DataColumn("Descripcion", typeof(String)));
        dt2.Columns.Add(new DataColumn("encargado", typeof(String)));
        dt2.Columns.Add(new DataColumn("ADN", typeof(String)));
        dt2.Columns.Add(new DataColumn("DACTILAR", typeof(String)));
        dt2.Columns.Add(new DataColumn("FechaMuestra2", typeof(String)));
        dt2.Columns.Add(new DataColumn("FechaIngreso2", typeof(String)));

        dt2.Columns.Add(new DataColumn("Notificacion", typeof(String)));
        dt2.Columns.Add(new DataColumn("FechaNotificacion", typeof(String)));  //8 
        dt2.Columns.Add(new DataColumn("FechaCita", typeof(String)));  //8 
        dt2.Columns.Add(new DataColumn("HoraCita", typeof(String)));

        string fecha = string.Empty;
        string fecha2 = string.Empty;
        string st1;
        string st2;
        while (datareader.Read())
        {
            try
            {

                dr = dt2.NewRow();
               
                dr[0] = (int)datareader["CodProyecto"];
                dr[1] = (int)datareader["ICodIE"];
                dr[2] = (String)datareader["Nombres"];
                dr[3] = (String)datareader["Apellido_paterno"];
                dr[4] = (String)datareader["Apellido_Materno"];
                dr[5] = (String)datareader["NUE"];
                if ((int)datareader["MuestraDactilar"] == 1)
                    st1 = "Si";
                else
                    st1 = "No";

                if ((int)datareader["MuestraADN"] == 1)
                    st2 = "Si";
                else
                    st2 = "No";
                
                if ((DateTime)datareader["FechaMuestra"] != null)
                    fecha2 = ((DateTime)datareader["FechaMuestra"]).ToString("dd/MM/yyyy");

                if ((DateTime)datareader["FechaIngreso"] != null)
                    fecha = ((DateTime)datareader["FechaIngreso"]).ToString("dd/MM/yyyy");
                
                dr[10] = (String)datareader["Descripcion"];
                dr[11] = (String)datareader["encargado"];
                dr[12] = st2;
                dr[13] = st1;
                dr[14] = fecha2;
                dr[15] = fecha;


                if (datareader["Notificacion"].ToString() == "1")
                    dr[16] = "SI";
                else
                    dr[16] = "NO";

                //                dr[16] = (String)datareader["Notificacion"].ToString();

                if (((DateTime)datareader["FechaNotificacion"]).ToString("dd/MM/yyyy") != "01-01-1900")
                    dr[17] = ((DateTime)datareader["FechaNotificacion"]).ToString("dd/MM/yyyy");
                else
                    dr[17] = "";

                if (((DateTime)datareader["FechaCita"]).ToString("dd/MM/yyyy") != "01-01-1900")
                    dr[18] = ((DateTime)datareader["FechaCita"]).ToString("dd/MM/yyyy");
                else
                    dr[18] = "";

                if ((Int32)datareader["HoraCita"] + (Int32)datareader["MinutosCita"] > 0)
                    dr[19] = (String)datareader["HoraCita"].ToString() + ":" + (String)datareader["MinutosCita"].ToString();
                else
                    dr[19] = "";

                dt2.Rows.Add(dr);
            }
            catch { }
        }
       
        con.Desconectar();
        return dt2;
       

    }



}
