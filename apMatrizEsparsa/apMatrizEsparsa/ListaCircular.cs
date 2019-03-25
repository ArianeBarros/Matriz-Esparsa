using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apMatrizEsparsa
{
    class ListaCircular
    {
        Celula cabeca, fim, atual, anterior, linhaAtual, colunaAtual;

        int quantosValores;

        int numColunas, numLinhas;

        public ListaCircular(int linhas, int colunas)
        {
            if (linhas < 0)
                throw new Exception("Número de linhas inválido");
            if (colunas < 0)
                throw new Exception("Número de colunas inválido");

            quantosValores = 0;
            numColunas = colunas;
            numLinhas = linhas;

            cabeca = new Celula(-1, -1, null, null, null);
            atual = cabeca;

            for (int i = 0; i < linhas; i++)
            {
                Celula umaLinhaCabeca = new Celula(i, -1, null, null, null);
                atual.Abaixo = umaLinhaCabeca;
                atual = atual.Abaixo;
                atual.Direita = atual;
                
            }
            
            atual.Abaixo = cabeca;

            atual = cabeca;
            for (int i = 0; i < colunas; i++)
            {
                Celula umaLinhaCabeca = new Celula(-1, i, null, null, null);
                atual.Direita = umaLinhaCabeca;
                atual = atual.Direita;
                atual.Abaixo = atual;
                
            }

            atual.Direita = cabeca;
        }

        public void InserirElemento(int linha, int coluna, double? valor)
        {
            if (linha < 0)
                throw new Exception("Index de linhas inválido");
            if (coluna < 0)
                throw new Exception("Index de colunas inválido");

            if (linha > numLinhas)
                throw new Exception("");

            if (coluna > numColunas)
                throw new Exception("");

            linhaAtual = cabeca;
            colunaAtual = cabeca;

            for (int i = -1; i < linha; i++)
                linhaAtual = linhaAtual.Abaixo;

            for(int i = -1; i < coluna; i++)
                colunaAtual = colunaAtual.Direita;

            Celula novaCelula = new Celula(linha, coluna, valor, linhaAtual, colunaAtual);
            if(linhaAtual.Direita != linhaAtual)
                linhaAtual.Direita = novaCelula;
            colunaAtual.Abaixo = novaCelula;
            quantosValores++;

        }

        public int NumColunas
        {
            get => numColunas;
        }

        public int NumLinhas
        {
            get => numLinhas;
        }

        public int QuantosValores
        {
            get => quantosValores;
        }

        public Celula Cabeca
        {
            get => cabeca;
        }

        public Celula Fim
        {
            get => fim;
        }

        public Celula Atual
        {
            get => atual; set => atual = value;
        }

        public Celula Anterior
        {
            get => anterior; set => anterior = value;
        }
    }
}
