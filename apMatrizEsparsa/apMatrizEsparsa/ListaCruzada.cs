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
        public const int INICIOCABECA = -1;
        Celula cabeca, atualLinha, atualColuna, anteriorLinha, anteriorColuna;
        int numLinhas, numColunas;
        int qtd;

        public ListaCruzada()
        {
            cabeca = new Celula(INICIOCABECA, INICIOCABECA, 0, null, null); ;
            qtd = 0;
        }
        public ListaCruzada(int linhas, int colunas)
        {
            cabeca = new Celula(INICIOCABECA, INICIOCABECA, 0, null, null);
            qtd = 0;
            numLinhas = linhas;
            numColunas = colunas;

            Celula atual = cabeca;
            for (int i = 0; i < linhas; i++)
            {
                Celula novaCelula = new Celula(i, INICIOCABECA, 0, null, null);
                atual.Abaixo = novaCelula;
                atual = novaCelula;
                atual.Direita = atual;
            }
            atual.Abaixo = cabeca;

            atual = cabeca;
            for (int i = 0; i < colunas; i++)
            {
                Celula novaCelula = new Celula(INICIOCABECA, i, 0, null, null);
                atual.Direita = novaCelula;
                atual = novaCelula;
                atual.Abaixo = atual;
            }
            atual.Direita = cabeca;
        }


        public int Qtd { get => qtd; }
        public int NumLinhas { get => numLinhas; }
        public int NumColunas { get => numColunas; }
        public Celula Cabeca { get => cabeca; }

        public void InserirElemento(int l, int c, double v)
        {
            if (v == 0)
                return; // arrumar

            if (Existe(l, c))
                atualColuna.Abaixo.Valor = v;
            else
            {
                Celula novaCelula = new Celula(l, c, v, null, null);

                novaCelula.Abaixo = atualColuna.Abaixo;
                atualColuna.Abaixo = novaCelula;

                novaCelula.Direita = atualLinha.Direita;
                atualLinha.Direita = novaCelula;

                qtd++;
            }
        }
        public double ValorDe(int l, int c)
        {
            if (Existe(l, c))
                return atualColuna.Abaixo.Valor;
            else
                return 0;
        }
        public bool Existe(int l, int c)
        {
            atualLinha = cabeca;
            atualColuna = cabeca;
            anteriorLinha = cabeca;
            anteriorColuna = cabeca;

            while (atualLinha.Linha < l && atualLinha.Abaixo != atualLinha)
            {
                anteriorLinha = atualLinha;
                atualLinha = atualLinha.Abaixo;
            }

            while (atualLinha.Direita.Coluna < c && atualLinha.Direita != atualLinha && atualLinha.Direita.Coluna != INICIOCABECA)
            {
                anteriorLinha = atualLinha;
                atualLinha = atualLinha.Direita;
            }

            while (atualColuna.Coluna < c && atualColuna.Direita != atualColuna)
            {
                anteriorColuna = atualColuna;
                atualColuna = atualColuna.Direita;
            }

            while (atualColuna.Abaixo.Linha < l && atualColuna.Abaixo != atualColuna && atualColuna.Abaixo.Linha != INICIOCABECA)
            {
                anteriorColuna = atualColuna;
                atualColuna = atualColuna.Abaixo;
            }

            Celula procurada = atualLinha.Direita;
            if (procurada.Coluna != c || procurada.Linha != l)
                return false;

            return true;
        }

        public void Listar(DataGridView dgv)
        {
            for (int l = 0; l < numLinhas; l++)
            {
                for (int c = 0; c < numColunas; c++)
                {
                    if (Existe(l, c))
                        dgv[c, l].Value = atualColuna.Abaixo.Valor;
                    else
                        dgv[c, l].Value = 0;
                }
            }
        }

        public bool Excluir(int l, int c)
        {
            if (Existe(l, c))
            {
                anteriorColuna.Abaixo = atualColuna.Abaixo;
                anteriorLinha.Direita = atualLinha.Direita;
                qtd--;

                return true;
            }

            return false;
        }

        public ListaCruzada SomarMatrizes(ListaCruzada listaB)
        {
            ListaCruzada soma = new ListaCruzada(numLinhas, numColunas);

            for (int l = 0; l < numLinhas; l++)
            {
                for (int c = 0; c < numColunas; c++)
                {
                    double somaValores = ValorDe(l, c) + listaB.ValorDe(l, c);
                    if(somaValores != 0)
                        soma.InserirElemento(l,c, somaValores);
                }
            }

            return soma;
        }
        public ListaCruzada MultiplicarMatrizes(ListaCruzada listaB)
        {
            ListaCruzada produto = new ListaCruzada(listaB.numLinhas, numColunas);

            for (int l = 0; l < produto.NumLinhas; l++)
            {
                for (int c = 0; c < produto.NumColunas; c++)
                {
                    //double resultado = ValorDe(l, c)  * listaB.ValorDe(l,c) + ValorDe(l);
                }
            }

            return produto;
        }

        public void ExcluirMatriz()
        {
            cabeca = null;
            qtd = 0;
        }

        public void SomarColuna(double v, int qualColuna)
        {
            atualColuna = cabeca;

            while (atualColuna.Coluna != qualColuna && atualColuna.Direita != atualColuna)
                atualColuna = atualColuna.Direita;

            for (int i = 0; i < NumLinhas; i++)
            {
                if (atualColuna.Abaixo.Linha != i)
                {
                    InserirElemento(i, qualColuna, v);
                }
                else
                {
                    if (v + atualColuna.Abaixo.Valor == 0)
                        Excluir(i, qualColuna);

                    InserirElemento(i, qualColuna, v + atualColuna.Abaixo.Valor);
                }

            }
        }
        
    }

}
