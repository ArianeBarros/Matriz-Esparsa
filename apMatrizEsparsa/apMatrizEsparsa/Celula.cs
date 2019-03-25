using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apMatrizEsparsa
{
    class Celula
    {
        int coluna, linha;
        double valor;

        public Celula(int l, int c, double v)
        {
            this.linha = l;
            this.coluna = c;
            this.valor = v;
        }

        public int Coluna { get => coluna; }
        public int Linha { get => linha; }
        public double Valor { get => valor; }
    }
}
