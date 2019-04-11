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
        ListaCruzada matrizA;  //Declaração da lista A
        ListaCruzada matrizB;  //Declaração da lista B

        public frmMatriz()
        {
            InitializeComponent();
        }

        private void btnLerMatrizA_Click(object sender, EventArgs e)
        {
            LerMatriz(ref matrizA, dgvA, rgbMA);    //Chama método LerMatriz que instancia e preenche a matriz passada por parâmetro, exibindo ela no DataGridView também passado por parametro
        }

        private void btnLerMatrizB_Click(object sender, EventArgs e) //Método chamado para a leitura da segunda matriz
        {
            LerMatriz(ref matrizB, dgvB, rgbMB); //Passando como referência a declaração da segunda lista cruzada
        }


        private void btnSomarMatrizes_Click(object sender, EventArgs e)  //Método chamado se o usuário deseja somar as duas matizes a ele apresentadas 
        {
            if (matrizA == null || matrizB == null) //Caso o usuário não tenha escolhido duas matrizes, não será possível soma-las, então uma mensagem de erro é mostrada ao usuário 
                MessageBox.Show("Para somar matrizes é necessário duas desta", "Erro ao somar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            if (matrizA.EstaDesalocada || matrizB.EstaDesalocada)  //Verifica se as duas matrizes estão bem organizadas(com os ponteiros funcionando corretamente)
                MessageBox.Show("Matriz desalocada", "Erro ao multiplicar matrizes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            if (matrizA.NumLinhas != matrizB.NumLinhas || matrizA.NumColunas != matrizB.NumColunas)  //Se as duas matrizes
                MessageBox.Show("Para somar matrizes, ambas precisam ter a mesma dimensão", "Erro ao somar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                AjustarDataGridView(dgvResultado, dgvA.RowCount, dgvA.ColumnCount); //Ajustamos o tamanho do dgvResultado ao tamanho da matriz que nele será exibida após a soma
                ListaCruzada soma = matrizA.SomarMatrizes(matrizB); //Chama o método da classe ListaCruzada e atribui seu retorno à nova lista criada, soma
                soma.Listar(dgvResultado);  //Após a soma feita, listamos o resultado para o usuário
            }
        }

        private void btnSomarColuna_Click(object sender, EventArgs e)    //Método que soma todos os itens de uma coluna com o número escolhido pelo usuário no valorUpDown, na coluna indicada no cbxColuna
        {
            if (cbxColuna.SelectedItem == null) //Verifica se o usuário escolheu uma coluna para manipular, caso não tenha esoclhido, não é possível realizar a operação, portanto lançamos uma exceção avisando o usuário do erro
                MessageBox.Show("Selecione uma coluna", "Erro ao somar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            if (rgbMA.Checked)   //Verifica se o usuário quer manipular a matriz A
            {
                matrizA.SomarColuna(int.Parse(valorUpDown.Value.ToString()), Convert.ToInt32(cbxColuna.SelectedItem));  //Chama o método da ListaCruzada com os parâmetros do número a somar e a coluna escolhidos pelo usuário
                matrizA.Listar(dgvA);  //Lista a matriz A após ser alterada
            }
            else                //Verifica se o usuário quer manipular a matriz B
            {
                matrizB.SomarColuna(int.Parse(valorUpDown.Value.ToString()), Convert.ToInt32(cbxColuna.SelectedItem));  //Chama o método da ListaCruzada com os parâmetros do número a somar e a coluna escolhidos pelo usuário
                matrizB.Listar(dgvB); //Lista a matriz B após ser alterada
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)  //Método que exclui o elemento selecionado da lista
        {
            if (int.Parse(linhaUpDown.Text) < 0 || int.Parse(colunaUpDown.Text) < 0)  //Verifica se as coordenadas adquiridas são válidas
                MessageBox.Show("Index inválido", "Erro ao excluir", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            if (rgbMA.Checked)   //Verifica se o usuário quer manipular a matriz A
            {
                if (matrizA.Excluir(int.Parse(linhaUpDown.Text), int.Parse(colunaUpDown.Text)))
                {
                    matrizA.Listar(dgvA);    //Exibimos a lista após a exclusão do elemento
                    numeroUpDown.Text = "0"; //Após a exclusão, já que a célula não existe mais, deve ser exibida com o valor zero
                }
                else
                    txtErro.Text = "Erro ao excluir!";  //Em caso de algum erro, indicamos o usuário sobre a existência de uma falha
            }
            else                 //Verifica se o usuário quer manipular a matriz B
            {
                if (matrizB.Excluir(int.Parse(linhaUpDown.Text), int.Parse(colunaUpDown.Text)))  //Verifica se a exclusão deu certo
                {
                    matrizB.Listar(dgvB);    //Exibimos a lista após a exclusão do elemento
                    numeroUpDown.Text = "0"; //Após a exclusão, já que a célula não existe mais, deve ser exibida com o valor zero
                }
                else
                    txtErro.Text = "Erro ao excluir!";  //Em caso de algum erro, indicamos o usuário sobre a existência de uma falha
            }
        }

        private void dgvA_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ExibirInformacoes(matrizA, e.RowIndex, e.ColumnIndex);
            if (dgvB.SelectedCells.Count != 0)
                dgvB.ClearSelection();
        }

        private void btnAlterar_Click(object sender, EventArgs e)  //Método que altera o valor da célula selecionada pelo usuário
        {  
            if (int.Parse(linhaUpDown.Text) < 0 || int.Parse(colunaUpDown.Text) < 0)
                MessageBox.Show("Index inválido", "Erro ao alterar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            if (rgbMA.Checked)   //Verifica se o usuário deseja manipular a matriz A
            { 
                matrizA.InserirElemento(int.Parse(linhaUpDown.Text), int.Parse(colunaUpDown.Text), double.Parse(numeroUpDown.Text)); //Chama o método InserirElemento da classe ListaCruzada que, caso a célula exista, apenas altera o seu valor de acordo com o parâmetro passado
                matrizA.Listar(dgvA);   //Exibe a matrizA após a alteração
            }
            else                //Verifica se o usuário deseja manipular a matriz B
            {
                matrizB.InserirElemento(int.Parse(linhaUpDown.Text), int.Parse(colunaUpDown.Text), double.Parse(numeroUpDown.Text)); //Chama o método InserirElemento da classe ListaCruzada que, caso a célula exista, apenas altera o seu valor de acordo com o parâmetro passado
                matrizB.Listar(dgvB);  //Exibe a matrizB após a alteração
            }  
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (int.Parse(linhaUpDown.Text) < 0 || int.Parse(colunaUpDown.Text) < 0)   //Se o índice das coordenadas escolhidas pelo usuário for inválido, enviamos um mensagem de erro ao usuário
                MessageBox.Show("Index do valor inválido", "Erro ao inserir", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            if (rgbMA.Checked)   //Verifica se o usuário deseja manipular a matriz A
            {

                matrizA.InserirElemento(int.Parse(linhaUpDown.Text), int.Parse(colunaUpDown.Text), double.Parse(numeroUpDown.Text));
                matrizA.Listar(dgvA);   //Após a nova inclusão, exibimos a matrizA alterada no dgvA
            }
            else                //Verifica se o usuário deseja manipular a matriz B
            {
                matrizB.InserirElemento(int.Parse(linhaUpDown.Text), int.Parse(colunaUpDown.Text), double.Parse(numeroUpDown.Text));
                matrizB.Listar(dgvB);   //Após a nova inclusão, exibimos a matrizB alterada no dgvB
            }
        }

        private void btnLiberarMatriz_Click(object sender, EventArgs e)   //Método que exclui todos os itens da matriz, deixando de exibi-la para o usuário
        {
            if (rgbMA.Checked)   //Verifica se o usuário deseja manipular a matrizA
            {
                matrizA.ExcluirMatriz();  //Chama o método que irá realizar a exclusão na classe ListaCruzada
                dgvA.Rows.Clear();        //Limpa o DataGridView em que a matriz estava antes sendo exibida
                rgbMA.Enabled = false;    //Já que nenhuma matriz está sendo exibida no dgvA, o usuário não pode seleciona-la
                 
                if (matrizB != null)     //Portanto, selecionamos automaticamente o rgbMB, já que é sua única opção(apenas se alguma matriz estiver sendo exibida nele)
                    rgbMB.Checked = true;
            }
            else 
            if (rgbMB.Checked)   //Verifica se o usuário deseja manipular a matrizB
            {
                matrizB.ExcluirMatriz();   //Chama o método que irá realizar a exclusão na classe ListaCruzada
                dgvB.Rows.Clear();         //Limpa o DataGridView em que a matriz estava antes sendo exibida
                rgbMB.Enabled = false;     //Já que nenhuma matriz está sendo exibida no dgvA, o usuário não pode seleciona-la
                
                if (matrizA != null)       //Portanto, selecionamos automaticamente o rgbMB, já que é sua única opção(apenas se alguma matriz estiver sendo exibida nele)
                    rgbMA.Checked = true;
            }

            colunaUpDown.Minimum = linhaUpDown.Minimum = 0;    

            if (matrizA.EstaDesalocada && matrizB.EstaDesalocada)   //Caso o usuário tiver excluido as duas matrizes,  não pode mais manipular nenhuma delas, portanto todas as opções que lhe permitem altera-las são desabilitadas
            {
                IniciarControles(false); 
                LimparCampos();
            }

        }
        private void btnMultiplicarMatrizes_Click(object sender, EventArgs e)   //Método responsável por multiplicar as linhas e colunas das duas matrizes sendo exibidas
        {
            if (matrizA == null || matrizB == null)  //Nenhuma multiplicação entre matrizes deve ser feita se o usuário não tiver selecionado duas matrizes
                MessageBox.Show("Para multiplicar matrizes é necessário duas desta", "Erro ao multiplicar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            if (matrizA.EstaDesalocada || matrizB.EstaDesalocada) 
                MessageBox.Show("Matriz desalocada", "Erro ao multiplicar matrizes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            if (matrizA.NumLinhas != matrizB.NumColunas || matrizA.NumColunas != matrizB.NumLinhas)    //Verifica se o número de linhas e colunas das matrizes é igual, em caso negativo, nenhuma multiplicação deve ser feita
                MessageBox.Show("O número de linhas de uma precisa ser igual ao número de colunas da outra matriz", "Erro ao multiplicar matrizes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                AjustarDataGridView(dgvResultado, dgvA.RowCount, dgvB.ColumnCount);     //Ajusta o tamanho do dgvResultado de acordo com o tamanho das matrizes(que devem ser iguais)
                ListaCruzada result = matrizA.MultiplicarMatrizes(matrizB);             //Atribuição da matriz resultante à uma nova matiz, que será exibida no dgvResultado
                result.Listar(dgvResultado);                                            //Exibe o resultado no dgvResultado
            }
        }

        private void rgbMA_CheckedChanged(object sender, EventArgs e)  //Ajusta o número máximo de linhas e colunas apresentado como opção para o usuário manipular de acordo com a matriz A
        {
            cbxColuna.Items.Clear();                         
            for (int i = 0; i < matrizA.NumColunas; i++)    //Preenche o cbxColuna com o número certo de colunas que a matriz A tem
                cbxColuna.Items.Add(i + "");

            linhaUpDown.Maximum = matrizA.NumLinhas - 1;    //Preenche o linhaUpDown com o número certo de linhas que a matriz A tem
            colunaUpDown.Maximum = matrizA.NumColunas - 1;  //Preenche o colunaUpDown com o número certo de colunas que a matriz A tem
        }

        private void rgbMB_CheckedChanged(object sender, EventArgs e)   //Ajusta o número máximo de linhas e colunas apresentado como opção para o usuário manipular de acordo com a matriz B
        {
            cbxColuna.Items.Clear();
            for (int i = 0; i < matrizB.NumColunas; i++)    //Preenche o cbxColuna com o número certo de colunas que a matriz B tem
                cbxColuna.Items.Add(i + "");
            linhaUpDown.Maximum = matrizB.NumLinhas - 1;    //Preenche o linhaUpDown com o número certo de linhas que a matriz B tem
            colunaUpDown.Maximum = matrizB.NumColunas - 1;   //Preenche o colunaUpDown com o número certo de colunas que a matriz B tem
        }


        private void dgvB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ExibirInformacoes(matrizB, e.RowIndex, e.ColumnIndex);

            if (dgvA.SelectedCells.Count != 0)
                dgvA.ClearSelection();

        }

        private void dgvA_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView qual = (DataGridView)sender;
            numeroUpDown.Value = Convert.ToDecimal(qual[e.ColumnIndex, e.RowIndex].Value);
            btnAlterar.PerformClick();
        }

        private void ExibirInformacoes(ListaCruzada qualMatriz, int l, int c)
        {
            colunaUpDown.Text = c + ""; //Configura o colunaUpDown para permitir que o usuário escolha apenas colunas que existam na matriz determinada, evitando que algum método receba como parâmetro algum índice fora dos limites
            linhaUpDown.Text = l + "";   //Configura o colunaUpDown para permitir que o usuário escolha apenas linhas que existam na matriz determinada, evitando que algum método receba como parâmetro algum índice fora dos limites
            numeroUpDown.Text = qualMatriz.ValorDe(l, c) + "";  //Recebe o valor de determinada célula, mesmo que esta não exista(neste caso, o método retornará zero), e o exibe para o usuário

            if (qualMatriz == matrizA)   //Seleciona automaticamente o rgbMA caso seja a matrizA que esteja sendo manipulada
            {
                rgbMA.Enabled = true;
                rgbMA.Checked = true;
            }
            else                        //Seleciona automaticamente o rgbMA caso seja a matrizA que esteja sendo manipulada
            {
                rgbMB.Enabled = true;
                rgbMB.Checked = true;
            }             
        }

        private void IniciarControles(bool estado)  //Método usado para ativar os botões para uso, após a leitura de pelo menos uma das listas
        {
            btnIncluir.Enabled = estado;
            btnDeletar.Enabled = estado;
            btnAlterar.Enabled = estado;
            btnSomarColuna.Enabled = estado;
            btnExcluirMatriz.Enabled = estado;

            btnSomarMatrizes.Enabled = estado;
            btnMultiplicarMatrizes.Enabled = estado;

            linhaUpDown.Enabled = estado;
            colunaUpDown.Enabled = estado;

            numeroUpDown.Enabled = estado;
            valorUpDown.Enabled = estado;
            cbxColuna.Enabled = estado;
        }

        private void AjustarDataGridView(DataGridView qualDgv, int numLinhas, int numColunas)  //Método usado para adaptar o tamanho do DataGridView à matriz lida, que recebe como parâmetro a matriz na qual os dados devem ser inseridos e o DataGridView em que a matriz deve ser exibida após ser preenchida
        {
            qualDgv.ColumnCount = numColunas;  //Ajusta o número de colunas do dgv
            qualDgv.RowCount = numLinhas;      //Ajusta o número de linhas do dgv

            int tamanhoCelula = qualDgv.Height / numLinhas; 

            foreach (DataGridViewRow linha in qualDgv.Rows)   //Configura o tamanho de todas as células para que fiquem uniformizadas
                linha.Height = linha.MinimumHeight = tamanhoCelula;
        }

        private void LerMatriz(ref ListaCruzada lista, DataGridView dgv, RadioButton qualRb)  //Método para ler um arquivo e construir uma matriz a partir de seus dados
        {
            try
            {
                if (dlgAbrir.ShowDialog() == DialogResult.OK)                 //Verifica se o 'openFileDialog' foi aberto corretamente             
                {
                    txtErro.Items.Clear();
                    var arquivo = new StreamReader(dlgAbrir.FileName);        //Seleção do arquivo pelo usuário
                    string numeroLinhaColuna = arquivo.ReadLine();            //variável do tipo string que guarda a linha inteira lida
                    lista = new ListaCruzada(int.Parse(numeroLinhaColuna.Substring(0, 5)), int.Parse(numeroLinhaColuna.Substring(5, 5))); //Instanciação da matriz passada como parâmetro com os valores lidos da primeira linha do arquivo, que guarda o número de linhas e de colunas que a matriz deve ter

                    AjustarDataGridView(dgv, lista.NumLinhas, lista.NumColunas);    //Chama o método que adapta o DataGridView escolhido ao tamanho da matriz lida
                    IniciarControles(true);                      //Habilitar os botões que agora(após a instanciação da matriz) podem ser selecionados

                    bool teveErro = false;                   //Variável do tipo boolean que é usada para informar o programa e o usuário na ocorrência de algum erro 

                    while (!arquivo.EndOfStream)             //Loop que garante que todas as linhas do arquivo serão lidas
                    {
                        Celula lida = Celula.LerRegistro(arquivo);  //Uma nova célula é criada a partir dos dados lidos, por meio do método da classe Celula LerRegistro, que se encarrega de criar uma nova celula ao ler uma linha por vez

                        if (lida.Coluna < 0 || lida.Linha < 0 || lida.Linha >= lista.NumLinhas || lida.Coluna >= lista.NumColunas)   //Caso os índices de posicionamento da célula seja inválido, a celula não será criada e o erro aparecerá para o usuário 
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
                    ExibirInformacoes(lista, 0, 0);
                    if (lista == matrizA)
                        dgvB.ClearSelection();
                    else
                        dgvA.ClearSelection();
                    qualRb.Checked = true;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Selecione um arquivo texto correto", "Erro na leitura da matriz", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void dgvB_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            ExibirInformacoes(matrizB, e.RowIndex, e.ColumnIndex);
        }

        private void dgvA_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            ExibirInformacoes(matrizA, e.RowIndex, e.ColumnIndex);
        }

        private void dgvB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
                btnDeletar.PerformClick();
        }

        private void LimparCampos()
        {
            numeroUpDown.Value = 0;
            linhaUpDown.Value = 0;
            colunaUpDown.Value = 0;
            cbxColuna.SelectedIndex = -1;
            valorUpDown.Value = 0;
        }

        private void frmMatriz_Load(object sender, EventArgs e)
        {
        }
    }
}
