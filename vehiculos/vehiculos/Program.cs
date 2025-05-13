using System;

namespace vehiculos
{
    class Program
    {
        public interface IVehiculo
        {
            int velocidadMaxima { get; set; }
            int posicion { get; set; }
            void mover(int tiempo);
            int getPosicion();
            void reiniciarPosicion();

        }

        public class Bicicleta : IVehiculo
        {
            public int velocidadMaxima { get; set; }
            public int posicion { get; set; }
            public Bicicleta()
            {
                velocidadMaxima = 10;
                posicion = 0;
            }

            public void mover(int tiempo)
            {
                posicion += tiempo * velocidadMaxima;
            }

            public int getPosicion()
            {
                return posicion;
            }

            public void reiniciarPosicion ()
            {
                posicion = 0;
            }
        }

        public class Auto : IVehiculo
        {
            public int velocidadMaxima { get; set; }
            public int posicion { get; set; }
            public Auto()
            {
                this.velocidadMaxima = velocidadMaxima;
                this.posicion = 0;
            }

            public Auto(int velocidadMaxima)
            {
                this.velocidadMaxima = velocidadMaxima;
                this.posicion = 0;
            }

            public void mover(int tiempo)
            {
                posicion += tiempo * velocidadMaxima;
            }

            public int getPosicion()
            {
                return posicion;
            }

            public void reiniciarPosicion()
            {
                posicion = 0;
            }
        }

        public class Camion : IVehiculo
        {
            public int velocidadMaxima { get; set; }
            public int posicion { get; set; }
            public Camion()
            {
                velocidadMaxima = 30;
                posicion = 0;
            }

            public void mover(int tiempo)
            {
                posicion += tiempo * velocidadMaxima;
            }

            public int getPosicion()
            {
                return posicion;
            }

            public void reiniciarPosicion()
            {
                posicion = 0;
            }
        }

        public class Carrera
        {
            private IVehiculo v1;
            private IVehiculo v2;

            public Carrera (IVehiculo v1, IVehiculo v2)
            {
                this.v1 = v1;
                this.v2 = v2;
            }

            public void correr(int tiempo)
            {
                v1.reiniciarPosicion();
                v2.reiniciarPosicion();
                v1.mover(tiempo);
                v2.mover(tiempo);
                Console.WriteLine("Termino la carrera!!!!");
                Console.WriteLine($"El primer vehiculo viajó {v1.getPosicion()}");
                Console.WriteLine($"El segundo vehiculo viajó {v2.getPosicion()}");
            }
        }

        static void Main(string[] args)
        {
            Auto tesla = new Auto(40);
            Bicicleta bici = new Bicicleta();
            Camion cami = new Camion();
            bici.mover(20);
            Console.WriteLine(bici.getPosicion());
            bici.mover(10);
            Console.WriteLine(bici.getPosicion());

            Carrera carry = new Carrera(bici, tesla);
            carry.correr(50);
        }
    }
}
