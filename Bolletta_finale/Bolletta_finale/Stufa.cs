using System;
using System.Collections.Generic;
using System.Text;

namespace Bolletta_finale
{
    class Stufa : Macchine
    {
        public Stufa()
        {
            this.tipologia_consumo = "Elettricita'";
            this.costi_aggiuntivi = 400;
            this.rendimento = 1;
            this.nome_macchina = "Stufa";
        }

        public override void Calcola_utilizzo()
        {
            this.utilizzo_annuale = this.consumo_totale * (this.potere_calorifico / this.rendimento);
        }
    }
}
