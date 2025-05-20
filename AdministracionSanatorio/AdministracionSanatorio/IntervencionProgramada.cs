using System;

namespace AdministracionSanatorio
{
    public class IntervencionProgramada
    {
        private static int contador = 1;
        public int Id { get; private set; }
        public DateTime Fecha { get; set; }
        public Intervencion Intervencion { get; set; }
        public Doctor Medico { get; set; }
        public bool Pagado { get; set; }

        public IntervencionProgramada(DateTime fecha, Intervencion intervencion, Doctor medico)
        {
            Id = contador++;
            Fecha = fecha;
            Intervencion = intervencion;
            Medico = medico;
            Pagado = false;
        }

        public double CalcularCostoPaciente(double cobertura)
        {
            double costo = Intervencion.GetCosto();
            return costo * (1 - cobertura / 100.0);
        }
    }
}