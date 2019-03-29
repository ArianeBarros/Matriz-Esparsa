using System;
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

                dgv.ColumnCount = lista.NumColunas;
                dgv.RowCount = lista.NumLinhas;

                cbxColuna.Visible = true;
                cbxLinha.Visible = true;

                bool teveErro = false;

                while (!arquivo.EndOfStream)
                {
                    Celula lida = Celula.LerRegistro(arquivo);

                    if (lida.Coluna < 0 || lida.Linha < 0 || lida.Linha > lista.NumLinhas || lida.Coluna > lista.NumColunas)
                    {
                        teveErro = true;
                        txtErro.Items.Add($"({lida.Linha}, {lida.Coluna})");
                        continue;
                    }

                    lista.InserirElemento(lida.Linha, lida.Coluna, lida.Valor);
                }

                if (teveErro)
                    lblErro.Text = "Células com index não suportados pela matriz: ";

                arquivo.Close();
                lista.Listar(dgv);
                for (int i = 0; i < lista.NumColunas ; i++)
                    dgv.Columns[i].HeaderText = i.ToString();
                for (int i = 0; i < lista.NumLinhas; i++)
                    dgv.Rows[i].HeaderCell.Value = i.ToString();
            }
        }

        private void btnLerMatrizB_Click(object sender, EventArgs e)
        {
            LerMatriz(ref matrizB, dgvB);
        }

        private void btnSomarMatrizes_Click(object sender, EventArgs e)
        {
            ListaCruzada soma = matrizA.SomarMatrizes(matrizB);
            soma.Listar(dgvResultado);
        }

        private void btnSomarColuna_Click(object sender, EventArgs e)
        {
            if (rgbMA.Checked)
            {
                matrizA.SomarColuna(int.Parse(txtSomar.Text), Convert.ToInt32(cbxColuna.SelectedItem));
                matrizA.Listar(dgvResultado);
            }                
            else
            {
                matrizB.SomarColuna(int.Parse(txtSomar.Text), Convert.ToInt32(cbxColuna.SelectedItem));
                matrizB.Listar(dgvResultado);
            }
               
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (txtValor.Text == "" || txtValor.Text == "0")
            {
                txtErro.Text = "Erro: Selecione uma célula para a exclusão!!";
                return;
            }            

            if(rgbMA.Checked)
            {
                if(matrizA.Excluir(int.Parse(txtLinha.Text), int.Parse(txtColuna.Text)))
                     matrizA.Listar(dgvA);
            }                
            else
            {
                if (matrizB.Excluir(int.Parse(txtLinha.Text), int.Parse(txtColuna.Text)))
                    matrizB.Listar(dgvB);
                else
                    txtErro.Text = "Erro ao excluir!";
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

        private void dgvA_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtColuna.Text = e.ColumnIndex + "";
            txtLinha.Text = e.RowIndex + "";
            txtValor.Text = matrizA.ValorDe(e.RowIndex, e.ColumnIndex) + "";
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {         

            if(rgbMA.Checked)
            {
                matrizA.InserirElemento(int.Parse(txtLinha.Text), int.Parse(txtColuna.Text), double.Parse(txtValor.Text));
                matrizA.Listar(dgvA);
            }
            else
            {
                matrizB.InserirElemento(int.Parse(txtLinha.Text), int.Parse(txtColuna.Text), double.Parse(txtValor.Text));
                matrizB.Listar(dgvB);
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {

            if(rgbMA.Checked)
            {
                matrizA.InserirElemento(int.Parse(txtLinha.Text), int.Parse(txtColuna.Text), double.Parse(txtValor.Text));
                matrizA.Listar(dgvA);
            }
            else
            {
                matrizB.InserirElemento(int.Parse(txtLinha.Text), int.Parse(txtColuna.Text), double.Parse(txtValor.Text));
                matrizB.Listar(dgvB);
            }           
        }

        private void btnLiberarMatriz_Click(object sender, EventArgs e)
        {
            matrizA.ExcluirMatriz();
        }

        private void btnSomarLinha_Click(object sender, EventArgs e)
        {
            if (txtSomar.Text == "" || txtSomar.Text == 0 + "")   //pode ser double
                matrizA.Listar(dgvResultado);

            if(rgbMA.Checked)
            {
                matrizA.SomarLinha(double.Parse(txtSomar.Text), Convert.ToInt32(cbxLinha.SelectedItem));
                matrizA.Listar(dgvResultado);
            }
            else
            {
                matrizB.SomarLinha(double.Parse(txtSomar.Text), Convert.ToInt32(cbxLinha.SelectedItem));
                matrizB.Listar(dgvResultado);
            }
        }

        private void btnMultiplicarColuna_Click(object sender, EventArgs e)
        {
            if (txtMultiplicar.Text == "" || txtMultiplicar.Text == 0 + "")   //pode ser double
            {
                if(rgbMA.Checked)
                    matrizA.Listar(dgvResultado);
                else
                    matrizB.Listar(dgvResultado);
            }                

            if (rgbMA.Checked)
            {
                matrizA.MultiplicarColuna(double.Parse(txtMultiplicar.Text), Convert.ToInt32(cbxColuna.SelectedItem));
                matrizA.Listar(dgvResultado);
            }
            else
            {
                matrizB.MultiplicarColuna(double.Parse(txtMultiplicar.Text), Convert.ToInt32(cbxColuna.SelectedItem));
                matrizB.Listar(dgvResultado);
            }
        }

        private void btnMultiplicarMatrizes_Click(object sender, EventArgs e)
        {
           
        }

        private void btnMultiplicarLinha_Click(object sender, EventArgs e)
        {
            if (txtMultiplicar.Text == "" || txtMultiplicar.Text == 0 + "")   //pode ser double
            {
                if (rgbMA.Checked)
                    matrizA.Listar(dgvResultado);
                else
                    matrizB.Listar(dgvResultado);
            }

            if (rgbMA.Checked)
            {
                matrizA.MultiplicarLinha(double.Parse(txtMultiplicar.Text), Convert.ToInt32(cbxLinha.SelectedItem));
                matrizA.Listar(dgvResultado);
            }
            else
            {
                matrizB.MultiplicarLinha(double.Parse(txtMultiplicar.Text), Convert.ToInt32(cbxLinha.SelectedItem));
                matrizB.Listar(dgvResultado);
            }
        }

        private void rgbMA_CheckedChanged(object sender, EventArgs e)
        {
            cbxColuna.Items.Clear();
            for (int i = 0; i < matrizA.NumColunas; i++)
                cbxColuna.Items.Add(i + "");

            cbxLinha.Items.Clear();
            for (int i = 0; i < matrizA.NumLinhas; i++)
                cbxLinha.Items.Add(i + "");
        }

        private void rgbMB_CheckedChanged(object sender, EventArgs e)
        {
            cbxColuna.Items.Clear();
            for (int i = 0; i < matrizB.NumColunas; i++)
                cbxColuna.Items.Add(i + "");

            cbxLinha.Items.Clear();
            for (int i = 0; i < matrizB.NumLinhas; i++)
                cbxLinha.Items.Add(i + "");
        }
    }
}
