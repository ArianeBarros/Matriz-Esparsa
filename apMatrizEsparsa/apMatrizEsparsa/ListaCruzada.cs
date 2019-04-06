using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace apMatrizEsparsa
{
    class ListaCruzada  // classe que representa uma lista cruzada
    {
        Celula cabeca, atualLinha, atualColuna;
        int numLinhas, numColunas;
        int qtdValores;

        public ListaCruzada()   // construtor padrão que instancia a classe vazia
        {
            cabeca = new Celula(-1, -1, 0, null, null); ;
            qtdValores = 0;
        }

        public ListaCruzada(int linhas, int colunas) 
        {
            if (linhas < 0)
                throw new Exception("Index de linha inválido");
            if (colunas < 0)
                throw new Exception("Index de coluna inválido");

            cabeca = new Celula(-1, -1, 0, null, null);
            qtdValores = 0;
            numLinhas = linhas;
            numColunas = colunas;

            Celula atual = cabeca;
            for (int i = 0; i < linhas; i++)
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


        public int Qtd { get => qtdValores; }
        public int NumLinhas { get => numLinhas; }
        public int NumColunas { get => numColunas; }
        public Celula Cabeca { get => cabeca; }

        public void InserirElemento(int l, int c, double v)
        {
            if (l < 0 || l > numLinhas)
                throw new Exception("Index de linha inválido");
            if (c < 0 || c > numColunas)
                throw new Exception("Index de coluna inválido");

            if (v != 0)
            {
                if (Existe(l, c))
                    atualColuna.Abaixo.Valor = v;
                else
                {
                    Celula novaCelula = new Celula(l, c, v, null, null);

                    novaCelula.Abaixo = atualColuna.Abaixo;
                    atualColuna.Abaixo = novaCelula;

                    novaCelula.Direita = atualLinha.Direita;
                    atualLinha.Direita = novaCelula;

                    qtdValores++;
                }
            }
        }

        public double ValorDe(int l, int c)
        {
            if (l < 0 || l > numLinhas)
                throw new Exception("Index de linha inválido");
            if (c < 0 || c > numColunas)
                throw new Exception("Index de coluna inválido");

            if (Existe(l, c))
                return atualColuna.Abaixo.Valor;
            else
                return 0;
        }

        protected bool Existe(int l, int c)
        {
            if (l < 0 || l > numLinhas)
                throw new Exception("Index de linha inválido");
            if (c < 0 || c > numColunas)
                throw new Exception("Index de coluna inválido");

            atualLinha = cabeca;
            atualColuna = cabeca;

            while (atualLinha.Linha < l && atualLinha.Abaixo != atualLinha)
            {
                atualLinha = atualLinha.Abaixo;
            }

            while (atualLinha.Direita.Coluna < c && atualLinha.Direita != atualLinha && atualLinha.Direita.Coluna != -1)
            {
                atualLinha = atualLinha.Direita;
            }

            while (atualColuna.Coluna < c && atualColuna.Direita != atualColuna)
            {
                atualColuna = atualColuna.Direita;
            }

            while (atualColuna.Abaixo.Linha < l && atualColuna.Abaixo != atualColuna && atualColuna.Abaixo.Linha != -1)
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
            if (dgv == null)
                throw new Exception("Parametros inválidos");

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
            if (l < 0 || l > numLinhas)
                throw new Exception("Index de linha inválido");
            if (c < 0 || c > numColunas)
                throw new Exception("Index de coluna inválido");

            if (Existe(l, c))
            {
                Celula desejada = atualLinha.Direita;

                atualColuna.Abaixo = desejada.Abaixo;
                atualLinha.Direita = desejada.Direita;
                qtdValores--;

                return true;
            }

            return false;
        }

        public ListaCruzada SomarMatrizes(ListaCruzada listaB)
        {
            if (listaB == null)
                throw new Exception("Parametros inválidos");

            if (this.NumColunas != listaB.NumColunas || this.NumLinhas != listaB.NumLinhas)
                throw new Exception("Para somar matrizes, ambas devem ter a mesma dimensão");

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
            if (listaB == null)
                throw new Exception("Parametros inválidos");

            if (this.NumLinhas != listaB.NumColunas)
                throw new Exception("Para multiplicar matrizes, o número de linhas de uma deve ser igual ao número de colunas da outra");

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
            numColunas = 0;
            numLinhas = 0;
            qtdValores = 0;
        }

        public void SomarColuna(double v, int qualColuna)
        {
            if (qualColuna < 0 || qualColuna > numColunas)
                throw new Exception("Index de coluna inválido");

            if(v != 0)
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

}
