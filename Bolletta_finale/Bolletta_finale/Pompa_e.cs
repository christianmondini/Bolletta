using System;
using System.Collections.Generic;
using System.Text;

namespace Bolletta_finale
{
    class Pompa_e:Macchine
    {
        public Pompa_e()
        {
            this.tipologia_consumo = "Elettricita'";
            this.costi_aggiuntivi = 1250;
            this.rendimento = 2.8;
            this.nome_macchina = "Pompa economica";
        }

        public override void Calcola_utilizzo()
        {
            this.utilizzo_annuale = this.consumo_totale * (this.potere_calorifico / this.rendimento);
        }
    }
}
