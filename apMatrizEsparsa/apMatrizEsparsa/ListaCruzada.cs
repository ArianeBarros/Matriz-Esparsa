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
        Celula cabeca, atualLinha, anteriorLinha, atualColuna, anteriorColuna;
        int numLinhas, numColunas;
        int qtd;
        
        public ListaCruzada()
        {
            cabeca = new Celula(-1, -1, 0, null, null); ;
            qtd = 0;
        }
        public ListaCruzada(int linhas, int colunas)
        {
            cabeca = new Celula(-1, -1, 0, null, null);
            qtd = 0;
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

            if (Existe(l, c))
                atualColuna.Valor = v;
            else
            {
                Celula novaCelula = new Celula(l, c, v, null, null);

                anteriorColuna.Abaixo = novaCelula;
                novaCelula.Abaixo = atualColuna;

                anteriorLinha.Direita = novaCelula;
                novaCelula.Direita = atualLinha;
                qtd++;
            }
        }
        

        public bool Existe(int l, int c)
        {
            Celula atual = cabeca;

            while (atual.Linha != l && atual.Abaixo != atual)
            {
                anteriorLinha = atualLinha;
                atual = atual.Abaixo;
            }
            

            while (atual.Coluna != c && atual.Direita != atual)
            {
                atual = atual.Direita;
            }
            


            if (atual.Linha != l && atual.Coluna != c)
                return false;
            else
                return true;
            //atualLinha = cabeca;
            //anteriorLinha = null;
            //atualColuna = cabeca;
            //anteriorColuna = null;

            //while (atualLinha.Linha != l && atualLinha.Abaixo != atualLinha)
            //{
            //    anteriorLinha = atualLinha;
            //    atualLinha = atualLinha.Abaixo;
            //}

            //while (atualLinha.Coluna != c && atualLinha.Direita != atualLinha)
            //{
            //    anteriorLinha = atualLinha;
            //    atualLinha = atualLinha.Direita;
            //}

            //while (atualColuna.Coluna != c && atualColuna.Direita != atualColuna)
            //{
            //    anteriorColuna = atualColuna;
            //    atualColuna = atualColuna.Direita;
            //}

            //while (atualColuna.Linha != l && atualColuna.Abaixo != atualColuna)
            //{
            //    anteriorColuna = atualColuna;
            //    atualColuna = atualColuna.Abaixo;
            //}

            //if (atualColuna.Linha != l && atualColuna.Coluna != c)
            //    return false;
            //else
            //    return true;
        }

        public void Listar(DataGridView dgv)
        {
            dgv.ColumnCount = numColunas;
            dgv.RowCount = numLinhas;

            for (int l = 0; l < numLinhas; l++)
            {
                for (int c = 0; c < numColunas; c++)
                {
                    if (dgv[c, l].Value == null)
                        dgv[c, l].Value = 0;                    
                    else
                        dgv[c, l].Value = atualColuna.Valor;
                }
            }

            // dgv.ColumnCount = numColunas;
            // dgv.RowCount = numLinhas;

            //for(int l = 0; l < numLinhas; l++)
            // {
            //     for(int c = 0; c < numColunas; c++)
            //     {
            //         if (Existe(l, c))
            //             dgv[c, l].Value = atualColuna.Valor;
            //         else
            //             dgv[c, l].Value = 0;


            //     }
            // }

        }

        public ListaCruzada SomarMatrizes(ListaCruzada listaB)
        {
            ListaCruzada soma = null;


            return soma;
        }
    }

}
