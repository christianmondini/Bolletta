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
        private static double spesa_tot_materia=0;

        //Istanze di classi utili per trovare lo strumento più conveniente
        private static Macchine riscaldamento = new Macchine();
        private static Macchine riscaldamento_scelto = new Macchine();

        //liste e matrice per controllo dati
        private static List<object> riscaldamenti;//Lista per contenere le macchine da confrontare
        private static string[] nomi_macchine = new string[5];//array per nomi delle macchine
        private static double[] bollette = new double[5];//array che conterrà i nome delle macchine e le bollette che ognuna provoca 

        

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

        public static void Tutte_bollette(double smc, double kwh,string nome_macchina)
        {
            int i = 0; 
          foreach(Macchine riscaldamento in riscaldamenti)
            {
                Bolletta bolletta = new Bolletta();
                double bollettone=0;

                if (riscaldamento.Get_tipologia_consumo() == "Gas")
                {
                    riscaldamento.Set_costo_gas();
                    riscaldamento.Set_consumo(smc);
                    riscaldamento.Calcola_utilizzo(kwh);
                }
                else if(riscaldamento.Get_tipologia_consumo() == "Elettricita")
                {
                    riscaldamento.Set_costo_elettricità();
                    riscaldamento.Set_consumo(kwh);
                    riscaldamento.Calcola_utilizzo(smc);

                }

                riscaldamento.Calcola_costo_totale();//spesa totale materia
                spesa_tot_materia = riscaldamento.costo_totale;//spesa totale provocata dal macchinario
                bolletta.Set_spesa_materia(spesa_tot_materia);//Passo alla classe bolletta la spesa totale provocata dal macchinario
                bolletta.Calcolo_bolletta2();//calcolo bolletta senza costi aggiuntivi
                
                string nome = riscaldamento.Get_nome();//prendo il nome
                bolletta.Set_nome(nome);//setto il nome all'interno della classe bolletta
                
               if(nome==nome_macchina){
                bollettone= bolletta.tot_bolletta2*10;
                string info_bolletta=bolletta.informazioni_bolletta();
                Console.WriteLine(info_bolletta);
                nomi_macchine[i] =nome;
                bollette[i] = bollettone;
                 i++;
                }else{
                   
                double costi_aggiuntivi = riscaldamento.Get_costi_aggiuntivi();//trovo costi aggiuntivi
                bolletta.Calcolo_bolletta1(costi_aggiuntivi);//Calcolo la bolletta con costi aggiuntivi pk è una macchina non posseduta dall'utente
                
                Console.WriteLine(bolletta);
                bollettone =bolletta.tot_bolletta1+(bolletta.tot_bolletta2*9);//calcolo l'andamento della bolletta nel corso di 10 anni
                //Ed ora dopo aver calcolato le bollette per ogni macchina non posseduta dall'utente le vado ad inserire nell'array per compararle e vedere quale fa risparmiare di più
                
                 nomi_macchine[i] =nome;
                 bollette[i] = bollettone;
                 i++;
                
                }
              
                
                
            }
        }

        public static string Controllo_migliore()
        {
          
            int contenitore=0;
            double min;
            min = bollette[0];
            for (int i = 0; i < bollette.Length; i++)
            {
                if (min > bollette[i])
                {
                    min = bollette[i];
                    contenitore = i;
                }
                   
            }
            return nomi_macchine[contenitore];

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
            switch (scelta)
            {
                case 1:
                    riscaldamento_scelto=caldaia_t;
                    riscaldamenti = new List<object>() { caldaia_c,caldaia_t, stufa, pompa_e, pompa_bl };
                    break;
                case 2:
                    riscaldamento_scelto=caldaia_c;
                    riscaldamenti = new List<object>() { caldaia_c, caldaia_t, stufa, pompa_e, pompa_bl };
                    break;
                case 3:
                    riscaldamento_scelto=stufa;
                    riscaldamenti = new List<object>() { caldaia_c, caldaia_t, stufa, pompa_e, pompa_bl };
                    break;
                case 4:
                    riscaldamento_scelto=pompa_e;
                    riscaldamenti = new List<object>() { caldaia_c, caldaia_t, stufa, pompa_e, pompa_bl };
                    break;
                case 5:
                    riscaldamento_scelto=pompa_bl;
                    riscaldamenti = new List<object>() { caldaia_c, caldaia_t, stufa, pompa_e, pompa_bl };
                    break;
            }

            if (riscaldamento_scelto.Get_tipologia_consumo() == "Gas")
            {
                riscaldamento_scelto.Set_costo_gas();
                riscaldamento_scelto.Set_consumo(smc);
                riscaldamento_scelto.Calcola_utilizzo(kwh);
            }
            else if(riscaldamento_scelto.Get_tipologia_consumo() == "Elettricita")
            {
                riscaldamento_scelto.Set_costo_elettricità();
                riscaldamento_scelto.Set_consumo(kwh);
                riscaldamento_scelto.Calcola_utilizzo(smc);

            }

            //Istanza Bolletta
            Bolletta bolletta = new Bolletta();
            riscaldamento_scelto.Calcola_costo_totale();//spesa totale materia
            spesa_tot_materia = riscaldamento_scelto.costo_totale;//spesa totale provocata dal macchinario posseduta dall'utente
            bolletta.Set_spesa_materia(spesa_tot_materia);//Passo alla classe bolletta la spesa totale provocata dal macchinario
            bolletta.Calcolo_bolletta2();//Calcolo la bolletta senza costi aggiuntivi pk la macchina è già posseduta dall'utente

            
            string nome=riscaldamento_scelto.Get_nome();
            bolletta.Set_nome(nome);
            string info_bolletta = bolletta.Informazioni_bolletta();
            Console.WriteLine(info_bolletta);
            //Adesso calcolo le bollette con tutti i macchinari per i prossimi 10 anni e vedo la più conveniente
            Tutte_bollette(smc,kwh,nome);
            string considerazione = Controllo_migliore();
            if (considerazione == nome)
            {
                Console.WriteLine("Hai già un ottimo impianto di riscaldamento");
            }
            else
            {
                Console.WriteLine($"La miglior macchina per risparmiare sulla bolletta nei prossimi dieci anni è {considerazione}");
            }
           

            Console.ReadKey();
        }
    }
}
