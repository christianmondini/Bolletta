using System;
using System.Collections.Generic;

namespace Bolletta_finale
{
    //Mondini Christian 4^F 13/01/2022 Informatica Prova d'ingresso.


    class Program
    {

        //Informazioni da far settare all'utente e variabili per il controllo della validità dei dati inseriti dall'utente
        private static int scelta;
        private static string valorescelta = "";
        private static bool controllo = false;
        private static double kwh = 0, smc = 0;//consumo annuale dell'utente
        private static double consumokwh = 0, consumosmc = 0;//consumo totale reale
        private static double spesa_tot_materia=0;

        //Istanze di classi utili per trovare lo strumento più conveniente
        private static Macchine riscaldamento = new Macchine();
        private static Macchine riscaldamaento_scelto = new Macchine();

        //liste e matrice per controllo dati
        private static List<object> riscaldamenti;//Lista per contenere le macchine da confrontare
        private static string[] nomi_macchine = new string[5];//array per nomi delle macchine
        private static double[] bollette = new double[5];//array che conterrà i nome delle macchine e le bollette che ognuna provoca 

        //Istanza Bolletta
        protected static Bolletta bolletta = new Bolletta();

        static int Scelta(int s)
        {
            do
            {
                Console.WriteLine("Scegli quale strumenti possiedi:\n" + "1)Caldaia tradizionale\n" + "2)Caldaia a condensazione\n" + "3)Stufa\n" + "4)Pompa di calore economica\n" + "5)Pompa di calore di buon livello\n");
                valorescelta = Console.ReadLine();
                controllo = int.TryParse(valorescelta, out scelta);//Controllo validità valore inserito da tastiera
            } while (scelta != 1 & scelta != 2 & scelta != 3 & scelta != 4 & scelta != 5 || controllo == false);//Ripeto finchè il valore inserito non è valido
            return s;
        }


        static double SetGas(double gas)
        {
            do
            {
                Console.WriteLine("Inserisci quanti smc di gas sfrutti all'anno");
                valorescelta = Console.ReadLine();
                controllo = double.TryParse(valorescelta, out smc);//Controllo validità valore inserito da tastiera
            } while (smc < 0 || controllo == false);//Ripeto finchè il valore inserito non è valido
            return gas;
        }

        static double SetKwh(double kwh)
        {
            do
            {
                Console.WriteLine("Inserisci quanti KWh sfrutti all'anno");
                valorescelta = Console.ReadLine();
                controllo = double.TryParse(valorescelta, out kwh);//Controllo validità valore inserito da tastiera
            } while (kwh < 0 || controllo == false);//Ripeto finchè il valore inserito non è valido
            return kwh;
        }

        public static void Tutte_bollette()
        {
            int i = 0; ;
          foreach(Macchine riscaldamento in riscaldamenti)
            {

                if (riscaldamento.Get_tipologia_consumo() == "gas")
                {
                    riscaldamento.Set_costo_gas();
                    riscaldamento.Set_consumo(smc);
                    riscaldamento.Calcola_utilizzo();
                }
                else
                {
                    riscaldamento.Set_costo_elettricità();
                    riscaldamento.Set_consumo(kwh);
                    riscaldamento.Calcola_utilizzo();

                }

                spesa_tot_materia = riscaldamaento_scelto.costo_totale;//spesa totale provocata dal macchinario
                bolletta.Set_spesa_materia(spesa_tot_materia);//Passo alla classe bolletta la spesa totale provocata dal macchinario
                bolletta.Calcolo_bolletta2();
                double costi_aggiuntivi = riscaldamento.Get_costi_aggiuntivi();
                bolletta.Calcolo_bolletta1(costi_aggiuntivi);//Calcolo la bolletta con costi aggiuntivi pk è una macchina non posseduta dall'utente
                bolletta.Calcolo_bolletta_anni();
                //Console.WriteLine(bolletta);

                //Ed ora dopo aver calcolato le bollette per ogni macchina non posseduta dall'utente le vado ad inserire nell'array per compararle e vedere quale fa risparmiare di più
                
                 nomi_macchine[i] =riscaldamento.Get_nome();
                 bollette[i] = bolletta.bolletta_anni;
                 i++;
                
            }
        }

        public static string Controllo_migliore()
        {
            int economica=0;
            for(int i = 0; i <= 5; i++)
            {
                for(int j = 1; j <= 5; j++)
                {
                    if (bollette[i]>bollette[j])
                    {
                        economica = j;
                    }
                    else
                    {
                        economica = i;
                    }
                   
                }
            }

            return nomi_macchine[economica];
            
        }

        static void Main(string[] args)
        {
           
            //Istanzo tutte le classi
            Caldaia_c caldaia_c = new Caldaia_c();
            Caldaia_t caldaia_t = new Caldaia_t();
            Pompa_e pompa_e = new Pompa_e();
            Pompa_bl pompa_bl = new Pompa_bl();
            Stufa stufa = new Stufa();
            //Faccio inserire informazioni base per il calcolo della bolletta all'utente
            SetGas(smc);
            SetKwh(kwh);
            //L'utente sceglie lo strumente che possiede al momento
            Scelta(scelta);
            Console.WriteLine($"La tua scelta e' {scelta}");
            /*consumosmc = (kwh / riscaldamento.potere_calorifico) + smc;
            consumokwh = (smc * riscaldamento.potere_calorifico) + kwh;*/
            switch (scelta)
            {
                case 1:
                    riscaldamaento_scelto = caldaia_t;
                    riscaldamenti = new List<object>() { caldaia_c,caldaia_t, stufa, pompa_e, pompa_bl };
                    break;
                case 2:
                    riscaldamaento_scelto = caldaia_c;
                    riscaldamenti = new List<object>() { caldaia_c, caldaia_t, stufa, pompa_e, pompa_bl };
                    break;
                case 3:
                    riscaldamaento_scelto = stufa;
                    riscaldamenti = new List<object>() { caldaia_c, caldaia_t, stufa, pompa_e, pompa_bl };
                    break;
                case 4:
                    riscaldamaento_scelto =pompa_e;
                    riscaldamenti = new List<object>() { caldaia_c, caldaia_t, stufa, pompa_e, pompa_bl };
                    break;
                case 5:
                    riscaldamaento_scelto = pompa_bl;
                    riscaldamenti = new List<object>() { caldaia_c, caldaia_t, stufa, pompa_e, pompa_bl };
                    break;
            }

            if (riscaldamaento_scelto.Get_tipologia_consumo() == "gas")
            {
                riscaldamaento_scelto.Set_costo_gas();
                riscaldamaento_scelto.Set_consumo(smc);
                riscaldamaento_scelto.Calcola_utilizzo();
            }
            else
            {
                riscaldamaento_scelto.Set_costo_elettricità();
                riscaldamaento_scelto.Set_consumo(kwh);
                riscaldamaento_scelto.Calcola_utilizzo();

            }

            spesa_tot_materia = riscaldamaento_scelto.costo_totale;//spesa totale provocata dal macchinario posseduta dall'utente
            bolletta.Set_spesa_materia(spesa_tot_materia);//Passo alla classe bolletta la spesa totale provocata dal macchinario
            bolletta.Calcolo_bolletta2();//Calcolo la bolletta senza costi aggiuntivi pk la macchina è già posseduta dall'utente

            string info_bolletta=bolletta.Informazioni_bolletta();
            Console.WriteLine(info_bolletta);
            Tutte_bollette();
            string considerazione = Controllo_migliore();
            Console.WriteLine($"La miglior macchina per risparmiare sulla bolletta è {considerazione}");

            Console.ReadKey();
        }
    }
}
