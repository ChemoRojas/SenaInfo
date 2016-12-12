using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ResumenNNA : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        validatescurity();
        cargar_datos();
    }

    private void validatescurity()
    {
        if (!window.existetoken("15152ADB-D98E-4D32-BFD5-4333DBC1ED78"))
        {
            Response.Redirect("~/logout.aspx");
        }
    }

    public void cargar_datos()
    {
        DataTable dt = new DataTable();
        string icodie;
        icodie = Request.QueryString["icodie"];

        string cinstitucion;
        string cproyecto;
        int codie;
        int cnino;
        string rut;
        string nombres;
        string apepat;
        string apemat;
        string fingreso;
        string fnacimiento;

        Conexiones con = new Conexiones();
        dt = con.TraerDataTable("PA_NNA_Vigentes", Convert.ToInt32(icodie));
        con.Desconectar();

        foreach (DataRow row in dt.Rows)
        {
            if (row[0] == "")
            {
                Response.Redirect("NinosEnProyecto.aspx");
            }
            else
            {
                cinstitucion = Convert.ToString(row["CodInstitucion"]);
                cproyecto = Convert.ToString(row["CodProyecto"]);
                codie = Convert.ToInt32(row["ICodIE"]);
                cnino = Convert.ToInt32(row["CodNino"]);
                rut = Convert.ToString(row["Rut"]);
                nombres = Convert.ToString(row["Nombres"]);
                apepat = Convert.ToString(row["Apellido_Paterno"]);
                apemat = Convert.ToString(row["Apellido_Materno"]);
                fingreso = Convert.ToString(row["FechaIngreso"]);
                fnacimiento = Convert.ToString(row["FechaNacimiento"]);

                oNNA NNA = new oNNA(cinstitucion, cproyecto, codie, cnino, rut, nombres, apepat, apemat, fingreso, fnacimiento);
                Session["NNA"] = NNA;

                tb_nombre_institucion.Text = Convert.ToString(row["NombreInstitucion"]);
                tb_codigo_proyecto.Text = "(" + cproyecto + ") " + Convert.ToString(row["NombreProyecto"]);
                tb_nombre_nna.Text = nombres;
                tb_apellido_paterno.Text = apepat;
                tb_apellido_materno.Text = apemat;
                if (fnacimiento == "")
                {
                    tb_fecha_nacimiento.Text = "01-01-1900";
                    fnacimiento = "01-01-1900";
                }
                else
                {
                    tb_fecha_nacimiento.Text = fnacimiento.Substring(0, 10);
                }
            }
        }
    }
}