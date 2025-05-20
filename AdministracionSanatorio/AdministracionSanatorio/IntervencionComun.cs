using System;

namespace AdministracionSanatorio
{
    public class IntervencionComun : Intervencion
    {
        public IntervencionComun(string codigo, string descripcion, string especialidad, double arancel)
            : base(codigo, descripcion, especialidad, arancel)
        {
        }

        public override double GetCosto()
        {
            return Arancel;
        }
    }
}