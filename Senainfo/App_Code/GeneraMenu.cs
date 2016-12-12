using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;

/// <summary>
/// Descripción breve de GeneraMenu
/// </summary>
public class GeneraMenu
{
    public static DataTable dt = new DataTable("Menu");
    public static DataTable dt2 = new DataTable("Menu2");
    public static DataTable dt3 = new DataTable("Menu3");
    public static DataTable dt4 = new DataTable("Menu4");

    public static DataView dv = new DataView();
    public static DataView dv2 = new DataView();
    public static DataView dv3 = new DataView();
    public static DataView dv4 = new DataView();

    public static string menu = string.Empty;

    private static string usuario = string.Empty;
    private static string password = string.Empty;
    private static string token = string.Empty;

    //private static int auxxx = 0;
    //private static int[] donde_estoy = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

	public GeneraMenu()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    public string getMenu_x_Token(string t)
    {
        token = t;
        getData_x_Token();

        string menu_aux = string.Empty;
        string menu = string.Empty;

        dv = dt.DefaultView;
        dv2 = dt2.DefaultView;
        dv3 = dt3.DefaultView;
        dv4 = dt4.DefaultView;

        dv.RowFilter = String.Empty;
        dv.RowFilter = "TokenNivel = " + 1;

        int cant_dv = dv.Count;
        string hijo_aux = String.Empty;

        for (int i = 0; i < cant_dv; i++)
        {
            hijo_aux = getHijo2((int)dv[i]["IdToken"]);

            if (hijo_aux == String.Empty)
            {
                menu = menu + "<li runat=\"server\" visible=\"true\"><a runat=\"server\" target=\"" + dv[i]["TokenTarget"] + "\" href=\"" + (HttpContext.Current.Handler as Page).ResolveUrl("~/" + dv[i]["TokenURL"]) + "\">" + dv[i]["TokenMenu"] + "</a></li>";
            }
            else
            {
                menu = menu + "<li runat=\"server\" visible=\"true\" class=\"dropdown dropdown-submenu\">";
                menu = menu + "    <a tabindex=\"-1\" href=\"" + (HttpContext.Current.Handler as Page).ResolveUrl("~/" + dv[i]["TokenURL"]) + "\" class=\"dropdown-toggle\" data-toggle=\"dropdown\">" + dv[i]["TokenMenu"] + "</a>";
                menu = menu + "    <ul class=\"dropdown-menu\">";
                menu = menu + hijo_aux;
                menu = menu + "    </ul>";
                menu = menu + "</li>";
            }
        }
        return menu;
    }

    public string getMenu(string u, string p)
    {
        usuario = u;
        password = window.EncriptarContrasena(u, p);
        getData();

        string menu_aux = string.Empty;
        string menu = string.Empty;

        dv = dt.DefaultView;
        dv2 = dt2.DefaultView;
        dv3 = dt3.DefaultView;
        dv4 = dt4.DefaultView;

        dv.RowFilter = String.Empty;
        dv.RowFilter = "TokenNivel = " + 1;

        int cant_dv = dv.Count;
        string hijo_aux = String.Empty;

        for (int i = 0; i < cant_dv; i++)
        {
            hijo_aux = getHijo2((int)dv[i]["IdToken"]);

            if(hijo_aux == String.Empty)
            {
                menu = menu + "<li runat=\"server\" visible=\"true\"><a runat=\"server\" target=\"" + dv[i]["TokenTarget"] + "\" href=\"" + (HttpContext.Current.Handler as Page).ResolveUrl("~/" + dv[i]["TokenURL"]) + "\">" + dv[i]["TokenMenu"] + "</a></li>";
            }
            else
            {
                menu = menu + "<li runat=\"server\" visible=\"true\" class=\"dropdown dropdown-submenu\">";
                menu = menu + "    <a tabindex=\"-1\" href=\"" + (HttpContext.Current.Handler as Page).ResolveUrl("~/" + dv[i]["TokenURL"]) + "\" class=\"dropdown-toggle\" data-toggle=\"dropdown\">" + dv[i]["TokenMenu"] + "</a>";
                menu = menu + "    <ul class=\"dropdown-menu\">";
                menu = menu + hijo_aux;
                menu = menu + "    </ul>";
                menu = menu + "</li>";
            }
        }
        return menu;
    }

