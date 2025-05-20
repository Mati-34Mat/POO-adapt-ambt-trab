using System;
using System.Collections.Generic;
using System.Linq;

namespace AdministracionSanatorio
{
    public class Hospital
    {
        public List<Doctor> Doctores { get; set; } = new List<Doctor>();
        public List<Paciente> Pacientes { get; set; } = new List<Paciente>();
        public List<Intervencion> Intervenciones { get; set; } = new List<Intervencion>();

        public Hospital()
        {
            // Doctores
            Doctores.Add(new Doctor("Juan Pérez", "12345", "Cardiología", true));
            Doctores.Add(new Doctor("Laura Gómez", "23456", "Traumatología", false));
            Doctores.Add(new Doctor("Carlos Ruiz", "34567", "Neurología", true));
            Doctores.Add(new Doctor("María Silva", "45678", "Gastroenterología", true));
            Doctores.Add(new Doctor("Fernando Torres", "56789", "Cardiología", true));
            Doctores.Add(new Doctor("Cecilia López", "67890", "Traumatología", true));

            // Pacientes
            Pacientes.Add(new Paciente("30111222", "Ana Torres", "1111-2222", "ObraMed", 80));
            Pacientes.Add(new Paciente("29222333", "Luis Fernández", "2222-3333", null, 0));
            Pacientes.Add(new Paciente("28444555", "Clara Méndez", "3333-4444", "SaludPlus", 90));
            Pacientes.Add(new Paciente("27555666", "Pedro Gómez", "4444-5555", "VidaTotal", 70));
            Pacientes.Add(new Paciente("26666777", "Lucía Ortega", "5555-6666", null, 0));
            Pacientes.Add(new Paciente("25777888", "Jorge Ramírez", "6666-7777", "SaludPlus", 60));

            // Intervenciones comunes
            Intervenciones.Add(new IntervencionComun("INT001", "Bypass coronario", "Cardiología", 120000));
            Intervenciones.Add(new IntervencionComun("INT003", "Artroscopía de rodilla", "Traumatología", 80000));
            Intervenciones.Add(new IntervencionComun("INT005", "Endoscopía digestiva", "Gastroenterología", 40000));
            Intervenciones.Add(new IntervencionComun("INT007", "Colocación de stent", "Cardiología", 95000));
            Intervenciones.Add(new IntervencionComun("INT008", "Reducción de fractura", "Traumatología", 60000));

            // Intervenciones de alta complejidad
            Intervenciones.Add(new IntervencionAltaComplejidad("INT002", "Neurocirugía", "Neurología", 200000));
            Intervenciones.Add(new IntervencionAltaComplejidad("INT004", "Revascularización miocárdica", "Cardiología", 250000));
            Intervenciones.Add(new IntervencionAltaComplejidad("INT006", "Cirugía de columna", "Traumatología", 180000));
            Intervenciones.Add(new IntervencionAltaComplejidad("INT009", "Cirugía bariátrica", "Gastroenterología", 220000));
            Intervenciones.Add(new IntervencionAltaComplejidad("INT010", "Craneotomía", "Neurología", 270000));
        }

        public void AltaPaciente(Paciente p)
        {
            Pacientes.Add(p);
            Console.WriteLine("Paciente dado de alta: " + p.Nombre);
        }

        public void ListarPacientes()
        {
            foreach (var p in Pacientes)
            {
                Console.WriteLine($"DNI: {p.DNI}, Nombre: {p.Nombre}, Tel: {p.Telefono}");
            }
        }

        public void AsignarIntervencion(string dni, Intervencion interv, Doctor doc, DateTime fecha)
        {
            var paciente = Pacientes.FirstOrDefault(x => x.DNI == dni);
            if (paciente == null)
            {
                Console.WriteLine("Paciente no registrado. Ingrese datos para dar de alta:");
                Console.Write("Nombre: "); var nom = Console.ReadLine();
                Console.Write("Teléfono: "); var tel = Console.ReadLine();
                Console.Write("Obra social (o vacío): "); var os = Console.ReadLine();
                Console.Write("Cobertura (%): "); var cov = double.Parse(Console.ReadLine());
                paciente = new Paciente(dni, nom, tel, string.IsNullOrEmpty(os) ? null : os, cov);
                AltaPaciente(paciente);
            }
            if (doc.Especialidad != interv.Especialidad)
            {
                Console.WriteLine("Error: el médico no tiene la especialidad requerida.");
                return;
            }
            if (!doc.Disponible)
            {
                Console.WriteLine("Error: el médico no está disponible.");
                return;
            }
            var ip = new IntervencionProgramada(fecha, interv, doc);
            paciente.AgregarIntervencion(ip);
            Console.WriteLine($"Intervención asignada. ID turno: {ip.Id}");
        }

        public double CalcularCostoTotalPaciente(string dni)
        {
            var paciente = Pacientes.FirstOrDefault(x => x.DNI == dni);
            if (paciente == null) return 0;
            return paciente.Intervenciones.Sum(i => i.CalcularCostoPaciente(paciente.Cobertura));
        }

        public void ReportePendientesPago()
        {
            Console.WriteLine("--- Liquidaciones Pendientes ---");
            foreach (var p in Pacientes)
            {
                foreach (var ip in p.Intervenciones.Where(i => !i.Pagado))
                {
                    string obraSocial = string.IsNullOrEmpty(p.ObraSocial) ? "-" : p.ObraSocial;
                    double importe = ip.CalcularCostoPaciente(p.Cobertura);
                    Console.WriteLine($"ID: {ip.Id}, Fecha: {ip.Fecha:d}, Descripción: {ip.Intervencion.Descripcion}, " +
                                      $"Paciente: {p.Nombre}, Médico: {ip.Medico.Nombre} ({ip.Medico.Matricula}), " +
                                      $"Obra Social: {obraSocial}, Importe: {importe:C}");
                }
            }
        }
    }
}