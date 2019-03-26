using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace apMatrizEsparsa
{
    class Celula
    {
        int coluna, linha;
        double valor;
        Celula direita, abaixo;

        public Celula(int l, int c, double v, Celula d, Celula a)
        {
            this.linha = l;
            this.coluna = c;
            this.valor = v;
            this.direita = d;
            this.abaixo = a;
        }

        public static Celula LerRegistro(StreamReader arq)
        {

            Celula cel = null;
            //if (!arq.EndOfStream)
            //{
            //    string linha = arq.ReadLine();
            //    cel = new Celula();
            //}

            return cel;
        }

        public int Coluna { get => coluna; }
        public int Linha { get => linha; }
        public double Valor { get => valor; }

        public Celula Direita { get => direita; set => direita = value; }
        public Celula Abaixo { get => abaixo; set => abaixo = value; }
    }
}
