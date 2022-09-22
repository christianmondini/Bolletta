using System;

namespace Bollettaprova
{


    //Mondini Christian 4^F 13/01/2022 Informatica Prova d'ingresso.


    class Program
        {


        private static int scelta;
        private static string valorescelta = "";
        private static bool controllo = false;
        private static double KWh = 2700, Smc = 1300, totKWh, totSmc;

        static int Scelta(int s)
        {
            do
            {
                Console.WriteLine("Scegli quale strumenti possiedi:\n" + "1)Caldaia tradizionale\n" + "2)Caldaia a condensazione\n" + "3)Stufa\n" + "4)Pompa di calore economica\n" + "5)Pompa di calore di buon livello\n");
                valorescelta = Console.ReadLine();
                controllo=int.TryParse(valorescelta,out scelta);//Controllo validità valore inserito da tastiera
            } while (scelta!=1 & scelta!=2 & scelta!=3 & scelta!=4 & scelta!=5 || controllo==false);//Ripeto finchè il valore inserito non è valido
            return s;
        }
        static void Main(string[] args)
            {
                Scelta(scelta);
                Console.WriteLine($"La tua scelta e' {scelta}");
         
                Console.ReadKey();
            }
        }
}

