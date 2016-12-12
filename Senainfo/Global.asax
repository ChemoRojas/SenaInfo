<%@ Application Language="C#" %>

<script runat="server">
    
   
   

    //public static neocsharp.NeoDatabase.objconnection globaconn;
    //void Application_Start(Object sender, EventArgs e) {
    //    // Code that runs on application startup
    //    neocsharp.NeoDatabase.objconnection neo_dbconnobj = new neocsharp.NeoDatabase.objconnection();
    //    neo_dbconnobj.Provider = System.Configuration.ConfigurationManager.AppSettings["provider"];
    //    neo_dbconnobj.Server = System.Configuration.ConfigurationManager.AppSettings["server"];
    //    neo_dbconnobj.User = System.Configuration.ConfigurationManager.AppSettings["user"];
    //    neo_dbconnobj.Password = System.Configuration.ConfigurationManager.AppSettings["password"];
    //    neo_dbconnobj.DatabaseName = System.Configuration.ConfigurationManager.AppSettings["dbname"];
    //    Application["NeoConnectionDefault"] = neo_dbconnobj;
    //    globaconn = neo_dbconnobj;
    //}
    
    void Application_End(Object sender, EventArgs e) {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(Object sender, EventArgs e) { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(Object sender, EventArgs e)
    {
        // Code that runs when a new session is started
        // Session["tokens"] = new ArrayList();
        Session["IdUsuario"] = 0;
        
    }

    void Session_End(Object sender, EventArgs e) {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

        window.logout();
        Response.Redirect("~/logout.aspx");
    }
       
</script>
  