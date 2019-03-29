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


        public int Qtd { get => qtd;}
        public int NumLinhas { get => numLinhas; }
        public int NumColunas { get => numColunas; }
        public Celula Cabeca { get => cabeca; }
        

        public void InserirElemento(int l, int c, double v)
        {
            if (v == 0)
                return; // arrumar
                       
            if (Existe(l, c))
                atualColuna.Valor = v;
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

        public double? ValorDe(int l, int c)
        {
            if (Existe(l, c))
                return atualColuna.Valor;
            else
                return null;
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
                
            

            while (atualLinha.Coluna < c && atualLinha.Direita != atualLinha && atualLinha.Direita.Coluna != INICIOCABECA)
            {
                anteriorLinha = atualLinha;
                atualLinha = atualLinha.Direita;
            }
                
            

            while (atualColuna.Coluna < c && atualColuna.Direita != atualColuna)
            {
                anteriorColuna = atualColuna;
                atualColuna = atualColuna.Direita;
            }           

            while (atualColuna.Linha < l && atualColuna.Abaixo != atualColuna && atualColuna.Abaixo.Linha != INICIOCABECA)
            {
                anteriorColuna = atualColuna;
                atualColuna = atualColuna.Abaixo;
            }     

            Celula procurada = atualLinha;
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
                        dgv[c, l].Value = atualColuna.Valor;
                    else
                        dgv[c , l ].Value = 0;
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
            ListaCruzada soma = null;


            return soma;
        }

        public void ExcluirMatriz()
        {

        }

        public void SomarColuna(double v, int qualColuna)
        {
            atualLinha = cabeca;
            atualColuna = cabeca;                     
           
            while (atualColuna.Coluna < qualColuna && atualColuna.Direita != atualColuna)
            {
                atualColuna.Valor = atualColuna.Valor + v;
                atualColuna = atualColuna.Direita;
            }
            
        }

        public void SomarLinha(double v, int qualLinha)
        {
            while (atualLinha.Linha < qualLinha && atualLinha.Abaixo != atualLinha)
            {
                atualLinha.Valor = atualLinha.Valor + v;
                atualLinha = atualLinha.Abaixo;
            }
        }

        public void MultiplicarColuna(double v, int qualColuna)
        {
            atualLinha = cabeca;
            atualColuna = cabeca;

            while (atualColuna.Coluna < qualColuna && atualColuna.Direita != atualColuna)
            {
                atualColuna.Valor = atualColuna.Valor + v;
                atualColuna = atualColuna.Direita;
            }

        }

        public void MultiplicarLinha(double v, int qualLinha)
        {
            while (atualLinha.Linha < qualLinha && atualLinha.Abaixo != atualLinha)
            {
                atualLinha.Valor = atualLinha.Valor + v;
                atualLinha = atualLinha.Abaixo;
            }
        }
    }

}
