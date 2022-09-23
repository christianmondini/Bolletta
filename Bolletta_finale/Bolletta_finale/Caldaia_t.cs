using System;
using System.Collections.Generic;
using System.Text;

namespace Bolletta_finale
{
    class Caldaia_t:Macchine
    {
        public Caldaia_t()
        {
            this.tipologia_consumo = "Gas'";
            this.costi_aggiuntivi = 1800;
            this.rendimento = 0.9;
            this.nome_macchina = "Caldaia tradizionale";
        }

        public override void Calcola_utilizzo()
        {
            this.utilizzo_annuale = this.consumo_totale / (this.potere_calorifico * this.rendimento);
        }
    }
}
