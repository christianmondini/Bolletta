using System;
using System.Collections.Generic;
using System.Text;

namespace Bolletta_finale
{
    class Caldaia_c:Macchine
    {
        public Caldaia_c()
        {
            this.tipologia_consumo = "Gas'";
            this.costi_aggiuntivi = 1800;
            this.rendimento = 1;
            this.nome_macchina = "Caldaia a condensazione";
        }

        public override void Calcola_utilizzo()
        {
            this.utilizzo_annuale = this.consumo_totale / (this.potere_calorifico * this.rendimento);
        }
    }
}
