using System;

namespace AdministracionSanatorio
{
    public class Doctor
    {
        public string Nombre { get; set; }
        public string Matricula { get; set; }
        public string Especialidad { get; set; }
        public bool Disponible { get; set; }

        public Doctor(string nombre, string matricula, string especialidad, bool disponible)
        {
            Nombre = nombre;
            Matricula = matricula;
            Especialidad = especialidad;
            Disponible = disponible;
        }
    }
}