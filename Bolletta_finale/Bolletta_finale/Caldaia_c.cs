using System;
using System.Collections.Generic;
using System.Text;

namespace Bolletta_finale
{
    class Caldaia_c:Macchine
    {
        public Caldaia_c()
        {
            this.tipologia_consumo = "Gas";
            this.costi_aggiuntivi = 2000;
            this.rendimento = 1;
            this.nome_macchina = "Caldaia a condensazione";
        }

        public override void Calcola_utilizzo(double consumo)
        {
            this.utilizzo_annuale = consumo / (this.potere_calorifico * this.rendimento);
        }
    }
}
