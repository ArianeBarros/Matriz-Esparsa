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
        Celula cabeca, esquerda, cima, anteriorLinha, anteriorColuna;
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


        public int Qtd { get => qtd;}
        public int NumLinhas { get => numLinhas; }
        public int NumColunas { get => numColunas; }
        public Celula Cabeca { get => cabeca; }
        

        public void InserirElemento(int l, int c, double v)
        {
            if (v == 0)
                return; // arrumar
                       
            if (Existe(l, c))
                cima.Abaixo.Valor = v;
            else
            {
                Celula novaCelula = new Celula(l, c, v, null, null);

                novaCelula.Abaixo = cima.Abaixo;
                cima.Abaixo = novaCelula;

                novaCelula.Direita = esquerda.Direita;
                esquerda.Direita = novaCelula;

                qtd++;
            }
        }

        public double? ValorDe(int l, int c)
        {
            if (Existe(l, c))
                return cima.Valor;
            else
                return null;
        }


        public bool Existe(int l, int c)
        {
            esquerda = cabeca;
            cima = cabeca;
            //anteriorLinha = cabeca;
            //anteriorColuna = cabeca;

            while (esquerda.Linha < l && esquerda.Abaixo != esquerda)
            {
                //anteriorLinha = esquerda;
                esquerda = esquerda.Abaixo;
            }

            while (esquerda.Direita.Coluna < c && esquerda.Direita != esquerda && esquerda.Direita.Coluna != INICIOCABECA)
            {
               // anteriorLinha = esquerda;
                esquerda = esquerda.Direita;
            }               

            while (cima.Coluna < c && cima.Direita != cima)
            {
                //anteriorColuna = cima;
                cima = cima.Direita;
            }           

            

            while (cima.Abaixo.Linha < l && cima.Abaixo != cabeca && cima.Abaixo.Linha != INICIOCABECA)
            {
                //anteriorColuna = cima;
                cima = cima.Abaixo;
            }     

            Celula procurada = esquerda.Direita;
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
                        dgv[c, l].Value = cima.Abaixo.Valor;
                    else
                        dgv[c , l ].Value = 0;
                }
            }
        }

        public bool Excluir(int l, int c)
        {
            if (Existe(l, c))
            {
                
                anteriorColuna.Abaixo = cima.Abaixo;
                anteriorLinha.Direita = esquerda.Direita;
                qtd--;
                
                return true;
            }

            return false;
        }

        public ListaCruzada SomarMatrizes(ListaCruzada listaB)
        {
            ListaCruzada soma = null;

            for (int l = 0; l < numLinhas; l++)
            {
                for (int c = 0; c < numColunas; c++)
                {
                    if (Existe(l, c) && listaB.Existe(l, c))                    
                        soma.InserirElemento(l, c, esquerda.Valor + listaB.esquerda.Valor); 
                    else
                    {
                        if (Existe(l, c))
                            soma.InserirElemento(l, c, esquerda.Valor);
                        else
                            soma.InserirElemento(l, c, listaB.esquerda.Valor);
                    }
                }
            }

            return soma;
        }
        
        public void ExcluirMatriz()
        {
            cabeca = null;
            qtd = 0;
        }

        public void SomarColuna(double v, int qualColuna)
        {
            cima = cabeca;                     
           
            while (cima.Coluna != qualColuna && cima.Direita != cima)
                cima = cima.Direita;

            //atualColuna = atualColuna.Abaixo;

            for(int i = 0; i < NumLinhas; i++)
            {
                if(cima.Abaixo.Linha != i)
                {
                    InserirElemento(i, qualColuna, v);
                    cima = cima.Abaixo;
                }
                else
                {
                    if (v + cima.Valor == 0)
                        Excluir(i, qualColuna);

                    InserirElemento(i, qualColuna, v + cima.Abaixo.Valor);
                }
                
            }
        }
    }

}
