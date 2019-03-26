using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace apMatrizEsparsa
{
    class ListaCruzada
    {
        Celula cabeca, acima, esquerda, direita, atual;
        int numLinhas, numColunas;
        int qtd;

        public ListaCruzada(int linhas, int colunas)
        {
            cabeca = new Celula(-1, -1, 0, null, null);
            qtd = 0;
            numLinhas = linhas;
            numColunas = colunas;

            atual = cabeca;
            for(int i = 0; i < linhas; i++)
            {
                Celula novaCelula = new Celula(i, -1, 0, null, null);
                atual.Abaixo = novaCelula;
                atual = novaCelula;
                atual.Direita = atual;
            }
            atual.Abaixo = cabeca;

            atual = cabeca;
            for (int i = 0; i < colunas; i++)
            {
                Celula novaCelula = new Celula(-1, i, 0, null, null);
                atual.Direita = novaCelula;
                atual = novaCelula;
                atual.Abaixo = atual;
            }
            atual.Direita = cabeca;
        }

        public int Qtd { get => qtd;}
        public int NumLinhas { get => numLinhas; }
        public int NumColunas { get => numColunas; }
        public Celula Cabeca { get => cabeca; }
        

        public void InserirElemento(int l, int c, double v)
        {
            if (c < 0 || l < 0)
                throw new Exception("Índice inválido!!");

            Celula novaCelula = new Celula(l, c, v, null, null);
            atual = cabeca;

            for(int i = 0; i < l; i++) //linha
            {
                for (int j = 0; j < c; j++) //coluna
                {
                    esquerda = atual;
                    atual = atual.Direita;
                }
                atual = atual.Abaixo;                
            }

            qtd++;
        }

        public void Listar(DataGridView dgv)
        {

        }
    }

}
