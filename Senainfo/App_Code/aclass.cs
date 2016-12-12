using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Text;
using System.Security.Cryptography;

using System.Collections.Generic;

/// <summary>
/// Summary description for Intitucion
/// </summary>
public class window
{
    #region window.close
    public static void close(Page p)
    {
        p.ClientScript.RegisterClientScriptBlock(typeof(string), "SENAINFO", "<script  languaje=javascript> window.close(); </script>");

    }
    #endregion

   
    #region window.open

    //Felipe Ormazabal
    public static void open(Page p, string surl, string wname, int wname2, bool menubar, bool resizable, int width, int height, bool location, bool status, bool scrollbars)
    {
        string features = "menubar=" + menubar.ToString() + ", resizable=" + resizable.ToString() + ", width=" + width.ToString() + ", height=" + height.ToString() + ", location=" + location.ToString() + ", status=" + status.ToString() + ", scrollbars=" + scrollbars.ToString();
        string script = "<script  languaje=javascript> window.open('" + surl + "','" + wname + "','" + features + "'); </script>";
        p.ClientScript.RegisterClientScriptBlock(typeof(string), "SENAINFO", script);

    }

    public static void open(Page p, string surl, string wname,  bool menubar, bool resizable, int width, int height, bool location, bool status, bool scrollbars)
    {

        string features = "menubar="+ Convert.ToInt32(menubar).ToString() + ", resizable=" + Convert.ToInt32(resizable).ToString() + ", width=" + width.ToString() +", height=" + height.ToString() + ", location=" + Convert.ToInt32(location).ToString() + ", status=" + Convert.ToInt32(status).ToString() + ", scrollbars=" + Convert.ToInt32(scrollbars).ToString();
        string script = "<script  languaje=javascript> window.open('" + surl + "','" + wname + "','" + features + "'); </script>";
        p.ClientScript.RegisterClientScriptBlock(typeof(string), "SENAINFO", script);
        
    }

    public static void open(Page p, string surl, string wname, bool resizable, int width, int height, bool location, bool status, bool scrollbars)
    {
        bool menubar = false;
        open(p, surl, wname, menubar, resizable, width, height, location, status, scrollbars) ;
    }
    public static void open(Page p, string surl, string wname, int width, int height, bool location, bool status, bool scrollbars)
    {
        bool menubar = false;
        bool resizable = false;
        open(p, surl, wname, menubar, resizable, width, height, location, status, scrollbars);
    }
    public static void open(Page p, string surl, string wname, int width, int height, bool status, bool scrollbars)
    {
        bool menubar = false;
        bool resizable = false;
        bool location = false;
        open(p, surl, wname, menubar, resizable, width, height, location, status, scrollbars);
    }
    public static void open(Page p, string surl, string wname, int width, int height, bool scrollbars)
    {
        bool menubar = false;
        bool resizable = false;
        bool location = false;
        bool status = false;

        open(p, surl, wname, menubar, resizable, width, height, location, status, scrollbars);
    }
   
    //Modificacion Felipe

    public static void open(Page p, string surl, string wname, int wname2, int width, int height)
    {
        bool menubar = false;
        bool resizable = false;
        bool location = false;
        bool status = false;
        bool scrollbars = false;

        open(p, surl, wname, wname2, menubar, resizable, width, height, location, status, scrollbars);


    }
    
    public static void open(Page p, string surl, string wname,  int width, int height)
    {
        bool menubar = false;
        bool resizable = false;
        bool location = false;
        bool status = false;
        bool scrollbars = false;

        open(p, surl, wname, menubar, resizable, width, height, location, status, scrollbars);


       //open(p, surl, wname, wname2, menubar, resizable, width, height, location, status, scrollbars);
    }
    public static void open(Page p, string surl, int width, int height)
    {
        bool menubar = false;
        bool resizable = false;
        bool location = false;
        bool status = false;
        bool scrollbars = false;
        string wname = "_media";

        open(p, surl, wname, menubar, resizable, width, height, location, status, scrollbars);
    }
#endregion
    #region window.opener
    public class opener
    {
        public static void execute(Page p, string str)
        {
            
            p.ClientScript.RegisterClientScriptBlock(typeof(string), "SENAINFO", "<script  languaje=javascript> window.opener." +str+"; </script>");
            
        }
   
    }
    #endregion

    #region window.alert

    public static void alert(Page p, string message)
    {
        p.ClientScript.RegisterClientScriptBlock(typeof(string), "SENAINFO", "<script  languaje=javascript> alert('"+  message + "'); </script>");

    }   

