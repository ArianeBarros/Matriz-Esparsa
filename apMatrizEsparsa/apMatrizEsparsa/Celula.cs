using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace apMatrizEsparsa
{
    class Celula
    {
        int coluna, linha;  //Atributos de cada célula, que guardam suas coordenadas, respectivamente, sua coluna e sua linha
        double valor;       //Variável que guarda o valor de uma célula
        Celula direita, abaixo;  //Ponteiros que representam(apontam) as células, respectivamente, à direita e abaixo à célula de referência

        public Celula(int l, int c, double v, Celula d, Celula a)  //Construtor padrão que instancia uma célula com suas coordenadas, valor e ponteiros
        {
            this.linha = l; //Atribuição aos atributos da classe com os valores passados por parâmetro
            this.coluna = c;
            this.valor = v;
            this.direita = d;
            this.abaixo = a;
        }

        public static Celula LerRegistro(StreamReader arq)  //Método responsável por ler uma linha do arquivo(passado por parâmetro) escolhido pelo usuário e atribuir os valores da linha à uma nova célula
        {

            Celula cel = null;  //Declaração de uma nova célula
            if (!arq.EndOfStream)  //Verifica s o arquivo já acabou, ou seja, se todas as linhas já foram lidas
            {
                string linha = arq.ReadLine();  //Atribuímos à variável linha do tipo string todo o conteúdo lido na linha atual do arquivo
                string[] conteudo = linha.Split(',');  //Dividimos em três divisões o conteúdo lido, respectivamente em: linha, coluna e valor
                cel = new Celula(int.Parse(conteudo[0]), int.Parse(conteudo[1]), double.Parse(conteudo[2]), null, null); //Após a separação. cada posição do vetor conteúdo contém uma das informações necessárias para instanciar uma nova célula
                if (conteudo.Length == 4)
                {
                    double inteiro = double.Parse(conteudo[2]);
                    int dec = int.Parse(conteudo[3]);
                    if (inteiro < 0)
                        cel.Valor -= (dec * 0.1);
                    else
                        cel.valor += (dec * 0.1);
                }                    
            }

            return cel;  //Retornamos a celula criada a partir da leitura da linha do arquivo
        }

        public int Coluna { get => coluna; }  //Propriedade que retorna a coluna respectiva à célula usada como referência
        public int Linha { get => linha; }     //Propriedade que retorna a linha respectiva à célula usada como referência
        public double Valor { get => valor; set => valor = value; }   //Propriedade que retorna o valor respectivo à célula usada como referência

        public Celula Direita { get => direita; set => direita = value; }   //Propriedade que retorna a célula à direita da célula usada como referência
        public Celula Abaixo { get => abaixo; set => abaixo = value; }      //Propriedade que retorna a célula abaixo da célula usada como referência
    }
}
