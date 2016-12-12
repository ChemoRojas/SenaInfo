using System;

namespace Argentis.Regmen
{
    /// <summary>
    /// Summary description for regobject.
    /// </summary>
    public class regobject
    {
        public regobject()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private string neo_rut;
        public string rut
        {
            get { return neo_rut; }
            set { neo_rut = value; }
        }
        private string neo_Apellido_Paterno;
        public string Apellido_Paterno
        {
            get { return neo_Apellido_Paterno; }
            set { neo_Apellido_Paterno = value; }
        }
        private string neo_Apellido_Materno;
        public string Apellido_Materno
        {
            get { return neo_Apellido_Materno; }
            set { neo_Apellido_Materno = value; }
        }
        private string neo_Nombres;
        public string Nombres
        {
            get { return neo_Nombres; }
            set { neo_Nombres = value; }
        }
        private DateTime neo_FechaNacimiento;
        public DateTime FechaNacimiento
        {
            get { return neo_FechaNacimiento; }
            set { neo_FechaNacimiento = value; }
        }

        private string neo_sexo;
        public string sexo
        {
            get { return neo_sexo; }
            set { neo_sexo = value; }
        }
        private string neo_NombreInst;
        public string NombreInst
        {
            get { return neo_NombreInst; }
            set { neo_NombreInst = value; }
        }
        private int neo_CodProyecto;
        public int CodProyecto
        {
            get { return neo_CodProyecto; }
            set { neo_CodProyecto = value; }
        }
        private int neo_CodNino;
        public int CodNino
        {
            get { return neo_CodNino; }
            set { neo_CodNino = value; }
        }
        private string neo_NombreProy;
        public string NombreProy
        {
            get { return neo_NombreProy; }
            set { neo_NombreProy = value; }
        }
        private DateTime neo_fchingdesde;
        public DateTime fchingdesde
        {
            get { return neo_fchingdesde; }
            set { neo_fchingdesde = value; }
        }
        private DateTime neo_fchinghasta;
        public DateTime fchinghasta
        {
            get { return neo_fchinghasta; }
            set { neo_fchinghasta = value; }
        }
        private DateTime neo_fchegdesde;
        public DateTime fchegdesde
        {
            get { return neo_fchegdesde; }
            set { neo_fchegdesde = value; }
        }
        private DateTime neo_fcheghasta;
        public DateTime fcheghasta
        {
            get { return neo_fcheghasta; }
            set { neo_fcheghasta = value; }
        }
        private DateTime neo_vigenteen;
        public DateTime vigenteen
        {
            get { return neo_vigenteen; }
            set { neo_vigenteen = value; }
        }
        private string neo_engest;
        public string engest
        {
            get { return neo_engest; }
            set { neo_engest = value; }
        }


    }
}
