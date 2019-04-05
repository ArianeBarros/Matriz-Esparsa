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
        Celula cabeca, atualLinha, atualColuna;
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

            while (atualLinha.Linha < l && atualLinha.Abaixo != atualLinha)
            {
                atualLinha = atualLinha.Abaixo;
            }

            while (atualLinha.Direita.Coluna < c && atualLinha.Direita != atualLinha && atualLinha.Direita.Coluna != INICIOCABECA)
            {
                atualLinha = atualLinha.Direita;
            }

            while (atualColuna.Coluna < c && atualColuna.Direita != atualColuna)
            {
                atualColuna = atualColuna.Direita;
            }

            while (atualColuna.Abaixo.Linha < l && atualColuna.Abaixo != atualColuna && atualColuna.Abaixo.Linha != INICIOCABECA)
            {
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
                Celula desejada = atualLinha.Direita;

                atualColuna.Abaixo = desejada.Abaixo;
                atualLinha.Direita = desejada.Direita;
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
            ListaCruzada produto = new ListaCruzada(numLinhas, listaB.numColunas);
            double resultado = 0;
            for (int l = 0; l < numLinhas; l++)
            {
                for (int c = 0; c < listaB.NumColunas; c++)
                {
                    resultado = 0;
                    for (int col = 0; col < numColunas; col++)
                    {
                        resultado += ValorDe(l, col) * listaB.ValorDe(col, c);
                    }

                        if (resultado != 0)
                            produto.InserirElemento(l, c, resultado);
                    
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
            for (int i = 0; i < NumLinhas; i++)
            {
                if (ValorDe(i, qualColuna) == 0)
                    InserirElemento(i, qualColuna, v);
                else
                {
                    Celula desejada = atualLinha.Direita;
                    if (desejada.Valor + v == 0)
                        Excluir(i, qualColuna);
                    else
                        InserirElemento(i, qualColuna, v + desejada.Valor);
                }
                    

            }
        }
        
    }

}
