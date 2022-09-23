using System;
using System.Collections.Generic;
using System.Text;

namespace Bolletta_finale
{
    class Pompa_bl:Macchine
    {
        public Pompa_bl()
        {
            this.tipologia_consumo = "Elettricita";
            this.costi_aggiuntivi = 3250;
            this.rendimento = 3.6;
            this.nome_macchina = "Pompa di buon livello";
        }

        public override void Calcola_utilizzo(double consumo)
        {
            this.utilizzo_annuale = consumo * (this.potere_calorifico / this.rendimento);
        }
    }
}
