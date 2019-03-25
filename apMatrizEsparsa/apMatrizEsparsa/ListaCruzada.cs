using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apMatrizEsparsa
{
    class ListaCruzada
    {
        Celula cabeca;

        int qtd;

        public ListaCruzada(int num)
        {
            qtd = num;

            for(int i = 0; i < qtd; i++)
            {
                Celula novaCelula = new Celula();
            }
        }
        

    }

}
