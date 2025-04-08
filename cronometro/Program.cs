using System;



namespace silla {
    class Program {
        static void Main(string[] args) {
            Cronometro cronometro = new Cronometro(3, 59);
            cronometro.mostrarTiempo();
            cronometro.incrementarTiempo();
            cronometro.mostrarTiempo();
            cronometro.reiniciarTiempo();
            cronometro.mostrarTiempo();
        }
    }
    public class Cronometro
    {
        public int segundos = 0;
        public int minutos = 0;

        public Cronometro(int minutos, int segundos)
        {
            this.segundos = segundos;
            this.minutos = minutos;
        }

        public void reiniciarTiempo() {
            this.segundos = 0;
            this.minutos = 0;
        }

        public void incrementarTiempo() {
            this.segundos += 1;
            if(this.segundos == 60)
            {
                this.segundos = 0;
                this.minutos += 1;
            }
        }

        public void mostrarTiempo() {
            Console.WriteLine("Pasaron " + this.minutos + " minutos y " + this.segundos + " segundos");
        }
    }
}