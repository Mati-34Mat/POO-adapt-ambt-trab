using System;
using System.Collections.Generic;

namespace AdministracionSanatorio
{
    public class Paciente
    {
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string ObraSocial { get; set; }
        public double Cobertura { get; set; }
        public List<IntervencionProgramada> Intervenciones { get; set; } = new List<IntervencionProgramada>();

        public Paciente(string dni, string nombre, string telefono, string obraSocial, double cobertura)
        {
            DNI = dni;
            Nombre = nombre;
            Telefono = telefono;
            ObraSocial = obraSocial;
            Cobertura = cobertura;
        }

        public void AgregarIntervencion(IntervencionProgramada ip)
        {
            Intervenciones.Add(ip);
        }
    }
}
