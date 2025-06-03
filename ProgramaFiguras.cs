// Nombre: Wilton Salazar
// Fecha: 03/06/2025

using System;

// Clase Circulo que encapsula el radio y proporciona métodos para calcular el área y el perímetro
public class Circulo
{
    private double radio; // Atributo privado para el radio del círculo

    // Constructor que inicializa el radio del círculo
    public Circulo(double radio)
    {
        this.radio = radio;
    }

    // CalcularArea es una función que devuelve un valor double, se utiliza para calcular el área de un círculo
    public double CalcularArea()
    {
        return Math.PI * radio * radio;
    }

    // CalcularPerimetro devuelve el perímetro (circunferencia) del círculo
    public double CalcularPerimetro()
    {
        return 2 * Math.PI * radio;
    }
}

// Clase Rectangulo que encapsula base y altura y proporciona métodos para calcular área y perímetro
public class Rectangulo
{
    private double baseRectangulo; // Atributo privado para la base
    private double altura;         // Atributo privado para la altura

    // Constructor que inicializa base y altura del rectángulo
    public Rectangulo(double baseRectangulo, double altura)
    {
        this.baseRectangulo = baseRectangulo;
        this.altura = altura;
    }

    // CalcularArea devuelve el área del rectángulo
    public double CalcularArea()
    {
        return baseRectangulo * altura;
    }

    // CalcularPerimetro devuelve el perímetro del rectángulo
    public double CalcularPerimetro()
    {
        return 2 * (baseRectangulo + altura);
    }
}

// Programa de ejemplo para utilizar las clases
class Programa
{
    static void Main(string[] args)
    {
        Circulo circulo = new Circulo(5);
        Console.WriteLine("Área del círculo: " + circulo.CalcularArea());
        Console.WriteLine("Perímetro del círculo: " + circulo.CalcularPerimetro());

        Rectangulo rectangulo = new Rectangulo(4, 6);
        Console.WriteLine("Área del rectángulo: " + rectangulo.CalcularArea());
        Console.WriteLine("Perímetro del rectángulo: " + rectangulo.CalcularPerimetro());
    }
}
