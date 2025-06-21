class Turno
{
    public string Nombre { get; set; }
    public string Cedula { get; set; }
    public System.DateTime FechaHora { get; set; }
}

class AgendaTurnos
{
    private Turno[] turnos = new Turno[100];
    private int contador = 0;

    public void AgendarTurno()
    {
        if (contador < turnos.Length)
        {
            Turno nuevo = new Turno();

            System.Console.Write("Ingrese nombre del paciente: ");
            nuevo.Nombre = System.Console.ReadLine();

            System.Console.Write("Ingrese cédula (solo números): ");
            string cedula;
            do
            {
                cedula = System.Console.ReadLine();
                if (!EsSoloNumeros(cedula))
                    System.Console.Write("Cédula inválida. Intente de nuevo: ");
            } while (!EsSoloNumeros(cedula));
            nuevo.Cedula = cedula;

            System.Console.Write("Ingrese fecha del turno (dd/mm/aaaa): ");
            System.DateTime fecha;
            while (!System.DateTime.TryParse(System.Console.ReadLine(), out fecha))
            {
                System.Console.Write("Fecha inválida. Intente de nuevo (dd/mm/aaaa): ");
            }

            System.Console.Write("Ingrese hora del turno (hh:mm, formato 24h): ");
            System.TimeSpan hora;
            while (!System.TimeSpan.TryParse(System.Console.ReadLine(), out hora))
            {
                System.Console.Write("Hora inválida. Intente de nuevo (hh:mm): ");
            }

            nuevo.FechaHora = fecha.Date + hora;

            turnos[contador] = nuevo;
            contador++;

            System.Console.WriteLine("✅ Turno registrado correctamente.\n");
        }
        else
        {
            System.Console.WriteLine("❌ No hay espacio para más turnos.\n");
        }
    }

    public void MostrarTurnos()
    {
        if (contador == 0)
        {
            System.Console.WriteLine("⚠️ No hay turnos registrados.\n");
            return;
        }

        System.Console.WriteLine("\n📋 Turnos registrados:");
        for (int i = 0; i < contador; i++)
        {
            System.Console.WriteLine($"Paciente: {turnos[i].Nombre}");
            System.Console.WriteLine($"Cédula: {turnos[i].Cedula}");
            System.Console.WriteLine($"Fecha y hora: {turnos[i].FechaHora:dd/MM/yyyy HH:mm}");
            System.Console.WriteLine("-----------------------------");
        }

        System.Console.WriteLine($"Total de turnos: {contador}\n");
    }

    private bool EsSoloNumeros(string texto)
    {
        if (string.IsNullOrEmpty(texto))
            return false;

        foreach (char c in texto)
        {
            if (c < '0' || c > '9')
                return false;
        }
        return true;
    }
}

class Program
{
    static void Main()
    {
        AgendaTurnos agenda = new AgendaTurnos();
        int opcion;

        do
        {
            System.Console.WriteLine("---- MENÚ ----");
            System.Console.WriteLine("1. Agendar nuevo turno");
            System.Console.WriteLine("2. Ver turnos agendados");
            System.Console.WriteLine("3. Salir");
            System.Console.Write("Seleccione una opción: ");

            string entrada = System.Console.ReadLine();
            int.TryParse(entrada, out opcion);
            System.Console.WriteLine();

            switch (opcion)
            {
                case 1:
                    agenda.AgendarTurno();
                    break;
                case 2:
                    agenda.MostrarTurnos();
                    break;
                case 3:
                    System.Console.WriteLine("👋 Saliendo del sistema...");
                    break;
                default:
                    System.Console.WriteLine("❌ Opción no válida.\n");
                    break;
            }

        } while (opcion != 3);
    }
}
