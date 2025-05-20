using System;

namespace AdministracionSanatorio
{
    class Program
    {
        static void Main(string[] args)
        {
            Hospital hospital = new Hospital();
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("\n--- Menú ---");
                Console.WriteLine("1. Dar de alta un nuevo Paciente");
                Console.WriteLine("2. Listar Pacientes");
                Console.WriteLine("3. Asignar nueva intervención a un Paciente");
                Console.WriteLine("4. Calcular costo de intervenciones por DNI");
                Console.WriteLine("5. Reporte de liquidaciones pendientes");
                Console.WriteLine("6. Salir");
                Console.Write("Opción: ");
                var opt = Console.ReadLine();
                switch (opt)
                {
                    case "1":
                        Console.Write("DNI: "); string dni = Console.ReadLine();
                        Console.Write("Nombre: "); string nombre = Console.ReadLine();
                        Console.Write("Teléfono: "); string tel = Console.ReadLine();
                        Console.Write("Obra social (o vacío): "); string os = Console.ReadLine();
                        Console.Write("Cobertura (%): "); double cov = double.Parse(Console.ReadLine());
                        hospital.AltaPaciente(new Paciente(dni, nombre, tel, string.IsNullOrEmpty(os) ? null : os, cov));
                        break;
                    case "2":
                        hospital.ListarPacientes();
                        break;
                    case "3":
                        Console.Write("DNI del paciente: "); dni = Console.ReadLine();
                        Console.Write("Código intervención: "); var code = Console.ReadLine();
                        var interv = hospital.Intervenciones.Find(i => i.Codigo == code);
                        Console.Write("Matrícula del médico: "); var mat = Console.ReadLine();
                        var doc = hospital.Doctores.Find(d => d.Matricula == mat);
                        Console.Write("Fecha (yyyy-MM-dd): "); var fecha = DateTime.Parse(Console.ReadLine());
                        hospital.AsignarIntervencion(dni, interv, doc, fecha);
                        break;
                    case "4":
                        Console.Write("Ingrese DNI: "); dni = Console.ReadLine();
                        double total = hospital.CalcularCostoTotalPaciente(dni);
                        Console.WriteLine($"Costo total para {dni}: {total:C}");
                        break;
                    case "5":
                        hospital.ReportePendientesPago();
                        break;
                    case "6":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
    }
}