    public static string getHijo2(int padre2)
    {
        string hijo2 = String.Empty;
        string hijo_aux2 = String.Empty;

        dv2.RowFilter = String.Empty;
        dv2.RowFilter = "TokenPadre = " + padre2;

        int cant_dv_aux = dv2.Count;

        for (int j = 0; j < cant_dv_aux; j++)
        {
            hijo_aux2 = getHijo3((int)dv2[j]["IdToken"]);

            if (hijo_aux2 == String.Empty)
            {
                hijo2 = hijo2 + "<li runat=\"server\" visible=\"true\"><a runat=\"server\" target=\"" + dv2[j]["TokenTarget"] + "\" href=\"" + (HttpContext.Current.Handler as Page).ResolveUrl("~/" + dv2[j]["TokenURL"]) + "\">" + dv2[j]["TokenMenu"] + "</a></li>";
            }
            else
            {
                hijo2 = hijo2 + "<li class=\"dropdown dropdown-submenu\">";
                hijo2 = hijo2 + "    <a tabindex=\"-1\" href=\"" + (HttpContext.Current.Handler as Page).ResolveUrl("~/" + dv2[j]["TokenURL"]) + "\" class=\"dropdown-toggle\" data-toggle=\"dropdown\">" + dv2[j]["TokenMenu"] + "</a>";
                hijo2 = hijo2 + "    <ul class=\"dropdown-menu\">";
                hijo2 = hijo2 + hijo_aux2;
                hijo2 = hijo2 + "    </ul>";
                hijo2 = hijo2 + "</li>";
            }
        }
        return hijo2;
    }

    public static string getHijo3(int padre3)
    {
        string hijo3 = String.Empty;
        string hijo_aux3 = String.Empty;

        dv3.RowFilter = String.Empty;
        dv3.RowFilter = "TokenPadre = " + padre3;

        int cant_dv_aux = dv3.Count;

        for (int k = 0; k < cant_dv_aux; k++)
        {
            hijo_aux3 = getHijo4((int)dv3[k]["IdToken"]);

            if (hijo_aux3 == String.Empty)
            {
                hijo3 = hijo3 + "<li runat=\"server\" visible=\"true\"><a runat=\"server\" target=\"" + dv3[k]["TokenTarget"] + "\" href=\"" + (HttpContext.Current.Handler as Page).ResolveUrl("~/" + dv3[k]["TokenURL"]) + "\">" + dv3[k]["TokenMenu"] + "</a></li>";
            }
            else
            {
                hijo3 = hijo3 + "<li class=\"dropdown dropdown-submenu\">";
                hijo3 = hijo3 + "    <a tabindex=\"-1\" href=\"" + (HttpContext.Current.Handler as Page).ResolveUrl("~/" + dv3[k]["TokenURL"]) + "\" class=\"dropdown-toggle\" data-toggle=\"dropdown\">" + dv3[k]["TokenMenu"] + "</a>";
                hijo3 = hijo3 + "    <ul class=\"dropdown-menu\">";
                hijo3 = hijo3 + hijo_aux3;
                hijo3 = hijo3 + "    </ul>";
                hijo3 = hijo3 + "</li>";
            }
        }
        return hijo3;
    }

