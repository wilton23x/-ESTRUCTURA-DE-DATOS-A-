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

    // Aquí compruebo si la cédula ya fue registrada antes de agendar otro turno.
    private bool CedulaYaRegistrada(string cedula)
    {
        for (int i = 0; i < contador; i++)
        {
            if (turnos[i].Cedula == cedula)
                return true;
        }
        return false;
    }

    public void AgendarTurno()
    {
        if (contador < turnos.Length)
        {
            Turno nuevo = new Turno();

            // Solicito el nombre del paciente para guardar el dato principal del turno.
            System.Console.Write("Ingrese nombre del paciente: ");
            nuevo.Nombre = System.Console.ReadLine();

            // Validación: no permito cédulas repetidas ni letras.
            string cedula;
            do
            {
                System.Console.Write("Ingrese cédula (solo números): ");
                cedula = System.Console.ReadLine();
                if (!EsSoloNumeros(cedula) || CedulaYaRegistrada(cedula))
                    System.Console.WriteLine("❌ Cédula inválida o ya registrada.");
            } while (!EsSoloNumeros(cedula) || CedulaYaRegistrada(cedula));
            nuevo.Cedula = cedula;

            // Aquí me aseguro de que la fecha no esté en el pasado.
            System.Console.Write("Ingrese fecha del turno (dd/mm/aaaa): ");
            System.DateTime fecha;
            while (!System.DateTime.TryParse(System.Console.ReadLine(), out fecha) || fecha.Date < System.DateTime.Today)
            {
                System.Console.Write("❌ Fecha inválida o pasada. Intente de nuevo: ");
            }

            // Solo se permiten horarios de 08:00 a 18:00.
            System.Console.Write("Ingrese hora del turno (hh:mm, 24h): ");
            System.TimeSpan hora;
            while (!System.TimeSpan.TryParse(System.Console.ReadLine(), out hora) || hora < new System.TimeSpan(8, 0, 0) || hora > new System.TimeSpan(18, 0, 0))
            {
                System.Console.Write("❌ Hora inválida (debe ser entre 08:00 y 18:00): ");
            }

            nuevo.FechaHora = fecha.Date + hora;

            turnos[contador] = nuevo;
            contador++;

            // Mensaje que indica que el turno fue guardado correctamente.
            System.Console.WriteLine("✅ Turno registrado correctamente.\n");
        }
        else
        {
            System.Console.WriteLine("❌ No hay espacio para más turnos.\n");
        }
    }

    public void MostrarTurnos()
    {
        // Muestra una advertencia si no se ha registrado ningún turno.
        if (contador == 0)
        {
            System.Console.WriteLine("⚠️ No hay turnos registrados.\n");
            return;
        }

        System.Console.WriteLine("\n📋 Turnos registrados:");
        for (int i = 0; i < contador; i++)
        {
            // Imprimo todos los turnos agendados con formato claro de fecha y hora.
            System.Console.WriteLine($"Paciente: {turnos[i].Nombre}");
            System.Console.WriteLine($"Cédula: {turnos[i].Cedula}");
            System.Console.WriteLine($"Fecha y hora: {turnos[i].FechaHora:dd/MM/yyyy HH:mm}");
            System.Console.WriteLine("-----------------------------");
        }

        System.Console.WriteLine($"Total de turnos: {contador}\n");
    }

    // Esta función permite eliminar un turno usando la cédula, si se necesita cancelar.
    public void EliminarTurno()
    {
        System.Console.Write("Ingrese la cédula del turno que desea eliminar: ");
        string cedula = System.Console.ReadLine();
        int index = -1;

        for (int i = 0; i < contador; i++)
        {
            if (turnos[i].Cedula == cedula)
            {
                index = i;
                break;
            }
        }

        if (index == -1)
        {
            System.Console.WriteLine("❌ No se encontró un turno con esa cédula.\n");
            return;
        }

        // Aquí corro todos los turnos hacia la izquierda para eliminar el seleccionado.
        for (int i = index; i < contador - 1; i++)
        {
            turnos[i] = turnos[i + 1];
        }

        contador--;
        System.Console.WriteLine("✅ Turno eliminado correctamente.\n");
    }

    // Me aseguro de que la cédula ingresada tenga solo números.
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
            // Menú con opciones claras para el usuario.
            System.Console.WriteLine("==== MENÚ PRINCIPAL ====");
            System.Console.WriteLine("1. Agendar nuevo turno");
            System.Console.WriteLine("2. Ver turnos agendados");
            System.Console.WriteLine("3. Eliminar turno por cédula");
            System.Console.WriteLine("4. Salir");
            System.Console.Write("Seleccione una opción: ");

            string entrada = System.Console.ReadLine();
            System.Int32.TryParse(entrada, out opcion);
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
                    agenda.EliminarTurno();
                    break;
                case 4:
                    // Indico al usuario que el sistema se está cerrando correctamente.
                    System.Console.WriteLine("👋 Saliendo del sistema...");
                    break;
                default:
                    // Manejo de opciones no válidas con mensaje de advertencia.
                    System.Console.WriteLine("❌ Opción no válida.\n");
                    break;
            }

        } while (opcion != 4);
    }
}
