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
            if (!arq.EndOfStream)
            {
                string linha = arq.ReadLine();
                string[] conteudo = linha.Split(',');
                cel = new Celula(int.Parse(conteudo[0]), int.Parse(conteudo[1]), double.Parse(conteudo[2]), null, null);
                if (conteudo.Length == 4)
                {
                    double inteiro = double.Parse(conteudo[2]);
                    int dec = int.Parse(conteudo[3]);
                    if (inteiro < 0)
                        cel.Valor -= (dec * 0.1);
                    else
                        cel.valor += (dec * 0.1);
                }
                    
            }

            return cel;
        }

        public int Coluna { get => coluna; }
        public int Linha { get => linha; }
        public double Valor { get => valor; set => valor = value; }

        public Celula Direita { get => direita; set => direita = value; }
        public Celula Abaixo { get => abaixo; set => abaixo = value; }
    }
}