    public static string getHijo4(int padre4)
    {
        string hijo4 = String.Empty;

        dv4.RowFilter = String.Empty;
        dv4.RowFilter = "TokenPadre = " + padre4;

        int cant_dv_aux = dv4.Count;

        for (int l = 0; l < cant_dv_aux; l++)
        {
            hijo4 = hijo4 + "<li runat=\"server\" visible=\"true\"><a runat=\"server\" target=\"" + dv4[l]["TokenTarget"] + "\" href=\"" + (HttpContext.Current.Handler as Page).ResolveUrl("~/" + dv4[l]["TokenURL"]) + "\">" + dv4[l]["TokenMenu"] + "</a></li>";
        }
        return hijo4;
    }

    public static void getData()
    {
        ConexionesSS con = new ConexionesSS();
        con.Autenticar();
        dt = con.TraerDataTable("LSI_ObtenerTokensMenuDinamico", usuario, password, 1); //IdSistema->1 = Senainfo
        dt.TableName = "Menu";
        dt2 = dt.Copy();
        dt2.TableName = "Menu2";
        dt3 = dt.Copy();
        dt3.TableName = "Menu3";
        dt4 = dt.Copy();
        dt4.TableName = "Menu4";
        con.CerrarConexion();
    }

    public static void getData_x_Token()
    {
        ConexionesSS con = new ConexionesSS();
        con.Autenticar();
        dt = con.TraerDataTable("LSI_ObtenerTokensMenuDinamico_x_Token", token, 1); //IdSistema->1 = Senainfo
        dt.TableName = "Menu";
        dt2 = dt.Copy();
        dt2.TableName = "Menu2";
        dt3 = dt.Copy();
        dt3.TableName = "Menu3";
        dt4 = dt.Copy();
        dt4.TableName = "Menu4";
        con.CerrarConexion();
    }

    #region niveles dinamicos
    //public static string getHijo(int padre)
    //{
    //    string hijo = String.Empty;
    //    dv2.RowFilter = String.Empty;
    //    dv2.RowFilter = "TokenPadre = " + padre;
    //    int cant_dv_aux = dv2.Count;
    //    string hijo_aux = String.Empty;
    //    for (int i = 0; i < cant_dv_aux; i++)
    //    {
    //        hijo_aux = getHijo((int)dv2[i]["IdToken"]);
    //        if (hijo_aux == String.Empty)
    //        {
    //            menu = menu + "<li runat='server' visible='true'><a runat='server' href='" + dv2[i]["TokenURL"] + "'>" + dv2[i]["TokenMenu"] + "</a></li>";
    //            //auxxx = i;
    //        }
    //        else
    //        {
    //            menu = menu + "<li runat='server' visible='true' class='dropdown dropdown-submenu'>";
    //            menu = menu + "    <a tabindex='-1' href='" + dv2[i]["TokenURL"] + "' class='dropdown-toggle' data-toggle='dropdown'>" + dv2[i]["TokenMenu"] + "</a>";
    //            menu = menu + "    <ul class='dropdown-menu'>";
    //            menu = menu + hijo_aux;
    //            menu = menu + "    </ul>";
    //            menu = menu + "</li>";
    //            //i = auxxx;
    //        }
    //    }
    //    //for (int j = 0; j < cant_dv_aux; j++)
    //    //{
    //    //    hijo = hijo + "<li runat='server' visible='true'><a runat='server' href='" + dv2[j]["TokenURL"] + "'>" + dv2[j]["TokenMenu"] + "</a></li>";
    //    //}
    //    return hijo;
    //}
    #endregion

    #region segundo nivel funcional
    //public static string getHijo(int padre)
    //{
    //    string hijo = String.Empty;

    //    dv2.RowFilter = String.Empty;
    //    dv2.RowFilter = "TokenPadre = " + padre;

    //    int cant_dv_aux = dv2.Count;

    //    for (int j = 0; j < cant_dv_aux; j++)
    //    {
    //        hijo = hijo + "<li runat='server' visible='true'><a runat='server' href='" + dv2[j]["TokenURL"] + "'>" + dv2[j]["TokenMenu"] + "</a></li>";
    //    }
    //    return hijo;
    //}
    #endregion
}