<<<<<<< HEAD
# Tarea 3 - Registro de Estudiante con Clases y Arrays en C#

## 📚 Universidad Estatal Amazónica
**Carrera:** Tecnología de la Información  
**Nivel:** 3er semestre  
**Estudiante:** Wilton Stiwar Salazar Bisbicuz  
**GitHub:** [@wilton23x](https://github.com/wilton23x)  
**Correo institucional:** ws.salazarb@uea.edu.ec  

---

## 📌 Descripción

Este proyecto en lenguaje **C#** tiene como objetivo el manejo de clases y arrays para registrar los datos básicos de un estudiante. Se incluye el uso de:

- Clases y objetos
- Propiedades y métodos
- Arrays para el almacenamiento de múltiples teléfonos

El código fue desarrollado en **Visual Studio Code** utilizando el **.NET SDK 9.0**.

---

## 💻 Código fuente principal (`Program.cs`)

```csharp
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
=======
# -ESTRUCTURA-DE-DATOS-A-
 Figuras Geométricas en C#

Este proyecto contiene dos clases en C# que encapsulan propiedades y comportamientos de figuras geométricas básicas: círculo y rectángulo. Ambas clases utilizan tipos de datos primitivos y métodos para calcular el área y el perímetro.

## Clases implementadas

### 🔵 Circulo
- **Atributo privado:** radio
- **Métodos:**
  - `CalcularArea()`: devuelve el área del círculo.
  - `CalcularPerimetro()`: devuelve el perímetro (circunferencia) del círculo.

### 🟦 Rectangulo
- **Atributos privados:** base, altura
- **Métodos:**
  - `CalcularArea()`: devuelve el área del rectángulo.
  - `CalcularPerimetro()`: devuelve el perímetro del rectángulo.

## Archivos incluidos

- `ProgramaFiguras.cs` — Código fuente con clases y programa de prueba.
- `CodigoFigurasGeometricas.pdf` — Documento con el código y explicaciones en formato PDF.

## Autor
**Wilton Salazar**  
📅 Fecha: 03/06/2025
>>>>>>> 7f54891c78b788cc0b1c8e1d29e8075487f45b87
