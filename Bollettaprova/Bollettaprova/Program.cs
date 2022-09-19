using System;

namespace Bollettaprova
{
   



        //Mondini Christian 4^F 13/01/2022 Verifica Informatica.



        class Bollettae
        { //Bolletta elettricità
            public double energia;
            public double prezzoe = 0.276;
            public Bollettae(double energia)
            {
                this.energia = energia;
            }

            public double Calcolobollettae()
            {
                return (energia * prezzoe);
            }

        }

        class Bollettag
        {//bolletta gas
            public double gas;
            public double prezzog=1.05;
            public int spese_contatore =96;
            public int spese_oneri=47;
            public int spesa_gas=70;
            public Bollettag(double gas)
            {

            }
           /* public double Calcolobollettag()
            {

            }*/
        }

        class Macchine
        {
            //public string caldaia_condensazione;
            public double rendimento_cc=1;
            //public string caldaia_tradizionale;
            public double rendimento_ct = 0.9;
            //public string stufetta;
            public double rendimento_s = 1;
            //public string pompa_caloreeconomica;
            public double rendimento_pce =2.8;
            //public string pompa_calorebuona;
            public double rendimento_pcb =3.6;

            public Macchine()
            {

            }

        }

        class Program
        {
            static void Main(string[] args)
            {
                int energia;
                int gas;
                Console.WriteLine("Inserisci la quantita' di gas annua utilizzata in smc: ");
                gas = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ora inserisci la quantita' di energia annua utilizzata in KwH: ");
                energia = Convert.ToInt32(Console.ReadLine());
                Bollettae b = new Bollettae(energia);
                Console.WriteLine("La bolletta dell'elettricita' e': {0}", b.Calcolobollettae());
                Console.WriteLine("Attraverso i numeri dicci quali tra questi macchinari possiedi in casa");
                Console.Write("1.Caldaia a condensazione"); Console.Write("2.Caldaia tradizionale"); Console.Write("3.Stufetta"); Console.Write("4.Pompa di calore economica"); Console.Write("5.Pompa di calore buona");

                string scelta = Console.ReadLine();
            switch(scelta)
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
            }
                Console.ReadKey();
            }
        }
}