    #endregion 
    
    #region ExisteToken
    public static bool existetoken(string token)
    {
        try
        {
            //DataTable listatokens = ((DataSet)npl).Tables[0];
            //((DataSet)HttpContext.Current.Session["tokens"]).Tables[0];
            DataTable listatokens = ((DataSet)HttpContext.Current.Session["tokens"]).Tables[0];
            if (token.Trim() != string.Empty && listatokens.Rows.Count > 0)
            {
                //return true;
                return (listatokens.Select("TokenCadena = '" + token.Trim() + "'").Length != 0);
            }

            //return (listatokens.Select("TokenCadena = '" + token.Trim() +"'").Length != 0);

            //for (int i = 0; i < listatokens.Rows.Count; i++)
            //{
            //    if (token.Trim() == listatokens.Rows[i][1].ToString().Trim())
            //    {
            //        return true;
            //    }

           // }
        }
        catch { }
        return false;
    }
    #endregion

    public static string Base64Encode(string plainText)
    {
        var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
        return System.Convert.ToBase64String(plainTextBytes);
    }

    public static string Base64Decode(string encodedString)
    {
        byte[] data = Convert.FromBase64String(encodedString);
        return Encoding.UTF8.GetString(data);

        //var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        //return System.Convert.ToBase64String(plainTextBytes);
    }

    /*public static string encriptaContrasena(string InContrasena)
    {
        byte[] hash = new SHA1CryptoServiceProvider().ComputeHash(Encoding.Unicode.GetBytes(InContrasena));
        string Contrasena = "";
        for (int index = 0; index < hash.Length; ++index)
            Contrasena += hash.GetValue(index).ToString();
        return Contrasena;
    }*/
    public static string EncriptarContrasena(string login, string contrasena)
    {
        List<byte> listBytes;
        StringBuilder sbResult;
        string username = login.ToLower();

        listBytes = new List<byte>();

        listBytes.AddRange(new SHA1CryptoServiceProvider().ComputeHash(Encoding.Unicode.GetBytes(contrasena)));
        /*if (username.Contains("@") == false)
        {
            listBytes.AddRange(new SHA1CryptoServiceProvider().ComputeHash(Encoding.Unicode.GetBytes(contrasena)));
        }
        else
        {
            username = username.Substring(username.Trim().Length - 1, 1) + username;

            listBytes.AddRange(new SHA1CryptoServiceProvider().ComputeHash(Encoding.Unicode.GetBytes(username)));
            listBytes.AddRange(new SHA1CryptoServiceProvider().ComputeHash(Encoding.Unicode.GetBytes(contrasena)));
        }*/

        sbResult = new StringBuilder();
        foreach (byte elemento in listBytes)
            sbResult.Append(elemento.ToString());

        return sbResult.ToString();
    }

    #region Validacion Usuario
    //public static bool validatetoken(string tkn, object npl)
    //{
    //    try
    //    {
    //        DataTable neopermissionlist = ((DataSet)npl).Tables[0];
    //        if (tkn.Trim() == string.Empty && neopermissionlist.Rows.Count > 0)
    //        {
    //            return true;
    //        }

    //        for (int i = 0; i < neopermissionlist.Rows.Count; i++)
    //        {
    //            if (tkn.Trim() == neopermissionlist.Rows[i][1].ToString().Trim())
    //            {
    //                return true;
    //            }

    //        }
    //    }
    //    catch { }
    //    return false;
    //}
    #endregion 

    #region window.logout
    public static void logout()
    {
        try
        {
            FormsAuthentication.SignOut();
            
            HttpContext.Current.Session.Clear();

            HttpContext.Current.Session.Remove("tokens");
            HttpContext.Current.Session.Remove("IdUsuario");
            HttpContext.Current.Session.Remove("Usuario");

            HttpContext.Current.Session.Remove("NNANombres");
            HttpContext.Current.Session.Remove("NNAApellidoPaterno");
            HttpContext.Current.Session.Remove("NNAApellidoMaterno");
            HttpContext.Current.Session.Remove("NNACodProyecto");
            HttpContext.Current.Session.Remove("NNACodInstitucion");
            HttpContext.Current.Session.Remove("NNASexo");
            HttpContext.Current.Session.Remove("NNARutNino");
            HttpContext.Current.Session.Remove("NNACodNino");
            HttpContext.Current.Session.Remove("NNAFechaNacimiento");
        }
        catch { }
    }
    #endregion
}

