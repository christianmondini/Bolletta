using System;
using System.Collections.Generic;
using System.Text;

namespace Bolletta_finale
{
    class Caldaia_t:Macchine
    {
        public Caldaia_t()
        {
            this.tipologia_consumo = "Gas";
            this.costi_aggiuntivi = 1800;
            this.rendimento = 0.9;
            this.nome_macchina = "Caldaia tradizionale";
        }

        public override void Calcola_utilizzo(double consumo)
        {
            this.utilizzo_annuale = consumo / (this.potere_calorifico * this.rendimento);
        }
    }
}
