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
 * Deletar negativos
 * Indicar número de linhas e colunas
 * Multiplicar matrizes
 * Salvar??
 * Usuario pode alterar células direto na dgv?
 * configurar tamanho do dgvResultado ao somar e multiplicarr as matrizes
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
            LerMatriz(ref matrizA, dgvA, rgbMA);
        }

        private void btnLerMatrizB_Click(object sender, EventArgs e) //Método chamado para a leitura da segunda matriz
        {
            LerMatriz(ref matrizB, dgvB, rgbMB); //Passando como referência a declaração da segunda lista cruzada
        }


        private void btnSomarMatrizes_Click(object sender, EventArgs e)  //Método chamado se o usuário deseja somar as duas matizes a ele apresentadas 
        {
            if(matrizA == null || matrizB == null) //Caso o usuário não tenha escolhido duas matrizes, não será possível soma-las, então uma mensagem de erro é mostrada ao usuário 
            {
                MessageBox.Show("Para somar matrizes é necessário duas desta", "Erro ao somar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dgvResultado.RowCount = dgvA.RowCount;  //Adequação do número de linhas do dgvResultado à soma das duas matrizes
                dgvResultado.ColumnCount = dgvA.ColumnCount;  //Adequação do número de colunas do dgvResultado à soma das duas matrizes

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
                {
                    matrizA.Listar(dgvA);
                    numeroUpDown.Text = "0";
                }                    
                else
                    txtErro.Text = "Erro ao excluir!";
            }                
            else
            {
                if (matrizB.Excluir(int.Parse(txtLinha.Text), int.Parse(txtColuna.Text)))
                {
                    matrizB.Listar(dgvB);
                    numeroUpDown.Text = "0";
                }
                else
                    txtErro.Text = "Erro ao excluir!";
            }          
        }

        private void dgvA_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ExibirInformacoes(matrizA, e.RowIndex, e.ColumnIndex);
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
            if (rgbMA.Checked)
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
                dgvA.Rows.Clear();
                rgbMA.Checked = false;
            }
            else
           if (rgbMB.Checked)
            {
                matrizB.ExcluirMatriz();
                dgvB.Rows.Clear();
                rgbMB.Checked = false;
            }
        }     
        private void btnMultiplicarMatrizes_Click(object sender, EventArgs e)
        {
            if (matrizA == null || matrizB == null)
            {
                MessageBox.Show("Para multiplicar matrizes é necessário duas desta", "Erro ao multiplicar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            if (matrizA.NumLinhas != matrizB.NumColunas || matrizA.NumColunas != matrizB.NumLinhas)
                MessageBox.Show("O número de linhas de uma precisa ser igual ao número de colunas da outra matriz", "Erro ao multiplicar matrizes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                AjustarDataGridView(dgvResultado, dgvA.RowCount, dgvB.ColumnCount);
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
        

        private void dgvB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ExibirInformacoes(matrizB, e.RowIndex, e.ColumnIndex);
        }

        private void dgvA_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView qual = (DataGridView)sender;
            numeroUpDown.Value = Convert.ToDecimal(qual[e.ColumnIndex, e.RowIndex].Value) ;
            btnAlterar.PerformClick();
        }

        private void ExibirInformacoes(ListaCruzada qualMatriz, int l, int c)
        {
            txtColuna.Text = c + "";
            txtLinha.Text = l + "";
            numeroUpDown.Text = qualMatriz.ValorDe(l, c) + "";
        }

        private void IniciarControles()  //Método usado para ativar os botões para uso, após a leitura de pelo menos uma das listas
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

        private void AjustarDataGridView(DataGridView qualDgv, int numLinhas, int numColunas)  //Método usado para adaptar o tamanho do DataGridView à matriz lida, que recebe como parâmetro a matriz na qual os dados devem ser inseridos e o DataGridView em que a matriz deve ser exibida após ser preenchida
        {
            qualDgv.ColumnCount = numColunas;  //Ajusta o número de colunas do dgv
            qualDgv.RowCount = numLinhas;      //Ajusta o número de linhas do dgv

            int tamanhoCelula = qualDgv.Height / numLinhas;

            foreach (DataGridViewRow linha in qualDgv.Rows)
                linha.Height = linha.MinimumHeight = tamanhoCelula;
           }

        private void LerMatriz(ref ListaCruzada lista, DataGridView dgv, RadioButton qualRb)  //Método para ler um arquivo e construir uma matriz a partir de seus dados
        {
            if (dlgAbrir.ShowDialog() == DialogResult.OK)                 //Verifica se o 'openFileDialog' foi aberto corretamente             
            {
                var arquivo = new StreamReader(dlgAbrir.FileName);        //Seleção do arquivo pelo usuário
                string numeroLinhaColuna = arquivo.ReadLine();            //variável do tipo string que guarda a linha inteira lida
                lista = new ListaCruzada(int.Parse(numeroLinhaColuna.Substring(0, 5)), int.Parse(numeroLinhaColuna.Substring(5, 5))); //Instanciação da matriz passada como parâmetro com os valores lidos da primeira linha do arquivo, que guarda o número de linhas e de colunas que a matriz deve ter

                AjustarDataGridView(dgv, lista.NumLinhas, lista.NumColunas);    //Chama o método que adapta o DataGridView escolhido ao tamanho da matriz lida
                IniciarControles();                      //Habilitar os botões que agora(após a instanciação da matriz) podem ser selecionados

                bool teveErro = false;                   //Variável do tipo boolean que é usada para informar o programa e o usuário na ocorrência de algum erro 

                while (!arquivo.EndOfStream)             //Loop que garante que todas as linhas do arquivo serão lidas
                {
                    Celula lida = Celula.LerRegistro(arquivo);  //Uma nova célula é criada a partir dos dados lidos, por meio do método da classe Celula LerRegistro, que se encarrega de criar uma nova celula ao ler uma linha por vez

                    if (lida.Coluna < 0 || lida.Linha < 0 || lida.Linha > lista.NumLinhas || lida.Coluna > lista.NumColunas)   //Caso os índices de posicionamento da célula seja inválido, a celula não será criada e o erro aparecerá para o usuário 
                    {
                        teveErro = true;
                        txtErro.Items.Add($"({lida.Linha}, {lida.Coluna})");
                        continue;
                    }

                    lista.InserirElemento(lida.Linha, lida.Coluna, lida.Valor);   //Caso não haja erro, a célula será criada  e o loop continuará
                }

                if (teveErro)         //Em caso de erro, uma mensagem será apresentada ao usuário 
                    lblErro.Text = "Células com index não suportados pela matriz: "; //Mensagem de erro específica à invalidação do posicionamento da célula lida 

                arquivo.Close();      //Depois do fim da leitura do arquivo, o arquivo é fechado
                lista.Listar(dgv);    //Listagem da matriz lida no dgv escolhido

                qualRb.Enabled = true;
                qualRb.Checked = true;
            }
        }
    }
}
