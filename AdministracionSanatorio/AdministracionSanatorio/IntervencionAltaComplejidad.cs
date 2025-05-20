using System;

namespace AdministracionSanatorio
{
    public class IntervencionAltaComplejidad : Intervencion
    {
        public static double PorcentajeAdicional { get; set; } = 20.0;

        public IntervencionAltaComplejidad(string codigo, string descripcion, string especialidad, double arancel)
            : base(codigo, descripcion, especialidad, arancel)
        {
        }

        public override double GetCosto()
        {
            return Arancel + (Arancel * PorcentajeAdicional / 100.0);
        }
    }
}