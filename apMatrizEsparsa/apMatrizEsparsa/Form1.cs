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

/*
 * Verificar se o valor de uma célula é 0, se for impedir sua criação(não deve ser guardada)
 * Somar matrizes
 * Somar linha com k
 * Somar coluna com k
 * Multiplicar matrizes
 * */

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
            rgbMA.Checked = true;
            rgbMA.Enabled = true;
        }

        private void IniciarControles()
        {
            btnIncluir.Enabled = true;
            btnDeletar.Enabled = true;
            btnAlterar.Enabled = true;
            btnSomarColuna.Enabled = true;
            btnExcluirMatriz.Enabled = true;

            btnSomarMatrizes.Enabled = true;
            btnMultiplicarMatrizes.Enabled = true;

            numeroUpDown.Enabled = true;
            valorUpDown.Enabled = true;
            cbxColuna.Enabled = true;
        }

        private void AjustarDataGridView(DataGridView qualDgv, int numLinhas, int numColunas)
        {
            qualDgv.ColumnCount = numColunas;
            qualDgv.RowCount = numLinhas;

            qualDgv.AllowUserToResizeColumns = false;
            qualDgv.AllowUserToResizeRows = false;
        }
        private void LerMatriz(ref ListaCruzada lista, DataGridView dgv)
        {
            if (dlgAbrir.ShowDialog() == DialogResult.OK)
            {
                var arquivo = new StreamReader(dlgAbrir.FileName);
                string numeroLinhaColuna = arquivo.ReadLine();
                lista = new ListaCruzada(int.Parse(numeroLinhaColuna.Substring(0, 5)), int.Parse(numeroLinhaColuna.Substring(5, 5)));

                AjustarDataGridView(dgv, lista.NumLinhas, lista.NumColunas);
                IniciarControles();

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
            }
        }

        private void btnLerMatrizB_Click(object sender, EventArgs e)
        {
            LerMatriz(ref matrizB, dgvB);
            rgbMB.Checked = true;
            rgbMB.Enabled = true;
        }

        private void btnSomarMatrizes_Click(object sender, EventArgs e)
        {
            if(matrizA == null || matrizB == null)
            {
                MessageBox.Show("Para somar matrizes é necessário duas desta", "Erro ao somar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dgvResultado.RowCount = dgvA.RowCount;
                dgvResultado.ColumnCount = dgvA.ColumnCount;

                ListaCruzada soma = matrizA.SomarMatrizes(matrizB);
                soma.Listar(dgvResultado);
            }
        }

        private void btnSomarColuna_Click(object sender, EventArgs e)
        {
            if (cbxColuna.SelectedItem == null)
                MessageBox.Show("Selecione uma coluna", "Erro ao somar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            if (rgbMA.Checked)
            {
                matrizA.SomarColuna(int.Parse(valorUpDown.Value.ToString()), Convert.ToInt32(cbxColuna.SelectedItem));
                matrizA.Listar(dgvA);
            }                
            else
            {
                matrizB.SomarColuna(int.Parse(valorUpDown.Value.ToString()), Convert.ToInt32(cbxColuna.SelectedItem));
                matrizB.Listar(dgvB);
            }
               
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (numeroUpDown.Text == "" || numeroUpDown.Text == "0")
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
            numeroUpDown.Text = matrizA.ValorDe(e.RowIndex, e.ColumnIndex) + "";
        }

        private void dgvB_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (matrizB.ValorDe(e.RowIndex, e.ColumnIndex) == 0)
                return;

            txtColuna.Text = e.ColumnIndex + "";
            txtLinha.Text = e.RowIndex + "";
            numeroUpDown.Text = matrizB.ValorDe(e.RowIndex, e.ColumnIndex) + "";
        }

        private void dgvA_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtColuna.Text = e.ColumnIndex + "";
            txtLinha.Text = e.RowIndex + "";
            numeroUpDown.Text = matrizA.ValorDe(e.RowIndex, e.ColumnIndex) + "";
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {         

            if(rgbMA.Checked)
            {
                matrizA.InserirElemento(int.Parse(txtLinha.Text), int.Parse(txtColuna.Text), double.Parse(numeroUpDown.Text));
                matrizA.Listar(dgvA);
            }
            else
            {
                matrizB.InserirElemento(int.Parse(txtLinha.Text), int.Parse(txtColuna.Text), double.Parse(numeroUpDown.Text));
                matrizB.Listar(dgvB);
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtLinha.Text == "" || txtColuna.Text == "")
                MessageBox.Show("Preencha os dados corretamente", "Dados incompletos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            if (int.Parse(txtLinha.Text) < 0 || int.Parse(txtColuna.Text) < 0)
                MessageBox.Show("Index do valor inválido", "Erro ao inserir", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            if(rgbMA.Checked)
            {
                matrizA.InserirElemento(int.Parse(txtLinha.Text), int.Parse(txtColuna.Text), double.Parse(numeroUpDown.Text));
                matrizA.Listar(dgvA);
            }
            else
            {
                matrizB.InserirElemento(int.Parse(txtLinha.Text), int.Parse(txtColuna.Text), double.Parse(numeroUpDown.Text));
                matrizB.Listar(dgvB);
            }           
        }

        private void btnLiberarMatriz_Click(object sender, EventArgs e)
        {
            if (rgbMA.Checked)
            {
                matrizA.ExcluirMatriz();
                dgvA.Rows.Clear() ;
            }
            else
            if (rgbMB.Checked)
            {
                matrizB.ExcluirMatriz();
            }
        }     
        private void btnMultiplicarMatrizes_Click(object sender, EventArgs e)
        {
            if (matrizA == null || matrizB == null)
            {
                MessageBox.Show("Para somar matrizes é necessário duas desta", "Erro ao somar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                dgvResultado.ColumnCount = dgvB.ColumnCount;
                dgvResultado.RowCount = dgvA.RowCount;

                ListaCruzada result = matrizA.MultiplicarMatrizes(matrizB);
                result.Listar(dgvResultado);
            }
        }

        private void rgbMA_CheckedChanged(object sender, EventArgs e)
        {
            cbxColuna.Items.Clear();
            for (int i = 0; i < matrizA.NumColunas; i++)
                cbxColuna.Items.Add(i + "");
        }

        private void rgbMB_CheckedChanged(object sender, EventArgs e)
        {
            cbxColuna.Items.Clear();
            for (int i = 0; i < matrizB.NumColunas; i++)
                cbxColuna.Items.Add(i + "");
        }

        private void frmMatriz_Load(object sender, EventArgs e)
        {
            
        }

        private void dgvB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtColuna.Text = e.ColumnIndex + "";
            txtLinha.Text = e.RowIndex + "";
            numeroUpDown.Text = matrizB.ValorDe(e.RowIndex, e.ColumnIndex) + "";
        }

        private void dgvA_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView qual = (DataGridView)sender;
            numeroUpDown.Value = Convert.ToDecimal(qual[e.ColumnIndex, e.RowIndex].Value) ;
            btnAlterar.PerformClick();
        }
    }
}
