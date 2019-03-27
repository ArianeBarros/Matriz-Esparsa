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
        Celula cabeca, primeiro;
        int numLinhas, numColunas;
        int qtd;
        
        public ListaCruzada()
        {
            cabeca = null;
            qtd = 0;
        }
        public ListaCruzada(int linhas, int colunas)
        {
            cabeca = new Celula(-1, -1, 0, null, null);
            qtd = 0;
            numLinhas = linhas;
            numColunas = colunas;

            primeiro = null;

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


        public int Qtd { get => qtd;}
        public int NumLinhas { get => numLinhas; }
        public int NumColunas { get => numColunas; }
        public Celula Cabeca { get => cabeca; }
        

        public void InserirElemento(int l, int c, double v)
        {
            if (c < 0 || l < 0)
                throw new Exception("Índice inválido!!");

            if (v == 0)
                return; // arrumar

            Celula novaCelula = new Celula(l, c, v, null, null);
            Celula atual = cabeca, anterior = null;


            while(atual.Linha != l)
            {
                anterior = atual;
                atual = atual.Abaixo;                  
            }

            while (atual.Abaixo != atual)
                atual = atual.Abaixo;   

            atual.Abaixo = novaCelula;
            

            while (atual.Coluna != c)
            {                
                anterior = atual;
                atual = atual.Direita;
            }

            while (atual.Direita != atual)
                atual = atual.Direita;

            atual.Direita = novaCelula;
            
            qtd++;
        }

        public double? Valor(int l, int c)
        {
            double? valor = null;

            Celula atualLinha = cabeca;

            while (atualLinha.Linha < l && atualLinha.Abaixo != atualLinha)
                atualLinha = atualLinha.Abaixo;

            Celula atualColuna = atualLinha;

            while (atualColuna.Coluna < c && atualColuna.Direita != atualColuna)
                atualColuna = atualColuna.Direita;

            //TERMINAR AQUII

            return valor;
        }

        public void Listar(DataGridView dgv)
        {
            Celula atual = primeiro;
            int i = 0;
            int j = 0;

            while(atual != null)
            {
                while(i < dgv.ColumnCount)
                {
                    for (j = 0; j < dgv.ColumnCount; j++)
                    {
                        dgv.Rows[i].Cells[j].Value = atual.Valor;
                        atual = atual.Direita;
                    }
                    j = 0;
                    i++;
                }                      
            }
        }

        public ListaCruzada SomarMatrizes(ListaCruzada listaB)
        {
            ListaCruzada soma = null;


            return soma;
        }
    }

}
