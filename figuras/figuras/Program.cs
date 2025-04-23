using System;

namespace figuras
{
    public interface Figura
    {
        double CalcularArea();
        double CalcularPerimetro();
    }

    public class Rectangulo : Figura
    {
        public double Base;
        public double Altura;

        public Rectangulo(double b, double h)
        {
            Base = b;
            Altura = h;
        }

        public double CalcularArea()
        {
            return Base * Altura;
        }

        public double CalcularPerimetro()
        {
            return 2 * (Base + Altura);
        }
    }
    
    public class Cuadrado : Figura
    {
        public double Lado;

        public Cuadrado(double l)
        {
            Lado = l;
        }

        public double CalcularArea()
        {
            return Lado * Lado;
        }

        public double CalcularPerimetro()
        {
            return 4 * Lado;
        }
    }

    public class Triangulo : Figura
    {
        public double Base;
        public double Lado2;
        public double Lado3;
        public double Altura;

        public Triangulo(double b, double l2, double l3, double h)
        {
            Base = b;
            Lado2 = l2;
            Lado3 = l3;
            Altura = h;
        }

        public double CalcularArea()
        {
            return (Base * Altura) / 2;
        }

        public double CalcularPerimetro()
        {
            return Base + Lado2 + Lado3;
        }
    }

    public class Circulo : Figura
    {
        public static double Pi = 3.14159265359;
        public double Radio;

        public Circulo(double radio)
        {
            Radio = radio;
        }

        public double CalcularArea()
        {
            return Pi * Radio * Radio;
        }

        public double CalcularPerimetro()
        {
            return 2 * Pi * Radio;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Figura[] figuras = new Figura[]
        {
            new Rectangulo(4, 5),
            new Cuadrado(6),
            new Triangulo(3, 3, 2, 4),
            new Circulo(2.5)
        };

            for (int i = 0; i < figuras.Length; i++)
            {
                Console.WriteLine($"Figura {i + 1}:");
                Console.WriteLine($"Área: {figuras[i].CalcularArea():F2}");
                Console.WriteLine($"Perímetro: {figuras[i].CalcularPerimetro():F2}");
            }
        }
    }
}
