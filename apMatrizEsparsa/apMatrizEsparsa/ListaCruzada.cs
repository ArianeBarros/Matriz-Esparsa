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

        public ListaCruzada(int linhas, int colunas) //construtor que cria uma lista cruzada com tamanho já definidos
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


        public int Qtd { get => qtdValores; }              //Propriedade que retorna a quantidade de valores da matriz
        public int NumLinhas { get => numLinhas; }         //Propriedade que retorna o número de linhas da matriz
        public int NumColunas { get => numColunas; }       //Propriedade que retorna o número de colunas da matriz
        public Celula Cabeca { get => cabeca; }            //Propriedade que retorna a célula inicial/de referência da matriz

        public void InserirElemento(int l, int c, double v)  //Método que insere um novo valor na matriz, de acordo com os índices de linha, coluna e valor passados por parâmetro
        {
            if (l < 0 || l > numLinhas)    //Verifica se a linha passada por parâmetro é válida
                throw new Exception("Index de linha inválido");
            if (c < 0 || c > numColunas)   //Verifica se a coluna passada por parâmetro é válida
                throw new Exception("Index de coluna inválido");

            if (v != 0)  //Se o valor passado por parâmetro for zero, não devemos criar um novo elemento
            {
                if (Existe(l, c))    //Caso o elemento já exista, apenas mudamos seu valor para o passado como parâmetro
                    atualColuna.Abaixo.Valor = v;
                else                //Caso não exista, criamos uma nova célula
                { 
                    Celula novaCelula = new Celula(l, c, v, null, null); //Instanciamos uma nova célula

                    novaCelula.Abaixo = atualColuna.Abaixo;              //Mudamos o posicionamento dos ponteiros para que apontem para a nova célula e essa aponte para a próxima
                    atualColuna.Abaixo = novaCelula;

                    novaCelula.Direita = atualLinha.Direita;
                    atualLinha.Direita = novaCelula;

                    qtdValores++;                 //Somamos 1 ao número de valores da lista após a inclusão
                }
            }
        }

        public double ValorDe(int l, int c)                          //Método que retorna o valor da célula na coordenadas passadas por parâmetro, caso exista, caso não exista retorna 0
        {
            if (l < 0 || l > numLinhas)          //Verifica se a linha é válida  
                throw new Exception("Index de linha inválido");
            if (c < 0 || c > numColunas)         //Verifica se a coluna é válida
                throw new Exception("Index de coluna inválido");

            if (Existe(l, c))          //Caso exista um item na lista nessa posição, retornamos seu valor
                return atualColuna.Abaixo.Valor;
            else                       //Caso não exista, retornamos zero
                return 0;
        }

        protected bool Existe(int l, int c)      //Método que verifica se uma célula em determinada posição existe ou não
        {
            if (l < 0 || l > numLinhas)          //Verifica se a linha é válida
                throw new Exception("Index de linha inválido");
            if (c < 0 || c > numColunas)         //Verifica se a coluna é válida
                throw new Exception("Index de coluna inválido");

            atualLinha = cabeca;    //Posiciona o atualLinha no ponto de referencia para o começo da lista
            atualColuna = cabeca;   //Posiciona o atualColuna no ponto de referencia para o começo da lista

            while (atualLinha.Linha < l && atualLinha.Abaixo != atualLinha)   //Loops usados para percorrer a lista e posicionar os ponteiros no local correto
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
            if (procurada.Coluna != c || procurada.Linha != l) //Verifica se existe um item nessa posiçao, caso não exista, as coordenadas referentes a este não baterão com as passadas por parâmetro
                return false;

            return true;
        }

        public void Listar(DataGridView dgv)                         //Método responsável por preencher o DataGridView passado por parâmetro com os elementos da lista
        {
            if (dgv == null)
                throw new Exception("Parametros inválidos");

            for (int l = 0; l < numLinhas; l++)                     //Percorre a lista e insere(caso exista) a célula atual
            {
                for (int c = 0; c < numColunas; c++)
                {
                    if (Existe(l, c))  //Caso exista um elemento nas coordenadas atuais, este deve ser exibido no DataGridView passado por parâmetro
                        dgv[c, l].Value = atualColuna.Abaixo.Valor;
                    else               //Caso não exista, o valor zero deve ser exibido em seu lugar
                        dgv[c, l].Value = 0;
                }
            }
        }

        public bool Excluir(int l, int c)   //Método que exclui da lista um elemento cuja posição é passada por parâmetro. Se for possível excluir o elemento, retornamos true, caso não seja possível retornamos false.
        {
            if (l < 0 || l > numLinhas)                  //Verifica se a linha passada como parâmetro é válida
                throw new Exception("Index de linha inválido");
            if (c < 0 || c > numColunas)                //Verifica se a coluna passada como parâmetro é válida
                throw new Exception("Index de coluna inválido");

            if (Existe(l, c))               //Verifica se existe uma célula nessa posição, caso exista, a exclusão é possível
            {
                Celula desejada = atualLinha.Direita;

                atualColuna.Abaixo = desejada.Abaixo;   //Mudamos as posições dos ponteiros de modo que nenhum aponte para a cécula escolhida, assim perdendo sua referência e deixando de existir
                atualLinha.Direita = desejada.Direita;
                qtdValores--;                           //Após a exclusão, diminuimos 1 na quantidade de elementos da lista

                return true;
            }

            return false;
        }

        public ListaCruzada SomarMatrizes(ListaCruzada listaB)                      //Método que soma as duas listas sendo exibidas para o usuário
        {
            if (listaB == null)
                throw new Exception("Parametros inválidos");

            if (this.NumColunas != listaB.NumColunas || this.NumLinhas != listaB.NumLinhas)
                throw new Exception("Para somar matrizes, ambas devem ter a mesma dimensão");

            ListaCruzada soma = new ListaCruzada(numLinhas, numColunas); //Declaramos e instanciamos uma lista local, que guardará o resultado da soma das duas outras listas

            for (int l = 0; l < numLinhas; l++)    //Percorremos as lista, somando item por item das listas e inserindo o resultado na lista
            {
                for (int c = 0; c < numColunas; c++)
                {
                    double somaValores = ValorDe(l, c) + listaB.ValorDe(l, c); //;Variavel que guarda a soma
                    if(somaValores != 0)  //Caso a soma não seja zero, devemos inserir o novo elemento na lista soma, caso seja zero, o elemento não deve ser inserido
                        soma.InserirElemento(l,c, somaValores);
                }
            }

            return soma;
        }
        public ListaCruzada MultiplicarMatrizes(ListaCruzada listaB)        //Método que multiplica as duas listas sendo exibidas para o usuário
        {
            if (listaB == null)      //Caso a lista passada como parâmetro não seja instanciada, não multiplicamos e lançamos uma exceção
                throw new Exception("Parametros inválidos");

            if (this.NumLinhas != listaB.NumColunas) //?
                throw new Exception("Para multiplicar matrizes, o número de linhas de uma deve ser igual ao número de colunas da outra");

            ListaCruzada produto = new ListaCruzada(numLinhas, listaB.numColunas); //Declaramos e instanciamos uma nova lista local, que será o resultado da multiplicação das listas
            double resultado = 0;

            for (int l = 0; l < numLinhas; l++)   //Percorremos as lista, multiplicando item por item das listas e inserindo o resultado na lista produto
            {
                for (int c = 0; c < listaB.NumColunas; c++) //Multiplicamos os valores de todas as células de uma linha, percorrendo cada coluna
                {
                    resultado = 0; //Zeramos a variável resultado, para que possa armazenar a multiplicação da próxima linha
                    for (int col = 0; col < numColunas; col++)
                    {
                        resultado += ValorDe(l, col) * listaB.ValorDe(col, c);  //Atribuição da multiplicação à variável resultado
                    }
                    if (resultado != 0)
                        produto.InserirElemento(l, c, resultado);      //Insere um novo elemento na lista produto, com o valor da multiplicação                
                }
            }            

            return produto;
        }

        public void ExcluirMatriz()                      //Método que exclui todos os elementos da lista, deixando de exibi-la para o usuário
        { 
            cabeca = null;  //Zeramos todos os seus atributos, pois não guardam mais nenhum valor
            numColunas = 0;
            numLinhas = 0;
            qtdValores = 0;
        }

        public bool EstaDesalocada                           //Propriedade que retorna se o ponteiro cabeca(ponto de referência para a lista) está apontando para o lugar certo
        {
            get => cabeca == null;                           //Retorna se a igualdade (se a cabeca da lista é nula) é falsa ou verdadeira
        }


        public void SomarColuna(double v, int qualColuna)    //Método de somar todos os itens de determinada coluna com o valor passado por parâmetro
        {
            if (qualColuna < 0 || qualColuna > numColunas)   //Verifica se a coluna indicada existe
                throw new Exception("Index de coluna inválido");  //Caso não exista, lança um erro

            if(v != 0)   //Verifica se o valor escolhido para a soma pelo usuário é zero, caso seja, não somamos os itens pois não alterará seu valor
            {
                for (int i = 0; i < NumLinhas; i++)             //Percorre linha por linha, somando os itens da coluna escolhida com o valor desejado
                {
                    if (ValorDe(i, qualColuna) == 0)            //Caso a célula atual não exista, ela é inserida na lista e seu valor(0) somado com o número escolhido
                        InserirElemento(i, qualColuna, v);      //Chama o método InserirElemento e passa por parametro as coordenadas da célula atual(que temos certeza que existe) e seu valor a ser alterado após a soma
                    else
                    {
                        Celula desejada = atualLinha.Direita;    
                        if (desejada.Valor + v == 0)  //Caso após a soma a célula fique com valor igual a zero, esta deve ser excluida
                            Excluir(i, qualColuna);   //Chama o método excluir passando por parâmetro as coordenadas da célula atual
                        else
                            InserirElemento(i, qualColuna, v + desejada.Valor);  //Caso o resultado da soma seja diferente de zero, chamamos o InserirElemento, que verifica se a célula existe e, nesse caso já que existe, altera seu valor pelo passado como parâmetro
                    }
                }
            }
        }
        
    }

}
