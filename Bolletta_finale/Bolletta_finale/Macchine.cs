using System;
using System.Collections.Generic;
using System.Text;

namespace Bolletta_finale
{
    class Macchine
    {
        public double potere_calorifico;//Per passare da smc a KWh
        protected double rendimento;//il rendimento della macchina
        protected string tipologia_consumo;//Gas o Energia elettrica
        protected double costo_elettricità;//Costo dell'elettricità al KWh
        protected double costo_gas;//Costo del gas al smc
        protected double costi_aggiuntivi;//costo per l'installazione e costo della macchina
        protected double consumo_totale;//Consumo totale dell'utente annuale
        public double costo_totale;//costo toale annuale in base al consumo
        protected double utilizzo_annuale;//Totale utilizzato dalla macchina che si utilizza
        protected double costo_materia;//Il costo della materia utilizzata dalla macchina quindi o gas o energia elettrica
        public string nome_macchina;
       

        public Macchine()
        {
            this.potere_calorifico = 10.7;//per trasformare smc in Kwh, in quanto 1smc equivale a 10,7 KWh
            this.costo_elettricità = 0.276;//Prezzo attuale energia elettrica
            this.costo_gas = 1.05;//Prezzo attuale gas
        }
        //Funzioni Get
        public string Get_tipologia_consumo()//se si tratta di elettricità o gas
        {
            return this.tipologia_consumo;
        }

        public double Get_costi_aggiuntivi()
        {
            return this.costi_aggiuntivi;
        }

        public double Get_costo_totale()
        {
            return this.costo_totale;
        }

        public string Get_nome()
        {
            return this.nome_macchina;
        }

        //Funzioni Set
       
        public void Set_costo_elettricità()
        {
            this.costo_materia = this.costo_elettricità;
        }
        public void Set_costo_gas()
        {
            this.costo_materia = this.costo_gas;
        }

        public void Set_consumo(double consumo)
        {
            this.consumo_totale = consumo;
        }

        //Funzioni di calcolo 
        public virtual void Calcola_utilizzo()
        {
        }

        public void Calcola_costo_totale()
        {
            this.costo_totale = this.costo_materia * (this.consumo_totale + this.utilizzo_annuale);
        }
        //Funzione ToString
        public override string ToString()
        {
            return $"I costi per l'acquisto e l'installazione della macchina sono{this.costi_aggiuntivi}€, l'utilizzo annuale e'{this.utilizzo_annuale} e il rendimento e' {this.rendimento}";
        }
    }
}
