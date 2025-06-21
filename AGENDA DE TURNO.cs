using System;
using System.Linq;

class Turno
{
    // Propiedades del turno
    public string Nombre { get; set; }
    public string Cedula { get; set; }
    public DateTime FechaHora { get; set; }
}

class AgendaTurnos
{
    Turno[] turnos = new Turno[100]; // Vector de turnos
    int contador = 0;

    public void AgendarTurno()
    {
        if (contador < turnos.Length)
        {
            Turno nuevo = new Turno();

            Console.Write("Ingrese nombre del paciente: ");
            nuevo.Nombre = Console.ReadLine();

            Console.Write("Ingrese cédula (solo números): ");
            string cedula;
            do
            {
                cedula = Console.ReadLine();
                if (!cedula.All(char.IsDigit))
                    Console.Write("Cédula inválida. Intente de nuevo: ");
            } while (!cedula.All(char.IsDigit));
            nuevo.Cedula = cedula;

            // Captura y validación de la fecha
            DateTime fecha;
            Console.Write("Ingrese fecha del turno (dd/mm/aaaa): ");
            while (!DateTime.TryParse(Console.ReadLine(), out fecha))
            {
                Console.Write("Fecha inválida. Intente de nuevo (dd/mm/aaaa): ");
            }

            // Captura y validación de la hora
            TimeSpan hora;
            Console.Write("Ingrese hora del turno (hh:mm, formato 24h): ");
            while (!TimeSpan.TryParse(Console.ReadLine(), out hora))
            {
                Console.Write("Hora inválida. Intente de nuevo (hh:mm): ");
            }

            // Combina fecha y hora
            nuevo.FechaHora = fecha.Date + hora;

            turnos[contador] = nuevo;
            contador++;

            Console.WriteLine("✅ Turno registrado correctamente.\n");
        }
        else
        {
            Console.WriteLine("❌ No hay espacio para más turnos.\n");
        }
    }

    public void MostrarTurnos()
    {
        if (contador == 0)
        {
            Console.WriteLine("⚠️ No hay turnos registrados.\n");
            return;
        }

        Console.WriteLine("\n📋 Turnos registrados:");
        for (int i = 0; i < contador; i++)
        {
            Console.WriteLine($"Paciente: {turnos[i].Nombre}");
            Console.WriteLine($"Cédula: {turnos[i].Cedula}");
            Console.WriteLine($"Fecha y hora: {turnos[i].FechaHora:dd/MM/yyyy HH:mm}");
            Console.WriteLine("-----------------------------");
        }

        Console.WriteLine($"Total de turnos: {contador}\n");
    }
}

class MainApp
{
    static void Main()
    {
        AgendaTurnos agenda = new AgendaTurnos();
        int opcion;

        do
        {
            Console.WriteLine("---- MENÚ ----");
            Console.WriteLine("1. Agendar nuevo turno");
            Console.WriteLine("2. Ver turnos agendados");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");

            string entrada = Console.ReadLine();
            int.TryParse(entrada, out opcion);
            Console.WriteLine();

            switch (opcion)
            {
                case 1:
                    agenda.AgendarTurno();
                    break;
                case 2:
                    agenda.MostrarTurnos();
                    break;
                case 3:
                    Console.WriteLine("👋 Saliendo del sistema...");
                    break;
                default:
                    Console.WriteLine("❌ Opción no válida.\n");
                    break;
            }

        } while (opcion != 3);
    }
}
// Este código implementa un sistema de agenda de turnos para pacientes.