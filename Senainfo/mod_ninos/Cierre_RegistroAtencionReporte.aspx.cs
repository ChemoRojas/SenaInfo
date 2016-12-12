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
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;

public partial class mod_ninos_Cierre_RegistroAtencionReporte : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    
        {
        if (!IsPostBack)
        {
            try
            {
                ArrayList al = new ArrayList();
                al = (ArrayList)Session["variables_impresion"];

                string vi_CodProyecto = Convert.ToString(al[0]);
                string vi_AnoMes = Convert.ToString(al[1]);
                string vi_IdUsr = Convert.ToString(al[2]);

                //if (Request.QueryString["CodProyecto"] != "" && Request.QueryString["AnoMes"] != "" && Request.QueryString["IdUsr"] != "")
                if (vi_CodProyecto != "" && vi_AnoMes != "" && vi_IdUsr != "")
                {
                    //DataTable dtVerAtencion = GetHeader(Convert.ToInt32(Request.QueryString["CodProyecto"]), Convert.ToInt32(Request.QueryString["AnoMes"]));
                    //DataTable sp_VerRegistroAtencion = GetHeader(Convert.ToInt32(Request.QueryString["CodProyecto"]), Convert.ToInt32(Request.QueryString["AnoMes"]));
                    DataTable sp_VerRegistroAtencion = GetHeader(Convert.ToInt32(vi_CodProyecto), Convert.ToInt32(vi_AnoMes));


                    DataSet dS = new DataSet();
                    //dS.Tables.Add(dtVerAtencion);
                    dS.Tables.Add(sp_VerRegistroAtencion);


                    //dS.Tables[0].TableName = "dtVerAtencion";
                    //dS.DataSetName = "dsVerAtencion";
                    dS.Tables[0].TableName = "sp_VerRegistroAtencion";
                    dS.DataSetName = "dsVerAtencion";

                    ReportDocument reportDocument = new ReportDocument();
                    ExportOptions crExportOptions = new ExportOptions();
                    DiskFileDestinationOptions crDiskFileDestinationOptions = new DiskFileDestinationOptions();

                    string rptPath = ConfigurationManager.AppSettings["PathReportes"].ToString(); //@"C:\Inetpub\wwwroot\ARGENTIS.SENAINFO\Reportes\";
                    DateTime Fecha = Convert.ToDateTime("01-" + vi_AnoMes.ToString().Substring(4, 2) + "-" + vi_AnoMes.ToString().Substring(0, 4));
                    reportDocument.Load(@rptPath + "crVerAtencion.rpt");
                    reportDocument.SetDataSource(dS);

                    rptPath = rptPath + "crVerAtencion.rpt" +
                            Session.SessionID.ToString() +
                            Convert.ToString(DateTime.Today.Year) +
                            Convert.ToString(DateTime.Today.Day) +
                            Convert.ToString(DateTime.Today.Month) +
                            Convert.ToString(DateTime.Now.Minute) +
                            Convert.ToString(DateTime.Now.Second) + ".pdf";

                    reportDocument.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                    reportDocument.DataDefinition.FormulaFields["cTitulo"].Text = "'Registro de Atención'";
                    reportDocument.DataDefinition.FormulaFields["cFiltros"].Text = "'Proyecto : " + sp_VerRegistroAtencion.Rows[0]["Proyecto"].ToString() + "/nPeriodo : " + Fecha.ToString("MMMM yyyy") + "'";

                    crDiskFileDestinationOptions.DiskFileName = rptPath;
                    crExportOptions = reportDocument.ExportOptions;

                    crExportOptions.DestinationOptions = crDiskFileDestinationOptions;
                    crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    crExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;

                    reportDocument.Export();
                    reportDocument.Close();
                    reportDocument.Dispose();

                    this.Response.ClearContent();
                    this.Response.ClearHeaders();
                    this.Response.ContentType = "application/pdf";
                    this.Response.WriteFile(rptPath);
                    this.Response.Flush();
                    this.Response.Close();

                    System.IO.File.Delete(rptPath);
                    
                    
                    
                }
            }
            catch
            { }
        }

    }
    private DataTable GetHeader(int CodProyecto, int AnoMes)
    {

        SqlConnection sconn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexiones"].ToString());
        System.Data.SqlClient.SqlCommand sqlc = new System.Data.SqlClient.SqlCommand();
        sqlc.Connection = sconn;
        sqlc.CommandType = System.Data.CommandType.StoredProcedure;
        sqlc.Parameters.Add("@codproyecto", SqlDbType.Int, 4).Value = CodProyecto;
        sqlc.Parameters.Add("@mesano", SqlDbType.Int, 4).Value = AnoMes;
        sqlc.CommandText = "sp_VerRegistroAtencion";

        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(sqlc);
        DataTable dt = new DataTable();
        sconn.Open();
        da.Fill(dt);
        sconn.Close();
        return dt;        
        #region Codigo antiguo
        //neocsharp.NeoDatabase.DbDataReader datareader = null;

        //neocsharp.NeoDatabase.Database db = new neocsharp.NeoDatabase.Database(objconn);
        //neocsharp.NeoDatabase.DbParameter[] parametros =
        //{
        //con.parametros("@codproyecto", neocsharp.NeoDatabase.SqlDbType.Int, 4, CodProyecto) ,
        //con.parametros("@mesano", neocsharp.NeoDatabase.SqlDbType.Int, 4, AnoMes)
        //};

        //con.ejecutarProcedimiento("sp_VerRegistroAtencion", parametros, out datareader);

        //DataTable dt = new DataTable();
        //DataRow dr;

        //dt.Columns.Add(new DataColumn("Nombres", typeof(string)));
        //dt.Columns.Add(new DataColumn("apellido_paterno", typeof(string)));
        //dt.Columns.Add(new DataColumn("apellido_materno", typeof(string)));
        //dt.Columns.Add(new DataColumn("ICodIE", typeof(int)));
        //dt.Columns.Add(new DataColumn("CodNino", typeof(int)));
        //dt.Columns.Add(new DataColumn("Sexo", typeof(string)));
        //dt.Columns.Add(new DataColumn("CodDiasAtencion", typeof(int)));
        //dt.Columns.Add(new DataColumn("D1", typeof(string)));
        //dt.Columns.Add(new DataColumn("D2", typeof(string)));
        //dt.Columns.Add(new DataColumn("D3", typeof(string)));
        //dt.Columns.Add(new DataColumn("D4", typeof(string)));
        //dt.Columns.Add(new DataColumn("D5", typeof(string)));
        //dt.Columns.Add(new DataColumn("D6", typeof(string)));
        //dt.Columns.Add(new DataColumn("D7", typeof(string)));
        //dt.Columns.Add(new DataColumn("D8", typeof(string)));
        //dt.Columns.Add(new DataColumn("D9", typeof(string)));
        //dt.Columns.Add(new DataColumn("D10", typeof(string)));
        //dt.Columns.Add(new DataColumn("D11", typeof(string)));
        //dt.Columns.Add(new DataColumn("D12", typeof(string)));
        //dt.Columns.Add(new DataColumn("D13", typeof(string)));
        //dt.Columns.Add(new DataColumn("D14", typeof(string)));
        //dt.Columns.Add(new DataColumn("D15", typeof(string)));
        //dt.Columns.Add(new DataColumn("D16", typeof(string)));
        //dt.Columns.Add(new DataColumn("D17", typeof(string)));
        //dt.Columns.Add(new DataColumn("D18", typeof(string)));
        //dt.Columns.Add(new DataColumn("D19", typeof(string)));
        //dt.Columns.Add(new DataColumn("D20", typeof(string)));
        //dt.Columns.Add(new DataColumn("D21", typeof(string)));
        //dt.Columns.Add(new DataColumn("D22", typeof(string)));
        //dt.Columns.Add(new DataColumn("D23", typeof(string)));
        //dt.Columns.Add(new DataColumn("D24", typeof(string)));
        //dt.Columns.Add(new DataColumn("D25", typeof(string)));
        //dt.Columns.Add(new DataColumn("D26", typeof(string)));
        //dt.Columns.Add(new DataColumn("D27", typeof(string)));
        //dt.Columns.Add(new DataColumn("D28", typeof(string)));
        //dt.Columns.Add(new DataColumn("D29", typeof(string)));
        //dt.Columns.Add(new DataColumn("D30", typeof(string)));
        //dt.Columns.Add(new DataColumn("D31", typeof(string)));
        //dt.Columns.Add(new DataColumn("DiasAtendido", typeof(int)));
        

        //while (datareader.Read())
        //{
        //    try
        //    {
        //        dr = dt.NewRow();
        //        dr[0] = (System.String)datareader["Nombres"];
        //        dr[1] = (System.String)datareader["apellido_paterno"];
        //        dr[2] = (System.String)datareader["apellido_materno"];
        //        dr[3] = (System.Int32)datareader["ICodIE"];
        //        dr[4] = (System.Int32)datareader["CodNino"];
        //        dr[5] = (System.String)datareader["Sexo"];
        //        dr[6] = (System.Int32)datareader["CodDiasAtencion"];
        //        dr[7] = (System.String)datareader["D1"];
        //        dr[8] = (System.String)datareader["D2"];
        //        dr[9] = (System.String)datareader["D3"];
        //        dr[10] = (System.String)datareader["D4"];
        //        dr[11] = (System.String)datareader["D5"];
        //        dr[12] = (System.String)datareader["D6"];
        //        dr[13] = (System.String)datareader["D7"];
        //        dr[14] = (System.String)datareader["D8"];
        //        dr[15] = (System.String)datareader["D9"];
        //        dr[16] = (System.String)datareader["D10"];
        //        dr[17] = (System.String)datareader["D11"];
        //        dr[18] = (System.String)datareader["D12"];
        //        dr[19] = (System.String)datareader["D13"];
        //        dr[20] = (System.String)datareader["D14"];
        //        dr[21] = (System.String)datareader["D15"];
        //        dr[22] = (System.String)datareader["D16"];
        //        dr[23] = (System.String)datareader["D17"];
        //        dr[24] = (System.String)datareader["D18"];
        //        dr[25] = (System.String)datareader["D19"];
        //        dr[26] = (System.String)datareader["D20"];
        //        dr[27] = (System.String)datareader["D21"];
        //        dr[28] = (System.String)datareader["D22"];
        //        dr[29] = (System.String)datareader["D23"];
        //        dr[30] = (System.String)datareader["D24"];
        //        dr[31] = (System.String)datareader["D25"];
        //        dr[32] = (System.String)datareader["D26"];
        //        dr[33] = (System.String)datareader["D27"];
        //        dr[34] = (System.String)datareader["D28"];
        //        dr[35] = (System.String)datareader["D29"];
        //        dr[36] = (System.String)datareader["D30"];
        //        dr[37] = (System.String)datareader["D31"];
        //        dr[38] = (System.Int32)datareader["DiasAtendido"];
               

        //        dt.Rows.Add(dr);
        //    }
        //    catch
        //    { }
        //}
        //con.Desconectar();
        //return dt;
        #endregion
    }
    
}
