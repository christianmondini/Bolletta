using System;
using System.Collections.Generic;
using System.Text;

namespace Bolletta_finale
{
    class Bolletta
    {
        protected int gestione_contatore;
        protected int oneri_sistema;
        protected int spesa_fissa;//qvd gas o pcv per energia elettrica
        protected double spesa_tot_materia;
        public double tot_bolletta1;//bolletta di quando si compra anche la macchina
        public double tot_bolletta2;//bolletta normale degli annni seguenti
        protected string macchina_nome;

        public Bolletta()
        {
            this.gestione_contatore = 96;
            this.oneri_sistema = 47;
            this.spesa_fissa = 70;
        }
        //Funzioni Get

        public double Get_bolletta2()
        {
            return this.tot_bolletta2;
        }
        //Funzioni Set
        public void Set_spesa_materia(double materia)
        {
            this.spesa_tot_materia = materia;
        }

        public void Set_nome(string nome)
        {
            this.macchina_nome =nome;
        }
        //Funzioni calcoli
        public void Calcolo_bolletta1(double costi_aggiuntivi)
        {
            this.tot_bolletta1 = tot_bolletta2 + costi_aggiuntivi;
        }

        public void Calcolo_bolletta2()
        {
            this.tot_bolletta2 = this.spesa_tot_materia + this.gestione_contatore + this.oneri_sistema + this.spesa_fissa;
        }
        
        //Funzione ToString

        public override string ToString()
        {
            return $"Con {this.macchina_nome} la bolletta il primo anno considerando le spese d'installazione sara' di {Math.Round(this.tot_bolletta1,2)} £, mentre dall'anno seguente sarà di {Math.Round(this.tot_bolletta2,2)} £ ";
        }

        public string Informazioni_bolletta()
        {
            return $"La bolletta con {this.macchina_nome} e' di {Math.Round(this.tot_bolletta2,2)} £";
        }
    }
}
