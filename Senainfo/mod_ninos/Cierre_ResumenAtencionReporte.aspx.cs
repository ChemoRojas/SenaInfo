using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data.Common;
using System.Data.SqlClient;

public partial class mod_ninos_Cierre_ResumenAtencionReporte : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{

        ArrayList al = new ArrayList();
        al = (ArrayList)Session["variables_impresion"];

        string vi_CodProyecto = Convert.ToString(al[0]);
        string vi_AnoMes = Convert.ToString(al[1]);
        string vi_IdUsr = Convert.ToString(al[2]);

        //if (Request.QueryString["CodProyecto"] != "" && Request.QueryString["AnoMes"] != "" && Request.QueryString["IdUsr"] != "")
        if (vi_CodProyecto != "" && vi_AnoMes != "" && vi_IdUsr != "")
        {

            //DataTable dt = getImpresionResumen(Convert.ToInt32(Request.QueryString["CodProyecto"]), Convert.ToInt32(Request.QueryString["AnoMes"]));
            DataTable dt = getImpresionResumen(Convert.ToInt32(vi_CodProyecto), Convert.ToInt32(vi_AnoMes));

            //todo lo que esta comentado es por Karina vega

            //DataTable dtHeader = GetHeader(Convert.ToInt32(Request.QueryString["CodProyecto"]), Convert.ToInt32(Request.QueryString["AnoMes"]));
            // DataTable dtBody = GetBody(Convert.ToInt32(Request.QueryString["CodProyecto"]), Convert.ToInt32(Request.QueryString["AnoMes"]), Convert.ToInt32(Request.QueryString["IdUsr"]));


            // DataSet dS = new DataSet();
            // dS.Tables.Add(dtHeader);
            // dS.Tables.Add(dtBody);


            // dS.Tables[0].TableName = "dtHeader";
            //dS.Tables[1].TableName = "dtBody";
            //dS.DataSetName = "dsResumenAtencion";


            ExportOptions crExportOptions = new ExportOptions();
            DiskFileDestinationOptions crDiskFileDestinationOptions = new DiskFileDestinationOptions();
            ReportDocument reportDocument = new ReportDocument();

            ninocoll ncoll = new ninocoll();
            //int CodModeloIntervencion = (int)ncoll.callto_get_codmodelointervencion(Convert.ToInt32(Request.QueryString["CodProyecto"]));
            int CodModeloIntervencion = (int)ncoll.callto_get_codmodelointervencion(Convert.ToInt32(vi_CodProyecto));
            string rptName = "";

            if (CodModeloIntervencion == 83)
                rptName = "crResumenAtencionMensual_PAD.rpt";
            else
                if (CodModeloIntervencion == 128)
                    rptName = "crResumenAtencionMensual_PJC.rpt";
                else
                    rptName = "crResumenAtencionMensual.rpt";

            string rptPath = ConfigurationSettings.AppSettings["PathReportes"].ToString();//@"C:\Inetpub\wwwroot\ARGENTIS.SENAINFO\Reportes\";
            reportDocument.Load(@rptPath + rptName);

            //reportDocument.SetDataSource(dS);
            reportDocument.SetDataSource(dt);

            rptPath = rptPath + "crResumenAtencionMensual" +
                    Session.SessionID.ToString() +
                    Convert.ToString(DateTime.Today.Year) +
                    Convert.ToString(DateTime.Today.Day) +
                    Convert.ToString(DateTime.Today.Month) +
                    Convert.ToString(DateTime.Now.Minute) +
                    Convert.ToString(DateTime.Now.Second) + ".pdf";

            reportDocument.PrintOptions.PaperOrientation = PaperOrientation.Portrait;

            crDiskFileDestinationOptions.DiskFileName = rptPath;
            crExportOptions = reportDocument.ExportOptions;

            crExportOptions.DestinationOptions = crDiskFileDestinationOptions;
            crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            crExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;

            reportDocument.Export();
            reportDocument.Dispose();

            this.Response.ClearContent();
            this.Response.ClearHeaders();
            this.Response.ContentType = "application/pdf";
            this.Response.AddHeader("Content-Disposition", "inline;filename=ReporteCierreResumenAtencionMensual.pdf");
            this.Response.WriteFile(rptPath);
            this.Response.Flush();
            this.Response.Close();

            System.IO.File.Delete(rptPath);
            reportDocument.Dispose();
            reportDocument.Close();
        }
        // }

    }
    private DataTable GetHeader(int CodProyecto, int AnoMes)
    {
        /*
                neocsharp.NeoDatabase.DbDataReader datareader = null;
                neocsharp.NeoDatabase.Database db = new neocsharp.NeoDatabase.Database(objconn);
                neocsharp.NeoDatabase.DbParameter[] parametros =
                {
                con.parametros("@codproyecto", neocsharp.NeoDatabase.SqlDbType.Int, 4, CodProyecto) ,
                con.parametros("@mesano", neocsharp.NeoDatabase.SqlDbType.Int, 4, AnoMes)
                };
        */
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        DbParameter[] parametros =
        {
		con.parametros("@codproyecto", SqlDbType.Int, 4, CodProyecto) ,
		con.parametros("@mesano", SqlDbType.Int, 4, AnoMes)
		};

        con.ejecutarProcedimiento("cierre_cabeceraproyecto", parametros, out datareader);

        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("codproyecto", typeof(int)));
        dt.Columns.Add(new DataColumn("nombre", typeof(string)));
        dt.Columns.Add(new DataColumn("mes", typeof(string)));
        dt.Columns.Add(new DataColumn("ano", typeof(int)));
        dt.Columns.Add(new DataColumn("institucion", typeof(string)));
        dt.Columns.Add(new DataColumn("region", typeof(string)));
        dt.Columns.Add(new DataColumn("asistencial", typeof(string)));
        dt.Columns.Add(new DataColumn("modelo", typeof(string)));
        dt.Columns.Add(new DataColumn("pago", typeof(string)));
        dt.Columns.Add(new DataColumn("tipo", typeof(string)));
        dt.Columns.Add(new DataColumn("diasatencion", typeof(string)));
        dt.Columns.Add(new DataColumn("dias", typeof(int)));
        dt.Columns.Add(new DataColumn("cerrado", typeof(int)));
        dt.Columns.Add(new DataColumn("numeroplazas", typeof(int)));
        dt.Columns.Add(new DataColumn("sexo", typeof(string)));

        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (System.Int32)datareader["codproyecto"];
                dr[1] = (System.String)datareader["nombre"];
                dr[2] = (System.String)datareader["mes"];
                dr[3] = (System.Int32)datareader["ano"];
                dr[4] = (System.String)datareader["institucion"];
                dr[5] = (System.String)datareader["region"];
                dr[6] = (System.String)datareader["asistencial"];
                dr[7] = (System.String)datareader["modelo"];
                dr[8] = (System.String)datareader["pago"];
                dr[9] = (System.String)datareader["tipo"];
                dr[10] = (System.String)datareader["diasatencion"];
                dr[11] = (System.Int32)datareader["dias"];
                dr[12] = (System.Int32)datareader["cerrado"];
                dr[13] = (System.Int32)datareader["numeroplazas"];
                dr[14] = (System.String)datareader["sexo"];

                dt.Rows.Add(dr);
            }
            catch
            { }
        }
        con.Desconectar();
        return dt;
    }
    private DataTable GetBody(int CodProyecto, int AnoMes, int IdUsuarioActualizacion)
    {
        /*
                neocsharp.NeoDatabase.DbDataReader datareader = null;
                neocsharp.NeoDatabase.Database db = new neocsharp.NeoDatabase.Database(objconn);
                neocsharp.NeoDatabase.DbParameter[] parametros =
                {
                con.parametros("@codproyecto", neocsharp.NeoDatabase.SqlDbType.Int, 4, CodProyecto) ,
                con.parametros("@MesAno", neocsharp.NeoDatabase.SqlDbType.Int, 4, AnoMes) ,
                con.parametros("@id_usr", neocsharp.NeoDatabase.SqlDbType.Int, 4, IdUsuarioActualizacion)
                };
        */
        DbDataReader datareader = null;
        Conexiones con = new Conexiones();
        DbParameter[] parametros =
        {
		con.parametros("@codproyecto", SqlDbType.Int, 4, CodProyecto) ,
		con.parametros("@MesAno", SqlDbType.Int, 4, AnoMes) ,
        con.parametros("@id_usr", SqlDbType.Int, 4, IdUsuarioActualizacion)
		};

        con.ejecutarProcedimiento("cierre_resumenatencionmensual", parametros, out datareader);
        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add(new DataColumn("aviso", typeof(int)));
        dt.Columns.Add(new DataColumn("cerrado", typeof(int)));
        dt.Columns.Add(new DataColumn("NroNinosVigentesMesAnteriorF", typeof(int)));
        dt.Columns.Add(new DataColumn("NroNinosVigentesMesAnteriorM", typeof(int)));
        dt.Columns.Add(new DataColumn("NroIngresosMesF", typeof(int)));
        dt.Columns.Add(new DataColumn("NroIngresosMesM", typeof(int)));
        dt.Columns.Add(new DataColumn("NroEgresosMesF", typeof(int)));
        dt.Columns.Add(new DataColumn("NroEgresosMesM", typeof(int)));
        dt.Columns.Add(new DataColumn("TotalDiasF", typeof(int)));
        dt.Columns.Add(new DataColumn("TotalDiasM", typeof(int)));
        dt.Columns.Add(new DataColumn("TotalDiasInasistenciaF", typeof(int)));
        dt.Columns.Add(new DataColumn("TotalDiasInasistenciaM", typeof(int)));
        dt.Columns.Add(new DataColumn("TotalDiasAtendidosF", typeof(int)));
        dt.Columns.Add(new DataColumn("TotalDiasAtendidosM", typeof(int)));
        dt.Columns.Add(new DataColumn("IntervencionesExigidas", typeof(int)));
        dt.Columns.Add(new DataColumn("NroIntervencionesMasF", typeof(int)));
        dt.Columns.Add(new DataColumn("NroIntervencionesMasM", typeof(int)));
        dt.Columns.Add(new DataColumn("NroIntervencionesMenosF", typeof(int)));
        dt.Columns.Add(new DataColumn("NroIntervencionesMenosM", typeof(int)));
        dt.Columns.Add(new DataColumn("NroIntervencionesIgualF", typeof(int)));
        dt.Columns.Add(new DataColumn("NroIntervencionesIgualM", typeof(int)));
        dt.Columns.Add(new DataColumn("TotalIntervencionF", typeof(int)));
        dt.Columns.Add(new DataColumn("TotalIntervencionM", typeof(int)));
        dt.Columns.Add(new DataColumn("PromedioIntervencionF", typeof(double)));
        dt.Columns.Add(new DataColumn("PromedioIntervencionM", typeof(double)));
        dt.Columns.Add(new DataColumn("TotalDiasPagarIntervencionesF", typeof(int)));
        dt.Columns.Add(new DataColumn("TotalDiasPagarIntervencionesM", typeof(int)));
        dt.Columns.Add(new DataColumn("fechacierre", typeof(DateTime)));
        dt.Columns.Add(new DataColumn("pago", typeof(int)));
        // << DPL 25-09-2008 >>
        dt.Columns.Add(new DataColumn("TotalDiscapacidadGraveF", typeof(int)));
        dt.Columns.Add(new DataColumn("TotalDiscapacidadGraveM", typeof(int)));
        dt.Columns.Add(new DataColumn("TotalDiscapacidadOtrasF", typeof(int)));
        dt.Columns.Add(new DataColumn("TotalDiscapacidadOtrasM", typeof(int)));
        // << DPL 25-09-2008 >>


        while (datareader.Read())
        {
            try
            {
                dr = dt.NewRow();
                dr[0] = (System.Int32)datareader["aviso"];
                dr[1] = (System.Int32)datareader["cerrado"];
                dr[2] = (System.Int32)datareader["NroNinosVigentesMesAnteriorF"];
                dr[3] = (System.Int32)datareader["NroNinosVigentesMesAnteriorM"];
                dr[4] = (System.Int32)datareader["NroIngresosMesF"];
                dr[5] = (System.Int32)datareader["NroIngresosMesM"];
                dr[6] = (System.Int32)datareader["NroEgresosMesF"];
                dr[7] = (System.Int32)datareader["NroEgresosMesM"];
                dr[8] = (System.Int32)datareader["TotalDiasF"];
                dr[9] = (System.Int32)datareader["TotalDiasM"];
                dr[10] = (System.Int32)datareader["TotalDiasInasistenciaF"];
                dr[11] = (System.Int32)datareader["TotalDiasInasistenciaM"];
                dr[12] = (System.Int32)datareader["TotalDiasAtendidosF"];
                dr[13] = (System.Int32)datareader["TotalDiasAtendidosM"];
                dr[14] = (System.Int32)datareader["IntervencionesExigidas"];
                dr[15] = (System.Int32)datareader["NroIntervencionesMasF"];
                dr[16] = (System.Int32)datareader["NroIntervencionesMasM"];
                dr[17] = (System.Int32)datareader["NroIntervencionesMenosF"];
                dr[18] = (System.Int32)datareader["NroIntervencionesMenosM"];
                dr[19] = (System.Int32)datareader["NroIntervencionesIgualF"];
                dr[20] = (System.Int32)datareader["NroIntervencionesIgualM"];
                dr[21] = (System.Int32)datareader["TotalIntervencionF"];
                dr[22] = (System.Int32)datareader["TotalIntervencionM"];
                dr[23] = (System.Double)datareader["PromedioIntervencionF"];
                dr[24] = (System.Double)datareader["PromedioIntervencionM"];
                dr[25] = (System.Int32)datareader["TotalDiasPagarIntervencionesF"];
                dr[26] = (System.Int32)datareader["TotalDiasPagarIntervencionesM"];
                dr[27] = (System.DateTime)datareader["fechacierre"];
                dr[28] = (System.Int32)datareader["pago"];
                // << DPL 25-09-2008 >>
                dr[29] = (System.Int32)datareader["TotalDiscapacidadGraveF"];
                dr[30] = (System.Int32)datareader["TotalDiscapacidadGraveM"];
                dr[31] = (System.Int32)datareader["TotalDiscapacidadOtrasF"];
                dr[32] = (System.Int32)datareader["TotalDiscapacidadOtrasM"];
                // << DPL 25-09-2008 >>

                dt.Rows.Add(dr);
            }
            catch
            { }
        }
        con.Desconectar();
        return dt;
    }


    public DataTable getImpresionResumen(int CodProyecto, int MesAno)
    {
        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.CommandText = "cierre_resumenatencionmensual_Firma_impresion";


        sqlc.Parameters.Add("@CodProyecto", SqlDbType.Int, 4).Value = CodProyecto;
        sqlc.Parameters.Add("@MesAno", SqlDbType.Int, 4).Value = MesAno;

        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;
    }
}