using System;

namespace semaforo
{
    class Program
    {
        static void Main(string[] args)
        {
            Semaforo semaforo = new Semaforo("Rojo");
            semaforo.mostrarColor();
            semaforo.pasoDelTiempo(56);
            semaforo.mostrarColor();
            semaforo.ponerEnIntermitente();
            semaforo.pasoDelTiempo(5);
            semaforo.mostrarColor();
            semaforo.pasoDelTiempo(8);
            semaforo.mostrarColor();
            semaforo.sacarDeIntermitente();
            semaforo.mostrarColor();
        }
    }

    public class Semaforo {
        public string colorActual = "Rojo";
        public bool intermitente = false;
        public int segundos = 0;
        public Semaforo(string colorActual) {
            this.colorActual = colorActual;
            if(colorActual == "Rojo - Amarillo")
                {
                segundos = 30;
                }
            else if (colorActual == "Verde")
            {
                segundos = 32;
            }
            else if (colorActual == "Amarillo")
            {
                segundos = 52;
            }
            else
                segundos = 0;
        }

        public void pasoDelTiempo(int segundos)
        {
            this.segundos = segundos;
        }

        public void mostrarColor() {

            if (!this.intermitente)
            {
                int tiempoNeto = this.segundos % 54;
                if (tiempoNeto < 30)
                {
                    Console.WriteLine("Rojo");
                }
                else if (tiempoNeto < 32)
                {
                    Console.WriteLine("Rojo - Amarillo");
                }
                else if (tiempoNeto < 52)
                {
                    Console.WriteLine("Verde");
                }
                else
                    Console.WriteLine("Amarillo");
            }
            else
            {
                int tiempoNeto = this.segundos % 2;
                if (tiempoNeto == 1)
                {
                    Console.WriteLine("Amarillo");
                }
                else
                    Console.WriteLine("Apagado");
            }
        }

        public void ponerEnIntermitente()
        {
            this.intermitente = true;
        }
        public void sacarDeIntermitente()
        {
            this.intermitente = false;
        }


    }
}
