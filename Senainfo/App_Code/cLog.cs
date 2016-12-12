using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;

/// <summary>
/// Descripción breve de cLog
/// </summary>
public class cLog
{
    /// <summary>
    /// Clase que hace el log en un .txt
    /// </summary>
    /// 

    private string _rutaLog;

    public string RutaLog
    {
        get { return _rutaLog; }
        set { _rutaLog = value; }
    }

    private string _userID;

    public string UserID
    {
        get { return _userID; }
        set { _userID = value; }
    }
    private string _ip;

    public string Ip
    {
        get { return _ip; }
        set { _ip = value; }
    }
    private string _browser;

    public string Browser
    {
        get { return _browser; }
        set { _browser = value; }
    }


	public cLog(System.Web.UI.Page pagina, string _userID) //pide la pagina donde sera usado y el userID
	{
        //leo carpeta de logs
        this.RutaLog = System.Configuration.ConfigurationManager.AppSettings["RutaLogs"];

        CrearFolderLogs();//valida o crea ruta log

        string ips = "";
        NetworkInterface[] ni = NetworkInterface.GetAllNetworkInterfaces();
        HttpBrowserCapabilities bc = pagina.Request.Browser;
        int count = 0;
        foreach (NetworkInterface n in ni)
        {
            if (count == 1)
            {

                if (n.GetIPProperties().UnicastAddresses.Count == 1)
                {
                    ips = n.GetIPProperties().UnicastAddresses[count - 1].Address.ToString();
                }
                else
                {
                    ips = n.GetIPProperties().UnicastAddresses[count].Address.ToString();
                }
            }
            count++;
        }

        this.UserID = _userID;
        this.Ip = ips;
        this.Browser = bc.Browser;
	}

    public void CrearLog(string messageExeption)//RPA
    {
        System.IO.StreamWriter Tex = System.IO.File.AppendText(this.RutaLog + "Log_" + this.UserID + "_" + DateTime.Now.ToString("ddMMyyyy hhmmss") + ".txt");
        Tex.WriteLine("Hora: " + DateTime.Now.ToString("ddMMyyyy hh:mm:ss") + " Mensage: " + messageExeption + " UserID: " + this.UserID + " IP: " + this.Ip + " Brower: " + this.Browser);
        Tex.Close();
    }


    private void CrearFolderLogs()
    { 
        //si el folder no existe se debe crear
        if (System.IO.Directory.Exists(this.RutaLog) == false)
            System.IO.Directory.CreateDirectory(this.RutaLog);
    }

}