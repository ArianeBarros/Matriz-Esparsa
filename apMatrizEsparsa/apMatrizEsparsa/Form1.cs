﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace apMatrizEsparsa
{
    public partial class frmMatriz : Form
    {
        ListaCruzada matrizA;
        ListaCruzada matrizB;
        public frmMatriz()
        {
            InitializeComponent();
        }

        private void frmMatriz_Load(object sender, EventArgs e)
        {
            
        }

        private void btnLerMatrizA_Click(object sender, EventArgs e)
        {
            LerMatriz(ref matrizA, dgvA);
        }


        private void LerMatriz(ref ListaCruzada lista, DataGridView dgv)
        {
            if (dlgAbrir.ShowDialog() == DialogResult.OK)
            {
                var arquivo = new StreamReader(dlgAbrir.FileName);

                string numeroLinhaColuna = arquivo.ReadLine();

                lista = new ListaCruzada(int.Parse(numeroLinhaColuna.Substring(0, 5)), int.Parse(numeroLinhaColuna.Substring(5, 5)));

                while (!arquivo.EndOfStream)
                {
                    Celula lida = Celula.LerRegistro(arquivo);
                    lista.InserirElemento(lida.Linha, lida.Coluna, lida.Valor);
                }
                arquivo.Close();
                lista.Listar(dgv);
            }
        }

        private void btnLerMatrizB_Click(object sender, EventArgs e)
        {
            LerMatriz(ref matrizB, dgvB);
        }

        private void btnSomarMatrizes_Click(object sender, EventArgs e)
        {
            matrizA.SomarMatrizes(matrizB);
        }

        private void btnSomarColuna_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (txtLinha.Text == "" || txtColuna.Text == "")
            {
                MessageBox.Show("Selecione uma célula para a exclusão!!");
                return;
            }            
         
             if (matrizA.Excluir(int.Parse(txtLinha.Text), int.Parse(txtColuna.Text)))
                 matrizA.Listar(dgvA);
            else
            {
                if (matrizB.Excluir(int.Parse(txtLinha.Text), int.Parse(txtColuna.Text)))
                    matrizB.Listar(dgvB);
                else
                    MessageBox.Show("Erro ao excluir!");
            }            
        }

        private void dgvA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (matrizA.ValorDe(e.RowIndex, e.ColumnIndex) == 0)
                return;

            txtColuna.Text = e.ColumnIndex + "";
            txtLinha.Text = e.RowIndex + "";
            txtValor.Text = matrizA.ValorDe(e.RowIndex, e.ColumnIndex) + "";
        }

        private void dgvB_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (matrizB.ValorDe(e.RowIndex, e.ColumnIndex) == 0)
                return;

            txtColuna.Text = e.ColumnIndex + "";
            txtLinha.Text = e.RowIndex + "";
            txtValor.Text = matrizB.ValorDe(e.RowIndex, e.ColumnIndex) + "";
        }
    }
}
