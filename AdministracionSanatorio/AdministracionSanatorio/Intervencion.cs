using System;

namespace AdministracionSanatorio
{
    public abstract class Intervencion
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Especialidad { get; set; }
        public double Arancel { get; set; }

        protected Intervencion(string codigo, string descripcion, string especialidad, double arancel)
        {
            Codigo = codigo;
            Descripcion = descripcion;
            Especialidad = especialidad;
            Arancel = arancel;
        }

        public abstract double GetCosto();
    }
}
