using System;

namespace Bollettaprova
{




    //Mondini Christian 4^F 13/01/2022 Verifica Informatica.



    /*class Bollettae
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
       public double Calcolobollettag()
        {

        }
    }*/
    class Materia
    {
        protected double costo_materia, qvd, spesa_trasporto, oneri;
        //protected internal double 

        public Materia(double costo)
        {
            costo_materia = costo;
            qvd = 70;
            spesa_trasporto = 8;
            oneri = 47;
        }

        public virtual double Costo_tot_bolletta(double consumo)
        {
            double costo = costo_materia * consumo + qvd + spesa_trasporto * 12 + oneri;
            return costo;
        }
    }

    class Scelta
    {
        protected int selezione;
        protected double kWh, Smc;
        public Scelta(int selezione)
        {
            this.selezione = selezione;
        }
        public double Bolletta()
        {
            double value = 0;
            if (selezione == 1)
            {
                Caldaia caldaia_cond = new Caldaia(1, (1500 + 300));
                value = caldaia_cond.costo_tot;
                return value;
            }
            else if (selezione == 2)
            {
                Caldaia caldaia_trad = new Caldaia(0.9, (1500 + 300));
                value = caldaia_trad.costo_tot;
                return value;
            }
            else if(selezione == 3)
            {
                Elettrico stufa = new Elettrico(1, (600 + 250));
                value = stufa.costo_tot;
                return value;
            }
            else if(selezione == 4)
            {
                Elettrico pompa_buona = new Elettrico(3.6, (3000 + 250));
                value = pompa_buona.costo_tot;
                return value;
            }
            else
            {
                Elettrico pompa_economica = new Elettrico(2.8, (1000 + 250));
                value = pompa_economica.costo_tot;
                return value;
            }

        }

        /*public void Scelta_Macchinario()
        {
            double value=0;
             Caldaia caldaia_cond = new Caldaia(1, (1500 + 300));
             Caldaia caldaia_trad = new Caldaia(0.9, (1500 + 300));
             Elettrico stufa = new Elettrico(1, (600 + 250));
             Elettrico pompa_buonlv = new Elettrico(3.6, (3000 + 250));
             Elettrico pompa_cheap = new Elettrico(2.8, (1000 + 250));
        }*/

    }


    class Macchina
        {
        //protected double rendimento, costo_tot, consumo, prezzo;
        protected double rendimento, consumo, prezzo;
        public double costo_tot;
        //public Macchina(double rendimento, double prezzo, double consumo, double costo_tot)
        public Macchina(double rendimento, double prezzo)
        {
            this.rendimento = rendimento;
            this.prezzo = prezzo;
            consumo = 0;
            costo_tot = 0;
            }
        public virtual void Calcola_Consumo(double elettricita_utilizzata, double gas_consumato, double potere_calorifero)
        {
            consumo = 0;
        }

        public virtual void Costo_Totale(Materia materia)
        {
            costo_tot = materia.Costo_tot_bolletta(consumo) + prezzo;

        }
        /*public virtual double GetPrezzo()
        {
            return prezzo;
        }*/
        /*public override string ToString()
        {
            string frase = rendimento + " e' il rendimento," + prezzo + " e' il costo di installazione e della macchina";
            return (frase);
        }*/

    }
    class Caldaia : Macchina
    {
        //public 
        public Caldaia(double rendimento, double costo_Iniziale) : base(rendimento, costo_Iniziale)
        {
            this.rendimento = rendimento;
            prezzo = costo_Iniziale;
            consumo = 0;
            costo_tot = 0;
        }

        public override void Calcola_Consumo(double kWh, double Smc, double potere_calorifero)
        {
            consumo = kWh / (potere_calorifero * rendimento) + Smc;
        }
        public override void Costo_Totale(Materia materia)
        {
            base.Costo_Totale(materia);
        }

    }

    class Elettrico : Macchina
    {
        public Elettrico(double rendimento, double costo_init) : base(rendimento, costo_init)
        {
            this.rendimento = rendimento;
            prezzo = costo_init;
            consumo = 0;
            costo_tot = 0;
        }

        public override void Calcola_Consumo(double elettricita_utilizzata, double gas_consumato, double potere_calorifero)
        {
            consumo = (gas_consumato * potere_calorifero / rendimento)+elettricita_utilizzata;
        }
        public override void Costo_Totale(Materia materia)
        {
            base.Costo_Totale(materia);
        }
    }

    class Program
        {
            static void Main(string[] args)
            {
                //int energia;
                //int gas;
                int scelta = 0;
                int i = 0;
                /*Console.WriteLine("Inserisci la quantita' di gas annua utilizzata in smc: ");
                gas = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ora inserisci la quantita' di energia annua utilizzata in KwH: ");
                energia = Convert.ToInt32(Console.ReadLine());
                Bollettae b = new Bollettae(energia);
                Console.WriteLine("La bolletta dell'elettricita' e': {0}", b.Calcolobollettae());*/
                do {
                    Console.WriteLine("Attraverso i numeri dicci quali tra questi macchinari possiedi in casa:");
                    Console.Write("1.Caldaia a condensazione\n"); Console.Write("2.Caldaia tradizionale\n"); Console.Write("3.Stufetta\n"); Console.Write("4.Pompa di calore economica\n"); Console.Write("5.Pompa di calore buona\n");

                    scelta = Convert.ToInt32(Console.ReadLine());

                    if (scelta != 1 & scelta!=2 & scelta!=3 & scelta !=4 & scelta!=5)
                    {
                        i = 0;
                    }
                    else
                    {
                        i = 1;
                    }
                } while (i==0);

                Scelta s = new Scelta(scelta);
                double bolletta = s.Bolletta();
                Console.WriteLine("La tua bolletta e' di: {0}",bolletta);
         
                Console.ReadKey();
            }
        }
}

