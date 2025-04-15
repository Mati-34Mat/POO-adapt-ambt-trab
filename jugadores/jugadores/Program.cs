using System;

namespace Figuras
{
    class Program
    {
        interface Jugador
        {
            bool correr(int minutos);
            bool cansado();
            void descansar(int minutos);
        }

        public class Amateur : Jugador
        {
            public int tiempoCorrido = 0;
            public int limite = 20;

            public bool correr(int minutos)
            {
                tiempoCorrido += minutos;
                if (tiempoCorrido > limite)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            public bool cansado()
            {
                if (tiempoCorrido > limite)
                    return true;
                else
                    return false;
            }

            public void descansar(int minutos)
            {
                if (tiempoCorrido >= minutos)
                {
                    tiempoCorrido -= minutos;
                }
            }
        }

        public class Profesional : Jugador
        {
            public int tiempoCorrido = 0;
            public int limite = 40;
            public bool correr(int minutos)
            {
                tiempoCorrido += minutos;
                if (tiempoCorrido > limite)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

            public bool cansado()
            {
                if (tiempoCorrido > limite)
                    return true;
                else
                    return false;
            }

            public void descansar(int minutos)
            {
                if (tiempoCorrido >= minutos)
                {
                    tiempoCorrido -= minutos;
                }
            }
        }

        static void Main(string[] args)
        {
            Jugador jugadorPro = new Profesional();
            Jugador jugadorNoob = new Amateur();

            jugadorPro.correr(30);
            Console.WriteLine("Profesional corre 30 minutos.");
            Console.WriteLine("¿Está cansado? " + (jugadorPro.cansado() ? "Sí" : "No"));

            jugadorNoob.correr(25);
            Console.WriteLine("Amateur corre 25 minutos.");
            Console.WriteLine("¿Está cansado? " + (jugadorNoob.cansado() ? "Sí" : "No"));

            jugadorNoob.descansar(10);
            Console.WriteLine("Después de descansar 10 minutos, ¿se cansa si corrriera 10 más? " + (jugadorNoob.correr(10) ? "Sí" : "No"));
        }
    }
}
