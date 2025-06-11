using System;

namespace RegistroEstudiante
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string[] Telefonos { get; set; }

        public Estudiante(int id, string nombres, string apellidos, string direccion, string[] telefonos)
        {
            Id = id;
            Nombres = nombres;
            Apellidos = apellidos;
            Direccion = direccion;
            Telefonos = telefonos;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine("=== INFORMACIÓN DEL ESTUDIANTE ===");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nombre: {Nombres} {Apellidos}");
            Console.WriteLine($"Dirección: {Direccion}");
            Console.WriteLine("Teléfonos:");
            for (int i = 0; i < Telefonos.Length; i++)
            {
                Console.WriteLine($"  Teléfono {i + 1}: {Telefonos[i]}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] telefonos = new string[3] { "0991234567", "0987654321", "0971122334" };

            Estudiante estudiante = new Estudiante(
                id: 1,
                nombres: "Wilton Stiwar",
                apellidos: "Salazar Bisbicuz",
                direccion: "Av. Amazonas y 12 de febrero",
                telefonos: telefonos
            );

            estudiante.MostrarInformacion();

            Console.WriteLine("\nPresione una tecla para salir...");
            Console.ReadKey();
        }
    }
}
